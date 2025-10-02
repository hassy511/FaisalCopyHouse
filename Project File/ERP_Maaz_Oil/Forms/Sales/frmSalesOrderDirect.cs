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
    public partial class frmSalesOrderDirect : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        string id = "";
        int is_edit = 0;
        char rateType = 'M';

        public frmSalesOrderDirect()
        {
            InitializeComponent();
        }
        private void TotalCalculation()
        {
            double muandRate = 0;
            if (!txtMuandRate.Text.Trim().Equals(""))
            {
                muandRate = Convert.ToDouble(txtMuandRate.Text);
                txtKgRate.Text = Math.Round((muandRate / 37.324),4).ToString();
                txtTotal.Text = Math.Round((Convert.ToDouble(txtWeight.Text) * Convert.ToDouble(txtKgRate.Text)),4).ToString();
            }
        }

        private void TotalCalculationKg()
        {
            double kgRate = 0;
            if (!txtKgRate.Text.Trim().Equals(""))
            {
                kgRate = Convert.ToDouble(txtKgRate.Text);
                txtMuandRate.Text = Math.Round((kgRate * 37.324), 4).ToString();
                txtTotal.Text = Math.Round((Convert.ToDouble(txtWeight.Text) * Convert.ToDouble(txtKgRate.Text)), 4).ToString();
            }
        }

        private void GenerateSONumber()
        {
            classHelper.GenerateSONumber(lblSOno);
            //classHelper.query = @"SELECT
            //(SELECT COUNT(SOD_ID) FROM SALES_ORDER_DIRECT)+
            //(SELECT COUNT(SOPM_ID) FROM SALES_ORDER_PRODUCT_MASTER)+
            //(SELECT COUNT(MPM_ID) FROM SO_MATERIAL_P_MASTER)+1";
            //lblSO.Text = "SO-" + classHelper.GetMaxValue(classHelper.query) + "-" + DateTime.Now.Year;
        }

        private void LoadGrid() {
            classHelper.query = @"SELECT A.SOD_ID,A.DATE,A.INVOICE_NO AS [INVOICE #],A.CUSTOMER_ID,B.COA_NAME AS [CUSTOMER],
            CASE WHEN A.SALES_TYPE = 0 THEN 'CASH' ELSE 'CREDIT' END AS [SALES TYPE],C.MATERIAL_NAME AS [MATERIAL TYPE],
            A.TOTAL_KGS AS [WEIGHT],
            A.RATE [KG RATE],ROUND((A.RATE * 37.324),2) AS [MUAND RATE],(A.TOTAL_KGS * A.RATE) AS [AMOUNT],A.DESCRIPTION,
            A.CREDIT_DAYS AS [CREDIT DAYS],A.MATERIAL_ID,[STATUS]
            FROM SALES_ORDER_DIRECT A,COA B,MATERIALS C
            WHERE A.CUSTOMER_ID = B.COA_ID AND A.MATERIAL_ID = C.MATERIAL_ID
            ORDER BY A.SOD_ID DESC";
            classHelper.LoadGrid(grdSEARCH, classHelper.query);
        }
        //load COMBO BOXES
        private void LoadCustomer()
        {
            classHelper.LoadCustomers(cmbCustomer);
        }

        //clear fields in form
        private void clear() {
            dtp_DATE.Value = DateTime.Now;
            cmbCustomer.SelectedIndex = 0;
            cmbMaterial.SelectedIndex = 0;
            txtDescription.Clear();
            txtWeight.Text = "0";
            txtKgRate.Text = "0";
            txtMuandRate.Text = "0";
            txtTotal.Text = "0";
            txtCreditDays.Text = "0";
            rdbCash.Checked = true;
            chkDiscard.Checked = false;
            GenerateSONumber();
        }

        private void Save() {
            if (cmbCustomer.SelectedIndex == 0)
            {
                classHelper.ShowMessageBox("Customer is not selected, please select customer.", "Warning");
                cmbCustomer.Focus();
            }
            else if (cmbMaterial.SelectedIndex == 0)
            {
                classHelper.ShowMessageBox("Material is not selected, please select material.", "Warning");
                cmbMaterial.Focus();
            }
            else if (txtWeight.Text.Trim().Equals(""))
            {
                classHelper.ShowMessageBox("Weight Field is empty.", "Warning");
                txtWeight.Focus();
            }
            else if (txtMuandRate.Text.Trim().Equals("") || txtMuandRate.Text.Trim().Equals(""))
            {
                classHelper.ShowMessageBox("Muand Rate Field is empty.", "Warning");
                txtMuandRate.Focus();
            }
            else if (txtCreditDays.Text.Trim().Equals(""))
            {
                classHelper.ShowMessageBox("Credit Days Field is empty.", "Warning");
                txtCreditDays.Focus();
            }
            else
            {
                char status = '1';
                if (chkDiscard.Checked == true) {
                    status = '0';
                }
                int salesType = 0;
                if(rdbCredit.Checked == true) {
                    salesType = 1;
                }
                classHelper.query = "BEGIN TRAN ";
                classHelper.query += @"IF EXISTS (select SOD_ID from SALES_ORDER_DIRECT WHERE SOD_ID ='" + id +
                    "')BEGIN  UPDATE SALES_ORDER_DIRECT SET DATE = '" + Classes.Helper.ConvertDatetime(dtp_DATE.Value.Date) +
                    "',TOTAL_KGS = '" + classHelper.AvoidInjection(txtWeight.Text) +
                    "',CUSTOMER_ID = '" + cmbCustomer.SelectedValue.ToString() +
                    "',[DESCRIPTION] = '" + classHelper.AvoidInjection(txtDescription.Text) +
                    "',CREDIT_DAYS = '" + classHelper.AvoidInjection(txtCreditDays.Text) +
                    "',RATE = '" + classHelper.AvoidInjection(txtKgRate.Text) +
                    "',MATERIAL_ID = '" + cmbMaterial.SelectedValue.ToString() + "', MODIFICATION_DATE = GETDATE(), MODIFIED_BY = '" + Classes.Helper.userId
                    + "',SALES_TYPE = '"+salesType+ "',REMAINING_WEIGHT = ((" + classHelper.AvoidInjection(txtWeight.Text) + " - TOTAL_KGS)+REMAINING_WEIGHT),[STATUS] = '"+status+"' WHERE SOD_ID = '" + id +
                    @"'; 
                    UPDATE SALES_PROGRAM_MASTER SET CUSTOMER_ID = '" + cmbCustomer.SelectedValue.ToString() + @"' WHERE SOD_ID = '" + id + @"' AND SO_TYPE = 'D'; END                    
                    ELSE BEGIN INSERT INTO SALES_ORDER_DIRECT VALUES('" + Classes.Helper.ConvertDatetime(dtp_DATE.Value.Date) +
                    "','" + lblSOno.Text + "','" + cmbCustomer.SelectedValue.ToString() + "','"
                    + classHelper.AvoidInjection(txtCreditDays.Text) + "','"
                    + classHelper.AvoidInjection(txtDescription.Text) + "','"
                    + classHelper.AvoidInjection(txtWeight.Text) + "','"
                    + classHelper.AvoidInjection(txtKgRate.Text) + "','"
                    + salesType + "','" + Classes.Helper.userId + @"',GETDATE(),NULL,NULL,
                    '" + classHelper.AvoidInjection(txtWeight.Text) +
                    "','" + cmbMaterial.SelectedValue.ToString() + "','"+status+"'); END";

                    //classHelper.query += @"IF((SELECT FOURMULA_ID FROM PRODUCTS_FORMULA WHERE CUSTOMER_ID = '"+cmbCustomer.SelectedValue.ToString()+"' AND CASH_CREDIT = '"+salesType+@"') = 1)
                    //BEGIN
                    //   UPDATE PRODUCTS_FORMULA SET KG_RATE = '"+ classHelper.AvoidInjection(txtKgRate.Text) + "' WHERE CUSTOMER_ID = '" + cmbCustomer.SelectedValue.ToString() + "' AND CASH_CREDIT = '" + salesType + @"'
                    //END
                    //ELSE 
                    //BEGIN
                    //    UPDATE PRODUCTS_FORMULA SET MUAND_RATE = '"+ classHelper.AvoidInjection(txtMuandRate.Text) + "' WHERE CUSTOMER_ID = '" + cmbCustomer.SelectedValue.ToString() + "' AND CASH_CREDIT = '" + salesType + @"'
                    //END";

                classHelper.query += " COMMIT TRAN";

                if (classHelper.InsertUpdateDelete(classHelper.query) >= 1)
                {
                    classHelper.ShowMessageBox("Record Saved Sucessfully.", "Information");
                    LoadGrid();
                    clear();
                }
            }
        }

        //get data from grid on click
        private void load_data_fromGrid(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.grdSEARCH.Rows[e.RowIndex];
                id = row.Cells["SOD_ID"].Value.ToString();
                is_edit = 1;
                lblSOno.Text = row.Cells["INVOICE #"].Value.ToString();
                dtp_DATE.Text = row.Cells["DATE"].Value.ToString();
                cmbCustomer.SelectedValue = row.Cells["CUSTOMER_ID"].Value.ToString();
                cmbMaterial.SelectedValue = row.Cells["MATERIAL_ID"].Value.ToString();
                if (row.Cells["SALES TYPE"].Value.ToString().Equals("CASH"))
                {
                    rdbCash.Checked = true;
                }
                else {
                    rdbCredit.Checked = true;
                }
                txtDescription.Text = row.Cells["DESCRIPTION"].Value.ToString();
                txtCreditDays.Text = row.Cells["CREDIT DAYS"].Value.ToString();
                txtWeight.Text = Math.Round(Convert.ToDecimal(row.Cells["WEIGHT"].Value.ToString()),4).ToString();
                txtKgRate.Text = Math.Round(Convert.ToDecimal(row.Cells["KG RATE"].Value.ToString()), 4).ToString();
                txtMuandRate.Text = Math.Round(Convert.ToDecimal(row.Cells["MUAND RATE"].Value.ToString())).ToString();
                txtTotal.Text = Math.Round(Convert.ToDecimal(row.Cells["AMOUNT"].Value.ToString()), 4).ToString();
                if (Convert.ToChar(row.Cells["STATUS"].Value.ToString()) == '0')
                {
                    chkDiscard.Checked = true;
                }
                else {
                    chkDiscard.Checked = false;
                }
            }
        }

        private void frm_AddGroupAccounts_Load(object sender, EventArgs e)
        {
            GenerateSONumber();
            LoadGrid();
            LoadCustomer();
            classHelper.LoadMaterial(1, cmbMaterial);
        }

        private void txtSEARCH_TextChanged(object sender, EventArgs e)
        {
            classHelper.SalesOrderDirectSearch(txtSEARCH, grdSEARCH);
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void grdSEARCH_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            grdSEARCH.Columns["SOD_ID"].Visible = false;
            grdSEARCH.Columns["CUSTOMER_ID"].Visible = false;
            grdSEARCH.Columns["SALES TYPE"].Visible = false;
            //grdSEARCH.Columns["MUAND RATE"].Visible = false;
            grdSEARCH.Columns["AMOUNT"].Visible = false;
            grdSEARCH.Columns["MATERIAL_ID"].Visible = false;
            grdSEARCH.Columns["STATUS"].Visible = false;
        }

        private void btnCLEAR_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void grdSEARCH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            load_data_fromGrid(e);
        }
        
        private void txtWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                classHelper.AllowNumbers(e);
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void txtMuandRate_TextChanged(object sender, EventArgs e)
        {
            if (!txtMuandRate.Text.Trim().Equals("") && rateType == 'M')
            {
                TotalCalculation();
            }
        }

        private void txtWeight_TextChanged(object sender, EventArgs e)
        {
            if (!txtWeight.Text.Trim().Equals("")) {
                TotalCalculation();
            }
        }

        private void rdb40_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdb37_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbCustomer.SelectedIndex != 0) {
                txtCreditDays.Text = classHelper.GetCustomerCreditDays(Convert.ToInt32(cmbCustomer.SelectedValue.ToString())).ToString();
            }
        }

        private void txtWeight_Leave(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt.Text.Trim().Equals("")) {
                txt.Text = "0";
            }
        }

        private void cmbMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMaterial.Text.Equals("CANOLA"))
            {
                txtKgRate.Enabled = true;
                txtKgRate.Text = "0";
                txtMuandRate.Text = "0";
                txtMuandRate.Enabled = false;
                rateType = 'K';
                
            }
            else {
                txtMuandRate.Enabled = true;
                txtKgRate.Enabled = false;
                txtKgRate.Text = "0";
                txtMuandRate.Text = "0";
                rateType = 'M';
            }
        }

        private void txtKgRate_TextChanged(object sender, EventArgs e)
        {
            if (!txtKgRate.Text.Trim().Equals("") && rateType == 'K')
            {
                TotalCalculationKg();
            }
        }

        private void btnDetailReport_Click(object sender, EventArgs e)
        {
            if (!id.Equals("0"))
            {
                Purchases.SOInwardReport clsSOInward = new Purchases.SOInwardReport();
                clsSOInward.SOInward_Report(Convert.ToInt32(id));
            }
        }
    }
    }

