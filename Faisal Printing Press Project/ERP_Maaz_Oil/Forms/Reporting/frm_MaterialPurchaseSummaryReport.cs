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
    public partial class frm_MaterialPurchaseSummaryReport : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        string supplierID="0";

        public frm_MaterialPurchaseSummaryReport()
        {
            InitializeComponent();
        }

        public frm_MaterialPurchaseSummaryReport(DateTime from, DateTime to,string supplier)
        {
            InitializeComponent();
            dtp_FROM.Value = from;
            dtp_TO.Value = to;
            supplierID = supplier;
        }

        public void ShowReport()
        {
            classHelper.query = @"--Summary Material Purchases
            SELECT A.SUPPLIER_ID,X.COA_NAME AS [SUPPLIER],
            SUM(ISNULL(B.KGS,0)) AS [CANOLA KG],AVG(ISNULL(B.KG_RATE,0)) AS [CANOLA RATE],SUM( ISNULL(B.KGS,0) * ISNULL(B.KG_RATE,0) ) AS [CANOLA AMOUNT],
            SUM(ISNULL(D.KGS,0)) AS [RBD KG],Avg(ISNULL(ROUND(D.MUAND_RATE,0),0)) AS [RBD RATE],SUM( ISNULL(D.KGS,0) * ISNULL(D.KG_RATE,0) ) AS [RBD AMOUNT],
            SUM(ISNULL(C.KGS,0)) AS [OLIEN KG],AVG(ISNULL(ROUND(C.MUAND_RATE,0),0)) AS [OLIEN RATE],SUM( ISNULL(C.KGS,0) * ISNULL(C.KG_RATE,0) ) AS [OLIEN AMOUNT],
            SUM(ISNULL(E.KGS,0)) AS [HARD OIL KG],AVG(ISNULL(ROUND(E.MUAND_RATE,0),0)) AS [HARD OIL RATE],SUM( ISNULL(E.KGS,0) * ISNULL(E.KG_RATE,0) ) AS [HARD OIL AMOUNT]					
            ,0 as PI_ID--,A.PI_ID            
            FROM PURCHASES A
            LEFT JOIN (
	            SELECT C.COA_ID,C.COA_NAME AS [SUPPLIER],D.MATERIAL_NAME,A.KORANGI_WEIGHT AS [KGS],A.KG_RATE,B.MUAND_RATE,A.PI_ID
	            FROM PURCHASES A
	            INNER JOIN PURCHASES_ORDER B ON A.PO_ID = B.PO_ID
	            INNER JOIN COA C ON A.SUPPLIER_ID = C.COA_ID
	            INNER JOIN MATERIALS D ON B.MATERIAL_ID = D.MATERIAL_ID
	            WHERE D.MATERIAL_ID = 5005 AND A.DATE BETWEEN '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
            ) B ON A.PI_ID = B.PI_ID
            LEFT JOIN (
	            SELECT C.COA_ID,C.COA_NAME AS [SUPPLIER],D.MATERIAL_NAME,A.KORANGI_WEIGHT AS [KGS],A.KG_RATE,B.MUAND_RATE,A.PI_ID
	            FROM PURCHASES A
	            INNER JOIN PURCHASES_ORDER B ON A.PO_ID = B.PO_ID
	            INNER JOIN COA C ON A.SUPPLIER_ID = C.COA_ID
	            INNER JOIN MATERIALS D ON B.MATERIAL_ID = D.MATERIAL_ID
	            WHERE D.MATERIAL_ID = 3002 AND A.DATE BETWEEN '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
            ) C ON A.PI_ID = C.PI_ID
            LEFT JOIN (
	            SELECT C.COA_ID,C.COA_NAME AS [SUPPLIER],D.MATERIAL_NAME,A.KORANGI_WEIGHT AS [KGS],A.KG_RATE,B.MUAND_RATE,A.PI_ID
	            FROM PURCHASES A
	            INNER JOIN PURCHASES_ORDER B ON A.PO_ID = B.PO_ID
	            INNER JOIN COA C ON A.SUPPLIER_ID = C.COA_ID
	            INNER JOIN MATERIALS D ON B.MATERIAL_ID = D.MATERIAL_ID
	            WHERE D.MATERIAL_ID = 5003 AND A.DATE BETWEEN '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'


            ) D ON A.PI_ID = D.PI_ID
	        LEfT JOIN
			(
			  SELECT C.COA_ID,C.COA_NAME AS [SUPPLIER],D.MATERIAL_NAME,A.KORANGI_WEIGHT AS [KGS],A.KG_RATE,B.MUAND_RATE,A.PI_ID
	            FROM PURCHASES A
	            INNER JOIN PURCHASES_ORDER B ON A.PO_ID = B.PO_ID
	            INNER JOIN COA C ON A.SUPPLIER_ID = C.COA_ID
	            INNER JOIN MATERIALS D ON B.MATERIAL_ID = D.MATERIAL_ID
	            WHERE D.MATERIAL_ID = 5017 AND A.DATE BETWEEN '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
			) E ON A.PI_ID = E.PI_ID
            INNER JOIN COA X ON A.SUPPLIER_ID = X.COA_ID
            WHERE A.DATE BETWEEN '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"' AND A.PI_ID NOT IN (SELECT purchases_id FROM purchases_sales_transfer)";
        
            if(!supplierID.Equals("0"))
            {
                classHelper.query += " AND A.SUPPLIER_ID = '"+supplierID+"'";
            }

           classHelper.query += @" GROUP BY A.SUPPLIER_ID,X.COA_NAME
ORDER BY [SUPPLIER]";
            

            char hasRows = 'N';
            try
            {
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    hasRows = 'Y';
                    classHelper.nds.Tables["MaterialPurchasesSummary"].Clear();
                    while (classHelper.dr.Read())
                    {
                        classHelper.dataR = classHelper.nds.Tables["MaterialPurchasesSummary"].NewRow();
                        classHelper.dataR["supplierId"] = classHelper.dr["SUPPLIER_ID"].ToString();
                        classHelper.dataR["supplierName"] = classHelper.dr["SUPPLIER"].ToString();
                        classHelper.dataR["canolaKg"] = Convert.ToDecimal(classHelper.dr["CANOLA KG"].ToString());
                        classHelper.dataR["canolaRate"] = Convert.ToDecimal(classHelper.dr["CANOLA RATE"].ToString());
                        classHelper.dataR["canoalaAmount"] = Convert.ToDecimal(classHelper.dr["CANOLA AMOUNT"].ToString());
                        classHelper.dataR["rbdKg"] = Convert.ToDecimal(classHelper.dr["RBD KG"].ToString());
                        classHelper.dataR["rbdRate"] = Convert.ToDecimal(classHelper.dr["RBD RATE"].ToString());
                        classHelper.dataR["rbdAmount"] = Convert.ToDecimal(classHelper.dr["RBD AMOUNT"].ToString());
                        classHelper.dataR["olienKg"] = Convert.ToDecimal(classHelper.dr["OLIEN KG"].ToString());
                        classHelper.dataR["olienRate"] = Convert.ToDecimal(classHelper.dr["OLIEN RATE"].ToString());
                        classHelper.dataR["olienAmount"] = Convert.ToDecimal(classHelper.dr["OLIEN AMOUNT"].ToString());
                        classHelper.dataR["hardKg"] = Convert.ToDecimal(classHelper.dr["HARD OIL KG"].ToString());
                        classHelper.dataR["hardRate"] = Convert.ToDecimal(classHelper.dr["HARD OIL RATE"].ToString());
                        classHelper.dataR["hardAmount"] = Convert.ToDecimal(classHelper.dr["HARD OIL AMOUNT"].ToString());

                        classHelper.dataR["fromDate"] = Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date);
                        classHelper.dataR["toDate"] = Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59));
                        classHelper.nds.Tables["MaterialPurchasesSummary"].Rows.Add(classHelper.dataR);
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
                classHelper.rpt = new frmReports();
                classHelper.rpt.GenerateReport("MaterialPurchasesSummary", classHelper.nds);
                classHelper.rpt.ShowDialog();
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
