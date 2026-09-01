using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace ERP_Maaz_Oil.Classes
{
    class cls_Cash_Receipt
    {
        Classes.Helper cls_fhp = new Helper();
        string query = "";
        public string debit_code = "";
        public string credit_code = "";

        //load cvr grid
        public void load_cvr_grid(DataGridView dg)
        {
            query = @"
            SELECT A.CRV_ID,A.CRV_CODE AS [VOUCHER #],A.TRANS_CODE,CONVERT(varchar(MAX),A.DAATE) AS [DATE],A.COA_ID,B.COA_NAME AS [ACCOUNT],A.DESCRIPTION AS [ACCOUNT_OF],A.REC_FROM AS [RECIVED FROM],CONVERT(varchar(MAX),a.AMOUNT) as [AMOUNT],A.CRV_ID,C.COA_NAME AS [CASH ACCOUNT]
            FROM CASH_REC_VOUCHER A,COA B,COA C
            WHERE A.COA_ID = B.COA_ID AND A.COA_ID = C.COA_ID ORDER BY A.DAATE DESC";
            cls_fhp.LoadGrid(dg, query);
        }

        //grid search 
        public void cvr_grid_search(TextBox txtSEARCH, DataGridView grdSEARCH)
        {
            (grdSEARCH.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
            [" + grdSEARCH.Columns[1].Name.ToString() + "] LIKE '%" + cls_fhp.AvoidInjection(txtSEARCH.Text) + "%' OR ["
              + grdSEARCH.Columns[3].Name.ToString() + "] LIKE '%" + cls_fhp.AvoidInjection(txtSEARCH.Text) + "%' OR ["
              + grdSEARCH.Columns[5].Name.ToString() + "] LIKE '%" + cls_fhp.AvoidInjection(txtSEARCH.Text) + "%' OR ["
              + grdSEARCH.Columns[6].Name.ToString() + "] LIKE '%" + cls_fhp.AvoidInjection(txtSEARCH.Text) + "%' OR ["
              + grdSEARCH.Columns[7].Name.ToString() + "] LIKE '%" + cls_fhp.AvoidInjection(txtSEARCH.Text) + "%' OR ["
              + grdSEARCH.Columns[8].Name.ToString() + "] LIKE '%" + cls_fhp.AvoidInjection(txtSEARCH.Text) + "%'");
            grdSEARCH.ClearSelection();
        }

        //grid search cash and petty cash
        public void cvr_grid_search_cash_pettyCash(string keyword, DataGridView grdSEARCH)
        {
            (grdSEARCH.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
            [" + grdSEARCH.Columns[10].Name.ToString() + "] = '" + keyword + "'");
            grdSEARCH.ClearSelection();
        }

        //load cash accounts combo box
        public void load_cash_accounts(ComboBox cmbAccounts)
        {
            query = @"SELECT '0' AS [id],'--SELECT ACCOUNT--' AS [name]
            UNION ALL
            SELECT COA_ID,COA_NAME FROM COA WHERE CA_ID = '7'";
            cls_fhp.LoadComboData(cmbAccounts, query);
        }

        //load account nature combo box
        public void load_accounts(ComboBox cmbAccounts)
        {
            query = @"SELECT '0' AS [id],'--SELECT ACCOUNT--' AS [name]
            UNION ALL
            SELECT COA_ID,COA_NAME FROM COA WHERE CA_ID <> '7'";
            cls_fhp.LoadComboData(cmbAccounts, query);
        }

        //load invoice
        public void load_invoices(ComboBox cmbInvoices,string coa_id)
        {
            query = @"SELECT '0' AS [id],'--SELECT INVOICE--' AS [name]
            UNION ALL
            select SM_ID,INV_CODE from SALES_M WHERE (TOTAL - REC_AMT) <> 0 AND COA_ID = '"+coa_id+"'";
            cls_fhp.LoadComboData(cmbInvoices, query);
        }

        //load All invoice
        public void load_all_invoices(ComboBox cmbInvoices, string coa_id)
        {
            query = @"SELECT '0' AS [id],'--SELECT INVOICE--' AS [name]
            UNION ALL
            select SM_ID,INV_CODE from SALES_M WHERE COA_ID = '" + coa_id + "'";
            cls_fhp.LoadComboData(cmbInvoices, query);
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
            query = "select count(CRV_ID)+1 from CASH_REC_VOUCHER";
            lbl.Text = "CRV-"+cls_fhp.generate_voucher_code(query)+"-"+DateTime.Now.Year;
        }

        //generate transaction no
        public void generate_transaction_no(Label lbl)
        {
            query = "select (count(LEGDER_ID)+1)+1000000 from LEDGERS";
            lbl.Text = cls_fhp.generate_voucher_code(query).ToString();
        }

        //insert ledger entry
        public int insert_ledger_entry(string date, int credit_coa_id, int debit_coa_id, string reference_id, string entry_of, float amount, string description,string code,string refAcc)
        {
            string query = @"
                DELETE FROM LEDGERS WHERE REF_ID = " + reference_id + " AND ENTRY_OF = '" + entry_of + @"'
                IF EXISTS (SELECT REF_ID FROM LEDGERS WHERE REF_ID = " + reference_id + @")
                BEGIN
                INSERT INTO LEDGERS VALUES('" + date + "', '" + debit_coa_id + @"',
                " + reference_id + ", '" + entry_of + @"','"+code+@"',
                '" + amount + "','0','" + description + "','" + Classes.Helper.userId + @"',
                '" + DateTime.Now + @"',NULL,NULL,1,'" + refAcc + @"');
                INSERT INTO LEDGERS VALUES('" + date + "', '" + credit_coa_id + @"',
                " + reference_id + ", '" + entry_of + @"','" + code + @"','0',
                '" + amount + "','" + description + "','" + Classes.Helper.userId + @"',
                '" + DateTime.Now + @"',NULL,NULL,1,'" + refAcc + @"');
                END
                ELSE
                BEGIN
                DELETE FROM LEDGERS WHERE REF_ID = " + reference_id + " AND ENTRY_OF = '" + entry_of + @"'
                INSERT INTO LEDGERS VALUES('" + date + "', '" + debit_coa_id + @"',
                (SELECT MAX(CRV_ID) FROM CASH_REC_VOUCHER),'" + entry_of + @"','" + code + @"',
                '" + amount + "','0','" + description + "','" + Classes.Helper.userId + @"',
                '" + DateTime.Now + @"',NULL,NULL,1,'" + refAcc + @"');
                INSERT INTO LEDGERS VALUES('" + date + "', '" + credit_coa_id + @"',
                (SELECT MAX(CRV_ID) FROM CASH_REC_VOUCHER),'" + entry_of + @"','" + code + @"','0',
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
            debit_code = codes[0];
            credit_code = codes[1];
        }

        public void invoice_detail(string vou_code, ComboBox cmbInvoices, RadioButton rdbInvoices, RadioButton rdbOther)
        {
            string query = "SELECT INVOICE_NO FROM INVOICES_DETAILS WHERE VOUCHER_ID = '" + vou_code + "' AND PAY_OF = 'SALES'";
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
    }
}
