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
    public partial class frmBankBookVouchersReport : Form
    {
        Classes.Helper clsHelper = new Classes.Helper();



        public frmBankBookVouchersReport()
        {
            InitializeComponent();
        }

        private void btnSHOW_Click(object sender, EventArgs e)
        {
            LoadGrid();
            if(grdEntries.Rows.Count > 0 )
            {
                Generate();
            }
            else
            {
                clsHelper.ShowMessageBox("No records found", "Error");
            }
        }

        private void load_account()
        {
            clsHelper.query = @"SELECT '0' AS [id],'--ALL--' as [name]
            UNION ALL
            SELECT COA_ID AS [id],COA_NAME AS [name] FROM COA ORDER BY [name]";
            clsHelper.LoadComboData(cmbACCOUNT, clsHelper.query);
        }

        private void LoadGrid()
        {
            clsHelper.query = @"
                SELECT A.DATE,B.COA_NAME as [RECEIVE ACC],C.COA_NAME as [PAYMENT ACC],A.REF_AC as [REF ACC],A.AMOUNT,ISNULL(D.CHQ_NO,'-') as CHQ_NO,A.INSTRUMENT,A.NARRATION,
                A.BB_ID,A.PAY_AC,A.REC_AC,'BV-' + CONVERT(varchar(20),A.BB_ID) + '-' +Convert(varchar(20),YEAR(A.DATE)) as [Voucher]
                FROM BANK_BOOK A
                INNER JOIN COA B ON A.REC_AC = B.COA_ID
                INNER JOIN COA C ON A.PAY_AC = C.COA_ID
                LEFT JOIN CHQ D ON A.CHQ_ID = D.CHQ_ID
                WHERE A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' and '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59) + "'";

            if (cmbACCOUNT.SelectedIndex > 0)
                clsHelper.query += @" AND (A.REC_AC = '" + cmbACCOUNT.SelectedValue.ToString() + "' OR A.PAY_AC = '" + cmbACCOUNT.SelectedValue.ToString() + "')";

            clsHelper.query += " ORDER BY A.BB_ID";

            clsHelper.LoadGrid(grdEntries, clsHelper.query);
        }

        public void Generate()
        {
            try
            {
                clsHelper.nds.Tables["BV"].Clear();
                foreach (DataGridViewRow rows in grdEntries.Rows)
                {
                    clsHelper.dataR = clsHelper.nds.Tables["BV"].NewRow();
                    clsHelper.dataR["date"] = Convert.ToDateTime(rows.Cells["DATE"].Value.ToString());
                    clsHelper.dataR["voucherNo"] = rows.Cells["Voucher"].Value.ToString();
                    clsHelper.dataR["accountName"] = rows.Cells["RECEIVE ACC"].Value.ToString();
                    clsHelper.dataR["description"] = string.IsNullOrEmpty(rows.Cells["NARRATION"].Value.ToString()) ? "-" : rows.Cells["NARRATION"].Value.ToString();
                    clsHelper.dataR["debit"] = 0;
                    clsHelper.dataR["credit"] = Convert.ToDouble(rows.Cells["AMOUNT"].Value.ToString());
                    clsHelper.dataR["chqNo"] = rows.Cells["CHQ_NO"].Value.ToString();
                    clsHelper.dataR["instrument"] = rows.Cells["INSTRUMENT"].Value.ToString();
                    clsHelper.nds.Tables["BV"].Rows.Add(clsHelper.dataR);

                    clsHelper.dataR = clsHelper.nds.Tables["BV"].NewRow();
                    clsHelper.dataR["date"] = Convert.ToDateTime(rows.Cells["DATE"].Value.ToString());
                    clsHelper.dataR["voucherNo"] = rows.Cells["Voucher"].Value.ToString();
                    clsHelper.dataR["accountName"] = rows.Cells["PAYMENT ACC"].Value.ToString();
                    clsHelper.dataR["description"] = string.IsNullOrEmpty(rows.Cells["NARRATION"].Value.ToString()) ? "-" : rows.Cells["NARRATION"].Value.ToString();
                    clsHelper.dataR["debit"] = Convert.ToDouble(rows.Cells["AMOUNT"].Value.ToString());
                    clsHelper.dataR["credit"] = 0;
                    clsHelper.dataR["chqNo"] = rows.Cells["CHQ_NO"].Value.ToString();
                    clsHelper.dataR["instrument"] = rows.Cells["INSTRUMENT"].Value.ToString();
                    clsHelper.nds.Tables["BV"].Rows.Add(clsHelper.dataR);


                }
                clsHelper.rpt = new Reporting.frmReports();
                clsHelper.rpt.GenerateReport("BVR", clsHelper.nds);
                clsHelper.rpt.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Classes.Helper.conn.Close();
            }
        }

        private void frmBankBookVouchersReport_Load(object sender, EventArgs e)
        {
            load_account();
        }
    }
}
