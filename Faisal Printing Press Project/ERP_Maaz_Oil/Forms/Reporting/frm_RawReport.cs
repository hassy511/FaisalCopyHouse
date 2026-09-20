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
    public partial class frm_RawReport : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        public frm_RawReport()
        {
            InitializeComponent();
        }

     //   private void LoadMaterials()
       // {
       //     classHelper.LoadRawMaterials(cmbItem);
       // }

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
        
        public void GenerateReport()
        {
            char hasRows = 'N';

            classHelper.query = @" SELECT 'RAW MATERIAL' AS [BRAND],D.MATERIAL_NAME AS [RAW MATERIAL],
            SUM(D.OPENING_QTY) +
            ISNULL(
	            (SELECT SUM(Y.QTY) AS [QTY]
	            FROM PURCHASE_MASTER X
	            INNER JOIN PURCHASE_DETAIL Y ON X.PURCHASE_MASTER_ID = Y.PURCHASE_MASTER_ID
	            INNER JOIN MATERIALS V ON V.MATERIAL_ID = Y.MATERIAL_ID
	            WHERE X.[DATE] <= '" + Classes.Helper.ConvertDatetime(dtpFrom.Value.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"' AND Y.MATERIAL_ID = D.MATERIAL_ID)
            ,0) +
	        ISNULL((
		        SELECT SUM(X.QTY) 
				FROM INVENTORY_ADJUSTMENTS_RAW X
				INNER JOIN MATERIALS Z ON X.MATERIAL_ID = Z.MATERIAL_ID
				WHERE X.[DATE] <= '" + Classes.Helper.ConvertDatetime(dtpFrom.Value.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"' AND X.MATERIAL_ID = D.MATERIAL_ID
				AND X.ADD_LESS = 'A'
	        ),0) AS [IN],
            ISNULL((
		    SELECT SUM(O.QTY) FROM (
                    SELECT ISNULL(SUM(W.WEIGHT * Y.QTY),0) AS [QTY]
			        FROM PRODUCTION_MASTER X
			        INNER JOIN PRODUCTION_DETAIL Y ON X.ID = Y.PRODUCTION_MASTER_ID
			        INNER JOIN PRODUCT_MASTER Z ON Y.PRODUCT_MASTER_ID = Z.PM_ID
			        INNER JOIN PRODUCT_DETAILS W ON W.PM_ID = Z.PM_ID
			        INNER JOIN MATERIALS V ON V.MATERIAL_ID = W.MATERIAL_ID
			        WHERE X.[DATE] <= '" + Classes.Helper.ConvertDatetime(dtpFrom.Value.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"' AND D.MATERIAL_ID = V.MATERIAL_ID

			        UNION ALL

			        SELECT ISNULL(SUM(Y.QTY),0)
			        FROM SALE_MASTER X
			        INNER JOIN SALE_DETAIL Y ON X.SALE_MASTER_ID = Y.SALE_MASTER_ID
			        INNER JOIN MATERIALS V ON V.MATERIAL_ID = Y.ITEM_ID
			        WHERE X.[DATE] <= '" + Classes.Helper.ConvertDatetime(dtpFrom.Value.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"' AND D.MATERIAL_ID = V.MATERIAL_ID  AND Y.ITEM_TYPE = 'R'

		        ) AS O
            ),0) +
	        ISNULL((
		        SELECT SUM(X.QTY) 
				FROM INVENTORY_ADJUSTMENTS_RAW X
				INNER JOIN MATERIALS Z ON X.MATERIAL_ID = Z.MATERIAL_ID
				WHERE X.[DATE] <= '" + Classes.Helper.ConvertDatetime(dtpFrom.Value.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"' AND X.MATERIAL_ID = D.MATERIAL_ID
				AND X.ADD_LESS = 'D'
	        ),0) AS [OUT]
            FROM MATERIALS D ";
                if (cmbItem.SelectedIndex > 0)
                {
                    classHelper.query += @" WHERE D.MATERIAL_ID = '" + cmbItem.SelectedValue.ToString() + "'";
                }
                classHelper.query += @" GROUP BY D.MATERIAL_NAME,D.MATERIAL_ID
            ORDER BY [RAW MATERIAL]";

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
                        classHelper.dataR["product"] = classHelper.dr["RAW MATERIAL"].ToString();
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
                classHelper.rpt.GenerateReport("MaterialStockReport", classHelper.nds);
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
           
        }
    }
}
