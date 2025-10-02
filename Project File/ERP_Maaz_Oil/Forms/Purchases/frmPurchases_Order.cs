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
    public partial class frmPurchases_Order : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        int id = 0;
        bool isEdit = false;
        public frmPurchases_Order()
        {
            InitializeComponent();
        }

        private void GeneratePINumber()
        {
            classHelper.query = "SELECT ISNULL(COUNT(PO_ID),0)+1 FROM PURCHASES_ORDER";
            lblInvoice.Text = "PO-" + classHelper.GetMaxValue(classHelper.query) + "-" + DateTime.Now.Year;
        }



        private void LoadGrid()
        {
            classHelper.query = @" SELECT A.PO_ID AS [ID], A.PO_NUMBER AS[INVOICE #],
            A.[DATE], B.COA_NAME AS[SUPPLIER], A.[DESCRIPTION],A.SUPPLIER_ID
            FROM PURCHASES_ORDER A
            INNER JOIN COA B ON A.SUPPLIER_ID = B.COA_ID            
            ORDER BY [ID] DESC";
            classHelper.LoadGrid(grdSearch, classHelper.query);
        }

        private void LoadSuppliers()
        {
            classHelper.LoadSuppliers(cmbSupplier);
        }
        private void LoadProducts()
        {
            classHelper.LoadProducts(cmbProducts);
        }

        private void Clear()
        {
            GeneratePINumber();
            dtpDate.Value = DateTime.Now;
            cmbSupplier.SelectedIndex = 0;
            //txtCreditDays.Text = "0";
            txtDescription.Clear();
            cmbProducts.SelectedIndex = 0;
            txtQty.Text = "0";
            txtRate.Text = "0";
            txtTotal.Text = "0";
            txtSearch.Clear();
            id = 0;
            isEdit = false;
            gridProducts.Rows.Clear();
            LoadGrid(); // Make sure LoadGrid() refreshes data for the search grid
        }

        private void Save()
        {
            // Step 1: Validate fields
            if (cmbSupplier.SelectedIndex == 0)
            {
                classHelper.ShowMessageBox("Supplier is not selected, please select Supplier.", "Warning");
                cmbSupplier.Focus();
                return;
            }
            else if (gridProducts.Rows.Count <= 0)
            {
                classHelper.ShowMessageBox("Add Products.", "Warning");
                cmbProducts.Focus();
                return;
            }

            // Step 2: Build the SQL query
            string masterId = id.ToString();
            if (id.ToString().Equals("0"))
            {
                masterId = "(SELECT MAX(PO_ID) FROM PURCHASES_ORDER)";
            }

            classHelper.query = @"BEGIN TRY 
                           BEGIN TRANSACTION ";

            // Insert or update PURCHASE_ORDER
            classHelper.query += @"IF EXISTS (SELECT PO_ID FROM PURCHASES_ORDER WHERE PO_ID = '" + id + @"') 
            BEGIN
                UPDATE PURCHASES_ORDER 
                SET DATE = '" + dtpDate.Value.ToString() + @"',   
                    SUPPLIER_ID = '" + cmbSupplier.SelectedValue.ToString() + @"',
                    DESCRIPTION = '" + classHelper.AvoidInjection(txtDescription.Text) + @"',
                    MODIFICATION_DATE = GETDATE(), 
                    MODIFIED_BY = '" + Classes.Helper.userId + @"'
                WHERE PO_ID = '" + id + @"';
            END
            ELSE
            BEGIN
                INSERT INTO PURCHASES_ORDER (DATE, SUPPLIER_ID, DESCRIPTION, CREATION_DATE, CREATED_BY, PO_NUMBER) 
                VALUES 
                ('" + dtpDate.Value.ToString() + "', '" + cmbSupplier.SelectedValue.ToString() + @"', 
                '" + classHelper.AvoidInjection(txtDescription.Text) + @"', 
                GETDATE(), '" + Classes.Helper.userId + @"', 
                '" + lblInvoice.Text + @"');
            END";

            // Step 4: Insert details into PURCHASE_DETAIL
            classHelper.query += @" DELETE FROM PURCHASES_ORDER_DETAILS WHERE PO_ID = '" + id + @"';";
            foreach (DataGridViewRow row in gridProducts.Rows)
            {
                classHelper.query += @" INSERT INTO PURCHASES_ORDER_DETAILS (PO_ID, MATERIAL_ID, QTY, RATE) 
                               VALUES 
                               (" + masterId + ", '" + row.Cells["productId"].Value.ToString() + "', '" + row.Cells["qty"].Value.ToString() + @"', 
                               '" + row.Cells["rate"].Value.ToString() + @"');";
            }

            // Step 6: Commit transaction
            classHelper.query += @" COMMIT TRANSACTION; 
                         END TRY 
                         BEGIN CATCH 
                             IF @@TRANCOUNT > 0 
                                 ROLLBACK TRANSACTION; 
                             THROW;
                         END CATCH;";

            // Step 7: Execute query and handle result
            try
            {
                if (classHelper.InsertUpdateDelete(classHelper.query) >= 1)
                {
                    classHelper.ShowMessageBox("Record Saved Successfully.", "Information");

                    //// Optional: Ask for print
                    //DialogResult dialogResult = MessageBox.Show("Print Invoice?", "Purchases Invoice", MessageBoxButtons.YesNo);
                    //if (dialogResult == DialogResult.Yes)
                    //{
                    //    PrintInvoice();
                    //}

                    // Clear fields and refresh grid
                    Clear();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving data: " + ex.Message);
            }
        }





        private void PrintInvoice()
        {
            classHelper.mds.Tables["PI"].Clear();
            foreach (DataGridViewRow rows in gridProducts.Rows)
            {
                classHelper.dataR = classHelper.mds.Tables["PI"].NewRow();
                classHelper.dataR["PI_num"] = lblInvoice.Text;
                classHelper.dataR["date"] = dtpDate.Value.ToShortDateString();
                classHelper.dataR["supplier"] = cmbSupplier.Text;
                classHelper.dataR["description"] = txtDescription.Text;
                classHelper.dataR["material"] = rows.Cells["productId"].Value.ToString();
                classHelper.dataR["qty"] = Convert.ToDouble(rows.Cells["qty"].Value.ToString());
                classHelper.dataR["rate"] = Convert.ToDouble(rows.Cells["rate"].Value.ToString());
                classHelper.dataR["total"] = Convert.ToDouble(rows.Cells["total"].Value.ToString());
                //   classHelper.dataR["creditDays"] = txtCreditDays.Text;
                //   classHelper.dataR["dueDate"] = DateTime.Now.AddDays(Convert.ToInt32(txtCreditDays.Text));
                classHelper.mds.Tables["PI"].Rows.Add(classHelper.dataR);
            }
            classHelper.rpt = new ERP_Maaz_Oil.Forms.Reporting.frmReports();
            classHelper.rpt.GenerateReport("PI", classHelper.mds);
            classHelper.rpt.ShowDialog();
        }
        private void LoadPurchasesOrderDetails(int poId)
        {
            classHelper.LoadPurchasesOrderDetail(gridProducts, poId);
        }
        // private void LoadPurchaseDetails(int rawId)
        //     {
        //     classHelper.LoadPurchasesDetail(gridProducts, rawId);
        //  }

        private void LoadGridData(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.grdSearch.Rows[e.RowIndex];
                id = Convert.ToInt32(row.Cells["ID"].Value.ToString());
                lblInvoice.Text = row.Cells["INVOICE #"].Value.ToString();
                isEdit = true;
                dtpDate.Text = row.Cells["DATE"].Value.ToString();
                cmbSupplier.SelectedValue = row.Cells["SUPPLIER_ID"].Value.ToString();
                txtDescription.Text = row.Cells["DESCRIPTION"].Value.ToString();
                LoadPurchasesOrderDetails(id);
                TotalSum();
            }
        }


        private void frm_AddGroupAccounts_Load(object sender, EventArgs e)
        {
            GeneratePINumber();
            LoadGrid();
            LoadSuppliers();
            LoadProducts();
        }

        private void txtSEARCH_TextChanged(object sender, EventArgs e)
        {
            classHelper.PurchaseRaw_search(txtSearch, grdSearch);
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void grdSEARCH_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            grdSearch.Columns["SUPPLIER_ID"].Visible = false;
            // grdSearch.Columns["PRODUCT_MASTER_ID"].Visible = false;
        }

        private void btnCLEAR_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void grdSEARCH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadGridData(e);
        }
        private void TotalSum()
        {
            try
            {
                txtTotal.Text = gridProducts.Rows.Cast<DataGridViewRow>()
                    .Sum(t => Convert.ToDecimal(t.Cells["total"].Value)).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbProducts.SelectedIndex == 0)
            {
                classHelper.ShowMessageBox("Product is not selected, please select Material.", "Warning");
                cmbProducts.Focus();
            }
            else if (txtQty.Text.Equals("") || txtQty.Text.Equals("0"))
            {
                classHelper.ShowMessageBox("Please add Product Qty.", "Warning");
                txtQty.Focus();
            }
            else if (txtRate.Text.Equals("") || txtRate.Text.Equals("0"))
            {
                classHelper.ShowMessageBox("Please add Product Rate.", "Warning");
                txtRate.Focus();
            }
            else
            {
                gridProducts.Rows.Add(cmbProducts.SelectedValue.ToString(), cmbProducts.Text, classHelper.AvoidInjection(txtQty.Text),
                classHelper.AvoidInjection(txtRate.Text), Convert.ToDecimal(classHelper.AvoidInjection(txtQty.Text)) *
                Convert.ToDecimal(classHelper.AvoidInjection(txtRate.Text)));
                TotalSum();
                cmbProducts.SelectedIndex = 0;
                txtQty.Text = "0";
                txtRate.Text = "0";
               // cmbProducts.Focus();
            }
        }



        private void btnViewInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                if (id != 0)
                { PrintInvoice(); }
                else
                {
                    MessageBox.Show("Invoice not found in record or save the invoice first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void txtCreditDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            classHelper.CheckNumber(e);
        }
        private void Delete()
        {

            classHelper.query = @" BEGIN TRY 
                             BEGIN TRANSACTION ";

            classHelper.query += @" DELETE FROM LEDGERS WHERE REF_ID = '" + id + @"' AND ENTRY_OF = 'PURCHASE_ORDER ';
            DELETE FROM MATERIAL_ITEM_LEDGER WHERE REF_NO = '" + id + @"' AND ENTRY_FROM = 'PURCHASE_ORDER ';
            DELETE FROM PRODUCT_ITEM_LEDGER WHERE REF_NO = '" + id + @"' AND ENTRY_FROM = 'PURCHASE_ORDER ';
            DELETE FROM PURCHASES_DETAILS WHERE PURCHASE_MASTER_ID = '" + id + @"';            
            DELETE FROM PURCHASE_ORDER WHERE PURCHASE_MASTER_ID = '" + id + @"'";

            classHelper.query += @" COMMIT TRANSACTION 
                        END TRY 
                    BEGIN CATCH 
                            IF @@TRANCOUNT > 0 
                            ROLLBACK TRANSACTION 
                    END CATCH";

            if (classHelper.InsertUpdateDelete(classHelper.query) >= 1)
            {
                classHelper.ShowMessageBox("Record Deleted Sucessfully.", "Information");
                Clear();
                LoadGrid();
            }
        }

        /*


            classHelper.query = @" BEGIN TRY 
                             BEGIN TRANSACTION ";

            classHelper.query += @" 
            DELETE FROM PURCHASE_DETAIL WHERE PRODUCTION_MASTER_ID = '" + id + @"';
            DELETE FROM PURCHASE_DETAIL WHERE ID = '" + id + @"';
          //  DELETE FROM PRODUCT_ITEM_LEDGER WHERE REF_NO = '" + id + @"' AND ENTRY_FROM = 'PRODUCTION PRODUCT';";

            classHelper.query += @" COMMIT TRANSACTION 
                        END TRY 
                    BEGIN CATCH 
                            IF @@TRANCOUNT > 0 
                            ROLLBACK TRANSACTION 
                    END CATCH";

            if (classHelper.InsertUpdateDelete(classHelper.query) >= 1)
            {
                classHelper.ShowMessageBox("Record Deleted Sucessfully.", "Information");
                Clear();
                LoadGrid();
            }
        }



                    classHelper.query = @" BEGIN TRY 
                                     BEGIN TRANSACTION ";

                    classHelper.query += @" DELETE FROM LEDGERS WHERE REF_ID = '" + id + @"' AND ENTRY_OF = 'PURCHASES';
                    DELETE FROM MATERIAL_ITEM_LEDGER WHERE REF_NO = '" + id + @"' AND ENTRY_FROM = 'PURCHASES';
                    DELETE FROM PURCHASE_DETAIL WHERE PURCHASE_MASTER_ID = '" + id + @"';            
                    DELETE FROM PURCHASE_MASTER WHERE PURCHASE_MASTER_ID = '" + id + @"'";

                    classHelper.query += @" COMMIT TRANSACTION 
                                END TRY 
                            BEGIN CATCH 
                                    IF @@TRANCOUNT > 0 
                                    ROLLBACK TRANSACTION 
                            END CATCH";

                    if (classHelper.InsertUpdateDelete(classHelper.query) >= 1)
                    {
                        classHelper.ShowMessageBox("Record Deleted Sucessfully.", "Information");
                        Clear();
                        LoadGrid();
                    }
                } */
        private void btn_VIEW_VOUCHER_Click(object sender, EventArgs e)
        {
            if (id > 0)
            {
                Delete();
            }
            else
            {
                MessageBox.Show("Please Select any invoice to delete.", "Error");
            }
        }

        private void txtVehicleNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void RemoveProductRaw(int productId)
        {
            foreach (DataGridViewRow item in this.gridProducts.Rows)
            {
                if (item.Cells["productId"].Value.ToString().Equals(productId.ToString()))
                {
                    gridProducts.Rows.RemoveAt(item.Index);
                }
            }
        }


        private void gridProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.gridProducts.Rows[e.RowIndex];
                cmbProducts.SelectedValue = row.Cells["productId"].Value.ToString();
                txtQty.Text = row.Cells["qty"].Value.ToString();
                txtRate.Text = row.Cells["rate"].Value.ToString();
                gridProducts.Rows.RemoveAt(e.RowIndex);
                TotalSum();
            }
        }

        /*   if (e.RowIndex >= 0)
           {
               DataGridViewRow row = this.gridProducts.Rows[e.RowIndex];

               // Ensure productId cell is not null or empty
               if (row.Cells["productId"].Value != null && !string.IsNullOrEmpty(row.Cells["productId"].Value.ToString()))
               {
                   // Safely parse productId to int
                   int productId;
                   if (int.TryParse(row.Cells["productId"].Value.ToString(), out productId))
                   {
                       cmbProducts.SelectedValue = productId.ToString(); // or productId if combobox accepts int
                       txtQty.Text = row.Cells["qty"].Value.ToString();

                       // Remove the product based on the parsed productId
                       RemoveProductRaw(productId);

                       // Remove the row from grid
                       gridProducts.Rows.RemoveAt(e.RowIndex);
                   }
                   else
                   {
                       // Handle the case where productId is not a valid number
                       MessageBox.Show("Invalid productId value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   }
               }
               else
               {
                   MessageBox.Show("Product ID is missing or invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
           }
       }
       *
       */
        private void gridProducts_ColumnNameChanged(object sender, DataGridViewColumnEventArgs e)
        {

        }

        private void grdSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pnlHEADER_Paint(object sender, PaintEventArgs e)
        {

        }

        private void grdSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadGridData(e);
        }

        private void lblInvoice_Click(object sender, EventArgs e)
        {

        }

        private void cmbSupplier_Leave(object sender, EventArgs e)
        {
            if (!classHelper.CheckAccountExists(cmbSupplier.Text)) {
                string supplierName = cmbSupplier.Text;
                DialogResult dialogResult = MessageBox.Show("Do you want to add "+cmbSupplier.Text+" Account?", "Add New Account", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    using (frmChartOfAccounts frm = new frmChartOfAccounts(20, 12, classHelper.AvoidInjection(cmbSupplier.Text), 1))
                    {
                        if (frm.ShowDialog() == System.Windows.Forms.DialogResult.Cancel || frm.ShowDialog() == System.Windows.Forms.DialogResult.Abort)
                        {
                            LoadSuppliers();
                            cmbSupplier.Text = supplierName;
                        }
                    }
                }
                else {
                    cmbSupplier.SelectedIndex = 0;
                    cmbSupplier.Focus();
                }
            }
        }

        private void cmbProducts_Leave(object sender, EventArgs e)
        {
            if (!classHelper.CheckProductExists(cmbProducts.Text))
            {
                string productName = cmbProducts.Text;
                DialogResult dialogResult = MessageBox.Show("Do you want to add " + cmbProducts.Text + " Product?", "Add New Productc", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    using (frmFinishedProducts frm = new frmFinishedProducts(classHelper.AvoidInjection(cmbProducts.Text)))
                    {
                        if (frm.ShowDialog() == System.Windows.Forms.DialogResult.Cancel || frm.ShowDialog() == System.Windows.Forms.DialogResult.Abort)
                        {
                            LoadProducts();
                            cmbProducts.Text = productName;
                        }
                    }
                }
                else
                {
                    cmbProducts.SelectedIndex = 0;
                    cmbProducts.Focus();
                }
            }
        }
    }
}



