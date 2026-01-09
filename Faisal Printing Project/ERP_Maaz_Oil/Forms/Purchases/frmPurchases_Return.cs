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
    public partial class frmPurchases_Return : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        int id = 0;

        public frmPurchases_Return()
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
            classHelper.query = @"
            SELECT A.ID AS [ID],A.INVOICE_NO AS [INVOICE #],
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
        private void LoadMaterials()
        {
            classHelper.LoadRawMaterials(cmbMaterials);
        }

        private void Clear()
        {
            GeneratePRNumber();
            dtpDate.Value = DateTime.Now;
            cmbSupplier.SelectedIndex = 0;
            txtDescription.Clear();
            cmbMaterials.SelectedIndex = 0;
            txtQty.Text = "0";
            txtRate.Text = "0";
            txtTotal.Text = "0";
            txtSearch.Clear();
            id = 0;
            gridMaterials.Rows.Clear();
        }

        private void Save()
        {
            if (cmbSupplier.SelectedIndex == 0)
            {
                classHelper.ShowMessageBox("Supplier is not selected, please select Supplier.", "Warning");
                cmbSupplier.Focus();
            }
            else if (gridMaterials.Rows.Count <= 0)
            {
                classHelper.ShowMessageBox("Add Raw Material.", "Warning");
                cmbMaterials.Focus();
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

                classHelper.query += @"IF EXISTS (SELECT ID from PURCHASE_RETURN_MASTER WHERE ID ='" + id + @"') 
            BEGIN
                UPDATE PURCHASE_RETURN_MASTER SET DATE = '" + dtpDate.Value.ToString() + "',SUPPLIER_ID = '" + cmbSupplier.SelectedValue.ToString() + @"',
                DESCRIPTION = '" + classHelper.AvoidInjection(txtDescription.Text) + @"',
                MODIFICATION_DATE = GETDATE(),MODIFIED_BY = '" + Classes.Helper.userId + @"' WHERE ID = '" + id + @"';
            END
            ELSE
            BEGIN
                INSERT INTO PURCHASE_RETURN_MASTER (DATE,SUPPLIER_ID,DESCRIPTION,CREATION_DATE,CREATED_BY,INVOICE_NO) 
                VALUES ('" + dtpDate.Value.ToString() + "','" + cmbSupplier.SelectedValue.ToString() + @"',
                '" + classHelper.AvoidInjection(txtDescription.Text) + @"',
                GETDATE(),'" + Classes.Helper.userId + "','" + lblInvoice.Text + @"')
            END
            
            DELETE FROM LEDGERS WHERE REF_ID = " + id + @" AND ENTRY_OF = 'PURCHASES RETURN'
            
            INSERT INTO LEDGERS(DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
            VALUES('" + dtpDate.Value.ToString() + "','" + cmbSupplier.SelectedValue.ToString() + "'," + masterId + ",'PURCHASES RETURN','" + lblInvoice.Text + @"',
            '" + txtTotal.Text + "',0,'P.R # " + lblInvoice.Text + @"','" + Classes.Helper.userId + @"',GETDATE(),1);
            
            INSERT INTO LEDGERS(DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
            VALUES('" + dtpDate.Value.ToString() + "','" + Classes.Helper.purchasesReturnId + "'," + masterId + ",'PURCHASES RETURN','" + lblInvoice.Text + @"',
            0,'" + txtTotal.Text + "','P.R # " + lblInvoice.Text + @"','" + Classes.Helper.userId + @"',GETDATE(),1);";

                classHelper.query += @"DELETE FROM PURCHASE_RETURN_DETAIL WHERE MASTER_ID = '" + id + @"'";

                foreach (DataGridViewRow rows in gridMaterials.Rows)
                {
                    classHelper.query += @"INSERT INTO PURCHASE_RETURN_DETAIL (MASTER_ID,MATERIAL_ID,QTY,RATE) VALUES 
            (" + masterId + ",'" + rows.Cells["rawId"].Value.ToString() + "','" + rows.Cells["qty"].Value.ToString() + @"',
                '" + rows.Cells["rate"].Value.ToString() + @"');";
                }

                classHelper.query += @" DELETE FROM MATERIAL_ITEM_LEDGER WHERE REF_NO = '" + id + @"' AND ENTRY_FROM = 'PURCHASES RETURN';";

                foreach (DataGridViewRow rows in gridMaterials.Rows)
                {
                    classHelper.query += @" INSERT INTO MATERIAL_ITEM_LEDGER 
                ([DATE],MATERIAL_ID,REF_NO,ENTRY_FROM,STOCK_IN,STOCK_OUT,COST_AMT,SALE_AMT,L_ID,CREATED_BY,CREATION_DATE,COMPANY_ID)
                VALUES('" + dtpDate.Value.ToString() + "','" + rows.Cells["rawId"].Value.ToString() + "'," + masterId + @",
                    'PURCHASES RETURN','0','" + rows.Cells["qty"].Value.ToString() + @"',
                    '" + rows.Cells["rate"].Value.ToString() + @"','0','1','" + Classes.Helper.userId + "',GETDATE(),'1');";
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

        private void LoadPurchaseReturnDetails(int prId)
        {
            classHelper.LoadPurchasesReturnDetail(gridMaterials, prId);
        }

        private void LoadGridData(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.grdSearch.Rows[e.RowIndex];
                id = Convert.ToInt32(row.Cells["ID"].Value.ToString());
                lblInvoice.Text = row.Cells["INVOICE #"].Value.ToString();
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
            LoadMaterials();
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
                txtTotal.Text = gridMaterials.Rows.Cast<DataGridViewRow>()
                    .Sum(t => Convert.ToDecimal(t.Cells["total"].Value)).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbMaterials.SelectedIndex == 0)
            {
                classHelper.ShowMessageBox("Material is not selected, please select Material.", "Warning");
                cmbMaterials.Focus();
            }
            else if (txtQty.Text.Equals("") || txtQty.Text.Equals("0"))
            {
                classHelper.ShowMessageBox("Please add Material Qty.", "Warning");
                txtQty.Focus();
            }
            else if (txtRate.Text.Equals("") || txtRate.Text.Equals("0"))
            {
                classHelper.ShowMessageBox("Please add Material Rate.", "Warning");
                txtRate.Focus();
            }
            else
            {
                gridMaterials.Rows.Add(cmbMaterials.SelectedValue.ToString(), cmbMaterials.Text, classHelper.AvoidInjection(txtQty.Text),
                classHelper.AvoidInjection(txtRate.Text),Convert.ToDecimal(classHelper.AvoidInjection(txtQty.Text)) * 
                Convert.ToDecimal(classHelper.AvoidInjection(txtRate.Text)));
                TotalSum();
                cmbMaterials.SelectedIndex = 0;
                txtQty.Text = "0";
                txtRate.Text = "0";
            }
        }

        private void gridMaterials_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.gridMaterials.Rows[e.RowIndex];
                cmbMaterials.SelectedValue = row.Cells["rawId"].Value.ToString();
                txtQty.Text = row.Cells["qty"].Value.ToString();
                txtRate.Text = row.Cells["rate"].Value.ToString();
                gridMaterials.Rows.RemoveAt(e.RowIndex);
                TotalSum();
            }
        }

        private void Delete()
        {

            classHelper.query = @" BEGIN TRY 
                             BEGIN TRANSACTION ";

            classHelper.query += @" DELETE FROM LEDGERS WHERE REF_ID = '" + id + @"' AND ENTRY_OF = 'PURCHASES RETURN';
            DELETE FROM MATERIAL_ITEM_LEDGER WHERE REF_NO = '" + id + @"' AND ENTRY_FROM = 'PURCHASES RETURN';
            DELETE FROM PURCHASE_RETURN_DETAIL WHERE MASTER_ID = '" + id + @"';            
            DELETE FROM PURCHASE_RETURN_MASTER WHERE ID = '" + id + @"'";

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

        private void cmbSupplier_Leave(object sender, EventArgs e)
        {
            if (id == 0)
            {
                int accountId = cmbSupplier.SelectedValue == null ? 0 : Convert.ToInt32(cmbSupplier.SelectedValue.ToString());
                if (classHelper.GetAccountStatus(accountId).Equals("1"))
                {
                    MessageBox.Show("Account is Deactivate, Please select another account.", "Error");
                    cmbSupplier.Focus();
                }
            }
        }

        private void grdSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblInvoice_Click(object sender, EventArgs e)
        {

        }

        private void PrintInvoice()
        {
            classHelper.mds.Tables["PI"].Clear();
            foreach (DataGridViewRow rows in gridMaterials.Rows)
            {
                classHelper.dataR = classHelper.mds.Tables["PI"].NewRow();
                classHelper.dataR["PI_num"] = lblInvoice.Text;
                classHelper.dataR["date"] = dtpDate.Value.ToShortDateString();
                classHelper.dataR["supplier"] = cmbSupplier.Text;
                classHelper.dataR["description"] = txtDescription.Text;
                classHelper.dataR["material"] = rows.Cells["rawMaterial"].Value.ToString();
                classHelper.dataR["qty"] = Convert.ToDouble(rows.Cells["qty"].Value.ToString());
                classHelper.dataR["rate"] = Convert.ToDouble(rows.Cells["rate"].Value.ToString());
                classHelper.dataR["total"] = Convert.ToDouble(rows.Cells["total"].Value.ToString());
                classHelper.dataR["creditDays"] = "";
                classHelper.dataR["vehicleNo"] = "";
                classHelper.dataR["dueDate"] = dtpDate.Value.ToShortDateString();
                classHelper.mds.Tables["PI"].Rows.Add(classHelper.dataR);
            }
            classHelper.rpt = new ERP_Maaz_Oil.Forms.Reporting.frmReports();
            classHelper.rpt.GenerateReport("PR", classHelper.mds);
            classHelper.rpt.ShowDialog();
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
    }

}

