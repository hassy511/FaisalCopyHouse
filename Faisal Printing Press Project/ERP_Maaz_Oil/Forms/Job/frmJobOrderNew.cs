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
    public partial class frmJobOrderNew : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        int id = 0;

        public frmJobOrderNew()
        {
            InitializeComponent();
        }

        private void Clear() {
            txtSearch.Clear();
            dtpDate.Value = DateTime.Now;
            cmbProduct.SelectedIndex = 0;
            txtProductQty.Text = "0";
            grdItems.Rows.Clear();
            grdMaterial.Rows.Clear();
            id = 0;
        }
        
        private void LoadGrid()
        {
            classHelper.query = @"SELECT A.[ID],A.[DATE],B.PRODUCT_MASTER_ID,C.PRODUCT_NAME,B.QTY
            FROM PRODUCTION_MASTER A
            INNER JOIN PRODUCTION_DETAIL B ON A.ID = B.PRODUCTION_MASTER_ID
            INNER JOIN PRODUCT_MASTER C ON B.PRODUCT_MASTER_ID = C.PM_ID
            ORDER BY A.ID DESC";
            classHelper.LoadGrid(grdSearch, classHelper.query);
        }
        private void LoadProducts()
        {
            classHelper.LoadProducts(cmbProduct);
        }

        private void LoadProductionProduct(int jobOrderId)
        {
            classHelper.LoadProductionProduct(grdItems, jobOrderId);
        }

        private void frmJobOrder_Load(object sender, EventArgs e)
        {
            LoadGrid();
            LoadProducts();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void LoadProductRaw()
        {
            classHelper.LoadProductRaw(grdMaterial, Convert.ToInt32(cmbProduct.SelectedValue.ToString()), Convert.ToDecimal(txtProductQty.Text));
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

        private void RemoveProductRaw(int productId)
        {
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
            if (grdItems.Rows.Count <= 0)
            {
                classHelper.ShowMessageBox("Please add Product.", "Warning");
                cmbProduct.Focus();
            }
            else {
                string masterId = id.ToString();
                if (id == 0) {
                    masterId = "(SELECT ISNULL(MAX(ID),1) FROM PRODUCTION_MASTER)";
                }

                classHelper.query = @"BEGIN TRY 
                             BEGIN TRANSACTION ";

                classHelper.query += @"IF EXISTS (SELECT ID FROM PRODUCTION_MASTER WHERE ID = '" + id + @"') 
                    BEGIN
	                    UPDATE PRODUCTION_MASTER SET [DATE] = '" + dtpDate.Value.ToString() + @"',
	                    MODIFICATION_DATE = GETDATE(),
	                    MODIFIED_BY = '" + Classes.Helper.userId + @"'
                        WHERE ID = '" + id + @"';
                    END
                    ELSE
                    BEGIN
                        INSERT INTO PRODUCTION_MASTER
                        ([DATE], CREATED_BY, CREATION_DATE)
	                    VALUES('" + dtpDate.Value.ToString() + @"', 
                        '" + Classes.Helper.userId + @"', GETDATE());
                    END";

                classHelper.query += @" DELETE FROM PRODUCTION_DETAIL WHERE PRODUCTION_MASTER_ID = '" + id + "'";

                foreach (DataGridViewRow rows in grdItems.Rows)
                {
                    classHelper.query += @"INSERT INTO PRODUCTION_DETAIL (PRODUCTION_MASTER_ID,PRODUCT_MASTER_ID,QTY) VALUES 
                    (" + masterId + ",'" + rows.Cells["productId"].Value.ToString() + "'," + rows.Cells["qty"].Value.ToString() + @");";
                }

                foreach (DataGridViewRow rows in grdItems.Rows)
                {
                    classHelper.query += @" INSERT INTO PRODUCT_ITEM_LEDGER 
                        ([DATE],PRODUCT_ID,REF_NO,ENTRY_FROM,STOCK_IN,STOCK_OUT,COST_AMT,SALE_AMT,L_ID,CREATED_BY,CREATION_DATE,COMPANY_ID)
                        VALUES('" + dtpDate.Value.ToString() + "','" + rows.Cells["productId"].Value.ToString() + "'," + masterId + @",
                            'PRODUCTION PRODUCT','" + rows.Cells["qty"].Value.ToString() + @"',
                            '0','0','0','1','" + Classes.Helper.userId + "',GETDATE(),'1');";
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

        private void LoadGridData(DataGridViewCellEventArgs e)
        {

          DataGridViewRow row = this.grdSearch.Rows[e.RowIndex];
            if (e.RowIndex >= 0)
            {
                id = Convert.ToInt32(row.Cells["ID"].Value.ToString());
                dtpDate.Text = row.Cells["DATE"].Value.ToString();
                grdItems.Rows.Clear();
                LoadProductionProduct(id);
            }
    }

        private void grdSearch_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            grdSearch.Columns["PRODUCT_MASTER_ID"].Visible = false;
            grdSearch.Columns["ID"].Visible = false;
        }

        private void grdSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadGridData(e);
        }


        private void txtProductQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            classHelper.CheckNumber(e);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            (grdSearch.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
            [" + grdSearch.Columns["PRODUCT_NAME"].Name.ToString() + "] LIKE '%" + classHelper.AvoidInjection(txtSearch.Text) + "%'");
            grdSearch.ClearSelection();
        }

        //private void PrintInvoice()
        //{
        //    classHelper.mds.Tables["SaleInvoice"].Clear();

        //    grdItems.Sort(this.grdItems.Columns["productName"],
        //                            ListSortDirection.Ascending);

        //    foreach (DataGridViewRow rows in grdItems.Rows)
        //    {
        //        classHelper.dataR = classHelper.mds.Tables["SaleInvoice"].NewRow();
        //        classHelper.dataR["InvoiceNo"] = lblInvoiceNo.Text;
        //        classHelper.dataR["date"] = dtpDate.Value.ToShortDateString();
        //        classHelper.dataR["description"] = txtDescription.Text;
        //        classHelper.dataR["itemName"] = rows.Cells["productName"].Value.ToString();
        //        classHelper.dataR["qty"] = Convert.ToDouble(rows.Cells["qty"].Value.ToString());
        //        classHelper.mds.Tables["SaleInvoice"].Rows.Add(classHelper.dataR);
        //    }

        //    classHelper.rpt = new ERP_Maaz_Oil.Forms.Reporting.frmReports();
        //    classHelper.rpt.GenerateReport("JobOrder", classHelper.mds);
        //    classHelper.rpt.ShowDialog();
        //}

        private void Delete()
        {
            classHelper.query = @" BEGIN TRY 
                             BEGIN TRANSACTION ";

            classHelper.query += @" 
            DELETE FROM PRODUCTION_DETAIL WHERE PRODUCTION_MASTER_ID = '" + id + @"';
            DELETE FROM PRODUCTION_MASTER WHERE ID = '" + id + @"';
            DELETE FROM PRODUCT_ITEM_LEDGER WHERE REF_NO = '" + id + @"' AND ENTRY_FROM = 'PRODUCTION PRODUCT';";

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

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void grdSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void grdMaterial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void grdItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
