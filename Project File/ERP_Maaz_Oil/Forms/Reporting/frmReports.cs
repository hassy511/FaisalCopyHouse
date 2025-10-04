using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ERP_Maaz_Oil.Forms.Reporting
{
    public partial class frmReports : Form
    {
        public string headingTextChange { get; set; }

        public frmReports()
        {
            InitializeComponent();
        }

        public void GenerateReport(string reportName, System.Data.DataSet ds)
        {
            if (reportName == "PO_M")
            {
                Reports.rptPO rptPO = new Reports.rptPO();
                rptPO.SetDataSource(ds.Tables["PO_M"]);

                crystalReportViewer1.ReportSource = rptPO;
            }
            else if (reportName == "ReceivablesSummary")
            {
                Reports.rptAccountsSummary rpt = new Reports.rptAccountsSummary();
                rpt.SetDataSource(ds.Tables["ReceivablesSummary"]);
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (reportName == "PrintingSalesProfit")
            {
                Reports.ServiceSales rpt = new Reports.ServiceSales();
                rpt.SetDataSource(ds.Tables["SERVICE_SALE"]);
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (reportName == "StockReportCustom")
            {
                Reports.rpt_StockReport_Custom rpt = new Reports.rpt_StockReport_Custom();
                rpt.SetDataSource(ds.Tables["StockReport"]);
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (reportName == "StockReport")
            {
                Reports.rpt_StockReport rpt = new Reports.rpt_StockReport();
                rpt.SetDataSource(ds.Tables["StockReport"]);
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (reportName == "MaterialStockReport")
            {
                Reports.rpt_MaterialStockReport rpt = new Reports.rpt_MaterialStockReport();
                rpt.SetDataSource(ds.Tables["StockReport"]);
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (reportName == "CustomerProfileReport")
            {
                Reports.CustomerProfileReport rpt = new Reports.CustomerProfileReport();
                rpt.SetDataSource(ds.Tables["CustomerProfile"]);
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (reportName == "SalesInvoiceHistory")
            {
                Reports.SalesInvoiceHistory rpt = new Reports.SalesInvoiceHistory();
                rpt.SetDataSource(ds.Tables["SalesInvoiceHistory"]);
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (reportName == "ChqReturn")
            {
                try
                {
                    Classes.Helper hlp = new Classes.Helper();
                    Vouchers.Reports.rptChqReturn rpt = new Vouchers.Reports.rptChqReturn();
                    rpt.SetDataSource(ds.Tables["ChqReturnVoucher"]);
                    rpt.SetParameterValue("RupeesValue", hlp.ConvertWholeNumber(
                        ds.Tables["ChqReturnVoucher"].AsEnumerable()
                        .Sum(x => x.Field<decimal>("debit"))
                        .ToString()
                    ));
                    crystalReportViewer1.ReportSource = rpt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (reportName == "BankBookReport")
            {
                Reports.BankBookReport rptPI = new Reports.BankBookReport();
                rptPI.SetDataSource(ds.Tables["BankBook"]);
                rptPI.Subreports[0].SetDataSource(ds.Tables["PayAccountSummary"]);
                rptPI.Subreports[1].SetDataSource(ds.Tables["RecAccountSummary"]);
                crystalReportViewer1.ReportSource = rptPI;
            }
            else if (reportName == "MaterialClosingSummary")
            {
                Reports.MaterialClosingSummaryReport rpt = new Reports.MaterialClosingSummaryReport();
                rpt.SetDataSource(ds.Tables["MaterialClosingSummary"]);
                rpt.Subreports[0].SetDataSource(ds.Tables["MaterialClosingDetail"]);
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (reportName == "PurchaseSalesTransfer")
            {
                Reports.rptPurchaseSalesDifference rptPI = new Reports.rptPurchaseSalesDifference();
                rptPI.SetDataSource(ds.Tables["PurchaseSalesFromTo"]);
                if (ds.Tables["Purchases"].Rows.Count <= 0)
                    rptPI.Subreports[1].Dispose();
                else
                    rptPI.Subreports[1].SetDataSource(ds.Tables["Purchases"]);
                if (ds.Tables["Sales"].Rows.Count <= 0)
                    rptPI.Subreports[2].Dispose();
                else
                    rptPI.Subreports[2].SetDataSource(ds.Tables["Sales"]);
                rptPI.Subreports[0].SetDataSource(ds.Tables["PurchaseSaleDifference"]);

                crystalReportViewer1.ReportSource = rptPI;
            }
            else if (reportName == "BalanceSheet")
            {
                Reports.rpt_BalanceSheet rpt = new Reports.rpt_BalanceSheet();
                rpt.SetDataSource(ds.Tables["TrialBalance"]);
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (reportName == "RawMaterialReport")
            {
                Reports.RawMaterialOverallReport rpt = new Reports.RawMaterialOverallReport();
                rpt.SetDataSource(ds.Tables["RawMaterialReport"]);
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (reportName == "RawMaterialReportConsolidated")
            {
                Reports.RawMaterialOverallReportConsolidated rpt = new Reports.RawMaterialOverallReportConsolidated();
                rpt.SetDataSource(ds.Tables["RawMaterialReport"]);
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (reportName == "RawMaterialDatewiseReport")
            {
                Reports.RawMaterialOverallDateWiseReport rpt = new Reports.RawMaterialOverallDateWiseReport();
                rpt.SetDataSource(ds.Tables["RawMaterialReport"]);
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (reportName == "RawMaterialDatewiseReportConsolidated")
            {
                Reports.RawMaterialOverallDateWiseReportConsolidated rpt = new Reports.RawMaterialOverallDateWiseReportConsolidated();
                rpt.SetDataSource(ds.Tables["RawMaterialReport"]);
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (reportName == "IncomeStatement")
            {
                Reports.rpt_IncomeStatement rpt = new Reports.rpt_IncomeStatement();
                rpt.SetDataSource(ds.Tables["IncomeStatement"]);
                crystalReportViewer1.ReportSource = rpt;
            }

            else if (reportName == "TrialBalanceUpto")
            {
                Reports.rpt_TrialBalanceUpto rpt = new Reports.rpt_TrialBalanceUpto();
                rpt.SetDataSource(ds.Tables["TrialBalance"]);
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (reportName == "TrialBalanceUptoConsolidated")
            {
                Reports.rpt_TrialBalanceUpto_Consolidated rpt = new Reports.rpt_TrialBalanceUpto_Consolidated();
                rpt.SetDataSource(ds.Tables["TrialBalance"]);
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (reportName == "TrialBalanceRange")
            {
                Reports.rpt_TrialBalanceRange rpt = new Reports.rpt_TrialBalanceRange();
                rpt.SetDataSource(ds.Tables["TrialBalance"]);
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (reportName == "MaterialPurchasesSummary")
            {
                Reports.MaterialPurchasesSummaryReport rpt = new Reports.MaterialPurchasesSummaryReport();
                rpt.SetDataSource(ds.Tables["MaterialPurchasesSummary"]);
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (reportName == "SupplierCustomerOutstanding")
            {
                Reports.SupplierCustomerOutstanding rpt = new Reports.SupplierCustomerOutstanding();

                decimal customerTotal = ds.Tables["CustomerOutstanding"].Rows.Count > 0 ?
                    Convert.ToDecimal(ds.Tables["CustomerOutstanding"].Compute("SUM(balance)", string.Empty)) : 0;
                decimal supplierTotal = ds.Tables["SupplierOutstanding"].Rows.Count > 0 ?
                    Convert.ToDecimal(ds.Tables["SupplierOutstanding"].Compute("SUM(balance)", string.Empty)) : 0;
                decimal balance = customerTotal - supplierTotal;

                //TextObject txtCustomer = (TextObject)rpt.ReportDefinition.ReportObjects["txtCustomerTotal"];
                //txtCustomer.Text = String.Format("{0:0,0.00}", customerTotal);

                TextObject txtSupplier = (TextObject)rpt.ReportDefinition.ReportObjects["txtSupplierTotal"];
                txtSupplier.Text = String.Format("{0:0,0.00}", supplierTotal);

                TextObject txtBalance = (TextObject)rpt.ReportDefinition.ReportObjects["txtBalance"];
                txtBalance.Text = String.Format("{0:0,0.00}", balance);

                rpt.Subreports[0].SetDataSource(ds.Tables["CustomerOutstanding"]);
                rpt.Subreports[1].SetDataSource(ds.Tables["SupplierOutstanding"]);
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (reportName == "SO_Approval_Report")
            {
                Reports.rptSOApprovalReport rpt = new Reports.rptSOApprovalReport();
                rpt.SetDataSource(ds.Tables["SO_Report"]);
                rpt.Subreports[0].SetDataSource(ds.Tables["SO_Summary"]);
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (reportName == "SupplierOutstanding")
            {
                Reports.SupplierOutstanding rpt = new Reports.SupplierOutstanding();
                rpt.SetDataSource(ds.Tables["SupplierOutstanding"]);
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (reportName == "CustomerOutstanding")
            {
                Reports.CustomerOutstanding rpt = new Reports.CustomerOutstanding();
                rpt.SetDataSource(ds.Tables["CustomerOutstanding"]);
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (reportName == "AgingReportSupplierO")
            {
                Reports.rpt_SupplierOverAllAgingReport rpt = new Reports.rpt_SupplierOverAllAgingReport();
                rpt.SetDataSource(ds.Tables["SupplierAgingReport"]);
                rpt.Subreports[0].SetDataSource(ds.Tables["SupplierAgingSummary"]);
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (reportName == "AgingReportSupplierD")
            {
                Reports.rpt_SupplierDueDateAgingReport rpt = new Reports.rpt_SupplierDueDateAgingReport();
                rpt.SetDataSource(ds.Tables["SupplierAgingReport"]);
                rpt.Subreports[0].SetDataSource(ds.Tables["SupplierAgingSummary"]);
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (reportName == "AgingReportSupplier")
            {
                Reports.rpt_SupplierWiseAgingReport rpt = new Reports.rpt_SupplierWiseAgingReport();
                rpt.SetDataSource(ds.Tables["SupplierAgingReport"]);
                rpt.Subreports[0].SetDataSource(ds.Tables["SupplierAgingSummary"]);
                crystalReportViewer1.ReportSource = rpt;
            }

            else if (reportName == "BV")
            {
                Reports.rpt_BankVoucher rpt = new Reports.rpt_BankVoucher();
                rpt.SetDataSource(ds.Tables["BV"]);
                crystalReportViewer1.ReportSource = rpt;
            }

            else if (reportName == "BVR")
            {
                Reports.rpt_BankVoucherReport rpt = new Reports.rpt_BankVoucherReport();
                rpt.SetDataSource(ds.Tables["BV"]);
                crystalReportViewer1.ReportSource = rpt;
            }

            else if (reportName == "PI")
            {
                Reports.rptPI rptPI = new Reports.rptPI();
                rptPI.SetDataSource(ds.Tables["PI"]);

                crystalReportViewer1.ReportSource = rptPI;
            }
            else if (reportName == "PSI")
            {
                Reporting.Reports.rptPurchasesSalesInvoice rpt = new Reporting.Reports.rptPurchasesSalesInvoice();
                rpt.SetDataSource(ds.Tables["PI"]);

                crystalReportViewer1.ReportSource = rpt;
            }
            else if (reportName == "CashAndBank")
            {

                Reports.BankAndCashReport rptCashBank = new Reports.BankAndCashReport();
                rptCashBank.SetDataSource(ds.Tables["CashAndBank"]);

                crystalReportViewer1.ReportSource = rptCashBank;
            }
            else if (reportName == "AL")
            {
                Reports.rpt_Accounts_Ledger rptAL = new Reports.rpt_Accounts_Ledger();
                rptAL.SetDataSource(ds.Tables["ACCOUNTS_LEDGER"]);
                crystalReportViewer1.ReportSource = rptAL;
            }
            else if (reportName == "JV")
            {
                Reports.rpt_JournalVoucher rpt = new Reports.rpt_JournalVoucher();
                rpt.SetDataSource(ds.Tables["JV"]);
                crystalReportViewer1.ReportSource = rpt;
            }

            else if (reportName == "JVReport")
            {
                Reports.JournalVoucherReport rpt = new Reports.JournalVoucherReport();
                rpt.SetDataSource(ds.Tables["JVReport"]);
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (reportName == "CHQINHAND")
            {
                Reports.rptCHQinHand rptChqinHand = new Reports.rptCHQinHand();

                if (headingTextChange != null)
                    ((TextObject)rptChqinHand.Section1.ReportObjects["headingText"]).Text = headingTextChange;
                rptChqinHand.SetDataSource(ds.Tables["ChqInHand"]);
                crystalReportViewer1.ReportSource = rptChqinHand;
            }
            else if (reportName == "CHQRCVD")
            {
                Reports.rptChqRcvd rptChqinHand = new Reports.rptChqRcvd();

                if (headingTextChange != null)
                    ((TextObject)rptChqinHand.Section1.ReportObjects["headingText"]).Text = headingTextChange;
                rptChqinHand.SetDataSource(ds.Tables["ChqInHand"]);
                crystalReportViewer1.ReportSource = rptChqinHand;
            }
            else if (reportName == "CHQACC")
            {
                Reports.rptChqAccount rptChqinHand = new Reports.rptChqAccount();

                if (headingTextChange != null)
                    ((TextObject)rptChqinHand.Section1.ReportObjects["headingText"]).Text = headingTextChange;
                rptChqinHand.SetDataSource(ds.Tables["ChqPaid"]);
                crystalReportViewer1.ReportSource = rptChqinHand;
            }

            else if (reportName == "CHQPAID")
            {
                Reports.rptChqPaid rptChqinHand = new Reports.rptChqPaid();

                if (headingTextChange != null)
                    ((TextObject)rptChqinHand.Section1.ReportObjects["headingText"]).Text = headingTextChange;
                rptChqinHand.SetDataSource(ds.Tables["ChqPaid"]);
                crystalReportViewer1.ReportSource = rptChqinHand;
            }
            else if (reportName == "PO_Report")
            {
                Reports.rptPOReport rptPOR = new Reports.rptPOReport();
                rptPOR.SetDataSource(ds.Tables["PO_Report"]);
                rptPOR.Subreports[0].SetDataSource(ds.Tables["PO_Summary"]);
                crystalReportViewer1.ReportSource = rptPOR;
            }
            else if (reportName == "PI_Report")
            {
                Reports.rptPIReport rptPOR = new Reports.rptPIReport();
                rptPOR.SetDataSource(ds.Tables["PI_Report"]);
                //rptPOR.Subreports[0].SetDataSource(ds.Tables["PI_Summary"]);
                crystalReportViewer1.ReportSource = rptPOR;
            }
            else if (reportName == "SalesInvoiceReport")
            {
                Reports.rptSalesInvoiceReport rptSIR = new Reports.rptSalesInvoiceReport();
                rptSIR.SetDataSource(ds.Tables["SalesInvoiceReport"]);
                crystalReportViewer1.ReportSource = rptSIR;
            }
            else if (reportName == "Quotation")
            {
                Reports.QuotationPrint rpt = new Reports.QuotationPrint();
                rpt.SetDataSource(ds.Tables["GeneralOrderSupply"]);
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (reportName == "SalesInvoice")
            {
                Reports.rptSaleInvoiceThermal rpt = new Reports.rptSaleInvoiceThermal();
                rpt.SetDataSource(ds.Tables["SaleInvoice"]);
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (reportName == "DeliveryChallan")
            {
                Reports.DeliveryChallanInvoice rpt = new Reports.DeliveryChallanInvoice();
                rpt.SetDataSource(ds.Tables["GeneralOrderSupply"]);
                crystalReportViewer1.ReportSource = rpt;
            }

            else if (reportName == "SalesInvoiceSummaryReport")
            {
                Reports.SalesInvoiceSummaryReport rptSISR = new Reports.SalesInvoiceSummaryReport();
                rptSISR.SetDataSource(ds.Tables["SalesInvoiceSummaryReport"]);
                crystalReportViewer1.ReportSource = rptSISR;
            }
            else if (reportName == "SalesInvoiceReportSP")
            {
                Reports.rptSalesInvoiceReportSP rptSIR = new Reports.rptSalesInvoiceReportSP();
                rptSIR.SetDataSource(ds.Tables["SalesInvoiceReport"]);
                crystalReportViewer1.ReportSource = rptSIR;
            }
            else if (reportName == "SalesInvoiceSummaryReportSP")
            {
                Reports.SalesInvoiceSummaryReportSP rptSISR = new Reports.SalesInvoiceSummaryReportSP();
                rptSISR.SetDataSource(ds.Tables["SalesInvoiceSummaryReport"]);
                crystalReportViewer1.ReportSource = rptSISR;
            }
            else if (reportName == "rptPI_InwardReport")
            {
                Reports.rptPI_InwardReport rptPoInward = new Reports.rptPI_InwardReport();
                rptPoInward.SetDataSource(ds.Tables["PO_Inward"]);
                crystalReportViewer1.ReportSource = rptPoInward;
            }
            else if (reportName == "GatePass")
            {
                Reports.rptGatePass rptGatePass = new Reports.rptGatePass();
                rptGatePass.SetDataSource(ds.Tables["GatePass"]);
                crystalReportViewer1.ReportSource = rptGatePass;
            }
            else if (reportName == "SalesProgramInvoiceWO")
            {
                Sales.Reports.rptSalesProgramInvoiceWOrate rpt = new Sales.Reports.rptSalesProgramInvoiceWOrate();
                rpt.SetDataSource(ds.Tables["SalesProgramInvoice"]);
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (reportName == "SalesProgramInvoice")
            {
                Sales.Reports.rptSalesProgramInvoice rpt = new Sales.Reports.rptSalesProgramInvoice();
                rpt.SetDataSource(ds.Tables["SalesProgramInvoice"]);
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (reportName == "SR_Invoice")
            {
                Reports.rptSR_Report rpt = new Reports.rptSR_Report();
                rpt.SetDataSource(ds.Tables["SaleInvoice"]);
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (reportName == "JobOrder")
            {
                Reports.rptJobOrder rpt = new Reports.rptJobOrder();
                rpt.SetDataSource(ds.Tables["SaleInvoice"]);
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (reportName == "StockIssuance")
            {
                Reports.rptStockIssuance rpt = new Reports.rptStockIssuance();
                rpt.SetDataSource(ds.Tables["SaleInvoice"]);
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (reportName == "SaleInvoiceOrignal")
            {
                Reports.rptSaleInvoice_Orignal rptSaleInvoiceOrignal = new Reports.rptSaleInvoice_Orignal();
                rptSaleInvoiceOrignal.SetDataSource(ds.Tables["SaleInvoice"]);
                crystalReportViewer1.ReportSource = rptSaleInvoiceOrignal;
            }
            else if (reportName == "SaleInvoiceDuplicate")
            {
                Reports.rptSaleInvoice_Duplicate rptSaleInvoiceDuplicate = new Reports.rptSaleInvoice_Duplicate();
                rptSaleInvoiceDuplicate.SetDataSource(ds.Tables["SaleInvoice"]);
                crystalReportViewer1.ReportSource = rptSaleInvoiceDuplicate;
            }
            else if (reportName == "SaleInvoiceGatePass")
            {
                Reports.rptSaleInvoice_GatePass rpt = new Reports.rptSaleInvoice_GatePass();
                rpt.SetDataSource(ds.Tables["SaleInvoice"]);
                crystalReportViewer1.ReportSource = rpt;
            }

            else if (reportName == "SO_Report")
            {
                Reports.rptSOReport rptSOR = new Reports.rptSOReport();
                rptSOR.SetDataSource(ds.Tables["PO_Report"]);
                rptSOR.Subreports[0].SetDataSource(ds.Tables["PO_Summary"]);
                crystalReportViewer1.ReportSource = rptSOR;
            }
            else if (reportName == "BrandReport")
            {
                Reports.BrandReport rptSIR = new Reports.BrandReport();
                rptSIR.SetDataSource(ds.Tables["BrandWiseReport"]);
                crystalReportViewer1.ReportSource = rptSIR;
            }
            else if (reportName == "BrandSummaryReport")
            {
                Reports.BrandSummaryReport rptSISR = new Reports.BrandSummaryReport();
                rptSISR.SetDataSource(ds.Tables["BrandWiseReportSummary"]);
                crystalReportViewer1.ReportSource = rptSISR;
            }
            else if (reportName == "ProvinceWiseReportSP")
            {
                Reports.rptSalesPersonReportProvince rptSIR = new Reports.rptSalesPersonReportProvince();
                rptSIR.SetDataSource(ds.Tables["ProvinceWiseReport"]);
                rptSIR.Subreports[0].SetDataSource(ds.Tables["ProvinceWiseReportSummary"]);
                crystalReportViewer1.ReportSource = rptSIR;
            }
            else if (reportName == "ProvinceWiseReportSummarySP")
            {
                Reports.SalesSummaryProvinceSP rptSISR = new Reports.SalesSummaryProvinceSP();
                rptSISR.SetDataSource(ds.Tables["ProvinceWiseReportSummary"]);
                crystalReportViewer1.ReportSource = rptSISR;
            }
            else if (reportName == "ProvinceWiseReportSalePerson")
            {
                Reports.rptSalesPersonReportProvinceSP rptSIR = new Reports.rptSalesPersonReportProvinceSP();
                rptSIR.SetDataSource(ds.Tables["ProvinceWiseReport"]);
                rptSIR.Subreports[0].SetDataSource(ds.Tables["ProvinceWiseReportSummary"]);
                crystalReportViewer1.ReportSource = rptSIR;
            }
            else if (reportName == "ProvinceWiseReportSummarySalePerson")
            {
                Reports.SalesSummaryProvinceSalePerson rptSISR = new Reports.SalesSummaryProvinceSalePerson();
                rptSISR.SetDataSource(ds.Tables["ProvinceWiseReportSummary"]);
                crystalReportViewer1.ReportSource = rptSISR;
            }
            else if (reportName == "ProvinceWiseReport")
            {
                Reports.rptSalesInvoiceReportProvince rptSIR = new Reports.rptSalesInvoiceReportProvince();
                rptSIR.SetDataSource(ds.Tables["ProvinceWiseReport"]);
                crystalReportViewer1.ReportSource = rptSIR;
            }
            else if (reportName == "ProvinceWiseReportSummary")
            {
                Reports.SalesSummaryProvince rptSISR = new Reports.SalesSummaryProvince();
                rptSISR.SetDataSource(ds.Tables["ProvinceWiseReportSummary"]);
                crystalReportViewer1.ReportSource = rptSISR;
            }
            else if (reportName == "SalesInvoiceReportInvoiceWise")
            {
                Reports.rptSalesInvoiceReportInvoice rptSIR = new Reports.rptSalesInvoiceReportInvoice();
                rptSIR.SetDataSource(ds.Tables["SalesInvoiceReport"]);
                crystalReportViewer1.ReportSource = rptSIR;
            }
            else if (reportName == "SalesInvoiceSummaryReportInvoiceWise")
            {
                Reports.SalesInvoiceSummaryReportInvoice rptSISR = new Reports.SalesInvoiceSummaryReportInvoice();
                rptSISR.SetDataSource(ds.Tables["SalesInvoiceSummaryReport"]);
                crystalReportViewer1.ReportSource = rptSISR;
            }
            else if (reportName == "PaymentTransferSheet")
            {
                Reports.PaymentTransferSheet rptSISR = new Reports.PaymentTransferSheet();
                rptSISR.SetDataSource(ds.Tables["PaymentTransferSheet"]);
                crystalReportViewer1.ReportSource = rptSISR;
            }
            else if (reportName == "ConformationReport")
            {
                Reports.PTConformationReport rpt = new Reports.PTConformationReport();
                rpt.SetDataSource(ds.Tables["PaymentTransferSheet"]);
                rpt.Subreports[0].SetDataSource(ds.Tables["PaymentSalesPersonSummary"]);
                rpt.Subreports[1].SetDataSource(ds.Tables["PaymentAccountSummary"]);
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (reportName == "PendingReport")
            {
                Reports.PTPendingReport rpt = new Reports.PTPendingReport();
                rpt.SetDataSource(ds.Tables["PaymentTransferSheet"]);
                rpt.Subreports[0].SetDataSource(ds.Tables["PaymentSalesPersonSummary"]);
                rpt.Subreports[1].SetDataSource(ds.Tables["PaymentAccountSummary"]);
                crystalReportViewer1.ReportSource = rpt;
            }

            else if (reportName == "SpPendingReport")
            {
                Reports.PTSPPendingReport rpt = new Reports.PTSPPendingReport();
                rpt.SetDataSource(ds.Tables["PaymentTransferSheet"]);
                crystalReportViewer1.ReportSource = rpt;
            }

            else if (reportName == "DailyReport")
            {
                Reports.PTDailyReport rpt = new Reports.PTDailyReport();
                rpt.SetDataSource(ds.Tables["PaymentTransferSheet"]);
                rpt.Subreports[0].SetDataSource(ds.Tables["PaymentSalesPersonSummary"]);
                rpt.Subreports[1].SetDataSource(ds.Tables["PaymentAccountSummary"]);
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (reportName == "CustomerPendingReport")
            {
                Reports.PTCustomerPendingReport rpt = new Reports.PTCustomerPendingReport();
                rpt.SetDataSource(ds.Tables["PaymentTransferSheet"]);
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (reportName == "SupplierPendingReport")
            {
                Reports.PTSupplierPendingReport rpt = new Reports.PTSupplierPendingReport();
                rpt.SetDataSource(ds.Tables["PaymentTransferSheet"]);
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (reportName == "SupplierReport")
            {
                Reports.PTSupplierReport rpt = new Reports.PTSupplierReport();
                rpt.SetDataSource(ds.Tables["PaymentTransferSheet"]);
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (reportName == "SalesPersonReport")
            {
                Reports.PTSalesPersonReport rpt = new Reports.PTSalesPersonReport();
                rpt.SetDataSource(ds.Tables["PaymentTransferSheet"]);
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (reportName == "CustomerReport")
            {
                Reports.PTCustomerReport rpt = new Reports.PTCustomerReport();
                rpt.SetDataSource(ds.Tables["PaymentTransferSheet"]);
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (reportName == "ReceiptVoucher")
            {
                Vouchers.Reports.rptReceiptVoucher rpt = new Vouchers.Reports.rptReceiptVoucher();
                rpt.SetDataSource(ds.Tables["ReceiptPaymentVoucher"]);
                crystalReportViewer1.ReportSource = rpt;
            }

            else if (reportName == "PaymentVoucher")
            {
                Vouchers.Reports.rptPaymentVoucher rpt = new Vouchers.Reports.rptPaymentVoucher();
                rpt.SetDataSource(ds.Tables["ReceiptPaymentVoucher"]);
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (reportName == "PaymentVoucherDuplicate")
            {
                Vouchers.Reports.rptPaymentVoucherDuplicate rpt = new Vouchers.Reports.rptPaymentVoucherDuplicate();
                rpt.SetDataSource(ds.Tables["ReceiptPaymentVoucher"]);
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (reportName == "PaymentVoucherWithCust")
            {
                Vouchers.Reports.rptPaymentVoucherWithCust rpt = new Vouchers.Reports.rptPaymentVoucherWithCust();
                rpt.SetDataSource(ds.Tables["ReceiptPaymentVoucher"]);
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (reportName == "CashPaymentVoucher")
            {
                Vouchers.Reports.rptCashPaymentVoucher rpt = new Vouchers.Reports.rptCashPaymentVoucher();
                rpt.SetDataSource(ds.Tables["ReceiptPaymentVoucher"]);
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (reportName == "CashReceiptVoucher")
            {
                Vouchers.Reports.rptCashReceiptVoucher rpt = new Vouchers.Reports.rptCashReceiptVoucher();
                rpt.SetDataSource(ds.Tables["ReceiptPaymentVoucher"]);
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (reportName == "CashBookReport")
            {
                Reporting.Reports.CashBookReport rpt = new Reporting.Reports.CashBookReport();
                rpt.SetDataSource(ds.Tables["CashBook"]);
                rpt.Subreports[0].SetDataSource(ds.Tables["CashBookPayments"]);
                rpt.Subreports[1].SetDataSource(ds.Tables["CashBookReceipts"]);
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (reportName == "AgingReportS")
            {
                Reports.rpt_AgingReportS rpt = new Reports.rpt_AgingReportS();
                rpt.SetDataSource(ds.Tables["AgingReport"]);
                rpt.Subreports[0].SetDataSource(ds.Tables["AgingSummary"]);
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (reportName == "AgingReportP")
            {
                Reports.rpt_AgingReportP rpt = new Reports.rpt_AgingReportP();
                rpt.SetDataSource(ds.Tables["AgingReport"]);
                rpt.Subreports[0].SetDataSource(ds.Tables["AgingSummary"]);
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (reportName == "AgingReportC")
            {
                Reports.rpt_AgingReportC rpt = new Reports.rpt_AgingReportC();
                rpt.SetDataSource(ds.Tables["AgingReport"]);
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (reportName == "AgingReportCS")
            {
                Reports.AgingSummaryO rpt1 = new Reports.AgingSummaryO();
                rpt1.SetDataSource(ds.Tables["AgingSummary"]);
                rpt1.Subreports[0].SetDataSource(ds.Tables["AgingOverAllSummary"]);
                crystalReportViewer1.ReportSource = rpt1;
            }
            else if (reportName == "AgingReport")
            {
                Reports.rpt_AgingReport rpt = new Reports.rpt_AgingReport();
                rpt.SetDataSource(ds.Tables["AgingReport"]);
                rpt.Subreports[0].SetDataSource(ds.Tables["AgingSummary"]);
                crystalReportViewer1.ReportSource = rpt;
            }
            else if (reportName == "SaleInvoicesReport")
            {
                Sales.Reports.rptSaleInvoiceReport rpt = new Sales.Reports.rptSaleInvoiceReport();
                rpt.SetDataSource(ds.Tables["SaleInvoice"]);
                crystalReportViewer1.ReportSource = rpt;
            }

        }
        public void GenerateReport(string reportName, System.Data.DataSet ds, string[] parameters)
        {
            if (reportName == "IncomeStatementComparision")
            {
                Reports.IncomeStatementComparisionReport rpt = new Reports.IncomeStatementComparisionReport();
                rpt.SetDataSource(ds.Tables["IS_Comparision"]);
                for (int i = 0; i < parameters.Length; i++)
                {
                    rpt.SetParameterValue("Month" + (i + 1), parameters[i]);
                }
                crystalReportViewer1.ReportSource = rpt;
            }
        }
        private void frmReports_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void frmReports_Load(object sender, EventArgs e)
        {

        }

        private void crystalReportViewer1_ClickPage(object sender, CrystalDecisions.Windows.Forms.PageMouseEventArgs e)
        {
            
        }
    }
}
