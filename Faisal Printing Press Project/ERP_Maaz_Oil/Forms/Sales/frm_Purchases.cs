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
    public partial class frm_Purchases : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        int id = 0;

        public frm_Purchases()
        {
            InitializeComponent();
        }

        private void GeneratePINumber()
        {
            classHelper.query = "SELECT ISNULL(COUNT(PI_ID),0)+1 FROM PURCHASES";
            lblInvoice.Text = "PI-" + classHelper.GetMaxValue(classHelper.query) + "-" + DateTime.Now.Year;
        }

        private void LoadGrid()
        {
            classHelper.query = @" SELECT A.PI_ID AS [ID],A.INVOICE_NO AS [INVOICE #],
            A.[DATE],A.SUPPLIER_ID,B.COA_NAME AS [VENDOR],A.[DESCRIPTION],
            A.NET_WEIGHT AS [TOTAL]
            FROM PURCHASES A
            INNER JOIN COA B ON A.SUPPLIER_ID = B.COA_ID
            ORDER BY PI_ID DESC";
            classHelper.LoadGrid(grdSearch, classHelper.query);
        }

        private void LoadVendors()
        {
            classHelper.LoadSuppliers(cmbVendor);
        }

        private void Clear()
        {
            GeneratePINumber();
            dtpDate.Value = DateTime.Now;
            cmbVendor.SelectedIndex = 0;
            txtTotal.Text = "0";
            txtDescription.Clear();            
            txtSearch.Clear();
            id = 0;
            LoadGrid();
        }

        private void Save()
        {
            {
                if (cmbVendor.SelectedIndex == 0)
                {
                    classHelper.ShowMessageBox("Customer is not selected, please select Customer.", "Warning");
                    cmbVendor.Focus();
                }
                else if (txtCreditDays.Text.Trim().Equals(""))
                {
                    classHelper.ShowMessageBox("Enter Credit Days.", "Warning");
                    txtCreditDays.Focus();
                }
                else if (gridProducts.Rows.Count <= 0)
                {
                    classHelper.ShowMessageBox("Add Products.", "Warning");
                    cmbProducts.Focus();
                }
                else
                {
                    string masterId = id.ToString();
                    if (id.ToString().Equals("0"))
                    {
                        masterId = "(SELECT MAX(SALE_MASTER_ID) FROM SALE_MASTER)";
                    }

                    // Determinetype based on selected radio button
                    char term = '0';
                    //char isPaid = '1';
                    if (rdbCredit.Checked == true)
                    {
                        term = '1';
                        //isPaid = '0';
                    }


                    classHelper.query = @"BEGIN TRY 
                    BEGIN TRANSACTION ";

                    classHelper.query += @"IF EXISTS (select SALE_MASTER_ID from SALE_MASTER WHERE SALE_MASTER_ID ='" + id + @"') 
                 BEGIN
                    UPDATE SALE_MASTER SET DATE = '" + dtpDate.Value.ToString() + @"',  
                    DESCRIPTION = '" + classHelper.AvoidInjection(txtDescription.Text) + @"',                     
                    CUSTOMER_ID = '" + cmbVendor.SelectedValue.ToString() + @"',
                    CUSTOMER_ADDRESS = '" + classHelper.AvoidInjection(txtCustomerAddress.Text) + @"',                     
                    CREDIT_DAYS = '" + classHelper.AvoidInjection(txtCreditDays.Text) + @"',
                    SHIP_TO = '" + classHelper.AvoidInjection(txtShipTo.Text) + @"',             
                    SHIPPING_ADDRESS = '" + classHelper.AvoidInjection(txtShippingAddress.Text) + @"',             
                    TERM = '" + term + @"',
                    IS_PAID = '0',
                    BORI_EXPENSE = '" + classHelper.AvoidInjection(txtBoriExpense.Text) + @"',   
                    CARTON_EXPENSE = '" + classHelper.AvoidInjection(txtCartonExpense.Text) + @"',   
                    MODIFICATION_DATE = GETDATE(),MODIFIED_BY = '" + Classes.Helper.userId + @"'
                    WHERE SALE_MASTER_ID = '" + id + @"';
                 END
                 ELSE
                 BEGIN
                     INSERT INTO SALE_MASTER (DATE,CUSTOMER_ID,DESCRIPTION,CREDIT_DAYS,TERM,CREATION_DATE,CREATED_BY,INVOICE_NO,IS_PAID,
                    CUSTOMER_ADDRESS,SHIP_TO,SHIPPING_ADDRESS,BORI_EXPENSE,CARTON_EXPENSE) 
                     VALUES ('" + dtpDate.Value.ToString() + "','" + cmbVendor.SelectedValue.ToString() + @"',
                     '" + classHelper.AvoidInjection(txtDescription.Text) + @"',
                     '" + classHelper.AvoidInjection(txtCreditDays.Text) + "', '" + term + @"', GETDATE(),'" + Classes.Helper.userId + @"',
                     '" + lblInvoice.Text + @"','0','" + classHelper.AvoidInjection(txtCustomerAddress.Text) + @"','" + classHelper.AvoidInjection(txtShipTo.Text) + @"','" + classHelper.AvoidInjection(txtShippingAddress.Text) + @"','" + classHelper.AvoidInjection(txtBoriExpense.Text) + @"','" + classHelper.AvoidInjection(txtCartonExpense.Text) + @"');
                 END";

                classHelper.query += @" DELETE FROM SALE_DETAIL WHERE SALE_MASTER_ID = '" + id + @"'";

                    foreach (DataGridViewRow rows in gridProducts.Rows)
                    {
                        classHelper.query += @" INSERT INTO SALE_DETAIL (SALE_MASTER_ID,ITEM_ID,QTY,RATE,GST,COST_RATE) 
                            VALUES (" + masterId + ",'" + rows.Cells["productId"].Value.ToString() + "','"
                        + rows.Cells["qty"].Value.ToString() + @"','" + rows.Cells["rate"].Value.ToString() + @"','" + rows.Cells["totalBundle"].Value.ToString() + @"','" + rows.Cells["bundlePcs"].Value.ToString() + @"');";
                    }

                classHelper.query += @" DELETE FROM LEDGERS WHERE REF_ID = " + id + @" AND ENTRY_OF = 'SALES'";

                        classHelper.query += @" 
                            INSERT INTO LEDGERS(DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
                            VALUES('" + dtpDate.Value.ToString() + "','" + Classes.Helper.salesId +
                                        "'," + masterId + ",'SALES','" + lblInvoice.Text + @"', 0,'" + txtTotal.Text + "','S.I # " + lblInvoice.Text + "','" + Classes.Helper.userId + @"',GETDATE(),1);

                            INSERT INTO LEDGERS(DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
                            VALUES('" + dtpDate.Value.ToString() + "','" + cmbVendor.SelectedValue.ToString() +
                                        "'," + masterId + ",'SALES','" + lblInvoice.Text + @"', '" + txtTotal.Text + "',0,'S.I # " + lblInvoice.Text + "','" + Classes.Helper.userId + @"',GETDATE(),1);"; 

                        //if (rdbCash.Checked == true)
                        //{
                        //    classHelper.query += @" INSERT INTO LEDGERS(DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
                        //    VALUES('" + dtpDate.Value.ToString() + "','" + cmbCustomer.SelectedValue.ToString() +
                        //    "'," + masterId + ",'SALES','" + lblInvoice.Text + @"', 0,'" + txtTotal.Text + "','S.I # " + lblInvoice.Text + " /" + txtCreditDays.Text + " DAYS PAYMENT)','" + Classes.Helper.userId + @"',GETDATE(),1);

                        //    INSERT INTO LEDGERS(DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
                        //    VALUES('" + dtpDate.Value.ToString() + "','" + Classes.Helper.cashId +
                        //    "'," + masterId + ",'SALES','" + lblInvoice.Text + @"', '" + txtTotal.Text + "',0,'S.I # " + lblInvoice.Text + " /" + txtCreditDays.Text + " DAYS PAYMENT)','" + Classes.Helper.userId + @"',GETDATE(),1);";
                        //}
                    

                    classHelper.query += @" COMMIT TRANSACTION 
                     END TRY 
                     BEGIN CATCH 
                             IF @@TRANCOUNT > 0 
                             ROLLBACK TRANSACTION 
                     END CATCH";

                    if (classHelper.InsertUpdateDelete(classHelper.query) >= 1)
                    {
                        classHelper.ShowMessageBox("Record Saved Successfully.", "Information");

                        DialogResult dialogResult = MessageBox.Show("Print Invoice?", "Purchases Invoice", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            PrintSalesInvoiceOriginal();
                            PrintSalesInvoiceDuplicate();
                        }
                        //PrintSalesInvoice();
                        Clear();
                    }
                }
            }
        }

        private void LoadGridData(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.grdSearch.Rows[e.RowIndex];
                id = Convert.ToInt32(row.Cells["ID"].Value.ToString());
                lblInvoice.Text = row.Cells["INVOICE #"].Value.ToString();
                dtpDate.Text = row.Cells["DATE"].Value.ToString();
                txtDescription.Text = row.Cells["DESCRIPTION"].Value.ToString();
                cmbVendor.SelectedValue = row.Cells["CUSTOMER_ID"].Value.ToString();
                txtCustomerAddress.Text = row.Cells["CUSTOMER_ADDRESS"].Value.ToString();
                txtCreditDays.Text = row.Cells["CREDIT_DAYS"].Value.ToString();
                txtShipTo.Text = row.Cells["SHIP_TO"].Value.ToString();
                txtShippingAddress.Text = row.Cells["SHIPPING_ADDRESS"].Value.ToString();
                if (row.Cells["TERM"].Value.ToString().Equals("0"))
                {
                    rdbCash.Checked = true;
                }
                else
                {
                    rdbCredit.Checked = true;
                }
                txtBoriExpense.Text = row.Cells["BORI_EXPENSE"].Value.ToString();
                txtCartonExpense.Text = row.Cells["CARTON_EXPENSE"].Value.ToString();
                LoadSalesDetail(id);
                TotalSum();
            }
        }

        private void frm_AddGroupAccounts_Load(object sender, EventArgs e)
        {
            GeneratePINumber();
            LoadGrid();
            LoadVendors();
        }

        private void txtSEARCH_TextChanged(object sender, EventArgs e)
        {
            try
            {
                (grdSearch.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
              [" + grdSearch.Columns["INVOICE #"].Name.ToString() + "] LIKE '%" + classHelper.AvoidInjection(txtSearch.Text) + "%' OR ["
              + grdSearch.Columns["VENDOR"].Name.ToString() + "] LIKE '%" + classHelper.AvoidInjection(txtSearch.Text) + "%' OR["
               + grdSearch.Columns["DESCRIPTION"].Name.ToString() + "] LIKE '%" + classHelper.AvoidInjection(txtSearch.Text) + "%'");
                grdSearch.ClearSelection();
            }

            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void grdSEARCH_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            grdSearch.Columns["ID"].Visible = false;
            grdSearch.Columns["SUPPLIER_ID"].Visible = false;
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
        
        
        private void Delete()
        {

            classHelper.query = @" BEGIN TRY 
                             BEGIN TRANSACTION ";

            classHelper.query += @" DELETE FROM LEDGERS WHERE REF_ID = '" + id + @"' AND ENTRY_OF = 'SALES ';
            DELETE FROM MATERIAL_ITEM_LEDGER WHERE REF_NO = '" + id + @"' AND ENTRY_FROM = 'SALES ';
            DELETE FROM PRODUCT_ITEM_LEDGER WHERE REF_NO = '" + id + @"' AND ENTRY_FROM = 'SALES ';
            DELETE FROM SALE_DETAIL WHERE SALE_MASTER_ID = '" + id + @"';            
            DELETE FROM SALE_MASTER WHERE SALE_MASTER_ID = '" + id + @"'";

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


        private void grdSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pnlHEADER_Paint(object sender, PaintEventArgs e)
        {

        }

        private void grdSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadGridData(e);
        }

        
        private void cmbCustomer_Leave(object sender, EventArgs e)
        {
            
        }
    }
}



