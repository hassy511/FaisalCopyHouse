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
    public partial class frm_TrailBalanceReport : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        public frm_TrailBalanceReport()
        {
            InitializeComponent();
        }

        private void ShowReport()
        {
            char hasRows = 'N';
            if (rdbUpto.Checked == true)
            {
                if (rdbDetailed.Checked == true)
                {
                    classHelper.query = @"SELECT Y.AN_NAME AS [NATURE],dbo.GET_ACCOUNT_PARENT(Z.CA_NAME) AS [PARENT],X.AG_NAME AS [GROUP],
                    B.COA_CODE,B.COA_NAME AS [ACCOUNT],ISNULL(E.REGION_NAME,'-') AS [REGION],
                    (SELECT CASE WHEN DR_CR = 'D' THEN OPEN_BAL ELSE (-1*OPEN_BAL) END FROM COA WHERE COA_ID = B.COA_ID) AS [OPENING],
                    (SELECT ISNULL(SUM(DEBIT)-SUM(CREDIT),'0') FROM LEDGERS WHERE [DATE] <= '" + Classes.Helper.ConvertDatetime(dtpUpto.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"' AND COA_ID = B.COA_ID) AS [BALANCE]
                    FROM COA B
                    INNER JOIN ACCOUNT_GROUP X ON B.AG_ID = X.AG_ID
                    INNER JOIN ACCOUNT_NATURE Y ON X.AN_ID = Y.AN_ID
                    INNER JOIN CONTROL_ACCOUNT Z ON B.CA_ID = Z.CA_ID
                    LEFT JOIN CUSTOMER_PROFILE C ON B.COA_ID = C.COA_ID
                    LEFT JOIN CITY D ON C.CITY_ID = D.CITY_ID
                    LEFT JOIN REGION E ON E.REGION_ID = D.REG_ID
                    GROUP BY Y.AN_NAME,X.AG_NAME,B.COA_NAME,E.REGION_NAME,Z.CA_NAME,B.COA_ID,B.COA_CODE
                    ORDER BY 
                    CASE 
	                    WHEN Y.AN_NAME = 'ASSETS' THEN 1
	                    WHEN Y.AN_NAME = 'LAIBILITIES' THEN 2
	                    WHEN Y.AN_NAME = 'EQUITY' THEN 3
	                    WHEN Y.AN_NAME = 'EXPENSES' THEN 4
	                    WHEN Y.AN_NAME = 'REVENUE' THEN 5
                    END,X.AG_NAME,B.COA_NAME";
                }
                else if (rdbConsolidated.Checked == true)
                {
                    classHelper.query = @"WITH A AS (SELECT Y.AN_NAME AS [NATURE],dbo.GET_ACCOUNT_PARENT(Z.CA_NAME) AS [PARENT],X.AG_NAME AS [GROUP],
                    B.COA_CODE,B.COA_NAME AS [ACCOUNT],ISNULL(E.REGION_NAME,'-') AS [REGION],
                    (SELECT CASE WHEN DR_CR = 'D' THEN OPEN_BAL ELSE (-1*OPEN_BAL) END FROM COA WHERE COA_ID = B.COA_ID) AS [OPENING],
                    (SELECT ISNULL(SUM(DEBIT)-SUM(CREDIT),'0') FROM LEDGERS WHERE [DATE] <= '" + Classes.Helper.ConvertDatetime(dtpUpto.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"' AND COA_ID = B.COA_ID) AS [BALANCE]
                    FROM COA B
                    INNER JOIN ACCOUNT_GROUP X ON B.AG_ID = X.AG_ID
                    INNER JOIN ACCOUNT_NATURE Y ON X.AN_ID = Y.AN_ID
                    INNER JOIN CONTROL_ACCOUNT Z ON B.CA_ID = Z.CA_ID
                    LEFT JOIN CUSTOMER_PROFILE C ON B.COA_ID = C.COA_ID
                    LEFT JOIN CITY D ON C.CITY_ID = D.CITY_ID
                    LEFT JOIN REGION E ON E.REGION_ID = D.REG_ID
                    GROUP BY Y.AN_NAME,X.AG_NAME,B.COA_NAME,E.REGION_NAME,Z.CA_NAME,B.COA_ID,B.COA_CODE)
                    SELECT A.NATURE,ISNULL(A.PARENT,'-') AS [PARENT],A.[GROUP],'' AS [COA_CODE],'' AS [ACCOUNT],'' AS [REGION],
                    SUM(OPENING) AS [OPENING],SUM(BALANCE) AS [BALANCE]
                    FROM A 
                    GROUP BY A.NATURE,A.PARENT,A.[GROUP]
                    ORDER BY 
                    CASE 
	                    WHEN A.[NATURE] = 'ASSETS' THEN 1
	                    WHEN A.[NATURE] = 'LAIBILITIES' THEN 2
	                    WHEN A.[NATURE] = 'EQUITY' THEN 3
	                    WHEN A.[NATURE] = 'EXPENSES' THEN 4
	                    WHEN A.[NATURE] = 'REVENUE' THEN 5
                    END,A.[GROUP]";
                }

                try
                {
                    Classes.Helper.conn.Open();
                    classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                    classHelper.dr = classHelper.cmd.ExecuteReader();
                    if (classHelper.dr.HasRows == true)
                    {
                        hasRows = 'Y';
                        classHelper.nds.Tables["TrialBalance"].Clear();

                        classHelper.dataR = classHelper.nds.Tables["TrialBalance"].NewRow();
                        classHelper.dataR["from"] = Classes.Helper.ConvertDatetime(dtpUpto.Value.Date);
                        classHelper.dataR["Nature"] = "ASSETS";
                        classHelper.dataR["Parent"] = "CURRENT ASSETS";
                        classHelper.dataR["Group"] = "INVENTORY";
                        classHelper.dataR["Code"] = "010020001";
                        classHelper.dataR["Account"] = "OPENING INVENTORY";
                        classHelper.dataR["Region"] = "-";
                        Decimal openingStock = classHelper.GetClosingStockValue(Convert.ToDateTime("2020-06-30 00:00:00"));
                        classHelper.dataR["Opening"] = openingStock;
                        decimal balance1 = openingStock;
                        if (balance1 >= 0)
                        {
                            classHelper.dataR["Debit"] = balance1;
                            classHelper.dataR["Credit"] = 0;
                        }
                        else
                        {
                            classHelper.dataR["Credit"] = Math.Abs(balance1);
                            classHelper.dataR["Debit"] = 0;
                        }
                        classHelper.nds.Tables["TrialBalance"].Rows.Add(classHelper.dataR);

                        while (classHelper.dr.Read())
                        {
                            if (chkZeroBalance.Checked == true)
                            {
                                decimal balance = Convert.ToDecimal(classHelper.dr["OPENING"].ToString()) + Convert.ToDecimal(classHelper.dr["BALANCE"].ToString());
                                if (balance != 0)
                                {
                                    classHelper.dataR = classHelper.nds.Tables["TrialBalance"].NewRow();
                                    classHelper.dataR["from"] = Classes.Helper.ConvertDatetime(dtpUpto.Value.Date);
                                    classHelper.dataR["Nature"] = classHelper.dr["NATURE"].ToString();
                                    classHelper.dataR["Parent"] = classHelper.dr["PARENT"].ToString();
                                    classHelper.dataR["Group"] = classHelper.dr["GROUP"].ToString();
                                    classHelper.dataR["Code"] = classHelper.dr["COA_CODE"].ToString();
                                    classHelper.dataR["Account"] = classHelper.dr["ACCOUNT"].ToString();
                                    classHelper.dataR["Region"] = classHelper.dr["REGION"].ToString();
                                    classHelper.dataR["Opening"] = Convert.ToDecimal(classHelper.dr["OPENING"].ToString());

                                    if (balance >= 0)
                                    {
                                        classHelper.dataR["Debit"] = balance;
                                        classHelper.dataR["Credit"] = 0;
                                    }
                                    else
                                    {
                                        classHelper.dataR["Credit"] = Math.Abs(balance);
                                        classHelper.dataR["Debit"] = 0;
                                    }
                                    classHelper.nds.Tables["TrialBalance"].Rows.Add(classHelper.dataR);
                                }
                            }
                            else {
                                classHelper.dataR = classHelper.nds.Tables["TrialBalance"].NewRow();
                                classHelper.dataR["from"] = Classes.Helper.ConvertDatetime(dtpUpto.Value.Date);
                                classHelper.dataR["Nature"] = classHelper.dr["NATURE"].ToString();
                                classHelper.dataR["Parent"] = classHelper.dr["PARENT"].ToString();
                                classHelper.dataR["Group"] = classHelper.dr["GROUP"].ToString();
                                classHelper.dataR["Code"] = classHelper.dr["COA_CODE"].ToString();
                                classHelper.dataR["Account"] = classHelper.dr["ACCOUNT"].ToString();
                                classHelper.dataR["Region"] = classHelper.dr["REGION"].ToString();
                                classHelper.dataR["Opening"] = Convert.ToDecimal(classHelper.dr["OPENING"].ToString());
                                decimal balance = Convert.ToDecimal(classHelper.dr["OPENING"].ToString()) + Convert.ToDecimal(classHelper.dr["BALANCE"].ToString());
                                if (balance >= 0)
                                {
                                    classHelper.dataR["Debit"] = balance;
                                    classHelper.dataR["Credit"] = 0;
                                }
                                else
                                {
                                    classHelper.dataR["Credit"] = Math.Abs(balance);
                                    classHelper.dataR["Debit"] = 0;
                                }
                                classHelper.nds.Tables["TrialBalance"].Rows.Add(classHelper.dataR);
                            }
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
            }
            else
            {
                classHelper.query = @"SELECT Y.AN_NAME AS [NATURE],dbo.GET_ACCOUNT_PARENT(Z.CA_NAME) AS [PARENT],X.AG_NAME AS [GROUP],
                B.COA_CODE,B.COA_NAME AS [ACCOUNT],ISNULL(E.REGION_NAME,'-') AS [REGION],
                (SELECT CASE WHEN DR_CR = 'D' THEN OPEN_BAL ELSE (-1*OPEN_BAL) END FROM COA WHERE COA_ID = B.COA_ID) AS [OPENING],
                (SELECT ISNULL(SUM(DEBIT),0)-ISNULL(SUM(CREDIT),0) FROM LEDGERS WHERE COA_ID = B.COA_ID AND [DATE] < '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + @"') AS [PREVIOUS],
                (SELECT ISNULL(SUM(DEBIT),'0') FROM LEDGERS WHERE DATE BETWEEN '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + @"' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"' AND COA_ID = B.COA_ID) AS [DEBIT],
                (SELECT ISNULL(SUM(CREDIT),'0') FROM LEDGERS WHERE DATE BETWEEN '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + @"' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"' AND COA_ID = B.COA_ID) AS [CREDIT]
                FROM COA B
                --LEFT JOIN LEDGERS A ON A.COA_ID = B.COA_ID
                INNER JOIN ACCOUNT_GROUP X ON B.AG_ID = X.AG_ID
                INNER JOIN ACCOUNT_NATURE Y ON X.AN_ID = Y.AN_ID
                INNER JOIN CONTROL_ACCOUNT Z ON B.CA_ID = Z.CA_ID
                LEFT JOIN CUSTOMER_PROFILE C ON B.COA_ID = C.COA_ID
                LEFT JOIN CITY D ON C.CITY_ID = D.CITY_ID
                LEFT JOIN REGION E ON E.REGION_ID = D.REG_ID
                --WHERE A.DATE BETWEEN '2019-06-27' AND '2019-08-27'
                GROUP BY Y.AN_NAME,X.AG_NAME,B.COA_NAME,E.REGION_NAME,Z.CA_NAME,B.COA_ID,B.COA_CODE
                ORDER BY 
                CASE 
	                WHEN Y.AN_NAME = 'ASSETS' THEN 1
	                WHEN Y.AN_NAME = 'LAIBILITIES' THEN 2
	                WHEN Y.AN_NAME = 'EQUITY' THEN 3
	                WHEN Y.AN_NAME = 'EXPENSES' THEN 4
	                WHEN Y.AN_NAME = 'REVENUE' THEN 5
                END,X.AG_NAME,B.COA_NAME";

                try
                {
                    Classes.Helper.conn.Open();
                    classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                    classHelper.cmd.CommandTimeout = 0;
                    classHelper.dr = classHelper.cmd.ExecuteReader();
                    if (classHelper.dr.HasRows == true)
                    {
                        hasRows = 'Y';
                        classHelper.nds.Tables["TrialBalance"].Clear();
                        while (classHelper.dr.Read())
                        {
                            if (chkZeroBalance.Checked == true) {
                                decimal openingBalance1 = Convert.ToDecimal(classHelper.dr["OPENING"].ToString()) + Convert.ToDecimal(classHelper.dr["Previous"].ToString());
                                if (openingBalance1 != 0)
                                {
                                    classHelper.dataR = classHelper.nds.Tables["TrialBalance"].NewRow();
                                    classHelper.dataR["from"] = Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date);
                                    classHelper.dataR["to"] = Classes.Helper.ConvertDatetime(dtp_TO.Value.Date);
                                    classHelper.dataR["Nature"] = classHelper.dr["NATURE"].ToString();
                                    classHelper.dataR["Parent"] = classHelper.dr["PARENT"].ToString();
                                    classHelper.dataR["Group"] = classHelper.dr["GROUP"].ToString();
                                    classHelper.dataR["Code"] = classHelper.dr["COA_CODE"].ToString();
                                    classHelper.dataR["Account"] = classHelper.dr["ACCOUNT"].ToString();
                                    classHelper.dataR["Region"] = classHelper.dr["REGION"].ToString();
                                    classHelper.dataR["Opening"] = Convert.ToDecimal(classHelper.dr["OPENING"].ToString());
                                    classHelper.dataR["Previous"] = Convert.ToDecimal(classHelper.dr["PREVIOUS"].ToString());


                                    if (openingBalance1 >= 0)
                                    {
                                        classHelper.dataR["OpeningDebit"] = openingBalance1;
                                        classHelper.dataR["OpeningCredit"] = 0;
                                    }
                                    else
                                    {
                                        classHelper.dataR["OpeningCredit"] = Math.Abs(openingBalance1);
                                        classHelper.dataR["OpeningDebit"] = 0;
                                    }

                                    classHelper.dataR["Debit"] = Convert.ToDecimal(classHelper.dr["DEBIT"].ToString());
                                    classHelper.dataR["Credit"] = Convert.ToDecimal(classHelper.dr["CREDIT"].ToString());
                                    //classHelper.dataR["Balance"] = ;

                                    decimal closingBalance1 = (Convert.ToDecimal(classHelper.dr["OPENING"].ToString()) + Convert.ToDecimal(classHelper.dr["PREVIOUS"].ToString()) +
                                                             Convert.ToDecimal(classHelper.dr["DEBIT"].ToString())) - Convert.ToDecimal(classHelper.dr["CREDIT"].ToString());
                                    if (closingBalance1 >= 0)
                                    {
                                        classHelper.dataR["ClosingDebit"] = closingBalance1;
                                        classHelper.dataR["ClosingCredit"] = 0;
                                    }
                                    else
                                    {
                                        classHelper.dataR["ClosingCredit"] = Math.Abs(closingBalance1);
                                        classHelper.dataR["ClosingDebit"] = 0;
                                    }

                                    classHelper.nds.Tables["TrialBalance"].Rows.Add(classHelper.dataR);
                                }
                            }
                            else {
                                classHelper.dataR = classHelper.nds.Tables["TrialBalance"].NewRow();
                                classHelper.dataR["from"] = Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date);
                                classHelper.dataR["to"] = Classes.Helper.ConvertDatetime(dtp_TO.Value.Date);
                                classHelper.dataR["Nature"] = classHelper.dr["NATURE"].ToString();
                                classHelper.dataR["Parent"] = classHelper.dr["PARENT"].ToString();
                                classHelper.dataR["Group"] = classHelper.dr["GROUP"].ToString();
                                classHelper.dataR["Code"] = classHelper.dr["COA_CODE"].ToString();
                                classHelper.dataR["Account"] = classHelper.dr["ACCOUNT"].ToString();
                                classHelper.dataR["Region"] = classHelper.dr["REGION"].ToString();
                                classHelper.dataR["Opening"] = Convert.ToDecimal(classHelper.dr["OPENING"].ToString());
                                classHelper.dataR["Previous"] = Convert.ToDecimal(classHelper.dr["PREVIOUS"].ToString());
                                decimal openingBalance1 = Convert.ToDecimal(classHelper.dr["OPENING"].ToString()) + Convert.ToDecimal(classHelper.dr["Previous"].ToString());

                                if (openingBalance1 >= 0)
                                {
                                    classHelper.dataR["OpeningDebit"] = openingBalance1;
                                    classHelper.dataR["OpeningCredit"] = 0;
                                }
                                else
                                {
                                    classHelper.dataR["OpeningCredit"] = Math.Abs(openingBalance1);
                                    classHelper.dataR["OpeningDebit"] = 0;
                                }

                                classHelper.dataR["Debit"] = Convert.ToDecimal(classHelper.dr["DEBIT"].ToString());
                                classHelper.dataR["Credit"] = Convert.ToDecimal(classHelper.dr["CREDIT"].ToString());
                                //classHelper.dataR["Balance"] = ;

                                decimal closingBalance1 = (Convert.ToDecimal(classHelper.dr["OPENING"].ToString()) + Convert.ToDecimal(classHelper.dr["PREVIOUS"].ToString()) +
                                                         Convert.ToDecimal(classHelper.dr["DEBIT"].ToString())) - Convert.ToDecimal(classHelper.dr["CREDIT"].ToString());
                                if (closingBalance1 >= 0)
                                {
                                    classHelper.dataR["ClosingDebit"] = closingBalance1;
                                    classHelper.dataR["ClosingCredit"] = 0;
                                }
                                else
                                {
                                    classHelper.dataR["ClosingCredit"] = Math.Abs(closingBalance1);
                                    classHelper.dataR["ClosingDebit"] = 0;
                                }

                                classHelper.nds.Tables["TrialBalance"].Rows.Add(classHelper.dataR);
                            }
                        }


                        classHelper.dataR = classHelper.nds.Tables["TrialBalance"].NewRow();
                        classHelper.dataR["from"] = Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date);
                        classHelper.dataR["to"] = Classes.Helper.ConvertDatetime(dtp_TO.Value.Date);
                        classHelper.dataR["Nature"] = "ASSETS";
                        classHelper.dataR["Parent"] = "CURRENT ASSETS";
                        classHelper.dataR["Group"] = "INVENTORY";
                        classHelper.dataR["Code"] = "010020001";
                        classHelper.dataR["Account"] = "OPENING INVENTORY";
                        classHelper.dataR["Region"] = "-";
                        Decimal openingStock = classHelper.GetClosingStockValue(Convert.ToDateTime("2020-06-30 00:00:00"));
                        classHelper.dataR["Opening"] = openingStock;
                        classHelper.dataR["Previous"] = 0;
                        
                        decimal openingBalance = openingStock;
                        if (openingBalance >= 0)
                        {
                            classHelper.dataR["OpeningDebit"] = openingBalance;
                            classHelper.dataR["OpeningCredit"] = 0;
                        }
                        else
                        {
                            classHelper.dataR["OpeningCredit"] = Math.Abs(openingBalance);
                            classHelper.dataR["OpeningDebit"] = 0;
                        }

                        classHelper.dataR["Debit"] = 0;
                        classHelper.dataR["Credit"] = 0;
                        //classHelper.dataR["Balance"] = ;

                        decimal closingBalance = openingStock;
                        if (closingBalance >= 0)
                        {
                            classHelper.dataR["ClosingDebit"] = closingBalance;
                            classHelper.dataR["ClosingCredit"] = 0;
                        }
                        else
                        {
                            classHelper.dataR["ClosingCredit"] = Math.Abs(closingBalance);
                            classHelper.dataR["ClosingDebit"] = 0;
                        }

                        classHelper.nds.Tables["TrialBalance"].Rows.Add(classHelper.dataR);

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
            }
            
            if (hasRows == 'Y')
            {
                if (rdbUpto.Checked == true)
                {
                    if (rdbDetailed.Checked == true) {
                        classHelper.rpt = new frmReports();
                        classHelper.rpt.GenerateReport("TrialBalanceUpto", classHelper.nds);
                        classHelper.rpt.ShowDialog();
                    }
                    else if (rdbConsolidated.Checked == true)
                    {
                        classHelper.rpt = new frmReports();
                        classHelper.rpt.GenerateReport("TrialBalanceUptoConsolidated", classHelper.nds);
                        classHelper.rpt.ShowDialog();
                    }
                }
                else {
                    classHelper.rpt = new frmReports();
                    classHelper.rpt.GenerateReport("TrialBalanceRange", classHelper.nds);
                    classHelper.rpt.ShowDialog();
                }
            }
        }

        private void grpSALES_Enter(object sender, EventArgs e)
        {
            
        }
        
        private void btnINTER_SAVE_Click(object sender, EventArgs e)
        {
            ShowReport();
        }

        private void frm_Account_Ledger_Load(object sender, EventArgs e)
        {
            
        }

        private void frm_Account_Ledger_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
