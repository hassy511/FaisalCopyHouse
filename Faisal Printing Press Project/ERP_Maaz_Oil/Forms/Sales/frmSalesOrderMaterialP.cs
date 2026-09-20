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
    public partial class frmSalesOrderMaterialP : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        string id = "";
        int is_edit = 0;

        public frmSalesOrderMaterialP()
        {
            InitializeComponent();
        }

        private void GenerateSONumber()
        {
            classHelper.GenerateSONumber(lblPI);
            //classHelper.query = "SELECT COUNT(MPM_ID)+1 FROM SO_MATERIAL_P_MASTER";
            //lblPI.Text = "SO-" + classHelper.GetMaxValue(classHelper.query) + "-" + DateTime.Now.Year;
        }

        //private void GetProductRate()
        //{
        //    try
        //    {
        //        if (cmbItem.SelectedIndex != 0)
        //        {
        //            char type = '0';
        //            if (rdbCredit.Checked == true) {
        //                type = '1';
        //            }
        //            txtRate.Text = classHelper.GetProductRate(Convert.ToInt32(cmbItem.SelectedValue.ToString()), Convert.ToInt32(cmbCustomer.SelectedValue.ToString()),type);
        //        }
        //    }
        //    catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
        //}

        private void LoadGrid()
        {
            classHelper.query = @"
            SELECT A.MPM_ID,A.DATE,A.INVOICE_NO AS [INVOICE #],A.CUSTOMER_ID,B.COA_NAME AS [CUSTOMER],
            A.TOTAL_WEIGHT AS [WEIGHT],A.TOTAL AS [AMOUNT],A.DESCRIPTION,A.CREDIT_DAYS AS [CREDIT DAYS],
            CASE WHEN A.SALE_TYPE = 0 THEN 'CASH' ELSE 'CREDIT' END AS [SALES TYPE],[STATUS],MUAND_RATE AS [MUAND RATE]
            FROM SO_MATERIAL_P_MASTER A,COA B
            WHERE A.CUSTOMER_ID = B.COA_ID
            ORDER BY A.[DATE] DESC";
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
            txtMuandRate.Clear();
            txtQuantity.Text = "0";
            txtRate.Text = "0";
            
            txtCreditDays.Text = "0";
            txtSEARCH.Clear();
            grdItems.Rows.Clear();
            id = "";
            is_edit = 0;
            rdbCash.Checked = true;

            chkDiscard.Checked = false;
        }

        private void AddClear() {
            //txtQuantity.Text = "0";
            txtRate.Text = "0";
            cmbItem.SelectedIndex = 0;
        }

        //private void ItemsTotalSum()
        //{
        //    if (grdItems.Rows.Count > 0)
        //    {
        //        txtTotal.Text = grdItems.Rows.Cast<DataGridViewRow>()
        //        .Sum(t => Convert.ToDecimal(t.Cells["total"].Value)).ToString();

        //        txtTotalWeight.Text = grdItems.Rows.Cast<DataGridViewRow>()
        //        .Sum(t => Convert.ToDecimal(t.Cells["weight"].Value)).ToString();
        //    }
        //}

        private void AddItemRow()
        {
            if (cmbItem.SelectedIndex == 0)
            {
                MessageBox.Show("Select Product", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbItem.Focus();
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
                grdItems.Rows.Add(cmbItem.SelectedValue.ToString(), cmbItem.Text, txtRate.Text);
                //ItemsTotalSum();
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
            else if (txtQuantity.Text.Trim().Equals(""))
            {
                MessageBox.Show("Enter Weight", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtQuantity.Focus();
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
                    id = "(SELECT MAX(MPM_ID) FROM SO_MATERIAL_P_MASTER)";
                    masterId = id;
                }

                string detailQuery = "";
                
                foreach (DataGridViewRow rows in grdItems.Rows)
                {
                    detailQuery += @"INSERT INTO SO_MATERIAL_P_DETAIL (MPM_ID,PRODUCT_ID,RATE)
                    VALUES(" + masterId+",'"+ rows.Cells[0].Value.ToString() + "','" + rows.Cells[2].Value.ToString() + @"');";
                }

                classHelper.query = "BEGIN TRAN ";
                classHelper.query += @"IF EXISTS (select MPM_ID from SO_MATERIAL_P_MASTER WHERE MPM_ID ='" + dId + @"') 
                    BEGIN 
                    UPDATE SO_MATERIAL_P_MASTER SET DATE = '" + dtp_DATE.Value.ToString() + "',CUSTOMER_ID = '" + cmbCustomer.SelectedValue.ToString() + @"',
                    DESCRIPTION = '" + txtDescript.Text + "',SALE_TYPE = '" + salesType + @"',
                    CREDIT_DAYS = '" + txtCreditDays.Text + "',TOTAL_WEIGHT = '" + txtQuantity.Text +"',[STATUS] = '"+status+ @"',REMAINING_WEIGHT = ((" + classHelper.AvoidInjection(txtQuantity.Text) + @" - TOTAL_WEIGHT)+REMAINING_WEIGHT),
                    MUAND_RATE = '"+classHelper.AvoidInjection(txtMuandRate.Text)+"',MODIFICATION_DATE = GETDATE(),MODIFIED_BY = '" + Classes.Helper.userId + @"' WHERE MPM_ID = '" + dId + @"'; 
                    UPDATE SALES_PROGRAM_MASTER SET CUSTOMER_ID = '" + cmbCustomer.SelectedValue.ToString() + @"' WHERE SOD_ID = '" + dId + @"' AND SO_TYPE = 'M';                    
                    END
                    ELSE
                    BEGIN
                    INSERT INTO SO_MATERIAL_P_MASTER (DATE,CUSTOMER_ID,DESCRIPTION,CREDIT_DAYS,CREATED_BY,CREATION_DATE,TOTAL_WEIGHT,INVOICE_NO,SALE_TYPE,[STATUS],REMAINING_WEIGHT,MUAND_RATE) 
                    VALUES ('" + dtp_DATE.Value.ToString() + "','" + cmbCustomer.SelectedValue.ToString() + "','" + txtDescript.Text + "','" + txtCreditDays.Text + "','" + Classes.Helper.userId + @"',
                    GETDATE(),'" + txtQuantity.Text + "','" + lblPI.Text + "','" + salesType + "','"+status+ "','" + txtQuantity.Text + "','"+classHelper.AvoidInjection(txtMuandRate.Text)+@"'); 
                    END 
                    DELETE FROM SO_MATERIAL_P_DETAIL WHERE MPM_ID = '" + dId + @"'; 
                    " + detailQuery+@"";
                classHelper.query += " COMMIT TRAN";
                if (classHelper.InsertUpdateDelete(classHelper.query) >= 1)
                {
                    classHelper.ShowMessageBox("Record Saved Sucessfully.", "Information");
                    Clear();
                    LoadGrid();
                }
            }
        }

        //get data from grid on click
        private void load_data_fromGrid(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.grdSEARCH.Rows[e.RowIndex];
                id = row.Cells["MPM_ID"].Value.ToString();
                is_edit = 1;

                dtp_DATE.Text = row.Cells["DATE"].Value.ToString();
                lblPI. Text = row.Cells["INVOICE #"].Value.ToString();
                cmbCustomer.SelectedValue = row.Cells["CUSTOMER_ID"].Value.ToString();
                txtDescript.Text = row.Cells["DESCRIPTION"].Value.ToString();
                txtCreditDays.Text = row.Cells["CREDIT DAYS"].Value.ToString();
                txtQuantity.Text = row.Cells["WEIGHT"].Value.ToString();
                txtMuandRate.Text = row.Cells["MUAND RATE"].Value.ToString(); 
                if (row.Cells["SALES TYPE"].Value.ToString().Equals("CASH"))
                {
                    rdbCash.Checked = true;
                }
                else {
                    rdbCredit.Checked = true;
                }
                grdItems.Rows.Clear();
                classHelper.GetProductMaterialSODetails(Convert.ToInt16(id),grdItems);
                if (Convert.ToChar(row.Cells["STATUS"].Value.ToString()) == '0')
                {
                    chkDiscard.Checked = true;
                }
                else
                {
                    chkDiscard.Checked = false;
                }
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
            grdSEARCH.Columns["MPM_ID"].Visible = false;
            grdSEARCH.Columns["CUSTOMER_ID"].Visible = false;
            grdSEARCH.Columns["AMOUNT"].Visible = false;
            grdSEARCH.Columns["STATUS"].Visible = false;

        }

        private void btnCLEAR_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void grdSEARCH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           load_data_fromGrid(e); 
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
        }

        private void grdItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.grdItems.Rows[e.RowIndex];
                cmbItem.SelectedValue = row.Cells[0].Value.ToString();
                //txtQuantity.Text = row.Cells[2].Value.ToString();
                txtRate.Text = row.Cells[2].Value.ToString();
                
                grdItems.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void cmbItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GetProductRate();
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
    }
    }

