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
    public partial class frm_Quotation : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        int id = 0;
        bool isEdit = false;
        public frm_Quotation()
        {
            InitializeComponent();
        }

        private void GenerateQTNumber()
        {
            classHelper.query = "SELECT ISNULL(COUNT(SOPM_ID),0)+1 FROM SALES_ORDER_PRODUCT_MASTER";
            lblInvoice.Text = "QT-" + classHelper.GetMaxValue(classHelper.query) + "-" + DateTime.Now.Year;
        }



        private void LoadGrid()
        {
            classHelper.query = @" SELECT A.SOPM_ID AS [ID], A.INVOICE_NO AS[INVOICE #],
            A.[DATE], B.COA_NAME AS [CUSTOMER], A.[DESCRIPTION],A.CUSTOMER_ID
            FROM SALES_ORDER_PRODUCT_MASTER A
            INNER JOIN COA B ON A.CUSTOMER_ID = B.COA_ID            
            ORDER BY [ID] DESC";
            classHelper.LoadGrid(grdSearch, classHelper.query);
        }

        private void LoadCustomers()
        {
            classHelper.LoadCustomers(cmbCustomer);
        }
        private void LoadProducts()
        {
            classHelper.LoadProducts(cmbProducts);
        }

        private void Clear()
        {
            GenerateQTNumber();
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
            LoadGrid(); 
        }

        private void Save()
        {
            // Step 1: Validate fields
            if (cmbCustomer.SelectedIndex == 0)
            {
                classHelper.ShowMessageBox("Customer is not selected, please select Supplier.", "Warning");
                cmbCustomer.Focus();
                return;
            }
            else if (gridProducts.Rows.Count <= 0)
            {
                classHelper.ShowMessageBox("Add Products.", "Warning");
                cmbProducts.Focus();
                return;
            }

            // Step 2: Build the SQL query
            string masterId = id.ToString();
            if (id.ToString().Equals("0"))
            {
                masterId = "(SELECT MAX(SOPM_ID) FROM SALES_ORDER_PRODUCT_MASTER)";
            }

            classHelper.query = @"BEGIN TRY 
                           BEGIN TRANSACTION ";

            // Insert or update PURCHASE_ORDER
            classHelper.query += @"IF EXISTS (SELECT SOPM_ID FROM SALES_ORDER_PRODUCT_MASTER WHERE SOPM_ID = '" + id + @"') 
            BEGIN
                UPDATE SALES_ORDER_PRODUCT_MASTER 
                SET DATE = '" + dtpDate.Value.ToString() + @"',   
                    CUSTOMER_ID = '" + cmbCustomer.SelectedValue.ToString() + @"',
                    DESCRIPTION = '" + classHelper.AvoidInjection(txtDescription.Text) + @"',
                    MODIFICATION_DATE = GETDATE(), 
                    MODIFIED_BY = '" + Classes.Helper.userId + @"'
                WHERE SOPM_ID = '" + id + @"';
            END
            ELSE
            BEGIN
                INSERT INTO SALES_ORDER_PRODUCT_MASTER (DATE, CUSTOMER_ID, DESCRIPTION, CREATION_DATE, CREATED_BY, INVOICE_NO) 
                VALUES 
                ('" + dtpDate.Value.ToString() + "', '" + cmbCustomer.SelectedValue.ToString() + @"', 
                '" + classHelper.AvoidInjection(txtDescription.Text) + @"', 
                GETDATE(), '" + Classes.Helper.userId + @"', 
                '" + lblInvoice.Text + @"');
            END";

            // Step 4: Insert details into PURCHASE_DETAIL
            classHelper.query += @" DELETE FROM SALES_ORDER_PRODUCT_DETAILS WHERE SOPM_ID = '" + id + @"';";
            foreach (DataGridViewRow row in gridProducts.Rows)
            {
                classHelper.query += @" INSERT INTO SALES_ORDER_PRODUCT_DETAILS (SOPM_ID, PRODUCT_ID, QTY, RATE) 
                               VALUES 
                               (" + masterId + ", '" + row.Cells["productId"].Value.ToString() + "', '" + row.Cells["qty"].Value.ToString() + @"', 
                               '" + row.Cells["rate"].Value.ToString() + @"');";
            }

            // Step 6: Commit transaction
            classHelper.query += @" COMMIT TRANSACTION; 
                         END TRY 
                         BEGIN CATCH 
                             IF @@TRANCOUNT > 0 
                                 ROLLBACK TRANSACTION; 
                             THROW;
                         END CATCH;";

            // Step 7: Execute query and handle result
            try
            {
                if (classHelper.InsertUpdateDelete(classHelper.query) >= 1)
                {
                    classHelper.ShowMessageBox("Record Saved Successfully.", "Information");

                    //// Optional: Ask for print
                    //DialogResult dialogResult = MessageBox.Show("Print Invoice?", "Purchases Invoice", MessageBoxButtons.YesNo);
                    //if (dialogResult == DialogResult.Yes)
                    //{
                    //    PrintInvoice();
                    //}

                    // Clear fields and refresh grid
                    Clear();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving data: " + ex.Message);
            }
        }

        private void PrintInvoice()
        {
            classHelper.mds.Tables["PI"].Clear();
            foreach (DataGridViewRow rows in gridProducts.Rows)
            {
                classHelper.dataR = classHelper.mds.Tables["PI"].NewRow();
                classHelper.dataR["PI_num"] = lblInvoice.Text;
                classHelper.dataR["date"] = dtpDate.Value.ToShortDateString();
                classHelper.dataR["supplier"] = cmbCustomer.Text;
                classHelper.dataR["description"] = txtDescription.Text;
                classHelper.dataR["material"] = rows.Cells["productId"].Value.ToString();
                classHelper.dataR["qty"] = Convert.ToDouble(rows.Cells["qty"].Value.ToString());
                classHelper.dataR["rate"] = Convert.ToDouble(rows.Cells["rate"].Value.ToString());
                classHelper.dataR["total"] = Convert.ToDouble(rows.Cells["total"].Value.ToString());
                //   classHelper.dataR["creditDays"] = txtCreditDays.Text;
                //   classHelper.dataR["dueDate"] = DateTime.Now.AddDays(Convert.ToInt32(txtCreditDays.Text));
                classHelper.mds.Tables["PI"].Rows.Add(classHelper.dataR);
            }
            classHelper.rpt = new ERP_Maaz_Oil.Forms.Reporting.frmReports();
            classHelper.rpt.GenerateReport("PI", classHelper.mds);
            classHelper.rpt.ShowDialog();
        }

        private void LoadQuotationDetails(int id)
        {
            classHelper.LoadQuotationDetail(gridProducts, id);
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
                LoadQuotationDetails(id);
                TotalSum();
            }
        }

        private void frm_AddGroupAccounts_Load(object sender, EventArgs e)
        {
            GenerateQTNumber();
            LoadGrid();
            LoadCustomers();
            LoadProducts();
        }

        private void txtSEARCH_TextChanged(object sender, EventArgs e)
        {
            (grdSearch.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
            [" + grdSearch.Columns["CUSTOMER"].Name.ToString() + "] LIKE '%" + classHelper.AvoidInjection(txtSearch.Text) + "%' OR ["
               + grdSearch.Columns["DESCRIPTION"].Name.ToString() + "] LIKE '%" + classHelper.AvoidInjection(txtSearch.Text) + "%' OR ["
              + grdSearch.Columns["INVOICE #"].Name.ToString() + "] LIKE '%" + classHelper.AvoidInjection(txtSearch.Text) + "%'");
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
                classHelper.AvoidInjection(txtRate.Text), Convert.ToDecimal(classHelper.AvoidInjection(txtQty.Text)) *
                Convert.ToDecimal(classHelper.AvoidInjection(txtRate.Text)));

                TotalSum();
                cmbProducts.SelectedIndex = 0;
                txtQty.Text = "0";
                txtRate.Text = "0";
              //  cmbProducts.Focus();
            }
        }

        private void btnViewInvoice_Click(object sender, EventArgs e)
        {

        }

        private void txtCreditDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            classHelper.CheckNumber(e);
        }
        private void Delete()
        {

            classHelper.query = @" BEGIN TRY 
                             BEGIN TRANSACTION ";

            classHelper.query += @" DELETE FROM SALES_ORDER_PRODUCT_DETAILS WHERE SOPM_ID = '" + id + @"';            
            DELETE FROM SALES_ORDER_PRODUCT_MASTER WHERE SOPM_ID = '" + id + @"'";

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

        private void lblInvoice_Click(object sender, EventArgs e)
        {

        }

        private void PrintQuotation()
        {
            classHelper.nds.Tables["GeneralOrderSupply"].Clear();
            foreach (DataGridViewRow rows in gridProducts.Rows)
            {
                classHelper.dataR = classHelper.nds.Tables["GeneralOrderSupply"].NewRow();
                classHelper.dataR["qty"] = Convert.ToDouble(rows.Cells["qty"].Value.ToString());
                classHelper.dataR["invoice"] = lblInvoice.Text;
                classHelper.dataR["rate"] = Convert.ToDouble(rows.Cells["rate"].Value.ToString());
                classHelper.dataR["fromDate"] = dtpDate.Value.ToShortDateString();
                classHelper.dataR["particulars"] = rows.Cells["productName"].Value.ToString();
                classHelper.dataR["amount"] = Convert.ToDouble(rows.Cells["total"].Value.ToString());
                classHelper.dataR["customer"] = cmbCustomer.Text;
                classHelper.nds.Tables["GeneralOrderSupply"].Rows.Add(classHelper.dataR);
            }
            classHelper.rpt = new ERP_Maaz_Oil.Forms.Reporting.frmReports();
            classHelper.rpt.GenerateReport("Quotation", classHelper.nds);
            classHelper.rpt.ShowDialog();
        }

        private void btnViewQuotation_Click(object sender, EventArgs e)
        {
            PrintQuotation();
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
                            LoadCustomers();
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
    }
}



