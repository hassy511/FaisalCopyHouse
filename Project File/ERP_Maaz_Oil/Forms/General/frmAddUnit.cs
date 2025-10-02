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
    public partial class frmAddUnit : Form
    {
        Classes.Helper cls_fhp = new Classes.Helper();
        string id = "";
        int is_edit = 0;

        public frmAddUnit()
        {
            InitializeComponent();
        }
        //============loading grid query--------------------->
        string query = @"SELECT UNIT_ID,UNIT_NAME,STAT
        FROM UNITS order by UNIT_ID desc";
        

        //clear fields in form
        private void clear() {
            txtUNIT.Clear();
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

                txtUNIT.Text = row.Cells[1].Value.ToString();
                

                

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


            
            if (txtUNIT.Text.Trim().Equals(""))
            {

                cls_fhp.ShowMessageBox("Unit field is blank.", "Warning");
                txtUNIT.Focus();
            }

            else {
                int status = 0;
                if (chkDeActive.Checked == true)
                {
                    status = 1;
                }
                cls_fhp.query = @"IF EXISTS (select UNIT_ID from UNITS WHERE UNIT_ID ='"+id+"') UPDATE UNITS SET UNIT_NAME = '" + txtUNIT.Text+ "',STAT = '" + status + "',MODIFICATION_DATE = '" 
                    + DateTime.Now + "', MODIFIED_BY = '" + Classes.Helper.userId 
                    + "' WHERE UNIT_ID = '"+id+"' ELSE INSERT INTO UNITS VALUES('" 
                    + cls_fhp.AvoidInjection(txtUNIT.Text) + "','"+status.ToString()+"','" + Classes.Helper.userId
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
