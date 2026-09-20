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
    public partial class frmSupplierProfile : Form
    {
        Classes.Helper cls_fhp = new Classes.Helper();
        string id = "";
        int is_edit = 0;

        public frmSupplierProfile()
        {
            InitializeComponent();
        }

        string query = @"SELECT A.SUPP_PRO,C.COA_NAME,A.COA_ID,A.SUPP_TYPE_ID,D.NAME as [SUPPLIER TYPE],
        A.CONTACT_PERSON,A.MOBILE,A.EMAIL,A.CITY_ID,B.CITY_NAME as [CITY],A.AREA_ID,E.AREA_NAME,A.ADDRESS,A.NTN_NUMBER,A.STRN_NUMBER,
        A.GST_NUMBER,convert(varchar(100), A.CREDIT_LIMIT) as CREDIT_LIMIT,A.STAT
        FROM SUPPLIER_PROFILE A, CITY B, COA C, SUPPLIER_TYPES D,AREA E
        WHERE A.COA_ID=C.COA_ID and A.CITY_ID=B.CITY_ID and A.SUPP_TYPE_ID=D.SUPP_TYPE_ID AND A.AREA_ID = E.AREA_ID";

        //load BANK PROFILE

        private void load_Supplier()
        {
            try
            {
                cls_fhp.query = "SELECT '0' AS [id], '--SELECT SUPPLIER--' AS [name] UNION SELECT COA_ID AS [id],COA_NAME AS [name] FROM COA WHERE CA_ID = 20";
                cls_fhp.LoadComboData(cmbSUPPLIER, cls_fhp.query);
            }
            catch (Exception ex) { cls_fhp.ShowMessageBox(ex.ToString(), "Exception"); }
        }
        private void load_AREA()
        {
            try
            {
                cls_fhp.query = "select 0 as [id],'--SELECT AREA--' as [name] UNION select AREA_ID as [id],AREA_NAME as [name] from AREA ORDER BY NAME";
                cls_fhp.LoadComboData(cmbArea, cls_fhp.query);
            }
            catch (Exception ex) { cls_fhp.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void load_Supplier_Type()
        {
            try
            {
                cls_fhp.query = "SELECT '0' AS[id], '--SELECT SUPPLIER TPYE--' AS[name] UNION SELECT SUPP_TYPE_ID AS[id], NAME AS[name] FROM SUPPLIER_TYPES WHERE STAT = 1";
                cls_fhp.LoadComboData(cmbTYPE, cls_fhp.query);
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
            cmbSUPPLIER.SelectedIndex = 0;
            txtNTN.Clear();
            txtSEARCH.Clear();
            id = "";
            txtEMAIL.Clear();
            txtMOBILE.Clear();
            cmbTYPE.SelectedIndex = 0;
            txtADDRESS.Clear();
            txtCONTACT_PERSON.Clear();
            txtLIMIT.Clear();
            txtSTRN.Clear();
            txtGST.Clear();
            cmbArea.SelectedIndex = 0;
            is_edit = 0;
            chkDeActive.Checked = false;
        }


        //get data from grid on click
        private void load_data_fromGrid(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = this.grdSEARCH.Rows[e.RowIndex];
                //id = row.Cells[0].Value.ToString();
                is_edit = 1;
                cmbSUPPLIER.SelectedValue = row.Cells[2].Value.ToString();
                //cmbTYPE.SelectedValue = row.Cells[3].Value.ToString();
                txtCONTACT_PERSON.Text = row.Cells[5].Value.ToString();
                txtMOBILE.Text = row.Cells[6].Value.ToString();
                txtEMAIL.Text = row.Cells[7].Value.ToString();
                cmbCITY.SelectedValue = row.Cells[8].Value.ToString();
                cmbArea.SelectedValue = row.Cells[10].Value.ToString();
                txtADDRESS.Text = row.Cells[12].Value.ToString();
                txtNTN.Text = row.Cells[13].Value.ToString();
                txtSTRN.Text = row.Cells[14].Value.ToString();
                txtGST.Text = row.Cells[15].Value.ToString();
                txtLIMIT.Text = row.Cells[16].Value.ToString();
                if (row.Cells[17].Value.ToString().Equals("0"))
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
            //load_Supplier_Type();
            load_city();
            load_AREA();   
            load_Supplier();
        }

        private void txtSEARCH_TextChanged(object sender, EventArgs e)
        {
            cls_fhp.SUPPILER_Profile_grid_search(txtSEARCH, grdSEARCH);
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {
            if (cmbSUPPLIER.SelectedIndex == 0)
            {
                cls_fhp.ShowMessageBox("Supplier is not selected, please select Supplier.", "Warning");
                cmbSUPPLIER.Focus();
            }
            else if (txtNTN.Text.Trim().Equals(""))
            {
                cls_fhp.ShowMessageBox("NTN number field is blank.", "Warning");
                txtNTN.Focus();
            }

            else if (txtSTRN.Text.Trim().Equals(""))
            {
                cls_fhp.ShowMessageBox("STRN # field is blank.", "Warning");
                txtSTRN.Focus();
            }

            else if (txtGST.Text.Trim().Equals(""))
            {
                cls_fhp.ShowMessageBox("GST number field is blank.", "Warning");
                txtGST.Focus();
            }

            else if (txtMOBILE.Text.Trim().Equals(""))
            {
                cls_fhp.ShowMessageBox("Mobile field is blank.", "Warning");
                txtMOBILE.Focus();
            }
            // else if (cmbTYPE.SelectedIndex == 0)
            //{
            //    cls_fhp.ShowMessageBox("SUPPLIER TYPE is not selected, please select TYPE.", "Warning");
            //    cmbTYPE.Focus();
            //}

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
            
            
            else
            {
                int status = 0;
                if (chkDeActive.Checked == true)
                {
                    status = 1;
                }
                cls_fhp.query = @"IF EXISTS (select COA_ID from SUPPLIER_PROFILE 
                                  WHERE COA_ID ='" + cmbSUPPLIER.SelectedValue.ToString()+
                    "') UPDATE SUPPLIER_PROFILE SET NTN_NUMBER = '" + txtNTN.Text+ 
                    "',STRN_NUMBER= '" + cls_fhp.AvoidInjection(txtSTRN.Text) + 
                    "' ,GST_NUMBER= '" + cls_fhp.AvoidInjection(txtGST.Text) + 
                    "',MOBILE = '" + cls_fhp.AvoidInjection(txtMOBILE.Text) + 
                    "',EMAIL = '" + cls_fhp.AvoidInjection(txtEMAIL.Text) +
                    "',ADDRESS = '" + cls_fhp.AvoidInjection(txtADDRESS.Text) +
                    "',CITY_ID = '" + cmbCITY.SelectedValue.ToString() +
                    "',AREA_ID = '" + cmbArea.SelectedValue.ToString() +
                    "',COA_ID = '" + cmbSUPPLIER.SelectedValue.ToString() +
                    "',SUPP_TYPE_ID = '1',CREDIT_LIMIT = '" + cls_fhp.AvoidInjection(txtLIMIT.Text) +
                    "',CONTACT_PERSON = '" + cls_fhp.AvoidInjection(txtCONTACT_PERSON.Text)+
                    "',STAT = '" + status + 
                    "',MODIFICATION_DATE = '" + DateTime.Now + 
                    "', MODIFIED_BY = '" + Classes.Helper.userId +
                    "' WHERE COA_ID = '" + cmbSUPPLIER.SelectedValue.ToString() +
                    "' ELSE INSERT INTO SUPPLIER_PROFILE VALUES('"
                    + cmbSUPPLIER.SelectedValue.ToString()+"','1','"
                    + cls_fhp.AvoidInjection(txtCONTACT_PERSON.Text) +
                    "','" + cls_fhp.AvoidInjection(txtMOBILE.Text) 
                    +"','"+ cls_fhp.AvoidInjection(txtEMAIL.Text) + 
                    "', '" + cls_fhp.AvoidInjection(txtADDRESS.Text) + 
                    "','" + cmbCITY.SelectedValue.ToString()  + 
                    "','" + cls_fhp.AvoidInjection(txtNTN.Text) + 
                    "', '" + cls_fhp.AvoidInjection(txtSTRN.Text) +
                    "','" + cls_fhp.AvoidInjection(txtGST.Text) + 
                    "','" + cls_fhp.AvoidInjection(txtLIMIT.Text) 
                    + "','" + cls_fhp.AvoidInjection(cmbArea.SelectedValue.ToString())
                    + "','" + status +"',GETDATE(),1,NULL,1,1)";
                    
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
            grdSEARCH.Columns[2].Visible = false;
            grdSEARCH.Columns[3].Visible = false;
            grdSEARCH.Columns[8].Visible = false;
            grdSEARCH.Columns[10].Visible = false;
            grdSEARCH.Columns[17].Visible = false;

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

        private void cmbSUPPLIER_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbSUPPLIER.SelectedIndex == 0)
                {
                    clear();
                }
                else
                {
                    cls_fhp.GetSupplierData(grdSEARCH, cmbSUPPLIER.SelectedValue.ToString(), txtNTN, txtSTRN, txtGST, txtMOBILE, cmbTYPE, txtEMAIL, cmbCITY, cmbArea, txtCONTACT_PERSON, txtLIMIT, txtADDRESS, chkDeActive);
                }
            }

            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }
    }
}
