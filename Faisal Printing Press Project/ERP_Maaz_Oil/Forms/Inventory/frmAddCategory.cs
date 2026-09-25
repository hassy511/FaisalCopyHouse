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
    public partial class frmAddCategory : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        int id = 0;
        int is_edit = 0;

        public frmAddCategory()
        {
            InitializeComponent();
        }
        //============loading grid query--------------------->
        string query = @"SELECT P_CATEGORY_ID,P_CATEEGORY_NAME as [BRAND NAME] from PRODUCT_CATEGORY"; 
        
        //clear fields in form
        private void clear() {
            txtSEARCH.Clear();
            id = 0;
            txtBrand.Clear();
            is_edit = 0;
            classHelper.LoadGrid(grdSEARCH, query);
        }


        //get data from grid on click
        private void load_data_fromGrid(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.grdSEARCH.Rows[e.RowIndex];
                id = Convert.ToInt32(row.Cells["P_CATEGORY_ID"].Value.ToString());
                is_edit = 1;
                txtBrand.Text = row.Cells["BRAND NAME"].Value.ToString();
            }
        }

        private void frm_AddGroupAccounts_Load(object sender, EventArgs e)
        {
            classHelper.LoadGrid(grdSEARCH, query);
        }

        private void txtSEARCH_TextChanged(object sender, EventArgs e)
        {
           classHelper.Brand_search(txtSEARCH, grdSEARCH);
        }

        private void Delete()
        {
            if (classHelper.CheckBrandRecordsExists(id))
            {
                classHelper.ShowMessageBox("You cannot delete this brand, production or sales record exists against this brand.", "Information");
            }
            else {
                classHelper.query = @" BEGIN TRY 
                             BEGIN TRANSACTION ";

                classHelper.query += @" DELETE FROM PRODUCT_MASTER WHERE BRAND_ID = '" + id + @"';
                DELETE FROM PRODUCT_CATEGORY WHERE P_CATEGORY_ID = '" + id + @"';";

                classHelper.query += @" COMMIT TRANSACTION 
                        END TRY 
                    BEGIN CATCH 
                            IF @@TRANCOUNT > 0 
                            ROLLBACK TRANSACTION 
                    END CATCH";

                if (classHelper.InsertUpdateDelete(classHelper.query) >= 1)
                {
                    classHelper.ShowMessageBox("Record Deleted Sucessfully.", "Information");
                    clear();
                }
            }
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {

            if (is_edit == 0)
            {
                if (classHelper.CheckNameExists(grdSEARCH, txtBrand.Text.Trim(), 1) == 1)
                {
                    classHelper.ShowMessageBox("Brand Name Already Exists.", "Warning");
                    txtBrand.Focus();
                    return;
                }
            }
            if (txtBrand.Text.Trim().Equals(""))
            {
                classHelper.ShowMessageBox("Brand Name Field is Empty!", "Warning");
                txtBrand.Focus();
            }
            else {
                classHelper.query = "BEGIN TRAN ";
                classHelper.query += @"IF EXISTS (select P_CATEGORY_ID from PRODUCT_CATEGORY WHERE P_CATEGORY_ID ='" + id+ "') UPDATE PRODUCT_CATEGORY SET P_CATEEGORY_NAME = '" + txtBrand.Text+
                    "',MODIFICATION_DATE = GETDATE(), MODIFIED_BY = '" 
                    + Classes.Helper.userId 
                    + "' WHERE P_CATEGORY_ID = '" + id+ "' ELSE INSERT INTO PRODUCT_CATEGORY VALUES('" + txtBrand.Text+"',0,'"+Classes.Helper.userId+"',GETDATE(),NULL,NULL,1); ";
                classHelper.query += "COMMIT TRAN";
                if (classHelper.InsertUpdateDelete(classHelper.query) >= 1) {
                    classHelper.ShowMessageBox("Record Saved Sucessfully.", "Information");
                    clear();
                }

            }
        }
        
        private void grdSEARCH_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            grdSEARCH.Columns["P_CATEGORY_ID"].Visible = false;
        }

        private void btnCLEAR_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void grdSEARCH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           load_data_fromGrid(e); 
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (id > 0)
            {
                Delete();
            }
            else
            {
                MessageBox.Show("Please Select any brand to delete.", "Error");
            }
        }
    }
}

