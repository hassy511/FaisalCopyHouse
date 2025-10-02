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
    public partial class frmSalesInvoice : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        string id = "";
        int is_edit = 0;
        float lastWeight = 0;
        float remainingWeight = 0;

        public frmSalesInvoice()
        {
            InitializeComponent();
        }
        private void GenerateSINumber()
        {
            classHelper.query = "SELECT COUNT(SM_ID)+1 FROM SALES_MASTER";
            lblPRO.Text = "SI-" + classHelper.GetMaxValue(classHelper.query) + "-" + DateTime.Now.Year;
        }
        //private void RowSum(DataGridViewCellEventArgs e)
        //{
        //    if (grdItems.Rows.Count > 0)
        //    {
        //        if (string.IsNullOrEmpty(grdItems.Rows[e.RowIndex].Cells[2].Value as string) || grdItems.Rows[e.RowIndex].Cells[2].Value.ToString().Equals("."))
        //        {
        //            grdItems.Rows[e.RowIndex].Cells[2].Value = "0";
        //        }
        //        if (string.IsNullOrEmpty(grdItems.Rows[e.RowIndex].Cells[3].Value as string) || grdItems.Rows[e.RowIndex].Cells[3].Value.ToString().Equals("."))
        //        {
        //            grdItems.Rows[e.RowIndex].Cells[3].Value = "0";
        //        }
        //    }

        //    if (grdItems.CurrentCell.ColumnIndex.Equals(2) && e.RowIndex != -1)
        //    {
        //        if (double.Parse(grdItems.Rows[e.RowIndex].Cells[2].Value.ToString()) > double.Parse(grdItems.Rows[e.RowIndex].Cells[8].Value.ToString()))
        //        {
        //            MessageBox.Show("Input Quantity is greater than Available Quantity", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            grdItems.Rows[e.RowIndex].Cells[2].Value = 0;

        //        }
        //    }
        //    if (grdItems.CurrentCell.ColumnIndex.Equals(2) && e.RowIndex != -1)
        //    {
        //        grdItems.Rows[e.RowIndex].Cells[6].Value = (Convert.ToDouble(grdItems.Rows[e.RowIndex].Cells[2].Value.ToString()) * Convert.ToDouble(grdItems.Rows[e.RowIndex].Cells[3].Value.ToString()));
        //    }
        //    else
        //    {
        //        grdItems.Rows[e.RowIndex].Cells[6].Value = (Convert.ToDouble(grdItems.Rows[e.RowIndex].Cells[2].Value.ToString()) * Convert.ToDouble(grdItems.Rows[e.RowIndex].Cells[3].Value.ToString()));
        //    }
        //    TotalSum();
        //}

        private void TotalSum()
        {
            if (grdItems.Rows.Count > 0)
            {
                txtQty.Text = grdItems.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToDecimal(t.Cells[2].Value)).ToString();

                txtTotalWeight.Text = grdItems.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToDecimal(t.Cells[3].Value)).ToString();

                txtTotal.Text = grdItems.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToDecimal(t.Cells[6].Value)).ToString();
            }
        }

        private void LoadGrid()
        {
            //classHelper.query = @"SELECT A.GPM_ID,A.DATE,A.INVOICE_NO AS [GATE PASS #],A.CUSTOMER_ID,B.COA_NAME AS [CUSTOMER],
            //C.GPD_ID,A.INVOICE_NO AS [GATE PASS #],A.DESCRIPTION,A.VEHICLE_NO,A.WEIGHT,A.QTY,A.TOTAL
            //FROM GATE_PASS_MASTER A,COA B,GATE_PASS_DETAILS C
            //WHERE A.CUSTOMER_ID = B.COA_ID";
            //classHelper.LoadGrid(grdSEARCH, classHelper.query);
        }
        //load COMBO BOXES
        private void LoadCustomers()
        {
            classHelper.LoadCustomers(cmbCustomer);
        }

        private void LoadGatePass()
        {
            classHelper.LoadGP(cmbPro, Convert.ToInt16(cmbCustomer.SelectedValue.ToString()));
        }
        private void LoadCustomerDetails()
        {
            classHelper.query = @"SELECT B.NAME AS [SALES PERSON],C.AREA_NAME,a.CREDIT_DAYS
            FROM CUSTOMER_PROFILE A,SALES_PERSONS B,AREA C
            WHERE A.SALE_PER_ID = B.SALES_PER_ID AND A.AREA_ID = C.AREA_ID AND COA_ID = '" + cmbCustomer.SelectedValue.ToString()+"'";
            classHelper.LoadCustomerDetails(classHelper.query,txtSalePerson,txtArea,txtDueDate);
        }
        private void LoadDueDate()
        {
            classHelper.query = @"SELECT B.NAME AS [SALES PERSON],C.AREA_NAME 
            FROM CUSTOMER_PROFILE A,SALES_PERSONS B,AREA C
            WHERE A.SALE_PER_ID = B.SALES_PER_ID AND A.AREA_ID = C.AREA_ID AND COA_ID = '" + cmbCustomer.SelectedValue.ToString() + "'";
            classHelper.LoadDueDate(classHelper.query, txtDueDate);
        }

        //clear fields in form
        private void Clear() {
            GenerateSINumber();
            dtp_DATE.Value = DateTime.Now;
            cmbCustomer.SelectedIndex = 0;
            if (cmbPro.Items.Count > 0) {
                cmbPro.SelectedIndex = 0;
            }
            cmbPro.Enabled = false;
            txtArea.Clear();
            txtDescript.Clear();
            txtSalePerson.Clear();
            txtVehicle.Clear();
            txtDueDate.Clear();
            txtTotalWeight.Text = "0";
            txtQty.Text = "0";
            txtTotal.Text = "0";
            grdItems.Rows.Clear();
            id = "";
            is_edit = 0;
            lastWeight = 0;
            remainingWeight = 0;
        }
        private void Save() {

            

            

            if (grdItems.Rows.Count > 0) {
                //string soIType = "pro";
                //string soType = "PROGRAM";
                //string updateQuery = "UPDATE SALES_PROGRAM_MASTER SET REMAINING_WEIGHT = (TOTAL - (REMAINING_WEIGHT+"+txtTotalWeight+")) WHERE SPM_ID = '"+cmbPro.SelectedValue.ToString()+"'";
                //if (soIType.Substring(0, 2).Equals("so")) {
                //    soIType = "so";
                //    soType = "SALE ORDER";
                //    updateQuery = "UPDATE SALES_ORDER_PRODUCT_MASTER SET REMAINING_WEIGHT = (TOTAL - (REMAINING_WEIGHT+" + txtTotalWeight + ")) WHERE SOPM_ID = '" + cmbPro.SelectedValue.ToString() + "'";
                //}

                string dId = id;
                string masterId = id;
                if (id.Equals(""))
                {
                    id = "(SELECT MAX(SM_ID) FROM SALES_MASTER)";
                    masterId = id;
                }

                string detailQuery = "";

                foreach (DataGridViewRow rows in grdItems.Rows)
                {
                    detailQuery += @"INSERT INTO SALES_DETAILS (SM_ID,PRODUCT_ID,QTY,WEIGHT,RATE) VALUES 
                    (" + masterId+ ",'" + rows.Cells[0].Value.ToString() + "'," + rows.Cells[2].Value.ToString() + @",
                     '" + rows.Cells[3].Value.ToString() + "','" + rows.Cells[5].Value.ToString() + @"');";

                    detailQuery += @"INSERT INTO PRODUCT_ITEM_LEDGER
                    (DATE, PRODUCT_ID, REF_NO, ENTRY_FROM, STOCK_IN, STOCK_OUT, COST_AMT, SALE_AMT, L_ID, CREATED_BY, CREATION_DATE, COMPANY_ID)
                    VALUES('" + dtp_DATE.Value.ToString() + "', '"+ rows.Cells[0].Value.ToString() + "', " + masterId + ", 'SALES', 0, '" + rows.Cells[2].Value.ToString() + @"',
                    '0','"+ rows.Cells[5].Value.ToString() + "', 1, '" + Classes.Helper.userId + @"', GETDATE(), 1); ";
                }

                classHelper.query = "BEGIN TRAN ";
                classHelper.query += @"IF EXISTS (select SM_ID from SALES_MASTER WHERE SM_ID ='" + dId + @"') 
                    BEGIN
                    UPDATE SALES_MASTER SET [DATE] = '" + dtp_DATE.Value.ToString() + "',CUSTOMER_ID = '" + cmbCustomer.SelectedValue.ToString() + @"',
                    GP_ID = '"+cmbPro.SelectedValue.ToString()+"', DESCRIPTION = '" + txtDescript.Text + @"',
                    VEHICLE_NO = '"+txtVehicle.Text+"',QTY = '"+txtQty.Text+"', TOTAL = '" + txtTotal.Text + "',WEIGHT = '" + txtTotalWeight.Text + @"',
                    MODIFICATION_DATE = GETDATE(),MODIFIED_BY = '" + Classes.Helper.userId + @"' WHERE SM_ID = '" + dId + @"';
                    END
                    ELSE
                    BEGIN
                    INSERT INTO SALES_MASTER 
                    (DATE,CUSTOMER_ID,GP_ID,INVOICE_NO,DESCRIPTION,VEHICLE_NO,WEIGHT,QTY,TOTAL,CREATED_BY,CREATION_DATE)
                    VALUES('" + dtp_DATE.Value.ToString() + "','" + cmbCustomer.SelectedValue.ToString() + "','"+cmbPro.SelectedValue.ToString()+@"',
                    '"+lblPRO.Text+"','"+txtDescript.Text+"','"+txtVehicle.Text+ "','" + txtTotalWeight.Text + "','" + txtQty.Text + @"',
                    '" + txtTotal.Text+"','" + Classes.Helper.userId + @"',GETDATE())
                    END
                    DELETE FROM SALES_DETAILS WHERE SM_ID = '" + dId + @"'
                    DELETE FROM PRODUCT_ITEM_LEDGER WHERE REF_NO = '" + dId + @"' AND ENTRY_FROM = 'SALES'
                    " + detailQuery + @";

                    DELETE FROM LEDGERS WHERE REF_ID = '" + dId + @"' AND ENTRY_OF = 'SALES'
                    INSERT INTO LEDGERS(DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
                    VALUES('" + dtp_DATE.Value.ToString() + "', '" + cmbCustomer.SelectedValue.ToString() + "', " + masterId + ", 'SALES', '" + lblPRO.Text + @"', 
                    '" + txtTotal.Text + "',0,'" + txtDescript.Text + "', '" + Classes.Helper.userId + @"', GETDATE(), 1);
                    INSERT INTO LEDGERS(DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
                    VALUES('" + dtp_DATE.Value.ToString() + "', '" + Classes.Helper.salesId + "', " + id + ", 'SALES', '" + lblPRO.Text + @"', 0,
                    '" + txtTotal.Text + "', '" + txtDescript.Text + "', '" + Classes.Helper.userId + @"', GETDATE(), 1);
                    ";
                classHelper.query += "COMMIT TRAN";
                if (classHelper.InsertUpdateDelete(classHelper.query) >= 1)
                {
                    classHelper.ShowMessageBox("Record Saved Sucessfully.", "Information");
                    Clear();
                    LoadGrid();
                }
            }
        }
        private void frm_AddGroupAccounts_Load(object sender, EventArgs e)
        {
            GenerateSINumber();
            //LoadGrid();
            LoadCustomers();
        }
        private void btnSAVE_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void btnCLEAR_Click(object sender, EventArgs e)
        {
            Clear();
        }
        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCustomer.SelectedIndex != 0)
            {
                grdItems.Rows.Clear();
                LoadGatePass();
                LoadCustomerDetails();
                cmbPro.Enabled = true;
            }
            else
            {
                if (cmbCustomer.Items.Count > 0)
                {
                    cmbCustomer.SelectedIndex = 0;
                }
            }
        }
        private void cmbSO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPro.SelectedIndex != 0)
            {
                char type = 'P';
                if (cmbPro.Text.Substring(0, 2).Equals("SO")) {
                    type = 'S';
                }
                if (grdItems.Rows.Count > 0)
                {
                    grdItems.Rows.Clear();
                }
                classHelper.LoadGPProducts(type, Convert.ToInt32(cmbPro.SelectedValue.ToString()), grdItems);
                
                TotalSum();
            }
            else
            {
                if (cmbPro.Items.Count > 0)
                {
                    cmbPro.SelectedIndex = 0;
                }
            }
        }

        private void grdItems_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var txtEdit = (TextBox)e.Control;
            txtEdit.KeyPress += EditKeyPress;
        }
        
        private void EditKeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || e.KeyChar == '.' || char.IsSeparator(e.KeyChar) || e.KeyChar == (char)Keys.Space || e.KeyChar == ' ' || Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void grdItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0)
            //{
            //    RowSum(e);
            //}
        }
    }
    }

