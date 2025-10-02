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
    public partial class frmChqPaidReport : Form
    {
        public frmChqPaidReport()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.R))
            {
                Generate();
                ShowReport();
            }
            if (keyData == (Keys.Escape))
            {
                this.Dispose();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        Classes.Helper classHelper = new Classes.Helper();


        private void Generate()
        {


            string query = @"SELECT CAST(G.PAY_DATE as date) as [PAY_DATE],H.COA_NAME as [PAID_ACCOUNT],E.COA_NAME AS [REC_FROM],
                    G.AMOUNT as[AMOUNT],
                    ISNULL(G.CHQ_NO,'-') as [CHQ_NO],ISNULL(G.BANK_NAME,'-') as [BANK],CONVERT(date,G.CHQ_DATE) as [CHQ_DATE],
                    F.DAY_BOOK_ID
			        FROM DAY_BOOK D             
			        LEFT JOIN DAY_BOOK_CHQ F ON D.DAY_BOOK_ID =f.DAY_BOOK_ID
			        LEFT JOIN CHQ G ON F.CHQ_ID = G.CHQ_ID
					LEFT JOIN COA H ON H.COA_ID = D.DEBIT_AC
                    LEFT JOIN COA E ON E.COA_ID=G.REC_AC
                    WHERE D.ENTRY_OF='PAYMENT VOUCHER' AND G.STATUS = 0
                    AND DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '";

            if (dtp_FROM.Value.Date.ToString().Equals(dtp_TO.Value.Date.ToString()))
            {
                query+= dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)+@"'";
            }
            else
                query+= dtp_TO.Value.Date + @"'";
					


           
            if (cmbPaidAcc.SelectedIndex > 0)
                query += @" AND H.COA_ID = '" + cmbPaidAcc.SelectedValue.ToString() + "' ";


            query += @" GROUP BY G.PAY_DATE,H.COA_NAME,E.COA_NAME,G.AMOUNT,G.CHQ_NO,G.BANK_NAME,G.CHQ_DATE,F.DAY_BOOK_ID
                        ORDER BY E.COA_NAME,G.BANK_NAME";

            //if(cmbSalesPerson.SelectedIndex > 0)
            //    query += " AND "

            //if (cmbCustomer.SelectedIndex > 0)
            //    query += @" AND ";

            try
            {
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                classHelper.dt = new DataTable();
                classHelper.dt.Load(classHelper.dr);
                grdSEARCH.DataSource = classHelper.dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Classes.Helper.conn.Close();
            }
        }

        private void ShowReport()
        {
            DataGridView dg = grdSEARCH;
            classHelper.nds.Tables["ChqPaid"].Clear();
            for (int i = 0; i < dg.Rows.Count; i++)
            {
                classHelper.dataR = classHelper.nds.Tables["ChqPaid"].NewRow();
                classHelper.dataR[0] = DateTime.Parse(dg.Rows[i].Cells["PAY_DATE"].Value.ToString()).ToString("dddd, dd MMMM yyyy");
                classHelper.dataR[1] = dg.Rows[i].Cells["PAID_ACCOUNT"].Value.ToString();
                classHelper.dataR[2] = dg.Rows[i].Cells["REC_FROM"].Value.ToString();
                classHelper.dataR[3] = dg.Rows[i].Cells["AMOUNT"].Value.ToString();
                classHelper.dataR[4] = dg.Rows[i].Cells["BANK"].Value.ToString();
                classHelper.dataR[5] = DateTime.Parse(dg.Rows[i].Cells["CHQ_DATE"].Value.ToString()).ToString("dd/MM/yyyy");
                classHelper.dataR[6] = dg.Rows[i].Cells["CHQ_NO"].Value.ToString();
                classHelper.dataR[7] = dtp_FROM.Value.Date.ToString("dddd, dd MMMM yyyy");
                classHelper.dataR[8] = dtp_TO.Value.Date.ToString("dddd, dd MMMM yyyy");
                classHelper.dataR[9] = dg.Rows[i].Cells["DAY_BOOK_ID"].Value.ToString();


                classHelper.nds.Tables["ChqPaid"].Rows.Add(classHelper.dataR);

            }
            classHelper.rpt = new frmReports();
            if (cmbPaidAcc.SelectedIndex > 0)
                classHelper.rpt.headingTextChange = "PAID ACCOUNT WISE CHQ PAID/DEPOSIT REPORT";

             


            classHelper.rpt.GenerateReport("CHQPAID", classHelper.nds);
            classHelper.rpt.ShowDialog();
        }

        private void LoadPaidAccounts()
        {
            classHelper.query = @"SELECT '0' AS [id],'--SELECT ACCOUNT--' AS [name]
                UNION
                SELECT COA_ID AS [id],COA_NAME AS [name] FROM COA WHERE STAT = 0 order by name";
            classHelper.LoadComboData(cmbPaidAcc, classHelper.query);
        }

        private void btnSHOW_Click(object sender, EventArgs e)
        {
            Generate();
            ShowReport();
        }

        private void frmChqPaidReport_Load(object sender, EventArgs e)
        {
            LoadPaidAccounts();
        }
    }
}
