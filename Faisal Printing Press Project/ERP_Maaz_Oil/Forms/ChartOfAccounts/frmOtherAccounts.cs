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
    public partial class frmOtherAccounts : Form
    {

        Classes.Helper classHelper = new Classes.Helper();

        int accountId = 0;
       
        public frmOtherAccounts()
        {
            InitializeComponent();
        }

        //Clear fields in form
        private void Clear()
        {
            try
            {
                cmbControlAccount.SelectedIndex = 0;
                cmbControlAccount.Focus();
                //cmbControlAccount.SelectedValue = 21;
                txtSearch.Clear();
                txtAccountName.Clear();
                txtOpeningBalance.Text = "0";
                accountId = 0;
                chkDeActive.Checked = false;
                rdbDebit.Checked = true;
                txtMobile.Clear();
                cmbCity.Text = "";
                txtAddress.Clear();
                txtCreditDays.Text = "0";
                LoadGrid();
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
                    if (row.Cells["DEBIT CREDIT"].Value.ToString().Equals("DEBIT"))
                    {
                        rdbDebit.Checked = true;
                    }
                    else
                    {
                        rdbCredit.Checked = true;
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
                    txtMobile.Text = row.Cells["MOBILE"].Value.ToString();
                    txtAddress.Text = row.Cells["ADDRESS"].Value.ToString();
                    cmbCity.Text = row.Cells["CITY"].Value.ToString();
                    txtCreditDays.Text = row.Cells["CREDIT_DAYS"].Value.ToString();
                    txtAccountName.Text = row.Cells["ACCOUNT NAME"].Value.ToString();
                }

                cmbControlAccount.Focus();
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void LoadGrid()
        {
            classHelper.query = @" SELECT A.COA_ID AS [ID],C.CA_ID,C.CA_NAME AS [CONTROL ACCOUNT],
            A.COA_NAME AS [ACCOUNT NAME],
            A.OPEN_BAL AS [OPENING BALANCE],
            CASE WHEN A.DR_CR = 'D' THEN 'DEBIT' ELSE 'CREDIT' END AS [DEBIT CREDIT],
            CASE WHEN A.STAT = 0 THEN 'ACTIVE' ELSE 'DE-ACTIVE' END AS [STATUS],
            A.MOBILE,A.[ADDRESS],A.CITY_NAME AS [CITY],A.CREDIT_DAYS
            FROM COA A
            INNER JOIN CONTROL_ACCOUNT C ON A.CA_ID = C.CA_ID
            WHERE C.CA_ID in (5,6,10)
            ORDER BY [ACCOUNT NAME]";
            classHelper.LoadGrid(grdSEARCH, classHelper.query);
        }

        private void frm_ChartOfAccounts_Load(object sender, EventArgs e)
        {
            try
            {
                LoadGrid();
                classHelper.LoadControlAccount(cmbControlAccount, "5,6,10");
                //cmbControlAccount.SelectedValue = 21;
                classHelper.LoadCoaCities(cmbCity);
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void txtSEARCH_TextChanged(object sender, EventArgs e)
        {
            try
            {
                (grdSEARCH.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
                [" + grdSEARCH.Columns["ACCOUNT NAME"].Name.ToString() + "] LIKE '%" + classHelper.AvoidInjection(txtSearch.Text) + "%'");
                grdSEARCH.ClearSelection();
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void grdSEARCH_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            grdSEARCH.Columns["ID"].Visible = false;
            grdSEARCH.Columns["CA_ID"].Visible = false;
        }

        private void btnCLEAR_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {
            try
            {
                if (accountId == 0)
                {
                    if (classHelper.CheckNameExists(grdSEARCH, txtAccountName.Text, 3) == 1)
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
                else if (txtAccountName.Text.Trim().Equals(""))
                {
                    classHelper.ShowMessageBox("Account name field is blank.", "Warning");
                    txtAccountName.Focus();
                }
                else
                {
                    int status = 0;
                    if (chkDeActive.Checked == true)
                    {
                        status = 1;
                    }

                    string drCr = "D";
                    if (rdbCredit.Checked == true)
                    {
                        drCr = "C";
                    }

                    int groupId = 0;
                    int controlId = Convert.ToInt32(cmbControlAccount.SelectedValue);
                    
                    if (controlId == 5) { groupId = 9; }
                    else if (controlId == 6) { groupId = 9; }
                    else if (controlId == 10) { groupId = 16; }


                    classHelper.query = @"IF EXISTS (select COA_ID from COA WHERE COA_ID = '" + accountId + @"') 
                     UPDATE COA SET 
                     COA_NAME = '" + classHelper.AvoidInjection(txtAccountName.Text) + @"',
                     CA_ID = '" + cmbControlAccount.SelectedValue.ToString() + @"',
                     OPEN_BAL = '" + classHelper.AvoidInjection(txtOpeningBalance.Text) + @"',
                    MOBILE = '" + classHelper.AvoidInjection(txtMobile.Text) + @"',
                    ADDRESS = '" + classHelper.AvoidInjection(txtAddress.Text) + @"',
                    CITY_NAME = '" + classHelper.AvoidInjection(cmbCity.Text) + @"',
                    CREDIT_DAYS = '" + classHelper.AvoidInjection(txtCreditDays.Text) + @"',
                     STAT = '" + status + @"',
                     DR_CR = '" + drCr + @"',
                     MODIFICATION_DATE = GETDATE(),
                     MODIFIED_BY = '" + Classes.Helper.userId + @"'
                 WHERE COA_ID = '" + accountId + @"' 
                 ELSE 
                 INSERT INTO COA 
                 (AG_ID, CA_ID, COA_NAME, OPEN_BAL, DR_CR, STAT, CREATION_DATE, CREATED_BY,MOBILE,ADDRESS,CITY_NAME,CREDIT_DAYS) 
                 VALUES(
                     '"+ groupId + @"',
                     '" + cmbControlAccount.SelectedValue.ToString() + @"',
                     '" + classHelper.AvoidInjection(txtAccountName.Text) + @"',
                     '" + classHelper.AvoidInjection(txtOpeningBalance.Text) + @"',
                     '" + drCr + @"',
                     '" + status + @"',
                     GETDATE(),
                     '" + Classes.Helper.userId + @"','" + classHelper.AvoidInjection(txtMobile.Text) + @"','" + classHelper.AvoidInjection(txtAddress.Text) + @"','" + classHelper.AvoidInjection(cmbCity.Text) + @"','" + classHelper.AvoidInjection(txtCreditDays.Text) + @"')";

                    if (classHelper.SaveCoa(classHelper.query) >= 1)
                    {
                        classHelper.ShowMessageBox("Record Saved Sucessfully.", "Information");
                        Clear();
                    }
                }
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void txtOPEN_BAL_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                classHelper.AllowNumbers(e);
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void txtOPEN_BAL_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtOpeningBalance.Text.Trim().Equals(""))
                {
                    txtOpeningBalance.Text = "0";
                }
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        
        private void grdSEARCH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

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
            try
            {
                ComboBox cbo = (ComboBox)sender;
                cbo.PreviewKeyDown += new PreviewKeyDownEventHandler(cmbCONTROL_AC_PreviewKeyDown);
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void cmbCONTROL_AC_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                ComboBox cbo = (ComboBox)sender;
                cbo.PreviewKeyDown -= cmbCONTROL_AC_PreviewKeyDown;
                if (cbo.DroppedDown) cbo.Focus();
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void cmbGROUP_AC_DropDown(object sender, EventArgs e)
        {
            try
            {
                ComboBox cbo = (ComboBox)sender;
                cbo.PreviewKeyDown += new PreviewKeyDownEventHandler(cmbGROUP_AC_PreviewKeyDown);
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void cmbGROUP_AC_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
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
                (grdSEARCH.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
                [" + grdSEARCH.Columns["ACCOUNT NAME"].Name.ToString() + "] LIKE '%" + classHelper.AvoidInjection(txtSearch.Text) + "%'");
                grdSEARCH.ClearSelection();
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void cmbControlAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbControlAccount.SelectedIndex > 0)
            //{
            //    classHelper.LoadGroupAccount(cmbGroupAccount, Convert.ToInt16(cmbControlAccount.SelectedValue.ToString()));
            //    cmbGroupAccount.Enabled = true;
            //}
            //else
            //{
            //    if (cmbGroupAccount.Items.Count > 0)
            //    {
            //        cmbGroupAccount.SelectedIndex = 0;
            //    }
            //    cmbGroupAccount.Enabled = false;
            //}
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
            //if (cmbCITY.SelectedIndex > 0)
            //{
            //    classHelper.load_area(cmbArea, cmbCITY.SelectedValue.ToString());
            //    cmbArea.Enabled = true;
            //}
            //else
            //{
            //    cmbArea.Enabled = false;
            //}
        }

        private void btnAddArea_Click(object sender, EventArgs e)
        {
            //using (classHelper.frmAddArea = new frmAddArea())
            //{
            //    if (classHelper.frmAddArea.ShowDialog() == System.Windows.Forms.DialogResult.Cancel || classHelper.frmAddArea.ShowDialog() == System.Windows.Forms.DialogResult.Abort)
            //    {
            //        classHelper.load_area(cmbArea, cmbCITY.SelectedValue.ToString());
            //    }
            //}
        }

        private void btnADD_CITY_Click(object sender, EventArgs e)
        {
            //using (classHelper.frmAddCity = new frmAddCity())
            //{
            //    if (classHelper.frmAddCity.ShowDialog() == System.Windows.Forms.DialogResult.Cancel || classHelper.frmAddCity.ShowDialog() == System.Windows.Forms.DialogResult.Abort)
            //    {
            //        classHelper.load_city(cmbCITY);
            //    }
            //}
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
