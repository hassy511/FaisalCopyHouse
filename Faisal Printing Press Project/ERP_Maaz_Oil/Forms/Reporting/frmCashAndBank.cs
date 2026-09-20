using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP_Maaz_Oil.Forms.Reporting
{
    public partial class frmCashAndBank : Form
    {
        public frmCashAndBank()
        {
            InitializeComponent();
        }

        Classes.Helper cls_fhp = new Classes.Helper();

        public void ledger_entry()
        {
            cls_fhp.query = @"	WITH X AS (
            SELECT A.COA_ID,A.COA_NAME AS [ACCOUNT],
            CASE WHEN A.DR_CR = 'D' THEN OPEN_BAL ELSE -OPEN_BAL END AS [OPENING],
            (SELECT ISNULL(SUM(DEBIT) - SUM(CREDIT),0) FROM LEDGERS WHERE COA_ID = A.COA_ID AND [DATE] < '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + @"') AS [LEDGER OPENING],
            ISNULL(C.RECEIVED,0) AS [RECEIVED],ISNULL(C.PAYMENT,0) AS [PAYMENT]
            FROM COA A
            LEFT JOIN (
	            SELECT B.COA_ID,
	            SUM(B.DEBIT) AS [RECEIVED], SUM(B.CREDIT) AS [PAYMENT]
	            FROM LEDGERS B
	            WHERE B.[DATE] BETWEEN '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + @"' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
	            GROUP BY B.COA_ID
            ) C ON A.COA_ID = C.COA_ID
            WHERE A.CA_ID in (5,6))

            SELECT [ACCOUNT],OPENING+[LEDGER OPENING] AS [OPENING],
            RECEIVED,PAYMENT as [PAYMENTS],(OPENING+[LEDGER OPENING])+RECEIVED-PAYMENT AS [CLOSING]
            FROM X
            UNION ALL
            --FOR SHOWING ACCOUNTS WITH NO RECORDS
            SELECT COA_NAME,0,0,0,0 FROM COA
            WHERE COA_NAME not in (SELECT [ACCOUNT] FROM X) AND AG_ID in (9,10)
            ORDER BY [ACCOUNT]

";

            cls_fhp.LoadGrid(grdSEARCH, cls_fhp.query);
        }

        private void ReportData()
        {
            char hasRows = 'N';
            try
            {
                if (grdSEARCH.Rows.Count > 0)
                {

                    cls_fhp.nds.Tables["CashAndBank"].Clear();
                    foreach (DataGridViewRow row in grdSEARCH.Rows)
                    {
                        hasRows = 'Y';
                        cls_fhp.dataR = cls_fhp.nds.Tables["CashAndBank"].NewRow();
                        cls_fhp.dataR["accName"] = row.Cells["ACCOUNT"].Value.ToString();
                        cls_fhp.dataR["closing"] = row.Cells["closing"].Value.ToString();
                        cls_fhp.dataR["opening"] = row.Cells["opening"].Value.ToString();
                        cls_fhp.dataR["payment"] = row.Cells["payments"].Value.ToString();
                        cls_fhp.dataR["received"] = row.Cells["received"].Value.ToString();
                    
                        cls_fhp.dataR["from"] = (dtp_FROM.Value.Date.ToString("dd-MMM-yyyy"));
                        cls_fhp.dataR["to"] = (dtp_TO.Value.Date.ToString("dd-MMM-yyyy"));
                  

                        cls_fhp.nds.Tables["CashAndBank"].Rows.Add(cls_fhp.dataR);

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
                //ReceiptsData();
                //PaymentData();

                cls_fhp.rpt = new frmReports();
                cls_fhp.rpt.GenerateReport("CashAndBank", cls_fhp.nds);
                cls_fhp.rpt.ShowDialog();
            }
        }

        private void btnSHOW_Click(object sender, EventArgs e)
        {
            ledger_entry();
            ReportData();
        }
    }
}
