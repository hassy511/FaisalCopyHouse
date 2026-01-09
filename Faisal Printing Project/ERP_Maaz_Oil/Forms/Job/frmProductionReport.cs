using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP_Maaz_Oil.DataSets;

using System.Windows.Forms;
using System.Data.SqlClient;
using ERP_Maaz_Oil.Forms.Reporting;

namespace ERP_Maaz_Oil.Forms.Job
{
    public partial class frmProductionReport : Form
    {
        Classes.Helper classHelper = new Classes.Helper();

        public frmProductionReport()
        {
            InitializeComponent();
        }

        private void LoadBrand()
        {
            try
            {
                classHelper.query = @"SELECT '0' AS [id], '--SELECT BRAND--' AS [name] 
                UNION
                SELECT P_CATEGORY_ID AS[id], P_CATEEGORY_NAME AS[name] FROM PRODUCT_CATEGORY
                WHERE STAT = 0";
                classHelper.LoadComboData(cmbBrand, classHelper.query);
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void LoadProducts()
        {
            classHelper.LoadProductsBrandWise(cmbProduct,Convert.ToInt32(cmbBrand.SelectedValue.ToString()));
        }

        private void frmJobOrder_Load(object sender, EventArgs e)
        {
            LoadBrand();
        }
     
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbBrand.SelectedIndex == 0)
            {
                classHelper.ShowMessageBox("Brand is not selected, please select Brand.", "Warning");
                cmbBrand.Focus();
            }
            else if (cmbProduct.SelectedIndex == 0)
            {
                classHelper.ShowMessageBox("Product is not selected, please select Product.", "Warning");
                cmbProduct.Focus();
            }
            else if (txtProductQty.Text.Equals("") || txtProductQty.Text.Equals("0"))
            {
                classHelper.ShowMessageBox("Please add Product Qty.", "Warning");
                txtProductQty.Focus();
            }
            else {
                grdItems.Rows.Add(cmbProduct.SelectedValue.ToString(),cmbProduct.Text,classHelper.AvoidInjection(txtProductQty.Text));
                cmbProduct.SelectedIndex = 0;
                txtProductQty.Text = "0";
            }
        }

        private void txtProductQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            classHelper.CheckNumber(e);
        }

        public void GenerateReport()
        {
            if (grdItems.Rows.Count > 0) {
                char hasRows = 'N';
                classHelper.query = "";

                foreach (DataGridViewRow row in grdItems.Rows)
                {
                    classHelper.query += @" SELECT D.P_CATEGORY_ID AS [BRAND ID],A.PM_ID,D.P_CATEEGORY_NAME AS [BRAND],C.PRODUCT_NAME,C.PRODUCT_CODE,A.MATERIAL_ID,CASE WHEN B.MATERIAL_NAME <> B.MATERIAL_CODE THEN B.MATERIAL_CODE+' : '+B.MATERIAL_NAME ELSE B.MATERIAL_NAME END AS [MATERIAL_NAME],A.[WEIGHT] * " + row.Cells["qty"].Value?.ToString() + @" AS [QTY]," + row.Cells["qty"].Value?.ToString() + @" AS [PRODUCT QTY]
                    --,(SELECT ISNULL(SUM(STOCK_IN),0) - ISNULL(SUM(STOCK_OUT),0) FROM MATERIAL_ITEM_LEDGER WHERE MATERIAL_ID = B.MATERIAL_ID) - 
                    --(SELECT ISNULL(SUM(X.QTY),0) FROM JOB_ORDER_MATERIALS X 
                    --INNER JOIN JOB_ORDER_MASTER Y ON X.JOB_ORDER_MASTER_ID = Y.JOB_ORDER_MASTER_ID 
                    --WHERE X.MATERIAL_ID = B.MATERIAL_ID  AND Y.[STATUS] = '0') AS [AVAILABLE QTY]
                    FROM PRODUCT_DETAILS A
                    INNER JOIN MATERIALS B ON A.MATERIAL_ID = B.MATERIAL_ID
                    INNER JOIN PRODUCT_MASTER C ON A.PM_ID = C.PM_ID
                    INNER JOIN PRODUCT_CATEGORY D ON C.BRAND_ID = D.P_CATEGORY_ID
                    WHERE D.P_CATEGORY_ID = '" + cmbBrand.SelectedValue.ToString()+"' AND A.PM_ID = '"+ row.Cells["productId"].Value?.ToString() + @"' UNION ALL ";                   
                }

                if (classHelper.query.EndsWith(" UNION ALL "))
                {
                    classHelper.query = classHelper.query.Substring(0, classHelper.query.Length - " UNION ALL ".Length);
                }

                classHelper.query += @" ORDER BY PM_ID";


                Classes.Helper.conn.Open();
                try
                {
                    classHelper.nds.Tables["ProductionReport"].Clear();
                    classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                    classHelper.dr = classHelper.cmd.ExecuteReader();
                    if (classHelper.dr.HasRows == true)
                    {
                        hasRows = 'Y';
                        while (classHelper.dr.Read())
                        {
                            classHelper.dataR = classHelper.nds.Tables["ProductionReport"].NewRow();

                            classHelper.dataR["brand"] = classHelper.dr["BRAND"].ToString();
                            classHelper.dataR["ProductName"] = classHelper.dr["PRODUCT_NAME"].ToString();
                            classHelper.dataR["ProductCode"] = classHelper.dr["PRODUCT_CODE"].ToString();
                            classHelper.dataR["qtyProduct"] = Convert.ToDecimal(classHelper.dr["PRODUCT QTY"].ToString());
                            classHelper.dataR["RawMaterial"] = classHelper.dr["MATERIAL_NAME"].ToString();
                            classHelper.dataR["quantity"] = Convert.ToDecimal(classHelper.dr["QTY"].ToString());

                            classHelper.nds.Tables["ProductionReport"].Rows.Add(classHelper.dataR);                           
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    Classes.Helper.conn.Close();
                }

                if (hasRows == 'Y')
                {
                    RawMaterialSummary();
                    classHelper.rpt = new frmReports();
                    classHelper.rpt.GenerateReport("ProductionReport", classHelper.nds);
                    classHelper.rpt.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No Record Found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void RawMaterialSummary() {
            try {
                
                DataTable productionTable = classHelper.nds.Tables["ProductionReport"];
                var query = from row in productionTable.AsEnumerable()
                            group row by row.Field<string>("rawMaterial") into g
                            orderby g.Key
                            select new
                            {
                                RawMaterial = g.Key,
                                TotalQuantity = g.Sum(r => r.Field<decimal>("quantity")) 
                            };

                // Insert grouped results into summaryTable
                classHelper.nds.Tables["ProductionSummary"].Clear();
                foreach (var item in query)
                {
                    classHelper.dataR = classHelper.nds.Tables["ProductionSummary"].NewRow();

                    classHelper.dataR["itemName"] = item.RawMaterial;
                    classHelper.dataR["qty"] = Convert.ToDecimal(item.TotalQuantity);
                    
                    classHelper.nds.Tables["ProductionSummary"].Rows.Add(classHelper.dataR);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            GenerateReport();
        }

        private void Clear(){
            cmbBrand.SelectedValue = "0";
            cmbProduct.Enabled = false;
            txtProductQty.Enabled = false;
            txtProductQty.Text = "0";
            grdItems.Rows.Clear();
        }

        private void btnCLEAR_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void cmbBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBrand.SelectedIndex > 0)
            {
                cmbProduct.Enabled = true;
                txtProductQty.Enabled = true;
                LoadProducts();
            }
            else {
                Clear();
            }
        }
    }
}
