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
    public partial class frm_SalesInvoiceReportProvinceSP : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        public frm_SalesInvoiceReportProvinceSP()
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
            classHelper.query = @"create table #temp1(
                sales_person varchar(max),
                province varchar(max),
                canolaWeight float,
                canolaAmount float,
                canolaRate float
                )
                insert into #temp1
                SELECT F.NAME AS [SALES PERSON],J.REGION_NAME AS [PROVINCE],
                SUM((C.WEIGHT)) AS [CANOLA TOTAL WEIGHT],SUM((C.QTY) * C.RATE) AS [CANOLA AMOUNT],
                SUM((C.QTY) * C.RATE) / SUM((C.WEIGHT)) AS [CANOLA AVG RATE]
                FROM SALES A
                INNER JOIN SALES_PROGRAM_MASTER B ON A.SOP_ID = B.SPM_ID
                INNER JOIN SALES_PROGRAM_DETAILS C ON B.SPM_ID = C.SPM_ID
                INNER JOIN PRODUCT_MASTER D ON C.PRODUCT_ID = D.PM_ID
                INNER JOIN PRODUCT_DETAILS E ON D.PM_ID = E.PM_ID
                INNER JOIN COA G ON B.CUSTOMER_ID = G.COA_ID
                INNER JOIN CUSTOMER_PROFILE H ON H.COA_ID = G.COA_ID
                INNER JOIN SALES_PERSONS F ON H.SALE_PER_ID = F.SALES_PER_ID
                INNER JOIN CITY I ON H.CITY_ID = I.CITY_ID
                INNER JOIN REGION J ON I.REG_ID = J.REGION_ID
                WHERE E.MATERIAL_ID = '5005' 
                AND A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
                GROUP BY F.NAME,J.REGION_NAME
                UNION ALL
                SELECT F.NAME AS [SALES PERSON],J.REGION_NAME AS [PROVINCE],
                SUM((C.WEIGHT)) AS [CANOLA TOTAL WEIGHT],SUM((C.QTY) * C.RATE) AS [CANOLA AMOUNT],
                SUM((C.QTY) * C.RATE) / SUM((C.WEIGHT)) AS [CANOLA AVG RATE]
                FROM SALES A
                INNER JOIN SALES_PROGRAM_MASTER B ON A.SOP_ID = B.SPM_ID
                INNER JOIN SALES_PROGRAM_DETAILS C ON B.SPM_ID = C.SPM_ID
                INNER JOIN MATERIALS E ON C.PRODUCT_ID = E.MATERIAL_ID
                INNER JOIN COA G ON B.CUSTOMER_ID = G.COA_ID
                INNER JOIN CUSTOMER_PROFILE H ON H.COA_ID = G.COA_ID
                INNER JOIN SALES_PERSONS F ON H.SALE_PER_ID = F.SALES_PER_ID
                INNER JOIN CITY I ON H.CITY_ID = I.CITY_ID
                INNER JOIN REGION J ON I.REG_ID = J.REGION_ID
                WHERE E.MATERIAL_ID = '5005' 
                AND A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
                GROUP BY F.NAME,J.REGION_NAME
				UNION ALL
				SELECT F.NAME AS [SALES PERSON],J.REGION_NAME AS [PROVINCE],
                SUM((C.WEIGHT)) AS [CANOLA TOTAL WEIGHT],SUM((C.QTY) * C.RATE) AS [CANOLA AMOUNT],
                SUM((C.QTY) * C.RATE) / SUM((C.WEIGHT)) AS [CANOLA AVG RATE]
                FROM SALES A
                INNER JOIN GATE_PASS B ON A.GPM_ID = B.GPM_ID
                INNER JOIN GATE_PASS_DETAIL C ON B.GPM_ID = C.GP_ID
                INNER JOIN PRODUCT_MASTER D ON C.PRODUCT_ID = D.PM_ID
                INNER JOIN PRODUCT_DETAILS E ON D.PM_ID = E.PM_ID
                INNER JOIN COA G ON A.CUSTOMER_ID = G.COA_ID
                INNER JOIN CUSTOMER_PROFILE H ON H.COA_ID = G.COA_ID
                INNER JOIN SALES_PERSONS F ON H.SALE_PER_ID = F.SALES_PER_ID
                INNER JOIN CITY I ON H.CITY_ID = I.CITY_ID
                INNER JOIN REGION J ON I.REG_ID = J.REGION_ID
                WHERE E.MATERIAL_ID = '5005' 
                AND A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
                GROUP BY F.NAME,J.REGION_NAME
                UNION ALL
                SELECT F.NAME AS [SALES PERSON],J.REGION_NAME AS [PROVINCE],
                SUM((C.WEIGHT)) AS [CANOLA TOTAL WEIGHT],SUM((C.QTY) * C.RATE) AS [CANOLA AMOUNT],
                SUM((C.QTY) * C.RATE) / SUM((C.WEIGHT)) AS [CANOLA AVG RATE]
                FROM SALES A
                INNER JOIN GATE_PASS B ON A.GPM_ID = B.GPM_ID
                INNER JOIN GATE_PASS_DETAIL C ON B.GPM_ID = C.GP_ID
                INNER JOIN MATERIALS E ON C.PRODUCT_ID = E.MATERIAL_ID
                INNER JOIN COA G ON A.CUSTOMER_ID = G.COA_ID
                INNER JOIN CUSTOMER_PROFILE H ON H.COA_ID = G.COA_ID
                INNER JOIN SALES_PERSONS F ON H.SALE_PER_ID = F.SALES_PER_ID
                INNER JOIN CITY I ON H.CITY_ID = I.CITY_ID
                INNER JOIN REGION J ON I.REG_ID = J.REGION_ID
                WHERE E.MATERIAL_ID = '5005' 
                AND A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
                GROUP BY F.NAME,J.REGION_NAME

                create table #temp2(
                sales_person varchar(max),
                province varchar(max),
                olienWeight float,
                olienAmount float,
                olienRate float
                )

                insert into #temp2
                SELECT F.NAME AS[SALES PERSON], J.REGION_NAME AS[PROVINCE],
                SUM((C.WEIGHT)) AS[OLIEN TOTAL WEIGHT], SUM((C.QTY) * C.RATE) AS[OLIEN AMOUNT],
                SUM((C.QTY) * C.RATE) / SUM((C.WEIGHT)) AS[OLIEN AVG RATE]
                FROM SALES A
                INNER JOIN SALES_PROGRAM_MASTER B ON A.SOP_ID = B.SPM_ID
                INNER JOIN SALES_PROGRAM_DETAILS C ON B.SPM_ID = C.SPM_ID
                INNER JOIN PRODUCT_MASTER D ON C.PRODUCT_ID = D.PM_ID
                INNER JOIN PRODUCT_DETAILS E ON D.PM_ID = E.PM_ID
                INNER JOIN COA G ON B.CUSTOMER_ID = G.COA_ID
                INNER JOIN CUSTOMER_PROFILE H ON H.COA_ID = G.COA_ID
                INNER JOIN SALES_PERSONS F ON H.SALE_PER_ID = F.SALES_PER_ID
                INNER JOIN CITY I ON H.CITY_ID = I.CITY_ID
                INNER JOIN REGION J ON I.REG_ID = J.REGION_ID
                WHERE E.MATERIAL_ID = '5003'
                AND A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
                GROUP BY F.NAME, J.REGION_NAME
                UNION ALL
                SELECT F.NAME AS[SALES PERSON], J.REGION_NAME AS[PROVINCE],
                SUM((C.WEIGHT)) AS[OLIEN TOTAL WEIGHT], SUM((C.QTY) * C.RATE) AS[OLIEN AMOUNT],
                SUM((C.QTY) * C.RATE) / SUM((C.WEIGHT)) AS[OLIEN AVG RATE]
                FROM SALES A
                INNER JOIN SALES_PROGRAM_MASTER B ON A.SOP_ID = B.SPM_ID
                INNER JOIN SALES_PROGRAM_DETAILS C ON B.SPM_ID = C.SPM_ID
                INNER JOIN MATERIALS E ON C.PRODUCT_ID = E.MATERIAL_ID
                INNER JOIN COA G ON B.CUSTOMER_ID = G.COA_ID
                INNER JOIN CUSTOMER_PROFILE H ON H.COA_ID = G.COA_ID
                INNER JOIN SALES_PERSONS F ON H.SALE_PER_ID = F.SALES_PER_ID
                INNER JOIN CITY I ON H.CITY_ID = I.CITY_ID
                INNER JOIN REGION J ON I.REG_ID = J.REGION_ID
                WHERE E.MATERIAL_ID = '5003'
                AND A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
                GROUP BY F.NAME, J.REGION_NAME
				UNION ALL
				SELECT F.NAME AS[SALES PERSON], J.REGION_NAME AS[PROVINCE],
                SUM((C.WEIGHT)) AS[OLIEN TOTAL WEIGHT], SUM((C.QTY) * C.RATE) AS[OLIEN AMOUNT],
                SUM((C.QTY) * C.RATE) / SUM((C.WEIGHT)) AS[OLIEN AVG RATE]
                FROM SALES A
                INNER JOIN GATE_PASS B ON A.GPM_ID = B.GPM_ID
                INNER JOIN GATE_PASS_DETAIL C ON B.GPM_ID = C.GP_ID
                INNER JOIN PRODUCT_MASTER D ON C.PRODUCT_ID = D.PM_ID
                INNER JOIN PRODUCT_DETAILS E ON D.PM_ID = E.PM_ID
                INNER JOIN COA G ON A.CUSTOMER_ID = G.COA_ID
                INNER JOIN CUSTOMER_PROFILE H ON H.COA_ID = G.COA_ID
                INNER JOIN SALES_PERSONS F ON H.SALE_PER_ID = F.SALES_PER_ID
                INNER JOIN CITY I ON H.CITY_ID = I.CITY_ID
                INNER JOIN REGION J ON I.REG_ID = J.REGION_ID
                WHERE E.MATERIAL_ID = '5003'
                AND A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
                GROUP BY F.NAME, J.REGION_NAME
                UNION ALL
                SELECT F.NAME AS[SALES PERSON], J.REGION_NAME AS[PROVINCE],
                SUM((C.WEIGHT)) AS[OLIEN TOTAL WEIGHT], SUM((C.QTY) * C.RATE) AS[OLIEN AMOUNT],
                SUM((C.QTY) * C.RATE) / SUM((C.WEIGHT)) AS[OLIEN AVG RATE]
                FROM SALES A
                INNER JOIN GATE_PASS B ON A.GPM_ID = B.GPM_ID
                INNER JOIN GATE_PASS_DETAIL C ON B.GPM_ID = C.GP_ID
                INNER JOIN MATERIALS E ON C.PRODUCT_ID = E.MATERIAL_ID
                INNER JOIN COA G ON A.CUSTOMER_ID = G.COA_ID
                INNER JOIN CUSTOMER_PROFILE H ON H.COA_ID = G.COA_ID
                INNER JOIN SALES_PERSONS F ON H.SALE_PER_ID = F.SALES_PER_ID
                INNER JOIN CITY I ON H.CITY_ID = I.CITY_ID
                INNER JOIN REGION J ON I.REG_ID = J.REGION_ID
                WHERE E.MATERIAL_ID = '5003'
                AND A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
                GROUP BY F.NAME, J.REGION_NAME

                select x.sales_person,x.province,
                ISNULL(a.olienWeight,'0') AS [olienWeight],ISNULL(a.olienAmount,'0') AS olienAmount,
                ISNULL(a.olienRate,'0') AS olienRate,ISNULL(x.canolaWeight,'0') AS canolaWeight,
                ISNULL(x.canolaAmount,'0') AS canolaAmount,ISNULL(x.canolaRate,'0') AS canolaRate
                from #temp2 a
                right join(
                select * from #temp1
                union all
                SELECT p.sales_person, p.province, null, null, null FROM #temp2 p WHERE
                p.sales_person not in (select q.sales_person from #temp1 q where q.province = p.province)
                GROUP BY p.sales_person, p.province
                ) x on x.sales_person = a.sales_person and x.province = a.province
                order by [sales_person]
                drop table #temp1
                drop table #temp2";
            

            char hasRows = 'N';
            try
            {
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    hasRows = 'Y';
                    classHelper.mds.Tables["ProvinceWiseReport"].Clear();
                    while (classHelper.dr.Read())
                    {
                        classHelper.dataR = classHelper.mds.Tables["ProvinceWiseReport"].NewRow();
                        classHelper.dataR["from"] = dtp_FROM.Value.Date;
                        classHelper.dataR["to"] = dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                        classHelper.dataR["salePerson"] = classHelper.dr["sales_person"].ToString();
                        classHelper.dataR["province"] = classHelper.dr["province"].ToString();
                        classHelper.dataR["canolaWeight"] = Convert.ToDecimal(classHelper.dr["canolaWeight"].ToString());
                        classHelper.dataR["canolaRate"] = Convert.ToDecimal(classHelper.dr["canolaRate"].ToString());
                        classHelper.dataR["canolaTotal"] = Convert.ToDecimal(classHelper.dr["canolaAmount"].ToString());
                        classHelper.dataR["olienWeight"] = Convert.ToDecimal(classHelper.dr["olienWeight"].ToString());
                        classHelper.dataR["olienRate"] = Convert.ToDecimal(classHelper.dr["olienRate"].ToString());
                        classHelper.dataR["olienTotal"] = Convert.ToDecimal(classHelper.dr["olienAmount"].ToString());
                        classHelper.mds.Tables["ProvinceWiseReport"].Rows.Add(classHelper.dataR);
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

            classHelper.query = @"create table #temp1(
                province varchar(max),
                canolaWeight float,
                canolaAmount float,
                canolaRate float
                )
                insert into #temp1
            SELECT J.REGION_NAME AS [PROVINCE],
            SUM((C.WEIGHT)) AS [CANOLA TOTAL WEIGHT],SUM((C.QTY) * C.RATE) AS [CANOLA AMOUNT],
            SUM((C.QTY) * C.RATE) / SUM((C.WEIGHT)) AS [CANOLA AVG RATE]
            FROM SALES A
            INNER JOIN SALES_PROGRAM_MASTER B ON A.SOP_ID = B.SPM_ID
            INNER JOIN SALES_PROGRAM_DETAILS C ON B.SPM_ID = C.SPM_ID
            INNER JOIN PRODUCT_MASTER D ON C.PRODUCT_ID = D.PM_ID
            INNER JOIN PRODUCT_DETAILS E ON D.PM_ID = E.PM_ID
            INNER JOIN COA G ON B.CUSTOMER_ID = G.COA_ID
            INNER JOIN CUSTOMER_PROFILE H ON H.COA_ID = G.COA_ID
            INNER JOIN CITY I ON H.CITY_ID = I.CITY_ID
            INNER JOIN REGION J ON I.REG_ID = J.REGION_ID
            WHERE E.MATERIAL_ID = '5005'
            AND A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
            GROUP BY J.REGION_NAME
            UNION ALL
            SELECT J.REGION_NAME AS [PROVINCE],
            SUM((C.WEIGHT)) AS [CANOLA TOTAL WEIGHT],SUM((C.QTY) * C.RATE) AS [CANOLA AMOUNT],
            SUM((C.QTY) * C.RATE) / SUM((C.WEIGHT)) AS [CANOLA AVG RATE]
            FROM SALES A
            INNER JOIN SALES_PROGRAM_MASTER B ON A.SOP_ID = B.SPM_ID
            INNER JOIN SALES_PROGRAM_DETAILS C ON B.SPM_ID = C.SPM_ID
            INNER JOIN MATERIALS E ON C.PRODUCT_ID = E.MATERIAL_ID
            INNER JOIN COA G ON B.CUSTOMER_ID = G.COA_ID
            INNER JOIN CUSTOMER_PROFILE H ON H.COA_ID = G.COA_ID
            INNER JOIN CITY I ON H.CITY_ID = I.CITY_ID
            INNER JOIN REGION J ON I.REG_ID = J.REGION_ID
            WHERE E.MATERIAL_ID = '5005'
            AND A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
            GROUP BY J.REGION_NAME
			UNION ALL
			SELECT J.REGION_NAME AS [PROVINCE],
            SUM((C.WEIGHT)) AS [CANOLA TOTAL WEIGHT],SUM((C.QTY) * C.RATE) AS [CANOLA AMOUNT],
            SUM((C.QTY) * C.RATE) / SUM((C.WEIGHT)) AS [CANOLA AVG RATE]
            FROM SALES A
            INNER JOIN GATE_PASS B ON A.GPM_ID = B.GPM_ID
            INNER JOIN GATE_PASS_DETAIL C ON B.GPM_ID = C.GP_ID
            INNER JOIN PRODUCT_MASTER D ON C.PRODUCT_ID = D.PM_ID
            INNER JOIN PRODUCT_DETAILS E ON D.PM_ID = E.PM_ID
            INNER JOIN COA G ON A.CUSTOMER_ID = G.COA_ID
            INNER JOIN CUSTOMER_PROFILE H ON H.COA_ID = G.COA_ID
            INNER JOIN CITY I ON H.CITY_ID = I.CITY_ID
            INNER JOIN REGION J ON I.REG_ID = J.REGION_ID
            WHERE E.MATERIAL_ID = '5005'
            AND A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
            GROUP BY J.REGION_NAME
            UNION ALL
            SELECT J.REGION_NAME AS [PROVINCE],
            SUM((C.WEIGHT)) AS [CANOLA TOTAL WEIGHT],SUM((C.QTY) * C.RATE) AS [CANOLA AMOUNT],
            SUM((C.QTY) * C.RATE) / SUM((C.WEIGHT)) AS [CANOLA AVG RATE]
            FROM SALES A
            INNER JOIN GATE_PASS B ON A.GPM_ID = B.GPM_ID
            INNER JOIN GATE_PASS_DETAIL C ON B.GPM_ID = C.GP_ID
            INNER JOIN MATERIALS E ON C.PRODUCT_ID = E.MATERIAL_ID
            INNER JOIN COA G ON A.CUSTOMER_ID = G.COA_ID
            INNER JOIN CUSTOMER_PROFILE H ON H.COA_ID = G.COA_ID
            INNER JOIN CITY I ON H.CITY_ID = I.CITY_ID
            INNER JOIN REGION J ON I.REG_ID = J.REGION_ID
            WHERE E.MATERIAL_ID = '5005'
            AND A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
            GROUP BY J.REGION_NAME
                create table #temp2(
                province varchar(max),
                olienWeight float,
                olienAmount float,
                olienRate float
                )

                insert into #temp2
                SELECT J.REGION_NAME AS[PROVINCE],
                SUM((C.WEIGHT)) AS[OLIEN TOTAL WEIGHT], SUM((C.QTY) * C.RATE) AS[OLIEN AMOUNT],
                SUM((C.QTY) * C.RATE) / SUM((C.WEIGHT)) AS[OLIEN AVG RATE]
                FROM SALES A
                INNER JOIN SALES_PROGRAM_MASTER B ON A.SOP_ID = B.SPM_ID
                INNER JOIN SALES_PROGRAM_DETAILS C ON B.SPM_ID = C.SPM_ID
                INNER JOIN PRODUCT_MASTER D ON C.PRODUCT_ID = D.PM_ID
                INNER JOIN PRODUCT_DETAILS E ON D.PM_ID = E.PM_ID
                INNER JOIN COA G ON B.CUSTOMER_ID = G.COA_ID
                INNER JOIN CUSTOMER_PROFILE H ON H.COA_ID = G.COA_ID
                INNER JOIN SALES_PERSONS F ON H.SALE_PER_ID = F.SALES_PER_ID
                INNER JOIN CITY I ON H.CITY_ID = I.CITY_ID
                INNER JOIN REGION J ON I.REG_ID = J.REGION_ID
                WHERE E.MATERIAL_ID = '5003'
                AND A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
                GROUP BY J.REGION_NAME
                UNION ALL
                SELECT J.REGION_NAME AS [PROVINCE],
                SUM((C.WEIGHT)) AS [CANOLA TOTAL WEIGHT],SUM((C.QTY) * C.RATE) AS [CANOLA AMOUNT],
                SUM((C.QTY) * C.RATE) / SUM((C.WEIGHT)) AS [CANOLA AVG RATE]
                FROM SALES A
                INNER JOIN SALES_PROGRAM_MASTER B ON A.SOP_ID = B.SPM_ID
                INNER JOIN SALES_PROGRAM_DETAILS C ON B.SPM_ID = C.SPM_ID
                INNER JOIN MATERIALS E ON C.PRODUCT_ID = E.MATERIAL_ID
                INNER JOIN COA G ON B.CUSTOMER_ID = G.COA_ID
                INNER JOIN CUSTOMER_PROFILE H ON H.COA_ID = G.COA_ID
                INNER JOIN CITY I ON H.CITY_ID = I.CITY_ID
                INNER JOIN REGION J ON I.REG_ID = J.REGION_ID
                WHERE E.MATERIAL_ID = '5003'
                AND A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
                GROUP BY J.REGION_NAME
				UNION ALL
				SELECT J.REGION_NAME AS[PROVINCE],
                SUM((C.WEIGHT)) AS[OLIEN TOTAL WEIGHT], SUM((C.QTY) * C.RATE) AS[OLIEN AMOUNT],
                SUM((C.QTY) * C.RATE) / SUM((C.WEIGHT)) AS[OLIEN AVG RATE]
                FROM SALES A
                INNER JOIN GATE_PASS B ON A.GPM_ID = B.GPM_ID
                INNER JOIN GATE_PASS_DETAIL C ON B.GPM_ID = C.GP_ID
                INNER JOIN PRODUCT_MASTER D ON C.PRODUCT_ID = D.PM_ID
                INNER JOIN PRODUCT_DETAILS E ON D.PM_ID = E.PM_ID
                INNER JOIN COA G ON A.CUSTOMER_ID = G.COA_ID
                INNER JOIN CUSTOMER_PROFILE H ON H.COA_ID = G.COA_ID
                INNER JOIN SALES_PERSONS F ON H.SALE_PER_ID = F.SALES_PER_ID
                INNER JOIN CITY I ON H.CITY_ID = I.CITY_ID
                INNER JOIN REGION J ON I.REG_ID = J.REGION_ID
                WHERE E.MATERIAL_ID = '5003'
                AND A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
                GROUP BY J.REGION_NAME
                UNION ALL
                SELECT J.REGION_NAME AS [PROVINCE],
                SUM((C.WEIGHT)) AS [CANOLA TOTAL WEIGHT],SUM((C.QTY) * C.RATE) AS [CANOLA AMOUNT],
                SUM((C.QTY) * C.RATE) / SUM((C.WEIGHT)) AS [CANOLA AVG RATE]
                FROM SALES A
                INNER JOIN GATE_PASS B ON A.GPM_ID = B.GPM_ID
                INNER JOIN GATE_PASS_DETAIL C ON B.GPM_ID = C.GP_ID
                INNER JOIN MATERIALS E ON C.PRODUCT_ID = E.MATERIAL_ID
                INNER JOIN COA G ON A.CUSTOMER_ID = G.COA_ID
                INNER JOIN CUSTOMER_PROFILE H ON H.COA_ID = G.COA_ID
                INNER JOIN CITY I ON H.CITY_ID = I.CITY_ID
                INNER JOIN REGION J ON I.REG_ID = J.REGION_ID
                WHERE E.MATERIAL_ID = '5003'
                AND A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
                GROUP BY J.REGION_NAME
                select x.province,
                ISNULL(a.olienWeight,'0') AS olienWeight,ISNULL(a.olienAmount,'0') AS olienAmount,
                ISNULL(a.olienRate,'0') AS olienRate,ISNULL(x.canolaWeight,'0') AS canolaWeight,
                ISNULL(x.canolaAmount,'0') AS canolaAmount,ISNULL(x.canolaRate,'0') AS canolaRate
                from #temp2 a
                right join(
                select *from #temp1
                union all
                SELECT province, null, null, null FROM #temp2 WHERE
                province not in (select province from #temp1)
                GROUP BY province
                ) x on x.province = a.province

                drop table #temp1
                drop table #temp2";

            try
            {
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    classHelper.mds.Tables["ProvinceWiseReportSummary"].Clear();
                    while (classHelper.dr.Read())
                    {
                        classHelper.dataR = classHelper.mds.Tables["ProvinceWiseReportSummary"].NewRow();
                        classHelper.dataR["province"] = classHelper.dr["province"].ToString();
                        classHelper.dataR["olienWeight"] = Convert.ToDecimal(classHelper.dr["olienWeight"].ToString());
                        classHelper.dataR["olienAmount"] = Convert.ToDecimal(classHelper.dr["olienAmount"].ToString());
                        classHelper.dataR["olienRate"] = Convert.ToDecimal(classHelper.dr["olienRate"].ToString());
                        classHelper.dataR["canolaWeight"] = Convert.ToDecimal(classHelper.dr["canolaWeight"].ToString());
                        classHelper.dataR["canolaRate"] = Convert.ToDecimal(classHelper.dr["canolaRate"].ToString());
                        classHelper.dataR["canolaAmount"] = Convert.ToDecimal(classHelper.dr["canolaAmount"].ToString()); 
                        classHelper.dataR["from"] = dtp_FROM.Value.Date;
                        classHelper.dataR["to"] = dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                        classHelper.mds.Tables["ProvinceWiseReportSummary"].Rows.Add(classHelper.dataR);
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
                classHelper.rpt.GenerateReport("ProvinceWiseReportSP", classHelper.mds);
                classHelper.rpt.ShowDialog();

                classHelper.rpt = new frmReports();
                classHelper.rpt.GenerateReport("ProvinceWiseReportSummarySP", classHelper.mds);
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
