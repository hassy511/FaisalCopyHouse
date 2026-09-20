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
    public partial class frm_PurchasesInvoiceReport : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        public frm_PurchasesInvoiceReport()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.R))
            {
                ShowReport();
                using (frm_MaterialPurchaseSummaryReport frm = new frm_MaterialPurchaseSummaryReport(dtp_FROM.Value, dtp_TO.Value, cmbSupplier.SelectedValue.ToString()))
                {
                    frm.ShowReport();
                }
            }
            if (keyData == (Keys.Escape))
            {
                this.Dispose();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void ShowReport()
        {
            classHelper.query = @"SELECT A.DATE,DATEADD(DAY,A.CREDIT_DAYS,A.[DATE]) AS [DUE DATE],
            A.INVOICE_NO AS [BILL NO.],
            D.COA_NAME AS [SUPPLIER NAME],C.PRODUCT_NAME AS [ITEM],
            B.QTY AS [QTY],B.RATE AS [RATE],
            B.QTY * B.RATE AS [TOTAL]
            FROM PURCHASE_MASTER A
            INNER JOIN PURCHASE_DETAIL B ON A.PURCHASE_MASTER_ID = B.PURCHASE_MASTER_ID
            INNER JOIN PRODUCT_MASTER C ON B.MATERIAL_ID = C.PM_ID
            INNER JOIN COA D ON A.SUPPLIER_ID = D.COA_ID
            WHERE A.DATE BETWEEN '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + @"' 
            AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'";

            if (cmbSupplier.SelectedIndex > 0)
                classHelper.query += " AND D.COA_ID = '"+cmbSupplier.SelectedValue.ToString()+"'";

           classHelper.query += " ORDER BY A.PURCHASE_MASTER_ID,A.[DATE]";
            char hasRows = 'N';

            try
            {
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    hasRows = 'Y';
                    classHelper.mds.Tables["PI_Report"].Clear();
                    while (classHelper.dr.Read())
                    {
                        classHelper.dataR = classHelper.mds.Tables["PI_Report"].NewRow();
                        classHelper.dataR["DATE"] = Convert.ToDateTime(classHelper.dr["DATE"].ToString());
                        classHelper.dataR["DUE DATE"] = Convert.ToDateTime(classHelper.dr["DUE DATE"].ToString());
                        classHelper.dataR["BILL NO"] = classHelper.dr["BILL NO."].ToString();
                        //classHelper.dataR["VEHICLE NO"] = classHelper.dr["VEHICLE NUMBER"].ToString();
                        classHelper.dataR["SUPPLIER"] = classHelper.dr["SUPPLIER NAME"].ToString();
                        classHelper.dataR["ITEM"] = classHelper.dr["ITEM"].ToString();
                        classHelper.dataR["QTY"] = Convert.ToDecimal(classHelper.dr["QTY"].ToString());
                        classHelper.dataR["RATE"] = Convert.ToDecimal(classHelper.dr["RATE"].ToString());
                        classHelper.dataR["TOTAL"] = Convert.ToDecimal(classHelper.dr["TOTAL"].ToString());
                        classHelper.dataR["from"] = dtp_FROM.Value.Date;
                        classHelper.dataR["to"] = dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                        classHelper.mds.Tables["PI_Report"].Rows.Add(classHelper.dataR);
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

            //classHelper.query = @"select C.MATERIAL_NAME,SUM(A.NET_WEIGHT) AS [T WEIGHT],SUM(A.KORANGI_WEIGHT) AS [K WEIGHT],
            //(SUM(A.NET_WEIGHT) - SUM(A.KORANGI_WEIGHT)) AS [DIFFERENCE],
            //ROUND(SUM((A.NET_WEIGHT * ROUND(A.KG_RATE,0)))/SUM(A.NET_WEIGHT),0) AS [AVERAGE RATE],
            //SUM(
            //CASE WHEN MATERIAL_NAME = 'OLIEN/RBD' THEN ROUND((A.NET_WEIGHT * (ROUND(A.MUAND_RATE,0)/37.324)),0) ELSE
            //ROUND((A.NET_WEIGHT * A.KG_RATE),0) END
            //--ROUND((A.NET_WEIGHT * (ROUND(A.MUAND_RATE,0)/37.324)),0) --END
            //) AS [AMOUNT]
            //from PURCHASES A
            //INNER JOIN PURCHASES_ORDER B ON A.PO_ID = B.PO_ID
            //INNER JOIN MATERIALS C ON B.MATERIAL_ID = C.MATERIAL_ID
            //WHERE A.DATE BETWEEN '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
            //AND A.PI_ID NOT IN (SELECT purchases_id FROM purchases_sales_transfer)";

            //if (cmbSupplier.SelectedIndex > 0)
            //    classHelper.query += " AND A.SUPPLIER_ID = '" + cmbSupplier.SelectedValue.ToString() + "'";

            //classHelper.query += "GROUP BY C.MATERIAL_NAME";
            
            //try
            //{
            //    Classes.Helper.conn.Open();
            //    classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
            //    classHelper.dr = classHelper.cmd.ExecuteReader();
            //    if (classHelper.dr.HasRows == true)
            //    {
            //        classHelper.mds.Tables["PI_Summary"].Clear();
            //        while (classHelper.dr.Read())
            //        {
            //            classHelper.dataR = classHelper.mds.Tables["PI_Summary"].NewRow();
            //            classHelper.dataR["MATERIAL"] = classHelper.dr["MATERIAL_NAME"].ToString();
            //            classHelper.dataR["T WEIGHT"] = Convert.ToDecimal(classHelper.dr["T WEIGHT"].ToString());
            //            classHelper.dataR["K WEIGHT"] = Convert.ToDecimal(classHelper.dr["K WEIGHT"].ToString());
            //            classHelper.dataR["DIFFERENCE"] = Convert.ToDecimal(classHelper.dr["DIFFERENCE"].ToString());
            //            classHelper.dataR["RATE"] = Math.Round(Convert.ToDecimal(classHelper.dr["AVERAGE RATE"].ToString()),2);
            //            classHelper.dataR["AMOUNT"] = Convert.ToDecimal(classHelper.dr["AMOUNT"].ToString());
            //            classHelper.mds.Tables["PI_Summary"].Rows.Add(classHelper.dataR);
            //        }
            //    }
            //    else
            //    {
            //       // MessageBox.Show("No Record Found.", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }

            //    //Reports.POSummary rptPOS = new Reports.POSummary();
            //    //rptPOS.SetDataSource(classHelper.mds.Tables["PO_Summary"]);
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
                classHelper.rpt.GenerateReport("PI_Report", classHelper.mds);
                classHelper.rpt.ShowDialog();
            }
        }

        private void grpSALES_Enter(object sender, EventArgs e)
        {
            
        }
        
        private void btnINTER_SAVE_Click(object sender, EventArgs e)
        {
            ShowReport();
            //using (frm_MaterialPurchaseSummaryReport frm = new frm_MaterialPurchaseSummaryReport(dtp_FROM.Value, dtp_TO.Value,cmbSupplier.SelectedValue.ToString()))
            //{
            //    frm.ShowReport();
            //}
        }

        private void frm_Account_Ledger_Load(object sender, EventArgs e)
        {
            classHelper.LoadSuppliers(cmbSupplier);
        }

        private void frm_Account_Ledger_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void cmbSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
