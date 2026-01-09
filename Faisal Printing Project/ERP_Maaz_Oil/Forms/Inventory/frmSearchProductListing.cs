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
    public partial class frmSearchProductListing : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        string id = "";
        int is_edit = 0;

        public frmSearchProductListing()
        {
            InitializeComponent();
        }

        private void LoadProducts()
        {
            classHelper.LoadProducts(cmbProduct);
        }

        private void LoadProductDetails()
        {
            try
            {
                grdSEARCH.Rows.Clear();
                classHelper.query = @" SELECT FORMAT(A.DATE,'dd-MM-yyyy') AS [DATE],'' AS [REFERENCE],'INVENTORY ADJUSTMENT' AS [USED IN]
                FROM INVENTORY_ADJUSTMENTS A
                INNER JOIN PRODUCT_MASTER B ON A.MATERIAL_ID = B.PM_ID
                WHERE B.PM_ID = '" + cmbProduct.SelectedValue.ToString() + @"'
                UNION ALL
                SELECT FORMAT(C.DATE,'dd-MM-yyyy') AS [DATE],C.INVOICE_NO AS [REFERENCE],'SALE' AS [USED IN]
                FROM SALE_DETAIL A
                INNER JOIN PRODUCT_MASTER B ON A.ITEM_ID = B.PM_ID
                INNER JOIN SALE_MASTER C ON A.SALE_MASTER_ID = C.SALE_MASTER_ID
                WHERE A.ITEM_TYPE = 'P' AND B.PM_ID = '" + cmbProduct.SelectedValue.ToString() + @"'
                UNION ALL
                SELECT FORMAT(C.DATE,'dd-MM-yyyy') AS [DATE],C.INVOICE_NO AS [REFERENCE],'SALE RETURN' AS [USED IN]
                FROM SALE_RETURN_DETAIL A
                INNER JOIN PRODUCT_MASTER B ON A.ITEM_ID = B.PM_ID
                INNER JOIN SALE_RETURN_MASTER C ON A.SALE_RETURN_MASTER_ID = C.SALE_RETURN_MASTER_ID
                WHERE A.ITEM_TYPE = 'P' AND B.PM_ID = '" + cmbProduct.SelectedValue.ToString() + @"'
                UNION ALL
                SELECT FORMAT(C.DATE,'dd-MM-yyyy') AS [DATE],'' AS [REFERENCE],'PRODUCTION' AS [USED IN]
                FROM PRODUCTION_DETAIL A
                INNER JOIN PRODUCT_MASTER B ON A.PRODUCT_MASTER_ID = B.PM_ID
                INNER JOIN PRODUCTION_MASTER C ON A.PRODUCTION_MASTER_ID = C.ID
                WHERE B.PM_ID = '" + cmbProduct.SelectedValue.ToString() + @"'
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
            LoadProducts();
            grdSEARCH.Rows.Clear();
        }


        //get data from grid on click
        private void load_data_fromGrid(DataGridViewCellEventArgs e)
        {
            
        }

        private void frm_AddGroupAccounts_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        

        private void btnSAVE_Click(object sender, EventArgs e)
        {
            if (!cmbProduct.SelectedValue.ToString().Equals("0")) {
                LoadProductDetails();
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

