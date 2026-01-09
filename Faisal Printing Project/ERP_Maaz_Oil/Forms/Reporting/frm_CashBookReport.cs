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
    public partial class frm_CashBookReport : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        decimal openingBalance = 0;
        decimal closingBalance = 0;
        public frm_CashBookReport()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.R))
            {
                generate();
                if (grdSEARCH.Rows.Count > 0)
                {
                    ReportData();
                }
            }
            if (keyData == (Keys.Escape))
            {
                this.Dispose();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void load_account()
        {
            classHelper.query = @"SELECT '0' AS [id],'--ALL--' as [name]
            UNION ALL
            SELECT COA_ID AS [id],COA_NAME AS [name] FROM COA ORDER BY [name]";
            classHelper.LoadComboData(cmbACCOUNT, classHelper.query);
        }

        private void opening_bal()
        {
            classHelper.query = @"SELECT ISNULL((SUM(DEBIT)-SUM(CREDIT)),0) + 
            ISNULL((SELECT CASE WHEN DR_CR = 'C' THEN (-1)*OPEN_BAL ELSE OPEN_BAL END
            FROM COA WHERE COA_ID = "+Classes.Helper.cashId+@"),0) AS [OPENING]
            FROM LEDGERS WHERE COA_ID = "+Classes.Helper.cashId+@"  AND DATE < '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date)+"'";

            Classes.Helper.conn.Open();
            try
            {
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    if (classHelper.dr.Read())
                    {
                        openingBalance = Convert.ToDecimal(classHelper.dr["OPENING"].ToString());
                        closingBalance = openingBalance;
                        grdSEARCH.Rows.Add("", "", "BALANCE BROUGHT FORWARDED", "", "", 0, 0, Convert.ToDecimal(classHelper.dr["OPENING"].ToString()),"");
                    }
                }
                else {
                    grdSEARCH.Rows.Add("", "", "BALANCE BROUGHT FORWARDED", "", "", 0, 0, 0,"");
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
        }

        public void ledger_Entry()
        {
            classHelper.query = @"SELECT A.FOLIO as [ID]
            --CASE WHEN A.CREDIT > 0 THEN 'CR-'+CONVERT(varchar(100),A.REF_ID) ELSE 'CP-'+CONVERT(varchar(100),A.REF_ID) END AS [ID]
            ,C.CA_NAME AS [ACCOUNT TYPE],
            B.COA_NAME AS [ACCOUNT NAME],
            isnull(A.REF_AC_ID,'') AS [REF ACCOUNT],
            A.DESCRIPTIONS AS [NARRATION],A.CREDIT AS [RECEIVED],A.DEBIT AS [PAYMENTS],FORMAT(A.DATE,'dd-MMMM-yyyy') AS [DATE],A.REF_ID
            FROM LEDGERS A
            INNER JOIN COA B ON A.COA_ID = B.COA_ID
            INNER JOIN CONTROL_ACCOUNT C ON B.CA_ID = C.CA_ID
           
            INNER JOIN (
            SELECT REF_ID,ENTRY_OF FROM LEDGERS WHERE COA_ID = "+Classes.Helper.cashId+@" 
            AND DATE BETWEEN '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + @"' 
            AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
            ) D ON A.REF_ID = D.REF_ID AND A.ENTRY_OF = D.ENTRY_OF
            WHERE A.COA_ID <> "+Classes.Helper.cashId+@" AND DATE BETWEEN '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + @"' 
            AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'";

            if(cmbACCOUNT.SelectedIndex>0)
                classHelper.query += " AND A.COA_ID = '" + cmbACCOUNT.SelectedValue.ToString() + @"'";
    
            classHelper.query += " ORDER BY [DATE],[ACCOUNT TYPE],[ACCOUNT NAME] asc";
            Classes.Helper.conn.Open();
            try
            {
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    //closingBalance = 0;
                    while (classHelper.dr.Read())
                    {
                        grdSEARCH.Rows.Add(classHelper.dr["ID"].ToString(), classHelper.dr["ACCOUNT TYPE"].ToString(), 
                        classHelper.dr["ACCOUNT NAME"].ToString(), classHelper.dr["REF ACCOUNT"].ToString(),
                        classHelper.dr["NARRATION"].ToString(), classHelper.dr["RECEIVED"].ToString(), classHelper.dr["PAYMENTS"].ToString(), 
                        closingBalance+Convert.ToDecimal(classHelper.dr["RECEIVED"].ToString())- Convert.ToDecimal(classHelper.dr["PAYMENTS"].ToString()),
                        classHelper.dr["DATE"].ToString());
                        closingBalance = closingBalance + Convert.ToDecimal(classHelper.dr["RECEIVED"].ToString()) - Convert.ToDecimal(classHelper.dr["PAYMENTS"].ToString());
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
        }

        public void ReceiptsData()
        {
            //classHelper.query = @"SELECT 
            //ISNULL((SELECT NAME FROM SALES_PERSONS WHERE SALES_PER_ID = 
            //(SELECT SALE_PER_ID FROM CUSTOMER_PROFILE WHERE COA_ID = A.COA_ID)),'OTHER') AS [SALES PERSON],
            //B.COA_NAME AS [ACCOUNT NAME],
            //SUM(A.CREDIT) AS [RECEIVED]
            //FROM LEDGERS A
            //INNER JOIN COA B ON A.COA_ID = B.COA_ID
            //INNER JOIN (
            //SELECT REF_ID FROM LEDGERS WHERE COA_ID = 5180 AND DATE BETWEEN '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
            //) D ON A.REF_ID = D.REF_ID
            //WHERE A.COA_ID <> 5180 AND A.DEBIT = 0
            //GROUP BY B.COA_NAME,A.COA_ID";

            classHelper.query = @"WITH A AS (
            SELECT 
            ISNULL((SELECT NAME FROM SALES_PERSONS WHERE SALES_PER_ID = 
            (SELECT SALE_PER_ID FROM CUSTOMER_PROFILE WHERE COA_ID = A.COA_ID)),'OTHER') AS [SALES PERSON],
            B.COA_NAME AS [ACCOUNT NAME],
            SUM(A.CREDIT) AS [RECEIVED]
            FROM LEDGERS A
            INNER JOIN COA B ON A.COA_ID = B.COA_ID
            INNER JOIN (
            SELECT REF_ID,ENTRY_OF FROM LEDGERS WHERE COA_ID = "+Classes.Helper.cashId+@" AND DATE BETWEEN '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
            ) D ON A.REF_ID = D.REF_ID AND A.ENTRY_OF = D.ENTRY_OF
            WHERE A.COA_ID <> "+Classes.Helper.cashId+@" AND A.DEBIT = 0 AND DATE BETWEEN '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
            GROUP BY B.COA_NAME,A.COA_ID)

            SELECT A.[SALES PERSON],SUM(A.RECEIVED) AS [RECEIVED] FROM A GROUP BY A.[SALES PERSON]";
            Classes.Helper.conn.Open();
            try
            {
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    classHelper.nds.Tables["CashBookReceipts"].Clear();
                    while (classHelper.dr.Read())
                    {
                        classHelper.dataR = classHelper.nds.Tables["CashBookReceipts"].NewRow();
                        classHelper.dataR["accountName"] = classHelper.dr["SALES PERSON"].ToString();
                        classHelper.dataR["amount"] = Convert.ToDouble(classHelper.dr["RECEIVED"].ToString());
                        classHelper.nds.Tables["CashBookReceipts"].Rows.Add(classHelper.dataR);
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
        }

        public void PaymentData()
        {
            classHelper.query = @"SELECT B.COA_NAME AS [ACCOUNT NAME],
            SUM(A.DEBIT) AS [PAYMENTS]
            FROM LEDGERS A
            INNER JOIN COA B ON A.COA_ID = B.COA_ID
            INNER JOIN (
            SELECT REF_ID,ENTRY_OF FROM LEDGERS WHERE COA_ID = "+Classes.Helper.cashId+@" AND DATE BETWEEN '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
            ) D ON A.REF_ID = D.REF_ID AND A.ENTRY_OF = D.ENTRY_OF
            WHERE A.COA_ID <> "+Classes.Helper.cashId+@"  AND A.CREDIT = 0 AND DATE BETWEEN '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
            GROUP BY B.COA_NAME";
            Classes.Helper.conn.Open();
            try
            {
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    classHelper.nds.Tables["CashBookPayments"].Clear();
                    while (classHelper.dr.Read())
                    {
                        classHelper.dataR = classHelper.nds.Tables["CashBookPayments"].NewRow();
                        classHelper.dataR["accountName"] = classHelper.dr["ACCOUNT NAME"].ToString();
                        classHelper.dataR["amount"] = Convert.ToDouble(classHelper.dr["PAYMENTS"].ToString());
                        classHelper.nds.Tables["CashBookPayments"].Rows.Add(classHelper.dataR);
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
        }

        private void ReportData()
        {
            char hasRows = 'N';
            try
            {
                if (grdSEARCH.Rows.Count > 0)
                {
                    classHelper.nds.Tables["CashBook"].Clear();
                    foreach (DataGridViewRow row in grdSEARCH.Rows)
                    {
                        if (!row.Cells["accountName"].Value.ToString().Equals("BALANCE BROUGHT FORWARDED")) {
                            hasRows = 'Y';
                            classHelper.dataR = classHelper.nds.Tables["CashBook"].NewRow();
                            classHelper.dataR["id"] = row.Cells["refNo"].Value.ToString();
                            classHelper.dataR["accountType"] = row.Cells["accountType"].Value.ToString();
                            classHelper.dataR["accountName"] = row.Cells["accountName"].Value.ToString();
                            classHelper.dataR["refAccount"] = row.Cells["refAccount"].Value.ToString();
                            classHelper.dataR["narration"] = row.Cells["narration"].Value.ToString();
                            classHelper.dataR["receipts"] = Convert.ToDouble(row.Cells["received"].Value.ToString());
                            classHelper.dataR["payments"] = Convert.ToDouble(row.Cells["payment"].Value.ToString());
                            classHelper.dataR["closing"] = Convert.ToDouble(row.Cells["balance"].Value.ToString());
                            classHelper.dataR["from"] = Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date);
                            classHelper.dataR["to"] = Classes.Helper.ConvertDatetime(dtp_TO.Value.Date);
                            classHelper.dataR["opening"] = openingBalance;
                            classHelper.dataR["ending"] = closingBalance;
                            classHelper.dataR["date"] = row.Cells["date"].Value.ToString();
                            classHelper.nds.Tables["CashBook"].Rows.Add(classHelper.dataR);
                        }
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
                ReceiptsData();
                PaymentData();

                classHelper.rpt = new frmReports();
                classHelper.rpt.GenerateReport("CashBookReport", classHelper.nds);
                classHelper.rpt.ShowDialog();
            }
        }

        private void generate()
        {
            grdSEARCH.Rows.Clear();
            opening_bal();
            ledger_Entry();
        }
        
        private void btnINTER_SAVE_Click(object sender, EventArgs e)
        {
            generate();
            if (grdSEARCH.Rows.Count > 0)
            {
                ReportData();
            }
        }

        
        private void frm_Account_Ledger_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void frm_CashBookReport_Load(object sender, EventArgs e)
        {
            load_account();
        }
    }
}
