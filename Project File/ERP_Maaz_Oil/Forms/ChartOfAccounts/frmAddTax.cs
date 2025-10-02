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
    public partial class frmAddTax : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        string id = "";
        int is_edit = 0;

        public frmAddTax()
        {
            InitializeComponent();
        }
        //============loading grid query--------------------->
        string query = @"
            SELECT A.TAX_ID,STR(A.TAX_VALUE) as TAX_VALUE,A.COA_ID ,B.COA_NAME,CASE 
                        WHEN A.TAX_TYPE =1  
                        THEN 'Rupess' 
                        ELSE '%' END as TAX_TYPE  
                        ,A.STAT FROM TAXES A, COA B
                          WHERE A.COA_ID = B.COA_ID"; 
        
        //load Broker

        private void load_tax()
        {
            try
            {
                classHelper.query = "SELECT '0' AS [id], '--SELECT TAX ACCOUNT--' AS [name] UNION SELECT COA_ID AS [id],COA_NAME AS [name] FROM COA WHERE CA_ID = 25";
                classHelper.LoadComboData(cmbTAXACC, classHelper.query);
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
        }
        

        //clear fields in form
        private void clear() {
            cmbTAX.SelectedIndex = 0;
            txtSEARCH.Clear();
            id = "";
            txtTAX.Clear();
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
                cmbTAXACC.Text = row.Cells[3].Value.ToString();
                cmbTAX.Text = row.Cells[4].Value.ToString();
                txtTAX.Text = row.Cells[1].Value.ToString();
                

                

                if (row.Cells[3].Value.ToString().Equals("0"))
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
           
            load_tax();
            
        }

        private void txtSEARCH_TextChanged(object sender, EventArgs e)
        {
           classHelper.TAX_search(txtSEARCH, grdSEARCH);
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {


            String cm=(cmbTAX.SelectedIndex+1).ToString();
             if (txtTAX.Text == "")
            {
                classHelper.ShowMessageBox("TAX value is empty, please Enter value.", "Warning");
                txtTAX.Focus();
            }
            else if (cmbTAXACC.SelectedIndex == 0)
            {
                classHelper.ShowMessageBox("TAX is not selected, please select TAX.", "Warning");
                cmbTAXACC.Focus();
            }
              else if (cmbTAX.Text == "--------SELECT TYPE---------")
            {
                classHelper.ShowMessageBox("TAX TYPE is not selected, please select TAX TYPE.", "Warning");
                cmbTAX.Focus();
            }

            else {
                int status = 0;
                if (chkDeActive.Checked == true)
                {
                    status = 1;
                }
                classHelper.query = @"IF EXISTS (select TAX_ID from TAXES WHERE TAX_ID ='" + id+ "') UPDATE TAXES SET TAX_VALUE = '" + txtTAX.Text+ "',TAX_TYPE = '" + cm + 
                    "',STAT = '" + status + "',MODIFICATION_DATE = '" 
                    + DateTime.Now + "', MODIFIED_BY = '" + Classes.Helper.userId 
                    + "' WHERE TAX_ID = '"+id+"' ELSE INSERT INTO TAXES VALUES('"+cmbTAXACC.SelectedValue.ToString()+"','"
                    +txtTAX.Text+
                    "','"+cm+"','"+status+"',GETDATE(), 1,NULL,0,1)";
                    
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

       
    }
    }

