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
    public partial class frmPurchases_New : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        int id = 0;
        bool isEdit = false;
        public frmPurchases_New()
        {
            InitializeComponent();
        }

        private void GeneratePINumber()
        {
            classHelper.query = "SELECT ISNULL(COUNT(PURCHASE_MASTER_ID),0)+1 FROM PURCHASE_MASTER";
            lblInvoice.Text = "PI-" + classHelper.GetMaxValue(classHelper.query) + "-" + DateTime.Now.Year;
        }

        private void LoadGrid()
        {
            classHelper.query = @" SELECT A.PURCHASE_MASTER_ID AS [ID],A.INVOICE_NO AS [INVOICE #],
            A.[DATE],B.COA_NAME AS [SUPPLIER],A.[DESCRIPTION],
            A.CREDIT_DAYS,A.SUPPLIER_ID,TERM,PO_ID
            FROM PURCHASE_MASTER A
            INNER JOIN COA B ON A.SUPPLIER_ID = B.COA_ID
            ORDER BY PURCHASE_MASTER_ID DESC";
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
            GeneratePINumber();
            dtpDate.Value = DateTime.Now;
            cmbSupplier.SelectedIndex = 0;
            txtCreditDays.Text = "0";
            txtDescription.Clear();
            cmbProducts.SelectedIndex = 0;
            txtQty.Text = "0";
            txtRate.Text = "0";
            txtTotal.Text = "0";
            txtSearch.Clear();
            id = 0;
            isEdit = false;
            gridProducts.Rows.Clear();
            chkPO.Checked = false;

            if (cmbPO.Items.Count > 0) {
                cmbPO.SelectedIndex = 0;
            }

            rdbCredit.Checked = true;
            LoadGrid();
        }

        private void Save(){
        {
            if (cmbSupplier.SelectedIndex == 0)
            {
                classHelper.ShowMessageBox("Supplier is not selected, please select Supplier.", "Warning");
                cmbSupplier.Focus();
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
                    masterId = "(SELECT MAX(PURCHASE_MASTER_ID) FROM PURCHASE_MASTER)";
                }

                    // Determinetype based on selected radio button
                    char term = '0';
                    if (rdbCredit.Checked == true) {
                        term = '1';
                    }

                    int poId = 0;
                    if (chkPO.Checked == true && cmbPO.SelectedValue.ToString().Equals("0")) {
                        poId = Convert.ToInt32(cmbPO.SelectedValue.ToString());
                    }
                
                classHelper.query = @"BEGIN TRY 
                    BEGIN TRANSACTION ";

                classHelper.query += @"IF EXISTS (select PURCHASE_MASTER_ID from PURCHASE_MASTER WHERE PURCHASE_MASTER_ID ='" + id + @"') 
                 BEGIN
                     UPDATE PURCHASE_MASTER SET DATE = '" + dtpDate.Value.ToString() + @"',  
                     SUPPLIER_ID = '" + cmbSupplier.SelectedValue.ToString() + @"',
                     DESCRIPTION = '" + classHelper.AvoidInjection(txtDescription.Text) + @"',
                     CREDIT_DAYS = '" + classHelper.AvoidInjection(txtCreditDays.Text) + @"',
                     TERM = '" + term+ @"',PO_ID = '"+cmbPO.SelectedValue+@"',
                     MODIFICATION_DATE = GETDATE(),MODIFIED_BY = '" + Classes.Helper.userId + @"'
                     WHERE PURCHASE_MASTER_ID = '" + id + @"';
                 END
                 ELSE
                 BEGIN
                     INSERT INTO PURCHASE_MASTER (DATE,SUPPLIER_ID,DESCRIPTION,CREDIT_DAYS,TERM,CREATION_DATE,CREATED_BY,INVOICE_NO,PO_ID) 
                     VALUES ('" + dtpDate.Value.ToString() + "','" + cmbSupplier.SelectedValue.ToString() + @"',
                     '" + classHelper.AvoidInjection(txtDescription.Text) + @"',
                     '" + classHelper.AvoidInjection(txtCreditDays.Text) + "', '" + term + @"', GETDATE(),'" + Classes.Helper.userId + @"',
                     '" + lblInvoice.Text + @"','"+poId+@"');
                 END

                DELETE FROM LEDGERS WHERE REF_ID = " + id + @" AND ENTRY_OF = 'PURCHASES'

                INSERT INTO LEDGERS(DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
                VALUES('" + dtpDate.Value.ToString() + "','"+ cmbSupplier.SelectedValue.ToString() +
                        "'," + masterId +",'PURCHASES','" + lblInvoice.Text + @"', 0,'" + txtTotal.Text + "','P.I # " + lblInvoice.Text + " /" + txtCreditDays.Text + " DAYS PAYMENT)','" + Classes.Helper.userId + @"',GETDATE(),1);

                INSERT INTO LEDGERS(DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
                VALUES('" + dtpDate.Value.ToString() + "','" + Classes.Helper.purchasesId + "'," + masterId + ",'PURCHASES','" + lblInvoice.Text + @"',
                '" + txtTotal.Text + "',0,'P.I # " + lblInvoice.Text + " /" + txtCreditDays.Text + " DAYS PAYMENT)','" + Classes.Helper.userId + @"',GETDATE(),1);";

                    if (rdbCash.Checked == true) {
                        classHelper.query += @" INSERT INTO LEDGERS(DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
                        VALUES('" + dtpDate.Value.ToString() + "','" + Classes.Helper.cashId +
                        "'," + masterId + ",'PURCHASES','" + lblInvoice.Text + @"', 0,'" + txtTotal.Text + "','P.I # " + lblInvoice.Text + " /" + txtCreditDays.Text + " DAYS PAYMENT)','" + Classes.Helper.userId + @"',GETDATE(),1);

                        INSERT INTO LEDGERS(DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
                        VALUES('" + dtpDate.Value.ToString() + "','" + cmbSupplier.SelectedValue.ToString() + "'," + masterId + ",'PURCHASES','" + lblInvoice.Text + @"',
                        '" + txtTotal.Text + "',0,'P.I # " + lblInvoice.Text + " /" + txtCreditDays.Text + " DAYS PAYMENT)','" + Classes.Helper.userId + @"',GETDATE(),1);";
                    }

                classHelper.query += @"DELETE FROM PURCHASE_DETAIL WHERE PURCHASE_MASTER_ID = '" + id + @"'";

                foreach (DataGridViewRow rows in gridProducts.Rows)
                {
                    classHelper.query += @" INSERT INTO PURCHASE_DETAIL (PURCHASE_MASTER_ID,MATERIAL_ID,QTY,RATE) VALUES (" + masterId + ",'" + rows.Cells["productId"].Value.ToString() + "','" + rows.Cells["qty"].Value.ToString() + @"','" + rows.Cells["rate"].Value.ToString() + @"');";
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

                        DialogResult dialogResult = MessageBox.Show("Print Invoice?", "Purchases Invoice", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            PrintInvoice();
                        }
                        Clear();
                    }
                }
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
                classHelper.dataR["supplier"] = cmbSupplier.Text;
                classHelper.dataR["description"] = txtDescription.Text;
                classHelper.dataR["material"] = rows.Cells["productName"].Value.ToString();
                classHelper.dataR["qty"] = Convert.ToDouble(rows.Cells["qty"].Value.ToString());
                classHelper.dataR["rate"] = Convert.ToDouble(rows.Cells["rate"].Value.ToString());
                classHelper.dataR["total"] = Convert.ToDouble(rows.Cells["total"].Value.ToString());
                classHelper.dataR["creditDays"] = txtCreditDays.Text;
                classHelper.dataR["dueDate"] = DateTime.Now.AddDays(Convert.ToInt32(txtCreditDays.Text));
                classHelper.mds.Tables["PI"].Rows.Add(classHelper.dataR);
            }
            classHelper.rpt = new ERP_Maaz_Oil.Forms.Reporting.frmReports();
            classHelper.rpt.GenerateReport("PI", classHelper.mds);
            classHelper.rpt.ShowDialog();
        }

        private void LoadPurchaseDetails(int piId)
        {
            classHelper.LoadPurchasesDetail(gridProducts, piId);
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
                txtCreditDays.Text = row.Cells["CREDIT_DAYS"].Value.ToString();

                if (row.Cells["PO_ID"].Value.ToString().Equals("0"))
                {
                    chkPO.Checked = false;
                }
                else {
                    chkPO.Checked = true;
                    cmbPO.SelectedValue = row.Cells["PO_ID"].Value.ToString();
                }

                if (row.Cells["TERM"].Value.ToString().Equals("0"))
                {
                    rdbCash.Checked = true;
                }
                else
                {
                    rdbCredit.Checked = true;
                }

                LoadPurchaseDetails(id);
                TotalSum();
            }
        }

        private void frm_AddGroupAccounts_Load(object sender, EventArgs e)
        {
            GeneratePINumber();
            LoadGrid();
            LoadSuppliers();
            LoadProducts();
        }

        private void txtSEARCH_TextChanged(object sender, EventArgs e)
        {
            classHelper.PurchaseRaw_search(txtSearch, grdSearch);
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void grdSEARCH_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            grdSearch.Columns["SUPPLIER_ID"].Visible = false;
            grdSearch.Columns["TERM"].Visible = false;
            grdSearch.Columns["PO_ID"].Visible = false;
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
             //   cmbProducts.Focus();
            }
        }



        private void btnViewInvoice_Click(object sender, EventArgs e)
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

        private void txtCreditDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            classHelper.CheckNumber(e);
        }
        private void Delete()
        {

            classHelper.query = @" BEGIN TRY 
                             BEGIN TRANSACTION ";

            classHelper.query += @" DELETE FROM LEDGERS WHERE REF_ID = '" + id + @"' AND ENTRY_OF = 'PURCHASE_MASTER ';
            DELETE FROM MATERIAL_ITEM_LEDGER WHERE REF_NO = '" + id + @"' AND ENTRY_FROM = 'PURCHASE_MASTER ';
            DELETE FROM PRODUCT_ITEM_LEDGER WHERE REF_NO = '" + id + @"' AND ENTRY_FROM = 'PURCHASE_MASTER ';
            DELETE FROM PURCHASE_DETAIL WHERE PURCHASE_MASTER_ID = '" + id + @"';            
            DELETE FROM PURCHASE_MASTER WHERE PURCHASE_MASTER_ID = '" + id + @"'";

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

        private void rdbCredit_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCash.Checked == true)
            {
                txtCreditDays.Enabled = false;
            }
            else {
                txtCreditDays.Enabled = true;
            }
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
            classHelper.LoadPurchaseOrderDetail(classHelper.query,gridProducts);
        }

        private void cmbPO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPO.SelectedIndex > 0)
            {
                LoadPODetails(Convert.ToInt32(cmbPO.SelectedValue.ToString()));
            }
        }

        private void chkPO_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPO.Checked == true)
            {
                classHelper.LoadProductPurchaseOrder(cmbPO, Convert.ToInt32(cmbSupplier.SelectedValue.ToString()), isEdit);
                cmbPO.Enabled = true;

            }
            else
            {
                cmbPO.SelectedIndex = 0;
                cmbPO.Enabled = false;
            }
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



