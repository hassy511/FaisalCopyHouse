using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ERP_Maaz_Oil.Forms.Sales
{
    public partial class frm_SalesInvoices : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        public frm_SalesInvoices()
        {
            InitializeComponent();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.R))
            {
                if (cmbCustomer.SelectedIndex == 0)
                {
                    MessageBox.Show("Select an Customer.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    ShowReport();
                }
            }
            if (keyData == (Keys.Escape))
            {
                this.Dispose();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void LoadCustomer()
        {
            classHelper.query = @"SELECT '0' AS [id],'--SELECT CUSTOMER--' AS [name]
                UNION
                SELECT COA_ID AS [id],COA_NAME AS [name] FROM COA WHERE CA_ID = '21' AND STAT = 0";
            classHelper.LoadComboData(cmbCustomer, classHelper.query);
        }

        private void ShowReport()
        {
            classHelper.query = @"	select a.INVOICE_NO,a.DATE,d.COA_NAME as [customer],a.VEHICLE_NO,f.NAME,DATEADD(day,isnull(e.CREDIT_DAYS,0),a.date) as [due],
	            g.PRODUCT_NAME,c.QTY,c.RATE,(c.QTY * c.RATE) as [total],a.DESCRIPTION,c.WEIGHT,a.MUAND_RATE
	            from SALES a
	            inner join SALES_PROGRAM_MASTER b on a.SOP_ID = b.SPM_ID
	            inner join SALES_PROGRAM_DETAILS c on b.SPM_ID = c.SPM_ID
	            inner join PRODUCT_MASTER g on c.PRODUCT_ID = g.PM_ID
	            inner join COA d on b.CUSTOMER_ID = d.COA_ID
	            left join CUSTOMER_PROFILE e on d.COA_ID = e.COA_ID
	            left join SALES_PERSONS f on e.SALE_PER_ID = f.SALES_PER_ID
	            where d.COA_ID = '" + cmbCustomer.SelectedValue.ToString() + @"' and a.[DATE] 
	            between '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' and '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
            UNION ALL
	            select a.INVOICE_NO,a.DATE,d.COA_NAME as [customer],a.VEHICLE_NO,f.NAME,DATEADD(day,isnull(e.CREDIT_DAYS,0),a.date) as [due],
	            g.MATERIAL_NAME,c.QTY,c.RATE,(c.QTY * c.RATE) as [total],a.DESCRIPTION,c.WEIGHT,a.MUAND_RATE
	            from SALES a
	            inner join SALES_PROGRAM_MASTER b on a.SOP_ID = b.SPM_ID
	            inner join SALES_PROGRAM_DETAILS c on b.SPM_ID = c.SPM_ID
	            inner join MATERIALS g on c.PRODUCT_ID = g.MATERIAL_ID
	            inner join COA d on b.CUSTOMER_ID = d.COA_ID
	            left join CUSTOMER_PROFILE e on d.COA_ID = e.COA_ID
	            left join SALES_PERSONS f on e.SALE_PER_ID = f.SALES_PER_ID
	            where d.COA_ID = '" + cmbCustomer.SelectedValue.ToString() + @"' and a.[DATE] 
	            between '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' and '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
            UNION ALL
	            select a.INVOICE_NO,a.DATE,d.COA_NAME as [customer],a.VEHICLE_NO,f.NAME,DATEADD(day,isnull(e.CREDIT_DAYS,0),a.date) as [due],
	            g.PRODUCT_NAME,c.QTY,c.RATE,(c.QTY * c.RATE) as [total],a.DESCRIPTION,c.WEIGHT,a.MUAND_RATE
	            from SALES a
	            inner join GATE_PASS b on a.GPM_ID = b.GPM_ID
	            inner join GATE_PASS_DETAIL c on b.GPM_ID = c.GP_ID
	            inner join PRODUCT_MASTER g on c.PRODUCT_ID = g.PM_ID
	            inner join COA d on A.CUSTOMER_ID = d.COA_ID
	            left join CUSTOMER_PROFILE e on d.COA_ID = e.COA_ID
	            left join SALES_PERSONS f on e.SALE_PER_ID = f.SALES_PER_ID
	            where d.COA_ID = '" + cmbCustomer.SelectedValue.ToString() + @"' and a.[DATE] 
	            between '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' and '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
            UNION ALL
	            select a.INVOICE_NO,a.DATE,d.COA_NAME as [customer],a.VEHICLE_NO,f.NAME,DATEADD(day,isnull(e.CREDIT_DAYS,0),a.date) as [due],
	            g.MATERIAL_NAME,c.QTY,c.RATE,(c.QTY * c.RATE) as [total],a.DESCRIPTION,c.WEIGHT,a.MUAND_RATE
	            from SALES a
	            inner join GATE_PASS b on a.GPM_ID = b.GPM_ID
	            inner join GATE_PASS_DETAIL c on b.GPM_ID = c.GP_ID
	            inner join MATERIALS g on c.PRODUCT_ID = g.MATERIAL_ID
	            inner join COA d on A.CUSTOMER_ID = d.COA_ID
	            left join CUSTOMER_PROFILE e on d.COA_ID = e.COA_ID
	            left join SALES_PERSONS f on e.SALE_PER_ID = f.SALES_PER_ID
	            where d.COA_ID = '" + cmbCustomer.SelectedValue.ToString() + @"' and a.[DATE] 
	            between '" + Classes.Helper.ConvertDatetime(dtp_FROM.Value.Date) + "' and '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"' 
            ORDER BY [DATE]";

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
                        classHelper.dataR["InvoiceNo"] = classHelper.dr["INVOICE_NO"].ToString();
                        classHelper.dataR["date"] = Convert.ToDateTime(classHelper.dr["DATE"].ToString());
                        classHelper.dataR["customer"] = classHelper.dr["customer"].ToString();
                        classHelper.dataR["vehicleNo"] = classHelper.dr["VEHICLE_NO"].ToString();
                        classHelper.dataR["itemName"] = classHelper.dr["PRODUCT_NAME"].ToString();
                        classHelper.dataR["qty"] = Convert.ToDouble(classHelper.dr["QTY"].ToString());
                        classHelper.dataR["rate"] = Convert.ToDouble(classHelper.dr["RATE"].ToString());
                        classHelper.dataR["amount"] = Convert.ToDouble(classHelper.dr["total"].ToString());
                        classHelper.dataR["salePerson"] = classHelper.dr["NAME"].ToString();
                        classHelper.dataR["dueDate"] = Convert.ToDateTime(classHelper.dr["due"].ToString());
                        classHelper.dataR["description"] = classHelper.dr["DESCRIPTION"].ToString();
                        classHelper.dataR["muandRate"] = classHelper.dr["MUAND_RATE"].ToString();
                        classHelper.dataR["totalWeight"] = Convert.ToDouble(classHelper.dr["WEIGHT"].ToString());

                        classHelper.mds.Tables["SaleInvoice"].Rows.Add(classHelper.dataR);
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
            if (hasRows == 'Y')
            {
                classHelper.rpt = new ERP_Maaz_Oil.Forms.Reporting.frmReports();
                classHelper.rpt.GenerateReport("SaleInvoicesReport", classHelper.mds);
                classHelper.rpt.ShowDialog();
            } 
        }

        private void grpSALES_Enter(object sender, EventArgs e)
        {
            
        }
        
        private void btnINTER_SAVE_Click(object sender, EventArgs e)
        {
            if (cmbCustomer.SelectedIndex == 0)
            {
                MessageBox.Show("Select an Customer.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                ShowReport();
            }
            
        }

        private void frm_Account_Ledger_Load(object sender, EventArgs e)
        {
            LoadCustomer();
        }

        private void frm_Account_Ledger_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
