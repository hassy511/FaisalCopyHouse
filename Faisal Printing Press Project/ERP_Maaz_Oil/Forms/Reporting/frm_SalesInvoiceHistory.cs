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
    public partial class frm_SalesInvoiceHistory : Form
    {
        public frm_SalesInvoiceHistory()
        {
            InitializeComponent();
        }

        Classes.Helper cls_fhp = new Classes.Helper();

        private void load_AREA()
        {
            try
            {
                cls_fhp.query = "select 0 as [id],'--SELECT AREA--' as [name] UNION select AREA_ID as [id],AREA_NAME as [name] from AREA ORDER BY NAME";
                cls_fhp.LoadComboData(cmbArea, cls_fhp.query);
            }
            catch (Exception ex) { cls_fhp.ShowMessageBox(ex.ToString(), "Exception"); }
        }
        private void load_Customer()
        {
            try
            {
                cls_fhp.query = "SELECT '0' AS [id], '--SELECT CUSTOMER--' AS [name] UNION SELECT COA_ID AS [id],COA_NAME AS [name] FROM COA WHERE CA_ID = 21";
                cls_fhp.LoadComboData(cmbCustName, cls_fhp.query);
            }
            catch (Exception ex) { cls_fhp.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void load_SalesPerson()
        {
            try
            {
                cls_fhp.query = @"SELECT '0' AS [id], '--SELECT SALES PERSON--' AS [name] 
                    UNION SELECT SALES_PER_ID AS [id],NAME AS [name] FROM SALES_PERSONS WHERE STAT = 0";
                cls_fhp.LoadComboData(cmbSalesPerson, cls_fhp.query);
            }
            catch (Exception ex) { cls_fhp.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void load_Province()
        {
            try
            {
                cls_fhp.query = "select 0 as [id],'--SELECT PROVINCE--' as [name] UNION select REGION_ID as [id],REGION_NAME as [name] from REGION ORDER BY NAME";
                cls_fhp.LoadComboData(cmbProvince, cls_fhp.query);
            }
            catch (Exception ex) { cls_fhp.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void frm_SalesInvoiceHistory_Load(object sender, EventArgs e)
        {
            load_AREA();
            load_Customer();
            load_Province();
            load_SalesPerson();
        }

        private void rdbSales_CheckedChanged(object sender, EventArgs e)
        {
            var rdbName = (sender as RadioButton).Name;
            bool isChecked = (sender as RadioButton).Checked;

            if(isChecked)
            {
                switch (rdbName)
                {
                    case "rdbSales":
                        cmbSalesPerson.Enabled = true;
                        cmbCustName.Enabled = false;
                        cmbProvince.Enabled = false;
                        break;

                    case "rdbProvince":
                        cmbProvince.Enabled = true;
                        cmbSalesPerson.Enabled = false;
                        cmbCustName.Enabled = false;
                        break;

                    case "rdbCustomer":
                        cmbCustName.Enabled = true;
                        cmbProvince.Enabled = false;
                        cmbSalesPerson.Enabled = false;
                        break;

                    case "rdbAll":
                        cmbCustName.Enabled = false;
                        cmbProvince.Enabled = false;
                        cmbSalesPerson.Enabled = false;
                        break;
                }
            }
           
        }

        private void checkBoxCheckedChanged(object sender, EventArgs e)
        {
            var checkBoxName = (sender as CheckBox).Name;
            bool isChecked = (sender as CheckBox).Checked;

            if (isChecked)
            {
                switch(checkBoxName)
                {
                    case "chkDays":
                        cmbDays.Enabled = true;
                        break;

                    case "chkArea":
                        cmbArea.Enabled = true; 
                        break;
                }
            }
            else if (!isChecked)
            {
                switch (checkBoxName)
                {
                    case "chkDays":
                        cmbDays.Enabled = false;
                        break;

                    case "chkArea":
                        cmbArea.Enabled = false;
                        break;
                }
            }
        }

        private void btnSHOW_Click(object sender, EventArgs e)
        {
            try
            {


                //           cls_fhp.query = @"
                //               select d.COA_NAME as [Customer],f.NAME as [SalesPerson],
                //               Max(b.Date) as [LastSaleDate],b.TOTAL as [LastSaleAmount],
                //               Max(L.CREATION_DATE) as [LastPaymentDate],L.DEBIT as [LastPaymentAmount],a.REMAINING_AMOUNT as Balance,DATEDIFF(day,b.Date,getdate()) as [Days],h.REGION_NAME as [Province]
                //               from SALES a
                //               inner join SALES_PROGRAM_MASTER b on a.SOP_ID = b.SPM_ID
                //               inner join SALES_PROGRAM_DETAILS c on b.SPM_ID = c.SPM_ID
                //               inner join COA d on b.CUSTOMER_ID = d.COA_ID
                //               left join CUSTOMER_PROFILE e on d.COA_ID = e.COA_ID
                //               left join SALES_PERSONS f on e.SALE_PER_ID = f.SALES_PER_ID
                //               inner join CITY g on g.CITY_ID = e.CITY_ID 
                //               inner join REGION h on g.REG_ID = h.REGION_ID
                //inner join LEDGERS L on d.COA_ID = L.COA_ID 
                //WHERE L.ENTRY_OF = 'SALES' ";

                cls_fhp.query = @"WITH A AS (
	            SELECT A.COA_ID,G.COA_NAME AS [Customer],D.NAME AS [SalesPerson],A.[DATE] AS [LastSaleDate],
	            A.DEBIT AS [LastSaleAmount],F.REGION_NAME AS [Province],F.REGION_ID,D.SALES_PER_ID,H.AREA_ID
	            FROM LEDGERS A 
	            INNER JOIN CUSTOMER_PROFILE C ON A.COA_ID = C.COA_ID
	            INNER JOIN SALES_PERSONS D ON C.SALE_PER_ID = D.SALES_PER_ID
	            INNER JOIN CITY E ON C.CITY_ID = E.CITY_ID
	            INNER JOIN REGION F ON E.REG_ID = F.REGION_ID
	            INNER JOIN COA G ON G.COA_ID = A.COA_ID
				INNER JOIN AREA H ON C.AREA_ID = H.AREA_ID
	            WHERE A.ENTRY_OF = 'SALES'
            ),
            X AS (
	            SELECT LEGDER_ID,COA_ID,[DATE] AS [LastPaymentDate],CREDIT AS [LastPaymentAmount] 
	            FROM LEDGERS 
	            WHERE ENTRY_OF IN ('PAYMENT TRANSFER','CASH RECEIPT','RECEIPT VOUCHER','BANK BOOK','GENERAL VOUCHER')
	            AND DEBIT = '0'
            )
            SELECT A.COA_ID,A.[Customer],A.[SalesPerson],A.[LastSaleDate],
            A.[LastSaleAmount],Z.[LastPaymentDate],Z.[LastPaymentAmount],
            (
	            SELECT 
		            CASE WHEN V.DR_CR = 'C' THEN 
			            -V.OPEN_BAL + (SELECT SUM(DEBIT) - SUM(CREDIT) FROM LEDGERS WHERE COA_ID = V.COA_ID)
		            ELSE V.OPEN_BAL + (SELECT SUM(DEBIT) - SUM(CREDIT) FROM LEDGERS WHERE COA_ID = V.COA_ID) END 
	            FROM COA V
	            WHERE V.COA_ID = A.COA_ID
            ) AS [Balance],
            (DATEDIFF(DAY,A.LastSaleDate,GETDATE())) as [Days],
            A.[Province],A.REGION_ID,A.SALES_PER_ID,A.AREA_ID
            FROM A
            INNER JOIN (
	            SELECT A.COA_ID,MAX(A.LastSaleDate) AS [DATE] 
	            FROM A 
	            GROUP BY A.COA_ID
            ) B ON A.COA_ID = B.COA_ID AND A.LastSaleDate = B.[DATE]

            INNER JOIN (
	            SELECT X.COA_ID,X.[LastPaymentDate],X.LastPaymentAmount
	            FROM X
	            INNER JOIN (
		            SELECT X.COA_ID,MAX(X.LEGDER_ID) AS [DATE],MAX(X.[LastPaymentAmount]) AS [AMOUNT] 
		            FROM X 
		            GROUP BY X.COA_ID
	            ) Y ON X.COA_ID = Y.COA_ID AND X.LEGDER_ID = Y.[DATE]
	            GROUP BY X.COA_ID,X.[LastPaymentDate],X.LastPaymentAmount
            ) Z ON A.COA_ID = Z.COA_ID ";



                if (rdbCustomer.Checked)
                {
                    cls_fhp.query += " WHERE A.COA_ID = '" + cmbCustName.SelectedValue + "' ";
                }
                else if (rdbProvince.Checked)
                {
                    cls_fhp.query += " WHERE A.[REGION_ID] = '" + cmbProvince.SelectedValue + "'";
                }
                else if (rdbSales.Checked)
                {
                    cls_fhp.query += " AND A.SALES_PER_ID = '" + cmbSalesPerson.SelectedValue + "'";
                }

                if (chkArea.Checked == true) {
                    cls_fhp.query += " AND A.AREA_ID = '" + cmbArea.SelectedValue + "'";
                }

                if (chkDays.Checked == true)
                {
                    cls_fhp.query += " AND (DATEDIFF(DAY,A.LastSaleDate,GETDATE())) >= '"+cmbDays.Text+"'";
                }

                cls_fhp.query += " ORDER BY [Days] DESC,A.[LastSaleDate] DESC";
                cls_fhp.LoadGrid(grdSEARCH, cls_fhp.query);

                cls_fhp.nds.Tables["SalesInvoiceHistory"].Clear();
                foreach (DataGridViewRow row in grdSEARCH.Rows)
                {
                    cls_fhp.dataR = cls_fhp.nds.Tables["SalesInvoiceHistory"].NewRow();
                    cls_fhp.dataR["customerName"] = row.Cells["Customer"].Value.ToString();
                    cls_fhp.dataR["salesPerson"] = row.Cells["SalesPerson"].Value.ToString();
                    cls_fhp.dataR["lastSaleDate"] = Convert.ToDateTime(row.Cells["LastSaleDate"].Value.ToString());
                    cls_fhp.dataR["lastPaymentReceiveDate"] = Convert.ToDateTime(row.Cells["LastPaymentDate"].Value.ToString());
                    cls_fhp.dataR["lastPaymentReceiveAmount"] = Convert.ToDecimal(row.Cells["LastPaymentAmount"].Value.ToString());
                    cls_fhp.dataR["lastSaleAmount"] = Convert.ToDecimal(row.Cells["LastSaleAmount"].Value.ToString());
                    cls_fhp.dataR["balance"] = Convert.ToDecimal(row.Cells["Balance"].Value.ToString());
                    cls_fhp.dataR["days"] = row.Cells["Days"].Value.ToString();
                    cls_fhp.dataR["Province"] = row.Cells["Province"].Value.ToString();


                    cls_fhp.nds.Tables["SalesInvoiceHistory"].Rows.Add(cls_fhp.dataR);
                }

                 cls_fhp.rpt = new frmReports();
                cls_fhp.rpt.GenerateReport("SalesInvoiceHistory", cls_fhp.nds);
                cls_fhp.rpt.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
