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
            classHelper.query = @" SELECT A.SALE_RETURN_MASTER_ID AS [ID],A.INVOICE_NO AS [INVOICE #],
            A.[DATE],B.COA_NAME AS [CUSTOMER],A.[DESCRIPTION],
            A.CUSTOMER_ID,TERM
            FROM SALE_RETURN_MASTER A
            INNER JOIN COA B ON A.CUSTOMER_ID = B.COA_ID
            ORDER BY SALE_RETURN_MASTER_ID DESC";
            classHelper.LoadGrid(grdSearch, classHelper.query);
        }

        private void LoadCustomer()
        {
            classHelper.LoadCustomers(cmbCustomer);
        }
        private void LoadProducts()
        {
            classHelper.LoadProducts(cmbProducts);
        }

        private void Clear()
        {
            GenerateSRNumber();
            dtpDate.Value = DateTime.Now;
            cmbCustomer.SelectedIndex = 0;
            txtDescription.Clear();
            cmbProducts.SelectedIndex = 0;
            txtQty.Text = "0";
            txtRate.Text = "0";
            txtTotal.Text = "0";
            txtSearch.Clear();
            id = 0;
            isEdit = false;
            gridProducts.Rows.Clear();
            rdbCredit.Checked = true;
            LoadGrid();
        }

        private void Save()
        {

            {
                if (cmbCustomer.SelectedIndex == 0)
                {
                    classHelper.ShowMessageBox("Customer is not selected, please select Customer.", "Warning");
                    cmbCustomer.Focus();
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
                        masterId = "(SELECT MAX(SALE_RETURN_MASTER_ID) FROM SALE_RETURN_MASTER)";
                    }

                    // Determinetype based on selected radio button
                    char term = '0';
                    if (rdbCredit.Checked == true)
                    {
                        term = '1';
                    }
                    
                    classHelper.query = @"BEGIN TRY 
                    BEGIN TRANSACTION ";

                    classHelper.query += @"IF EXISTS (select SALE_RETURN_MASTER_ID from SALE_RETURN_MASTER WHERE SALE_RETURN_MASTER_ID ='" + id + @"') 
                 BEGIN
                     UPDATE SALE_RETURN_MASTER SET DATE = '" + dtpDate.Value.ToString() + @"',  
                     CUSTOMER_ID = '" + cmbCustomer.SelectedValue.ToString() + @"',
                     DESCRIPTION = '" + classHelper.AvoidInjection(txtDescription.Text) + @"',
                     TERM = '" + term + @"',
                     MODIFICATION_DATE = GETDATE(),MODIFIED_BY = '" + Classes.Helper.userId + @"'
                     WHERE SALE_RETURN_MASTER_ID = '" + id + @"';
                 END
                 ELSE
                 BEGIN
                     INSERT INTO SALE_RETURN_MASTER (DATE,CUSTOMER_ID,DESCRIPTION,TERM,CREATION_DATE,CREATED_BY,INVOICE_NO) 
                     VALUES ('" + dtpDate.Value.ToString() + "','" + cmbCustomer.SelectedValue.ToString() + @"',
                     '" + classHelper.AvoidInjection(txtDescription.Text) + @"',
                     '" + term + @"', GETDATE(),'" + Classes.Helper.userId + @"',
                     '" + lblInvoice.Text + @"');
                 END

                DELETE FROM LEDGERS WHERE REF_ID = " + id + @" AND ENTRY_OF = 'SALES RETURN'

                INSERT INTO LEDGERS(DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
                VALUES('" + dtpDate.Value.ToString() + "','" + Classes.Helper.salesReturnId +
                            "'," + masterId + ",'SALES RETURN','" + lblInvoice.Text + @"', '" + txtTotal.Text + "',0,'S.R # " + lblInvoice.Text + ")','" + Classes.Helper.userId + @"',GETDATE(),1);

                INSERT INTO LEDGERS(DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
                VALUES('" + dtpDate.Value.ToString() + "','" + cmbCustomer.SelectedValue.ToString() + "'," + masterId + ",'SALES RETURN','" + lblInvoice.Text + @"',
                0,'" + txtTotal.Text + "','S.R # " + lblInvoice.Text + ")','" + Classes.Helper.userId + @"',GETDATE(),1);";

                    if (rdbCash.Checked == true)
                    {
                        classHelper.query += @" INSERT INTO LEDGERS(DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
                        VALUES('" + dtpDate.Value.ToString() + "','" + cmbCustomer.SelectedValue.ToString() +
                        "'," + masterId + ",'SALES RETURN','" + lblInvoice.Text + @"', '" + txtTotal.Text + "', 0,'S.R # " + lblInvoice.Text + ")','" + Classes.Helper.userId + @"',GETDATE(),1);

                        INSERT INTO LEDGERS(DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
                        VALUES('" + dtpDate.Value.ToString() + "','" + Classes.Helper.cashId + "'," + masterId + ",'SALES RETURN','" + lblInvoice.Text + @"',
                        0,'" + txtTotal.Text + "','S.R # " + lblInvoice.Text + ")','" + Classes.Helper.userId + @"',GETDATE(),1);";
                    }

                    classHelper.query += @"DELETE FROM SALE_RETURN_DETAIL WHERE SALE_RETURN_MASTER_ID = '" + id + @"'";

                    foreach (DataGridViewRow rows in gridProducts.Rows)
                    {
                        classHelper.query += @" INSERT INTO SALE_RETURN_DETAIL (SALE_RETURN_MASTER_ID,ITEM_ID,QTY,RATE) 
                            VALUES (" + masterId + ",'" + rows.Cells["productId"].Value.ToString() + "','"
                        + rows.Cells["qty"].Value.ToString() + @"','" + rows.Cells["rate"].Value.ToString() + @"');";
                    }

                    classHelper.query += @" COMMIT TRANSACTION 
                 END TRY 
                 BEGIN CATCH 
                         IF @@TRANCOUNT > 0 
                         ROLLBACK TRANSACTION 
                 END CATCH";

                    if (classHelper.InsertUpdateDelete(classHelper.query) >= 1)
                    {
                        classHelper.ShowMessageBox("Record Saved Successfully.", "Information");
                        Clear();
                    }
                }
            }
        
        }

        private void LoadSalesReturnDetail(int id)
        {
            classHelper.LoadSalesReturnDetail(gridProducts, id);
        }

        private void LoadGridData(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.grdSearch.Rows[e.RowIndex];
                id = Convert.ToInt32(row.Cells["ID"].Value.ToString());
                lblInvoice.Text = row.Cells["INVOICE #"].Value.ToString();
                isEdit = true;
                dtpDate.Text = row.Cells["DATE"].Value.ToString();
                cmbCustomer.SelectedValue = row.Cells["CUSTOMER_ID"].Value.ToString();
                txtDescription.Text = row.Cells["DESCRIPTION"].Value.ToString();
                
                if (row.Cells["TERM"].Value.ToString().Equals("0"))
                {
                    rdbCash.Checked = true;
                }
                else
                {
                    rdbCredit.Checked = true;
                }

                LoadSalesReturnDetail(id);
                TotalSum();
            }
        }

        private void frm_AddGroupAccounts_Load(object sender, EventArgs e)
        {
            GenerateSRNumber();
            LoadGrid();
            LoadCustomer();
            LoadProducts();
        }

        private void txtSEARCH_TextChanged(object sender, EventArgs e)
        {
            try
            {
                (grdSearch.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
              [" + grdSearch.Columns["INVOICE #"].Name.ToString() + "] LIKE '%" + classHelper.AvoidInjection(txtSearch.Text) + "%' OR ["
              + grdSearch.Columns["CUSTOMER"].Name.ToString() + "] LIKE '%" + classHelper.AvoidInjection(txtSearch.Text) + "%' OR["
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
            grdSearch.Columns["CUSTOMER_ID"].Visible = false;
            grdSearch.Columns["TERM"].Visible = false;
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
        private void TotalSum()
        {
            try
            {
                txtTotal.Text = gridProducts.Rows.Cast<DataGridViewRow>()
                    .Sum(t => Convert.ToDecimal(t.Cells["total"].Value)).ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }


        //private decimal CalculateTotalWithGST(decimal quantity, decimal rate, decimal gst)
        //{
        //    decimal total = quantity * rate;
        //    decimal totalWithGST = total * (1 + gst / 100);
        //    return totalWithGST;

        //}


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbProducts.SelectedIndex == 0)
            {
                classHelper.ShowMessageBox("Product is not selected, please select Material.", "Warning");
                cmbProducts.Focus();
            }
            else if (txtQty.Text.Equals("") || txtQty.Text.Equals("0"))
            {
                classHelper.ShowMessageBox("Please add Product Qty.", "Warning");
                txtQty.Focus();
            }
            else if (txtRate.Text.Equals("") || txtRate.Text.Equals("0"))
            {
                classHelper.ShowMessageBox("Please add Product Rate.", "Warning");
                txtRate.Focus();
            }

            else
            {
                gridProducts.Rows.Add(cmbProducts.SelectedValue.ToString(), cmbProducts.Text, classHelper.AvoidInjection(txtQty.Text),
                classHelper.AvoidInjection(txtRate.Text),
                Convert.ToDecimal(classHelper.AvoidInjection(txtQty.Text)) * Convert.ToDecimal(classHelper.AvoidInjection(txtRate.Text)));

                TotalSum();
                cmbProducts.SelectedIndex = 0;
                txtQty.Text = "0";
                txtRate.Text = "0";
               // cmbProducts.Focus();
                btnSave.Focus();

            }
        }



        private void btnViewInvoice_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (id != 0)
            //    { PrintInvoice(); }
            //    else
            //    {
            //        MessageBox.Show("Invoice not found in record or save the invoice first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }

            //}
            //catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void txtCreditDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            classHelper.CheckNumber(e);
        }
        private void Delete()
        {

            classHelper.query = @" BEGIN TRY 
                             BEGIN TRANSACTION ";

            classHelper.query += @" DELETE FROM LEDGERS WHERE REF_ID = '" + id + @"' AND ENTRY_OF = 'SALES RETURN';
            DELETE FROM MATERIAL_ITEM_LEDGER WHERE REF_NO = '" + id + @"' AND ENTRY_FROM = 'SALES RETURN';
            DELETE FROM PRODUCT_ITEM_LEDGER WHERE REF_NO = '" + id + @"' AND ENTRY_FROM = 'SALES RETURN';
            DELETE FROM SALE_RETURN_DETAIL WHERE SALE_RETURN_MASTER_ID = '" + id + @"';            
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

        private void txtVehicleNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbMaterials_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void RemoveProductRaw(int productId)
        {
            foreach (DataGridViewRow item in this.gridProducts.Rows)
            {
                if (item.Cells["productId"].Value.ToString().Equals(productId.ToString()))
                {
                    gridProducts.Rows.RemoveAt(item.Index);
                }
            }
        }


        private void gridProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.gridProducts.Rows[e.RowIndex];
                cmbProducts.SelectedValue = row.Cells["productId"].Value.ToString();
                txtQty.Text = row.Cells["qty"].Value.ToString();
                txtRate.Text = row.Cells["rate"].Value.ToString();
                gridProducts.Rows.RemoveAt(e.RowIndex);
                TotalSum();
            }
        }
        private void gridProducts_ColumnNameChanged(object sender, DataGridViewColumnEventArgs e)
        {

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

        private void rdbCredit_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbCustomer_Leave(object sender, EventArgs e)
        {
            if (!classHelper.CheckAccountExists(cmbCustomer.Text))
            {
                string customerName = cmbCustomer.Text;
                DialogResult dialogResult = MessageBox.Show("Do you want to add " + cmbCustomer.Text + " Account?", "Add New Account", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    using (frmChartOfAccounts frm = new frmChartOfAccounts(21, 26, classHelper.AvoidInjection(cmbCustomer.Text), 0))
                    {
                        if (frm.ShowDialog() == System.Windows.Forms.DialogResult.Cancel || frm.ShowDialog() == System.Windows.Forms.DialogResult.Abort)
                        {
                            LoadCustomer();
                            cmbCustomer.Text = customerName;
                        }
                    }
                }
                else
                {
                    cmbCustomer.SelectedIndex = 0;
                    cmbCustomer.Focus();
                }
            }
        }

        private void cmbProducts_Leave(object sender, EventArgs e)
        {
              if (!classHelper.CheckProductExists(cmbProducts.Text))
                {
                    string productName = cmbProducts.Text;
                    DialogResult dialogResult = MessageBox.Show("Do you want to add " + cmbProducts.Text + " Product?", "Add New Productc", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        using (frmFinishedProducts frm = new frmFinishedProducts(classHelper.AvoidInjection(cmbProducts.Text)))
                        {
                            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.Cancel || frm.ShowDialog() == System.Windows.Forms.DialogResult.Abort)
                            {
                                LoadProducts();
                                cmbProducts.Text = productName;
                            }
                        }
                    }
                    else
                    {
                        cmbProducts.SelectedIndex = 0;
                        cmbProducts.Focus();
                    }
                }
            }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void lblAcc_Click(object sender, EventArgs e)
        {

        }
    }
    }
