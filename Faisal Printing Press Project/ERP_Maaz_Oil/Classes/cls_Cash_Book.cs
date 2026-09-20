using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace ERP_Maaz_Oil.Classes
{
    class cls_Cash_Book
    {
        Classes.Helper cls_fhp = new Helper();
        string query = "";
        public string debit_code = "";
        public string credit_code = "";
        DataTable dt = new DataTable();
        SqlDataReader dr;





        public void load_CPMM_grid(DataGridView dg, DateTime dtpDate, double totalBalance)
        {
            query = @"SELECT DISTINCT A.CPV_ID, A.BANK_ID, A.CPV_CODE AS [VOUCHER #],CONVERT(varchar(MAX), A.DAATE) AS [DATE], B.COA_NAME AS [ACCOUNT], B.COA_NAME AS [BANK], A.COA_ID, A.TRANS_CODE, A.DESCRIPTION, A.AMOUNT, A.TYPE
                   FROM  CASHBANKRECMASTER A
                     INNER JOIN COA B ON A.COA_ID = B.COA_ID
                     WHERE A.DAATE BETWEEN '" + dtpDate + @"' AND '" + dtpDate.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
                     ORDER BY [DATE] DESC";
            
            try
            {
                if (Classes.Helper.conn.State == ConnectionState.Closed)
                    Classes.Helper.conn.Open();

                cls_fhp.cmd = new SqlCommand(query, Classes.Helper.conn);
                dr = cls_fhp.cmd.ExecuteReader();
                dt = new DataTable();
                dt.Load(dr);
                dg.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Classes.Helper.conn.Close();
            }
        }



        //load cvrCASHPAYRECMASTER grid
        public void load_CPM_grid(DataGridView dg, DateTime dtpDate, double totalBalance)
        {
            query = @"SELECT DISTINCT A.CPV_ID, A.CPV_CODE AS [VOUCHER #],CONVERT(varchar(MAX), A.DAATE) AS [DATE], B.COA_NAME AS [ACCOUNT], A.COA_ID, A.TRANS_CODE, A.DESCRIPTION, A.AMOUNT, A.TYPE
               FROM CASHPAYRECMASTER A
               INNER JOIN COA B ON A.COA_ID = B.COA_ID
               WHERE A.DAATE BETWEEN '" + dtpDate + @"' AND '" + dtpDate.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
                ORDER BY [DATE] DESC";

            try
            {
                if (Classes.Helper.conn.State == ConnectionState.Closed)
                    Classes.Helper.conn.Open();

                cls_fhp.cmd = new SqlCommand(query, Classes.Helper.conn);
                dr = cls_fhp.cmd.ExecuteReader();
                dt = new DataTable();
                dt.Load(dr);
                dg.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Classes.Helper.conn.Close();
            }
        }


        //load cvr grid

        public void load_cvr_grid(DataGridView dg,DateTime dtpDate,double totalBalance)
        {
            query = @"SELECT DISTINCT A.CPV_ID,A.CPV_CODE AS [VOUCHER #],CONVERT(varchar(MAX),A.DAATE) AS [DATE],B.COA_NAME AS [ACCOUNT],A.COA_ID,'0' as [RECEIVED AMOUNT],
					LTRIM(STR(a.AMOUNT,25,2)) as [PAYMENT AMOUNT],					
					A.REF_ACCOUNT AS [REF ACCOUNT],A.PAID_TO AS [PAID TO],'-' as [RECV PERSON],A.TRANS_CODE,A.ACCOUNT_OF as [NARRATION]
					FROM CASH_PAY_VOUCHER A,COA B,COA C,RECOVERY_PERSON R
                    WHERE A.COA_ID = B.COA_ID AND A.COA_ID = C.COA_ID AND DAATE BETWEEN '" + dtpDate + @"' AND '" + dtpDate.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'

					UNION ALL

					SELECT DISTINCT A.CRV_ID,A.CRV_CODE AS [VOUCHER #],CONVERT(varchar(MAX),A.DAATE) AS [DATE],B.COA_NAME AS [ACCOUNT],A.COA_ID,LTRIM(STR(a.AMOUNT,25,2)) as [RECEIVED AMOUNT],
					'0'  as [PAYMENT AMOUNT],				
					A.REF_ACCOUNT AS [REF ACCOUNT],'-' AS [PAID TO],R.REC_PERSON_NAME as [RECV PERSON],A.TRANS_CODE,A.DESCRIPTION as [NARRATION]
					FROM CASH_REC_VOUCHER A,COA B,COA C,RECOVERY_PERSON R
					WHERE A.COA_ID = B.COA_ID AND A.COA_ID = C.COA_ID AND A.REC_PERSON_ID = R.REC_PERSON_ID AND DAATE BETWEEN '" + dtpDate + @"' AND '" + dtpDate.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
                    ORDER BY [DATE] DESC";
            try
            {
                if (Classes.Helper.conn.State == ConnectionState.Closed)
                    Classes.Helper.conn.Open();
                cls_fhp.cmd = new SqlCommand(query, Classes.Helper.conn);
                dr = cls_fhp.cmd.ExecuteReader();
                dt = new DataTable();
                dt.Load(dr);
                //dt.Columns.Add("BALANCE AMOUNT");
                //foreach (DataRow row in dt.Rows)
                //{
                    
                //    if (row["VOUCHER #"].ToString().Contains("CPV"))
                //    {
                //        //balanceLeft = balanceLeft - double.Parse(row["PAYMENT AMOUNT"].ToString());
                //        totalBalance = totalBalance - double.Parse(row["PAYMENT AMOUNT"].ToString());
                //    }
                //    else
                //        totalBalance = totalBalance - double.Parse(row["RECEIVED AMOUNT"].ToString());
                //    row["BALANCE AMOUNT"] = totalBalance.ToString();
                //}
                dg.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Classes.Helper.conn.Close();
            }
            //cls_fhp.LoadGrid(dg, query);
        }







        public void load_receipt_grid(DataGridView dg, DateTime date)
        {
            //       cls_fhp.query = @"SELECT D.NAME AS [SALES PERSON],SUM(A.AMOUNT) AS TOTAL
            //   FROM CASHPAYRECMASTER A
            // INNER JOIN COA B ON A.COA_ID = B.COA_ID         
            //	INNER JOIN CUSTOMER_PROFILE C ON B.COA_ID = C.COA_ID
            // INNER JOIN SALES_PERSONS D ON C.SALE_PER_ID = D.SALES_PER_ID
            //WHERE A.DAATE BETWEEN '" + date.ToShortDateString() + @" 00:00:00 AM' AND '" + date.ToShortDateString() + @" 23:59:59 PM'
            //GROUP BY D.NAME";

            cls_fhp.query = @"SELECT B.COA_NAME AS[SALES PERSON], SUM(A.AMOUNT) AS TOTAL
            FROM CASHPAYRECMASTER A
            INNER JOIN COA B ON A.COA_ID = B.COA_ID
            WHERE A.DAATE BETWEEN '" + Classes.Helper.ConvertDatetime(date.Date)+ "' AND '" + Classes.Helper.ConvertDatetime(date.Date.AddHours(23).AddMinutes(59).AddSeconds(59))+ @"'
            AND A.Type = '1' 
            GROUP BY B.COA_NAME";

            try
            {
                Classes.Helper.conn.Open();
                cls_fhp.cmd = new SqlCommand(cls_fhp.query, Classes.Helper.conn);
                cls_fhp.dr = cls_fhp.cmd.ExecuteReader();
                if (cls_fhp.dr.HasRows == true)
                {
                    DataTable dt = new DataTable();
                    dt.Load(cls_fhp.dr);
                    dg.DataSource = dt;
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
        }

        public void load_Bankrec_grid(DataGridView dg, DateTime date)
        {

            cls_fhp.query = @" SELECT B.COA_NAME AS[SALES PERSON], SUM(A.AMOUNT) AS TOTAL
            FROM CASHBANKRECMASTER A
            INNER JOIN COA B ON A.COA_ID = B.COA_ID
            WHERE A.DAATE BETWEEN '" + Classes.Helper.ConvertDatetime(date.Date)+ "' AND '" + Classes.Helper.ConvertDatetime(date.Date.AddHours(23).AddMinutes(59).AddSeconds(59))+ @"'
            AND A.Type = '1'
            GROUP BY B.COA_NAME";

           // cls_fhp.query = @"SELECT D.NAME AS [SALES PERSON],SUM(A.AMOUNT) AS TOTAL
           // FROM CASHBANKRECMASTER A
           // INNER JOIN COA B ON A.COA_ID = B.COA_ID         
           //	INNER JOIN CUSTOMER_PROFILE C ON B.COA_ID = C.COA_ID
           //  INNER JOIN SALES_PERSONS D ON C.SALE_PER_ID = D.SALES_PER_ID
           // WHERE A.DAATE BETWEEN '" + date.ToShortDateString() + @" 00:00:00 AM' AND '" + date.ToShortDateString() + @" 23:59:59 PM'
           // GROUP BY D.NAME";

            try
            {
                Classes.Helper.conn.Open();
                cls_fhp.cmd = new SqlCommand(cls_fhp.query, Classes.Helper.conn);
                cls_fhp.dr = cls_fhp.cmd.ExecuteReader();
                if (cls_fhp.dr.HasRows == true)
                {
                    DataTable dt = new DataTable();
                    dt.Load(cls_fhp.dr);
                    dg.DataSource = dt;
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
        }




        public void load_Bankcash_grid(DataGridView dg, DateTime date)
        {
            cls_fhp.query = @" SELECT B.Coa_NAME AS[PAYMENT ACCOUNT], SUM(A.AMOUNT) AS TOTAL
            FROM CASHBANKRECMASTER A
            INNER JOIN COA B ON A.COA_ID = B.COA_ID
            WHERE A.DAATE BETWEEN '" + date.ToShortDateString() + @" 00:00:00 AM' AND '" + date.ToShortDateString() + @" 23:59:59 PM'
           AND A.Type = '0'
            GROUP BY B.COA_NAME";

            try
            {
                Classes.Helper.conn.Open();
                cls_fhp.cmd = new SqlCommand(cls_fhp.query, Classes.Helper.conn);
                cls_fhp.dr = cls_fhp.cmd.ExecuteReader();
                if (cls_fhp.dr.HasRows == true)
                {
                    DataTable dt = new DataTable();
                    dt.Load(cls_fhp.dr);
                    dg.DataSource = dt;
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
        }




        public void load_cash_grid(DataGridView dg, DateTime date)
        {
            cls_fhp.query = @"SELECT B.Coa_NAME AS [PAYMENT ACCOUNT],SUM(A.AMOUNT) AS TOTAL
            FROM CASHPAYRECMASTER A
            INNER JOIN COA B ON A.COA_ID = B.COA_ID          
            WHERE A.DAATE BETWEEN '" + date.ToShortDateString() + @" 00:00:00 AM' AND '" + date.ToShortDateString() + @" 23:59:59 PM'
           AND A.Type = '0'
            GROUP BY B.COA_NAME";

            try
            {
                Classes.Helper.conn.Open();
                cls_fhp.cmd = new SqlCommand(cls_fhp.query, Classes.Helper.conn);
                cls_fhp.dr = cls_fhp.cmd.ExecuteReader();
                if (cls_fhp.dr.HasRows == true)
                {
                    DataTable dt = new DataTable();
                    dt.Load(cls_fhp.dr);
                    dg.DataSource = dt;
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
        }

        public void load_rec_grid(DataGridView dg, DateTime date)
        {
            cls_fhp.query = @"SELECT D.NAME AS [SALES PERSON],SUM(A.AMOUNT) AS TOTAL
            FROM CASH_REC_VOUCHER A
            INNER JOIN COA B ON A.COA_ID = B.COA_ID         
			INNER JOIN CUSTOMER_PROFILE C ON B.COA_ID = C.COA_ID
            INNER JOIN SALES_PERSONS D ON C.SALE_PER_ID = D.SALES_PER_ID
            WHERE A.DAATE BETWEEN '" + date.ToShortDateString() + @" 00:00:00 AM' AND '" + date.ToShortDateString() + @" 23:59:59 PM'
            GROUP BY D.NAME";

            try
            {
                Classes.Helper.conn.Open();
                cls_fhp.cmd = new SqlCommand(cls_fhp.query, Classes.Helper.conn);
                cls_fhp.dr = cls_fhp.cmd.ExecuteReader();
                if (cls_fhp.dr.HasRows == true)
                {
                    DataTable dt = new DataTable();
                    dt.Load(cls_fhp.dr);
                    dg.DataSource = dt;
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
        }







        public void load_pay_grid(DataGridView dg, DateTime date)
        {
            cls_fhp.query = @"SELECT B.Coa_NAME AS [PAYMENT ACCOUNT],SUM(A.AMOUNT) AS TOTAL
            FROM CASH_PAY_VOUCHER A
            INNER JOIN COA B ON A.COA_ID = B.COA_ID          
            WHERE A.DAATE BETWEEN '" + date.ToShortDateString() + @" 00:00:00 AM' AND '" + date.ToShortDateString() + @" 23:59:59 PM'
            GROUP BY B.COA_NAME";

            try
            {
                Classes.Helper.conn.Open();
                cls_fhp.cmd = new SqlCommand(cls_fhp.query, Classes.Helper.conn);
                cls_fhp.dr = cls_fhp.cmd.ExecuteReader();
                if (cls_fhp.dr.HasRows == true)
                {
                    DataTable dt = new DataTable();
                    dt.Load(cls_fhp.dr);
                    dg.DataSource = dt;
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
        }

   

    //grid search 
    public void cvr_grid_search(TextBox txtSEARCH, DataGridView grdSEARCH)
        {
            {
                (grdSEARCH.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
            [" + grdSEARCH.Columns[1].Name.ToString() + "] LIKE '%" + cls_fhp.AvoidInjection(txtSEARCH.Text) + "%' OR ["
                  + grdSEARCH.Columns[3].Name.ToString() + "] LIKE '%" + cls_fhp.AvoidInjection(txtSEARCH.Text) + "%' OR ["
                  + grdSEARCH.Columns[5].Name.ToString() + "] LIKE '%" + cls_fhp.AvoidInjection(txtSEARCH.Text) + "%' OR ["
                  
                  + grdSEARCH.Columns[6].Name.ToString() + "] LIKE '%" + cls_fhp.AvoidInjection(txtSEARCH.Text) + "%'");
                grdSEARCH.ClearSelection();
            }

 }

        //grid search 
        public void cvrr_grid_search(TextBox txtSEARCH, DataGridView grdSEARCH)
        {
            {
                (grdSEARCH.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
            [" + grdSEARCH.Columns[5].Name.ToString() + "] LIKE '%" + cls_fhp.AvoidInjection(txtSEARCH.Text) + "%' OR ["
                  + grdSEARCH.Columns[3].Name.ToString() + "] LIKE '%" + cls_fhp.AvoidInjection(txtSEARCH.Text) + "%' OR ["
                  + grdSEARCH.Columns[7].Name.ToString() + "] LIKE '%" + cls_fhp.AvoidInjection(txtSEARCH.Text) + "%' OR ["

                  + grdSEARCH.Columns[8].Name.ToString() + "] LIKE '%" + cls_fhp.AvoidInjection(txtSEARCH.Text) + "%'");
                grdSEARCH.ClearSelection();
            }

        }


        //grid search cash and petty cash
        public void cvr_grid_search_cash_pettyCash(string keyword, DataGridView grdSEARCH)
        {
            (grdSEARCH.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
            [" + grdSEARCH.Columns[10].Name.ToString() + "] = '" + keyword + "'");
            grdSEARCH.ClearSelection();
        }

        //load account nature combo box
        public void load_accounts(ComboBox cmbAccounts)
        {
            query = @"SELECT '0' AS [id],'--SELECT ACCOUNT--' AS [name]
            UNION ALL
            SELECT COA_ID,COA_NAME FROM COA";
            cls_fhp.LoadComboData(cmbAccounts, query);
        }

        //LOAD BANK ACCOUNT

        public void load_bankaccounts(ComboBox cmbank)
        {
            query = @"SELECT '0' AS [id],'--SELECT BANK ACCOUNT--' AS [name]
            UNION ALL
            SELECT COA_ID,COA_NAME FROM COA";
            cls_fhp.LoadComboData(cmbank, query);
        }


        //load cash accounts combo box
        public void load_cash_accounts(ComboBox cmbAccounts)
        {
            query = @"SELECT '0' AS [id],'--SELECT ACCOUNT--' AS [name]
            UNION ALL
            SELECT COA_ID,COA_NAME FROM COA";
            cls_fhp.LoadComboData(cmbAccounts, query);
        }

        //load invoice
        public void load_invoices(ComboBox cmbInvoices, string coa_id)
        {
            query = @"SELECT '0' AS [id],'--SELECT INVOICE--' AS [name]
            UNION ALL
            select P_ID,P_CODE from PURCHASES WHERE (TOTAL - REC_AMT) <> 0 AND COA_ID = '" + coa_id + "'";
            cls_fhp.LoadComboData(cmbInvoices, query);
        }

        //load All invoice
        public void load_all_invoices(ComboBox cmbInvoices, string coa_id)
        {
            query = @"SELECT '0' AS [id],'--SELECT INVOICE--' AS [name]
            UNION ALL
            select P_ID,P_CODE from PURCHASES WHERE COA_ID = '" + coa_id + "'";
            cls_fhp.LoadComboData(cmbInvoices, query);
        }

        public void invoice_detail(string vou_code, ComboBox cmbInvoices, RadioButton rdbInvoices, RadioButton rdbOther)
        {
            string query = "SELECT INVOICE_NO FROM INVOICES_DETAILS WHERE VOUCHER_ID = '" + vou_code + "' AND PAY_OF = 'PURCHASES'";
            Classes.Helper.conn.Open();
            try
            {
                cls_fhp.cmd = new SqlCommand(query, Classes.Helper.conn);
                cls_fhp.cmd.CommandTimeout = 0;
                SqlDataReader dr = cls_fhp.cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    if (dr.Read())
                    {
                        cmbInvoices.Enabled = true;
                        cmbInvoices.SelectedValue = dr[0].ToString();
                        rdbInvoices.Checked = true;
                    }
                }
                else
                {
                    cmbInvoices.Enabled = false;
                    cmbInvoices.SelectedIndex = 0;
                    rdbOther.Checked = false;
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

        //save group record in database
        public int save_cpv_details(string save_query)
        {
            return cls_fhp.InsertUpdateDelete(save_query);
        }

        //check blank and place zero
        public void check_blank_zero(TextBox txt)
        {
            if (txt.Text.Trim().Equals(""))
            {
                txt.Text = "0";
            }
        }

        //generate voucher no
        public void generate_voucher_no(Label lbl)
        {
            query = "select count(CPV_ID)+1 from CASH_PAY_VOUCHER";
            lbl.Text = "CPV-"+cls_fhp.generate_voucher_code(query)+"-"+DateTime.Now.Year;
        }

        //generate transaction no
        public void generate_transaction_no(Label lbl)
        {
            query = "select (count(LEGDER_ID)+1)+1000000 from LEDGERS";
            lbl.Text = cls_fhp.generate_voucher_code(query).ToString();
        }

        //insert ledger entry
        public int insert_ledger_entry(string date, int debit_coa_id, int credit_coa_id, string reference_id, string entry_of, float amount, string description,string code,string refAcc)
        {
                string query = @"
                DELETE FROM LEDGERS WHERE REF_ID = " + reference_id + " AND ENTRY_OF = '" + entry_of + @"'
                IF EXISTS (SELECT REF_ID FROM LEDGERS WHERE REF_ID = " + reference_id + @")
                BEGIN
                INSERT INTO LEDGERS VALUES('" + date + "', '" + debit_coa_id + @"',
                " + reference_id + ", '" + entry_of + @"','"+code+@"',
                '" + amount + "','0','" + description + "','" + Classes.Helper.userId + @"',
                '" + DateTime.Now + @"',NULL,NULL,1,'"+refAcc+@"');
                INSERT INTO LEDGERS VALUES('" + date + "', '" + credit_coa_id + @"',
                " + reference_id + ", '" + entry_of + @"','" + code + @"','0',
                '" + amount + "','" + description + "','" + Classes.Helper.userId + @"',
                '" + DateTime.Now + @"',NULL,NULL,1,'" + refAcc + @"');
                END
                ELSE
                BEGIN
                DELETE FROM LEDGERS WHERE REF_ID = " + reference_id + " AND ENTRY_OF = '" + entry_of + @"'
                INSERT INTO LEDGERS VALUES('" + date + "', '" + debit_coa_id + @"',
                (SELECT MAX(CPV_ID) FROM CASH_PAY_VOUCHER),'" + entry_of + @"','" + code + @"',
                '" + amount + "','0','" + description + "','" + Classes.Helper.userId + @"',
                '" + DateTime.Now + @"',NULL,NULL,1,'" + refAcc + @"');
                INSERT INTO LEDGERS VALUES('" + date + "', '" + credit_coa_id + @"',
                (SELECT MAX(CPV_ID) FROM CASH_PAY_VOUCHER),'" + entry_of + @"','" + code + @"','0',
                '" + amount + "','" + description + "','" + Classes.Helper.userId + @"',
                '" + DateTime.Now + @"',NULL,NULL,1,'" + refAcc + @"');
                END";
            Classes.Helper.conn.Open();
            try
            {
                cls_fhp.cmd = new SqlCommand(query, Classes.Helper.conn);
                cls_fhp.cmd.CommandTimeout = 0;
                return cls_fhp.cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 0;
            }
            finally
            {
                Classes.Helper.conn.Close();
            }
        }

        //get cash and head account code & name
        public void get_head_cash_code(string code) {
            string[] codes = new string[2];
            string query = "select COA_CODE from COA WHERE COA_ID = '"+code+"' OR COA_NAME = 'PETTY CASH'";
            Classes.Helper.conn.Open();
            try
            {
                cls_fhp.cmd = new SqlCommand(query, Classes.Helper.conn);
                cls_fhp.cmd.CommandTimeout = 0;
                SqlDataReader dr = cls_fhp.cmd.ExecuteReader();
                if(dr.HasRows){
                    int i = 0;
                    while (dr.Read())
                    {
                        codes[i] = dr[0].ToString();
                        i += 1;
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
            debit_code = codes[1];
            credit_code = codes[0];
        }

        public void getOpeningBal(TextBox txtOpenBal,DateTime dtp_DATE)
        {
            cls_fhp.query = @"SELECT SUM(B.DEBIT)+SUM(B.CREDIT)
		                +(select case when DR_CR = 'D' then OPEN_BAL else -OPEN_BAL end from COA where COA_ID = b.COA_ID) 
		                as [Opening] FROM
		                LEDGERS B
		                WHERE B.DATE < '"+dtp_DATE+@"' AND B.COA_ID = "+Classes.Helper.cashId+@"
		                Group By B.COA_ID";
            txtOpenBal.Text = cls_fhp.GetScalarAmount(cls_fhp.query).ToString();
        }
    }
}
