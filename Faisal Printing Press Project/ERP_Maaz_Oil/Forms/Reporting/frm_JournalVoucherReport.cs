using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP_Maaz_Oil.Forms.Reporting
{
    public partial class frm_JournalVoucherReport : Form
    {
        public frm_JournalVoucherReport()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.R))
            {
                generate();
                //if (grdSEARCH.Rows.Count > 0)
                //{
                //    showReport();
                //}
                //else
                //{
                //    classHelper.ShowMessageBox("No records found", "Error");
                //}
            }
            if (keyData == (Keys.Escape))
            {
                this.Dispose();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        Classes.Helper classHelper = new Classes.Helper();

        private void load_account()
        {
            classHelper.query = @"SELECT '0' AS [id],'--ALL--' as [name]
            UNION ALL
            SELECT COA_ID AS [id],COA_NAME AS [name] FROM COA ORDER BY [name]";
            classHelper.LoadComboData(cmbACCOUNT, classHelper.query);
        }

        private void frm_JournalVoucherReport_Load(object sender, EventArgs e)
        {
            load_account();
        }

        private void generate_old()
        {
            try
            {
                classHelper.query = @"
                SELECT DENSE_RANK() OVER (ORDER BY A.GV_ID ) as [SNo],
                A.GV_CODE AS [VOUCHER #],FORMAT(A.DAATE,'dd-MMM-yyyy') AS [DATE],
                C.COA_NAME as [ACCOUNT],
                B.DEBIT as [DEBIT],B.CREDIT as [CREDIT],B.NARRATION AS [NARRATION]
                FROM GENERAL_VOUCHER_M A
                INNER JOIN GENERAL_VOUCHER_D B ON A.GV_ID = B.GV_ID
                INNER JOIN COA C ON B.COA_ID = C.COA_ID
                WHERE A.DAATE BETWEEN '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + @"' and 
                '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
                ";

                if (cmbACCOUNT.SelectedIndex > 0)
                    classHelper.query += " AND C.COA_ID = '" + cmbACCOUNT.SelectedValue.ToString() + @"' ";

                classHelper.query += @" 
                GROUP BY A.GV_ID,A.GV_CODE,C.COA_NAME,B.DEBIT,B.CREDIT,B.NARRATION,A.DAATE
                ORDER BY A.GV_ID";

                classHelper.LoadGrid(grdSEARCH, classHelper.query);
            }
            catch (Exception ex)
            {
                classHelper.ShowMessageBox(ex.Message, "Error");
            }
            finally
            {
                Classes.Helper.conn.Close();
            }
        }

        private void generate()
        {
            try
            {
                classHelper.query = @"
                    SELECT DENSE_RANK() OVER (ORDER BY A.GV_ID ) as [SNo],
                    A.GV_CODE AS [VOUCHER #],FORMAT(A.DAATE,'dd-MMM-yyyy') AS [DATE],
                    B.DEBIT as [AMOUNT],
                    C.COA_NAME as [DEBIT],D.COA_NAME as [CREDIT],B.NARRATION AS [NARRATION]
                    FROM GENERAL_VOUCHER_M A
                    INNER JOIN GENERAL_VOUCHER_D B ON A.GV_ID = B.GV_ID
                    INNER JOIN COA C ON B.COA_ID = C.COA_ID
                    INNER JOIN COA D ON B.CREDIT_ID = D.COA_ID
                    WHERE A.DAATE BETWEEN '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + @"' and 
                    '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
                    ";

                if (cmbACCOUNT.SelectedIndex > 0)
                    classHelper.query += " AND (C.COA_ID = '" + cmbACCOUNT.SelectedValue.ToString() + @"' OR  D.COA_ID = '" + cmbACCOUNT.SelectedValue.ToString() + @"') ";

                classHelper.query += @" 
                    --GROUP BY A.DAATE,A.GV_ID,A.GV_CODE,C.COA_NAME,B.DEBIT,B.CREDIT,B.NARRATION
                    ORDER BY A.DAATE,A.GV_ID,A.GV_CODE,[DEBIT],[CREDIT]";

                char hasRows = 'N';
                try
                {
                    Classes.Helper.conn.Open();
                    classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                    classHelper.dr = classHelper.cmd.ExecuteReader();
                    if (classHelper.dr.HasRows == true)
                    {
                        hasRows = 'Y';
                        classHelper.nds.Tables["JVReport"].Clear();
                        while (classHelper.dr.Read())
                        {
                            classHelper.dataR = classHelper.nds.Tables["JVReport"].NewRow();
                            classHelper.dataR["date"] = Convert.ToDateTime(classHelper.dr["DATE"].ToString());
                            classHelper.dataR["voucherNo"] = classHelper.dr["VOUCHER #"].ToString();
                            classHelper.dataR["amount"] = Convert.ToDouble(classHelper.dr["AMOUNT"].ToString());
                            classHelper.dataR["description"] = classHelper.dr["NARRATION"].ToString();
                            classHelper.dataR["debit"] = classHelper.dr["DEBIT"].ToString();
                            classHelper.dataR["credit"] = classHelper.dr["CREDIT"].ToString();
                            classHelper.dataR["sNo"] = Convert.ToDouble(classHelper.dr["SNo"].ToString());
                            classHelper.dataR["from"] = dtp_FROM.Value.Date.ToString("dd-MMM-yyyy");
                            classHelper.dataR["to"] = dtp_TO.Value.Date.ToString("dd-MMM-yyyy");
                            classHelper.nds.Tables["JVReport"].Rows.Add(classHelper.dataR);
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
                    classHelper.rpt = new Forms.Reporting.frmReports();
                    classHelper.rpt.GenerateReport("JVReport", classHelper.nds);
                    classHelper.rpt.ShowDialog();
                }

                //classHelper.LoadGrid(grdSEARCH, classHelper.query);
            }
            catch (Exception ex)
            {
                classHelper.ShowMessageBox(ex.Message, "Error");
            }
            finally
            {
                Classes.Helper.conn.Close();
            }
        }

        private void showReport()
        {
            classHelper.nds.Tables["JVReport"].Clear();
            foreach (DataGridViewRow rows in grdSEARCH.Rows)
            {
                classHelper.dataR = classHelper.nds.Tables["JVReport"].NewRow();
                classHelper.dataR["date"] = Convert.ToDateTime(rows.Cells["date"].Value.ToString());
                classHelper.dataR["voucherNo"] = rows.Cells["voucher #"].Value.ToString();
                classHelper.dataR["accountName"] = rows.Cells["account"].Value.ToString();
                classHelper.dataR["description"] = rows.Cells["narration"].Value.ToString();
                classHelper.dataR["debit"] = Convert.ToDouble(rows.Cells["debit"].Value.ToString());
                classHelper.dataR["credit"] = Convert.ToDouble(rows.Cells["credit"].Value.ToString());
                classHelper.dataR["sNo"] = Convert.ToDouble(rows.Cells["sNo"].Value.ToString());
                classHelper.dataR["from"] = dtp_FROM.Value.Date.ToString("dd-MMM-yyyy");
                classHelper.dataR["to"] = dtp_TO.Value.Date.ToString("dd-MMM-yyyy");

                classHelper.nds.Tables["JVReport"].Rows.Add(classHelper.dataR);
            }
            classHelper.rpt = new Forms.Reporting.frmReports();
            classHelper.rpt.GenerateReport("JVReportOld", classHelper.nds);
            classHelper.rpt.ShowDialog();
        }

        private void btnSHOW_Click(object sender, EventArgs e)
        {
            generate();
            //if (Classes.Helper.companyName.Equals("FFMS") || Classes.Helper.companyName.Equals("SS") || Classes.Helper.companyName.Equals("Sawera"))
            //{
            //    generate_old();
            //    if (grdSEARCH.Rows.Count > 0)
            //    {
            //        showReport();
            //    }
            //    else
            //    {
            //        classHelper.ShowMessageBox("No records found", "Error");
            //    }
            //}
            //else {
            //    generate();
            //}
        }
    }
}
