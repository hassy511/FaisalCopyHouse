using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ERP_Maaz_Oil.Forms
{
    public partial class frmSalesReturn_New : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        int id = 0;
        bool isEdit = false;
        public frmSalesReturn_New()
        {
            InitializeComponent();
        }

        private void GenerateSRNumber()
        {
            classHelper.query = "SELECT ISNULL(COUNT(SALE_RETURN_MASTER_ID),0)+1 FROM SALE_RETURN_MASTER";
            lblInvoice.Text = "SR-" + classHelper.GetMaxValue(classHelper.query) + "-" + DateTime.Now.Year;
        }
        private void LoadGrid()
        {
            classHelper.query = @"SELECT A.SALE_RETURN_MASTER_ID AS [ID],A.INVOICE_NO AS [INVOICE #],
            A.[DATE],B.COA_NAME AS [CUSTOMER],A.[DESCRIPTION],
            A.CUSTOMER_ID
            FROM SALE_RETURN_MASTER A
            INNER JOIN COA B ON A.CUSTOMER_ID = B.COA_ID
            ORDER BY SALE_RETURN_MASTER_ID DESC";
            classHelper.LoadGrid(grdSearch, classHelper.query);
        }
        private void LoadCustomers()
        {
            classHelper.LoadCustomers(cmbCustomer);
        }
        private void LoadMaterials()
        {
            classHelper.LoadRawMaterials(cmbItem);
        }
        private void LoadProducts()
        {
            classHelper.LoadProducts(cmbItem);
        }

        private void Clear()
        {
            GenerateSRNumber();
            dtpDate.Value = DateTime.Now;
            cmbCustomer.SelectedIndex = 0;
            txtDescription.Clear();
            cmbItem.SelectedIndex = 0;
            txtQty.Text = "0";
            txtRate.Text = "0";
            txtTotal.Text = "0";
            txtSearch.Clear();
            rdbProduct.Checked = true;
            id = 0;
            isEdit = false;
            grdItems.Rows.Clear();
        }

        private void Save()
        {
            if (cmbCustomer.SelectedIndex == 0)
            {
                classHelper.ShowMessageBox("Customer is not selected, please select Customer.", "Warning");
                cmbCustomer.Focus();
            }
            else if (grdItems.Rows.Count <= 0)
            {
                classHelper.ShowMessageBox("Add Products.", "Warning");
                cmbItem.Focus();
            }
            else
            {
                char itemType = 'P';
                if (rdbRaw.Checked == true)
                {
                    itemType = 'R';
                }

                string masterId = id.ToString();
                if (id.ToString().Equals("0"))
                {
                    masterId = "(SELECT MAX(SALE_RETURN_MASTER_ID) FROM SALE_RETURN_MASTER)";
                }

                classHelper.query = @"BEGIN TRY 
                             BEGIN TRANSACTION ";

                classHelper.query += @"IF EXISTS (select SALE_RETURN_MASTER_ID from SALE_RETURN_MASTER WHERE SALE_RETURN_MASTER_ID ='" + id + @"') 
                    BEGIN
                        UPDATE SALE_RETURN_MASTER SET DATE = '" + dtpDate.Value.ToString() + "',CUSTOMER_ID = '" + cmbCustomer.SelectedValue.ToString() + @"',
                        DESCRIPTION = '" + classHelper.AvoidInjection(txtDescription.Text) + @"',
                        MODIFICATION_DATE = GETDATE(),MODIFIED_BY = '" + Classes.Helper.userId + @"' WHERE SALE_RETURN_MASTER_ID = '" + id + @"';
                    END
                    ELSE
                    BEGIN
                        INSERT INTO SALE_RETURN_MASTER (DATE,CUSTOMER_ID,DESCRIPTION,CREATION_DATE,CREATED_BY,INVOICE_NO) 
                        VALUES ('" + dtpDate.Value.ToString() + "','" + cmbCustomer.SelectedValue.ToString() + @"',
                        '" + classHelper.AvoidInjection(txtDescription.Text) + @"',
                        GETDATE(),'" + Classes.Helper.userId + "','" + lblInvoice.Text + @"')
                    END
                    
                    DELETE FROM LEDGERS WHERE REF_ID = " + id + @" AND ENTRY_OF = 'SALES RETURN'
                    
                    INSERT INTO LEDGERS(DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
                    VALUES('" + dtpDate.Value.ToString() + "','" + cmbCustomer.SelectedValue.ToString() + "'," + masterId + ",'SALES RETURN','" + lblInvoice.Text + @"',
                    0,'" + (Convert.ToDecimal(txtTotal.Text))  + "','S.R # " + lblInvoice.Text + ")','" + Classes.Helper.userId + @"',GETDATE(),1);
                    
                    INSERT INTO LEDGERS(DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
                    VALUES('" + dtpDate.Value.ToString() + "','" + Classes.Helper.salesReturnId + "'," + masterId + ",'SALES RETURN','" + lblInvoice.Text + @"',
                    '" + (Convert.ToDecimal(txtTotal.Text)) + "',0,'S.I # " + lblInvoice.Text + ")','" + Classes.Helper.userId + @"',GETDATE(),1);";

                classHelper.query += @"DELETE FROM SALE_RETURN_DETAIL WHERE SALE_RETURN_MASTER_ID = '" + id + @"'";

                foreach (DataGridViewRow rows in grdItems.Rows)
                {
                    classHelper.query += @"INSERT INTO SALE_RETURN_DETAIL (SALE_RETURN_MASTER_ID,ITEM_TYPE,ITEM_ID,QTY,RATE) VALUES 
                    (" + masterId + ",'" + rows.Cells["itemType"].Value.ToString() + "','" + rows.Cells["itemId"].Value.ToString() + @"',
                        '" + rows.Cells["itemQty"].Value.ToString() + @"','" + rows.Cells["rate"].Value.ToString() + @"');";
                }

                classHelper.query += @" DELETE FROM MATERIAL_ITEM_LEDGER WHERE REF_NO = '" + id + @"' AND ENTRY_FROM = 'SALES RETURN';";

                classHelper.query += @" DELETE FROM PRODUCT_ITEM_LEDGER WHERE REF_NO = '" + id + @"' AND ENTRY_FROM = 'SALES RETURN';";

                foreach (DataGridViewRow rows in grdItems.Rows)
                {
                    if (rows.Cells["itemType"].Value.ToString().Equals("R"))
                    {
                        classHelper.query += @" INSERT INTO MATERIAL_ITEM_LEDGER 
                        ([DATE],MATERIAL_ID,REF_NO,ENTRY_FROM,STOCK_IN,STOCK_OUT,COST_AMT,SALE_AMT,L_ID,CREATED_BY,CREATION_DATE,COMPANY_ID)
                        VALUES('" + dtpDate.Value.ToString() + "','" + rows.Cells["itemId"].Value.ToString() + "'," + masterId + @",
                            'SALES RETURN','" + rows.Cells["itemQty"].Value.ToString() + @"','0',
                            '0','" + rows.Cells["rate"].Value.ToString() + @"','1','" + Classes.Helper.userId + "',GETDATE(),'1');";
                    }
                    else {
                        classHelper.query += @" INSERT INTO PRODUCT_ITEM_LEDGER 
                        ([DATE],PRODUCT_ID,REF_NO,ENTRY_FROM,STOCK_IN,STOCK_OUT,COST_AMT,SALE_AMT,L_ID,CREATED_BY,CREATION_DATE,COMPANY_ID)
                        VALUES('" + dtpDate.Value.ToString() + "','" + rows.Cells["itemId"].Value.ToString() + "'," + masterId + @",
                            'SALES RETURN','" + rows.Cells["itemQty"].Value.ToString() + @"','0',
                            '0','" + rows.Cells["rate"].Value.ToString() + @"','1','" + Classes.Helper.userId + "',GETDATE(),'1');";
                    }
                }

                classHelper.query += @" COMMIT TRANSACTION 
                        END TRY 
                    BEGIN CATCH 
                            IF @@TRANCOUNT > 0 
                            ROLLBACK TRANSACTION 
                    END CATCH";
                if (classHelper.InsertUpdateDelete(classHelper.query) >= 1)
                {
                    classHelper.ShowMessageBox("Record Saved Sucessfully.", "Information");
                    Clear();
                    LoadGrid();
                }
            }
        }
        
        private void LoadSalesReturnDetails(int saleReturnId)
        {
            classHelper.LoadSalesReturnDetail(grdItems, saleReturnId);
        }
        private void LoadGridData(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.grdSearch.Rows[e.RowIndex];
                id = Convert.ToInt32(row.Cells["ID"].Value.ToString());

                isEdit = true;
                lblInvoice.Text = row.Cells["INVOICE #"].Value.ToString();
                dtpDate.Text = row.Cells["DATE"].Value.ToString();
                cmbCustomer.SelectedValue = row.Cells["CUSTOMER_ID"].Value.ToString();
                txtDescription.Text = row.Cells["DESCRIPTION"].Value.ToString();
                LoadSalesReturnDetails(id);
                TotalSum();
            }
        }
        private void frm_AddGroupAccounts_Load(object sender, EventArgs e)
        {
            GenerateSRNumber();
            LoadGrid();
            LoadCustomers();
            LoadProducts();
        }

        private void txtSEARCH_TextChanged(object sender, EventArgs e)
        {
            (grdSearch.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
            [" + grdSearch.Columns["INVOICE #"].Name.ToString() + "] LIKE '%" + classHelper.AvoidInjection(txtSearch.Text) + "%' OR ["
               + grdSearch.Columns["CUSTOMER"].Name.ToString() + "] LIKE '%" + classHelper.AvoidInjection(txtSearch.Text) + "%'");
            grdSearch.ClearSelection();
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void grdSEARCH_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            grdSearch.Columns["CUSTOMER_ID"].Visible = false;
        }

        private void btnCLEAR_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void grdSEARCH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadGridData(e);
        }
        private void cmbSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtNetWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            classHelper.CheckNumber(e);
        }

        private void rdbRaw_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbProduct.Checked == true)
            {
                LoadProducts();
            }
            else if (rdbRaw.Checked == true)
            {
                LoadMaterials();
            }
        }

        private void rdbProduct_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbProduct.Checked == true)
            {
                LoadProducts();
            }
            else if (rdbRaw.Checked == true)
            {
                LoadMaterials();
            }
        }

        private void grdItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.grdItems.Rows[e.RowIndex];
                cmbItem.SelectedValue = row.Cells["itemId"].Value.ToString();
                txtQty.Text = row.Cells["itemQty"].Value.ToString();
                txtRate.Text = row.Cells["rate"].Value.ToString();
                if (row.Cells["itemType"].Value.ToString().Equals("P"))
                {
                    rdbProduct.Checked = true;
                }
                else {
                    rdbRaw.Checked = true;
                }
                grdItems.Rows.RemoveAt(e.RowIndex);
                TotalSum();
            }
        }
        private void TotalSum()
        {
            try
            {
                txtTotal.Text = grdItems.Rows.Cast<DataGridViewRow>()
                    .Sum(t => Convert.ToDecimal(t.Cells["total"].Value)).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbItem.SelectedIndex == 0)
            {
                classHelper.ShowMessageBox("Item is not selected, please select Item.", "Warning");
                cmbItem.Focus();
            }
            else if (txtQty.Text.Equals("") || txtQty.Text.Equals("0"))
            {
                classHelper.ShowMessageBox("Please add Qty.", "Warning");
                txtQty.Focus();
            }
            else if (txtRate.Text.Equals("") || txtRate.Text.Equals("0"))
            {
                classHelper.ShowMessageBox("Please add Rate.", "Warning");
                txtRate.Focus();
            }
            else
            {
                char itemType = 'P';
                if (rdbRaw.Checked == true) {
                    itemType = 'R';
                }
                string modelNo = "";
                if (rdbProduct.Checked == true)
                {
                    modelNo = classHelper.GetProductCode(Convert.ToInt32(cmbItem.SelectedValue.ToString()));
                }
                grdItems.Rows.Add(cmbItem.SelectedValue.ToString(), itemType,cmbItem.Text, classHelper.AvoidInjection(txtQty.Text),
                classHelper.AvoidInjection(txtRate.Text), Convert.ToDecimal(classHelper.AvoidInjection(txtQty.Text)) *
                Convert.ToDecimal(classHelper.AvoidInjection(txtRate.Text)), modelNo);
                TotalSum();
                cmbItem.SelectedIndex = 0;
                txtQty.Text = "0";
                txtRate.Text = "0";
            }
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            classHelper.CheckNumber(e);
        }

        private void cmbItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txtRate.Text = "0";
            if (cmbItem.SelectedIndex > 0 && rdbProduct.Checked == true)
            {
                txtRate.Text = classHelper.GetProductRate(Convert.ToInt32(cmbItem.SelectedValue.ToString()), "retail");
            }
        }

        private void PrintInvoice()
        {
            classHelper.mds.Tables["SaleInvoice"].Clear();
            foreach (DataGridViewRow rows in grdItems.Rows)
            {
                classHelper.dataR = classHelper.mds.Tables["SaleInvoice"].NewRow();
                classHelper.dataR["InvoiceNo"] = lblInvoice.Text;
                classHelper.dataR["date"] = dtpDate.Value.ToShortDateString();
                classHelper.dataR["customer"] = cmbCustomer.Text;
                classHelper.dataR["description"] = txtDescription.Text;
                classHelper.dataR["itemName"] = classHelper.GetProductName(Convert.ToInt32(rows.Cells["itemid"].Value.ToString()), Convert.ToChar(rows.Cells["itemType"].Value.ToString()));
                classHelper.dataR["qty"] = Convert.ToDouble(rows.Cells["itemQty"].Value.ToString());
                classHelper.dataR["rate"] = Convert.ToDouble(rows.Cells["rate"].Value.ToString());
                classHelper.dataR["amount"] = Convert.ToDouble(rows.Cells["total"].Value.ToString());
                classHelper.dataR["code"] = rows.Cells["modelNo"].Value.ToString();
                classHelper.mds.Tables["SaleInvoice"].Rows.Add(classHelper.dataR);
            }
            classHelper.rpt = new ERP_Maaz_Oil.Forms.Reporting.frmReports();
            classHelper.rpt.GenerateReport("SR_Invoice", classHelper.mds);
            classHelper.rpt.ShowDialog();
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                if (id != 0)
                { PrintInvoice(); }
                else
                {
                    MessageBox.Show("S/R Invoice not found in record or save the invoice first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void cmbCustomer_Leave(object sender, EventArgs e)
        {
            if (id == 0)
            {
                int accountId = cmbCustomer.SelectedValue == null ? 0 : Convert.ToInt32(cmbCustomer.SelectedValue.ToString());
                if (classHelper.GetAccountStatus(accountId).Equals("1"))
                {
                    MessageBox.Show("Account is Deactivate, Please select another account.", "Error");
                    cmbCustomer.Focus();
                }
            }
        }

        private void Delete()
        {

            classHelper.query = @" BEGIN TRY 
                             BEGIN TRANSACTION ";

            classHelper.query += @" DELETE FROM LEDGERS WHERE REF_ID = " + id + @" AND ENTRY_OF = 'SALES RETURN';
            DELETE FROM MATERIAL_ITEM_LEDGER WHERE REF_NO = '" + id + @"' AND ENTRY_FROM = 'SALES RETURN';
            DELETE FROM PRODUCT_ITEM_LEDGER WHERE REF_NO = '" + id + @"' AND ENTRY_FROM = 'SALES RETURN';
            DELETE FROM SALE_RETURN_DETAIL WHERE SALE_RETURN_MASTER_ID = '" + id + @"'            
            DELETE FROM SALE_RETURN_MASTER WHERE SALE_RETURN_MASTER_ID = '" + id + @"'";

            classHelper.query += @" COMMIT TRANSACTION 
                        END TRY 
                    BEGIN CATCH 
                            IF @@TRANCOUNT > 0 
                            ROLLBACK TRANSACTION 
                    END CATCH";

            if (classHelper.InsertUpdateDelete(classHelper.query) >= 1)
            {
                classHelper.ShowMessageBox("Record Deleted Sucessfully.", "Information");
                Clear();
                LoadGrid();
            }
        }

        private void btn_VIEW_VOUCHER_Click(object sender, EventArgs e)
        {
            if (id > 0)
            {
                Delete();
            }
            else
            {
                MessageBox.Show("Please Select any invoice to delete.", "Error");
            }
        }
    }
}

