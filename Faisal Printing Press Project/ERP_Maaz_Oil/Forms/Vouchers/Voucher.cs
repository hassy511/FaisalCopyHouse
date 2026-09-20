using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP_Maaz_Oil.Forms.Vouchers
{
    class Voucher
    {
        Classes.Helper classHelper = new Classes.Helper();
        public string ReceiptVoucherQuery(int id)
        {
            return @"WITH A AS (SELECT A.DAY_BOOK_ID AS [ID],E.REC_PERSON_NAME AS PAID_TO,B.COA_NAME AS [DEBIT TO],
            A.[DATE],D.CHQ_NO,FORMAT(D.CHQ_DATE,'dd-MM-yyyy') as CHQ_DATE,D.BANK_NAME,D.AMOUNT
            FROM DAY_BOOK A
            INNER JOIN COA B ON A.CREDIT_AC = B.COA_ID
            LEFT JOIN DAY_BOOK_CHQ C ON A.DAY_BOOK_ID = C.DAY_BOOK_ID
            LEFT JOIN CHQ D ON C.CHQ_ID = D.CHQ_ID
            INNER JOIN RECOVERY_PERSON E ON A.REC_PERSON_ID = E.REC_PERSON_ID
            WHERE A.DAY_BOOK_ID = '" + id + @"'
            UNION ALL
            SELECT A.DAY_BOOK_ID AS [ID],E.REC_PERSON_NAME AS PAID_TO,B.COA_NAME AS [DEBIT TO],
            A.[DATE],'' as CHQ_NO,NULL as CHQ_DATE,'-CASH' as BANK_NAME,A.CASH_AMOUNT
            FROM DAY_BOOK A
            INNER JOIN COA B ON A.CREDIT_AC = B.COA_ID
            INNER JOIN RECOVERY_PERSON E ON A.REC_PERSON_ID = E.REC_PERSON_ID
            WHERE A.DAY_BOOK_ID = '" + id + @"')
            SELECT * FROM A WHERE AMOUNT > 0 order by BANK_NAME,CHQ_DATE";
        }

        public string PaymentVoucherQuery(int id,bool withCustomer)
        {
            string query = @"WITH A AS (
                SELECT A.DAY_BOOK_ID AS [ID],A.PAID_TO,C.COA_NAME AS [DEBIT TO],
                A.[DATE],B.CHQ_NO,FORMAT(B.CHQ_DATE,'dd-MM-yyyy') as CHQ_DATE,B.BANK_NAME,B.AMOUNT
                FROM DAY_BOOK A
                INNER JOIN COA C ON A.DEBIT_AC = C.COA_ID
                INNER JOIN DAY_BOOK_CHQ D ON A.DAY_BOOK_ID = D.DAY_BOOK_ID AND D.[TYPE] = 'P'
                INNER JOIN CHQ B ON D.CHQ_ID = B.CHQ_ID
                WHERE A.DAY_BOOK_ID = '" + id + @"'
                UNION ALL
                SELECT A.DAY_BOOK_ID AS [ID],A.PAID_TO,B.COA_NAME AS [DEBIT TO],
                A.[DATE],'' as CHQ_NO,NULL as CHQ_DATE,'-CASH' as BANK_NAME,A.CASH_AMOUNT
                FROM DAY_BOOK A
                INNER JOIN COA B ON A.DEBIT_AC = B.COA_ID
                WHERE A.DAY_BOOK_ID = '" + id + @"')";

            if(withCustomer)
                query += " SELECT * FROM A WHERE AMOUNT > 0 order by CUST_NAME,BANK_NAME,CHQ_DATE";
            else
                query += " SELECT * FROM A WHERE AMOUNT > 0 order by BANK_NAME,CHQ_DATE";
            return query;

        }
        public string CashReceiptVoucherQuery(int id)
        {
            //return @"SELECT CRV_ID AS [ID],C.COA_NAME AS [DEBIT_TO],A.DAATE AS [DATE],
            // A.[DESCRIPTION],A.REF_ACCOUNT,A.AMOUNT
            // FROM CASH_REC_VOUCHER A 
            // INNER JOIN RECOVERY_PERSON B ON A.REC_PERSON_ID = B.REC_PERSON_ID
            //INNER JOIN COA C ON A.COA_ID = C.COA_ID
            //WHERE A.CRV_ID = '" + id + "'";
            return @" SELECT CPV_ID AS[ID], A.DAATE AS[DATE],
                       A.AMOUNT,  A.TYPE , A.DESCRIPTION, C.COA_NAME AS [ACCOUNT]
                       FROM  CASHPAYRECMASTER A 
                       INNER JOIN COA C ON A.COA_ID = C.COA_ID
                       WHERE A.CPV_ID = '" + id + "'";
        }


        public string CashPaymentVoucherQuery(int id)
        {
            //  return @"SELECT CPV_ID AS [ID],A.PAID_TO AS [PAID TO],C.COA_NAME AS [DEBIT_TO],A.DAATE AS [DATE],
            // A.REF_ACCOUNT,A.AMOUNT,A.ACCOUNT_OF
            // FROM CASH_PAY_VOUCHER A 
            //INNER JOIN COA C ON A.COA_ID = C.COA_ID
            //WHERE A.CPV_ID = '" + id + "'";


           return @" SELECT CPV_ID AS[ID], A.DAATE AS[DATE],
                       A.AMOUNT,  A.TYPE , A.DESCRIPTION, C.COA_NAME AS [ACCOUNT]
                       FROM  CASHPAYRECMASTER A 
                       INNER JOIN COA C ON A.COA_ID = C.COA_ID
                       WHERE A.CPV_ID = '" + id + "'";
        }

        
        public string CashBankPaymentVoucherQuery(int id)
        {

            return @" SELECT CPV_ID AS[ID], A.DAATE AS[DATE],
                       A.AMOUNT,  A.TYPE , A.DESCRIPTION, C.COA_NAME AS [BANK]
                       FROM  
                      CASHBANKRECMASTER A 
                       INNER JOIN COA C ON A.COA_ID = C.COA_ID
                       WHERE A.CPV_ID = '" + id + "'";
        }

        public void BankCashPaymentVoucherReport(int id)
        {
            try
            {
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(CashBankPaymentVoucherQuery(id), Classes.Helper.conn);

                SqlDataReader dr;
                dr = classHelper.cmd.ExecuteReader();
                if (dr.HasRows == true)
                
                    {
                    classHelper.dataR = classHelper.mds.Tables["ReceiptPaymentVoucher"].NewRow();
                    classHelper.dataR["id"] = Convert.ToDouble(dr["ID"].ToString());
                    //     classHelper.dataR["paidRecTo"] = classHelper.dr["PAID TO"].ToString();
                    // classHelper.dataR["debitCreditAc"] = classHelper.dr["DEBIT_TO"].ToString();
                    classHelper.dataR["date"] = Convert.ToDateTime(dr["DATE"].ToString());
                    //     classHelper.dataR["bankName"] = classHelper.dr["TYPE"].ToString();
                   // classHelper.dataR["chqDate"] = classHelper.dr["DESCRIPTION"].ToString();
                   // classHelper.dataR["bankName"] = classHelper.dr["BANK"].ToString();
                 //   classHelper.dataR["amount"] = Convert.ToDouble(classHelper.dr["AMOUNT"].ToString());
                    classHelper.dataR["voucherName"] = "CASH PAYMENT VOUCHER";
                    //     classHelper.dataR["userName"] = Classes.Helper.GetUserName(Convert.ToInt32(classHelper.dr["CREATED_BY"].ToString()));
                    classHelper.mds.Tables["ReceiptPaymentVoucher"].Rows.Add(classHelper.dataR);
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

            classHelper.rpt = new ERP_Maaz_Oil.Forms.Reporting.frmReports();
            classHelper.rpt.GenerateReport("CashPaymentVoucher", classHelper.mds);
            classHelper.rpt.ShowDialog();
        }




        public void CashPaymentVoucherReport(int id)
        {
            try
            {
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(CashPaymentVoucherQuery(id), Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    classHelper.mds.Tables["ReceiptPaymentVoucher"].Clear();
                    while (classHelper.dr.Read())
                    {
                        classHelper.dataR = classHelper.mds.Tables["ReceiptPaymentVoucher"].NewRow();
                        classHelper.dataR["id"] = Convert.ToDouble(classHelper.dr["ID"].ToString());
                   //     classHelper.dataR["paidRecTo"] = classHelper.dr["PAID TO"].ToString();
                       // classHelper.dataR["debitCreditAc"] = classHelper.dr["DEBIT_TO"].ToString();
                        classHelper.dataR["date"] = Convert.ToDateTime(classHelper.dr["DATE"].ToString());
                   //     classHelper.dataR["bankName"] = classHelper.dr["TYPE"].ToString();
                       classHelper.dataR["chqDate"] = classHelper.dr["DESCRIPTION"].ToString();
                    classHelper.dataR["bankName"] = classHelper.dr["ACCOUNT"].ToString();
                        classHelper.dataR["amount"] = Convert.ToDouble(classHelper.dr["AMOUNT"].ToString());
                        classHelper.dataR["voucherName"] = "CASH PAYMENT VOUCHER";
                   //     classHelper.dataR["userName"] = Classes.Helper.GetUserName(Convert.ToInt32(classHelper.dr["CREATED_BY"].ToString()));
                        classHelper.mds.Tables["ReceiptPaymentVoucher"].Rows.Add(classHelper.dataR);
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

            classHelper.rpt = new ERP_Maaz_Oil.Forms.Reporting.frmReports();
            classHelper.rpt.GenerateReport("CashPaymentVoucher", classHelper.mds);
            classHelper.rpt.ShowDialog();
        }
        public void CashReceiptVoucherReport(int id)
        {
            try
            {
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(CashReceiptVoucherQuery(id), Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    classHelper.mds.Tables["ReceiptPaymentVoucher"].Clear();
                    while (classHelper.dr.Read())
                    {
                        classHelper.dataR = classHelper.mds.Tables["ReceiptPaymentVoucher"].NewRow();
                        classHelper.dataR["id"] = Convert.ToDouble(classHelper.dr["ID"].ToString());
                        //lassHelper.dataR["paidRecTo"] = classHelper.dr["REC_FROM"].ToString();
                     //   classHelper.dataR["debitCreditAc"] = classHelper.dr["DEBIT_TO"].ToString();
                        classHelper.dataR["date"] = Convert.ToDateTime(classHelper.dr["DATE"].ToString());
                        classHelper.dataR["chqDate"] = classHelper.dr["DESCRIPTION"].ToString();
                        classHelper.dataR["bankName"] = classHelper.dr["ACCOUNT"].ToString();
                        classHelper.dataR["amount"] = Convert.ToDouble(classHelper.dr["AMOUNT"].ToString());

                        //  classHelper.dataR["chqNo"] = classHelper.dr["FOLIO"].ToString();
                        //   classHelper.dataR["chqDate"] = classHelper.dr["DESCRIPTION"].ToString();
                        //classHelper.dataR["bankName"] = classHelper.dr["REF_ACCOUNT"].ToString();
                     //   classHelper.dataR["amount"] = Convert.ToDouble(classHelper.dr["AMOUNT"].ToString());
                        classHelper.dataR["voucherName"] = "CASH RECEIPT VOUCHER";
                        classHelper.mds.Tables["ReceiptPaymentVoucher"].Rows.Add(classHelper.dataR);
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

            classHelper.rpt = new ERP_Maaz_Oil.Forms.Reporting.frmReports();
            classHelper.rpt.GenerateReport("CashReceiptVoucher", classHelper.mds);
            classHelper.rpt.ShowDialog();
        }




        public string BankCashReceiptVoucherQuery(int id)
        {
            return @" SELECT CPV_ID AS[ID], A.DAATE AS[DATE],
                       A.AMOUNT,  A.TYPE , A.DESCRIPTION, C.COA_NAME AS [BANK]
                       FROM  CASHBANKRECMASTER A 
                       INNER JOIN COA C ON A.COA_ID = C.COA_ID
                       WHERE A.CPV_ID = '" + id + "'";
        }
        public void BankCashReceiptVoucherReport(int id)
        {
            try
            {
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(BankCashReceiptVoucherQuery(id), Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    classHelper.mds.Tables["ReceiptPaymentVoucher"].Clear();
                    while (classHelper.dr.Read())
                    {
                        classHelper.dataR = classHelper.mds.Tables["ReceiptPaymentVoucher"].NewRow();
                        classHelper.dataR["id"] = Convert.ToDouble(classHelper.dr["ID"].ToString());
                        //lassHelper.dataR["paidRecTo"] = classHelper.dr["REC_FROM"].ToString();
                        //   classHelper.dataR["debitCreditAc"] = classHelper.dr["DEBIT_TO"].ToString();
                        classHelper.dataR["date"] = Convert.ToDateTime(classHelper.dr["DATE"].ToString());
                        classHelper.dataR["chqDate"] = classHelper.dr["DESCRIPTION"].ToString();
                        classHelper.dataR["bankName"] = classHelper.dr["BANK"].ToString();
                        classHelper.dataR["amount"] = Convert.ToDouble(classHelper.dr["AMOUNT"].ToString());

                        //  classHelper.dataR["chqNo"] = classHelper.dr["FOLIO"].ToString();
                        //   classHelper.dataR["chqDate"] = classHelper.dr["DESCRIPTION"].ToString();
                        //classHelper.dataR["bankName"] = classHelper.dr["REF_ACCOUNT"].ToString();
                        //   classHelper.dataR["amount"] = Convert.ToDouble(classHelper.dr["AMOUNT"].ToString());
                        classHelper.dataR["voucherName"] = "CASH RECEIPT VOUCHER";
                        classHelper.mds.Tables["ReceiptPaymentVoucher"].Rows.Add(classHelper.dataR);
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

            classHelper.rpt = new ERP_Maaz_Oil.Forms.Reporting.frmReports();
            classHelper.rpt.GenerateReport("CashReceiptVoucher", classHelper.mds);
            classHelper.rpt.ShowDialog();
        }

        public void ReceiptVoucherReport(int id) {
            try
            {
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(ReceiptVoucherQuery(id), Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    classHelper.mds.Tables["ReceiptPaymentVoucher"].Clear();
                    while (classHelper.dr.Read())
                    {
                        classHelper.dataR = classHelper.mds.Tables["ReceiptPaymentVoucher"].NewRow();
                        classHelper.dataR["id"] = Convert.ToDouble(classHelper.dr["ID"].ToString());
                        classHelper.dataR["paidRecTo"] = classHelper.dr["PAID_TO"].ToString();
                        classHelper.dataR["debitCreditAc"] = classHelper.dr["DEBIT TO"].ToString();
                        classHelper.dataR["date"] = Convert.ToDateTime(classHelper.dr["DATE"].ToString());
                        classHelper.dataR["chqNo"] = classHelper.dr["CHQ_NO"].ToString();
                        classHelper.dataR["chqDate"] = classHelper.dr["CHQ_DATE"].ToString();
                        classHelper.dataR["bankName"] = classHelper.dr["BANK_NAME"].ToString();
                        classHelper.dataR["amount"] = Convert.ToDouble(classHelper.dr["AMOUNT"].ToString());
                        classHelper.dataR["voucherName"] = "RECEIPT VOUCHER";

                        classHelper.mds.Tables["ReceiptPaymentVoucher"].Rows.Add(classHelper.dataR);
                    }
                    
                }
                //classHelper.dr.Close();

                //string query = @"SELECT A.DAY_BOOK_ID AS [ID],E.REC_PERSON_NAME AS PAID_TO,B.COA_NAME AS [DEBIT TO],
                //        A.[DATE],'' as CHQ_NO,NULL as CHQ_DATE,'CASH' as BANK_NAME,A.CASH_AMOUNT as [AMOUNT]
                //        FROM DAY_BOOK A
                //        INNER JOIN COA B ON A.CREDIT_AC = B.COA_ID
                //        INNER JOIN RECOVERY_PERSON E ON A.REC_PERSON_ID = E.REC_PERSON_ID
                //        WHERE A.DAY_BOOK_ID = '" + id + @"'";
                //SqlCommand cmd = new SqlCommand(query, Classes.Helper.conn);
                //if (Classes.Helper.conn.State == System.Data.ConnectionState.Closed)
                //    Classes.Helper.conn.Open();
                //SqlDataReader dr = cmd.ExecuteReader();
                //if (dr.HasRows)
                //{
                //    while (dr.Read())
                //    {
                //        classHelper.dataR = classHelper.mds.Tables["ReceiptPaymentVoucher"].NewRow();
                //        classHelper.dataR["id"] = Convert.ToDouble(dr["ID"].ToString());
                //        classHelper.dataR["paidRecTo"] = dr["PAID_TO"].ToString();
                //        classHelper.dataR["debitCreditAc"] = dr["DEBIT TO"].ToString();
                //        classHelper.dataR["date"] = Convert.ToDateTime(dr["DATE"].ToString());
                //        classHelper.dataR["chqNo"] = dr["CHQ_NO"].ToString();
                //        classHelper.dataR["chqDate"] = dr["CHQ_DATE"].ToString();
                //        classHelper.dataR["bankName"] = dr["BANK_NAME"].ToString();
                //        classHelper.dataR["amount"] = Convert.ToDouble(dr["AMOUNT"].ToString());
                //        classHelper.dataR["voucherName"] = "RECEIPT VOUCHER";

                //        classHelper.mds.Tables["ReceiptPaymentVoucher"].Rows.Add(classHelper.dataR);
                //    }
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Classes.Helper.conn.Close();
            }

            classHelper.rpt = new ERP_Maaz_Oil.Forms.Reporting.frmReports();
            classHelper.rpt.GenerateReport("ReceiptVoucher", classHelper.mds);
            classHelper.rpt.ShowDialog();
        }

        public void PaymentVoucherReport(int id,int accountId)
        {
            try
            {
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(PaymentVoucherQuery(id,false), Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    classHelper.mds.Tables["ReceiptPaymentVoucher"].Clear();
                    while (classHelper.dr.Read())
                    {
                        classHelper.dataR = classHelper.mds.Tables["ReceiptPaymentVoucher"].NewRow();
                        classHelper.dataR["id"] = Convert.ToDouble(classHelper.dr["ID"].ToString());
                        classHelper.dataR["paidRecTo"] = classHelper.dr["PAID_TO"].ToString();
                        classHelper.dataR["debitCreditAc"] = classHelper.dr["DEBIT TO"].ToString();
                        classHelper.dataR["date"] = Convert.ToDateTime(classHelper.dr["DATE"].ToString());
                        classHelper.dataR["chqNo"] = classHelper.dr["CHQ_NO"].ToString();
                        classHelper.dataR["chqDate"] = classHelper.dr["CHQ_DATE"].ToString();
                        classHelper.dataR["bankName"] = classHelper.dr["BANK_NAME"].ToString();
                        classHelper.dataR["custName"] = "ORIGNAL";
                        classHelper.dataR["balance"] = classHelper.GetAccountBalance(accountId);
                        classHelper.dataR["amount"] = Convert.ToDouble(classHelper.dr["AMOUNT"].ToString());
                        classHelper.dataR["voucherName"] = "PAYMENT VOUCHER";
                        classHelper.mds.Tables["ReceiptPaymentVoucher"].Rows.Add(classHelper.dataR);
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

            try
            {
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(PaymentVoucherQuery(id, false), Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    while (classHelper.dr.Read())
                    {
                        classHelper.dataR = classHelper.mds.Tables["ReceiptPaymentVoucher"].NewRow();
                        classHelper.dataR["id"] = Convert.ToDouble(classHelper.dr["ID"].ToString());
                        classHelper.dataR["paidRecTo"] = classHelper.dr["PAID_TO"].ToString();
                        classHelper.dataR["debitCreditAc"] = classHelper.dr["DEBIT TO"].ToString();
                        classHelper.dataR["date"] = Convert.ToDateTime(classHelper.dr["DATE"].ToString());
                        classHelper.dataR["chqNo"] = classHelper.dr["CHQ_NO"].ToString();
                        classHelper.dataR["chqDate"] = classHelper.dr["CHQ_DATE"].ToString();
                        classHelper.dataR["bankName"] = classHelper.dr["BANK_NAME"].ToString();
                        classHelper.dataR["custName"] = "DUPLICATE";
                        classHelper.dataR["balance"] = classHelper.GetAccountBalance(accountId);
                        classHelper.dataR["amount"] = Convert.ToDouble(classHelper.dr["AMOUNT"].ToString());
                        classHelper.dataR["voucherName"] = "PAYMENT VOUCHER";
                        classHelper.mds.Tables["ReceiptPaymentVoucher"].Rows.Add(classHelper.dataR);
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

            classHelper.rpt = new ERP_Maaz_Oil.Forms.Reporting.frmReports();
            classHelper.rpt.GenerateReport("PaymentVoucher", classHelper.mds);
            classHelper.rpt.ShowDialog();
        }


        public void PaymentVoucherReportWithCust(int id)
        {
            try
            {
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(PaymentVoucherQuery(id,true), Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    classHelper.nds.Tables["ReceiptPaymentVoucher"].Clear();
                    while (classHelper.dr.Read())
                    {
                        classHelper.dataR = classHelper.nds.Tables["ReceiptPaymentVoucher"].NewRow();
                        classHelper.dataR["id"] = Convert.ToDouble(classHelper.dr["ID"].ToString());
                        classHelper.dataR["paidRecTo"] = classHelper.dr["PAID_TO"].ToString();
                        classHelper.dataR["debitCreditAc"] = classHelper.dr["DEBIT TO"].ToString();
                        classHelper.dataR["date"] = Convert.ToDateTime(classHelper.dr["DATE"].ToString());
                        classHelper.dataR["chqNo"] = classHelper.dr["CHQ_NO"].ToString();
                        classHelper.dataR["chqDate"] = classHelper.dr["CHQ_DATE"].ToString();
                        classHelper.dataR["bankName"] = classHelper.dr["BANK_NAME"].ToString();
                        classHelper.dataR["custName"] = classHelper.dr["CUST_NAME"].ToString();

                        classHelper.dataR["amount"] = Convert.ToDouble(classHelper.dr["AMOUNT"].ToString());
                        classHelper.dataR["voucherName"] = "PAYMENT VOUCHER";
                        classHelper.nds.Tables["ReceiptPaymentVoucher"].Rows.Add(classHelper.dataR);
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

            classHelper.rpt = new ERP_Maaz_Oil.Forms.Reporting.frmReports();
            classHelper.rpt.GenerateReport("PaymentVoucherWithCust", classHelper.nds);
            classHelper.rpt.ShowDialog();
        }
    }
}
