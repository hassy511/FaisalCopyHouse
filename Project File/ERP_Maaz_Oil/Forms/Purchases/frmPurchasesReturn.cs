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
    public partial class frmPurchasesReturn : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        int id = 0;
        bool isEdit = false;
        public frmPurchasesReturn()
        {
            InitializeComponent();
        }

        private void GeneratePRNumber()
        {
            classHelper.query = "SELECT ISNULL(COUNT(ID),0)+1 FROM PURCHASE_RETURN_MASTER";
            lblInvoice.Text = "PR-" + classHelper.GetMaxValue(classHelper.query) + "-" + DateTime.Now.Year;
        }

        private void LoadGrid()
        {
            classHelper.query = @" SELECT A.ID AS [ID],A.INVOICE_NO AS [INVOICE #],
            A.[DATE],B.COA_NAME AS [SUPPLIER],A.[DESCRIPTION],
            A.SUPPLIER_ID
            FROM PURCHASE_RETURN_MASTER A
            INNER JOIN COA B ON A.SUPPLIER_ID = B.COA_ID
            ORDER BY ID DESC";
            classHelper.LoadGrid(grdSearch, classHelper.query);
        }

        private void LoadSuppliers()
        {
            classHelper.LoadSuppliers(cmbSupplier);
        }
        private void LoadProducts()
        {
            classHelper.LoadProducts(cmbProducts);
        }

        private void Clear()
        {
            GeneratePRNumber();
            dtpDate.Value = DateTime.Now;
            cmbSupplier.SelectedIndex = 0;
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

        private void Save(){
        {
            if (cmbSupplier.SelectedIndex == 0)
            {
                classHelper.ShowMessageBox("Supplier is not selected, please select Supplier.", "Warning");
                cmbSupplier.Focus();
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
                    masterId = "(SELECT MAX(ID) FROM PURCHASE_RETURN_MASTER)";
                }

                classHelper.query = @"BEGIN TRY 
                    BEGIN TRANSACTION ";

                classHelper.query += @"IF EXISTS (select ID from PURCHASE_RETURN_MASTER WHERE ID ='" + id + @"') 
                 BEGIN
                     UPDATE PURCHASE_RETURN_MASTER SET DATE = '" + dtpDate.Value.ToString() + @"',  
                     SUPPLIER_ID = '" + cmbSupplier.SelectedValue.ToString() + @"',
                     DESCRIPTION = '" + classHelper.AvoidInjection(txtDescription.Text) + @"',
                     MODIFICATION_DATE = GETDATE(),MODIFIED_BY = '" + Classes.Helper.userId + @"'
                     WHERE ID = '" + id + @"';
                 END
                 ELSE
                 BEGIN
                     INSERT INTO PURCHASE_RETURN_MASTER (DATE,SUPPLIER_ID,DESCRIPTION,CREATION_DATE,CREATED_BY,INVOICE_NO) 
                     VALUES ('" + dtpDate.Value.ToString() + "','" + cmbSupplier.SelectedValue.ToString() + @"',
                     '" + classHelper.AvoidInjection(txtDescription.Text) + @"',
                     GETDATE(),'" + Classes.Helper.userId + @"',
                     '" + lblInvoice.Text + @"');
                 END

                DELETE FROM LEDGERS WHERE REF_ID = " + id + @" AND ENTRY_OF = 'PURCHASE RETURN'

                INSERT INTO LEDGERS(DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
                VALUES('" + dtpDate.Value.ToString() + "','"+ cmbSupplier.SelectedValue.ToString() +
                        "'," + masterId + ",'PURCHASE RETURN','" + lblInvoice.Text + @"', '" + txtTotal.Text + "',0,'P.R # " + lblInvoice.Text + " / DAYS PAYMENT)','" + Classes.Helper.userId + @"',GETDATE(),1);

                INSERT INTO LEDGERS(DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
                VALUES('" + dtpDate.Value.ToString() + "','" + Classes.Helper.purchaseReturnId + "'," + masterId + ",'PURCHASE RETURN','" + lblInvoice.Text + @"',
                0,'" + txtTotal.Text + "','P.R # " + lblInvoice.Text + " / DAYS PAYMENT)','" + Classes.Helper.userId + @"',GETDATE(),1);";

                classHelper.query += @"DELETE FROM PURCHASE_RETURN_DETAIL WHERE PURCHASE_RETURN_MASTER_ID = '" + id + @"'";

                foreach (DataGridViewRow rows in gridProducts.Rows)
                {
                    classHelper.query += @" INSERT INTO PURCHASE_RETURN_DETAIL (PURCHASE_RETURN_MASTER_ID,MATERIAL_ID,QTY,RATE) VALUES (" + masterId + ",'" + rows.Cells["productId"].Value.ToString() + "','" + rows.Cells["qty"].Value.ToString() + @"','" + rows.Cells["rate"].Value.ToString() + @"');";
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

        private void LoadPurchaseReturnDetails(int prId)
        {
            classHelper.LoadPurchasesReturnDetail(gridProducts, prId);
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
                cmbSupplier.SelectedValue = row.Cells["SUPPLIER_ID"].Value.ToString();
                txtDescription.Text = row.Cells["DESCRIPTION"].Value.ToString();
                LoadPurchaseReturnDetails(id);
                TotalSum();
            }
        }

        private void frm_AddGroupAccounts_Load(object sender, EventArgs e)
        {
            GeneratePRNumber();
            LoadGrid();
            LoadSuppliers();
            LoadProducts();
        }

        private void txtSEARCH_TextChanged(object sender, EventArgs e)
        {
            (grdSearch.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
            [" + grdSearch.Columns["SUPPLIER"].Name.ToString() + "] LIKE '%" + classHelper.AvoidInjection(txtSearch.Text) + "%' OR ["
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



        

        private void txtCreditDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            classHelper.CheckNumber(e);
        }
        private void Delete()
        {

            classHelper.query = @" BEGIN TRY 
                             BEGIN TRANSACTION ";

            classHelper.query += @" DELETE FROM LEDGERS WHERE REF_ID = '" + id + @"' AND ENTRY_OF = 'PURCHASE RETURN';
            DELETE FROM MATERIAL_ITEM_LEDGER WHERE REF_NO = '" + id + @"' AND ENTRY_FROM = 'PURCHASE RETURN';
            DELETE FROM PRODUCT_ITEM_LEDGER WHERE REF_NO = '" + id + @"' AND ENTRY_FROM = 'PURCHASE RETURN';
            DELETE FROM PURCHASE_RETURN_MASTER WHERE ID = '" + id + @"';            
            DELETE FROM PURCHASE_RETURN_DETAIL WHERE PURCHASE_RETURN_MASTER_ID = '" + id + @"'";

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

        private void LoadPODetails(int poId)
        {
            classHelper.query = @"	SELECT B.MATERIAL_ID,C.PRODUCT_NAME as [PRODUCT NAME],B.QTY,B.RATE,B.QTY - ISNULL(D.QTY,0) AS [BALANCE QTY]
	        FROM PURCHASES_ORDER A
	        INNER JOIN PURCHASES_ORDER_DETAILS B ON A.PO_ID = B.PO_ID
	        INNER JOIN PRODUCT_MASTER C ON B.MATERIAL_ID = C.PM_ID
	        LEFT JOIN (
		        SELECT B.MATERIAL_ID,SUM(B.QTY) AS [QTY]
		        FROM PURCHASE_MASTER A
		        INNER JOIN PURCHASE_DETAIL B ON A.PURCHASE_MASTER_ID = B.PURCHASE_MASTER_ID 
		        WHERE A.PO_ID = '" + poId + @"'
		        GROUP BY B.MATERIAL_ID
	        ) D ON B.MATERIAL_ID = D.MATERIAL_ID
	        WHERE A.PO_ID = '" + poId + @"'
	        ORDER BY [PRODUCT NAME]";
            classHelper.LoadGrid(gridProducts, classHelper.query);
        }

        private void cmbSupplier_Leave(object sender, EventArgs e)
        {
            if (!classHelper.CheckAccountExists(cmbSupplier.Text))
            {
                string supplierName = cmbSupplier.Text;
                DialogResult dialogResult = MessageBox.Show("Do you want to add " + cmbSupplier.Text + " Account?", "Add New Account", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    using (frmChartOfAccounts frm = new frmChartOfAccounts(20, 12, classHelper.AvoidInjection(cmbSupplier.Text), 1))
                    {
                        if (frm.ShowDialog() == System.Windows.Forms.DialogResult.Cancel || frm.ShowDialog() == System.Windows.Forms.DialogResult.Abort)
                        {
                            LoadSuppliers();
                            cmbSupplier.Text = supplierName;
                        }
                    }
                }
                else
                {
                    cmbSupplier.SelectedIndex = 0;
                    cmbSupplier.Focus();
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



