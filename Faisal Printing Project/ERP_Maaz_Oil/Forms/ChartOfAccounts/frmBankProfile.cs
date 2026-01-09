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
    public partial class frmBankProfile : Form
    {
        Classes.Helper cls_fhp = new Classes.Helper();
        string id = "";
        int is_edit = 0;

        public frmBankProfile()
        {
            InitializeComponent();
        }

        string query = @"select 
        A.BANK_PRO,C.COA_NAME,A.AC_NUMBER,
        A.AC_TITLE,A.BRANCH_CODE,A.PHONE,
        A.MOBILE,A.EMAIL,A.ADDRESS,
        A.CITY_ID,convert(varchar(100),A.CREDIT_LIMIT) as Credit_Limit ,A.CONTACT_PERSON,A.COA_ID,
        B.CITY_NAME as [CITY],A.AREA_ID,D.AREA_NAME AS [AREA],
        A.STAT FROM BANK_PROFILE A, CITY B, COA C,AREA D
        WHERE A.CITY_ID = B.CITY_ID and A.COA_ID = C.COA_ID AND A.AREA_ID = D.AREA_ID";
        //load BANK PROFILE

        private void load_Account()
        {
            try
            {
                cls_fhp.query = "SELECT '0' AS [id], '--SELECT BANK ACCOUNT--' AS [name] UNION SELECT COA_ID AS [id],COA_NAME AS [name] FROM COA WHERE CA_ID = 5";
                cls_fhp.LoadComboData(cmbACCOUNT, cls_fhp.query);
            }
            catch (Exception ex) { cls_fhp.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        //load City

        private void load_city()
        {
            try
            {
                cls_fhp.query = "select 0 as [id],'--SELECT CITY--' as [name] UNION select CITY_ID as [id],CITY_NAME as [name] from CITY ORDER BY NAME";
                cls_fhp.LoadComboData(cmbCITY, cls_fhp.query);
            }
            catch (Exception ex) { cls_fhp.ShowMessageBox(ex.ToString(), "Exception"); }
        }


        //clear fields in form
        private void clear() {
            cmbCITY.SelectedIndex = 0;
            cmbArea.SelectedIndex = 0;
            cmbACCOUNT.SelectedIndex = 0;
            txtACC_NO.Clear();
            txtSEARCH.Clear();
            id = "";
            txtEMAIL.Clear();
            txtMOBILE.Clear();
            txtPHONE.Clear();
            txtADDRESS.Clear();
            txtCONTACT_PERSON.Clear();
            txtLIMIT.Clear();
            txtACC_TITLE.Clear();
            txtBRANCH.Clear();
            is_edit = 0;
        }


        //get data from grid on click
        private void load_data_fromGrid(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.grdSEARCH.Rows[e.RowIndex];
                //id = row.Cells[0].Value.ToString();
                is_edit = 1;
                cmbACCOUNT.Text = row.Cells[1].Value.ToString();
                txtACC_NO.Text = row.Cells[3].Value.ToString();
                txtACC_TITLE.Text = row.Cells[4].Value.ToString();
                txtBRANCH.Text = row.Cells[5].Value.ToString();
                txtPHONE.Text = row.Cells[6].Value.ToString();
                txtMOBILE.Text = row.Cells[7].Value.ToString();
                txtEMAIL.Text = row.Cells[8].Value.ToString();
                txtADDRESS.Text = row.Cells[9].Value.ToString();
                cmbCITY.Text = row.Cells[10].Value.ToString();
                cmbArea.Text = row.Cells[14].Value.ToString();
                txtLIMIT.Text = row.Cells[11].Value.ToString();
                txtCONTACT_PERSON.Text = row.Cells[12].Value.ToString();
                
                
                if (row.Cells[15].Value.ToString().Equals("0"))
                {
                    chkDeActive.Checked = false;
                }
                else
                {
                    chkDeActive.Checked = true;
                }
            }
        }

        private void frm_AddGroupAccounts_Load(object sender, EventArgs e)
        {
            cls_fhp.LoadGrid(grdSEARCH, query);
            load_Account();
            load_city();
        }

        private void txtSEARCH_TextChanged(object sender, EventArgs e)
        {
            cls_fhp.BankProfile_grid_search(txtSEARCH, grdSEARCH);
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {

            if (cmbACCOUNT.SelectedIndex == 0)
            {
                cls_fhp.ShowMessageBox("Account is not selected, please select Account.", "Warning");
                cmbACCOUNT.Focus();
            }
            else if (txtACC_NO.Text.Trim().Equals(""))
            {
                cls_fhp.ShowMessageBox("Account number field is blank.", "Warning");
                txtACC_NO.Focus();
            }

            else if (txtACC_TITLE.Text.Trim().Equals(""))
            {
                cls_fhp.ShowMessageBox("Account title field is blank.", "Warning");
                txtACC_TITLE.Focus();
            }

            else if (txtBRANCH.Text.Trim().Equals(""))
            {
                cls_fhp.ShowMessageBox("Branch number field is blank.", "Warning");
                txtBRANCH.Focus();
            }
            else if (txtMOBILE.Text.Trim().Equals(""))
            {
                cls_fhp.ShowMessageBox("Mobile field is blank.", "Warning");
                txtMOBILE.Focus();
            }

            else if (txtPHONE.Text.Trim().Equals(""))
            {
                cls_fhp.ShowMessageBox("PHONE field is blank.", "Warning");
                txtPHONE.Focus();
            }

            else if (txtEMAIL.Text.Trim().Equals(""))
            {
                cls_fhp.ShowMessageBox("Email field is blank.", "Warning");
                txtEMAIL.Focus();
            }
            else if (cmbCITY.SelectedIndex == 0)
            {
                cls_fhp.ShowMessageBox("City is not selected, please select city.", "Warning");
                cmbCITY.Focus();
            }
            else if (cmbArea.SelectedIndex == 0)
            {
                cls_fhp.ShowMessageBox("Area is not selected, please select area.", "Warning");
                cmbArea.Focus();
            }
            else if (txtLIMIT.Text.Trim().Equals(""))
            {
                cls_fhp.ShowMessageBox("Credit limit field is blank.", "Warning");
                txtLIMIT.Focus();
            }
            else if (txtCONTACT_PERSON.Text.Trim().Equals(""))
            {
                cls_fhp.ShowMessageBox("Contact Person field is blank.", "Warning");
                txtCONTACT_PERSON.Focus();
            }

            else if (txtADDRESS.Text.Trim().Equals(""))
            {
                cls_fhp.ShowMessageBox("Address field is blank.", "Warning");
                txtADDRESS.Focus();
            }
            
            

            else {
                int status = 0;
                if (chkDeActive.Checked == true)
                {
                    status = 1;
                }
                cls_fhp.query = @"IF EXISTS (select BANK_PRO from BANK_PROFILE WHERE BANK_PRO ='" + id+ 
                    "') UPDATE BANK_PROFILE SET AC_NUMBER = '" + txtACC_NO.Text+ 
                    "',AC_TITLE= '" + cls_fhp.AvoidInjection(txtACC_TITLE.Text) + 
                    "' ,BRANCH_CODE= '" + cls_fhp.AvoidInjection(txtBRANCH.Text) + 
                    "',PHONE = '" + cls_fhp.AvoidInjection(txtPHONE.Text) + 
                    "' ,MOBILE = '" + cls_fhp.AvoidInjection(txtMOBILE.Text) + 
                    "',EMAIL = '" + cls_fhp.AvoidInjection(txtEMAIL.Text) +
                    "',ADDRESS = '" + cls_fhp.AvoidInjection(txtADDRESS.Text) +
                    "',CITY_ID = '" + cmbCITY.SelectedValue.ToString() +
                    "',AREA_ID = '" + cmbArea.SelectedValue.ToString() +
                    "',CREDIT_LIMIT = '" + cls_fhp.AvoidInjection(txtLIMIT.Text) +
                    "',CONTACT_PERSON = '" + cls_fhp.AvoidInjection(txtCONTACT_PERSON.Text)+
                    "',STAT = '" + status + 
                    "',MODIFICATION_DATE = '" + DateTime.Now + 
                    "', MODIFIED_BY = '" + Classes.Helper.userId +
                    "' WHERE BANK_PRO = '" + id+
                    "' ELSE INSERT INTO BANK_PROFILE VALUES('"
                    +cmbACCOUNT.SelectedValue.ToString()+"','"
                    + cls_fhp.AvoidInjection(txtACC_NO.Text) +
                    "','" + cls_fhp.AvoidInjection(txtACC_TITLE.Text) 
                    +"','"+ cls_fhp.AvoidInjection(txtBRANCH.Text) + 
                    "', '" + cls_fhp.AvoidInjection(txtPHONE.Text) + 
                    "','" + cls_fhp.AvoidInjection(txtMOBILE.Text) + 
                    "','" + cls_fhp.AvoidInjection(txtEMAIL.Text) + 
                    "','" + cls_fhp.AvoidInjection(txtADDRESS.Text) + 
                    "', '" + cmbCITY.SelectedValue.ToString()+ 
                    "','" + cls_fhp.AvoidInjection(txtLIMIT.Text) + 
                    "','" + cls_fhp.AvoidInjection(txtCONTACT_PERSON.Text) 
                    + "','"+ status +"',GETDATE(), 1,NULL,1,1,'"+cmbArea.SelectedValue.ToString()+"')";
                    
                if (cls_fhp.InsertUpdateDelete(cls_fhp.query) >= 1) {
                    cls_fhp.ShowMessageBox("Record Saved Sucessfully.", "Information");
                    clear();
                    cls_fhp.LoadGrid(grdSEARCH, query);
                }

            }
        }

        private void cmbPACCOUNT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCITY.SelectedIndex > 0)
            {
                cls_fhp.load_area(cmbArea, cmbCITY.SelectedValue.ToString());
                cmbArea.Enabled = true;
            }
            else
            {
                cmbArea.Enabled = false;
            }
        }

        private void grdSEARCH_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            grdSEARCH.Columns[0].Visible = false;
            grdSEARCH.Columns[9].Visible = false;
            grdSEARCH.Columns[12].Visible = false;

        }

        private void btnCLEAR_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void grdSEARCH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           load_data_fromGrid(e); 
        }


        
        private void txtPHONE_MouseClick(object sender, MouseEventArgs e)
        {
            cls_fhp.select_all_text(sender as TextBox);
        }

        private void txtPHONE_Enter(object sender, EventArgs e)
        {
            cls_fhp.select_all_text(sender as TextBox);
        }

        private void txtPHONE_Leave(object sender, EventArgs e)
        {
            
        }

        private void cmbVENDOR_TextUpdate(object sender, EventArgs e)
        {
            cls_fhp.CmbTextUpdate(sender as ComboBox);
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

        private void txtPHONE_KeyPress(object sender, KeyPressEventArgs e)
        {
            cls_fhp.AllowNumbers(e);
        }

        

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnADD_CITY_Click(object sender, EventArgs e)
        {
            using (cls_fhp.frmAddCity = new frmAddCity())
            {
                if (cls_fhp.frmAddCity.ShowDialog() == System.Windows.Forms.DialogResult.Cancel || cls_fhp.frmAddCity.ShowDialog() == System.Windows.Forms.DialogResult.Abort)
                {
                    cls_fhp.load_city(cmbCITY);
                }
            }
        }

        private void btnAddArea_Click(object sender, EventArgs e)
        {
            using (cls_fhp.frmAddArea = new frmAddArea())
            {
                if (cls_fhp.frmAddArea.ShowDialog() == System.Windows.Forms.DialogResult.Cancel || cls_fhp.frmAddArea.ShowDialog() == System.Windows.Forms.DialogResult.Abort)
                {
                    cls_fhp.load_area(cmbArea, cmbCITY.SelectedValue.ToString());
                }
            }
        }
    }
}
