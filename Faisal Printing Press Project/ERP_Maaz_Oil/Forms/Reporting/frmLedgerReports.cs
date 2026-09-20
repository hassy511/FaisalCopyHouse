using CrystalDecisions.CrystalReports.Engine;
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
    public partial class frmLedgerReports : Form
    {
        public string headingTextChange { get; set; }
        Classes.Helper classHelper = new Classes.Helper();

        public frmLedgerReports()
        {
            InitializeComponent();
        }

        public void GenerateReport(string reportName, System.Data.DataSet ds)
        {
            if (reportName == "AL")
            {
                Reports.rpt_Accounts_Ledger rptAL = new Reports.rpt_Accounts_Ledger();
                rptAL.SetDataSource(ds.Tables["ACCOUNTS_LEDGER"]);
                crystalReportViewer1.ReportSource = rptAL;
            }
            //else if (reportName == "LedgerSummary")
            //{
            //    Reports.LedgerSummaryReport rptAL = new Reports.LedgerSummaryReport();
            //    rptAL.SetDataSource(ds.Tables["LedgerSummary"]);
            //    crystalReportViewer1.ReportSource = rptAL;
            //}
            //else if (reportName == "AgingReportC")
            //{
            //    Reports.rpt_AgingReportC rpt = new Reports.rpt_AgingReportC();
            //    rpt.SetDataSource(ds.Tables["AgingReport"]);
            //    crystalReportViewer1.ReportSource = rpt;
            //}
            //else if (reportName == "AgingReportCS")
            //{
            //    Reports.AgingSummaryO rpt1 = new Reports.AgingSummaryO();
            //    rpt1.SetDataSource(ds.Tables["AgingSummary"]);
            //    rpt1.Subreports[0].SetDataSource(ds.Tables["AgingOverAllSummary"]);
            //    crystalReportViewer1.ReportSource = rpt1;
            //}
            //else if (reportName == "AgingReportS")
            //{
            //    Reports.rpt_AgingReportS rpt = new Reports.rpt_AgingReportS();
            //    rpt.SetDataSource(ds.Tables["AgingReport"]);
            //    rpt.Subreports[0].SetDataSource(ds.Tables["AgingSummary"]);
            //    crystalReportViewer1.ReportSource = rpt;
            //}
            //else if (reportName == "AgingReportP")
            //{
            //    Reports.rpt_AgingReportP rpt = new Reports.rpt_AgingReportP();
            //    rpt.SetDataSource(ds.Tables["AgingReport"]);
            //    rpt.Subreports[0].SetDataSource(ds.Tables["AgingSummary"]);
            //    crystalReportViewer1.ReportSource = rpt;
            //}
            //else if (reportName == "AgingReport")
            //{
            //    Reports.rpt_AgingReport rpt = new Reports.rpt_AgingReport();
            //    rpt.SetDataSource(ds.Tables["AgingReport"]);
            //    rpt.Subreports[0].SetDataSource(ds.Tables["AgingSummary"]);
            //    crystalReportViewer1.ReportSource = rpt;
            //}
            //else if (reportName == "AgingReportSupplierO")
            //{
            //    Reports.rpt_SupplierOverAllAgingReport rpt = new Reports.rpt_SupplierOverAllAgingReport();
            //    rpt.SetDataSource(ds.Tables["SupplierAgingReport"]);
            //    rpt.Subreports[0].SetDataSource(ds.Tables["SupplierAgingSummary"]);
            //    crystalReportViewer1.ReportSource = rpt;
            //}
            //else if (reportName == "AgingReportSupplierD")
            //{
            //    Reports.rpt_SupplierDueDateAgingReport rpt = new Reports.rpt_SupplierDueDateAgingReport();
            //    rpt.SetDataSource(ds.Tables["SupplierAgingReport"]);
            //    rpt.Subreports[0].SetDataSource(ds.Tables["SupplierAgingSummary"]);
            //    crystalReportViewer1.ReportSource = rpt;
            //}
            //else if (reportName == "AgingReportSupplier")
            //{
            //    Reports.rpt_SupplierWiseAgingReport rpt = new Reports.rpt_SupplierWiseAgingReport();
            //    rpt.SetDataSource(ds.Tables["SupplierAgingReport"]);
            //    rpt.Subreports[0].SetDataSource(ds.Tables["SupplierAgingSummary"]);
            //    crystalReportViewer1.ReportSource = rpt;
            //}
        }
        private void frmReports_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void frmReports_Load(object sender, EventArgs e)
        {

        }
        private void SaleInvoiceReport(string invoiceNumber)
        {
            classHelper.query = @"select a.INVOICE_NO,a.DATE,d.COA_NAME as [customer],a.VEHICLE_NO,f.NAME,DATEADD(day,isnull(e.CREDIT_DAYS,0),a.date) as [due],
	        g.PRODUCT_NAME,c.QTY,c.RATE,(c.QTY * c.RATE) as [total],a.DESCRIPTION,c.WEIGHT,a.MUAND_RATE
	        from SALES a
	        inner join SALES_PROGRAM_MASTER b on a.SOP_ID = b.SPM_ID
	        inner join SALES_PROGRAM_DETAILS c on b.SPM_ID = c.SPM_ID
	        inner join PRODUCT_MASTER g on c.PRODUCT_ID = g.PM_ID
	        inner join COA d on b.CUSTOMER_ID = d.COA_ID
	        left join CUSTOMER_PROFILE e on d.COA_ID = e.COA_ID
	        left join SALES_PERSONS f on e.SALE_PER_ID = f.SALES_PER_ID
	        where a.INVOICE_NO = '"+invoiceNumber+ @"'
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
	        where a.INVOICE_NO = '" + invoiceNumber + @"'
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
	        where a.INVOICE_NO = '" + invoiceNumber + @"'
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
	        where a.INVOICE_NO = '" + invoiceNumber + @"'
        ORDER BY [DATE]";

            try
            {
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                classHelper.mds.Tables["SaleInvoice"].Clear();
                if (classHelper.dr.HasRows == true)
                {
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
                else {
                    return;
                }
                classHelper.rpt = new ERP_Maaz_Oil.Forms.Reporting.frmReports();
                classHelper.rpt.GenerateReport("SaleInvoice", classHelper.mds);
                classHelper.rpt.ShowDialog();
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
        private void SaleReturnInvoiceReport(string invoiceNumber)
        {
            classHelper.query = @"select a.INVOICE_NO,a.DATE,c.COA_NAME as [customer],a.VEHICLE_NO,d.PRODUCT_NAME,
            b.QTY,b.ITEM_RATE as [rate],(b.QTY * b.ITEM_RATE) as [total],
            isnull(f.NAME,'N/A') as [NAME],a.DESCRIPTION,a.MUAND_RATE,(select sum(ITEM_WEIGHT) from SALES_RETURN_DETAIL where SRM_ID = a.SRM_ID) as WEIGHT
            from SALES_RETURN_MASTER a 
            inner join SALES_RETURN_DETAIL b on a.SRM_ID = b.SRM_ID
            inner join COA c on a.CUSTOMER_ID = c.COA_ID
            inner join PRODUCT_MASTER d on b.ITEM_ID = d.PM_ID and b.ITEM_TYPE = 'P'
            left join CUSTOMER_PROFILE e on a.CUSTOMER_ID = e.COA_ID
            left join SALES_PERSONS f on e.SALE_PER_ID = f.SALES_PER_ID
            where a.INVOICE_NO = '" + invoiceNumber + @"'
            union all
            select a.INVOICE_NO,a.DATE,c.COA_NAME as [customer],a.VEHICLE_NO,d.MATERIAL_NAME as PRODUCT_NAME,
            b.QTY,b.ITEM_RATE as [rate],(b.QTY * b.ITEM_RATE) as [total],
            isnull(f.NAME,'N/A') as [NAME],a.DESCRIPTION,a.MUAND_RATE,(select sum(ITEM_WEIGHT) from SALES_RETURN_DETAIL where SRM_ID = a.SRM_ID) as WEIGHT
            from SALES_RETURN_MASTER a 
            inner join SALES_RETURN_DETAIL b on a.SRM_ID = b.SRM_ID
            inner join COA c on a.CUSTOMER_ID = c.COA_ID
            inner join MATERIALS d on b.ITEM_ID = d.MATERIAL_ID and b.ITEM_TYPE = 'R'
            left join CUSTOMER_PROFILE e on a.CUSTOMER_ID = e.COA_ID
            left join SALES_PERSONS f on e.SALE_PER_ID = f.SALES_PER_ID
            where a.INVOICE_NO = '" + invoiceNumber + @"'";

            try
            {
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                classHelper.mds.Tables["SaleInvoice"].Clear();
                if (classHelper.dr.HasRows == true)
                {
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
                        //classHelper.dataR["dueDate"] = Convert.ToDateTime(classHelper.dr["due"].ToString());
                        classHelper.dataR["description"] = classHelper.dr["DESCRIPTION"].ToString();
                        classHelper.dataR["muandRate"] = classHelper.dr["MUAND_RATE"].ToString();
                        classHelper.dataR["totalWeight"] = Convert.ToDouble(classHelper.dr["WEIGHT"].ToString());

                        classHelper.mds.Tables["SaleInvoice"].Rows.Add(classHelper.dataR);
                    }
                }
                else
                {
                    return;
                }
                classHelper.rpt = new ERP_Maaz_Oil.Forms.Reporting.frmReports();
                classHelper.rpt.GenerateReport("SaleReturnInvoice", classHelper.mds);
                classHelper.rpt.ShowDialog();
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
        private void PurchasesInvoiceReport(string invoiceNumber)
        {
            classHelper.query = @"SELECT A.INVOICE_NO AS [PI_NO],A.DATE,C.COA_NAME AS [SUPPLIER],A.DESCRIPTION,
            E.M_TYPE_NAME AS [materialType],D.MATERIAL_NAME AS [MATERIAL],
            A.NET_WEIGHT,A.KG_RATE,A.MUAND_RATE,(A.NET_WEIGHT / A.MUAND_VALUE) AS [MUAND_WEIGHT],
            A.NET_WEIGHT * A.KG_RATE AS [TOTAL],A.CREDIT_DAYS,B.PO_NUMBER,A.VEHICLE_NO,A.KORANGI_WEIGHT,
            A.CREDIT_DAYS AS [DUEDATE],A.MUAND_VALUE
            FROM PURCHASES A
            INNER JOIN PURCHASES_ORDER B ON A.PO_ID = B.PO_ID
            INNER JOIN COA C ON A.SUPPLIER_ID = C.COA_ID
            INNER JOIN MATERIALS D ON B.MATERIAL_ID = D.MATERIAL_ID
            INNER JOIN MATERIAL_TYPES E ON D.M_TYPE_ID = E.M_TYPE_ID
            WHERE A.INVOICE_NO = '" + invoiceNumber + @"'";

            try
            {
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                classHelper.mds.Tables["PI"].Clear();
                if (classHelper.dr.HasRows == true)
                {
                    while (classHelper.dr.Read())
                    {
                        classHelper.dataR = classHelper.mds.Tables["PI"].NewRow();
                        classHelper.dataR["PI_num"] = classHelper.dr["PI_NO"].ToString();
                        classHelper.dataR["date"] = classHelper.dr["DATE"].ToString();
                        classHelper.dataR["supplier"] = classHelper.dr["SUPPLIER"].ToString();
                        classHelper.dataR["description"] = classHelper.dr["DESCRIPTION"].ToString();
                        classHelper.dataR["material_type"] = classHelper.dr["materialType"].ToString(); 
                        classHelper.dataR["material"] = classHelper.dr["MATERIAL"].ToString();
                        classHelper.dataR["weight"] = Convert.ToDouble(classHelper.dr["NET_WEIGHT"].ToString());
                        classHelper.dataR["kgRate"] = Convert.ToDouble(classHelper.dr["KG_RATE"].ToString());
                        classHelper.dataR["munadRate"] = Convert.ToDouble(classHelper.dr["MUAND_RATE"].ToString());
                        classHelper.dataR["m_weight"] = Convert.ToDouble(classHelper.dr["MUAND_WEIGHT"].ToString());
                        classHelper.dataR["total"] = classHelper.dr["TOTAL"].ToString();
                        classHelper.dataR["creditDays"] = classHelper.dr["CREDIT_DAYS"].ToString();
                        classHelper.dataR["PO_no"] = classHelper.dr["PO_NUMBER"].ToString();
                        classHelper.dataR["vehicleNo"] = classHelper.dr["VEHICLE_NO"].ToString();
                        classHelper.dataR["korangiWeight"] = classHelper.dr["KORANGI_WEIGHT"].ToString();
                        classHelper.dataR["dueDate"] = DateTime.Now.AddDays(Convert.ToDouble(classHelper.dr["DUEDATE"].ToString()));
                        classHelper.dataR["muandValue"] = Convert.ToDouble(classHelper.dr["MUAND_VALUE"].ToString());
                        classHelper.mds.Tables["PI"].Rows.Add(classHelper.dataR);
                    }
                }
                else
                {
                    return;
                }
                classHelper.rpt = new ERP_Maaz_Oil.Forms.Reporting.frmReports();
                classHelper.rpt.GenerateReport("PI", classHelper.mds);
                classHelper.rpt.ShowDialog();
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

        private void VoucherReport(string refNumber) {
            if (refNumber.Contains("JV"))
            {
                PrintJournalVoucher(refNumber);
            }
            else if (refNumber.Contains("CRV"))
            {
                PrintCashReceiptVoucher(refNumber);
            }
            else if (refNumber.Contains("CPV"))
            {
                PrintCashPaymentVoucher(refNumber);
            }
            
        }

        private void PrintCashReceiptVoucher(string refNumber)
        {
            char hasRows = 'N';
            try
            {
                classHelper.query = @"SELECT CRV_ID AS [ID],B.REC_PERSON_NAME AS [REC_FROM],C.COA_NAME AS [DEBIT_TO],A.DAATE AS [DATE],
                A.CRV_CODE AS FOLIO,A.[DESCRIPTION],A.REF_ACCOUNT,A.AMOUNT
                FROM CASH_REC_VOUCHER A
                INNER JOIN RECOVERY_PERSON B ON A.REC_PERSON_ID = B.REC_PERSON_ID
                INNER JOIN COA C ON A.COA_ID = C.COA_ID
                WHERE A.CRV_ID = (SELECT TOP 1 REF_ID FROM LEDGERS WHERE FOLIO = '" + refNumber + @"')";
                               
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    hasRows = 'Y';
                    classHelper.mds.Tables["ReceiptPaymentVoucher"].Clear();
                    while (classHelper.dr.Read())
                    {
                        classHelper.dataR = classHelper.mds.Tables["ReceiptPaymentVoucher"].NewRow();
                        classHelper.dataR["id"] = Convert.ToDouble(classHelper.dr["ID"].ToString());
                        classHelper.dataR["paidRecTo"] = classHelper.dr["REC_FROM"].ToString();
                        classHelper.dataR["debitCreditAc"] = classHelper.dr["DEBIT_TO"].ToString();
                        classHelper.dataR["date"] = Convert.ToDateTime(classHelper.dr["DATE"].ToString());
                        classHelper.dataR["chqNo"] = classHelper.dr["FOLIO"].ToString();
                        classHelper.dataR["chqDate"] = classHelper.dr["DESCRIPTION"].ToString();
                        classHelper.dataR["bankName"] = classHelper.dr["REF_ACCOUNT"].ToString();
                        classHelper.dataR["amount"] = Convert.ToDouble(classHelper.dr["AMOUNT"].ToString());
                        classHelper.dataR["voucherName"] = "CASH RECEIPT VOUCHER";
                        classHelper.dataR["custName"] = classHelper.dr["FOLIO"].ToString();
                        classHelper.mds.Tables["ReceiptPaymentVoucher"].Rows.Add(classHelper.dataR);
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
                classHelper.rpt.GenerateReport("CashReceiptVoucher", classHelper.mds);
                classHelper.rpt.ShowDialog();
            }
        }

        private void PrintCashPaymentVoucher(string refNumber)
        {
            char hasRows = 'N';
            try
            {
                classHelper.query = @"SELECT CPV_ID AS [ID],A.PAID_TO AS [PAID TO],C.COA_NAME AS [DEBIT_TO],A.DAATE AS [DATE],
	            A.CPV_CODE AS FOLIO,A.REF_ACCOUNT,A.AMOUNT,A.ACCOUNT_OF
	            FROM CASH_PAY_VOUCHER A 
	            INNER JOIN COA C ON A.COA_ID = C.COA_ID
	            WHERE A.CPV_ID = (SELECT TOP 1 REF_ID FROM LEDGERS WHERE FOLIO = '" + refNumber + @"')";

                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    hasRows = 'Y';
                    classHelper.mds.Tables["ReceiptPaymentVoucher"].Clear();
                    while (classHelper.dr.Read())
                    {
                        classHelper.dataR = classHelper.mds.Tables["ReceiptPaymentVoucher"].NewRow();
                        classHelper.dataR["id"] = Convert.ToDouble(classHelper.dr["ID"].ToString());
                        classHelper.dataR["paidRecTo"] = classHelper.dr["PAID TO"].ToString();
                        classHelper.dataR["debitCreditAc"] = classHelper.dr["DEBIT_TO"].ToString();
                        classHelper.dataR["date"] = Convert.ToDateTime(classHelper.dr["DATE"].ToString());
                        classHelper.dataR["bankName"] = classHelper.dr["REF_ACCOUNT"].ToString();
                        classHelper.dataR["chqDate"] = classHelper.dr["ACCOUNT_OF"].ToString();
                        classHelper.dataR["custName"] = classHelper.dr["FOLIO"].ToString();
                        classHelper.dataR["amount"] = Convert.ToDouble(classHelper.dr["AMOUNT"].ToString());
                        classHelper.dataR["voucherName"] = "CASH PAYMENT VOUCHER";
                        classHelper.mds.Tables["ReceiptPaymentVoucher"].Rows.Add(classHelper.dataR);
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
                classHelper.rpt.GenerateReport("CashPaymentVoucher", classHelper.mds);
                classHelper.rpt.ShowDialog();
            }
            
        }

        private void PrintJournalVoucher(string refNumber)
        {
            char hasRows = 'N';
            if (Classes.Helper.conn.State == System.Data.ConnectionState.Closed) { Classes.Helper.conn.Open(); }
            try
            {
                classHelper.query = @"SELECT A.DAATE,A.GV_CODE,C.COA_NAME,B.NARRATION,B.DEBIT,0 AS [CREDIT]
                FROM GENERAL_VOUCHER_M A 
                INNER JOIN GENERAL_VOUCHER_D B ON A.GV_ID = B.GV_ID
                INNER JOIN COA C ON B.COA_ID = C.COA_ID
                WHERE A.GV_ID = (SELECT TOP 1 REF_ID FROM LEDGERS WHERE FOLIO = '"+refNumber+ @"')
                AND B.DEBIT <> 0
                UNION ALL
                SELECT A.DAATE,A.GV_CODE,C.COA_NAME,B.NARRATION,0 AS [DEBIT],B.CREDIT
                FROM GENERAL_VOUCHER_M A 
                INNER JOIN GENERAL_VOUCHER_D B ON A.GV_ID = B.GV_ID
                INNER JOIN COA C ON B.COA_ID = C.COA_ID
                WHERE A.GV_ID = (SELECT TOP 1 REF_ID FROM LEDGERS WHERE FOLIO = '" + refNumber + @"')
                AND B.CREDIT <> 0";

                
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.cmd.CommandTimeout = 0;
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows)
                {
                    hasRows = 'Y';
                    classHelper.nds.Tables["JV"].Clear();
                    while (classHelper.dr.Read())
                    {
                        classHelper.dataR = classHelper.nds.Tables["JV"].NewRow();
                        classHelper.dataR["date"] = Convert.ToDateTime(classHelper.dr["DAATE"].ToString());
                        classHelper.dataR["voucherNo"] = classHelper.dr["GV_CODE"].ToString();
                        classHelper.dataR["accountName"] = classHelper.dr["COA_NAME"].ToString();
                        classHelper.dataR["description"] = classHelper.dr["NARRATION"].ToString();
                        classHelper.dataR["debit"] = Convert.ToDouble(classHelper.dr["DEBIT"].ToString());
                        classHelper.dataR["credit"] = Convert.ToDouble(classHelper.dr["CREDIT"].ToString());
                        classHelper.nds.Tables["JV"].Rows.Add(classHelper.dataR);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Classes.Helper.conn.Close();
            }

            if (hasRows == 'Y') {
                classHelper.rpt = new Forms.Reporting.frmReports();
                classHelper.rpt.GenerateReport("JV", classHelper.nds);
                classHelper.rpt.ShowDialog();
            }
        }

        private void crystalReportViewer1_ClickPage(object sender, CrystalDecisions.Windows.Forms.PageMouseEventArgs e)
        {
            if (e.ObjectInfo.Name == "REFNO1")
            {
                if (e.ObjectInfo.Text.Contains("SI")) {
                    classHelper.PrintSalesInvoice(e.ObjectInfo.Text);
                }
                else if (e.ObjectInfo.Text.Contains("PSI"))
                {
                    classHelper.PrintServiceSalesInvoice(e.ObjectInfo.Text);
                }
                //else if(e.ObjectInfo.Text.Contains("PI") || e.ObjectInfo.Text.Contains("PST")) {
                //    PurchasesInvoiceReport(e.ObjectInfo.Text);
                //}
                //else if (e.ObjectInfo.Text.Contains("SR"))
                //{
                //    SaleReturnInvoiceReport(e.ObjectInfo.Text);
                //}
                //else 
                //{
                //    VoucherReport(e.ObjectInfo.Text);
                //}
            }
            //else if (e.ObjectInfo.Name == "Invoice1")
            //{
            //    if (e.ObjectInfo.Text.Contains("SI"))
            //    {
            //        SaleInvoiceReport(e.ObjectInfo.Text);
            //    }
            //    else if (e.ObjectInfo.Text.Contains("PI") || e.ObjectInfo.Text.Contains("PST"))
            //    {
            //        PurchasesInvoiceReport(e.ObjectInfo.Text);
            //    }
            //    else if (e.ObjectInfo.Text.Contains("SR"))
            //    {
            //        SaleReturnInvoiceReport(e.ObjectInfo.Text);
            //    }
            //}
        }
    }
}
