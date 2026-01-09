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
    public partial class frmChartOfAccounts : Form
    {

        Classes.Helper cls_fhp = new Classes.Helper();

        string accountId = "";
        int isEdit = 0;
        int level;

        public frmChartOfAccounts()
        {
            InitializeComponent();
        }

        //clear fields in form
        private void clear()
        {
            try {
                cmbControlAccount.SelectedIndex = 0;
                cmbControlAccount.Focus();
                cmbGroupAccount.SelectedIndex = 0;
                cmbGroupAccount.Enabled = true;
                cmbDebitCredit.SelectedIndex = 0;
                txtSearch.Clear();
                txtAccountName.Clear();
                txtOpeningBalance.Text = "0.00";
                accountId = "";
                level = 0;
                isEdit = 0;
                chkDeActive.Checked = false;
                rdbNet.Checked = false;
                rdbRetail.Checked = false;
            }
            catch (Exception ex) { cls_fhp.ShowMessageBox(ex.ToString(),"Exception"); }
        }

        //generate account code
        private string GenerateLevelId(string parentCode)
        {
            string agCode = "";
            try { 
                int levelNo = 0;
                levelNo = cls_fhp.GetLevelFromDB(parentCode);
                
                if (levelNo == 1)
                {
                    agCode = parentCode + "00";
                }
                else if (levelNo == 2)
                {
                    agCode = parentCode + "000";
                }
                else if (levelNo == 3)
                {
                    agCode = parentCode + "0000";
                }
                else if (levelNo == 4)
                {
                    agCode = parentCode + "00000";
                }
                else if (levelNo == 5)
                {
                    agCode = parentCode + "000000";
                }
                else if (levelNo == 6)
                {
                    agCode = parentCode + "0000000";
                }
                else if (levelNo == 7)
                {
                    agCode = parentCode + "00000000";
                }
            }
            catch (Exception ex) { cls_fhp.ShowMessageBox(ex.ToString(),"Exception"); }
            return agCode;
        }       

        //get data from grid on click
        private void loadDataFromGrid(DataGridViewCellEventArgs e)
        {
            try {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.grdSEARCH.Rows[e.RowIndex];
                    accountId = row.Cells[5].Value.ToString();
                    isEdit = 1;
                    cmbControlAccount.SelectedValue = row.Cells[3].Value.ToString();
                    cmbGroupAccount.SelectedValue = row.Cells[1].Value.ToString();
                    if (cmbGroupAccount.Text.Equals("")) {
                        cmbGroupAccount.SelectedValue = 0;
                    }
                    cmbGroupAccount.Enabled = false;
                    if (row.Cells[9].Value.ToString().Equals("DEBIT")) {
                        cmbDebitCredit.SelectedIndex = 0;
                    }
                    else
                    {
                        cmbDebitCredit.SelectedIndex = 1;
                    }
                    txtOpeningBalance.Text = (row.Cells[8].Value??0).ToString();
                    level = int.Parse((row.Cells[11].Value??0).ToString());
                    if (row.Cells[10].Value.ToString().Equals("ACTIVE"))
                    {
                        chkDeActive.Checked = false;
                    }
                    else
                    {
                        chkDeActive.Checked = true;
                    }
                    txtAccountName.Text = row.Cells[7].Value.ToString();

                    string rateType = cls_fhp.GetAccountRateType(accountId);
                    if (rateType.Equals("R"))
                    {
                        rdbRetail.Checked = true;
                    }
                    else if (rateType.Equals("N"))
                    {
                        rdbNet.Checked = true;
                    }
                    else
                    {
                        rdbRetail.Checked = false;
                        rdbNet.Checked = false;
                    }

                    cmbControlAccount.Focus();

                }
            }
            catch (Exception ex) { cls_fhp.ShowMessageBox(ex.ToString(),"Exception"); }
        }

        private void frm_ChartOfAccounts_Load(object sender, EventArgs e)
        {
            try {
                cls_fhp.LoadTree(treeCOA);
                cls_fhp.LoadCoaGrid(grdSEARCH);
                cls_fhp.LoadControlAccount(cmbControlAccount);
                
                cmbDebitCredit.SelectedIndex = 0;
                //Classes.Helper.userId = 1;
            }
            catch (Exception ex) { cls_fhp.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void txtSEARCH_TextChanged(object sender, EventArgs e)
        {
            cls_fhp.CoaGridSearch(txtSearch, grdSEARCH);
            try {
                
            }
            catch (Exception ex) { cls_fhp.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void grdSEARCH_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            grdSEARCH.Columns[0].Visible = false;
            grdSEARCH.Columns[1].Visible = false;
            grdSEARCH.Columns[3].Visible = false;
            grdSEARCH.Columns[4].Visible = false;
            grdSEARCH.Columns[5].Visible = false;
            grdSEARCH.Columns[11].Visible = false;
            grdSEARCH.Columns["NATURE"].DisplayIndex = 8;
            grdSEARCH.Columns["LEVL"].DisplayIndex = 11;
            //grdSEARCH.Columns["rateType"].Visible = false;
        }

        private void btnCLEAR_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {
            try {
                if (isEdit == 0)
                {
                    if (cls_fhp.CheckNameExists(grdSEARCH, txtAccountName.Text, 7) == 1)
                    {
                        cls_fhp.ShowMessageBox("Account name already exists in your record.", "Warning");
                        return;
                    }
                }
                if (cmbControlAccount.SelectedIndex == 0)
                {
                    cls_fhp.ShowMessageBox("Control account is not selected, please select control account.", "Warning");
                    cmbControlAccount.Focus();
                }
                else if (cmbGroupAccount.SelectedIndex == 0 || cmbGroupAccount.Items.Count == 0)
                {
                    cls_fhp.ShowMessageBox("Group account is not selected, please select group account.", "Warning");
                    cmbGroupAccount.Focus();
                }
                else if (txtAccountName.Text.Trim().Equals(""))
                {
                    cls_fhp.ShowMessageBox("Account name field is blank.", "Warning");
                    txtAccountName.Focus();
                }
                else
                {
                    char rateType = '0';
                    if (rdbRetail.Checked == true) {
                        rateType = 'R';
                    }
                    else if (rdbNet.Checked == true)
                    {
                        rateType = 'N';
                    }

                    int status = 0;
                    if (chkDeActive.Checked == true)
                    {
                        status = 1;
                    }
                    string drCr = "D";
                    if (cmbDebitCredit.Text.Equals("CREDIT"))
                    {
                        drCr = "C";
                    }
                    cls_fhp.query = @"IF EXISTS (select COA_ID from COA WHERE COA_ID = '" + accountId + "') UPDATE COA SET COA_NAME = '" + cls_fhp.AvoidInjection(txtAccountName.Text) + 
                        "',CA_ID = '" + cmbControlAccount.SelectedValue.ToString() + "',rateType = '"+rateType+"',OPEN_BAL = '" + 
                        cls_fhp.AvoidInjection(txtOpeningBalance.Text) + "',STAT = '" + 
                        status + "',DR_CR = '" + drCr + "',MODIFICATION_DATE = GETDATE(), MODIFIED_BY = '" +
                        Classes.Helper.userId + "',AG_ID = (SELECT AG_ID FROM ACCOUNT_GROUP WHERE AG_CODE = '" +
                        cmbGroupAccount.SelectedValue.ToString() + "') WHERE COA_ID = '" + accountId + "' " +
                        "ELSE INSERT INTO COA VALUES((SELECT AG_ID FROM ACCOUNT_GROUP WHERE AG_CODE = '" + 
                        cmbGroupAccount.SelectedValue.ToString() + "'),'" + cmbControlAccount.SelectedValue.ToString() + 
                        "',CAST('" + GenerateLevelId(cmbGroupAccount.SelectedValue.ToString()) + 
                        "' AS VARCHAR) + CAST((CASE WHEN (select count(AG_ID) from COA where AG_ID = (SELECT AG_ID FROM ACCOUNT_GROUP WHERE AG_CODE = '" + 
                        cmbGroupAccount.SelectedValue.ToString() + @"')) = 0 THEN 1 ELSE (select count(AG_ID)+1 from COA where AG_ID = (SELECT AG_ID FROM ACCOUNT_GROUP WHERE AG_CODE = '" + cmbGroupAccount.SelectedValue.ToString() + @"')) END) AS VARCHAR),
                        '" + cls_fhp.AvoidInjection(txtAccountName.Text) + "','" + cls_fhp.AvoidInjection(txtOpeningBalance.Text) + "','" + drCr + "','" + status + @"',GETDATE(),
                        '" + Classes.Helper.userId + "',NULL,NULL,1,'" + rateType + "')";

                    if (cls_fhp.SaveCoa(cls_fhp.query) >= 1) {
                        cls_fhp.ShowMessageBox("Record Saved Sucessfully.", "Information");
                        clear();
                        cls_fhp.LoadCoaGrid(grdSEARCH);
                        cls_fhp.LoadTree(treeCOA);
                    }
                }
            }
            catch (Exception ex) { cls_fhp.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void txtOPEN_BAL_KeyPress(object sender, KeyPressEventArgs e)
        {
            try {
                cls_fhp.AllowNumbers(e);
            }
            catch (Exception ex) { cls_fhp.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void txtOPEN_BAL_Leave(object sender, EventArgs e)
        {
            try {
                if (txtOpeningBalance.Text.Trim().Equals("")) {
                    txtOpeningBalance.Text = "0";
                }
            }
            catch (Exception ex) { cls_fhp.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void btnADDGROUP_AC_Click(object sender, EventArgs e)
        {
            cls_fhp.query = @"SELECT '0' AS [id],'--SELECT ACCOUNT GROUP--' AS [name]
            UNION
            SELECT AG_CODE AS [id],AG_NAME AS [name] FROM ACCOUNT_GROUP 
            WHERE AN_ID = (SELECT AN_ID FROM CONTROL_ACCOUNT WHERE CA_ID = '" + cmbControlAccount.SelectedValue.ToString() + @"')
            ORDER BY [name]";
            //cls_fhp.query = "SELECT AG_CODE AS [id],AG_NAME AS [name] FROM ACCOUNT_GROUP";
            cls_fhp.OpenGroupForm(cls_fhp.query,cmbGroupAccount);
        }

        private void grdSEARCH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try {
                loadDataFromGrid(e);
            }
            catch (Exception ex) { cls_fhp.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void txtACCOUNT_NAME_MouseClick(object sender, MouseEventArgs e)
        {
            cls_fhp.select_all_text(sender as TextBox);
        }

        private void txtACCOUNT_NAME_Enter(object sender, EventArgs e)
        {
            cls_fhp.select_all_text(sender as TextBox);
        }

        private void cmbCONTROL_AC_TextUpdate(object sender, EventArgs e)
        {
            try
            {
                cls_fhp.CmbTextUpdate(sender as ComboBox);
            }
            catch (Exception ex) { cls_fhp.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void cmbCONTROL_AC_DropDown(object sender, EventArgs e)
        {
            try {
                ComboBox cbo = (ComboBox)sender;
                cbo.PreviewKeyDown += new PreviewKeyDownEventHandler(cmbCONTROL_AC_PreviewKeyDown);
            }
            catch (Exception ex) { cls_fhp.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void cmbCONTROL_AC_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try {
                ComboBox cbo = (ComboBox)sender;
                cbo.PreviewKeyDown -= cmbCONTROL_AC_PreviewKeyDown;
                if (cbo.DroppedDown) cbo.Focus();
            }
            catch (Exception ex) { cls_fhp.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void cmbGROUP_AC_DropDown(object sender, EventArgs e)
        {
            try {
                ComboBox cbo = (ComboBox)sender;
                cbo.PreviewKeyDown += new PreviewKeyDownEventHandler(cmbGROUP_AC_PreviewKeyDown);
            }
            catch (Exception ex) { cls_fhp.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void cmbGROUP_AC_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try {
                ComboBox cbo = (ComboBox)sender;
                cbo.PreviewKeyDown -= cmbGROUP_AC_PreviewKeyDown;
                if (cbo.DroppedDown) cbo.Focus();
            }
            catch (Exception ex) { cls_fhp.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cls_fhp.CoaGridSearch(txtSearching, grdSEARCH);
            }
            catch (Exception ex) { cls_fhp.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void cmbControlAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbControlAccount.SelectedIndex > 0)
            {
                cls_fhp.LoadGroupAccount(cmbGroupAccount,Convert.ToInt16(cmbControlAccount.SelectedValue.ToString()));
                cmbGroupAccount.Enabled = true;
            }
            else {
                if (cmbGroupAccount.Items.Count > 0) {
                    cmbGroupAccount.SelectedIndex = 0;
                }
                cmbGroupAccount.Enabled = false;
            }
        }

        private void txtAccountName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cls_fhp.CoaGridSearch(txtAccountName, grdSEARCH);
            }
            catch (Exception ex) { cls_fhp.ShowMessageBox(ex.ToString(), "Exception"); }
        }
    }
}
