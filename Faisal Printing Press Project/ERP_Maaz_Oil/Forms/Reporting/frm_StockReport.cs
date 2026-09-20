using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ERP_Maaz_Oil.Forms.Reporting
{
    public partial class frm_StockReport : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        public frm_StockReport()
        {
            InitializeComponent();
        }

        private void LoadProducts()
        {
            classHelper.LoadProducts(cmbItem);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.R))
            {
                GenerateReport();
            }
            if (keyData == (Keys.Escape))
            {
                this.Dispose();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        //private void LoadBrands()
        //{
        //    classHelper.query = @"SELECT P_CATEGORY_ID AS [ID],P_CATEEGORY_NAME AS [BRAND] 
        //    FROM PRODUCT_CATEGORY 
        //    ORDER BY [BRAND]";
        //    classHelper.LoadCheckedListBox(brandList, classHelper.query);
        //}
        
        public void GenerateReport()
        {
            char hasRows = 'N';

            classHelper.query = @" SELECT B.PRODUCT_CODE,C.P_CATEEGORY_NAME AS [BRAND],B.PRODUCT_NAME AS [PRODUCT],
            B.OPENING_QTY +
            ISNULL((
	            SELECT SUM(QTY) 
	            FROM SALE_RETURN_MASTER X
	            INNER JOIN SALE_RETURN_DETAIL Y ON X.SALE_RETURN_MASTER_ID = Y.SALE_RETURN_MASTER_ID
	            INNER JOIN PRODUCT_MASTER Z ON Y.ITEM_ID = Z.PM_ID
	            WHERE X.[DATE] <= '" + Classes.Helper.ConvertDatetime(dtpFrom.Value.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"' AND Y.ITEM_ID = B.PM_ID 
            ),0) +
            ISNULL((
		        SELECT SUM(QTY) 
		        FROM PURCHASE_MASTER X
		        INNER JOIN PURCHASE_DETAIL Y ON X.PURCHASE_MASTER_ID = Y.PURCHASE_MASTER_ID
		        INNER JOIN PRODUCT_MASTER Z ON Y.MATERIAL_ID = Z.PM_ID
		        WHERE X.[DATE] <= '" + Classes.Helper.ConvertDatetime(dtpFrom.Value.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"' AND Y.MATERIAL_ID = B.PM_ID 
	        ),0) +
	        ISNULL((
		        SELECT SUM(QTY) 
		        FROM PRODUCTION_MASTER X
		        INNER JOIN PRODUCTION_DETAIL Y ON X.ID = Y.PRODUCTION_MASTER_ID
		        INNER JOIN PRODUCT_MASTER Z ON Y.PRODUCT_MASTER_ID = Z.PM_ID
		        WHERE X.[DATE] <= '" + Classes.Helper.ConvertDatetime(dtpFrom.Value.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"' AND Y.PRODUCT_MASTER_ID = B.PM_ID 
	        ),0) +
	        ISNULL((
		        SELECT SUM(X.QTY) 
				FROM INVENTORY_ADJUSTMENTS X
				INNER JOIN PRODUCT_MASTER Z ON X.MATERIAL_ID = Z.PM_ID
				WHERE X.[DATE] <= '" + Classes.Helper.ConvertDatetime(dtpFrom.Value.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"' AND X.MATERIAL_ID = B.PM_ID 
				AND X.ADD_LESS = 'A'
	        ),0) AS [IN],
            ISNULL((
	            SELECT SUM(QTY) 
	            FROM SALE_MASTER X
	            INNER JOIN SALE_DETAIL Y ON X.SALE_MASTER_ID = Y.SALE_MASTER_ID
	            INNER JOIN PRODUCT_MASTER Z ON Y.ITEM_ID = Z.PM_ID
	            WHERE X.[DATE] <= '" + Classes.Helper.ConvertDatetime(dtpFrom.Value.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"' AND Y.ITEM_ID = B.PM_ID 
            ),0)  +
            ISNULL((
		        SELECT SUM(QTY) 
		        FROM PURCHASE_RETURN_MASTER X
		        INNER JOIN PURCHASE_RETURN_DETAIL Y ON X.ID = Y.PURCHASE_RETURN_MASTER_ID
		        INNER JOIN PRODUCT_MASTER Z ON Y.MATERIAL_ID = Z.PM_ID
		        WHERE X.[DATE] <= '" + Classes.Helper.ConvertDatetime(dtpFrom.Value.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"' AND Y.MATERIAL_ID = B.PM_ID 
	        ),0) +
            ISNULL((
		        SELECT SUM(X.QTY) 
				FROM INVENTORY_ADJUSTMENTS X
				INNER JOIN PRODUCT_MASTER Z ON X.MATERIAL_ID = Z.PM_ID
				WHERE X.[DATE] <= '" + Classes.Helper.ConvertDatetime(dtpFrom.Value.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"' AND X.MATERIAL_ID = B.PM_ID 
				AND X.ADD_LESS = 'D'
	        ),0) AS [OUT]
            FROM PRODUCT_MASTER B
            INNER JOIN PRODUCT_CATEGORY C ON C.P_CATEGORY_ID = B.BRAND_ID ";
            if (cmbItem.SelectedIndex > 0)
            {
                classHelper.query += @" WHERE B.PM_ID = '" + cmbItem.SelectedValue.ToString() + "' ";
            }
            classHelper.query += @" ORDER BY [BRAND]";

            Classes.Helper.conn.Open();
            try
            {
                classHelper.nds.Tables["StockReport"].Clear();
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    hasRows = 'Y';
                    while (classHelper.dr.Read())
                    {
                        classHelper.dataR = classHelper.nds.Tables["StockReport"].NewRow();

                        classHelper.dataR["fromDate"] = dtpFrom.Value.Date;
                        //classHelper.dataR["toDate"] = dtpTo.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                        classHelper.dataR["brand"] = classHelper.dr["BRAND"].ToString();
                        classHelper.dataR["code"] = classHelper.dr["PRODUCT_CODE"].ToString();
                        classHelper.dataR["product"] = classHelper.dr["PRODUCT"].ToString();
                        //classHelper.dataR["opening"] = Convert.ToDecimal(classHelper.dr["OPENING"].ToString());
                        classHelper.dataR["in"] = Convert.ToDecimal(classHelper.dr["IN"].ToString());
                        classHelper.dataR["out"] = Convert.ToDecimal(classHelper.dr["OUT"].ToString());
                        classHelper.dataR["balance"] = Convert.ToDecimal(classHelper.dr["IN"].ToString()) - Convert.ToDecimal(classHelper.dr["OUT"].ToString());
                        //classHelper.dataR["rate"] = Convert.ToDecimal(classHelper.dr["RATE"].ToString());
                        //classHelper.dataR["amount"] = (Convert.ToDecimal(classHelper.dr["OPENING"].ToString()) + Convert.ToDecimal(classHelper.dr["IN"].ToString()) - Convert.ToDecimal(classHelper.dr["OUT"].ToString())) * Convert.ToDecimal(classHelper.dr["RATE"].ToString()); 

                        classHelper.nds.Tables["StockReport"].Rows.Add(classHelper.dataR);
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
                classHelper.rpt = new frmReports();
                classHelper.rpt.GenerateReport("StockReport", classHelper.nds);
                classHelper.rpt.ShowDialog();
            }
            else {
                MessageBox.Show("No Record Found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnINTER_SAVE_Click(object sender, EventArgs e)
        {
            GenerateReport();
        }
        private void frm_Account_Ledger_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void frm_ControlAccountLedger_Load(object sender, EventArgs e)
        {
            //LoadBrands();
            LoadProducts();
        }
    }
}
