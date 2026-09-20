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
    public partial class frm_PayablesStatemenReport : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        public frm_PayablesStatemenReport()
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

        private void LoadSalesPerson()
        {
            classHelper.query = @"SELECT '0' AS [id],'-ALL-' as [name]
            UNION ALL
            SELECT SALES_PER_ID AS [id],NAME AS [name] FROM SALES_PERSONS WHERE SALES_PER_ID <> '1' ORDER BY [name]";
            classHelper.LoadComboData(cmbSalePerson, classHelper.query);
        }

        private void ShowReport()
        {
            classHelper.query = @"SELECT ISNULL(E.NAME,'-') AS [NAME],ISNULL(F.CITY_NAME,'-') AS [CITY_NAME],ISNULL(G.AREA_NAME,'-') AS [AREA_NAME],A.COA_NAME,
            CASE WHEN A.DR_CR = 'C' THEN (A.OPEN_BAL) ELSE (-A.OPEN_BAL) END AS [OPEN],
            ISNULL(C.[DEBIT],0) AS [DEBIT],ISNULL(C.[CREDIT],0) AS [CREDIT],
            CASE WHEN A.DR_CR = 'C' THEN (A.OPEN_BAL+ISNULL(C.BALANCE,0)) ELSE (-A.OPEN_BAL+ISNULL(C.BALANCE,0)) END AS [OPENING]
            FROM COA A
            LEFT JOIN
            (SELECT A.COA_NAME,ISNULL(SUM(DEBIT),0) AS [DEBIT],ISNULL(SUM(CREDIT),0) AS [CREDIT],
            ISNULL(SUM(CREDIT),0) - ISNULL(SUM(DEBIT),0)   AS [BALANCE]
            FROM COA A
            INNER JOIN LEDGERS B ON A.COA_ID = B.COA_ID
            WHERE A.STAT = '0' AND B.DATE <= '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
            AND A.CA_ID IN ('14','20')
            GROUP BY A.COA_NAME) C ON A.COA_NAME = C.COA_NAME
            LEFT JOIN CUSTOMER_PROFILE D ON A.COA_ID = D.COA_ID
            LEFT JOIN SALES_PERSONS E ON D.SALE_PER_ID = E.SALES_PER_ID
            LEFT JOIN CITY F ON D.CITY_ID = F.CITY_ID
            LEFT JOIN AREA G ON D.AREA_ID = G.AREA_ID
            WHERE A.STAT = '0' AND A.CA_ID IN ('14','20')";
            if (cmbSalePerson.SelectedIndex != 0) {
                classHelper.query += " AND D.SALE_PER_ID = '"+cmbSalePerson.SelectedValue.ToString()+"'";
            }
            classHelper.query += "ORDER BY G.AREA_NAME,A.COA_NAME";

            char hasRows = 'N';
            try
            {
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    hasRows = 'Y';
                    classHelper.nds.Tables["ReceivablesSummary"].Clear();
                    while (classHelper.dr.Read())
                    {
                        classHelper.dataR = classHelper.nds.Tables["ReceivablesSummary"].NewRow();
                        classHelper.dataR["from"] = DateTime.Now;//dtp_FROM.Value.Date;
                        classHelper.dataR["to"] = Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59));
                        classHelper.dataR["salesPerson"] = classHelper.dr["NAME"].ToString();
                        classHelper.dataR["title"] = "PAYABLES SUMMARY";
                        classHelper.dataR["city"] = classHelper.dr["CITY_NAME"].ToString();
                        classHelper.dataR["accountName"] = classHelper.dr["COA_NAME"].ToString();
                        classHelper.dataR["area"] = classHelper.dr["AREA_NAME"].ToString();
                        classHelper.dataR["opening"] = Convert.ToDecimal(classHelper.dr["OPEN"].ToString());
                        classHelper.dataR["debit"] = Convert.ToDecimal(classHelper.dr["DEBIT"].ToString());
                        classHelper.dataR["credit"] = Convert.ToDecimal(classHelper.dr["CREDIT"].ToString());
                        classHelper.dataR["closing"] = Convert.ToDecimal(classHelper.dr["OPENING"].ToString());
                        //if (Convert.ToDecimal(classHelper.dr["OPENING"].ToString()) < 0)
                        //{
                        //    classHelper.dataR["debit"] = "0";
                        //    classHelper.dataR["credit"] = Math.Abs(Convert.ToDecimal(classHelper.dr["OPENING"].ToString()));
                        //}
                        //else {
                        //    classHelper.dataR["debit"] = Convert.ToDecimal(classHelper.dr["OPENING"].ToString());
                        //    classHelper.dataR["credit"] = "0";
                        //}
                        classHelper.nds.Tables["ReceivablesSummary"].Rows.Add(classHelper.dataR);
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
            
            if (hasRows == 'Y')
            {
                classHelper.rpt = new frmReports();
                classHelper.rpt.GenerateReport("ReceivablesSummary", classHelper.nds);
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
            LoadSalesPerson();
        }

        private void frm_Account_Ledger_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void pnlHEADER_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
