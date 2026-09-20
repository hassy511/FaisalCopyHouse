using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ERP_Maaz_Oil.Forms
{
    public partial class frmSalesOrderProduct : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        string id = "";
        int is_edit = 0;

        public frmSalesOrderProduct()
        {
            InitializeComponent();
        }

        private void GenerateSONumber()
        {
            classHelper.GenerateSONumber(lblPI);
            //classHelper.query = "SELECT COUNT(SOPM_ID)+1 FROM SALES_ORDER_PRODUCT_MASTER";
            //lblPI.Text = "SO-" + classHelper.GetMaxValue(classHelper.query) + "-" + DateTime.Now.Year;
        }

        private void GetProductRate()
        {
            try
            {
                if (cmbItem.SelectedIndex != 0)
                {
                    char type = '0';
                    if (rdbCredit.Checked == true) {
                        type = '1';
                    }
                    txtRate.Text = classHelper.GetProductRate(Convert.ToInt32(cmbItem.SelectedValue.ToString()), Convert.ToInt32(cmbCustomer.SelectedValue.ToString()),type);
                }
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private int GetMaterialID()
        {
            try
            {
                classHelper.query = @"SELECT MATERIAL_ID FROM PRODUCT_DETAILS WHERE PM_ID = '" + cmbItem.SelectedValue.ToString() + "' ";
                if (Classes.Helper.conn.State == ConnectionState.Closed)
                    Classes.Helper.conn.Open();
                classHelper.cmd = new System.Data.SqlClient.SqlCommand(classHelper.query, Classes.Helper.conn);
                int result = int.Parse(classHelper.cmd.ExecuteScalar().ToString());
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return 0;
            }
            finally
            {
                Classes.Helper.conn.Close();
            }
        }

        private void LoadGrid()
        {
            classHelper.query = @"
            SELECT A.SOPM_ID,A.DATE,A.INVOICE_NO AS [INVOICE #],A.CUSTOMER_ID,B.COA_NAME AS [CUSTOMER],
            A.TOTAL_WEIGHT AS [WEIGHT],A.TOTAL AS [AMOUNT],A.DESCRIPTION,A.CREDIT_DAYS AS [CREDIT DAYS],
            CASE WHEN A.SALES_TYPE = 0 THEN 'CASH' ELSE 'CREDIT' END AS [SALES TYPE],[STATUS],MUAND_RATE as [MUAND RATE]
            FROM SALES_ORDER_PRODUCT_MASTER A,COA B
            WHERE A.CUSTOMER_ID = B.COA_ID
            ORDER BY A.SOPM_ID DESC";
            classHelper.LoadGrid(grdSEARCH, classHelper.query);
        }
        //load COMBO BOXES
        private void LoadCustomers()
        {
            classHelper.LoadCustomers(cmbCustomer);
        }

        //load item COMBO BOXES
        private void LoadProducts()
        {
            classHelper.LoadProducts(cmbItem);
        }
        
        //clear fields in form
        private void Clear() {
            GenerateSONumber();
            dtp_DATE.Value = DateTime.Now;
            cmbCustomer.SelectedIndex = 0;
            txtDescript.Clear();
            cmbItem.SelectedIndex = 0;
            txtQuantity.Text = "0";
            txtRate.Text = "0";
            txtTotal.Text = "0";
            txtTotalWeight.Text = "0";
            txtCreditDays.Text = "0";
            txtMuandRate.Clear();
            txtSEARCH.Clear();
            grdItems.Rows.Clear();
            id = "";
            is_edit = 0;
            rdbCash.Checked = true;
            chkDiscard.Checked = false;

            txtCanolaWeight.Text = "0";
            txtOlienWeight.Text = "0";
        }

        private double GetProductWeight()
        {
            try
            {
                if (cmbItem.SelectedIndex != 0)
                {
                    return Convert.ToDouble(classHelper.GetProductWeight(Convert.ToInt32(cmbItem.SelectedValue.ToString())));
                }
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
            return 0;
        }

        private void AddClear() {
            txtQuantity.Text = "0";
            txtRate.Text = "0";
            cmbItem.SelectedIndex = 0;
        }

        private void ItemsTotalSum()
        {
            if (grdItems.Rows.Count > 0)
            {
                txtTotal.Text = grdItems.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToDecimal(t.Cells["total"].Value)).ToString();

                txtTotalWeight.Text = grdItems.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToDecimal(t.Cells["weight"].Value)).ToString();

                txtTotalQty.Text = grdItems.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToDecimal(t.Cells["qty"].Value)).ToString();
            }
        }

        private void AddItemRow()
        {
            if (cmbItem.SelectedIndex == 0)
            {
                MessageBox.Show("Select Product", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbItem.Focus();
                return;
            }
            else if (txtQuantity.Text.Trim().Equals(""))
            {
                MessageBox.Show("Enter Quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtQuantity.Focus();
                return;
            }
            else if (txtRate.Text.Trim().Equals(""))
            {
                MessageBox.Show("Enter Rate", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRate.Focus();
                return;
            }
            else
            {
                grdItems.Rows.Add(cmbItem.SelectedValue.ToString(), cmbItem.Text, txtQuantity.Text, txtRate.Text, (GetProductWeight() * Convert.ToDouble(txtQuantity.Text)), (Convert.ToDecimal(txtQuantity.Text) * Convert.ToDecimal(txtRate.Text)),GetMaterialID());
                ItemsTotalSum();
                AddClear();
            }
        }

        private void Save() {
            if (cmbCustomer.SelectedIndex == 0)
            {
                classHelper.ShowMessageBox("Customer is not selected, please select Customer.", "Warning");
                cmbCustomer.Focus();
                return;
            }
            else
            {
                char status = '1';
                if (chkDiscard.Checked == true) {
                    status = '0';
                }
                int salesType = 0;
                if (rdbCredit.Checked == true) {
                    salesType = 1;
                }
                string dId = id;
                string masterId = id;
                if (id.Equals(""))
                {
                    id = "(SELECT MAX(SOPM_ID) FROM SALES_ORDER_PRODUCT_MASTER)";
                    masterId = id;
                }
      
                string detailQuery = "";
                
                foreach (DataGridViewRow rows in grdItems.Rows)
                {
                    detailQuery += @"INSERT INTO SALES_ORDER_PRODUCT_DETAILS (SOPM_ID,PRODUCT_ID,QTY,RATE,[WEIGHT])
                    VALUES(" + masterId+",'"+ rows.Cells[0].Value.ToString() + "','" + rows.Cells["qty"].Value.ToString() + "','" + rows.Cells["rate"].Value.ToString() + "','" + rows.Cells["weight"].Value.ToString() + @"');";
                }

                classHelper.query = "BEGIN TRAN ";
                classHelper.query += @"IF EXISTS (select SOPM_ID from SALES_ORDER_PRODUCT_MASTER WHERE SOPM_ID ='" + dId + @"') 
                    BEGIN
                    UPDATE SALES_ORDER_PRODUCT_MASTER SET DATE = '" + Classes.Helper.ConvertDatetime(dtp_DATE.Value.Date) + "',CUSTOMER_ID = '" + cmbCustomer.SelectedValue.ToString() + @"',
                    DESCRIPTION = '" + txtDescript.Text + "',SALES_TYPE = '" + salesType + @"',
                    TOTAL = '" + txtTotal.Text + "',CREDIT_DAYS = '" + txtCreditDays.Text + @"',
                    TOTAL_WEIGHT = '" + txtTotalWeight.Text + "',[STATUS] = '"+status+ "',REMAINING_WEIGHT = ((" + classHelper.AvoidInjection(txtTotalWeight.Text) + @" - TOTAL_WEIGHT)+REMAINING_WEIGHT),
                    MUAND_RATE = '"+classHelper.AvoidInjection(txtMuandRate.Text)+"',MODIFICATION_DATE = GETDATE(),MODIFIED_BY = '" + Classes.Helper.userId + @"' WHERE SOPM_ID = '" + dId + @"';
                    UPDATE SALES_PROGRAM_MASTER SET CUSTOMER_ID = '" + cmbCustomer.SelectedValue.ToString() + @"' WHERE SOD_ID = '" + dId + @"' AND SO_TYPE = 'P';
                    END
                    ELSE
                    BEGIN
                    INSERT INTO SALES_ORDER_PRODUCT_MASTER (DATE,CUSTOMER_ID,DESCRIPTION,CREDIT_DAYS,CREATED_BY,CREATION_DATE,TOTAL,INVOICE_NO,SALES_TYPE,TOTAL_WEIGHT,[STATUS],REMAINING_WEIGHT,MUAND_RATE) 
                    VALUES ('" + Classes.Helper.ConvertDatetime(dtp_DATE.Value.Date) + "','" + cmbCustomer.SelectedValue.ToString() + "','" + txtDescript.Text + "','" + txtCreditDays.Text + "','" + Classes.Helper.userId + @"',
                    GETDATE(),'" + txtTotal.Text + "','" + lblPI.Text + "','" + salesType + "','" + txtTotalWeight.Text + "','" + status + "','" + txtTotalWeight.Text + "','"+classHelper.AvoidInjection(txtMuandRate.Text)+@"')
                    END
                    DELETE FROM SALES_ORDER_PRODUCT_DETAILS WHERE SOPM_ID = '" + dId + @"'
                    " + detailQuery+@";";
                classHelper.query += "COMMIT TRAN";
                if (classHelper.InsertUpdateDelete(classHelper.query) >= 1)
                {
                    classHelper.ShowMessageBox("Record Saved Sucessfully.", "Information");
                    Clear();
                    LoadGrid();
                }
            }
        }
        private void WeightSum()
        {
            txtOlienWeight.Text = grdItems.Rows.Cast<DataGridViewRow>()
                .Where(x => !(x.Cells["MaterialID"].Value).ToString().Equals("5005"))
                .Sum(x => Convert.ToDecimal(x.Cells["weight"].Value)).ToString();

            txtCanolaWeight.Text = grdItems.Rows.Cast<DataGridViewRow>()
                .Where(x => (x.Cells["MaterialID"].Value).ToString().Equals("5005"))
                .Sum(x => Convert.ToDecimal(x.Cells["weight"].Value)).ToString();

        }
        //get data from grid on click
        private void load_data_fromGrid(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.grdSEARCH.Rows[e.RowIndex];
                id = row.Cells["SOPM_ID"].Value.ToString();
                is_edit = 1;

                dtp_DATE.Text = row.Cells["DATE"].Value.ToString();
                lblPI. Text = row.Cells["INVOICE #"].Value.ToString();
                cmbCustomer.SelectedValue = row.Cells["CUSTOMER_ID"].Value.ToString();
                txtDescript.Text = row.Cells["DESCRIPTION"].Value.ToString();
                txtTotal.Text = row.Cells["AMOUNT"].Value.ToString();
                txtCreditDays.Text = row.Cells["CREDIT DAYS"].Value.ToString();
                txtMuandRate.Text = row.Cells["MUAND RATE"].Value.ToString(); 
                if (row.Cells["SALES TYPE"].Value.ToString().Equals("CASH"))
                {
                    rdbCash.Checked = true;
                }
                else {
                    rdbCredit.Checked = true;
                }
                grdItems.Rows.Clear();
                classHelper.GetProductSODetails(Convert.ToInt16(id),grdItems);
                if (Convert.ToChar(row.Cells["STATUS"].Value.ToString()) == '0')
                {
                    chkDiscard.Checked = true;
                }
                else {
                    chkDiscard.Checked = false;
                }
                ItemsTotalSum();
                //classHelper.query = @"SELECT A.P_MATERIAL_ID,B.MATERIAL_NAME,A.QTY,A.RATE 
                //FROM PURCHASES_PACKING_DETAILS A,MATERIALS B
                //WHERE A.P_MATERIAL_ID = B.MATERIAL_ID AND A.PPM_ID = '"+id+"'";
                //classHelper.LoadDataPackingPurchases(classHelper.query,grdItems);
            }
        }

        private void frm_AddGroupAccounts_Load(object sender, EventArgs e)
        {
            GenerateSONumber();
            LoadGrid();
            LoadCustomers();
            LoadProducts();
        }

        private void txtSEARCH_TextChanged(object sender, EventArgs e)
        {
           classHelper.Sales_Order_Product_Search(txtSEARCH, grdSEARCH);
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {
            Save();
        }
        
        private void grdSEARCH_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            grdSEARCH.Columns["SOPM_ID"].Visible = false;
            grdSEARCH.Columns["CUSTOMER_ID"].Visible = false;
            grdSEARCH.Columns["STATUS"].Visible = false;
        }

        private void btnCLEAR_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void grdSEARCH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           load_data_fromGrid(e);
           WeightSum();
        }
        
        private void txtNetWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                classHelper.AllowNumbers(e);
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddItemRow();
            WeightSum();
        }

        private void grdItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.grdItems.Rows[e.RowIndex];
                cmbItem.SelectedValue = row.Cells[0].Value.ToString();
                txtQuantity.Text = row.Cells["qty"].Value.ToString();
                txtRate.Text = row.Cells["rate"].Value.ToString();
                
                grdItems.Rows.RemoveAt(e.RowIndex);
                ItemsTotalSum();
                WeightSum();
            }
        }

        private void cmbItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetProductRate();
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCustomer.SelectedIndex != 0)
            {
                txtCreditDays.Text = classHelper.GetCustomerCreditDays(Convert.ToInt32(cmbCustomer.SelectedValue.ToString())).ToString();
            }
        }

        private void btnADD_CITY_Click(object sender, EventArgs e)
        {
            using (classHelper.frmProducts = new frmFinishedProducts())
            {
                if (classHelper.frmProducts.ShowDialog() == System.Windows.Forms.DialogResult.Cancel || classHelper.frmAddCity.ShowDialog() == System.Windows.Forms.DialogResult.Abort)
                {
                    classHelper.LoadProducts(cmbItem);
                }
            }
        }
    }
    }

