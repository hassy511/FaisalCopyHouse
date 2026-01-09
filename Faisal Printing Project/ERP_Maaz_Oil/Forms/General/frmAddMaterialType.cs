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
    public partial class frmAddMaterialType : Form
    {
        Classes.Helper cls_fhp = new Classes.Helper();
        string id = "";
        int is_edit = 0;

        public frmAddMaterialType()
        {
            InitializeComponent();
        }
        //============loading grid query--------------------->
        string query = @"SELECT M_TYPE_ID,M_TYPE_NAME,STAT
                        FROM MATERIAL_TYPES
                        ORDER BY M_TYPE_ID DESC";
        

        //clear fields in form
        private void clear() {
            txtMaterialType.Clear();
            chkDeActive.Checked = false;
            txtSEARCH.Clear();
            is_edit = 0;
            id = "";
        }


        //get data from grid on click
        private void load_data_fromGrid(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.grdSEARCH.Rows[e.RowIndex];
                id = row.Cells[0].Value.ToString();
                is_edit = 1;

                txtMaterialType.Text = row.Cells[1].Value.ToString();
                

                

                if (row.Cells[2].Value.ToString().Equals("0"))
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
        }

        private void txtSEARCH_TextChanged(object sender, EventArgs e)
        {
           cls_fhp.unit_search(txtSEARCH, grdSEARCH);
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {


            
            if (txtMaterialType.Text.Trim().Equals(""))
            {

                cls_fhp.ShowMessageBox("Material Type field is blank.", "Warning");
                txtMaterialType.Focus();
            }

            else {
                int status = 0;
                if (chkDeActive.Checked == true)
                {
                    status = 1;
                }
                cls_fhp.query = @"IF EXISTS (select M_TYPE_ID from MATERIAL_TYPES WHERE M_TYPE_ID ='" + id+ @"') 
                    UPDATE MATERIAL_TYPES SET M_TYPE_NAME = '" + txtMaterialType.Text+ "',STAT = '" + status + "',MODIFICATION_DATE = '" 
                    + DateTime.Now + "', MODIFIED_BY = '" + Classes.Helper.userId 
                    + "' WHERE M_TYPE_ID = '" + id+ "' ELSE INSERT INTO MATERIAL_TYPES VALUES('"
                    + cls_fhp.AvoidInjection(txtMaterialType.Text) + "','"+status.ToString()+"','" + Classes.Helper.userId
                    + "',GETDATE(),NULL,1,1)";
                    
                if (cls_fhp.InsertUpdateDelete(cls_fhp.query) >= 1) {
                    cls_fhp.ShowMessageBox("Record Saved Sucessfully.", "Information");
                    clear();
                    cls_fhp.LoadGrid(grdSEARCH, query);
                }

            }
        }

        private void cmbPACCOUNT_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void grdSEARCH_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            grdSEARCH.Columns[0].Visible = false;
            grdSEARCH.Columns[2].Visible = false;

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
        
    }
}
