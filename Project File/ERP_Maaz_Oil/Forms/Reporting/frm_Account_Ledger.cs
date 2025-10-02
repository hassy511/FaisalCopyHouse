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
    public partial class frm_Account_Ledger : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        //Finance_Classes.cls_Fhelper classHelper = new Finance_Classes.cls_Fhelper();
        //Helper.cls_validations cls_valid = new Helper.cls_validations();
        //Helper.cls_database cls_db = new Helper.cls_database();
        char accountType = '0';
        public frm_Account_Ledger()
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
                    show_report();
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
            classHelper.query = @"SELECT '0' AS [id],'--SELECT ACCOUNT--' as [name]
            UNION ALL
            SELECT COA_ID AS [id],COA_NAME AS [name] FROM COA where stat = '0' ORDER BY [name]";
            classHelper.LoadComboData(cmbACCOUNT, classHelper.query);
        }

        private void opening_bal()
        {

            var fdate = dtp_FROM.Value.AddDays(-1);
            DateTime fdt = fdate;
            string fd = string.Format("{0:yyyy-MM-dd}", fdt);

            classHelper.query = @"SELECT
                CASE WHEN A.DR_CR = 'D' THEN A.OPEN_BAL ELSE -A.OPEN_BAL END,C.AN_ID
            FROM COA A
            INNER JOIN CONTROL_ACCOUNT B ON A.CA_ID = B.CA_ID
            INNER JOIN ACCOUNT_NATURE C ON B.AN_ID = C.AN_ID
            WHERE A.COA_ID = '" + cmbACCOUNT.SelectedValue.ToString() + @"'
            UNION ALL
            SELECT ISNULL(SUM(A.DEBIT - A.CREDIT),0)
               -- CASE WHEN D.AN_ID IN(2,4) THEN ISNULL(SUM(A.CREDIT -A.DEBIT),0)
		         --   ELSE ISNULL(SUM(A.DEBIT -A.CREDIT),0) END
            ,d.AN_ID
            FROM LEDGERS A
            INNER JOIN COA B ON A.COA_ID = B.COA_ID
            INNER JOIN CONTROL_ACCOUNT C ON B.CA_ID = C.CA_ID
            INNER JOIN ACCOUNT_NATURE D ON C.AN_ID = D.AN_ID
            WHERE A.COA_ID = '" + cmbACCOUNT.SelectedValue.ToString() + @"' AND cast(A.[DATE] as date) BETWEEN cast('2017-01-01' as date) AND cast('" + fd + @"' as date)
            GROUP BY D.AN_ID";

            //classHelper.query = @"SELECT
            // CASE WHEN C.AN_ID IN (2,4) THEN 
            //  CASE WHEN A.DR_CR  = 'D' THEN -A.OPEN_BAL ELSE A.OPEN_BAL END
            // ELSE 
            //  CASE WHEN A.DR_CR  = 'D' THEN A.OPEN_BAL ELSE -A.OPEN_BAL END
            // END AS [BALANCE],C.AN_ID
            //FROM COA A
            //INNER JOIN CONTROL_ACCOUNT B ON A.CA_ID = B.CA_ID
            //INNER JOIN ACCOUNT_NATURE C ON B.AN_ID = C.AN_ID
            //WHERE A.COA_ID = '" + cmbACCOUNT.SelectedValue.ToString() + @"'
            //UNION ALL
            //SELECT 
            // CASE WHEN D.AN_ID IN (2,4) THEN ISNULL(SUM(A.CREDIT - A.DEBIT),0)
            //  ELSE ISNULL(SUM(A.DEBIT - A.CREDIT),0) END,d.AN_ID
            //FROM LEDGERS A
            //INNER JOIN COA B ON A.COA_ID = B.COA_ID
            //INNER JOIN CONTROL_ACCOUNT C ON B.CA_ID = C.CA_ID
            //INNER JOIN ACCOUNT_NATURE D ON C.AN_ID = D.AN_ID
            //WHERE A.COA_ID = '" + cmbACCOUNT.SelectedValue.ToString() + @"' AND cast(A.[DATE] as date) BETWEEN cast('2017-01-01' as date) AND cast('" + fd + @"' as date)
            //GROUP BY D.AN_ID";

            Classes.Helper.conn.Open();
            decimal value = 0;
            try
            {
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    while (classHelper.dr.Read())
                    {
                        if (classHelper.dr[0].ToString().Equals(""))
                        {

                        }
                        else
                        {
                            value = value + Math.Round(Convert.ToDecimal(classHelper.dr[0].ToString()));
                            accountType = Convert.ToChar(classHelper.dr[1].ToString());
                        }
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

            var datestrings = DateTime.Parse(dtp_FROM.Value.ToString());
            DateTime dt = datestrings;
            string d = string.Format("{0:dd-MM-yyyy}", dt);

            if (value < 0)
            {
                //-1
                grdSEARCH.Rows.Add("", "Opeing As on " + d + "", "", "", (value * (-1)), "Cr","",accountType);
            }
            else
            {
                grdSEARCH.Rows.Add("", "Opeing As on " + d + "", "", "", value.ToString(), "Dr", "", accountType);
            }

            //if (accountType == '2' || accountType == '4')
            //{
            //    if (value < 0)
            //    {
            //        //-1
            //        grdSEARCH.Rows.Add("", "Opeing As on " + d + "", "", "", (value * (1)), "Dr");
            //    }
            //    else
            //    {
            //        grdSEARCH.Rows.Add("", "Opeing As on " + d + "", "", "", value.ToString(), "Cr");
            //    }
            //}
            //else {
            //    if (value < 0)
            //    {
            //        //-1
            //        grdSEARCH.Rows.Add("", "Opeing As on " + d + "", "", "", (value * (1)), "Cr");
            //    }
            //    else
            //    {
            //        grdSEARCH.Rows.Add("", "Opeing As on " + d + "", "", "", value.ToString(), "Dr");
            //    }
            //}
        }

        public void ledger_Entry()
        {
            var fdate = dtp_FROM.Value;
            DateTime fdt = fdate;
            string fd = string.Format("{0:yyyy-MM-dd}", fdt);

            var tdate = dtp_TO.Value;
            DateTime tdt = tdate;
            string td = string.Format("{0:yyyy-MM-dd}", tdt);

            decimal deb = 0;
            decimal cre = 0;
            classHelper.query = @"SELECT A.[DATE],A.DESCRIPTIONS,A.DEBIT,A.CREDIT,A.FOLIO,D.AN_ID
            FROM LEDGERS A
            INNER JOIN COA B ON A.COA_ID = B.COA_ID
            INNER JOIN CONTROL_ACCOUNT C ON B.CA_ID = C.CA_ID
            INNER JOIN ACCOUNT_NATURE D ON C.AN_ID = D.AN_ID
            WHERE A.COA_ID = '" + cmbACCOUNT.SelectedValue.ToString() + "' AND CONVERT(date,A.[DATE]) BETWEEN '" + fd + "' AND '" + td + @"'
            ORDER BY A.[DATE]";
            Classes.Helper.conn.Open();
            try
            {
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    while (classHelper.dr.Read())
                    {
                        decimal debit = 0;
                        decimal credit = 0;
                        decimal balance = 0;
                        for (int i = 0; i < grdSEARCH.Rows.Count; ++i)
                        {
                            string type = grdSEARCH.Rows[i].Cells[5].Value.ToString();
                            balance = Math.Round(Convert.ToDecimal(grdSEARCH.Rows[i].Cells[4].Value));
                            if (type.Equals("Cr"))
                            {
                                balance = -balance;
                            }
                            debit = Math.Round(Convert.ToDecimal(classHelper.dr[2].ToString()));
                            credit = Math.Round(Convert.ToDecimal(classHelper.dr[3].ToString()));
                        }
                        decimal n = balance + debit - credit;
                        var datestrings = DateTime.Parse(classHelper.dr[0].ToString());
                        DateTime dt = datestrings;
                        string d = string.Format("{0:dd-MM-yyyy}", dt);

                        if (n < 0)
                        {
                            grdSEARCH.Rows.Add(d, classHelper.dr[1].ToString(), classHelper.dr[2].ToString(), classHelper.dr[3].ToString(), (n * (-1)), "Cr", classHelper.dr[4].ToString(),accountType);
                            deb = deb + Math.Round(Convert.ToDecimal(classHelper.dr[2].ToString()));
                            cre = cre + Math.Round(Convert.ToDecimal(classHelper.dr[3].ToString()));
                        }
                        else
                        {
                            grdSEARCH.Rows.Add(d, classHelper.dr[1].ToString(), classHelper.dr[2].ToString(), classHelper.dr[3].ToString(), n, "Dr", classHelper.dr[4].ToString(), accountType);
                            deb = deb + Math.Round(Convert.ToDecimal(classHelper.dr[2].ToString()));
                            cre = cre + Math.Round(Convert.ToDecimal(classHelper.dr[3].ToString()));
                        }
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

        private void show_report()
        {
            DataGridView dg = grdSEARCH;
            classHelper.mds.Tables["ACCOUNTS_LEDGER"].Clear();
            for (int i = 0; i < dg.Rows.Count; i++)
            {
                classHelper.dataR = classHelper.mds.Tables["ACCOUNTS_LEDGER"].NewRow();
                classHelper.dataR[0] = cmbACCOUNT.Text;
                classHelper.dataR[1] = dtp_FROM.Value;
                classHelper.dataR[2] = dtp_TO.Value;
                classHelper.dataR[3] = dg.Rows[i].Cells[0].Value.ToString();
                classHelper.dataR[4] = dg.Rows[i].Cells[1].Value.ToString();
                classHelper.dataR[9] = (dg.Rows[i].Cells["FOLIO"].Value ?? "-").ToString();

                if (dg.Rows[i].Cells[2].Value.ToString().Equals(""))
                {
                    classHelper.dataR[5] = 0;
                }
                else
                {
                    classHelper.dataR[5] = Convert.ToDouble(dg.Rows[i].Cells[2].Value.ToString());
                }

                if (dg.Rows[i].Cells[3].Value.ToString().Equals(""))
                {
                    classHelper.dataR[6] = 0;
                }
                else
                {
                    classHelper.dataR[6] = Convert.ToDouble(dg.Rows[i].Cells[3].Value.ToString());
                }

                if (dg.Rows[i].Cells[4].Value.ToString().Equals(""))
                {
                    classHelper.dataR[7] = 0;
                }
                else
                {
                    classHelper.dataR[7] = Convert.ToDouble(dg.Rows[i].Cells[4].Value.ToString());
                }
                classHelper.dataR[8] = dg.Rows[i].Cells[5].Value.ToString();
                classHelper.dataR["accountNature"] = dg.Rows[i].Cells["accountNature"].Value.ToString();
                classHelper.mds.Tables["ACCOUNTS_LEDGER"].Rows.Add(classHelper.dataR);
            }

            //QTY@Rate/Material Name/Payment days/Vehicle#

            classHelper.query = @"SELECT C.[DATE] AS [DATE],
A.BANK_NAME+' CHQ DATE: '+CONVERT(VARCHAR(50),FORMAT(A.CHQ_DATE,'dd/MM/yyyy'))+' CHQ #'+A.CHQ_NO+' '+C.[DESCRIPTION] AS [DESCRIPTION],A.AMOUNT,'PDC CHQ' AS [TYPE]
            FROM CHQ A 
            INNER JOIN DAY_BOOK_CHQ B ON A.CHQ_ID = B.CHQ_ID and [TYPE] = 'R'
            INNER JOIN DAY_BOOK C ON B.DAY_BOOK_ID = C.DAY_BOOK_ID
            WHERE A.[REC_AC] = '" + cmbACCOUNT.SelectedValue.ToString() + @"' AND A.[STATUS] = 1
            UNION ALL
            SELECT [DATE],PV_NO+'/'+BANK+'/'+BR_CODE+'/'+REF_AC+'/'+INSTRUMENT_NO AS [DESCRIPTION],AMOUNT,'PENDING PAYMENT' AS [TYPE]
            FROM PAYMENT_TRANSFER
            WHERE REC_AC = '" + cmbACCOUNT.SelectedValue.ToString() + @"' AND [STATUS] = 0
            UNION ALL
            SELECT [DATE],PV_NO+'/'+BANK+'/'+BR_CODE+'/'+REF_AC+'/'+INSTRUMENT_NO AS [DESCRIPTION],AMOUNT,'PENDING PAYMENT' AS [TYPE]
            FROM PAYMENT_TRANSFER
            WHERE PAY_AC = '" + cmbACCOUNT.SelectedValue.ToString() + @"' AND [STATUS] = 0";
            Classes.Helper.conn.Open();
            try
            {
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                classHelper.mds.Tables["LedgerPendingEntries"].Clear();
                if (classHelper.dr.HasRows == true)
                {
                    while (classHelper.dr.Read())
                    {
                        classHelper.dataR = classHelper.mds.Tables["LedgerPendingEntries"].NewRow();
                        classHelper.dataR["date"] = Convert.ToDateTime(classHelper.dr["DATE"].ToString());
                        classHelper.dataR["description"] = classHelper.dr["DESCRIPTION"].ToString();
                        classHelper.dataR["amount"] = Convert.ToDouble(classHelper.dr["AMOUNT"].ToString());
                        classHelper.dataR["type"] = classHelper.dr["TYPE"].ToString();
                        classHelper.mds.Tables["LedgerPendingEntries"].Rows.Add(classHelper.dataR);
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


            classHelper.rptLedger = new frmLedgerReports();
            classHelper.rptLedger.GenerateReport("AL", classHelper.mds);
            classHelper.rptLedger.ShowDialog();
        }

        private void generate()
        {
            if (cmbACCOUNT.SelectedIndex == 0)
            {
                MessageBox.Show("Select an Account.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                grdSEARCH.Rows.Clear();
                opening_bal();
                ledger_Entry();
            }
        }

        private void grpSALES_Enter(object sender, EventArgs e)
        {

        }

        private void btnINTER_SAVE_Click(object sender, EventArgs e)
        {
            generate();
            if (grdSEARCH.Rows.Count > 0)
            {
                show_report();
            }

        }

        private void frm_Account_Ledger_Load(object sender, EventArgs e)
        {
            load_account();
        }

        private void cmbACCOUNT_DropDown(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown += new PreviewKeyDownEventHandler(cmbACCOUNT_PreviewKeyDown);
        }

        private void cmbACCOUNT_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown -= cmbACCOUNT_PreviewKeyDown;
            if (cbo.DroppedDown) cbo.Focus();
        }

        private void cmbACCOUNT_TextUpdate(object sender, EventArgs e)
        {
            classHelper.CmbTextUpdate(sender as ComboBox);
        }

        private void frm_Account_Ledger_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
