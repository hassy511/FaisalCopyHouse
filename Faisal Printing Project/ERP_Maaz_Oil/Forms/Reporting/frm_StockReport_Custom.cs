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
    public partial class frm_StockReport_Custom : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        List<string> IsCheckedName = new List<string>();
        List<int> IsCheckedValue = new List<int>();

        public frm_StockReport_Custom()
        {
            InitializeComponent();
        }

        private void LoadProducts(int brandId)
        {
            classHelper.query = @"SELECT PM_ID AS [ID],PRODUCT_NAME+'-'+PRODUCT_CODE AS [NAME]
                FROM PRODUCT_MASTER
                WHERE BRAND_ID = '" + brandId+ @"'
                ORDER BY [NAME]";
            //classHelper.LoadCheckedListBox(itemList, classHelper.query);
            
            try
            {
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                Classes.Helper.conn.Close();
                classHelper.adp = new SqlDataAdapter(classHelper.cmd);
                DataTable dt = new DataTable();
                classHelper.adp.Fill(dt);
                ((ListBox)this.itemList).DataSource = dt;
                ((ListBox)this.itemList).DisplayMember = "NAME";
                ((ListBox)this.itemList).ValueMember = "ID";

            }
            catch (Exception)
            {
                //throw;
            }
            finally
            {
                Classes.Helper.conn.Close();
            }
        }

        private void LoadBrands()
        {
            classHelper.query = @"SELECT '0' AS [id],'--SELECT BRAND--' AS [name]
            UNION ALL
            SELECT P_CATEGORY_ID AS [ID],P_CATEEGORY_NAME AS [name] 
            FROM PRODUCT_CATEGORY 
            ORDER BY [name]";
            classHelper.LoadComboData(cmbBrand, classHelper.query);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.R))
            {
                GenerateReport();
            }
            if (keyData == (Keys.Escape))
            {
                this.Dispose();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void GenerateReport()
        {
            char hasRows = 'N';

            if (cmbBrand.SelectedIndex <= 0)
            {
                MessageBox.Show("Please select brand.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbBrand.Focus();
                return;
            }

            classHelper.query = @"SELECT B.PM_ID,B.PRODUCT_CODE,C.P_CATEEGORY_NAME AS [BRAND],B.PRODUCT_NAME AS [PRODUCT],
            B.OPENING_QTY AS [OPENING],
            ISNULL((
	            SELECT SUM(QTY) 
	            FROM SALE_RETURN_MASTER X
	            INNER JOIN SALE_RETURN_DETAIL Y ON X.SALE_RETURN_MASTER_ID = Y.SALE_RETURN_MASTER_ID
	            INNER JOIN PRODUCT_MASTER Z ON Y.ITEM_ID = Z.PM_ID
	            WHERE X.[DATE] <= '" + Classes.Helper.ConvertDatetime(dtpTo.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"' AND Y.ITEM_ID = B.PM_ID 
            ),0) +
            ISNULL((
	            SELECT SUM(QTY) 
	            FROM PRODUCTION_MASTER X
	            INNER JOIN PRODUCTION_DETAIL Y ON X.ID = Y.PRODUCTION_MASTER_ID
	            INNER JOIN PRODUCT_MASTER Z ON Y.PRODUCT_MASTER_ID = Z.PM_ID
	            WHERE X.[DATE] <= '" + Classes.Helper.ConvertDatetime(dtpTo.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"' AND Y.PRODUCT_MASTER_ID = B.PM_ID 
            ),0) +
            ISNULL((
	            SELECT SUM(X.QTY) 
	            FROM INVENTORY_ADJUSTMENTS X
	            INNER JOIN PRODUCT_MASTER Z ON X.MATERIAL_ID = Z.PM_ID
	            WHERE X.[DATE] <= '" + Classes.Helper.ConvertDatetime(dtpTo.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"' AND X.MATERIAL_ID = B.PM_ID 
	            AND X.ADD_LESS = 'A'
            ),0) AS [IN],
            ISNULL((
	            SELECT SUM(QTY) 
	            FROM SALE_MASTER X
	            INNER JOIN SALE_DETAIL Y ON X.SALE_MASTER_ID = Y.SALE_MASTER_ID
	            INNER JOIN PRODUCT_MASTER Z ON Y.ITEM_ID = Z.PM_ID
	            WHERE X.[DATE] <= '" + Classes.Helper.ConvertDatetime(dtpTo.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"' AND Y.ITEM_ID = B.PM_ID 
            ),0)  +
            ISNULL((
	            SELECT SUM(X.QTY) 
	            FROM INVENTORY_ADJUSTMENTS X
	            INNER JOIN PRODUCT_MASTER Z ON X.MATERIAL_ID = Z.PM_ID
	            WHERE X.[DATE] <= '" + Classes.Helper.ConvertDatetime(dtpTo.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"' AND X.MATERIAL_ID = B.PM_ID 
	            AND X.ADD_LESS = 'D'
            ),0) AS [OUT]
            FROM PRODUCT_MASTER B
            INNER JOIN PRODUCT_CATEGORY C ON C.P_CATEGORY_ID = B.BRAND_ID  
            WHERE B.PM_ID IN (" + classHelper.GetCheckedListValues(itemList) + @")  
            ORDER BY [BRAND]";

            //classHelper.query = @"SELECT B.PM_ID,B.PRODUCT_CODE,C.P_CATEEGORY_NAME AS [BRAND],B.PRODUCT_NAME AS [PRODUCT],
            //MAX(B.OPENING_QTY) + SUM(CASE WHEN ENTRY_FROM = 'ADD PRODUCT OPENING' THEN 0 ELSE A.STOCK_IN END) - SUM(A.STOCK_OUT) AS OPENING,
            //ISNULL((
	           // SELECT SUM(CASE WHEN ENTRY_FROM = 'ADD PRODUCT OPENING' THEN 0 ELSE X.STOCK_IN END) FROM PRODUCT_ITEM_LEDGER X 
	           // WHERE X.PRODUCT_ID = B.PM_ID AND X.[DATE] BETWEEN '" + Classes.Helper.ConvertDatetime(dtpFrom.Value.Date) + @"' AND '" + Classes.Helper.ConvertDatetime(dtpTo.Value.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
            //),0) AS [IN],
            //ISNULL((
	           // SELECT SUM(Y.STOCK_OUT) FROM PRODUCT_ITEM_LEDGER Y 
	           // WHERE Y.PRODUCT_ID = B.PM_ID AND Y.[DATE] BETWEEN '" + Classes.Helper.ConvertDatetime(dtpFrom.Value.Date) + @"' AND '" + Classes.Helper.ConvertDatetime(dtpTo.Value.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
            //),0) AS [OUT]
            //FROM PRODUCT_MASTER B
            //INNER JOIN PRODUCT_ITEM_LEDGER A ON A.PRODUCT_ID = B.PM_ID
            //INNER JOIN PRODUCT_CATEGORY C ON C.P_CATEGORY_ID = B.BRAND_ID
            //WHERE A.[DATE] <= '" + Classes.Helper.ConvertDatetime(dtpFrom.Value.Date) + @"'  AND B.PM_ID IN (" + classHelper.GetCheckedListValues(itemList) + @") 
            //GROUP BY B.PM_ID,C.P_CATEEGORY_NAME,B.PRODUCT_NAME,B.PRODUCT_CODE
            //ORDER BY [BRAND]";

            Classes.Helper.conn.Open();
            try
            {
                classHelper.nds.Tables["StockReport"].Clear();
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    hasRows = 'Y';
                    while (classHelper.dr.Read())
                    {
                        classHelper.dataR = classHelper.nds.Tables["StockReport"].NewRow();

                        classHelper.dataR["fromDate"] = dtpFrom.Value.Date;
                        classHelper.dataR["toDate"] = dtpTo.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                        classHelper.dataR["brand"] = classHelper.dr["BRAND"].ToString();
                        classHelper.dataR["code"] = classHelper.dr["PRODUCT_CODE"].ToString();
                        classHelper.dataR["product"] = classHelper.dr["PRODUCT"].ToString();
                        classHelper.dataR["opening"] = Convert.ToDecimal(classHelper.dr["OPENING"].ToString());
                        classHelper.dataR["in"] = Convert.ToDecimal(classHelper.dr["IN"].ToString());
                        classHelper.dataR["out"] = Convert.ToDecimal(classHelper.dr["OUT"].ToString());
                        classHelper.dataR["balance"] = Convert.ToDecimal(classHelper.dr["OPENING"].ToString()) + Convert.ToDecimal(classHelper.dr["IN"].ToString()) - Convert.ToDecimal(classHelper.dr["OUT"].ToString());
                        //classHelper.dataR["rate"] = Convert.ToDecimal(classHelper.dr["RATE"].ToString());
                        //classHelper.dataR["amount"] = (Convert.ToDecimal(classHelper.dr["OPENING"].ToString()) + Convert.ToDecimal(classHelper.dr["IN"].ToString()) - Convert.ToDecimal(classHelper.dr["OUT"].ToString())) * Convert.ToDecimal(classHelper.dr["RATE"].ToString()); 

                        classHelper.nds.Tables["StockReport"].Rows.Add(classHelper.dataR);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Classes.Helper.conn.Close();
            }

            if (hasRows == 'Y')
            {
                classHelper.rpt = new frmReports();
                classHelper.rpt.GenerateReport("StockReportCustom", classHelper.nds);
                classHelper.rpt.ShowDialog();
            }
            else {
                MessageBox.Show("No Record Found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnINTER_SAVE_Click(object sender, EventArgs e)
        {
            GenerateReport();
        }
        private void frm_Account_Ledger_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            IsCheckedName = null;
            IsCheckedValue = null;
        }

        private void frm_ControlAccountLedger_Load(object sender, EventArgs e)
        {
            LoadBrands();
        }

        private void cmbBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBrand.SelectedIndex > 0)
            {
                LoadProducts(Convert.ToInt32(cmbBrand.SelectedValue.ToString()));
            }
            else {
                itemList.Items.Clear();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            if (cmbBrand.SelectedIndex > 0)
            {
                try
                {
                    foreach (object item in itemList.CheckedItems)
                    {
                        DataRowView castedItem = item as DataRowView;
                        int value = Convert.ToInt32(castedItem["ID"]);
                        string countrieName = castedItem["NAME"].ToString().Trim();
                        IsCheckedValue.Add(value);
                        IsCheckedName.Add(countrieName);
                    }
                    string selected = txtSearch.Text.Trim();

                    SqlCommand cmd = new SqlCommand("GETPRODUCTLIST", Classes.Helper.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", selected);
                    cmd.Parameters.AddWithValue("@BRAND_ID", Convert.ToInt32(cmbBrand.SelectedValue.ToString()));
                    classHelper.adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    classHelper.adp.Fill(dt);
                    ((ListBox)this.itemList).DataSource = dt;
                    ((ListBox)this.itemList).DisplayMember = "NAME";
                    ((ListBox)this.itemList).ValueMember = "ID";

                    for (int i = 0; i < itemList.Items.Count; i++)
                    {
                        itemList.SetItemChecked(i, false);
                    }

                    foreach (string item in IsCheckedName)
                    {
                        for (int i = 0; i < itemList.Items.Count; i++)
                        {
                            if (item == Convert.ToString(dt.Rows[i]["NAME"]).Trim())
                            {
                                itemList.SetItemChecked(i, true);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    Classes.Helper.conn.Close();
                }
            }
        }
    }
}
