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
    public partial class frmStockIssuance : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        int id = 0;
        bool isEdit = false;
        public frmStockIssuance()
        {
            InitializeComponent();
        }

        private void GenerateIssuanceNumber()
        {
            //classHelper.query = "SELECT ISNULL(COUNT(ISSUANCE_MASTER_ID),0)+1 FROM ISSUANCE_MASTER";
            classHelper.query = @"SELECT 'ISSUANCE-'+CONVERT(varchar(100),(ISNULL(COUNT(ISSUANCE_MASTER_ID),0)+1))+'-'+CONVERT(varchar(100),YEAR(GETDATE()))+'/'+CONVERT(varchar(100),(ISNULL(MAX(ISSUANCE_MASTER_ID),0)+1))
                                    FROM ISSUANCE_MASTER";
            //lblInvoice.Text = "SI-" + classHelper.GetMaxValue(classHelper.query) + "-" + DateTime.Now.Year;
            lblInvoice.Text = classHelper.GetSaleInvoiceValue(classHelper.query);
        }
        private void LoadGrid()
        {
            classHelper.query = @"SELECT A.ISSUANCE_MASTER_ID AS [ID],A.INVOICE_NO AS [INVOICE #],
            A.[DATE],B.COA_NAME AS [CUSTOMER],A.VEHICLE_NO,A.[DESCRIPTION],
            A.CREDIT_DAYS,A.ACCOUNT_ID
            FROM ISSUANCE_MASTER A
            INNER JOIN COA B ON A.ACCOUNT_ID = B.COA_ID
            ORDER BY ISSUANCE_MASTER_ID DESC";
            classHelper.LoadGrid(grdSearch, classHelper.query);
        }
        private void LoadCustomers()
        {
            classHelper.LoadCustomers(cmbCustomer);
        }
      //  private void LoadMaterials()
       // {
       //   classHelper.LoadRawMaterials(cmbItem);
      //  }
     //   private void LoadProducts()
       // {
        //    classHelper.LoadProducts(cmbItem);
        //}

        private void Clear()
        {
            GenerateIssuanceNumber();
            dtpDate.Value = DateTime.Now;
            cmbCustomer.SelectedIndex = 0;
            txtVehicleNumber.Clear();
            txtCreditDays.Text = "0";
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
                classHelper.ShowMessageBox("Account is not selected, please select Customer.", "Warning");
                cmbCustomer.Focus();
            }
            else if (txtCreditDays.Text.Trim().Equals(""))
            {
                classHelper.ShowMessageBox("Enter Credit Days.", "Warning");
                txtCreditDays.Focus();
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
                    masterId = "(SELECT MAX(ISSUANCE_MASTER_ID) FROM ISSUANCE_MASTER)";
                }

                classHelper.query = @"BEGIN TRY 
                             BEGIN TRANSACTION ";

                classHelper.query += @"IF EXISTS (select ISSUANCE_MASTER_ID from ISSUANCE_MASTER WHERE ISSUANCE_MASTER_ID ='" + id + @"') 
                    BEGIN
                        UPDATE ISSUANCE_MASTER SET DATE = '" + dtpDate.Value.ToString() + "',ACCOUNT_ID = '" + cmbCustomer.SelectedValue.ToString() + @"',
                        VEHICLE_NO = '" + classHelper.AvoidInjection(txtVehicleNumber.Text) + "',DESCRIPTION = '" + classHelper.AvoidInjection(txtDescription.Text) + @"',
                        CREDIT_DAYS = '" + classHelper.AvoidInjection(txtCreditDays.Text) + @"',
                        MODIFICATION_DATE = GETDATE(),MODIFIED_BY = '" + Classes.Helper.userId + @"' WHERE ISSUANCE_MASTER_ID = '" + id + @"';
                    END
                    ELSE
                    BEGIN
                        INSERT INTO ISSUANCE_MASTER (DATE,ACCOUNT_ID,VEHICLE_NO,DESCRIPTION,CREDIT_DAYS,CREATION_DATE,CREATED_BY,INVOICE_NO) 
                        VALUES ('" + dtpDate.Value.ToString() + "','" + cmbCustomer.SelectedValue.ToString() + @"',
                        '" + classHelper.AvoidInjection(txtVehicleNumber.Text) + "','" + classHelper.AvoidInjection(txtDescription.Text) + @"',
                        '" + classHelper.AvoidInjection(txtCreditDays.Text) + "',GETDATE(),'" + Classes.Helper.userId + "','" + lblInvoice.Text + @"')
                    END
                    
                    DELETE FROM LEDGERS WHERE REF_ID = " + id + @" AND ENTRY_OF = 'STOCK ISSUANCE'
                    
                    INSERT INTO LEDGERS(DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
                    VALUES('" + dtpDate.Value.ToString() + "','" + cmbCustomer.SelectedValue.ToString() + "'," + masterId + ",'STOCK ISSUANCE','" + lblInvoice.Text + @"',
                    0,'" + Convert.ToDecimal(txtTotal.Text) + "','" + txtDescription.Text + "','" + Classes.Helper.userId + @"',GETDATE(),1);

                    INSERT INTO LEDGERS(DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
                    VALUES('" + dtpDate.Value.ToString() + "','" + Classes.Helper.purchasesId + "'," + masterId + ",'STOCK ISSUANCE','" + lblInvoice.Text + @"',
                    '" + Convert.ToDecimal(txtTotal.Text) + "',0,'" + txtDescription.Text + "','" + Classes.Helper.userId + @"',GETDATE(),1);";

                classHelper.query += @"DELETE FROM ISSUANCE_DETAIL WHERE ISSUANCE_MASTER_ID = '" + id + @"'";

                foreach (DataGridViewRow rows in grdItems.Rows)
                {
                    classHelper.query += @"INSERT INTO ISSUANCE_DETAIL (ISSUANCE_MASTER_ID,ITEM_TYPE,ITEM_ID,QTY,RATE) VALUES 
                    (" + masterId + ",'" + rows.Cells["itemType"].Value.ToString() + "','" + rows.Cells["itemId"].Value.ToString() + @"',
                        '" + rows.Cells["itemQty"].Value.ToString() + @"','" + rows.Cells["rate"].Value.ToString() + @"');";
                }

                classHelper.query += @" DELETE FROM MATERIAL_ITEM_LEDGER WHERE REF_NO = '" + id + @"' AND ENTRY_FROM = 'STOCK ISSUANCE';";

                classHelper.query += @" DELETE FROM PRODUCT_ITEM_LEDGER WHERE REF_NO = '" + id + @"' AND ENTRY_FROM = 'STOCK ISSUANCE';";

                foreach (DataGridViewRow rows in grdItems.Rows)
                {
                    if (rows.Cells["itemType"].Value.ToString().Equals("R"))
                    {
                        classHelper.query += @" INSERT INTO MATERIAL_ITEM_LEDGER 
                        ([DATE],MATERIAL_ID,REF_NO,ENTRY_FROM,STOCK_IN,STOCK_OUT,COST_AMT,SALE_AMT,L_ID,CREATED_BY,CREATION_DATE,COMPANY_ID)
                        VALUES('" + dtpDate.Value.ToString() + "','" + rows.Cells["itemId"].Value.ToString() + "'," + masterId + @",
                            'STOCK ISSUANCE','0','" + rows.Cells["itemQty"].Value.ToString() + @"',
                            '0','" + rows.Cells["rate"].Value.ToString() + @"','1','" + Classes.Helper.userId + "',GETDATE(),'1');";
                    }
                    else {
                        classHelper.query += @" INSERT INTO PRODUCT_ITEM_LEDGER 
                        ([DATE],PRODUCT_ID,REF_NO,ENTRY_FROM,STOCK_IN,STOCK_OUT,COST_AMT,SALE_AMT,L_ID,CREATED_BY,CREATION_DATE,COMPANY_ID)
                        VALUES('" + dtpDate.Value.ToString() + "','" + rows.Cells["itemId"].Value.ToString() + "'," + masterId + @",
                            'STOCK ISSUANCE','0','" + rows.Cells["itemQty"].Value.ToString() + @"',
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
                    DialogResult dialogResult = MessageBox.Show("Print Invoice?", "Invoice", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        PrintInvoice();
                    }
                    Clear();
                    LoadGrid();
                }
            }
        }
        private void PrintInvoice()
        {
            classHelper.mds.Tables["SaleInvoice"].Clear();

            grdItems.Sort(this.grdItems.Columns["modelNo"],
                                    ListSortDirection.Ascending);

            //grdItems.Sort(this.grdItems.Columns["modelNo"],
            //                        ListSortDirection.Ascending);

            foreach (DataGridViewRow rows in grdItems.Rows)
            {
                classHelper.dataR = classHelper.mds.Tables["SaleInvoice"].NewRow();
                classHelper.dataR["InvoiceNo"] = lblInvoice.Text;
                classHelper.dataR["date"] = dtpDate.Value.ToShortDateString();
                classHelper.dataR["customer"] = cmbCustomer.Text;
                classHelper.dataR["description"] = txtDescription.Text;
               // classHelper.dataR["itemName"] = classHelper.GetProductName(Convert.ToInt32(rows.Cells["itemid"].Value.ToString()),Convert.ToChar(rows.Cells["itemType"].Value.ToString()));
                classHelper.dataR["qty"] = Convert.ToDouble(rows.Cells["itemQty"].Value.ToString());
                classHelper.dataR["rate"] = Convert.ToDouble(rows.Cells["rate"].Value.ToString());
                classHelper.dataR["amount"] = Convert.ToDouble(rows.Cells["total"].Value.ToString());
                classHelper.dataR["creditDays"] = txtCreditDays.Text;
                classHelper.dataR["vehicleNo"] = txtVehicleNumber.Text;
                classHelper.dataR["balance"] = classHelper.GetAccountBalance(Convert.ToInt32(cmbCustomer.SelectedValue.ToString()));
                classHelper.dataR["code"] = rows.Cells["modelNo"].Value.ToString();
                classHelper.dataR["dueDate"] = dtpDate.Value.Date.AddDays(Convert.ToInt32(txtCreditDays.Text));
                classHelper.mds.Tables["SaleInvoice"].Rows.Add(classHelper.dataR);
            }
            //classHelper.mds.Tables["SaleInvoice"].DefaultView.Sort = "itemName asc";
            //classHelper.mds.Tables["SaleInvoice"].DefaultView.Sort = "code asc";
            
            
            classHelper.rpt = new ERP_Maaz_Oil.Forms.Reporting.frmReports();
            classHelper.rpt.GenerateReport("StockIssuance", classHelper.mds);
            classHelper.rpt.ShowDialog();
        }
        private void LoadIssuanceDetails(int issuanceId)
        {
            classHelper.LoadIssuanceDetail(grdItems, issuanceId);
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
                cmbCustomer.SelectedValue = row.Cells["ACCOUNT_ID"].Value.ToString();
                txtVehicleNumber.Text = row.Cells["VEHICLE_NO"].Value.ToString();
                txtDescription.Text = row.Cells["DESCRIPTION"].Value.ToString();
                txtCreditDays.Text = row.Cells["CREDIT_DAYS"].Value.ToString();
                LoadIssuanceDetails(id);
                TotalSum();
            }
        }
        private void frm_AddGroupAccounts_Load(object sender, EventArgs e)
        {
            GenerateIssuanceNumber();
            LoadGrid();
            LoadCustomers();
            //LoadProducts();
        }

        private void txtSEARCH_TextChanged(object sender, EventArgs e)
        {
            classHelper.Sale_search(txtSearch, grdSearch);
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void grdSEARCH_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            grdSearch.Columns["ACCOUNT_ID"].Visible = false;
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
            //if (cmbCustomer.SelectedIndex > 0) {
            //    string rateType = classHelper.GetAccountRateType(cmbCustomer.SelectedValue.ToString());
            //    if (rateType.Equals("R"))
            //    {
            //        rdbRetail.Checked = true;
            //    }
            //    else if (rateType.Equals("N"))
            //    {
            //        rdbnet.Checked = true;
            //    }
            //    else
            //    {
            //        rdbRetail.Checked = false;
            //        rdbnet.Checked = false;
            //    }
            //}
        }

        private void txtNetWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            classHelper.CheckNumber(e);
        }

        private void btn_VIEW_VOUCHER_Click(object sender, EventArgs e)
        {
            try
            {
                if (id != 0)
                { PrintInvoice(); }
                else
                {
                    MessageBox.Show("Invoice not found in record or save the invoice first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

    /*    private void rdbRaw_CheckedChanged(object sender, EventArgs e)
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
        */

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
                //if (rdbProduct.Checked == true) {
                //    int stockBalance = classHelper.GetStockBalance(cmbItem.SelectedValue.ToString());
                //    if (Convert.ToInt32(txtQty.Text) > stockBalance)
                //    {
                //        classHelper.ShowMessageBox(cmbItem.Text + " is out of stock, current stock is " + stockBalance, "Warning");
                //    }
                //}
                //else if (rdbRaw.Checked == true)
                //{
                //    int stockBalance = classHelper.GetMaterialBalance(cmbItem.SelectedValue.ToString());
                //    if (Convert.ToInt32(txtQty.Text) > stockBalance)
                //    {
                //        classHelper.ShowMessageBox(cmbItem.Text + " is out of stock, current stock is " + stockBalance, "Warning");
                //    }
                //}

                char itemType = 'P';
                if (rdbRaw.Checked == true) {
                    itemType = 'R';
                }
                string modelNo = "";
                if (rdbProduct.Checked == true)
                {
                    modelNo = classHelper.GetProductCode(Convert.ToInt32(cmbItem.SelectedValue.ToString()));
                }
                grdItems.Rows.Add(cmbItem.SelectedValue.ToString(), itemType, cmbItem.Text.Substring(cmbItem.Text.LastIndexOf(':') + 1), cmbItem.Text,  classHelper.AvoidInjection(txtQty.Text),
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
            txtRate.Text = "0";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (cmbItem.SelectedIndex > 0 && rdbProduct.Checked == true)
            {
                txtRate.Text = classHelper.GetProductRate(Convert.ToInt32(cmbItem.SelectedValue.ToString()), "net");
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (cmbItem.SelectedIndex > 0 && rdbProduct.Checked == true)
            {
                txtRate.Text = classHelper.GetProductRate(Convert.ToInt32(cmbItem.SelectedValue.ToString()), "retail");
            }
        }

        private void txtQty_Leave(object sender, EventArgs e)
        {
           
        }

        private void rdbRetail_Leave(object sender, EventArgs e)
        {
            
        }

        private void rdbnet_Leave(object sender, EventArgs e)
        {
            txtRate.Focus();
        }

        private void Delete()
        {

            classHelper.query = @" BEGIN TRY 
                             BEGIN TRANSACTION ";

            classHelper.query += @" DELETE FROM LEDGERS WHERE REF_ID = '" + id + @"' AND ENTRY_OF = 'STOCK ISSUANCE';
            DELETE FROM MATERIAL_ITEM_LEDGER WHERE REF_NO = '" + id + @"' AND ENTRY_FROM = 'STOCK ISSUANCE';
            DELETE FROM PRODUCT_ITEM_LEDGER WHERE REF_NO = '" + id + @"' AND ENTRY_FROM = 'STOCK ISSUANCE';
            DELETE FROM ISSUANCE_DETAIL WHERE ISSUANCE_MASTER_ID = '" + id + @"';            
            DELETE FROM ISSUANCE_MASTER WHERE ISSUANCE_MASTER_ID = '" + id + @"'";

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

        private void btn_VIEW_VOUCHER_Click_1(object sender, EventArgs e)
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

        private void cmbItem_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //if (rdbProduct.Checked == true)
            //{
            //    lblBalanceStock.Text = "AVAILABLE STOCK: "+ classHelper.GetStockBalance(cmbItem.SelectedValue.ToString());

            //    string value = "";
            //    if (rdbnet.Checked == true)
            //    {
            //        value = "net";
            //    }
            //    else if (rdbRetail.Checked == true)
            //    {
            //        value = "retail";
            //    }

            //    if (cmbItem.SelectedIndex > 0 && rdbProduct.Checked == true)
            //    {
            //        txtRate.Text = classHelper.GetProductRate(Convert.ToInt32(cmbItem.SelectedValue.ToString()), value);
            //    }
            //}
            //else if (rdbRaw.Checked == true)
            //{
            //    lblBalanceStock.Text = "AVAILABLE STOCK: " + classHelper.GetMaterialBalance(cmbItem.SelectedValue.ToString());
            //}
        }
    }
}

