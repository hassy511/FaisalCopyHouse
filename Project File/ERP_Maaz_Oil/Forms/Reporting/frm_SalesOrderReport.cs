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
    public partial class frm_SalesOrderReport : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        public frm_SalesOrderReport()
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
            classHelper.query = @"SELECT A.[DATE],A.INVOICE_NO AS [S.O #],C.COA_NAME AS [CUSTOMER],B.MATERIAL_NAME AS [RAW MATERIAL],A.[TOTAL_KGS] AS [KG WEIGHT],A.RATE AS [RATE (KG)],
            (A.[TOTAL_KGS] / 37.324) AS [MUAND WEIGHT], (A.RATE * 37.324) AS [MUAND RATE],
            CASE WHEN A.CREDIT_DAYS <= 0 THEN 'CASH' ELSE CONVERT(VARCHAR,A.CREDIT_DAYS)+' DAYS' END AS [CONDITON],
            DATEADD(DAY,A.CREDIT_DAYS,A.[DATE]) AS [DUE DATE]
            FROM SALES_ORDER_DIRECT A
            INNER JOIN MATERIALS B ON A.MATERIAL_ID = B.MATERIAL_ID
            INNER JOIN COA C ON A.CUSTOMER_ID = C.COA_ID
            WHERE A.[DATE] BETWEEN '" + dtp_FROM.Value.Date+"' AND '"+dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)+"'";

            char hasRows = 'N';
            try
            {
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    hasRows = 'Y';
                    classHelper.mds.Tables["PO_Report"].Clear();
                    while (classHelper.dr.Read())
                    {
                        classHelper.dataR = classHelper.mds.Tables["PO_Report"].NewRow();
                        classHelper.dataR["DATE"] = Convert.ToDateTime(classHelper.dr["DATE"].ToString());
                        classHelper.dataR["P.O #"] = classHelper.dr["S.O #"].ToString();
                        classHelper.dataR["SUPPLIER"] = classHelper.dr["CUSTOMER"].ToString();
                        classHelper.dataR["RAW MATERIAL"] = classHelper.dr["RAW MATERIAL"].ToString();
                        classHelper.dataR["BALANCE_WEIGHT"] = Convert.ToDecimal(classHelper.dr["KG WEIGHT"].ToString());
                        if (classHelper.dr["RAW MATERIAL"].ToString().Equals("CANOLA"))
                        {
                            classHelper.dataR["RATE (KG)"] = Convert.ToDecimal(classHelper.dr["RATE (KG)"].ToString());
                        }
                        else {
                            classHelper.dataR["RATE (KG)"] = Convert.ToDecimal(classHelper.dr["MUAND RATE"].ToString());
                        }
                        classHelper.dataR["MUAND WEIGHT"] = Convert.ToDecimal(classHelper.dr["MUAND WEIGHT"].ToString());
                        classHelper.dataR["MUAND RATE"] = Convert.ToDecimal(classHelper.dr["MUAND RATE"].ToString());
                        classHelper.dataR["CONDITION"] = classHelper.dr["CONDITON"].ToString();
                        classHelper.dataR["DUE DATE"] = Convert.ToDateTime(classHelper.dr["DUE DATE"].ToString());
                        classHelper.dataR["from"] = dtp_FROM.Value.Date;
                        classHelper.dataR["to"] = dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                        classHelper.mds.Tables["PO_Report"].Rows.Add(classHelper.dataR);
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

            classHelper.query = @"select B.MATERIAL_NAME,SUM(A.TOTAL_KGS) AS [TOTAL WEIGHT],AVG(A.RATE) AS [AVERAGE RATE],
            (SUM(A.TOTAL_KGS) * AVG(A.RATE)) AS [AMOUNT]
            from SALES_ORDER_DIRECT A
            INNER JOIN MATERIALS B ON A.MATERIAL_ID = B.MATERIAL_ID
            WHERE A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
            GROUP BY B.MATERIAL_NAME";
            
            try
            {
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    classHelper.mds.Tables["PO_Summary"].Clear();
                    while (classHelper.dr.Read())
                    {
                        classHelper.dataR = classHelper.mds.Tables["PO_Summary"].NewRow();
                        classHelper.dataR["MATERIAL"] = classHelper.dr["MATERIAL_NAME"].ToString();
                        classHelper.dataR["WEIGHT"] = Convert.ToDecimal(classHelper.dr["TOTAL WEIGHT"].ToString());
                        classHelper.dataR["RATE"] = Convert.ToDecimal(classHelper.dr["AVERAGE RATE"].ToString());
                        classHelper.dataR["AMOUNT"] = Convert.ToDecimal(classHelper.dr["AMOUNT"].ToString());
                        classHelper.mds.Tables["PO_Summary"].Rows.Add(classHelper.dataR);
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
                classHelper.rpt.GenerateReport("SO_Report", classHelper.mds);
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
