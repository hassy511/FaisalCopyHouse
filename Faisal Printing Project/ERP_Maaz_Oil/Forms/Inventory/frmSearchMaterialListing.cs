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
    public partial class frmSearchMaterialListing : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        string id = "";
        int is_edit = 0;

        public frmSearchMaterialListing()
        {
            InitializeComponent();
        }

        private void LoadMaterials()
        {
            classHelper.LoadRawMaterials(cmbMaterials);
        }

        private void LoadMaterialDetails()
        {
            try
            {
                grdSEARCH.Rows.Clear();
                classHelper.query = @"SELECT FORMAT(A.DATE,'dd-MM-yyyy') AS [DATE],'' AS [REFERENCE],'INVENTORY ADJUSTMENT' AS [USED IN]
                FROM INVENTORY_ADJUSTMENTS_RAW A
                INNER JOIN MATERIALS B ON A.MATERIAL_ID = B.MATERIAL_ID
                WHERE B.MATERIAL_ID = '"+cmbMaterials.SelectedValue.ToString()+ @"'
                UNION ALL
                SELECT FORMAT(C.DATE,'dd-MM-yyyy') AS [DATE],C.INVOICE_NO AS [REFERENCE],'SALE' AS [USED IN]
                FROM SALE_DETAIL A
                INNER JOIN MATERIALS B ON A.ITEM_ID = B.MATERIAL_ID
                INNER JOIN SALE_MASTER C ON A.SALE_MASTER_ID = C.SALE_MASTER_ID
                WHERE A.ITEM_TYPE = 'R' AND B.MATERIAL_ID = '" + cmbMaterials.SelectedValue.ToString() + @"'
                UNION ALL
                SELECT FORMAT(C.DATE,'dd-MM-yyyy') AS [DATE],C.INVOICE_NO AS [REFERENCE],'SALE RETURN' AS [USED IN]
                FROM SALE_RETURN_DETAIL A
                INNER JOIN MATERIALS B ON A.ITEM_ID = B.MATERIAL_ID
                INNER JOIN SALE_RETURN_MASTER C ON A.SALE_RETURN_MASTER_ID = C.SALE_RETURN_MASTER_ID
                WHERE A.ITEM_TYPE = 'R' AND B.MATERIAL_ID = '" + cmbMaterials.SelectedValue.ToString() + @"'
                UNION ALL
                SELECT FORMAT(C.DATE,'dd-MM-yyyy') AS [DATE],C.INVOICE_NO AS [REFERENCE],'PURCHASE' AS [USED IN]
                FROM PURCHASE_DETAIL A
                INNER JOIN MATERIALS B ON A.MATERIAL_ID = B.MATERIAL_ID
                INNER JOIN PURCHASE_MASTER C ON A.PURCHASE_MASTER_ID = C.PURCHASE_MASTER_ID
                WHERE B.MATERIAL_ID = '" + cmbMaterials.SelectedValue.ToString() + @"'
                UNION ALL
                SELECT FORMAT(C.DATE,'dd-MM-yyyy') AS [DATE],C.INVOICE_NO AS [REFERENCE],'PURCHASE RETURN' AS [USED IN]
                FROM PURCHASE_RETURN_DETAIL A
                INNER JOIN MATERIALS B ON A.MATERIAL_ID = B.MATERIAL_ID
                INNER JOIN PURCHASE_RETURN_MASTER C ON A.MASTER_ID = C.ID
                WHERE B.MATERIAL_ID = '" + cmbMaterials.SelectedValue.ToString() + @"'
                UNION ALL
                SELECT '' AS [DATE],C.PRODUCT_NAME AS [REFERENCE],'PRODUCT SETUP' AS [USED IN]
                FROM PRODUCT_DETAILS A
                INNER JOIN MATERIALS B ON A.MATERIAL_ID = B.MATERIAL_ID
                INNER JOIN PRODUCT_MASTER C ON A.PM_ID = C.PM_ID
                WHERE B.MATERIAL_ID = '" + cmbMaterials.SelectedValue.ToString() + @"'
                ORDER BY [USED IN]";

                if (Classes.Helper.conn.State == System.Data.ConnectionState.Closed) { Classes.Helper.conn.Open(); }
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.cmd.CommandTimeout = 0;
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    while (classHelper.dr.Read())
                    {
                        grdSEARCH.Rows.Add(classHelper.dr["DATE"].ToString(), classHelper.dr["REFERENCE"].ToString(), classHelper.dr["USED IN"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), ":: Error ::");
            }
            finally
            {
                Classes.Helper.conn.Close();
            }
        }


        //clear fields in form
        private void clear() {
            LoadMaterials();
            grdSEARCH.Rows.Clear();
        }


        //get data from grid on click
        private void load_data_fromGrid(DataGridViewCellEventArgs e)
        {
            
        }

        private void frm_AddGroupAccounts_Load(object sender, EventArgs e)
        {
            LoadMaterials();
        }

        

        private void btnSAVE_Click(object sender, EventArgs e)
        {
            if (!cmbMaterials.SelectedValue.ToString().Equals("0")) {
                LoadMaterialDetails();
            }
            
        }
        
        private void grdSEARCH_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            
        }

        private void btnCLEAR_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void grdSEARCH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
    }
}

