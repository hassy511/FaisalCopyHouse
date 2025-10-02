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
    public partial class frm_Sales : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        int id = 0;
        bool isEdit = false;
        public frm_Sales()
        {
            InitializeComponent();
        }

        private void GenerateSINumber()
        {
            classHelper.query = "SELECT ISNULL(COUNT(SALE_MASTER_ID),0)+1 FROM SALE_MASTER";
            lblInvoice.Text = "P-SI-" + classHelper.GetMaxValue(classHelper.query) + "-" + DateTime.Now.Year;
        }

        private void LoadGrid()
        {
            classHelper.query = @" SELECT A.SALE_MASTER_ID AS [ID],A.INVOICE_NO AS [INVOICE #],
            A.[DATE],B.COA_NAME AS [CUSTOMER],A.REFERENCE,A.[DESCRIPTION],
            A.CREDIT_DAYS,A.CUSTOMER_ID,TERM,SO_ID,A.BILL_NO,A.IS_POSTED
            FROM SALE_MASTER A
            INNER JOIN COA B ON A.CUSTOMER_ID = B.COA_ID
            WHERE A.SALE_MASTER_ID NOT IN (SELECT SALE_MASTER_ID FROM SALE_EXPENSE)
            ORDER BY SALE_MASTER_ID DESC";
            classHelper.LoadGrid(grdSearch, classHelper.query);
        }

        private void LoadCustomer()
        {
            classHelper.LoadCustomers(cmbCustomer);
        }
        private void LoadProducts()
        {
            classHelper.LoadProducts(cmbProducts);
        }

        private void LoadReferenceAccount()
        {
            classHelper.LoadSalesReferenceAccount(cmbReference);
        }

        private void Clear()
        {
            GenerateSINumber();
            chkPosted.Checked = true;
            dtpDate.Value = DateTime.Now;
            cmbCustomer.SelectedIndex = 0;
            txtBillNo.Clear();
            txtCreditDays.Text = "0";
            txtCostRate.Text = "0";
            txtDescription.Clear();
            cmbProducts.SelectedIndex = 0;
            txtQty.Text = "0";
            txtRate.Text = "0";
            txtGST.Text = "0";
            txtNetTotal.Text = "0";
            txtTotal.Text = "0";
            cmbReference.Text = "";
            txtSearch.Clear();
            id = 0;
            isEdit = false;
            gridProducts.Rows.Clear();
            chkSO.Checked = false;
            if (cmbSO.Items.Count > 0)
            {
                cmbSO.SelectedIndex = 0;
            }
            rdbCredit.Checked = true;
            LoadGrid();
        }

        private void Save()
        {
            {
                if (cmbCustomer.SelectedIndex == 0)
                {
                    classHelper.ShowMessageBox("Customer is not selected, please select Customer.", "Warning");
                    cmbCustomer.Focus();
                }
                else if (txtCreditDays.Text.Trim().Equals(""))
                {
                    classHelper.ShowMessageBox("Enter Credit Days.", "Warning");
                    txtCreditDays.Focus();
                }
                else if (txtBillNo.Text.Trim().Equals(""))
                {
                    classHelper.ShowMessageBox("Enter Bill No.", "Warning");
                    txtBillNo.Focus();
                }
                else if (gridProducts.Rows.Count <= 0)
                {
                    classHelper.ShowMessageBox("Add Products.", "Warning");
                    cmbProducts.Focus();
                }
                else
                {
                    string masterId = id.ToString();
                    if (id.ToString().Equals("0"))
                    {
                        masterId = "(SELECT MAX(SALE_MASTER_ID) FROM SALE_MASTER)";
                    }

                    // Determinetype based on selected radio button
                    char term = '0';
                    char isPaid = '1';
                    if (rdbCredit.Checked == true)
                    {
                        term = '1';
                        isPaid = '0';
                    }

                    char isPosted = 'Y';
                    if (chkPosted.Checked == false) {
                        isPosted = 'N';
                    }

                    int soId = 0;
                    if (chkSO.Checked == true && cmbSO.SelectedValue.ToString().Equals("0"))
                    {
                        soId = Convert.ToInt32(cmbSO.SelectedValue.ToString());
                    }

                    classHelper.query = @"BEGIN TRY 
                    BEGIN TRANSACTION ";

                    classHelper.query += @"IF EXISTS (select SALE_MASTER_ID from SALE_MASTER WHERE SALE_MASTER_ID ='" + id + @"') 
                 BEGIN
                     UPDATE SALE_MASTER SET DATE = '" + dtpDate.Value.ToString() + @"',  
                     CUSTOMER_ID = '" + cmbCustomer.SelectedValue.ToString() + @"',
                     DESCRIPTION = '" + classHelper.AvoidInjection(txtDescription.Text) + @"',
                     CREDIT_DAYS = '" + classHelper.AvoidInjection(txtCreditDays.Text) + @"',
                     BILL_NO = '" + classHelper.AvoidInjection(txtBillNo.Text) + @"',
                     REFERENCE = '" + classHelper.AvoidInjection(cmbReference.Text) + @"',
                     TERM = '" + term + @"',SO_ID = '" + cmbSO.SelectedValue + @"',
                     IS_POSTED = '" + isPosted + @"',
                     IS_PAID = '" + isPaid + @"',
                     MODIFICATION_DATE = GETDATE(),MODIFIED_BY = '" + Classes.Helper.userId + @"'
                     WHERE SALE_MASTER_ID = '" + id + @"';
                 END
                 ELSE
                 BEGIN
                     INSERT INTO SALE_MASTER (DATE,CUSTOMER_ID,DESCRIPTION,CREDIT_DAYS,TERM,CREATION_DATE,CREATED_BY,INVOICE_NO,SO_ID,BILL_NO,IS_POSTED,REFERENCE,IS_PAID) 
                     VALUES ('" + dtpDate.Value.ToString() + "','" + cmbCustomer.SelectedValue.ToString() + @"',
                     '" + classHelper.AvoidInjection(txtDescription.Text) + @"',
                     '" + classHelper.AvoidInjection(txtCreditDays.Text) + "', '" + term + @"', GETDATE(),'" + Classes.Helper.userId + @"',
                     '" + lblInvoice.Text + @"','" + soId + @"','" + classHelper.AvoidInjection(txtBillNo.Text) + @"','" + isPosted + @"','" + classHelper.AvoidInjection(cmbReference.Text) + @"','" + isPaid + @"');
                 END";

                classHelper.query += @" DELETE FROM SALE_DETAIL WHERE SALE_MASTER_ID = '" + id + @"'";

                    foreach (DataGridViewRow rows in gridProducts.Rows)
                    {
                        classHelper.query += @" INSERT INTO SALE_DETAIL (SALE_MASTER_ID,ITEM_ID,QTY,RATE,GST,COST_RATE) 
                            VALUES (" + masterId + ",'" + rows.Cells["productId"].Value.ToString() + "','"
                        + rows.Cells["qty"].Value.ToString() + @"','" + rows.Cells["rate"].Value.ToString() + @"','"
                      + rows.Cells["gstValue"].Value.ToString() + @"','" + rows.Cells["costRate"].Value.ToString() + @"');";
                    }

                classHelper.query += @" DELETE FROM LEDGERS WHERE REF_ID = " + id + @" AND ENTRY_OF = 'SALES'";

                    if (chkPosted.Checked == true) {
                        classHelper.query += @" 
                            INSERT INTO LEDGERS(DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
                            VALUES('" + dtpDate.Value.ToString() + "','" + Classes.Helper.salesId +
                                        "'," + masterId + ",'SALES','" + lblInvoice.Text + @"', 0,'" + txtNetTotal.Text + "','S.I # "+cmbReference.Text+" / " + txtBillNo.Text + " /" + txtCreditDays.Text + " DAYS PAYMENT)','" + Classes.Helper.userId + @"',GETDATE(),1);

                            INSERT INTO LEDGERS(DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
                            VALUES('" + dtpDate.Value.ToString() + "','" + cmbCustomer.SelectedValue.ToString() + "'," + masterId + ",'SALES','" + lblInvoice.Text + @"',
                            '" + txtNetTotal.Text + "',0,'S.I # " + cmbReference.Text + " / " + txtBillNo.Text + " /" + txtCreditDays.Text + " DAYS PAYMENT)','" + Classes.Helper.userId + @"',GETDATE(),1);

                            INSERT INTO LEDGERS(DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
                            VALUES('" + dtpDate.Value.ToString() + "','" + Classes.Helper.gstTaxId +
                            "'," + masterId + ",'SALES','" + lblInvoice.Text + @"', '" + (Convert.ToDecimal(txtNetTotal.Text) - Convert.ToDecimal(txtTotal.Text)).ToString() + "',0,'S.I # " + cmbReference.Text + " / " + txtBillNo.Text + " /" + txtCreditDays.Text + " DAYS PAYMENT)','" + Classes.Helper.userId + @"',GETDATE(),1);

                            INSERT INTO LEDGERS(DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
                            VALUES('" + dtpDate.Value.ToString() + "','" + cmbCustomer.SelectedValue.ToString() +
                            "'," + masterId + ",'SALES','" + lblInvoice.Text + @"', 0,'" + (Convert.ToDecimal(txtNetTotal.Text) - Convert.ToDecimal(txtTotal.Text)).ToString() + "','GST on S.I # " + cmbReference.Text + " / " + txtBillNo.Text + " /" + txtCreditDays.Text + " DAYS PAYMENT)','" + Classes.Helper.userId + @"',GETDATE(),1);";

                        if (rdbCash.Checked == true)
                        {
                            classHelper.query += @" INSERT INTO LEDGERS(DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
                            VALUES('" + dtpDate.Value.ToString() + "','" + cmbCustomer.SelectedValue.ToString() +
                                "'," + masterId + ",'SALES','" + lblInvoice.Text + @"', 0,'" + txtTotal.Text + "','S.I # " + cmbReference.Text + " / " + txtBillNo.Text + " /" + txtCreditDays.Text + " DAYS PAYMENT)','" + Classes.Helper.userId + @"',GETDATE(),1);

                            INSERT INTO LEDGERS(DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
                            VALUES('" + dtpDate.Value.ToString() + "','" + Classes.Helper.cashId + "'," + masterId + ",'SALES','" + lblInvoice.Text + @"',
                            '" + txtTotal.Text + "',0,'S.I # " + cmbReference.Text + " / " + txtBillNo.Text + " /" + txtCreditDays.Text + " DAYS PAYMENT)','" + Classes.Helper.userId + @"',GETDATE(),1);";
                        }
                    }

                    classHelper.query += @" COMMIT TRANSACTION 
                     END TRY 
                     BEGIN CATCH 
                             IF @@TRANCOUNT > 0 
                             ROLLBACK TRANSACTION 
                     END CATCH";

                    if (classHelper.InsertUpdateDelete(classHelper.query) >= 1)
                    {
                        classHelper.ShowMessageBox("Record Saved Successfully.", "Information");

                        DialogResult dialogResult = MessageBox.Show("Print Invoice?", "Purchases Invoice", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            PrintSalesInvoice();
                            if (chkPosted.Checked == true)
                            {
                                PrintDeliveryChallan();
                            }
                        }
                        Clear();
                    }
                }
            }
        }

        private void PrintSalesInvoice()
        {
            classHelper.nds.Tables["GeneralOrderSupply"].Clear();
            foreach (DataGridViewRow rows in gridProducts.Rows)
            {
                classHelper.dataR = classHelper.nds.Tables["GeneralOrderSupply"].NewRow();
                classHelper.dataR["qty"] = Convert.ToDouble(rows.Cells["qty"].Value.ToString());
                classHelper.dataR["invoice"] = lblInvoice.Text;
                classHelper.dataR["deliveryChallan"] = txtBillNo.Text;
                classHelper.dataR["rate"] = Convert.ToDouble(rows.Cells["rate"].Value.ToString());
                classHelper.dataR["fromDate"] = dtpDate.Value.ToShortDateString();
                classHelper.dataR["particulars"] = rows.Cells["productName"].Value.ToString();
                classHelper.dataR["gstPercentage"] = Convert.ToDouble(rows.Cells["gstValue"].Value.ToString());
                classHelper.dataR["gstAmount"] = (((Convert.ToDecimal(rows.Cells["qty"].Value.ToString()) * Convert.ToDecimal(rows.Cells["rate"].Value.ToString()))) * (Convert.ToDecimal(rows.Cells["gstValue"].Value.ToString()) / 100));
                classHelper.dataR["amount"] = Convert.ToDouble(rows.Cells["netTotal"].Value.ToString());
                classHelper.dataR["customer"] = cmbCustomer.Text;
                classHelper.nds.Tables["GeneralOrderSupply"].Rows.Add(classHelper.dataR);
            }
            classHelper.rpt = new ERP_Maaz_Oil.Forms.Reporting.frmReports();
            classHelper.rpt.GenerateReport("SalesInvoice", classHelper.nds);
            classHelper.rpt.ShowDialog();
        }

        private void PrintDeliveryChallan()
        {
            classHelper.nds.Tables["GeneralOrderSupply"].Clear();
            foreach (DataGridViewRow rows in gridProducts.Rows)
            {
                classHelper.dataR = classHelper.nds.Tables["GeneralOrderSupply"].NewRow();
                classHelper.dataR["qty"] = Convert.ToDouble(rows.Cells["qty"].Value.ToString());
                classHelper.dataR["invoice"] = lblInvoice.Text;
                classHelper.dataR["deliveryChallan"] = txtBillNo.Text;
                classHelper.dataR["fromDate"] = dtpDate.Value.ToShortDateString();
                classHelper.dataR["particulars"] = rows.Cells["productName"].Value.ToString();
                classHelper.dataR["customer"] = cmbCustomer.Text;
                classHelper.nds.Tables["GeneralOrderSupply"].Rows.Add(classHelper.dataR);
            }
            classHelper.rpt = new ERP_Maaz_Oil.Forms.Reporting.frmReports();
            classHelper.rpt.GenerateReport("DeliveryChallan", classHelper.nds);
            classHelper.rpt.ShowDialog();
        }

        //private void PrintInvoice()
        //{
        //    classHelper.mds.Tables["PI"].Clear();
        //    foreach (DataGridViewRow rows in gridProducts.Rows)
        //    {
        //        classHelper.dataR = classHelper.mds.Tables["PI"].NewRow();
        //        classHelper.dataR["PI_num"] = lblInvoice.Text;
        //        classHelper.dataR["date"] = dtpDate.Value.ToShortDateString();
        //        classHelper.dataR["supplier"] = cmbCustomer.Text;
        //        classHelper.dataR["description"] = txtDescription.Text;
        //        classHelper.dataR["material"] = rows.Cells["productId"].Value.ToString();
        //        classHelper.dataR["qty"] = Convert.ToDouble(rows.Cells["qty"].Value.ToString());
        //        classHelper.dataR["rate"] = Convert.ToDouble(rows.Cells["rate"].Value.ToString());
        //        classHelper.dataR["total"] = Convert.ToDouble(rows.Cells["total"].Value.ToString());
        //        classHelper.dataR["creditDays"] = txtCreditDays.Text;
        //        classHelper.dataR["dueDate"] = DateTime.Now.AddDays(Convert.ToInt32(txtCreditDays.Text));
        //        classHelper.mds.Tables["PI"].Rows.Add(classHelper.dataR);
        //    }
        //    classHelper.rpt = new ERP_Maaz_Oil.Forms.Reporting.frmReports();
        //    classHelper.rpt.GenerateReport("PI", classHelper.mds);
        //    classHelper.rpt.ShowDialog();
        //}

        private void LoadSalesDetail(int siId)
        {
            classHelper.LoadSalesDetail(gridProducts, siId);
        }

        private void LoadGridData(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.grdSearch.Rows[e.RowIndex];
                id = Convert.ToInt32(row.Cells["ID"].Value.ToString());
                lblInvoice.Text = row.Cells["INVOICE #"].Value.ToString();
                isEdit = true;
                dtpDate.Text = row.Cells["DATE"].Value.ToString();
                cmbCustomer.SelectedValue = row.Cells["CUSTOMER_ID"].Value.ToString();
                txtDescription.Text = row.Cells["DESCRIPTION"].Value.ToString();
                cmbReference.Text = row.Cells["REFERENCE"].Value.ToString();
                txtCreditDays.Text = row.Cells["CREDIT_DAYS"].Value.ToString();
                txtBillNo.Text = row.Cells["BILL_NO"].Value.ToString();
                
                if (row.Cells["IS_POSTED"].Value.ToString().Equals("Y"))
                {
                    chkPosted.Checked = true;
                }
                else
                {
                    chkPosted.Checked = false;
                }

                if (row.Cells["SO_ID"].Value.ToString().Equals("0"))
                {
                    chkSO.Checked = false;
                }
                else
                {
                    chkSO.Checked = true;
                    cmbSO.SelectedValue = row.Cells["SO_ID"].Value.ToString();
                }

                if (row.Cells["TERM"].Value.ToString().Equals("0"))
                {
                    rdbCash.Checked = true;
                }
                else
                {
                    rdbCredit.Checked = true;
                }

                LoadSalesDetail(id);
                TotalSum();
            }
        }

        private void frm_AddGroupAccounts_Load(object sender, EventArgs e)
        {
            GenerateSINumber();
            LoadGrid();
            LoadCustomer();
            LoadProducts();
            LoadReferenceAccount();
        }

        private void txtSEARCH_TextChanged(object sender, EventArgs e)
        {
            try
            {
                (grdSearch.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
              [" + grdSearch.Columns["INVOICE #"].Name.ToString() + "] LIKE '%" + classHelper.AvoidInjection(txtSearch.Text) + "%' OR ["
              + grdSearch.Columns["CUSTOMER"].Name.ToString() + "] LIKE '%" + classHelper.AvoidInjection(txtSearch.Text) + "%' OR["
              + grdSearch.Columns["REFERENCE"].Name.ToString() + "] LIKE '%" + classHelper.AvoidInjection(txtSearch.Text) + "%' OR["
              + grdSearch.Columns["BILL_NO"].Name.ToString() + "] LIKE '%" + classHelper.AvoidInjection(txtSearch.Text) + "%' OR["
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
            grdSearch.Columns["CUSTOMER_ID"].Visible = false;
            grdSearch.Columns["TERM"].Visible = false;
            grdSearch.Columns["SO_ID"].Visible = false;
            grdSearch.Columns["IS_POSTED"].Visible = false;
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
        private void TotalSum()
        {
            try
            {
                txtNetTotal.Text = gridProducts.Rows.Cast<DataGridViewRow>()
                    .Sum(t => Convert.ToDecimal(t.Cells["netTotal"].Value)).ToString();

                txtTotal.Text = gridProducts.Rows.Cast<DataGridViewRow>()
                    .Sum(t => Convert.ToDecimal(t.Cells["total"].Value)).ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }


        private decimal CalculateTotalWithGST(decimal quantity, decimal rate, decimal gst)
        {
            decimal total = quantity * rate;
            decimal totalWithGST = total * (1 + gst / 100);
            return totalWithGST;

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

            else if (txtGST.Text.Equals("")) // Check if GST is provided
            {
                classHelper.ShowMessageBox("Please add GST value.", "Warning");
                txtGST.Focus();
            }
            else
            {
                gridProducts.Rows.Add(cmbProducts.SelectedValue.ToString(), cmbProducts.Text, classHelper.AvoidInjection(txtQty.Text),
                Math.Round(Convert.ToDecimal(classHelper.AvoidInjection(txtRate.Text)),2) - (Math.Round(Convert.ToDecimal(classHelper.AvoidInjection(txtRate.Text)),2) *
                Math.Round((Convert.ToDecimal(classHelper.AvoidInjection(txtGST.Text)) / 100),2)),

                Math.Round(Convert.ToDecimal(classHelper.AvoidInjection(txtQty.Text)),2) * (Math.Round(Convert.ToDecimal(classHelper.AvoidInjection(txtRate.Text)),2) - (Math.Round(Convert.ToDecimal(classHelper.AvoidInjection(txtRate.Text)),2) *
                (Math.Round(Convert.ToDecimal(classHelper.AvoidInjection(txtGST.Text)) / 100,2)))),

                classHelper.AvoidInjection(txtGST.Text),

                (Math.Round(Convert.ToDecimal(classHelper.AvoidInjection(txtQty.Text)),2) * Math.Round(Convert.ToDecimal(classHelper.AvoidInjection(txtRate.Text)),2)),

                Math.Round(Convert.ToDecimal(classHelper.AvoidInjection(txtCostRate.Text)),2));

                TotalSum();
                cmbProducts.SelectedIndex = 0;
                txtQty.Text = "0";
                txtRate.Text = "0";
                txtCostRate.Text = "0";
             //   cmbProducts.Focus();
            }
        }



        private void btnViewInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                if (id != 0)
                { PrintSalesInvoice(); }
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

            classHelper.query += @" DELETE FROM LEDGERS WHERE REF_ID = '" + id + @"' AND ENTRY_OF = 'SALES ';
            DELETE FROM MATERIAL_ITEM_LEDGER WHERE REF_NO = '" + id + @"' AND ENTRY_FROM = 'SALES ';
            DELETE FROM PRODUCT_ITEM_LEDGER WHERE REF_NO = '" + id + @"' AND ENTRY_FROM = 'SALES ';
            DELETE FROM SALE_DETAIL WHERE SALE_MASTER_ID = '" + id + @"';            
            DELETE FROM SALE_MASTER WHERE SALE_MASTER_ID = '" + id + @"'";

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

        private void txtVehicleNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbMaterials_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (id == 0) {
                if (cmbProducts.SelectedIndex > 0)
                {
                    txtCostRate.Text = classHelper.GetProductRate(Convert.ToInt32(cmbProducts.SelectedValue.ToString())).ToString();
                    if (classHelper.LoadStockBalance(Convert.ToInt32(cmbProducts.SelectedValue.ToString())) < 0) {
                        MessageBox.Show("Stock Quantity is not available.", "Error");
                    }
                }
                else
                {
                    txtCostRate.Text = "0";
                }
            }
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
                txtRate.Text = (Convert.ToDecimal(row.Cells["netTotal"].Value.ToString()) / Convert.ToDecimal(row.Cells["qty"].Value.ToString())).ToString();
                txtGST.Text = row.Cells["gstValue"].Value.ToString();
                txtCostRate.Text = row.Cells["costRate"].Value.ToString();
                gridProducts.Rows.RemoveAt(e.RowIndex);
                TotalSum();
            }
        }
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

        private void rdbCredit_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCash.Checked == true)
            {
                txtCreditDays.Enabled = false;
            }
            else
            {
                txtCreditDays.Enabled = true;
            }
        }

        private void LoadSODetails(int soId)
        {
            classHelper.query = @"	SELECT B.PRODUCT_ID,C.PRODUCT_NAME as [PRODUCT NAME],B.QTY,B.RATE,B.QTY - ISNULL(D.QTY,0) AS [BALANCE QTY],dbo.GetCostRate(B.PRODUCT_ID) AS [COST RATE]
            FROM SALES_ORDER_PRODUCT_MASTER A
            INNER JOIN SALES_ORDER_PRODUCT_DETAILS B ON A.SOPM_ID = B.SOPM_ID
            INNER JOIN PRODUCT_MASTER C ON B.PRODUCT_ID = C.PM_ID
            LEFT JOIN (
	            SELECT B.ITEM_ID,SUM(B.QTY) AS [QTY]
	            FROM SALE_MASTER A
	            INNER JOIN SALE_DETAIL B ON A.SALE_MASTER_ID = B.SALE_MASTER_ID 
	            WHERE A.SO_ID = '" + soId + @"'
	            GROUP BY B.ITEM_ID
            ) D ON B.PRODUCT_ID = D.ITEM_ID
            WHERE A.SOPM_ID = '" + soId + @"'
            ORDER BY [PRODUCT NAME]";
            classHelper.LoadSalesOrderDetail(classHelper.query, gridProducts);
            TotalSum();
        }

        private void cmbPO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSO.SelectedIndex > 0)
            {
                LoadSODetails(Convert.ToInt32(cmbSO.SelectedValue.ToString()));
            }
        }

        private void chkPO_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSO.Checked == true)
            {
                classHelper.LoadProductSalesOrder(cmbSO, Convert.ToInt32(cmbCustomer.SelectedValue.ToString()), isEdit);
                cmbSO.Enabled = true;

            }
            else
            {
                cmbSO.SelectedIndex = 0;
                cmbSO.Enabled = false;
            }
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (id != 0)
                { PrintDeliveryChallan(); }
                else
                {
                    MessageBox.Show("Invoice not found in record or save the invoice first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void cmbCustomer_Leave(object sender, EventArgs e)
        {
            if (!classHelper.CheckAccountExists(cmbCustomer.Text))
            {
                string customerName = cmbCustomer.Text;
                DialogResult dialogResult = MessageBox.Show("Do you want to add " + cmbCustomer.Text + " Account?", "Add New Account", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    using (frmChartOfAccounts frm = new frmChartOfAccounts(21, 26, classHelper.AvoidInjection(cmbCustomer.Text), 0))
                    {
                        if (frm.ShowDialog() == System.Windows.Forms.DialogResult.Cancel || frm.ShowDialog() == System.Windows.Forms.DialogResult.Abort)
                        {
                            LoadCustomer();
                            cmbCustomer.Text = customerName;
                        }
                    }
                }
                else
                {
                    cmbCustomer.SelectedIndex = 0;
                    cmbCustomer.Focus();
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



