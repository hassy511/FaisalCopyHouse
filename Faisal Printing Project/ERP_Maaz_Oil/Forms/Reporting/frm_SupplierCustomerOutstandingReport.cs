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
    public partial class frm_SupplierCustomerOutstandingReport : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        public frm_SupplierCustomerOutstandingReport()
        {
            InitializeComponent();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.R))
            {
                if (rdbCustomer.Checked == true)
                {
                    CustomerReport();
                }
                else if (rdbSupplier.Checked == true)
                {
                    SupplierReport();
                }
                else if (rdbOverallDetailReport.Checked == true)
                {
                    OverallReport();
                }
            }
            if (keyData == (Keys.Escape))
            {
                this.Dispose();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        //private void LoadSalesPerson()
        //{
        //    classHelper.query = @"SELECT '0' AS [id],'-ALL-' as [name]
        //    UNION ALL
        //    SELECT SALES_PER_ID AS [id],NAME AS [name] FROM SALES_PERSONS WHERE SALES_PER_ID <> '1' ORDER BY [name]";
        //    classHelper.LoadComboData(cmbSalePerson, classHelper.query);
        //}
        private void LoadCustomer()
        {
            classHelper.query = @"SELECT '0' AS [id],'-ALL-' as [name]
            UNION ALL
            SELECT COA_ID AS [id],COA_NAME AS [name] FROM COA ORDER BY [name]";
            classHelper.LoadComboData(cmbCustomer, classHelper.query);
        }
        private void LoadSupplier()
        {
            classHelper.query = @"SELECT '0' AS [id],'-ALL-' as [name]
            UNION ALL
            SELECT COA_ID AS [id],COA_NAME AS [name] FROM COA ORDER BY [name]";
            classHelper.LoadComboData(cmbSupplier, classHelper.query);
        }

        private void CustomerReport()
        {
            if (rdbCustomer.Checked == true && cmbCustomer.SelectedIndex == 0)
            {
                classHelper.query = @"WITH B AS (
                SELECT A.COA_ID,A.COA_NAME AS [CUSTOMER],
				ISNUll(A.OPEN_BAL,0) + 
				(SELECT ISNUll(SUM(DEBIT),0) - ISNUll(SUM(CREDIT),0) 
					FROM LEDGERS WHERE COA_ID = A.COA_ID AND [DATE] < '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + @"') AS [OPENING],
                (
	                SELECT (SELECT ISNULL(SUM(Y.TOTAL_WEIGHT),0)
	                FROM SALES X
	                INNER JOIN SALES_PROGRAM_MASTER Y ON X.SOP_ID = Y.SPM_ID
	                WHERE Y.customer_id = A.COA_ID AND Y.[date] BETWEEN
	                '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"')
	                +
	                (SELECT ISNULL(SUM(sales_weight),0) FROM purchases_sales_transfer 
	                WHERE customer_id = A.COA_ID AND [date] BETWEEN
	                '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"')
                ) AS [SALES KGS],
                (
	                SELECT (SELECT ISNULL(SUM(Y.TOTAL),0)
	                FROM SALES X
	                INNER JOIN SALES_PROGRAM_MASTER Y ON X.SOP_ID = Y.SPM_ID
	                WHERE Y.customer_id = A.COA_ID AND Y.[date] BETWEEN
	                '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"')
	                +
	                (SELECT ISNULL(SUM(total),0) FROM purchases_sales_transfer 
	                WHERE customer_id = A.COA_ID AND [date] BETWEEN
	                '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"')
                ) AS [SALES AMOUNT],
                (
	                SELECT ISNULL(SUM(CREDIT),0)
	                FROM LEDGERS WHERE COA_ID = A.COA_ID AND [DATE] BETWEEN
	                '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
	                --SELECT ISNULL(SUM(AMOUNT),0)
	                --FROM PAYMENT_TRANSFER 
	                --WHERE [STATUS] = 1 AND REC_AC = A.COA_ID AND [CONFORMATION_DATE] BETWEEN
	                --'2019-09-01 00:00:00' AND '2020-09-05 23:59:59'
                ) AS [RECEVIED AMOUNT],
                (
	                SELECT (SELECT ISNULL(SUM(AMOUNT),0)
	                FROM CHQ
	                WHERE REC_AC = A.COA_ID AND [REC_DATE] <= '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"' AND [STATUS] = 1)
	                +
	                (SELECT ISNULL(SUM(AMOUNT),0)
	                FROM PAYMENT_TRANSFER 
	                WHERE [STATUS] = 0 AND REC_AC = A.COA_ID AND [date] <= '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"')
                ) AS [PENDING AMOUNT],
                (
                    SELECT ISNULL(SUM(DEBIT),0) - ISNULL(SUM(CREDIT),0)
                    FROM LEDGERS 
                    WHERE ENTRY_OF = 'JOURNAL VOUCHER' AND COA_ID = A.COA_ID AND [date] BETWEEN
                    '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
                ) AS [JV AMOUNT]
                FROM COA A
                WHERE CA_ID IN (21)
                )
                SELECT CUSTOMER,[SALES KGS],[SALES AMOUNT],([RECEVIED AMOUNT]) AS [RECEVIED AMOUNT],[PENDING AMOUNT],[OPENING]+[SALES AMOUNT]-[RECEVIED AMOUNT]-[PENDING AMOUNT] AS [RECEIVABLE AMOUNT] 
                FROM B
                WHERE [SALES KGS] <> 0 OR [SALES AMOUNT] <> 0 OR ([RECEVIED AMOUNT]) <> 0 OR [PENDING AMOUNT] <> 0 OR 
                ([OPENING]+[SALES AMOUNT]-[RECEVIED AMOUNT]-[PENDING AMOUNT]) <> 0 ";
            }
            else if (rdbCustomer.Checked == true && cmbCustomer.SelectedIndex != 0)
            {
                classHelper.query = @"WITH B AS (
                SELECT A.COA_ID,A.COA_NAME AS [CUSTOMER],
				ISNUll(A.OPEN_BAL,0) + 
				(SELECT ISNUll(SUM(DEBIT),0) - ISNUll(SUM(CREDIT),0) 
					FROM LEDGERS WHERE COA_ID = A.COA_ID AND [DATE] < '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + @"') AS [OPENING],
                (
	                SELECT (SELECT ISNULL(SUM(Y.TOTAL_WEIGHT),0)
	                FROM SALES X
	                INNER JOIN SALES_PROGRAM_MASTER Y ON X.SOP_ID = Y.SPM_ID
	                WHERE Y.customer_id = A.COA_ID AND Y.[date] BETWEEN
	                '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"')
	                +
	                (SELECT ISNULL(SUM(sales_weight),0) FROM purchases_sales_transfer 
	                WHERE customer_id = A.COA_ID AND [date] BETWEEN
	                '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"')
                ) AS [SALES KGS],
                (
	                SELECT (SELECT ISNULL(SUM(Y.TOTAL),0)
	                FROM SALES X
	                INNER JOIN SALES_PROGRAM_MASTER Y ON X.SOP_ID = Y.SPM_ID
	                WHERE Y.customer_id = A.COA_ID AND Y.[date] BETWEEN
	                '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"')
	                +
	                (SELECT ISNULL(SUM(total),0) FROM purchases_sales_transfer 
	                WHERE customer_id = A.COA_ID AND [date] BETWEEN
	                '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"')
                ) AS [SALES AMOUNT],
                (
	                SELECT ISNULL(SUM(CREDIT),0)
	                FROM LEDGERS WHERE COA_ID = A.COA_ID AND [DATE] BETWEEN
	                '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
	                --SELECT ISNULL(SUM(AMOUNT),0)
	                --FROM PAYMENT_TRANSFER 
	                --WHERE [STATUS] = 1 AND REC_AC = A.COA_ID AND [CONFORMATION_DATE] BETWEEN
	                --'2019-09-01 00:00:00' AND '2020-09-05 23:59:59'
                ) AS [RECEVIED AMOUNT],
                (
	                SELECT (SELECT ISNULL(SUM(AMOUNT),0)
	                FROM CHQ
	                WHERE REC_AC = A.COA_ID AND [REC_DATE] <= '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"' AND [STATUS] = 1)
	                +
	                (SELECT ISNULL(SUM(AMOUNT),0)
	                FROM PAYMENT_TRANSFER 
	                WHERE [STATUS] = 0 AND REC_AC = A.COA_ID AND [date] <= '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"')
                ) AS [PENDING AMOUNT],
                (
                    SELECT ISNULL(SUM(DEBIT),0) - ISNULL(SUM(CREDIT),0)
                    FROM LEDGERS 
                    WHERE ENTRY_OF = 'JOURNAL VOUCHER' AND COA_ID = A.COA_ID AND [date] BETWEEN
                    '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
                ) AS [JV AMOUNT]
                FROM COA A
                WHERE CA_ID IN (21) AND COA_ID = '" + cmbCustomer.SelectedValue.ToString() + @"'
                )
                SELECT CUSTOMER,[SALES KGS],[SALES AMOUNT],([RECEVIED AMOUNT]) AS [RECEVIED AMOUNT],[PENDING AMOUNT],[OPENING]+[SALES AMOUNT]-[RECEVIED AMOUNT]-[PENDING AMOUNT] AS [RECEIVABLE AMOUNT] 
                FROM B
                WHERE [SALES KGS] <> 0 OR [SALES AMOUNT] <> 0 OR ([RECEVIED AMOUNT]) <> 0 OR [PENDING AMOUNT] <> 0 OR 
                ([OPENING]+[SALES AMOUNT]-[RECEVIED AMOUNT]-[PENDING AMOUNT]) <> 0 ";
            }

            char hasRows = 'N';
            try
            {
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    hasRows = 'Y';
                    classHelper.nds.Tables["CustomerOutstanding"].Clear();
                    while (classHelper.dr.Read())
                    {
                        //if (Convert.ToDecimal(classHelper.dr["RECEIVABLE AMOUNT"].ToString()) != 0)
                        //{
                        classHelper.dataR = classHelper.nds.Tables["CustomerOutstanding"].NewRow();
                        classHelper.dataR["account"] = classHelper.dr["CUSTOMER"].ToString();
                        classHelper.dataR["kgs"] = Convert.ToDecimal(classHelper.dr["SALES KGS"].ToString());
                        classHelper.dataR["amount"] = Convert.ToDecimal(classHelper.dr["SALES AMOUNT"].ToString());
                        classHelper.dataR["paid"] = Convert.ToDecimal(classHelper.dr["RECEVIED AMOUNT"].ToString());
                        classHelper.dataR["pending"] = Convert.ToDecimal(classHelper.dr["PENDING AMOUNT"].ToString());
                        classHelper.dataR["balance"] = Convert.ToDecimal(classHelper.dr["RECEIVABLE AMOUNT"].ToString());
                        classHelper.dataR["from"] = Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date);
                        classHelper.dataR["to"] = Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59));
                        classHelper.nds.Tables["CustomerOutstanding"].Rows.Add(classHelper.dataR);
                        //}
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
                classHelper.rpt.GenerateReport("CustomerOutstanding", classHelper.nds);
                classHelper.rpt.ShowDialog();
            }
        }
        private void SupplierReport()
        {
            if (rdbSupplier.Checked == true && cmbSupplier.SelectedIndex == 0)
            {
                classHelper.query = @"WITH A AS (
                SELECT A.COA_ID,A.COA_NAME AS [SUPPLIER],A.OPEN_BAL AS [OPENING],
                (
	                SELECT ISNULL(SUM(NET_WEIGHT),0) FROM PURCHASES 
	                WHERE SUPPLIER_ID = A.COA_ID AND [date] BETWEEN
	                '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
                ) AS [PURCHASED KGS],
                (
                    --round((MUAND_RATE/MUAND_VALUE),0)
	                SELECT ISNULL(SUM(ROUND((NET_WEIGHT * KG_RATE),0)),0) 
                    FROM PURCHASES 
	                WHERE SUPPLIER_ID = A.COA_ID AND [date] BETWEEN
	                '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
                ) AS [PURCHASED AMOUNT],
                (
	                SELECT ISNULL(SUM(AMOUNT),0)
	                FROM PAYMENT_TRANSFER 
	                WHERE [STATUS] = 1 AND PAY_AC = A.COA_ID AND [CONFORMATION_DATE] BETWEEN
	                '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
                ) AS [PAID AMOUNT],
                (
	                SELECT ISNULL(SUM(AMOUNT),0)
	                FROM PAYMENT_TRANSFER 
	                WHERE [STATUS] = 0 AND PAY_AC = A.COA_ID AND [date] <= '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
                ) AS [PENDING AMOUNT],
                (
	                SELECT ISNULL(SUM(DEBIT),0) - ISNULL(SUM(CREDIT),0)
	                FROM LEDGERS 
	                WHERE ENTRY_OF = 'JOURNAL VOUCHER' AND COA_ID = A.COA_ID AND [date] BETWEEN
	                '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
                ) AS [JV AMOUNT],
                (
	                SELECT 
	                (SELECT CASE WHEN DR_CR = 'D' THEN ISNULL(OPEN_BAL,0) ELSE ISNULL(-OPEN_BAL,0) END FROM COA WHERE COA_ID = A.COA_ID)+
	                ISNULL(SUM(DEBIT),0) - ISNULL(SUM(CREDIT),0)
	                FROM LEDGERS 
	                WHERE COA_ID = A.COA_ID AND [date] <= '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
                ) AS [PAYABLE AMOUNT]
                FROM COA A
                WHERE CA_ID IN (20)
                )
                SELECT SUPPLIER,[PURCHASED KGS],[PURCHASED AMOUNT],([PAID AMOUNT] - [JV AMOUNT]) AS [PAID AMOUNT],[PENDING AMOUNT],[PAYABLE AMOUNT] AS [PAYABLE AMOUNT] 
                FROM A
            WHERE [PAYABLE AMOUNT] <> 0        
            --WHERE [PURCHASED KGS] <> 0 OR [PURCHASED AMOUNT] <> 0 OR ([PAID AMOUNT] - [JV AMOUNT]) <> 0 OR [PENDING AMOUNT] <> 0 OR 
            --([PURCHASED AMOUNT]-[PAID AMOUNT]-[PENDING AMOUNT] + [JV AMOUNT])  <> 0";
            }
            else if (rdbSupplier.Checked == true && cmbSupplier.SelectedIndex != 0)
            {
                classHelper.query = @"WITH A AS (
                SELECT A.COA_ID,A.COA_NAME AS [SUPPLIER],A.OPEN_BAL AS [OPENING],
                (
	                SELECT ISNULL(SUM(NET_WEIGHT),0) FROM PURCHASES 
	                WHERE SUPPLIER_ID = A.COA_ID AND [date] BETWEEN
	                '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
                ) AS [PURCHASED KGS],
                (
	                --round((MUAND_RATE/MUAND_VALUE),0)
	                SELECT ISNULL(SUM(ROUND((NET_WEIGHT * KG_RATE),0)),0) 
                    FROM PURCHASES 
	                WHERE SUPPLIER_ID = A.COA_ID AND [date] BETWEEN
	                '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
                ) AS [PURCHASED AMOUNT],
                (
                    SELECT ISNULL(SUM(DEBIT),0)
	                FROM LEDGERS WHERE COA_ID = A.COA_ID AND [DATE] BETWEEN
	                '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
	                --SELECT ISNULL(SUM(AMOUNT),0)
	                --FROM PAYMENT_TRANSFER 
	                --WHERE [STATUS] = 1 AND PAY_AC = A.COA_ID AND [CONFORMATION_DATE] BETWEEN
	                --'" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
                ) AS [PAID AMOUNT],
                (
	                SELECT ISNULL(SUM(AMOUNT),0)
	                FROM PAYMENT_TRANSFER 
	                WHERE [STATUS] = 0 AND PAY_AC = A.COA_ID AND [date] <= '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
                ) AS [PENDING AMOUNT],
                (
	                SELECT ISNULL(SUM(DEBIT),0) - ISNULL(SUM(CREDIT),0)
	                FROM LEDGERS 
	                WHERE ENTRY_OF = 'JOURNAL VOUCHER' AND COA_ID = A.COA_ID AND [date] BETWEEN
	                '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
                ) AS [JV AMOUNT],
                (
	                SELECT 
	                (SELECT CASE WHEN DR_CR = 'D' THEN ISNULL(OPEN_BAL,0) ELSE ISNULL(-OPEN_BAL,0) END FROM COA WHERE COA_ID = A.COA_ID)+
	                ISNULL(SUM(DEBIT),0) - ISNULL(SUM(CREDIT),0)
	                FROM LEDGERS 
	                WHERE COA_ID = A.COA_ID AND [date] <= '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
                ) AS [PAYABLE AMOUNT]
                FROM COA A
                WHERE CA_ID IN (20) AND COA_ID = '" + cmbSupplier.SelectedValue.ToString() + @"'
                )
                SELECT SUPPLIER,[PURCHASED KGS],[PURCHASED AMOUNT],([PAID AMOUNT] - [JV AMOUNT]) AS [PAID AMOUNT],[PENDING AMOUNT],[PAYABLE AMOUNT] AS [PAYABLE AMOUNT] 
                FROM A   
            WHERE [PAYABLE AMOUNT] <> 0        
            --WHERE [PURCHASED KGS] <> 0 OR [PURCHASED AMOUNT] <> 0 OR ([PAID AMOUNT] - [JV AMOUNT]) <> 0 OR [PENDING AMOUNT] <> 0 OR 
            --([PURCHASED AMOUNT]-[PAID AMOUNT]-[PENDING AMOUNT] + [JV AMOUNT])  <> 0";
            }

            char hasRows = 'N';
            try
            {
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    hasRows = 'Y';
                    classHelper.nds.Tables["SupplierOutstanding"].Clear();
                    while (classHelper.dr.Read())
                    {
                        //if (Convert.ToDecimal(classHelper.dr["PAYABLE AMOUNT"].ToString()) != 0)
                        //{
                        classHelper.dataR = classHelper.nds.Tables["SupplierOutstanding"].NewRow();
                        classHelper.dataR["account"] = classHelper.dr["SUPPLIER"].ToString();
                        classHelper.dataR["kgs"] = Convert.ToDecimal(classHelper.dr["PURCHASED KGS"].ToString());
                        classHelper.dataR["amount"] = Convert.ToDecimal(classHelper.dr["PURCHASED AMOUNT"].ToString());
                        classHelper.dataR["paid"] = Convert.ToDecimal(classHelper.dr["PAID AMOUNT"].ToString());
                        classHelper.dataR["pending"] = Convert.ToDecimal(classHelper.dr["PENDING AMOUNT"].ToString());
                        classHelper.dataR["balance"] = Convert.ToDecimal(classHelper.dr["PAYABLE AMOUNT"].ToString());
                        classHelper.dataR["from"] = Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date);
                        classHelper.dataR["to"] = Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59));
                        classHelper.nds.Tables["SupplierOutstanding"].Rows.Add(classHelper.dataR);
                        //}
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
                classHelper.rpt.GenerateReport("SupplierOutstanding", classHelper.nds);
                classHelper.rpt.ShowDialog();
            }
        }
        private void OverallReport()
        {
            classHelper.query = @"WITH B AS (
                SELECT A.COA_ID,A.COA_NAME AS [CUSTOMER],A.OPEN_BAL AS [OPENING],
                (
	                SELECT ISNULL(SUM(sales_weight),0) FROM purchases_sales_transfer 
	                WHERE customer_id = A.COA_ID AND [date] BETWEEN
	                '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
                ) AS [SALES KGS],
                (
	                SELECT ISNULL(SUM(total),0) FROM purchases_sales_transfer 
	                WHERE customer_id = A.COA_ID AND [date] BETWEEN
	                '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
                ) AS [SALES AMOUNT],
                (
	                SELECT ISNULL(SUM(AMOUNT),0)
	                FROM PAYMENT_TRANSFER 
	                WHERE [STATUS] = 1 AND REC_AC = A.COA_ID AND [CONFORMATION_DATE] BETWEEN
	                '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
                ) AS [RECEVIED AMOUNT],
                (
	                SELECT ISNULL(SUM(AMOUNT),0)
	                FROM PAYMENT_TRANSFER 
	                WHERE [STATUS] = 0 AND REC_AC = A.COA_ID AND [date] <= '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
                ) AS [PENDING AMOUNT],
                (
	                SELECT ISNULL(SUM(DEBIT),0) - ISNULL(SUM(CREDIT),0)
	                FROM LEDGERS 
	                WHERE ENTRY_OF = 'JOURNAL VOUCHER' AND COA_ID = A.COA_ID AND [date] BETWEEN
	                '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
                ) AS [JV AMOUNT]
                FROM COA A
                WHERE CA_ID IN (21)
                )
                SELECT CUSTOMER,[SALES KGS],[SALES AMOUNT],([RECEVIED AMOUNT] - [JV AMOUNT]) AS [RECEVIED AMOUNT],[PENDING AMOUNT],[OPENING]+[SALES AMOUNT]-[RECEVIED AMOUNT]-[PENDING AMOUNT] + [JV AMOUNT] AS [RECEIVABLE AMOUNT] 
                FROM B
                WHERE [SALES KGS] <> 0 OR [SALES AMOUNT] <> 0 OR ([RECEVIED AMOUNT] - [JV AMOUNT]) <> 0 OR [PENDING AMOUNT] <> 0 OR 
                ([OPENING]+[SALES AMOUNT]-[RECEVIED AMOUNT]-[PENDING AMOUNT] + [JV AMOUNT]) <> 0 
                ORDER BY CUSTOMER";

            char hasRows = 'N';
            try
            {
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    hasRows = 'Y';
                    classHelper.nds.Tables["CustomerOutstanding"].Clear();
                    while (classHelper.dr.Read())
                    {
                        //if (Convert.ToDecimal(classHelper.dr["RECEIVABLE AMOUNT"].ToString()) != 0) {
                        classHelper.dataR = classHelper.nds.Tables["CustomerOutstanding"].NewRow();
                        classHelper.dataR["account"] = classHelper.dr["CUSTOMER"].ToString();
                        classHelper.dataR["kgs"] = Convert.ToDecimal(classHelper.dr["SALES KGS"].ToString());
                        classHelper.dataR["amount"] = Convert.ToDecimal(classHelper.dr["SALES AMOUNT"].ToString());
                        classHelper.dataR["paid"] = Convert.ToDecimal(classHelper.dr["RECEVIED AMOUNT"].ToString());
                        classHelper.dataR["pending"] = Convert.ToDecimal(classHelper.dr["PENDING AMOUNT"].ToString());
                        classHelper.dataR["balance"] = Convert.ToDecimal(classHelper.dr["RECEIVABLE AMOUNT"].ToString());
                        classHelper.dataR["from"] = Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date);
                        classHelper.dataR["to"] = Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59));
                        classHelper.nds.Tables["CustomerOutstanding"].Rows.Add(classHelper.dataR);
                        //}
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

            classHelper.query = @"WITH A AS (
            SELECT A.COA_ID,A.COA_NAME AS [SUPPLIER],A.OPEN_BAL AS [OPENING],
            (
	            SELECT ISNULL(SUM(NET_WEIGHT),0) FROM PURCHASES 
	            WHERE SUPPLIER_ID = A.COA_ID AND [date] BETWEEN
	            '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
            ) AS [PURCHASED KGS],
            (
	            --round((MUAND_RATE/MUAND_VALUE),0)
	                SELECT ISNULL(SUM(ROUND((NET_WEIGHT * KG_RATE),0)),0) 
                    FROM PURCHASES  
	            WHERE SUPPLIER_ID = A.COA_ID AND [date] BETWEEN
	            '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
            ) AS [PURCHASED AMOUNT],
            (
	            SELECT ISNULL(SUM(AMOUNT),0)
	            FROM PAYMENT_TRANSFER 
	            WHERE [STATUS] = 1 AND PAY_AC = A.COA_ID AND [CONFORMATION_DATE] BETWEEN
	            '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
            ) AS [PAID AMOUNT],
            (
	            SELECT ISNULL(SUM(AMOUNT),0)
	            FROM PAYMENT_TRANSFER 
	            WHERE [STATUS] = 0 AND PAY_AC = A.COA_ID AND [date] <= '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
            ) AS [PENDING AMOUNT],
            (
	            SELECT ISNULL(SUM(DEBIT),0) - ISNULL(SUM(CREDIT),0)
	            FROM LEDGERS 
	            WHERE ENTRY_OF = 'JOURNAL VOUCHER' AND COA_ID = A.COA_ID AND [date] BETWEEN
	            '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
            ) AS [JV AMOUNT],
            (
	            SELECT 
	            (SELECT CASE WHEN DR_CR = 'D' THEN ISNULL(OPEN_BAL,0) ELSE ISNULL(-OPEN_BAL,0) END FROM COA WHERE COA_ID = A.COA_ID)+
	            ISNULL(SUM(DEBIT),0) - ISNULL(SUM(CREDIT),0)
	            FROM LEDGERS 
	            WHERE COA_ID = A.COA_ID AND [date] <= '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
            ) AS [PAYABLE AMOUNT]
            FROM COA A
            WHERE CA_ID IN (20)
            )
            SELECT SUPPLIER,[PURCHASED KGS],[PURCHASED AMOUNT],([PAID AMOUNT] - [JV AMOUNT]) AS [PAID AMOUNT],[PENDING AMOUNT],[PAYABLE AMOUNT] AS [PAYABLE AMOUNT] 
            FROM A
            WHERE [PAYABLE AMOUNT] <> 0        
            --WHERE [PURCHASED KGS] <> 0 OR [PURCHASED AMOUNT] <> 0 OR ([PAID AMOUNT] - [JV AMOUNT]) <> 0 OR [PENDING AMOUNT] <> 0 OR 
            --([PURCHASED AMOUNT]-[PAID AMOUNT]-[PENDING AMOUNT] + [JV AMOUNT])  <> 0
            ORDER BY SUPPLIER";

            try
            {
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    classHelper.nds.Tables["SupplierOutstanding"].Clear();
                    while (classHelper.dr.Read())
                    {
                        //if (Convert.ToDecimal(classHelper.dr["PAYABLE AMOUNT"].ToString()) != 0)
                        //{
                        classHelper.dataR = classHelper.nds.Tables["SupplierOutstanding"].NewRow();
                        classHelper.dataR["account"] = classHelper.dr["SUPPLIER"].ToString();
                        classHelper.dataR["kgs"] = Convert.ToDecimal(classHelper.dr["PURCHASED KGS"].ToString());
                        classHelper.dataR["amount"] = Convert.ToDecimal(classHelper.dr["PURCHASED AMOUNT"].ToString());
                        classHelper.dataR["paid"] = Convert.ToDecimal(classHelper.dr["PAID AMOUNT"].ToString());
                        classHelper.dataR["pending"] = Convert.ToDecimal(classHelper.dr["PENDING AMOUNT"].ToString());
                        classHelper.dataR["balance"] = -Convert.ToDecimal(classHelper.dr["PAYABLE AMOUNT"].ToString());
                        classHelper.dataR["from"] = Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date);
                        classHelper.dataR["to"] = Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59));
                        classHelper.nds.Tables["SupplierOutstanding"].Rows.Add(classHelper.dataR);
                        //}
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
                classHelper.rpt.GenerateReport("SupplierCustomerOutstanding", classHelper.nds);
                classHelper.rpt.ShowDialog();
            }
        }
        private void btnINTER_SAVE_Click(object sender, EventArgs e)
        {
            if (rdbCustomer.Checked == true)
            {
                CustomerReport();
            }
            else if (rdbSupplier.Checked == true)
            {
                SupplierReport();
            }
            else if (rdbOverallDetailReport.Checked == true)
            {
                OverallReport();
            }
        }

        private void frm_Account_Ledger_Load(object sender, EventArgs e)
        {
            LoadCustomer();
            LoadSupplier();
        }

        private void frm_Account_Ledger_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void cmbSalePerson_TextUpdate(object sender, EventArgs e)
        {
            classHelper.CmbTextUpdate(sender as ComboBox);
        }

        private void cmbSalePerson_DropDown(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown += new PreviewKeyDownEventHandler(cmbSalePerson_PreviewKeyDown);
        }

        private void cmbSalePerson_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown -= cmbSalePerson_PreviewKeyDown;
            if (cbo.DroppedDown) cbo.Focus();
        }

        private void rdbSupplier_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbSupplier.Checked == true)
            {
                cmbSupplier.Enabled = true;
            }
            else
            {
                cmbSupplier.Enabled = false;
            }
        }

        private void rdbCustomer_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCustomer.Checked == true)
            {
                cmbCustomer.Enabled = true;
            }
            else
            {
                cmbCustomer.Enabled = false;
            }
        }

        private void cmbSupplier_DropDown(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown += new PreviewKeyDownEventHandler(cmbSupplier_PreviewKeyDown);
        }

        private void cmbSupplier_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown -= cmbSupplier_PreviewKeyDown;
            if (cbo.DroppedDown) cbo.Focus();
        }

        private void cmbCustomer_DropDown(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown += new PreviewKeyDownEventHandler(cmbCustomer_PreviewKeyDown);
        }

        private void cmbCustomer_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown -= cmbCustomer_PreviewKeyDown;
            if (cbo.DroppedDown) cbo.Focus();
        }
    }
}
