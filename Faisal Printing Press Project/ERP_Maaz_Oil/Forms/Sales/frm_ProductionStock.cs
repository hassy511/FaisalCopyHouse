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
    public partial class frm_ProductionStock : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        int id = 0;
        //bool isEdit = false;
        public frm_ProductionStock()
        {
            InitializeComponent();
        }

        private void GenerateInvoiceNumber()
        {
            classHelper.query = "SELECT ISNULL(COUNT(ID),0)+1 FROM PRODUCTION_MASTER";
            lblInvoice.Text = "PROD-" + classHelper.GetMaxValue(classHelper.query) + "-" + DateTime.Now.Year;
        }

        private void LoadGrid()
        {
            classHelper.query = @" 	SELECT A.ID AS [ID],A.INVOICE_NO AS [INVOICE #],
            A.[DATE],A.[DESCRIPTION]
            FROM PRODUCTION_MASTER A
            ORDER BY ID DESC";
            classHelper.LoadGrid(grdSearch, classHelper.query);
        }

        private void LoadProducts()
        {
            classHelper.LoadProducts(cmbProducts);
        }

        private void Clear()
        {
            GenerateInvoiceNumber();
            dtpDate.Value = DateTime.Now;
            txtDescription.Clear();
            cmbProducts.SelectedIndex = 0;
            txtBundle.Text = "0";
            txtBundlePcs.Text = "0";
            txtQty.Text = "0";
            txtRate.Text = "0";
            txtTotal.Text = "0";
            txtSearch.Clear();
            id = 0;
            gridProducts.Rows.Clear();
            LoadGrid();
        }

        private void Save()
        {
            {
                if (gridProducts.Rows.Count <= 0)
                {
                    classHelper.ShowMessageBox("Add Products.", "Warning");
                    cmbProducts.Focus();
                }
                else
                {
                    string masterId = id.ToString();
                    if (id.ToString().Equals("0"))
                    {
                        masterId = "(SELECT MAX(ID) FROM PRODUCTION_MASTER)";
                    }

                    
                    classHelper.query = @"BEGIN TRY 
                    BEGIN TRANSACTION ";

                    classHelper.query += @"IF EXISTS (select ID from PRODUCTION_MASTER WHERE ID ='" + id + @"') 
                 BEGIN
                    UPDATE PRODUCTION_MASTER SET DATE = '" + dtpDate.Value.ToString() + @"',  
                    DESCRIPTION = '" + classHelper.AvoidInjection(txtDescription.Text) + @"',
                    MODIFICATION_DATE = GETDATE(),MODIFIED_BY = '" + Classes.Helper.userId + @"'
                    WHERE ID = '" + id + @"';
                 END
                 ELSE
                 BEGIN
                     INSERT INTO PRODUCTION_MASTER (DATE,DESCRIPTION,CREATION_DATE,CREATED_BY,INVOICE_NO) 
                     VALUES ('" + dtpDate.Value.ToString() + @"',
                     '" + classHelper.AvoidInjection(txtDescription.Text) + @"', 
                        GETDATE(),'" + Classes.Helper.userId + @"',
                     '" + lblInvoice.Text + @"');
                 END";

                classHelper.query += @" DELETE FROM PRODUCTION_DETAIL WHERE PRODUCTION_MASTER_ID = '" + id + @"'";

                    foreach (DataGridViewRow rows in gridProducts.Rows)
                    {
                        classHelper.query += @" INSERT INTO PRODUCTION_DETAIL (PRODUCTION_MASTER_ID,PRODUCT_MASTER_ID,QTY,RATE,TOTAL_BUNDLE,BUNDLE_PCS,TOTAL) 
                            VALUES (" + masterId + ",'" + rows.Cells["productId"].Value.ToString() + "','"
                        + rows.Cells["qty"].Value.ToString() + @"','" + rows.Cells["rate"].Value.ToString() + @"','" + rows.Cells["totalBundle"].Value.ToString() + @"','" + rows.Cells["bundlePcs"].Value.ToString() + @"','" + rows.Cells["total"].Value.ToString() + @"');";
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

        private void LoadproductionDetail(int id)
        {
            classHelper.LoadProductionDetail(gridProducts, id);
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
                LoadproductionDetail(id);
                TotalSum();
            }
        }

        private void frm_AddGroupAccounts_Load(object sender, EventArgs e)
        {
            GenerateInvoiceNumber();
            LoadGrid();
            LoadProducts();
        }

        private void txtSEARCH_TextChanged(object sender, EventArgs e)
        {
            try
            {
                (grdSearch.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
              [" + grdSearch.Columns["INVOICE #"].Name.ToString() + "] LIKE '%" + classHelper.AvoidInjection(txtSearch.Text) + "%' OR["
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
            //grdSearch.Columns["CUSTOMER_ID"].Visible = false;
            //grdSearch.Columns["TERM"].Visible = false;
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


        private void QtyCalculation()
        {
            try
            {
                decimal bundles = 0;
                if (!txtBundle.Text.Equals(""))
                {
                    bundles = Convert.ToDecimal(txtBundle.Text);
                }

                decimal bundlesPcs = 0;
                if (!txtBundlePcs.Text.Equals(""))
                {
                    bundlesPcs = Convert.ToDecimal(txtBundlePcs.Text);
                }

                txtQty.Text = Math.Round((bundles * bundlesPcs)).ToString();
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
            //else if (txtBundle.Text.Equals("") || txtBundle.Text.Equals("0"))
            //{
            //    classHelper.ShowMessageBox("Please add Total Bundles.", "Warning");
            //    txtBundle.Focus();
            //}
            //else if (txtBundlePcs.Text.Equals("") || txtBundlePcs.Text.Equals("0"))
            //{
            //    classHelper.ShowMessageBox("Please add Pcs Per Bundle.", "Warning");
            //    txtBundlePcs.Focus();
            //}
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
                gridProducts.Rows.Add(cmbProducts.SelectedValue.ToString(), cmbProducts.Text, classHelper.AvoidInjection(txtBundle.Text), 
                    classHelper.AvoidInjection(txtBundlePcs.Text), classHelper.AvoidInjection(txtQty.Text),
                Math.Round(Convert.ToDecimal(classHelper.AvoidInjection(txtRate.Text)),2),
                (Math.Round(Convert.ToDecimal(classHelper.AvoidInjection(txtQty.Text)),2) * Math.Round(Convert.ToDecimal(classHelper.AvoidInjection(txtRate.Text)),2)));
                TotalSum();
                cmbProducts.SelectedIndex = 0;
                txtBundle.Text = "0";
                txtBundlePcs.Text = "0";
                txtQty.Text = "0";
                txtRate.Text = "0";
                cmbProducts.Focus();
            }
        }



        private void btnViewInvoice_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (id != 0)
            //    { PrintSalesInvoiceOriginal(); }
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

            classHelper.query += @" 
            DELETE FROM PRODUCTION_DETAIL WHERE PRODUCTION_MASTER_ID = '" + id + @"';            
            DELETE FROM PRODUCTION_MASTER WHERE ID = '" + id + @"'";

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
            if (cmbProducts.SelectedIndex > 0)
            {
                txtBundlePcs.Text = classHelper.GetProductBundlePcs(Convert.ToInt32(cmbProducts.SelectedValue.ToString())).ToString();
            }
            else
            {
                txtBundlePcs.Text = "0";
            }
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
                txtRate.Text = row.Cells["rate"].Value.ToString();
                txtBundle.Text = row.Cells["totalBundle"].Value.ToString();
                txtBundlePcs.Text = row.Cells["bundlePcs"].Value.ToString();
                txtQty.Text = row.Cells["qty"].Value.ToString();
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


        private void txtQty_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbProducts_Leave(object sender, EventArgs e)
        {
            //if (!classHelper.CheckProductExists(cmbProducts.Text))
            //{
            //    string productName = cmbProducts.Text;
            //    DialogResult dialogResult = MessageBox.Show("Do you want to add " + cmbProducts.Text + " Product?", "Add New Productc", MessageBoxButtons.YesNo);
            //    if (dialogResult == DialogResult.Yes)
            //    {
            //        using (frmFinishedProducts frm = new frmFinishedProducts(classHelper.AvoidInjection(cmbProducts.Text)))
            //        {
            //            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.Cancel || frm.ShowDialog() == System.Windows.Forms.DialogResult.Abort)
            //            {
            //                LoadProducts();
            //                cmbProducts.Text = productName;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        cmbProducts.SelectedIndex = 0;
            //        cmbProducts.Focus();
            //    }
            //}
        }

        private void txtBundle_TextChanged(object sender, EventArgs e)
        {
            QtyCalculation();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //try
            //{
            //    if (id != 0)
            //    { PrintSalesInvoiceDuplicate(); }
            //    else
            //    {
            //        MessageBox.Show("Invoice not found in record or save the invoice first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }

            //}
            //catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }
    }
}



