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
    public partial class frmAddVehicles : Form
    {
        Classes.Helper cls_fhp = new Classes.Helper();

        string vehicle_id = "";
        int is_edit = 0;

        public frmAddVehicles()
        {
            InitializeComponent();
        }

        //clear fields in form
        private void clear()
        {
            try
            {
                txtSEARCH.Clear();
                txtVehicleNumber.Clear();
                vehicle_id = "";
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
                    vehicle_id = row.Cells[0].Value.ToString();
                    is_edit = 1;
                    txtVehicleNumber.Text = row.Cells[1].Value.ToString();
                    txtVehicleNumber.Focus();
                }
            }
            catch (Exception ex) { cls_fhp.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void frmAddGroupAccounts_Load(object sender, EventArgs e)
        {
            try
            {
                cls_fhp.LoadVehiclesGrid(grdSEARCH);
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
                    if (cls_fhp.check_name_exists(grdSEARCH, txtVehicleNumber.Text,1) == 1)
                    {
                        cls_fhp.ShowMessageBox("Vehicle number already exists in your record.", "Warning");
                        return;
                    }
                }

                if (txtVehicleNumber.Text.Trim().Equals(""))
                {
                    cls_fhp.ShowMessageBox("Vehicle Number field is blank.", "Warning");
                    txtVehicleNumber.Focus();
                }
                else
                {
                    cls_fhp.query = @"IF EXISTS (select veh_ID from vehicles WHERE veh_ID = '" + vehicle_id + "') UPDATE vehicles SET veh_number = '" + cls_fhp.AvoidInjection(txtVehicleNumber.Text) + "', MODIFICATION_DATE = GETDATE(), MODIFIED_BY = '"+Classes.Helper.userId+"' WHERE veh_ID = '" + vehicle_id + "' ELSE INSERT INTO vehicles VALUES('" + cls_fhp.AvoidInjection(txtVehicleNumber.Text) + "',GETDATE(),'"+ Classes.Helper.userId + "',NULL,NULL)";
                    if (cls_fhp.save_group(cls_fhp.query) >= 1)
                    {
                        cls_fhp.ShowMessageBox("Record Saved Sucessfully.", "Information");
                        clear();
                        cls_fhp.LoadVehiclesGrid(grdSEARCH);
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
