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
    public partial class frm_RawMaterialReport : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        public frm_RawMaterialReport()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.R))
            {
                if (chkDateWise.Checked)
                {
                    ShowReportDateWise();
                }
                else
                {
                    ShowReport();
                }
            }
            if (keyData == (Keys.Escape))
            {
                this.Dispose();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void ShowReport()
        {
            classHelper.query = @"WITH A AS (
	        --OPENING
	        SELECT A.MATERIAL_ID,A.MATERIAL,
	        SUM((ISNULL(A.QTY,0) + ISNULL(B.QTY,0) + ISNULL(C.QTY,0) + ISNULL(D.QTY,0) + ISNULL(E.QTY,0))) AS [QTY],
	        AVG((ISNULL(A.AMOUNT,0) + ISNULL(B.AMOUNT,0) + ISNULL(C.AMOUNT,0) + ISNULL(D.AMOUNT,0) + ISNULL(E.AMOUNT,0)) / 
	        CASE WHEN 
	        (ISNULL(A.QTY,0) + ISNULL(B.QTY,0) + ISNULL(C.QTY,0) + ISNULL(D.QTY,0) + ISNULL(E.QTY,0)) = 0 THEN 1 ELSE 
	        (ISNULL(A.QTY,0) + ISNULL(B.QTY,0) + ISNULL(C.QTY,0) + ISNULL(D.QTY,0) + ISNULL(E.QTY,0)) END
	        ) AS [RATE],
	        SUM((ISNULL(A.AMOUNT,0) + ISNULL(B.AMOUNT,0) + ISNULL(C.AMOUNT,0) + ISNULL(D.AMOUNT,0) + ISNULL(E.AMOUNT,0))) AS [AMOUNT]
	        FROM 
	        (
		        SELECT A.MATERIAL_ID,A.MATERIAL_NAME AS [MATERIAL],A.OPENING_QTY AS [QTY],
		        A.OPENING_RATE AS [RATE],A.OPENING_QTY * A.OPENING_RATE AS [AMOUNT],
		        'OPENING' AS [TYPE]
		        FROM MATERIALS A
	        ) A
	        LEFT JOIN (
		        SELECT C.MATERIAL_ID,C.MATERIAL_NAME AS [MATERIAL],SUM(A.NET_WEIGHT) AS [QTY],
		        AVG(A.KG_RATE) AS [RATE],SUM(A.NET_WEIGHT) * AVG(A.KG_RATE) AS [AMOUNT],
		        'OPENING' AS [TYPE]
		        FROM PURCHASES A
		        INNER JOIN PURCHASES_ORDER B ON A.PO_ID = B.PO_ID
		        INNER JOIN MATERIALS C ON B.MATERIAL_ID = C.MATERIAL_ID
		        WHERE A.[DATE] < '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + @"' AND A.PI_ID NOT IN (SELECT purchases_id FROM purchases_sales_transfer)
		        GROUP BY C.MATERIAL_ID,C.MATERIAL_NAME
	        ) B ON A.MATERIAL_ID = B.MATERIAL_ID
	        LEFT JOIN (
		        SELECT F.MATERIAL_ID,F.MATERIAL_NAME AS [MATERIAL],SUM(C.WEIGHT) AS [QTY],
		        AVG(ISNULL(C.QTY * C.RATE,0) / (C.WEIGHT)) AS [RATE],
		        ISNULL(SUM(C.QTY * C.RATE),0) AS [AMOUNT],
		        'OPENING' AS [TYPE]
		        FROM SALES A
		        INNER JOIN SALES_PROGRAM_MASTER B ON A.SOP_ID = B.SPM_ID
		        INNER JOIN SALES_PROGRAM_DETAILS C ON B.SPM_ID = C.SPM_ID
		        INNER JOIN SALES_ORDER_DIRECT G ON B.SOD_ID = G.SOD_ID
		        INNER JOIN PRODUCT_MASTER D ON C.PRODUCT_ID = D.PM_ID
		        INNER JOIN PRODUCT_DETAILS E ON D.PM_ID = E.PM_ID
		        INNER JOIN MATERIALS F ON E.MATERIAL_ID = F.MATERIAL_ID
		        WHERE A.[DATE] < '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + @"' 
		        GROUP BY F.MATERIAL_ID,F.MATERIAL_NAME
	        ) C ON A.MATERIAL_ID = C.MATERIAL_ID
	        LEFT JOIN (
                --AA SALES
                SELECT F.MATERIAL_ID,F.MATERIAL_NAME AS [MATERIAL],SUM(A.sales_weight) AS [QTY],
                AVG(ISNULL(A.total,0) / (A.sales_weight)) AS [RATE],
                ISNULL(SUM(A.total),0) AS [AMOUNT],
                'SALES' AS [TYPE]
                FROM AA_SALES A
                INNER JOIN SALES_ORDER_DIRECT G ON A.SO_ID = G.SOD_ID
                INNER JOIN MATERIALS F ON G.MATERIAL_ID = F.MATERIAL_ID
                WHERE A.[DATE] < '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + @"' 
                GROUP BY F.MATERIAL_ID,F.MATERIAL_NAME
	        ) D ON A.MATERIAL_ID = D.MATERIAL_ID		
	        LEFT JOIN (
		        SELECT C.MATERIAL_ID,C.MATERIAL_NAME AS [MATERIAL],SUM(B.ITEM_WEIGHT) AS [QTY],
		        AVG(ISNULL(B.QTY * B.ITEM_RATE,0) / (B.ITEM_WEIGHT)) AS [RATE],
		        ISNULL(SUM(B.QTY * B.ITEM_RATE),0) AS [AMOUNT],
		        'OPENING' AS [TYPE]
		        FROM SALES_RETURN_MASTER A
		        INNER JOIN SALES_RETURN_DETAIL B ON A.SRM_ID = B.SRM_ID
		        INNER JOIN MATERIALS C ON B.MATERIAL_ID = C.MATERIAL_ID
		        WHERE A.[DATE] < '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + @"' 
		        GROUP BY C.MATERIAL_ID,C.MATERIAL_NAME
	        ) E ON A.MATERIAL_ID = E.MATERIAL_ID
	        GROUP BY A.MATERIAL_ID,A.MATERIAL),
        B AS (
	        --PURCHASES
	        SELECT C.MATERIAL_ID,C.MATERIAL_NAME AS [MATERIAL],SUM(A.NET_WEIGHT) AS [QTY],
	        AVG(A.KG_RATE) AS [RATE],SUM(A.NET_WEIGHT) * AVG(A.KG_RATE) AS [AMOUNT],
	        'PURCHASES' AS [TYPE]
	        FROM PURCHASES A
	        INNER JOIN PURCHASES_ORDER B ON A.PO_ID = B.PO_ID
	        INNER JOIN MATERIALS C ON B.MATERIAL_ID = C.MATERIAL_ID
	        WHERE A.[DATE] BETWEEN '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
            AND A.PI_ID NOT IN (SELECT purchases_id FROM purchases_sales_transfer)
	        GROUP BY C.MATERIAL_ID,C.MATERIAL_NAME),
        C AS (
	        --SALES
	        SELECT X.MATERIAL_ID,X.MATERIAL,SUM(X.QTY) AS [QTY],
            AVG(X.RATE) AS [RATE],SUM(X.AMOUNT) AS [AMOUNT],X.[TYPE]
            FROM (
            SELECT F.MATERIAL_ID,F.MATERIAL_NAME AS [MATERIAL],SUM(C.WEIGHT) AS [QTY],
            AVG(ISNULL(C.QTY * C.RATE,0) / (C.WEIGHT)) AS [RATE],
            ISNULL(SUM(C.QTY * C.RATE),0) AS [AMOUNT],
            'SALES' AS [TYPE]
            FROM SALES A
            INNER JOIN SALES_PROGRAM_MASTER B ON A.SOP_ID = B.SPM_ID
            INNER JOIN SALES_PROGRAM_DETAILS C ON B.SPM_ID = C.SPM_ID
            INNER JOIN SALES_ORDER_PRODUCT_MASTER G ON B.SOD_ID = G.SOPM_ID
            INNER JOIN PRODUCT_MASTER D ON C.PRODUCT_ID = D.PM_ID
            INNER JOIN PRODUCT_DETAILS E ON D.PM_ID = E.PM_ID
            INNER JOIN MATERIALS F ON E.MATERIAL_ID = F.MATERIAL_ID
            WHERE A.[DATE] BETWEEN '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"' AND B.SO_TYPE = 'P'
            GROUP BY F.MATERIAL_ID,F.MATERIAL_NAME
            UNION ALL
            SELECT D.MATERIAL_ID,D.MATERIAL_NAME AS [MATERIAL],SUM(C.WEIGHT) AS [QTY],
            AVG(ISNULL(C.QTY * C.RATE,0) / (C.WEIGHT)) AS [RATE],
            ISNULL(SUM(C.QTY * C.RATE),0) AS [AMOUNT],
            'SALES' AS [TYPE]
            FROM SALES A
            INNER JOIN SALES_PROGRAM_MASTER B ON A.SOP_ID = B.SPM_ID
            INNER JOIN SALES_PROGRAM_DETAILS C ON B.SPM_ID = C.SPM_ID
            INNER JOIN SALES_ORDER_PRODUCT_MASTER G ON B.SOD_ID = G.SOPM_ID
            INNER JOIN MATERIALS D ON C.PRODUCT_ID = D.MATERIAL_ID
            WHERE A.[DATE] BETWEEN '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"' AND B.SO_TYPE = 'P'
            GROUP BY D.MATERIAL_ID,D.MATERIAL_NAME
            UNION ALL
            SELECT F.MATERIAL_ID,F.MATERIAL_NAME AS [MATERIAL],SUM(C.WEIGHT) AS [QTY],
            AVG(ISNULL(C.QTY * C.RATE,0) / (C.WEIGHT)) AS [RATE],
            ISNULL(SUM(C.QTY * C.RATE),0) AS [AMOUNT],
            'SALES' AS [TYPE]
            FROM SALES A
            INNER JOIN SALES_PROGRAM_MASTER B ON A.SOP_ID = B.SPM_ID
            INNER JOIN SALES_PROGRAM_DETAILS C ON B.SPM_ID = C.SPM_ID
            INNER JOIN SALES_ORDER_DIRECT G ON B.SOD_ID = G.SOD_ID
            INNER JOIN PRODUCT_MASTER D ON C.PRODUCT_ID = D.PM_ID
            INNER JOIN PRODUCT_DETAILS E ON D.PM_ID = E.PM_ID
            INNER JOIN MATERIALS F ON E.MATERIAL_ID = F.MATERIAL_ID
            WHERE A.[DATE] BETWEEN '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date)+ "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"' AND B.SO_TYPE = 'D'
            GROUP BY F.MATERIAL_ID,F.MATERIAL_NAME
            UNION ALL
            SELECT D.MATERIAL_ID,D.MATERIAL_NAME AS [MATERIAL],SUM(C.WEIGHT) AS [QTY],
            AVG(ISNULL(C.QTY * C.RATE,0) / (C.WEIGHT)) AS [RATE],
            ISNULL(SUM(C.QTY * C.RATE),0) AS [AMOUNT],
            'SALES' AS [TYPE]
            FROM SALES A
            INNER JOIN SALES_PROGRAM_MASTER B ON A.SOP_ID = B.SPM_ID
            INNER JOIN SALES_PROGRAM_DETAILS C ON B.SPM_ID = C.SPM_ID
            INNER JOIN SALES_ORDER_DIRECT G ON B.SOD_ID = G.SOD_ID
            INNER JOIN MATERIALS D ON C.PRODUCT_ID = D.MATERIAL_ID
            WHERE A.[DATE] BETWEEN '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"' AND B.SO_TYPE = 'D'
            GROUP BY D.MATERIAL_ID,D.MATERIAL_NAME) AS X
            GROUP BY X.MATERIAL_ID,X.MATERIAL,X.[TYPE]), 
        D AS (
	        --AA SALES
	        SELECT F.MATERIAL_ID,F.MATERIAL_NAME AS [MATERIAL],SUM(A.sales_weight) AS [QTY],
	        AVG(ISNULL(A.total,0) / (A.sales_weight)) AS [RATE],
	        ISNULL(SUM(A.total),0) AS [AMOUNT],
	        'SALES' AS [TYPE]
	        FROM AA_SALES A
	        INNER JOIN SALES_ORDER_DIRECT G ON A.SO_ID = G.SOD_ID
	        INNER JOIN MATERIALS F ON G.MATERIAL_ID = F.MATERIAL_ID
	        WHERE A.[DATE] BETWEEN '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
	        GROUP BY F.MATERIAL_ID,F.MATERIAL_NAME),
        E AS (
	        --SALES RETURN
	        SELECT C.MATERIAL_ID,C.MATERIAL_NAME AS [MATERIAL],SUM(B.ITEM_WEIGHT) AS [QTY],
	        AVG(ISNULL(B.QTY * B.ITEM_RATE,0) / (B.ITEM_WEIGHT)) AS [RATE],
	        ISNULL(SUM(B.QTY * B.ITEM_RATE),0) AS [AMOUNT],
	        'SALES RETURN' AS [TYPE]
	        FROM SALES_RETURN_MASTER A
	        INNER JOIN SALES_RETURN_DETAIL B ON A.SRM_ID = B.SRM_ID
	        INNER JOIN MATERIALS C ON B.MATERIAL_ID = C.MATERIAL_ID
	        WHERE A.[DATE] BETWEEN '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
	        GROUP BY C.MATERIAL_ID,C.MATERIAL_NAME),
		F AS (
			SELECT B.MATERIAL_ID,B.MATERIAL_NAME AS [MATERIAL],
			SUM(CASE WHEN A.ADD_LESS = 'A' THEN A.QTY ELSE -A.QTY END) AS [QTY],
			ISNULL(CASE WHEN B.MATERIAL_ID = 5005 THEN A.RATE ELSE A.RATE / 37.324 END,0) AS [RATE],
			ISNULL(SUM(A.QTY * ISNULL(CASE WHEN B.MATERIAL_ID = 5005 THEN A.RATE ELSE A.RATE / 37.324 END,0)),0) AS [AMOUNT]
			FROM INVENTORY_ADJUSTMENTS A
			INNER JOIN MATERIALS B ON A.MATERIAL_ID = B.MATERIAL_ID
			WHERE A.[DATE] BETWEEN '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
			GROUP BY B.MATERIAL_ID,B.MATERIAL_NAME,A.RATE
		)
        SELECT A.MATERIAL,
	        A.QTY AS [OPENING QTY],A.RATE AS [OPENING RATE],A.AMOUNT AS [OPENING AMOUNT],
	        ISNULL(B.QTY,0) AS [PURCHASES QTY],ISNULL(B.RATE,0) AS [PURCHASES RATE],ISNULL(B.AMOUNT,0) AS [PURCHASES AMOUNT],
	        ISNULL(C.QTY,0) AS [SALES QTY],ISNULL(C.AMOUNT / C.QTY,0) AS [SALES RATE],ISNULL(C.AMOUNT,0) AS [SALES AMOUNT],
	        ISNULL(D.QTY,0) AS [AA SALES QTY],ISNULL(D.RATE,0) AS [AA SALES RATE],ISNULL(D.AMOUNT,0) AS [AA SALES AMOUNT],
	        ISNULL(E.QTY,0) AS [SALES RETURN QTY],ISNULL(E.RATE,0) AS [SALES RETURN RATE],ISNULL(E.AMOUNT,0) AS [SALES RETURN AMOUNT],
            ISNULL(F.QTY,0) AS [OIL_ADJUSTMENT],ISNULL(F.RATE,0) AS [ADJUSTMENT RATE],ISNULL(F.AMOUNT,0) AS [ADJUSTMENT AMOUNT],
            '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date)+ "' as [from],'" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"' as [to]
        FROM A
        LEFT JOIN B ON A.MATERIAL_ID = B.MATERIAL_ID
        LEFT JOIN C ON A.MATERIAL_ID = C.MATERIAL_ID
        LEFT JOIN D ON A.MATERIAL_ID = D.MATERIAL_ID
        LEFT JOIN E ON A.MATERIAL_ID = E.MATERIAL_ID
        LEFT JOIN F ON A.MATERIAL_ID = F.MATERIAL_ID
        ORDER BY A.MATERIAL";

            char hasRows = 'N';
            try
            {
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.cmd.CommandTimeout = 0;
                classHelper.nds = new DataSets.NewDataSet();
                classHelper.adp = new System.Data.SqlClient.SqlDataAdapter(classHelper.cmd);
                classHelper.adp.Fill(classHelper.nds, "RawMaterialReport");

                if (classHelper.nds.Tables["RawMaterialReport"].Rows.Count <= 0)
                {
                    MessageBox.Show("No Record Found.", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else {
                    DataTable dt = classHelper.GetClosingStockData(dtp_FROM.Value.Date.AddDays(-1).AddHours(23).AddMinutes(59).AddSeconds(59));

                    Decimal olienOpeningQty = Convert.ToDecimal(Math.Round(dt.Rows.Cast<DataRow>().
                                                Where(x => x.Field<string>("MATERIAL_NAME").Equals("OLIEN/RBD")).
                                                Sum(r => r.Field<double>("NET_WEIGHT")), 2));

                    Decimal olienOpeningAmount = Convert.ToDecimal(Math.Round(dt.Rows.Cast<DataRow>().
                                                Where(x => x.Field<string>("MATERIAL_NAME").Equals("OLIEN/RBD")).
                                                Sum(r => r.Field<double>("AMOUNT")), 2));

                    Decimal canolaOpeningQty = Convert.ToDecimal(Math.Round(dt.Rows.Cast<DataRow>().
                                                Where(x => x.Field<string>("MATERIAL_NAME").Equals("CANOLA")).
                                                Sum(r => r.Field<double>("NET_WEIGHT")), 2));

                    Decimal canolaOpeningAmount = Convert.ToDecimal(Math.Round(dt.Rows.Cast<DataRow>().
                                                Where(x => x.Field<string>("MATERIAL_NAME").Equals("CANOLA")).
                                                Sum(r => r.Field<double>("AMOUNT")), 2));

                    Decimal hardOpeningQty = Convert.ToDecimal(Math.Round(dt.Rows.Cast<DataRow>().
                                                Where(x => x.Field<string>("MATERIAL_NAME").Equals("HARD OIL")).
                                                Sum(r => r.Field<double>("NET_WEIGHT")), 2));

                    Decimal hardOpeningAmount = Convert.ToDecimal(Math.Round(dt.Rows.Cast<DataRow>().
                                                Where(x => x.Field<string>("MATERIAL_NAME").Equals("HARD OIL")).
                                                Sum(r => r.Field<double>("AMOUNT")), 2));

                    Decimal soyaOpeningQty = Convert.ToDecimal(Math.Round(dt.Rows.Cast<DataRow>().
                                                Where(x => x.Field<string>("MATERIAL_NAME").Equals("SOYA BEAN")).
                                                Sum(r => r.Field<double>("NET_WEIGHT")), 2));

                    Decimal soyaOpeningAmount = Convert.ToDecimal(Math.Round(dt.Rows.Cast<DataRow>().
                                                Where(x => x.Field<string>("MATERIAL_NAME").Equals("SOYA BEAN")).
                                                Sum(r => r.Field<double>("AMOUNT")), 2));

                    foreach (DataRow dr in classHelper.nds.Tables["RawMaterialReport"].Rows) {
                        if (dr["MATERIAL"].ToString().Equals("CANOLA")) {
                            dr["OPENING QTY"] = canolaOpeningQty;
                            if (canolaOpeningQty == 0) { canolaOpeningQty = 1; }
                            dr["OPENING RATE"] = canolaOpeningAmount / canolaOpeningQty;
                            dr["OPENING AMOUNT"] = canolaOpeningAmount;
                        }
                        else if (dr["MATERIAL"].ToString().Equals("HARD OIL"))
                        {
                            dr["OPENING QTY"] = hardOpeningQty;
                            if (hardOpeningQty == 0) { hardOpeningQty = 1; }
                            dr["OPENING RATE"] = hardOpeningAmount / hardOpeningQty;
                            dr["OPENING AMOUNT"] = hardOpeningAmount;
                        }
                        else if (dr["MATERIAL"].ToString().Equals("OLIEN/RBD"))
                        {
                            dr["OPENING QTY"] = olienOpeningQty;
                            if (olienOpeningQty == 0) { olienOpeningQty = 1; }
                            dr["OPENING RATE"] = olienOpeningAmount / olienOpeningQty;
                            dr["OPENING AMOUNT"] = olienOpeningAmount;
                        }
                        else if (dr["MATERIAL"].ToString().Equals("SOYA BEAN"))
                        {
                            dr["OPENING QTY"] = soyaOpeningQty;
                            if (soyaOpeningQty == 0) { soyaOpeningQty = 1; }
                            dr["OPENING RATE"] = soyaOpeningAmount / soyaOpeningQty;
                            dr["OPENING AMOUNT"] = soyaOpeningAmount;
                        }
                    }
                    hasRows = 'Y';
                }
                /*Classes.Helper.conn.Open();
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
                }*/
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
                if (rdbDetailed.Checked == true)
                {
                    classHelper.rpt = new frmReports();
                    classHelper.rpt.GenerateReport("RawMaterialReport", classHelper.nds);
                    classHelper.rpt.ShowDialog();
                }
                else {
                    classHelper.rpt = new frmReports();
                    classHelper.rpt.GenerateReport("RawMaterialReportConsolidated", classHelper.nds);
                    classHelper.rpt.ShowDialog();
                }
            }
        }
        public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }

        private void ShowReportDateWise()
        {
            string upperquery = "WITH ";
            string lowerquery = "";
            DateTime startDate = dtp_FROM.Value.Date;
            DateTime endDate = dtp_TO.Value.Date;
            int value = 0;
            
            foreach (DateTime day in EachDay(startDate, endDate))
            {
                        upperquery += @"A"+value+@" AS (
	                    --OPENING
	                    SELECT A.MATERIAL_ID,A.MATERIAL,
	                    SUM((ISNULL(A.QTY,0) + ISNULL(B.QTY,0) - ISNULL(C.QTY,0) - ISNULL(D.QTY,0) + ISNULL(E.QTY,0))) AS [QTY],
	                    AVG((ISNULL(A.AMOUNT,0) + ISNULL(B.AMOUNT,0) - ISNULL(C.AMOUNT,0) - ISNULL(D.AMOUNT,0) + ISNULL(E.AMOUNT,0)) / 
	                    CASE WHEN 
	                    (ISNULL(A.QTY,0) + ISNULL(B.QTY,0) - ISNULL(C.QTY,0) - ISNULL(D.QTY,0) + ISNULL(E.QTY,0)) = 0 THEN 1 ELSE 
	                    (ISNULL(A.QTY,0) + ISNULL(B.QTY,0) - ISNULL(C.QTY,0) - ISNULL(D.QTY,0) + ISNULL(E.QTY,0)) END
	                    ) AS [RATE],
	                    SUM((ISNULL(A.AMOUNT,0) + ISNULL(B.AMOUNT,0) - ISNULL(C.AMOUNT,0) - ISNULL(D.AMOUNT,0) + ISNULL(E.AMOUNT,0))) AS [AMOUNT]
	                    FROM 
	                    (
		                    SELECT A.MATERIAL_ID,A.MATERIAL_NAME AS [MATERIAL],A.OPENING_QTY AS [QTY],
		                    A.OPENING_RATE AS [RATE],A.OPENING_QTY * A.OPENING_RATE AS [AMOUNT],
		                    'OPENING' AS [TYPE]
		                    FROM MATERIALS A
	                    ) A
	                    LEFT JOIN (
		                    SELECT C.MATERIAL_ID,C.MATERIAL_NAME AS [MATERIAL],SUM(A.NET_WEIGHT) AS [QTY],
		                    AVG(A.KG_RATE) AS [RATE],SUM(A.NET_WEIGHT) * AVG(A.KG_RATE) AS [AMOUNT],
		                    'OPENING' AS [TYPE]
		                    FROM PURCHASES A
		                    INNER JOIN PURCHASES_ORDER B ON A.PO_ID = B.PO_ID
		                    INNER JOIN MATERIALS C ON B.MATERIAL_ID = C.MATERIAL_ID
		                    WHERE A.[DATE] < '" + day + @"' AND A.PI_ID NOT IN (SELECT purchases_id FROM purchases_sales_transfer)
		                    GROUP BY C.MATERIAL_ID,C.MATERIAL_NAME
	                    ) B ON A.MATERIAL_ID = B.MATERIAL_ID
	                    LEFT JOIN (
		                    SELECT F.MATERIAL_ID,F.MATERIAL_NAME AS [MATERIAL],SUM(C.WEIGHT) AS [QTY],
		                    AVG(ISNULL(C.QTY * C.RATE,0) / (C.WEIGHT)) AS [RATE],
		                    ISNULL(SUM(C.QTY * C.RATE),0) AS [AMOUNT],
		                    'OPENING' AS [TYPE]
		                    FROM SALES A
		                    INNER JOIN SALES_PROGRAM_MASTER B ON A.SOP_ID = B.SPM_ID
		                    INNER JOIN SALES_PROGRAM_DETAILS C ON B.SPM_ID = C.SPM_ID
		                    INNER JOIN SALES_ORDER_DIRECT G ON B.SOD_ID = G.SOD_ID
		                    INNER JOIN PRODUCT_MASTER D ON C.PRODUCT_ID = D.PM_ID
		                    INNER JOIN PRODUCT_DETAILS E ON D.PM_ID = E.PM_ID
		                    INNER JOIN MATERIALS F ON E.MATERIAL_ID = F.MATERIAL_ID
		                    WHERE A.[DATE] < '" + day + @"' 
		                    GROUP BY F.MATERIAL_ID,F.MATERIAL_NAME
	                    ) C ON A.MATERIAL_ID = C.MATERIAL_ID
	                    LEFT JOIN (
                            --AA SALES
                            SELECT F.MATERIAL_ID,F.MATERIAL_NAME AS [MATERIAL],SUM(A.sales_weight) AS [QTY],
                            AVG(ISNULL(A.total,0) / (A.sales_weight)) AS [RATE],
                            ISNULL(SUM(A.total),0) AS [AMOUNT],
                            'SALES' AS [TYPE]
                            FROM AA_SALES A
                            INNER JOIN SALES_ORDER_DIRECT G ON A.SO_ID = G.SOD_ID
                            INNER JOIN MATERIALS F ON G.MATERIAL_ID = F.MATERIAL_ID
                            WHERE A.[DATE] < '" + day + @"' 
                            GROUP BY F.MATERIAL_ID,F.MATERIAL_NAME
	                    ) D ON A.MATERIAL_ID = D.MATERIAL_ID		
	                    LEFT JOIN (
		                    SELECT C.MATERIAL_ID,C.MATERIAL_NAME AS [MATERIAL],SUM(B.ITEM_WEIGHT) AS [QTY],
		                    AVG(ISNULL(B.QTY * B.ITEM_RATE,0) / (B.ITEM_WEIGHT)) AS [RATE],
		                    ISNULL(SUM(B.QTY * B.ITEM_RATE),0) AS [AMOUNT],
		                    'OPENING' AS [TYPE]
		                    FROM SALES_RETURN_MASTER A
		                    INNER JOIN SALES_RETURN_DETAIL B ON A.SRM_ID = B.SRM_ID
		                    INNER JOIN MATERIALS C ON B.MATERIAL_ID = C.MATERIAL_ID
		                    WHERE A.[DATE] < '" + day + @"' 
		                    GROUP BY C.MATERIAL_ID,C.MATERIAL_NAME
	                    ) E ON A.MATERIAL_ID = E.MATERIAL_ID
	                    GROUP BY A.MATERIAL_ID,A.MATERIAL),
                    B" + value + @" AS (
	                    --PURCHASES
	                    SELECT C.MATERIAL_ID,C.MATERIAL_NAME AS [MATERIAL],SUM(A.NET_WEIGHT) AS [QTY],
	                    AVG(A.KG_RATE) AS [RATE],SUM(A.NET_WEIGHT) * AVG(A.KG_RATE) AS [AMOUNT],
	                    'PURCHASES' AS [TYPE]
	                    FROM PURCHASES A
	                    INNER JOIN PURCHASES_ORDER B ON A.PO_ID = B.PO_ID
	                    INNER JOIN MATERIALS C ON B.MATERIAL_ID = C.MATERIAL_ID
	                    WHERE A.[DATE] BETWEEN '" + day + "' AND '" + day.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
                        AND A.PI_ID NOT IN (SELECT purchases_id FROM purchases_sales_transfer)
	                    GROUP BY C.MATERIAL_ID,C.MATERIAL_NAME),
                    C" + value + @" AS (
	                    --SALES
	                    SELECT X.MATERIAL_ID,X.MATERIAL,SUM(X.QTY) AS [QTY],
                        AVG(X.RATE) AS [RATE],SUM(X.AMOUNT) AS [AMOUNT],X.[TYPE]
                        FROM (
                        SELECT F.MATERIAL_ID,F.MATERIAL_NAME AS [MATERIAL],SUM(C.WEIGHT) AS [QTY],
                        AVG(ISNULL(C.QTY * C.RATE,0) / (C.WEIGHT)) AS [RATE],
                        ISNULL(SUM(C.QTY * C.RATE),0) AS [AMOUNT],
                        'SALES' AS [TYPE]
                        FROM SALES A
                        INNER JOIN SALES_PROGRAM_MASTER B ON A.SOP_ID = B.SPM_ID
                        INNER JOIN SALES_PROGRAM_DETAILS C ON B.SPM_ID = C.SPM_ID
                        INNER JOIN SALES_ORDER_PRODUCT_MASTER G ON B.SOD_ID = G.SOPM_ID
                        INNER JOIN PRODUCT_MASTER D ON C.PRODUCT_ID = D.PM_ID
                        INNER JOIN PRODUCT_DETAILS E ON D.PM_ID = E.PM_ID
                        INNER JOIN MATERIALS F ON E.MATERIAL_ID = F.MATERIAL_ID
                        WHERE A.[DATE] BETWEEN '" + day + "' AND '" + day.AddHours(23).AddMinutes(59).AddSeconds(59) + @"' AND B.SO_TYPE = 'P'
                        GROUP BY F.MATERIAL_ID,F.MATERIAL_NAME
                        UNION ALL
                        SELECT D.MATERIAL_ID,D.MATERIAL_NAME AS [MATERIAL],SUM(C.WEIGHT) AS [QTY],
                        AVG(ISNULL(C.QTY * C.RATE,0) / (C.WEIGHT)) AS [RATE],
                        ISNULL(SUM(C.QTY * C.RATE),0) AS [AMOUNT],
                        'SALES' AS [TYPE]
                        FROM SALES A
                        INNER JOIN SALES_PROGRAM_MASTER B ON A.SOP_ID = B.SPM_ID
                        INNER JOIN SALES_PROGRAM_DETAILS C ON B.SPM_ID = C.SPM_ID
                        INNER JOIN SALES_ORDER_PRODUCT_MASTER G ON B.SOD_ID = G.SOPM_ID
                        INNER JOIN MATERIALS D ON C.PRODUCT_ID = D.MATERIAL_ID
                        WHERE A.[DATE] BETWEEN '" + day + "' AND '" + day.AddHours(23).AddMinutes(59).AddSeconds(59) + @"' AND B.SO_TYPE = 'P'
                        GROUP BY D.MATERIAL_ID,D.MATERIAL_NAME
                        UNION ALL
                        SELECT F.MATERIAL_ID,F.MATERIAL_NAME AS [MATERIAL],SUM(C.WEIGHT) AS [QTY],
                        AVG(ISNULL(C.QTY * C.RATE,0) / (C.WEIGHT)) AS [RATE],
                        ISNULL(SUM(C.QTY * C.RATE),0) AS [AMOUNT],
                        'SALES' AS [TYPE]
                        FROM SALES A
                        INNER JOIN SALES_PROGRAM_MASTER B ON A.SOP_ID = B.SPM_ID
                        INNER JOIN SALES_PROGRAM_DETAILS C ON B.SPM_ID = C.SPM_ID
                        INNER JOIN SALES_ORDER_DIRECT G ON B.SOD_ID = G.SOD_ID
                        INNER JOIN PRODUCT_MASTER D ON C.PRODUCT_ID = D.PM_ID
                        INNER JOIN PRODUCT_DETAILS E ON D.PM_ID = E.PM_ID
                        INNER JOIN MATERIALS F ON E.MATERIAL_ID = F.MATERIAL_ID
                        WHERE A.[DATE] BETWEEN '" + day + "' AND '" + day.AddHours(23).AddMinutes(59).AddSeconds(59) + @"' AND B.SO_TYPE = 'D'
                        GROUP BY F.MATERIAL_ID,F.MATERIAL_NAME
                        UNION ALL
                        SELECT D.MATERIAL_ID,D.MATERIAL_NAME AS [MATERIAL],SUM(C.WEIGHT) AS [QTY],
                        AVG(ISNULL(C.QTY * C.RATE,0) / (C.WEIGHT)) AS [RATE],
                        ISNULL(SUM(C.QTY * C.RATE),0) AS [AMOUNT],
                        'SALES' AS [TYPE]
                        FROM SALES A
                        INNER JOIN SALES_PROGRAM_MASTER B ON A.SOP_ID = B.SPM_ID
                        INNER JOIN SALES_PROGRAM_DETAILS C ON B.SPM_ID = C.SPM_ID
                        INNER JOIN SALES_ORDER_DIRECT G ON B.SOD_ID = G.SOD_ID
                        INNER JOIN MATERIALS D ON C.PRODUCT_ID = D.MATERIAL_ID
                        WHERE A.[DATE] BETWEEN '" + day + "' AND '" + day.AddHours(23).AddMinutes(59).AddSeconds(59) + @"' AND B.SO_TYPE = 'D'
                        GROUP BY D.MATERIAL_ID,D.MATERIAL_NAME) AS X
                        GROUP BY X.MATERIAL_ID,X.MATERIAL,X.[TYPE]), 
                    D" + value + @" AS (
	                    --AA SALES
	                    SELECT F.MATERIAL_ID,F.MATERIAL_NAME AS [MATERIAL],SUM(A.sales_weight) AS [QTY],
	                    AVG(ISNULL(A.total,0) / (A.sales_weight)) AS [RATE],
	                    ISNULL(SUM(A.total),0) AS [AMOUNT],
	                    'SALES' AS [TYPE]
	                    FROM AA_SALES A
	                    INNER JOIN SALES_ORDER_DIRECT G ON A.SO_ID = G.SOD_ID
	                    INNER JOIN MATERIALS F ON G.MATERIAL_ID = F.MATERIAL_ID
	                    WHERE A.[DATE] BETWEEN '" + day + "' AND '" + day.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
	                    GROUP BY F.MATERIAL_ID,F.MATERIAL_NAME),
                    E" + value + @" AS (
	                    --SALES RETURN
	                    SELECT C.MATERIAL_ID,C.MATERIAL_NAME AS [MATERIAL],SUM(B.ITEM_WEIGHT) AS [QTY],
	                    AVG(ISNULL(B.QTY * B.ITEM_RATE,0) / (B.ITEM_WEIGHT)) AS [RATE],
	                    ISNULL(SUM(B.QTY * B.ITEM_RATE),0) AS [AMOUNT],
	                    'SALES RETURN' AS [TYPE]
	                    FROM SALES_RETURN_MASTER A
	                    INNER JOIN SALES_RETURN_DETAIL B ON A.SRM_ID = B.SRM_ID
	                    INNER JOIN MATERIALS C ON B.MATERIAL_ID = C.MATERIAL_ID
	                    WHERE A.[DATE] BETWEEN '" + day + "' AND '" + day.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
	                    GROUP BY C.MATERIAL_ID,C.MATERIAL_NAME),";

                lowerquery += @" SELECT '"+day+"' as [DATE],A" + value + @".MATERIAL,
	            A" + value + @".QTY AS [OPENING QTY],A" + value + @".RATE AS [OPENING RATE],A" + value + @".AMOUNT AS [OPENING AMOUNT],
	            ISNULL(B" + value + @".QTY,0) AS [PURCHASES QTY],ISNULL(B" + value + @".RATE,0) AS [PURCHASES RATE],ISNULL(B" + value + @".AMOUNT,0) AS [PURCHASES AMOUNT],
	            ISNULL(C" + value + @".QTY,0) AS [SALES QTY],ISNULL(C" + value + @".AMOUNT / C" + value + @".QTY,0) AS [SALES RATE],ISNULL(C" + value + @".AMOUNT,0) AS [SALES AMOUNT],
	            ISNULL(D" + value + @".QTY,0) AS [AA SALES QTY],ISNULL(D" + value + @".RATE,0) AS [AA SALES RATE],ISNULL(D" + value + @".AMOUNT,0) AS [AA SALES AMOUNT],
	            ISNULL(E" + value + @".QTY,0) AS [SALES RETURN QTY],ISNULL(E" + value + @".RATE,0) AS [SALES RETURN RATE],ISNULL(E" + value + @".AMOUNT,0) AS [SALES RETURN AMOUNT],
                '" + day + "' as [from],'" + day.AddHours(23).AddMinutes(59).AddSeconds(59) + @"' as [to]
                FROM A" + value + @"
                LEFT JOIN B" + value + @" ON A" + value + @".MATERIAL_ID = B" + value + @".MATERIAL_ID
                LEFT JOIN C" + value + @" ON A" + value + @".MATERIAL_ID = C" + value + @".MATERIAL_ID
                LEFT JOIN D" + value + @" ON A" + value + @".MATERIAL_ID = D" + value + @".MATERIAL_ID
                LEFT JOIN E" + value + @" ON A" + value + @".MATERIAL_ID = E" + value + @".MATERIAL_ID
                UNION ALL";

                value++;
            }

            upperquery = upperquery.Remove(upperquery.Length - 1, 1);
            lowerquery = lowerquery.Remove(lowerquery.Length - 9, 9);
            classHelper.query = upperquery + lowerquery;
            //    classHelper.query = @"WITH A AS (
            // --OPENING
            // SELECT A.MATERIAL_ID,A.MATERIAL,
            // SUM((ISNULL(A.QTY,0) + ISNULL(B.QTY,0) + ISNULL(C.QTY,0) + ISNULL(D.QTY,0) + ISNULL(E.QTY,0))) AS [QTY],
            // AVG((ISNULL(A.AMOUNT,0) + ISNULL(B.AMOUNT,0) + ISNULL(C.AMOUNT,0) + ISNULL(D.AMOUNT,0) + ISNULL(E.AMOUNT,0)) / 
            // CASE WHEN 
            // (ISNULL(A.QTY,0) + ISNULL(B.QTY,0) + ISNULL(C.QTY,0) + ISNULL(D.QTY,0) + ISNULL(E.QTY,0)) = 0 THEN 1 ELSE 
            // (ISNULL(A.QTY,0) + ISNULL(B.QTY,0) + ISNULL(C.QTY,0) + ISNULL(D.QTY,0) + ISNULL(E.QTY,0)) END
            // ) AS [RATE],
            // SUM((ISNULL(A.AMOUNT,0) + ISNULL(B.AMOUNT,0) + ISNULL(C.AMOUNT,0) + ISNULL(D.AMOUNT,0) + ISNULL(E.AMOUNT,0))) AS [AMOUNT]
            // FROM 
            // (
            //  SELECT A.MATERIAL_ID,A.MATERIAL_NAME AS [MATERIAL],A.OPENING_QTY AS [QTY],
            //  A.OPENING_RATE AS [RATE],A.OPENING_QTY * A.OPENING_RATE AS [AMOUNT],
            //  'OPENING' AS [TYPE]
            //  FROM MATERIALS A
            // ) A
            // LEFT JOIN (
            //  SELECT C.MATERIAL_ID,C.MATERIAL_NAME AS [MATERIAL],SUM(A.NET_WEIGHT) AS [QTY],
            //  AVG(A.KG_RATE) AS [RATE],SUM(A.NET_WEIGHT) * AVG(A.KG_RATE) AS [AMOUNT],A.DATE,
            //  'OPENING' AS [TYPE]
            //  FROM PURCHASES A
            //  INNER JOIN PURCHASES_ORDER B ON A.PO_ID = B.PO_ID
            //  INNER JOIN MATERIALS C ON B.MATERIAL_ID = C.MATERIAL_ID
            //  WHERE A.[DATE] < '" + dtp_FROM.Value.Date + @"' AND A.PI_ID NOT IN (SELECT purchases_id FROM purchases_sales_transfer)
            //  GROUP BY C.MATERIAL_ID,C.MATERIAL_NAME
            // ) B ON A.MATERIAL_ID = B.MATERIAL_ID
            // LEFT JOIN (
            //  SELECT F.MATERIAL_ID,F.MATERIAL_NAME AS [MATERIAL],SUM(C.WEIGHT) AS [QTY],
            //  AVG(ISNULL(C.QTY * C.RATE,0) / (C.WEIGHT)) AS [RATE],
            //  ISNULL(SUM(C.QTY * C.RATE),0) AS [AMOUNT],A.DATE,
            //  'OPENING' AS [TYPE]
            //  FROM SALES A
            //  INNER JOIN SALES_PROGRAM_MASTER B ON A.SOP_ID = B.SPM_ID
            //  INNER JOIN SALES_PROGRAM_DETAILS C ON B.SPM_ID = C.SPM_ID
            //  INNER JOIN SALES_ORDER_DIRECT G ON B.SOD_ID = G.SOD_ID
            //  INNER JOIN PRODUCT_MASTER D ON C.PRODUCT_ID = D.PM_ID
            //  INNER JOIN PRODUCT_DETAILS E ON D.PM_ID = E.PM_ID
            //  INNER JOIN MATERIALS F ON E.MATERIAL_ID = F.MATERIAL_ID
            //  WHERE A.[DATE] < '" + dtp_FROM.Value.Date + @"' 
            //  GROUP BY F.MATERIAL_ID,F.MATERIAL_NAME
            // ) C ON A.MATERIAL_ID = C.MATERIAL_ID
            // LEFT JOIN (
            //        --AA SALES
            //        SELECT F.MATERIAL_ID,F.MATERIAL_NAME AS [MATERIAL],SUM(A.sales_weight) AS [QTY],
            //        AVG(ISNULL(A.total,0) / (A.sales_weight)) AS [RATE],
            //        ISNULL(SUM(A.total),0) AS [AMOUNT],
            //        'SALES' AS [TYPE]
            //        FROM AA_SALES A
            //        INNER JOIN SALES_ORDER_DIRECT G ON A.SO_ID = G.SOD_ID
            //        INNER JOIN MATERIALS F ON G.MATERIAL_ID = F.MATERIAL_ID
            //        WHERE A.[DATE] < '" + dtp_FROM.Value.Date + @"' 
            //        GROUP BY F.MATERIAL_ID,F.MATERIAL_NAME
            // ) D ON A.MATERIAL_ID = D.MATERIAL_ID		
            // LEFT JOIN (
            //  SELECT C.MATERIAL_ID,C.MATERIAL_NAME AS [MATERIAL],SUM(B.ITEM_WEIGHT) AS [QTY],
            //  AVG(ISNULL(B.QTY * B.ITEM_RATE,0) / (B.ITEM_WEIGHT)) AS [RATE],
            //  ISNULL(SUM(B.QTY * B.ITEM_RATE),0) AS [AMOUNT],
            //  'OPENING' AS [TYPE]
            //  FROM SALES_RETURN_MASTER A
            //  INNER JOIN SALES_RETURN_DETAIL B ON A.SRM_ID = B.SRM_ID
            //  INNER JOIN MATERIALS C ON B.MATERIAL_ID = C.MATERIAL_ID
            //  WHERE A.[DATE] < '" + dtp_FROM.Value.Date + @"' 
            //  GROUP BY C.MATERIAL_ID,C.MATERIAL_NAME
            // ) E ON A.MATERIAL_ID = E.MATERIAL_ID
            // GROUP BY A.MATERIAL_ID,A.MATERIAL),
            //B AS (
            // --PURCHASES
            // SELECT C.MATERIAL_ID,C.MATERIAL_NAME AS [MATERIAL],SUM(A.NET_WEIGHT) AS [QTY],
            // AVG(A.KG_RATE) AS [RATE],SUM(A.NET_WEIGHT) * AVG(A.KG_RATE) AS [AMOUNT],
            // 'PURCHASES' AS [TYPE]
            // FROM PURCHASES A
            // INNER JOIN PURCHASES_ORDER B ON A.PO_ID = B.PO_ID
            // INNER JOIN MATERIALS C ON B.MATERIAL_ID = C.MATERIAL_ID
            // WHERE A.[DATE] BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
            //    AND A.PI_ID NOT IN (SELECT purchases_id FROM purchases_sales_transfer)
            // GROUP BY C.MATERIAL_ID,C.MATERIAL_NAME),
            //C AS (
            // --SALES
            // SELECT X.MATERIAL_ID,X.MATERIAL,SUM(X.QTY) AS [QTY],
            //    AVG(X.RATE) AS [RATE],SUM(X.AMOUNT) AS [AMOUNT],X.[TYPE]
            //    FROM (
            //    SELECT F.MATERIAL_ID,F.MATERIAL_NAME AS [MATERIAL],SUM(C.WEIGHT) AS [QTY],
            //    AVG(ISNULL(C.QTY * C.RATE,0) / (C.WEIGHT)) AS [RATE],
            //    ISNULL(SUM(C.QTY * C.RATE),0) AS [AMOUNT],
            //    'SALES' AS [TYPE]
            //    FROM SALES A
            //    INNER JOIN SALES_PROGRAM_MASTER B ON A.SOP_ID = B.SPM_ID
            //    INNER JOIN SALES_PROGRAM_DETAILS C ON B.SPM_ID = C.SPM_ID
            //    INNER JOIN SALES_ORDER_PRODUCT_MASTER G ON B.SOD_ID = G.SOPM_ID
            //    INNER JOIN PRODUCT_MASTER D ON C.PRODUCT_ID = D.PM_ID
            //    INNER JOIN PRODUCT_DETAILS E ON D.PM_ID = E.PM_ID
            //    INNER JOIN MATERIALS F ON E.MATERIAL_ID = F.MATERIAL_ID
            //    WHERE A.[DATE] BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"' AND B.SO_TYPE = 'P'
            //    GROUP BY F.MATERIAL_ID,F.MATERIAL_NAME
            //    UNION ALL
            //    SELECT D.MATERIAL_ID,D.MATERIAL_NAME AS [MATERIAL],SUM(C.WEIGHT) AS [QTY],
            //    AVG(ISNULL(C.QTY * C.RATE,0) / (C.WEIGHT)) AS [RATE],
            //    ISNULL(SUM(C.QTY * C.RATE),0) AS [AMOUNT],
            //    'SALES' AS [TYPE]
            //    FROM SALES A
            //    INNER JOIN SALES_PROGRAM_MASTER B ON A.SOP_ID = B.SPM_ID
            //    INNER JOIN SALES_PROGRAM_DETAILS C ON B.SPM_ID = C.SPM_ID
            //    INNER JOIN SALES_ORDER_PRODUCT_MASTER G ON B.SOD_ID = G.SOPM_ID
            //    INNER JOIN MATERIALS D ON C.PRODUCT_ID = D.MATERIAL_ID
            //    WHERE A.[DATE] BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"' AND B.SO_TYPE = 'P'
            //    GROUP BY D.MATERIAL_ID,D.MATERIAL_NAME
            //    UNION ALL
            //    SELECT F.MATERIAL_ID,F.MATERIAL_NAME AS [MATERIAL],SUM(C.WEIGHT) AS [QTY],
            //    AVG(ISNULL(C.QTY * C.RATE,0) / (C.WEIGHT)) AS [RATE],
            //    ISNULL(SUM(C.QTY * C.RATE),0) AS [AMOUNT],
            //    'SALES' AS [TYPE]
            //    FROM SALES A
            //    INNER JOIN SALES_PROGRAM_MASTER B ON A.SOP_ID = B.SPM_ID
            //    INNER JOIN SALES_PROGRAM_DETAILS C ON B.SPM_ID = C.SPM_ID
            //    INNER JOIN SALES_ORDER_DIRECT G ON B.SOD_ID = G.SOD_ID
            //    INNER JOIN PRODUCT_MASTER D ON C.PRODUCT_ID = D.PM_ID
            //    INNER JOIN PRODUCT_DETAILS E ON D.PM_ID = E.PM_ID
            //    INNER JOIN MATERIALS F ON E.MATERIAL_ID = F.MATERIAL_ID
            //    WHERE A.[DATE] BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"' AND B.SO_TYPE = 'D'
            //    GROUP BY F.MATERIAL_ID,F.MATERIAL_NAME
            //    UNION ALL
            //    SELECT D.MATERIAL_ID,D.MATERIAL_NAME AS [MATERIAL],SUM(C.WEIGHT) AS [QTY],
            //    AVG(ISNULL(C.QTY * C.RATE,0) / (C.WEIGHT)) AS [RATE],
            //    ISNULL(SUM(C.QTY * C.RATE),0) AS [AMOUNT],
            //    'SALES' AS [TYPE]
            //    FROM SALES A
            //    INNER JOIN SALES_PROGRAM_MASTER B ON A.SOP_ID = B.SPM_ID
            //    INNER JOIN SALES_PROGRAM_DETAILS C ON B.SPM_ID = C.SPM_ID
            //    INNER JOIN SALES_ORDER_DIRECT G ON B.SOD_ID = G.SOD_ID
            //    INNER JOIN MATERIALS D ON C.PRODUCT_ID = D.MATERIAL_ID
            //    WHERE A.[DATE] BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"' AND B.SO_TYPE = 'D'
            //    GROUP BY D.MATERIAL_ID,D.MATERIAL_NAME) AS X
            //    GROUP BY X.MATERIAL_ID,X.MATERIAL,X.[TYPE]), 
            //D AS (
            // --AA SALES
            // SELECT F.MATERIAL_ID,F.MATERIAL_NAME AS [MATERIAL],SUM(A.sales_weight) AS [QTY],
            // AVG(ISNULL(A.total,0) / (A.sales_weight)) AS [RATE],
            // ISNULL(SUM(A.total),0) AS [AMOUNT],
            // 'SALES' AS [TYPE]
            // FROM AA_SALES A
            // INNER JOIN SALES_ORDER_DIRECT G ON A.SO_ID = G.SOD_ID
            // INNER JOIN MATERIALS F ON G.MATERIAL_ID = F.MATERIAL_ID
            // WHERE A.[DATE] BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
            // GROUP BY F.MATERIAL_ID,F.MATERIAL_NAME),
            //E AS (
            // --SALES RETURN
            // SELECT C.MATERIAL_ID,C.MATERIAL_NAME AS [MATERIAL],SUM(B.ITEM_WEIGHT) AS [QTY],
            // AVG(ISNULL(B.QTY * B.ITEM_RATE,0) / (B.ITEM_WEIGHT)) AS [RATE],
            // ISNULL(SUM(B.QTY * B.ITEM_RATE),0) AS [AMOUNT],
            // 'SALES RETURN' AS [TYPE]
            // FROM SALES_RETURN_MASTER A
            // INNER JOIN SALES_RETURN_DETAIL B ON A.SRM_ID = B.SRM_ID
            // INNER JOIN MATERIALS C ON B.MATERIAL_ID = C.MATERIAL_ID
            // WHERE A.[DATE] BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
            // GROUP BY C.MATERIAL_ID,C.MATERIAL_NAME)

            //SELECT A.MATERIAL,
            // A.QTY AS [OPENING QTY],A.RATE AS [OPENING RATE],A.AMOUNT AS [OPENING AMOUNT],
            // ISNULL(B.QTY,0) AS [PURCHASES QTY],ISNULL(B.RATE,0) AS [PURCHASES RATE],ISNULL(B.AMOUNT,0) AS [PURCHASES AMOUNT],
            // ISNULL(C.QTY,0) AS [SALES QTY],ISNULL(C.AMOUNT / C.QTY,0) AS [SALES RATE],ISNULL(C.AMOUNT,0) AS [SALES AMOUNT],
            // ISNULL(D.QTY,0) AS [AA SALES QTY],ISNULL(D.RATE,0) AS [AA SALES RATE],ISNULL(D.AMOUNT,0) AS [AA SALES AMOUNT],
            // ISNULL(E.QTY,0) AS [SALES RETURN QTY],ISNULL(E.RATE,0) AS [SALES RETURN RATE],ISNULL(E.AMOUNT,0) AS [SALES RETURN AMOUNT],
            //    '" + dtp_FROM.Value.Date + "' as [from],'" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"' as [to]
            //FROM A
            //LEFT JOIN B ON A.MATERIAL_ID = B.MATERIAL_ID
            //LEFT JOIN C ON A.MATERIAL_ID = C.MATERIAL_ID
            //LEFT JOIN D ON A.MATERIAL_ID = D.MATERIAL_ID
            //LEFT JOIN E ON A.MATERIAL_ID = E.MATERIAL_ID
            //ORDER BY A.MATERIAL";

            char hasRows = 'N';
            try
            {
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.cmd.CommandTimeout = 0;
                classHelper.nds = new DataSets.NewDataSet();
                classHelper.adp = new System.Data.SqlClient.SqlDataAdapter(classHelper.cmd);
                classHelper.adp.Fill(classHelper.nds, "RawMaterialReport");

                if (classHelper.nds.Tables["RawMaterialReport"].Rows.Count <= 0)
                {
                    MessageBox.Show("No Record Found.", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    hasRows = 'Y';
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

            if (hasRows == 'Y')
            {
                if (rdbDetailed.Checked == true)
                {
                    classHelper.rpt = new frmReports();
                    classHelper.rpt.GenerateReport("RawMaterialDatewiseReport", classHelper.nds);
                    classHelper.rpt.ShowDialog();
                }
                else
                {
                    classHelper.rpt = new frmReports();
                    classHelper.rpt.GenerateReport("RawMaterialDatewiseReportConsolidated", classHelper.nds);
                    classHelper.rpt.ShowDialog();
                }
            }
        }

        private void grpSALES_Enter(object sender, EventArgs e)
        {
            
        }
        
        private void btnINTER_SAVE_Click(object sender, EventArgs e)
        {
            if (chkDateWise.Checked)
            {
                ShowReportDateWise();
            }
            else
            {
                ShowReport();
            }
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
