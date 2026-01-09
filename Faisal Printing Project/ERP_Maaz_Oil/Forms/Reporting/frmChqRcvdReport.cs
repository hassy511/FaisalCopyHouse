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
    public partial class frmChqRcvdReport : Form
    {
        public frmChqRcvdReport()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.R))
            {
                generate();
                showReport();
            }
            if (keyData == (Keys.Escape))
            {
                this.Dispose();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        Classes.Helper classHelper = new Classes.Helper();

        private void generate()
        {
            if (dtp_FROM.Value.Date.ToString() == dtp_TO.Value.Date.ToString())
                dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

            string query = @"SELECT CAST(DATE as date) as [DATE],Isnull(E.COA_NAME,'-') AS [REC_FROM],
                    ISNULL(G.AMOUNT,0) as[AMOUNT],
                    ISNULL(G.CHQ_NO,'-') as [CHQ_NO],ISNULL(G.BANK_NAME,'-') as [BANK],CONVERT(date,G.CHQ_DATE) as [CHQ_DATE]
			        FROM DAY_BOOK D             
                    LEFT JOIN COA E ON E.COA_ID=D.CREDIT_AC
			        LEFT JOIN DAY_BOOK_CHQ F ON D.DAY_BOOK_ID =f.DAY_BOOK_ID
			        LEFT JOIN CHQ G ON F.CHQ_ID = G.CHQ_ID
                    WHERE ENTRY_OF='RECEIPT VOUCHER' --AND G.STATUS = 0
                    AND DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '";
            query+=
                    dtp_TO.Value.Date.ToString()==dtp_FROM.Value.Date.ToString()?
                     dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59).ToString() + @"'" :
                     dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59).ToString() 
                     + @"'";

            if (cmbSalesPerson.SelectedIndex > 0)
            {
                query = @"SELECT CAST(DATE as date) as [DATE],ISNULL(E.COA_NAME,'-') AS [REC_FROM],
                        ISNULL(G.AMOUNT,0) as[AMOUNT],
                        ISNULL(G.CHQ_NO,'-') as [CHQ_NO],ISNULL(G.BANK_NAME,'-') as [BANK],CONVERT(date,G.CHQ_DATE) as [CHQ_DATE]
                        ,I.NAME AS [SALES PERSON]
                        FROM DAY_BOOK D             
                        LEFT JOIN COA E ON E.COA_ID=D.CREDIT_AC
                        LEFT JOIN DAY_BOOK_CHQ F ON D.DAY_BOOK_ID =f.DAY_BOOK_ID
                        LEFT JOIN CHQ G ON F.CHQ_ID = G.CHQ_ID
                        LEFT JOIN CUSTOMER_PROFILE H ON E.COA_ID = H.COA_ID
                        LEFT JOIN SALES_PERSONS I ON H.SALE_PER_ID = I.SALES_PER_ID
                        WHERE ENTRY_OF='RECEIPT VOUCHER' --AND G.STATUS = 0 
                        AND I.SALES_PER_ID = '" + cmbSalesPerson.SelectedValue.ToString() + @"'
                        AND DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '";
                query +=
                        dtp_TO.Value.Date.ToString() == dtp_FROM.Value.Date.ToString() ?
                         dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59).ToString() + @"'" :
                         dtp_TO.Value.Date.ToString()
                         + @"'";
            }

            if (chckChqDate.Checked)
                query += " AND G.CHQ_DATE BETWEEN '" + dtp_ChqDate.Value.Date + "' AND '" + dtp_ChqDate.Value.AddDays(1).Date + "' ";
            if (cmbCustomer.SelectedIndex > 0)
                query += @" AND E.COA_ID = '" + cmbCustomer.SelectedValue.ToString() + "' ";

            query += " GROUP BY date,E.COA_NAME,G.amount,g.chq_No,g.bank_name,g.chq_date";
            if (cmbSalesPerson.SelectedIndex > 0)
                query += ",I.NAME ";

            query += " ORDER BY DATE,E.COA_NAME,G.BANK_NAME ";

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

        private void showReport()
        {
            DataGridView dg = grdSEARCH;
            classHelper.nds.Tables["ChqInHand"].Clear();
            for (int i = 0; i < dg.Rows.Count; i++)
            {
                classHelper.dataR = classHelper.nds.Tables["ChqInHand"].NewRow();
                classHelper.dataR[0] = DateTime.Parse(dg.Rows[i].Cells["DATE"].Value.ToString()).ToString("dd/MM/yyyy");
                classHelper.dataR[1] = dg.Rows[i].Cells["REC_FROM"].Value.ToString();
                classHelper.dataR[2] = dg.Rows[i].Cells["AMOUNT"].Value.ToString();
                classHelper.dataR[3] = dg.Rows[i].Cells["BANK"].Value.ToString();
                if (dg.Rows[i].Cells["CHQ_DATE"].Value == null || dg.Rows[i].Cells["CHQ_DATE"].Value.ToString().Equals(""))
                    classHelper.dataR[4] = "-";
                else
                    classHelper.dataR[4] = DateTime.Parse(dg.Rows[i].Cells["CHQ_DATE"].Value.ToString()).ToString("dd/MM/yyyy");
                classHelper.dataR[5] = dg.Rows[i].Cells["CHQ_NO"].Value.ToString();
                classHelper.dataR[6] = dtp_FROM.Value.Date.ToString("dddd, dd MMMM yyyy");
                classHelper.dataR[7] = dtp_TO.Value.Date.ToString("dddd, dd MMMM yyyy");


                classHelper.nds.Tables["ChqInHand"].Rows.Add(classHelper.dataR);

            }
            classHelper.rpt = new frmReports();
            if (cmbSalesPerson.SelectedIndex > 0)
                classHelper.rpt.headingTextChange = "SALES PERSON WISE CHQ RECEIVED REPORT";
            else if (chckChqDate.Checked)
                classHelper.rpt.headingTextChange = "CHEQUE DATE WISE CHQ RECEIVED REPORT";
            else if (cmbCustomer.SelectedIndex > 0)
                classHelper.rpt.headingTextChange = "CUSTOMER WISE CHQ RECEIVED REPORT";



            classHelper.rpt.GenerateReport("CHQRCVD", classHelper.nds);
            classHelper.rpt.ShowDialog();

        }


        private void load_customer()
        {
            classHelper.query = @"SELECT '0' AS [id],'--SELECT ACCOUNT--' as [name]
            UNION ALL
            SELECT COA_ID AS [id],COA_NAME AS [name] FROM COA ORDER BY [name]";
            classHelper.LoadComboData(cmbCustomer, classHelper.query);
        }

        private void load_sales_person()
        {
            classHelper.query = @"SELECT 0 as [id], '--SELECT SALES PERSON--' as [name]
					union all
					SELECT sales_per_id as [id], name from SALES_PERSONS";
            classHelper.LoadComboData(cmbSalesPerson, classHelper.query);
        }

        private void btnSHOW_Click(object sender, EventArgs e)
        {
            generate();
            showReport();
        }

        private void frmChqRcvdReport_Load(object sender, EventArgs e)
        {
            load_sales_person();
            load_customer();
        }

        private void chckChqDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chckChqDate.Checked)
                dtp_ChqDate.Enabled = true;
            else
                dtp_ChqDate.Enabled = false;
        }
    }
}
