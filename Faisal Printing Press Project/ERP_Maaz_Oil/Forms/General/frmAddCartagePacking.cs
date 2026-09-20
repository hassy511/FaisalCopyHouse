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
    public partial class frmAddCartagePacking : Form
    {
        Classes.Helper cls_fhp = new Classes.Helper();
        int is_edit = 0;
        public frmAddCartagePacking()
        {
            InitializeComponent();
        }

        //clear all fields
        private void clear() {
            try
            {
                txtSEARCH.Clear();
                txtName.Clear();
                txtRate.Clear();
                lblID.Text = "";
                txtName.Focus();
                cls_fhp.LoadCartagePacking(grdSEARCH);
            }
            catch (Exception ex) { cls_fhp.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        //save record
        private void save() {
            try
            {
                if (is_edit == 0)
                {
                    if (cls_fhp.check_CityName_exists(grdSEARCH, txtRate.Text) == 1)
                    {
                        cls_fhp.ShowMessageBox("Name already exists in your record.", "Warning");
                        txtName.Focus();
                        return;
                    }
                }
                if (txtName.Text.Equals(""))
                {
                    cls_fhp.ShowMessageBox("Name field is blank.", "Warning");
                    txtName.Focus();
                }
                else if (txtRate.Text.Equals(""))
                {
                    cls_fhp.ShowMessageBox("Rate field is blank.", "Warning");
                    txtRate.Focus();
                }
                else
                {
                    cls_fhp.query = "BEGIN TRAN ";
                    cls_fhp.query += @"IF EXISTS (select CP_ID from CARTAGE_PACKING WHERE CP_ID ='" + lblID.Text + @"') 
                    BEGIN                    
                    UPDATE CARTAGE_PACKING SET CP_NAME = '" + cls_fhp.AvoidInjection(txtName.Text) + "',CP_RATE = '" + cls_fhp.AvoidInjection(txtRate.Text) + @"',MODIFICATION_DATE = GETDATE(), 
                    MODIFICATION_ID = '" + Classes.Helper.userId+ "' WHERE CP_ID = '" + lblID.Text + @"' END 
                    ELSE BEGIN
                    INSERT INTO CARTAGE_PACKING (CP_NAME,CP_RATE,CREATED_BY,CREATION_DATE) 
                    VALUES('" + cls_fhp.AvoidInjection(txtName.Text) + "','" + cls_fhp.AvoidInjection(txtRate.Text) + "','" + Classes.Helper.userId + @"',GETDATE()); 
                    END ";
                    cls_fhp.query += "COMMIT TRAN";
                    int i = cls_fhp.InsertUpdateDelete(cls_fhp.query);
                    if (i >= 1)
                    {
                        cls_fhp.ShowMessageBox("Record Saved Sucessfully", "Information");
                        clear();
                    }
                }
            }
            catch (Exception ex) { cls_fhp.ShowMessageBox(ex.ToString(), "Exception"); }
        }


        private void grdSEARCH_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            grdSEARCH.Columns["CP_ID"].Visible = false;
        }

        private void txtSEARCH_TextChanged(object sender, EventArgs e)
        {
            try
            {
                (grdSEARCH.DataSource as DataTable).DefaultView.RowFilter = string.Format("" + grdSEARCH.Columns["CP_NAME"].Name.ToString() + " LIKE '%" + cls_fhp.AvoidInjection(txtSEARCH.Text) + "%'");
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
                    lblID.Text = row.Cells["CP_ID"].Value.ToString();
                    txtName.Text = row.Cells["NAME"].Value.ToString();
                    txtRate.Text = row.Cells["RATE"].Value.ToString();
                    is_edit = 1;
                    txtName.Focus();
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
            txtName.Focus();
        }

        private void frm_Add_Data_Load(object sender, EventArgs e)
        {
            try
            {
                cls_fhp.LoadCartagePacking(grdSEARCH);
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
            TextBox txt = sender as TextBox;
            if (txt.Text.Trim().Equals(""))
            {
                txt.Text = "0";
            }
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

        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            cls_fhp.AllowNumbers(e);
        }
    }
}
