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
    public partial class frmStockAdjustment_Raw : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        int editId = 0;
        bool isEdit = false;
        private Decimal TotalSum()
        {
            Decimal total = 0;
            try
            {
                total = grdGrid.Rows.Cast<DataGridViewRow>()
                    .Sum(t => Convert.ToDecimal(t.Cells["total"].Value));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return total;
        }
        public frmStockAdjustment_Raw()
        {
            InitializeComponent();
        }

        private void LoadGrid() {
            classHelper.query = @"SELECT A.ID IA_ID,A.[DATE],A.MATERIAL_ID,B.MATERIAL_NAME AS [MATERIAL],
            CASE WHEN A.ADD_LESS = 'A' THEN 'INCREASE' ELSE 'DECREASE' END AS [INCREASE / DECREASE],
            A.QTY,A.RATE
            FROM INVENTORY_ADJUSTMENTS_RAW A
            INNER JOIN MATERIALS B ON A.MATERIAL_ID = B.MATERIAL_ID";
            classHelper.LoadGrid(grdSearch, classHelper.query);
        }
        
        private void Clear() {
            txtSearch.Clear();
            classHelper.LoadMaterial(cmbMaterial);
            LoadGrid();
            dtpFrom.Value = DateTime.Now;
            cmbMaterial.SelectedIndex = 0;
            txtQty.Text = "0";
            txtRate.Text = "0";
            grdGrid.Rows.Clear();
            rdbIn.Checked = true;
            editId = 0;
            isEdit = false;
        }

        private void LoadAdjustmentDetail(string date) {
            classHelper.LoadAdjustmentMaterial(date,grdGrid);
        }

        private void GetRate() {
            if (rdbOut.Checked == true) {
                decimal rate = classHelper.GetProductRate(Convert.ToInt32(cmbMaterial.SelectedValue.ToString()));
                if (rate < 0)
                {
                    txtRate.Text = "0";
                }
                else
                {
                    txtRate.Text = rate.ToString();
                }
            }
        }

        private void LoadGridData(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.grdSearch.Rows[e.RowIndex];
                isEdit = true;
                dtpFrom.Value = Convert.ToDateTime(row.Cells["DATE"].Value.ToString());
                LoadAdjustmentDetail(row.Cells["DATE"].Value.ToString());
            }
        }

        private void frm_AddGroupAccounts_Load(object sender, EventArgs e)
        {
            classHelper.LoadMaterial(cmbMaterial);
            LoadGrid();
        }

        private void txtSEARCH_TextChanged(object sender, EventArgs e)
        {
           classHelper.AdjustmentSearch(txtSearch, grdSearch);
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {
            if (grdGrid.Rows.Count > 0)
            {
                classHelper.query = @"BEGIN TRY 
                BEGIN TRANSACTION ";

                foreach (DataGridViewRow rows in grdGrid.Rows)
                {
                    if (isEdit == true)
                    {
                        classHelper.query += @"UPDATE INVENTORY_ADJUSTMENTS_RAW SET 
                        [DATE] = '" + dtpFrom.Value.Date + "',MATERIAL_ID = '" + rows.Cells["materialId"].Value.ToString() + @"',
                        [ADD_LESS] = '" + rows.Cells["type"].Value.ToString() + "',QTY = '" + rows.Cells["qty"].Value.ToString() + @"',
                        [RATE] = '" + rows.Cells["rate"].Value.ToString() + @"',
                        MODIFIED_BY = '" + Classes.Helper.userId + @"',MODIFICATION_DATE = GETDATE()
                        WHERE ID = '" + rows.Cells["id"].Value.ToString() + @"';";
                    }
                    else {
                        classHelper.query += @"INSERT INTO INVENTORY_ADJUSTMENTS_RAW 
                        ([DATE],MATERIAL_ID,ADD_LESS,QTY,RATE,CREATED_BY,CREATION_DATE) VALUES 
                        ('" + dtpFrom.Value.Date + "','" + rows.Cells["materialId"].Value.ToString() + @"',
                        '" + rows.Cells["type"].Value.ToString() + "','" + rows.Cells["qty"].Value.ToString() + @"',
                        '" + rows.Cells["rate"].Value.ToString() + @"',
                        '" + Classes.Helper.userId + @"',GETDATE());";
                    }

                    string masterId = rows.Cells["id"].Value.ToString();
                    if (masterId.Equals("")) {
                        masterId = "(SELECT MAX(ID) FROM INVENTORY_ADJUSTMENTS_RAW)";
                    }

                    //Accounts Ledger
                    classHelper.query += "DELETE FROM LEDGERS WHERE REF_ID = '" + rows.Cells["id"].Value.ToString() + @"' AND ENTRY_OF = 'RAW INVENTORY ADJUSTMENT';";

                    if (rows.Cells["type"].Value.ToString().Equals("A"))
                    {
                        classHelper.query += @"INSERT INTO LEDGERS(DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
                        VALUES('" + dtpFrom.Value.Date + "', '" + Classes.Helper.inventoryId + "'," + masterId + @",'RAW INVENTORY ADJUSTMENT',
                        " + masterId + ",'" + rows.Cells["total"].Value.ToString() + @"', 0,
                        'RAW INVENTORY ADJUSTMENT - INCREASE " + rows.Cells["materialName"].Value.ToString() + " (" + rows.Cells["qty"].Value.ToString() + " x " + rows.Cells["rate"].Value.ToString() + @")', 
                        '" + Classes.Helper.userId + @"', GETDATE(), 1);";

                            classHelper.query += @"INSERT INTO LEDGERS(DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
                        VALUES('" + dtpFrom.Value.Date + "', '" + Classes.Helper.lossInventoryId + "'," + masterId + @",'RAW INVENTORY ADJUSTMENT',
                        " + masterId + ", 0,'" + rows.Cells["total"].Value.ToString() + @"',
                        'RAW INVENTORY ADJUSTMENT - INCREASE " + rows.Cells["materialName"].Value.ToString() + " (" + rows.Cells["qty"].Value.ToString() + " x " + rows.Cells["rate"].Value.ToString() + @")', 
                        '" + Classes.Helper.userId + @"', GETDATE(), 1);";
                    }
                    else
                    {
                        classHelper.query += @"INSERT INTO LEDGERS(DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
                        VALUES('" + dtpFrom.Value.Date + "', '" + Classes.Helper.lossInventoryId + "'," + masterId + @",'RAW INVENTORY ADJUSTMENT',
                        " + masterId + ",'" + rows.Cells["total"].Value.ToString() + @"', 0,
                        'RAW INVENTORY ADJUSTMENT - DECREASE " + rows.Cells["materialName"].Value.ToString() + " (" + rows.Cells["qty"].Value.ToString() + " x " + rows.Cells["rate"].Value.ToString() + @")', 
                        '" + Classes.Helper.userId + @"', GETDATE(), 1);";

                        classHelper.query += @"INSERT INTO LEDGERS(DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
                        VALUES('" + dtpFrom.Value.Date + "', '" + Classes.Helper.inventoryId + "'," + masterId + @",'RAW INVENTORY ADJUSTMENT',
                        " + masterId + ", 0,'" + rows.Cells["total"].Value.ToString() + @"',
                        'RAW INVENTORY ADJUSTMENT - DECREASE " + rows.Cells["materialName"].Value.ToString() + " (" + rows.Cells["qty"].Value.ToString() + " x " + rows.Cells["rate"].Value.ToString() + @")', 
                        '" + Classes.Helper.userId + @"', GETDATE(), 1);";
                    }

                    //Product Ledger
                    classHelper.query += "DELETE FROM MATERIAL_ITEM_LEDGER WHERE REF_NO = '" + rows.Cells["id"].Value.ToString() + @"' AND ENTRY_FROM = 'RAW INVENTORY ADJUSTMENT';";

                    if (rows.Cells["type"].Value.ToString().Equals("A"))
                    {
                        classHelper.query += @"INSERT INTO MATERIAL_ITEM_LEDGER(DATE, MATERIAL_ID, REF_NO, ENTRY_FROM, STOCK_IN, STOCK_OUT, COST_AMT, SALE_AMT, CREATED_BY, CREATION_DATE, COMPANY_ID,L_ID)
                        VALUES('" + dtpFrom.Value.Date + "', '" + rows.Cells["materialId"].Value.ToString() + "'," + masterId + @",'RAW INVENTORY ADJUSTMENT',
                        '" + rows.Cells["qty"].Value.ToString() + @"', 0,'" + rows.Cells["rate"].Value.ToString() + @"',0, 
                        '" + Classes.Helper.userId + @"', GETDATE(), 1, 1);";
                    }
                    else
                    {
                        classHelper.query += @"INSERT INTO MATERIAL_ITEM_LEDGER(DATE, MATERIAL_ID, REF_NO, ENTRY_FROM, STOCK_IN, STOCK_OUT, COST_AMT, SALE_AMT, CREATED_BY, CREATION_DATE, COMPANY_ID,L_ID)
                        VALUES('" + dtpFrom.Value.Date + "', '" + rows.Cells["materialId"].Value.ToString() + "'," + masterId + @",'RAW INVENTORY ADJUSTMENT',
                         0,'" + rows.Cells["qty"].Value.ToString() + @"',0,'" + rows.Cells["rate"].Value.ToString() + @"',
                        '" + Classes.Helper.userId + @"', GETDATE(), 1, 1);";
                    }
                }

                classHelper.query += @"COMMIT TRANSACTION 
                    END TRY 
                BEGIN CATCH 
                        IF @@TRANCOUNT > 0 
                        ROLLBACK TRANSACTION 
                END CATCH";

                if (classHelper.InsertUpdateDelete(classHelper.query) >= 1)
                {
                    classHelper.ShowMessageBox("Record Saved Sucessfully.", "Information");
                    Clear();
                }
            }
            else {
                classHelper.ShowMessageBox("Please Add Record to Save.", "Information");
            }
        }
        
        private void grdSEARCH_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            grdSearch.Columns["IA_ID"].Visible = false;
            grdSearch.Columns["MATERIAL_ID"].Visible = false;
        }

        private void btnCLEAR_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void grdSEARCH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           LoadGridData(e); 
        }

        private void cmbMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetRate();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbMaterial.SelectedIndex == 0)
            {
                classHelper.ShowMessageBox("Select Product.", "Warning");
                cmbMaterial.Focus();
                return;
            }
            else if (txtQty.Text.Trim().Equals("0") || txtQty.Text.Trim().Equals(""))
            {
                classHelper.ShowMessageBox("Enter Qty", "Warning");
                txtQty.Focus();
                return;
            }
            else
            {
                char type = 'A';
                if (rdbOut.Checked == true) {
                    type = 'D';
                }
                grdGrid.Rows.Add(editId,cmbMaterial.SelectedValue.ToString(),cmbMaterial.Text,txtQty.Text,txtRate.Text,
                        (Convert.ToDecimal(txtQty.Text) * Convert.ToDecimal(txtRate.Text)),type);

                cmbMaterial.SelectedIndex = 0;
                txtQty.Text = "0";
                txtRate.Text = "0";
                rdbIn.Checked = true;
                editId = 0;
            }
        }

        private void grdGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.grdGrid.Rows[e.RowIndex];
                editId = Convert.ToInt32(row.Cells["id"].Value.ToString());
                char type = Convert.ToChar(row.Cells["type"].Value.ToString());
                if (type == 'A')
                {
                    rdbIn.Checked = true;
                }
                else {
                    rdbOut.Checked = true;
                }
                cmbMaterial.SelectedValue = row.Cells["materialId"].Value.ToString();
                txtQty.Text = row.Cells["qty"].Value.ToString();
                txtRate.Text = row.Cells["rate"].Value.ToString();
                grdGrid.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void rdbIn_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbIn.Checked == true)
            {
                txtRate.Enabled = true;
                txtRate.Text = "0";
            }
            else if (rdbOut.Checked == true)
            {
                txtRate.Enabled = true;
                txtRate.Text = "0";

                //txtRate.Enabled = false;
                //if (cmbMaterial.SelectedIndex > 0)
                //{
                //    GetRate();
                //}
                //else {
                //    txtRate.Text = "0";
                //}
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (grdGrid.Rows.Count > 0)
            {
                classHelper.query = @"BEGIN TRY 
                BEGIN TRANSACTION ";

                foreach (DataGridViewRow rows in grdGrid.Rows)
                {
                    if (isEdit == true)
                    {
                        classHelper.query += @"DELETE FROM INVENTORY_ADJUSTMENTS_RAW WHERE ID = '" + rows.Cells["id"].Value.ToString() + @"';";
                    }

                    //Accounts Ledger
                    classHelper.query += "DELETE FROM LEDGERS WHERE REF_ID = '" + rows.Cells["id"].Value.ToString() + @"' AND ENTRY_OF = 'RAW INVENTORY ADJUSTMENT';";
                    
                    //Product Ledger
                    classHelper.query += "DELETE FROM MATERIAL_ITEM_LEDGER WHERE REF_NO = '" + rows.Cells["id"].Value.ToString() + @"' AND ENTRY_FROM = 'RAW INVENTORY ADJUSTMENT';";
                }

                classHelper.query += @"COMMIT TRANSACTION 
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
            else
            {
                classHelper.ShowMessageBox("Please Add Record to Save.", "Information");
            }
        }
    }
}

