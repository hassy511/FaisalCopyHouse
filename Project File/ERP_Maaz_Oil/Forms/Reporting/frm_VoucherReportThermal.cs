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
    public partial class frm_VoucherReportThermal : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        public frm_VoucherReportThermal()
        {
            InitializeComponent();
        }

        private void LoadAccounts()
        {
            classHelper.LoadAllAccounts(cmbCustomer);
        }

        private void ShowReport()
        {

            classHelper.query = @" SELECT C.COA_NAME AS [ACCOUNT],SUM(B.DEBIT) AS [DEBIT],'Dr' AS [TYPE]
            FROM GENERAL_VOUCHER_M A
            INNER JOIN GENERAL_VOUCHER_D B ON A.GV_ID = B.GV_ID
            INNER JOIN COA C ON B.COA_ID = C.COA_ID
            WHERE A.DAATE BETWEEN '" + dtp_FROM.Value.Date.ToString("yyyy-MM-dd") + @"' 
            AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"' ";

            if (cmbCustomer.SelectedIndex > 0)
            {
                classHelper.query += " AND B.COA_ID = '" + cmbCustomer.SelectedValue.ToString() + "'";
            }
            classHelper.query += @" GROUP BY C.COA_NAME
            UNION ALL
            SELECT C.COA_NAME AS [ACCOUNT],-SUM(B.CREDIT) AS [CREDIT],'Cr' AS [TYPE]
            FROM GENERAL_VOUCHER_M A
            INNER JOIN GENERAL_VOUCHER_D B ON A.GV_ID = B.GV_ID
            INNER JOIN COA C ON B.CREDIT_ID = C.COA_ID
            WHERE A.DAATE BETWEEN '" + dtp_FROM.Value.Date.ToString("yyyy-MM-dd") + @"' 
            AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"' ";

            if (cmbCustomer.SelectedIndex > 0)
            {
                classHelper.query += " AND B.CREDIT_ID = '" + cmbCustomer.SelectedValue.ToString() + "'";
            }
            classHelper.query += @" 
            GROUP BY C.COA_NAME
            ORDER BY [ACCOUNT]";
                

            char hasRows = 'N';
            try
            {
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    hasRows = 'Y';
                    classHelper.mds.Tables["SaleInvoice"].Clear();
                    while (classHelper.dr.Read())
                    {
                        classHelper.dataR = classHelper.mds.Tables["SaleInvoice"].NewRow();
                        classHelper.dataR["date"] = dtp_FROM.Value.Date;
                        classHelper.dataR["dueDate"] = dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                        classHelper.dataR["product"] = classHelper.dr["ACCOUNT"].ToString();
                        classHelper.dataR["code"] = classHelper.dr["TYPE"].ToString();
                        classHelper.dataR["amount"] = Convert.ToDecimal(classHelper.dr["DEBIT"].ToString());
                        classHelper.mds.Tables["SaleInvoice"].Rows.Add(classHelper.dataR);
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
                classHelper.rpt.GenerateReport("VoucherReportThermal", classHelper.mds);
                //classHelper.rpt.ShowDialog();
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
            LoadAccounts();

        }

        private void frm_Account_Ledger_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
