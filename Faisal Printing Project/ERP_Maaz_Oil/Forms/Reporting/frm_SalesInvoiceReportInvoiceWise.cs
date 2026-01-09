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
    public partial class frm_SalesInvoiceReportInvoiceWise : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        public frm_SalesInvoiceReportInvoiceWise()
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
            classHelper.query = @"SELECT A.S_ID,A.DATE,A.INVOICE_NO,DATEADD(DAY,F.CREDIT_DAYS,A.DATE) AS [DUE DATE],D.COA_NAME,E.PRODUCT_NAME,
            C.QTY,C.WEIGHT,C.RATE,(C.QTY * C.RATE) AS [AMOUNT]
            FROM SALES A
            INNER JOIN SALES_PROGRAM_MASTER B ON A.SOP_ID = B.SPM_ID
            INNER JOIN SALES_PROGRAM_DETAILS C ON B.SPM_ID = C.SPM_ID
            INNER JOIN COA D ON B.CUSTOMER_ID = D.COA_ID
            INNER JOIN PRODUCT_MASTER E ON C.PRODUCT_ID = E.PM_ID
            INNER JOIN PRODUCT_DETAILS G ON E.PM_ID = G.PM_ID
            LEFT JOIN CUSTOMER_PROFILE F ON F.COA_ID = D.COA_ID
            WHERE A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
            union all
            SELECT A.S_ID,A.DATE,A.INVOICE_NO,DATEADD(DAY, F.CREDIT_DAYS, A.DATE) AS[DUE DATE],D.COA_NAME,E.MATERIAL_NAME as PRODUCT_NAME,
            C.QTY,C.WEIGHT,C.RATE,(C.QTY * C.RATE) AS[AMOUNT]
            FROM SALES A
            INNER JOIN SALES_PROGRAM_MASTER B ON A.SOP_ID = B.SPM_ID
            INNER JOIN SALES_PROGRAM_DETAILS C ON B.SPM_ID = C.SPM_ID
            INNER JOIN COA D ON B.CUSTOMER_ID = D.COA_ID
            INNER JOIN MATERIALS E ON C.PRODUCT_ID = E.MATERIAL_ID
            LEFT JOIN CUSTOMER_PROFILE F ON F.COA_ID = D.COA_ID
            WHERE A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
            UNION ALL
            SELECT A.S_ID,A.DATE,A.INVOICE_NO,DATEADD(DAY,F.CREDIT_DAYS,A.DATE) AS [DUE DATE],D.COA_NAME,E.PRODUCT_NAME,
            C.QTY,C.WEIGHT,C.RATE,(C.QTY * C.RATE) AS [AMOUNT]
            FROM SALES A
            INNER JOIN GATE_PASS B ON A.GPM_ID = B.GPM_ID
            INNER JOIN GATE_PASS_DETAIL C ON B.GPM_ID = C.GP_ID
            INNER JOIN COA D ON A.CUSTOMER_ID = D.COA_ID
            INNER JOIN PRODUCT_MASTER E ON C.PRODUCT_ID = E.PM_ID
            INNER JOIN PRODUCT_DETAILS G ON E.PM_ID = G.PM_ID
            LEFT JOIN CUSTOMER_PROFILE F ON F.COA_ID = D.COA_ID
            WHERE A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
            union all
            SELECT A.S_ID,A.DATE,A.INVOICE_NO,DATEADD(DAY, F.CREDIT_DAYS, A.DATE) AS[DUE DATE],D.COA_NAME,E.MATERIAL_NAME as PRODUCT_NAME,
            C.QTY,C.WEIGHT,C.RATE,(C.QTY * C.RATE) AS[AMOUNT]
            FROM SALES A
            INNER JOIN GATE_PASS B ON A.GPM_ID = B.GPM_ID
            INNER JOIN GATE_PASS_DETAIL C ON B.GPM_ID = C.GP_ID
            INNER JOIN COA D ON A.CUSTOMER_ID = D.COA_ID
            INNER JOIN MATERIALS E ON C.PRODUCT_ID = E.MATERIAL_ID
            LEFT JOIN CUSTOMER_PROFILE F ON F.COA_ID = D.COA_ID
            WHERE A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
            ORDER BY S_ID";
            
            char hasRows = 'N';
            try
            {
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    hasRows = 'Y';
                    classHelper.mds.Tables["SalesInvoiceReport"].Clear();
                    while (classHelper.dr.Read())
                    {
                        classHelper.dataR = classHelper.mds.Tables["SalesInvoiceReport"].NewRow();
                        classHelper.dataR["from"] = dtp_FROM.Value.Date;
                        classHelper.dataR["to"] = dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                        classHelper.dataR["date"] = Convert.ToDateTime(classHelper.dr["DATE"].ToString());
                        classHelper.dataR["invoiceNo"] = classHelper.dr["INVOICE_NO"].ToString();
                        classHelper.dataR["dueDate"] = Convert.ToDateTime(classHelper.dr["DUE DATE"].ToString());
                        classHelper.dataR["customer"] = classHelper.dr["COA_NAME"].ToString();
                        classHelper.dataR["product"] = classHelper.dr["PRODUCT_NAME"].ToString();
                        classHelper.dataR["qty"] = Convert.ToDecimal(classHelper.dr["QTY"].ToString());
                        classHelper.dataR["weight"] = Convert.ToDecimal(classHelper.dr["WEIGHT"].ToString());
                        classHelper.dataR["rate"] = Convert.ToDecimal(classHelper.dr["RATE"].ToString());
                        classHelper.dataR["amount"] = Convert.ToDecimal(classHelper.dr["AMOUNT"].ToString());
                        classHelper.dataR["s_id"] = Convert.ToDecimal(classHelper.dr["S_ID"].ToString());
                        classHelper.mds.Tables["SalesInvoiceReport"].Rows.Add(classHelper.dataR);
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

            classHelper.query = @"
            SELECT D.COA_NAME,sa.INVOICE_NO, SUM(C.WEIGHT) AS [TOTAL WEIGHT],SA.[DATE],
                (
                SELECT 
	                (
		                SELECT ISNULL(SUM(C.WEIGHT),0)
		                FROM SALES A
		                INNER JOIN SALES_PROGRAM_MASTER B ON A.SOP_ID = B.SPM_ID
		                INNER JOIN SALES_PROGRAM_DETAILS C ON B.SPM_ID = C.SPM_ID
		                INNER JOIN COA D ON B.CUSTOMER_ID = D.COA_ID
		                INNER JOIN PRODUCT_MASTER E ON C.PRODUCT_ID = E.PM_ID
		                INNER JOIN PRODUCT_DETAILS G ON E.PM_ID = G.PM_ID
		                WHERE G.MATERIAL_ID = '5003' AND A.S_ID = SA.S_ID AND A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
	                ) + 
	                (
		                SELECT ISNULL(SUM(C.WEIGHT),0)
		                FROM SALES A
		                INNER JOIN SALES_PROGRAM_MASTER B ON A.SOP_ID = B.SPM_ID
		                INNER JOIN SALES_PROGRAM_DETAILS C ON B.SPM_ID = C.SPM_ID
		                INNER JOIN COA D ON B.CUSTOMER_ID = D.COA_ID
		                INNER JOIN MATERIALS E ON C.PRODUCT_ID = E.MATERIAL_ID
		                WHERE E.MATERIAL_ID = '5003' AND A.S_ID = SA.S_ID AND A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
	                )
                ) 
                AS [OLIEN WEIGHT], 
                (
                SELECT
	                (
		                SELECT ISNULL(SUM(C.QTY * C.RATE),0)
		                FROM SALES A
		                INNER JOIN SALES_PROGRAM_MASTER B ON A.SOP_ID = B.SPM_ID
		                INNER JOIN SALES_PROGRAM_DETAILS C ON B.SPM_ID = C.SPM_ID
		                INNER JOIN COA D ON B.CUSTOMER_ID = D.COA_ID
		                INNER JOIN PRODUCT_MASTER E ON C.PRODUCT_ID = E.PM_ID
		                INNER JOIN PRODUCT_DETAILS G ON E.PM_ID = G.PM_ID
		                WHERE G.MATERIAL_ID = '5003' 
		                AND A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
	                ) +
	                (
		                SELECT ISNULL(SUM(C.QTY * C.RATE),0)
		                FROM SALES A
		                INNER JOIN SALES_PROGRAM_MASTER B ON A.SOP_ID = B.SPM_ID
		                INNER JOIN SALES_PROGRAM_DETAILS C ON B.SPM_ID = C.SPM_ID
		                INNER JOIN COA D ON B.CUSTOMER_ID = D.COA_ID
		                INNER JOIN MATERIALS E ON C.PRODUCT_ID = E.MATERIAL_ID
		                WHERE E.MATERIAL_ID = '5003' 
		                AND A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
	                )
                ) AS [OLIEN AMOUNT],
                (
                SELECT
	                (
		                SELECT ISNULL(SUM(C.WEIGHT),0)
		                FROM SALES A
		                INNER JOIN SALES_PROGRAM_MASTER B ON A.SOP_ID = B.SPM_ID
		                INNER JOIN SALES_PROGRAM_DETAILS C ON B.SPM_ID = C.SPM_ID
		                INNER JOIN COA D ON B.CUSTOMER_ID = D.COA_ID
		                INNER JOIN PRODUCT_MASTER E ON C.PRODUCT_ID = E.PM_ID
		                INNER JOIN PRODUCT_DETAILS G ON E.PM_ID = G.PM_ID
		                WHERE G.MATERIAL_ID = '5005' AND A.S_ID = SA.S_ID 
		                AND A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
	                ) +
	                (
		                SELECT ISNULL(SUM(C.WEIGHT),0)
		                FROM SALES A
		                INNER JOIN SALES_PROGRAM_MASTER B ON A.SOP_ID = B.SPM_ID
		                INNER JOIN SALES_PROGRAM_DETAILS C ON B.SPM_ID = C.SPM_ID
		                INNER JOIN COA D ON B.CUSTOMER_ID = D.COA_ID
		                INNER JOIN MATERIALS E ON C.PRODUCT_ID = E.MATERIAL_ID
		                WHERE E.MATERIAL_ID = '5005' AND A.S_ID = SA.S_ID 
		                AND A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
	                )
                ) 
                AS [CANOLA],
                (
                SELECT
	                (
		                SELECT ISNULL(SUM(C.QTY * C.RATE),0)
		                FROM SALES A
		                INNER JOIN SALES_PROGRAM_MASTER B ON A.SOP_ID = B.SPM_ID
		                INNER JOIN SALES_PROGRAM_DETAILS C ON B.SPM_ID = C.SPM_ID
		                INNER JOIN COA D ON B.CUSTOMER_ID = D.COA_ID
		                INNER JOIN PRODUCT_MASTER E ON C.PRODUCT_ID = E.PM_ID
		                INNER JOIN PRODUCT_DETAILS G ON E.PM_ID = G.PM_ID
		                WHERE G.MATERIAL_ID = '5005' 
		                AND A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
	                ) +
	                (
		                SELECT ISNULL(SUM(C.QTY * C.RATE),0)
		                FROM SALES A
		                INNER JOIN SALES_PROGRAM_MASTER B ON A.SOP_ID = B.SPM_ID
		                INNER JOIN SALES_PROGRAM_DETAILS C ON B.SPM_ID = C.SPM_ID
		                INNER JOIN COA D ON B.CUSTOMER_ID = D.COA_ID
		                INNER JOIN MATERIALS E ON C.PRODUCT_ID = E.MATERIAL_ID
		                WHERE E.MATERIAL_ID = '5005' 
		                AND A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
	                )
                ) AS [CANOLA AMOUNT],
                SUM(C.QTY * C.RATE) AS [AMOUNT],ISNULL(I.NAME,'-') AS [SALES PERSON],SA.S_ID
                FROM SALES SA
                INNER JOIN SALES_PROGRAM_MASTER B ON SA.SOP_ID = B.SPM_ID
                INNER JOIN SALES_PROGRAM_DETAILS C ON B.SPM_ID = C.SPM_ID
                INNER JOIN COA D ON B.CUSTOMER_ID = D.COA_ID
                LEFT JOIN CUSTOMER_PROFILE H ON D.COA_ID = H.COA_ID
                LEFT JOIN SALES_PERSONS I ON H.SALE_PER_ID = I.SALES_PER_ID
                WHERE SA.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
                GROUP BY D.COA_NAME,SA.S_ID,SA.INVOICE_NO,SA.[DATE],I.NAME

                UNION ALL

                SELECT D.COA_NAME,sa.INVOICE_NO, SUM(C.WEIGHT) AS [TOTAL WEIGHT],SA.[DATE],
                (
                SELECT
	                (
		                SELECT ISNULL(SUM(C.WEIGHT),0)
		                FROM SALES A
		                INNER JOIN GATE_PASS B ON A.GPM_ID = B.GPM_ID
		                INNER JOIN GATE_PASS_DETAIL C ON B.GPM_ID = C.GP_ID
		                INNER JOIN COA D ON A.CUSTOMER_ID = D.COA_ID
		                INNER JOIN PRODUCT_MASTER E ON C.PRODUCT_ID = E.PM_ID
		                INNER JOIN PRODUCT_DETAILS G ON E.PM_ID = G.PM_ID
		                WHERE G.MATERIAL_ID = '5003' AND A.S_ID = SA.S_ID AND A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
	                ) +
	                (
		                SELECT ISNULL(SUM(C.WEIGHT),0)
		                FROM SALES A
		                INNER JOIN GATE_PASS B ON A.GPM_ID = B.GPM_ID
		                INNER JOIN GATE_PASS_DETAIL C ON B.GPM_ID = C.GP_ID
		                INNER JOIN COA D ON A.CUSTOMER_ID = D.COA_ID
		                INNER JOIN MATERIALS E ON C.PRODUCT_ID = E.MATERIAL_ID
		                WHERE E.MATERIAL_ID = '5003' AND A.S_ID = SA.S_ID AND A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
	                )
                ) 
                AS [OLIEN WEIGHT], 
                (
                SELECT
	                (
		                SELECT ISNULL(SUM(C.QTY * C.RATE),0)
		                FROM SALES A
		                INNER JOIN GATE_PASS B ON A.GPM_ID = B.GPM_ID
		                INNER JOIN GATE_PASS_DETAIL C ON B.GPM_ID = C.GP_ID
		                INNER JOIN COA D ON A.CUSTOMER_ID = D.COA_ID
		                INNER JOIN PRODUCT_MASTER E ON C.PRODUCT_ID = E.PM_ID
		                INNER JOIN PRODUCT_DETAILS G ON E.PM_ID = G.PM_ID
		                WHERE G.MATERIAL_ID = '5003' 
		                AND A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
	                ) +
	                (
		                SELECT ISNULL(SUM(C.QTY * C.RATE),0)
		                FROM SALES A
		                INNER JOIN GATE_PASS B ON A.GPM_ID = B.GPM_ID
		                INNER JOIN GATE_PASS_DETAIL C ON B.GPM_ID = C.GP_ID
		                INNER JOIN COA D ON A.CUSTOMER_ID = D.COA_ID
		                INNER JOIN MATERIALS E ON C.PRODUCT_ID = E.MATERIAL_ID
		                WHERE E.MATERIAL_ID = '5003' 
		                AND A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
	                )
                ) AS [OLIEN AMOUNT],
                (
                SELECT
	                (
		                SELECT ISNULL(SUM(C.WEIGHT),0)
		                FROM SALES A
		                INNER JOIN GATE_PASS B ON A.GPM_ID = B.GPM_ID
		                INNER JOIN GATE_PASS_DETAIL C ON B.GPM_ID = C.GP_ID
		                INNER JOIN COA D ON A.CUSTOMER_ID = D.COA_ID
		                INNER JOIN PRODUCT_MASTER E ON C.PRODUCT_ID = E.PM_ID
		                INNER JOIN PRODUCT_DETAILS G ON E.PM_ID = G.PM_ID
		                WHERE G.MATERIAL_ID = '5005' AND A.S_ID = SA.S_ID 
		                AND A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
	                ) +
	                (
		                SELECT ISNULL(SUM(C.WEIGHT),0)
		                FROM SALES A
		                INNER JOIN GATE_PASS B ON A.GPM_ID = B.GPM_ID
		                INNER JOIN GATE_PASS_DETAIL C ON B.GPM_ID = C.GP_ID
		                INNER JOIN COA D ON A.CUSTOMER_ID = D.COA_ID
		                INNER JOIN MATERIALS E ON C.PRODUCT_ID = E.MATERIAL_ID
		                WHERE E.MATERIAL_ID = '5005' AND A.S_ID = SA.S_ID 
		                AND A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
	                )
                ) 
                AS [CANOLA],
                (
                SELECT 
	                (
		                SELECT ISNULL(SUM(C.QTY * C.RATE),0)
		                FROM SALES A
		                INNER JOIN GATE_PASS B ON A.GPM_ID = B.GPM_ID
		                INNER JOIN GATE_PASS_DETAIL C ON B.GPM_ID = C.GP_ID
		                INNER JOIN COA D ON A.CUSTOMER_ID = D.COA_ID
		                INNER JOIN PRODUCT_MASTER E ON C.PRODUCT_ID = E.PM_ID
		                INNER JOIN PRODUCT_DETAILS G ON E.PM_ID = G.PM_ID
		                WHERE G.MATERIAL_ID = '5005' 
		                AND A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
	                ) + 
	                (
		                SELECT ISNULL(SUM(C.QTY * C.RATE),0)
		                FROM SALES A
		                INNER JOIN GATE_PASS B ON A.GPM_ID = B.GPM_ID
		                INNER JOIN GATE_PASS_DETAIL C ON B.GPM_ID = C.GP_ID
		                INNER JOIN COA D ON A.CUSTOMER_ID = D.COA_ID
		                INNER JOIN MATERIALS E ON C.PRODUCT_ID = E.MATERIAL_ID
		                WHERE E.MATERIAL_ID = '5005' 
		                AND A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
	                )
                ) AS [CANOLA AMOUNT],
                SUM(C.QTY * C.RATE) AS [AMOUNT],ISNULL(I.NAME,'-') AS [SALES PERSON],SA.S_ID
                FROM SALES SA
                INNER JOIN GATE_PASS B ON SA.GPM_ID = B.GPM_ID
                INNER JOIN GATE_PASS_DETAIL C ON B.GPM_ID = C.GP_ID
                INNER JOIN COA D ON SA.CUSTOMER_ID = D.COA_ID
                LEFT JOIN CUSTOMER_PROFILE H ON D.COA_ID = H.COA_ID
                LEFT JOIN SALES_PERSONS I ON H.SALE_PER_ID = I.SALES_PER_ID
                WHERE SA.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
                GROUP BY D.COA_NAME,SA.S_ID,SA.INVOICE_NO,SA.[DATE],I.NAME
                ORDER BY S_ID";

            try
            {
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    classHelper.mds.Tables["SalesInvoiceSummaryReport"].Clear();
                    while (classHelper.dr.Read())
                    {
                        classHelper.dataR = classHelper.mds.Tables["SalesInvoiceSummaryReport"].NewRow();
                        classHelper.dataR["customer"] = classHelper.dr["COA_NAME"].ToString();
                        classHelper.dataR["canola"] = Convert.ToDecimal(classHelper.dr["CANOLA"].ToString());
                        classHelper.dataR["olien"] = Convert.ToDecimal(classHelper.dr["OLIEN WEIGHT"].ToString());
                        classHelper.dataR["totalKg"] = Convert.ToDecimal(classHelper.dr["TOTAL WEIGHT"].ToString());
                        classHelper.dataR["amout"] = Convert.ToDecimal(classHelper.dr["AMOUNT"].ToString());
                        classHelper.dataR["invoice"] = classHelper.dr["INVOICE_NO"].ToString();
                        classHelper.dataR["olienTotal"] = Convert.ToDecimal(classHelper.dr["OLIEN AMOUNT"].ToString());
                        classHelper.dataR["canolaTotal"] = Convert.ToDecimal(classHelper.dr["CANOLA AMOUNT"].ToString());
                        classHelper.dataR["date"] = Convert.ToDateTime(classHelper.dr["DATE"].ToString());
                        classHelper.dataR["salesPerson"] = classHelper.dr["SALES PERSON"].ToString();
                        classHelper.dataR["from"] = dtp_FROM.Value.Date;
                        classHelper.dataR["to"] = dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                        classHelper.mds.Tables["SalesInvoiceSummaryReport"].Rows.Add(classHelper.dataR);
                    }
                }
                else
                {
                    // MessageBox.Show("No Record Found.", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                classHelper.rpt.GenerateReport("SalesInvoiceReportInvoiceWise", classHelper.mds);
                classHelper.rpt.ShowDialog();

                classHelper.rpt = new frmReports();
                classHelper.rpt.GenerateReport("SalesInvoiceSummaryReportSP", classHelper.mds);
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
