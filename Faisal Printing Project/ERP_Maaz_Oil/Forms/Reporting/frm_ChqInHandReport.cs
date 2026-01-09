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
    public partial class frm_ChqInHandReport : Form
    {
        ERP_Maaz_Oil.Classes.Helper classHelper = new ERP_Maaz_Oil.Classes.Helper();
        ChqInHandReport clsChqInHand = new ChqInHandReport();
        public frm_ChqInHandReport()
        {
            InitializeComponent();
        }
        private void LoadSalesPerson()
        {
            classHelper.query = @"SELECT '0' AS [id],'--SELECT SALES PERSON--' as [name]
            UNION ALL
            SELECT SALES_PER_ID AS [id],NAME AS [name] FROM SALES_PERSONS WHERE SALES_PER_ID <> '1' ORDER BY [name]";
            classHelper.LoadComboData(cmbSalePerson, classHelper.query);
        }
        private void LoadCustomers()
        {
            classHelper.LoadCustomers(cmbCustomer);
        }

        private void ShowReport()
        {
            if (rdbSalesPerson.Checked == true) {
                classHelper.query = clsChqInHand.SalesPersonWiseQuery(Convert.ToInt32(cmbSalePerson.SelectedValue.ToString()));
            }
            else if (rdbCustomer.Checked == true)
            {
                classHelper.query = clsChqInHand.CustomerWiseQuery(Convert.ToInt32(cmbCustomer.SelectedValue.ToString()));
            }
            else if (rdbDate.Checked == true)
            {
                classHelper.query = clsChqInHand.DateWiseQuery(dtp_FROM.Value.Date,dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59));
            }
            else
            {
                classHelper.query = clsChqInHand.OverAllQuery();
            }

            char hasRows = 'N';
            try
            {
                //Classes.Helper.conn.Open();
                //classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                //classHelper.dr = classHelper.cmd.ExecuteReader();
                //if (classHelper.dr.HasRows == true)
                //{
                //    hasRows = 'Y';
                //    classHelper.mds.Tables["ProvinceWiseReport"].Clear();
                //    while (classHelper.dr.Read())
                //    {
                //        classHelper.dataR = classHelper.mds.Tables["ProvinceWiseReport"].NewRow();
                //        classHelper.dataR["from"] = dtp_FROM.Value.Date;
                //        classHelper.dataR["to"] = dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                //        classHelper.dataR["salePerson"] = classHelper.dr["sales_person"].ToString();
                //        classHelper.dataR["province"] = classHelper.dr["province"].ToString();
                //        classHelper.dataR["customerName"] = classHelper.dr["customerName"].ToString();
                //        classHelper.dataR["canolaWeight"] = Convert.ToDecimal(classHelper.dr["canolaWeight"].ToString());
                //        classHelper.dataR["canolaRate"] = Convert.ToDecimal(classHelper.dr["canolaRate"].ToString());
                //        classHelper.dataR["canolaTotal"] = Convert.ToDecimal(classHelper.dr["canolaAmount"].ToString());
                //        classHelper.dataR["olienWeight"] = Convert.ToDecimal(classHelper.dr["olienWeight"].ToString());
                //        classHelper.dataR["olienRate"] = Convert.ToDecimal(classHelper.dr["olienRate"].ToString());
                //        classHelper.dataR["olienTotal"] = Convert.ToDecimal(classHelper.dr["olienAmount"].ToString());
                //        classHelper.mds.Tables["ProvinceWiseReport"].Rows.Add(classHelper.dataR);
                //    }
                //}
                //else {
                //    MessageBox.Show("No Record Found.", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Classes.Helper.conn.Close();
            }

            classHelper.query = @"create table #temp1(
                province varchar(max),
                canolaWeight float,
                canolaAmount float,
                canolaRate float
                )
                insert into #temp1
                SELECT J.REGION_NAME AS [PROVINCE],
                SUM((E.WEIGHT * C.QTY)) AS [CANOLA TOTAL WEIGHT],SUM((C.QTY) * C.RATE) AS [CANOLA AMOUNT],
                SUM((C.QTY) * C.RATE) / SUM((E.WEIGHT * C.QTY)) AS [CANOLA AVG RATE]
                FROM SALES A
                INNER JOIN SALES_PROGRAM_MASTER B ON A.SOP_ID = B.SPM_ID
                INNER JOIN SALES_PROGRAM_DETAILS C ON B.SPM_ID = C.SPM_ID
                INNER JOIN PRODUCT_MASTER D ON C.PRODUCT_ID = D.PM_ID
                INNER JOIN PRODUCT_DETAILS E ON D.PM_ID = E.PM_ID
                INNER JOIN COA G ON B.CUSTOMER_ID = G.COA_ID
                INNER JOIN CUSTOMER_PROFILE H ON H.COA_ID = G.COA_ID
                INNER JOIN CITY I ON H.CITY_ID = I.CITY_ID
                INNER JOIN REGION J ON I.REG_ID = J.REGION_ID
                WHERE E.MATERIAL_ID = '5005'
                AND A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
                AND H.SALE_PER_ID = '" + cmbSalePerson.SelectedValue.ToString() + @"'
                GROUP BY J.REGION_NAME

                create table #temp2(
                province varchar(max),
                olienWeight float,
                olienAmount float,
                olienRate float
                )

                insert into #temp2
                SELECT J.REGION_NAME AS[PROVINCE],
                SUM((E.WEIGHT * C.QTY)) AS[OLIEN TOTAL WEIGHT], SUM((C.QTY) * C.RATE) AS[OLIEN AMOUNT],
                SUM((C.QTY) * C.RATE) / SUM((E.WEIGHT * C.QTY)) AS[OLIEN AVG RATE]
                FROM SALES A
                INNER JOIN SALES_PROGRAM_MASTER B ON A.SOP_ID = B.SPM_ID
                INNER JOIN SALES_PROGRAM_DETAILS C ON B.SPM_ID = C.SPM_ID
                INNER JOIN PRODUCT_MASTER D ON C.PRODUCT_ID = D.PM_ID
                INNER JOIN PRODUCT_DETAILS E ON D.PM_ID = E.PM_ID
                INNER JOIN COA G ON B.CUSTOMER_ID = G.COA_ID
                INNER JOIN CUSTOMER_PROFILE H ON H.COA_ID = G.COA_ID
                INNER JOIN SALES_PERSONS F ON H.SALE_PER_ID = F.SALES_PER_ID
                INNER JOIN CITY I ON H.CITY_ID = I.CITY_ID
                INNER JOIN REGION J ON I.REG_ID = J.REGION_ID
                WHERE E.MATERIAL_ID = '5003'
                AND A.DATE BETWEEN '" + dtp_FROM.Value.Date + "' AND '" + dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
                AND H.SALE_PER_ID = '" + cmbSalePerson.SelectedValue.ToString() + @"'
                GROUP BY J.REGION_NAME

                select x.province,
                ISNULL(a.olienWeight,'0') AS olienWeight,ISNULL(a.olienAmount,'0') AS olienAmount,
                ISNULL(a.olienRate,'0') AS olienRate,ISNULL(x.canolaWeight,'0') AS canolaWeight,
                ISNULL(x.canolaAmount,'0') AS canolaAmount,ISNULL(x.canolaRate,'0') AS canolaRate
                from #temp2 a
                right join(
                select *from #temp1
                union all
                SELECT province, null, null, null FROM #temp2 WHERE
                province not in (select province from #temp1)
                ) x on x.province = a.province

                drop table #temp1
                drop table #temp2";
            
            try
            {
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    classHelper.mds.Tables["ProvinceWiseReportSummary"].Clear();
                    while (classHelper.dr.Read())
                    {
                        classHelper.dataR = classHelper.mds.Tables["ProvinceWiseReportSummary"].NewRow();
                        classHelper.dataR["province"] = classHelper.dr["province"].ToString();
                        classHelper.dataR["olienWeight"] = Convert.ToDecimal(classHelper.dr["olienWeight"].ToString());
                        classHelper.dataR["olienAmount"] = Convert.ToDecimal(classHelper.dr["olienAmount"].ToString());
                        classHelper.dataR["olienRate"] = Convert.ToDecimal(classHelper.dr["olienRate"].ToString());
                        classHelper.dataR["canolaWeight"] = Convert.ToDecimal(classHelper.dr["canolaWeight"].ToString());
                        classHelper.dataR["canolaRate"] = Convert.ToDecimal(classHelper.dr["canolaRate"].ToString());
                        classHelper.dataR["canolaAmount"] = Convert.ToDecimal(classHelper.dr["canolaAmount"].ToString()); 
                        classHelper.dataR["from"] = dtp_FROM.Value.Date;
                        classHelper.dataR["to"] = dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                        classHelper.dataR["salePerson"] = cmbSalePerson.Text;
                        classHelper.mds.Tables["ProvinceWiseReportSummary"].Rows.Add(classHelper.dataR);
                    }
                }
                else
                {
                    // MessageBox.Show("No Record Found.", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //Reports.POSummary rptPOS = new Reports.POSummary();
                //rptPOS.SetDataSource(classHelper.mds.Tables["PO_Summary"]);
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
                classHelper.rpt.GenerateReport("ProvinceWiseReport", classHelper.mds);
                classHelper.rpt.ShowDialog();

                classHelper.rpt = new frmReports();
                classHelper.rpt.GenerateReport("ProvinceWiseReportSummary", classHelper.mds);
                classHelper.rpt.ShowDialog();
            }
        }

        private void grpSALES_Enter(object sender, EventArgs e)
        {
            
        }
        
        private void btnINTER_SAVE_Click(object sender, EventArgs e)
        {
            if (cmbSalePerson.Enabled == true && cmbSalePerson.SelectedIndex == 0)
            {
                MessageBox.Show("Select an Sales Person.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmbCustomer.Enabled == true && cmbCustomer.SelectedIndex == 0)
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
            LoadSalesPerson();
            LoadCustomers();
        }

        private void frm_Account_Ledger_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void lblAC_NAME_Click(object sender, EventArgs e)
        {

        }

        private void cmbSalePerson_TextUpdate(object sender, EventArgs e)
        {
            classHelper.CmbTextUpdate(sender as ComboBox);
        }

        private void cmbSalePerson_DropDown(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown += new PreviewKeyDownEventHandler(cmbSalePerson_PreviewKeyDown);
        }

        private void cmbSalePerson_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown -= cmbSalePerson_PreviewKeyDown;
            if (cbo.DroppedDown) cbo.Focus();
        }

        private void rdbSalesPerson_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbSalesPerson.Checked == true)
            {
                cmbSalePerson.Enabled = true;
                cmbCustomer.Enabled = false;
                dtp_FROM.Enabled = false;
                dtp_TO.Enabled = false;
            }
            else {
                cmbSalePerson.Enabled = false;
            }
        }

        private void rdbCustomer_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCustomer.Checked == true)
            {
                cmbSalePerson.Enabled = false;
                cmbCustomer.Enabled = true;
                dtp_FROM.Enabled = false;
                dtp_TO.Enabled = false;
            }
            else
            {
                cmbCustomer.Enabled = false;
            }
        }

        private void rdbDate_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbDate.Checked == true)
            {
                cmbSalePerson.Enabled = false;
                cmbCustomer.Enabled = false;
                dtp_FROM.Enabled = true;
                dtp_TO.Enabled = true;
            }
            else
            {
                dtp_FROM.Enabled = false;
                dtp_TO.Enabled = false;
            }
        }

        private void rdbOverAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbOverAll.Checked == true)
            {
                cmbSalePerson.Enabled = false;
                cmbCustomer.Enabled = false;
                dtp_FROM.Enabled = false;
                dtp_TO.Enabled = false;
            }
        }

        private void cmbCustomer_DropDown(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown += new PreviewKeyDownEventHandler(cmbCustomer_PreviewKeyDown);
        }

        private void cmbCustomer_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown -= cmbCustomer_PreviewKeyDown;
            if (cbo.DroppedDown) cbo.Focus();
        }
    }
}
