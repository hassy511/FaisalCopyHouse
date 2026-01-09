using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP_Maaz_Oil
{
    public partial class frmAddGroupAccounts : Form
    {
        Classes.Helper cls_fhp = new Classes.Helper();

        string group_id = "";
        int level;
        int is_edit = 0;

        public frmAddGroupAccounts()
        {
            InitializeComponent();
        }

        //clear fields in form
        private void clear()
        {
            try
            {
                cmbACCOUNT_NATURE.SelectedIndex = 0;
                cmbACCOUNT_NATURE.Enabled = true;
                cmbACCOUNT_NATURE.Focus();
                cmbPACCOUNT.SelectedIndex = 0;
                cmbPACCOUNT.Enabled = true;
                txtSEARCH.Clear();
                txtGROUP.Clear();
                group_id = "";
                level = 0;
                is_edit = 0;
            }
            catch (Exception ex) { cls_fhp.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        //generate account code
        private string generate_level_id(int level_no, string parent_code)
        {
            string ag_cod = "";
            try
            {
                if (level_no == 1)
                {
                    ag_cod = parent_code + "00";
                }
                else if (level_no == 2)
                {
                    ag_cod = parent_code + "000";
                }
                else if (level_no == 3)
                {
                    ag_cod = parent_code + "0000";
                }
                else if (level_no == 4)
                {
                    ag_cod = parent_code + "00000";
                }
                else if (level_no == 5)
                {
                    ag_cod = parent_code + "000000";
                }
                else if (level_no == 6)
                {
                    ag_cod = parent_code + "0000000";
                }
                else if (level_no == 7)
                {
                    ag_cod = parent_code + "00000000";
                }
            }
            catch (Exception ex) { cls_fhp.ShowMessageBox(ex.ToString(), "Exception"); }
            return ag_cod;
        }

        //get data from grid on click
        private void load_data_fromGrid(DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.grdSEARCH.Rows[e.RowIndex];
                    group_id = row.Cells[4].Value.ToString();
                    is_edit = 1;
                    cmbACCOUNT_NATURE.SelectedValue = row.Cells[0].Value.ToString();
                    cmbACCOUNT_NATURE.Enabled = false;
                    cmbPACCOUNT.SelectedValue = row.Cells[2].Value.ToString();
                    cmbPACCOUNT.Enabled = false;
                    txtGROUP.Text = row.Cells[5].Value.ToString();
                    txtGROUP.Focus();
                    level = int.Parse(row.Cells[6].Value.ToString());
                }
            }
            catch (Exception ex) { cls_fhp.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void frmAddGroupAccounts_Load(object sender, EventArgs e)
        {
            try
            {
                cls_fhp.load_group_grid(grdSEARCH);
                cls_fhp.load_account_nature(cmbACCOUNT_NATURE);
                cls_fhp.load_group_account(cmbPACCOUNT);
                ////Classes.Helper.userId = 1;
            }
            catch (Exception ex) { cls_fhp.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void txtSEARCH_TextChanged(object sender, EventArgs e)
        {

            try
            {
                cls_fhp.AccountGroupGridSearching(txtSEARCH, grdSEARCH);
            }
            catch (Exception ex) { cls_fhp.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {
            try
            {
                if (is_edit == 0)
                {
                    if (cls_fhp.check_name_exists(grdSEARCH, txtGROUP.Text,5) == 1)
                    {
                        cls_fhp.ShowMessageBox("Group name already exists in your record.", "Warning");
                        return;
                    }
                }
                if (cmbACCOUNT_NATURE.SelectedIndex == 0)
                {
                    cls_fhp.ShowMessageBox("Account nature is not selected, please select account nature.", "Warning");
                    cmbACCOUNT_NATURE.Focus();
                }
                else if (cmbPACCOUNT.SelectedIndex == 0)
                {
                    cls_fhp.ShowMessageBox("Parent account is not selected, please select parent account.", "Warning");
                    cmbPACCOUNT.Focus();
                }
                else if (txtGROUP.Text.Trim().Equals(""))
                {
                    cls_fhp.ShowMessageBox("Group name field is blank.", "Warning");
                    txtGROUP.Focus();
                }
                else
                {
                    cls_fhp.query = "IF EXISTS (select AG_CODE from ACCOUNT_GROUP WHERE AG_CODE = '" + group_id + "') UPDATE ACCOUNT_GROUP SET AG_NAME = '" + cls_fhp.AvoidInjection(txtGROUP.Text) + "',MODIFICATION_DATE = GETDATE(), MODIFIED_BY = '" + Classes.Helper.userId + "' WHERE AG_CODE = '" + group_id + "' ELSE INSERT INTO ACCOUNT_GROUP VALUES('" + cmbACCOUNT_NATURE.SelectedValue.ToString() + "','" + cmbPACCOUNT.SelectedValue.ToString() + "',CAST('" + generate_level_id(level, cmbPACCOUNT.SelectedValue.ToString()) + "' AS VARCHAR) + CAST((CASE WHEN (select count(parent_id) from ACCOUNT_GROUP where PARENT_ID = '" + cmbPACCOUNT.SelectedValue.ToString() + "') = 0 THEN 1 ELSE (select count(parent_id)+1 from ACCOUNT_GROUP where PARENT_ID = '" + cmbPACCOUNT.SelectedValue.ToString() + "') END) AS VARCHAR),'" + cls_fhp.AvoidInjection(txtGROUP.Text) + "','" + (level + 1) + "',GETDATE(),'" + Classes.Helper.userId + "',NULL,NULL,1)";
                    if (cls_fhp.save_group(cls_fhp.query) >= 1)
                    {
                        cls_fhp.ShowMessageBox("Record Saved Sucessfully.", "Information");
                        clear();
                        cls_fhp.load_group_grid(grdSEARCH);
                    }
                }
            }
            catch (Exception ex) { cls_fhp.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void cmbPACCOUNT_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                level = cls_fhp.get_account_level(cmbPACCOUNT.SelectedValue.ToString(), grdSEARCH);
            }
            catch (Exception ex) { cls_fhp.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void grdSEARCH_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            grdSEARCH.Columns[0].Visible = false;
            grdSEARCH.Columns[2].Visible = false;
            grdSEARCH.Columns[4].Visible = false;
            grdSEARCH.Columns[6].Visible = false;
        }

        private void btnCLEAR_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void grdSEARCH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            load_data_fromGrid(e);
        }

        private void txtGROUP_Enter(object sender, EventArgs e)
        {
            cls_fhp.select_all_text(sender as TextBox);
        }

        private void txtGROUP_MouseClick(object sender, MouseEventArgs e)
        {
            cls_fhp.select_all_text(sender as TextBox);
        }

        private void cmbACCOUNT_NATURE_TextUpdate(object sender, EventArgs e)
        {
            cls_fhp.CmbTextUpdate(sender as ComboBox);
        }

        private void cmbACCOUNT_NATURE_DropDown(object sender, EventArgs e)
        {
            try
            {
                ComboBox cbo = (ComboBox)sender;
                cbo.PreviewKeyDown += new PreviewKeyDownEventHandler(cmbACCOUNT_NATURE_PreviewKeyDown);
            }
            catch (Exception ex) { cls_fhp.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void cmbACCOUNT_NATURE_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                ComboBox cbo = (ComboBox)sender;
                cbo.PreviewKeyDown -= cmbACCOUNT_NATURE_PreviewKeyDown;
                if (cbo.DroppedDown) cbo.Focus();
            }
            catch (Exception ex) { cls_fhp.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void cmbPACCOUNT_DropDown(object sender, EventArgs e)
        {
            try
            {
                ComboBox cbo = (ComboBox)sender;
                cbo.PreviewKeyDown += new PreviewKeyDownEventHandler(cmbPACCOUNT_PreviewKeyDown);
            }
            catch (Exception ex) { cls_fhp.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void cmbPACCOUNT_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                ComboBox cbo = (ComboBox)sender;
                cbo.PreviewKeyDown -= cmbPACCOUNT_PreviewKeyDown;
                if (cbo.DroppedDown) cbo.Focus();
            }
            catch (Exception ex) { cls_fhp.ShowMessageBox(ex.ToString(), "Exception"); }
        }
    }
}
