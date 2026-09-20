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
    public partial class frmSalesPerson : Form
    {
        Classes.Helper cls_fhp = new Classes.Helper();
        string id = "";
        int is_edit = 0;

        public frmSalesPerson()
        {
            InitializeComponent();
        }

        //clear fields in form
        private void clear() {
            cmbCITY.SelectedIndex = 0;
            txtSEARCH.Clear();
            id = "";
            txtEMAIL.Clear();
            txtMOBILE.Clear();
            is_edit = 0;
            txtCONT_PER.Clear();
        }


        //get data from grid on click
        private void load_data_fromGrid(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.grdSEARCH.Rows[e.RowIndex];
                id = row.Cells[0].Value.ToString();
                is_edit = 1;
                cmbCITY.SelectedValue = row.Cells[6].Value.ToString();
                cmbArea.SelectedValue = row.Cells[4].Value.ToString();
                txtCONT_PER.Text = row.Cells[1].Value.ToString();
                txtMOBILE.Text = row.Cells[2].Value.ToString();
                txtEMAIL.Text = row.Cells[3].Value.ToString();


                if (row.Cells[8].Value.ToString().Equals("0"))
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
            cls_fhp.load_salePerson_grid(grdSEARCH);
            cls_fhp.load_city(cmbCITY);
        }

        private void txtSEARCH_TextChanged(object sender, EventArgs e)
        {
            cls_fhp.salePerson_grid_search(txtSEARCH, grdSEARCH);
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {
            if (cmbCITY.SelectedIndex == 0)
            {
                cls_fhp.ShowMessageBox("City is not selected, please select city.", "Warning");
                cmbCITY.Focus();
                return;
            }
            if (cmbArea.SelectedIndex == 0)
            {
                cls_fhp.ShowMessageBox("Area is not selected, please select area.", "Warning");
                cmbArea.Focus();
                return;
            }
            if (txtMOBILE.Text.Trim().Equals("") ) {
                cls_fhp.ShowMessageBox("Mobile field is blank.", "Warning");
                txtMOBILE.Focus();
                return;
            }
            if (txtEMAIL.Text.Trim().Equals("") ) {
                cls_fhp.ShowMessageBox("Email field is blank.", "Warning");
                txtEMAIL.Focus();
                return;
            }
            if (txtCONT_PER.Text.Trim().Equals(""))
            {
                cls_fhp.ShowMessageBox("Contact Person field is blank.", "Warning");
                txtCONT_PER.Focus();
            }
            else {
                int status = 0;
                if (chkDeActive.Checked == true)
                {
                    status = 1;
                }
                cls_fhp.query = "IF EXISTS (select SALES_PER_ID from SALES_PERSONS WHERE SALES_PER_ID = '" + id + "') UPDATE SALES_PERSONS SET NAME = '" + cls_fhp.AvoidInjection(txtCONT_PER.Text) + "',MOBILE = '" + cls_fhp.AvoidInjection(txtMOBILE.Text) + "',EMAIL = '" + cls_fhp.AvoidInjection(txtEMAIL.Text) + "',CITY_ID = '" + cmbCITY.SelectedValue.ToString() + "',AREA_ID = '" + cmbArea.SelectedValue.ToString() + "',MODIFICATION_DATE = GETDATE(), MODIFIED_BY = '" + Classes.Helper.userId + "',STAT = '"+status+"' WHERE SALES_PER_ID = '" + id + "' ELSE INSERT INTO SALES_PERSONS VALUES('" + cls_fhp.AvoidInjection(txtCONT_PER.Text) + "','" + cls_fhp.AvoidInjection(txtMOBILE.Text) + "','" + cls_fhp.AvoidInjection(txtEMAIL.Text) + "','" + cmbCITY.SelectedValue.ToString() + "','"+status+"',GETDATE(),'" + Classes.Helper.userId + "',NULL,NULL,1,'" + cmbArea.SelectedValue.ToString() + "')";
                if (cls_fhp.InsertUpdateDelete(cls_fhp.query) >= 1) {
                    cls_fhp.ShowMessageBox("Record Saved Sucessfully.", "Information");
                    clear();
                    cls_fhp.load_salePerson_grid(grdSEARCH);
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
            else {
                cmbArea.Enabled = false;
            }
        }

        private void grdSEARCH_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            grdSEARCH.Columns[0].Visible = false;
            grdSEARCH.Columns[4].Visible = false;
            grdSEARCH.Columns[6].Visible = false;
            grdSEARCH.Columns[8].Visible = false;
        }

        private void btnCLEAR_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void grdSEARCH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           load_data_fromGrid(e); 
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

        private void btnAddArea_Click(object sender, EventArgs e)
        {
            using (cls_fhp.frmAddArea = new frmAddArea())
            {
                if (cls_fhp.frmAddArea.ShowDialog() == System.Windows.Forms.DialogResult.Cancel || cls_fhp.frmAddArea.ShowDialog() == System.Windows.Forms.DialogResult.Abort)
                {
                    cls_fhp.load_area(cmbArea,cmbCITY.SelectedValue.ToString());
                }
            }
        }

        private void cmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
