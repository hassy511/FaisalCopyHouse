using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP_Maaz_Oil.Classes
{
    class Helper
    {
        //abc testing 123
        public string query = "";
        public DataTable dt;
        public SqlCommand cmd;
        public SqlDataReader dr;
        public SqlDataReader dr2;
        public SqlDataAdapter adp;
        public System.Data.DataSet ds;

        public DataSets.ReportDataSets mds = new DataSets.ReportDataSets();
        public DataSets.NewDataSet nds = new DataSets.NewDataSet();
        public DataSets.NewDataSet2 nds2 = new DataSets.NewDataSet2();
        public DataRow dataR;
        public ERP_Maaz_Oil.Forms.Reporting.frmReports rpt;
        public ERP_Maaz_Oil.Forms.Reporting.frmLedgerReports rptLedger;

        public static SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
        public static SqlConnection conn1 = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
        public static SqlConnection conn3 = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
        public static SqlConnection conn2 = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString1"]);

        //public static SqlConnection conn = new SqlConnection("server=92.205.25.83; database=BROKER_MANAGEMENT_SYSTEM_2023_24;user id = sa;password=nbot@2121#$;");
        //public static SqlConnection conn1 = new SqlConnection("server=92.205.25.83; database=BROKER_MANAGEMENT_SYSTEM_2023_24;user id = sa;password=nbot@2121#$;");
        //public static SqlConnection conn3 = new SqlConnection("server=92.205.25.83; database=BROKER_MANAGEMENT_SYSTEM_2023_24;user id = sa;password=nbot@2121#$;");
        //public static SqlConnection conn2 = new SqlConnection("server=92.205.25.83; database=BROKER_MANAGEMENT_SYSTEM_2023_24;user id = sa;password=nbot@2121#$;");

        //public static string userRights { get; set; }
        public static int userId { get; set; }
        public static int cashId { get; set; }
        public static int purchasesId { get; set; }
        public static int purchaseReturnId { get; set; }
        public static int otherIncomeId { get; set; }
        public static int gstTaxId { get; set; }
        public static int salesId { get; set; }
        public static int salesReturnId { get; set; }
        public static int inventoryId { get; set; }
        public static int lossInventoryId { get; set; }
        public static int printingExpense { get; set; }
        public static DateTime openingDate = Convert.ToDateTime("2020-07-01 00:00:00");
        public string project = "1";
        public frmAddGroupAccounts frmAddGroup;
        public ERP_Maaz_Oil.Forms.frmAddRegion frmAddRegion;
        public ERP_Maaz_Oil.Forms.frmAddCity frmAddCity;
        public ERP_Maaz_Oil.Forms.frmAddArea frmAddArea;
        public ERP_Maaz_Oil.Forms.frmFinishedProducts frmProducts;

        public string GetCheckedListValues(CheckedListBox ckhB) {
            string value = "";
            foreach (object itemChecked in ckhB.CheckedItems)
            {
                DataRowView item = itemChecked as DataRowView;
                value = value + item["ID"].ToString() + ",";
            }
            value = value.TrimEnd(',');
            return value;
        }

        public void check_blank_zero(TextBox txt)
        {
            if (txt.Text.Trim().Equals(""))
            {
                txt.Text = "0";
            }
        }

        public string GetAccountBalance(DateTime date, int accountId)
        {
            query = @" SELECT SUM(B.DEBIT)+SUM(B.CREDIT)
		                +(select case when DR_CR = 'D' then OPEN_BAL else -OPEN_BAL end from COA where COA_ID = b.COA_ID) 
		                as [Opening] FROM
		                LEDGERS B
		                WHERE B.DATE < '" + date + @"' AND B.COA_ID = " + accountId + @"
		                Group By B.COA_ID";
            return GetScalarAmount(query).ToString();
        }

        //load data in checked list box
        public void LoadCheckedListBox(CheckedListBox listBox, string query)
        {
            SqlConnection thisConn = new SqlConnection();
            thisConn = Classes.Helper.conn;
            ((ListBox)listBox).DataSource = null;
            listBox.Items.Clear();
            try
            {
                if (thisConn.State == System.Data.ConnectionState.Closed) { if (thisConn.State == System.Data.ConnectionState.Closed) { thisConn.Open(); } }

                cmd = new SqlCommand(query, thisConn);
                cmd.CommandTimeout = 0;
                adp = new SqlDataAdapter();
                adp.SelectCommand = cmd;
                ds = new System.Data.DataSet();
                adp.Fill(ds, "data");

                ((ListBox)listBox).DataSource = ds.Tables["data"];
                ((ListBox)listBox).DisplayMember = "BRAND";
                ((ListBox)listBox).ValueMember = "ID";

                //cmb.MatchingMethod = StringMatchingMethod.NoWildcards;

                //Font = new Font("Segoe UI", 9.0f);
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.ToString(), "Exception");
            }
            finally
            {
                thisConn.Close();

            }
        }

        public static string GetUserName(int userId)
        {
            if (conn3.State == System.Data.ConnectionState.Closed) { conn3.Open(); }
            try
            {
                string query = "select USERS_NAME from users where USERS_ID = '" + userId + "'";
                SqlCommand cmd = new SqlCommand(query, conn3);
                cmd.CommandTimeout = 0;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    if (dr.Read())
                    {
                        return dr["USERS_NAME"].ToString();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            finally
            {
                conn3.Close();
            }
            return "";
        }

        public bool CheckProductExists(string productName)
        {
            if (conn3.State == System.Data.ConnectionState.Closed) { conn3.Open(); }
            try
            {
                string query = @"SELECT PRODUCT_NAME FROM PRODUCT_MASTER WHERE PRODUCT_NAME = '" + productName + "'";
                SqlCommand cmd = new SqlCommand(query, conn3);
                cmd.CommandTimeout = 0;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    if (dr.Read())
                    {
                        if (!dr["PRODUCT_NAME"].ToString().Equals(""))
                        {
                            return true;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            finally
            {
                conn3.Close();
            }
            return false;
        }

        public bool CheckAccountExists(string accountName) {
            if (conn3.State == System.Data.ConnectionState.Closed) { conn3.Open(); }
            try
            {
                string query = @"SELECT COA_NAME FROM COA WHERE COA_NAME = '" + accountName + "'";
                SqlCommand cmd = new SqlCommand(query, conn3);
                cmd.CommandTimeout = 0;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    if (dr.Read())
                    {
                        if (!dr["COA_NAME"].ToString().Equals("")) {
                            return true;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            finally
            {
                conn3.Close();
            }
            return false;
        }

        public void LoadBankCashVoucherGrid(DataGridView dg, DateTime dtpDate)
        {
            query = @" SELECT A.ID,A.[DATE],CASE WHEN A.VOUCHER_TYPE = 'R' THEN 'RECEIPT' ELSE 'PAYMENT' END AS [VOUCHER TYPE],A.VOUCHER_NUMBER,A.ACCOUNT_ID,A.BANK_ID,
            B.COA_NAME AS [ACCOUNT NAME],A.[DESCRIPTION],A.AMOUNT
            FROM BANK_VOUCHER A
            INNER JOIN COA B ON A.ACCOUNT_ID = B.COA_ID
            WHERE A.[DATE] BETWEEN '" + dtpDate + @"' AND '" + dtpDate.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
            ORDER BY [DATE] DESC";

            try
            {
                if (Classes.Helper.conn.State == ConnectionState.Closed)
                    Classes.Helper.conn.Open();

                cmd = new SqlCommand(query, Classes.Helper.conn);
                dr = cmd.ExecuteReader();
                dt = new DataTable();
                dt.Load(dr);
                dg.DataSource = dt;
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

        public void LoadReceivingPaymentVoucherGrid(DataGridView dg, DateTime dtpDate)
        {
            query = @" SELECT A.ID,A.[DATE],CASE WHEN A.VOUCHER_TYPE = 'R' THEN 'RECEIPT' ELSE 'PAYMENT' END AS [VOUCHER TYPE],A.VOUCHER_NUMBER,A.ACCOUNT_ID,
            B.COA_NAME AS [ACCOUNT NAME],A.[DESCRIPTION],A.AMOUNT
            FROM CASH_VOUCHER A
            INNER JOIN COA B ON A.ACCOUNT_ID = B.COA_ID
            WHERE A.[DATE] BETWEEN '" + dtpDate + @"' AND '" + dtpDate.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
            ORDER BY [DATE] DESC";

            try
            {
                if (Classes.Helper.conn.State == ConnectionState.Closed)
                    Classes.Helper.conn.Open();

                cmd = new SqlCommand(query, Classes.Helper.conn);
                dr = cmd.ExecuteReader();
                dt = new DataTable();
                dt.Load(dr);
                dg.DataSource = dt;
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

        public void LoadCashVoucherGrid(DataGridView dg, DateTime dtpDate)
        {
            query = @" SELECT A.ID,A.[DATE],CASE WHEN A.VOUCHER_TYPE = 'R' THEN 'RECEIPT' ELSE 'PAYMENT' END AS [VOUCHER TYPE],A.VOUCHER_NUMBER,A.ACCOUNT_ID,
            B.COA_NAME AS [ACCOUNT NAME],A.[DESCRIPTION],A.AMOUNT
            FROM CASH_VOUCHER A
            INNER JOIN COA B ON A.ACCOUNT_ID = B.COA_ID
            WHERE A.[DATE] BETWEEN '" + dtpDate + @"' AND '" + dtpDate.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
            ORDER BY [DATE] DESC";

            try
            {
                if (Classes.Helper.conn.State == ConnectionState.Closed)
                    Classes.Helper.conn.Open();

                cmd = new SqlCommand(query, Classes.Helper.conn);
                dr = cmd.ExecuteReader();
                dt = new DataTable();
                dt.Load(dr);
                dg.DataSource = dt;
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

        public decimal GetProductRate(int productId)
        {
            try
            {
                query = @" SELECT TOP 1 X.RATE FROM (
                SELECT -1 AS [ID],OPENING_RATE AS [RATE] FROM PRODUCT_MASTER WHERE PM_ID = '" + productId + @"'
                UNION ALL
                SELECT PURCHASE_DETAIL AS [ID],RATE FROM PURCHASE_DETAIL WHERE MATERIAL_ID = '" + productId + @"'
                ) X
                ORDER BY ID DESC";
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                cmd = new SqlCommand(query, conn);
                cmd.CommandTimeout = 0;
                return Convert.ToDecimal(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.ToString(), "Exception");
            }
            finally
            {
                conn.Close();
            }
            return 0;
        }

        public void LoadAdjustmentProducts(string date, DataGridView dg)
        {
            dg.Rows.Clear();
            query = @"SELECT A.IA_ID,A.[DATE],A.MATERIAL_ID,B.PRODUCT_NAME AS [PRODUCT],
	        A.ADD_LESS,
            A.QTY,A.RATE
            FROM INVENTORY_ADJUSTMENTS A
            INNER JOIN PRODUCT_MASTER B ON A.MATERIAL_ID = B.PM_ID
            WHERE [DATE] = '" + date + "'";

            try
            {
                if (conn1.State == System.Data.ConnectionState.Closed) { conn1.Open(); }
                cmd = new SqlCommand(query, conn1);
                cmd.CommandTimeout = 0;
                dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        dg.Rows.Add(dr["IA_ID"].ToString(), dr["MATERIAL_ID"].ToString(), dr["PRODUCT"].ToString(),
                        dr["QTY"].ToString(), dr["RATE"].ToString(), (Convert.ToDecimal(dr["QTY"].ToString()) * Convert.ToDecimal(dr["RATE"].ToString())),
                        dr["ADD_LESS"].ToString());
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), ":: Error ::", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn1.Close();
            }
        }

        public void LoadAdjustmentMaterial(string date, DataGridView dg)
        {
            dg.Rows.Clear();
            query = @"SELECT A.ID AS IA_ID,A.[DATE],A.MATERIAL_ID,B.MATERIAL_NAME AS [PRODUCT],
            A.ADD_LESS,
            A.QTY,A.RATE
            FROM INVENTORY_ADJUSTMENTS_RAW A
            INNER JOIN MATERIALS B ON A.MATERIAL_ID = B.MATERIAL_ID
            WHERE A.[DATE] = '" + date + "'";

            try
            {
                if (conn1.State == System.Data.ConnectionState.Closed) { conn1.Open(); }
                cmd = new SqlCommand(query, conn1);
                cmd.CommandTimeout = 0;
                dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        dg.Rows.Add(dr["IA_ID"].ToString(), dr["MATERIAL_ID"].ToString(), dr["PRODUCT"].ToString(),
                        dr["QTY"].ToString(), dr["RATE"].ToString(), (Convert.ToDecimal(dr["QTY"].ToString()) * Convert.ToDecimal(dr["RATE"].ToString())),
                        dr["ADD_LESS"].ToString());
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), ":: Error ::", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn1.Close();
            }
        }

        //*****************Global methods************************//
        public void PurchaseSale_search(TextBox txtSEARCH, DataGridView grdSEARCH)
        {
            (grdSEARCH.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
            CONVERT([" + grdSEARCH.Columns["SO DATE"].Name.ToString() + "],System.String) LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR CONVERT(["
               + grdSEARCH.Columns["SALES INVOICE"].Name.ToString() + "],System.String) LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR CONVERT(["
               + grdSEARCH.Columns["SO #"].Name.ToString() + "],System.String) LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR CONVERT("
               + grdSEARCH.Columns["MATERIAL_NAME"].Name.ToString() + ",System.String) LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR CONVERT("
               + grdSEARCH.Columns["SALES_WEIGHT"].Name.ToString() + ",System.String) LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR CONVERT(["
               + grdSEARCH.Columns["SO BALANCE WEIGHT"].Name.ToString() + "],System.String) LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR CONVERT(["
              + grdSEARCH.Columns["SALES DESCRIPTION"].Name.ToString() + "],System.String) LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%'");
            grdSEARCH.ClearSelection();
        }

        public DataTable GetClosingStockData(DateTime date) {
            DataTable dt = new DataTable();
            try
            {
                if (conn1.State == System.Data.ConnectionState.Closed) { conn1.Open(); }
                cmd = new SqlCommand("GET_CLOSING_INVENTORY", conn1);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@REPORT_DATE", date);
                cmd.CommandTimeout = 0;
                adp = new SqlDataAdapter();
                adp.SelectCommand = cmd;
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.ToString(), ":: Error ::");
            }
            finally
            {
                conn1.Close();
            }
            return dt;
        }
        public Decimal GetClosingStockValue(DateTime date) {
            try
            {
                DataTable dt = GetClosingStockData(date);
                //DataGridView dg = new DataGridView();
                //dg.DataSource = dt;
                //Decimal v = dg.Rows.Cast<DataGridViewRow>()
                //.Sum(t => Convert.ToDecimal(t.Cells["AMOUNT"].Value));
                //return v;
                return Convert.ToDecimal(Math.Round(dt.Rows.Cast<DataRow>().Sum(r => r.Field<double>("AMOUNT")), 2));
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.ToString(), ":: Error ::");
            }
            return 0;
        }

        public Decimal GetAdjustmentInventoryValue(DateTime date)
        {
            Decimal value = 0;
            if (conn3.State == System.Data.ConnectionState.Closed) { conn3.Open(); }
            try
            {
                query = "select sum(DEBIT) - SUM(CREDIT) as [Value] from LEDGERS where COA_ID = 6565 and [DATE] <= '" + date + "'";
                SqlCommand cmd = new SqlCommand(query, conn3);
                cmd.CommandTimeout = 0;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    if (dr.Read())
                    {
                        value = Convert.ToDecimal(dr["Value"].ToString());
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                conn3.Close();
            }
            return value;
        }
        public void FocusField(TextBox txt)
        {
            txt.SelectAll();
        }
        public void getReceiptChq(string Id, DataGridView dg)
        {
            if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
            try
            {
                cmd = new SqlCommand(Queries.getReceiptChq(Id), conn);
                cmd.CommandTimeout = 0;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        dg.Rows.Add(dr["CHQ_ID"].ToString(), dr["DATE"].ToString(), dr["COA_NAME"].ToString(), dr["AMOUNT"].ToString(),
                        dr["BANK"].ToString(), dr["CHQ_NO"].ToString());
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                conn.Close();
            }
        }

        public static bool isNumber(string val)
        {
            try
            {
                int x = int.Parse(val);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string ConvertDatetime(DateTime dt)
        {
            return string.Format("{0:yyyy-MM-dd HH:mm:ss}", dt);
        }
        public static string DateFormat(DateTime dt)
        {
            return string.Format("{0:dd-MM-yyyy}", dt);
        }
        public void getReceiptChq(string Id, string chqNo, DataGridView dg)
        {
            if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
            try
            {
                cmd = new SqlCommand(Queries.getReceiptChqByNum(chqNo, Id), conn);
                cmd.CommandTimeout = 0;

                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        dg.Rows.Add(dr["CHQ_ID"].ToString(), dr["DATE"].ToString(), dr["COA_ID"].ToString(), dr["COA_NAME"].ToString(), dr["AMOUNT"].ToString(),
                        dr["BANK"].ToString(), dr["CHQ_NO"].ToString());
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                conn.Close();
            }
        }
        public decimal GetAccountBalance(int accountId)
        {
            decimal code = 0;
            try
            {
                query = @"IF (
                SELECT C.AN_ID 
                FROM COA A
                INNER JOIN CONTROL_ACCOUNT B ON A.CA_ID = B.CA_ID
                INNER JOIN ACCOUNT_NATURE C ON B.AN_ID = C.AN_ID
                WHERE A.COA_ID = '" + accountId + @"') IN (1,5)
                BEGIN
	                SELECT ROUND(isnull(CASE WHEN DR_CR = 'D' THEN OPEN_BAL ELSE -OPEN_BAL END,0)+isnull(
	                (SELECT SUM(DEBIT)-SUM(CREDIT) FROM LEDGERS WHERE COA_ID = '" + accountId + @"')
	                , 0),2) FROM COA WHERE COA_ID = '" + accountId + @"'
                END
                ELSE 
                BEGIN
	                SELECT ROUND(isnull(CASE WHEN DR_CR = 'D' THEN -OPEN_BAL ELSE OPEN_BAL END,0)+isnull(
	                (SELECT SUM(CREDIT)-SUM(DEBIT) FROM LEDGERS WHERE COA_ID = '" + accountId + @"')
	                , 0),2) FROM COA WHERE COA_ID = '" + accountId + @"'
                END";
                if (Classes.Helper.conn3.State == System.Data.ConnectionState.Closed) { Classes.Helper.conn3.Open(); }
                SqlCommand cmd = new SqlCommand(query, Classes.Helper.conn3);
                cmd.CommandTimeout = 0;
                code = Convert.ToDecimal(cmd.ExecuteScalar().ToString());
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Classes.Helper.conn3.Close();
            }
            return code;
        }

        public string GetProductN(int productId)
        {
            string code = "";
            try
            {
                query = "select PRODUCT_NAME from PRODUCT_MASTER where PM_ID = '" + productId + "'";
                if (Classes.Helper.conn.State == System.Data.ConnectionState.Closed) { Classes.Helper.conn.Open(); }
                cmd = new SqlCommand(query, Classes.Helper.conn);
                cmd.CommandTimeout = 0;
                code = cmd.ExecuteScalar().ToString();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Classes.Helper.conn.Close();
            }
            return code;
        }




        public string GetProductName(int productId, char itemType)
        {
            string code = "";
            try
            {
                if (itemType == 'P')
                {
                    query = @"select PRODUCT_NAME from PRODUCT_MASTER where PM_ID = '" + productId + @"'";
                }
                else {
                    query = @"select MATERIAL_NAME from MATERIALS where MATERIAL_ID = '" + productId + @"'";
                }

                if (Classes.Helper.conn.State == System.Data.ConnectionState.Closed) { Classes.Helper.conn.Open(); }
                cmd = new SqlCommand(query, Classes.Helper.conn);
                cmd.CommandTimeout = 0;
                code = cmd.ExecuteScalar().ToString();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Classes.Helper.conn.Close();
            }
            return code;
        }

        public string GetProductCode(int productId)
        {
            string code = "";
            try
            {
                query = "select PRODUCT_CODE from PRODUCT_MASTER where PM_ID = '" + productId + "'";
                if (Classes.Helper.conn.State == System.Data.ConnectionState.Closed) { Classes.Helper.conn.Open(); }
                cmd = new SqlCommand(query, Classes.Helper.conn);
                cmd.CommandTimeout = 0;
                code = cmd.ExecuteScalar().ToString();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Classes.Helper.conn.Close();
            }
            return code;
        }

        public string GetProductRate(int productId, string type)
        {
            string code = "";
            try
            {
                if (type.Equals("retail"))
                {
                    query = "select LIST_RATE from PRODUCT_MASTER where PM_ID = '" + productId + "'";
                }
                else {
                    query = "select NET_RATE from PRODUCT_MASTER where PM_ID = '" + productId + "'";
                }
                if (Classes.Helper.conn.State == System.Data.ConnectionState.Closed) { Classes.Helper.conn.Open(); }
                cmd = new SqlCommand(query, Classes.Helper.conn);
                cmd.CommandTimeout = 0;
                code = cmd.ExecuteScalar().ToString();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Classes.Helper.conn.Close();
            }
            return code;
        }
        public int GetProductMaterialId(int itemId)
        {
            int code = 0;
            try
            {
                query = "select MATERIAL_ID from PRODUCT_DETAILS where PM_ID = '" + itemId + "'";
                if (Classes.Helper.conn.State == System.Data.ConnectionState.Closed) { Classes.Helper.conn.Open(); }
                cmd = new SqlCommand(query, Classes.Helper.conn);
                cmd.CommandTimeout = 0;
                code = Int32.Parse(cmd.ExecuteScalar().ToString());
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Classes.Helper.conn.Close();
            }
            return code;
        }

        public int GenerateVoucherCode(string query)
        {
            int code = 0;
            try
            {
                if (Classes.Helper.conn.State == System.Data.ConnectionState.Closed) { Classes.Helper.conn.Open(); }
                cmd = new SqlCommand(query, Classes.Helper.conn);
                cmd.CommandTimeout = 0;
                code = Int32.Parse(cmd.ExecuteScalar().ToString());
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Classes.Helper.conn.Close();
            }
            return code;
        }

        public void CheckNumber(KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || e.KeyChar == '.' || Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Enter Only Digits", "error");
                //essageBox.Show("Only Numbers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        public void getPaymentChq(string id, DataGridView dg)
        {
            if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
            try
            {
                cmd = new SqlCommand(Queries.getPayChq(id), conn);
                cmd.CommandTimeout = 0;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        dg.Rows.Add(dr["DATE"].ToString(), dr["AMOUNT"].ToString(),
                        dr["BANK"].ToString(), dr["CHQ_NO"].ToString());
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                conn.Close();
            }
        }

        public double GetScalarAmount(string query)
        {
            double val = 0;
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                cmd = new SqlCommand(query, conn);
                cmd.CommandTimeout = 0;
                val = double.Parse((cmd.ExecuteScalar() ?? 0).ToString());
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString(), ":: Error ::", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
            return val;
        }

        public int getNo(string query)
        {
            int code = 0;
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                cmd = new SqlCommand(query, conn);
                cmd.CommandTimeout = 0;
                code = Int32.Parse((cmd.ExecuteScalar() ?? 0).ToString());
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString(), ":: Error ::", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
            return code;
        }
        //show message box
        public void GatePassSP(int programId)
        {
            if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
            try
            {
                cmd = new SqlCommand("dbo.[UPDATE_PRODUCTION]", conn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PROGRAM_ID", programId);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.ToString(), "Exception");
            }
            finally
            {
                conn.Close();
            }
        }

        //Database BackUp
        public void DatabaseBackUp()
        {
            if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
            try
            {
                cmd = new SqlCommand("dbo.[CREATE_BACKUP_MAAZ_OIL_D]", conn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                ShowMessageBox("Database BackUp Completed Successfully.", "Information");
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.ToString(), "Exception");
            }
            finally
            {
                conn.Close();
            }
        }

        //record search in grid
        public int record_search_grid(DataGridView dg, string value, int column_index)
        {
            foreach (DataGridViewRow rows in dg.Rows)
            {
                if (rows.Cells[column_index].Value.ToString().Equals(value))
                {
                    return 1;
                }
            }
            return 0;
        }

        public void ShowMessageBox(string message, string boxHeading)
        {
            MessageBox.Show(message, boxHeading, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //get material item ledger query
        public string GetMaterialItemLedgerQuery(DateTime date, string materialId, string refNo, string entryFrom,
            Decimal stockIn, Decimal stockOut, Decimal cost, Decimal saleAmount) {
            return @"INSERT INTO MATERIAL_ITEM_LEDGER ([DATE],MATERIAL_ID,REF_NO,ENTRY_FROM,STOCK_IN,STOCK_OUT,
                    COST_AMT,SALE_AMT,L_ID,CREATED_BY,CREATION_DATE,COMPANY_ID)
                    VALUES('" + date + "'," + materialId + "," + refNo + ",'" + entryFrom + "','" + stockIn + "','" + stockOut + @"',
                    '" + cost + "','" + saleAmount + "','1','" + userId + "',GETDATE(),'1')";
        }

        //get product item ledger query
        public string GetProductItemLedgerQuery(DateTime date, int productId, string refNo, string entryFrom,
            Decimal stockIn, Decimal stockOut, Decimal cost, Decimal saleAmount)
        {
            return @"INSERT INTO PRODUCT_ITEM_LEDGER ([DATE],PRODUCT_ID,REF_NO,ENTRY_FROM,STOCK_IN,STOCK_OUT,
            COST_AMT,SALE_AMT,L_ID,CREATED_BY,CREATION_DATE,COMPANY_ID) 
            VALUES ('" + date + "','" + productId + "','" + refNo + "','" + entryFrom + "','" + stockIn + "','" + stockOut + @"',
                    '" + cost + "','" + saleAmount + "','1','" + userId + "',GETDATE(),'1')";
        }

        //get account ledger query
        public string GetAccountLedgerQuery(DateTime date, int coaId, string refId, string entryof, string folio,
        Decimal debit, Decimal credit, string description)
        {
            return @"INSERT INTO LEDGER ([DATE],COA_ID,REF_ID,ENTRY_OF,FOLIO,DEBIT,CREDIT,DESCRIPTIONS,
            CREATED_BY,CREATION_DATE,COMPANY_ID)
            VALUES('" + date + "','" + coaId + "','" + refId + "','" + entryof + "','" + folio + "','" + debit + "','" + credit + @"',
                    '" + description + "','" + userId + "',GETDATE(),'1')";
        }

        //Load Material Unit
        public void LoadMaterialUnit(int materialId, TextBox txtUnit) {
            query = @"select b.UNIT_NAME 
            from MATERIALS a,UNITS b 
            where a.UNIT_ID = b.UNIT_ID and a.MATERIAL_ID = '" + materialId + "'";

            if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
            try
            {
                cmd = new SqlCommand(query, conn);
                cmd.CommandTimeout = 0;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    if (dr.Read())
                    {
                        txtUnit.Text = dr[0].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                conn.Close();
            }
        }

        //check balance avialable
        public string check_balance_avilable(string coa_id, string amount)
        {
            string query = "SELECT isnull(OPEN_BAL,0)+isnull((SELECT SUM(DEBIT)-SUM(CREDIT) FROM LEDGERS WHERE COA_ID = '" + coa_id + "'), 0) FROM COA WHERE COA_ID = '" + coa_id + "'";
            if (amount.Equals(""))
                amount = "0";
            if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
            try
            {
                cmd = new SqlCommand(query, conn);

                cmd.CommandTimeout = 0;
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    if (float.Parse(dr[0].ToString()) < float.Parse(amount))
                    {
                        return dr[0].ToString();
                    }
                    else
                    {
                        return dr[0].ToString();
                    }
                }
                else
                    return "0";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return "0";
            }
            finally
            {
                conn.Close();
            }
        }
        string str;
        public string getPur_Invoice_Bal(string pur_Id, float amount)
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                str = "select (TOTAL - REC_AMT) from PURCHASES WHERE P_ID = '" + pur_Id + "'";
                cmd = new System.Data.SqlClient.SqlCommand(str, conn);
                if ((float.Parse(cmd.ExecuteScalar().ToString()) - amount) <= 0)
                {
                    conn.Close();
                    return "The amount is Above than Invoice Total.";
                }
                else
                {
                    conn.Close();
                    return "OK";
                }

            }
            catch (Exception ex)
            {
                conn.Close();
                return ex.Message + Environment.NewLine + ex.StackTrace;

            }
        }

        //load All invoice
        public void load_all_invoices(ComboBox cmbInvoices, string coa_id)
        {
            query = @"SELECT '0' AS [id],'--SELECT INVOICE--' AS [name]
            UNION ALL
            select P_ID,P_CODE from PURCHASES WHERE COA_ID = '" + coa_id + "'";
            LoadComboData(cmbInvoices, query);
        }

        public void invoice_detail(string vou_code, ComboBox cmbInvoices, RadioButton rdbInvoices, RadioButton rdbOther)
        {
            string query = "SELECT INVOICE_NO FROM INVOICES_DETAILS WHERE VOUCHER_ID = '" + vou_code + "' AND PAY_OF = 'PURCHASES'";
            if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
            try
            {
                cmd = new SqlCommand(query, conn);
                cmd.CommandTimeout = 0;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    if (dr.Read())
                    {
                        cmbInvoices.Enabled = true;
                        cmbInvoices.SelectedValue = dr[0].ToString();
                        rdbInvoices.Checked = true;
                    }
                }
                else
                {
                    cmbInvoices.Enabled = false;
                    cmbInvoices.SelectedIndex = 0;
                    rdbOther.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                conn.Close();
            }
        }

        //text field leave
        public void textField_leave(TextBox txt)
        {
            txt.BackColor = Color.FromArgb(255, 255, 255);
        }

        //get so muand rate
        public string GetSOMuandRate(int soId, char soType)
        {
            string muandRate = "";
            if (soType == 'D') {
                query = "select ROUND(RATE * 37.324,2) from SALES_ORDER_DIRECT WHERE SOD_ID = '" + soId + "'";
            }
            else if (soType == 'P')
            {
                query = "select MUAND_RATE from SALES_ORDER_PRODUCT_MASTER WHERE SOPM_ID = '" + soId + "'";
            }
            else
            {
                query = "select MUAND_RATE from SO_MATERIAL_P_MASTER WHERE MPM_ID = '" + soId + "'";
            }
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandTimeout = 0;
                object v = cmd.ExecuteScalar();
                if (v != null)
                {
                    muandRate = v.ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                conn.Close();
            }
            return muandRate;
        }

        //get program muand rate
        public string GetProgramMuandRate(int programId)
        {
            string muandRate = "";

            query = @"DECLARE @SO_TYPE CHAR
                SET @SO_TYPE = (SELECT SO_TYPE FROM SALES_PROGRAM_MASTER WHERE SPM_ID = '" + programId + @"')
                IF(@SO_TYPE = 'D')
                BEGIN
                    select ROUND(b.RATE * 37.324,2) from SALES_PROGRAM_MASTER a
                    inner join SALES_ORDER_DIRECT b on a.SOD_ID = b.SOD_ID
                    where a.SPM_ID = '" + programId + @"'
                END
                ELSE IF(@SO_TYPE = 'P')
                BEGIN
                    select b.MUAND_RATE from SALES_PROGRAM_MASTER a
                    inner join SALES_ORDER_PRODUCT_MASTER b on a.SOD_ID = b.SOPM_ID
                    where a.SPM_ID = '" + programId + @"'
                END
                ELSE
                BEGIN
                    select b.MUAND_RATE from SALES_PROGRAM_MASTER a
                    inner join SO_MATERIAL_P_MASTER b on a.SOD_ID = b.MPM_ID
                    where a.SPM_ID = '" + programId + @"'
                END";

            try
            {
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandTimeout = 0;
                object v = cmd.ExecuteScalar();
                if (v != null)
                {
                    muandRate = v.ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                conn.Close();
            }
            return muandRate;
        }

        //get customer credit d ays
        public int GetCustomerCreditDays(int customerId)
        {
            int creditDays = 0;
            query = "SELECT CREDIT_DAYS FROM CUSTOMER_PROFILE WHERE COA_ID = '" + customerId + "'";
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandTimeout = 0;
                object v = cmd.ExecuteScalar();
                if (v != null)
                {
                    creditDays = Int32.Parse(v.ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                conn.Close();
            }
            return creditDays;
        }

        //get SO Muand Value
        public int GetSOMuandValue(int soId)
        {
            int value = 0;
            query = @"select b.TOTAL_KGS from SALES_PROGRAM_MASTER a inner join SALES_ORDER_DIRECT b on a.SOD_ID = b.SOD_ID where a.SPM_ID = '" + soId + "'";
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandTimeout = 0;
                object v = cmd.ExecuteScalar();
                if (v != null) {
                    value = Int32.Parse(v.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                conn.Close();
            }
            return value;
        }

        //generate voucher code 
        public int generate_voucher_code(string query)
        {
            int code = 0;
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandTimeout = 0;
                object v = cmd.ExecuteScalar();
                if (v != null)
                {
                    code = Int32.Parse(v.ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                conn.Close();
            }
            return code;
        }

        //select all in text field focus
        public void select_all_text(TextBox txt)
        {
            txt.SelectAll();
        }




        //load grid by rows
        public void LoadProductDetailGrid(DataGridView dg, string gridquery)
        {
            try
            {
                dg.Rows.Clear();
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                cmd = new SqlCommand(gridquery, conn);
                cmd.CommandTimeout = 0;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dg.Rows.Add(dr["PRODUCT_ID"].ToString(), dr["PRODUCT_NAME"].ToString(), dr["QTY"].ToString());
                }

                dg.ClearSelection();
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.ToString(), "Exception");
            }
            finally
            {
                conn.Close();
            }
        }

        public void LoadCoaGrid(DataGridView dg, string gridquery)
        {
            try
            {
                //dg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                //dg.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                cmd = new SqlCommand(gridquery, conn);
                cmd.CommandTimeout = 0;
                adp = new SqlDataAdapter();
                adp.SelectCommand = cmd;
                ds = new System.Data.DataSet();
                adp.Fill(ds, "data");
                dg.Invoke((MethodInvoker)delegate
                {
                    dg.DataSource = ds.Tables["data"];
                });
                dg.ClearSelection();

            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.ToString(), "Exception");
            }
            finally
            {
                conn.Close();
            }
        }

        //load grid
        public void LoadGrid(DataGridView dg, string gridquery)
        {
            try
            {
                dg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                dg.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                cmd = new SqlCommand(gridquery, conn);
                cmd.CommandTimeout = 0;
                adp = new SqlDataAdapter();
                adp.SelectCommand = cmd;
                ds = new System.Data.DataSet();
                adp.Fill(ds, "data");
                dg.Invoke((MethodInvoker)delegate
                {
                    dg.DataSource = ds.Tables["data"];
                });
                dg.ClearSelection();

            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.ToString(), "Exception");
            }
            finally
            {
                conn.Close();
            }
        }

        public void LoadPaymentChqGrid(DataGridView dg, string gridquery)
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                cmd = new SqlCommand(gridquery, conn);
                cmd.CommandTimeout = 0;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    //dg.Rows.Add("", dtpPayChq.Value, cmbSupplierPay.SelectedValue.ToString(), cmbSupplierPay.Text, txtPayChqAmount.Text, cmbPaymentBank.Text, db.AvoidInjection(txtChqNoPay.Text));
                    dg.Rows.Add(dr[0].ToString(), dr["CHQ DATE"].ToString(), dr["CREDIT_AC"].ToString(), dr["NAME"].ToString(), dr["AMOUNT"].ToString(), dr["BANK"].ToString(), dr["CHQ NO"].ToString());

                }

                dg.ClearSelection();
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.ToString(), "Exception");
            }
            finally
            {
                conn.Close();
            }
        }

        public class MethodItem
        {
            public string Name { get; set; }
            public SergeUtils.StringMatchingMethod Value { get; set; }
        }

        //load data in combo box
        public void LoadEasyComboData(SergeUtils.EasyCompletionComboBox cmb, string query)
        {
            SqlConnection thisConn = new SqlConnection();
            if (cmb.Name != "cmbSubAccount")
            {
                thisConn = Classes.Helper.conn;
            }
            else
            {
                thisConn = Classes.Helper.conn2;
            }
            try
            {
                if (thisConn.State == System.Data.ConnectionState.Closed) { if (thisConn.State == System.Data.ConnectionState.Closed) { thisConn.Open(); } }

                cmd = new SqlCommand(query, thisConn);
                cmd.CommandTimeout = 0;
                adp = new SqlDataAdapter();
                adp.SelectCommand = cmd;
                ds = new System.Data.DataSet();
                adp.Fill(ds, "data");
                cmb.DisplayMember = "name";
                cmb.ValueMember = "id";
                cmb.DataSource = ds.Tables["data"];

                cmb.MatchingMethod = SergeUtils.StringMatchingMethod.UseRegexs;

                //Font = new Font("Segoe UI", 9.0f);
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.ToString(), "Exception");
            }
            finally
            {
                thisConn.Close();

            }
        }



        public void LoadTextBoxData(TextBox txtQTY, string query, int productCode)
        {
            SqlConnection thisConn;

            // Decide which connection to use based on the context
            thisConn = (txtQTY.Name != "txtSubAccount") ? Classes.Helper.conn : Classes.Helper.conn2;

            try
            {
                if (thisConn.State == System.Data.ConnectionState.Closed)
                {
                    thisConn.Open();
                }

                using (var cmd = new SqlCommand(query, thisConn))
                {
                    // Use a parameterized query to prevent SQL injection
                    cmd.Parameters.AddWithValue("@ProductCode", productCode);
                    cmd.CommandTimeout = 0;

                    // Execute the query and retrieve the quantity
                    var result = cmd.ExecuteScalar();

                    // Set the TextBox value based on the result
                    if (result != null)
                    {
                        txtQTY.Text = result.ToString();
                    }
                    else
                    {
                        txtQTY.Text = "0"; // or set it to empty or any default value you prefer
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.ToString(), "Exception"); // Handle the error appropriately
            }
            finally
            {
                thisConn.Close(); // Ensure the connection is closed
            }
        }

        //load data in combo box
        public void LoadComboData(ComboBox cmb, string query)
        {
            SqlConnection thisConn = new SqlConnection();
            if (cmb.Name != "cmbSubAccount")
            {
                thisConn = Classes.Helper.conn;
            }
            else
            {
                thisConn = Classes.Helper.conn2;
            }
            try
            {
                if (thisConn.State == System.Data.ConnectionState.Closed) { if (thisConn.State == System.Data.ConnectionState.Closed) { thisConn.Open(); } }

                cmd = new SqlCommand(query, thisConn);
                cmd.CommandTimeout = 0;
                adp = new SqlDataAdapter();
                adp.SelectCommand = cmd;
                ds = new System.Data.DataSet();
                adp.Fill(ds, "data");
                cmb.DisplayMember = "name";
                cmb.ValueMember = "id";
                cmb.DataSource = ds.Tables["data"];

                //cmb.MatchingMethod = StringMatchingMethod.NoWildcards;

                //Font = new Font("Segoe UI", 9.0f);
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.ToString(), "Exception");
            }
            finally
            {
                thisConn.Close();

            }
        }

        //insert, update or delete in database
        public int InsertUpdateDelete(String query)
        {
            if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
            try
            {
                cmd = new SqlCommand(query, conn);
                cmd.CommandTimeout = 0;
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.ToString(), "Exception");
                return 0;
            }
            finally
            {
                conn.Close();
            }
        }

        public int InsertUpdateDeleteAA(String query)
        {
            if (conn2.State == System.Data.ConnectionState.Closed) { conn2.Open(); }
            try
            {
                cmd = new SqlCommand(query, conn2);
                cmd.CommandTimeout = 0;
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.ToString(), "Exception");
                return 0;
            }
            finally
            {
                conn2.Close();
            }
        }
        
        //remove injection query character
        public string AvoidInjection(string txt)
        {
            return txt.Replace("'", "''").Trim();
        }

        //check mobile number lenght
        public void MobileNumberLenghtCheck(TextBox txt)
        {
            if (txt.Text.Count() < 11)
            {
                MessageBox.Show("Contact Number is not valid, please enter a correct number.", "Invalid Number", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt.Focus();
                txt.SelectAll();
            }
        }

        //to check string contains only digits
        public int AllowNumbers(KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || e.KeyChar == '.' || Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                return 0;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Character are not allowed, please enter only numbers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return 1;
            }
        }

        //print serial number in grid 
        public void GridRowPostPaint(DataGridViewRowPostPaintEventArgs e, DataGridView grid)
        {
            grid.TopLeftHeaderCell.Value = "S.NO.";
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,

                LineAlignment = StringAlignment.Center
            };
            //get the size of the string
            Size textSize = TextRenderer.MeasureText(rowIdx, grid.Font);
            //if header width lower then string width then resize
            if (grid.RowHeadersWidth < textSize.Width + 40)
            {
                grid.RowHeadersWidth = textSize.Width + 40;
            }
            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, grid.Font, SystemBrushes.ControlText, headerBounds, centerFormat);

        }

        //check fields are not blank
        public void CheckBlankField(TextBox txt)
        {
            if (txt.Text.Equals(""))
            {
                MessageBox.Show("Field is empty.");
                txt.Focus();
            }
        }

        //check fields is blank than print zero
        public void BlankSetZero(TextBox txt)
        {
            if (txt.Text.Trim().Equals(""))
            {
                txt.Text = "0";
            }
        }

        public string getSale_Invoice_Bal(string sale_Id, float amount)
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                str = "select (TOTAL - REC_AMT) from SALES_M WHERE SM_ID = '" + sale_Id + "'";
                cmd = new System.Data.SqlClient.SqlCommand(str, conn);
                if ((float.Parse(cmd.ExecuteScalar().ToString()) - amount) <= 0)
                {
                    conn.Close();
                    return "The amount is Above than Invoice Total.";
                }
                else
                {
                    conn.Close();
                    return "OK";
                }

            }
            catch (Exception ex)
            {
                conn.Close();
                return ex.Message + Environment.NewLine + ex.StackTrace;

            }
        }

        //check if name already exixts
        public int CheckNameExists(DataGridView grid, string value, int columnNumber)
        {
            foreach (DataGridViewRow rows in grid.Rows)
            {
                if (rows.Cells[columnNumber].Value.ToString().Equals(value))
                {
                    return 1;
                }
            }
            return 0;
        }

        //load purchases invoice
        public void load_purchases_invoices(ComboBox cmbInvoices, string coa_id)
        {
            query = @"SELECT '0' AS [id],'--SELECT INVOICE--' AS [name]
            UNION ALL
            select P_ID,P_CODE from PURCHASES WHERE (TOTAL - REC_AMT) <> 0 AND COA_ID = '" + coa_id + "'";
            LoadComboData(cmbInvoices, query);
        }

        //load sale invoice
        public void load_sale_invoices(ComboBox cmbInvoices, string coa_id)
        {
            query = @"SELECT '0' AS [id],'--SELECT INVOICE--' AS [name]
            UNION ALL
            select SM_ID,INV_CODE from SALES_M WHERE (TOTAL - REC_AMT) <> 0 AND COA_ID = '" + coa_id + "'";
            LoadComboData(cmbInvoices, query);
        }

        public void LoadPODetails(string query, TextBox txtMaterialType, TextBox txtMaterial, TextBox txtKorangiWeight, TextBox txtUnit,
            TextBox txtKgRate, TextBox txtDescript, TextBox txtTotal, TextBox txtCreditDays, TextBox txtMuandRate, TextBox txtOrderWeight,
            TextBox txtBalanceWeight, TextBox txtPODate, TextBox txtMuandValue) {
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                cmd = new SqlCommand(query, conn);
                cmd.CommandTimeout = 0;
                dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    if (dr.Read())
                    {
                        //txtNetWeight.Text = dr[0].ToString();
                        txtBalanceWeight.Text = dr["WEIGHT"].ToString();
                        txtMaterial.Text = dr["MATERIAL_NAME"].ToString();
                        txtMaterialType.Text = dr["M_TYPE_NAME"].ToString();
                        txtUnit.Text = dr["UNIT_NAME"].ToString();
                        txtKgRate.Text = dr["KG_RATE"].ToString();
                        txtMuandRate.Text = dr["MUAND_RATE"].ToString();
                        txtMuandValue.Text = dr["MUAND_VALUE"].ToString();

                        //txtTotal.Text = dr[6].ToString();
                        txtCreditDays.Text = dr["CREDIT_DAYS"].ToString();
                        txtDescript.Text = dr["DESCRIPTION"].ToString();
                        txtOrderWeight.Text = dr["ORDERED WEIGHT"].ToString();
                        txtPODate.Text = dr["DATE"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.ToString(), ":: Error ::");
            }
            finally
            {
                conn.Close();
            }
        }

        //load All sale invoice
        public void load_all_sale_invoices(ComboBox cmbInvoices, string coa_id)
        {
            query = @"SELECT '0' AS [id],'--SELECT INVOICE--' AS [name]
            UNION ALL
            select SM_ID,INV_CODE from SALES_M WHERE COA_ID = '" + coa_id + "'";
            LoadComboData(cmbInvoices, query);
        }

        //load All purchases invoice
        public void load_all_purchases_invoices(ComboBox cmbInvoices, string coa_id)
        {
            query = @"SELECT '0' AS [id],'--SELECT INVOICE--' AS [name]
            UNION ALL
            select P_ID,P_CODE from PURCHASES WHERE COA_ID = '" + coa_id + "'";
            LoadComboData(cmbInvoices, query);
        }

        //Get Stock Balance
        public int GetStockBalance(string productId)
        {
            try
            {
                query = @"SELECT 
                B.OPENING_QTY
	        +
            ISNULL((
	            SELECT SUM(QTY) 
	            FROM SALE_RETURN_MASTER X
	            INNER JOIN SALE_RETURN_DETAIL Y ON X.SALE_RETURN_MASTER_ID = Y.SALE_RETURN_MASTER_ID
	            INNER JOIN PRODUCT_MASTER Z ON Y.ITEM_ID = Z.PM_ID
	            WHERE X.[DATE] <= GETDATE() AND Y.ITEM_ID = B.PM_ID AND Y.ITEM_TYPE = 'P'
            ),0) +
	        ISNULL((
		        SELECT SUM(QTY) 
		        FROM PRODUCTION_MASTER X
		        INNER JOIN PRODUCTION_DETAIL Y ON X.ID = Y.PRODUCTION_MASTER_ID
		        INNER JOIN PRODUCT_MASTER Z ON Y.PRODUCT_MASTER_ID = Z.PM_ID
		        WHERE X.[DATE] <= GETDATE() AND Y.PRODUCT_MASTER_ID = B.PM_ID 
	        ),0) +
                ISNULL((
	                SELECT SUM(X.QTY) 
	                FROM INVENTORY_ADJUSTMENTS X
	                INNER JOIN PRODUCT_MASTER Z ON X.MATERIAL_ID = Z.PM_ID
	                WHERE X.[DATE] <= GETDATE() AND X.MATERIAL_ID = B.PM_ID 
	                AND X.ADD_LESS = 'A'
                ),0)
            -   (
                ISNULL((
	                SELECT SUM(QTY) 
	                FROM SALE_MASTER X
	                INNER JOIN SALE_DETAIL Y ON X.SALE_MASTER_ID = Y.SALE_MASTER_ID
	                INNER JOIN PRODUCT_MASTER Z ON Y.ITEM_ID = Z.PM_ID
	                WHERE X.[DATE] <= GETDATE() AND Y.ITEM_ID = B.PM_ID AND Y.ITEM_TYPE = 'P'
                ),0)
                +
                ISNULL((
	                SELECT SUM(X.QTY) 
	                FROM INVENTORY_ADJUSTMENTS X
	                INNER JOIN PRODUCT_MASTER Z ON X.MATERIAL_ID = Z.PM_ID
	                WHERE X.[DATE] <= GETDATE() AND X.MATERIAL_ID = B.PM_ID 
	                AND X.ADD_LESS = 'D'
                ),0)
                )AS [BALANCE]
                FROM PRODUCT_MASTER B
                INNER JOIN PRODUCT_CATEGORY C ON C.P_CATEGORY_ID = B.BRAND_ID  WHERE B.PM_ID = '" + productId + "'";

                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                cmd = new SqlCommand(query, conn);
                cmd.CommandTimeout = 0;
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.ToString(), "Exception");
            }
            finally
            {
                conn.Close();
            }
            return 0;
        }

        //Get Material Balance
        public int GetMaterialBalance(string materialId)
        {
            try
            {
                query = @"SELECT ISNULL(SUM(STOCK_IN),0) - ISNULL(SUM(STOCK_OUT),0)
                FROM MATERIAL_ITEM_LEDGER
                WHERE MATERIAL_ID = '" + materialId + "'";

                query = @"	SELECT 
	            (SUM(D.OPENING_QTY) +
	            ISNULL(
		            (SELECT SUM(Y.QTY) AS [QTY]
		            FROM PURCHASE_MASTER X
		            INNER JOIN PURCHASE_DETAIL Y ON X.PURCHASE_MASTER_ID = Y.PURCHASE_MASTER_ID
		            INNER JOIN MATERIALS V ON V.MATERIAL_ID = Y.MATERIAL_ID
		            WHERE X.[DATE] <= GETDATE() AND Y.MATERIAL_ID = D.MATERIAL_ID)
	            ,0) +
	            ISNULL((
	            SELECT SUM(QTY) 
	            FROM SALE_RETURN_MASTER X
	            INNER JOIN SALE_RETURN_DETAIL Y ON X.SALE_RETURN_MASTER_ID = Y.SALE_RETURN_MASTER_ID
	            INNER JOIN PRODUCT_MASTER Z ON Y.ITEM_ID = Z.PM_ID
	            WHERE X.[DATE] <= GETDATE() AND Y.ITEM_ID = D.MATERIAL_ID AND Y.ITEM_TYPE = 'R'
	            ),0) +
	            ISNULL((
		            SELECT SUM(X.QTY) 
		            FROM INVENTORY_ADJUSTMENTS_RAW X
		            INNER JOIN MATERIALS Z ON X.MATERIAL_ID = Z.MATERIAL_ID
		            WHERE X.[DATE] <= GETDATE() AND X.MATERIAL_ID = D.MATERIAL_ID
		            AND X.ADD_LESS = 'A'
	            ),0)) 
	            -
	            (ISNULL((
			            SELECT SUM(O.QTY) FROM (
			            SELECT ISNULL(SUM(W.WEIGHT * Y.QTY),0) AS [QTY]
			            FROM PRODUCTION_MASTER X
			            INNER JOIN PRODUCTION_DETAIL Y ON X.ID = Y.PRODUCTION_MASTER_ID
			            INNER JOIN PRODUCT_MASTER Z ON Y.PRODUCT_MASTER_ID = Z.PM_ID
			            INNER JOIN PRODUCT_DETAILS W ON W.PM_ID = Z.PM_ID
			            INNER JOIN MATERIALS V ON V.MATERIAL_ID = W.MATERIAL_ID
			            WHERE X.[DATE] <= GETDATE() AND D.MATERIAL_ID = V.MATERIAL_ID

			            UNION ALL

			            SELECT ISNULL(SUM(Y.QTY),0)
			            FROM SALE_MASTER X
			            INNER JOIN SALE_DETAIL Y ON X.SALE_MASTER_ID = Y.SALE_MASTER_ID
			            INNER JOIN MATERIALS V ON V.MATERIAL_ID = Y.ITEM_ID
			            WHERE X.[DATE] <= GETDATE() AND D.MATERIAL_ID = V.MATERIAL_ID  AND Y.ITEM_TYPE = 'R'
		            ) AS O
	            ),0) +
	            ISNULL((
		            SELECT SUM(X.QTY) 
		            FROM INVENTORY_ADJUSTMENTS_RAW X
		            INNER JOIN MATERIALS Z ON X.MATERIAL_ID = Z.MATERIAL_ID
		            WHERE X.[DATE] <= GETDATE() AND X.MATERIAL_ID = D.MATERIAL_ID
		            AND X.ADD_LESS = 'D'
	            ),0)) AS [BALANCE]
	            FROM MATERIALS D  
	            WHERE D.MATERIAL_ID = '" + materialId + @"'
                GROUP BY D.MATERIAL_NAME,D.MATERIAL_ID";

                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                cmd = new SqlCommand(query, conn);
                cmd.CommandTimeout = 0;
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.ToString(), "Exception");
            }
            finally
            {
                conn.Close();
            }
            return 0;
        }

        //Get GetMaterialFIFORate
        public decimal GetMaterialFIFORate(int materialId)
        {
            try
            {
                query = @"IF('" + materialId + @"' = 5005)
                BEGIN
	                SELECT TOP 1 B.KG_RATE
	                FROM PURCHASES A
	                INNER JOIN PURCHASES_ORDER B ON A.PO_ID = B.PO_ID
	                WHERE B.MATERIAL_ID = '" + materialId + @"'
	                ORDER BY A.PI_ID DESC
                END
                ELSE
                BEGIN
	                SELECT TOP 1 B.MUAND_RATE
	                FROM PURCHASES A
	                INNER JOIN PURCHASES_ORDER B ON A.PO_ID = B.PO_ID
	                WHERE B.MATERIAL_ID = '" + materialId + @"'
	                ORDER BY A.PI_ID DESC
                END";
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                cmd = new SqlCommand(query, conn);
                cmd.CommandTimeout = 0;
                return Convert.ToDecimal(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.ToString(), "Exception");
            }
            finally
            {
                conn.Close();
            }
            return 0;
        }

        //load invoice
        public void load_invoices(ComboBox cmbInvoices, string coa_id)
        {
            query = @"SELECT '0' AS [id],'--SELECT INVOICE--' AS [name]
            UNION ALL
            select P_ID,P_CODE from PURCHASES WHERE (TOTAL - REC_AMT) <> 0 AND COA_ID = '" + coa_id + "'";
            LoadComboData(cmbInvoices, query);
        }

        //Combo Box text update
        public void CmbTextUpdate(ComboBox cmb)
        {
            return;
            ///Stop the code due new combo box update
            //int index = cmb.FindString(cmb.Text);
            //if (index < 0)
            //{
            //    MessageBox.Show("Invalid Record");
            //    cmb.Focus();
            //    return;
            //}
        }

        //*****************Account Group methods************************//
        //load group grid
        public void load_group_grid(DataGridView dg)
        {
            query = @"SELECT A.AN_ID AS [NATURE_ID],B.AN_NAME AS [NATURE],A.PARENT_ID AS [PARENT_ID],C.AG_NAME AS [PARENT ACCOUNT],A.AG_CODE AS [GROUP_ID],A.AG_NAME AS [GROUP_NAME],A.LEVL AS [LEVEL]
        FROM ACCOUNT_GROUP A,ACCOUNT_NATURE B,ACCOUNT_GROUP C
        WHERE A.AN_ID = B.AN_ID AND A.PARENT_ID = C.AG_CODE";
            LoadGrid(dg, query);
        }

        //grid search 
        public void AccountGroupGridSearching(TextBox txtSEARCH, DataGridView grdSEARCH)
        {
            (grdSEARCH.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
            [" + grdSEARCH.Columns[1].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
              + grdSEARCH.Columns[2].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
              + grdSEARCH.Columns[3].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
              + grdSEARCH.Columns[4].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
              + grdSEARCH.Columns[5].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%'");
            grdSEARCH.ClearSelection();
        }

        //load account nature combo box
        public void load_account_nature(ComboBox cmbAccountNature)
        {
            query = @"SELECT '0' AS [id],'--SELECT ACCOUNT NATURE--' AS [name]
            UNION
            SELECT AN_ID AS [id],AN_NAME AS [name] FROM ACCOUNT_NATURE";
            LoadComboData(cmbAccountNature, query);
        }

        //load group account combo box
        public void load_group_account(ComboBox cmbGroupAccount)
        {
            query = @"SELECT '0' AS [id],'--SELECT ACCOUNT GROUP--' AS [name]
            UNION
            SELECT AG_CODE AS [id],AG_NAME AS [name] FROM ACCOUNT_GROUP";
            LoadComboData(cmbGroupAccount, query);
        }

        //save group record in database
        public int save_group(string saveQuery)
        {
            return InsertUpdateDelete(saveQuery);
        }

        //get account level
        public int get_account_level(string group_id, DataGridView dg)
        {
            int i = 0;
            foreach (DataGridViewRow rows in dg.Rows)
            {
                if (rows.Cells[4].Value.ToString().Equals(group_id))
                {
                    i = Int32.Parse(rows.Cells[6].Value.ToString());
                }
            }
            return i;
        }

        //check if name already exixts
        public int check_name_exists(DataGridView dg, string value, int cellNo)
        {
            foreach (DataGridViewRow rows in dg.Rows)
            {
                if (rows.Cells[cellNo].Value.ToString().Equals(value))
                {
                    return 1;
                }
            }
            return 0;
        }

        //*****************Chart Of Account methods************************//
        TreeNode parentNode = null;
        TreeNode childNode;

        /*  public void LoadTree(TreeView tree)
          {
              tree.Nodes.Clear();
              query = "select ag_code,ag_name from account_group where ag_code in ('01','02','03','04','05')";
              adp = new SqlDataAdapter(query, conn);
              dt = new DataTable();
              if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
              adp.Fill(dt);
              foreach (DataRow dr in dt.Rows)
              {
                  parentNode = tree.Nodes.Add(dr[0].ToString(), dr[1].ToString());
                  PopulateTreeView(dr[0].ToString(), parentNode, tree);
              }
              tree.ExpandAll();
              conn.Close();
          }

          private void PopulateTreeView(string parentId, TreeNode parentNode, TreeView tree)
          {
              query = "select AG_CODE,AG_NAME from account_group WHERE PARENT_ID='" + parentId + "' AND AG_CODE <> '" + parentId + "'";
              adp = new SqlDataAdapter(query, conn1);
              dt = new DataTable();
              adp.Fill(dt);
              if (dt.Rows.Count > 0)
              {
                  foreach (DataRow dr in dt.Rows)
                  {
                      if (parentNode == null)
                          childNode = tree.Nodes.Add(dr[0].ToString(), dr[1].ToString());
                      else
                          childNode = parentNode.Nodes.Add(dr[0].ToString(), dr[1].ToString());

                      PopulateTreeView(dr[0].ToString(), childNode, tree);
                  }
              }
              else
              {
                  PopulateChildTreeView(parentId, parentNode, tree);
              }

          }

          private void PopulateChildTreeView(string parentId, TreeNode parentNode, TreeView tree)
          {
              query = @"select A.COA_CODE,A.COA_NAME from coa A, account_group B where A.AG_ID = B.AG_ID AND B.AG_CODE = '" + parentId + "'";
              adp = new SqlDataAdapter(query, conn1);
              dt = new DataTable();
              if (dt.Rows.Count <= 0) {
                  return;
              }
              adp.Fill(dt);
              TreeNode childNode;
              if (dt.Rows.Count > 0)
              {
                  foreach (DataRow dr in dt.Rows)
                  {
                      if (parentNode == null)
                          childNode = tree.Nodes.Add(dr[0].ToString(), dr[1].ToString());
                      else
                          childNode = parentNode.Nodes.Add(dr[0].ToString(), dr[1].ToString());

                      PopulateChildTreeView(dr[0].ToString(), childNode, tree);
                  }
              }
          } */

        public string GetAccountRateType(string accountId)
        {
            string accountName = "";
            query = "SELECT rateType FROM COA WHERE COA_ID = '" + accountId + "'";
            try
            {
                if (conn1.State == System.Data.ConnectionState.Closed) { conn1.Open(); }
                cmd = new SqlCommand(query, conn1);
                cmd.CommandTimeout = 0;
                object v = cmd.ExecuteScalar();
                if (v != null)
                {
                    accountName = v.ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), ":: Error ::", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn1.Close();
            }
            return accountName;
        }

        //load group grid
        public void LoadCoaGrid(DataGridView dg)
        {
            query = @"SELECT A.COA_ID AS [ID],C.CA_ID,C.CA_NAME AS [CONTROL ACCOUNT],
                A.AG_ID AS [GP_ID],B.AG_NAME AS [GROUP NAME],
                A.COA_NAME AS [ACCOUNT NAME],
                A.OPEN_BAL AS [OPENING BALANCE],
                CASE WHEN A.DR_CR = 'D' THEN 'DEBIT' ELSE 'CREDIT' END AS [DEBIT CREDIT],
                CASE WHEN A.STAT = 0 THEN 'ACTIVE' ELSE 'DE-ACTIVE' END AS [STATUS],
                A.MOBILE,A.EMAIL, A.[ADDRESS],A.CREDIT_DAYS,
                D.CITY_NAME,E.AREA_NAME
                FROM COA A
                INNER JOIN ACCOUNT_GROUP B ON A.AG_ID = B.AG_ID
                INNER JOIN CONTROL_ACCOUNT C ON A.CA_ID = C.CA_ID
                INNER JOIN CITY D ON A.CITY_ID = D.CITY_ID
                INNER JOIN AREA E ON A.AREA_ID = E.AREA_ID
                ORDER BY [ACCOUNT NAME]";
            LoadGrid(dg, query);

        }

        //grid search 
        public void CoaGridSearch(TextBox txtSEARCH, DataGridView grdSEARCH)
        {
            (grdSEARCH.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
            [" + grdSEARCH.Columns["CONTROL ACCOUNT"].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
               + grdSEARCH.Columns["ACCOUNT NAME"].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR["
               + grdSEARCH.Columns["EMAIL"].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR["
              + grdSEARCH.Columns["MOBILE"].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%'");
            grdSEARCH.ClearSelection();
        }
        public void AdjustmentSearch(TextBox txtSEARCH, DataGridView grdSEARCH)
        {
            (grdSEARCH.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
            [" + grdSEARCH.Columns["MATERIAL"].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
               + grdSEARCH.Columns["INCREASE / DECREASE"].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%'");
            grdSEARCH.ClearSelection();
        }
        //load control account combo box
        public void LoadControlAccount(ComboBox cmbControlAccount)
        {
            query = @"SELECT '0' AS [id],'--SELECT CONTROL ACCOUNT--' AS [name]
            UNION
            SELECT CA_ID AS [id],CA_NAME AS [name] FROM CONTROL_ACCOUNT WHERE CA_ID NOT IN (4,18,12,17,8,19,13) ORDER BY [name]";
            LoadComboData(cmbControlAccount, query);
        }

        //load group account combo box
        public void LoadGroupAccount(ComboBox cmbGroupAccount, int natureId)
        {
            query = @"SELECT '0' AS [id],'--SELECT ACCOUNT GROUP--' AS [name]
             UNION
             SELECT AG_ID AS [id],AG_NAME AS [name] FROM ACCOUNT_GROUP 
             WHERE AN_ID = (SELECT AN_ID FROM CONTROL_ACCOUNT WHERE CA_ID = '" + natureId + @"')
             ORDER BY [name]";
            LoadComboData(cmbGroupAccount, query);



        }


        //save coa record in database
        public int SaveCoa(string save_query)
        {
            return InsertUpdateDelete(save_query);
        }

        //get level from db 
        public int GetLevelFromDB(string groupCode)
        {
            int i = 0;
            query = "SELECT LEVL FROM ACCOUNT_GROUP WHERE AG_CODE = '" + groupCode + "'";
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                cmd = new SqlCommand(query, conn);
                cmd.CommandTimeout = 0;
                object v = cmd.ExecuteScalar();
                if (v != null) {
                    i = int.Parse(v.ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), ":: Error ::", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
            return i;
        }

        //get account level
        public int GetAccountLevel(string groupCode, DataGridView dg)
        {
            int i = 0;
            foreach (DataGridViewRow rows in dg.Rows)
            {
                if (rows.Cells[1].Value.ToString().Equals(groupCode))
                {
                    i = int.Parse(rows.Cells[11].Value.ToString());
                }
            }
            return i;
        }

        ////open add group form
        public void OpenGroupForm(string query, ComboBox cmb)
        {
            using (frmAddGroup = new frmAddGroupAccounts())
            {
                if (frmAddGroup.ShowDialog() == System.Windows.Forms.DialogResult.Cancel || frmAddGroup.ShowDialog() == System.Windows.Forms.DialogResult.Abort)
                {
                    LoadComboData(cmb, query);
                }
            }
        }

        //*****************Add Region methods************************//
        //grid search 
        public void region_grid_search(TextBox txtSEARCH, DataGridView grdSEARCH)
        {
            (grdSEARCH.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
            [" + grdSEARCH.Columns[1].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%'");
            grdSEARCH.ClearSelection();
        }

        //load group grid
        public void load_region_grid(DataGridView dg)
        {
            query = "select REGION_ID,REGION_NAME as [PROVINCE] from REGION order by PROVINCE";
            LoadGrid(dg, query);
        }

        //load vehicle
        public void LoadVehiclesGrid(DataGridView dg)
        {
            query = "select VEH_ID,VEH_NUMBER as [VEHICLE NUMBER] from vehicles order by [VEHICLE NUMBER]";
            LoadGrid(dg, query);
        }

        //*****************Add City methods************************//
        //clear form fields
        public void clear(TextBox search, TextBox name, Label id, ComboBox cmbIncident)
        {
            search.Text = "";
            name.Text = "";
            id.Text = "";
            cmbIncident.SelectedIndex = 0;
        }

        //check if name already exixts
        public int check_CityName_exists(DataGridView dg, string value)
        {
            foreach (DataGridViewRow rows in dg.Rows)
            {
                if (rows.Cells[1].Value.ToString().Equals(value))
                {
                    return 1;
                }
            }
            return 0;
        }

        //load data grid
        public void load_city_grid(DataGridView dg)
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                query = @"
                select B.REGION_ID,B.REGION_NAME AS [PROVINCE],A.CITY_ID,A.CITY_NAME as [CITY] 
                from CITY A,REGION B
                WHERE A.REG_ID = B.REGION_ID
                order by A.CITY_NAME";
                cmd = new SqlCommand(query, conn);
                cmd.CommandTimeout = 0;
                adp = new SqlDataAdapter();
                adp.SelectCommand = cmd;
                ds = new System.Data.DataSet();
                adp.Fill(ds, "data");
                dg.DataSource = ds.Tables["data"];
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.ToString(), ":: Error ::");
            }
            finally
            {
                conn.Close();
            }
        }

        //load data grid
        public void LoadCartagePacking(DataGridView dg)
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                query = @"SELECT CP_ID,CP_NAME AS [NAME],CP_RATE AS [RATE] FROM CARTAGE_PACKING";
                cmd = new SqlCommand(query, conn);
                cmd.CommandTimeout = 0;
                adp = new SqlDataAdapter();
                adp.SelectCommand = cmd;
                ds = new System.Data.DataSet();
                adp.Fill(ds, "data");
                dg.DataSource = ds.Tables["data"];
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.ToString(), ":: Error ::");
            }
            finally
            {
                conn.Close();
            }
        }

        public void load_Area_grid(DataGridView dg)
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                query = @"
                select B.CITY_ID,B.CITY_NAME AS [CITY],A.AREA_ID,A.AREA_NAME as [AREA] 
                from AREA A,CITY B
                WHERE A.CITY_ID = B.CITY_ID
                order by A.AREA_NAME";
                cmd = new SqlCommand(query, conn);
                cmd.CommandTimeout = 0;
                adp = new SqlDataAdapter();
                adp.SelectCommand = cmd;
                ds = new System.Data.DataSet();
                adp.Fill(ds, "data");
                dg.DataSource = ds.Tables["data"];
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.ToString(), ":: Error ::");
            }
            finally
            {
                conn.Close();
            }
        }



        //*****************Location Gride************************//

        public void load_location_grid(DataGridView dg)
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                query = @"select B.CITY_ID,B.CITY_NAME AS [CITY],A.LOCATION_ID,A.LOCATION_NAME as [LOCATION] 
                from LOCATION A,CITY B
                WHERE A.CITY_ID = B.CITY_ID
                order by A.LOCATION_NAME";
                cmd = new SqlCommand(query, conn);
                cmd.CommandTimeout = 0;
                adp = new SqlDataAdapter();
                adp.SelectCommand = cmd;
                ds = new System.Data.DataSet();
                adp.Fill(ds, "data");
                dg.DataSource = ds.Tables["data"];
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.ToString(), ":: Error ::");
            }
            finally
            {
                conn.Close();
            }
        }


        //*****************Add Sales Person methods************************//
        public void load_salePerson_grid(DataGridView dg)
        {
            query = @"SELECT A.SALES_PER_ID,A.NAME,A.MOBILE,A.EMAIL,A.AREA_ID,C.AREA_NAME AS [AREA],
            A.CITY_ID,B.CITY_NAME as [CITY],A.STAT 
            FROM  SALES_PERSONS A,CITY B,AREA C
            WHERE A.CITY_ID = B.CITY_ID AND A.AREA_ID = C.AREA_ID";
            LoadGrid(dg, query);
        }

        //grid search 
        public void salePerson_grid_search(TextBox txtSEARCH, DataGridView grdSEARCH)
        {
            (grdSEARCH.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
            [" + grdSEARCH.Columns[1].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
              + grdSEARCH.Columns[2].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
              + grdSEARCH.Columns[3].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
              + grdSEARCH.Columns[5].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
              + grdSEARCH.Columns[7].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%'");
            grdSEARCH.ClearSelection();
        }


        public void BankProfile_grid_search(TextBox txtSEARCH, DataGridView grdSEARCH)
        {
            (grdSEARCH.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
            [" + grdSEARCH.Columns[2].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
               + grdSEARCH.Columns[1].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
              + grdSEARCH.Columns[3].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
              + grdSEARCH.Columns[4].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
              + grdSEARCH.Columns[5].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
              + grdSEARCH.Columns[6].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
              + grdSEARCH.Columns[7].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
              + grdSEARCH.Columns[8].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
              + grdSEARCH.Columns[10].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["

              + grdSEARCH.Columns[13].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
              + grdSEARCH.Columns[11].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%'");
            grdSEARCH.ClearSelection();
        }
        public void SUPPILER_Profile_grid_search(TextBox txtSEARCH, DataGridView grdSEARCH)
        {
            (grdSEARCH.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
            [" + grdSEARCH.Columns[13].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
               + grdSEARCH.Columns[14].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
              + grdSEARCH.Columns[15].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
              + grdSEARCH.Columns[6].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
              + grdSEARCH.Columns[4].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
              + grdSEARCH.Columns[7].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
              + grdSEARCH.Columns[9].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
              + grdSEARCH.Columns[11].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
              + grdSEARCH.Columns[5].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
              + grdSEARCH.Columns[12].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%'");
            grdSEARCH.ClearSelection();
        }
        public void CHQ_grid_search(TextBox txtSEARCH, DataGridView grdSEARCH)
        {
            (grdSEARCH.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
            [" + grdSEARCH.Columns[5].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
               + grdSEARCH.Columns[3].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
                 // + grdSEARCH.Columns[13].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
                 + grdSEARCH.Columns[2].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%'");
            grdSEARCH.ClearSelection();
        }
        public void CUSTOMER_Profile_grid_search(TextBox txtSEARCH, DataGridView grdSEARCH)
        {
            (grdSEARCH.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
            [" + grdSEARCH.Columns[13].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
               + grdSEARCH.Columns[14].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
              + grdSEARCH.Columns[15].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
              + grdSEARCH.Columns[6].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
              + grdSEARCH.Columns[7].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
              + grdSEARCH.Columns[8].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
              + grdSEARCH.Columns[10].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
                + grdSEARCH.Columns[5].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
                + grdSEARCH.Columns[4].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
              + grdSEARCH.Columns[12].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%'");
            grdSEARCH.ClearSelection();
        }

        public void Brand_search(TextBox txtSEARCH, DataGridView grdSEARCH)
        {
            (grdSEARCH.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
            [" + grdSEARCH.Columns["BRAND NAME"].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%'");
            grdSEARCH.ClearSelection();
        }
        public void Product_search(TextBox txtSEARCH, DataGridView grdSEARCH)
        {
            (grdSEARCH.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
            ["
               + grdSEARCH.Columns["PRODUCT CODE"].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
               + grdSEARCH.Columns["BRAND"].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
               + grdSEARCH.Columns["PRODUCT NAME"].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%'");
            grdSEARCH.ClearSelection();
        }

        public void Material_search(TextBox txtSEARCH, DataGridView grdSEARCH)
        {
            (grdSEARCH.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
            [" + grdSEARCH.Columns[2].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
               + grdSEARCH.Columns[4].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
              + grdSEARCH.Columns[6].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%'");
            grdSEARCH.ClearSelection();
        }

        public void PurchaseRaw_search(TextBox txtSEARCH, DataGridView grdSEARCH)
        
        {

            try
            {
                (grdSEARCH.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
              [" + grdSEARCH.Columns["INVOICE #"].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
              + grdSEARCH.Columns["SUPPLIER"].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR["
               + grdSEARCH.Columns["DESCRIPTION"].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%'");
        grdSEARCH.ClearSelection();
            }

            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }



            public void Sale_search(TextBox txtSEARCH, DataGridView grdSEARCH)
        {

            try
            {
                (grdSEARCH.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
              [" + grdSEARCH.Columns["INVOICE #"].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
               + grdSEARCH.Columns["CUSTOMER"].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%'");
                grdSEARCH.ClearSelection();
            }

            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }


        public void ProductFormulaSearch(TextBox txtSEARCH, DataGridView grdSEARCH)
        {
            (grdSEARCH.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
            [" + grdSEARCH.Columns[1].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%'");
            grdSEARCH.ClearSelection();
        }



        public void Packing_Purchases_search(TextBox txtSEARCH, DataGridView grdSEARCH)
        {
            (grdSEARCH.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
            [" + grdSEARCH.Columns[6].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
               + grdSEARCH.Columns[4].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
              + grdSEARCH.Columns[5].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%'");
            grdSEARCH.ClearSelection();
        }

        public void Sales_Order_Product_Search(TextBox txtSEARCH, DataGridView grdSEARCH)
        {
            (grdSEARCH.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
            [" + grdSEARCH.Columns["INVOICE #"].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
               + grdSEARCH.Columns["CUSTOMER"].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
               + grdSEARCH.Columns["SALES TYPE"].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%'");
            grdSEARCH.ClearSelection();
        }

        public void Sale_Program_Search(TextBox txtSEARCH, DataGridView grdSEARCH)
        {
            try
            {
                (grdSEARCH.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
            [" + grdSEARCH.Columns["PROGRAM #"].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
                   + grdSEARCH.Columns["SALES ORDER #"].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
                   + grdSEARCH.Columns["CUSTOMER"].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
                   + grdSEARCH.Columns["DESCRIPTION"].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
                   + grdSEARCH.Columns["SO_TYPE"].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%'");
                grdSEARCH.ClearSelection();
            }
            catch (Exception ex)
            {

            }
        }

        public void Sale_Return_Search(TextBox txtSEARCH, DataGridView grdSEARCH)
        {
            (grdSEARCH.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
            [" + grdSEARCH.Columns["INVOICE #"].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
               + grdSEARCH.Columns["CUSTOMER NAME"].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
               + grdSEARCH.Columns["VEHICLE_NO"].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%'");
            grdSEARCH.ClearSelection();
        }
        public void JobOrder_Search(TextBox txtSEARCH, DataGridView grdSEARCH)
        {
            (grdSEARCH.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
            [" + grdSEARCH.Columns["INVOICE #"].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
               + grdSEARCH.Columns["DESCRIPTION"].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%'");
            grdSEARCH.ClearSelection();
        }
        public void JobOrderMaterial_Search(TextBox txtSEARCH, DataGridView grdSEARCH)
        {
            (grdSEARCH.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
            [" + grdSEARCH.Columns["EXPENSE"].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
               + grdSEARCH.Columns["PAYMENT ACCOUNT"].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
               + grdSEARCH.Columns["MATERIAL_NAME"].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
               + grdSEARCH.Columns["DESCRIPTION"].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%'");
            grdSEARCH.ClearSelection();
        }
        public void JobOrderExpense_Search(TextBox txtSEARCH, DataGridView grdSEARCH)
        {
            (grdSEARCH.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
            [" + grdSEARCH.Columns["EXPENSE"].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
               + grdSEARCH.Columns["DESCRIPTION"].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%'");
            grdSEARCH.ClearSelection();
        }
        public void GatePass_Search(TextBox txtSEARCH, DataGridView grdSEARCH)
        {
            (grdSEARCH.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
            [" + grdSEARCH.Columns["SALE INVOICE #"].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
               + grdSEARCH.Columns["GATE PASS #"].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
               + grdSEARCH.Columns["SALE PROGRAM #"].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
               + grdSEARCH.Columns["VEHICLE_NO"].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
               + grdSEARCH.Columns["CUSTOMER"].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%'");
            grdSEARCH.ClearSelection();
        }

        public void PurchasesOrderSearch(TextBox txtSEARCH, DataGridView grdSEARCH)
        {
            (grdSEARCH.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
            [" + grdSEARCH.Columns[1].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
               + grdSEARCH.Columns[4].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
               + grdSEARCH.Columns[6].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
              + grdSEARCH.Columns[8].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%'");
            grdSEARCH.ClearSelection();
        }

        public void SalesOrderDirectSearch(TextBox txtSEARCH, DataGridView grdSEARCH)
        {
            (grdSEARCH.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
            [" + grdSEARCH.Columns["INVOICE #"].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
               + grdSEARCH.Columns["CUSTOMER"].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
               + grdSEARCH.Columns["SALES TYPE"].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%'");
            grdSEARCH.ClearSelection();
        }

        //Add Broker/////////////////////
        //load details on combo box item changed
        public void LoadBrokerDetails(DataGridView dg, string id, TextBox txtEmail, TextBox txtMobile, ComboBox cmbCity, TextBox txtCommAmount, ComboBox cmbCommType, CheckBox chkStatus)
        {
            foreach (DataGridViewRow rows in dg.Rows)
            {
                if (rows.Cells[0].Value.ToString().Equals(id))
                {
                    txtEmail.Text = rows.Cells[3].Value.ToString();
                    txtMobile.Text = rows.Cells[2].Value.ToString();
                    cmbCity.SelectedValue = rows.Cells[6].Value.ToString();
                    txtCommAmount.Text = rows.Cells[4].Value.ToString();
                    cmbCommType.Text = rows.Cells[5].Value.ToString();
                    if (rows.Cells[8].Value.ToString().Equals("1"))
                    {
                        chkStatus.Checked = true;
                    }
                    return;
                }
            }
            txtEmail.Clear();
            txtMobile.Clear();
            cmbCity.SelectedIndex = 0;
            txtCommAmount.Clear();
            cmbCommType.Text = "--------SELECT TYPE---------";
            chkStatus.Checked = false;

        }
        public void Broker_grid_search(TextBox txtSEARCH, DataGridView grdSEARCH)
        {
            (grdSEARCH.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
            [" + grdSEARCH.Columns[1].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
               + grdSEARCH.Columns[2].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
               + grdSEARCH.Columns[3].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
              + grdSEARCH.Columns[5].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
              + grdSEARCH.Columns[7].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%'");
            grdSEARCH.ClearSelection();
        }
        public void unit_search(TextBox txtSEARCH, DataGridView grdSEARCH)
        {
            (grdSEARCH.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
            [" + grdSEARCH.Columns[1].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%'");
            grdSEARCH.ClearSelection();
        }

        public void TAX_search(TextBox txtSEARCH, DataGridView grdSEARCH)
        {
            (grdSEARCH.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
            [" + grdSEARCH.Columns[1].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%' OR ["
              + grdSEARCH.Columns[3].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%'");
            grdSEARCH.ClearSelection();
        }

        //public void Product_search(TextBox txtSEARCH, DataGridView grdSEARCH)
        //{
        //    (grdSEARCH.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
        //    ["
        //      + grdSEARCH.Columns[1].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%'");
        //    grdSEARCH.ClearSelection();
        //}



        //load city combo box
        public void load_city(ComboBox cmbCity)
        {
            query = @"SELECT '0' AS [id],'--SELECT CITY--' AS [name]
            union all
            SELECT City_ID AS [id]
            ,City_NAME AS [name]
            FROM CITY";
            LoadComboData(cmbCity, query);
        }

        public void load_area(ComboBox cmbArea, string city_id)
        {
            query = @"SELECT '0' AS [id],'--SELECT AREA--' AS [name]
            union all
            SELECT AREA_ID AS [id]
            ,AREA_NAME AS [name]
            FROM AREA WHERE city_ID = '" + city_id + "'";
            LoadComboData(cmbArea, query);
        }

        //*****************Add Supplier Category methods************************//
        public void load_SupplierCategory_grid(DataGridView dg)
        {
            query = @"select SUPP_TYPE_ID,NAME,STAT from  SUPPLIER_TYPES";
            LoadGrid(dg, query);
        }

        //grid search 
        public void SupplierCategory_grid_search(TextBox txtSEARCH, DataGridView grdSEARCH)
        {
            (grdSEARCH.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
            [" + grdSEARCH.Columns[1].Name.ToString() + "] LIKE '%" + AvoidInjection(txtSEARCH.Text) + "%'");
            grdSEARCH.ClearSelection();
        }

        //get customer data from coa id
        public void GetCustomerData(DataGridView dg, string value, TextBox txtNtn, TextBox txtStrn, TextBox txtGst, TextBox txtMobile,
            ComboBox cmbSalesPerson, TextBox txtEmail, ComboBox cmbCity, ComboBox cmbArea, TextBox txtCont_Per, TextBox txtCreditLimit,
            TextBox txtAddress, CheckBox chkStatus, TextBox txtCreditDays)
        {
            foreach (DataGridViewRow rows in dg.Rows)
            {
                if (rows.Cells[2].Value.ToString().Equals(value))
                {
                    txtNtn.Text = rows.Cells[13].Value.ToString();
                    txtStrn.Text = rows.Cells[14].Value.ToString();
                    txtGst.Text = rows.Cells[15].Value.ToString();
                    txtMobile.Text = rows.Cells[6].Value.ToString();
                    cmbSalesPerson.SelectedValue = rows.Cells[3].Value.ToString();
                    txtEmail.Text = rows.Cells[7].Value.ToString();
                    cmbCity.SelectedValue = rows.Cells[9].Value.ToString();
                    cmbArea.SelectedValue = rows.Cells[11].Value.ToString();
                    txtCont_Per.Text = rows.Cells[5].Value.ToString();
                    txtCreditLimit.Text = rows.Cells[16].Value.ToString();
                    txtAddress.Text = rows.Cells[8].Value.ToString();
                    txtCreditDays.Text = rows.Cells["CREDIT DAYS"].Value.ToString();
                    if (rows.Cells[17].Value.ToString().Equals("1")) {
                        chkStatus.Checked = true;
                    }
                }
            }
        }

        //get supplier data from coa id
        public void GetSupplierData(DataGridView dg, string value, TextBox txtNtn, TextBox txtStrn, TextBox txtGst, TextBox txtMobile,
            ComboBox cmbSupplierType, TextBox txtEmail, ComboBox cmbCity, ComboBox cmbArea, TextBox txtCont_Per, TextBox txtCreditLimit,
            TextBox txtAddress, CheckBox chkStatus)
        {
            foreach (DataGridViewRow rows in dg.Rows)
            {
                if (rows.Cells[2].Value.ToString().Equals(value))
                {
                    txtNtn.Text = rows.Cells[13].Value.ToString();
                    txtStrn.Text = rows.Cells[14].Value.ToString();
                    txtGst.Text = rows.Cells[15].Value.ToString();
                    txtMobile.Text = rows.Cells[6].Value.ToString();
                    cmbSupplierType.SelectedValue = rows.Cells[3].Value.ToString();
                    txtEmail.Text = rows.Cells[7].Value.ToString();
                    cmbCity.SelectedValue = rows.Cells[8].Value.ToString();
                    cmbArea.SelectedValue = rows.Cells[10].Value.ToString();
                    txtCont_Per.Text = rows.Cells[5].Value.ToString();
                    txtCreditLimit.Text = rows.Cells[16].Value.ToString();
                    txtAddress.Text = rows.Cells[12].Value.ToString();
                    if (rows.Cells[17].Value.ToString().Equals("1"))
                    {
                        chkStatus.Checked = true;
                    }
                }
            }
        }

        //load COMBO BOXES
        public void LoadPurchaseOrder(ComboBox cmbPO, int supplier, int isEdit)
        {
            try
            {
                if (isEdit == 1)
                {
                    query = @"SELECT '0' AS [id], '--SELECT P.O--' AS [name] UNION ALL SELECT PO_ID as [id],PO_NUMBER as [name]
                    FROM PURCHASES_ORDER
                    WHERE SUPPLIER_ID = '" + supplier + "'";
                }
                else {
                    query = @"SELECT '0' AS [id], '--SELECT P.O--' AS [name] UNION ALL SELECT PO_ID as [id],PO_NUMBER as [name]
                    FROM PURCHASES_ORDER
                    WHERE SUPPLIER_ID = '" + supplier + "' AND [STATUS] = 'N' ";
                }
                LoadComboData(cmbPO, query);
            }
            catch (Exception ex) { ShowMessageBox(ex.ToString(), "Exception"); }
        }

        public void GenerateSONumber(Label lbl)
        {
            query = @"SELECT
            (SELECT COUNT(SOD_ID) FROM SALES_ORDER_DIRECT)+
            (SELECT COUNT(SOPM_ID) FROM SALES_ORDER_PRODUCT_MASTER)+
            (SELECT COUNT(MPM_ID) FROM SO_MATERIAL_P_MASTER)+1";
            lbl.Text = "SO-" + GetMaxValue(query) + "-" + DateTime.Now.Year;
        }

        //load COMBO BOXES SO
        public void LoadSOOrder(ComboBox cmbSO, string customerId)
        {
            try
            {
                query = @"SELECT '0' AS [id], '--SELECT S.O--' AS [name] 
                UNION ALL 
                SELECT CONVERT(VARCHAR(50),SOD_ID)+'D' as [id],INVOICE_NO +' ('+(CONVERT(VARCHAR(15),FORMAT(DATE,'dd/MM/yyyy')))+')' as [name]
                FROM SALES_ORDER_DIRECT
                WHERE CUSTOMER_ID = '" + customerId + @"' AND STATUS = '1'
                UNION ALL
                SELECT CONVERT(VARCHAR(50), SOPM_ID)+'P' as [id],INVOICE_NO +' ('+(CONVERT(VARCHAR(15),FORMAT(DATE,'dd/MM/yyyy')))+')' as [name]
                FROM SALES_ORDER_PRODUCT_MASTER
                WHERE CUSTOMER_ID = '" + customerId + @"' AND STATUS = '1'
                UNION ALL
                SELECT CONVERT(VARCHAR(50), MPM_ID)+'M' as [id],INVOICE_NO +' ('+(CONVERT(VARCHAR(15),FORMAT(DATE,'dd/MM/yyyy')))+')' as [name]
                FROM SO_MATERIAL_P_MASTER
                WHERE CUSTOMER_ID = '" + customerId + "' AND STATUS = '1'";
                LoadComboData(cmbSO, query);
            }
            catch (Exception ex) { ShowMessageBox(ex.ToString(), "Exception"); }
        }

        //load COMBO BOXES SO
        public void LoadSOOrder(ComboBox cmbSO, int customerId, string soId)
        {
            try
            {
                query = @"SELECT '0' AS [id], '--SELECT S.O--' AS [name] 
                UNION ALL 
                SELECT CONVERT(VARCHAR(50),SOD_ID)+'D' as [id],INVOICE_NO +' ('+(CONVERT(VARCHAR(15),FORMAT(DATE,'dd/MM/yyyy')))+')' as [name]
                FROM SALES_ORDER_DIRECT
                WHERE CUSTOMER_ID = '" + customerId + @"'
                UNION ALL
                SELECT CONVERT(VARCHAR(50), SOPM_ID)+'P' as [id],INVOICE_NO +' ('+(CONVERT(VARCHAR(15),FORMAT(DATE,'dd/MM/yyyy')))+')' as [name]
                FROM SALES_ORDER_PRODUCT_MASTER
                WHERE CUSTOMER_ID = '" + customerId + @"'
                UNION ALL
                SELECT CONVERT(VARCHAR(50), MPM_ID)+'M' as [id],INVOICE_NO +' ('+(CONVERT(VARCHAR(15),FORMAT(DATE,'dd/MM/yyyy')))+')' as [name]
                FROM SO_MATERIAL_P_MASTER
                WHERE CUSTOMER_ID = '" + customerId + "'";
                LoadComboData(cmbSO, query);
            }
            catch (Exception ex) { ShowMessageBox(ex.ToString(), "Exception"); }
        }

        //load COMBO BOXES Pro
        public void LoadSO(ComboBox cmbSO, int customerId, char type)
        {
            try
            {
                if (type == 'a')
                {
                    query = @"SELECT '0' AS [id], '--SELECT S.O--' AS [name] 
                    UNION ALL 
                    SELECT SPM_ID as [id],INVOICE_NO as [name]
                    FROM SALES_PROGRAM_MASTER
                    WHERE CUSTOMER_ID = '" + customerId + @"'";
                }
                else {
                    query = @"SELECT '0' AS [id], '--SELECT S.O--' AS [name] 
                    UNION ALL 
                    SELECT SPM_ID as [id],INVOICE_NO as [name]
                    FROM SALES_PROGRAM_MASTER
                    WHERE CUSTOMER_ID = '" + customerId + @"' AND SPM_ID NOT IN (SELECT SOP_ID FROM GATE_PASS)";
                }
                //UNION ALL
                //SELECT SOPM_ID as [id],INVOICE_NO as [name]
                //FROM SALES_ORDER_PRODUCT_MASTER
                //WHERE CUSTOMER_ID = '" + customerId + "' AND TOTAL_WEIGHT -REMAINING_WEIGHT > 0
                LoadComboData(cmbSO, query);
            }
            catch (Exception ex) { ShowMessageBox(ex.ToString(), "Exception"); }
        }

        //load COMBO BOXES Gate Pass
        public void LoadGP(ComboBox cmbGP, int customerId)
        {
            try
            {
                query = @"SELECT '0' AS [id], '--SELECT GATE PASS--' AS [name] 
                UNION ALL 
                SELECT GPM_ID as [id],INVOICE_NO as [name]
                FROM GATE_PASS_MASTER
                WHERE CUSTOMER_ID = '" + customerId + @"' AND GPM_ID NOT IN (SELECT SO_ID FROM SALES_MASTER)";
                LoadComboData(cmbGP, query);
            }
            catch (Exception ex) { ShowMessageBox(ex.ToString(), "Exception"); }
        }

        //load GP Products
        public void LoadGPProducts(int gatePassId, DataGridView dg, TextBox creditDays, DateTime date)
        {
            try
            {
                query = @"SELECT C.PM_ID AS [PRODUCT_ID],C.PRODUCT_NAME,B.QTY,B.RATE,
                B.[WEIGHT],'KGS' AS [UNIT],0 AS [MILLING_RATE],0 AS [PACKING_RATE],(B.QTY * B.RATE) AS [TOTAL],
                B.ITEM_TYPE AS [CHAR],(SELECT MATERIAL_ID FROM PRODUCT_DETAILS WHERE PM_ID = C.PM_ID) AS [MATERIAL_ID],
                (SELECT CREDIT_DAYS FROM CUSTOMER_PROFILE WHERE COA_ID = D.CUSTOMER_ID) AS [CREDIT_DAYS]
                FROM GATE_PASS A
                INNER JOIN GATE_PASS_DETAIL B ON A.GPM_ID = B.GP_ID
                INNER JOIN PRODUCT_MASTER C ON B.PRODUCT_ID = C.PM_ID
                INNER JOIN SALES D ON A.GPM_ID = D.GPM_ID 
                WHERE A.GPM_ID = '" + gatePassId + @"' AND B.ITEM_TYPE = 'P'
                UNION ALL
                SELECT C.MATERIAL_ID AS [PRODUCT_ID],C.MATERIAL_NAME,B.QTY,B.RATE,
                B.[WEIGHT],'KGS' AS [UNIT],0 AS [MILLING_RATE],0 AS [PACKING_RATE],(B.QTY * B.RATE) AS [TOTAL],
                B.ITEM_TYPE AS [CHAR],C.MATERIAL_ID AS [MATERIAL_ID],
                (SELECT CREDIT_DAYS FROM CUSTOMER_PROFILE WHERE COA_ID = D.CUSTOMER_ID) AS [CREDIT_DAYS]
                FROM GATE_PASS A
                INNER JOIN GATE_PASS_DETAIL B ON A.GPM_ID = B.GP_ID
                INNER JOIN MATERIALS C ON B.PRODUCT_ID = C.MATERIAL_ID
                INNER JOIN SALES D ON A.GPM_ID = D.GPM_ID 
                WHERE A.GPM_ID = '" + gatePassId + "' AND B.ITEM_TYPE = 'R'";

                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                cmd = new SqlCommand(query, conn);
                cmd.CommandTimeout = 0;
                dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        dg.Rows.Add(dr["PRODUCT_ID"].ToString(), dr["PRODUCT_NAME"].ToString(), dr["QTY"].ToString(), dr["RATE"].ToString(),
                            dr["WEIGHT"].ToString(), dr["UNIT"].ToString(), dr["MILLING_RATE"].ToString(), dr["PACKING_RATE"].ToString(),
                            dr["TOTAL"].ToString(), dr["CHAR"].ToString(), dr["MATERIAL_ID"].ToString());
                        creditDays.Text = dr["CREDIT_DAYS"].ToString();
                    }
                    creditDays.Text = string.Format("{0:dd-MM-yyyy}", date.AddDays(Convert.ToInt32(creditDays.Text)));
                }
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.ToString(), ":: Error ::");
            }
            finally
            {
                conn.Close();
            }
        }

        //load SO Products
        public void LoadSOProducts(char type, int soId, DataGridView dg, TextBox creditDays, DateTime date)
        {
            try
            {
                if (type == 'P')
                {
                    query = @"IF (SELECT SO_TYPE FROM SALES_PROGRAM_MASTER WHERE SPM_ID = '" + soId + @"') = 'D'
                    BEGIN
	                    SELECT B.PRODUCT_ID,C.PRODUCT_NAME,B.QTY,(B.QTY * C.NET_WEIGHT) AS [TOTAL WEIGHT],'KGS' AS [UNIT],B.RATE,(B.QTY * B.RATE) AS [TOTAL],'P' AS [CHAR],D.CREDIT_DAYS,
	                    C.MILLING_RATE,C.PACKING_RATE,C.NET_WEIGHT AS [UNIT WEIGHT],D.MATERIAL_ID
	                    FROM SALES_PROGRAM_MASTER A
	                    INNER JOIN SALES_PROGRAM_DETAILS B ON A.SPM_ID = B.SPM_ID
	                    INNER JOIN PRODUCT_MASTER C ON B.PRODUCT_ID = C.PM_ID
	                    INNER JOIN SALES_ORDER_DIRECT D ON A.SOD_ID = D.SOD_ID
	                    WHERE B.ITEM_TYPE = 'P' AND A.SPM_ID = '" + soId + @"'
	                    UNION ALL
	                    SELECT B.PRODUCT_ID,C.MATERIAL_NAME,B.QTY,B.QTY,'KGS',B.RATE,(B.QTY * B.RATE),'R',D.CREDIT_DAYS,'0','0',B.QTY AS [UNIT WEIGHT],C.MATERIAL_ID
	                    FROM SALES_PROGRAM_MASTER A
	                    INNER JOIN SALES_PROGRAM_DETAILS B ON A.SPM_ID = B.SPM_ID
	                    INNER JOIN MATERIALS C ON B.PRODUCT_ID = C.MATERIAL_ID
	                    INNER JOIN SALES_ORDER_DIRECT D ON A.SOD_ID = D.SOD_ID
	                    WHERE B.ITEM_TYPE = 'R' AND A.SPM_ID = '" + soId + @"'
                    END
                    ELSE IF (SELECT SO_TYPE FROM SALES_PROGRAM_MASTER WHERE SPM_ID = '" + soId + @"') = 'P'
                    BEGIN
	                    SELECT B.PRODUCT_ID,C.PRODUCT_NAME,B.QTY,(B.QTY * C.NET_WEIGHT) AS [TOTAL WEIGHT],'KGS' AS [UNIT],B.RATE,(B.QTY * B.RATE) AS [TOTAL],'P' AS [CHAR],D.CREDIT_DAYS,
	                    C.MILLING_RATE,C.PACKING_RATE,C.NET_WEIGHT AS [UNIT WEIGHT],(select MATERIAL_ID from PRODUCT_DETAILS WHERE PM_ID = C.PM_ID) AS [MATERIAL_ID]
	                    FROM SALES_PROGRAM_MASTER A
	                    INNER JOIN SALES_PROGRAM_DETAILS B ON A.SPM_ID = B.SPM_ID
	                    INNER JOIN PRODUCT_MASTER C ON B.PRODUCT_ID = C.PM_ID
	                    INNER JOIN SALES_ORDER_PRODUCT_MASTER D ON A.SOD_ID = D.SOPM_ID
	                    WHERE B.ITEM_TYPE = 'P' AND A.SPM_ID = '" + soId + @"'
	                    UNION ALL
	                    SELECT B.PRODUCT_ID,C.MATERIAL_NAME,B.QTY,B.QTY,'KGS',B.RATE,(B.QTY * B.RATE),'R',D.CREDIT_DAYS,'0','0',B.QTY AS [UNIT WEIGHT],C.MATERIAL_ID
	                    FROM SALES_PROGRAM_MASTER A
	                    INNER JOIN SALES_PROGRAM_DETAILS B ON A.SPM_ID = B.SPM_ID
	                    INNER JOIN MATERIALS C ON B.PRODUCT_ID = C.MATERIAL_ID
	                    INNER JOIN SALES_ORDER_PRODUCT_MASTER D ON A.SOD_ID = D.SOPM_ID
	                    WHERE B.ITEM_TYPE = 'R' AND A.SPM_ID = '" + soId + @"'
                    END
                    ELSE IF (SELECT SO_TYPE FROM SALES_PROGRAM_MASTER WHERE SPM_ID = '" + soId + @"') = 'M'
                    BEGIN
	                    SELECT B.PRODUCT_ID,C.PRODUCT_NAME,B.QTY,(B.QTY * C.NET_WEIGHT) AS [TOTAL WEIGHT],'KGS' AS [UNIT],B.RATE,(B.QTY * B.RATE) AS [TOTAL],'P' AS [CHAR],D.CREDIT_DAYS,
	                    C.MILLING_RATE,C.PACKING_RATE,C.NET_WEIGHT AS [UNIT WEIGHT],(select MATERIAL_ID from PRODUCT_DETAILS WHERE PM_ID = C.PM_ID) AS [MATERIAL_ID]
	                    FROM SALES_PROGRAM_MASTER A
	                    INNER JOIN SALES_PROGRAM_DETAILS B ON A.SPM_ID = B.SPM_ID
	                    INNER JOIN PRODUCT_MASTER C ON B.PRODUCT_ID = C.PM_ID
	                    INNER JOIN SO_MATERIAL_P_MASTER D ON A.SOD_ID = D.MPM_ID
	                    WHERE B.ITEM_TYPE = 'P' AND A.SPM_ID = '" + soId + @"'
	                    UNION ALL
	                    SELECT B.PRODUCT_ID,C.MATERIAL_NAME,B.QTY,B.QTY,'KGS',B.RATE,(B.QTY * B.RATE),'R',D.CREDIT_DAYS,'0','0',B.QTY AS [UNIT WEIGHT],C.MATERIAL_ID
	                    FROM SALES_PROGRAM_MASTER A
	                    INNER JOIN SALES_PROGRAM_DETAILS B ON A.SPM_ID = B.SPM_ID
	                    INNER JOIN MATERIALS C ON B.PRODUCT_ID = C.MATERIAL_ID
	                    INNER JOIN SO_MATERIAL_P_MASTER D ON A.SOD_ID = D.MPM_ID
	                    WHERE B.ITEM_TYPE = 'R' AND A.SPM_ID = '" + soId + @"'
                    END";
                }
                else {
                    //query = @"SELECT B.PRODUCT_ID,C.PRODUCT_NAME,B.QTY,(B.QTY * C.NET_WEIGHT),'KGS',B.RATE,(B.QTY * B.RATE),'P'
                    //FROM SALES_ORDER_PRODUCT_MASTER A
                    //INNER JOIN SALES_ORDER_PRODUCT_DETAILS B ON A.SOPM_ID = B.SOPM_ID
                    //INNER JOIN PRODUCT_MASTER C ON B.PRODUCT_ID = C.PM_ID  AND A.SPM_ID = '" + soId + "'";
                }
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                cmd = new SqlCommand(query, conn);
                cmd.CommandTimeout = 0;
                dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        dg.Rows.Add(dr["PRODUCT_ID"].ToString(), dr["PRODUCT_NAME"].ToString(), dr["QTY"].ToString(), dr["RATE"].ToString(),
                            dr["TOTAL WEIGHT"].ToString(), dr["UNIT"].ToString(), dr["MILLING_RATE"].ToString(), dr["PACKING_RATE"].ToString(),
                            dr["TOTAL"].ToString(), dr["CHAR"].ToString(), dr["MATERIAL_ID"].ToString());
                        //dr["QTY"].ToString(), dr["UNIT WEIGHT"].ToString()
                        creditDays.Text = dr["CREDIT_DAYS"].ToString();
                    }
                    creditDays.Text = string.Format("{0:dd-MM-yyyy}", date.AddDays(Convert.ToInt32(creditDays.Text)));
                    UpdateSoGrid(dg, GetSoldItems(soId, type));
                }
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.ToString(), ":: Error ::");
            }
            finally
            {
                conn.Close();
            }
        }
        //load GP Products
        public void LoadGPProducts(char type, int soId, DataGridView dg)
        {
            try
            {
                query = @"SELECT B.PRODUCT_ID,C.MATERIAL_NAME,B.QTY,B.WEIGHT,'KGS',B.RATE,(B.QTY * B.RATE)
                FROM GATE_PASS_MASTER A
                INNER JOIN GATE_PASS_DETAILS B ON A.GPM_ID = B.GPM_ID
                INNER JOIN MATERIALS C ON B.PRODUCT_ID = C.MATERIAL_ID
                WHERE A.GPM_ID = '" + soId + "'";

                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                cmd = new SqlCommand(query, conn);
                cmd.CommandTimeout = 0;
                dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        dg.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(),
                            dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
                    }
                    //UpdateSoGrid(dg, GetSoldItems(soId, type));
                }
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.ToString(), ":: Error ::");
            }
            finally
            {
                conn.Close();
            }
        }

        public void LoadPurchaseOrderDetail(string query, DataGridView dg)
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                cmd = new SqlCommand(query, conn);
                cmd.CommandTimeout = 0;
                dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    dg.Rows.Clear();
                    while (dr.Read())
                    {
                        dg.Rows.Add(dr["MATERIAL_ID"].ToString(), dr["PRODUCT NAME"].ToString(), dr["QTY"].ToString(), dr["RATE"].ToString(),
                            dr["BALANCE QTY"].ToString());
                    }
                    //UpdateSoGrid(dg, GetSoldItems(soId, type));
                }
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.ToString(), ":: Error ::");
            }
            finally
            {
                conn.Close();
            }
        }

        public void LoadSalesOrderDetail(string query, DataGridView dg)
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                cmd = new SqlCommand(query, conn);
                cmd.CommandTimeout = 0;
                dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    dg.Rows.Clear();
                    while (dr.Read())
                    {
                        dg.Rows.Add(dr["PRODUCT_ID"].ToString(), dr["PRODUCT NAME"].ToString(), dr["QTY"].ToString(), dr["RATE"].ToString(),
                            Convert.ToDecimal(dr["QTY"].ToString()) * Convert.ToDecimal(dr["RATE"].ToString()),0, Convert.ToDecimal(dr["QTY"].ToString()) * Convert.ToDecimal(dr["RATE"].ToString()), Convert.ToDecimal(dr["COST RATE"].ToString()));
                    }
                    //UpdateSoGrid(dg, GetSoldItems(soId, type));
                }
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.ToString(), ":: Error ::");
            }
            finally
            {
                conn.Close();
            }
        }

        public void LoadSalesInvoiceDetail(string query, DataGridView dg)
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                cmd = new SqlCommand(query, conn);
                cmd.CommandTimeout = 0;
                dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    dg.Rows.Clear();
                    while (dr.Read())
                    {
                        dg.Rows.Add(dr["ITEM_ID"].ToString(), dr["PRODUCT NAME"].ToString(), dr["QTY"].ToString(), dr["RATE"].ToString(),
                            Convert.ToDecimal(dr["QTY"].ToString()) * Convert.ToDecimal(dr["RATE"].ToString()), dr["GST"].ToString(),
                            (Convert.ToDecimal(dr["QTY"].ToString()) * Convert.ToDecimal(dr["RATE"].ToString())) + 
                            ((Convert.ToDecimal(dr["QTY"].ToString()) * Convert.ToDecimal(dr["RATE"].ToString())) * Convert.ToDecimal(dr["GST"].ToString()) / 100));
                    }
                    //UpdateSoGrid(dg, GetSoldItems(soId, type));
                }
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.ToString(), ":: Error ::");
            }
            finally
            {
                conn.Close();
            }
        }

        //load SO Products
        public Dictionary<int, string> GetSoldItems(int soId, char type)
        {
            string rquery = "";
            Dictionary<int, string> productList = new Dictionary<int, string>();
            try
            {
                if (type == 'P')
                {
                    rquery = @"SELECT B.PRODUCT_ID,SUM(B.QTY)
                    FROM SALES_PROGRAM_MASTER A,SALES_PROGRAM_DETAILS B
                    WHERE A.SPM_ID = B.SPM_ID AND A.SPM_ID = '" + soId + @"'
                    GROUP BY B.PRODUCT_ID";
                }
                else {
                    //rquery = @"SELECT B.PRODUCT_ID,SUM(B.QTY)
                    //FROM GATE_PASS_MASTER A,GATE_PASS_DETAILS B
                    //WHERE A.GPM_ID = B.GPM_ID AND A.SO_ID = '" + soId + @"'
                    //AND A.SO_TYPE = 'S'
                    //GROUP BY B.PRODUCT_ID";
                }

                if (conn1.State == System.Data.ConnectionState.Closed) { conn1.Open(); }
                SqlCommand cmd = new SqlCommand(rquery, conn1);
                cmd.CommandTimeout = 0;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        productList.Add(Convert.ToInt32(dr[0].ToString()), dr[1].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.ToString(), ":: Error ::");
            }
            finally
            {
                conn1.Close();
            }
            return productList;
        }
        public void UpdateSoGrid(DataGridView dg, Dictionary<int, string> productList) {
            try {
                foreach (DataGridViewRow rows in dg.Rows) {
                    foreach (KeyValuePair<int, string> items in productList) {
                        if (rows.Cells[0].Value.ToString().Equals(items.Key)) {
                            double weight = Convert.ToDouble(rows.Cells[3].Value.ToString()) / Convert.ToDouble(rows.Cells[2].Value.ToString());
                            rows.Cells[2].Value = Convert.ToDouble(rows.Cells[2].Value.ToString()) - Convert.ToDouble(items.Value);
                            rows.Cells[8].Value = Convert.ToDouble(rows.Cells[2].Value.ToString()) - Convert.ToDouble(items.Value);
                            rows.Cells[3].Value = Convert.ToDouble(rows.Cells[2].Value.ToString()) * weight;
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        public void LoadSuppliers(ComboBox cmbSupplier)
        {
            try
            {


                query = @"    SELECT '0' AS[id],'--SELECT SUPPLIER--' AS[name]
                UNION
                SELECT COA_ID AS[id], COA_NAME AS[name] FROM COA";
                LoadComboData(cmbSupplier, query);

                // query = @"SELECT '0' AS [id],'--SELECT SUPPLIER--' AS [name]
                //UNION
                //SELECT COA_ID AS [id],COA_NAME AS [name] FROM COA WHERE CA_ID IN ('20','21') AND STAT = 0";
                //LoadComboData(cmbSupplier, query);
            }
            catch (Exception ex) { ShowMessageBox(ex.ToString(), "Exception"); }
        }

        public Decimal LoadStockBalance(int productId)
        {
            query = @" SELECT X.[IN] - X.[OUT] AS [BALANCE] 
            FROM (
            SELECT 
            B.OPENING_QTY +
            ISNULL((
	            SELECT SUM(QTY) 
	            FROM SALE_RETURN_MASTER X
	            INNER JOIN SALE_RETURN_DETAIL Y ON X.SALE_RETURN_MASTER_ID = Y.SALE_RETURN_MASTER_ID
	            INNER JOIN PRODUCT_MASTER Z ON Y.ITEM_ID = Z.PM_ID
	            WHERE X.[DATE] <= GETDATE() AND Y.ITEM_ID = B.PM_ID 
            ),0) +
            ISNULL((
		        SELECT SUM(QTY) 
		        FROM PURCHASE_MASTER X
		        INNER JOIN PURCHASE_DETAIL Y ON X.PURCHASE_MASTER_ID = Y.PURCHASE_MASTER_ID
		        INNER JOIN PRODUCT_MASTER Z ON Y.MATERIAL_ID = Z.PM_ID
		        WHERE X.[DATE] <= GETDATE() AND Y.MATERIAL_ID = B.PM_ID 
	        ),0) +
	        ISNULL((
		        SELECT SUM(QTY) 
		        FROM PRODUCTION_MASTER X
		        INNER JOIN PRODUCTION_DETAIL Y ON X.ID = Y.PRODUCTION_MASTER_ID
		        INNER JOIN PRODUCT_MASTER Z ON Y.PRODUCT_MASTER_ID = Z.PM_ID
		        WHERE X.[DATE] <= GETDATE() AND Y.PRODUCT_MASTER_ID = B.PM_ID 
	        ),0) +
	        ISNULL((
		        SELECT SUM(X.QTY) 
				FROM INVENTORY_ADJUSTMENTS X
				INNER JOIN PRODUCT_MASTER Z ON X.MATERIAL_ID = Z.PM_ID
				WHERE X.[DATE] <= GETDATE() AND X.MATERIAL_ID = B.PM_ID 
				AND X.ADD_LESS = 'A'
	        ),0) AS [IN],
            ISNULL((
	            SELECT SUM(QTY) 
	            FROM SALE_MASTER X
	            INNER JOIN SALE_DETAIL Y ON X.SALE_MASTER_ID = Y.SALE_MASTER_ID
	            INNER JOIN PRODUCT_MASTER Z ON Y.ITEM_ID = Z.PM_ID
	            WHERE X.[DATE] <= GETDATE() AND Y.ITEM_ID = B.PM_ID 
            ),0)  +
            ISNULL((
		        SELECT SUM(QTY) 
		        FROM PURCHASE_RETURN_MASTER X
		        INNER JOIN PURCHASE_RETURN_DETAIL Y ON X.ID = Y.PURCHASE_RETURN_MASTER_ID
		        INNER JOIN PRODUCT_MASTER Z ON Y.MATERIAL_ID = Z.PM_ID
		        WHERE X.[DATE] <= GETDATE() AND Y.MATERIAL_ID = B.PM_ID 
	        ),0) +
            ISNULL((
		        SELECT SUM(X.QTY) 
				FROM INVENTORY_ADJUSTMENTS X
				INNER JOIN PRODUCT_MASTER Z ON X.MATERIAL_ID = Z.PM_ID
				WHERE X.[DATE] <= GETDATE() AND X.MATERIAL_ID = B.PM_ID 
				AND X.ADD_LESS = 'D'
	        ),0) AS [OUT]
            FROM PRODUCT_MASTER B
            INNER JOIN PRODUCT_CATEGORY C ON C.P_CATEGORY_ID = B.BRAND_ID 
            WHERE B.PM_ID = '" + productId + "' ) X";

            try
            {
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                cmd = new SqlCommand(query, conn);
                cmd.CommandTimeout = 0;
                dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    if (dr.Read())
                    {
                        return Convert.ToDecimal(dr["BALANCE"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.ToString(), ":: Error ::");
            }
            finally
            {
                conn.Close();
            }
            return 0;
        }

            public void LoadCustomers(ComboBox cmbCustomer)
        {
            try
            {
                query = @"SELECT '0' AS [id],'--SELECT CUSTOMER--' AS [name]
                UNION
                SELECT COA_ID AS [id],COA_NAME AS [name] FROM COA WHERE STAT = 0";
                LoadComboData(cmbCustomer, query);
            }
            catch (Exception ex) { ShowMessageBox(ex.ToString(), "Exception"); }
        }
        public void LoadProducts(ComboBox cmbItems)
        {
            try
            {
                query = @"SELECT '0' AS [id],'--SELECT PRODUCT--' AS [name]
                UNION ALL
                SELECT PM_ID AS [id],PRODUCT_NAME AS [name] 
                FROM PRODUCT_MASTER";
                LoadComboData(cmbItems, query);
            }
            catch (Exception ex) { ShowMessageBox(ex.ToString(), "Exception"); }
        }
        public void LoadSalesReferenceAccount(ComboBox cmb)
        {
            try
            {
                query = @" SELECT '0' AS [id],'' AS [name]
                UNION ALL
                SELECT REFERENCE AS [id],REFERENCE AS [name] 
                FROM SALE_MASTER
                GROUP BY REFERENCE";
                LoadComboData(cmb, query);
            }
            catch (Exception ex) { ShowMessageBox(ex.ToString(), "Exception"); }
        }
        public void LoadServices(ComboBox cmb)
        {
            try
            {
                query = @"SELECT '0' AS [id],'*--SELECT SERVICE--*' AS [name]
                UNION ALL
                SELECT ID AS [id],SERVICE_TYPE AS [name] 
                FROM SERVICE_TYPES
                ORDER BY NAME";
                LoadComboData(cmb, query);
            }
            catch (Exception ex) { ShowMessageBox(ex.ToString(), "Exception"); }
        }
        //   public void LoadallProducts(ComboBox cmb)
        // {
        //    try
        //   {
        //    query = @"SELECT '0' AS [id], '--SELECT Products--' AS [name] 
        //    UNION ALL 
        //   SELECT PRODUCT_ID AS [id], PRODUCT_NAME AS [name] FROM PRODUCT_MASTER WHERE stat = 0";
        //  LoadComboData(cmb, query);
        // }
        // catch (Exception ex) { ShowMessageBox(ex.ToString(), "Exception"); }
        //  }
        public void LoadAllAccounts(ComboBox cmbAccounts)
        {
            try
            {
                query = @"SELECT '0' AS [id],'--SELECT ACCOUNT--' AS [name]
                UNION ALL
                SELECT COA_ID AS [ID],COA_NAME AS [NAME] 
                FROM COA WHERE STAT = 0";
                LoadComboData(cmbAccounts, query);


               
            }
            catch (Exception ex) { ShowMessageBox(ex.ToString(), "Exception"); }
        }

        public void LoadAllBankss(ComboBox cmbBanks)
        {
            try
            {
                query = @" SELECT '0' AS [id],'--SELECT BANK--' AS [name]
                UNION ALL
                SELECT COA_ID AS [ID],COA_NAME AS [NAME] 
                FROM COA WHERE STAT = 0  AND CA_ID = 5";
                LoadComboData(cmbBanks, query);



            }
            catch (Exception ex) { ShowMessageBox(ex.ToString(), "Exception"); }
        }

        public void LoadNewProducts(ComboBox cmbItems)
        {
            try
            {
                query = @"SELECT '0' AS [id],'--SELECT PRODUCT--' AS [name]
                UNION ALL
                SELECT PM_ID AS [ID],PRODUCT_NAME AS [PRODUCT NAME] 
                FROM PRODUCT_MASTER";
                LoadComboData(cmbItems, query);
            }
            catch (Exception ex) { ShowMessageBox(ex.ToString(), "Exception"); }
        }

        public void LoadSoProducts(ComboBox cmbSoProducts, int soId)
        {
            try
            {
                query = @"SELECT A.RATE AS [id],B.PRODUCT_NAME AS [name] 
                FROM SO_MATERIAL_P_DETAIL A
                INNER JOIN PRODUCT_MASTER B ON A.PRODUCT_ID = B.PM_ID
                WHERE A.MPM_ID = '" + soId + "'";
                LoadComboData(cmbSoProducts, query);
            }
            catch (Exception ex) { ShowMessageBox(ex.ToString(), "Exception"); }
        }
        public void LoadProductRaw(DataGridView dgv, int productId, decimal qty)
        {
            try
            {
                query = @"SELECT A.MATERIAL_ID,B.MATERIAL_NAME,A.[WEIGHT] AS [QTY],
                (SELECT ISNULL(SUM(STOCK_IN),0) - ISNULL(SUM(STOCK_OUT),0) FROM MATERIAL_ITEM_LEDGER WHERE MATERIAL_ID = B.MATERIAL_ID) - 
                (SELECT ISNULL(SUM(X.QTY),0) FROM JOB_ORDER_MATERIALS X 
	                INNER JOIN JOB_ORDER_MASTER Y ON X.JOB_ORDER_MASTER_ID = Y.JOB_ORDER_MASTER_ID 
	                WHERE X.MATERIAL_ID = B.MATERIAL_ID  AND Y.[STATUS] = '0') AS [AVAILABLE QTY]
                FROM PRODUCT_DETAILS A
                INNER JOIN MATERIALS B ON A.MATERIAL_ID = B.MATERIAL_ID
                WHERE PM_ID = '" + productId + "'";
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                cmd = new SqlCommand(query, conn);
                cmd.CommandTimeout = 0;
                dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        //    decimal qtyInGrid = 0;
                        //qtyInGrid = dgv.Rows.Cast<DataGridViewRow>()
                        //    .Where(x => x.Cells["rawId"].Value.ToString().Equals(dr["MATERIAL_ID"].ToString()))
                        //    .Sum(t => Convert.ToDecimal(t.Cells["rawQty"].Value));

                        //dgv.Rows.Add(dr["MATERIAL_ID"].ToString(),productId,dr["MATERIAL_NAME"].ToString(),
                        //    (Convert.ToDecimal(dr["QTY"].ToString()) * qty), (Convert.ToDecimal(dr["AVAILABLE QTY"].ToString()) - qtyInGrid),
                        //        (Convert.ToDecimal(dr["AVAILABLE QTY"].ToString()) - qtyInGrid) - (Convert.ToDecimal(dr["QTY"].ToString()) * qty));

                        dgv.Rows.Add(dr["MATERIAL_ID"].ToString(), productId, dr["MATERIAL_NAME"].ToString(),
                            (Convert.ToDecimal(dr["QTY"].ToString()) * qty));

                        //foreach (DataGridViewRow row in dgv.Rows)
                        //{
                        //    if (Convert.ToDecimal(row.Cells["difference"].Value) < 0)
                        //    {
                        //        row.DefaultCellStyle.BackColor = Color.Red;
                        //    }
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.ToString(), ":: Error ::");
            }
            finally
            {
                conn.Close();
            }
        }

        public void LoadProductionProduct(DataGridView dgv, int productionId)
        {
            try
            {
                query = @"SELECT B.PRODUCT_MASTER_ID,C.PRODUCT_NAME,B.QTY
                FROM PRODUCTION_DETAIL B
                INNER JOIN PRODUCT_MASTER C ON B.PRODUCT_MASTER_ID = C.PM_ID
                WHERE B.PRODUCTION_MASTER_ID = '" + productionId + "'";

                /* query = @"SELECT B.PRODUCT_MASTER_ID,C.PRODUCT_NAME,B.QTY
                FROM PRODUCTION_DETAIL B
                INNER JOIN PRODUCT_MASTER C ON B.PRODUCT_MASTER_ID = C.PM_ID
                WHERE B.PRODUCTION_MASTER_ID = '"+productionId+"'";
    */
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                cmd = new SqlCommand(query, conn);
                cmd.CommandTimeout = 0;
                dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        dgv.Rows.Add(dr["PRODUCT_MASTER_ID"].ToString(), dr["PRODUCT_NAME"].ToString(), dr["QTY"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.ToString(), ":: Error ::");
            }
            finally
            {
                conn.Close();
            }
        }

        public void LoadJobOrderProduct(DataGridView dgv, int jobOrderId)
        {
            try
            {
                query = @"SELECT A.PRODUCT_MASTER_ID,B.PRODUCT_NAME,A.QTY 
                FROM JOB_ORDER_PRODUCTS A
                INNER JOIN PRODUCT_MASTER B ON A.PRODUCT_MASTER_ID = B.PM_ID
                WHERE A.JOB_ORDER_MASTER_ID = '" + jobOrderId + @"'";
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                cmd = new SqlCommand(query, conn);
                cmd.CommandTimeout = 0;
                dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        dgv.Rows.Add(dr["PRODUCT_MASTER_ID"].ToString(), dr["PRODUCT_NAME"].ToString(), dr["QTY"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.ToString(), ":: Error ::");
            }
            finally
            {
                conn.Close();
            }
        }

        public void LoadJobOrderRaw(DataGridView dgv, int jobOrderId)
        {
            try
            {
                query = @"SELECT A.MATERIAL_ID,B.MATERIAL_NAME,A.[QTY],A.JOB_ORDER_PRODUCT_ID,
                (SELECT ISNULL(SUM(STOCK_IN),0) - ISNULL(SUM(STOCK_OUT),0) FROM MATERIAL_ITEM_LEDGER WHERE MATERIAL_ID = B.MATERIAL_ID) - 
                (SELECT ISNULL(SUM(X.QTY),0) FROM JOB_ORDER_MATERIALS X 
                INNER JOIN JOB_ORDER_MASTER Y ON X.JOB_ORDER_MASTER_ID = Y.JOB_ORDER_MASTER_ID 
                WHERE X.MATERIAL_ID = B.MATERIAL_ID AND Y.[STATUS] = '0' AND Y.JOB_ORDER_MASTER_ID <> '" + jobOrderId + @"') AS [AVAILABLE QTY]
                FROM JOB_ORDER_MATERIALS A
                INNER JOIN MATERIALS B ON A.MATERIAL_ID = B.MATERIAL_ID
                WHERE A.JOB_ORDER_MASTER_ID = '" + jobOrderId + @"'";
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                cmd = new SqlCommand(query, conn);
                cmd.CommandTimeout = 0;
                dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        decimal qtyInGrid = 0;
                        qtyInGrid = dgv.Rows.Cast<DataGridViewRow>()
                            .Where(x => x.Cells["rawId"].Value.ToString().Equals(dr["MATERIAL_ID"].ToString()))
                            .Sum(t => Convert.ToDecimal(t.Cells["rawQty"].Value));

                        dgv.Rows.Add(dr["MATERIAL_ID"].ToString(), dr["JOB_ORDER_PRODUCT_ID"].ToString(), dr["MATERIAL_NAME"].ToString(),
                            (Convert.ToDecimal(dr["QTY"].ToString())), (Convert.ToDecimal(dr["AVAILABLE QTY"].ToString()) - qtyInGrid),
                                (Convert.ToDecimal(dr["AVAILABLE QTY"].ToString()) - qtyInGrid));
                        // - (Convert.ToDecimal(dr["QTY"].ToString()))
                        foreach (DataGridViewRow row in dgv.Rows)
                        {
                            if (Convert.ToDecimal(row.Cells["difference"].Value) < 0)
                            {
                                row.DefaultCellStyle.BackColor = Color.Red;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.ToString(), ":: Error ::");
            }
            finally
            {
                conn.Close();
            }
        }

        public void LoadQuotationDetail(DataGridView dgv, int id)
        {
            try
            {
                dgv.Rows.Clear();
                query = @" SELECT A.PRODUCT_ID AS [PRODUCT_ID], B.PRODUCT_NAME AS [PRODUCT], A.QTY, A.RATE, (A.QTY*A.RATE) AS [TOTAL]
                FROM SALES_ORDER_PRODUCT_DETAILS A
                INNER JOIN PRODUCT_MASTER B ON A.PRODUCT_ID = B.PM_ID
                WHERE A.SOPM_ID = '" + id + @"'";

                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                cmd = new SqlCommand(query, conn);
                cmd.CommandTimeout = 0;
                dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        dgv.Rows.Add(dr["PRODUCT_ID"].ToString(), dr["PRODUCT"].ToString(), dr["QTY"].ToString(),
                                         dr["RATE"].ToString(), dr["TOTAL"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.ToString(), ":: Error ::");
            }
            finally
            {
                conn.Close();
            }
        }

        public void LoadPurchasesOrderDetail(DataGridView dgv, int poId)
        {
            try
            {
                dgv.Rows.Clear();
                query = @"SELECT A.MATERIAL_ID AS [PRODUCT_ID], B.PRODUCT_NAME AS [PRODUCT], A.QTY, A.RATE, (A.QTY*A.RATE) AS [TOTAL]
                FROM PURCHASES_ORDER_DETAILS A
                INNER JOIN PRODUCT_MASTER B ON A.MATERIAL_ID = B.PM_ID
                WHERE A.PO_ID = '" + poId + @"'";

                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                cmd = new SqlCommand(query, conn);
                cmd.CommandTimeout = 0;
                dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        dgv.Rows.Add(dr["PRODUCT_ID"].ToString(), dr["PRODUCT"].ToString(), dr["QTY"].ToString(),
                                         dr["RATE"].ToString(), dr["TOTAL"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.ToString(), ":: Error ::");
            }
            finally
            {
                conn.Close();
            }
        }

        public void LoadPurchasesReturnDetail(DataGridView dgv, int id)
        {
            try
            {
                dgv.Rows.Clear();
                query = @" SELECT A.MATERIAL_ID, B.PRODUCT_NAME AS [PRODUCT], A.QTY, A.RATE, (A.QTY*A.RATE) AS [TOTAL]
                FROM PURCHASE_RETURN_DETAIL A
                INNER JOIN PRODUCT_MASTER B ON A.MATERIAL_ID = B.PM_ID
                WHERE A.PURCHASE_RETURN_MASTER_ID = '" + id + @"'";


                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                cmd = new SqlCommand(query, conn);
                cmd.CommandTimeout = 0;
                dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        dgv.Rows.Add(dr["MATERIAL_ID"].ToString(), dr["PRODUCT"].ToString(), dr["QTY"].ToString(),
                                         dr["RATE"].ToString(), dr["TOTAL"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.ToString(), ":: Error ::");
            }
            finally
            {
                conn.Close();
            }
        }

      //  public void LoadSalesDetail(DataGridView dgv, int rawId)
       /* {
            try
            {
                dgv.Rows.Clear();
                 query = @" SELECT A.ITEM_ID, B.PRODUCT_NAME AS [PRODUCT], A.QTY, A.RATE, (A.QTY*A.RATE) AS [TOTAL]
                FROM SALE_DETAIL A
                INNER JOIN PRODUCT_MASTER B ON A.ITEM_ID = B.PM_ID
               WHERE A.SALE_MASTER_ID = '" + rawId + @"'";


      //        query = @"SELECT A.ITEM_ID, B.PRODUCT_NAME AS [PRODUCT], A.QTY, A.RATE, 
        //         (A.QTY * A.RATE) AS [TOTAL], 
        //         (A.QTY * A.RATE) * (1 + A.GST / 100) AS [TOTAL_WITH_GST]
       //   FROM SALE_DETAIL A
       //   INNER JOIN PRODUCT_MASTER B ON A.ITEM_ID = B.PM_ID
       //   WHERE A.SALE_MASTER_ID = '" + rawId + @"'";

                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                cmd = new SqlCommand(query, conn);
                cmd.CommandTimeout = 0;
                dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {

                        dgv.Rows.Add(dr["ITEM_ID"].ToString(), dr["PRODUCT"].ToString(), dr["QTY"].ToString(),
                                         dr["RATE"].ToString(), dr["TOTAL"].ToString());
                            
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.ToString(), ":: Error ::");
            }
            finally
            {
                conn.Close();
            }
        }
        */

     public void LoadSalesDetail(DataGridView dgv, int rawId)
            {
                   try
                        {
                                dgv.Rows.Clear();


                                                    query = @"	SELECT A.ITEM_ID,   
                                                    B.PRODUCT_NAME AS [PRODUCT], 
                                                    A.QTY,
                                                    A.RATE, 
                                                    (A.QTY * A.RATE) AS [TOTAL]
                                                    FROM SALE_DETAIL A
                                                    INNER JOIN PRODUCT_MASTER B ON A.ITEM_ID = B.PM_ID
                                                   WHERE A.SALE_MASTER_ID = '" + rawId + @"'";


                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@rawId", rawId);  // Use parameterized query to prevent SQL injection
                cmd.CommandTimeout = 0;
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        // Add TOTAL_WITH_GST to the DataGridView
                        dgv.Rows.Add(dr["ITEM_ID"].ToString(),dr["PRODUCT"].ToString(),dr["QTY"].ToString(),
                        dr["RATE"].ToString(),dr["TOTAL"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.ToString(), ":: Error ::");
            }
            finally
            {
                conn.Close();
            }
        }

        public void LoadSalesExpenses(DataGridView dgv, int id)
        {
            try
            {
                dgv.Rows.Clear();


                query = @"SELECT A.[DATE],
	            A.VENDOR_ID,
	            C.COA_NAME AS [VENDOR],
	            A.SERVICE_ID,
	            B.SERVICE_TYPE AS [SERVICE], 
	            A.[DESCRIPTION],
	            A.[TYPE], 
	            A.AMOUNT
	            FROM SALE_EXPENSE A
	            INNER JOIN SERVICE_TYPES B ON A.SERVICE_ID = B.ID
	            INNER JOIN COA C ON A.VENDOR_ID = C.COA_ID
	            WHERE A.SALE_MASTER_ID = '" + id + @"'";


                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);  // Use parameterized query to prevent SQL injection
                cmd.CommandTimeout = 0;
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        dgv.Rows.Add(dr["DATE"].ToString(), dr["VENDOR_ID"].ToString(), dr["VENDOR"].ToString(),
                        dr["SERVICE_ID"].ToString(), dr["SERVICE"].ToString(), dr["DESCRIPTION"].ToString(), dr["AMOUNT"].ToString(), dr["TYPE"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.ToString(), ":: Error ::");
            }
            finally
            {
                conn.Close();
            }
        }

        public void LoadSalesReturnDetail(DataGridView dgv, int id)
        {
            try
            {
                dgv.Rows.Clear();


                query = @"SELECT A.ITEM_ID,   
                                                   B.PRODUCT_NAME AS [PRODUCT], 
                                                   A.QTY,
                                                   A.RATE, 
                                                   (A.QTY * A.RATE) AS [TOTAL]
                                                   FROM SALE_RETURN_DETAIL A
                                                   INNER JOIN PRODUCT_MASTER B ON A.ITEM_ID = B.PM_ID
                                                   WHERE A.SALE_RETURN_MASTER_ID = '" + id + @"'";


                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@rawId", id);  // Use parameterized query to prevent SQL injection
                cmd.CommandTimeout = 0;
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        // Add TOTAL_WITH_GST to the DataGridView
                        dgv.Rows.Add(dr["ITEM_ID"].ToString(), dr["PRODUCT"].ToString(), dr["QTY"].ToString(),
                        dr["RATE"].ToString(), dr["TOTAL"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.ToString(), ":: Error ::");
            }
            finally
            {
                conn.Close();
            }
        }

        public void LoadPurchasesDetail(DataGridView dgv, int rawId)
        {
            try
            {
                dgv.Rows.Clear();
                query = @"SELECT A.MATERIAL_ID, B.PRODUCT_NAME AS [PRODUCT], A.QTY, A.RATE, (A.QTY*A.RATE) AS [TOTAL]
                  FROM PURCHASE_DETAIL A
                  INNER JOIN PRODUCT_MASTER B ON A.MATERIAL_ID = B.PM_ID
                  WHERE A.PURCHASE_MASTER_ID = '" + rawId + @"'";


                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                cmd = new SqlCommand(query, conn);
                cmd.CommandTimeout = 0;
                dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        dgv.Rows.Add(dr["MATERIAL_ID"].ToString(), dr["PRODUCT"].ToString(), dr["QTY"].ToString(),
                                         dr["RATE"].ToString(), dr["TOTAL"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.ToString(), ":: Error ::");
            }
            finally
            {
                conn.Close();
            }
        }

        public void PrintSalesInvoice(string invoiceNo)
        {
           try
            {
                nds.Tables["GeneralOrderSupply"].Clear();

                query = @" SELECT A.DATE,A.BILL_NO,D.COA_NAME AS [CUSTOMER],C.PRODUCT_NAME,
                B.QTY,B.RATE,B.GST,
                (B.QTY * B.RATE) + ((B.QTY * B.RATE) / 100) AS [NET TOTAL]
                FROM SALE_MASTER A
                INNER JOIN SALE_DETAIL B ON A.SALE_MASTER_ID = B.SALE_MASTER_ID
                INNER JOIN PRODUCT_MASTER C ON B.ITEM_ID = C.PM_ID
                INNER JOIN COA D ON A.CUSTOMER_ID = D.COA_ID
                WHERE A.INVOICE_NO = '"+invoiceNo+"'";

                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                cmd = new SqlCommand(query, conn);
                cmd.CommandTimeout = 0;
                dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        dataR = nds.Tables["GeneralOrderSupply"].NewRow();
                        dataR["qty"] = Convert.ToDecimal(dr["QTY"].ToString());
                        dataR["invoice"] = dr["BILL_NO"].ToString();
                        dataR["deliveryChallan"] = dr["BILL_NO"].ToString();
                        dataR["rate"] = Convert.ToDecimal(dr["RATE"].ToString());
                        dataR["fromDate"] = Convert.ToDateTime(dr["DATE"].ToString());
                        dataR["particulars"] = dr["PRODUCT_NAME"].ToString();
                        dataR["gstPercentage"] = Convert.ToDecimal(dr["GST"].ToString());
                        dataR["gstAmount"] = (((Convert.ToDecimal(dr["QTY"].ToString()) * Convert.ToDecimal(dr["RATE"].ToString()))) * (Convert.ToDecimal(dr["GST"].ToString()) / 100));
                        dataR["amount"] = Convert.ToDecimal(dr["NET TOTAL"].ToString());
                        dataR["customer"] = dr["CUSTOMER"].ToString();
                        nds.Tables["GeneralOrderSupply"].Rows.Add(dataR);
                    }

                    rpt = new ERP_Maaz_Oil.Forms.Reporting.frmReports();
                    rpt.GenerateReport("SalesInvoice", nds);
                    rpt.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.ToString(), ":: Error ::");
            }
            finally
            {
                conn.Close();
            }
        }

        public void PrintServiceSalesInvoice(string invoiceNo)
        {
            try
            {
                nds.Tables["GeneralOrderSupply"].Clear();

                query = @" SELECT A.DATE,A.BILL_NO,D.COA_NAME AS [CUSTOMER],C.PRODUCT_NAME,
                B.QTY,B.RATE,B.GST,
                (B.QTY * B.RATE) + ((B.QTY * B.RATE) / 100) AS [NET TOTAL]
                FROM SALE_MASTER A
                INNER JOIN SALE_DETAIL B ON A.SALE_MASTER_ID = B.SALE_MASTER_ID
                INNER JOIN PRODUCT_MASTER C ON B.ITEM_ID = C.PM_ID
                INNER JOIN COA D ON A.CUSTOMER_ID = D.COA_ID
                WHERE A.INVOICE_NO = '" + invoiceNo + "'";

                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                cmd = new SqlCommand(query, conn);
                cmd.CommandTimeout = 0;
                dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        dataR = nds.Tables["GeneralOrderSupply"].NewRow();
                        dataR["qty"] = Convert.ToDecimal(dr["QTY"].ToString());
                        dataR["invoice"] = dr["BILL_NO"].ToString();
                        dataR["deliveryChallan"] = dr["BILL_NO"].ToString();
                        dataR["rate"] = Convert.ToDecimal(dr["RATE"].ToString());
                        dataR["fromDate"] = Convert.ToDateTime(dr["DATE"].ToString());
                        dataR["particulars"] = dr["PRODUCT_NAME"].ToString();
                        dataR["gstPercentage"] = Convert.ToDecimal(dr["GST"].ToString());
                        dataR["gstAmount"] = (((Convert.ToDecimal(dr["QTY"].ToString()) * Convert.ToDecimal(dr["RATE"].ToString()))) * (Convert.ToDecimal(dr["GST"].ToString()) / 100));
                        dataR["amount"] = Convert.ToDecimal(dr["NET TOTAL"].ToString());
                        dataR["customer"] = dr["CUSTOMER"].ToString();
                        nds.Tables["GeneralOrderSupply"].Rows.Add(dataR);
                    }

                    rpt = new ERP_Maaz_Oil.Forms.Reporting.frmReports();
                    rpt.GenerateReport("SalesInvoice", nds);
                    rpt.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.ToString(), ":: Error ::");
            }
            finally
            {
                conn.Close();
            }
        }

        public void LoadProductSalesInvoice(ComboBox cmbSO, int customer, bool isEdit)
        {
            try
            {
                query = @" SELECT '0' AS [id], '--SELECT S.I--' AS [name] UNION ALL SELECT SALE_MASTER_ID as [id],BILL_NO as [name]
                    FROM SALE_MASTER
                    WHERE CUSTOMER_ID = '" + customer + "'";
                //if (isEdit == true)
                //{
                //    query = @" SELECT '0' AS [id], '--SELECT S.O--' AS [name] UNION ALL SELECT SOPM_ID as [id],INVOICE_NO as [name]
                //    FROM SALES_ORDER_PRODUCT_MASTER
                //    WHERE CUSTOMER_ID = '" + customer + "'";
                //}
                //else
                //{
                //    query = @" SELECT '0' AS [id], '--SELECT S.O--' AS [name] UNION ALL SELECT SO_ID as [id],INVOICE_NO as [name]
                //    FROM SALES_ORDER_PRODUCT_MASTER
                //    WHERE CUSTOMER_ID = '" + customer + "' AND [STATUS] = '0' ";
                //}
                LoadComboData(cmbSO, query);
            }
            catch (Exception ex) { ShowMessageBox(ex.ToString(), "Exception"); }
        }

        public void LoadProductSalesOrder(ComboBox cmbSO, int customer, bool isEdit)
        {
            try
            {
                query = @" SELECT '0' AS [id], '--SELECT S.O--' AS [name] UNION ALL SELECT SOPM_ID as [id],INVOICE_NO as [name]
                    FROM SALES_ORDER_PRODUCT_MASTER
                    WHERE CUSTOMER_ID = '" + customer + "'";
                //if (isEdit == true)
                //{
                //    query = @" SELECT '0' AS [id], '--SELECT S.O--' AS [name] UNION ALL SELECT SOPM_ID as [id],INVOICE_NO as [name]
                //    FROM SALES_ORDER_PRODUCT_MASTER
                //    WHERE CUSTOMER_ID = '" + customer + "'";
                //}
                //else
                //{
                //    query = @" SELECT '0' AS [id], '--SELECT S.O--' AS [name] UNION ALL SELECT SO_ID as [id],INVOICE_NO as [name]
                //    FROM SALES_ORDER_PRODUCT_MASTER
                //    WHERE CUSTOMER_ID = '" + customer + "' AND [STATUS] = '0' ";
                //}
                LoadComboData(cmbSO, query);
            }
            catch (Exception ex) { ShowMessageBox(ex.ToString(), "Exception"); }
        }

        public void LoadProductPurchaseOrder(ComboBox cmbPO, int supplier, bool isEdit)
        {
            try
            {
                query = @" SELECT '0' AS [id], '--SELECT P.O--' AS [name] UNION ALL SELECT PO_ID as [id],PO_NUMBER as [name]
                    FROM PURCHASES_ORDER
                    WHERE SUPPLIER_ID = '" + supplier + "'";
                //if (isEdit == true)
                //{
                //    query = @" SELECT '0' AS [id], '--SELECT P.O--' AS [name] 
                //    UNION ALL SELECT PO_ID as [id],PO_NUMBER as [name]
                //    FROM PURCHASES_ORDER
                //    WHERE SUPPLIER_ID = '" + supplier + "'";
                //}
                //else
                //{
                //    query = @" SELECT '0' AS [id], '--SELECT P.O--' AS [name] UNION ALL SELECT PO_ID as [id],PO_NUMBER as [name]
                //    FROM PURCHASES_ORDER
                //    WHERE SUPPLIER_ID = '" + supplier + "' AND [STATUS] = '0' ";
                //}
                LoadComboData(cmbPO, query);
            }
            catch (Exception ex) { ShowMessageBox(ex.ToString(), "Exception"); }
        }

        public void LoadIssuanceDetail(DataGridView dgv, int issuanceId)
        {
            try
            {
                dgv.Rows.Clear();
                query = @"SELECT A.ITEM_ID,A.ITEM_TYPE,B.MATERIAL_NAME AS [ITEM NAME],A.QTY,A.RATE,(A.QTY*A.RATE) AS [TOTAL],'' AS [CODE]
                FROM ISSUANCE_DETAIL A
                INNER JOIN MATERIALS B ON A.ITEM_ID = B.MATERIAL_ID
                WHERE A.ISSUANCE_MASTER_ID = '" + issuanceId + @"' AND 
                A.ITEM_TYPE = 'R'
                UNION ALL
                SELECT A.ITEM_ID,A.ITEM_TYPE,B.PRODUCT_NAME+':'+B.PRODUCT_CODE AS [ITEM NAME],A.QTY,A.RATE,(A.QTY*A.RATE) AS [TOTAL],B.PRODUCT_CODE AS [CODE]
                FROM ISSUANCE_DETAIL A
                INNER JOIN PRODUCT_MASTER B ON A.ITEM_ID = B.PM_ID
                WHERE A.ISSUANCE_MASTER_ID = '" + issuanceId + @"' AND 
                A.ITEM_TYPE = 'P'";
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                cmd = new SqlCommand(query, conn);
                cmd.CommandTimeout = 0;
                dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        dgv.Rows.Add(dr["ITEM_ID"].ToString(), dr["ITEM_TYPE"].ToString(), dr["ITEM NAME"].ToString().Substring(dr["ITEM NAME"].ToString().LastIndexOf(':') + 1),
                            dr["ITEM NAME"].ToString(), dr["QTY"].ToString(),
                            dr["RATE"].ToString(), dr["TOTAL"].ToString(), dr["CODE"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.ToString(), ":: Error ::");
            }
            finally
            {
                conn.Close();
            }
        }


        public void LoadQuotationsDetail(DataGridView dgv, int QUOTATIONId)
        {

            try
            {

                dgv.Rows.Clear();

                query = @"SELECT A.ITEM_ID,  A.ITEM_TYPE, B.MATERIAL_NAME AS [ITEM NAME], A.QTY, A.RATE, (A.QTY * A.RATE) AS [TOTAL]
          FROM QUOTATION_DETAIL A
          INNER JOIN MATERIALS B ON A.ITEM_ID = B.MATERIAL_ID
          WHERE A.QUOTATION_MASTER_ID = '" + QUOTATIONId + @"'
          UNION ALL
          SELECT A.ITEM_ID,  A.ITEM_TYPE, B.PRODUCT_NAME AS [ITEM NAME], A.QTY, A.RATE, (A.QTY * A.RATE) AS [TOTAL]
          FROM QUOTATION_DETAIL A
          INNER JOIN PRODUCT_MASTER B ON A.ITEM_ID = B.PM_ID
          WHERE A.QUOTATION_MASTER_ID = '" + QUOTATIONId + @"'";

                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                cmd = new SqlCommand(query, conn);
                cmd.CommandTimeout = 0;

                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        dgv.Rows.Add(
                            dr["ITEM_ID"].ToString(),  
                           dr["ITEM_TYPE"].ToString(),                           
                           dr["ITEM NAME"].ToString(),       // Item name (from MATERIALS or PRODUCT_MASTER)
                            dr["QTY"].ToString(),             // Quantity
                            dr["RATE"].ToString(),            // Rate
                            dr["TOTAL"].ToString()            // Total (QTY * RATE)
                        );
                    }
                }                }
            catch (Exception ex)
            {
                ShowMessageBox(ex.ToString(), ":: Error ::");
}
            finally
            {
                conn.Close();
            }
        }



    
    //    public void LoadSalesDetail(DataGridView dgv, int saleId)
    //    {

  
    //        try
    //        { 
    //            dgv.Rows.Clear();


    //            query = @"SELECT A.ITEM_ID, A.ITEM_TYPE, B.MATERIAL_NAME AS [ITEM NAME], A.QTY, A.RATE, (A.QTY*A.RATE) AS [TOTAL], '' AS [CODE]
    //           FROM SALE_DETAIL A
    //           INNER JOIN MATERIALS B ON A.ITEM_ID = B.MATERIAL_ID
    //           WHERE A.SALE_MASTER_ID = '" + saleId + @"'
    //           UNION ALL
    //           SELECT A.ITEM_ID, A.ITEM_TYPE, B.PRODUCT_NAME AS [ITEM NAME], A.QTY, A.RATE, (A.QTY*A.RATE) AS [TOTAL], B.PRODUCT_CODE AS [CODE]
    //           FROM SALE_DETAIL A
    //           INNER JOIN PRODUCT_MASTER B ON A.ITEM_ID = B.PM_ID
    //           WHERE A.SALE_MASTER_ID = '" + saleId + @"'";
    //           if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
    //           cmd = new SqlCommand(query, conn);
    //           cmd.CommandTimeout = 0;
    //           dr = cmd.ExecuteReader();
    //           if (dr.HasRows == true)
    //           {
    //               while (dr.Read())
    //               {
    //                   dgv.Rows.Add(
    //                       dr["ITEM_ID"].ToString(),

    //                       dr["ITEM_TYPE"].ToString(),
    //                       dr["ITEM NAME"].ToString(),
    //                       dr["QTY"].ToString(),
    //                       dr["RATE"].ToString(),
    //                       dr["TOTAL"].ToString(),
    //                       dr["CODE"].ToString());
           
    //}}}
    //catch (Exception ex)
    //        {
    //            ShowMessageBox(ex.ToString(), ":: Error ::");
    //        }
    //        finally
    //        {
    //            conn.Close();
    //        }
    //    }








        

        //public void LoadSalesReturnDetail(DataGridView dgv, int saleReturnId)
        //{
        //    try
        //    {
        //        dgv.Rows.Clear();
        //        query = @"SELECT A.ITEM_ID, B.MATERIAL_NAME AS [ITEM NAME], A.QTY, A.RATE, (A.QTY*A.RATE) AS [TOTAL], '' AS [CODE]
        //        FROM SALE_RETURN_DETAIL A
        //        INNER JOIN MATERIALS B ON A.ITEM_ID = B.MATERIAL_ID
        //        WHERE A.SALE_RETURN_MASTER_ID = '" + saleReturnId + @"'
        //        UNION ALL
        //        SELECT A.ITEM_ID, B.PRODUCT_NAME AS [ITEM NAME], A.QTY, A.RATE, (A.QTY*A.RATE) AS [TOTAL], B.PRODUCT_CODE AS [CODE]
        //        FROM SALE_RETURN_DETAIL A
        //        INNER JOIN PRODUCT_MASTER B ON A.ITEM_ID = B.PM_ID
        //        WHERE A.SALE_RETURN_MASTER_ID = '" + saleReturnId + @"'";
        //        if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
        //        cmd = new SqlCommand(query, conn);
        //        cmd.CommandTimeout = 0;
        //        dr = cmd.ExecuteReader();
        //        if (dr.HasRows == true)
        //        {
        //            while (dr.Read())
        //            {
        //                dgv.Rows.Add(
        //                    dr["ITEM_ID"].ToString(),
        //                    dr["ITEM NAME"].ToString(),
        //                    dr["QTY"].ToString(),
        //                    dr["RATE"].ToString(),
        //                    dr["TOTAL"].ToString(),
        //                    dr["CODE"].ToString());
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ShowMessageBox(ex.ToString(), ":: Error ::");
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //}

       
        public void LoadJobMaterials(DataGridView dgv, int jobId)
        {
            try
            {
                query = @"SELECT A.MATERIAL_ID,A.JOB_ORDER_PRODUCT_ID,B.MATERIAL_NAME,A.QTY 
                FROM JOB_ORDER_MATERIALS A
                INNER JOIN MATERIALS B ON A.MATERIAL_ID = B.MATERIAL_ID
                WHERE A.JOB_ORDER_MASTER_ID = '"+jobId+"'";
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                cmd = new SqlCommand(query, conn);
                cmd.CommandTimeout = 0;
                dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        dgv.Rows.Add(dr["MATERIAL_ID"].ToString(), dr["JOB_ORDER_PRODUCT_ID"].ToString(), dr["MATERIAL_NAME"].ToString(), dr["QTY"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.ToString(), ":: Error ::");
            }
            finally
            {
                conn.Close();
            }
        }

        public void LoadJobProducts(DataGridView dgv, int jobId)
        {
            try
            {
                query = @"SELECT A.PRODUCT_MASTER_ID,B.PRODUCT_NAME,A.QTY 
                FROM JOB_ORDER_PRODUCTS A
                INNER JOIN PRODUCT_MASTER B ON A.PRODUCT_MASTER_ID = B.PM_ID
                WHERE A.JOB_ORDER_MASTER_ID = '"+jobId+"'";
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                cmd = new SqlCommand(query, conn);
                cmd.CommandTimeout = 0;
                dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        dgv.Rows.Add(dr["PRODUCT_MASTER_ID"].ToString(),dr["PRODUCT_NAME"].ToString(), dr["QTY"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.ToString(), ":: Error ::");
            }
            finally
            {
                conn.Close();
            }
        }
        public void LoadSOProducts(DataGridView dgv,int soId)
        {
            try
            {
                query = @"select a.PRODUCT_ID,b.PRODUCT_NAME,a.QTY,a.RATE,a.[WEIGHT],'KGS' as [unit],(a.QTY * a.RATE) as [total],
                'P' as [type]
                from SALES_ORDER_PRODUCT_DETAILS a
                inner join PRODUCT_MASTER b on a.PRODUCT_ID = b.PM_ID
                where a.SOPM_ID = '" + soId+"'";
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                cmd = new SqlCommand(query, conn);
                cmd.CommandTimeout = 0;
                dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        dgv.Rows.Add(dr["PRODUCT_ID"].ToString(), dr["PRODUCT_NAME"].ToString(), dr["QTY"].ToString(),
                        dr["RATE"].ToString(), dr["WEIGHT"].ToString(), dr["unit"].ToString(),  dr["total"].ToString(),
                        dr["type"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.ToString(), ":: Error ::");
            }
            finally
            {
                conn.Close();
            }
        }

        public void LoadPackingItems(ComboBox cmbItems)
        {
            try
            {
                query = @"SELECT '0' AS [id],'--SELECT PACKING ITEM' AS [name]
                UNION ALL
                SELECT MATERIAL_ID AS [id],MATERIAL_NAME AS [name] 
                FROM MATERIALS
                WHERE M_TYPE_ID = 3";
                LoadComboData(cmbItems, query);
            }
            catch (Exception ex) { ShowMessageBox(ex.ToString(), "Exception"); }
        }

        public void LoadMaterialType(ComboBox cmbMaterialType)
        {
            try
            {
                query = "SELECT '0' AS [id], '--SELECT MATERIAL TYPE--' AS [name] UNION SELECT M_TYPE_ID,M_TYPE_NAME FROM MATERIAL_TYPES WHERE STAT = 1 AND M_TYPE_ID <> 3";
                LoadComboData(cmbMaterialType, query);
            }
            catch (Exception ex) { ShowMessageBox(ex.ToString(), "Exception"); }
        }
        public void LoadMaterial(int typeId, ComboBox cmbMaterial)
        {
            try
            {
                query = "SELECT '0' AS [id], '--SELECT MATERIAL--' AS [name] UNION SELECT MATERIAL_ID AS [id],MATERIAL_NAME AS [name] FROM MATERIALS WHERE M_TYPE_ID = '" + typeId + "' AND STAT = 0";
                LoadComboData(cmbMaterial, query);
            }
            catch (Exception ex) { ShowMessageBox(ex.ToString(), "Exception"); }
        }

        public void LoadMaterial(ComboBox cmbMaterial)
        {
            try
            {
                query = "SELECT '0' AS [id], '--SELECT MATERIAL--' AS [name] UNION SELECT MATERIAL_ID AS [id],MATERIAL_NAME AS [name] FROM MATERIALS";
                LoadComboData(cmbMaterial, query);
            }
            catch (Exception ex) { ShowMessageBox(ex.ToString(), "Exception"); }
        }

        public void load_Location(ComboBox cmbLocation)
        {
            try
            {
                query = "SELECT '0' AS [id], '--SELECT LOCATION--' AS [name] UNION SELECT LOCATION_ID AS [id],LOCATION_NAME AS [name] FROM LOCATION ";
                LoadComboData(cmbLocation, query);
            }
            catch (Exception ex) { ShowMessageBox(ex.ToString(), "Exception"); }
        }

        public void load_Unit(ComboBox cmbUnit)
        {
            try
            {
                query = "SELECT '0' AS [id], '--SELECT UNIT--' AS [name] UNION SELECT UNIT_ID AS [id],UNIT_NAME AS [name] FROM UNITS";
                LoadComboData(cmbUnit, query);
            }
            catch (Exception ex) { ShowMessageBox(ex.ToString(), "Exception"); }
        }

        public string GetSaleInvoiceValue(string query)
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                cmd = new SqlCommand(query, conn);
                cmd.CommandTimeout = 0;
                dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    if (dr.Read())
                    {
                        return dr[0].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.ToString(), ":: Error ::");
            }
            finally
            {
                conn.Close();
            }
            return "";
        }




        public string GetQoutationInvoiceValue(string query)
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                cmd = new SqlCommand(query, conn);
                cmd.CommandTimeout = 0;
                dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    if (dr.Read())
                    {
                        return dr[0].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.ToString(), ":: Error ::");
            }
            finally
            {
                conn.Close();
            }
            return "";
        }



        public int GetMaxValue(string query) {
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                cmd = new SqlCommand(query, conn);
                cmd.CommandTimeout = 0;
                dr = cmd.ExecuteReader();
                if (dr.HasRows == true) {
                    if (dr.Read()) {
                        return Convert.ToInt32(dr[0].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.ToString(), ":: Error ::");
            }
            finally
            {
                conn.Close();
            }
            return 0;
        }

        public void LoadCustomerDetails(string query, TextBox SalesPerson,TextBox Area,TextBox dueDate)
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                cmd = new SqlCommand(query, conn);
                cmd.CommandTimeout = 0;
                dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        SalesPerson.Text = dr[0].ToString();
                        Area.Text = dr[1].ToString();
                        dueDate.Text = DateTime.Now.AddDays(Convert.ToInt16(dr[2].ToString())).ToShortDateString();
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.ToString(), ":: Error ::");
            }
            finally
            {
                conn.Close();
            }
        }

        public void LoadDueDate(string query, TextBox DueDate)
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                cmd = new SqlCommand(query, conn);
                cmd.CommandTimeout = 0;
                dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        DueDate.Text = dr[0].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.ToString(), ":: Error ::");
            }
            finally
            {
                conn.Close();
            }
        }


        public void LoadDataPackingPurchases(string query,DataGridView dg)
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                cmd = new SqlCommand(query, conn);
                cmd.CommandTimeout = 0;
                dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        dg.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), Convert.ToDecimal(dr[2].ToString()) * Convert.ToDecimal(dr[3].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.ToString(), ":: Error ::");
            }
            finally
            {
                conn.Close();
            }
        }

        public void LoadDataProduct(string query, DataGridView dgRaw, DataGridView dgConsumable,ComboBox cmbPacking)
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                cmd = new SqlCommand(query, conn);
                cmd.CommandTimeout = 0;
                dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        if (dr[0].ToString().Equals("1")) {
                            dgRaw.Rows.Add(dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
                        }
                        else if (dr[0].ToString().Equals("2"))
                        {
                            dgConsumable.Rows.Add(dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
                        }
                        else if (dr[0].ToString().Equals("3"))
                        {
                            cmbPacking.SelectedValue = dr[1].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.ToString(), ":: Error ::");
            }
            finally
            {
                conn.Close();
            }
        }

        //get packing material weight
        public string GetPackingMaterialWeight(int materialId)
        {
            string weight = "";
            query = "SELECT WEIGHT FROM MATERIALS WHERE MATERIAL_ID = '"+materialId+"'";
            try
            {
                if (conn1.State == System.Data.ConnectionState.Closed) { conn1.Open(); }
                cmd = new SqlCommand(query, conn1);
                cmd.CommandTimeout = 0;
                object v = cmd.ExecuteScalar();
                if (v != null) {
                    weight = v.ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), ":: Error ::", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn1.Close();
            }
            return weight;
        }

        ////get product weight
        public string GetProductWeight(int productId)
        {
            string weight = "0";
            query = "SELECT NET_WEIGHT FROM PRODUCT_MASTER WHERE PM_ID = '" + productId + "'";
            try
            {
                if (conn1.State == System.Data.ConnectionState.Closed) { conn1.Open(); }
                cmd = new SqlCommand(query, conn1);
                cmd.CommandTimeout = 0;
                weight = cmd.ExecuteScalar().ToString();
                //var v = (string)cmd.ExecuteScalar();
                //if (v != null) {

                //}


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), ":: Error ::", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn1.Close();
            }
            return weight;
        }

        //get product weight
        //public string[] GetProductWeight(int productId)
        //{
        //    string[] weight = new string[2];
        //    query = @"SELECT A.NET_WEIGHT,B.MATERIAL_ID
        //    FROM PRODUCT_MASTER A
        //    INNER JOIN PRODUCT_DETAILS B ON A.PM_ID = B.PM_ID
        //    WHERE B.MATERIAL_ID IN ('5003','5005') 
        //    AND A.PM_ID = '" + productId + "'";
        //    try
        //    {
        //        if (conn1.State == System.Data.ConnectionState.Closed) { conn1.Open(); }
        //        cmd = new SqlCommand(query, conn1);
        //        cmd.CommandTimeout = 0;
        //        dr = cmd.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            weight[0] = dr["NET_WEIGHT"].ToString();
        //            weight[1] = dr["MATERIAL_ID"].ToString();
        //        }
        //        //var v = (string)cmd.ExecuteScalar();
        //        //if (v != null) {

        //        //}


        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString(), ":: Error ::", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conn1.Close();
        //    }
        //    return weight;
        //}

        //get SOD weight
        public string[] GetSODWeight(int soId)
        {
            string[] soDetails = new string[3];
            query = "SELECT REMAINING_WEIGHT AS [WEIGHT],total_kgs,(rate*37.324) AS [muand rate] FROM SALES_ORDER_DIRECT WHERE SOD_ID = '" + soId + "'";
            try
            {
                if (conn1.State == System.Data.ConnectionState.Closed) { conn1.Open(); }
                cmd = new SqlCommand(query, conn1);
                cmd.CommandTimeout = 0;
                dr = cmd.ExecuteReader();
                if (dr.Read()) {
                    soDetails[0] = dr[0].ToString();
                    soDetails[1] = dr[1].ToString();
                    soDetails[2] = dr[2].ToString();
                }
                //weight = cmd.ExecuteScalar().ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), ":: Error ::", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn1.Close();
            }
            return soDetails;
        }

        //get SOP weight
        public string[] GetSOPWeight(int soId)
        {
            string[] soDetails = new string[3];
            query = "SELECT ISNULL(REMAINING_WEIGHT,0) AS [REM WEIGHT],ISNULL(TOTAL_WEIGHT,0) AS [TOTAL WEIGHT] FROM SALES_ORDER_PRODUCT_MASTER WHERE SOPM_ID = '" + soId + "'";
            try
            {
                if (conn1.State == System.Data.ConnectionState.Closed) { conn1.Open(); }
                cmd = new SqlCommand(query, conn1);
                cmd.CommandTimeout = 0;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    soDetails[0] = dr["REM WEIGHT"].ToString();
                    soDetails[1] = dr["TOTAL WEIGHT"].ToString();
                    soDetails[2] = "0";
                }
                //weight = cmd.ExecuteScalar().ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), ":: Error ::", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn1.Close();
            }
            return soDetails;
        }

        //get SOM weight
        public string[] GetSOMWeight(int soId)
        {
            string[] soDetails = new string[3];
            query = "SELECT ISNULL(REMAINING_WEIGHT,0) AS [REM WEIGHT],ISNULL(TOTAL_WEIGHT,0) AS [TOTAL WEIGHT] FROM SO_MATERIAL_P_MASTER WHERE MPM_ID = '" + soId + "'";
            try
            {
                if (conn1.State == System.Data.ConnectionState.Closed) { conn1.Open(); }
                cmd = new SqlCommand(query, conn1);
                cmd.CommandTimeout = 0;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    soDetails[0] = dr["REM WEIGHT"].ToString();
                    soDetails[1] = dr["TOTAL WEIGHT"].ToString();
                    soDetails[2] = "0";
                }
                //weight = cmd.ExecuteScalar().ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), ":: Error ::", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn1.Close();
            }
            return soDetails;
        }

        //get product rate
        public string GetProductRate(int productId,int customerId,char type)
        {
            string rate = "0";
            query = "select SALE_PRICE from PRODUCTS_FORMULA WHERE CUSTOMER_ID = '"+customerId+"' AND PRODUCT_ID = '"+productId+ "' AND CASH_CREDIT = '"+type+"'";
            try
            {
                if (conn1.State == System.Data.ConnectionState.Closed) { conn1.Open(); }
                cmd = new SqlCommand(query, conn1);
                cmd.CommandTimeout = 0;
                if (cmd.ExecuteScalar() != null) { rate = cmd.ExecuteScalar().ToString(); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), ":: Error ::", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn1.Close();
            }
            return rate;
        }
        public string GetProductRate(int productId, int customerId)
        {
            string rate = "0";
            query = "select SALE_PRICE from PRODUCTS_FORMULA WHERE CUSTOMER_ID = '" + customerId + "' AND PRODUCT_ID = '" + productId + "'";
            try
            {
                if (conn1.State == System.Data.ConnectionState.Closed) { conn1.Open(); }
                cmd = new SqlCommand(query, conn1);
                cmd.CommandTimeout = 0;
                if (cmd.ExecuteScalar() != null) { rate = cmd.ExecuteScalar().ToString(); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), ":: Error ::", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn1.Close();
            }
            return rate;
        }



        public void LoadFormulaProduct(int customerId, int cashCredit,int formulaType, DataGridView dg)
        {
            try
            {
                if(formulaType == 2) { 
                query = @"IF EXISTS (SELECT CUSTOMER_ID FROM PRODUCTS_FORMULA WHERE CUSTOMER_ID = '"+customerId+"' AND FOURMULA_ID = '"+formulaType+"' AND CASH_CREDIT = '"+cashCredit+ @"')
                        BEGIN
	                        SELECT B.PM_ID,B.PRODUCT_NAME,ISNULL(B.GROSS_WEIGHT,0) AS [GROSS WEIGHT],ISNULL(B.NET_WEIGHT,0) AS [NET WEIGHT],
	                        (SELECT BB.MATERIAL_NAME FROM PRODUCT_DETAILS AA,MATERIALS BB WHERE AA.MATERIAL_ID = BB.MATERIAL_ID AND AA.M_TYPE_ID = 3 AND AA.PM_ID = B.PM_ID) AS [PACKING MATERIAL],
	                        ISNULL(A.PACKING_RATE,0) AS [PACKING RATE],ISNULL(A.MUAND_RATE,0) AS [MUAND RATE],ISNULL(A.MILLING,0) AS [MILLING],ISNULL(A.SALE_PRICE,0) AS [SALE RATE]
	                        FROM PRODUCT_MASTER B
	                        LEFT JOIN PRODUCTS_FORMULA A ON B.PM_ID = A.PRODUCT_ID
	                        WHERE A.CUSTOMER_ID = '"+customerId+ "' AND A.CASH_CREDIT = '"+cashCredit+ "' AND A.FOURMULA_ID = '"+formulaType+@"'
                        END	
                        ELSE 
                        BEGIN
	                        SELECT B.PM_ID,B.PRODUCT_NAME,ISNULL(B.GROSS_WEIGHT,0) AS [GROSS WEIGHT],ISNULL(B.NET_WEIGHT,0) AS [NET WEIGHT],
	                        (SELECT BB.MATERIAL_NAME FROM PRODUCT_DETAILS AA,MATERIALS BB WHERE AA.MATERIAL_ID = BB.MATERIAL_ID AND AA.M_TYPE_ID = 3 AND AA.PM_ID = B.PM_ID) AS [PACKING MATERIAL],
	                        ISNULL(A.PACKING_RATE,0) AS [PACKING RATE],ISNULL(A.MUAND_RATE,0) AS [MUAND RATE],ISNULL(A.MILLING,0) AS [MILLING],ISNULL(A.SALE_PRICE,0) AS [SALE RATE]
	                        FROM PRODUCT_MASTER B
	                        LEFT JOIN PRODUCTS_FORMULA A ON B.PM_ID = A.PRODUCT_ID
                        END";
                }
                else if (formulaType == 1)
                {
                    query = @"IF EXISTS (SELECT CUSTOMER_ID FROM PRODUCTS_FORMULA WHERE CUSTOMER_ID = '"+customerId+ "' AND FOURMULA_ID = '"+formulaType+ "' AND CASH_CREDIT = '"+cashCredit+ @"')
                            BEGIN
	                            SELECT B.PM_ID,B.PRODUCT_NAME,ISNULL(A.CONSTANT_VALUE,0) AS [CONSTANT KG],ISNULL(A.KG_RATE,0) AS [KG RATE],ISNULL(B.GROSS_WEIGHT,0) AS [GROSS WEIGHT],
	                            (SELECT BB.MATERIAL_NAME FROM PRODUCT_DETAILS AA,MATERIALS BB WHERE AA.MATERIAL_ID = BB.MATERIAL_ID AND AA.M_TYPE_ID = 3 AND AA.PM_ID = B.PM_ID) AS [PACKING MATERIAL],
	                            ISNULL(A.DIFFERENCE,0) AS [DIFFERENCE],ISNULL(A.ADDITION,0) AS [ADDITION],ISNULL(A.[2x],0) AS [2x],ISNULL(A.SALE_PRICE,0) AS [SALE RATE]
	                            FROM PRODUCT_MASTER B
	                            LEFT JOIN PRODUCTS_FORMULA A ON B.PM_ID = A.PRODUCT_ID
	                            WHERE A.CUSTOMER_ID = '"+customerId+ "' AND A.CASH_CREDIT = '"+cashCredit+ "' AND A.FOURMULA_ID = '"+formulaType+@"'
                            END	
                            ELSE 
                            BEGIN
	                            SELECT B.PM_ID,B.PRODUCT_NAME,ISNULL(A.CONSTANT_VALUE,0) AS [CONSTANT KG],ISNULL(A.KG_RATE,0) AS [KG RATE],ISNULL(B.GROSS_WEIGHT,0) AS [GROSS WEIGHT],
	                            (SELECT BB.MATERIAL_NAME FROM PRODUCT_DETAILS AA,MATERIALS BB WHERE AA.MATERIAL_ID = BB.MATERIAL_ID AND AA.M_TYPE_ID = 3 AND AA.PM_ID = B.PM_ID) AS [PACKING MATERIAL],
	                            ISNULL(A.DIFFERENCE,0) AS [DIFFERENCE],ISNULL(A.ADDITION,0) AS [ADDITION],ISNULL(A.[2x],0) AS [2x],ISNULL(A.SALE_PRICE,0) AS [SALE RATE]
	                            FROM PRODUCT_MASTER B
	                            LEFT JOIN PRODUCTS_FORMULA A ON B.PM_ID = A.PRODUCT_ID
                            END";
                }
                dg.DataSource = null;
                if (conn.State == System.Data.ConnectionState.Closed) { conn.Open(); }
                cmd = new SqlCommand(query, conn);
                cmd.CommandTimeout = 0;
                adp = new SqlDataAdapter();
                adp.SelectCommand = cmd;
                ds = new System.Data.DataSet();
                adp.Fill(ds, "data");
                dg.Invoke((MethodInvoker)delegate
                {
                    dg.DataSource = ds.Tables["data"];
                });
                dg.ClearSelection();
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.ToString(), ":: Error ::");
            }
            finally
            {
                conn.Close();
            }
        }

        //get product sale order details
        public void GetProductSODetails(int saleOrderId,DataGridView dg)
        {
            query = @"SELECT A.PRODUCT_ID,B.PRODUCT_NAME,A.QTY,A.RATE,(A.QTY * A.RATE) AS [TOTAL],a.[WEIGHT],C.MATERIAL_ID
            FROM SALES_ORDER_PRODUCT_DETAILS A,PRODUCT_MASTER B, PRODUCT_DETAILS C
            WHERE A.PRODUCT_ID = B.PM_ID and B.PM_ID = C.PM_ID AND A.SOPM_ID = '" + saleOrderId+"'";

            try
            {
                if (conn1.State == System.Data.ConnectionState.Closed) { conn1.Open(); }
                cmd = new SqlCommand(query, conn1);
                cmd.CommandTimeout = 0;
                dr = cmd.ExecuteReader();
                if (dr.HasRows == true) {
                    while (dr.Read()) {
                        dg.Rows.Add(dr["PRODUCT_ID"].ToString(), dr["PRODUCT_NAME"].ToString(), dr["QTY"].ToString(),
                            dr["RATE"].ToString(), dr["WEIGHT"].ToString(),  dr["TOTAL"].ToString(), dr["MATERIAL_ID"].ToString());
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), ":: Error ::", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn1.Close();
            }
        }

        //get product material sale order details
        public void GetProductMaterialSODetails(int saleOrderId, DataGridView dg)
        {
            query = @"SELECT A.PRODUCT_ID,B.PRODUCT_NAME,A.RATE
            FROM SO_MATERIAL_P_DETAIL A,PRODUCT_MASTER B
            WHERE A.PRODUCT_ID = B.PM_ID AND A.MPM_ID = '" + saleOrderId + "'";

            try
            {
                if (conn1.State == System.Data.ConnectionState.Closed) { conn1.Open(); }
                cmd = new SqlCommand(query, conn1);
                cmd.CommandTimeout = 0;
                dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        dg.Rows.Add(dr["PRODUCT_ID"].ToString(), dr["PRODUCT_NAME"].ToString(), dr["RATE"].ToString());
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), ":: Error ::", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn1.Close();
            }
        }

        //get sale program details
        public void GetSaleProgramDetails(int programId, DataGridView dg,TextBox txtOlienWeight, TextBox txtCanolaWeight)
        {
            txtCanolaWeight.Text = "0";
            txtOlienWeight.Text = "0";

            dg.Rows.Clear();
            query = @"SELECT A.PRODUCT_ID,B.MATERIAL_NAME,A.QTY,A.RATE,A.[WEIGHT],'KGS' AS [UNIT],(A.QTY * A.RATE) AS [TOTAL],'R' AS [TYPE],B.MATERIAL_ID
            FROM SALES_PROGRAM_DETAILS A,MATERIALS B
            WHERE A.PRODUCT_ID = B.MATERIAL_ID AND A.ITEM_TYPE = 'R' AND A.SPM_ID = '" + programId+ @"'
            UNION ALL
            SELECT A.PRODUCT_ID,B.PRODUCT_NAME,A.QTY,A.RATE,A.[WEIGHT],'KGS' AS [UNIT],(A.QTY * A.RATE) AS [TOTAL],'P' AS [TYPE],C.MATERIAL_ID
            FROM SALES_PROGRAM_DETAILS A,PRODUCT_MASTER B,PRODUCT_DETAILS C
            WHERE A.PRODUCT_ID = B.PM_ID AND B.PM_ID = C.PM_ID  AND A.ITEM_TYPE = 'P' AND A.SPM_ID = '" + programId + "'";

            try
            {
                if (conn1.State == System.Data.ConnectionState.Closed) { conn1.Open(); }
                cmd = new SqlCommand(query, conn1);
                cmd.CommandTimeout = 0;
                dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        dg.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(),
                            dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString());

                        if (dr[8].ToString().Equals("5005"))
                            txtCanolaWeight.Text = (txtCanolaWeight.Text == "" ? 0 : double.Parse(txtCanolaWeight.Text) + double.Parse(dr["WEIGHT"].ToString())).ToString();
                        else
                            txtOlienWeight.Text = (txtOlienWeight.Text == "" ? 0 : double.Parse(txtOlienWeight.Text) + double.Parse(dr["WEIGHT"].ToString())).ToString();

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), ":: Error ::", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn1.Close();
            }
        }

        public void GetSaleReturnDetails(int srId, DataGridView dg)
        {
            dg.Rows.Clear();
            query = @" select a.ITEM_ID,b.PRODUCT_NAME,a.QTY,a.ITEM_WEIGHT,
            'KGS' as [UNIT],a.ITEM_RATE,(a.QTY * a.ITEM_RATE) as [TOTAL],
            a.ITEM_TYPE,CASE WHEN C.MATERIAL_ID = '5005' THEN 'C' ELSE 'R' END AS [PRODUCT TYPE],
            A.MATERIAL_ID
            from SALES_RETURN_DETAIL a
            inner join PRODUCT_MASTER b on a.ITEM_ID = b.PM_ID
            inner join PRODUCT_DETAILS c on b.PM_ID = c.PM_ID
            WHERE A.SRM_ID = '"+srId+"'";

            try
            {
                if (conn1.State == System.Data.ConnectionState.Closed) { conn1.Open(); }
                cmd = new SqlCommand(query, conn1);
                cmd.CommandTimeout = 0;
                dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        dg.Rows.Add(dr["ITEM_ID"].ToString(), dr["PRODUCT_NAME"].ToString(), dr["QTY"].ToString(), 
                        dr["ITEM_WEIGHT"].ToString(), dr["UNIT"].ToString(),dr["ITEM_RATE"].ToString(), dr["TOTAL"].ToString(),
                        dr["PRODUCT TYPE"].ToString(), dr["PRODUCT TYPE"].ToString(), dr["MATERIAL_ID"].ToString());
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), ":: Error ::", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn1.Close();
            }
        }

        private static String ones(String Number)
        {
            int _Number = Convert.ToInt32(Number);
            String name = "";
            switch (_Number)
            {

                case 1:
                    name = "One";
                    break;
                case 2:
                    name = "Two";
                    break;
                case 3:
                    name = "Three";
                    break;
                case 4:
                    name = "Four";
                    break;
                case 5:
                    name = "Five";
                    break;
                case 6:
                    name = "Six";
                    break;
                case 7:
                    name = "Seven";
                    break;
                case 8:
                    name = "Eight";
                    break;
                case 9:
                    name = "Nine";
                    break;
            }
            return name;
        }

        private static String tens(String Number)
        {
            int _Number = Convert.ToInt32(Number);
            String name = null;
            switch (_Number)
            {
                case 10:
                    name = "Ten";
                    break;
                case 11:
                    name = "Eleven";
                    break;
                case 12:
                    name = "Twelve";
                    break;
                case 13:
                    name = "Thirteen";
                    break;
                case 14:
                    name = "Fourteen";
                    break;
                case 15:
                    name = "Fifteen";
                    break;
                case 16:
                    name = "Sixteen";
                    break;
                case 17:
                    name = "Seventeen";
                    break;
                case 18:
                    name = "Eighteen";
                    break;
                case 19:
                    name = "Nineteen";
                    break;
                case 20:
                    name = "Twenty";
                    break;
                case 30:
                    name = "Thirty";
                    break;
                case 40:
                    name = "Fourty";
                    break;
                case 50:
                    name = "Fifty";
                    break;
                case 60:
                    name = "Sixty";
                    break;
                case 70:
                    name = "Seventy";
                    break;
                case 80:
                    name = "Eighty";
                    break;
                case 90:
                    name = "Ninety";
                    break;
                default:
                    if (_Number > 0)
                    {
                        name = tens(Number.Substring(0, 1) + "0") + " " + ones(Number.Substring(1));
                    }
                    break;
            }
            return name;
        }

        public String ConvertWholeNumber(String Number)
        {
            string word = "";
            if(Number.Contains("."))
               Number = Number.Substring(0, Number.IndexOf('.'));
            try
            {
                bool beginsZero = false;//tests for 0XX   
                bool isDone = false;//test if already translated   
                double dblAmt = (Convert.ToDouble(Number));
                //if ((dblAmt > 0) && number.StartsWith("0"))   
                if (dblAmt > 0)
                {//test for zero or digit zero in a nuemric   
                    beginsZero = Number.StartsWith("0");

                    int numDigits = Number.Length;
                    int pos = 0;//store digit grouping   
                    String place = "";//digit grouping name:hundres,thousand,etc...   
                    switch (numDigits)
                    {
                        case 1://ones' range   

                            word = ones(Number);
                            isDone = true;
                            break;
                        case 2://tens' range   
                            word = tens(Number);
                            isDone = true;
                            break;
                        case 3://hundreds' range   
                            pos = (numDigits % 3) + 1;
                            place = " Hundred ";
                            break;
                        case 4://thousands' range   
                        case 5:
                        case 6:
                            pos = (numDigits % 4) + 1;
                            place = " Thousand ";
                            break;
                        case 7://millions' range   
                        case 8:
                        case 9:
                            pos = (numDigits % 7) + 1;
                            place = " Million ";
                            break;
                        case 10://Billions's range   
                        case 11:
                        case 12:

                            pos = (numDigits % 10) + 1;
                            place = " Billion ";
                            break;
                        //add extra case options for anything above Billion...   
                        default:
                            isDone = true;
                            break;
                    }
                    if (!isDone)
                    {//if transalation is not done, continue...(Recursion comes in now!!)   
                        if (Number.Substring(0, pos) != "0" && Number.Substring(pos) != "0")
                        {
                            try
                            {
                                word = ConvertWholeNumber(Number.Substring(0, pos)) + place + ConvertWholeNumber(Number.Substring(pos));
                            }
                            catch { }
                        }
                        else
                        {
                            word = ConvertWholeNumber(Number.Substring(0, pos)) + ConvertWholeNumber(Number.Substring(pos));
                        }


                    }
                    //ignore digit grouping names   
                    if (word.Trim().Equals(place.Trim())) word = "";
                }
            }
            catch { }
            return word.Trim();
        }

        public void LoadCustomersWithAll(ComboBox cmbCustomer)
        {
            try
            {
                query = @"SELECT '0' AS [id],'--ALL--' AS [name]
                UNION
                SELECT COA_ID AS [id],COA_NAME AS [name] FROM COA WHERE CA_ID = '21' AND STAT = 0";
                LoadComboData(cmbCustomer, query);
            }
            catch (Exception ex) { ShowMessageBox(ex.ToString(), "Exception"); }
        }

        public void GetWeights()
        {

        }

        public string[] GetChqDetails(int chqId)
        {
            string[] chqDetails = new string[2];
            query = @"SELECT A.REC_AC,A.AMOUNT 
            FROM CHQ A 
            --INNER JOIN COA B ON A.REC_AC = B.COA_ID ,A.BANK_NAME,
            WHERE A.CHQ_ID = '" + chqId+"'";
            try
            {
                if (conn1.State == System.Data.ConnectionState.Closed) { conn1.Open(); }
                cmd = new SqlCommand(query, conn1);
                cmd.CommandTimeout = 0;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    chqDetails[0] = dr["REC_AC"].ToString();
                    chqDetails[1] = dr["AMOUNT"].ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), ":: Error ::", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn1.Close();
            }
            return chqDetails;
        }
    }
}