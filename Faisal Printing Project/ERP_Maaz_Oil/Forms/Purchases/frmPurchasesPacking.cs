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
    public partial class frmPurchasesPacking : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        string id = "";
        int is_edit = 0;

        public frmPurchasesPacking()
        {
            InitializeComponent();
        }

        private void GeneratePINumber()
        {
            classHelper.query = "SELECT COUNT(PI_ID)+1 FROM PURCHASES";
            lblPI.Text = "PI-" + classHelper.GetMaxValue(classHelper.query) + "-" + DateTime.Now.Year;
        }

        private void LoadGrid()
        {
            classHelper.query = @"SELECT A.PPMI_ID,A.DATE,A.INVOICE_NO,A.SUPPLIER_ID,B.COA_NAME AS [SUPPLIER],A.VEHICLE_NO,A.DESCRIPTION,A.TOTAL,A.CREDIT_DAYS AS [CREDIT DAYS]
            FROM PURCHASES_PACKING_MASTER A,COA B
            WHERE A.SUPPLIER_ID = B.COA_ID";
            classHelper.LoadGrid(grdSEARCH, classHelper.query);
        }
        //load COMBO BOXES
        private void LoadSuppliers()
        {
            classHelper.LoadSuppliers(cmbSupplier);
        }

        //load item COMBO BOXES
        private void LoadPackingItems()
        {
            classHelper.LoadPackingItems(cmbItem);
        }
        
        //clear fields in form
        private void Clear() {
            GeneratePINumber();
            dtp_DATE.Value = DateTime.Now;
            cmbSupplier.SelectedIndex = 0;
            txtVehNumber.Clear();
            txtDescript.Clear();
            cmbItem.SelectedIndex = 0;
            txtQuantity.Text = "0";
            txtRate.Text = "0";
            txtTotal.Text = "0";
            txtCreditDays.Text = "0";
            txtSEARCH.Clear();
            grdItems.Rows.Clear();
            id = "";
            is_edit = 0;
        }

        private void ItemsTotalSum()
        {
            if (grdItems.Rows.Count > 0)
            {
                txtTotal.Text = grdItems.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToDecimal(t.Cells[4].Value)).ToString();
            }
        }

        private void AddItemRow()
        {
            if (cmbItem.SelectedIndex == 0)
            {
                MessageBox.Show("Select Item", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                grdItems.Rows.Add(cmbItem.SelectedValue.ToString(), cmbItem.Text, txtQuantity.Text, txtRate.Text, (Convert.ToDecimal(txtQuantity.Text) * Convert.ToDecimal(txtRate.Text)));
                ItemsTotalSum();
                cmbItem.SelectedIndex = 0;
                txtQuantity.Text = "0";
                txtRate.Text = "0";
            }
        }

        private void Save() {
            if (cmbSupplier.SelectedIndex == 0)
            {
                classHelper.ShowMessageBox("Supplier is not selected, please select Supplier.", "Warning");
                cmbSupplier.Focus();
                return;
            }
            else if (txtVehNumber.Text.Trim().Equals(""))
            {
                classHelper.ShowMessageBox("Vehicle Number field is blank.", "Warning");
                txtVehNumber.Focus();
            }
            else if (grdItems.Rows.Count <= 0)
            {
                classHelper.ShowMessageBox("No Item Found.", "Warning");
                cmbItem.Focus();
            }
            else
            {
                string dId = id;
                string masterId = id;
                if (id.Equals(""))
                {
                    id = "(SELECT MAX(PPMI_ID) FROM PURCHASES_PACKING_MASTER)";
                    masterId = id;
                }

                string detailQuery = "";
                
                foreach (DataGridViewRow rows in grdItems.Rows)
                {
                    detailQuery += @"INSERT INTO PURCHASES_PACKING_DETAILS (PPM_ID,P_MATERIAL_ID,QTY,RATE)
                    VALUES("+masterId+",'"+ rows.Cells[0].Value.ToString() + "','" + rows.Cells[2].Value.ToString() + "','" + rows.Cells[3].Value.ToString() + @"');
                    INSERT INTO MATERIAL_ITEM_LEDGER
                    (DATE, MATERIAL_ID, REF_NO, ENTRY_FROM, STOCK_IN, STOCK_OUT, COST_AMT, SALE_AMT, L_ID, CREATED_BY, CREATION_DATE, COMPANY_ID)
                    VALUES('" + dtp_DATE.Value.ToString() + "','" + rows.Cells[0].Value.ToString() + "' ," + id + ",'PURCHASES PACKING','" + rows.Cells[2].Value.ToString() + "',0,'" + rows.Cells[3].Value.ToString() + @"',
                            0,1,'" + Classes.Helper.userId + @"',GETDATE(),1);";
                }

                classHelper.query = "BEGIN TRAN ";
                classHelper.query += @"IF EXISTS (select PPMI_ID from PURCHASES_PACKING_MASTER WHERE PPMI_ID ='" + dId + @"') 
                    BEGIN
                    UPDATE PURCHASES_PACKING_MASTER SET DATE = '" + dtp_DATE.Value.ToString() + "',SUPPLIER_ID = '" + cmbSupplier.SelectedValue.ToString() + @"',
                    VEHICLE_NO = '" + txtVehNumber.Text + "',DESCRIPTION = '" + txtDescript.Text + @"',
                    TOTAL = '" + txtTotal.Text + "',CREDIT_DAYS = '" + txtCreditDays.Text + @"',
                    MODIFICATION_DATE = GETDATE(),MODIFIED_BY = '" + Classes.Helper.userId + @"' WHERE PPMI_ID = '" + dId + @"';
                    END
                    ELSE
                    BEGIN
                    INSERT INTO PURCHASES_PACKING_MASTER (DATE,SUPPLIER_ID,VEHICLE_NO,DESCRIPTION,CREDIT_DAYS,CREATED_BY,CREATION_DATE,TOTAL,INVOICE_NO) 
                    VALUES ('" + dtp_DATE.Value.ToString() + "','" + cmbSupplier.SelectedValue.ToString() + "','" + txtVehNumber.Text + "','" + txtDescript.Text + "','" + txtCreditDays.Text + "','" + Classes.Helper.userId + @"',
                    GETDATE(),'" + txtTotal.Text + "','" + lblPI.Text + @"')
                    END
                    DELETE FROM PURCHASES_PACKING_DETAILS WHERE PPM_ID = '" + dId + @"'
                    DELETE FROM MATERIAL_ITEM_LEDGER WHERE REF_NO = '" + dId + @"' AND ENTRY_FROM = 'PURCHASES PACKING'
                    " + detailQuery+@"
                    DELETE FROM LEDGERS WHERE REF_ID = '" + dId + @"' AND ENTRY_OF = 'PURCHASES PACKING'
                    INSERT INTO LEDGERS(DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
                    VALUES('" + dtp_DATE.Value.ToString() + "','" + cmbSupplier.SelectedValue.ToString() + "'," + id + ",'PURCHASES PACKING','" + lblPI.Text + @"',
                    '" + txtTotal.Text + "',0,'" + txtDescript.Text + "','" + Classes.Helper.userId + @"',GETDATE(),1);
                    INSERT INTO LEDGERS(DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
                    VALUES('" + dtp_DATE.Value.ToString() + "','"+Classes.Helper.purchasesId+"'," + id + ",'PURCHASES PACKING','" + lblPI.Text + @"',0,
                    '" + txtTotal.Text + "','" + txtDescript.Text + "','" + Classes.Helper.userId + @"',GETDATE(),1);";
                classHelper.query += "COMMIT TRAN";
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
                id = row.Cells[0].Value.ToString();
                is_edit = 1;

                dtp_DATE.Text = row.Cells[1].Value.ToString();
                lblPI. Text = row.Cells[2].Value.ToString();
                cmbSupplier.SelectedValue = row.Cells[3].Value.ToString();
                txtVehNumber.Text = row.Cells[5].Value.ToString();
                txtDescript.Text = row.Cells[6].Value.ToString();
                txtTotal.Text = row.Cells[7].Value.ToString();
                txtCreditDays.Text = row.Cells[8].Value.ToString();

                classHelper.query = @"SELECT A.P_MATERIAL_ID,B.MATERIAL_NAME,A.QTY,A.RATE 
                FROM PURCHASES_PACKING_DETAILS A,MATERIALS B
                WHERE A.P_MATERIAL_ID = B.MATERIAL_ID AND A.PPM_ID = '"+id+"'";
                classHelper.LoadDataPackingPurchases(classHelper.query,grdItems);
            }
        }

        private void frm_AddGroupAccounts_Load(object sender, EventArgs e)
        {
            GeneratePINumber();
            LoadGrid();
            LoadSuppliers();
            LoadPackingItems();
        }

        private void txtSEARCH_TextChanged(object sender, EventArgs e)
        {
           classHelper.Packing_Purchases_search(txtSEARCH, grdSEARCH);
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {
            Save();
        }
        
        private void grdSEARCH_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            grdSEARCH.Columns[0].Visible = false;
            grdSEARCH.Columns[3].Visible = false;
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
                txtQuantity.Text = row.Cells[2].Value.ToString();
                txtRate.Text = row.Cells[3].Value.ToString();
                ItemsTotalSum();
                grdItems.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void cmbItem_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    }

