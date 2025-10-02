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
    public partial class frmSupplierCategory : Form
    {
        Classes.Helper cls_fhp = new Classes.Helper();
        string id = "";
        int is_edit = 0;

        public frmSupplierCategory()
        {
            InitializeComponent();

        }

        //clear fields in form
        private void clear() {
            txtSEARCH.Clear();
            id = "";
            is_edit = 0;
            txtCONT_PER.Clear();
            chkDeActive.Checked = false;
        }


        //get data from grid on click
        private void load_data_fromGrid(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.grdSEARCH.Rows[e.RowIndex];
                id = row.Cells[0].Value.ToString();
                is_edit = 1;
                txtCONT_PER.Text = row.Cells[1].Value.ToString();
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
            cls_fhp.load_SupplierCategory_grid(grdSEARCH);
        }

        private void txtSEARCH_TextChanged(object sender, EventArgs e)
        {
            cls_fhp.SupplierCategory_grid_search(txtSEARCH, grdSEARCH);
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {
            if (txtCONT_PER.Text.Trim().Equals(""))
            {
                cls_fhp.ShowMessageBox(" field is blank.", "Warning");
                txtCONT_PER.Focus();
            }
            else {
                int status = 0;
                if (chkDeActive.Checked == true)
                {
                    status = 1;
                }
                cls_fhp.query = "IF EXISTS (select SUPP_TYPE_ID from SUPPLIER_TYPES WHERE SUPP_TYPE_ID = '" + id + "') UPDATE SUPPLIER_TYPES SET NAME = '" + cls_fhp.AvoidInjection(txtCONT_PER.Text) + "',MODIFICATION_DATE = GETDATE(), MODIFIED_BY = '" + Classes.Helper.userId + "',STAT = '"+status+ "' WHERE SUPP_TYPE_ID = '" + id + "' ELSE INSERT INTO SUPPLIER_TYPES VALUES('" + cls_fhp.AvoidInjection(txtCONT_PER.Text) + "','"+status+"',GETDATE(),'" + Classes.Helper.userId + "',NULL,NULL,1)";
                if (cls_fhp.InsertUpdateDelete(cls_fhp.query) >= 1) {
                    cls_fhp.ShowMessageBox("Record Saved Sucessfully.", "Information");
                    clear();
                    cls_fhp.load_SupplierCategory_grid(grdSEARCH);
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
    }
}
