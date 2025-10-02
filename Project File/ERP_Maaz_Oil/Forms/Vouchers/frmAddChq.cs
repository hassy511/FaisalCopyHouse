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
    public partial class frmAddChq : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        string id = "";
        int is_edit = 0;

        public frmAddChq()
        {
            InitializeComponent();
        }
        //============loading grid query--------------------->
        string query = @"select A.CHQ_BOOK_ID , A.COA_ID,A.BOOK_NUMBER,
                        A.NUMBER_OF_CHQS,A.STAT, B.COA_NAME 
                        from CHQ_BOOKS A, COA B where A.COA_ID=B.COA_ID";



        //load Broker

        private void load_Acc()
        {
            try
            {
                classHelper.query = "SELECT '0' AS [id], '--SELECT BANK ACCOUNT--' AS [name] UNION SELECT COA_ID AS [id],COA_NAME AS [name] FROM COA WHERE CA_ID = 5";
                classHelper.LoadComboData(cmbBA, classHelper.query);
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
        }
        

        //clear fields in form
        private void clear() {
            txtSEARCH.Clear();
            id = "";
            cmbBA.SelectedIndex = 0;
            txtSP.Clear();
            txtCHQ.Clear();
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
                cmbBA.Text = row.Cells[5].Value.ToString();
                txtCHQ.Text = row.Cells[3].Value.ToString();
                txtSP.Text = row.Cells[2].Value.ToString();
                

                if (row.Cells[4].Value.ToString().Equals("0"))
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
           
            load_Acc();
            
        }

        private void txtSEARCH_TextChanged(object sender, EventArgs e)
        {
           classHelper.CHQ_grid_search(txtSEARCH, grdSEARCH);
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {

            if (cmbBA.SelectedIndex == 0)
            {
                classHelper.ShowMessageBox("Account is not selected, please select Account.", "Warning");
                cmbBA.Focus();
            }
            else if (txtSP.Text.Trim().Equals(""))
            {
                classHelper.ShowMessageBox("Slip # field is blank.", "Warning");
                txtSP.Focus();
            }
            else if (txtCHQ.Text.Trim().Equals(""))
            {
                classHelper.ShowMessageBox("CHQ field is blank.", "Warning");
                txtCHQ.Focus();
            }

            else {
                int status = 0;
                if (chkDeActive.Checked == true)
                {
                    status = 1;
                }
                classHelper.query = @"IF EXISTS (select CHQ_BOOK_ID from CHQ_BOOKS WHERE CHQ_BOOK_ID ='" + id+
                    "') UPDATE CHQ_BOOK_ID SET COA_ID = '" + cmbBA.SelectedValue.ToString()+ "',BOOK_NUMBER = '" + txtSP.Text +
                    "',NUMBER_OF_CHQS = '" + txtCHQ.Text +
                    "',STAT = '" + status + "',MODIFICATION_DATE = '" 
                    + DateTime.Now + "', MODIFIED_BY = '" + Classes.Helper.userId 
                    + "' WHERE CHQ_BOOK_ID = '" + id+ "' ELSE INSERT INTO CHQ_BOOKS VALUES('" + cmbBA.SelectedValue.ToString()+"','"
                    +txtSP.Text+
                    "','"+txtCHQ.Text+"','"+status+
                    "',GETDATE(), 1,NULL,0,1) DECLARE @NO INT SET @NO = 0 WHILE(@NO < BOOK_NUMBER)  BEGIN INSERT INTO CHQ_BOOKS_SLIPS VALUES((SELECT MAX(CHQ_BOOK_ID) FROM CHQ_BOOKS),101 + @NO,1,GETDATE(),1,NULL,NULL,1) SET @NO += 1 END ";

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

