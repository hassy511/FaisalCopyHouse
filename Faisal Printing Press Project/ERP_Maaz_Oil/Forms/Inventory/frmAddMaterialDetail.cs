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
    public partial class frmAddMaterialDetail : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        int materialId = 0;
        public frmAddMaterialDetail(int materialId)
        {
            InitializeComponent();
            this.materialId = materialId;
        }

        private void LoadData()
        {
            try
            {
                classHelper.query = @"SELECT A.PRODUCT_CODE, A.PRODUCT_NAME 
                FROM PRODUCT_MASTER A
                INNER JOIN PRODUCT_DETAILS B ON A.PM_ID = B.PM_ID
                WHERE B.MATERIAL_ID  = '"+this.materialId+@"'
                GROUP BY A.PRODUCT_CODE,A.PRODUCT_NAME
                ORDER BY A.PRODUCT_NAME";
                classHelper.LoadGrid(grdSEARCH, classHelper.query);
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void frm_AddGroupAccounts_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void grdSEARCH_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //grdSEARCH.Columns[0].Visible = false;

        }

        private void grdSEARCH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

    }
}

