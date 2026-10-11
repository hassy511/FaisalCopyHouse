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
    public partial class frm_Purchases : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        int id = 0;

        public frm_Purchases()
        {
            InitializeComponent();
        }

        private void GeneratePINumber()
        {
            classHelper.query = "SELECT ISNULL(COUNT(PI_ID),0)+1 FROM PURCHASES";
            lblInvoice.Text = "PI-" + classHelper.GetMaxValue(classHelper.query) + "-" + DateTime.Now.Year;
        }

        private void LoadGrid()
        {
            classHelper.query = @" SELECT A.PI_ID AS [ID],A.INVOICE_NO AS [INVOICE #],
            A.[DATE],A.SUPPLIER_ID,B.COA_NAME AS [VENDOR],A.[DESCRIPTION],
            A.NET_WEIGHT AS [TOTAL]
            FROM PURCHASES A
            INNER JOIN COA B ON A.SUPPLIER_ID = B.COA_ID
            ORDER BY PI_ID DESC";
            classHelper.LoadGrid(grdSearch, classHelper.query);
            grdSearch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadVendors()
        {
            classHelper.LoadSuppliers(cmbVendor);
        }

        private void Clear()
        {
            GeneratePINumber();
            dtpDate.Value = DateTime.Now;
            cmbVendor.SelectedIndex = 0;
            txtTotal.Text = "0";
            txtDescription.Clear();            
            txtSearch.Clear();
            id = 0;
            LoadGrid();
        }

        private void Save()
        {
            {
                if (cmbVendor.SelectedIndex == 0)
                {
                    classHelper.ShowMessageBox("Vendor is not selected, please select Vendor.", "Warning");
                    cmbVendor.Focus();
                }
                else if (txtDescription.Text.Trim().Equals(""))
                {
                    classHelper.ShowMessageBox("Enter Description.", "Warning");
                    txtDescription.Focus();
                }
                else if (txtTotal.Text.Trim().Equals("") || txtTotal.Text.Trim().Equals("0"))
                {
                    classHelper.ShowMessageBox("Enter Total Amount.", "Warning");
                    txtTotal.Focus();
                }
                else
                {
                    string masterId = id.ToString();
                    if (id.ToString().Equals("0"))
                    {
                        masterId = "(SELECT MAX(PI_ID) FROM PURCHASES)";
                    }

                    
                    classHelper.query = @"BEGIN TRY 
                    BEGIN TRANSACTION ";

                    classHelper.query += @"IF EXISTS (select PI_ID from PURCHASES WHERE PI_ID ='" + id + @"') 
                 BEGIN
                    UPDATE PURCHASES SET DATE = '" + dtpDate.Value.ToString() + @"',  
                    DESCRIPTION = '" + classHelper.AvoidInjection(txtDescription.Text) + @"',
                    SUPPLIER_ID = '" + cmbVendor.SelectedValue.ToString() + @"',
                    NET_WEIGHT = '" + classHelper.AvoidInjection(txtTotal.Text) + @"',  
                    MODIFICATION_DATE = GETDATE(),MODIFIED_BY = '" + Classes.Helper.userId + @"'
                    WHERE PI_ID = '" + id + @"';
                 END
                 ELSE
                 BEGIN
                     INSERT INTO PURCHASES (DATE,SUPPLIER_ID,DESCRIPTION,NET_WEIGHT,CREATION_DATE,CREATED_BY,INVOICE_NO) 
                     VALUES ('" + dtpDate.Value.ToString() + "','" + cmbVendor.SelectedValue.ToString() + @"',
                     '" + classHelper.AvoidInjection(txtDescription.Text) + @"',
                     '" + classHelper.AvoidInjection(txtTotal.Text) + "',GETDATE(),'" + Classes.Helper.userId + @"',
                     '" + lblInvoice.Text + @"');
                 END";

                classHelper.query += @" DELETE FROM LEDGERS WHERE REF_ID = " + id + @" AND ENTRY_OF = 'PURCHASES'";

                        classHelper.query += @" 
                            INSERT INTO LEDGERS(DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
                            VALUES('" + dtpDate.Value.ToString() + "','" + Classes.Helper.purchasesId +
                                        "'," + masterId + ",'PURCHASES','" + lblInvoice.Text + @"','" + txtTotal.Text + "', 0,'" + txtDescription.Text + "','" + Classes.Helper.userId + @"',GETDATE(),1);

                            INSERT INTO LEDGERS(DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
                            VALUES('" + dtpDate.Value.ToString() + "','" + cmbVendor.SelectedValue.ToString() +
                                        "'," + masterId + ",'PURCHASES','" + lblInvoice.Text + @"',0, '" + txtTotal.Text + "','" + txtDescription.Text + "','" + Classes.Helper.userId + @"',GETDATE(),1);"; 

                    classHelper.query += @" COMMIT TRANSACTION 
                     END TRY 
                     BEGIN CATCH 
                             IF @@TRANCOUNT > 0 
                             ROLLBACK TRANSACTION 
                     END CATCH";

                    if (classHelper.InsertUpdateDelete(classHelper.query) >= 1)
                    {
                        classHelper.ShowMessageBox("Record Saved Successfully.", "Information");
                        Clear();
                    }
                }
            }
        }

        private void LoadGridData(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.grdSearch.Rows[e.RowIndex];
                id = Convert.ToInt32(row.Cells["ID"].Value.ToString());
                lblInvoice.Text = row.Cells["INVOICE #"].Value.ToString();
                dtpDate.Text = row.Cells["DATE"].Value.ToString();
                txtDescription.Text = row.Cells["DESCRIPTION"].Value.ToString();
                cmbVendor.SelectedValue = row.Cells["SUPPLIER_ID"].Value.ToString();
                txtTotal.Text = row.Cells["TOTAL"].Value.ToString();
            }
        }

        private void frm_AddGroupAccounts_Load(object sender, EventArgs e)
        {
            GeneratePINumber();
            LoadGrid();
            LoadVendors();
        }

        private void txtSEARCH_TextChanged(object sender, EventArgs e)
        {
            try
            {
                (grdSearch.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
              [" + grdSearch.Columns["INVOICE #"].Name.ToString() + "] LIKE '%" + classHelper.AvoidInjection(txtSearch.Text) + "%' OR ["
              + grdSearch.Columns["VENDOR"].Name.ToString() + "] LIKE '%" + classHelper.AvoidInjection(txtSearch.Text) + "%' OR["
               + grdSearch.Columns["DESCRIPTION"].Name.ToString() + "] LIKE '%" + classHelper.AvoidInjection(txtSearch.Text) + "%'");
                grdSearch.ClearSelection();
            }

            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void grdSEARCH_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            grdSearch.Columns["ID"].Visible = false;
            grdSearch.Columns["SUPPLIER_ID"].Visible = false;
        }

        private void btnCLEAR_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void grdSEARCH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadGridData(e);
        }
        private void cmbSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        
        
        private void Delete()
        {

            classHelper.query = @" BEGIN TRY 
                             BEGIN TRANSACTION ";

            classHelper.query += @" DELETE FROM LEDGERS WHERE REF_ID = '" + id + @"' AND ENTRY_OF = 'PURCHASES ';
            DELETE FROM MATERIAL_ITEM_LEDGER WHERE REF_NO = '" + id + @"' AND ENTRY_FROM = 'PURCHASES ';
            DELETE FROM PRODUCT_ITEM_LEDGER WHERE REF_NO = '" + id + @"' AND ENTRY_FROM = 'PURCHASES ';
            DELETE FROM PURCHASES WHERE PI_ID = '" + id + @"';  ";

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
            }
        }

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

        
        private void cmbCustomer_Leave(object sender, EventArgs e)
        {
            
        }

        private void txtTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            classHelper.CheckNumber(e);
        }
    }
}



