using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP_Maaz_Oil.Forms.Job
{
    public partial class frmJobOrder : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        int id = 0;
        bool isEdit = false;
        public frmJobOrder()
        {
            InitializeComponent();
        }

        private void Clear() {
            txtSearch.Clear();
            GenerateJONumber();
            dtpDate.Value = DateTime.Now;
            cmbProduct.SelectedIndex = 0;
            txtDescription.Clear();
            txtProductQty.Text = "0";
            grdItems.Rows.Clear();
            grdMaterial.Rows.Clear();
            id = 0;
            //chkJobCompleted.Checked = false;
            isEdit = false;
        }
        private void GenerateJONumber()
        {
            classHelper.query = "SELECT COUNT(JOB_ORDER_MASTER_ID)+1 FROM JOB_ORDER_MASTER";
            lblInvoiceNo.Text = "JO-" + classHelper.GetMaxValue(classHelper.query) + "-" + DateTime.Now.Year;
        }
        private void LoadGrid()
        {
            classHelper.query = @"SELECT JOB_ORDER_MASTER_ID AS [ID],[DATE],INVOICE_NO AS [INVOICE #],[DESCRIPTION] 
            FROM JOB_ORDER_MASTER
            ORDER BY JOB_ORDER_MASTER_ID DESC";
            classHelper.LoadGrid(grdSearch, classHelper.query);
        }
        private void LoadProducts()
        {
            classHelper.LoadProducts(cmbProduct);
            //classHelper.LoadNewProducts(cmbProduct);
        }

        private void LoadProductRaw() {
            classHelper.LoadProductRaw(grdMaterial,Convert.ToInt32(cmbProduct.SelectedValue.ToString()),Convert.ToDecimal(txtProductQty.Text));
        }

        private void LoadJobProducts(int jobOrderId)
        {
            classHelper.LoadJobOrderProduct(grdItems, jobOrderId);
        }
        private void LoadJobMaterials(int jobOrderId)
        {
            classHelper.LoadJobOrderRaw(grdMaterial, jobOrderId);
        }

        private void frmJobOrder_Load(object sender, EventArgs e)
        {
            GenerateJONumber();
            LoadGrid();
            LoadProducts();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbProduct.SelectedIndex == 0)
            {
                classHelper.ShowMessageBox("Product is not selected, please select Product.", "Warning");
                cmbProduct.Focus();
            }
            else if (txtProductQty.Text.Equals("") || txtProductQty.Text.Equals("0"))
            {
                classHelper.ShowMessageBox("Please add Product Qty.", "Warning");
                txtProductQty.Focus();
            }
            else {
                grdItems.Rows.Add(cmbProduct.SelectedValue.ToString(),cmbProduct.Text,classHelper.AvoidInjection(txtProductQty.Text));
                LoadProductRaw();
                cmbProduct.SelectedIndex = 0;
                txtProductQty.Text = "0";
            }
        }

        private void RemoveProductRaw(int productId) {
            foreach (DataGridViewRow item in this.grdMaterial.Rows)
            {
                if (item.Cells["rawProductId"].Value.ToString().Equals(productId.ToString()))
                {
                    grdMaterial.Rows.RemoveAt(item.Index);
                }
            }
        }

        private void grdItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.grdItems.Rows[e.RowIndex];
                cmbProduct.SelectedValue = row.Cells["productId"].Value.ToString();
                txtProductQty.Text = row.Cells["qty"].Value.ToString();
                RemoveProductRaw(Convert.ToInt32(row.Cells["productId"].Value.ToString()));
                grdItems.Rows.RemoveAt(e.RowIndex);                
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (grdItems.Rows.Count <= 0 || grdMaterial.Rows.Count <= 0)
            {
                classHelper.ShowMessageBox("Please add Product.", "Warning");
                cmbProduct.Focus();
            }
            else {
                string masterId = id.ToString();
                if (id == 0) {
                    masterId = "(SELECT ISNULL(MAX(JOB_ORDER_MASTER_ID),1) FROM JOB_ORDER_MASTER)";
                }

                char jobCompleted = '1';
                //if (chkJobCompleted.Checked == true) {
                //    jobCompleted = '1';
                //}

                decimal differenceSum = grdMaterial.Rows.Cast<DataGridViewRow>()
                    .Sum(t => Convert.ToDecimal(t.Cells["difference"].Value));

                //chkJobCompleted.Checked == true && 
                if (differenceSum < 0)
                {
                    classHelper.ShowMessageBox("Material Qty is not Available.", "Warning");
                    return;
                }
                else {
                    classHelper.query = @"BEGIN TRY 
                             BEGIN TRANSACTION ";

                    classHelper.query += @"IF EXISTS (SELECT JOB_ORDER_MASTER_ID FROM JOB_ORDER_MASTER WHERE JOB_ORDER_MASTER_ID = '" + id + @"') 
                    BEGIN
	                    UPDATE JOB_ORDER_MASTER SET [DATE] = '" + dtpDate.Value.ToString() + @"',
                        [DESCRIPTION] = '" + classHelper.AvoidInjection(txtDescription.Text) + @"',
	                    MODIFICATION_DATE = GETDATE(),
	                    MODIFIED_BY = '" + Classes.Helper.userId + @"',
                        [STATUS] = '" + jobCompleted + @"',
                        INVOICE_NO = '" + lblInvoiceNo.Text + @"'
                        WHERE JOB_ORDER_MASTER_ID = '" + id + @"';
                    END
                    ELSE
                    BEGIN
                        INSERT INTO JOB_ORDER_MASTER
                        ([DATE],[DESCRIPTION], CREATED_BY, CREATION_DATE,[STATUS],INVOICE_NO)
	                    VALUES('" + dtpDate.Value.ToString() + "', '" + classHelper.AvoidInjection(txtDescription.Text) + @"',
                        '" + Classes.Helper.userId + @"', GETDATE(),'" + jobCompleted + @"','" + lblInvoiceNo.Text + @"');
                    END";

                    classHelper.query += @" DELETE FROM JOB_ORDER_PRODUCTS WHERE JOB_ORDER_MASTER_ID = '" + id + "'";

                    foreach (DataGridViewRow rows in grdItems.Rows)
                    {
                        classHelper.query += @"INSERT INTO JOB_ORDER_PRODUCTS (JOB_ORDER_MASTER_ID,PRODUCT_MASTER_ID,QTY) VALUES 
                    (" + masterId + ",'" + rows.Cells["productId"].Value.ToString() + "'," + rows.Cells["qty"].Value.ToString() + @");";
                    }

                    classHelper.query += @"DELETE FROM JOB_ORDER_MATERIALS WHERE JOB_ORDER_MASTER_ID = '" + id + "'";

                    foreach (DataGridViewRow rows in grdMaterial.Rows)
                    {
                        classHelper.query += @"INSERT INTO JOB_ORDER_MATERIALS (JOB_ORDER_MASTER_ID,JOB_ORDER_PRODUCT_ID,MATERIAL_ID,QTY) VALUES 
                    (" + masterId + ",'" + rows.Cells["rawProductId"].Value.ToString() + "','" + rows.Cells["rawId"].Value.ToString() + @"',
                    " + rows.Cells["rawQty"].Value.ToString() + @");";
                    }

                    classHelper.query += @" DELETE FROM MATERIAL_ITEM_LEDGER WHERE REF_NO = '" + id + @"' AND ENTRY_FROM = 'JOB ORDER MATERIAL';";

                    classHelper.query += @" DELETE FROM PRODUCT_ITEM_LEDGER WHERE REF_NO = '" + id + @"' AND ENTRY_FROM = 'JOB ORDER PRODUCT';";

                    foreach (DataGridViewRow rows in grdMaterial.Rows)
                    {
                        classHelper.query += @" INSERT INTO MATERIAL_ITEM_LEDGER 
                        ([DATE],MATERIAL_ID,REF_NO,ENTRY_FROM,STOCK_IN,STOCK_OUT,COST_AMT,SALE_AMT,L_ID,CREATED_BY,CREATION_DATE,COMPANY_ID)
                        VALUES('" + dtpDate.Value.ToString() + "','" + rows.Cells["rawId"].Value.ToString() + "'," + masterId + @",
                            'JOB ORDER MATERIAL','0','" + rows.Cells["rawQty"].Value.ToString() + @"',
                            '0','0','1','" + Classes.Helper.userId + "',GETDATE(),'1');";
                    }

                    foreach (DataGridViewRow rows in grdItems.Rows)
                    {
                        classHelper.query += @" INSERT INTO PRODUCT_ITEM_LEDGER 
                        ([DATE],PRODUCT_ID,REF_NO,ENTRY_FROM,STOCK_IN,STOCK_OUT,COST_AMT,SALE_AMT,L_ID,CREATED_BY,CREATION_DATE,COMPANY_ID)
                        VALUES('" + dtpDate.Value.ToString() + "','" + rows.Cells["productId"].Value.ToString() + "'," + masterId + @",
                            'JOB ORDER PRODUCT','" + rows.Cells["qty"].Value.ToString() + @"',
                            '0','0','0','1','" + Classes.Helper.userId + "',GETDATE(),'1');";
                    }

                    //if (chkJobCompleted.Checked == true)
                    //{
                        

                    //}

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
        }

        private void LoadGridData(DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.grdSearch.Rows[e.RowIndex];
            if (e.RowIndex >= 0)
            {
                id = Convert.ToInt32(row.Cells["ID"].Value.ToString());
                lblInvoiceNo.Text = row.Cells["INVOICE #"].Value.ToString();
                dtpDate.Text = row.Cells["DATE"].Value.ToString();
                txtDescription.Text = row.Cells["DESCRIPTION"].Value.ToString();
                grdMaterial.Rows.Clear();
                grdItems.Rows.Clear();
                LoadJobProducts(id);
                LoadJobMaterials(id);
            }
        }

        private void grdSearch_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }

        private void grdSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadGridData(e);
        }

        private void btnMaterialExpense_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                classHelper.ShowMessageBox("Please Select any Job Order.", "Information");
            }
            else {
                Forms.Job.frmJobOrderMaterialExpenses frm = new frmJobOrderMaterialExpenses(id);
                frm.ShowDialog();
            }
        }

        private void btnProcessExpense_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                classHelper.ShowMessageBox("Please Select any Job Order.", "Information");
            }
            else
            {
                Forms.Job.frmJobProductMatrialExpenses frm = new frmJobProductMatrialExpenses(id);
                frm.ShowDialog();
            }
        }

        private void txtProductQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            classHelper.CheckNumber(e);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            classHelper.JobOrder_Search(txtSearch, grdSearch);
        }

        private void PrintInvoice()
        {
            classHelper.mds.Tables["SaleInvoice"].Clear();

            grdItems.Sort(this.grdItems.Columns["productName"],
                                    ListSortDirection.Ascending);

            foreach (DataGridViewRow rows in grdItems.Rows)
            {
                classHelper.dataR = classHelper.mds.Tables["SaleInvoice"].NewRow();
                classHelper.dataR["InvoiceNo"] = lblInvoiceNo.Text;
                classHelper.dataR["date"] = dtpDate.Value.ToShortDateString();
                classHelper.dataR["description"] = txtDescription.Text;
                classHelper.dataR["itemName"] = rows.Cells["productName"].Value.ToString();
                classHelper.dataR["qty"] = Convert.ToDouble(rows.Cells["qty"].Value.ToString());
                classHelper.mds.Tables["SaleInvoice"].Rows.Add(classHelper.dataR);
            }

            classHelper.rpt = new ERP_Maaz_Oil.Forms.Reporting.frmReports();
            classHelper.rpt.GenerateReport("JobOrder", classHelper.mds);
            classHelper.rpt.ShowDialog();
        }

        private void btnPrint_Click(object sender, EventArgs e)
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

        private void Delete()
        {
            classHelper.query = @" BEGIN TRY 
                             BEGIN TRANSACTION ";

            classHelper.query += @" DELETE FROM JOB_ORDER_PRODUCTS WHERE JOB_ORDER_MASTER_ID = '" + id + @"';
            DELETE FROM JOB_ORDER_MATERIALS WHERE JOB_ORDER_MASTER_ID = '" + id + @"';
            DELETE FROM MATERIAL_ITEM_LEDGER WHERE REF_NO = '" + id + @"' AND ENTRY_FROM = 'JOB ORDER MATERIAL';
            DELETE FROM PRODUCT_ITEM_LEDGER WHERE REF_NO = '" + id + @"' AND ENTRY_FROM = 'JOB ORDER PRODUCT';
            DELETE FROM JOB_ORDER_MASTER WHERE JOB_ORDER_MASTER_ID = '" + id + @"'";

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
