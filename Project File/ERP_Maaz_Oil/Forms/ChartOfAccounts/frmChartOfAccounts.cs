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

        Classes.Helper classHelper = new Classes.Helper();

        int accountId = 0;

        bool isParameter = false;
        int controlId = 0;
        int branchId = 0;
        string accountName = "";
        int drCr = 0;

        private void LoadParameterForm() {
            
            cmbControlAccount.SelectedValue = this.controlId;
            cmbGroupAccount.SelectedValue = this.branchId;
            txtAccountName.Text = this.accountName;
            cmbDebitCredit.SelectedIndex = this.drCr;
            cmbCITY.Text = "N/A";
            cmbArea.Text = "N/A";
            txtMOBILE.Text = "-";
            txtEMAIL.Text = "-";
            txtADDRESS.Text = "-";
        }

        public frmChartOfAccounts()
        {
            InitializeComponent();
        }

        public frmChartOfAccounts(int controlId, int branchId, string accountName, int drCr)
        {
            InitializeComponent();
            isParameter = true;
            this.controlId = controlId;
            this.branchId = branchId;
            this.accountName = accountName;
            this.drCr = drCr;
        }

        //Clear fields in form
        private void Clear()
        {
            try
            {
                isParameter = false;
                cmbControlAccount.SelectedIndex = 0;
                cmbControlAccount.Focus();
                cmbGroupAccount.SelectedIndex = 0;
                cmbGroupAccount.Enabled = true;
                cmbDebitCredit.SelectedIndex = 0;
                txtSearch.Clear();
                txtAccountName.Clear();
                txtOpeningBalance.Text = "0";
                accountId = 0;
                chkDeActive.Checked = false;
                txtADDRESS.Clear();
                txtCreditDays.Text = "0";
                txtEMAIL.Clear();
                txtMOBILE.Clear();
                cmbCITY.SelectedIndex = 0;
                cmbArea.SelectedIndex = 0;
                LoadGrid();
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void LoadArea()
        {
            try
            {
                classHelper.query = @"SELECT 0 AS [ID],'--SELECT AREA--' AS [NAME] 
                                    UNION ALL 
                                    SELECT AREA_ID AS [ID],AREA_NAME AS [NAME] FROM AREA 
                                    WHERE CITY_ID = '"+cmbCITY.SelectedValue.ToString()+@"'    
                                    ORDER BY NAME";
                classHelper.LoadComboData(cmbArea, classHelper.query);
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void LoadCity()
        {
            try
            {
                classHelper.query = "SELECT 0 AS [ID],'--SELECT CITY--' AS [NAME] UNION SELECT CITY_ID AS [ID],CITY_NAME AS [NAME] FROM CITY ORDER BY NAME";
                classHelper.LoadComboData(cmbCITY, classHelper.query);
            }

            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void loadDataFromGrid(DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.grdSEARCH.Rows[e.RowIndex];
                    accountId = Convert.ToInt32(row.Cells["id"].Value.ToString());
                    cmbControlAccount.SelectedValue = row.Cells["ca_id"].Value.ToString();
                    cmbGroupAccount.SelectedValue = row.Cells["gp_id"].Value.ToString();
                    if (cmbGroupAccount.Text.Equals(""))
                    {
                        cmbGroupAccount.SelectedValue = 0;
                    }
                    cmbGroupAccount.Enabled = false;
                    if (row.Cells["DEBIT CREDIT"].Value.ToString().Equals("DEBIT"))
                    {
                        cmbDebitCredit.SelectedIndex = 0;
                    }
                    else
                    {
                        cmbDebitCredit.SelectedIndex = 1;
                    }
                    txtOpeningBalance.Text = row.Cells["OPENING BALANCE"].Value.ToString();
                    if (row.Cells["STATUS"].Value.ToString().Equals("ACTIVE"))
                    {
                        chkDeActive.Checked = false;
                    }
                    else
                    {
                        chkDeActive.Checked = true;
                    }
                    txtMOBILE.Text = row.Cells["MOBILE"].Value.ToString();
                    txtEMAIL.Text = row.Cells["EMAIL"].Value.ToString();
                    txtADDRESS.Text = row.Cells["ADDRESS"].Value.ToString();
                    cmbCITY.SelectedValue = row.Cells["CITY_ID"].Value.ToString();
                    cmbArea.SelectedValue = row.Cells["AREA_ID"].Value.ToString();
                    txtCreditDays.Text = row.Cells["CREDIT_DAYS"].Value.ToString();
                    txtAccountName.Text = row.Cells["ACCOUNT NAME"].Value.ToString();
                }

                cmbControlAccount.Focus();
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void LoadGrid()
        {
            classHelper.query = @"SELECT A.COA_ID AS [ID],C.CA_ID,C.CA_NAME AS [CONTROL ACCOUNT],
                A.AG_ID AS [GP_ID],B.AG_NAME AS [GROUP NAME],
                A.COA_NAME AS [ACCOUNT NAME],
                A.OPEN_BAL AS [OPENING BALANCE],
                CASE WHEN A.DR_CR = 'D' THEN 'DEBIT' ELSE 'CREDIT' END AS [DEBIT CREDIT],
                CASE WHEN A.STAT = 0 THEN 'ACTIVE' ELSE 'DE-ACTIVE' END AS [STATUS],
                A.MOBILE,A.EMAIL, A.[ADDRESS],A.CREDIT_DAYS,
                D.CITY_NAME,E.AREA_NAME,A.CITY_ID,A.AREA_ID
                FROM COA A
                INNER JOIN ACCOUNT_GROUP B ON A.AG_ID = B.AG_ID
                INNER JOIN CONTROL_ACCOUNT C ON A.CA_ID = C.CA_ID
                INNER JOIN CITY D ON A.CITY_ID = D.CITY_ID
                INNER JOIN AREA E ON A.AREA_ID = E.AREA_ID
                ORDER BY [ACCOUNT NAME]";
            classHelper.LoadGrid(grdSEARCH, classHelper.query);
        }

        private void frm_ChartOfAccounts_Load(object sender, EventArgs e)
        {
            try {
                //classHelper.LoadCoaGrid(grdSEARCH);
                LoadGrid();
                classHelper.LoadControlAccount(cmbControlAccount);
                LoadCity();
                LoadArea();
                cmbDebitCredit.SelectedIndex = 0;
                if (isParameter) {
                    LoadParameterForm();
                }
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void txtSEARCH_TextChanged(object sender, EventArgs e)
        {
            try {
                (grdSEARCH.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
                [" + grdSEARCH.Columns["ACCOUNT NAME"].Name.ToString() + "] LIKE '%" + classHelper.AvoidInjection(txtSearch.Text) + "%' OR ["
                + grdSEARCH.Columns["CITY_NAME"].Name.ToString() + "] LIKE '%" + classHelper.AvoidInjection(txtSearch.Text) + "%' OR["
                + grdSEARCH.Columns["AREA_NAME"].Name.ToString() + "] LIKE '%" + classHelper.AvoidInjection(txtSearch.Text) + "%' OR["
                + grdSEARCH.Columns["MOBILE"].Name.ToString() + "] LIKE '%" + classHelper.AvoidInjection(txtSearch.Text) + "%' OR["
                + grdSEARCH.Columns["EMAIL"].Name.ToString() + "] LIKE '%" + classHelper.AvoidInjection(txtSearch.Text) + "%' OR["
                + grdSEARCH.Columns["CONTROL ACCOUNT"].Name.ToString() + "] LIKE '%" + classHelper.AvoidInjection(txtSearch.Text) + "%'");
                grdSEARCH.ClearSelection();
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void grdSEARCH_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            grdSEARCH.Columns["ID"].Visible = false;
            grdSEARCH.Columns["CA_ID"].Visible = false;
            grdSEARCH.Columns["GP_ID"].Visible = false;
            grdSEARCH.Columns["CITY_ID"].Visible = false;
            grdSEARCH.Columns["AREA_ID"].Visible = false;

            //foreach (DataGridViewColumn col in grdSEARCH.Columns)
            //{
            //    MessageBox.Show(col.Name);
            //}
        }

        private void btnCLEAR_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {
            try {
                if (accountId == 0)
                {
                    if (classHelper.CheckNameExists(grdSEARCH, txtAccountName.Text, 5) == 1)
                    {
                        classHelper.ShowMessageBox("Account name already exists in your record.", "Warning");
                        return;
                    }
                }
                if (cmbControlAccount.SelectedIndex == 0)
                {
                    classHelper.ShowMessageBox("Control account is not selected, please select control account.", "Warning");
                    cmbControlAccount.Focus();
                }
                else if (cmbGroupAccount.SelectedIndex == 0 || cmbGroupAccount.Items.Count == 0)
                {
                    classHelper.ShowMessageBox("Group account is not selected, please select group account.", "Warning");
                    cmbGroupAccount.Focus();
                }
                else if (txtAccountName.Text.Trim().Equals(""))
                {
                    classHelper.ShowMessageBox("Account name field is blank.", "Warning");
                    txtAccountName.Focus();
                }
                else if (cmbCITY.SelectedIndex == 0)
                {
                    classHelper.ShowMessageBox("City is not selected, please select city.", "Warning");
                    cmbCITY.Focus();
                }
                else if (cmbArea.SelectedIndex == 0)
                {
                    classHelper.ShowMessageBox("Area is not selected, please select Area.", "Warning");
                    cmbArea.Focus();
                }
                else
                {
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

                    classHelper.query = @"IF EXISTS (select COA_ID from COA WHERE COA_ID = '" + accountId + @"') 
                UPDATE COA SET 
                     COA_NAME = '" + classHelper.AvoidInjection(txtAccountName.Text) + @"',
                     CA_ID = '" + cmbControlAccount.SelectedValue.ToString() + @"',
                     OPEN_BAL = '" + classHelper.AvoidInjection(txtOpeningBalance.Text) + @"',
                     STAT = '" + status + @"',
                     DR_CR = '" + drCr + @"',
                     MODIFICATION_DATE = GETDATE(),
                     MODIFIED_BY = '" + Classes.Helper.userId + @"',
                     AG_ID = '" + cmbGroupAccount.SelectedValue.ToString() + @"',
                     MOBILE = '" + classHelper.AvoidInjection(txtMOBILE.Text) + @"',
                     EMAIL = '" + classHelper.AvoidInjection(txtEMAIL.Text) + @"',
                     CITY_ID = '" + cmbCITY.SelectedValue.ToString() + @"',
                     AREA_ID = '" + cmbArea.SelectedValue.ToString() + @"',
                     CREDIT_DAYS = '" + classHelper.AvoidInjection(txtCreditDays.Text) + @"',
                     ADDRESS = '" + classHelper.AvoidInjection(txtADDRESS.Text) + @"'
                 WHERE COA_ID = '" + accountId + @"' 
                 ELSE 
                 INSERT INTO COA 
                 (AG_ID, CA_ID, COA_NAME, OPEN_BAL, DR_CR, STAT, CREATION_DATE, CREATED_BY, MOBILE, EMAIL, CITY_ID, AREA_ID, CREDIT_DAYS, ADDRESS) 
                 VALUES(
                     '" + cmbGroupAccount.SelectedValue.ToString() + @"',
                     '" + cmbControlAccount.SelectedValue.ToString() + @"',
                     '" + classHelper.AvoidInjection(txtAccountName.Text) + @"',
                     '" + classHelper.AvoidInjection(txtOpeningBalance.Text) + @"',
                     '" + drCr + @"',
                     '" + status + @"',
                     GETDATE(),
                     '" + Classes.Helper.userId + @"',
                     '" + classHelper.AvoidInjection(txtMOBILE.Text) + @"',
                     '" + classHelper.AvoidInjection(txtEMAIL.Text) + @"',
                     '" + cmbCITY.SelectedValue.ToString() + @"',
                     '" + cmbArea.SelectedValue.ToString() + @"',
                     '" + classHelper.AvoidInjection(txtCreditDays.Text) + @"',
                     '" + classHelper.AvoidInjection(txtADDRESS.Text) + @"'
                 )";

                    if (classHelper.SaveCoa(classHelper.query) >= 1) {
                        classHelper.ShowMessageBox("Record Saved Sucessfully.", "Information");
                        Clear();
                    }
                }
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void txtOPEN_BAL_KeyPress(object sender, KeyPressEventArgs e)
        {
            try {
                classHelper.AllowNumbers(e);
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void txtOPEN_BAL_Leave(object sender, EventArgs e)
        {
            try {
                if (txtOpeningBalance.Text.Trim().Equals("")) {
                    txtOpeningBalance.Text = "0";
                }
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void btnADDGROUP_AC_Click(object sender, EventArgs e)
        {
            classHelper.query = @"SELECT '0' AS [id],'--SELECT ACCOUNT GROUP--' AS [name]
            UNION
            SELECT AG_CODE AS [id],AG_NAME AS [name] FROM ACCOUNT_GROUP 
            WHERE AN_ID = (SELECT AN_ID FROM CONTROL_ACCOUNT WHERE CA_ID = '" + cmbControlAccount.SelectedValue.ToString() + @"')
            ORDER BY [name]";
            classHelper.OpenGroupForm(classHelper.query,cmbGroupAccount);
        }

        private void grdSEARCH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try {
                
                loadDataFromGrid(e);
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void txtACCOUNT_NAME_MouseClick(object sender, MouseEventArgs e)
        {
            classHelper.select_all_text(sender as TextBox);
        }

        private void txtACCOUNT_NAME_Enter(object sender, EventArgs e)
        {
            classHelper.select_all_text(sender as TextBox);
        }

        private void cmbCONTROL_AC_TextUpdate(object sender, EventArgs e)
        {
            try
            {
                classHelper.CmbTextUpdate(sender as ComboBox);
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void cmbCONTROL_AC_DropDown(object sender, EventArgs e)
        {
            try {
                ComboBox cbo = (ComboBox)sender;
                cbo.PreviewKeyDown += new PreviewKeyDownEventHandler(cmbCONTROL_AC_PreviewKeyDown);
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void cmbCONTROL_AC_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try {
                ComboBox cbo = (ComboBox)sender;
                cbo.PreviewKeyDown -= cmbCONTROL_AC_PreviewKeyDown;
                if (cbo.DroppedDown) cbo.Focus();
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void cmbGROUP_AC_DropDown(object sender, EventArgs e)
        {
            try {
                ComboBox cbo = (ComboBox)sender;
                cbo.PreviewKeyDown += new PreviewKeyDownEventHandler(cmbGROUP_AC_PreviewKeyDown);
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void cmbGROUP_AC_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try {
                ComboBox cbo = (ComboBox)sender;
                cbo.PreviewKeyDown -= cmbGROUP_AC_PreviewKeyDown;
                if (cbo.DroppedDown) cbo.Focus();
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                classHelper.CoaGridSearch(txtSearching, grdSEARCH);
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void cmbControlAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbControlAccount.SelectedIndex > 0)
            {
                classHelper.LoadGroupAccount(cmbGroupAccount,Convert.ToInt16(cmbControlAccount.SelectedValue.ToString()));
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
            //try
            //{
            //    classHelper.CoaGridSearch(txtAccountName, grdSEARCH);
            //}
            //catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void treeCOA_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void cmbGroupAccount_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rdbRetail_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cmbCITY_SelectedIndexChanged(object sender, EventArgs e)
        {
          

              if (cmbCITY.SelectedIndex > 0)
              {
                classHelper.load_area(cmbArea, cmbCITY.SelectedValue.ToString());
                 cmbArea.Enabled = true;
            }
            else
            {
                cmbArea.Enabled = false;
            }
        }

        private void btnAddArea_Click(object sender, EventArgs e)
        {
            using (classHelper.frmAddArea = new frmAddArea())
            {
                if (classHelper.frmAddArea.ShowDialog() == System.Windows.Forms.DialogResult.Cancel || classHelper.frmAddArea.ShowDialog() == System.Windows.Forms.DialogResult.Abort)
                {
                    classHelper.load_area(cmbArea, cmbCITY.SelectedValue.ToString());
                }
            }
        }

        private void btnADD_CITY_Click(object sender, EventArgs e)
        {
            using (classHelper.frmAddCity = new frmAddCity())
            {
                if (classHelper.frmAddCity.ShowDialog() == System.Windows.Forms.DialogResult.Cancel || classHelper.frmAddCity.ShowDialog() == System.Windows.Forms.DialogResult.Abort)
                {
                    classHelper.load_city(cmbCITY);
                }
            }
        }

        private void cmbCITY_DropDown(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown += new PreviewKeyDownEventHandler(cmbCITY_PreviewKeyDown);
        }

        private void cmbCITY_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown -= cmbCITY_PreviewKeyDown;
            if (cbo.DroppedDown) cbo.Focus();

        }

        private void grdSEARCH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtADDRESS_TextChanged(object sender, EventArgs e)
        {

        }

        private void gridSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void txtCreditDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            classHelper.CheckNumber(e);
        }
    }
}
