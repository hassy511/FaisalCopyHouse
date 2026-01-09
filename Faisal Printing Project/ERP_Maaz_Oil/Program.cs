using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP_Maaz_Oil
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Classes.Helper.purchasesId = 24;
            Classes.Helper.purchasesReturnId = 95205;
            Classes.Helper.salesId = 23;
            Classes.Helper.otherIncomeId = 5110;
            Classes.Helper.salesReturnId = 2106;
            Classes.Helper.aasalesId = 0;
            Classes.Helper.inventoryId = 5112;
            Classes.Helper.lossInventoryId = 5111;
            Classes.Helper.cashId = 1082;

            //Classes.Helper hlp = new Classes.Helper();
            //MessageBox.Show(hlp.GetClosingStockValue(Convert.ToDateTime("2020-07-31 23:59:59")).ToString());

            //Application.Run(new Forms.LogIn());

            Classes.Helper.userId = 1;
            Application.Run(new Forms.frmDashboard());
            //Application.Run(new Forms.Reporting.frm_Account_Ledger());
            //Application.Run(new Forms.frmGatePass_New());



        }
    }
}
