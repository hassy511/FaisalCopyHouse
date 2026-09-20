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
    public partial class frm_SalesReportThermal : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        public frm_SalesReportThermal()
        {
            InitializeComponent();
        }

        private void LoadCustomer()
        {
            classHelper.LoadCustomers(cmbCustomer);
        }
        private void LoadProducts()
        {
            classHelper.LoadProducts(cmbProduct);
        }

        private void ShowReport()
        {

            classHelper.query = @" SELECT C.PRODUCT_NAME,SUM(B.QTY) AS [TOTAL QTY],SUM(B.QTY * B.RATE) AS [TOTAL] 
            FROM SALE_MASTER A
            INNER JOIN SALE_DETAIL B ON A.SALE_MASTER_ID = B.SALE_MASTER_ID
            INNER JOIN PRODUCT_MASTER C ON B.ITEM_ID = C.PM_ID
            WHERE A.DATE BETWEEN '" + dtp_FROM.Value.Date.ToString("yyyy-MM-dd") + @"' 
            AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"' ";

            if (cmbCustomer.SelectedIndex > 0)
            {
                classHelper.query += " AND A.CUSTOMER_ID = '" + cmbCustomer.SelectedValue.ToString() + "'";
            }
            if (cmbProduct.SelectedIndex > 0)
            {
                classHelper.query += " AND B.ITEM_ID = '" + cmbProduct.SelectedValue.ToString() + "'";
            }

            classHelper.query += @" GROUP BY C.PRODUCT_NAME 
                                    ORDER BY C.PRODUCT_NAME";
                

            char hasRows = 'N';
            try
            {
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    hasRows = 'Y';
                    classHelper.mds.Tables["SaleInvoice"].Clear();
                    while (classHelper.dr.Read())
                    {
                        classHelper.dataR = classHelper.mds.Tables["SaleInvoice"].NewRow();
                        classHelper.dataR["date"] = dtp_FROM.Value.Date;
                        classHelper.dataR["dueDate"] = dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                        classHelper.dataR["product"] = classHelper.dr["PRODUCT_NAME"].ToString();
                        classHelper.dataR["qty"] = Convert.ToDecimal(classHelper.dr["TOTAL QTY"].ToString());
                        classHelper.dataR["amount"] = Convert.ToDecimal(classHelper.dr["TOTAL"].ToString());
                        classHelper.mds.Tables["SaleInvoice"].Rows.Add(classHelper.dataR);
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
                classHelper.rpt = new frmReports();
                classHelper.rpt.GenerateReport("SalesReportThermal", classHelper.mds);
                //classHelper.rpt.ShowDialog();
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
            LoadCustomer();
            LoadProducts();

        }

        private void frm_Account_Ledger_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
