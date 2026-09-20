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
    public partial class frm_BrandReport : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        public frm_BrandReport()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.R))
            {
                ShowReport();
            }
            if (keyData == (Keys.Escape))
            {
                this.Dispose();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void ShowReport()
        {
            classHelper.query = @"SELECT D.P_CATEEGORY_NAME AS [BRAND],C.PRODUCT_NAME AS [PRODUCT NAME],
            C.NET_WEIGHT AS [PRODUCT WEIGHT],SUM(B.QTY) AS [QTY],(C.NET_WEIGHT * SUM(B.QTY)) AS [TOTAL WEIGHT],
            ROUND((ROUND(SUM((B.QTY * B.RATE)),4) / SUM(B.QTY)),4) AS [AVG RATE],ROUND(SUM((B.QTY * B.RATE)),4) AS [TOTAL]
            FROM SALES X
            INNER JOIN SALES_PROGRAM_MASTER A ON X.SOP_ID = A.SPM_ID
            INNER JOIN SALES_PROGRAM_DETAILS B ON A.SPM_ID = B.SPM_ID
            INNER JOIN PRODUCT_MASTER C ON B.PRODUCT_ID = C.PM_ID
            INNER JOIN PRODUCT_CATEGORY D ON C.BRAND_ID = D.P_CATEGORY_ID
            WHERE X.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
            GROUP BY D.P_CATEEGORY_NAME,C.PRODUCT_NAME,C.NET_WEIGHT
            ORDER BY[BRAND]";

            char hasRows = 'N';
            try
            {
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    hasRows = 'Y';
                    classHelper.mds.Tables["BrandWiseReport"].Clear();
                    while (classHelper.dr.Read())
                    {
                        classHelper.dataR = classHelper.mds.Tables["BrandWiseReport"].NewRow();
                        classHelper.dataR["from"] = dtp_FROM.Value.Date;
                        classHelper.dataR["to"] = dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                        classHelper.dataR["brand"] = classHelper.dr["BRAND"].ToString();
                        classHelper.dataR["product"] = classHelper.dr["PRODUCT NAME"].ToString();
                        classHelper.dataR["productWeight"] = Convert.ToDecimal(classHelper.dr["PRODUCT WEIGHT"].ToString());
                        classHelper.dataR["qty"] = Convert.ToDecimal(classHelper.dr["QTY"].ToString());
                        classHelper.dataR["totalWeight"] = Convert.ToDecimal(classHelper.dr["TOTAL WEIGHT"].ToString());
                        classHelper.dataR["averageRate"] = Convert.ToDecimal(classHelper.dr["AVG RATE"].ToString());
                        classHelper.dataR["amount"] = Convert.ToDecimal(classHelper.dr["TOTAL"].ToString());
                        classHelper.mds.Tables["BrandWiseReport"].Rows.Add(classHelper.dataR);
                    }
                }
                else {
                    MessageBox.Show("No Record Found.", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Classes.Helper.conn.Close();
            }

            classHelper.query = @"SELECT EA.P_CATEEGORY_NAME AS [BRAND],
	        (SELECT ISNULL(SUM(C.WEIGHT),0)
	        FROM SALES A
	        INNER JOIN SALES_PROGRAM_MASTER B ON A.SOP_ID = B.SPM_ID
	        INNER JOIN SALES_PROGRAM_DETAILS C ON B.SPM_ID = C.SPM_ID
	        INNER JOIN PRODUCT_MASTER E ON C.PRODUCT_ID = E.PM_ID
	        INNER JOIN PRODUCT_DETAILS G ON E.PM_ID = G.PM_ID
	        WHERE G.MATERIAL_ID = '5003' 
	        AND E.BRAND_ID = EA.P_CATEGORY_ID 
	        AND A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
	        ) 
	        AS [OLIEN WEIGHT], 
	        (SELECT ISNULL(SUM(C.QTY * C.RATE),0)
	        FROM SALES A
	        INNER JOIN SALES_PROGRAM_MASTER B ON A.SOP_ID = B.SPM_ID
	        INNER JOIN SALES_PROGRAM_DETAILS C ON B.SPM_ID = C.SPM_ID
	        INNER JOIN PRODUCT_MASTER E ON C.PRODUCT_ID = E.PM_ID
	        INNER JOIN PRODUCT_DETAILS G ON E.PM_ID = G.PM_ID
	        WHERE G.MATERIAL_ID = '5003' 
	        AND E.BRAND_ID = EA.P_CATEGORY_ID
	        AND A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
	        ) AS [OLIEN AMOUNT],
	        (SELECT ISNULL(SUM(C.WEIGHT),0)
	        FROM SALES A
	        INNER JOIN SALES_PROGRAM_MASTER B ON A.SOP_ID = B.SPM_ID
	        INNER JOIN SALES_PROGRAM_DETAILS C ON B.SPM_ID = C.SPM_ID
	        INNER JOIN PRODUCT_MASTER E ON C.PRODUCT_ID = E.PM_ID
	        INNER JOIN PRODUCT_DETAILS G ON E.PM_ID = G.PM_ID
	        WHERE G.MATERIAL_ID = '5005' AND E.BRAND_ID = EA.P_CATEGORY_ID
	        AND A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
	        ) 
	        AS [CANOLA],
	        (SELECT ISNULL(SUM(C.QTY * C.RATE),0)
	        FROM SALES A
	        INNER JOIN SALES_PROGRAM_MASTER B ON A.SOP_ID = B.SPM_ID
	        INNER JOIN SALES_PROGRAM_DETAILS C ON B.SPM_ID = C.SPM_ID
	        INNER JOIN PRODUCT_MASTER E ON C.PRODUCT_ID = E.PM_ID
	        INNER JOIN PRODUCT_DETAILS G ON E.PM_ID = G.PM_ID
	        WHERE G.MATERIAL_ID = '5005' 
	        AND E.BRAND_ID = EA.P_CATEGORY_ID
	        AND A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
	        ) AS [CANOLA AMOUNT],
	        SUM(C.QTY * C.RATE) AS [AMOUNT]
	        FROM SALES SA
	        INNER JOIN SALES_PROGRAM_MASTER B ON SA.SOP_ID = B.SPM_ID
	        INNER JOIN SALES_PROGRAM_DETAILS C ON B.SPM_ID = C.SPM_ID
	        INNER JOIN PRODUCT_MASTER D ON C.PRODUCT_ID = D.PM_ID
	        INNER JOIN PRODUCT_CATEGORY EA ON D.BRAND_ID = EA.P_CATEGORY_ID
	        WHERE SA.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
	        GROUP BY EA.P_CATEEGORY_NAME,EA.P_CATEGORY_ID
            ORDER BY [BRAND]";
            
            try
            {
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    classHelper.mds.Tables["BrandWiseReportSummary"].Clear();
                    while (classHelper.dr.Read())
                    {
                        classHelper.dataR = classHelper.mds.Tables["BrandWiseReportSummary"].NewRow();
                        classHelper.dataR["brand"] = classHelper.dr["BRAND"].ToString();
                        classHelper.dataR["olienWeight"] = Convert.ToDecimal(classHelper.dr["OLIEN WEIGHT"].ToString());
                        classHelper.dataR["olienAmount"] = Convert.ToDecimal(classHelper.dr["OLIEN AMOUNT"].ToString());
                        classHelper.dataR["canolaWeight"] = Convert.ToDecimal(classHelper.dr["CANOLA"].ToString());
                        classHelper.dataR["canolaAmount"] = Convert.ToDecimal(classHelper.dr["CANOLA AMOUNT"].ToString());
                        classHelper.dataR["amount"] = Convert.ToDecimal(classHelper.dr["AMOUNT"].ToString());
                        classHelper.dataR["from"] = dtp_FROM.Value.Date;
                        classHelper.dataR["to"] = dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                        classHelper.mds.Tables["BrandWiseReportSummary"].Rows.Add(classHelper.dataR);
                    }
                }
                else
                {
                   // MessageBox.Show("No Record Found.", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //Reports.POSummary rptPOS = new Reports.POSummary();
                //rptPOS.SetDataSource(classHelper.mds.Tables["PO_Summary"]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Classes.Helper.conn.Close();
            }
            if (hasRows == 'Y')
            {
                classHelper.rpt = new frmReports();
                classHelper.rpt.GenerateReport("BrandReport", classHelper.mds);
                classHelper.rpt.ShowDialog();

                classHelper.rpt = new frmReports();
                classHelper.rpt.GenerateReport("BrandSummaryReport", classHelper.mds);
                classHelper.rpt.ShowDialog();
            }
        }

        private void grpSALES_Enter(object sender, EventArgs e)
        {
            
        }
        
        private void btnINTER_SAVE_Click(object sender, EventArgs e)
        {
            ShowReport();
        }

        private void frm_Account_Ledger_Load(object sender, EventArgs e)
        {
            
        }

        private void frm_Account_Ledger_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
