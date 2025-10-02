using ERP_Maaz_Oil.Vouchers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP_Maaz_Oil.Forms
{
    public partial class frmDashboard : Form
    {
        frm_BankPmt frmBankPay;
        frm_BankRcpt frmBankRec;
        
        public frmDashboard()
        {
            InitializeComponent();
        }

        private void UserRights() {
            if (Classes.Helper.userId == 6)
            {
                accountsToolStripMenuItem.Enabled = false;
                //bankToolStripMenuItem.Enabled = false;
                //cashToolStripMenuItem.Enabled = false;
                inventoryToolStripMenuItem.Enabled = false;
                purchasesToolStripMenuItem1.Enabled = false;
                salesToolStripMenuItem.Enabled = false;
                vouchersToolStripMenuItem.Enabled = false;
                toolStripMenuItem1.Enabled = false;
                financialStatementsToolStripMenuItem.Enabled = false;
                salesInvoiceToolStripMenuItem.Enabled = true;
            }
            else if (Classes.Helper.userId == 4)
            {
                //bankToolStripMenuItem.Enabled = false;
                //cashToolStripMenuItem.Enabled = false;
                inventoryToolStripMenuItem.Enabled = false;
                toolStripMenuItem1.Enabled = false;
                cashBookToolStrip.Enabled = false;
                salesToolStripMenuItem.Enabled = false;
                paymentTransferToolStripMenuItem.Enabled = false;
                paymentVoucherApprovalToolStripMenuItem.Enabled = false;
                paymentVoucherReportsToolStripMenuItem.Enabled = false;
                salesInvoiceToolStripMenuItem.Enabled = true;
            }
        }

        private void chartOfAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChartOfAccounts CA = new frmChartOfAccounts();
            CA.Show();
        }

        private void addBrokerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddBroker CA = new frmAddBroker();
            CA.Show();
        }

        private void addCityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddCity CA = new frmAddCity();
            CA.Show();
        }

        private void addTaxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddTax CA = new frmAddTax();
            CA.Show();
        }

        private void addUnitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUnit CA = new frmAddUnit();
            CA.Show();
        }

        private void addSalesPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSalesPerson CA = new frmSalesPerson();
            CA.Show();
        }

        private void customerProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomerProfile CA = new frmCustomerProfile();
            CA.Show();
        }

        private void supplierProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSupplierProfile CA = new frmSupplierProfile();
            CA.Show();
        }

        private void addRegionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddRegion CA = new frmAddRegion();
            CA.Show();
        }

        private void bankReceiptVouchersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_BankRcpt CA = new frm_BankRcpt();
            CA.Show();
        }

        private void bankPaymentVouchersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_BankPmt CA = new frm_BankPmt();
            CA.Show();
        }

        private void bankTransferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_BankTr CA = new frm_BankTr();
            CA.Show();
        }

        private void chqBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddChq CA = new frmAddChq();
            CA.Show();
        }

        private void cashReceiptVoucherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_CashRcpt CA = new frm_CashRcpt();
            CA.Show();
        }

        private void cashPaymentVoucherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_CashPmt CA = new frm_CashPmt();
            CA.Show();
        }

        private void generalJournalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_General_Voucher CA = new frm_General_Voucher();
            CA.Show();
        }

        private void addCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddCategory CA = new frmAddCategory();
            CA.Show();
        }

        private void addLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddLocation CA = new frmAddLocation();
            CA.Show();
        }

        private void addMaterialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddMaterial CA = new frmAddMaterial();
            CA.Show();
        }

        private void addProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void aDDUNITToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddUnit frmud = new frmAddUnit();
            frmud.Show();
        }

        private void pRODUCTIONFORMULAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSalesRateFormula frmpf = new frmSalesRateFormula();
            frmpf.Show();
        }

        private void pRODUCTIONPROCESSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductionProcess frmpfp = new frmProductionProcess();
            frmpfp.Show();
        }

        private void pURCHASESORDERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void pURCHASESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void sALESORDERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //frmAddPackingMaterial frmPackingMaterial = new frmAddPackingMaterial();
            //frmPackingMaterial.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmPurchasesPacking frmPurchasePacking = new frmPurchasesPacking();
            frmPurchasePacking.ShowDialog();
        }

        private void addVehiclesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddVehicles frmVehicles = new frmAddVehicles();
            frmVehicles.ShowDialog();
        }

        private void salesOrderMaterialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void salesProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void gatePassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void salesInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSalesInvoice frmSI = new frmSalesInvoice();
            frmSI.ShowDialog();
        }

        private void accountsLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reporting.frm_Account_Ledger frmLedger = new Reporting.frm_Account_Ledger();
            frmLedger.ShowDialog();
        }

        private void purchasesOrderReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Reporting.frm_PurchasesInvoiceReport frmPOR = new Reporting.frm_PurchasesInvoiceReport();
            frmPOR.ShowDialog();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Reporting.frm_SalesOrderReport frmSOR = new Reporting.frm_SalesOrderReport();
            frmSOR.ShowDialog();
        }

        private void sALESORDERToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void salesOrderProductToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void purchasesToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void pURCHASESORDERToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmPurchases_Order frmPO = new frmPurchases_Order();
            frmPO.Show();
        }

        private void gatePassToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmGatePass frmGp = new frmGatePass();
            frmGp.ShowDialog();
        }

        private void salesProgramToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmSalesProgram frmSalePro = new frmSalesProgram();
            frmSalePro.ShowDialog();
        }

        private void pURCHASESToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmPurchases_New frmpi = new frmPurchases_New();
            frmpi.Show();
        }

        private void salesOrderMaterialToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmSalesOrderDirect frmSaleOrderDirect = new frmSalesOrderDirect();
            frmSaleOrderDirect.ShowDialog();
        }

        private void salesOrderDirectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void addBrandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddCategory frmBrand = new frmAddCategory();
            frmBrand.ShowDialog();
        }

        private void addCartagePackingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddCartagePacking frmCartagePacking = new frmAddCartagePacking();
            frmCartagePacking.ShowDialog();
        }

        private void addVehiclesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmAddVehicles frmVehicles = new frmAddVehicles();
            frmVehicles.ShowDialog();
        }

        private void salesOrderDirectToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmSalesOrderProduct frmso = new frmSalesOrderProduct();
            frmso.Show();
        }

        private void salesOrderProductMaterialToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmSalesOrderMaterialP frmSOMP = new frmSalesOrderMaterialP();
            frmSOMP.ShowDialog();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            UserRights();
        }

        private void salesInvoiceReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reporting.frm_SalesInvoiceReport frmSIR = new Reporting.frm_SalesInvoiceReport();
            frmSIR.ShowDialog();
        }

        private void salesInvoiceReportSalesPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reporting.frm_SalesInvoiceSalesPersonReport frmSIR = new Reporting.frm_SalesInvoiceSalesPersonReport();
            frmSIR.ShowDialog();
        }

        private void brandWiseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reporting.frm_BrandReport frmSIR = new Reporting.frm_BrandReport();
            frmSIR.ShowDialog();
        }

        private void salesInvoiceReportInvoiceWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reporting.frm_SalesInvoiceReportInvoiceWise frmSIR = new Reporting.frm_SalesInvoiceReportInvoiceWise();
            frmSIR.ShowDialog();
        }

        private void saleInvoiceReportProvinceWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reporting.frm_SalesInvoiceReportProvince frmSIR = new Reporting.frm_SalesInvoiceReportProvince();
            frmSIR.ShowDialog();
        }

        private void proviceSalesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reporting.frm_SalesInvoiceReportProvinceSP frmSIR = new Reporting.frm_SalesInvoiceReportProvinceSP();
            frmSIR.ShowDialog();
        }

        private void salesPersonProvinceReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reporting.frm_SalesInvoiceReportProvinceSalePerson frmSIR = new Reporting.frm_SalesInvoiceReportProvinceSalePerson();
            frmSIR.ShowDialog();
        }

        private void paymentTransferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_PaymentTransfer frmPTransfer = new frm_PaymentTransfer();
            frmPTransfer.ShowDialog();
        }

        private void paymentVoucherApprovalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ERP_Maaz_Oil.Forms.Vouchers.frm_PaymentTransferApproval frmPTransferApproval = new Vouchers.frm_PaymentTransferApproval();
            frmPTransferApproval.ShowDialog();
        }

        private void paymentVoucherReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ERP_Maaz_Oil.Forms.Reporting.frm_PaymentReports frmPaymentReport = new Reporting.frm_PaymentReports();
            frmPaymentReport.ShowDialog();
        }

        private void backUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Classes.Helper clsHelper = new Classes.Helper();
            clsHelper.DatabaseBackUp();
        }

        private void vouchersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ERP_Maaz_Oil.Vouchers.DayBookForm frm = new ERP_Maaz_Oil.Vouchers.DayBookForm();
            frm.ShowDialog();
        }

        private void bankPaymentVoucherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frm_BankPmt frm = new frm_BankPmt())
            {
                frm.ShowDialog();
            }
        }

        private void bankReceiptVoucherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frm_BankRcpt frm = new frm_BankRcpt())
            {
                frm.ShowDialog();
            }
        }

        private void cashBookToolStrip_Click(object sender, EventArgs e)
        {
            using (frm_CashPmt frm = new frm_CashPmt())
            {
                frm.ShowDialog();
            }
        }

        private void cashbookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reporting.frm_CashBookReport frm = new Reporting.frm_CashBookReport();
            frm.ShowDialog();
        }

        private void databaseBackUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBackUpDatabase frm = new frmBackUpDatabase();
            frm.ShowDialog();
            //Classes.Helper clsHelper = new Classes.Helper();
            //clsHelper.DatabaseBackUp();
        }

        private void databaseRestoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBackUpRestoreDatabase frm = new frmBackUpRestoreDatabase();
            frm.ShowDialog();
        }

        private void chqInHandReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reporting.frmChqInHandReport frm = new Reporting.frmChqInHandReport();
            frm.ShowDialog();
        }

        private void chqPaidReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reporting.frmChqPaidReport frm = new Reporting.frmChqPaidReport();
            frm.ShowDialog();
        }

        private void chqReceivedReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reporting.frmChqRcvdReport frm = new Reporting.frmChqRcvdReport();
            frm.ShowDialog();
        }

        private void chqAccountReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reporting.frmChqAccount frm = new Reporting.frmChqAccount();
            frm.ShowDialog();
        }

       
        private void bankBookToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            using (Vouchers.frmBankBook frm = new Vouchers.frmBankBook())
            {
                frm.ShowDialog();
            }
        }

        private void bankBookReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Reporting.frm_BankBook frm = new Reporting.frm_BankBook())
            {
                frm.ShowDialog();
            }
        }

        private void bankAndCashReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Reporting.frmCashAndBank frm = new Reporting.frmCashAndBank())
            {
                frm.ShowDialog();
            }
        }

        private void purchasesSalesTransferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmPurchasesSalesTransfer frm = new Forms.frmPurchasesSalesTransfer();
            frm.ShowDialog();
        }

        private void purchaseSalesTransferReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Reporting.frmPurchaseSalesDifferenceRpt frm = new Reporting.frmPurchaseSalesDifferenceRpt())
            {
                frm.ShowDialog();
            }
        }

        private void salesReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmSalesReturn frm = new Forms.frmSalesReturn();
            frm.ShowDialog();
        }

        private void salesOrderDiscardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Reporting.frm_SalesOrderApproval frm = new Reporting.frm_SalesOrderApproval())
            {
                frm.ShowDialog();
            }
        }

        private void supplierCustomerOutstandingReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Reporting.frm_SupplierCustomerOutstandingReport frm = new Reporting.frm_SupplierCustomerOutstandingReport())
            {
                frm.ShowDialog();
            }

        }

        private void supplierAgingReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Reporting.frm_SupplierAgingReport frm = new Reporting.frm_SupplierAgingReport())
            {
                frm.ShowDialog();
            }
        }

        private void trialBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reporting.frm_TrailBalanceReport frm = new Reporting.frm_TrailBalanceReport();
            frm.ShowDialog();
        }

        private void incomeStatementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reporting.frm_IncomeStatementReport frm = new Reporting.frm_IncomeStatementReport();
            frm.ShowDialog();
        }

        private void balanceSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reporting.frm_BalanceSheetReport frm = new Reporting.frm_BalanceSheetReport();
            frm.ShowDialog();
        }

        private void customerAgingReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reporting.frm_CustomerAgingReport frm = new Reporting.frm_CustomerAgingReport();
            frm.ShowDialog();
        }

        private void purchasesOrderDiscardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reporting.frm_PurchasesOrderReport frmPOR = new Reporting.frm_PurchasesOrderReport();
            frmPOR.ShowDialog();
        }

        private void aASalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmAASales frm = new Forms.frmAASales();
            frm.ShowDialog();
        }

        private void rawMaterialReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reporting.frm_RawMaterialReport frm = new Reporting.frm_RawMaterialReport();
            frm.ShowDialog();
        }

        private void receivablesSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reporting.frm_ReceivablesStatemenReport frm = new Reporting.frm_ReceivablesStatemenReport();
            frm.ShowDialog();
        }

        private void frmDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void salesInvoiceToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            
        }

        private void journalVoucherReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Reporting.frm_JournalVoucherReport frm = new Reporting.frm_JournalVoucherReport())
            {
                frm.ShowDialog();
            }
        }

        private void bankVoucherReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new Reporting.frmBankBookVouchersReport())
            {
                frm.ShowDialog();
            }
        }

        private void inventoryAdjustmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmStockAdjustment frm = new Forms.frmStockAdjustment();
            frm.ShowDialog();
        }

        private void orderPositionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Reporting.frm_MaterialPositionClosingReport frm = new Forms.Reporting.frm_MaterialPositionClosingReport();
            frm.ShowDialog();
        }

        private void salesInvoiceToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            Forms.Sales.frm_SalesInvoices frm = new Sales.frm_SalesInvoices();
            frm.ShowDialog();
        }

        private void cHQReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void customerProfileReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new Reporting.frm_CustomerProfileReport())
            {
                frm.ShowDialog();
            }
        }

        private void salesDirectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSalesDirect frm = new frmSalesDirect();
            frm.ShowDialog();
        }

        private void salesInvoiceHIstoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new Reporting.frm_SalesInvoiceHistory())
            {
                frm.ShowDialog();
            }
        }

        private void gatePassNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGatePass_New frm = new frmGatePass_New();
            frm.ShowDialog();
        }

        private void toolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            Forms.Reporting.frm_IncomeStatementComparisionReport frm = new Forms.Reporting.frm_IncomeStatementComparisionReport();
            frm.ShowDialog();
        }


        private void jOBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Job.frmJobOrder frm = new Job.frmJobOrder();
        }
        private void addUnitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmAddUnit frm = new Forms.frmAddUnit();
            frm.ShowDialog();
        }

        private void addMaterialTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmAddMaterialType frm = new Forms.frmAddMaterialType();
            frm.ShowDialog();
        }

        private void jobOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Job.frmJobOrder frm = new Job.frmJobOrder();
            frm.ShowDialog();
        }

        private void salesInvoiceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void salesReturnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Forms.frmSalesReturn_New frm = new Forms.frmSalesReturn_New();
            frm.ShowDialog();
        }

        private void payablesSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reporting.frm_PayablesStatemenReport frm = new Reporting.frm_PayablesStatemenReport();
            frm.ShowDialog();
        }

        private void stockReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void finishedStockReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void materialStockReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void stockReportDateItemWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reporting.frm_StockReport_Custom frm = new Reporting.frm_StockReport_Custom();
            frm.ShowDialog();
        }

        private void toolStripMenuItem3_Click_1(object sender, EventArgs e)
        {
            frmFinishedProducts CA = new frmFinishedProducts();
            CA.Show();
        }

        private void toolStripMenuItem4_Click_1(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Reporting.frm_StockReport frm = new Reporting.frm_StockReport();
            frm.ShowDialog();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Reporting.frm_RawReport frm = new Reporting.frm_RawReport();
            frm.ShowDialog();
        }

        private void productionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Job.frmJobOrderNew frm = new Job.frmJobOrderNew();
            frm.ShowDialog();
        }

        private void materialtInventoryAdjustmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmStockAdjustment_Raw frm = new Forms.frmStockAdjustment_Raw();
            frm.ShowDialog();
        }

        private void stockIssuanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmStockIssuance frm = new Forms.frmStockIssuance();
            frm.ShowDialog();
        }

        private void purchaseReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPurchasesReturn frmpo = new frmPurchasesReturn();
            frmpo.Show();
        }

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void qutationFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void qutationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void accountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChartOfAccounts CA = new frmChartOfAccounts();
            CA.Show();
        }

        private void quotationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Quotation frm = new frm_Quotation();
            frm.Show();
        }

        private void salesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Forms.frm_Sales frm = new Forms.frm_Sales();
            frm.ShowDialog();
        }

        private void salesReturnToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Forms.frmSalesReturn_New frm = new Forms.frmSalesReturn_New();
            frm.ShowDialog();
        }

        private void cashPaymentReceiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frm_CashPaymentReceive frm = new frm_CashPaymentReceive())
            {
                frm.ShowDialog();
            }
        }

        private void cashbankrecToolStripMenuItem_Click(object sender, EventArgs e)
        {
           using (frm_BankVoucher frm = new frm_BankVoucher())
            {
                frm.ShowDialog();
           }
        }

        private void journalVoucherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_GeneralVoucher frm = new frm_GeneralVoucher();
            frm.ShowDialog();
        }

        private void printingSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_SalesServices frm = new frm_SalesServices();
            frm.ShowDialog();
        }

        private void printingSalesProfitReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reporting.frm_PrintingSalesProfitReport frm = new Reporting.frm_PrintingSalesProfitReport();
            frm.ShowDialog();
        }

        private void invoicePaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_SalesInvoiceClear frm = new frm_SalesInvoiceClear();
            frm.ShowDialog();
        }
    }
}
