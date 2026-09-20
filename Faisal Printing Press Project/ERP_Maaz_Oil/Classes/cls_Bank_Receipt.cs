using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace ERP_Maaz_Oil.Classes
{
    class cls_Bank_Receipt
    {
        Classes.Helper cls_fhp = new Classes.Helper();
        string query = "";
        public string debit_code = "";
        public string credit_code = "";

        //load cvr grid
        public void load_bvr_grid(DataGridView dg)
        {
            query = @"SELECT A.BRV_ID,A.BRV_CODE AS [VOUCHER #],A.TRANS_CODE,CONVERT(varchar(MAX),A.DAATE) AS [DATE],A.BANK_ID,C.COA_NAME AS [BANK],A.COA_ID,B.COA_NAME AS [ACCOUNT],A.CHQ_NO AS [CHEQUE #],CONVERT(varchar(MAX),A.CHQ_DAATE) AS [CHEQUE DATE], A.ACCOUNT_OF AS [DESCRIPTION],A.REC_FROM AS [RECIVED FROM],LTRIM(STR(a.AMOUNT,25,2)) as [AMOUNT]
FROM BANK_REC_VOUCHER A,COA B,COA C
WHERE A.COA_ID = B.COA_ID AND A.BANK_ID = C.COA_ID ORDER BY A.DAATE DESC
            ";
            cls_fhp.LoadGrid(dg, query);
        }

        //grid search 
        public void cvr_grid_search(TextBox txtSEARCH, DataGridView grdSEARCH)
        {
            (grdSEARCH.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
            [" + grdSEARCH.Columns[1].Name.ToString() + "] LIKE '%" + cls_fhp.AvoidInjection(txtSEARCH.Text) + "%' OR ["
              + grdSEARCH.Columns[3].Name.ToString() + "] LIKE '%" + cls_fhp.AvoidInjection(txtSEARCH.Text) + "%' OR ["
              + grdSEARCH.Columns[5].Name.ToString() + "] LIKE '%" + cls_fhp.AvoidInjection(txtSEARCH.Text) + "%' OR ["
              + grdSEARCH.Columns[7].Name.ToString() + "] LIKE '%" + cls_fhp.AvoidInjection(txtSEARCH.Text) + "%' OR ["
              + grdSEARCH.Columns[8].Name.ToString() + "] LIKE '%" + cls_fhp.AvoidInjection(txtSEARCH.Text) + "%' OR ["
              + grdSEARCH.Columns[9].Name.ToString() + "] LIKE '%" + cls_fhp.AvoidInjection(txtSEARCH.Text) + "%' OR ["
              + grdSEARCH.Columns[10].Name.ToString() + "] LIKE '%" + cls_fhp.AvoidInjection(txtSEARCH.Text) + "%' OR ["
              + grdSEARCH.Columns[11].Name.ToString() + "] LIKE '%" + cls_fhp.AvoidInjection(txtSEARCH.Text) + "%'");
            grdSEARCH.ClearSelection();
        }

        //grid search by bank account
        public void bvr_grid_search_bankAccount(string keyword, DataGridView grdSEARCH)
        {
            (grdSEARCH.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
            [" + grdSEARCH.Columns[5].Name.ToString() + "] like '%" + keyword + "%'");
            grdSEARCH.ClearSelection();
        }

        //load account nature combo box
        public void load_accounts(ComboBox cmbAccounts)
        {
            query = @"SELECT '0' AS [id],'--SELECT ACCOUNT--' AS [name]
            UNION ALL
            SELECT COA_ID,COA_NAME FROM COA WHERE CA_ID <> '6'";
            cls_fhp.LoadComboData(cmbAccounts, query);
        }

        //load bank accounts combo box
        public void load_bank_accounts(ComboBox cmbBankAccounts)
        {
            query = @"SELECT '0' AS [id],'--SELECT BANK ACCOUNT--' AS [name]
            UNION ALL
            SELECT COA_ID,COA_NAME FROM COA WHERE CA_ID = 2 and COA_NAME LIKE '%TAQWA%'";
            cls_fhp.LoadComboData(cmbBankAccounts, query);
        }

        //save group record in database
        public int save_crv_details(string save_query)
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
            query = "select count(BRV_ID)+1 from BANK_REC_VOUCHER";
            lbl.Text = "BRV-"+cls_fhp.generate_voucher_code(query)+"-"+DateTime.Now.Year;
        }

        //generate transaction no
        public void generate_transaction_no(Label lbl)
        {
            query = "select (count(LEGDER_ID)+1)+1000000 from LEDGERS";
            lbl.Text = cls_fhp.generate_voucher_code(query).ToString();
        }

        //insert ledger entry
        public int insert_ledger_entry(string date, int debit_coa_id, int credit_coa_id, string reference_id, string entry_of, float amount, string description,string code)
        {
            string query = @"IF EXISTS (SELECT REF_ID FROM LEDGERS WHERE REF_ID = '" + reference_id + @"')
                BEGIN
                DELETE FROM LEDGERS WHERE REF_ID = '" + reference_id + "' AND ENTRY_OF = '" + entry_of + @"'
                INSERT INTO LEDGERS VALUES('" + date + "', '" + debit_coa_id + @"',
                '" + reference_id + "', '" + entry_of + @"','"+code+@"',
                '" + amount + "','0','" + description + "','" + Classes.Helper.userId + @"',
                '" + DateTime.Now + @"',NULL,NULL,1,'00');
                INSERT INTO LEDGERS VALUES('" + date + "', '" + credit_coa_id + @"',
                '" + reference_id + "', '" + entry_of + @"','" + code + @"','0',
                '" + amount + "','" + description + "','" + Classes.Helper.userId + @"',
                '" + DateTime.Now + @"',NULL,NULL,1,'00');
                END
                ELSE
                BEGIN
                DELETE FROM LEDGERS WHERE REF_ID = '" + reference_id + "' AND ENTRY_OF = '" + entry_of + @"'
                INSERT INTO LEDGERS VALUES('" + date + "', '" + debit_coa_id + @"',
                (SELECT MAX(BRV_ID) FROM BANK_REC_VOUCHER),'" + entry_of + @"','" + code + @"',
                '" + amount + "','0','" + description + "','" + Classes.Helper.userId + @"',
                '" + DateTime.Now + @"',NULL,NULL,1,'00');
                INSERT INTO LEDGERS VALUES('" + date + "', '" + credit_coa_id + @"',
                (SELECT MAX(BRV_ID) FROM BANK_REC_VOUCHER),'" + entry_of + @"','" + code + @"','0',
                '" + amount + "','" + description + "','" + Classes.Helper.userId + @"',
                '" + DateTime.Now + @"',NULL,NULL,1,'00');
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
        public void get_head_bank_code(string Acode, string Bcode)
        {
            string[] codes = new string[2];
            string query = "select COA_CODE from COA WHERE COA_ID = '"+Acode+"' OR COA_ID = '"+Bcode+"'";
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
    }
}
