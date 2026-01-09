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
    public partial class frmSalesRateFormula : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        string id = "";
        int is_edit = 0;
        int isLoad = 0;
        public frmSalesRateFormula()
        {
            InitializeComponent();
        }
        
        //load COMBO BOXES
        private void LoadCustomer()
        {
            try
            {
                classHelper.query = @"SELECT '0' AS [id],'--SELECT CUSTOMER--' AS [name]
                UNION ALL
                SELECT COA_ID AS [id],COA_NAME AS [name] 
                FROM COA WHERE CA_ID = 21 AND STAT = 0";
                classHelper.LoadComboData(cmbCustomer, classHelper.query);
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
        }
        private void LoadFormulaType()
        {
            try
            {
                classHelper.query = @"SELECT '0' AS [id],'--SELECT FORMULA TYPE--' AS [name]
                UNION ALL
                SELECT FT_ID AS [id],FT_NAME AS [name] 
                FROM FORMULA_TYPE
                ORDER BY [name]";
                classHelper.LoadComboData(cmbFormula, classHelper.query);
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void LoadProducts()
        {
            try
            {
                if (isLoad == 1) {
                    return;
                }
                if (cmbCustomer.SelectedIndex == 0 )
                {
                    classHelper.ShowMessageBox("Select Customer", "Warning");
                    cmbCustomer.Focus();
                    return;
                }
                else if (cmbFormula.SelectedIndex == 0)
                {
                    classHelper.ShowMessageBox("Select Formula Type", "Warning");
                    cmbFormula.Focus();
                    return;
                }
                else {
                    int cashCredit = 0;
                    if (rdbCredit.Checked == true)
                    {
                        cashCredit = 1;
                    }
                    classHelper.LoadFormulaProduct(Convert.ToInt32(cmbCustomer.SelectedValue.ToString()), cashCredit, Convert.ToInt32(cmbFormula.SelectedValue.ToString()), grdItems);
                }
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        //clear fields in form
        private void clear() {
            isLoad = 1;
            cmbCustomer.SelectedIndex = 0;
            cmbFormula.SelectedIndex = 0;
            rdbCredit.Checked = true;
            id = "";
            grdItems.DataSource = null;
            is_edit = 0;
            isLoad = 0;
        }

        private void Save() {
            if (grdItems.Rows.Count <= 0) {
                classHelper.ShowMessageBox("No Product Found, please add Product.", "Warning");
                cmbCustomer.Focus();
            }
            else
            {
                int cashCredit = 0;
                if (rdbCredit.Checked == true) {
                    cashCredit = 1;
                }

                string detailQuery = "";

                if (cmbFormula.SelectedValue.ToString().Equals("2")) {
                    foreach (DataGridViewRow rows in grdItems.Rows)
                    {
                        detailQuery += @"INSERT INTO PRODUCTS_FORMULA (FOURMULA_ID,CASH_CREDIT,CUSTOMER_ID,PRODUCT_ID,PACKING_RATE,MUAND_RATE,MILLING,SALE_PRICE)
                        VALUES('"+cmbFormula.SelectedValue.ToString()+ "','"+cashCredit+ "','"+cmbCustomer.SelectedValue.ToString()+ "','"+ rows.Cells[0].Value.ToString() + @"',
                        '" + rows.Cells[5].Value.ToString() + "','" + rows.Cells[6].Value.ToString() + "','" + rows.Cells[7].Value.ToString() + "','" + rows.Cells[8].Value.ToString() + "');";
                    }
                }
                else if (cmbFormula.SelectedValue.ToString().Equals("1"))
                {
                    foreach (DataGridViewRow rows in grdItems.Rows)
                    {
                        detailQuery += @"INSERT INTO PRODUCTS_FORMULA (FOURMULA_ID,CASH_CREDIT,CUSTOMER_ID,PRODUCT_ID,CONSTANT_VALUE,KG_RATE,DIFFERENCE,ADDITION,[2x],SALE_PRICE)
                        VALUES('" + cmbFormula.SelectedValue.ToString() + "','" + cashCredit + "','" + cmbCustomer.SelectedValue.ToString() + "','" + rows.Cells[0].Value.ToString() + @"',
                        '" + rows.Cells[2].Value.ToString() + "','" + rows.Cells[3].Value.ToString() + "','" + rows.Cells[6].Value.ToString() + "','" + rows.Cells[7].Value.ToString() + @"',
                        '" + rows.Cells[8].Value.ToString() + "','" + rows.Cells[9].Value.ToString() + @"');";
                    }
                }
                classHelper.query = "BEGIN TRAN ";
                classHelper.query += @"DELETE FROM PRODUCTS_FORMULA WHERE CUSTOMER_ID = '"+cmbCustomer.SelectedValue.ToString()+"' AND CASH_CREDIT = '"+cashCredit+@"'
                "+detailQuery+@"";

                classHelper.query += " COMMIT TRAN";
                if (classHelper.InsertUpdateDelete(classHelper.query) >= 1)
                {
                    classHelper.ShowMessageBox("Record Saved Sucessfully.", "Information");
                    clear();
                }
            }
        }

        private void frm_AddGroupAccounts_Load(object sender, EventArgs e)
        {
            isLoad = 1;
            LoadCustomer();
            LoadFormulaType();
            isLoad = 0;
        }

        private void txtSEARCH_TextChanged(object sender, EventArgs e)
        {
           classHelper.ProductFormulaSearch(txtSEARCH, grdItems);
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {
            Save();

            
        }
        
        private void btnCLEAR_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void grdSEARCH_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (grdItems.Rows.Count <= 0) {
                return;
            }
            if (cmbFormula.SelectedValue.ToString().Equals("2")) {
                decimal netWeight = Convert.ToDecimal(grdItems.Rows[e.RowIndex].Cells[3].Value.ToString());
                decimal muandValue = 37.325M;
                decimal packingRate = Convert.ToDecimal(grdItems.Rows[e.RowIndex].Cells[5].Value.ToString());
                decimal milling = Convert.ToDecimal(grdItems.Rows[e.RowIndex].Cells[7].Value.ToString());
                decimal muandRate = Convert.ToDecimal(grdItems.Rows[e.RowIndex].Cells[6].Value.ToString());

                if (grdItems.Columns[e.ColumnIndex].Name == "MUAND RATE" || grdItems.Columns[e.ColumnIndex].Name == "MILLING" || grdItems.Columns[e.ColumnIndex].Name == "PACKING RATE")
                {
                    grdItems.Rows[e.RowIndex].Cells[8].Value = Math.Round(((((muandRate + milling) / muandValue) * netWeight) + packingRate), 2);
                }
            }
            else if (cmbFormula.SelectedValue.ToString().Equals("1"))
            {
                decimal kgRate = Convert.ToDecimal(grdItems.Rows[e.RowIndex].Cells[3].Value.ToString());
                decimal difference = Convert.ToDecimal(grdItems.Rows[e.RowIndex].Cells[6].Value.ToString());
                decimal constant = Convert.ToDecimal(grdItems.Rows[e.RowIndex].Cells[2].Value.ToString());
                decimal gross = Convert.ToDecimal(grdItems.Rows[e.RowIndex].Cells[4].Value.ToString());
                decimal x2 = Convert.ToDecimal(grdItems.Rows[e.RowIndex].Cells[8].Value.ToString());
                decimal addition = Convert.ToDecimal(grdItems.Rows[e.RowIndex].Cells[7].Value.ToString());
                if (x2 == 0) {
                    x2 = 1;
                }
                if (grdItems.Columns[e.ColumnIndex].Name == "CONSTANT KG" || grdItems.Columns[e.ColumnIndex].Name == "KG RATE" || grdItems.Columns[e.ColumnIndex].Name == "DIFFERENCE"
                    || grdItems.Columns[e.ColumnIndex].Name == "ADDITION" || grdItems.Columns[e.ColumnIndex].Name == "2x")
                {
                    grdItems.Rows[e.RowIndex].Cells[9].Value = Math.Round( ((((kgRate-difference) / constant) * (gross / x2)) + addition)*x2 , 2);
                }
            }
        }

        private void grdSEARCH_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var txtEdit = (TextBox)e.Control;
            txtEdit.KeyPress += EditKeyPress;
        }

        private void EditKeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == '.' || Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void cmbFormula_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void rdbCash_CheckedChanged(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void rdbCredit_CheckedChanged(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void grdItems_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            grdItems.Columns[0].Visible = false;
            if (cmbFormula.SelectedValue.ToString().Equals("2"))
            {
                grdItems.Columns[0].ReadOnly = true;
                grdItems.Columns[1].ReadOnly = true;
                grdItems.Columns[2].ReadOnly = true;
                grdItems.Columns[3].ReadOnly = true;
                grdItems.Columns[8].ReadOnly = true;
            }
            else if (cmbFormula.SelectedValue.ToString().Equals("1"))
            {
                grdItems.Columns[0].ReadOnly = true;
                grdItems.Columns[1].ReadOnly = true;
                grdItems.Columns[4].ReadOnly = true;
                grdItems.Columns[9].ReadOnly = true;
            }
        }
    }
    }

