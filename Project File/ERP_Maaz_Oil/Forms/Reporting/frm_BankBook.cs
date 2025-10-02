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
    public partial class frm_BankBook : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        decimal openingBalance = 0;
        decimal closingBalance = 0;

        public frm_BankBook()
        {
            InitializeComponent();
        }

        private void load_account()
        {
            classHelper.query = @"SELECT '0' AS [id],'--ALL--' as [name]
            UNION ALL
            SELECT COA_ID AS [id],COA_NAME AS [name] FROM COA WHERE CA_ID = 5 ORDER BY [name]";
            classHelper.LoadComboData(cmbACCOUNT, classHelper.query);
        }

        private void opening_bal()
        {
            if (cmbACCOUNT.SelectedValue.ToString().Equals("0"))
            {
                classHelper.query = @"SELECT ISNULL(ISNULL((SUM(DEBIT)-SUM(CREDIT)),0) + 
                (SELECT SUM(OPEN_BAL)
                FROM COA WHERE COA_ID IN (SELECT COA_ID FROM COA WHERE CA_ID = 5)),0) AS [OPENING]
                FROM LEDGERS WHERE COA_ID IN (SELECT COA_ID FROM COA WHERE CA_ID = 5) AND DATE < '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "'";
            }
            else
            {
                classHelper.query = @"SELECT ISNULL(ISNULL((SUM(DEBIT)-SUM(CREDIT)),0) + 
                (SELECT SUM(OPEN_BAL)
                FROM COA WHERE COA_ID IN ('" + cmbACCOUNT.SelectedValue.ToString() + @"')),0) AS [OPENING]
                FROM LEDGERS WHERE COA_ID IN ('" + cmbACCOUNT.SelectedValue.ToString() + @"') AND DATE < '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "'";
            }
            Classes.Helper.conn.Open();
            try
            {
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    if (classHelper.dr.Read())
                    {
                        openingBalance = Convert.ToDecimal(classHelper.dr["OPENING"].ToString());
                        closingBalance = openingBalance;
                        grdSEARCH.Rows.Add("", "", "BALANCE BROUGHT FORWARDED", "", "", 0, 0, Convert.ToDecimal(classHelper.dr["OPENING"].ToString()),"");
                    }
                }
                else {
                    grdSEARCH.Rows.Add("", "", "BALANCE BROUGHT FORWARDED", "", "", 0, 0, 0,"");
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

        public void ledger_Entry()
        {
            classHelper.query = @"
                 SELECT * FROM ( SELECT FORMAT(A.DATE,'dd-MMM-yyyy') as date,B.COA_NAME as [recAcc],C.COA_NAME as [payAcc],A.REF_AC as [refAcc],A.AMOUNT,ISNULL(A.CHQ_ID,'-') as CHQ_NO,A.INSTRUMENT as [SLIP],
                'BV-'+CONVERT(varchar(20),A.BB_ID)  as [refNo],C.COA_ID,A.NARRATION
                FROM BANK_BOOK A
                INNER JOIN COA B ON A.REC_AC = B.COA_ID
                INNER JOIN COA C ON A.PAY_AC = C.COA_ID
				
				UNION ALL

				SELECT FORMAT(A.DATE,'dd-MMM-yyyy')  as date,B.COA_NAME as [recAcc],C.COA_NAME as [payAcc],A.REF_AC as [refAcc],A.AMOUNT,'-' as CHQ_NO,'-' as [SLIP],
				A.PV_NO  as [refNo],C.COA_ID,A.REMARKS
				FROM PAYMENT_TRANSFER A
				INNER JOIN COA B ON A.REC_AC = B.COA_ID
				INNER JOIN COA C ON A.PAY_AC = C.COA_ID
				WHERE B.AG_ID in (10,9) and C.AG_ID in (10,9) AND A.STATUS = 1 AND B.CA_ID = 5 AND C.CA_ID = 5
				
				UNION ALL

				--SELECT Convert(varchar(max),FORMAT(A.DAATE,'dd-MMM-yyyy'))  as date,'CASH IN HAND' as [recAcc],B.COA_NAME as [payAcc],A.REF_ACCOUNT as [refAcc],A.AMOUNT,'-' as CHQ_NO,'-' as [SLIP],
				--A.CPV_CODE as [refNo],B.COA_ID,A.ACCOUNT_OF
				--FROM CASH_PAY_VOUCHER A
				--INNER JOIN COA B ON A.COA_ID = B.COA_ID
				--WHERE B.AG_ID in (10,9) AND B.CA_ID = 5

				--UNION ALL

				--SELECT Convert(varchar(max),FORMAT(A.DAATE,'dd-MMM-yyyy'))  as date,B.COA_NAME as [recAcc],'CASH IN HAND' as [payAcc],A.REF_ACCOUNT as [refAcc],A.AMOUNT,'-' as CHQ_NO,'-' as [SLIP],
				--A.CRV_CODE as [refNo],B.COA_ID,A.DESCRIPTION
				--FROM CASH_REC_VOUCHER A
				--INNER JOIN COA B ON A.COA_ID = B.COA_ID
				--WHERE B.AG_ID in (10,9) AND B.CA_ID = 5

				--UNION ALL

    	        SELECT FORMAT(A.DATE,'dd-MMM-yyyy')  as date,C.COA_NAME as [recAcc],B.COA_NAME as [payAcc],'-' as [refAcc],A.AMOUMT,F.CHQ_NO as CHQ_NO,'-' as [SLIP],	
				LD.FOLIO as [refNo]
				,C.COA_ID,A.DESCRIPTION
				FROM DAY_BOOK A
				LEFT JOIN DAY_BOOK_CHQ D ON A.DAY_BOOK_ID = D.DAY_BOOK_ID
				LEFT JOIN CHQ F ON D.CHQ_ID = F.CHQ_ID				
				LEFT JOIN COA B ON A.DEBIT_AC = B.COA_ID
				LEFT JOIN COA C ON F.REC_AC = C.COA_ID
                INNER JOIN LEDGERS LD ON LD.REF_ID = A.DAY_BOOK_ID AND (LD.ENTRY_OF = 'PAYMENT VOUCHER' OR LD.ENTRY_OF = 'RECEIPT VOUCHER') AND LD.DEBIT <> 0
				WHERE --F.PAY_DATE is null AND
                B.AG_ID in (10,9) AND B.CA_ID = 5 OR (C.AG_ID in (10,9) and C.CA_ID = 5)
                GROUP BY FORMAT(A.DATE,'dd-MMM-yyyy'),C.COA_NAME,B.COA_NAME,A.AMOUMT,F.CHQ_NO,LD.FOLIO,C.COA_ID,A.[DESCRIPTION]


                UNION ALL

                -- JOURNAL VOUCHER
				-- SELECT FORMAT(A.DAATE,'dd-MMM-yyyy')  as date,	
	            -- (SELECT COA_NAME FROM COA WHERE COA_ID = 
	            -- (SELECT gv.COA_ID FROM GENERAL_VOUCHER_D gv where gv.GV_ID = A.gv_ID
	            -- AND gv.DEBIT = 0
	            -- )) as [recAcc],
	            -- C.COA_NAME as [payAcc],'-' as [refAcc],
                -- CASE WHEN B.DEBIT<> 0 THEN B.DEBIT
                -- WHEN B.CREDIT <> 0 THEN B.CREDIT
                -- END as AMOUNT
                -- ,'-' as CHQ_NO,'-' as [SLIP],
	            -- A.GV_CODE as [refNo],B.COA_ID,A.NARRATION
	            -- FROM GENERAL_VOUCHER_M A
	            -- INNER JOIN GENERAL_VOUCHER_D B ON A.GV_ID = B.GV_ID
	            -- INNER JOIN COA C ON B.COA_ID = C.COA_ID
                -- WHERE C.AG_ID in (10,9) AND C.CA_ID = 5

                --UNION ALL

                 --REC CASH
                SELECT FORMAT(A.DATE,'dd-MMM-yyyy') as Date,'CASH IN HAND' as [recAcc],B.COA_NAME as [payAcc],ISNULL(A.REF_AC_ID,'-') as [refAcc]
                ,A.DEBIT as [Amount], '-' as CHQ_NO,'-' as [SLIP],A.FOLIO as [refNo],A.COA_ID,A.DESCRIPTIONS
                FROM LEDGERS A 
                INNER JOIN COA B ON A.COA_ID = B.COA_ID
                INNER JOIN (
	                SELECT REF_ID,ENTRY_OF,FOLIO FROM LEDGERS WHERE COA_ID = "+Classes.Helper.cashId+@"
                ) C ON A.REF_ID = C.REF_ID AND A.ENTRY_OF = C.ENTRY_OF
                WHERE A.COA_ID <> "+Classes.Helper.cashId+@" AND A.DEBIT <> 0 AND B.CA_ID = 5  

                UNION ALL

                --PAID CASH
                SELECT FORMAT(A.DATE,'dd-MMM-yyyy') as Date,B.COA_NAME as [recAcc],'CASH IN HAND' as [payAcc],ISNULL(A.REF_AC_ID,'-') as [refAcc]
                ,A.CREDIT as [Amount], '-' as CHQ_NO,'-' as [SLIP],A.FOLIO as [refNo],A.COA_ID,A.DESCRIPTIONS
                FROM LEDGERS A 
                INNER JOIN COA B ON A.COA_ID = B.COA_ID
                INNER JOIN (
	                SELECT REF_ID,ENTRY_OF,FOLIO FROM LEDGERS WHERE COA_ID = "+Classes.Helper.cashId+@"
                ) C ON A.REF_ID = C.REF_ID AND A.ENTRY_OF = C.ENTRY_OF
                WHERE A.COA_ID <> "+Classes.Helper.cashId+@" AND A.CREDIT <> 0 AND B.CA_ID = 5


				) A

                WHERE FORMAT(CONVERT(Datetime,A.DATE),'yyyy-MM-dd') BETWEEN '" + dtp_FROM.Value.Date.ToString("yyyy-MM-dd") + "' and '" +
                (dtp_TO.Value == dtp_FROM.Value ? dtp_TO.Value.Date.AddDays(0).ToString("yyyy-MM-dd") : dtp_TO.Value.ToString("yyyy-MM-dd")) + "'";


            if (!cmbACCOUNT.SelectedValue.ToString().Equals("0"))
            {
                classHelper.query += " and A.COA_ID = '"+cmbACCOUNT.SelectedValue.ToString()+"'";
            }

            classHelper.query += " ORDER BY FORMAT(CONVERT(Datetime,A.DATE),'yyyy-MM-dd'),A.recAcc ";

            classHelper.LoadGrid(grdSEARCH, classHelper.query);


            classHelper.query = @"

                WITH X AS (
                SELECT * FROM ( 
	                SELECT Convert(varchar(max),FORMAT(A.DATE,'dd-MMM-yyyy')) as date,B.COA_NAME as [recAcc],C.COA_NAME as [payAcc],A.REF_AC as [refAcc],A.AMOUNT,ISNULL(A.CHQ_ID,'-') as CHQ_NO,A.INSTRUMENT as [SLIP],
	                'BV-'+CONVERT(varchar(20),A.BB_ID)  as [refNo],C.COA_ID,A.NARRATION
	                FROM BANK_BOOK A
	                INNER JOIN COA B ON A.REC_AC = B.COA_ID
	                INNER JOIN COA C ON A.PAY_AC = C.COA_ID
                UNION ALL
	                SELECT Convert(varchar(max),FORMAT(A.DATE,'dd-MMM-yyyy'))  as date,B.COA_NAME as [recAcc],C.COA_NAME as [payAcc],A.REF_AC as [refAcc],A.AMOUNT,'-' as CHQ_NO,'-' as [SLIP],
	                A.PV_NO  as [refNo],C.COA_ID,A.REMARKS
	                FROM PAYMENT_TRANSFER A
	                INNER JOIN COA B ON A.REC_AC = B.COA_ID
	                INNER JOIN COA C ON A.PAY_AC = C.COA_ID
	                WHERE B.AG_ID in (10,9) and C.AG_ID in (10,9) AND A.STATUS = 1 AND B.CA_ID = 5 AND C.CA_ID = 5
                UNION ALL
	            --SELECT Convert(varchar(max),FORMAT(A.DAATE,'dd-MMM-yyyy'))  as date,'CASH IN HAND' as [recAcc],B.COA_NAME as [payAcc],A.REF_ACCOUNT as [refAcc],A.AMOUNT,'-' as CHQ_NO,'-' as [SLIP],
				--A.CPV_CODE as [refNo],B.COA_ID,A.ACCOUNT_OF
				--FROM CASH_PAY_VOUCHER A
				--INNER JOIN COA B ON A.COA_ID = B.COA_ID
				--WHERE B.AG_ID in (10,9) AND B.CA_ID = 5

				--UNION ALL

				--SELECT Convert(varchar(max),FORMAT(A.DAATE,'dd-MMM-yyyy'))  as date,B.COA_NAME as [recAcc],'CASH IN HAND' as [payAcc],A.REF_ACCOUNT as [refAcc],A.AMOUNT,'-' as CHQ_NO,'-' as [SLIP],
				--A.CRV_CODE as [refNo],B.COA_ID,A.DESCRIPTION
				--FROM CASH_REC_VOUCHER A
				--INNER JOIN COA B ON A.COA_ID = B.COA_ID
				--WHERE B.AG_ID in (10,9) AND B.CA_ID = 5
                --UNION ALL
	                  SELECT Convert(varchar(max),FORMAT(A.DATE,'dd-MMM-yyyy'))  as date,C.COA_NAME as [recAcc],B.COA_NAME as [payAcc],'-' as [refAcc],A.AMOUMT,F.CHQ_NO as CHQ_NO,'-' as [SLIP],	
				    'PV-'+ Convert(varchar(20),A.DAY_BOOK_ID) +'-2020' as [refNo]
				    ,C.COA_ID,A.DESCRIPTION
				    FROM DAY_BOOK A
				    LEFT JOIN DAY_BOOK_CHQ D ON A.DAY_BOOK_ID = D.DAY_BOOK_ID
				    LEFT JOIN CHQ F ON D.CHQ_ID = F.CHQ_ID				
				    LEFT JOIN COA B ON A.DEBIT_AC = B.COA_ID
				    LEFT JOIN COA C ON F.REC_AC = C.COA_ID
				    WHERE --F.PAY_DATE is null AND
                    B.AG_ID in (10,9) AND B.CA_ID = 5 OR (C.AG_ID in (10,9) and C.CA_ID = 5)
                UNION ALL
	                SELECT Convert(varchar(max),FORMAT(A.DAATE,'dd-MMM-yyyy'))  as date,'CASH IN HAND' as [recAcc],C.COA_NAME as [payAcc],'-' as [refAcc],
	                CASE WHEN B.DEBIT<> 0 THEN B.DEBIT
	                WHEN B.CREDIT <> 0 THEN B.CREDIT
	                END as AMOUNT
	                ,'-' as CHQ_NO,'-' as [SLIP],
	                A.GV_CODE as [refNo],B.COA_ID,A.NARRATION
	                FROM GENERAL_VOUCHER_M A
	                INNER JOIN GENERAL_VOUCHER_D B ON A.GV_ID = B.GV_ID
	                INNER JOIN COA C ON B.COA_ID = C.COA_ID
	                WHERE C.AG_ID in (10,9) AND C.CA_ID = 5
                    UNION ALL
                    --REC CASH
                SELECT Convert(varchar(max),FORMAT(A.DATE,'dd-MMM-yyyy')) as Date,'CASH IN HAND' as [recAcc],B.COA_NAME as [payAcc],ISNULL(A.REF_AC_ID,'-') as [refAcc]
                ,A.DEBIT as [Amount], '-' as CHQ_NO,'-' as [SLIP],A.FOLIO as [refNo],A.COA_ID,A.DESCRIPTIONS
                FROM LEDGERS A 
                INNER JOIN COA B ON A.COA_ID = B.COA_ID
                INNER JOIN (
	                SELECT REF_ID,ENTRY_OF,FOLIO FROM LEDGERS WHERE COA_ID = "+Classes.Helper.cashId+@"
                ) C ON A.REF_ID = C.REF_ID AND A.ENTRY_OF = C.ENTRY_OF
                WHERE A.COA_ID <> "+Classes.Helper.cashId+@" AND A.DEBIT <> 0 AND B.CA_ID = 5  

                UNION ALL

                --PAID CASH
                SELECT Convert(varchar(max),FORMAT(A.DATE,'dd-MMM-yyyy')) as Date,B.COA_NAME as [recAcc],'CASH IN HAND' as [payAcc],ISNULL(A.REF_AC_ID,'-') as [refAcc]
                ,A.CREDIT as [Amount], '-' as CHQ_NO,'-' as [SLIP],A.FOLIO as [refNo],A.COA_ID,A.DESCRIPTIONS
                FROM LEDGERS A 
                INNER JOIN COA B ON A.COA_ID = B.COA_ID
                INNER JOIN (
	                SELECT REF_ID,ENTRY_OF,FOLIO FROM LEDGERS WHERE COA_ID = "+Classes.Helper.cashId+@"
                ) C ON A.REF_ID = C.REF_ID AND A.ENTRY_OF = C.ENTRY_OF
                WHERE A.COA_ID <> "+Classes.Helper.cashId+@" AND A.CREDIT <> 0 AND B.CA_ID = 5

                ) A

                WHERE FORMAT(CONVERT(Datetime,A.DATE),'yyyy-MM-dd') BETWEEN '" + dtp_FROM.Value.Date.ToString("yyyy-MM-dd") + "' and '" +
                (dtp_TO.Value == dtp_FROM.Value ? dtp_TO.Value.Date.AddDays(0).ToString("yyyy-MM-dd") : dtp_TO.Value.ToString("yyyy-MM-dd")) + @"')

                SELECT payAcc,sum(AMOUNT) as TOTAL FROM X group by payAcc

";
            try
            {
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    classHelper.nds.Tables["PayAccountSummary"].Clear();
                    while (classHelper.dr.Read())
                    {
                        classHelper.dataR = classHelper.nds.Tables["PayAccountSummary"].NewRow();
                        classHelper.dataR["payAcc"] = classHelper.dr["payAcc"].ToString();
                        classHelper.dataR["amount"] = Convert.ToDouble(classHelper.dr["TOTAL"].ToString());
                        classHelper.nds.Tables["PayAccountSummary"].Rows.Add(classHelper.dataR);
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

            classHelper.query = @"
            
                WITH X AS (
                SELECT * FROM ( 
	                SELECT Convert(varchar(max),FORMAT(A.DATE,'dd-MMM-yyyy')) as date,B.COA_NAME as [recAcc],C.COA_NAME as [payAcc],A.REF_AC as [refAcc],A.AMOUNT,ISNULL(A.CHQ_ID,'-') as CHQ_NO,A.INSTRUMENT as [SLIP],
	                'BV-'+CONVERT(varchar(20),A.BB_ID)  as [refNo],C.COA_ID,A.NARRATION
	                FROM BANK_BOOK A
	                INNER JOIN COA B ON A.REC_AC = B.COA_ID
	                INNER JOIN COA C ON A.PAY_AC = C.COA_ID
                UNION ALL
	                SELECT Convert(varchar(max),FORMAT(A.DATE,'dd-MMM-yyyy'))  as date,B.COA_NAME as [recAcc],C.COA_NAME as [payAcc],A.REF_AC as [refAcc],A.AMOUNT,'-' as CHQ_NO,'-' as [SLIP],
	                A.PV_NO  as [refNo],C.COA_ID,A.REMARKS
	                FROM PAYMENT_TRANSFER A
	                INNER JOIN COA B ON A.REC_AC = B.COA_ID
	                INNER JOIN COA C ON A.PAY_AC = C.COA_ID
	                WHERE B.AG_ID in (10,9) and C.AG_ID in (10,9) AND A.STATUS = 1 AND B.CA_ID = 5 AND C.CA_ID = 5
                UNION ALL
	                --SELECT Convert(varchar(max),FORMAT(A.DAATE,'dd-MMM-yyyy'))  as date,'CASH IN HAND' as [recAcc],B.COA_NAME as [payAcc],A.REF_ACCOUNT as [refAcc],A.AMOUNT,'-' as CHQ_NO,'-' as [SLIP],
				    --A.CPV_CODE as [refNo],B.COA_ID,A.ACCOUNT_OF
				    --FROM CASH_PAY_VOUCHER A
				    --INNER JOIN COA B ON A.COA_ID = B.COA_ID
				    --WHERE B.AG_ID in (10,9) AND B.CA_ID = 5

				--UNION ALL

				    --SELECT Convert(varchar(max),FORMAT(A.DAATE,'dd-MMM-yyyy'))  as date,B.COA_NAME as [recAcc],'CASH IN HAND' as [payAcc],A.REF_ACCOUNT as [refAcc],A.AMOUNT,'-' as CHQ_NO,'-' as [SLIP],
				    --A.CRV_CODE as [refNo],B.COA_ID,A.DESCRIPTION
				    --FROM CASH_REC_VOUCHER A
				    --INNER JOIN COA B ON A.COA_ID = B.COA_ID
				    --WHERE B.AG_ID in (10,9) AND B.CA_ID = 5
                --UNION ALL
	                  SELECT Convert(varchar(max),FORMAT(A.DATE,'dd-MMM-yyyy'))  as date,C.COA_NAME as [recAcc],B.COA_NAME as [payAcc],'-' as [refAcc],A.AMOUMT,F.CHQ_NO as CHQ_NO,'-' as [SLIP],	
				    'PV-'+ Convert(varchar(20),A.DAY_BOOK_ID) +'-2020' as [refNo]
				    ,C.COA_ID,A.DESCRIPTION
				    FROM DAY_BOOK A
				    LEFT JOIN DAY_BOOK_CHQ D ON A.DAY_BOOK_ID = D.DAY_BOOK_ID
				    LEFT JOIN CHQ F ON D.CHQ_ID = F.CHQ_ID				
				    LEFT JOIN COA B ON A.DEBIT_AC = B.COA_ID
				    LEFT JOIN COA C ON F.REC_AC = C.COA_ID
				    WHERE --F.PAY_DATE is null AND
                    B.AG_ID in (10,9) AND B.CA_ID = 5 OR (C.AG_ID in (10,9) and C.CA_ID = 5)
                UNION ALL
	                SELECT Convert(varchar(max),FORMAT(A.DAATE,'dd-MMM-yyyy'))  as date,'CASH IN HAND' as [recAcc],C.COA_NAME as [payAcc],'-' as [refAcc],
	                CASE WHEN B.DEBIT<> 0 THEN B.DEBIT
	                WHEN B.CREDIT <> 0 THEN B.CREDIT
	                END as AMOUNT
	                ,'-' as CHQ_NO,'-' as [SLIP],
	                A.GV_CODE as [refNo],B.COA_ID,A.NARRATION
	                FROM GENERAL_VOUCHER_M A
	                INNER JOIN GENERAL_VOUCHER_D B ON A.GV_ID = B.GV_ID
	                INNER JOIN COA C ON B.COA_ID = C.COA_ID
	                WHERE C.AG_ID in (10,9) AND C.CA_ID = 5

                    UNION ALL

                --REC CASH
                SELECT Convert(varchar(max),FORMAT(A.DATE,'dd-MMM-yyyy')) as Date,'CASH IN HAND' as [recAcc],B.COA_NAME as [payAcc],ISNULL(A.REF_AC_ID,'-') as [refAcc]
                ,A.DEBIT as [Amount], '-' as CHQ_NO,'-' as [SLIP],A.FOLIO as [refNo],A.COA_ID,A.DESCRIPTIONS
                FROM LEDGERS A 
                INNER JOIN COA B ON A.COA_ID = B.COA_ID
                INNER JOIN (
	                SELECT REF_ID,ENTRY_OF,FOLIO FROM LEDGERS WHERE COA_ID = "+Classes.Helper.cashId+@"
                ) C ON A.REF_ID = C.REF_ID AND A.ENTRY_OF = C.ENTRY_OF
                WHERE A.COA_ID <> "+Classes.Helper.cashId+@" AND A.DEBIT <> 0 AND B.CA_ID = 5  

                UNION ALL

                --PAID CASH
                SELECT Convert(varchar(max),FORMAT(A.DATE,'dd-MMM-yyyy')) as Date,B.COA_NAME as [recAcc],'CASH IN HAND' as [payAcc],ISNULL(A.REF_AC_ID,'-') as [refAcc]
                ,A.CREDIT as [Amount], '-' as CHQ_NO,'-' as [SLIP],A.FOLIO as [refNo],A.COA_ID,A.DESCRIPTIONS
                FROM LEDGERS A 
                INNER JOIN COA B ON A.COA_ID = B.COA_ID
                INNER JOIN (
	                SELECT REF_ID,ENTRY_OF,FOLIO FROM LEDGERS WHERE COA_ID = "+Classes.Helper.cashId+@"
                ) C ON A.REF_ID = C.REF_ID AND A.ENTRY_OF = C.ENTRY_OF
                WHERE A.COA_ID <> "+Classes.Helper.cashId+@" AND A.CREDIT <> 0 AND B.CA_ID = 5

                ) A

                WHERE FORMAT(CONVERT(Datetime,A.DATE),'yyyy-MM-dd') BETWEEN  '" + dtp_FROM.Value.Date.ToString("yyyy-MM-dd") + "' and '" +
                (dtp_TO.Value == dtp_FROM.Value ? dtp_TO.Value.Date.AddDays(0).ToString("yyyy-MM-dd") : dtp_TO.Value.ToString("yyyy-MM-dd")) + @"')

            SELECT recAcc,sum(AMOUNT) as TOTAL FROM X group by recAcc 

         ";
            try
            {
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    classHelper.nds.Tables["RecAccountSummary"].Clear();
                    while (classHelper.dr.Read())
                    {
                        classHelper.dataR = classHelper.nds.Tables["RecAccountSummary"].NewRow();
                        classHelper.dataR["recAcc"] = classHelper.dr["recAcc"].ToString();
                        classHelper.dataR["amount"] = Convert.ToDouble(classHelper.dr["TOTAL"].ToString());
                        classHelper.nds.Tables["RecAccountSummary"].Rows.Add(classHelper.dataR);
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


            //if (cmbACCOUNT.SelectedValue.ToString().Equals("0"))
            //{
            //    classHelper.query = @"SELECT CASE WHEN A.CREDIT > 0 THEN 'BV-'+CONVERT(varchar(100),A.REF_ID) ELSE 'BV-'+CONVERT(varchar(100),A.REF_ID) END AS [ID],C.CA_NAME AS [ACCOUNT TYPE],
            //    B.COA_NAME AS [ACCOUNT NAME],
            //    isnull(A.REF_AC_ID,'') AS [REF ACCOUNT],
            //    A.DESCRIPTIONS AS [NARRATION],A.CREDIT AS [RECEIVED],A.DEBIT AS [PAYMENTS],FORMAT(A.DATE,'dd-MMMM-yyyy') AS [DATE],A.REF_ID
            //    FROM LEDGERS A
            //    INNER JOIN COA B ON A.COA_ID = B.COA_ID
            //    INNER JOIN CONTROL_ACCOUNT C ON B.CA_ID = C.CA_ID
            //    INNER JOIN (
            //    SELECT DISTINCT REF_ID FROM LEDGERS WHERE --COA_ID IN (SELECT COA_ID FROM COA WHERE CA_ID = 5) AND 
            //    DATE BETWEEN '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
            //    ) D ON A.REF_ID = D.REF_ID
            //    WHERE A.COA_ID NOT IN (SELECT COA_ID FROM COA WHERE CA_ID = 5) and A.ENTRY_OF = 'BANK BOOK'
            //    ORDER BY A.DATE,REF_ID,[ACCOUNT TYPE]";
            //}
            //else {
            //    classHelper.query = @"SELECT CASE WHEN A.CREDIT > 0 THEN 'BV-'+CONVERT(varchar(100),A.REF_ID) ELSE 'BV-'+CONVERT(varchar(100),A.REF_ID) END AS [ID],C.CA_NAME AS [ACCOUNT TYPE],
            //    B.COA_NAME AS [ACCOUNT NAME],
            //    isnull(A.REF_AC_ID,'') AS [REF ACCOUNT],
            //    A.DESCRIPTIONS AS [NARRATION],A.CREDIT AS [RECEIVED],A.DEBIT AS [PAYMENTS],FORMAT(A.DATE,'dd-MMMM-yyyy') AS [DATE],A.REF_ID
            //    FROM LEDGERS A
            //    INNER JOIN COA B ON A.COA_ID = B.COA_ID
            //    INNER JOIN CONTROL_ACCOUNT C ON B.CA_ID = C.CA_ID
            //    INNER JOIN (
            //    SELECT REF_ID FROM LEDGERS WHERE COA_ID IN ('"+ cmbACCOUNT.SelectedValue.ToString() + @"') AND DATE BETWEEN '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
            //    ) D ON A.REF_ID = D.REF_ID
            //    WHERE A.COA_ID NOT IN ('" + cmbACCOUNT.SelectedValue.ToString() + @"') and A.ENTRY_OF = 'BANK BOOK'
            //    ORDER BY A.DATE,REF_ID,[ACCOUNT TYPE]";
            //}

            //Classes.Helper.conn.Open();
            //try
            //{
            //    classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
            //    classHelper.dr = classHelper.cmd.ExecuteReader();
            //    if (classHelper.dr.HasRows == true)
            //    {
            //        closingBalance = 0;
            //        while (classHelper.dr.Read())
            //        {
            //            grdSEARCH.Rows.Add(classHelper.dr["ID"].ToString(), classHelper.dr["ACCOUNT TYPE"].ToString(), 
            //            classHelper.dr["ACCOUNT NAME"].ToString(), classHelper.dr["REF ACCOUNT"].ToString(),
            //            classHelper.dr["NARRATION"].ToString(), classHelper.dr["RECEIVED"].ToString(), classHelper.dr["PAYMENTS"].ToString(), 
            //            closingBalance+Convert.ToDecimal(classHelper.dr["RECEIVED"].ToString())- Convert.ToDecimal(classHelper.dr["PAYMENTS"].ToString()),
            //            classHelper.dr["DATE"].ToString());
            //            closingBalance = closingBalance + Convert.ToDecimal(classHelper.dr["RECEIVED"].ToString()) - Convert.ToDecimal(classHelper.dr["PAYMENTS"].ToString());
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //finally
            //{
            //    Classes.Helper.conn.Close();
            //}
        }

        public void ReceiptsData()
        {
            //classHelper.query = @"SELECT 
            //ISNULL((SELECT NAME FROM SALES_PERSONS WHERE SALES_PER_ID = 
            //(SELECT SALE_PER_ID FROM CUSTOMER_PROFILE WHERE COA_ID = A.COA_ID)),'OTHER') AS [SALES PERSON],
            //B.COA_NAME AS [ACCOUNT NAME],
            //SUM(A.CREDIT) AS [RECEIVED]
            //FROM LEDGERS A
            //INNER JOIN COA B ON A.COA_ID = B.COA_ID
            //INNER JOIN (
            //SELECT REF_ID FROM LEDGERS WHERE COA_ID = 5180 AND DATE BETWEEN '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
            //) D ON A.REF_ID = D.REF_ID
            //WHERE A.COA_ID <> 5180 AND A.DEBIT = 0
            //GROUP BY B.COA_NAME,A.COA_ID";

            classHelper.query = @"WITH A AS (
            SELECT 
            ISNULL((SELECT NAME FROM SALES_PERSONS WHERE SALES_PER_ID = 
            (SELECT SALE_PER_ID FROM CUSTOMER_PROFILE WHERE COA_ID = A.COA_ID)),'OTHER') AS [SALES PERSON],
            B.COA_NAME AS [ACCOUNT NAME],
            SUM(A.CREDIT) AS [RECEIVED]
            FROM LEDGERS A
            INNER JOIN COA B ON A.COA_ID = B.COA_ID
            INNER JOIN (
            SELECT REF_ID FROM LEDGERS WHERE COA_ID = 5180 AND DATE BETWEEN '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
            ) D ON A.REF_ID = D.REF_ID
            WHERE A.COA_ID <> 5180 AND A.DEBIT = 0
            GROUP BY B.COA_NAME,A.COA_ID)

            SELECT A.[SALES PERSON],SUM(A.RECEIVED) AS [RECEIVED] FROM A GROUP BY A.[SALES PERSON]";
            Classes.Helper.conn.Open();
            try
            {
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    classHelper.nds.Tables["CashBookReceipts"].Clear();
                    while (classHelper.dr.Read())
                    {
                        classHelper.dataR = classHelper.nds.Tables["CashBookReceipts"].NewRow();
                        classHelper.dataR["accountName"] = classHelper.dr["SALES PERSON"].ToString();
                        classHelper.dataR["amount"] = Convert.ToDouble(classHelper.dr["RECEIVED"].ToString());
                        classHelper.nds.Tables["CashBookReceipts"].Rows.Add(classHelper.dataR);
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

        public void PaymentData()
        {
            classHelper.query = @"SELECT B.COA_NAME AS [ACCOUNT NAME],
            SUM(A.DEBIT) AS [PAYMENTS]
            FROM LEDGERS A
            INNER JOIN COA B ON A.COA_ID = B.COA_ID
            INNER JOIN (
            SELECT REF_ID FROM LEDGERS WHERE COA_ID = 5180 AND DATE BETWEEN '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
            ) D ON A.REF_ID = D.REF_ID
            WHERE A.COA_ID <> 5180  AND A.CREDIT = 0
            GROUP BY B.COA_NAME";
            Classes.Helper.conn.Open();
            try
            {
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    classHelper.nds.Tables["CashBookPayments"].Clear();
                    while (classHelper.dr.Read())
                    {
                        classHelper.dataR = classHelper.nds.Tables["CashBookPayments"].NewRow();
                        classHelper.dataR["accountName"] = classHelper.dr["ACCOUNT NAME"].ToString();
                        classHelper.dataR["amount"] = Convert.ToDouble(classHelper.dr["PAYMENTS"].ToString());
                        classHelper.nds.Tables["CashBookPayments"].Rows.Add(classHelper.dataR);
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

        private void ReportData()
        {
            char hasRows = 'N';
            try
            {
                if (grdSEARCH.Rows.Count > 0)
                {
                    
                    classHelper.nds.Tables["BankBook"].Clear();
                    foreach (DataGridViewRow row in grdSEARCH.Rows)
                    {
                        hasRows = 'Y';
                        classHelper.dataR = classHelper.nds.Tables["BankBook"].NewRow();
                        classHelper.dataR["refNo"] = row.Cells["refNo"].Value.ToString();
                        classHelper.dataR["recAcc"] = row.Cells["recAcc"].Value.ToString();
                        classHelper.dataR["payAcc"] = row.Cells["payAcc"].Value.ToString();
                        classHelper.dataR["refAcc"] = row.Cells["refAcc"].Value.ToString();
                        classHelper.dataR["narration"] = row.Cells["narration"].Value.ToString();
                        //classHelper.dataR["received"] = Convert.ToDouble(row.Cells["received"].Value.ToString());
                        classHelper.dataR["amount"] = Convert.ToDouble(row.Cells["amount"].Value.ToString());
                        //classHelper.dataR["closingBal"] = Convert.ToDouble(row.Cells["balance"].Value.ToString());
                        classHelper.dataR["from"] = (dtp_FROM.Value.Date.ToString("dd-MMM-yyyy"));
                        classHelper.dataR["to"] = (dtp_TO.Value.Date.ToString("dd-MMM-yyyy"));
                        //classHelper.dataR["opening"] = openingBalance;
                        //classHelper.dataR["ending"] = closingBalance;
                        classHelper.dataR["chqNo"] = row.Cells["CHQ_NO"].Value.ToString();
                        classHelper.dataR["slipNo"] = row.Cells["SLIP"].Value.ToString();

                        classHelper.dataR["date"] = row.Cells["date"].Value.ToString();

                        classHelper.nds.Tables["BankBook"].Rows.Add(classHelper.dataR);
                        
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
                //ReceiptsData();
                //PaymentData();

                classHelper.rpt = new frmReports();
                classHelper.rpt.GenerateReport("BankBookReport", classHelper.nds);
                classHelper.rpt.ShowDialog();
            }
        }

        private void generate()
        {
            //grdSEARCH.Rows.Clear();
            //opening_bal();
            ledger_Entry();
        }
        
        private void btnINTER_SAVE_Click(object sender, EventArgs e)
        {
            generate();
            if (grdSEARCH.Rows.Count > 0)
            {
                ReportData();
            }
        }

        
        private void frm_Account_Ledger_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void frm_BankBook_Load(object sender, EventArgs e)
        {
            load_account();
        }
    }
}
