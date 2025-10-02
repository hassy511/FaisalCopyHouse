using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace ERP_Maaz_Oil.Vouchers
{
    public partial class frm_GeneralVoucher : Form
    {
        Forms.Vouchers.Voucher voucher = new Forms.Vouchers.Voucher();
        Classes.Helper db = new Classes.Helper();
        List<string> addedChqs = new List<string>();
        cls_GeneralVoucher dayBook = new cls_GeneralVoucher();

        string chqId = "";
        int rowEdit = -1;
        string refNum = "";
        string refID = "";
        string daybookID = "";
        string paybookID = "";
        string gv_id = "";
        int is_edit = 0;
        int isEdit = -1;
        string ID;
        int userId = Classes.Helper.userId;

        public frm_GeneralVoucher()
        {
            InitializeComponent();

        }

        private void dayControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (dayControl.SelectedTab.Text.Equals("General Entry"))
                {
                    loadGE();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void DayBookForm_Load(object sender, EventArgs e)
        {
            loadGE();
        }

        //Genral
        private void loadGE()
        {
            try
            {
                userId = Classes.Helper.userId;
                refNum = dayBook.getNum().ToString();
                dayBook.loadEntryGrid(EntryGrid);
                dayBook.loadDebit(cmbDebitAccount);
                dayBook.loadCredit(cmbCreditAccount);
                generate_voucher_no(lblGV);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }
        private void Generalclear()
        {
            try {
                userId = Classes.Helper.userId;
                dtpDate.ResetText();
                cmbDebitAccount.SelectedValue = 0;
                cmbCreditAccount.SelectedValue = 0;
                txtGVAmount.Text = "0";
                txtNarration.Clear();
                refNum = dayBook.getNum().ToString();
                refID = "";
                txtDebitTotalGV.Text = "0";
                txtCreditTotalGV.Text = "0";
                isEdit = -1;
                grdENTRY.Rows.Clear();
                generate_voucher_no(lblGV);
                gv_id = "";
                dayBook.loadEntryGrid(EntryGrid);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }
        private void btnClr_Click(object sender, EventArgs e)
        {
            Generalclear();
        }

        private void txtPrice_Enter(object sender, EventArgs e)
        {
            txtGVAmount.SelectAll();
        }

        private void txtPrice_Click(object sender, EventArgs e)
        {
            txtGVAmount.SelectAll();
        }

        public void generate_voucher_no(Label lbl)
        {
            string query = "SELECT ISNULL(COUNT(GV_ID)+1,1) FROM GENERAL_VOUCHER_M";
            lbl.Text = "JV-" + db.GenerateVoucherCode(query) + "-" + DateTime.Now.Year;
            lbl.Refresh();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try {
                if(!txtDebitTotalGV.Text.Equals(txtCreditTotalGV.Text))
                {
                    MessageBox.Show("Debit and Credit not equal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if(grdENTRY.RowCount==0)
                {
                    MessageBox.Show("No entries to save", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string query = @"BEGIN TRY 
                            declare @mid int = '" + gv_id + @"';
                             BEGIN TRANSACTION ";

                    query += @"IF EXISTS (select GV_ID from GENERAL_VOUCHER_M WHERE GV_ID = '" + gv_id + @"') 
                    BEGIN
                    UPDATE GENERAL_VOUCHER_M SET DAATE = '" + Classes.Helper.ConvertDatetime(dtpDate.Value) + "',NARRATION = '" + db.AvoidInjection(txtNarration.Text) + "',  MODIFICATION_DATE = getdate(), MODIFIED_BY = '" + Classes.Helper.userId + @"' 
                    WHERE GV_ID = '" + gv_id + @"';
                    END
                    ELSE
                    BEGIN
                    INSERT INTO GENERAL_VOUCHER_M (GV_CODE,DAATE,NARRATION,CREATED_BY,CREATION_DATE)
                    VALUES('" + lblGV.Text + "','" + Classes.Helper.ConvertDatetime(dtpDate.Value) + "', '" + db.AvoidInjection(txtNarration.Text) + "', '" + Classes.Helper.userId + @"', getdate());
                    set @mid =(SELECT SCOPE_IDENTITY());
                    END; ";

                    query += @"DELETE FROM GENERAL_VOUCHER_D WHERE GV_ID = @mid;";
                    query += @"DELETE FROM LEDGERS WHERE REF_ID = @mid AND ENTRY_OF = 'GENERAL VOUCHER';";

                    foreach (DataGridViewRow rows in grdENTRY.Rows)
                    {

                        query += "INSERT INTO GENERAL_VOUCHER_D VALUES(@mid,'" + rows.Cells["debitId"].Value.ToString() + @"',
                        '" + rows.Cells["gvAmount"].Value.ToString() + "','" + rows.Cells["gvAmount"].Value.ToString() + @"',
                        '"+ rows.Cells["DESCRIPTION"].Value.ToString() + "','" + rows.Cells["creditId"].Value.ToString() + "')";

                        query += @"INSERT INTO LEDGERS (DATE,COA_ID,REF_ID,ENTRY_OF,FOLIO,DEBIT,CREDIT,DESCRIPTIONS,CREATED_BY,CREATION_DATE)
                                VALUES('" + Classes.Helper.ConvertDatetime(dtpDate.Value) + "', '" + rows.Cells["debitId"].Value.ToString() + @"',
                                @mid, 'GENERAL VOUCHER','" + lblGV.Text + "','" + (rows.Cells["gvAmount"].Value.ToString()) + @"','0',
                                '" + rows.Cells["DESCRIPTION"].Value.ToString() + "','" + Classes.Helper.userId + @"',
                                GETDATE());";

                        query += @"INSERT INTO LEDGERS (DATE,COA_ID,REF_ID,ENTRY_OF,FOLIO,DEBIT,CREDIT,DESCRIPTIONS,CREATED_BY,CREATION_DATE)
                                VALUES('" + Classes.Helper.ConvertDatetime(dtpDate.Value) + "', '" + rows.Cells["creditId"].Value.ToString() + @"',
                                @mid, 'GENERAL VOUCHER','" + lblGV.Text + "','0','" + (rows.Cells["gvAmount"].Value.ToString()) + @"',
                                '" + rows.Cells["DESCRIPTION"].Value.ToString() + "','" + Classes.Helper.userId + @"',
                                GETDATE());";
                    }

                    query += @" COMMIT TRANSACTION 
                        END TRY 
                    BEGIN CATCH 
                            IF @@TRANCOUNT > 0 
                            ROLLBACK 
                        TRANSACTION 
                    END CATCH";
                        
                    if (db.InsertUpdateDelete(query) > 0)
                    {
                        MessageBox.Show("Record Save Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        show_report();
                        Generalclear();
                        loadGE();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void txtAmnt_KeyPress(object sender, KeyPressEventArgs e)
        {
            db.CheckNumber(e);
        }

        public void get_voucher_details(string gv_id, DataGridView dg)
        {
            dg.Rows.Clear();
            string query = @"SELECT C.DAATE AS [DATE],B.COA_NAME AS [DEBIT ACCOUNT],D.COA_NAME AS [CREDIT ACCOUNT],
            A.DEBIT AS [AMOUNT],A.NARRATION,A.COA_ID AS [DEBIT ID],A.CREDIT_ID AS [CREDIT ID]
            FROM GENERAL_VOUCHER_D A
            INNER JOIN COA B ON A.COA_ID = B.COA_ID
            INNER JOIN GENERAL_VOUCHER_M C ON A.GV_ID = C.GV_ID
            INNER JOIN COA D ON A.CREDIT_ID = D.COA_ID
            WHERE A.GV_ID = '" + gv_id + "'";

            if (Classes.Helper.conn.State == System.Data.ConnectionState.Closed) { Classes.Helper.conn.Open(); }
            try
            {
                db.cmd = new SqlCommand(query, Classes.Helper.conn);
                db.cmd.CommandTimeout = 0;
                db.dr = db.cmd.ExecuteReader();
                if (db.dr.HasRows)
                {
                    int i = 0;
                    while (db.dr.Read())
                    {
                        dg.Rows.Add(db.dr["DATE"].ToString(), db.dr["DEBIT ACCOUNT"].ToString(), db.dr["CREDIT ACCOUNT"].ToString(), 
                            db.dr["NARRATION"].ToString(), db.dr["AMOUNT"].ToString(),db.dr["DEBIT ID"].ToString(), db.dr["CREDIT ID"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Classes.Helper.conn.Close();
            }
        }

        private void EntryGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.EntryGrid.Rows[e.RowIndex];
                    gv_id = row.Cells["GV_ID"].Value.ToString();
                    is_edit = e.RowIndex;
                    dtpDate.Value = DateTime.Parse(row.Cells["DATE"].Value.ToString());
                    lblGV.Text = row.Cells["VOUCHER #"].Value.ToString();
                    get_voucher_details(gv_id, grdENTRY);
                    userId = Convert.ToInt32(row.Cells["created_by"].Value.ToString());
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void EntryGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            EntryGrid.Columns["CREATED_BY"].Visible = false;
            EntryGrid.Columns["GV_ID"].Visible = false;
        }
        
        //gv grid search 
        public void gv_grid_search()
        {
            try
            {
                (EntryGrid.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
                [" + EntryGrid.Columns["NARRATION"].Name.ToString() + "] LIKE '%" + db.AvoidInjection(txtSEARCH.Text) + "%' OR ["
                + EntryGrid.Columns["VOUCHER #"].Name.ToString() + "] LIKE '%" + db.AvoidInjection(txtSEARCH.Text) + "%' OR CONVERT(["
                + EntryGrid.Columns["CREDIT"].Name.ToString() + "], System.String) LIKE '%" + db.AvoidInjection(txtSEARCH.Text) + "%' OR ["
                + EntryGrid.Columns["NARRATION"].Name.ToString() + "] LIKE '%" + db.AvoidInjection(txtSEARCH.Text) + @"%'");
                EntryGrid.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            EntryGrid.ClearSelection();
        }

        private void txtSEARCH_TextChanged(object sender, EventArgs e)
        {
            gv_grid_search();
        }

        private void cmbDebit_TextUpdate(object sender, EventArgs e)
        {
            db.CmbTextUpdate(sender as ComboBox);
        }

        private void cmbDebit_DropDown(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown += new PreviewKeyDownEventHandler(cmbDebit_PreviewKeyDown);
        }

        private void cmbCredit_DropDown(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown += new PreviewKeyDownEventHandler(cmbDebit_PreviewKeyDown);
        }

        private void cmbDebit_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown -= cmbDebit_PreviewKeyDown;
            if (cbo.DroppedDown) cbo.Focus();
        }

        private void cmbCredit_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown -= cmbDebit_PreviewKeyDown;
            if (cbo.DroppedDown) cbo.Focus();
        }
        
        private void btnADD_Click(object sender, EventArgs e)
        {
            Classes.Helper cls_fhp = new Classes.Helper();
            try
            {
                if (cmbDebitAccount.SelectedIndex == 0)
                {
                    cls_fhp.ShowMessageBox("Debit Account is not selected", "error");
                    cmbDebitAccount.Focus();
                }
                else if (cmbCreditAccount.SelectedIndex == 0)
                {
                    cls_fhp.ShowMessageBox("Credit Account is not selected", "error");
                    cmbCreditAccount.Focus();
                }
                else if(txtGVAmount.Text.Equals(""))
                {
                    cls_fhp.ShowMessageBox("Amount is not entered", "error");
                    txtGVAmount.Focus();
                }
                else
                {
                    grdENTRY.Rows.Add(dtpDate.Value.Date.ToString("dd-MM-yyyy"), cmbDebitAccount.Text, cmbCreditAccount.Text, txtNarration.Text, 
                                txtGVAmount.Text,cmbDebitAccount.SelectedValue.ToString(), cmbCreditAccount.SelectedValue.ToString());
                    cmbDebitAccount.SelectedIndex = 0;
                    cmbCreditAccount.SelectedIndex = 0;
                    txtGVAmount.Text = "0";
                    txtAmountWordsGen.Text = "-";
                    txtNarration.Clear();

                }
                isEdit = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void grdENTRY_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grdENTRY.Rows.Count > 0)
                {
                    if (e.RowIndex >= 0)
                    {
                        DialogResult diag = new DialogResult();
                        diag = MessageBox.Show("Do you want to delete this entry?", "Delete Entry", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (diag == DialogResult.Yes)
                        {
                            isEdit = e.RowIndex;
                            cmbDebitAccount.SelectedValue = grdENTRY.Rows[e.RowIndex].Cells["debitId"].Value.ToString();
                            cmbCreditAccount.SelectedValue = grdENTRY.Rows[e.RowIndex].Cells["creditId"].Value.ToString();
                            txtNarration.Text = grdENTRY.Rows[e.RowIndex].Cells["DESCRIPTION"].Value.ToString();
                            txtGVAmount.Text = grdENTRY.Rows[e.RowIndex].Cells["gvAmount"].Value.ToString();
                            grdENTRY.Rows.RemoveAt(e.RowIndex);
                        }
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDeleteGeneral_Click(object sender, EventArgs e)
        {
            if (gv_id.Equals(""))
            {
                MessageBox.Show("Please select an entry from the upper grid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (MessageBox.Show("Do you really want to delete this entry?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    db.query = @"DELETE FROM GENERAL_VOUCHER_M WHERE GV_ID = '" + gv_id + @"';
                                 DELETE FROM GENERAL_VOUCHER_D WHERE GV_ID = '"+gv_id+"'; " +
                                 "DELETE FROM LEDGERS WHERE REF_ID = '"+gv_id+"' AND ENTRY_OF = 'GENERAL VOUCHER'";
                    if (db.InsertUpdateDelete(db.query) > 0)
                    {
                        MessageBox.Show("Entry deleted successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Generalclear();
                        loadGE();

                    }
                }
            }
        }

        private void rowAddedOrRemoved()
        {
            if (grdENTRY.Rows.Count > 0)
            {
                txtDebitTotalGV.Text = grdENTRY.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToDecimal(t.Cells["gvAmount"].Value)).ToString();

                txtCreditTotalGV.Text = grdENTRY.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToDecimal(t.Cells["gvAmount"].Value)).ToString();
            }
        }

        private void grdENTRY_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            rowAddedOrRemoved();
        }

        private void grdENTRY_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            rowAddedOrRemoved();
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int.Parse(txtGVAmount.Text);
                txtAmountWordsGen.Text = DayBook.ConvertWholeNumber(txtGVAmount.Text);
                
            }
            catch
            {

            }
        }

        private void txtCreditGV_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //int.Parse(txtCreditGV.Text);
                //txtAmountWordsGen.Text = DayBook.ConvertWholeNumber(txtCreditGV.Text);
                
            }
            catch 
            {

            }
        }

        private void txtCreditGV_KeyPress(object sender, KeyPressEventArgs e)
        {
            db.CheckNumber(e);
            txtGVAmount.Text = "0";      
        }
        
        private void show_report()
        {
            db.nds.Tables["JV"].Clear();
            foreach (DataGridViewRow rows in grdENTRY.Rows)
            {
                db.dataR = db.nds.Tables["JV"].NewRow();
                db.dataR["date"] = Convert.ToDateTime(dtpDate.Value.Date);
                db.dataR["voucherNo"] = lblGV.Text;
                db.dataR["accountName"] = rows.Cells["debitAccount"].Value.ToString();
                db.dataR["description"] = rows.Cells["description"].Value.ToString();
                db.dataR["preparedBy"] = Classes.Helper.GetUserName(userId);
                db.dataR["debit"] = Convert.ToDouble(rows.Cells["gvAmount"].Value.ToString());
                db.dataR["credit"] = 0;
                db.nds.Tables["JV"].Rows.Add(db.dataR);

                db.dataR = db.nds.Tables["JV"].NewRow();
                db.dataR["date"] = Convert.ToDateTime(dtpDate.Value.Date);
                db.dataR["voucherNo"] = lblGV.Text;
                db.dataR["accountName"] = rows.Cells["creditAccount"].Value.ToString();
                db.dataR["description"] = rows.Cells["description"].Value.ToString();
                db.dataR["preparedBy"] = Classes.Helper.GetUserName(userId);
                db.dataR["debit"] = 0;
                db.dataR["credit"] = Convert.ToDouble(rows.Cells["gvAmount"].Value.ToString());
                db.nds.Tables["JV"].Rows.Add(db.dataR);
            }
            db.rpt = new Forms.Reporting.frmReports();
            db.rpt.GenerateReport("JV", db.nds);
            db.rpt.ShowDialog();
        }

        private void btn_VIEW_VOUCHER_Click(object sender, EventArgs e)
        {
            try
            {
                if(grdENTRY.Rows.Count>0)
                { show_report(); }
                else
                {
                    db.ShowMessageBox("Record Not Found To Print", "error");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void rdbPaid_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cmbDebitAccount_Leave(object sender, EventArgs e)
        {
            if (!db.CheckAccountExists(cmbDebitAccount.Text))
            {
                string accountName = cmbDebitAccount.Text;
                DialogResult dialogResult = MessageBox.Show("Do you want to add " + cmbDebitAccount.Text + " Account?", "Add New Account", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    using (Forms.frmChartOfAccounts frm = new Forms.frmChartOfAccounts(10, 5, db.AvoidInjection(cmbDebitAccount.Text), 0))
                    {
                        if (frm.ShowDialog() == System.Windows.Forms.DialogResult.Cancel || frm.ShowDialog() == System.Windows.Forms.DialogResult.Abort)
                        {
                            dayBook.loadDebit(cmbDebitAccount);
                            cmbDebitAccount.Text = accountName;
                        }
                    }
                }
                else
                {
                    cmbDebitAccount.SelectedIndex = 0;
                    cmbDebitAccount.Focus();
                }
            }
        }

        private void cmbCreditAccount_Leave(object sender, EventArgs e)
        {
            if (!db.CheckAccountExists(cmbCreditAccount.Text))
            {
                string accountName = cmbCreditAccount.Text;
                DialogResult dialogResult = MessageBox.Show("Do you want to add " + cmbCreditAccount.Text + " Account?", "Add New Account", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    using (Forms.frmChartOfAccounts frm = new Forms.frmChartOfAccounts(10, 5, db.AvoidInjection(cmbCreditAccount.Text), 0))
                    {
                        if (frm.ShowDialog() == System.Windows.Forms.DialogResult.Cancel || frm.ShowDialog() == System.Windows.Forms.DialogResult.Abort)
                        {
                            dayBook.loadCredit(cmbCreditAccount);
                            cmbCreditAccount.Text = accountName;
                        }
                    }
                }
                else
                {
                    cmbCreditAccount.SelectedIndex = 0;
                    cmbCreditAccount.Focus();
                }
            }
        }
    }
}
