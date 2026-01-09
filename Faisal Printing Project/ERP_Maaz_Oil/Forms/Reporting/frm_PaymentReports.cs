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
    public partial class frm_PaymentReports : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        public frm_PaymentReports()
        {
            InitializeComponent();
        }
        private void LoadSalesPerson()
        {
            classHelper.query = @"SELECT '0' AS [id],'-ALL-' as [name]
            UNION ALL
            SELECT SALES_PER_ID AS [id],NAME AS [name] FROM SALES_PERSONS WHERE SALES_PER_ID <> '1' ORDER BY [name]";
            classHelper.LoadComboData(cmbSalePerson, classHelper.query);
        }
        private void LoadCustomer()
        {
            classHelper.query = @"SELECT '0' AS [id],'-ALL-' as [name]
            UNION ALL
            SELECT COA_ID AS [id],COA_NAME AS [name] FROM COA ORDER BY [name]";
            classHelper.LoadComboData(cmbCustomer, classHelper.query);
        }
        private void LoadSupplier()
        {
            classHelper.query = @"SELECT '0' AS [id],'-ALL-' as [name]
            UNION ALL
            SELECT COA_ID AS [id],COA_NAME AS [name] FROM COA ORDER BY [name]";
            classHelper.LoadComboData(cmbSupplier, classHelper.query);
        }

     
        private void ConformationReport()
        {
            classHelper.query = @"SELECT A.SUB_ACC,A.DATE,A.AMOUNT,B.COA_NAME AS [CUSTOMER],A.BANK,A.BR_CODE,A.INSTRUMENT_NO,C.COA_NAME AS [SUPPLIER],A.REF_AC,
            'APPROVED' AS [STATUS],
            A.CONFORMATION_DATE,A.PERSON 
            FROM PAYMENT_TRANSFER A
            INNER JOIN COA B ON A.REC_AC = B.COA_ID
            INNER JOIN COA C ON A.PAY_AC = C.COA_ID
            WHERE A.STATUS = 1 AND A.CONFORMATION_DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
            ORDER BY A.REF_AC,B.COA_NAME,A.SUB_ACC,A.BANK ASC";
            
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

                        classHelper.dataR = classHelper.mds.Tables["PaymentTransferSheet"].NewRow();
                        classHelper.dataR["date"] = Convert.ToDateTime(classHelper.dr["DATE"].ToString());
                        classHelper.dataR["recAccount"] = classHelper.dr["CUSTOMER"].ToString();
                        classHelper.dataR["amount"] = Convert.ToDecimal(classHelper.dr["AMOUNT"].ToString());
                        classHelper.dataR["bank"] = classHelper.dr["BANK"].ToString();
                        classHelper.dataR["brCode"] = classHelper.dr["BR_CODE"].ToString();
                        classHelper.dataR["instrumentNo"] = classHelper.dr["INSTRUMENT_NO"].ToString();
                        classHelper.dataR["paymentAccount"] = classHelper.dr["SUPPLIER"].ToString();
                        classHelper.dataR["refAccount"] = classHelper.dr["REF_AC"].ToString();
                        classHelper.dataR["status"] = classHelper.dr["STATUS"].ToString();
                        classHelper.dataR["conformationDate"] = cDate;
                        classHelper.dataR["salesPerson"] = classHelper.dr["PERSON"].ToString();
                        classHelper.dataR["from"] = dtp_FROM.Value.Date;
                        classHelper.dataR["to"] = dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                        classHelper.dataR["subAcc"] = 
                            classHelper.dr["SUB_ACC"].ToString()=="--SELECT ACCOUNT--"? "N/A": classHelper.dr["SUB_ACC"].ToString();
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

            classHelper.query = @"SELECT B.COA_NAME AS [PAY ACCOUNT],SUM(A.AMOUNT) AS TOTAL
            FROM PAYMENT_TRANSFER A
            INNER JOIN COA B ON A.PAY_AC = B.COA_ID
            WHERE A.STATUS = 1 
            AND A.CONFORMATION_DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
            GROUP BY B.COA_NAME";

            try
            {
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    classHelper.mds.Tables["PaymentAccountSummary"].Clear();
                    while (classHelper.dr.Read())
                    {
                        classHelper.dataR = classHelper.mds.Tables["PaymentAccountSummary"].NewRow();
                        classHelper.dataR["name"] = classHelper.dr["PAY ACCOUNT"].ToString();
                        classHelper.dataR["amount"] = Convert.ToDecimal(classHelper.dr["TOTAL"].ToString());
                        classHelper.mds.Tables["PaymentAccountSummary"].Rows.Add(classHelper.dataR);
                    }
                }
                else
                {
                    // MessageBox.Show("No Record Found.", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            classHelper.query = @"SELECT D.NAME AS [SALES PERSON],SUM(A.AMOUNT) AS TOTAL
            FROM PAYMENT_TRANSFER A
            INNER JOIN COA B ON A.REC_AC = B.COA_ID
            INNER JOIN CUSTOMER_PROFILE C ON B.COA_ID = C.COA_ID
            INNER JOIN SALES_PERSONS D ON C.SALE_PER_ID = D.SALES_PER_ID
            WHERE A.STATUS = 1 
            AND A.CONFORMATION_DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
            GROUP BY D.NAME";

            try
            {
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    classHelper.mds.Tables["PaymentSalesPersonSummary"].Clear();
                    while (classHelper.dr.Read())
                    {
                        classHelper.dataR = classHelper.mds.Tables["PaymentSalesPersonSummary"].NewRow();
                        classHelper.dataR["name"] = classHelper.dr["SALES PERSON"].ToString();
                        classHelper.dataR["amount"] = Convert.ToDecimal(classHelper.dr["TOTAL"].ToString());
                        classHelper.mds.Tables["PaymentSalesPersonSummary"].Rows.Add(classHelper.dataR);
                    }
                }
                else
                {
                    // MessageBox.Show("No Record Found.", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                classHelper.rpt.GenerateReport("ConformationReport", classHelper.mds);
                classHelper.rpt.ShowDialog();
            }
        }
        private void ConformationCustomerReport()
        {
            classHelper.query = @"SELECT A.DATE,A.AMOUNT,B.COA_NAME AS [CUSTOMER],A.BANK,A.BR_CODE,A.INSTRUMENT_NO,C.COA_NAME AS [SUPPLIER],A.REF_AC,
            'APPROVED' AS [STATUS],
            A.CONFORMATION_DATE,A.PERSON 
            FROM PAYMENT_TRANSFER A
            INNER JOIN COA B ON A.REC_AC = B.COA_ID
            INNER JOIN COA C ON A.PAY_AC = C.COA_ID
            WHERE A.STATUS = 1 AND 
            A.CONFORMATION_DATE BETWEEN '" + dtp_FROM.Value.Date + @"' 
            AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"' AND A.REC_AC = '"+cmbCustomer.SelectedValue.ToString()+ @"'
            ORDER BY [DATE],A.REF_AC";

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

                        classHelper.dataR = classHelper.mds.Tables["PaymentTransferSheet"].NewRow();
                        classHelper.dataR["date"] = Convert.ToDateTime(classHelper.dr["DATE"].ToString());
                        classHelper.dataR["recAccount"] = classHelper.dr["CUSTOMER"].ToString();
                        classHelper.dataR["amount"] = Convert.ToDecimal(classHelper.dr["AMOUNT"].ToString());
                        classHelper.dataR["bank"] = classHelper.dr["BANK"].ToString();
                        classHelper.dataR["brCode"] = classHelper.dr["BR_CODE"].ToString();
                        classHelper.dataR["instrumentNo"] = classHelper.dr["INSTRUMENT_NO"].ToString();
                        classHelper.dataR["paymentAccount"] = classHelper.dr["SUPPLIER"].ToString();
                        classHelper.dataR["refAccount"] = classHelper.dr["REF_AC"].ToString();
                        classHelper.dataR["status"] = classHelper.dr["STATUS"].ToString();
                        classHelper.dataR["conformationDate"] = cDate;
                        classHelper.dataR["salesPerson"] = classHelper.dr["PERSON"].ToString();
                        classHelper.dataR["from"] = dtp_FROM.Value.Date;
                        classHelper.dataR["to"] = dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                        classHelper.mds.Tables["PaymentTransferSheet"].Rows.Add(classHelper.dataR);
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

            //classHelper.query = @"SELECT B.COA_NAME AS [PAY ACCOUNT],SUM(A.AMOUNT) AS TOTAL
            //FROM PAYMENT_TRANSFER A
            //INNER JOIN COA B ON A.PAY_AC = B.COA_ID
            //WHERE A.STATUS = 1 
            //AND A.CONFORMATION_DATE 
            //BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
            //AND A.REC_AC = '" + cmbCustomer.SelectedValue.ToString() + @"'
            //GROUP BY B.COA_NAME";

            //try
            //{
            //    Classes.Helper.conn.Open();
            //    classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
            //    classHelper.dr = classHelper.cmd.ExecuteReader();
            //    if (classHelper.dr.HasRows == true)
            //    {
            //        classHelper.mds.Tables["PaymentAccountSummary"].Clear();
            //        while (classHelper.dr.Read())
            //        {
            //            classHelper.dataR = classHelper.mds.Tables["PaymentAccountSummary"].NewRow();
            //            classHelper.dataR["name"] = classHelper.dr["PAY ACCOUNT"].ToString();
            //            classHelper.dataR["amount"] = Convert.ToDecimal(classHelper.dr["TOTAL"].ToString());
            //            classHelper.mds.Tables["PaymentAccountSummary"].Rows.Add(classHelper.dataR);
            //        }
            //    }
            //    else
            //    {
            //        // MessageBox.Show("No Record Found.", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //finally
            //{
            //    Classes.Helper.conn.Close();
            //}

            //classHelper.query = @"SELECT D.NAME AS [SALES PERSON],SUM(A.AMOUNT) AS TOTAL
            //FROM PAYMENT_TRANSFER A
            //INNER JOIN COA B ON A.REC_AC = B.COA_ID
            //INNER JOIN CUSTOMER_PROFILE C ON B.COA_ID = C.COA_ID
            //INNER JOIN SALES_PERSONS D ON C.SALE_PER_ID = D.SALES_PER_ID
            //WHERE A.STATUS = 1 
            //AND A.CONFORMATION_DATE 
            //BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
            //AND A.REC_AC = '" + cmbCustomer.SelectedValue.ToString() + @"'
            //GROUP BY D.NAME";

            //try
            //{
            //    Classes.Helper.conn.Open();
            //    classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
            //    classHelper.dr = classHelper.cmd.ExecuteReader();
            //    if (classHelper.dr.HasRows == true)
            //    {
            //        classHelper.mds.Tables["PaymentSalesPersonSummary"].Clear();
            //        while (classHelper.dr.Read())
            //        {
            //            classHelper.dataR = classHelper.mds.Tables["PaymentSalesPersonSummary"].NewRow();
            //            classHelper.dataR["name"] = classHelper.dr["SALES PERSON"].ToString();
            //            classHelper.dataR["amount"] = Convert.ToDecimal(classHelper.dr["TOTAL"].ToString());
            //            classHelper.mds.Tables["PaymentSalesPersonSummary"].Rows.Add(classHelper.dataR);
            //        }
            //    }
            //    else
            //    {
            //        // MessageBox.Show("No Record Found.", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //finally
            //{
            //    Classes.Helper.conn.Close();
            //}

            if (hasRows == 'Y')
            {
                classHelper.rpt = new frmReports();
                classHelper.rpt.GenerateReport("CustomerPendingReport", classHelper.mds);
                classHelper.rpt.ShowDialog();
            }
        }
        private void ConformationSupplierReport()
        {
            classHelper.query = @"SELECT A.DATE,A.AMOUNT,B.COA_NAME AS [CUSTOMER],A.BANK,A.BR_CODE,A.INSTRUMENT_NO,C.COA_NAME AS [SUPPLIER],A.REF_AC,
            'APPROVED' AS [STATUS],
            A.CONFORMATION_DATE,A.PERSON 
            FROM PAYMENT_TRANSFER A
            INNER JOIN COA B ON A.REC_AC = B.COA_ID
            INNER JOIN COA C ON A.PAY_AC = C.COA_ID
            WHERE A.STATUS = 1 AND 
            A.CONFORMATION_DATE BETWEEN '" + dtp_FROM.Value.Date + @"' 
            AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"' 
            AND A.PAY_AC = '" + cmbSupplier.SelectedValue.ToString() + @"'
            ORDER BY [DATE],A.REF_AC";

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

                        classHelper.dataR = classHelper.mds.Tables["PaymentTransferSheet"].NewRow();
                        classHelper.dataR["date"] = Convert.ToDateTime(classHelper.dr["DATE"].ToString());
                        classHelper.dataR["recAccount"] = classHelper.dr["CUSTOMER"].ToString();
                        classHelper.dataR["amount"] = Convert.ToDecimal(classHelper.dr["AMOUNT"].ToString());
                        classHelper.dataR["bank"] = classHelper.dr["BANK"].ToString();
                        classHelper.dataR["brCode"] = classHelper.dr["BR_CODE"].ToString();
                        classHelper.dataR["instrumentNo"] = classHelper.dr["INSTRUMENT_NO"].ToString();
                        classHelper.dataR["paymentAccount"] = classHelper.dr["SUPPLIER"].ToString();
                        classHelper.dataR["refAccount"] = classHelper.dr["REF_AC"].ToString();
                        classHelper.dataR["status"] = classHelper.dr["STATUS"].ToString();
                        classHelper.dataR["conformationDate"] = cDate;
                        classHelper.dataR["salesPerson"] = classHelper.dr["PERSON"].ToString();
                        classHelper.dataR["from"] = dtp_FROM.Value.Date;
                        classHelper.dataR["to"] = dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                        classHelper.mds.Tables["PaymentTransferSheet"].Rows.Add(classHelper.dataR);
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

            //classHelper.query = @"SELECT B.COA_NAME AS [PAY ACCOUNT],SUM(A.AMOUNT) AS TOTAL
            //FROM PAYMENT_TRANSFER A
            //INNER JOIN COA B ON A.PAY_AC = B.COA_ID
            //WHERE A.STATUS = 1 
            //AND A.CONFORMATION_DATE 
            //BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
            //AND A.PAY_AC = '" + cmbSupplier.SelectedValue.ToString() + @"'
            //GROUP BY B.COA_NAME";

            //try
            //{
            //    Classes.Helper.conn.Open();
            //    classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
            //    classHelper.dr = classHelper.cmd.ExecuteReader();
            //    if (classHelper.dr.HasRows == true)
            //    {
            //        classHelper.mds.Tables["PaymentAccountSummary"].Clear();
            //        while (classHelper.dr.Read())
            //        {
            //            classHelper.dataR = classHelper.mds.Tables["PaymentAccountSummary"].NewRow();
            //            classHelper.dataR["name"] = classHelper.dr["PAY ACCOUNT"].ToString();
            //            classHelper.dataR["amount"] = Convert.ToDecimal(classHelper.dr["TOTAL"].ToString());
            //            classHelper.mds.Tables["PaymentAccountSummary"].Rows.Add(classHelper.dataR);
            //        }
            //    }
            //    else
            //    {
            //        // MessageBox.Show("No Record Found.", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //finally
            //{
            //    Classes.Helper.conn.Close();
            //}

            //classHelper.query = @"SELECT D.NAME AS [SALES PERSON],SUM(A.AMOUNT) AS TOTAL
            //FROM PAYMENT_TRANSFER A
            //INNER JOIN COA B ON A.REC_AC = B.COA_ID
            //INNER JOIN CUSTOMER_PROFILE C ON B.COA_ID = C.COA_ID
            //INNER JOIN SALES_PERSONS D ON C.SALE_PER_ID = D.SALES_PER_ID
            //WHERE A.STATUS = 1 
            //AND A.CONFORMATION_DATE 
            //BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
            //AND A.PAY_AC = '" + cmbSupplier.SelectedValue.ToString() + @"'
            //GROUP BY D.NAME";

            //try
            //{
            //    Classes.Helper.conn.Open();
            //    classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
            //    classHelper.dr = classHelper.cmd.ExecuteReader();
            //    if (classHelper.dr.HasRows == true)
            //    {
            //        classHelper.mds.Tables["PaymentSalesPersonSummary"].Clear();
            //        while (classHelper.dr.Read())
            //        {
            //            classHelper.dataR = classHelper.mds.Tables["PaymentSalesPersonSummary"].NewRow();
            //            classHelper.dataR["name"] = classHelper.dr["SALES PERSON"].ToString();
            //            classHelper.dataR["amount"] = Convert.ToDecimal(classHelper.dr["TOTAL"].ToString());
            //            classHelper.mds.Tables["PaymentSalesPersonSummary"].Rows.Add(classHelper.dataR);
            //        }
            //    }
            //    else
            //    {
            //        // MessageBox.Show("No Record Found.", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //finally
            //{
            //    Classes.Helper.conn.Close();
            //}

            if (hasRows == 'Y')
            {
                classHelper.rpt = new frmReports();
                classHelper.rpt.GenerateReport("SupplierPendingReport", classHelper.mds);
                classHelper.rpt.ShowDialog();
            }
        }
        private void ConformationSalesPersonReport()
        {
            classHelper.query = @"SELECT A.DATE,A.AMOUNT,B.COA_NAME AS [CUSTOMER],A.BANK,A.BR_CODE,A.INSTRUMENT_NO,C.COA_NAME AS [SUPPLIER],A.REF_AC,
            'APPROVED' AS [STATUS],
            A.CONFORMATION_DATE,A.PERSON 
            FROM PAYMENT_TRANSFER A
            INNER JOIN COA B ON A.REC_AC = B.COA_ID
            INNER JOIN COA C ON A.PAY_AC = C.COA_ID
            INNER JOIN CUSTOMER_PROFILE D ON B.COA_ID = D.COA_ID
            INNER JOIN SALES_PERSONS E ON D.SALE_PER_ID = E.SALES_PER_ID
            WHERE A.STATUS = 1 AND 
            A.CONFORMATION_DATE BETWEEN '" + dtp_FROM.Value.Date + @"' 
            AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"' 
            AND D.SALE_PER_ID = '" + cmbSalePerson.SelectedValue.ToString() + @"'
            ORDER BY [DATE],A.REF_AC";

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

                        classHelper.dataR = classHelper.mds.Tables["PaymentTransferSheet"].NewRow();
                        classHelper.dataR["date"] = Convert.ToDateTime(classHelper.dr["DATE"].ToString());
                        classHelper.dataR["recAccount"] = classHelper.dr["CUSTOMER"].ToString();
                        classHelper.dataR["amount"] = Convert.ToDecimal(classHelper.dr["AMOUNT"].ToString());
                        classHelper.dataR["bank"] = classHelper.dr["BANK"].ToString();
                        classHelper.dataR["brCode"] = classHelper.dr["BR_CODE"].ToString();
                        classHelper.dataR["instrumentNo"] = classHelper.dr["INSTRUMENT_NO"].ToString();
                        classHelper.dataR["paymentAccount"] = classHelper.dr["SUPPLIER"].ToString();
                        classHelper.dataR["refAccount"] = classHelper.dr["REF_AC"].ToString();
                        classHelper.dataR["status"] = classHelper.dr["STATUS"].ToString();
                        classHelper.dataR["conformationDate"] = cDate;
                        classHelper.dataR["salesPerson"] = classHelper.dr["PERSON"].ToString();
                        classHelper.dataR["from"] = dtp_FROM.Value.Date;
                        classHelper.dataR["to"] = dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                        classHelper.mds.Tables["PaymentTransferSheet"].Rows.Add(classHelper.dataR);
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

            //classHelper.query = @"SELECT B.COA_NAME AS [PAY ACCOUNT],SUM(A.AMOUNT) AS TOTAL
            //FROM PAYMENT_TRANSFER A
            //INNER JOIN COA B ON A.PAY_AC = B.COA_ID
            //INNER JOIN CUSTOMER_PROFILE D ON A.REC_AC = D.COA_ID
            //INNER JOIN SALES_PERSONS E ON D.SALE_PER_ID = E.SALES_PER_ID
            //WHERE A.STATUS = 1 
            //AND A.CONFORMATION_DATE 
            //BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
            //AND D.SALE_PER_ID = '" + cmbSalePerson.SelectedValue.ToString() + @"'
            //GROUP BY B.COA_NAME";

            //try
            //{
            //    Classes.Helper.conn.Open();
            //    classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
            //    classHelper.dr = classHelper.cmd.ExecuteReader();
            //    if (classHelper.dr.HasRows == true)
            //    {
            //        classHelper.mds.Tables["PaymentAccountSummary"].Clear();
            //        while (classHelper.dr.Read())
            //        {
            //            classHelper.dataR = classHelper.mds.Tables["PaymentAccountSummary"].NewRow();
            //            classHelper.dataR["name"] = classHelper.dr["PAY ACCOUNT"].ToString();
            //            classHelper.dataR["amount"] = Convert.ToDecimal(classHelper.dr["TOTAL"].ToString());
            //            classHelper.mds.Tables["PaymentAccountSummary"].Rows.Add(classHelper.dataR);
            //        }
            //    }
            //    else
            //    {
            //        // MessageBox.Show("No Record Found.", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //finally
            //{
            //    Classes.Helper.conn.Close();
            //}

            //classHelper.query = @"SELECT D.NAME AS [SALES PERSON],SUM(A.AMOUNT) AS TOTAL
            //FROM PAYMENT_TRANSFER A
            //INNER JOIN COA B ON A.REC_AC = B.COA_ID
            //INNER JOIN CUSTOMER_PROFILE C ON B.COA_ID = C.COA_ID
            //INNER JOIN SALES_PERSONS D ON C.SALE_PER_ID = D.SALES_PER_ID
            //WHERE A.STATUS = 1 
            //AND A.CONFORMATION_DATE 
            //BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
            //AND D.SALES_PER_ID = '" + cmbSalePerson.SelectedValue.ToString() + @"'
            //GROUP BY D.NAME";

            //try
            //{
            //    Classes.Helper.conn.Open();
            //    classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
            //    classHelper.dr = classHelper.cmd.ExecuteReader();
            //    if (classHelper.dr.HasRows == true)
            //    {
            //        classHelper.mds.Tables["PaymentSalesPersonSummary"].Clear();
            //        while (classHelper.dr.Read())
            //        {
            //            classHelper.dataR = classHelper.mds.Tables["PaymentSalesPersonSummary"].NewRow();
            //            classHelper.dataR["name"] = classHelper.dr["SALES PERSON"].ToString();
            //            classHelper.dataR["amount"] = Convert.ToDecimal(classHelper.dr["TOTAL"].ToString());
            //            classHelper.mds.Tables["PaymentSalesPersonSummary"].Rows.Add(classHelper.dataR);
            //        }
            //    }
            //    else
            //    {
            //        // MessageBox.Show("No Record Found.", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //finally
            //{
            //    Classes.Helper.conn.Close();
            //}

            if (hasRows == 'Y')
            {
                classHelper.rpt = new frmReports();
                classHelper.rpt.GenerateReport("ConformationReport", classHelper.mds);
                classHelper.rpt.ShowDialog();
            }
        }
        private void PendingReport()
        {
            classHelper.query = @"SELECT A.DATE,A.AMOUNT,B.COA_NAME AS [CUSTOMER],A.BANK,A.BR_CODE,A.INSTRUMENT_NO,C.COA_NAME AS [SUPPLIER],A.REF_AC,
            'PENDING' AS [STATUS],A.SUB_ACC
            FROM PAYMENT_TRANSFER A
            INNER JOIN COA B ON A.REC_AC = B.COA_ID
            INNER JOIN COA C ON A.PAY_AC = C.COA_ID
            WHERE A.STATUS = 0 AND A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'";

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
                        classHelper.dataR["recAccount"] = classHelper.dr["CUSTOMER"].ToString();
                        classHelper.dataR["amount"] = Convert.ToDecimal(classHelper.dr["AMOUNT"].ToString());
                        classHelper.dataR["bank"] = classHelper.dr["BANK"].ToString();
                        classHelper.dataR["brCode"] = classHelper.dr["BR_CODE"].ToString();
                        classHelper.dataR["instrumentNo"] = classHelper.dr["INSTRUMENT_NO"].ToString();
                        classHelper.dataR["paymentAccount"] = classHelper.dr["SUPPLIER"].ToString();
                        classHelper.dataR["refAccount"] = classHelper.dr["REF_AC"].ToString();
                        classHelper.dataR["status"] = classHelper.dr["STATUS"].ToString();
                        classHelper.dataR["from"] = dtp_FROM.Value.Date;
                        classHelper.dataR["to"] = dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                        if (classHelper.dr["SUB_ACC"].ToString().Equals("--SELECT ACCOUNT--"))
                            classHelper.dataR["subAcc"] = "NA";
                        else
                            classHelper.dataR["subAcc"] = classHelper.dr["SUB_ACC"].ToString();
                        classHelper.mds.Tables["PaymentTransferSheet"].Rows.Add(classHelper.dataR);
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

            classHelper.query = @"SELECT B.COA_NAME AS [PAY ACCOUNT],SUM(A.AMOUNT) AS TOTAL
            FROM PAYMENT_TRANSFER A
            INNER JOIN COA B ON A.PAY_AC = B.COA_ID
            WHERE A.STATUS = 0 
            AND A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
            GROUP BY B.COA_NAME";

            try
            {
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    classHelper.mds.Tables["PaymentAccountSummary"].Clear();
                    while (classHelper.dr.Read())
                    {
                        classHelper.dataR = classHelper.mds.Tables["PaymentAccountSummary"].NewRow();
                        classHelper.dataR["name"] = classHelper.dr["PAY ACCOUNT"].ToString();
                        classHelper.dataR["amount"] = Convert.ToDecimal(classHelper.dr["TOTAL"].ToString());
                        classHelper.mds.Tables["PaymentAccountSummary"].Rows.Add(classHelper.dataR);
                    }
                }
                else
                {
                    // MessageBox.Show("No Record Found.", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            classHelper.query = @"SELECT D.NAME AS [SALES PERSON],SUM(A.AMOUNT) AS TOTAL
            FROM PAYMENT_TRANSFER A
            INNER JOIN COA B ON A.REC_AC = B.COA_ID
            INNER JOIN CUSTOMER_PROFILE C ON B.COA_ID = C.COA_ID
            INNER JOIN SALES_PERSONS D ON C.SALE_PER_ID = D.SALES_PER_ID
            WHERE A.STATUS = 0 
            AND A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
            GROUP BY D.NAME";

            try
            {
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    classHelper.mds.Tables["PaymentSalesPersonSummary"].Clear();
                    while (classHelper.dr.Read())
                    {
                        classHelper.dataR = classHelper.mds.Tables["PaymentSalesPersonSummary"].NewRow();
                        classHelper.dataR["name"] = classHelper.dr["SALES PERSON"].ToString();
                        classHelper.dataR["amount"] = Convert.ToDecimal(classHelper.dr["TOTAL"].ToString());
                        classHelper.mds.Tables["PaymentSalesPersonSummary"].Rows.Add(classHelper.dataR);
                    }
                }
                else
                {
                    // MessageBox.Show("No Record Found.", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                classHelper.rpt.GenerateReport("PendingReport", classHelper.mds);
                classHelper.rpt.ShowDialog();
            }
        }
        private void PendingCustomerReport()
        {
            classHelper.query = @"SELECT A.DATE,A.AMOUNT,B.COA_NAME AS [CUSTOMER],A.BANK,A.BR_CODE,A.INSTRUMENT_NO,C.COA_NAME AS [SUPPLIER],A.REF_AC,
            'PENDING' AS [STATUS]
            FROM PAYMENT_TRANSFER A
            INNER JOIN COA B ON A.REC_AC = B.COA_ID
            INNER JOIN COA C ON A.PAY_AC = C.COA_ID
            WHERE A.STATUS = 0 AND A.DATE 
            BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
            AND A.REC_AC = '"+cmbCustomer.SelectedValue.ToString()+@"'
            ORDER BY [DATE]";

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
                        classHelper.dataR["recAccount"] = classHelper.dr["CUSTOMER"].ToString();
                        classHelper.dataR["amount"] = Convert.ToDecimal(classHelper.dr["AMOUNT"].ToString());
                        classHelper.dataR["bank"] = classHelper.dr["BANK"].ToString();
                        classHelper.dataR["brCode"] = classHelper.dr["BR_CODE"].ToString();
                        classHelper.dataR["instrumentNo"] = classHelper.dr["INSTRUMENT_NO"].ToString();
                        classHelper.dataR["paymentAccount"] = classHelper.dr["SUPPLIER"].ToString();
                        classHelper.dataR["refAccount"] = classHelper.dr["REF_AC"].ToString();
                        classHelper.dataR["status"] = classHelper.dr["STATUS"].ToString();
                        classHelper.dataR["from"] = dtp_FROM.Value.Date;
                        classHelper.dataR["to"] = dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                        classHelper.mds.Tables["PaymentTransferSheet"].Rows.Add(classHelper.dataR);
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

            //classHelper.query = @"SELECT B.COA_NAME AS [PAY ACCOUNT],SUM(A.AMOUNT) AS TOTAL
            //FROM PAYMENT_TRANSFER A
            //INNER JOIN COA B ON A.PAY_AC = B.COA_ID
            //WHERE A.STATUS = 0 
            //AND A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
            //AND A.REC_AC = '" + cmbCustomer.SelectedValue.ToString() + @"'
            //GROUP BY B.COA_NAME";

            //try
            //{
            //    Classes.Helper.conn.Open();
            //    classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
            //    classHelper.dr = classHelper.cmd.ExecuteReader();
            //    if (classHelper.dr.HasRows == true)
            //    {
            //        classHelper.mds.Tables["PaymentAccountSummary"].Clear();
            //        while (classHelper.dr.Read())
            //        {
            //            classHelper.dataR = classHelper.mds.Tables["PaymentAccountSummary"].NewRow();
            //            classHelper.dataR["name"] = classHelper.dr["PAY ACCOUNT"].ToString();
            //            classHelper.dataR["amount"] = Convert.ToDecimal(classHelper.dr["TOTAL"].ToString());
            //            classHelper.mds.Tables["PaymentAccountSummary"].Rows.Add(classHelper.dataR);
            //        }
            //    }
            //    else
            //    {
            //        // MessageBox.Show("No Record Found.", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //finally
            //{
            //    Classes.Helper.conn.Close();
            //}

            //classHelper.query = @"SELECT D.NAME AS [SALES PERSON],SUM(A.AMOUNT) AS TOTAL
            //FROM PAYMENT_TRANSFER A
            //INNER JOIN COA B ON A.REC_AC = B.COA_ID
            //INNER JOIN CUSTOMER_PROFILE C ON B.COA_ID = C.COA_ID
            //INNER JOIN SALES_PERSONS D ON C.SALE_PER_ID = D.SALES_PER_ID
            //WHERE A.STATUS = 0 
            //AND A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
            //AND A.REC_AC = '" + cmbCustomer.SelectedValue.ToString() + @"'
            //GROUP BY D.NAME";

            //try
            //{
            //    Classes.Helper.conn.Open();
            //    classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
            //    classHelper.dr = classHelper.cmd.ExecuteReader();
            //    if (classHelper.dr.HasRows == true)
            //    {
            //        classHelper.mds.Tables["PaymentSalesPersonSummary"].Clear();
            //        while (classHelper.dr.Read())
            //        {
            //            classHelper.dataR = classHelper.mds.Tables["PaymentSalesPersonSummary"].NewRow();
            //            classHelper.dataR["name"] = classHelper.dr["SALES PERSON"].ToString();
            //            classHelper.dataR["amount"] = Convert.ToDecimal(classHelper.dr["TOTAL"].ToString());
            //            classHelper.mds.Tables["PaymentSalesPersonSummary"].Rows.Add(classHelper.dataR);
            //        }
            //    }
            //    else
            //    {
            //        // MessageBox.Show("No Record Found.", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //finally
            //{
            //    Classes.Helper.conn.Close();
            //}

            if (hasRows == 'Y')
            {
                classHelper.rpt = new frmReports();
                classHelper.rpt.GenerateReport("CustomerPendingReport", classHelper.mds);
                classHelper.rpt.ShowDialog();
            }
        }
        private void PendingSupplierReport()
        {
            classHelper.query = @"SELECT A.DATE,A.AMOUNT,B.COA_NAME AS [CUSTOMER],A.BANK,A.BR_CODE,A.INSTRUMENT_NO,C.COA_NAME AS [SUPPLIER],A.REF_AC,
            'PENDING' AS [STATUS]
            FROM PAYMENT_TRANSFER A
            INNER JOIN COA B ON A.REC_AC = B.COA_ID
            INNER JOIN COA C ON A.PAY_AC = C.COA_ID
            WHERE A.STATUS = 0 AND A.DATE 
            BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
            AND A.PAY_AC = '" + cmbSupplier.SelectedValue.ToString() + @"'
            ORDER BY [DATE]";

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
                        classHelper.dataR["recAccount"] = classHelper.dr["CUSTOMER"].ToString();
                        classHelper.dataR["amount"] = Convert.ToDecimal(classHelper.dr["AMOUNT"].ToString());
                        classHelper.dataR["bank"] = classHelper.dr["BANK"].ToString();
                        classHelper.dataR["brCode"] = classHelper.dr["BR_CODE"].ToString();
                        classHelper.dataR["instrumentNo"] = classHelper.dr["INSTRUMENT_NO"].ToString();
                        classHelper.dataR["paymentAccount"] = classHelper.dr["SUPPLIER"].ToString();
                        classHelper.dataR["refAccount"] = classHelper.dr["REF_AC"].ToString();
                        classHelper.dataR["status"] = classHelper.dr["STATUS"].ToString();
                        classHelper.dataR["from"] = dtp_FROM.Value.Date;
                        classHelper.dataR["to"] = dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                        classHelper.mds.Tables["PaymentTransferSheet"].Rows.Add(classHelper.dataR);
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

            //classHelper.query = @"SELECT B.COA_NAME AS [PAY ACCOUNT],SUM(A.AMOUNT) AS TOTAL
            //FROM PAYMENT_TRANSFER A
            //INNER JOIN COA B ON A.PAY_AC = B.COA_ID
            //WHERE A.STATUS = 0 
            //AND A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
            //AND A.PAY_AC = '" + cmbSupplier.SelectedValue.ToString() + @"'
            //GROUP BY B.COA_NAME";

            //try
            //{
            //    Classes.Helper.conn.Open();
            //    classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
            //    classHelper.dr = classHelper.cmd.ExecuteReader();
            //    if (classHelper.dr.HasRows == true)
            //    {
            //        classHelper.mds.Tables["PaymentAccountSummary"].Clear();
            //        while (classHelper.dr.Read())
            //        {
            //            classHelper.dataR = classHelper.mds.Tables["PaymentAccountSummary"].NewRow();
            //            classHelper.dataR["name"] = classHelper.dr["PAY ACCOUNT"].ToString();
            //            classHelper.dataR["amount"] = Convert.ToDecimal(classHelper.dr["TOTAL"].ToString());
            //            classHelper.mds.Tables["PaymentAccountSummary"].Rows.Add(classHelper.dataR);
            //        }
            //    }
            //    else
            //    {
            //        // MessageBox.Show("No Record Found.", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //finally
            //{
            //    Classes.Helper.conn.Close();
            //}

            //classHelper.query = @"SELECT D.NAME AS [SALES PERSON],SUM(A.AMOUNT) AS TOTAL
            //FROM PAYMENT_TRANSFER A
            //INNER JOIN COA B ON A.REC_AC = B.COA_ID
            //INNER JOIN CUSTOMER_PROFILE C ON B.COA_ID = C.COA_ID
            //INNER JOIN SALES_PERSONS D ON C.SALE_PER_ID = D.SALES_PER_ID
            //WHERE A.STATUS = 0 
            //AND A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
            //AND A.PAY_AC = '" + cmbSupplier.SelectedValue.ToString() + @"'
            //GROUP BY D.NAME";

            //try
            //{
            //    Classes.Helper.conn.Open();
            //    classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
            //    classHelper.dr = classHelper.cmd.ExecuteReader();
            //    if (classHelper.dr.HasRows == true)
            //    {
            //        classHelper.mds.Tables["PaymentSalesPersonSummary"].Clear();
            //        while (classHelper.dr.Read())
            //        {
            //            classHelper.dataR = classHelper.mds.Tables["PaymentSalesPersonSummary"].NewRow();
            //            classHelper.dataR["name"] = classHelper.dr["SALES PERSON"].ToString();
            //            classHelper.dataR["amount"] = Convert.ToDecimal(classHelper.dr["TOTAL"].ToString());
            //            classHelper.mds.Tables["PaymentSalesPersonSummary"].Rows.Add(classHelper.dataR);
            //        }
            //    }
            //    else
            //    {
            //        // MessageBox.Show("No Record Found.", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //finally
            //{
            //    Classes.Helper.conn.Close();
            //}

            if (hasRows == 'Y')
            {
                classHelper.rpt = new frmReports();
                classHelper.rpt.GenerateReport("SupplierPendingReport", classHelper.mds);
                classHelper.rpt.ShowDialog();
            }
        }
        private void PendingSalesPersonReport()
        {
            classHelper.query = @"SELECT A.DATE,A.AMOUNT,B.COA_NAME AS [CUSTOMER],A.BANK,A.BR_CODE,A.INSTRUMENT_NO,C.COA_NAME AS [SUPPLIER],A.REF_AC,
            'PENDING' AS [STATUS]
            FROM PAYMENT_TRANSFER A
            INNER JOIN COA B ON A.REC_AC = B.COA_ID
            INNER JOIN COA C ON A.PAY_AC = C.COA_ID
            INNER JOIN CUSTOMER_PROFILE D ON B.COA_ID = D.COA_ID
            INNER JOIN SALES_PERSONS E ON D.SALE_PER_ID = E.SALES_PER_ID
            WHERE A.STATUS = 0 AND A.DATE 
            BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
            AND D.SALE_PER_ID = '" + cmbSalePerson.SelectedValue.ToString() + @"'
            ORDER BY [DATE]";

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
                        classHelper.dataR["recAccount"] = classHelper.dr["CUSTOMER"].ToString();
                        classHelper.dataR["amount"] = Convert.ToDecimal(classHelper.dr["AMOUNT"].ToString());
                        classHelper.dataR["bank"] = classHelper.dr["BANK"].ToString();
                        classHelper.dataR["brCode"] = classHelper.dr["BR_CODE"].ToString();
                        classHelper.dataR["instrumentNo"] = classHelper.dr["INSTRUMENT_NO"].ToString();
                        classHelper.dataR["paymentAccount"] = classHelper.dr["SUPPLIER"].ToString();
                        classHelper.dataR["refAccount"] = classHelper.dr["REF_AC"].ToString();
                        classHelper.dataR["status"] = classHelper.dr["STATUS"].ToString();
                        classHelper.dataR["from"] = dtp_FROM.Value.Date;
                        classHelper.dataR["to"] = dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                        classHelper.mds.Tables["PaymentTransferSheet"].Rows.Add(classHelper.dataR);
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

            //classHelper.query = @"SELECT B.COA_NAME AS [PAY ACCOUNT],SUM(A.AMOUNT) AS TOTAL
            //FROM PAYMENT_TRANSFER A
            //INNER JOIN COA B ON A.PAY_AC = B.COA_ID
            //INNER JOIN CUSTOMER_PROFILE D ON A.REC_AC = D.COA_ID
            //INNER JOIN SALES_PERSONS E ON D.SALE_PER_ID = E.SALES_PER_ID
            //WHERE A.STATUS = 0 
            //AND A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
            //AND D.SALE_PER_ID = '" + cmbSalePerson.SelectedValue.ToString() + @"'
            //GROUP BY B.COA_NAME";

            //try
            //{
            //    Classes.Helper.conn.Open();
            //    classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
            //    classHelper.dr = classHelper.cmd.ExecuteReader();
            //    if (classHelper.dr.HasRows == true)
            //    {
            //        classHelper.mds.Tables["PaymentAccountSummary"].Clear();
            //        while (classHelper.dr.Read())
            //        {
            //            classHelper.dataR = classHelper.mds.Tables["PaymentAccountSummary"].NewRow();
            //            classHelper.dataR["name"] = classHelper.dr["PAY ACCOUNT"].ToString();
            //            classHelper.dataR["amount"] = Convert.ToDecimal(classHelper.dr["TOTAL"].ToString());
            //            classHelper.mds.Tables["PaymentAccountSummary"].Rows.Add(classHelper.dataR);
            //        }
            //    }
            //    else
            //    {
            //        // MessageBox.Show("No Record Found.", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //finally
            //{
            //    Classes.Helper.conn.Close();
            //}

            //classHelper.query = @"SELECT D.NAME AS [SALES PERSON],SUM(A.AMOUNT) AS TOTAL
            //FROM PAYMENT_TRANSFER A
            //INNER JOIN COA B ON A.REC_AC = B.COA_ID
            //INNER JOIN CUSTOMER_PROFILE C ON B.COA_ID = C.COA_ID
            //INNER JOIN SALES_PERSONS D ON C.SALE_PER_ID = D.SALES_PER_ID
            //WHERE A.STATUS = 0 
            //AND A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
            //AND D.SALES_PER_ID = '" + cmbSalePerson.SelectedValue.ToString() + @"'
            //GROUP BY D.NAME";

            //try
            //{
            //    Classes.Helper.conn.Open();
            //    classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
            //    classHelper.dr = classHelper.cmd.ExecuteReader();
            //    if (classHelper.dr.HasRows == true)
            //    {
            //        classHelper.mds.Tables["PaymentSalesPersonSummary"].Clear();
            //        while (classHelper.dr.Read())
            //        {
            //            classHelper.dataR = classHelper.mds.Tables["PaymentSalesPersonSummary"].NewRow();
            //            classHelper.dataR["name"] = classHelper.dr["SALES PERSON"].ToString();
            //            classHelper.dataR["amount"] = Convert.ToDecimal(classHelper.dr["TOTAL"].ToString());
            //            classHelper.mds.Tables["PaymentSalesPersonSummary"].Rows.Add(classHelper.dataR);
            //        }
            //    }
            //    else
            //    {
            //        // MessageBox.Show("No Record Found.", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //finally
            //{
            //    Classes.Helper.conn.Close();
            //}

            if (hasRows == 'Y')
            {
                classHelper.rpt = new frmReports();
                classHelper.rpt.GenerateReport("SpPendingReport", classHelper.mds);
                classHelper.rpt.ShowDialog();
            }
        }
        private void DailyReport()
        {
            classHelper.query = @"SELECT A.DATE,A.AMOUNT,B.COA_NAME AS [CUSTOMER],A.BANK,A.BR_CODE,A.INSTRUMENT_NO,C.COA_NAME AS [SUPPLIER],A.REF_AC
            ,A.SUB_ACC FROM PAYMENT_TRANSFER A
            INNER JOIN COA B ON A.REC_AC = B.COA_ID
            INNER JOIN COA C ON A.PAY_AC = C.COA_ID
            WHERE A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'";

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
                        classHelper.dataR["recAccount"] = classHelper.dr["CUSTOMER"].ToString();
                        classHelper.dataR["amount"] = Convert.ToDecimal(classHelper.dr["AMOUNT"].ToString());
                        classHelper.dataR["bank"] = classHelper.dr["BANK"].ToString();
                        classHelper.dataR["brCode"] = classHelper.dr["BR_CODE"].ToString();
                        classHelper.dataR["instrumentNo"] = classHelper.dr["INSTRUMENT_NO"].ToString();
                        classHelper.dataR["paymentAccount"] = classHelper.dr["SUPPLIER"].ToString();
                        classHelper.dataR["refAccount"] = classHelper.dr["REF_AC"].ToString();
                        classHelper.dataR["from"] = dtp_FROM.Value.Date;
                        if (classHelper.dr["SUB_ACC"].ToString().Equals("--SELECT ACCOUNT--"))
                            classHelper.dataR["subAcc"] = "NA";
                        else
                            classHelper.dataR["subAcc"] = classHelper.dr["SUB_ACC"].ToString();
                        classHelper.dataR["to"] = dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                        classHelper.mds.Tables["PaymentTransferSheet"].Rows.Add(classHelper.dataR);
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

            classHelper.query = @"SELECT B.COA_NAME AS [PAY ACCOUNT],SUM(A.AMOUNT) AS TOTAL
            FROM PAYMENT_TRANSFER A
            INNER JOIN COA B ON A.PAY_AC = B.COA_ID
            WHERE A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
            GROUP BY B.COA_NAME";

            try
            {
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    classHelper.mds.Tables["PaymentAccountSummary"].Clear();
                    while (classHelper.dr.Read())
                    {
                        classHelper.dataR = classHelper.mds.Tables["PaymentAccountSummary"].NewRow();
                        classHelper.dataR["name"] = classHelper.dr["PAY ACCOUNT"].ToString();
                        classHelper.dataR["amount"] = Convert.ToDecimal(classHelper.dr["TOTAL"].ToString());
                        classHelper.mds.Tables["PaymentAccountSummary"].Rows.Add(classHelper.dataR);
                    }
                }
                else
                {
                    // MessageBox.Show("No Record Found.", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            classHelper.query = @"SELECT D.NAME AS [SALES PERSON],SUM(A.AMOUNT) AS TOTAL
            FROM PAYMENT_TRANSFER A
            INNER JOIN COA B ON A.REC_AC = B.COA_ID
            INNER JOIN CUSTOMER_PROFILE C ON B.COA_ID = C.COA_ID
            INNER JOIN SALES_PERSONS D ON C.SALE_PER_ID = D.SALES_PER_ID
            WHERE A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
            GROUP BY D.NAME";

            try
            {
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    classHelper.mds.Tables["PaymentSalesPersonSummary"].Clear();
                    while (classHelper.dr.Read())
                    {
                        classHelper.dataR = classHelper.mds.Tables["PaymentSalesPersonSummary"].NewRow();
                        classHelper.dataR["name"] = classHelper.dr["SALES PERSON"].ToString();
                        classHelper.dataR["amount"] = Convert.ToDecimal(classHelper.dr["TOTAL"].ToString());
                        classHelper.mds.Tables["PaymentSalesPersonSummary"].Rows.Add(classHelper.dataR);
                    }
                }
                else
                {
                    // MessageBox.Show("No Record Found.", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                classHelper.rpt.GenerateReport("DailyReport", classHelper.mds);
                classHelper.rpt.ShowDialog();
            }
        }
        private void DailyCustomerReport()
        {
            classHelper.query = @"SELECT A.DATE,A.AMOUNT,B.COA_NAME AS [CUSTOMER],A.BANK,A.BR_CODE,A.INSTRUMENT_NO,C.COA_NAME AS [SUPPLIER],A.REF_AC,
            CASE WHEN A.STATUS = '0' THEN 'PENDING' ELSE 'APPROVED' END AS [STATUS],A.CONFORMATION_DATE
            FROM PAYMENT_TRANSFER A
            INNER JOIN COA B ON A.REC_AC = B.COA_ID
            INNER JOIN COA C ON A.PAY_AC = C.COA_ID
            WHERE A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
            AND A.REC_AC = '"+cmbCustomer.SelectedValue.ToString()+ @"'
            ORDER BY [DATE] ";

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
                                cDate = "-";
                            }
                            else
                            {
                                cDate = string.Format("{0:dd-MM-yyyy}", conformationDate);
                            }
                        }


                        classHelper.dataR = classHelper.mds.Tables["PaymentTransferSheet"].NewRow();
                        classHelper.dataR["date"] = Convert.ToDateTime(classHelper.dr["DATE"].ToString());
                        classHelper.dataR["recAccount"] = classHelper.dr["CUSTOMER"].ToString();
                        classHelper.dataR["amount"] = Convert.ToDecimal(classHelper.dr["AMOUNT"].ToString());
                        classHelper.dataR["bank"] = classHelper.dr["BANK"].ToString();
                        classHelper.dataR["brCode"] = classHelper.dr["BR_CODE"].ToString();
                        classHelper.dataR["instrumentNo"] = classHelper.dr["INSTRUMENT_NO"].ToString();
                        classHelper.dataR["paymentAccount"] = classHelper.dr["SUPPLIER"].ToString();
                        classHelper.dataR["refAccount"] = classHelper.dr["REF_AC"].ToString();
                        classHelper.dataR["status"] = classHelper.dr["STATUS"].ToString();
                        classHelper.dataR["conformationDate"] = cDate;
                        classHelper.dataR["from"] = dtp_FROM.Value.Date;
                        classHelper.dataR["to"] = dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                        classHelper.mds.Tables["PaymentTransferSheet"].Rows.Add(classHelper.dataR);
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

            //classHelper.query = @"SELECT B.COA_NAME AS [PAY ACCOUNT],SUM(A.AMOUNT) AS TOTAL
            //FROM PAYMENT_TRANSFER A
            //INNER JOIN COA B ON A.PAY_AC = B.COA_ID
            //WHERE A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
            //AND A.REC_AC = '" + cmbCustomer.SelectedValue.ToString() + @"'
            //GROUP BY B.COA_NAME";

            //try
            //{
            //    Classes.Helper.conn.Open();
            //    classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
            //    classHelper.dr = classHelper.cmd.ExecuteReader();
            //    if (classHelper.dr.HasRows == true)
            //    {
            //        classHelper.mds.Tables["PaymentAccountSummary"].Clear();
            //        while (classHelper.dr.Read())
            //        {
            //            classHelper.dataR = classHelper.mds.Tables["PaymentAccountSummary"].NewRow();
            //            classHelper.dataR["name"] = classHelper.dr["PAY ACCOUNT"].ToString();
            //            classHelper.dataR["amount"] = Convert.ToDecimal(classHelper.dr["TOTAL"].ToString());
            //            classHelper.mds.Tables["PaymentAccountSummary"].Rows.Add(classHelper.dataR);
            //        }
            //    }
            //    else
            //    {
            //        // MessageBox.Show("No Record Found.", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //finally
            //{
            //    Classes.Helper.conn.Close();
            //}

            //classHelper.query = @"SELECT D.NAME AS [SALES PERSON],SUM(A.AMOUNT) AS TOTAL
            //FROM PAYMENT_TRANSFER A
            //INNER JOIN COA B ON A.REC_AC = B.COA_ID
            //INNER JOIN CUSTOMER_PROFILE C ON B.COA_ID = C.COA_ID
            //INNER JOIN SALES_PERSONS D ON C.SALE_PER_ID = D.SALES_PER_ID
            //WHERE A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
            //AND A.REC_AC = '" + cmbCustomer.SelectedValue.ToString() + @"'
            //GROUP BY D.NAME";

            //try
            //{
            //    Classes.Helper.conn.Open();
            //    classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
            //    classHelper.dr = classHelper.cmd.ExecuteReader();
            //    if (classHelper.dr.HasRows == true)
            //    {
            //        classHelper.mds.Tables["PaymentSalesPersonSummary"].Clear();
            //        while (classHelper.dr.Read())
            //        {
            //            classHelper.dataR = classHelper.mds.Tables["PaymentSalesPersonSummary"].NewRow();
            //            classHelper.dataR["name"] = classHelper.dr["SALES PERSON"].ToString();
            //            classHelper.dataR["amount"] = Convert.ToDecimal(classHelper.dr["TOTAL"].ToString());
            //            classHelper.mds.Tables["PaymentSalesPersonSummary"].Rows.Add(classHelper.dataR);
            //        }
            //    }
            //    else
            //    {
            //        // MessageBox.Show("No Record Found.", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //finally
            //{
            //    Classes.Helper.conn.Close();
            //}

            if (hasRows == 'Y')
            {
                classHelper.rpt = new frmReports();
                classHelper.rpt.GenerateReport("CustomerPendingReport", classHelper.mds);
                classHelper.rpt.ShowDialog();
            }
        }
        private void DailySupplierReport()
        {
            classHelper.query = @"SELECT A.DATE,A.AMOUNT,B.COA_NAME AS [CUSTOMER],A.BANK,A.BR_CODE,A.INSTRUMENT_NO,C.COA_NAME AS [SUPPLIER],A.REF_AC,
            CASE WHEN A.STATUS = '0' THEN 'PENDING' ELSE 'APPROVED' END AS [STATUS]
            FROM PAYMENT_TRANSFER A
            INNER JOIN COA B ON A.REC_AC = B.COA_ID
            INNER JOIN COA C ON A.PAY_AC = C.COA_ID
            WHERE A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
            AND A.PAY_AC = '" + cmbSupplier.SelectedValue.ToString() + @"'
            ORDER BY [DATE]";

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
                        classHelper.dataR["recAccount"] = classHelper.dr["CUSTOMER"].ToString();
                        classHelper.dataR["amount"] = Convert.ToDecimal(classHelper.dr["AMOUNT"].ToString());
                        classHelper.dataR["bank"] = classHelper.dr["BANK"].ToString();
                        classHelper.dataR["brCode"] = classHelper.dr["BR_CODE"].ToString();
                        classHelper.dataR["instrumentNo"] = classHelper.dr["INSTRUMENT_NO"].ToString();
                        classHelper.dataR["paymentAccount"] = classHelper.dr["SUPPLIER"].ToString();
                        classHelper.dataR["refAccount"] = classHelper.dr["REF_AC"].ToString();
                        classHelper.dataR["status"] = classHelper.dr["STATUS"].ToString();
                        classHelper.dataR["from"] = dtp_FROM.Value.Date;
                        classHelper.dataR["to"] = dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                        classHelper.mds.Tables["PaymentTransferSheet"].Rows.Add(classHelper.dataR);
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

            //classHelper.query = @"SELECT B.COA_NAME AS [PAY ACCOUNT],SUM(A.AMOUNT) AS TOTAL
            //FROM PAYMENT_TRANSFER A
            //INNER JOIN COA B ON A.PAY_AC = B.COA_ID
            //WHERE A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
            //AND A.PAY_AC = '" + cmbSupplier.SelectedValue.ToString() + @"'
            //GROUP BY B.COA_NAME";

            //try
            //{
            //    Classes.Helper.conn.Open();
            //    classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
            //    classHelper.dr = classHelper.cmd.ExecuteReader();
            //    if (classHelper.dr.HasRows == true)
            //    {
            //        classHelper.mds.Tables["PaymentAccountSummary"].Clear();
            //        while (classHelper.dr.Read())
            //        {
            //            classHelper.dataR = classHelper.mds.Tables["PaymentAccountSummary"].NewRow();
            //            classHelper.dataR["name"] = classHelper.dr["PAY ACCOUNT"].ToString();
            //            classHelper.dataR["amount"] = Convert.ToDecimal(classHelper.dr["TOTAL"].ToString());
            //            classHelper.mds.Tables["PaymentAccountSummary"].Rows.Add(classHelper.dataR);
            //        }
            //    }
            //    else
            //    {
            //        // MessageBox.Show("No Record Found.", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //finally
            //{
            //    Classes.Helper.conn.Close();
            //}

            //classHelper.query = @"SELECT D.NAME AS [SALES PERSON],SUM(A.AMOUNT) AS TOTAL
            //FROM PAYMENT_TRANSFER A
            //INNER JOIN COA B ON A.REC_AC = B.COA_ID
            //INNER JOIN CUSTOMER_PROFILE C ON B.COA_ID = C.COA_ID
            //INNER JOIN SALES_PERSONS D ON C.SALE_PER_ID = D.SALES_PER_ID
            //WHERE A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
            //AND A.PAY_AC = '" + cmbSupplier.SelectedValue.ToString() + @"'
            //GROUP BY D.NAME";

            //try
            //{
            //    Classes.Helper.conn.Open();
            //    classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
            //    classHelper.dr = classHelper.cmd.ExecuteReader();
            //    if (classHelper.dr.HasRows == true)
            //    {
            //        classHelper.mds.Tables["PaymentSalesPersonSummary"].Clear();
            //        while (classHelper.dr.Read())
            //        {
            //            classHelper.dataR = classHelper.mds.Tables["PaymentSalesPersonSummary"].NewRow();
            //            classHelper.dataR["name"] = classHelper.dr["SALES PERSON"].ToString();
            //            classHelper.dataR["amount"] = Convert.ToDecimal(classHelper.dr["TOTAL"].ToString());
            //            classHelper.mds.Tables["PaymentSalesPersonSummary"].Rows.Add(classHelper.dataR);
            //        }
            //    }
            //    else
            //    {
            //        // MessageBox.Show("No Record Found.", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //finally
            //{
            //    Classes.Helper.conn.Close();
            //}

            if (hasRows == 'Y')
            {
                classHelper.rpt = new frmReports();
                classHelper.rpt.GenerateReport("SupplierPendingReport", classHelper.mds);
                classHelper.rpt.ShowDialog();
            }
        }
        private void DailySalesPersonReport()
        {
            classHelper.query = @"SELECT A.DATE,A.AMOUNT,B.COA_NAME AS [CUSTOMER],A.BANK,A.BR_CODE,A.INSTRUMENT_NO,C.COA_NAME AS [SUPPLIER],A.REF_AC
            FROM PAYMENT_TRANSFER A
            INNER JOIN COA B ON A.REC_AC = B.COA_ID
            INNER JOIN COA C ON A.PAY_AC = C.COA_ID
            INNER JOIN CUSTOMER_PROFILE D ON B.COA_ID = D.COA_ID
            INNER JOIN SALES_PERSONS E ON D.SALE_PER_ID = E.SALES_PER_ID
            WHERE A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
            AND D.SALE_PER_ID = '" + cmbSalePerson.SelectedValue.ToString() + @"'
            ORDER BY [DATE]";

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
                        classHelper.dataR["recAccount"] = classHelper.dr["CUSTOMER"].ToString();
                        classHelper.dataR["amount"] = Convert.ToDecimal(classHelper.dr["AMOUNT"].ToString());
                        classHelper.dataR["bank"] = classHelper.dr["BANK"].ToString();
                        classHelper.dataR["brCode"] = classHelper.dr["BR_CODE"].ToString();
                        classHelper.dataR["instrumentNo"] = classHelper.dr["INSTRUMENT_NO"].ToString();
                        classHelper.dataR["paymentAccount"] = classHelper.dr["SUPPLIER"].ToString();
                        classHelper.dataR["refAccount"] = classHelper.dr["REF_AC"].ToString();
                        classHelper.dataR["from"] = dtp_FROM.Value.Date;
                        classHelper.dataR["to"] = dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                        classHelper.mds.Tables["PaymentTransferSheet"].Rows.Add(classHelper.dataR);
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

            //classHelper.query = @"SELECT B.COA_NAME AS [PAY ACCOUNT],SUM(A.AMOUNT) AS TOTAL
            //FROM PAYMENT_TRANSFER A
            //INNER JOIN COA B ON A.PAY_AC = B.COA_ID
            //INNER JOIN CUSTOMER_PROFILE D ON A.REC_AC = D.COA_ID
            //INNER JOIN SALES_PERSONS E ON D.SALE_PER_ID = E.SALES_PER_ID
            //WHERE A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
            //AND D.SALE_PER_ID = '" + cmbSalePerson.SelectedValue.ToString() + @"'
            //GROUP BY B.COA_NAME";

            //try
            //{
            //    Classes.Helper.conn.Open();
            //    classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
            //    classHelper.dr = classHelper.cmd.ExecuteReader();
            //    if (classHelper.dr.HasRows == true)
            //    {
            //        classHelper.mds.Tables["PaymentAccountSummary"].Clear();
            //        while (classHelper.dr.Read())
            //        {
            //            classHelper.dataR = classHelper.mds.Tables["PaymentAccountSummary"].NewRow();
            //            classHelper.dataR["name"] = classHelper.dr["PAY ACCOUNT"].ToString();
            //            classHelper.dataR["amount"] = Convert.ToDecimal(classHelper.dr["TOTAL"].ToString());
            //            classHelper.mds.Tables["PaymentAccountSummary"].Rows.Add(classHelper.dataR);
            //        }
            //    }
            //    else
            //    {
            //        // MessageBox.Show("No Record Found.", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //finally
            //{
            //    Classes.Helper.conn.Close();
            //}

            //classHelper.query = @"SELECT D.NAME AS [SALES PERSON],SUM(A.AMOUNT) AS TOTAL
            //FROM PAYMENT_TRANSFER A
            //INNER JOIN COA B ON A.REC_AC = B.COA_ID
            //INNER JOIN CUSTOMER_PROFILE C ON B.COA_ID = C.COA_ID
            //INNER JOIN SALES_PERSONS D ON C.SALE_PER_ID = D.SALES_PER_ID
            //WHERE A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
            //AND D.SALES_PER_ID = '" + cmbSalePerson.SelectedValue.ToString() + @"'
            //GROUP BY D.NAME";

            //try
            //{
            //    Classes.Helper.conn.Open();
            //    classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
            //    classHelper.dr = classHelper.cmd.ExecuteReader();
            //    if (classHelper.dr.HasRows == true)
            //    {
            //        classHelper.mds.Tables["PaymentSalesPersonSummary"].Clear();
            //        while (classHelper.dr.Read())
            //        {
            //            classHelper.dataR = classHelper.mds.Tables["PaymentSalesPersonSummary"].NewRow();
            //            classHelper.dataR["name"] = classHelper.dr["SALES PERSON"].ToString();
            //            classHelper.dataR["amount"] = Convert.ToDecimal(classHelper.dr["TOTAL"].ToString());
            //            classHelper.mds.Tables["PaymentSalesPersonSummary"].Rows.Add(classHelper.dataR);
            //        }
            //    }
            //    else
            //    {
            //        // MessageBox.Show("No Record Found.", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //finally
            //{
            //    Classes.Helper.conn.Close();
            //}

            if (hasRows == 'Y')
            {
                classHelper.rpt = new frmReports();
                classHelper.rpt.GenerateReport("DailyReport", classHelper.mds);
                classHelper.rpt.ShowDialog();
            }
        }
        private void SupplierReport()
        {
            if (cmbSupplier.SelectedValue.ToString().Equals("0"))
            {
                classHelper.query = @"SELECT A.DATE,A.AMOUNT,A.BANK,A.BR_CODE,A.INSTRUMENT_NO,A.REF_AC,B.COA_NAME AS [SUPPLIER]
                FROM PAYMENT_TRANSFER A
                INNER JOIN COA B ON A.PAY_AC = B.COA_ID
                WHERE A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'";
            }
            else {
                classHelper.query = @"SELECT A.DATE,A.AMOUNT,A.BANK,A.BR_CODE,A.INSTRUMENT_NO,A.REF_AC,B.COA_NAME AS [SUPPLIER]
                FROM PAYMENT_TRANSFER A
                INNER JOIN COA B ON A.PAY_AC = B.COA_ID
                WHERE A.PAY_AC = '" + cmbSupplier.SelectedValue.ToString()+"' AND A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'";
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
                        classHelper.dataR["amount"] = Convert.ToDecimal(classHelper.dr["AMOUNT"].ToString());
                        classHelper.dataR["bank"] = classHelper.dr["BANK"].ToString();
                        classHelper.dataR["brCode"] = classHelper.dr["BR_CODE"].ToString();
                        classHelper.dataR["instrumentNo"] = classHelper.dr["INSTRUMENT_NO"].ToString();
                        classHelper.dataR["paymentAccount"] = classHelper.dr["SUPPLIER"].ToString();
                        classHelper.dataR["refAccount"] = classHelper.dr["REF_AC"].ToString();
                        classHelper.dataR["from"] = dtp_FROM.Value.Date;
                        classHelper.dataR["to"] = dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                        classHelper.mds.Tables["PaymentTransferSheet"].Rows.Add(classHelper.dataR);
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
                classHelper.rpt.GenerateReport("SupplierReport", classHelper.mds);
                classHelper.rpt.ShowDialog();
            }
        }
        private void SalesPersonReport()
        {
            if (cmbSalePerson.SelectedValue.ToString().Equals("0"))
            {
                classHelper.query = @"SELECT E.NAME AS [SALES PERSON],A.DATE,A.AMOUNT,B.COA_NAME AS [CUSTOMER],A.BANK,A.BR_CODE,A.INSTRUMENT_NO,A.REF_AC,
                CASE WHEN A.STATUS = '0' THEN 'PENDING' ELSE 'APPROVED' END AS [STATUS]
                FROM PAYMENT_TRANSFER A
                INNER JOIN COA B ON A.REC_AC = B.COA_ID
                INNER JOIN COA C ON A.PAY_AC = C.COA_ID
                INNER JOIN CUSTOMER_PROFILE D ON B.COA_ID = D.COA_ID
                INNER JOIN SALES_PERSONS E ON D.SALE_PER_ID = E.SALES_PER_ID
                WHERE A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'";
            }
            else
            {
                classHelper.query = @"SELECT E.NAME AS [SALES PERSON],A.DATE,A.AMOUNT,B.COA_NAME AS [CUSTOMER],A.BANK,A.BR_CODE,A.INSTRUMENT_NO,A.REF_AC,
                CASE WHEN A.STATUS = '0' THEN 'PENDING' ELSE 'APPROVED' END AS [STATUS]
                FROM PAYMENT_TRANSFER A
                INNER JOIN COA B ON A.REC_AC = B.COA_ID
                INNER JOIN COA C ON A.PAY_AC = C.COA_ID
                INNER JOIN CUSTOMER_PROFILE D ON B.COA_ID = D.COA_ID
                INNER JOIN SALES_PERSONS E ON D.SALE_PER_ID = E.SALES_PER_ID
                WHERE E.SALES_PER_ID = '" + cmbSalePerson.SelectedValue.ToString() + @"' 
                AND A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'";
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
                        classHelper.dataR["recAccount"] = classHelper.dr["CUSTOMER"].ToString();
                        classHelper.dataR["amount"] = Convert.ToDecimal(classHelper.dr["AMOUNT"].ToString());
                        classHelper.dataR["bank"] = classHelper.dr["BANK"].ToString();
                        classHelper.dataR["brCode"] = classHelper.dr["BR_CODE"].ToString();
                        classHelper.dataR["instrumentNo"] = classHelper.dr["INSTRUMENT_NO"].ToString();
                        classHelper.dataR["refAccount"] = classHelper.dr["REF_AC"].ToString();
                        classHelper.dataR["status"] = classHelper.dr["STATUS"].ToString();
                        classHelper.dataR["salesPerson"] = classHelper.dr["SALES PERSON"].ToString();
                        classHelper.dataR["from"] = dtp_FROM.Value.Date;
                        classHelper.dataR["to"] = dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                        classHelper.mds.Tables["PaymentTransferSheet"].Rows.Add(classHelper.dataR);
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
                classHelper.rpt.GenerateReport("SalesPersonReport", classHelper.mds);
                classHelper.rpt.ShowDialog();
            }
        }
        private void CustomerReport()
        {
            if (cmbCustomer.SelectedIndex > 0)
            {
                if (cmbCustomer.SelectedValue.ToString().Equals("0"))
                {
                    classHelper.query = @"SELECT A.DATE,A.AMOUNT,B.COA_NAME AS [CUSTOMER],A.BANK,A.BR_CODE,A.INSTRUMENT_NO,A.REF_AC,
                CASE WHEN A.STATUS = '0' THEN 'PENDING' ELSE 'APPROVED' END AS [STATUS],ISNULL(CONVERT(varchar(max),A.CONFORMATION_DATE),'-') as CONFORMATION_DATE
                FROM PAYMENT_TRANSFER A
                INNER JOIN COA B ON A.REC_AC = B.COA_ID
                WHERE A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'";
                }
                else
                {
                    classHelper.query = @"SELECT A.DATE,A.AMOUNT,B.COA_NAME AS [CUSTOMER],A.BANK,A.BR_CODE,A.INSTRUMENT_NO,A.REF_AC,
                CASE WHEN A.STATUS = '0' THEN 'PENDING' ELSE 'APPROVED' END AS [STATUS],ISNULL(CONVERT(varchar(max),A.CONFORMATION_DATE),'-') as CONFORMATION_DATE
                FROM PAYMENT_TRANSFER A
                INNER JOIN COA B ON A.REC_AC = B.COA_ID
                WHERE A.REC_AC = '" + cmbCustomer.SelectedValue.ToString() + "' AND A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'";
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
                            classHelper.dataR["recAccount"] = classHelper.dr["CUSTOMER"].ToString();
                            classHelper.dataR["amount"] = Convert.ToDecimal(classHelper.dr["AMOUNT"].ToString());
                            classHelper.dataR["bank"] = classHelper.dr["BANK"].ToString();
                            classHelper.dataR["brCode"] = classHelper.dr["BR_CODE"].ToString();
                            classHelper.dataR["instrumentNo"] = classHelper.dr["INSTRUMENT_NO"].ToString();
                            classHelper.dataR["refAccount"] = classHelper.dr["REF_AC"].ToString();
                            classHelper.dataR["status"] = classHelper.dr["STATUS"].ToString();
                            classHelper.dataR["from"] = dtp_FROM.Value.Date;
                            classHelper.dataR["to"] = dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                            if ((classHelper.dr["CONFORMATION_DATE"].ToString())
                                .Equals("-"))
                            {
                                classHelper.dataR["conformationDate"] = "-";
                            }
                            else
                            {
                                classHelper.dataR["conformationDate"] = Convert.ToDateTime(classHelper.dr["CONFORMATION_DATE"].ToString()).ToString("dd-MMM-yyyy");

                            }
                            classHelper.mds.Tables["PaymentTransferSheet"].Rows.Add(classHelper.dataR);
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
                    classHelper.rpt.GenerateReport("CustomerReport", classHelper.mds);
                    classHelper.rpt.ShowDialog();
                }
            }
        }

        private void btnINTER_SAVE_Click(object sender, EventArgs e)
        {
            if (rdbConformation.Checked == true)
            {
                if (cmbCustomer.SelectedIndex > 0)
                {
                    ConformationCustomerReport();
                }
                else if (cmbSupplier.SelectedIndex > 0)
                {
                    ConformationSupplierReport();
                }
                else if (cmbSalePerson.SelectedIndex > 0)
                {
                    ConformationSalesPersonReport();
                }
                else {
                    ConformationReport();
                }
            }
            else if (rdbPending.Checked == true)
            {
                if (cmbCustomer.SelectedIndex > 0)
                {
                    PendingCustomerReport();
                }
                else if (cmbSupplier.SelectedIndex > 0)
                {
                    PendingSupplierReport();
                }
                else if (cmbSalePerson.SelectedIndex > 0)
                {
                    PendingSalesPersonReport();
                }
                else
                {
                    PendingReport();
                }
            }
            else if (rdbOverallDetailReport.Checked == true)
            {
                if (cmbCustomer.SelectedIndex > 0)
                {
                    DailyCustomerReport();
                }
                else if (cmbSupplier.SelectedIndex > 0)
                {
                    DailySupplierReport();
                }
                else if (cmbSalePerson.SelectedIndex > 0)
                {
                    DailySalesPersonReport();
                }
                else
                {
                    DailyReport();
                }
            }
            else if (rdbSupplier.Checked == true)
            {
                SupplierReport();
            }
            else if (rdbSalesPerson.Checked == true)
            {
                SalesPersonReport();
            }
            else if (rdbCustomer.Checked == true)
            {
                CustomerReport();
            }
        }

        private void frm_Account_Ledger_Load(object sender, EventArgs e)
        {
            LoadSalesPerson();
            LoadCustomer();
            LoadSupplier();
        }

        private void frm_Account_Ledger_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void cmbSalePerson_TextUpdate(object sender, EventArgs e)
        {
            classHelper.CmbTextUpdate(sender as ComboBox);
        }

        private void cmbSalePerson_DropDown(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown += new PreviewKeyDownEventHandler(cmbSalePerson_PreviewKeyDown);
        }

        private void cmbSalePerson_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown -= cmbSalePerson_PreviewKeyDown;
            if (cbo.DroppedDown) cbo.Focus();
        }

        private void rdbSalesPerson_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbSalesPerson.Checked == true)
            {
                cmbSalePerson.Enabled = true;
            }
            else {
                cmbSalePerson.Enabled = false;
            }
        }

        private void rdbSupplier_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbSupplier.Checked == true)
            {
                cmbSupplier.Enabled = true;
            }
            else
            {
                cmbSupplier.Enabled = false;
            }
        }

        private void rdbCustomer_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCustomer.Checked == true)
            {
                cmbCustomer.Enabled = true;
            }
            else
            {
                cmbCustomer.Enabled = false;
            }
        }

        private void cmbSupplier_DropDown(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown += new PreviewKeyDownEventHandler(cmbSupplier_PreviewKeyDown);
        }

        private void cmbSupplier_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown -= cmbSupplier_PreviewKeyDown;
            if (cbo.DroppedDown) cbo.Focus();
        }

        private void cmbCustomer_DropDown(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown += new PreviewKeyDownEventHandler(cmbCustomer_PreviewKeyDown);
        }

        private void cmbCustomer_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown -= cmbCustomer_PreviewKeyDown;
            if (cbo.DroppedDown) cbo.Focus();
        }
    }
}
