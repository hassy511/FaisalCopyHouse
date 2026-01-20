using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ERP_Maaz_Oil.Forms
{
    public partial class frmAddMaterial : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        string id = "";
        int is_edit = 0;

        public frmAddMaterial()
        {
            InitializeComponent();
        }
        //============loading grid query--------------------->
        string query = @"	SELECT A.MATERIAL_ID,A.M_TYPE_ID,C.M_TYPE_NAME AS [MATERIAL TYPE],A.UNIT_ID,D.UNIT_NAME AS [UNIT],
        A.MATERIAL_CODE AS [CODE],A.MATERIAL_NAME AS [NAME],A.OPENING_QTY AS [QTY],
        A.OPENING_RATE AS [RATE],A.HEIGHT,A.WIDTH,A.STAT,A.GRAMMAGE
        FROM MATERIALS A,MATERIAL_TYPES C,UNITS D
        WHERE A.UNIT_ID = D.UNIT_ID AND A.M_TYPE_ID=C.M_TYPE_ID";
        //load COMBO BOXES

        private void load_MATERIAL_Type()
        {
            try
            {
                classHelper.query = @"SELECT '0' AS [id], '--SELECT MATERIAL TYPE--' AS [name] 
                UNION
                SELECT M_TYPE_ID,M_TYPE_NAME FROM MATERIAL_TYPES WHERE STAT = 0";
                classHelper.LoadEasyComboData(cmbMaterialType, classHelper.query);
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
        }
        private void load_Location()
        {
            try
            {
                classHelper.query = "SELECT '0' AS [id], '--SELECT LOCATION--' AS [name] UNION SELECT LOCATION_ID AS [id],LOCATION_NAME AS [name] FROM LOCATION ";
                //classHelper.LoadComboData(cmbLocation, classHelper.query);
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void load_Unit()
        {
            try
            {
                classHelper.query = "SELECT '0' AS [id], '--SELECT UNIT--' AS [name] UNION SELECT UNIT_ID AS [id],UNIT_NAME AS [name] FROM UNITS where STAT = 0";
                classHelper.LoadComboData(cmbUnit, classHelper.query);
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        //clear fields in form
        private void clear()
        {
            //cmbLocation.SelectedIndex = 0;
            cmbMaterialType.SelectedIndex = 0;
            cmbUnit.SelectedIndex = 0;
            txtSearch.Clear();
            id = "";
            txtMaterialCode.Clear();
            txtMaterialName.Clear();
            txtOpeningQty.Text = "0";
            txtOpeningRate.Text = "0";
            txtHeight.Text = "0";
            txtWidth.Text = "0";
            txtGrammage.Clear();
            is_edit = 0;
            chkDeActive.Checked = false;
            classHelper.LoadGrid(grdSearch, query);
        }

        private void Save()
        {
            if (cmbMaterialType.SelectedIndex == 0)
            {
                classHelper.ShowMessageBox("Material  is not selected, please select MATERAL.", "Warning");
                cmbMaterialType.Focus();
            }
            else if (cmbUnit.SelectedIndex == 0)
            {
                classHelper.ShowMessageBox("UNIT  is not selected, please select UNIT.", "Warning");
                cmbUnit.Focus();
            }
            else if (txtMaterialCode.Text.Trim().Equals(""))
            {
                classHelper.ShowMessageBox("Material Code field is blank.", "Warning");
                txtMaterialCode.Focus();
            }
            else if (txtMaterialName.Text.Trim().Equals(""))
            {
                classHelper.ShowMessageBox("Material Name  field is blank.", "Warning");
                txtMaterialName.Focus();
            }
            else if (txtHeight.Text.Trim().Equals(""))
            {
                classHelper.ShowMessageBox("Height field is blank.", "Warning");
                txtHeight.Focus();
            }
            else if (txtOpeningQty.Text.Trim().Equals(""))
            {
                classHelper.ShowMessageBox("Material QTY field is blank.", "Warning");
                txtOpeningQty.Focus();
            }
            else if (txtOpeningRate.Text.Trim().Equals(""))
            {
                classHelper.ShowMessageBox("Material RATE field is blank.", "Warning");
                txtOpeningRate.Focus();
            }
            else if (txtGrammage.Text.Trim().Equals(""))
            {
                classHelper.ShowMessageBox("Minimum Qty field is blank.", "Warning");
                txtGrammage.Focus();
            }
            else if (txtWidth.Text.Trim().Equals(""))
            {
                classHelper.ShowMessageBox("Width field is blank.", "Warning");
                txtWidth.Focus();
            }
            else
            {
                string masterId = id;
                if (id.Equals(""))
                {
                    masterId = "(SELECT MAX(MATERIAL_ID) FROM MATERIALS)";
                }

                int status = 0;
                if (chkDeActive.Checked == true)
                {
                    status = 1;
                }
                classHelper.query = @"BEGIN TRY 
                             BEGIN TRANSACTION ";

                classHelper.query += @"IF EXISTS (select MATERIAL_ID from MATERIALS WHERE MATERIAL_ID ='" + id +@"') 
                UPDATE MATERIALS SET M_TYPE_ID = '" + cmbMaterialType.SelectedValue.ToString() +@"',LOCATION_ID = '1',
                UNIT_ID = '" + cmbUnit.SelectedValue.ToString() +"',MATERIAL_CODE = '" + txtMaterialCode.Text + @"',
                MATERIAL_NAME = '" + txtMaterialName.Text +@"',OPENING_QTY = '" + txtOpeningQty.Text + "',OPENING_RATE = '" + txtOpeningRate.Text +@"',
                HEIGHT = '" + txtHeight.Text + "',WIDTH = '" + txtWidth.Text + "',STAT = '" + status + @"',
                GRAMMAGE = '" + txtGrammage.Text + "',MODIFICATION_DATE = '" + DateTime.Now +@"', 
                MODIFIED_BY = '" + Classes.Helper.userId + "' WHERE MATERIAL_ID = '" + id + @"' ELSE 
                INSERT INTO MATERIALS (M_TYPE_ID,MATERIAL_CODE,MATERIAL_NAME,UNIT_ID,OPENING_QTY,OPENING_RATE,STAT,
                CREATED_BY,CREATION_DATE,COMPANY_ID,HEIGHT,WIDTH,GRAMMAGE) 
                VALUES('" + cmbMaterialType.SelectedValue.ToString() +"', '" + txtMaterialCode.Text + @"',
                '"+ txtMaterialName.Text + "', '"+ cmbUnit.SelectedValue.ToString() + "', '"+ txtOpeningQty.Text + @"',
                '" + txtOpeningRate.Text+ "', '" + status + "', '" + Classes.Helper.userId + @"', GETDATE(), 1,
                '" + txtHeight.Text + "', '" + txtWidth.Text + @"', '" + txtGrammage.Text + @"'); ";

                classHelper.query += @" DELETE FROM MATERIAL_ITEM_LEDGER WHERE REF_NO = '00' AND MATERIAL_ID = " + masterId + @" AND ENTRY_FROM = 'ADD MATERIAL OPENING';
                    INSERT INTO MATERIAL_ITEM_LEDGER 
                    ([DATE],MATERIAL_ID,REF_NO,ENTRY_FROM,STOCK_IN,STOCK_OUT,COST_AMT,SALE_AMT,L_ID,CREATED_BY,CREATION_DATE,COMPANY_ID)
                    VALUES('01-07-2020'," + masterId + ",'00','ADD MATERIAL OPENING','" + classHelper.AvoidInjection(txtOpeningQty.Text) + @"',
                    '0','" + classHelper.AvoidInjection(txtOpeningRate.Text) + "','0','1','" + Classes.Helper.userId + "',GETDATE(),'1');";

                classHelper.query += @" COMMIT TRANSACTION 
                        END TRY 
                    BEGIN CATCH 
                            IF @@TRANCOUNT > 0 
                            ROLLBACK TRANSACTION 
                    END CATCH";

                if (classHelper.InsertUpdateDelete(classHelper.query) >= 1)
                {
                    classHelper.ShowMessageBox("Record Saved Sucessfully.", "Information");
                    clear();
                    classHelper.LoadGrid(grdSearch, query);
                }

            }
        }

        //get material product list from grid on double click
        private void LoadMaterialProducts(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.grdSearch.Rows[e.RowIndex];
                frmAddMaterialDetail frm = new frmAddMaterialDetail(Convert.ToInt32(row.Cells[0].Value.ToString()));
                frm.Show();
            }
        }

        //get data from grid on click
        private void load_data_fromGrid(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.grdSearch.Rows[e.RowIndex];
                id = row.Cells[0].Value.ToString();
                is_edit = 1;
                cmbMaterialType.SelectedValue = row.Cells["M_TYPE_ID"].Value.ToString();
                cmbUnit.SelectedValue = row.Cells["UNIT_ID"].Value.ToString();
                txtMaterialCode.Text = row.Cells["CODE"].Value.ToString();
                txtMaterialName.Text = row.Cells["NAME"].Value.ToString();
                txtOpeningQty.Text = row.Cells["QTY"].Value.ToString();
                txtOpeningRate.Text = row.Cells["RATE"].Value.ToString();
                txtHeight.Text = row.Cells["HEIGHT"].Value.ToString();
                txtWidth.Text = row.Cells["WIDTH"].Value.ToString();
                txtGrammage.Text = row.Cells["GRAMMAGE"].Value.ToString();
                if (row.Cells["STAT"].Value.ToString().Equals("0"))
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
            classHelper.LoadGrid(grdSearch, query);
            load_MATERIAL_Type();
            load_Location();
            load_Unit();
            //cmbUnit.SelectedValue = 1;

        }

        private void txtSEARCH_TextChanged(object sender, EventArgs e)
        {
            classHelper.Material_search(txtSearch, grdSearch);
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void cmbPACCOUNT_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void grdSEARCH_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            grdSearch.Columns["MATERIAL_ID"].Visible = false;
            grdSearch.Columns["M_TYPE_ID"].Visible = false;
            grdSearch.Columns["UNIT_ID"].Visible = false;
            grdSearch.Columns["STAT"].Visible = false;

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
            classHelper.select_all_text(sender as TextBox);
        }

        private void txtPHONE_Enter(object sender, EventArgs e)
        {
            classHelper.select_all_text(sender as TextBox);
        }

        private void txtPHONE_Leave(object sender, EventArgs e)
        {

        }

        private void cmbVENDOR_TextUpdate(object sender, EventArgs e)
        {
            classHelper.CmbTextUpdate(sender as ComboBox);
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
            classHelper.AllowNumbers(e);
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtQTY_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                classHelper.AllowNumbers(e);
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private int DeleteMaterial(int materialId)
        {
            int value = 0;
            classHelper.query = @"SELECT DBO.[DeleteMaterial](" + materialId + ")  as [value];";

            try
            {
                if (Classes.Helper.conn.State == System.Data.ConnectionState.Closed) { Classes.Helper.conn.Open(); }
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.cmd.CommandTimeout = 0;
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    if (classHelper.dr.Read())
                    {
                        if (classHelper.dr["value"].ToString().Equals("True"))
                        {
                            value = 1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                classHelper.ShowMessageBox(ex.Message, "Exception");
            }
            finally
            {
                Classes.Helper.conn.Close();
            }

            return value;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (id.Equals(""))
            {
                MessageBox.Show("Please Select Material!", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (DeleteMaterial(Convert.ToInt32(id)) == 0)
                {
                    classHelper.query = @" delete from MATERIALS where MATERIAL_ID = '" + id + @"'";
                    if (classHelper.InsertUpdateDelete(classHelper.query) > 0)
                    {
                        MessageBox.Show("Material Deleted Sucessfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clear();
                    }
                }
                else
                {
                    MessageBox.Show("Material Cannot Delete, It is in use.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clear();
                }
            }
        }

        private void grdSearch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadMaterialProducts(e);
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void txtOpeningRate_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}

