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
    public partial class frmAddServiceTypes : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        int id = 0;

        public frmAddServiceTypes()
        {
            InitializeComponent();
        }

        private void LoadGrid() {
            classHelper.query = @" SELECT ID,SERVICE_TYPE AS [SERVICE TYPE] FROM SERVICE_TYPES";
            classHelper.LoadGrid(grdSearch, classHelper.query);
        }
        
        private void Clear() {
            txtSearch.Clear();
            id = 0;
            txtServiceType.Clear();
            LoadGrid();
        }

        private void LoadDataFromGrid(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.grdSearch.Rows[e.RowIndex];
                id = Convert.ToInt32(row.Cells["ID"].Value.ToString());
                txtServiceType.Text = row.Cells["SERVICE TYPE"].Value.ToString();
            }
        }

        private void frm_AddGroupAccounts_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void txtSEARCH_TextChanged(object sender, EventArgs e)
        {
            (grdSearch.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
            [" + grdSearch.Columns["SERVICE TYPE"].Name.ToString() + "] LIKE '%" + classHelper.AvoidInjection(txtSearch.Text) + "%'");
            grdSearch.ClearSelection();
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {

            if (id == 0)
            {
                if (classHelper.CheckNameExists(grdSearch, txtServiceType.Text.Trim(), 1) == 1)
                {
                    classHelper.ShowMessageBox("Service Type Already Exists.", "Warning");
                    txtServiceType.Focus();
                    return;
                }
            }
            if (txtServiceType.Text.Trim().Equals(""))
            {
                classHelper.ShowMessageBox("Service Type Field is Empty!", "Warning");
                txtServiceType.Focus();
            }
            else {
                classHelper.query = "BEGIN TRAN ";
                classHelper.query += @"IF EXISTS (SELECT ID FROM SERVICE_TYPES WHERE ID ='" + id+ "') UPDATE SERVICE_TYPES SET SERVICE_TYPE = '" + txtServiceType.Text+
                    "',MODIFICATION_DATE = GETDATE(), MODIFIED_BY = '" 
                    + Classes.Helper.userId 
                    + "' WHERE ID = '" + id+ "' ELSE INSERT INTO SERVICE_TYPES VALUES('" + txtServiceType.Text+"','"+Classes.Helper.userId+"',GETDATE(),NULL,NULL); ";
                classHelper.query += "COMMIT TRAN";
                if (classHelper.InsertUpdateDelete(classHelper.query) >= 1) {
                    classHelper.ShowMessageBox("Record Saved Sucessfully.", "Information");
                    Clear();
                }

            }
        }
        
        private void grdSEARCH_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            grdSearch.Columns["ID"].Visible = false;
        }

        private void btnCLEAR_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void grdSEARCH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           LoadDataFromGrid(e); 
        }
    }
}

