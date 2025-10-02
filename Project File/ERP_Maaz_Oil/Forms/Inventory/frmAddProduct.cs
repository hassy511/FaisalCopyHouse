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
    public partial class frmAddProduct : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        string id = "";
        int is_edit = 0;

        public frmAddProduct()
        {
            InitializeComponent();
        }
        //============loading grid query--------------------->
        string query = @"SELECT A.PRODUCT_ID,A.M_CATEGORY_ID,
			A.LOCATION_ID, CONVERT(varchar(50), A.PRODUCT_CODE)as PRODUCT_CODE ,
			A.PRODUCT_NAME
			,A.UNIT_ID,CONVERT(varchar(50), A.OPENING_QTY )as OPENING_QTY,
			CONVERT(varchar(50), A.OPENING_RATE )as OPENING_RATE ,A.STAT,
			B.LOCATION_NAME,
			C.P_CATEEGORY_NAME,d.UNIT_NAME,CONVERT(varchar(50), A.APPLY_SALE_RATE )as APPLY_SALE_RATE,
            CONVERT(varchar(50), A.MIN_QTY )as MIN_QTY,CONVERT(varchar(50), A.MAX_QTY )as MAX_QTY,CONVERT(varchar(50), A.SELLING_RATE )as SELLING_RATE
			FROM PRODUCTS A, LOCATION B 
			,PRODUCT_CATEGORY C,UNITS d
           WHERE A.UNIT_ID = d.UNIT_ID 
		   and A.LOCATION_ID=B.LOCATION_ID  and A.M_CATEGORY_ID=C.P_CATEGORY_ID 
";
                    //load COMBO BOXES
                     
             


        private void load_Product()
        {
            try
            {
                classHelper.query = "SELECT '0' AS [id], '--SELECT PRODUCT CATEGORY--' AS [name] UNION SELECT P_CATEGORY_ID,P_CATEEGORY_NAME FROM PRODUCT_CATEGORY WHERE STAT = 1";
                classHelper.LoadComboData(cmbPRODUCT, classHelper.query);
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
                classHelper.query = "SELECT '0' AS [id], '--SELECT UNIT--' AS [name] UNION SELECT UNIT_ID AS [id],UNIT_NAME AS [name] FROM UNITS";
                classHelper.LoadComboData(cmbUnit, classHelper.query);
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        //clear fields in form
        private void clear() {
            //cmbLocation.SelectedIndex = 0;
            cmbPRODUCT.SelectedIndex = 0;
            cmbUnit.SelectedIndex = 0;
            txtSEARCH.Clear();
            id = "";
            txtCODE.Clear();
            txtNAME.Clear();
            txtQTY.Clear();
            txtRATE.Clear();
            //txtSRATE.Clear();
            //txtMIN.Clear();
            //txtMAX.Clear();
            //txtAPPLY_SALE_RATE.Clear();
            is_edit = 0;
        }


        //get data from grid on click
        private void load_data_fromGrid(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.grdSEARCH.Rows[e.RowIndex];
                id = row.Cells[0].Value.ToString();
                is_edit = 1;
                txtCODE.Text = row.Cells[3].Value.ToString();
                txtNAME.Text = row.Cells[4].Value.ToString();
                txtQTY.Text = row.Cells[6].Value.ToString();
                txtRATE.Text = row.Cells[7].Value.ToString();
                //cmbLocation.Text = row.Cells[9].Value.ToString();
                cmbUnit.Text = row.Cells[11].Value.ToString();
                cmbPRODUCT.Text = row.Cells[10].Value.ToString();
                //txtSRATE.Text = row.Cells[15].Value.ToString();

                //txtAPPLY_SALE_RATE.Text = row.Cells[12].Value.ToString();

                //txtMIN.Text = row.Cells[13].Value.ToString();

                //txtMAX.Text = row.Cells[14].Value.ToString();
                txtRATE.Text = row.Cells[7].Value.ToString();
                

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
            
            classHelper.LoadGrid(grdSEARCH, query);
           
            load_Product();
            load_Location();
            load_Unit();

        }

        private void txtSEARCH_TextChanged(object sender, EventArgs e)
        {
           classHelper.Material_search(txtSEARCH, grdSEARCH);
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {


            if (cmbPRODUCT.SelectedIndex == 0)
            {
                classHelper.ShowMessageBox("Material  is not selected, please select TAX.", "Warning");
                cmbPRODUCT.Focus();
            }
            else if (cmbUnit.SelectedIndex == 0)
            {
                classHelper.ShowMessageBox("UNIT  is not selected, please select TAX.", "Warning");
                cmbUnit.Focus();
            }

            else if (txtCODE.Text.Trim().Equals(""))
            {
                classHelper.ShowMessageBox("Product Code field is blank.", "Warning");
                txtCODE.Focus();
            }
            else if (txtNAME.Text.Trim().Equals(""))
            {
                classHelper.ShowMessageBox("Product Name  field is blank.", "Warning");
                txtNAME.Focus();
            }


            //else if (cmbLocation.SelectedIndex == 0)
            //{
            //    classHelper.ShowMessageBox("Location  is not selected, please select TAX.", "Warning");
            //    cmbLocation.Focus();
            //}

            else if (txtQTY.Text.Trim().Equals(""))
            {
                classHelper.ShowMessageBox(" QTY field is blank.", "Warning");
                txtQTY.Focus();
            }
            else if (txtRATE.Text.Trim().Equals(""))
            {
                classHelper.ShowMessageBox(" RATE field is blank.", "Warning");
                txtRATE.Focus();
            }
            //else if (txtSRATE.Text.Trim().Equals(""))
            //{
            //    classHelper.ShowMessageBox(" Selling RATE field is blank.", "Warning");
            //    txtSRATE.Focus();
            //}
            //else if (txtAPPLY_SALE_RATE.Text.Trim().Equals(""))
            //{
            //    classHelper.ShowMessageBox("APPLY SALE RATE field is blank.", "Warning");
            //    txtAPPLY_SALE_RATE.Focus();
            //}

            //else if (txtMIN.Text.Trim().Equals(""))
            //{
            //    classHelper.ShowMessageBox(" MIN QTY field is blank.", "Warning");
            //    txtMIN.Focus();
            //}
            
            //else if (txtMAX.Text.Trim().Equals(""))
            //{
            //    classHelper.ShowMessageBox(" MAX QTY field is blank.", "Warning");
            //    txtMAX.Focus();
            //}
            


            else
            {
                int status = 0;
                if (chkDeActive.Checked == true)
                {
                    status = 1;
                }
                classHelper.query = @"IF EXISTS (select PRODUCT_ID from PRODUCTS WHERE PRODUCT_ID ='" + id + 
                    "') UPDATE PRODUCTS SET M_CATEGORY_ID = '" +cmbPRODUCT.SelectedValue.ToString()+

                    "',LOCATION_ID = '',UNIT_ID = '" +cmbUnit.SelectedValue.ToString()+
                    "',PRODUCT_CODE = '" +txtCODE.Text+
                    "',PRODUCT_NAME = '" +txtNAME.Text+
                    "',OPENING_QTY = '" +txtQTY.Text+
                    "',OPENING_RATE = '" +txtRATE.Text+
                    "',MIN_QTY = '',MAX_QTY = '',SELLING_RATE = '',STAT = '" + status + 
                    "',MODIFICATION_DATE ='" + DateTime.Now + 
                    "', MODIFIED_BY = '" + Classes.Helper.userId
                    + "' WHERE PRODUCT_ID = '" + id + 
                    "' ELSE INSERT INTO PRODUCTS VALUES('" 
                    + cmbPRODUCT.SelectedValue.ToString() + 
                    "','','" + txtCODE.Text + "','" 
                    + txtNAME.Text + "','" 
                    + cmbUnit.SelectedValue.ToString() + "','" 
                    + txtQTY.Text + "','" + txtRATE.Text 
                    + "','','','','','" + status+"','"
                    + Classes.Helper.userId + "',GETDATE(),NULL,1,1)";
                    
                if (classHelper.InsertUpdateDelete(classHelper.query) >= 1) {
                    classHelper.ShowMessageBox("Record Saved Sucessfully.", "Information");
                    clear();
                    classHelper.LoadGrid(grdSEARCH, query);
                }

            }
        }

        private void cmbPACCOUNT_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void grdSEARCH_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            grdSEARCH.Columns[0].Visible = false;
            grdSEARCH.Columns[1].Visible = false;
            grdSEARCH.Columns[2].Visible = false;
           grdSEARCH.Columns[5].Visible = false;

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
            //if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            //{
            //    e.Handled = true;
            //}
        }
    }
    }

