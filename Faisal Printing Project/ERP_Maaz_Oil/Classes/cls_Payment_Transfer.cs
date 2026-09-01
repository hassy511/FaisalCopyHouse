using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace ERP_Maaz_Oil.Classes
{
    class cls_Payment_Transfer
    {
        Classes.Helper cls_fhp = new Helper();

        //grid search 
        public void PTVGridSearch(string txtSEARCH, DataGridView grdSEARCH)
        {
            (grdSEARCH.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
            [" + grdSEARCH.Columns["REC ACCOUNT"].Name.ToString() + "] LIKE '%" + cls_fhp.AvoidInjection(txtSEARCH) + "%' OR ["
               + grdSEARCH.Columns["SUB ACCOUNT"].Name.ToString() + "] LIKE '%" + cls_fhp.AvoidInjection(txtSEARCH) + "%' OR["
               + grdSEARCH.Columns["REF AC"].Name.ToString() + "] LIKE '%" + cls_fhp.AvoidInjection(txtSEARCH) + "%' OR["
              + grdSEARCH.Columns["PAYMENT AC"].Name.ToString() + "] LIKE '%" + cls_fhp.AvoidInjection(txtSEARCH) + "%'");
            grdSEARCH.ClearSelection();
        }

        //load pt grid
        public void load_pt_grid(DataGridView dg,DateTime date)
        {
            cls_fhp.query = @"SELECT A.PT_ID,A.DATE,A.AMOUNT,A.REC_AC,B.COA_NAME AS [REC ACCOUNT],A.SUB_ACC as [SUB ACCOUNT],A.PAY_AC,C.COA_NAME AS [PAYMENT AC],
            '' AS REF_AC,A.REF_AC AS [REF AC],A.BANK,A.BR_CODE,A.INSTRUMENT_NO,A.CNIC,
            CASE WHEN A.STATUS = '0' THEN 'PENDING' ELSE 'APPROVED' END AS [STATUS],            
            CASE WHEN A.CHQ_ONLINE = 'C' THEN 'CHQ' ELSE 'ONLINE' END AS [CHQ_ONLINE],            
            A.CHQ_DATE,A.REMARKS,A.PV_NO,A.CHQ_ID
            FROM PAYMENT_TRANSFER A
            INNER JOIN COA B ON A.REC_AC = B.COA_ID
            INNER JOIN COA C ON A.PAY_AC = C.COA_ID
            WHERE A.DATE BETWEEN '" + date.Date + "' AND '" + date.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
            ORDER BY A.PT_ID DESC";
            cls_fhp.LoadGrid(dg, cls_fhp.query);
            dg.Columns["DATE"].Visible = false;
        }

        //grid search 
        public void cvr_grid_search(TextBox txtSEARCH, DataGridView grdSEARCH)
        {
            (grdSEARCH.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
            [" + grdSEARCH.Columns["REC ACCOUNT"].Name.ToString() + "] LIKE '%" + cls_fhp.AvoidInjection(txtSEARCH.Text) + "%' OR ["
              + grdSEARCH.Columns["SUB ACCOUNT"].Name.ToString() + "] LIKE '%" + cls_fhp.AvoidInjection(txtSEARCH.Text) + "%' OR ["
              + grdSEARCH.Columns["PAYMENT AC"].Name.ToString() + "] LIKE '%" + cls_fhp.AvoidInjection(txtSEARCH.Text) + "%' OR ["
              + grdSEARCH.Columns["BANK"].Name.ToString() + "] LIKE '%" + cls_fhp.AvoidInjection(txtSEARCH.Text) + "%' OR ["
              + grdSEARCH.Columns["REF AC"].Name.ToString() + "] LIKE '%" + cls_fhp.AvoidInjection(txtSEARCH.Text) + "%' OR ["
              + grdSEARCH.Columns["BR_CODE"].Name.ToString() + "] LIKE '%" + cls_fhp.AvoidInjection(txtSEARCH.Text) + "%' OR ["
              + grdSEARCH.Columns["STATUS"].Name.ToString() + "] LIKE '%" + cls_fhp.AvoidInjection(txtSEARCH.Text) + "%' OR ["
              + grdSEARCH.Columns["INSTRUMENT_NO"].Name.ToString() + "] LIKE '%" + cls_fhp.AvoidInjection(txtSEARCH.Text) + "%' ");
            grdSEARCH.ClearSelection();
        }

        //load accounts combo box
        public void load_accounts(ComboBox cmbAccounts)
        {
            cls_fhp.query = @"SELECT '0' AS [id],'--SELECT ACCOUNT--' as [name]
            UNION ALL
            SELECT COA_ID AS [id],COA_NAME AS [name] FROM COA ORDER BY [name]";
            cls_fhp.LoadComboData(cmbAccounts, cls_fhp.query);
        }

        //load accounts combo box
        public void load_ref_accounts(ComboBox cmbAccounts)
        {
            cls_fhp.query = @"SELECT '0' as [id],REF_AC as [name] FROM PAYMENT_TRANSFER
			GROUP BY REF_AC
            ORDER BY [name]";
            cls_fhp.LoadComboData(cmbAccounts, cls_fhp.query);
        }

        //load branch code combo box
        public void load_branch_code(ComboBox cmbBranchCode)
        {
            cls_fhp.query = @"select BR_CODE as [id],BR_CODE as [name] 
            from PAYMENT_TRANSFER group by BR_CODE order by [name]";
            cls_fhp.LoadComboData(cmbBranchCode, cls_fhp.query);
        }

        public void load_names(ComboBox cmbSub)
        {
            cls_fhp.query = @"SELECT '0' AS [id],'--SELECT ACCOUNT--' as [name]
            UNION ALL
            SELECT COA_ID AS [id],COA_NAME AS [name] FROM COA ORDER BY [name]";
            cls_fhp.LoadComboData(cmbSub, cls_fhp.query);
        }


        public void load_instruments(ComboBox cmbInstr)
        {
            cls_fhp.query = @"SELECT '0' as [id], '--SELECT INSTRUMENT--' as [name]
                    UNION ALL
            SELECT '0' as [id],INSTRUMENT_NO as [name] FROM PAYMENT_TRANSFER";
            cls_fhp.LoadComboData(cmbInstr, cls_fhp.query);

        }
        //load accounts combo box
        public void load_bank(ComboBox cmbAccounts)
        {
            cls_fhp.query = @"SELECT '0' as [id],BANK as [name] FROM PAYMENT_TRANSFER
			GROUP BY BANK
            ORDER BY [name]";
            cls_fhp.LoadComboData(cmbAccounts, cls_fhp.query);
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
            cls_fhp.query = "select (COUNT(PT_ID)+1) from PAYMENT_TRANSFER";
            lbl.Text = "PV-"+cls_fhp.generate_voucher_code(cls_fhp.query) +"-"+DateTime.Now.Year;
        }

        public void load_rec_grid(DataGridView dg,DateTime date)
        {
            cls_fhp.query = @"SELECT D.NAME AS [SALES PERSON],SUM(A.AMOUNT) AS TOTAL
            FROM PAYMENT_TRANSFER A
            INNER JOIN COA B ON A.REC_AC = B.COA_ID 
            INNER JOIN CUSTOMER_PROFILE C ON B.COA_ID = C.COA_ID
            INNER JOIN SALES_PERSONS D ON C.SALE_PER_ID = D.SALES_PER_ID
            WHERE A.DATE BETWEEN '" + date.ToShortDateString() + @" 00:00:00 AM' AND '"+date.ToShortDateString()+@" 23:59:59 PM'
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
            FROM PAYMENT_TRANSFER A
            INNER JOIN COA B ON A.PAY_AC = B.COA_ID          
            WHERE A.DATE BETWEEN '" + date.ToShortDateString() + @" 00:00:00 AM' AND '" + date.ToShortDateString() + @" 23:59:59 PM'
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

    }
}
