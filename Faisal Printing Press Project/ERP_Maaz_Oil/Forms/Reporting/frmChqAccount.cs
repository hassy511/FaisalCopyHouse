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
    public partial class frmChqAccount : Form
    {
        public frmChqAccount()
        {
            InitializeComponent();
        }

        Classes.Helper classHelper = new Classes.Helper();

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.R))
            {
                generate();
                show_report();
            }
            if (keyData == (Keys.Escape))
            {
                this.Dispose();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void generate()
        {
            string query = @"SELECT CAST(G.REC_DATE as date) as [DATE],E.COA_NAME AS [REC_FROM],
                    G.AMOUNT as[AMOUNT],
                    ISNULL(G.CHQ_NO,'-') as [CHQ_NO],ISNULL(G.BANK_NAME,'-') as [BANK],CONVERT(date,G.CHQ_DATE) as [CHQ_DATE],
                    ISNULL(CONVERT(varchar(max),G.PAY_DATE),'-') as [PAY_DATE],ISNULL(J.COA_NAME,'-') as [PAID_TO]
			        FROM 
					CHQ G 
					LEFT JOIN COA E ON E.COA_ID=G.REC_AC
                    LEFT JOIN COA J ON J.COA_ID = G.PAY_AC
                    WHERE G.AMOUNT is not null
                    AND 
                    REC_DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'";

            if (cmbSalesPerson.SelectedIndex > 0)
                query = @"SELECT CAST(REC_DATE as date) as [DATE],E.COA_NAME AS [REC_FROM],
                        G.AMOUNT as[AMOUNT],
                        ISNULL(G.CHQ_NO,'-') as [CHQ_NO],ISNULL(G.BANK_NAME,'-') as [BANK],CONVERT(date,G.CHQ_DATE) as [CHQ_DATE]
                        ,I.NAME AS [SALES PERSON],ISNULL(CONVERT(varchar(max),G.PAY_DATE),'-') as [PAY_DATE],ISNULL(J.COA_NAME,'-') as [PAID_TO]
                        FROM CHQ G 
						LEFT JOIN COA E ON E.COA_ID=G.REC_AC
                        LEFT JOIN COA J ON J.COA_ID = G.PAY_AC
                        LEFT JOIN CUSTOMER_PROFILE H ON E.COA_ID = H.COA_ID
                        LEFT JOIN SALES_PERSONS I ON H.SALE_PER_ID = I.SALES_PER_ID
                        WHERE G.AMOUNT is not null--ENTRY_OF='PAYMENT VOUCHER'
                        AND 
                        I.SALES_PER_ID = '" + cmbSalesPerson.SelectedValue.ToString() + @"'
                        AND REC_DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'";

            if (chckChqNo.Checked)
                query += " AND G.CHQ_ID = '" + cmbChqNo.SelectedValue+ "' ";
            if (cmbCustomer.SelectedIndex > 0)
                query += @" AND E.COA_ID = '" + cmbCustomer.SelectedValue.ToString() + "' ";
            query += " ORDER BY CAST(REC_DATE as date),E.COA_NAME,G.BANK_NAME ";

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

        public void show_report()
        {
            DataGridView dg = grdSEARCH;
            classHelper.nds.Tables["ChqPaid"].Clear();
            for (int i = 0; i < dg.Rows.Count; i++)
            {
                classHelper.dataR = classHelper.nds.Tables["ChqPaid"].NewRow();
                if (dg.Rows[i].Cells["PAY_DATE"].Value.ToString().Equals("-"))
                    classHelper.dataR[0] = "-";
                else
                classHelper.dataR[0] = DateTime.Parse(dg.Rows[i].Cells["PAY_DATE"].Value.ToString()).ToString("dd/MM/yyyy");
                classHelper.dataR[1] = dg.Rows[i].Cells["PAID_TO"].Value.ToString();
                classHelper.dataR[2] = dg.Rows[i].Cells["REC_FROM"].Value.ToString();
                classHelper.dataR[3] = dg.Rows[i].Cells["AMOUNT"].Value.ToString();
                classHelper.dataR[4] = dg.Rows[i].Cells["BANK"].Value.ToString();
                classHelper.dataR[5] = DateTime.Parse(dg.Rows[i].Cells["CHQ_DATE"].Value.ToString()).ToString("dd/MM/yyyy");
                classHelper.dataR[6] = dg.Rows[i].Cells["CHQ_NO"].Value.ToString();
                classHelper.dataR[7] = dtp_FROM.Value.Date.ToString("dddd, dd MMMM yyyy");
                classHelper.dataR[8] = dtp_TO.Value.Date.ToString("dddd, dd MMMM yyyy");
                classHelper.dataR[9] = 0;
                classHelper.dataR[10] = DateTime.Parse(dg.Rows[i].Cells["DATE"].Value.ToString()).ToString("dd/MM/yyyy");

                classHelper.nds.Tables["ChqPaid"].Rows.Add(classHelper.dataR);

            }
            classHelper.rpt = new frmReports();
            if (cmbSalesPerson.SelectedIndex > 0)
                classHelper.rpt.headingTextChange = "SALES PERSON WISE CHQ ACCOUNT REPORT";
            else if (cmbChqNo.SelectedIndex > 0) 
                classHelper.rpt.headingTextChange = "CHEQUE NO. WISE CHQ ACCOUNT REPORT";
            else if (cmbCustomer.SelectedIndex > 0)
                classHelper.rpt.headingTextChange = "CUSTOMER WISE CHQ ACCOUNT REPORT";





            classHelper.rpt.GenerateReport("CHQACC", classHelper.nds);
            classHelper.rpt.ShowDialog();

        }


        private void btnSHOW_Click(object sender, EventArgs e)
        {
            generate();
            show_report();
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

        private void load_chqNo()
        {
            classHelper.query = @"SELECT 0 as [id], '--SELECT CHQ NO--' as [name]
					union all
					SELECT CHQ_ID as [id], CHQ_NO as name from CHQ
					ORDER BY name";
            classHelper.LoadComboData(cmbChqNo, classHelper.query);
        }

        private void frmChqInHandReport_Load(object sender, EventArgs e)
        {
            load_customer();
            load_sales_person();
            load_chqNo();
        }

        private void chckChqDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chckChqNo.Checked)
                cmbChqNo.Enabled = true;
            else
                cmbChqNo.Enabled = false;
        }
    }
}
