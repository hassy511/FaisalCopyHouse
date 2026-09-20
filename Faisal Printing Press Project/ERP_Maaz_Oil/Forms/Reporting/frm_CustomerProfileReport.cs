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
    public partial class frm_CustomerProfileReport : Form
    {
        public frm_CustomerProfileReport()
        {
            InitializeComponent();
        }

        Classes.Helper cls_fhp = new Classes.Helper();

        private void load_city()
        {
            try
            {
                cls_fhp.query = "select 0 as [id],'--SELECT CITY--' as [name] UNION select CITY_ID as [id],CITY_NAME as [name] from CITY ORDER BY NAME";
                cls_fhp.LoadComboData(cmbCity, cls_fhp.query);
            }

            catch (Exception ex) { cls_fhp.ShowMessageBox(ex.ToString(), "Exception"); }
        }

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

        private void frm_CustomerProfileReport_Load(object sender, EventArgs e)
        {
            load_AREA();
            load_Customer();
            load_SalesPerson();
            load_city();
        }

        private void btnSHOW_Click(object sender, EventArgs e)
        {
            try
            {
                if (Classes.Helper.conn.State == ConnectionState.Closed)
                    Classes.Helper.conn.Open();
                cls_fhp.query = @"SELECT
                    A.CUST_PRO,C.COA_NAME,A.COA_ID,A.SALE_PER_ID,D.NAME as [SALES PERSON],
                    A.CONTACT_PERSON,A.MOBILE,A.EMAIL,A.ADDRESS,A.CITY_ID,B.CITY_NAME as [CITY],A.AREA_ID,E.AREA_NAME,A.NTN_NUMBER,
                    A.STRN_NUMBER,A.GST_NUMBER,convert(varchar(100), A.CREDIT_LIMIT) as CREDIT_LIMIT,A.STAT,A.CREDIT_DAYS as [CREDIT DAYS],
                    A.CNIC,A.EXPIRY
                    FROM CUSTOMER_PROFILE A, CITY B, COA C, SALES_PERSONS D,AREA E
                    WHERE A.COA_ID=C.COA_ID and A.CITY_ID=B.CITY_ID and A.SALE_PER_ID=D.SALES_PER_ID AND A.AREA_ID = E.AREA_ID ";

                if (cmbArea.SelectedIndex > 0)
                    cls_fhp.query += $" AND A.AREA_ID = '{cmbArea.SelectedValue.ToString()}'";
                if (cmbCity.SelectedIndex > 0)
                    cls_fhp.query += $" AND A.CITY_ID = '{cmbCity.SelectedValue.ToString()}'";
                if (cmbCustName.SelectedIndex > 0)
                    cls_fhp.query += $" AND A.COA_ID = '{cmbCustName.SelectedValue.ToString()}'";
                if (cmbSalesPerson.SelectedIndex > 0)
                    cls_fhp.query += $" AND A.SALE_PER_ID = '{cmbSalesPerson.SelectedValue.ToString()}'";

                cls_fhp.query +=@"
                    order by C.COA_NAME";
                cls_fhp.LoadGrid(grdSEARCH, cls_fhp.query);

                cls_fhp.mds.Tables["CustomerProfile"].Clear();
                foreach (DataGridViewRow row in grdSEARCH.Rows)
                {
                    cls_fhp.dataR = cls_fhp.mds.Tables["CustomerProfile"].NewRow();
                    cls_fhp.dataR["CustomerName"] = row.Cells["COA_NAME"].Value.ToString();
                    cls_fhp.dataR["SalesPerson"] = row.Cells["SALES PERSON"].Value.ToString(); 
                    cls_fhp.dataR["ContactPerson"] = row.Cells["CONTACT_PERSON"].Value.ToString(); 
                    cls_fhp.dataR["Mobile"] = row.Cells["MOBILE"].Value.ToString(); 
                    cls_fhp.dataR["Email"] = row.Cells["EMAIL"].Value.ToString();
                    cls_fhp.dataR["Address"] = row.Cells["ADDRESS"].Value.ToString(); 
                    cls_fhp.dataR["City"] = row.Cells["CITY"].Value.ToString(); 

                    cls_fhp.mds.Tables["CustomerProfile"].Rows.Add(cls_fhp.dataR);
                }

                cls_fhp.rpt = new frmReports();
                cls_fhp.rpt.GenerateReport("CustomerProfileReport", cls_fhp.mds);
                cls_fhp.rpt.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
