using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace ERP_Maaz_Oil.Classes
{
    class cls_General_Voucher
    {
        Classes.Helper cls_fhp = new Helper();
        string query = "";
        public string debit_code = "";
        public string credit_code = "";

        //load trv grid
        public void load_trv_grid(DataGridView dg)
        {
            query = @"SELECT A.GV_ID,CONVERT(varchar(MAX),A.DAATE) AS [DATE],A.GV_CODE AS [VOUCHER #],A.TRANS_CODE AS [TRANSACTION CODE],A.NARRATION AS [NARRATION],
            SUM(B.DEBIT) AS [AMOUNT]
            FROM GENERAL_VOUCHER_M A
            INNER JOIN GENERAL_VOUCHER_D B ON A.GV_ID = B.GV_ID
            GROUP BY A.GV_ID,A.DAATE,A.GV_CODE,A.TRANS_CODE,A.NARRATION ORDER BY A.DAATE DESC";
            cls_fhp.LoadGrid(dg, query);
        }

        //get head account code
        public string get_head_code(string code)
        {
            string acode = "0000";
            string query = "select COA_CODE from COA WHERE COA_ID = '" + code + "'";
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
                        acode = dr[0].ToString();
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
            return acode;
        }

        //grid search 
        public void cvr_grid_search(TextBox txtSEARCH, DataGridView grdSEARCH)
        {
            (grdSEARCH.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
            [" + grdSEARCH.Columns[1].Name.ToString() + "] LIKE '%" + cls_fhp.AvoidInjection(txtSEARCH.Text) + "%' OR ["
              + grdSEARCH.Columns[2].Name.ToString() + "] LIKE '%" + cls_fhp.AvoidInjection(txtSEARCH.Text) + "%' OR ["
              + grdSEARCH.Columns[3].Name.ToString() + "] LIKE '%" + cls_fhp.AvoidInjection(txtSEARCH.Text) + "%' OR ["
              + grdSEARCH.Columns[4].Name.ToString() + "] LIKE '%" + cls_fhp.AvoidInjection(txtSEARCH.Text) + "%' ");
            grdSEARCH.ClearSelection();
        }

        //load bank accounts combo box
        public void load_accounts(ComboBox cmbBankAccounts)
        {
            query = @"SELECT '0' AS [id],'--SELECT ACCOUNT--' AS [name]
            UNION ALL
            SELECT COA_ID,COA_NAME FROM COA";
            cls_fhp.LoadComboData(cmbBankAccounts, query);
        }

        //save group record in database
        public int save_Gv_details(string save_query)
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
            query = "select count(GV_ID)+1 from GENERAL_VOUCHER_M";
            lbl.Text = "GV-"+cls_fhp.generate_voucher_code(query)+"-"+DateTime.Now.Year;
        }

        //generate transaction no
        public void generate_transaction_no(Label lbl)
        {
            query = "select (count(LEGDER_ID)+1)+1000000 from LEDGERS";
            lbl.Text = cls_fhp.generate_voucher_code(query).ToString();
        }


        //get details from voucher id
        public void get_voucher_details(string gv_id,DataGridView dg)
        {
            dg.Rows.Clear();
            string query = @"SELECT A.COA_ID,B.COA_NAME,A.DEBIT,A.CREDIT,(select INVOICE_NO from INVOICES_DETAILS where VOUCHER_ID = '" + gv_id + "' AND VOUCHER_OF = 'JV' AND COA_ID = A.COA_ID),(select PAY_OF from INVOICES_DETAILS where VOUCHER_ID = '" + gv_id + @"' AND VOUCHER_OF = 'JV' AND COA_ID = A.COA_ID)
            FROM GENERAL_VOUCHER_D A,COA B
            WHERE A.COA_ID = B.COA_ID AND A.GV_ID = '" + gv_id+"'";
            //SELECT A.COA_ID,B.COA_NAME,A.DEBIT,A.CREDIT FROM GENERAL_VOUCHER_D A,COA B WHERE A.COA_ID = B.COA_ID AND A.GV_ID = '" + gv_id+"'
            Classes.Helper.conn.Open();
            try
            {
                cls_fhp.cmd = new SqlCommand(query, Classes.Helper.conn);
                cls_fhp.cmd.CommandTimeout = 0;
                cls_fhp.dr = cls_fhp.cmd.ExecuteReader();
                if (cls_fhp.dr.HasRows)
                {
                    int i = 0;
                    while (cls_fhp.dr.Read())
                    {
                        dg.Rows.Add(cls_fhp.dr[0].ToString(), cls_fhp.dr[1].ToString(), cls_fhp.dr[2].ToString(), cls_fhp.dr[3].ToString(), cls_fhp.dr[4].ToString(), cls_fhp.dr[5].ToString());
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

        //insert ledger entry
        public int insert_ledger_entry(string date, int coa_id, string reference_id, string entry_of, float damount, float camount, string description)
        {
            string query = @"IF EXISTS (SELECT REF_ID FROM LEDGERS WHERE REF_ID = '" + reference_id + @"')
                BEGIN
                DELETE FROM LEDGERS WHERE REF_ID = '" + reference_id + "' AND ENTRY_OF = '" + entry_of + @"'
                INSERT INTO LEDGERS VALUES('" + date + "', '" + coa_id + @"',
                '" + reference_id + "', '" + entry_of + @"',
                '" + damount + "','" + camount + "','" + description + "','" + Classes.Helper.userId + @"',
                '" + DateTime.Now + @"',NULL,'00');
                END
                ELSE
                BEGIN
                DELETE FROM LEDGERS WHERE REF_ID = '" + reference_id + "' AND ENTRY_OF = '" + entry_of + @"'
                INSERT INTO LEDGERS VALUES('" + date + "', '" + coa_id + @"',
                (SELECT MAX(GV_ID) FROM GENERAL_VOUCHER_M),'" + entry_of + @"',
                '" + damount + "','" + camount + "','" + description + "','" + Classes.Helper.userId + @"',
                '" + DateTime.Now + @"',NULL,'00');
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
        public void get_head_bank_code(string Dcode, string Ccode)
        {
            string[] codes = new string[2];
            string query = "select COA_CODE from COA WHERE COA_ID = '"+Dcode+"' OR COA_ID = '"+Ccode+"'";
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
            debit_code = codes[0];
            credit_code = codes[1];
        }
    }
}
