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
    public partial class frm_PrintingSalesProfitReport : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        public frm_PrintingSalesProfitReport()
        {
            InitializeComponent();
        }

        private void ShowReport()
        {
            classHelper.query = @" SELECT A.INVOICE_NO,A.DATE,A.BILL_NO,D.COA_NAME AS [CUSTOMER NAME],
            A.DESCRIPTION,E.PRODUCT_NAME,B.QTY,B.RATE,(B.QTY*B.RATE) AS [TOTAL],B.GST,
            (B.QTY*B.RATE) + (((B.QTY*B.RATE)*B.GST)/100) AS [NET TOTAL],
            C.DATE AS [VENDOR DATE],F.COA_NAME AS [VENDOR NAME],G.SERVICE_TYPE,
            C.DESCRIPTION AS [SERVICE DESCRIPTION],C.AMOUNT AS [EXPENSE AMOUNT]
            FROM SALE_MASTER A
            INNER JOIN SALE_DETAIL B ON A.SALE_MASTER_ID = B.SALE_MASTER_ID
            INNER JOIN SALE_EXPENSE C ON A.SALE_MASTER_ID = C.SALE_MASTER_ID
            INNER JOIN COA D ON A.CUSTOMER_ID = D.COA_ID
            INNER JOIN PRODUCT_MASTER E ON B.ITEM_ID = E.PM_ID
            INNER JOIN COA F ON C.VENDOR_ID = F.COA_ID
            INNER JOIN SERVICE_TYPES G ON C.SERVICE_ID = G.ID
            WHERE A.DATE BETWEEN '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + @"' 
            AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'";
           classHelper.query += " ORDER BY A.[DATE]";
            char hasRows = 'N';

            try
            {
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    hasRows = 'Y';
                    classHelper.nds2.Tables["SERVICE_SALE"].Clear();
                    while (classHelper.dr.Read())
                    {
                        classHelper.dataR = classHelper.nds2.Tables["SERVICE_SALE"].NewRow();
                        classHelper.dataR["InvoiceNo"] = classHelper.dr["INVOICE_NO"].ToString();
                        classHelper.dataR["date"] = Convert.ToDateTime(classHelper.dr["DATE"].ToString());
                        classHelper.dataR["description"] = classHelper.dr["DESCRIPTION"].ToString();
                        classHelper.dataR["customerName"] = classHelper.dr["CUSTOMER NAME"].ToString();
                        classHelper.dataR["billNo"] = classHelper.dr["BILL_NO"].ToString();
                        classHelper.dataR["particulars"] = classHelper.dr["PRODUCT_NAME"].ToString();
                        classHelper.dataR["qty"] = Convert.ToDecimal(classHelper.dr["QTY"].ToString());
                        classHelper.dataR["rate"] = Convert.ToDecimal(classHelper.dr["RATE"].ToString());
                        classHelper.dataR["total"] = Convert.ToDecimal(classHelper.dr["TOTAL"].ToString());
                        classHelper.dataR["gst"] = Convert.ToDecimal(classHelper.dr["GST"].ToString());
                        classHelper.dataR["netTotal"] = Convert.ToDecimal(classHelper.dr["NET TOTAL"].ToString());
                        classHelper.dataR["vendorDate"] = Convert.ToDateTime(classHelper.dr["VENDOR DATE"].ToString());
                        classHelper.dataR["vendor"] = classHelper.dr["VENDOR NAME"].ToString();
                        classHelper.dataR["services"] = classHelper.dr["SERVICE_TYPE"].ToString();
                        classHelper.dataR["serviceDescription"] = classHelper.dr["SERVICE DESCRIPTION"].ToString();
                        classHelper.dataR["amount"] = Convert.ToDecimal(classHelper.dr["EXPENSE AMOUNT"].ToString());
                        classHelper.dataR["expenseTotal"] = 0;// Convert.ToDecimal(classHelper.dr["EXPENSE AMOUNT"].ToString());
                        //classHelper.dataR["from"] = dtp_FROM.Value.Date;
                        //classHelper.dataR["to"] = dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                        classHelper.nds2.Tables["SERVICE_SALE"].Rows.Add(classHelper.dataR);
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
                classHelper.rpt.GenerateReport("PrintingSalesProfit", classHelper.nds2);
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
