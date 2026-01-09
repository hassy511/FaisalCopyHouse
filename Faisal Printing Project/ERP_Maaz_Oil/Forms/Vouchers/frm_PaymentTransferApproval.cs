using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ERP_Maaz_Oil.Forms.Vouchers
{
    public partial class frm_PaymentTransferApproval : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        Classes.cls_Payment_Transfer clsPt = new Classes.cls_Payment_Transfer();
        //DateTimePicker dtp;
        //DateTimePicker dtp = new DateTimePicker();
        //Rectangle _Rectangle;
        public frm_PaymentTransferApproval()
        {
            InitializeComponent();

            //grdEntries.Controls.Add(dtp);

            //dtp.Visible = false;
            //dtp.Format = DateTimePickerFormat.Custom;
            //dtp.CustomFormat = "MM/dd/yyyy";
            //dtp.TextChanged += new EventHandler(dtp_TextChange);
        }

        private void dtp_TextChange(object sender, EventArgs e)
        {
            //grdEntries.CurrentCell.Value = dtp.Text.ToString();
        }

        private void LoadSalesPerson()
        {
            classHelper.query = @"SELECT '0' AS [id],'--SELECT SALES PERSON--' as [name]
            UNION ALL
            SELECT '0' AS [id],'-ALL-' as [name]
            UNION ALL
            SELECT SALES_PER_ID AS [id],NAME AS [name] FROM SALES_PERSONS WHERE SALES_PER_ID <> '1' ORDER BY [name]";
            classHelper.LoadComboData(cmbSalesPerson, classHelper.query);
        }
        private void LoadPerson()
        {
            classHelper.query = @"SELECT '0' as [id],UPPER(PERSON) AS [name] FROM PAYMENT_TRANSFER WHERE PERSON IS NOT NULL AND PERSON <> '' GROUP BY PERSON ORDER BY [NAME]";
            classHelper.LoadComboData(cmbPerson, classHelper.query);
        }
        private void LoadRefAccount()
        {
            classHelper.query = @"SELECT '0' AS [id],'-ALL-' as [name]
            UNION ALL
            SELECT '1' AS [id],REF_AC AS [name] FROM PAYMENT_TRANSFER GROUP BY REF_AC";
            classHelper.LoadComboData(cmbRefAc, classHelper.query);
        }

        private void LoadPaymentAccount()
        {
            classHelper.query = @"SELECT '0' AS [id],'--SELECT ACCOUNT--' as [name]
            UNION ALL
            SELECT '0' AS [id],'-ALL-' as [name]
            UNION ALL
            SELECT COA_ID AS [id],COA_NAME AS [name] FROM COA ORDER BY [name]";
            classHelper.LoadComboData(cmbPayAccount, classHelper.query);
        }
        private void LoadRecAccount()
        {
            classHelper.query = @"SELECT '0' AS [id],'--SELECT ACCOUNT--' as [name]
            UNION ALL
            SELECT '0' AS [id],'-ALL-' as [name]
            UNION ALL
            SELECT COA_ID AS [id],COA_NAME AS [name] FROM COA ORDER BY [name]";
            classHelper.LoadComboData(cmbRecAccount, classHelper.query);
        }
        private void UpdateDiscardPO() {
            try
            {
                // && rdbPending.Checked == true
                if (grdEntries.Rows.Count > 0)
                {
                    classHelper.query = @"BEGIN TRY 
                             BEGIN TRANSACTION ";
                    foreach (DataGridViewRow dgvr in grdEntries.Rows)
                    {
                        char status = '0';
                        if (dgvr.Cells["STATUS"].Value.ToString().Equals("APPROVED"))
                        {
                            status = '1';
                        }

                        if (status == '1')
                        {

                            string cDate = dgvr.Cells["conformationDate"].Value.ToString();
                            if (!cDate.Equals(""))
                            {
                                DateTime conformationDate = Convert.ToDateTime(cDate);
                                cDate = string.Format("{0:MM-dd-yyyy}", conformationDate);
                            }

                            classHelper.query += @"UPDATE PAYMENT_TRANSFER SET STATUS = '" + status + "',CONFORMATION_DATE = '" + cDate + @"',
                            PERSON = '" + dgvr.Cells["person"].Value.ToString() + @"',REMARKS = '" + dgvr.Cells["narration"].Value.ToString() + @"' 
                            WHERE PT_ID = '" + dgvr.Cells["ptID"].Value.ToString() + @"';";

                            classHelper.query += @"IF ((select CHQ_ID from PAYMENT_TRANSFER WHERE PT_ID = '" + dgvr.Cells["ptID"].Value.ToString() + @"') <> '0')
                            BEGIN
	                            UPDATE CHQ SET PAY_AC = '" + dgvr.Cells["payId"].Value.ToString() + @"',PAY_DATE = '" + dtpConformationDate.Value + @"',[STATUS] = 0
                                WHERE CHQ_ID = (select CHQ_ID from PAYMENT_TRANSFER WHERE PT_ID = '" + dgvr.Cells["ptID"].Value.ToString() + @"')
                            END;";

                            classHelper.query += @"DELETE FROM LEDGERS WHERE REF_ID = '" + dgvr.Cells["ptID"].Value.ToString() + @"' AND ENTRY_OF = 'PAYMENT TRANSFER'; 
                            INSERT INTO LEDGERS 
                            (DATE,COA_ID,REF_ID,ENTRY_OF,FOLIO,DEBIT,CREDIT,DESCRIPTIONS,CREATED_BY,CREATION_DATE,COMPANY_ID,REF_AC_ID)
                            VALUES ('" + dtpConformationDate.Value + "','" + dgvr.Cells["recId"].Value.ToString() + @"',
                            '" + dgvr.Cells["ptID"].Value.ToString() + @"','PAYMENT TRANSFER','" + dgvr.Cells["voucherNo"].Value.ToString() + @"',
                            '0','" + dgvr.Cells["amount"].Value.ToString() + @"',
                            '" + dgvr.Cells["bankName"].Value.ToString() + " / " + dgvr.Cells["brCode"].Value.ToString() + " / " +
                            dgvr.Cells["refAccount"].Value.ToString() + " / " + dgvr.Cells["narration"].Value.ToString() + " / " +
                            dgvr.Cells["instrumentNo"].Value.ToString() + @"',
                            '0',GETDATE(),'1','" + dgvr.Cells["refAccount"].Value.ToString() + "'); ";

                            classHelper.query += @"INSERT INTO LEDGERS 
                            (DATE,COA_ID,REF_ID,ENTRY_OF,FOLIO,DEBIT,CREDIT,DESCRIPTIONS,CREATED_BY,CREATION_DATE,COMPANY_ID,REF_AC_ID)
                            VALUES ('" + dtpConformationDate.Value + "','" + dgvr.Cells["payId"].Value.ToString() + @"',
                            '" + dgvr.Cells["ptID"].Value.ToString() + @"','PAYMENT TRANSFER','" + dgvr.Cells["voucherNo"].Value.ToString() + @"',
                            '" + dgvr.Cells["amount"].Value.ToString() + @"','0',
                            '" + dgvr.Cells["bankName"].Value.ToString() + " / " + dgvr.Cells["brCode"].Value.ToString() + " / " +
                            dgvr.Cells["refAccount"].Value.ToString() + " / " + dgvr.Cells["narration"].Value.ToString() + " / " +
                            dgvr.Cells["instrumentNo"].Value.ToString() + @"',
                            '0',GETDATE(),'1','" + dgvr.Cells["refAccount"].Value.ToString() + "'); ";
                        }

                        else if (status == '0')
                        {

                            classHelper.query += @"UPDATE PAYMENT_TRANSFER SET STATUS = '0',CONFORMATION_DATE = NULL,
                            PERSON = NULL
                            WHERE PT_ID = '" + dgvr.Cells["ptID"].Value.ToString() + @"';";

                            classHelper.query += @"DELETE FROM LEDGERS WHERE REF_ID = '" + dgvr.Cells["ptID"].Value.ToString() + @"'  AND ENTRY_OF = 'PAYMENT TRANSFER'; ";
                        }

                    }

                    classHelper.query += @" COMMIT TRANSACTION 
                        END TRY 
                    BEGIN CATCH 
                            IF @@TRANCOUNT > 0 
                            ROLLBACK TRANSACTION 
                    END CATCH";

                    if (classHelper.InsertUpdateDelete(classHelper.query) > 0)
                    {
                        LoadPaymentEntries();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void TotalSum()
        {
            if (grdEntries.Rows.Count > 0)
            {
                txtTotalPending.Text = grdEntries.Rows.Cast<DataGridViewRow>()
                .Where(w => w.Cells["status"].Value.ToString().Equals("PENDING"))
                .Sum(t => Convert.ToDecimal(t.Cells["amount"].Value)).ToString();
                
                txtTotalApproved.Text = grdEntries.Rows.Cast<DataGridViewRow>()
                .Where(w => w.Cells["status"].Value.ToString().Equals("APPROVED"))
                .Sum(t => Convert.ToDecimal(t.Cells["amount"].Value)).ToString();
            }
        }

        private void LoadPaymentEntries() {
            grdEntries.Rows.Clear();
            if (rdbPending.Checked == true)
            {
                if (cmbSalesPerson.SelectedValue.ToString().Equals("0") && cmbSalesPerson.Text.Equals("-ALL-") && 
                    cmbPayAccount.SelectedValue.ToString().Equals("0") && cmbPayAccount.Text.Equals("-ALL-") &&
                    cmbRefAc.SelectedValue.ToString().Equals("0") && cmbRefAc.Text.Equals("-ALL-"))
                {
                    classHelper.query = @"SELECT ISNULL(F.NAME,'OTHER') AS [SALES PERSON],A.PT_ID,A.PV_NO,A.DATE,B.COA_NAME AS [REC ACCOUNT],A.SUB_ACC as [SUB ACCOUNT],A.AMOUNT,A.BANK,A.BR_CODE,A.INSTRUMENT_NO,
                    C.COA_NAME AS [PAY ACCOUNT],
                    A.REF_AC AS [REF AC],
                    CASE WHEN A.STATUS = '0' THEN 'PENDING' ELSE 'APPROVED' END AS [STATUS],
                    A.CONFORMATION_DATE,A.PERSON,A.REMARKS,A.REC_AC,A.PAY_AC
                    FROM PAYMENT_TRANSFER A
                    INNER JOIN COA B ON A.REC_AC = B.COA_ID
                    INNER JOIN COA C ON A.PAY_AC = C.COA_ID
                    LEFT JOIN CUSTOMER_PROFILE E ON E.COA_ID = B.COA_ID
                    LEFT JOIN SALES_PERSONS F ON E.SALE_PER_ID = F.SALES_PER_ID
                    WHERE A.STATUS = '0' AND
                    A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'";
                }
                else if (cmbSalesPerson.SelectedValue.ToString().Equals("0") && cmbSalesPerson.Text.Equals("-ALL-") 
                    && !cmbPayAccount.SelectedValue.ToString().Equals("0") && !cmbPayAccount.Text.Equals("-ALL-") &&
                    cmbRefAc.SelectedValue.ToString().Equals("0") && cmbRefAc.Text.Equals("-ALL-"))
                {
                    classHelper.query = @"SELECT ISNULL(F.NAME,'OTHER') AS [SALES PERSON],A.PT_ID,A.PV_NO,A.DATE,B.COA_NAME AS [REC ACCOUNT],A.SUB_ACC as [SUB ACCOUNT],A.AMOUNT,A.BANK,A.BR_CODE,A.INSTRUMENT_NO,
                    C.COA_NAME AS [PAY ACCOUNT],
                    A.REF_AC AS [REF AC],
                    CASE WHEN A.STATUS = '0' THEN 'PENDING' ELSE 'APPROVED' END AS [STATUS],
                    A.CONFORMATION_DATE,A.PERSON,A.REMARKS,A.REC_AC,A.PAY_AC
                    FROM PAYMENT_TRANSFER A
                    INNER JOIN COA B ON A.REC_AC = B.COA_ID
                    INNER JOIN COA C ON A.PAY_AC = C.COA_ID
                    LEFT JOIN CUSTOMER_PROFILE E ON E.COA_ID = B.COA_ID
                    LEFT JOIN SALES_PERSONS F ON E.SALE_PER_ID = F.SALES_PER_ID
                    WHERE A.STATUS = '0' AND A.PAY_AC = '" + cmbPayAccount.SelectedValue.ToString()+@"' AND
                    A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'";
                }
                else if (!cmbSalesPerson.SelectedValue.ToString().Equals("0") && !cmbSalesPerson.Text.Equals("-ALL-") 
                    && cmbPayAccount.SelectedValue.ToString().Equals("0") && cmbPayAccount.Text.Equals("-ALL-") &&
                    cmbRefAc.SelectedValue.ToString().Equals("0") && cmbRefAc.Text.Equals("-ALL-"))
                {
                    classHelper.query = @"SELECT ISNULL(F.NAME,'OTHER') AS [SALES PERSON],A.PT_ID,A.PV_NO,A.DATE,B.COA_NAME AS [REC ACCOUNT],A.SUB_ACC as [SUB ACCOUNT],A.AMOUNT,A.BANK,A.BR_CODE,A.INSTRUMENT_NO,
                    C.COA_NAME AS [PAY ACCOUNT],
                    A.REF_AC AS [REF AC],
                    CASE WHEN A.STATUS = '0' THEN 'PENDING' ELSE 'APPROVED' END AS [STATUS],
                    A.CONFORMATION_DATE,A.PERSON,A.REMARKS,A.REC_AC,A.PAY_AC
                    FROM PAYMENT_TRANSFER A
                    INNER JOIN COA B ON A.REC_AC = B.COA_ID
                    INNER JOIN COA C ON A.PAY_AC = C.COA_ID
                    LEFT JOIN CUSTOMER_PROFILE E ON E.COA_ID = B.COA_ID
                    LEFT JOIN SALES_PERSONS F ON E.SALE_PER_ID = F.SALES_PER_ID
                    WHERE A.STATUS = '0' AND F.SALES_PER_ID = '" + cmbSalesPerson.SelectedValue.ToString() + @"' AND
                    A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'";
                }
                else if (cmbSalesPerson.SelectedValue.ToString().Equals("0") && cmbSalesPerson.Text.Equals("-ALL-")
                    && cmbPayAccount.SelectedValue.ToString().Equals("0") && cmbPayAccount.Text.Equals("-ALL-") &&
                    !cmbRefAc.SelectedValue.ToString().Equals("0") && !cmbRefAc.Text.Equals("-ALL-"))
                {
                    classHelper.query = @"SELECT ISNULL(F.NAME,'OTHER') AS [SALES PERSON],A.PT_ID,A.PV_NO,A.DATE,B.COA_NAME AS [REC ACCOUNT],A.SUB_ACC as [SUB ACCOUNT],A.AMOUNT,A.BANK,A.BR_CODE,A.INSTRUMENT_NO,
                    C.COA_NAME AS [PAY ACCOUNT],
                    A.REF_AC AS [REF AC],
                    CASE WHEN A.STATUS = '0' THEN 'PENDING' ELSE 'APPROVED' END AS [STATUS],
                    A.CONFORMATION_DATE,A.PERSON,A.REMARKS,A.REC_AC,A.PAY_AC
                    FROM PAYMENT_TRANSFER A
                    INNER JOIN COA B ON A.REC_AC = B.COA_ID
                    INNER JOIN COA C ON A.PAY_AC = C.COA_ID
                    LEFT JOIN CUSTOMER_PROFILE E ON E.COA_ID = B.COA_ID
                    LEFT JOIN SALES_PERSONS F ON E.SALE_PER_ID = F.SALES_PER_ID
                    WHERE A.STATUS = '0' AND A.REF_AC = '" + cmbRefAc.Text + @"' AND
                    A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'";
                }
                else {
                    classHelper.query = @"SELECT F.NAME AS [SALES PERSON],A.PT_ID,A.PV_NO,A.DATE,B.COA_NAME AS [REC ACCOUNT],A.SUB_ACC as [SUB ACCOUNT],A.AMOUNT,A.BANK,A.BR_CODE,A.INSTRUMENT_NO,
                    C.COA_NAME AS [PAY ACCOUNT],
                    A.REF_AC AS [REF AC],
                    CASE WHEN A.STATUS = '0' THEN 'PENDING' ELSE 'APPROVED' END AS [STATUS],
                    A.CONFORMATION_DATE,A.PERSON,A.REMARKS,A.REC_AC,A.PAY_AC
                    FROM PAYMENT_TRANSFER A
                    INNER JOIN COA B ON A.REC_AC = B.COA_ID
                    INNER JOIN COA C ON A.PAY_AC = C.COA_ID
                    INNER JOIN CUSTOMER_PROFILE E ON E.COA_ID = B.COA_ID
                    INNER JOIN SALES_PERSONS F ON E.SALE_PER_ID = F.SALES_PER_ID
                    WHERE F.SALES_PER_ID = '" + cmbSalesPerson.SelectedValue.ToString()+ @"' AND A.PAY_AC = '" + cmbPayAccount.SelectedValue.ToString() + @"' 
                    AND A.STATUS = '0' AND A.REF_AC = '"+cmbRefAc.Text+@"' AND
                    A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'";
                }
                if (cmbSubAccount.SelectedIndex > 0)
                    classHelper.query += " AND A.SUB_ACC = '" + cmbSubAccount.Text + "'";

            }
            else {
                if (cmbSalesPerson.SelectedValue.ToString().Equals("0") && cmbSalesPerson.Text.Equals("-ALL-") 
                    && cmbPayAccount.SelectedValue.ToString().Equals("0") && cmbPayAccount.Text.Equals("-ALL-") &&
                    cmbRefAc.SelectedValue.ToString().Equals("0") && cmbRefAc.Text.Equals("-ALL-"))
                {
                    classHelper.query = @"SELECT ISNULL(F.NAME,'OTHER') AS [SALES PERSON],A.PT_ID,A.PV_NO,A.DATE,B.COA_NAME AS [REC ACCOUNT],A.SUB_ACC as [SUB ACCOUNT],A.AMOUNT,A.BANK,A.BR_CODE,A.INSTRUMENT_NO,
                    C.COA_NAME AS [PAY ACCOUNT],
                    A.REF_AC AS [REF AC],
                    CASE WHEN A.STATUS = '0' THEN 'PENDING' ELSE 'APPROVED' END AS [STATUS],
                    A.CONFORMATION_DATE,A.PERSON,A.REMARKS,A.REC_AC,A.PAY_AC
                    FROM PAYMENT_TRANSFER A
                    INNER JOIN COA B ON A.REC_AC = B.COA_ID
                    INNER JOIN COA C ON A.PAY_AC = C.COA_ID
                    LEFT JOIN CUSTOMER_PROFILE E ON E.COA_ID = B.COA_ID
                    LEFT JOIN SALES_PERSONS F ON E.SALE_PER_ID = F.SALES_PER_ID
                    WHERE 
                    A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'";
                }
                else if (cmbSalesPerson.SelectedValue.ToString().Equals("0") && cmbSalesPerson.Text.Equals("-ALL-") 
                    && !cmbPayAccount.SelectedValue.ToString().Equals("0") && !cmbPayAccount.Text.Equals("-ALL-") &&
                    cmbRefAc.SelectedValue.ToString().Equals("0") && cmbRefAc.Text.Equals("-ALL-"))
                {
                    classHelper.query = @"SELECT ISNULL(F.NAME,'OTHER') AS [SALES PERSON],A.PT_ID,A.PV_NO,A.DATE,B.COA_NAME AS [REC ACCOUNT],A.SUB_ACC as [SUB ACCOUNT],A.AMOUNT,A.BANK,A.BR_CODE,A.INSTRUMENT_NO,
                    C.COA_NAME AS [PAY ACCOUNT],
                    A.REF_AC AS [REF AC],
                    CASE WHEN A.STATUS = '0' THEN 'PENDING' ELSE 'APPROVED' END AS [STATUS],
                    A.CONFORMATION_DATE,A.PERSON,A.REMARKS,A.REC_AC,A.PAY_AC
                    FROM PAYMENT_TRANSFER A
                    INNER JOIN COA B ON A.REC_AC = B.COA_ID
                    INNER JOIN COA C ON A.PAY_AC = C.COA_ID
                    LEFT JOIN CUSTOMER_PROFILE E ON E.COA_ID = B.COA_ID
                    LEFT JOIN SALES_PERSONS F ON E.SALE_PER_ID = F.SALES_PER_ID
                    WHERE A.PAY_AC = '" + cmbPayAccount.SelectedValue.ToString() + @"' AND
                    A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'";
                }
                else if (!cmbSalesPerson.SelectedValue.ToString().Equals("0") && !cmbSalesPerson.Text.Equals("-ALL-") && 
                    cmbPayAccount.SelectedValue.ToString().Equals("0") && cmbPayAccount.Text.Equals("-ALL-") &&
                    cmbRefAc.SelectedValue.ToString().Equals("0") && cmbRefAc.Text.Equals("-ALL-"))
                {
                    classHelper.query = @"SELECT ISNULL(F.NAME,'OTHER') AS [SALES PERSON],A.PT_ID,A.PV_NO,A.DATE,B.COA_NAME AS [REC ACCOUNT],A.SUB_ACC as [SUB ACCOUNT],A.AMOUNT,A.BANK,A.BR_CODE,A.INSTRUMENT_NO,
                    C.COA_NAME AS [PAY ACCOUNT],
                    A.REF_AC AS [REF AC],
                    CASE WHEN A.STATUS = '0' THEN 'PENDING' ELSE 'APPROVED' END AS [STATUS],
                    A.CONFORMATION_DATE,A.PERSON,A.REMARKS,A.REC_AC,A.PAY_AC
                    FROM PAYMENT_TRANSFER A
                    INNER JOIN COA B ON A.REC_AC = B.COA_ID
                    INNER JOIN COA C ON A.PAY_AC = C.COA_ID
                    LEFT JOIN CUSTOMER_PROFILE E ON E.COA_ID = B.COA_ID
                    LEFT JOIN SALES_PERSONS F ON E.SALE_PER_ID = F.SALES_PER_ID
                    WHERE F.SALES_PER_ID = '" + cmbSalesPerson.SelectedValue.ToString() + @"' AND
                    A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'";
                }
                else if (cmbSalesPerson.SelectedValue.ToString().Equals("0") && cmbSalesPerson.Text.Equals("-ALL-") &&
                    cmbPayAccount.SelectedValue.ToString().Equals("0") && cmbPayAccount.Text.Equals("-ALL-") &&
                    !cmbRefAc.SelectedValue.ToString().Equals("0") && !cmbRefAc.Text.Equals("-ALL-"))
                {
                    classHelper.query = @"SELECT ISNULL(F.NAME,'OTHER') AS [SALES PERSON],A.PT_ID,A.PV_NO,A.DATE,B.COA_NAME AS [REC ACCOUNT],A.SUB_ACC as [SUB ACCOUNT],A.AMOUNT,A.BANK,A.BR_CODE,A.INSTRUMENT_NO,
                    C.COA_NAME AS [PAY ACCOUNT],
                    A.REF_AC AS [REF AC],
                    CASE WHEN A.STATUS = '0' THEN 'PENDING' ELSE 'APPROVED' END AS [STATUS],
                    A.CONFORMATION_DATE,A.PERSON,A.REMARKS,A.REC_AC,A.PAY_AC
                    FROM PAYMENT_TRANSFER A
                    INNER JOIN COA B ON A.REC_AC = B.COA_ID
                    INNER JOIN COA C ON A.PAY_AC = C.COA_ID
                    LEFT JOIN CUSTOMER_PROFILE E ON E.COA_ID = B.COA_ID
                    LEFT JOIN SALES_PERSONS F ON E.SALE_PER_ID = F.SALES_PER_ID
                    WHERE A.REF_AC = '" + cmbRefAc.Text + @"' AND
                    A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'";
                }
                else
                {
                    classHelper.query = @"SELECT F.NAME AS [SALES PERSON],A.PT_ID,A.PV_NO,A.DATE,B.COA_NAME AS [REC ACCOUNT],A.SUB_ACC as [SUB ACCOUNT],A.AMOUNT,A.BANK,A.BR_CODE,A.INSTRUMENT_NO,
                    C.COA_NAME AS [PAY ACCOUNT],
                    A.REF_AC AS [REF AC],
                    CASE WHEN A.STATUS = '0' THEN 'PENDING' ELSE 'APPROVED' END AS [STATUS],
                    A.CONFORMATION_DATE,A.PERSON,A.REMARKS,A.REC_AC,A.PAY_AC
                    FROM PAYMENT_TRANSFER A
                    INNER JOIN COA B ON A.REC_AC = B.COA_ID
                    INNER JOIN COA C ON A.PAY_AC = C.COA_ID
                    INNER JOIN CUSTOMER_PROFILE E ON E.COA_ID = B.COA_ID
                    INNER JOIN SALES_PERSONS F ON E.SALE_PER_ID = F.SALES_PER_ID
                    WHERE F.SALES_PER_ID = '" + cmbSalesPerson.SelectedValue.ToString() + @"' 
                    AND A.PAY_AC = '" + cmbPayAccount.SelectedValue.ToString() + @"' AND A.REF_AC = '" + cmbRefAc.Text + @"' AND
                    A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'";
                }

                if (cmbSubAccount.SelectedIndex > 0)
                    classHelper.query += " AND A.SUB_ACC = '"+cmbSubAccount.Text+"'"; 

            }

            if (cmbBank.SelectedIndex > 0)
                classHelper.query += " AND A.BANK = '"+cmbBank.Text+"'";

            if (cmbRecAccount.SelectedIndex > 1)
                classHelper.query += " AND B.COA_ID = '"+cmbRecAccount.SelectedValue.ToString()+"'";


            try
            {
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                grdEntries.Rows.Clear();
                if (classHelper.dr.HasRows == true)
                {
                    while (classHelper.dr.Read())
                    {
                        object data = classHelper.dr["CONFORMATION_DATE"].ToString();
                        string cDate;
                        if (data.ToString().Equals(""))
                        {
                            cDate = "";
                        }
                        else
                        {
                            DateTime conformationDate = Convert.ToDateTime(classHelper.dr["CONFORMATION_DATE"].ToString());
                            if (conformationDate.ToString().Equals("1/1/1900 12:00:00 AM"))
                            {
                                cDate = "";
                            }
                            else
                            {
                                cDate = string.Format("{0:dd-MM-yyyy}", conformationDate);
                            }
                        }

                        grdEntries.Rows.Add(false,classHelper.dr["PT_ID"].ToString(), classHelper.dr["DATE"].ToString(), classHelper.dr["PV_NO"].ToString(), 
                        classHelper.dr["REC ACCOUNT"].ToString(),classHelper.dr["SUB ACCOUNT"].ToString(),classHelper.dr["AMOUNT"].ToString(), classHelper.dr["BANK"].ToString(), 
                        classHelper.dr["BR_CODE"].ToString(),classHelper.dr["INSTRUMENT_NO"].ToString(), classHelper.dr["PAY ACCOUNT"].ToString(), 
                        classHelper.dr["REF AC"].ToString(), classHelper.dr["STATUS"].ToString(), classHelper.dr["CONFORMATION_DATE"].ToString(),
                        classHelper.dr["PERSON"].ToString(), classHelper.dr["REMARKS"].ToString(), classHelper.dr["SALES PERSON"].ToString(),
                        classHelper.dr["REC_AC"].ToString(), classHelper.dr["PAY_AC"].ToString());
                    }
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
        }

        private void ShowReport()
        {
            if (rdbEntryDate.Checked == true)
            {
                if (rdbPending.Checked == true)
                {
                    if (cmbSalesPerson.SelectedValue.ToString().Equals("0") && cmbSalesPerson.Text.Equals("-ALL-") &&
                        cmbPayAccount.SelectedValue.ToString().Equals("0") && cmbPayAccount.Text.Equals("-ALL-") &&
                        cmbRefAc.SelectedValue.ToString().Equals("0") && cmbRefAc.Text.Equals("-ALL-"))
                    {
                        classHelper.query = @"SELECT ISNULL(F.NAME,'OTHER') AS [SALES PERSON],A.PT_ID,A.PV_NO,A.DATE,B.COA_NAME AS [REC ACCOUNT],A.AMOUNT,A.BANK,A.BR_CODE,A.INSTRUMENT_NO,
                    C.COA_NAME AS [PAY ACCOUNT],A.SUB_ACC,
                    A.REF_AC AS [REF AC],
                    CASE WHEN A.STATUS = '0' THEN 'PENDING' ELSE 'APPROVED' END AS [STATUS],
                    A.CONFORMATION_DATE,A.PERSON,A.REMARKS
                    FROM PAYMENT_TRANSFER A
                    INNER JOIN COA B ON A.REC_AC = B.COA_ID
                    INNER JOIN COA C ON A.PAY_AC = C.COA_ID
                    LEFT JOIN CUSTOMER_PROFILE E ON E.COA_ID = B.COA_ID
                    LEFT JOIN SALES_PERSONS F ON E.SALE_PER_ID = F.SALES_PER_ID
                    WHERE A.STATUS = '0' AND
                    A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
                    ORDER BY [DATE]";
                    }
                    else if (cmbSalesPerson.SelectedValue.ToString().Equals("0") && cmbSalesPerson.Text.Equals("-ALL-") &&
                        !cmbPayAccount.SelectedValue.ToString().Equals("0") && !cmbPayAccount.Text.Equals("-ALL-") &&
                        cmbRefAc.SelectedValue.ToString().Equals("0") && cmbRefAc.Text.Equals("-ALL-"))
                    {
                        classHelper.query = @"SELECT ISNULL(F.NAME,'OTHER') AS [SALES PERSON],A.PT_ID,A.PV_NO,A.DATE,B.COA_NAME AS [REC ACCOUNT],A.AMOUNT,A.BANK,A.BR_CODE,A.INSTRUMENT_NO,
                    C.COA_NAME AS [PAY ACCOUNT],A.SUB_ACC,
                    A.REF_AC AS [REF AC],
                    CASE WHEN A.STATUS = '0' THEN 'PENDING' ELSE 'APPROVED' END AS [STATUS],
                    A.CONFORMATION_DATE,A.PERSON,A.REMARKS
                    FROM PAYMENT_TRANSFER A
                    INNER JOIN COA B ON A.REC_AC = B.COA_ID
                    INNER JOIN COA C ON A.PAY_AC = C.COA_ID
                    LEFT JOIN CUSTOMER_PROFILE E ON E.COA_ID = B.COA_ID
                    LEFT JOIN SALES_PERSONS F ON E.SALE_PER_ID = F.SALES_PER_ID
                    WHERE A.STATUS = '0' AND A.PAY_AC = '" + cmbPayAccount.SelectedValue.ToString() + @"' AND
                    A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
                    ORDER BY [DATE]";
                    }
                    else if (!cmbSalesPerson.SelectedValue.ToString().Equals("0") && !cmbSalesPerson.Text.Equals("-ALL-") &&
                        cmbPayAccount.SelectedValue.ToString().Equals("0") && cmbPayAccount.Text.Equals("-ALL-") &&
                        cmbRefAc.SelectedValue.ToString().Equals("0") && cmbRefAc.Text.Equals("-ALL-"))
                    {
                        classHelper.query = @"SELECT ISNULL(F.NAME,'OTHER') AS [SALES PERSON],A.PT_ID,A.PV_NO,A.DATE,B.COA_NAME AS [REC ACCOUNT],A.AMOUNT,A.BANK,A.BR_CODE,A.INSTRUMENT_NO,
                    C.COA_NAME AS [PAY ACCOUNT],A.SUB_ACC,
                    A.REF_AC AS [REF AC],
                    CASE WHEN A.STATUS = '0' THEN 'PENDING' ELSE 'APPROVED' END AS [STATUS],
                    A.CONFORMATION_DATE,A.PERSON,A.REMARKS
                    FROM PAYMENT_TRANSFER A
                    INNER JOIN COA B ON A.REC_AC = B.COA_ID
                    INNER JOIN COA C ON A.PAY_AC = C.COA_ID
                    LEFT JOIN CUSTOMER_PROFILE E ON E.COA_ID = B.COA_ID
                    LEFT JOIN SALES_PERSONS F ON E.SALE_PER_ID = F.SALES_PER_ID
                    WHERE A.STATUS = '0' AND F.SALES_PER_ID = '" + cmbSalesPerson.SelectedValue.ToString() + @"' AND
                    A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
                    ORDER BY [DATE]";
                    }
                    else if (cmbSalesPerson.SelectedValue.ToString().Equals("0") && cmbSalesPerson.Text.Equals("-ALL-") &&
                        cmbPayAccount.SelectedValue.ToString().Equals("0") && cmbPayAccount.Text.Equals("-ALL-") &&
                        !cmbRefAc.SelectedValue.ToString().Equals("0") && !cmbRefAc.Text.Equals("-ALL-"))
                    {
                        classHelper.query = @"SELECT ISNULL(F.NAME,'OTHER') AS [SALES PERSON],A.PT_ID,A.PV_NO,A.DATE,B.COA_NAME AS [REC ACCOUNT],A.AMOUNT,A.BANK,A.BR_CODE,A.INSTRUMENT_NO,
                    C.COA_NAME AS [PAY ACCOUNT],A.SUB_ACC,
                    A.REF_AC AS [REF AC],
                    CASE WHEN A.STATUS = '0' THEN 'PENDING' ELSE 'APPROVED' END AS [STATUS],
                    A.CONFORMATION_DATE,A.PERSON,A.REMARKS
                    FROM PAYMENT_TRANSFER A
                    INNER JOIN COA B ON A.REC_AC = B.COA_ID
                    INNER JOIN COA C ON A.PAY_AC = C.COA_ID
                    LEFT JOIN CUSTOMER_PROFILE E ON E.COA_ID = B.COA_ID
                    LEFT JOIN SALES_PERSONS F ON E.SALE_PER_ID = F.SALES_PER_ID
                    WHERE A.STATUS = '0' AND A.REF_AC = '" + cmbRefAc.Text + @"' AND
                    A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
                    ORDER BY [DATE]";
                    }
                    else
                    {
                        classHelper.query = @"SELECT F.NAME AS [SALES PERSON],A.PT_ID,A.PV_NO,A.DATE,B.COA_NAME AS [REC ACCOUNT],A.AMOUNT,A.BANK,A.BR_CODE,A.INSTRUMENT_NO,
                    C.COA_NAME AS [PAY ACCOUNT],A.SUB_ACC,
                    A.REF_AC AS [REF AC],
                    CASE WHEN A.STATUS = '0' THEN 'PENDING' ELSE 'APPROVED' END AS [STATUS],
                    A.CONFORMATION_DATE,A.PERSON,A.REMARKS
                    FROM PAYMENT_TRANSFER A
                    INNER JOIN COA B ON A.REC_AC = B.COA_ID
                    INNER JOIN COA C ON A.PAY_AC = C.COA_ID
                    INNER JOIN CUSTOMER_PROFILE E ON E.COA_ID = B.COA_ID
                    INNER JOIN SALES_PERSONS F ON E.SALE_PER_ID = F.SALES_PER_ID
                    WHERE F.SALES_PER_ID = '" + cmbSalesPerson.SelectedValue.ToString() + @"' AND A.PAY_AC = '" + cmbPayAccount.SelectedValue.ToString() + @"' 
                    AND A.STATUS = '0' AND A.REF_AC = '" + cmbRefAc.Text + @"' AND
                    A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
                    ORDER BY [DATE]";
                    }
                }
                else
                {
                    if (cmbSalesPerson.SelectedValue.ToString().Equals("0") && cmbSalesPerson.Text.Equals("-ALL-") &&
                        cmbPayAccount.SelectedValue.ToString().Equals("0") && cmbPayAccount.Text.Equals("-ALL-") &&
                        cmbRefAc.SelectedValue.ToString().Equals("0") && cmbRefAc.Text.Equals("-ALL-"))
                    {
                        classHelper.query = @"SELECT ISNULL(F.NAME,'OTHER') AS [SALES PERSON],A.PT_ID,A.PV_NO,A.DATE,B.COA_NAME AS [REC ACCOUNT],A.AMOUNT,A.BANK,A.BR_CODE,A.INSTRUMENT_NO,
                    C.COA_NAME AS [PAY ACCOUNT],A.SUB_ACC,
                    A.REF_AC AS [REF AC],
                    CASE WHEN A.STATUS = '0' THEN 'PENDING' ELSE 'APPROVED' END AS [STATUS],
                    A.CONFORMATION_DATE,A.PERSON,A.REMARKS
                    FROM PAYMENT_TRANSFER A
                    INNER JOIN COA B ON A.REC_AC = B.COA_ID
                    INNER JOIN COA C ON A.PAY_AC = C.COA_ID
                    LEFT JOIN CUSTOMER_PROFILE E ON E.COA_ID = B.COA_ID
                    LEFT JOIN SALES_PERSONS F ON E.SALE_PER_ID = F.SALES_PER_ID
                    WHERE 
                    A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
                    ORDER BY [DATE]";
                    }
                    else if (cmbSalesPerson.SelectedValue.ToString().Equals("0") && cmbSalesPerson.Text.Equals("-ALL-") &&
                        !cmbPayAccount.SelectedValue.ToString().Equals("0") && !cmbPayAccount.Text.Equals("-ALL-") &&
                        cmbRefAc.SelectedValue.ToString().Equals("0") && cmbRefAc.Text.Equals("-ALL-"))
                    {
                        classHelper.query = @"SELECT ISNULL(F.NAME,'OTHER') AS [SALES PERSON],A.PT_ID,A.PV_NO,A.DATE,B.COA_NAME AS [REC ACCOUNT],A.AMOUNT,A.BANK,A.BR_CODE,A.INSTRUMENT_NO,
                    C.COA_NAME AS [PAY ACCOUNT],A.SUB_ACC,
                    A.REF_AC AS [REF AC],
                    CASE WHEN A.STATUS = '0' THEN 'PENDING' ELSE 'APPROVED' END AS [STATUS],
                    A.CONFORMATION_DATE,A.PERSON,A.REMARKS
                    FROM PAYMENT_TRANSFER A
                    INNER JOIN COA B ON A.REC_AC = B.COA_ID
                    INNER JOIN COA C ON A.PAY_AC = C.COA_ID
                    LEFT JOIN CUSTOMER_PROFILE E ON E.COA_ID = B.COA_ID
                    LEFT JOIN SALES_PERSONS F ON E.SALE_PER_ID = F.SALES_PER_ID
                    WHERE A.PAY_AC = '" + cmbPayAccount.SelectedValue.ToString() + @"' AND
                    A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
                    ORDER BY [DATE]";
                    }
                    else if (!cmbSalesPerson.SelectedValue.ToString().Equals("0") && !cmbSalesPerson.Text.Equals("-ALL-") &&
                        cmbPayAccount.SelectedValue.ToString().Equals("0") && cmbPayAccount.Text.Equals("-ALL-") &&
                        cmbRefAc.SelectedValue.ToString().Equals("0") && cmbRefAc.Text.Equals("-ALL-"))
                    {
                        classHelper.query = @"SELECT ISNULL(F.NAME,'OTHER') AS [SALES PERSON],A.PT_ID,A.PV_NO,A.DATE,B.COA_NAME AS [REC ACCOUNT],A.AMOUNT,A.BANK,A.BR_CODE,A.INSTRUMENT_NO,
                    C.COA_NAME AS [PAY ACCOUNT],A.SUB_ACC,
                    A.REF_AC AS [REF AC],
                    CASE WHEN A.STATUS = '0' THEN 'PENDING' ELSE 'APPROVED' END AS [STATUS],
                    A.CONFORMATION_DATE,A.PERSON,A.REMARKS
                    FROM PAYMENT_TRANSFER A
                    INNER JOIN COA B ON A.REC_AC = B.COA_ID
                    INNER JOIN COA C ON A.PAY_AC = C.COA_ID
                    LEFT JOIN CUSTOMER_PROFILE E ON E.COA_ID = B.COA_ID
                    LEFT JOIN SALES_PERSONS F ON E.SALE_PER_ID = F.SALES_PER_ID
                    WHERE F.SALES_PER_ID = '" + cmbSalesPerson.SelectedValue.ToString() + @"' AND
                    A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
                    ORDER BY [DATE]";
                    }
                    else if (cmbSalesPerson.SelectedValue.ToString().Equals("0") && cmbSalesPerson.Text.Equals("-ALL-") &&
                        cmbPayAccount.SelectedValue.ToString().Equals("0") && cmbPayAccount.Text.Equals("-ALL-") &&
                        !cmbRefAc.SelectedValue.ToString().Equals("0") && !cmbRefAc.Text.Equals("-ALL-"))
                    {
                        classHelper.query = @"SELECT ISNULL(F.NAME,'OTHER') AS [SALES PERSON],A.PT_ID,A.PV_NO,A.DATE,B.COA_NAME AS [REC ACCOUNT],A.AMOUNT,A.BANK,A.BR_CODE,A.INSTRUMENT_NO,
                    C.COA_NAME AS [PAY ACCOUNT],A.SUB_ACC,
                    A.REF_AC AS [REF AC],
                    CASE WHEN A.STATUS = '0' THEN 'PENDING' ELSE 'APPROVED' END AS [STATUS],
                    A.CONFORMATION_DATE,A.PERSON,A.REMARKS
                    FROM PAYMENT_TRANSFER A
                    INNER JOIN COA B ON A.REC_AC = B.COA_ID
                    INNER JOIN COA C ON A.PAY_AC = C.COA_ID
                    LEFT JOIN CUSTOMER_PROFILE E ON E.COA_ID = B.COA_ID
                    LEFT JOIN SALES_PERSONS F ON E.SALE_PER_ID = F.SALES_PER_ID
                    WHERE A.REF_AC = '" + cmbRefAc.Text + @"' AND
                    A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
                    ORDER BY [DATE]";
                    }
                    else
                    {
                        classHelper.query = @"SELECT F.NAME AS [SALES PERSON],A.PT_ID,A.PV_NO,A.DATE,B.COA_NAME AS [REC ACCOUNT],A.AMOUNT,A.BANK,A.BR_CODE,A.INSTRUMENT_NO,
                    C.COA_NAME AS [PAY ACCOUNT],A.SUB_ACC,
                    A.REF_AC AS [REF AC],
                    CASE WHEN A.STATUS = '0' THEN 'PENDING' ELSE 'APPROVED' END AS [STATUS],
                    A.CONFORMATION_DATE,A.PERSON,A.REMARKS
                    FROM PAYMENT_TRANSFER A
                    INNER JOIN COA B ON A.REC_AC = B.COA_ID
                    INNER JOIN COA C ON A.PAY_AC = C.COA_ID
                    INNER JOIN CUSTOMER_PROFILE E ON E.COA_ID = B.COA_ID
                    INNER JOIN SALES_PERSONS F ON E.SALE_PER_ID = F.SALES_PER_ID
                    WHERE F.SALES_PER_ID = '" + cmbSalesPerson.SelectedValue.ToString() + @"' AND 
                    A.PAY_AC = '" + cmbPayAccount.SelectedValue.ToString() + @"' AND A.REF_AC = '" + cmbRefAc.Text + @"' AND
                    A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
                    ORDER BY [DATE]";
                    }
                }
            }
            else if (rdbConformation.Checked == true) {
                if (rdbPending.Checked == true)
                {
                    if (cmbSalesPerson.SelectedValue.ToString().Equals("0") && cmbSalesPerson.Text.Equals("-ALL-") &&
                        cmbPayAccount.SelectedValue.ToString().Equals("0") && cmbPayAccount.Text.Equals("-ALL-") &&
                        cmbRefAc.SelectedValue.ToString().Equals("0") && cmbRefAc.Text.Equals("-ALL-"))
                    {
                        classHelper.query = @"SELECT ISNULL(F.NAME,'OTHER') AS [SALES PERSON],A.PT_ID,A.PV_NO,A.DATE,B.COA_NAME AS [REC ACCOUNT],A.AMOUNT,A.BANK,A.BR_CODE,A.INSTRUMENT_NO,
                    C.COA_NAME AS [PAY ACCOUNT],A.SUB_ACC,
                    A.REF_AC AS [REF AC],
                    CASE WHEN A.STATUS = '0' THEN 'PENDING' ELSE 'APPROVED' END AS [STATUS],
                    A.CONFORMATION_DATE,A.PERSON,A.REMARKS
                    FROM PAYMENT_TRANSFER A
                    INNER JOIN COA B ON A.REC_AC = B.COA_ID
                    INNER JOIN COA C ON A.PAY_AC = C.COA_ID
                    LEFT JOIN CUSTOMER_PROFILE E ON E.COA_ID = B.COA_ID
                    LEFT JOIN SALES_PERSONS F ON E.SALE_PER_ID = F.SALES_PER_ID
                    WHERE A.STATUS = '0' AND
                    A.CONFORMATION_DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
                    ORDER BY [CONFORMATION_DATE]";
                    }
                    else if (cmbSalesPerson.SelectedValue.ToString().Equals("0") && cmbSalesPerson.Text.Equals("-ALL-") &&
                        !cmbPayAccount.SelectedValue.ToString().Equals("0") && !cmbPayAccount.Text.Equals("-ALL-") &&
                        cmbRefAc.SelectedValue.ToString().Equals("0") && cmbRefAc.Text.Equals("-ALL-"))
                    {
                        classHelper.query = @"SELECT ISNULL(F.NAME,'OTHER') AS [SALES PERSON],A.PT_ID,A.PV_NO,A.DATE,B.COA_NAME AS [REC ACCOUNT],A.AMOUNT,A.BANK,A.BR_CODE,A.INSTRUMENT_NO,
                    C.COA_NAME AS [PAY ACCOUNT],A.SUB_ACC,
                    A.REF_AC AS [REF AC],
                    CASE WHEN A.STATUS = '0' THEN 'PENDING' ELSE 'APPROVED' END AS [STATUS],
                    A.CONFORMATION_DATE,A.PERSON,A.REMARKS
                    FROM PAYMENT_TRANSFER A
                    INNER JOIN COA B ON A.REC_AC = B.COA_ID
                    INNER JOIN COA C ON A.PAY_AC = C.COA_ID
                    LEFT JOIN CUSTOMER_PROFILE E ON E.COA_ID = B.COA_ID
                    LEFT JOIN SALES_PERSONS F ON E.SALE_PER_ID = F.SALES_PER_ID
                    WHERE A.STATUS = '0' AND A.PAY_AC = '" + cmbPayAccount.SelectedValue.ToString() + @"' AND
                    A.CONFORMATION_DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
                    ORDER BY [CONFORMATION_DATE]";
                    }
                    else if (!cmbSalesPerson.SelectedValue.ToString().Equals("0") && !cmbSalesPerson.Text.Equals("-ALL-") &&
                        cmbPayAccount.SelectedValue.ToString().Equals("0") && cmbPayAccount.Text.Equals("-ALL-") &&
                        cmbRefAc.SelectedValue.ToString().Equals("0") && cmbRefAc.Text.Equals("-ALL-"))
                    {
                        classHelper.query = @"SELECT ISNULL(F.NAME,'OTHER') AS [SALES PERSON],A.PT_ID,A.PV_NO,A.DATE,B.COA_NAME AS [REC ACCOUNT],A.AMOUNT,A.BANK,A.BR_CODE,A.INSTRUMENT_NO,
                    C.COA_NAME AS [PAY ACCOUNT],A.SUB_ACC,
                    A.REF_AC AS [REF AC],
                    CASE WHEN A.STATUS = '0' THEN 'PENDING' ELSE 'APPROVED' END AS [STATUS],
                    A.CONFORMATION_DATE,A.PERSON,A.REMARKS
                    FROM PAYMENT_TRANSFER A
                    INNER JOIN COA B ON A.REC_AC = B.COA_ID
                    INNER JOIN COA C ON A.PAY_AC = C.COA_ID
                    LEFT JOIN CUSTOMER_PROFILE E ON E.COA_ID = B.COA_ID
                    LEFT JOIN SALES_PERSONS F ON E.SALE_PER_ID = F.SALES_PER_ID
                    WHERE A.STATUS = '0' AND F.SALES_PER_ID = '" + cmbSalesPerson.SelectedValue.ToString() + @"' AND
                    A.CONFORMATION_DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
                    ORDER BY [CONFORMATION_DATE]";
                    }
                    else if (cmbSalesPerson.SelectedValue.ToString().Equals("0") && cmbSalesPerson.Text.Equals("-ALL-") &&
                        cmbPayAccount.SelectedValue.ToString().Equals("0") && cmbPayAccount.Text.Equals("-ALL-") &&
                        !cmbRefAc.SelectedValue.ToString().Equals("0") && !cmbRefAc.Text.Equals("-ALL-"))
                    {
                        classHelper.query = @"SELECT ISNULL(F.NAME,'OTHER') AS [SALES PERSON],A.PT_ID,A.PV_NO,A.DATE,B.COA_NAME AS [REC ACCOUNT],A.AMOUNT,A.BANK,A.BR_CODE,A.INSTRUMENT_NO,
                    C.COA_NAME AS [PAY ACCOUNT],A.SUB_ACC,
                    A.REF_AC AS [REF AC],
                    CASE WHEN A.STATUS = '0' THEN 'PENDING' ELSE 'APPROVED' END AS [STATUS],
                    A.CONFORMATION_DATE,A.PERSON,A.REMARKS
                    FROM PAYMENT_TRANSFER A
                    INNER JOIN COA B ON A.REC_AC = B.COA_ID
                    INNER JOIN COA C ON A.PAY_AC = C.COA_ID
                    LEFT JOIN CUSTOMER_PROFILE E ON E.COA_ID = B.COA_ID
                    LEFT JOIN SALES_PERSONS F ON E.SALE_PER_ID = F.SALES_PER_ID
                    WHERE A.STATUS = '0' AND A.REF_AC = '" + cmbRefAc.Text + @"' AND
                    A.CONFORMATION_DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
                    ORDER BY [CONFORMATION_DATE]";
                    }
                    else
                    {
                        classHelper.query = @"SELECT F.NAME AS [SALES PERSON],A.PT_ID,A.PV_NO,A.DATE,B.COA_NAME AS [REC ACCOUNT],A.AMOUNT,A.BANK,A.BR_CODE,A.INSTRUMENT_NO,
                    C.COA_NAME AS [PAY ACCOUNT],A.SUB_ACC,
                    A.REF_AC AS [REF AC],
                    CASE WHEN A.STATUS = '0' THEN 'PENDING' ELSE 'APPROVED' END AS [STATUS],
                    A.CONFORMATION_DATE,A.PERSON,A.REMARKS
                    FROM PAYMENT_TRANSFER A
                    INNER JOIN COA B ON A.REC_AC = B.COA_ID
                    INNER JOIN COA C ON A.PAY_AC = C.COA_ID
                    INNER JOIN CUSTOMER_PROFILE E ON E.COA_ID = B.COA_ID
                    INNER JOIN SALES_PERSONS F ON E.SALE_PER_ID = F.SALES_PER_ID
                    WHERE F.SALES_PER_ID = '" + cmbSalesPerson.SelectedValue.ToString() + @"' AND A.PAY_AC = '" + cmbPayAccount.SelectedValue.ToString() + @"' 
                    AND A.STATUS = '0' AND A.REF_AC = '" + cmbRefAc.Text + @"' AND
                    A.CONFORMATION_DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
                    ORDER BY [CONFORMATION_DATE]";
                    }
                }
                else
                {
                    if (cmbSalesPerson.SelectedValue.ToString().Equals("0") && cmbSalesPerson.Text.Equals("-ALL-") &&
                        cmbPayAccount.SelectedValue.ToString().Equals("0") && cmbPayAccount.Text.Equals("-ALL-") &&
                        cmbRefAc.SelectedValue.ToString().Equals("0") && cmbRefAc.Text.Equals("-ALL-"))
                    {
                        classHelper.query = @"SELECT ISNULL(F.NAME,'OTHER') AS [SALES PERSON],A.PT_ID,A.PV_NO,A.DATE,B.COA_NAME AS [REC ACCOUNT],A.AMOUNT,A.BANK,A.BR_CODE,A.INSTRUMENT_NO,
                    C.COA_NAME AS [PAY ACCOUNT],A.SUB_ACC,
                    A.REF_AC AS [REF AC],
                    CASE WHEN A.STATUS = '0' THEN 'PENDING' ELSE 'APPROVED' END AS [STATUS],
                    A.CONFORMATION_DATE,A.PERSON,A.REMARKS
                    FROM PAYMENT_TRANSFER A
                    INNER JOIN COA B ON A.REC_AC = B.COA_ID
                    INNER JOIN COA C ON A.PAY_AC = C.COA_ID
                    LEFT JOIN CUSTOMER_PROFILE E ON E.COA_ID = B.COA_ID
                    LEFT JOIN SALES_PERSONS F ON E.SALE_PER_ID = F.SALES_PER_ID
                    WHERE 
                    A.CONFORMATION_DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
                    ORDER BY [CONFORMATION_DATE]";
                    }
                    else if (cmbSalesPerson.SelectedValue.ToString().Equals("0") && cmbSalesPerson.Text.Equals("-ALL-") &&
                        !cmbPayAccount.SelectedValue.ToString().Equals("0") && !cmbPayAccount.Text.Equals("-ALL-") &&
                        cmbRefAc.SelectedValue.ToString().Equals("0") && cmbRefAc.Text.Equals("-ALL-"))
                    {
                        classHelper.query = @"SELECT ISNULL(F.NAME,'OTHER') AS [SALES PERSON],A.PT_ID,A.PV_NO,A.DATE,B.COA_NAME AS [REC ACCOUNT],A.AMOUNT,A.BANK,A.BR_CODE,A.INSTRUMENT_NO,
                    C.COA_NAME AS [PAY ACCOUNT],A.SUB_ACC,
                    A.REF_AC AS [REF AC],
                    CASE WHEN A.STATUS = '0' THEN 'PENDING' ELSE 'APPROVED' END AS [STATUS],
                    A.CONFORMATION_DATE,A.PERSON,A.REMARKS
                    FROM PAYMENT_TRANSFER A
                    INNER JOIN COA B ON A.REC_AC = B.COA_ID
                    INNER JOIN COA C ON A.PAY_AC = C.COA_ID
                    LEFT JOIN CUSTOMER_PROFILE E ON E.COA_ID = B.COA_ID
                    LEFT JOIN SALES_PERSONS F ON E.SALE_PER_ID = F.SALES_PER_ID
                    WHERE A.PAY_AC = '" + cmbPayAccount.SelectedValue.ToString() + @"' AND
                    A.CONFORMATION_DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
                    ORDER BY [CONFORMATION_DATE]";
                    }
                    else if (!cmbSalesPerson.SelectedValue.ToString().Equals("0") && !cmbSalesPerson.Text.Equals("-ALL-") &&
                        cmbPayAccount.SelectedValue.ToString().Equals("0") && cmbPayAccount.Text.Equals("-ALL-") &&
                        cmbRefAc.SelectedValue.ToString().Equals("0") && cmbRefAc.Text.Equals("-ALL-"))
                    {
                        classHelper.query = @"SELECT ISNULL(F.NAME,'OTHER') AS [SALES PERSON],A.PT_ID,A.PV_NO,A.DATE,B.COA_NAME AS [REC ACCOUNT],A.AMOUNT,A.BANK,A.BR_CODE,A.INSTRUMENT_NO,
                    C.COA_NAME AS [PAY ACCOUNT],A.SUB_ACC,
                    A.REF_AC AS [REF AC],
                    CASE WHEN A.STATUS = '0' THEN 'PENDING' ELSE 'APPROVED' END AS [STATUS],
                    A.CONFORMATION_DATE,A.PERSON,A.REMARKS
                    FROM PAYMENT_TRANSFER A
                    INNER JOIN COA B ON A.REC_AC = B.COA_ID
                    INNER JOIN COA C ON A.PAY_AC = C.COA_ID
                    LEFT JOIN CUSTOMER_PROFILE E ON E.COA_ID = B.COA_ID
                    LEFT JOIN SALES_PERSONS F ON E.SALE_PER_ID = F.SALES_PER_ID
                    WHERE F.SALES_PER_ID = '" + cmbSalesPerson.SelectedValue.ToString() + @"' AND
                    A.CONFORMATION_DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
                    ORDER BY [CONFORMATION_DATE]";
                    }
                    else if (cmbSalesPerson.SelectedValue.ToString().Equals("0") && cmbSalesPerson.Text.Equals("-ALL-") &&
                        cmbPayAccount.SelectedValue.ToString().Equals("0") && cmbPayAccount.Text.Equals("-ALL-") &&
                        !cmbRefAc.SelectedValue.ToString().Equals("0") && !cmbRefAc.Text.Equals("-ALL-"))
                    {
                        classHelper.query = @"SELECT ISNULL(F.NAME,'OTHER') AS [SALES PERSON],A.PT_ID,A.PV_NO,A.DATE,B.COA_NAME AS [REC ACCOUNT],A.AMOUNT,A.BANK,A.BR_CODE,A.INSTRUMENT_NO,
                    C.COA_NAME AS [PAY ACCOUNT],A.SUB_ACC,
                    A.REF_AC AS [REF AC],
                    CASE WHEN A.STATUS = '0' THEN 'PENDING' ELSE 'APPROVED' END AS [STATUS],
                    A.CONFORMATION_DATE,A.PERSON,A.REMARKS
                    FROM PAYMENT_TRANSFER A
                    INNER JOIN COA B ON A.REC_AC = B.COA_ID
                    INNER JOIN COA C ON A.PAY_AC = C.COA_ID
                    LEFT JOIN CUSTOMER_PROFILE E ON E.COA_ID = B.COA_ID
                    LEFT JOIN SALES_PERSONS F ON E.SALE_PER_ID = F.SALES_PER_ID
                    WHERE A.REF_AC = '" + cmbRefAc.Text + @"' AND
                    A.CONFORMATION_DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
                    ORDER BY [CONFORMATION_DATE]";
                    }
                    else
                    {
                        classHelper.query = @"SELECT F.NAME AS [SALES PERSON],A.PT_ID,A.PV_NO,A.DATE,B.COA_NAME AS [REC ACCOUNT],A.AMOUNT,A.BANK,A.BR_CODE,A.INSTRUMENT_NO,
                    C.COA_NAME AS [PAY ACCOUNT],A.SUB_ACC,
                    A.REF_AC AS [REF AC],
                    CASE WHEN A.STATUS = '0' THEN 'PENDING' ELSE 'APPROVED' END AS [STATUS],
                    A.CONFORMATION_DATE,A.PERSON,A.REMARKS
                    FROM PAYMENT_TRANSFER A
                    INNER JOIN COA B ON A.REC_AC = B.COA_ID
                    INNER JOIN COA C ON A.PAY_AC = C.COA_ID
                    INNER JOIN CUSTOMER_PROFILE E ON E.COA_ID = B.COA_ID
                    INNER JOIN SALES_PERSONS F ON E.SALE_PER_ID = F.SALES_PER_ID
                    WHERE F.SALES_PER_ID = '" + cmbSalesPerson.SelectedValue.ToString() + @"' AND 
                    A.PAY_AC = '" + cmbPayAccount.SelectedValue.ToString() + @"' AND A.REF_AC = '" + cmbRefAc.Text + @"' AND
                    A.CONFORMATION_DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
                    ORDER BY [CONFORMATION_DATE]";
                    }
                }
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
                    classHelper.mds.Tables["PaymentTransferSheet"].Clear();
                    while (classHelper.dr.Read())
                    {
                        classHelper.dataR = classHelper.mds.Tables["PaymentTransferSheet"].NewRow();
                        classHelper.dataR["date"] = Convert.ToDateTime(classHelper.dr["DATE"].ToString());
                        classHelper.dataR["recAccount"] = classHelper.dr["REC ACCOUNT"].ToString();
                        classHelper.dataR["amount"] = Convert.ToDecimal(classHelper.dr["AMOUNT"].ToString());
                        classHelper.dataR["bank"] = classHelper.dr["BANK"].ToString();
                        classHelper.dataR["brCode"] = classHelper.dr["BR_CODE"].ToString();
                        classHelper.dataR["instrumentNo"] = classHelper.dr["INSTRUMENT_NO"].ToString();
                        classHelper.dataR["paymentAccount"] = classHelper.dr["PAY ACCOUNT"].ToString();
                        classHelper.dataR["refAccount"] = classHelper.dr["REF AC"].ToString();
                        classHelper.dataR["subAcc"] = classHelper.dr["SUB_ACC"].ToString();

                        classHelper.dataR["status"] = classHelper.dr["STATUS"].ToString();
                        if (classHelper.dr["CONFORMATION_DATE"].ToString().Equals(""))
                        {
                            classHelper.dataR["conformationDate"] = "";
                        }
                        else {
                            classHelper.dataR["conformationDate"] = String.Format("{0:dd-MM-yyyy}", Convert.ToDateTime(classHelper.dr["CONFORMATION_DATE"].ToString()));
                        }
                        classHelper.dataR["salesPerson"] = classHelper.dr["SALES PERSON"].ToString();
                        classHelper.dataR["from"] = dtp_FROM.Value.Date;
                        classHelper.dataR["to"] = dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                        classHelper.dataR["remarks"] = classHelper.dr["REMARKS"].ToString();
                        classHelper.mds.Tables["PaymentTransferSheet"].Rows.Add(classHelper.dataR);
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
                classHelper.rpt = new Reporting.frmReports();
                classHelper.rpt.GenerateReport("PaymentTransferSheet", classHelper.mds);
                classHelper.rpt.ShowDialog();
            }
        }

        private void grpSALES_Enter(object sender, EventArgs e)
        {
            
        }



        private void btnINTER_SAVE_Click(object sender, EventArgs e)
        {
            if (cmbSalesPerson.SelectedValue.ToString().Equals("0") && !cmbSalesPerson.Text.Equals("-ALL-"))
            {
                classHelper.ShowMessageBox("Select Sales Person", "Error");
            }
            else if (cmbPayAccount.SelectedValue.ToString().Equals("0") && !cmbPayAccount.Text.Equals("-ALL-"))
            {
                classHelper.ShowMessageBox("Select Payment Account", "Error");
            }
            else {
                LoadPaymentEntries();
                TotalSum();
            }
        }

        private void LoadBank()
        {
            Classes.cls_Payment_Transfer clspt = new Classes.cls_Payment_Transfer();
            clspt.load_bank(cmbBank);
        }

        private void frm_Account_Ledger_Load(object sender, EventArgs e)
        {
            LoadSalesPerson();
            LoadPaymentAccount();
            LoadRefAccount();
            LoadRecAccount();
            LoadPerson();
            LoadBank();
            clsPt.load_names(cmbSubAccount);
        }

        private void frm_Account_Ledger_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            ShowReport();
        }
        
        //private void dtp_OnTextChange(object sender, EventArgs e)
        //{
        //    grdEntries.CurrentCell.Value = dtp.Value.ToString();
        //}
        //void dtp_CloseUp(object sender, EventArgs e)
        //{
        //    dtp.Visible = false;
        //}
        private void grdPOList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (grdEntries.CurrentCell.ColumnIndex.Equals(11) && e.RowIndex != -1 && grdEntries.Rows.Count > 0)
            //{ 
            //    dtp = new DateTimePicker();
            //    grdEntries.Controls.Add(dtp);
            //    dtp.Format = DateTimePickerFormat.Short;
            //    if (grdEntries.Rows[e.RowIndex].Cells["conformationDate"].Value.ToString().Equals(""))
            //    {
            //        dtp.Value = DateTime.Now;
            //    }
            //    else {
            //        dtp.Value = Convert.ToDateTime(grdEntries.Rows[e.RowIndex].Cells["conformationDate"].Value.ToString());
            //    }
            //    Rectangle Rectangle = grdEntries.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            //    dtp.Size = new Size(Rectangle.Width, Rectangle.Height);
            //    dtp.Location = new Point(Rectangle.X, Rectangle.Y);

            //    dtp.CloseUp += new EventHandler(dtp_CloseUp);
            //    dtp.TextChanged += new EventHandler(dtp_OnTextChange);


            //    dtp.Visible = true;
            //}

            //switch (grdEntries.Columns[e.ColumnIndex].Name)
            //{
            //    case "conformationDate":

            //        _Rectangle = grdEntries.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true); //  
            //        dtp.Size = new Size(_Rectangle.Width, _Rectangle.Height); //  
            //        dtp.Location = new Point(_Rectangle.X, _Rectangle.Y); //  
            //        dtp.Visible = true;

            //        break;

            //}
        }

        private void btnDiscard_Click(object sender, EventArgs e)
        {
            UpdateDiscardPO();
        }

        private void grdPOList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            
        }

        private void grdEntries_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            TotalSum();
        }

        private void grdEntries_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            //dtp.Visible = false;
        }

        private void grdEntries_Scroll(object sender, ScrollEventArgs e)
        {
            //dtp.Visible = false;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvr in grdEntries.Rows)
            {
                if (dgvr.Cells["select"].Value.ToString().Equals("True"))
                {
                    dgvr.Cells["conformationDate"].Value = dtpConformationDate.Value;
                    dgvr.Cells["person"].Value = cmbPerson.Text;
                }
                else {
                    dgvr.Cells["conformationDate"].Value = "";
                    dgvr.Cells["person"].Value ="";
                }
            }
        }
    }
}
