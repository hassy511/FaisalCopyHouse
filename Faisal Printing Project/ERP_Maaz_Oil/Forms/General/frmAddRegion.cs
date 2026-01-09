using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP_Maaz_Oil.Forms
{
    public partial class frmAddRegion : Form
    {
        Classes.Helper cls_fhp = new Classes.Helper();

        string region_id = "";
        int is_edit = 0;

        public frmAddRegion()
        {
            InitializeComponent();
        }

        //clear fields in form
        private void clear()
        {
            try
            {
                txtSEARCH.Clear();
                txtREGION.Clear();
                region_id = "";
                is_edit = 0;
            }
            catch (Exception ex) { cls_fhp.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        
        //get data from grid on click
        private void load_data_fromGrid(DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.grdSEARCH.Rows[e.RowIndex];
                    region_id = row.Cells[0].Value.ToString();
                    is_edit = 1;
                    txtREGION.Text = row.Cells[1].Value.ToString();
                    txtREGION.Focus();
                }
            }
            catch (Exception ex) { cls_fhp.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void frmAddGroupAccounts_Load(object sender, EventArgs e)
        {
            try
            {
                cls_fhp.load_region_grid(grdSEARCH);
                //Classes.Helper.userId = 1;
            }
            catch (Exception ex) { cls_fhp.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void txtSEARCH_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cls_fhp.region_grid_search(txtSEARCH, grdSEARCH);
            }
            catch (Exception ex) { cls_fhp.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {
            try
            {
                if (is_edit == 0)
                {
                    if (cls_fhp.check_name_exists(grdSEARCH, txtREGION.Text,1) == 1)
                    {
                        cls_fhp.ShowMessageBox("Region name already exists in your record.", "Warning");
                        return;
                    }
                }

                if (txtREGION.Text.Trim().Equals(""))
                {
                    cls_fhp.ShowMessageBox("Group name field is blank.", "Warning");
                    txtREGION.Focus();
                }
                else
                {
                    cls_fhp.query = "IF EXISTS (select REGION_ID from REGION WHERE REGION_ID = '" + region_id + "') UPDATE REGION SET REGION_NAME = '" + cls_fhp.AvoidInjection(txtREGION.Text) + "', MODIFICATION_DATE = GETDATE(), MODIFIED_BY = '1' WHERE REGION_ID = '" + region_id + "' ELSE INSERT INTO REGION VALUES('" + cls_fhp.AvoidInjection(txtREGION.Text) + "',GETDATE(),'1',NULL,'00','1')";
                    if (cls_fhp.save_group(cls_fhp.query) >= 1)
                    {
                        cls_fhp.ShowMessageBox("Record Saved Sucessfully.", "Information");
                        clear();
                        cls_fhp.load_region_grid(grdSEARCH);
                    }
                }
            }
            catch (Exception ex) { cls_fhp.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void grdSEARCH_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            grdSEARCH.Columns[0].Visible = false;
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
    }
}
