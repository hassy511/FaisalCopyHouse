using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ERP_Maaz_Oil.Forms.Reporting
{
    public partial class frm_IncomeStatementComparisionReport : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        public frm_IncomeStatementComparisionReport()
        {
            InitializeComponent();
                    }
        
        private void ShowReport() {
            DateTime startDate = dtp_FROM.Value.Date;
            DateTime endDate = dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            int numberOfMonths = (((endDate.Year - startDate.Year) * 12) + endDate.Month - startDate.Month) + 1;

            string[] months = new string[12];
            int x = 0;
            while (x < 12)
            {
                if (x < numberOfMonths)
                {
                    months[x] = startDate.AddMonths(x).ToString("MMMM", CultureInfo.InvariantCulture).ToUpper();
                }
                else {
                    months[x] = "";
                }
                x++;
            }

            classHelper.query = @"CREATE TABLE IS_DATA(
                SNO INT,
                ACCOUNT_TYPE VARCHAR(MAX),
                ACCOUNT_NAME VARCHAR(MAX),
                MONTH1 FLOAT,
                MONTH2 FLOAT,
                MONTH3 FLOAT,
                MONTH4 FLOAT,
                MONTH5 FLOAT,
                MONTH6 FLOAT,
                MONTH7 FLOAT,
                MONTH8 FLOAT,
                MONTH9 FLOAT,
                MONTH10 FLOAT,
                MONTH11 FLOAT,
                MONTH12 FLOAT,
            );";
            
            //AOI SALES
            classHelper.query += @"INSERT INTO IS_DATA VALUES (1,'SALES','AOI SALES',";
            for (int i = 0; i < 12; i++) {
                DateTime sDate = startDate.AddMonths(i);
                if (i == 0) {
                    sDate = startDate;
                }
                DateTime eDate = startDate.AddMonths(i + 1).AddDays(-1).AddHours(23).AddMinutes(59).AddSeconds(59);

                if (i > numberOfMonths - 1)
                {
                    classHelper.query += @"null,";
                }
                else {
                    classHelper.query += @"(SELECT 
                    (ISNULL((
	                    SELECT SUM((ISNULL(C.QTY,0) * ISNULL(C.RATE,0))) AS [AMOUNT]
	                    FROM SALES A
	                    INNER JOIN SALES_PROGRAM_MASTER B ON A.SOP_ID = B.SPM_ID 
	                    INNER JOIN SALES_PROGRAM_DETAILS C ON B.SPM_ID = C.SPM_ID
	                    WHERE A.DATE BETWEEN '"+sDate+"' AND '"+eDate+ @"'
                    ),0)) +
                    (ISNULL((
	                    SELECT SUM((ISNULL(C.QTY,0) * ISNULL(C.RATE,0))) AS [AMOUNT]
	                    FROM SALES A
	                    INNER JOIN GATE_PASS B ON A.GPM_ID = B.GPM_ID 
	                    INNER JOIN GATE_PASS_DETAIL C ON B.GPM_ID = C.GP_ID
	                    WHERE A.DATE BETWEEN '" + sDate + "' AND '" + eDate + @"'
                    ),0))),";
                }
            }
            classHelper.query = classHelper.query.Remove(classHelper.query.Length - 1, 1);
            classHelper.query += @"); ";

            //AA SALES
            classHelper.query += @"INSERT INTO IS_DATA VALUES (2,'SALES','AA SALES',";
            for (int i = 0; i < 12; i++)
            {
                DateTime sDate = startDate.AddMonths(i);
                if (i == 0)
                {
                    sDate = startDate;
                }
                DateTime eDate = startDate.AddMonths(i + 1).AddDays(-1).AddHours(23).AddMinutes(59).AddSeconds(59);
                if (i == 0)
                {
                    sDate = startDate;
                }
                

                if (i > numberOfMonths - 1)
                {
                    classHelper.query += @"null,";
                }
                else
                {
                    classHelper.query += @"(SELECT SUM(ISNULL(A.total,0)) AS [AMOUNT]
                    FROM AA_SALES A
                    WHERE A.DATE BETWEEN '" + sDate + "' AND '" + eDate + @"'),";
                }
            }
            classHelper.query = classHelper.query.Remove(classHelper.query.Length - 1, 1);
            classHelper.query += @"); ";

            //SALES RETURN
            classHelper.query += @"INSERT INTO IS_DATA VALUES (3,'SALES','SALES RETURN',";
            for (int i = 0; i < 12; i++)
            {
                DateTime sDate = startDate.AddMonths(i);
                if (i == 0)
                {
                    sDate = startDate;
                }
                DateTime eDate = startDate.AddMonths(i + 1).AddDays(-1).AddHours(23).AddMinutes(59).AddSeconds(59);
                if (i == 0)
                {
                    sDate = startDate;
                }


                if (i > numberOfMonths - 1)
                {
                    classHelper.query += @"null,";
                }
                else
                {
                    classHelper.query += @"(SELECT -SUM((ISNULL(B.QTY,0) * ISNULL(B.ITEM_RATE,0))) AS [AMOUNT]
                    FROM SALES_RETURN_MASTER A
                    INNER JOIN SALES_RETURN_DETAIL B ON A.SRM_ID = B.SRM_ID
                    WHERE A.DATE BETWEEN '" + sDate + "' AND '" + eDate + @"'),";
                }
            }
            classHelper.query = classHelper.query.Remove(classHelper.query.Length - 1, 1);
            classHelper.query += @"); ";

            //SALES DISCOUNT
            classHelper.query += @"INSERT INTO IS_DATA VALUES (4,'SALES','SALES DISCOUNT',";
            for (int i = 0; i < 12; i++)
            {
                DateTime sDate = startDate.AddMonths(i);
                if (i == 0)
                {
                    sDate = startDate;
                }
                DateTime eDate = startDate.AddMonths(i + 1).AddDays(-1).AddHours(23).AddMinutes(59).AddSeconds(59);
                if (i == 0)
                {
                    sDate = startDate;
                }


                if (i > numberOfMonths - 1)
                {
                    classHelper.query += @"null,";
                }
                else
                {
                    classHelper.query += @"(SELECT
                    (
	                    SELECT SUM(ISNULL(CREDIT,0)) - SUM(ISNULL(DEBIT,0)) 
	                    FROM LEDGERS 
	                    WHERE COA_ID = 6540
	                    AND DATE BETWEEN '" + sDate + "' AND '" + eDate + @"'
                    )),";
                }
            }
            classHelper.query = classHelper.query.Remove(classHelper.query.Length - 1, 1);
            classHelper.query += @"); ";

            //PURCHASES
            classHelper.query += @"INSERT INTO IS_DATA VALUES (6,'PURCHASES','PURCHASES',";
            for (int i = 0; i < 12; i++)
            {
                DateTime sDate = startDate.AddMonths(i);
                if (i == 0)
                {
                    sDate = startDate;
                }
                DateTime eDate = startDate.AddMonths(i + 1).AddDays(-1).AddHours(23).AddMinutes(59).AddSeconds(59);
                if (i == 0)
                {
                    sDate = startDate;
                }


                if (i > numberOfMonths - 1)
                {
                    classHelper.query += @"null,";
                }
                else
                {
                    classHelper.query += @"(SELECT SUM(DEBIT) - SUM(CREDIT) FROM LEDGERS 
                    WHERE ENTRY_OF = 'PURCHASES' AND REF_ID NOT IN (SELECT purchases_id FROM purchases_sales_transfer)
                    AND DATE BETWEEN '" + sDate + "' AND '" + eDate + @"' AND CREDIT = 0),";

                    //classHelper.query += @"(SELECT (SELECT 
                    //SUM(ROUND((A.NET_WEIGHT * (ROUND(B.MUAND_RATE,0)/37.324)),0))  [AMOUNT]
                    //FROM PURCHASES A
                    //INNER JOIN PURCHASES_ORDER B ON A.PO_ID = B.PO_ID
                    //INNER JOIN MATERIALS C ON B.MATERIAL_ID = C.MATERIAL_ID
                    //WHERE A.DATE BETWEEN '" + sDate + "' AND '" + eDate + @"' 
                    //AND A.PI_ID NOT IN (SELECT purchases_id FROM purchases_sales_transfer)
                    //AND C.MATERIAL_ID = 5003)
                    //+
                    //(SELECT 
                    //SUM(ROUND((A.NET_WEIGHT * (ROUND(B.MUAND_RATE,0)/37.324)),0))  [AMOUNT]
                    //FROM PURCHASES A
                    //INNER JOIN PURCHASES_ORDER B ON A.PO_ID = B.PO_ID
                    //INNER JOIN MATERIALS C ON B.MATERIAL_ID = C.MATERIAL_ID
                    //WHERE A.DATE BETWEEN '" + sDate + "' AND '" + eDate + @"' 
                    //AND A.PI_ID NOT IN (SELECT purchases_id FROM purchases_sales_transfer)
                    //AND C.MATERIAL_ID <> 5003)),";
                }
            }
            classHelper.query = classHelper.query.Remove(classHelper.query.Length - 1, 1);
            classHelper.query += @"); ";

            //PURCHASES DISCOUNT
            classHelper.query += @"INSERT INTO IS_DATA VALUES (6,'PURCHASES','PURCHASES DISCOUNT ',";
            for (int i = 0; i < 12; i++)
            {
                DateTime sDate = startDate.AddMonths(i);
                if (i == 0)
                {
                    sDate = startDate;
                }
                DateTime eDate = startDate.AddMonths(i + 1).AddDays(-1).AddHours(23).AddMinutes(59).AddSeconds(59);
                if (i == 0)
                {
                    sDate = startDate;
                }


                if (i > numberOfMonths - 1)
                {
                    classHelper.query += @"null,";
                }
                else
                {
                    classHelper.query += @"(SELECT
                    (
	                    SELECT SUM(ISNULL(DEBIT,0)) - SUM(ISNULL(CREDIT,0))
	                    FROM LEDGERS 
	                    WHERE COA_ID = 5357 AND
	                    DATE BETWEEN '" + sDate + "' AND '" + eDate + @"' 
                    )),";
                }
            }
            classHelper.query = classHelper.query.Remove(classHelper.query.Length - 1, 1);
            classHelper.query += @"); ";

            //Opening Inventory
            classHelper.query += @"INSERT INTO IS_DATA VALUES (8,'INVENTORY','OPENING INVENTORY',";
            for (int i = 0; i < 12; i++)
            {
                DateTime sDate = startDate.AddMonths(i);
                if (i == 0)
                {
                    sDate = startDate;
                }
                DateTime eDate = startDate.AddMonths(i + 1).AddDays(-1).AddHours(23).AddMinutes(59).AddSeconds(59);
                if (i == 0)
                {
                    sDate = startDate;
                }


                if (i > numberOfMonths - 1)
                {
                    classHelper.query += @"null,";
                }
                else
                {
                    classHelper.query += @"('"+classHelper.GetClosingStockValue(sDate.AddDays(-1).AddHours(23).AddMinutes(59).AddSeconds(59)) +@"'),";
                }
            }
            classHelper.query = classHelper.query.Remove(classHelper.query.Length - 1, 1);
            classHelper.query += @"); ";

            //Closing Inventory
            classHelper.query += @"INSERT INTO IS_DATA VALUES (10,'INVENTORY','CLOSING INVENTORY',";
            for (int i = 0; i < 12; i++)
            {
                DateTime sDate = startDate.AddMonths(i);
                if (i == 0)
                {
                    sDate = startDate;
                }
                DateTime eDate = startDate.AddMonths(i + 1).AddDays(-1).AddHours(23).AddMinutes(59).AddSeconds(59);
                if (i == 0)
                {
                    sDate = startDate;
                }


                if (i > numberOfMonths - 1)
                {
                    classHelper.query += @"null,";
                }
                else
                {
                    classHelper.query += @"('-" + classHelper.GetClosingStockValue(eDate) + @"'),";
                }
            }
            classHelper.query = classHelper.query.Remove(classHelper.query.Length - 1, 1);
            classHelper.query += @"); ";

            //GAIN OR LOSS ON INVENTORY
            classHelper.query += @"INSERT INTO IS_DATA VALUES (11,'INVENTORY','LOSS OR GAIN ON INVENTORY',";
            for (int i = 0; i < 12; i++)
            {
                DateTime sDate = startDate.AddMonths(i);
                if (i == 0)
                {
                    sDate = startDate;
                }
                DateTime eDate = startDate.AddMonths(i + 1).AddDays(-1).AddHours(23).AddMinutes(59).AddSeconds(59);
                if (i == 0)
                {
                    sDate = startDate;
                }


                if (i > numberOfMonths - 1)
                {
                    classHelper.query += @"null,";
                }
                else
                {
                    classHelper.query += @"(
                    SELECT 
                    (
	                    SELECT SUM(ISNULL(DEBIT,0)) - SUM(ISNULL(CREDIT,0)) 
	                    FROM LEDGERS 
	                    WHERE COA_ID = 6565 AND
	                    DATE BETWEEN '" + sDate + "' AND '" + eDate + @"'
                    )),";
                }
            }
            classHelper.query = classHelper.query.Remove(classHelper.query.Length - 1, 1);
            classHelper.query += @"); ";

            //EXPENSES
            classHelper.query += @"INSERT INTO IS_DATA SELECT 14,'EXPENSES',B.COA_NAME,";
            for (int i = 0; i < 12; i++)
            {
                DateTime sDate = startDate.AddMonths(i);
                if (i == 0)
                {
                    sDate = startDate;
                }
                DateTime eDate = startDate.AddMonths(i + 1).AddDays(-1).AddHours(23).AddMinutes(59).AddSeconds(59);
                if (i == 0)
                {
                    sDate = startDate;
                }


                if (i > numberOfMonths - 1)
                {
                    classHelper.query += @"null,";
                }
                else
                {
                    classHelper.query += @"(
	                SELECT ISNULL(SUM(DEBIT),'0') - ISNULL(SUM(CREDIT),'0') 
	                FROM LEDGERS WHERE COA_ID = B.COA_ID
	                AND DATE BETWEEN '" + sDate + "' AND '" + eDate + @"'),";
                }
            }
            classHelper.query = classHelper.query.Remove(classHelper.query.Length - 1, 1);
            classHelper.query += @" FROM COA B WHERE B.CA_ID IN (10, 11, 17, 25, 27);";

            //OTHER INCOME
            classHelper.query += @"INSERT INTO IS_DATA VALUES (17,'PROFIT','OTHER INCOME',";
            for (int i = 0; i < 12; i++)
            {
                DateTime sDate = startDate.AddMonths(i);
                if (i == 0)
                {
                    sDate = startDate;
                }
                DateTime eDate = startDate.AddMonths(i + 1).AddDays(-1).AddHours(23).AddMinutes(59).AddSeconds(59);
                if (i == 0)
                {
                    sDate = startDate;
                }


                if (i > numberOfMonths - 1)
                {
                    classHelper.query += @"null,";
                }
                else
                {
                    classHelper.query += @"(
                    SELECT 
                    (
	                    SELECT SUM(ISNULL(CREDIT,0)) - SUM(ISNULL(DEBIT,0)) 
	                    FROM LEDGERS 
	                    WHERE COA_ID = 5338 AND
	                    DATE BETWEEN '" + sDate + "' AND '" + eDate + @"'
                    )),";
                }
            }
            classHelper.query = classHelper.query.Remove(classHelper.query.Length - 1, 1);
            classHelper.query += @"); ";

            classHelper.query += @"	INSERT INTO IS_DATA
	        select 5 AS [SNO],'SALES','NET SALES',SUM(ISNULL(MONTH1,0)) AS [MONTH 1],SUM(ISNULL(MONTH2,0)) AS [MONTH 2],
	        SUM(ISNULL(MONTH3,0)) AS [MONTH 3],SUM(ISNULL(MONTH4,0)) AS [MONTH 4],SUM(ISNULL(MONTH5,0)) AS [MONTH 5],
	        SUM(ISNULL(MONTH6,0)) AS [MONTH 6],SUM(ISNULL(MONTH7,0)) AS [MONTH 7],SUM(ISNULL(MONTH8,0)) AS [MONTH 8],
	        SUM(ISNULL(MONTH9,0)) AS [MONTH 9],SUM(ISNULL(MONTH10,0)) AS [MONTH 10],SUM(ISNULL(MONTH11,0)) AS [MONTH 11],
	        SUM(ISNULL(MONTH12,0)) AS [MONTH 12]
	        from IS_DATA
	        WHERE ACCOUNT_TYPE = 'SALES'

	        INSERT INTO IS_DATA
	        select 7 AS [SNO],'PURCHASES','NET PURCHASES',SUM(ISNULL(MONTH1,0)) AS [MONTH 1],SUM(ISNULL(MONTH2,0)) AS [MONTH 2],
	        SUM(ISNULL(MONTH3,0)) AS [MONTH 3],SUM(ISNULL(MONTH4,0)) AS [MONTH 4],SUM(ISNULL(MONTH5,0)) AS [MONTH 5],
	        SUM(ISNULL(MONTH6,0)) AS [MONTH 6],SUM(ISNULL(MONTH7,0)) AS [MONTH 7],SUM(ISNULL(MONTH8,0)) AS [MONTH 8],
	        SUM(ISNULL(MONTH9,0)) AS [MONTH 9],SUM(ISNULL(MONTH10,0)) AS [MONTH 10],SUM(ISNULL(MONTH11,0)) AS [MONTH 11],
	        SUM(ISNULL(MONTH12,0)) AS [MONTH 12]
	        from IS_DATA
	        WHERE ACCOUNT_TYPE = 'PURCHASES'


	        INSERT INTO IS_DATA
	        SELECT '9','INVENTORY','GOODS AVAILABLE FOR SALE',
	        A.[MONTH 1] + B.[MONTH 1],A.[MONTH 2] + B.[MONTH 2],A.[MONTH 3] + B.[MONTH 3],A.[MONTH 4] + B.[MONTH 4],
	        A.[MONTH 5] + B.[MONTH 5],A.[MONTH 6] + B.[MONTH 6],A.[MONTH 7] + B.[MONTH 7],A.[MONTH 8] + B.[MONTH 8],
	        A.[MONTH 9] + B.[MONTH 9],A.[MONTH 10] + B.[MONTH 10],A.[MONTH 11] + B.[MONTH 11],A.[MONTH 12] + B.[MONTH 12]
	        FROM
	        (
		        select 0 AS [ID],ACCOUNT_TYPE,ACCOUNT_NAME,ISNULL(MONTH1,0) AS [MONTH 1],ISNULL(MONTH2,0) AS [MONTH 2],ISNULL(MONTH3,0) AS [MONTH 3],
		        ISNULL(MONTH4,0) AS [MONTH 4],ISNULL(MONTH5,0) AS [MONTH 5],ISNULL(MONTH6,0) AS [MONTH 6],ISNULL(MONTH7,0) AS [MONTH 7],
		        ISNULL(MONTH8,0) AS [MONTH 8],ISNULL(MONTH9,0) AS [MONTH 9],ISNULL(MONTH10,0) AS [MONTH 10],ISNULL(MONTH11,0) AS [MONTH 11],
		        ISNULL(MONTH12,0) AS [MONTH 12]
		        from IS_DATA
		        WHERE ACCOUNT_NAME = 'NET PURCHASES'
	        ) AS A
	        INNER JOIN (
		        select 0 AS [ID],ACCOUNT_TYPE,ACCOUNT_NAME,ISNULL(MONTH1,0) AS [MONTH 1],ISNULL(MONTH2,0) AS [MONTH 2],ISNULL(MONTH3,0) AS [MONTH 3],
		        ISNULL(MONTH4,0) AS [MONTH 4],ISNULL(MONTH5,0) AS [MONTH 5],ISNULL(MONTH6,0) AS [MONTH 6],ISNULL(MONTH7,0) AS [MONTH 7],
		        ISNULL(MONTH8,0) AS [MONTH 8],ISNULL(MONTH9,0) AS [MONTH 9],ISNULL(MONTH10,0) AS [MONTH 10],ISNULL(MONTH11,0) AS [MONTH 11],
		        ISNULL(MONTH12,0) AS [MONTH 12]
		        from IS_DATA
		        WHERE ACCOUNT_NAME = 'OPENING INVENTORY'
	        ) B ON A.ID = B.ID

            INSERT INTO IS_DATA
	        SELECT '12','INVENTORY','COST OF GOODS SOLD',
	        A.[MONTH 1] + B.[MONTH 1] + C.[MONTH 1],
			A.[MONTH 2] + B.[MONTH 2] + C.[MONTH 2],
			A.[MONTH 3] + B.[MONTH 3] + C.[MONTH 3],
			A.[MONTH 4] + B.[MONTH 4] + C.[MONTH 4],
	        A.[MONTH 5] + B.[MONTH 5] + C.[MONTH 5],
			A.[MONTH 6] + B.[MONTH 6] + C.[MONTH 6],
			A.[MONTH 7] + B.[MONTH 7] + C.[MONTH 7],
			A.[MONTH 8] + B.[MONTH 8] + C.[MONTH 8],
	        A.[MONTH 9] + B.[MONTH 9] + C.[MONTH 9],
			A.[MONTH 10] + B.[MONTH 10] + C.[MONTH 10],
			A.[MONTH 11] + B.[MONTH 11] + C.[MONTH 11],
			A.[MONTH 12] + B.[MONTH 12] + C.[MONTH 12]
	        FROM
	        (
		        select 0 AS [ID],ACCOUNT_TYPE,ACCOUNT_NAME,ISNULL(MONTH1,0) AS [MONTH 1],ISNULL(MONTH2,0) AS [MONTH 2],ISNULL(MONTH3,0) AS [MONTH 3],
		        ISNULL(MONTH4,0) AS [MONTH 4],ISNULL(MONTH5,0) AS [MONTH 5],ISNULL(MONTH6,0) AS [MONTH 6],ISNULL(MONTH7,0) AS [MONTH 7],
		        ISNULL(MONTH8,0) AS [MONTH 8],ISNULL(MONTH9,0) AS [MONTH 9],ISNULL(MONTH10,0) AS [MONTH 10],ISNULL(MONTH11,0) AS [MONTH 11],
		        ISNULL(MONTH12,0) AS [MONTH 12]
		        from IS_DATA
		        WHERE ACCOUNT_NAME = 'GOODS AVAILABLE FOR SALE'
	        ) AS A
	        INNER JOIN (
		        select 0 AS [ID],ACCOUNT_TYPE,ACCOUNT_NAME,ISNULL(MONTH1,0) AS [MONTH 1],ISNULL(MONTH2,0) AS [MONTH 2],ISNULL(MONTH3,0) AS [MONTH 3],
		        ISNULL(MONTH4,0) AS [MONTH 4],ISNULL(MONTH5,0) AS [MONTH 5],ISNULL(MONTH6,0) AS [MONTH 6],ISNULL(MONTH7,0) AS [MONTH 7],
		        ISNULL(MONTH8,0) AS [MONTH 8],ISNULL(MONTH9,0) AS [MONTH 9],ISNULL(MONTH10,0) AS [MONTH 10],ISNULL(MONTH11,0) AS [MONTH 11],
		        ISNULL(MONTH12,0) AS [MONTH 12]
		        from IS_DATA
		        WHERE ACCOUNT_NAME = 'CLOSING INVENTORY'
	        ) B ON A.ID = B.ID 
			INNER JOIN (
		        select 0 AS [ID],ACCOUNT_TYPE,ACCOUNT_NAME,ISNULL(MONTH1,0) AS [MONTH 1],ISNULL(MONTH2,0) AS [MONTH 2],ISNULL(MONTH3,0) AS [MONTH 3],
		        ISNULL(MONTH4,0) AS [MONTH 4],ISNULL(MONTH5,0) AS [MONTH 5],ISNULL(MONTH6,0) AS [MONTH 6],ISNULL(MONTH7,0) AS [MONTH 7],
		        ISNULL(MONTH8,0) AS [MONTH 8],ISNULL(MONTH9,0) AS [MONTH 9],ISNULL(MONTH10,0) AS [MONTH 10],ISNULL(MONTH11,0) AS [MONTH 11],
		        ISNULL(MONTH12,0) AS [MONTH 12]
		        from IS_DATA
		        WHERE ACCOUNT_NAME = 'LOSS OR GAIN ON INVENTORY'
	        ) C ON A.ID = B.ID 

            INSERT INTO IS_DATA
	        SELECT '13','INVENTORY','GROSS PROFIT',
	        A.[MONTH 1] - B.[MONTH 1],A.[MONTH 2] - B.[MONTH 2],A.[MONTH 3] - B.[MONTH 3],A.[MONTH 4] - B.[MONTH 4],
	        A.[MONTH 5] - B.[MONTH 5],A.[MONTH 6] - B.[MONTH 6],A.[MONTH 7] - B.[MONTH 7],A.[MONTH 8] - B.[MONTH 8],
	        A.[MONTH 9] - B.[MONTH 9],A.[MONTH 10] - B.[MONTH 10],A.[MONTH 11] - B.[MONTH 11],A.[MONTH 12] - B.[MONTH 12]
	        FROM
	        (
		        select 0 AS [ID],ACCOUNT_TYPE,ACCOUNT_NAME,ISNULL(MONTH1,0) AS [MONTH 1],ISNULL(MONTH2,0) AS [MONTH 2],ISNULL(MONTH3,0) AS [MONTH 3],
		        ISNULL(MONTH4,0) AS [MONTH 4],ISNULL(MONTH5,0) AS [MONTH 5],ISNULL(MONTH6,0) AS [MONTH 6],ISNULL(MONTH7,0) AS [MONTH 7],
		        ISNULL(MONTH8,0) AS [MONTH 8],ISNULL(MONTH9,0) AS [MONTH 9],ISNULL(MONTH10,0) AS [MONTH 10],ISNULL(MONTH11,0) AS [MONTH 11],
		        ISNULL(MONTH12,0) AS [MONTH 12]
		        from IS_DATA
		        WHERE ACCOUNT_NAME = 'NET SALES'
	        ) AS A
	        INNER JOIN (
		        select 0 AS [ID],ACCOUNT_TYPE,ACCOUNT_NAME,ISNULL(MONTH1,0) AS [MONTH 1],ISNULL(MONTH2,0) AS [MONTH 2],ISNULL(MONTH3,0) AS [MONTH 3],
		        ISNULL(MONTH4,0) AS [MONTH 4],ISNULL(MONTH5,0) AS [MONTH 5],ISNULL(MONTH6,0) AS [MONTH 6],ISNULL(MONTH7,0) AS [MONTH 7],
		        ISNULL(MONTH8,0) AS [MONTH 8],ISNULL(MONTH9,0) AS [MONTH 9],ISNULL(MONTH10,0) AS [MONTH 10],ISNULL(MONTH11,0) AS [MONTH 11],
		        ISNULL(MONTH12,0) AS [MONTH 12]
		        from IS_DATA
		        WHERE ACCOUNT_NAME = 'COST OF GOODS SOLD'
	        ) B ON A.ID = B.ID 

			INSERT INTO IS_DATA
	        select 15 AS [SNO],'EXPENSES','TOTAL EXPENSES',SUM(ISNULL(MONTH1,0)) AS [MONTH 1],SUM(ISNULL(MONTH2,0)) AS [MONTH 2],
	        SUM(ISNULL(MONTH3,0)) AS [MONTH 3],SUM(ISNULL(MONTH4,0)) AS [MONTH 4],SUM(ISNULL(MONTH5,0)) AS [MONTH 5],
	        SUM(ISNULL(MONTH6,0)) AS [MONTH 6],SUM(ISNULL(MONTH7,0)) AS [MONTH 7],SUM(ISNULL(MONTH8,0)) AS [MONTH 8],
	        SUM(ISNULL(MONTH9,0)) AS [MONTH 9],SUM(ISNULL(MONTH10,0)) AS [MONTH 10],SUM(ISNULL(MONTH11,0)) AS [MONTH 11],
	        SUM(ISNULL(MONTH12,0)) AS [MONTH 12]
	        from IS_DATA
	        WHERE ACCOUNT_TYPE = 'EXPENSES'

			INSERT INTO IS_DATA
	        SELECT '16','PROFIT','OPERATING PROFIT',
	        A.[MONTH 1] - B.[MONTH 1],A.[MONTH 2] - B.[MONTH 2],A.[MONTH 3] - B.[MONTH 3],A.[MONTH 4] - B.[MONTH 4],
	        A.[MONTH 5] - B.[MONTH 5],A.[MONTH 6] - B.[MONTH 6],A.[MONTH 7] - B.[MONTH 7],A.[MONTH 8] - B.[MONTH 8],
	        A.[MONTH 9] - B.[MONTH 9],A.[MONTH 10] - B.[MONTH 10],A.[MONTH 11] - B.[MONTH 11],A.[MONTH 12] - B.[MONTH 12]
	        FROM
	        (
		        select 0 AS [ID],ACCOUNT_TYPE,ACCOUNT_NAME,ISNULL(MONTH1,0) AS [MONTH 1],ISNULL(MONTH2,0) AS [MONTH 2],ISNULL(MONTH3,0) AS [MONTH 3],
		        ISNULL(MONTH4,0) AS [MONTH 4],ISNULL(MONTH5,0) AS [MONTH 5],ISNULL(MONTH6,0) AS [MONTH 6],ISNULL(MONTH7,0) AS [MONTH 7],
		        ISNULL(MONTH8,0) AS [MONTH 8],ISNULL(MONTH9,0) AS [MONTH 9],ISNULL(MONTH10,0) AS [MONTH 10],ISNULL(MONTH11,0) AS [MONTH 11],
		        ISNULL(MONTH12,0) AS [MONTH 12]
		        from IS_DATA
		        WHERE ACCOUNT_NAME = 'GROSS PROFIT'
	        ) AS A
	        INNER JOIN (
		        select 0 AS [ID],ACCOUNT_TYPE,ACCOUNT_NAME,ISNULL(MONTH1,0) AS [MONTH 1],ISNULL(MONTH2,0) AS [MONTH 2],ISNULL(MONTH3,0) AS [MONTH 3],
		        ISNULL(MONTH4,0) AS [MONTH 4],ISNULL(MONTH5,0) AS [MONTH 5],ISNULL(MONTH6,0) AS [MONTH 6],ISNULL(MONTH7,0) AS [MONTH 7],
		        ISNULL(MONTH8,0) AS [MONTH 8],ISNULL(MONTH9,0) AS [MONTH 9],ISNULL(MONTH10,0) AS [MONTH 10],ISNULL(MONTH11,0) AS [MONTH 11],
		        ISNULL(MONTH12,0) AS [MONTH 12]
		        from IS_DATA
		        WHERE ACCOUNT_NAME = 'TOTAL EXPENSES'
	        ) B ON A.ID = B.ID 

            INSERT INTO IS_DATA
	        SELECT '18','PROFIT','NET PROFIT',
	        A.[MONTH 1] + B.[MONTH 1],A.[MONTH 2] + B.[MONTH 2],A.[MONTH 3] + B.[MONTH 3],A.[MONTH 4] + B.[MONTH 4],
	        A.[MONTH 5] + B.[MONTH 5],A.[MONTH 6] + B.[MONTH 6],A.[MONTH 7] + B.[MONTH 7],A.[MONTH 8] + B.[MONTH 8],
	        A.[MONTH 9] + B.[MONTH 9],A.[MONTH 10] + B.[MONTH 10],A.[MONTH 11] + B.[MONTH 11],A.[MONTH 12] + B.[MONTH 12]
	        FROM
	        (
		        select 0 AS [ID],ACCOUNT_TYPE,ACCOUNT_NAME,ISNULL(MONTH1,0) AS [MONTH 1],ISNULL(MONTH2,0) AS [MONTH 2],ISNULL(MONTH3,0) AS [MONTH 3],
		        ISNULL(MONTH4,0) AS [MONTH 4],ISNULL(MONTH5,0) AS [MONTH 5],ISNULL(MONTH6,0) AS [MONTH 6],ISNULL(MONTH7,0) AS [MONTH 7],
		        ISNULL(MONTH8,0) AS [MONTH 8],ISNULL(MONTH9,0) AS [MONTH 9],ISNULL(MONTH10,0) AS [MONTH 10],ISNULL(MONTH11,0) AS [MONTH 11],
		        ISNULL(MONTH12,0) AS [MONTH 12]
		        from IS_DATA
		        WHERE ACCOUNT_NAME = 'OPERATING PROFIT'
	        ) AS A
	        INNER JOIN (
		        select 0 AS [ID],ACCOUNT_TYPE,ACCOUNT_NAME,ISNULL(MONTH1,0) AS [MONTH 1],ISNULL(MONTH2,0) AS [MONTH 2],ISNULL(MONTH3,0) AS [MONTH 3],
		        ISNULL(MONTH4,0) AS [MONTH 4],ISNULL(MONTH5,0) AS [MONTH 5],ISNULL(MONTH6,0) AS [MONTH 6],ISNULL(MONTH7,0) AS [MONTH 7],
		        ISNULL(MONTH8,0) AS [MONTH 8],ISNULL(MONTH9,0) AS [MONTH 9],ISNULL(MONTH10,0) AS [MONTH 10],ISNULL(MONTH11,0) AS [MONTH 11],
		        ISNULL(MONTH12,0) AS [MONTH 12]
		        from IS_DATA
		        WHERE ACCOUNT_NAME = 'OTHER INCOME'
	        ) B ON A.ID = B.ID ";


            classHelper.query += @" select ACCOUNT_TYPE,ACCOUNT_NAME,ISNULL(MONTH1,0) AS [MONTH 1],ISNULL(MONTH2,0) AS [MONTH 2],ISNULL(MONTH3,0) AS [MONTH 3],
            ISNULL(MONTH4,0) AS [MONTH 4],ISNULL(MONTH5,0) AS [MONTH 5],ISNULL(MONTH6,0) AS [MONTH 6],ISNULL(MONTH7,0) AS [MONTH 7],
            ISNULL(MONTH8,0) AS [MONTH 8],ISNULL(MONTH9,0) AS [MONTH 9],ISNULL(MONTH10,0) AS [MONTH 10],ISNULL(MONTH11,0) AS [MONTH 11],
            ISNULL(MONTH12,0) AS [MONTH 12]
            from IS_DATA
            ORDER BY SNO;

            DROP TABLE IS_DATA;";
        
        char hasRows = 'Y';
           try
            {
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    classHelper.nds.Tables["IS_Comparision"].Clear();
                    while (classHelper.dr.Read())
                    {
                        classHelper.dataR = classHelper.nds.Tables["IS_Comparision"].NewRow();
                        classHelper.dataR["Type"] = classHelper.dr["ACCOUNT_TYPE"].ToString();
                        classHelper.dataR["name"] = classHelper.dr["ACCOUNT_NAME"].ToString();
                        classHelper.dataR["Month1"] = Convert.ToDecimal(classHelper.dr["MONTH 1"].ToString());
                        classHelper.dataR["Month2"] = Convert.ToDecimal(classHelper.dr["MONTH 2"].ToString());
                        classHelper.dataR["Month3"] = Convert.ToDecimal(classHelper.dr["MONTH 3"].ToString());
                        classHelper.dataR["Month4"] = Convert.ToDecimal(classHelper.dr["MONTH 4"].ToString());
                        classHelper.dataR["Month5"] = Convert.ToDecimal(classHelper.dr["MONTH 5"].ToString());
                        classHelper.dataR["Month6"] = Convert.ToDecimal(classHelper.dr["MONTH 6"].ToString());
                        classHelper.dataR["Month7"] = Convert.ToDecimal(classHelper.dr["MONTH 7"].ToString());
                        classHelper.dataR["Month8"] = Convert.ToDecimal(classHelper.dr["MONTH 8"].ToString());
                        classHelper.dataR["Month9"] = Convert.ToDecimal(classHelper.dr["MONTH 9"].ToString());
                        classHelper.dataR["Month10"] = Convert.ToDecimal(classHelper.dr["MONTH 10"].ToString());
                        classHelper.dataR["Month11"] = Convert.ToDecimal(classHelper.dr["MONTH 11"].ToString());
                        classHelper.dataR["Month12"] = Convert.ToDecimal(classHelper.dr["MONTH 12"].ToString());
                        classHelper.nds.Tables["IS_Comparision"].Rows.Add(classHelper.dataR);
                    }
                }
                else
                {
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

            if (hasRows == 'Y')
            {
                classHelper.rpt = new frmReports();
                classHelper.rpt.GenerateReport("IncomeStatementComparision", classHelper.nds,months);
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
