using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP_Maaz_Oil.Forms.Reporting
{
    public partial class frmPurchaseSalesDifferenceRpt : Form
    {
        public frmPurchaseSalesDifferenceRpt()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.R))
            {
                GeneratePurchase();
                GenerateSales();
                GenerateDifference();
                LoadReport();
            }
            if (keyData == (Keys.Escape))
            {
                this.Dispose();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        Classes.Helper clsDb = new Classes.Helper();
        char hasRows = 'N';
        DataTable 
            dtPurchase = new DataTable(), 
            dtSales = new DataTable(), 
            dtDifference = new DataTable();

        private void GenerateSales()
        {
            try
            {
                clsDb.query = @"SELECT FORMAT(A.DATE,'dd-MMM-yyyy') as [INVOICE DATE],A.INVOICE_NO AS [INVOICE #],
                E.COA_NAME AS [CUSTOMER NAME],
                B.VEHICLE_NO AS [VEHICLE #],D.MATERIAL_NAME AS [MATERIAL NAME],A.sales_weight AS [SALES WEIGHT],
                CASE WHEN D.MATERIAL_ID = 5005 THEN A.KG_RATE ELSE A.MUAND_RATE END AS [RATE],
                --A.total 
                CASE WHEN D.MATERIAL_ID = 5005 THEN ROUND(A.KG_RATE * A.sales_weight,2) ELSE 
                ROUND((A.MUAND_RATE / 37.324) * A.sales_weight,2) END
                AS [INVOICE AMOUNT]
                FROM purchases_sales_transfer A
                INNER JOIN PURCHASES B ON A.purchases_id = B.PI_ID
                INNER JOIN PURCHASES_ORDER C ON C.PO_ID = B.PO_ID
                INNER JOIN MATERIALS D ON D.MATERIAL_ID = C.MATERIAL_ID
                INNER JOIN COA E ON A.customer_id = E.COA_ID
                WHERE B.DATE BETWEEN '" + dtp_FROM.Value.Date+@"' and '"+dtp_TO.Value.Date.AddHours(23).AddMinutes(59)+@"'
                ";

                if (cmbACCOUNT.SelectedIndex > 0)
                {
                    clsDb.query += " AND E.COA_ID = '" + cmbACCOUNT.SelectedValue.ToString() + "'";
                }

                clsDb.cmd = new System.Data.SqlClient.SqlCommand(clsDb.query, Classes.Helper.conn);
                if (Classes.Helper.conn.State == ConnectionState.Closed)
                    Classes.Helper.conn.Open();

                clsDb.dr = clsDb.cmd.ExecuteReader();
                if(clsDb.dr.HasRows)
                {
                    dtSales = new DataTable();
                    dtSales.Load(clsDb.dr);
                    hasRows = 'Y';
                }

                clsDb.nds.Tables["Sales"].Clear();
                for (int i = 0; i < dtSales.Rows.Count; i++)
                {
                    clsDb.dataR = clsDb.nds.Tables["Sales"].NewRow();
                    clsDb.dataR["invDate"] = dtSales.Rows[i]["INVOICE DATE"].ToString();
                    clsDb.dataR["invNum"] = dtSales.Rows[i]["INVOICE #"].ToString();
                    clsDb.dataR["custName"] = dtSales.Rows[i]["CUSTOMER NAME"].ToString();
                    clsDb.dataR["vehNum"] = dtSales.Rows[i]["VEHICLE #"].ToString();
                    clsDb.dataR["material"] = dtSales.Rows[i]["MATERIAL NAME"].ToString();
                    clsDb.dataR["weight"] = dtSales.Rows[i]["SALES WEIGHT"].ToString();
                    clsDb.dataR["rate"] = dtSales.Rows[i]["RATE"].ToString();
                    clsDb.dataR["invAmount"] = dtSales.Rows[i]["INVOICE AMOUNT"].ToString();
                    clsDb.nds.Tables["Sales"].Rows.Add(clsDb.dataR);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Classes.Helper.conn.Close();
            }
        }

        private void GeneratePurchase()
        {
            try
            {
                clsDb.query = @"SELECT FORMAT(B.DATE,'dd-MMM-yyyy') as [INVOICE DATE],B.INVOICE_NO AS [INVOICE #],E.COA_NAME AS [SUPPLIER NAME],
                B.VEHICLE_NO AS [VEHICLE #],D.MATERIAL_NAME AS [MATERIAL NAME],B.NET_WEIGHT AS [PURCHASES WEIGHT],
                CASE WHEN D.MATERIAL_ID = 5005 THEN B.KG_RATE ELSE C.MUAND_RATE END AS [RATE],
                CASE WHEN D.MATERIAL_ID = 5005 THEN ROUND(B.KG_RATE * B.NET_WEIGHT,2) ELSE 
                ROUND((C.MUAND_RATE / 37.324) * B.NET_WEIGHT,2) END AS [INVOICE AMOUNT]
                --ROUND(B.KG_RATE * B.NET_WEIGHT,2) 
                FROM purchases_sales_transfer A
                INNER JOIN PURCHASES B ON A.purchases_id = B.PI_ID
                INNER JOIN PURCHASES_ORDER C ON C.PO_ID = B.PO_ID
                INNER JOIN MATERIALS D ON D.MATERIAL_ID = C.MATERIAL_ID
                INNER JOIN COA E ON B.SUPPLIER_ID = E.COA_ID
                WHERE B.DATE BETWEEN '" + dtp_FROM.Value.Date + @"' and '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59) + @"'
                ";

                if(cmbACCOUNT.SelectedIndex>0)
                {
                    clsDb.query += " AND E.COA_ID = '"+cmbACCOUNT.SelectedValue.ToString()+"'";
                }

                clsDb.cmd = new System.Data.SqlClient.SqlCommand(clsDb.query, Classes.Helper.conn);
                if (Classes.Helper.conn.State == ConnectionState.Closed)
                    Classes.Helper.conn.Open();

                clsDb.dr = clsDb.cmd.ExecuteReader();
                if (clsDb.dr.HasRows)
                {
                    dtPurchase = new DataTable();
                    dtPurchase.Load(clsDb.dr);
                    hasRows = 'Y';
                }

                clsDb.nds.Tables["Purchases"].Clear();
                for (int i = 0; i < dtPurchase.Rows.Count; i++)
                {
                    clsDb.dataR = clsDb.nds.Tables["Purchases"].NewRow();
                    clsDb.dataR["invDate"] = dtPurchase.Rows[i]["INVOICE DATE"].ToString(); 
                    clsDb.dataR["invNum"] = dtPurchase.Rows[i]["INVOICE #"].ToString();
                    clsDb.dataR["suppName"] = dtPurchase.Rows[i]["SUPPLIER NAME"].ToString();
                    clsDb.dataR["vehNum"] = dtPurchase.Rows[i]["VEHICLE #"].ToString();
                    clsDb.dataR["material"] = dtPurchase.Rows[i]["MATERIAL NAME"].ToString();
                    clsDb.dataR["weight"] = dtPurchase.Rows[i]["PURCHASES WEIGHT"].ToString();
                    clsDb.dataR["rate"] = dtPurchase.Rows[i]["RATE"].ToString();
                    clsDb.dataR["invAmount"] = dtPurchase.Rows[i]["INVOICE AMOUNT"].ToString();
                    clsDb.nds.Tables["Purchases"].Rows.Add(clsDb.dataR);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Classes.Helper.conn.Close();
            }
        }

        private void GenerateDifference()
        {
            try
            {
                clsDb.query = @"WITH SALE AS (
                            SELECT A.pst_id AS [ID],A.DATE AS [INVOICE DATE],A.INVOICE_NO AS [INVOICE #],E.COA_NAME AS [CUSTOMER NAME],
                            B.VEHICLE_NO AS [VEHICLE #],D.MATERIAL_NAME AS [MATERIAL NAME],A.sales_weight AS [SALES WEIGHT],E.COA_ID,
                            CASE WHEN D.MATERIAL_ID = 5005 THEN A.KG_RATE ELSE A.MUAND_RATE END AS [RATE],
                            --A.total 
                            CASE WHEN D.MATERIAL_ID = 5005 THEN ROUND(A.KG_RATE * A.sales_weight,2) ELSE 
                            ROUND((A.MUAND_RATE / 37.324) * A.sales_weight,2) END
                            AS [INVOICE AMOUNT]
                            FROM purchases_sales_transfer A
                            INNER JOIN PURCHASES B ON A.purchases_id = B.PI_ID
                            INNER JOIN PURCHASES_ORDER C ON C.PO_ID = B.PO_ID
                            INNER JOIN MATERIALS D ON D.MATERIAL_ID = C.MATERIAL_ID
                            INNER JOIN COA E ON A.customer_id = E.COA_ID
                            ),
                            PURCHASE AS (
                            SELECT A.pst_id AS [ID],B.DATE AS [INVOICE DATE],B.INVOICE_NO AS [INVOICE #],E.COA_NAME AS [SUPPLIER NAME],
                            B.VEHICLE_NO AS [VEHICLE #],D.MATERIAL_NAME AS [MATERIAL NAME],B.NET_WEIGHT AS [PURCHASES WEIGHT],E.COA_ID,
                            CASE WHEN D.MATERIAL_ID = 5005 THEN B.KG_RATE ELSE C.MUAND_RATE END AS [RATE],
                            CASE WHEN D.MATERIAL_ID = 5005 THEN ROUND(B.KG_RATE * B.NET_WEIGHT,2) ELSE 
                            ROUND((C.MUAND_RATE / 37.324) * B.NET_WEIGHT,2) END AS [INVOICE AMOUNT]
                            FROM purchases_sales_transfer A
                            INNER JOIN PURCHASES B ON A.purchases_id = B.PI_ID
                            INNER JOIN PURCHASES_ORDER C ON C.PO_ID = B.PO_ID
                            INNER JOIN MATERIALS D ON D.MATERIAL_ID = C.MATERIAL_ID
                            INNER JOIN COA E ON B.SUPPLIER_ID = E.COA_ID
                            )
                            SELECT FORMAT(A.[INVOICE DATE],'dd-MMM-yyyy') as [INVOICE DATE],A.[INVOICE #],'OTHER INCOME' AS [ACCOUNT NAME],A.[VEHICLE #],
                            A.[MATERIAL NAME],(A.[SALES WEIGHT] - B.[PURCHASES WEIGHT]) AS [DIFFERENCE WEIGHT],
                            A.RATE - B.RATE AS [RATE DIFFERENCE],A.[INVOICE AMOUNT] - B.[INVOICE AMOUNT] AS [AMOUNT DIFFERENCE]
                            FROM SALE A
                            INNER JOIN PURCHASE B ON A.ID = B.ID
                            WHERE A.[INVOICE DATE] BETWEEN '" + dtp_FROM.Value.Date + @"' and '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59) + @"'
                ";

                if (cmbACCOUNT.SelectedIndex > 0)
                {
                    clsDb.query += " AND (A.COA_ID = '" + cmbACCOUNT.SelectedValue.ToString() + "' OR B.COA_ID = '" + cmbACCOUNT.SelectedValue.ToString() + "')";
                }

                clsDb.cmd = new System.Data.SqlClient.SqlCommand(clsDb.query, Classes.Helper.conn);
                if (Classes.Helper.conn.State == ConnectionState.Closed)
                    Classes.Helper.conn.Open();

                clsDb.dr = clsDb.cmd.ExecuteReader();
                if (clsDb.dr.HasRows)
                {
                    dtDifference = new DataTable();
                    dtDifference.Load(clsDb.dr);
                    hasRows = 'Y';
                }

                clsDb.nds.Tables["PurchaseSaleDifference"].Clear();
                for (int i = 0; i < dtDifference.Rows.Count; i++)
                {
                    clsDb.dataR = clsDb.nds.Tables["PurchaseSaleDifference"].NewRow();
                    clsDb.dataR["invDate"] = dtDifference.Rows[i]["INVOICE DATE"].ToString();
                    clsDb.dataR["invNum"] = dtDifference.Rows[i]["INVOICE #"].ToString();
                    clsDb.dataR["accName"] = dtDifference.Rows[i]["ACCOUNT NAME"].ToString();
                    clsDb.dataR["vehNum"] = dtDifference.Rows[i]["VEHICLE #"].ToString();
                    clsDb.dataR["material"] = dtDifference.Rows[i]["MATERIAL NAME"].ToString();
                    clsDb.dataR["weight"] = dtDifference.Rows[i]["DIFFERENCE WEIGHT"].ToString();
                    clsDb.dataR["rate"] = dtDifference.Rows[i]["RATE DIFFERENCE"].ToString();
                    clsDb.dataR["invAmount"] = dtDifference.Rows[i]["AMOUNT DIFFERENCE"].ToString();
                    clsDb.nds.Tables["PurchaseSaleDifference"].Rows.Add(clsDb.dataR);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Classes.Helper.conn.Close();
            }
        }

        private void frmPurchaseSalesDifferenceRpt_Load(object sender, EventArgs e)
        {
            LoadAccounts();
        }

        private void LoadAccounts()
        {
            clsDb.query = @"SELECT '0' AS [id],'--ALL--' as [name]
            UNION ALL
            SELECT COA_ID AS [id],COA_NAME AS [name] FROM COA ORDER BY [name]";
            clsDb.LoadComboData(cmbACCOUNT, clsDb.query);
            
        }

        public void LoadReport()
        {
            clsDb.nds.Tables["PurchaseSalesFromTo"].Clear();
            clsDb.dataR = clsDb.nds.Tables["PurchaseSalesFromTo"].NewRow();

            clsDb.dataR["from"] = dtp_FROM.Value.ToString("dd-MMM-yyyy");
            clsDb.dataR["to"] = dtp_TO.Value.ToString("dd-MMM-yyyy"); ;
            if (dtPurchase.Rows.Count == 0)
                clsDb.dataR["showPurchase"] = "Y";
            if (dtSales.Rows.Count == 0)
                clsDb.dataR["showSales"] = "Y";
                
            clsDb.nds.Tables["PurchaseSalesFromTo"].Rows.Add(clsDb.dataR);
          
            if (hasRows == 'Y')
            {
                clsDb.rpt = new frmReports();
                clsDb.rpt.GenerateReport("PurchaseSalesTransfer", clsDb.nds);
                clsDb.rpt.ShowDialog();
                dtDifference = new DataTable();
                dtPurchase = new DataTable();
                dtSales = new DataTable();
            }
            else
            {
                MessageBox.Show("No record found.","Error",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void btnSHOW_Click(object sender, EventArgs e)
        {
            GeneratePurchase();
            GenerateSales();
            GenerateDifference();
            LoadReport();
        }
    }
}
