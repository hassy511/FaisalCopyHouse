using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ERP_Maaz_Oil.Forms
{
    public partial class frmAddCity : Form
    {
        Classes.Helper cls_fhp = new Classes.Helper();
        int is_edit = 0;
        public frmAddCity()
        {
            InitializeComponent();
        }

        private void load_region() {
            try
            {
                cls_fhp.query = "select 0 as [id],'--SELECT PROVINCE--' as [name] UNION select REGION_ID as [id],REGION_NAME as [name] from REGION ORDER BY NAME";
                cls_fhp.LoadComboData(cmbREGION, cls_fhp.query);
            }
            catch (Exception ex) { cls_fhp.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        //clear all fields
        private void clear() {
            try
            {
                cls_fhp.clear(txtSEARCH, txtNAME, lblID, cmbREGION);
                cmbREGION.Focus();
            }
            catch (Exception ex) { cls_fhp.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        //save record
        private void save() {
            try
            {
                txtSEARCH.Text = "";
                int check_name = 0;
                if (is_edit == 0)
                {
                    if (cls_fhp.check_CityName_exists(grdSEARCH, txtNAME.Text) == 1)
                    {
                        cls_fhp.ShowMessageBox("Name already exists in your record.", "Warning");
                        check_name = 1;
                    }
                }
                if (txtNAME.Text.Equals(""))
                {
                    cls_fhp.ShowMessageBox("City Name field is blank.", "Warning");
                    txtNAME.Focus();
                }
                else if (cmbREGION.SelectedIndex == 0)
                {
                    cls_fhp.ShowMessageBox("Please Select Region.", "Warning");
                    cmbREGION.Focus();
                }
                else
                {
                    if (check_name == 0)
                    {
                        cls_fhp.query = "IF EXISTS (select CITY_ID from CITY WHERE CITY_ID = '" + lblID.Text + "') UPDATE CITY SET CITY_NAME = '" + cls_fhp.AvoidInjection(txtNAME.Text) + "', MODIFICATION_DATE = GETDATE(), MODIFIED_BY = '" + Classes.Helper.userId.ToString() + "',REG_ID = '" + cmbREGION.SelectedValue.ToString() + "' WHERE CITY_ID = '" + lblID.Text + "' ELSE INSERT INTO CITY VALUES('" + cls_fhp.AvoidInjection(txtNAME.Text) + "',GETDATE(),'" + Classes.Helper.userId.ToString() + "',NULL,NULL,'" + cmbREGION.SelectedValue.ToString() + "','1')";

                    }
                    int i = cls_fhp.InsertUpdateDelete(cls_fhp.query);
                    if (i >= 1)
                    {
                        cls_fhp.ShowMessageBox("Record Saved Sucessfully", "Information");
                        clear();
                        cls_fhp.load_city_grid(grdSEARCH);
                    }
                }
            }
            catch (Exception ex) { cls_fhp.ShowMessageBox(ex.ToString(), "Exception"); }
        }


        private void grdSEARCH_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            grdSEARCH.Columns[0].Visible = false;
            grdSEARCH.Columns[2].Visible = false;
        }

        private void txtSEARCH_TextChanged(object sender, EventArgs e)
        {
            try
            {
                (grdSEARCH.DataSource as DataTable).DefaultView.RowFilter = string.Format("" + grdSEARCH.Columns[1].Name.ToString() + " LIKE '%" + cls_fhp.AvoidInjection(txtSEARCH.Text) + "%' OR ["
                 + grdSEARCH.Columns[3].Name.ToString() + "] LIKE '%" + cls_fhp.AvoidInjection(txtSEARCH.Text) + "%'");
            }
            catch (Exception ex) { cls_fhp.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void grdSEARCH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.grdSEARCH.Rows[e.RowIndex];
                    cmbREGION.SelectedValue = row.Cells[0].Value.ToString();
                    lblID.Text = row.Cells[2].Value.ToString();
                    txtNAME.Text = row.Cells[3].Value.ToString();
                    is_edit = 1;
                    cmbREGION.Focus();
                }
            }
            catch (Exception ex) { cls_fhp.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void btnCLEAR_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {
            save();
            cmbREGION.Focus();
        }

        private void frm_Add_Data_Load(object sender, EventArgs e)
        {
            try
            {
                cls_fhp.load_city_grid(grdSEARCH);
                load_region();
                clear();
            }
            catch (Exception ex) { cls_fhp.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void grdSEARCH_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void grdSEARCH_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            cls_fhp.GridRowPostPaint(e, grdSEARCH);
        }

        private void txtNAME_Leave(object sender, EventArgs e)
        {
           
        }

        private void btn_R_ADD_INCIDENT_Click(object sender, EventArgs e)
        {
            try
            {
                using (cls_fhp.frmAddRegion = new frmAddRegion())
                {
                    if (cls_fhp.frmAddRegion.ShowDialog() == System.Windows.Forms.DialogResult.Cancel || cls_fhp.frmAddRegion.ShowDialog() == System.Windows.Forms.DialogResult.Abort)
                    {
                        load_region();
                    }
                }
            }
            catch (Exception ex) { cls_fhp.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void txtNAME_MouseClick(object sender, MouseEventArgs e)
        {
            cls_fhp.select_all_text(sender as TextBox);
        }

        private void txtNAME_Enter(object sender, EventArgs e)
        {
            cls_fhp.select_all_text(sender as TextBox);
        }

        private void cmbRINCIDENT_TextUpdate(object sender, EventArgs e)
        {
            cls_fhp.CmbTextUpdate(sender as ComboBox);
        }

        private void cmbRINCIDENT_DropDown(object sender, EventArgs e)
        {
            try
            {
                ComboBox cbo = (ComboBox)sender;
                cbo.PreviewKeyDown += new PreviewKeyDownEventHandler(cmbRINCIDENT_PreviewKeyDown);
            }
            catch (Exception ex) { cls_fhp.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void cmbRINCIDENT_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                ComboBox cbo = (ComboBox)sender;
                cbo.PreviewKeyDown -= cmbRINCIDENT_PreviewKeyDown;
                if (cbo.DroppedDown) cbo.Focus();
            }
            catch (Exception ex) { cls_fhp.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void cmbREGION_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
