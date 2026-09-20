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
    public partial class frmSales_New : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        int id = 0;
        bool isEdit = false;
        public string query = "";
        public frmSales_New()
        {
            InitializeComponent();
        }

        private void GenerateSINumber()
        {
            //classHelper.query = "SELECT ISNULL(COUNT(SALE_MASTER_ID),0)+1 FROM SALE_MASTER";
            classHelper.query = @"SELECT 'SI-'+CONVERT(varchar(100),(ISNULL(COUNT(SALE_MASTER_ID),0)+1))+'-'+CONVERT(varchar(100),YEAR(GETDATE()))+'/'+CONVERT(varchar(100),(ISNULL(MAX(SALE_MASTER_ID),0)+1))
                                    FROM SALE_MASTER";
            //lblInvoice.Text = "SI-" + classHelper.GetMaxValue(classHelper.query) + "-" + DateTime.Now.Year;
            lblInvoice.Text = classHelper.GetSaleInvoiceValue(classHelper.query);
        }
        private void LoadGrid()
        {
            classHelper.query = @"SELECT A.SALE_MASTER_ID AS [ID],A.INVOICE_NO AS [INVOICE #],
            A.[DATE],B.COA_NAME AS [CUSTOMER],A.[DESCRIPTION],
            A.CREDIT_DAYS,A.CUSTOMER_ID
            FROM SALE_MASTER A
            INNER JOIN COA B ON A.CUSTOMER_ID = B.COA_ID
            ORDER BY SALE_MASTER_ID DESC";
            classHelper.LoadGrid(grdSearch, classHelper.query);
        }


        private void LoadProducts()
        {
            classHelper.LoadProducts(cmbProducts);
        }

        private void LoadCustomers()
        {
            classHelper.LoadCustomers(cmbCustomer);
        }


        //private void LoadProducts()
        //{
        //classHelper.LoadRawMaterials(cmbItem);
        //  }
        //    private void LoadProducts()
        //      {
        //classHelper.LoadProducts(cmbItem);
        //        }

        private void Clear()
        {
            GenerateSINumber();
            dtpDate.Value = DateTime.Now;
            cmbCustomer.SelectedIndex = 0;
            // txtVehicleNumber.Clear();
            txtCreditDays.Text = "0";
            txtDescription.Clear();
            cmbProducts.SelectedIndex = 0;
            txtQty.Text = "0";
            txtRate.Text = "0";
            txtTotal.Text = "0";
            //txtTransportation.Text = "0";
            txtSearch.Clear();
            rdbCredit.Checked = true;
            //rdbnet.Checked = false;
            //rdbRetail.Checked = false;
            id = 0;
            isEdit = false;
            grdItems.Rows.Clear();
            //lblBalanceStock.Text = "AVAILABLE STOCK: 00";
        }



        private void Save()
        {
            if (cmbCustomer.SelectedIndex == 0)
            {
                classHelper.ShowMessageBox("Customer is not selected, please select Customer.", "Warning");
                cmbCustomer.Focus();
            }
            else if (grdItems.Rows.Count <= 0)
            {
                classHelper.ShowMessageBox("Add Products.", "Warning");
                cmbProducts.Focus();
            }
            else
            {
                char Type = '1';
                if (rdbCash.Checked == true)
                {
                    Type = '0';
                }

                string masterId = id.ToString();
                if (id.ToString().Equals("0"))
                {
                    masterId = "(SELECT MAX(SALE_MASTER_ID) FROM SALE_MASTER)";
                }

                // Start building the SQL query string with the TRY-CATCH block
                classHelper.query = @"BEGIN TRY
                                BEGIN TRANSACTION ";

                // Check if the SALE_MASTER_ID exists in SALE_DETAIL
                classHelper.query += @"IF EXISTS (SELECT SALE_MASTER_ID FROM SALE_MASTER WHERE SALE_MASTER_ID ='" + id + @"')
                               BEGIN
                                    UPDATE SALE_MASTER
                                    SET DATE = '" + dtpDate.Value.ToString() + @"',
                                        DESCRIPTION = '" + classHelper.AvoidInjection(txtDescription.Text) + @"',
                                        MODIFICATION_DATE = GETDATE(),
                                        MODIFIED_BY = '" + Classes.Helper.userId + @"'
                                    WHERE SALE_MASTER_ID = '" + id + @"';
                               END
                               ELSE
                               
BEGIN
                                    INSERT INTO SALE_MASTER (DATE, CUSTOMER_ID, DESCRIPTION, CREDIT_DAYS, CREATION_DATE, CREATED_BY, INVOICE_NO) 
                                    VALUES 
    ('" + dtpDate.Value.ToString() + "', '" + cmbCustomer.SelectedValue.ToString() + @"',
    '" + classHelper.AvoidInjection(txtDescription.Text) + @"', '" + txtCreditDays.Text + @"',
    GETDATE(), '" + Classes.Helper.userId + "', '" + lblInvoice.Text + @"');
               



END";

                // Delete and insert into LEDGERS
                classHelper.query += @" DELETE FROM LEDGERS WHERE REF_ID = " + id + @" AND ENTRY_OF = 'SALE_MASTER';
                                INSERT INTO LEDGERS (DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
                                VALUES ('" + dtpDate.Value.ToString() + "', '" + cmbCustomer.SelectedValue.ToString() + "', " + masterId + @",
                                        'SALE_MASTER', '" + lblInvoice.Text + @"', 0, '" + (Convert.ToDecimal(txtTotal.Text)) + @"', 
                                        'S.R # " + lblInvoice.Text + "', '" + Classes.Helper.userId + @"', GETDATE(), 1);";

                classHelper.query += @" INSERT INTO LEDGERS (DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
                                VALUES ('" + dtpDate.Value.ToString() + "', '" + Classes.Helper.salesReturnId + "', " + masterId + @",
                                        'SALE_MASTER', '" + lblInvoice.Text + @"', '" + (Convert.ToDecimal(txtTotal.Text)) + @"', 0,
                                        'S.I # " + lblInvoice.Text + "', '" + Classes.Helper.userId + @"', GETDATE(), 1);";

                // Delete SALE_MASTER and MATERIAL_ITEM_LEDGER/Product_ITEM_LEDGER
                classHelper.query += @" DELETE FROM SALE_DETAIL WHERE SALE_MASTER_ID = '" + id + @"';
                                DELETE FROM MATERIAL_ITEM_LEDGER WHERE REF_NO = '" + id + @"' AND ENTRY_FROM = 'SALE_MASTER';
                                DELETE FROM PRODUCT_ITEM_LEDGER WHERE REF_NO = '" + id + @"' AND ENTRY_FROM = 'SALE_MASTER';";

                // Insert into SALE_MASTER and ledgers based on grdItems rows
                foreach (DataGridViewRow rows in grdItems.Rows)
                {
                    classHelper.query += @" INSERT INTO SALE_DETAIL (SALE_MASTER_ID, ITEM_TYPE, ITEM_ID, QTY, RATE)
                                    VALUES (" + masterId + @", '" + rows.Cells["itemType"].Value.ToString() + @"',
                                            '" + rows.Cells["itemId"].Value.ToString() + @"', '" + rows.Cells["itemQty"].Value.ToString() + @"',
                                            '" + rows.Cells["rate"].Value.ToString() + @"');";
                }

                // Insert into MATERIAL_ITEM_LEDGER or PRODUCT_ITEM_LEDGER
                foreach (DataGridViewRow rows in grdItems.Rows)
                {
                    if (rows.Cells["itemType"].Value.ToString().Equals("R"))
                    {
                        classHelper.query += @" INSERT INTO MATERIAL_ITEM_LEDGER (DATE, MATERIAL_ID, REF_NO, ENTRY_FROM, STOCK_IN, STOCK_OUT, COST_AMT, SALE_AMT, L_ID, CREATED_BY, CREATION_DATE, COMPANY_ID)
                                        VALUES ('" + dtpDate.Value.ToString() + "', '" + rows.Cells["itemId"].Value.ToString() + @"', " + masterId + @",
                                                'SALE_MASTER', '" + rows.Cells["itemQty"].Value.ToString() + @"', '0', '0', '" + rows.Cells["rate"].Value.ToString() + @"',
                                                '1', '" + Classes.Helper.userId + @"', GETDATE(), '1');";
                    }
                    else
                    {
                        classHelper.query += @" INSERT INTO PRODUCT_ITEM_LEDGER (DATE, PRODUCT_ID, REF_NO, ENTRY_FROM, STOCK_IN, STOCK_OUT, COST_AMT, SALE_AMT, L_ID, CREATED_BY, CREATION_DATE, COMPANY_ID)
                                        VALUES ('" + dtpDate.Value.ToString() + "', '" + rows.Cells["itemId"].Value.ToString() + @"', " + masterId + @",
                                                'SALE_MASTER', '" + rows.Cells["itemQty"].Value.ToString() + @"', '0', '0', '" + rows.Cells["rate"].Value.ToString() + @"',
                                                '1', '" + Classes.Helper.userId + @"', GETDATE(), '1');";
                    }
                }

                // Commit the transaction
                classHelper.query += @" COMMIT TRANSACTION;
                                END TRY
                                BEGIN CATCH
                                    IF @@TRANCOUNT > 0
                                        ROLLBACK TRANSACTION;
                                    THROW;
                                END CATCH;";

                // Execute the query
                if (classHelper.InsertUpdateDelete(classHelper.query) >= 1)
                {
                    classHelper.ShowMessageBox("Record Saved Successfully.", "Information");
                    Clear();
                    LoadGrid();
                }
            }
        }


        /*private void Save()
        {

            {
                if (cmbCustomer.SelectedIndex == 0)
                {
                    classHelper.ShowMessageBox("Customer is not selected, please select Customer.", "Warning");
                    cmbCustomer.Focus();
                }
                else if (grdItems.Rows.Count <= 0)
                {
                    classHelper.ShowMessageBox("Add Products.", "Warning");
                    cmbProducts.Focus();
                }
                else
                {
                    char Type = '1';
                    if (rdbCash.Checked == true)
                    {
                        Type = '0';
                    }

                    string masterId = id.ToString();
                    if (id.ToString().Equals("0"))
                    {
                        masterId = "(SELECT MAX(SALE_MASTER_ID) FROM SALE_MASTER)";
                    }

                    classHelper.query = @"BEGIN TRY 
                             BEGIN TRANSACTION ";

                    classHelper.query += @"IF EXISTS (SELECT SALE_MASTER_ID FROM SALE_DETAIL WHERE SALE_MASTER_ID ='" + id + @"') 
                    BEGIN
                        UPDATE SALE_DETAIL  SET DATE = '" + dtpDate.Value.ToString() +  @"',
                        DESCRIPTION = '" + classHelper.AvoidInjection(txtDescription.Text) + @"',
                        MODIFICATION_DATE = GETDATE(),MODIFIED_BY = '" + Classes.Helper.userId + @"' WHERE SALE_MASTER_ID = '" + id + @"';
                    END
                    ELSE
                    BEGIN
                        INSERT INTO SALE_DETAIL (DATE,DESCRIPTION,CREATION_DATE,CREATED_BY,INVOICE_NO) 
                        VALUES ('" + dtpDate.Value.ToString() + "','" + cmbCustomer.SelectedValue.ToString() + @"',
                        '" + classHelper.AvoidInjection(txtDescription.Text) + @"',
                        GETDATE(),'" + Classes.Helper.userId + "','" + lblInvoice.Text + @"')
                    END
                    
                    DELETE FROM LEDGERS WHERE REF_ID = " + id + @" AND ENTRY_OF = 'SALES DETAIL'
                    
                    INSERT INTO LEDGERS(DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
                    VALUES('" + dtpDate.Value.ToString() + "','" + cmbCustomer.SelectedValue.ToString() + "'," + masterId + ",'SALE_MASTER','" + lblInvoice.Text + @"',
                    0,'" + (Convert.ToDecimal(txtTotal.Text)) + "','S.R # " + lblInvoice.Text + ")','" + Classes.Helper.userId + @"',GETDATE(),1);
                    
                    INSERT INTO LEDGERS(DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
                    VALUES('" + dtpDate.Value.ToString() + "','" + Classes.Helper.salesReturnId + "'," + masterId + ",'SALES RETURN','" + lblInvoice.Text + @"',
                    '" + (Convert.ToDecimal(txtTotal.Text)) + "',0,'S.I # " + lblInvoice.Text + ")','" + Classes.Helper.userId + @"',GETDATE(),1);";

                    classHelper.query += @"DELETE FROM SALE_DETAIL WHERE SALE_MASTER_ID = '" + id + @"'";

                    foreach (DataGridViewRow rows in grdItems.Rows)
                    {
                        classHelper.query += @"INSERT INTO SALE_DETAIL (SALE_MASTER_ID,ITEM_TYPE,ITEM_ID,QTY,RATE) VALUES 
                    (" + masterId + ",'" + rows.Cells["itemType"].Value.ToString() + "','" + rows.Cells["itemId"].Value.ToString() + @"',
                        '" + rows.Cells["itemQty"].Value.ToString() + @"','" + rows.Cells["rate"].Value.ToString() + @"');";
                    }

                    classHelper.query += @" DELETE FROM MATERIAL_ITEM_LEDGER WHERE REF_NO = '" + id + @"' AND ENTRY_FROM = 'SALE_DETAIL';";

                    classHelper.query += @" DELETE FROM PRODUCT_ITEM_LEDGER WHERE REF_NO = '" + id + @"' AND ENTRY_FROM = 'SALES_DETAIL';";

                    foreach (DataGridViewRow rows in grdItems.Rows)
                    {
                        if (rows.Cells["itemType"].Value.ToString().Equals("R"))
                        {
                            classHelper.query += @" INSERT INTO MATERIAL_ITEM_LEDGER 
                        ([DATE],MATERIAL_ID,REF_NO,ENTRY_FROM,STOCK_IN,STOCK_OUT,COST_AMT,SALE_AMT,L_ID,CREATED_BY,CREATION_DATE,COMPANY_ID)
                        VALUES('" + dtpDate.Value.ToString() + "','" + rows.Cells["itemId"].Value.ToString() + "'," + masterId + @",
                            'SALES DETAIL','" + rows.Cells["itemQty"].Value.ToString() + @"','0',
                            '0','" + rows.Cells["rate"].Value.ToString() + @"','1','" + Classes.Helper.userId + "',GETDATE(),'1');";
                        }
                        else
                        {
                            classHelper.query += @" INSERT INTO PRODUCT_ITEM_LEDGER 
                        ([DATE],PRODUCT_ID,REF_NO,ENTRY_FROM,STOCK_IN,STOCK_OUT,COST_AMT,SALE_AMT,L_ID,CREATED_BY,CREATION_DATE,COMPANY_ID)
                        VALUES('" + dtpDate.Value.ToString() + "','" + rows.Cells["itemId"].Value.ToString() + "'," + masterId + @",
                            'SALES DETAIL','" + rows.Cells["itemQty"].Value.ToString() + @"','0',
                            '0','" + rows.Cells["rate"].Value.ToString() + @"','1','" + Classes.Helper.userId + "',GETDATE(),'1');";
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
                        classHelper.ShowMessageBox("Record Saved Sucessfully.", "Information");
                        Clear();
                        LoadGrid();
                    }
                }
            }
        }
       
        */

        /*   // Delete from LEDGERS where REF_ID matches and ENTRY_OF is 'SALES'
             classHelper.query += @"
      DELETE FROM LEDGERS WHERE REF_ID = " + id + @" AND ENTRY_OF = 'SALES';";

             // Insert into LEDGERS for the first entry
             classHelper.query += @"
      INSERT INTO LEDGERS (DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
      VALUES (
      '" + dtpDate.Value.ToString("yyyy-MM-dd") + @"',
      '" + Classes.Helper.salesId + @"',
      " + masterId + @",
      'SALES',
      '" + lblInvoice.Text + @"',
      0,
      " + Convert.ToDecimal(txtTotal.Text) + @",
      'S.I # " + lblInvoice.Text + " / " + txtCreditDays.Text + " DAYS PAYMENT',
      '" + Classes.Helper.userId + @"',
      GETDATE(), 1); ";

      // Insert the second entry into LEDGERS
             classHelper.query += @"
      INSERT INTO LEDGERS (DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
      VALUES (
      '" + dtpDate.Value.ToString("yyyy-MM-dd") + @"',
      '" + Classes.Helper.salesId + @"',
      " + masterId + @",
      'SALES',
      '" + lblInvoice.Text + @"',
      0,
      " + Convert.ToDecimal(txtTotal.Text) + @",
      'S.I # " + lblInvoice.Text + " / " + txtCreditDays.Text + " DAYS PAYMENT',
      '" + Classes.Helper.userId + @"',
      GETDATE(), 1); ";

      // Delete from SALE_DETAIL
             classHelper.query += @"DELETE FROM SALE_DETAIL WHERE SALE_MASTER_ID = '" + id + @"';";

             foreach (DataGridViewRow rows in grdItems.Rows)
             {
                 classHelper.query += @"INSERT INTO SALE_DETAIL (SALE_MASTER_ID, ITEM_TYPE, ITEM_ID, QTY, RATE) VALUES 
         (
             " + masterId + @",
             '" + rows.Cells["itemType"].Value.ToString() + @"',
             '" + rows.Cells["itemId"].Value.ToString() + @"',
             '" + rows.Cells["itemQty"].Value.ToString() + @"',
             '" + rows.Cells["rate"].Value.ToString() + @"'
         ); ";
             }

             classHelper.query += @"DELETE FROM SALE_DETAIL WHERE SALE_MASTER_ID = '" + id + @"';";

             foreach (DataGridViewRow rows in grdItems.Rows)
             {
                 classHelper.query += @"INSERT INTO SALE_DETAIL (SALE_MASTER_ID, ITEM_TYPE, ITEM_ID, QTY, RATE) 
         VALUES (
             " + masterId + @",
             '" + rows.Cells["itemType"].Value.ToString() + @"',
             '" + rows.Cells["itemId"].Value.ToString() + @"',
             " + rows.Cells["itemQty"].Value.ToString() + @",
             " + rows.Cells["rate"].Value.ToString() + @"
         ); ";
             }

             classHelper.query += @"DELETE FROM MATERIAL_ITEM_LEDGER WHERE REF_NO = '" + id + @"' AND ENTRY_FROM = 'SALES';";
             classHelper.query += @"DELETE FROM PRODUCT_ITEM_LEDGER WHERE REF_NO = '" + id + @"' AND ENTRY_FROM = 'SALES';";

             foreach (DataGridViewRow rows in grdItems.Rows)
             {
                 if (rows.Cells["itemType"].Value.ToString().Equals("R"))
                 {
                     classHelper.query += @"INSERT INTO MATERIAL_ITEM_LEDGER 
             ([DATE], MATERIAL_ID, REF_NO, ENTRY_FROM, STOCK_IN, STOCK_OUT, COST_AMT, SALE_AMT, L_ID, CREATED_BY, CREATION_DATE, COMPANY_ID)
             VALUES (
                 '" + dtpDate.Value.ToString("yyyy-MM-dd") + @"',
                 '" + rows.Cells["itemId"].Value.ToString() + @"',
                 " + masterId + @",
                 'SALES',
                 '0',
                 '" + rows.Cells["itemQty"].Value.ToString() + @"',
                 '0',
                 '" + rows.Cells["rate"].Value.ToString() + @"',
                 '1',
                 '" + Classes.Helper.userId + @"',
                 GETDATE(),
                 '1'
             ); ";
                 }
                 else
                 {
                     classHelper.query += @"INSERT INTO PRODUCT_ITEM_LEDGER 
             ([DATE], PRODUCT_ID, REF_NO, ENTRY_FROM, STOCK_IN, STOCK_OUT, COST_AMT, SALE_AMT, L_ID, CREATED_BY, CREATION_DATE, COMPANY_ID)
             VALUES (
                 '" + dtpDate.Value.ToString("yyyy-MM-dd") + @"',
                 '" + rows.Cells["itemId"].Value.ToString() + @"',
                 " + masterId + @",
                 'SALES',
                 '0',
                 '" + rows.Cells["itemQty"].Value.ToString() + @"',
                 '0',
                 '" + rows.Cells["rate"].Value.ToString() + @"',
                 '1',
                 '" + Classes.Helper.userId + @"',
                 GETDATE(),
                 '1'
             ); ";
                 }
             }

             classHelper.query += @"COMMIT TRANSACTION; 
                         END TRY 
                         BEGIN CATCH 
                             IF @@TRANCOUNT > 0 
                                 ROLLBACK TRANSACTION; 
                         END CATCH;";

             if (classHelper.InsertUpdateDelete(classHelper.query) >= 1)
             {
                 classHelper.ShowMessageBox("Record Saved Successfully.", "Information");
                 DialogResult dialogResult = MessageBox.Show("Print Invoice?", "Purchases Invoice", MessageBoxButtons.YesNo);
                 if (dialogResult == DialogResult.Yes)
                 {
                     PrintInvoice();
                 }
                 Clear();
                 LoadGrid();
             }
         }
      } */


        private void PrintInvoice()
        {
            classHelper.nds.Tables["GeneralOrderSupply"].Clear();
            foreach (DataGridViewRow rows in grdItems.Rows)
            { 
              classHelper.dataR = classHelper.nds.Tables["GeneralOrderSupply"].NewRow();
              classHelper.dataR["qty"]=Convert.ToDouble(rows.Cells["itemQty"].Value.ToString());
              classHelper.dataR["invoice#"] = lblInvoice.Text;
              classHelper.dataR["rate"] = Convert.ToDouble(rows.Cells["rate"].Value.ToString());
              classHelper.dataR["fromDate"] = dtpDate.Value.ToShortDateString();
               classHelper.dataR["amount "] = Convert.ToDouble(rows.Cells["total"].Value.ToString());
                //   classHelper.dataR["particulars "] = Convert.ToInt32(rows.Cells["itemid"].Value.ToString());
                classHelper.nds.Tables["GeneralOrderSupply"].Rows.Add(classHelper.dataR);
            }
            classHelper.rpt = new ERP_Maaz_Oil.Forms.Reporting.frmReports();
            classHelper.rpt.GenerateReport("GeneralOrderSupply", classHelper.nds);
            classHelper.rpt.ShowDialog();

        } /*
             *classHelper.mds.Tables["SaleInvoice"].Clear();

                grdItems.Sort(this.grdItems.Columns["modelNo"],
                                        ListSortDirection.Ascending);

                //grdItems.Sort(this.grdItems.Columns["modelNo"],
                //                        ListSortDirection.Ascending);

                foreach (DataGridViewRow rows in grdItems.Rows)
                {
                    classHelper.dataR = classHelper.mds.Tables["SaleInvoice"].NewRow();
                    classHelper.dataR["InvoiceNo"] = lblInvoice.Text;
                    classHelper.dataR["date"] = dtpDate.Value.ToShortDateString();
                    classHelper.dataR["customer"] = cmbCustomer.Text;
                    classHelper.dataR["description"] = txtDescription.Text;
                    classHelper.dataR["itemName"] = classHelper.GetProductName(Convert.ToInt32(rows.Cells["itemid"].Value.ToString()), Convert.ToChar(rows.Cells["itemType"].Value.ToString()));
                    classHelper.dataR["qty"] = Convert.ToDouble(rows.Cells["itemQty"].Value.ToString());
                    classHelper.dataR["rate"] = Convert.ToDouble(rows.Cells["rate"].Value.ToString());
                    classHelper.dataR["amount"] = Convert.ToDouble(rows.Cells["total"].Value.ToString());
                    classHelper.dataR["creditDays"] = txtCreditDays.Text;
                    //classHelper.dataR["vehicleNo"] = txtVehicleNumber.Text;
                    classHelper.dataR["balance"] = classHelper.GetAccountBalance(Convert.ToInt32(cmbCustomer.SelectedValue.ToString()));
                    classHelper.dataR["code"] = rows.Cells["modelNo"].Value.ToString();
                    classHelper.dataR["dueDate"] = dtpDate.Value.Date.AddDays(Convert.ToInt32(txtCreditDays.Text));
                    //classHelper.dataR["transportation"] = Convert.ToDouble(txtTransportation.Text);
                    classHelper.mds.Tables["SaleInvoice"].Rows.Add(classHelper.dataR);
                }
                //classHelper.mds.Tables["SaleInvoice"].DefaultView.Sort = "itemName asc";
                //classHelper.mds.Tables["SaleInvoice"].DefaultView.Sort = "code asc";


                classHelper.rpt = new ERP_Maaz_Oil.Forms.Reporting.frmReports();
                classHelper.rpt.GenerateReport("SaleInvoiceOrignal", classHelper.mds);
                classHelper.rpt.ShowDialog();

                classHelper.rpt = new ERP_Maaz_Oil.Forms.Reporting.frmReports();
                classHelper.rpt.GenerateReport("SaleInvoiceDuplicate", classHelper.mds);
                classHelper.rpt.ShowDialog();

                classHelper.rpt = new ERP_Maaz_Oil.Forms.Reporting.frmReports();
                classHelper.rpt.GenerateReport("SaleInvoiceGatePass", classHelper.mds);
                classHelper.rpt.ShowDialog();
            }
            */

            private void LoadSalesDetails(int saleId)
        {
            classHelper.LoadSalesDetail(grdItems, saleId);
        }
        private void LoadGridData(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.grdSearch.Rows[e.RowIndex];
                id = Convert.ToInt32(row.Cells["ID"].Value.ToString());

                isEdit = true;
                lblInvoice.Text = row.Cells["INVOICE #"].Value.ToString();
                dtpDate.Text = row.Cells["DATE"].Value.ToString();
                cmbCustomer.SelectedValue = row.Cells["CUSTOMER_ID"].Value.ToString();
                //txtVehicleNumber.Text = row.Cells["VEHICLE_NO"].Value.ToString();
                txtDescription.Text = row.Cells["DESCRIPTION"].Value.ToString();
                txtCreditDays.Text = row.Cells["CREDIT_DAYS"].Value.ToString();
                // txtTransportation.Text = row.Cells["TRANSPORTATION"].Value.ToString();
                LoadSalesDetails(id);
                TotalSum();
            }
        }
        private void frm_AddGroupAccounts_Load(object sender, EventArgs e)
        {
            GenerateSINumber();
            LoadGrid();
            LoadCustomers();
            LoadProducts();
           
        }

        private void txtSEARCH_TextChanged(object sender, EventArgs e)
        {
            classHelper.Sale_search(txtSearch, grdSearch);
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void grdSEARCH_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            grdSearch.Columns["CUSTOMER_ID"].Visible = false;
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
            //     if (cmbCustomer.SelectedIndex > 0) {
            //       string rateType = classHelper.GetAccountRateType(cmbCustomer.SelectedValue.ToString());
            //     if (rateType.Equals("R"))
            //   {
            //     rdbRetail.Checked = true;
            //}
            ///else if (rateType.Equals("N"))
            // {
            //   rdbnet.Checked = true;
            // }
            //else
            //{
            //  rdbRetail.Checked = false;
            //rdbnet.Checked = false;
            //}
            //}
        }

        private void txtNetWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            classHelper.CheckNumber(e);
        }

        private void btn_VIEW_VOUCHER_Click(object sender, EventArgs e)
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

        /*    private void rdbRaw_CheckedChanged(object sender, EventArgs e)
            {
                if (rdbProduct.Checked == true)
                {
                    LoadProducts();
                }
                else if (rdbRaw.Checked == true)
                {
                    LoadMaterials();
                }
            }

            private void rdbProduct_CheckedChanged(object sender, EventArgs e)
            {
                if (rdbProduct.Checked == true)
                {
                    LoadProducts();
                }
                else if (rdbRaw.Checked == true)
                {
                    LoadMaterials();
                }
            }

        */
        private void grdItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = this.grdItems.Rows[e.RowIndex];
                cmbProducts.SelectedValue = row.Cells["itemId"].Value.ToString();
                txtQty.Text = row.Cells["itemQty"].Value.ToString();
                txtRate.Text = row.Cells["rate"].Value.ToString();
                if (row.Cells["itemType"].Value.ToString().Equals("1"))
                {
                    rdbCredit.Checked = true;
                }
                else {
                    rdbCash.Checked = true;
                }
                grdItems.Rows.RemoveAt(e.RowIndex);
                TotalSum();
                //  lblBalanceStock.Text = "AVAILABLE STOCK: 00";
            }
        }
        private void TotalSum()
        {
            try
            {
                txtTotal.Text = grdItems.Rows.Cast<DataGridViewRow>()
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
                classHelper.ShowMessageBox("Products is not selected, please select Item.", "Warning");
                cmbProducts.Focus();
            }
            else if (txtQty.Text.Equals("") || txtQty.Text.Equals("0"))
            {
                classHelper.ShowMessageBox("Please add Qty.", "Warning");
                txtQty.Focus();
            }
            else if (txtRate.Text.Equals("") || txtRate.Text.Equals("0"))
            {
                classHelper.ShowMessageBox("Please add Rate.", "Warning");
                txtRate.Focus();
            }
            else
            {
                /*  if (rdbCredit.Checked == true) {
                      int stockBalance = classHelper.GetStockBalance(cmbProducts.SelectedValue.ToString());
                      if (Convert.ToInt32(txtQty.Text) > stockBalance)
                      {
                          classHelper.ShowMessageBox(cmbProducts.Text + " is out of stock, current stock is " + stockBalance, "Warning");
                      }
                  }
                  else if (rdbCash.Checked == true)
                  {
                      int stockBalance = classHelper.GetMaterialBalance(cmbProducts.SelectedValue.ToString());
                      if (Convert.ToInt32(txtQty.Text) > stockBalance)
                      {
                          classHelper.ShowMessageBox(cmbProducts.Text + " is out of stock, current stock is " + stockBalance, "Warning");
                      }
                  }
                  */

                char itemType = '0';
                if (rdbCash.Checked == true) {
                    itemType = '1';
                }
                string modelNo = "";
                if (rdbCredit.Checked == true)
                {
                    modelNo = classHelper.GetProductCode(Convert.ToInt32(cmbProducts.SelectedValue.ToString()));

                }
                //  //    grdItems.Rows.Add(cmbProducts.SelectedValue.ToString(), itemType, cmbProducts.Text.Substring(cmbProducts.Text.LastIndexOf(':') + 1), cmbProducts.Text, classHelper.AvoidInjection(txtQty.Text),

                grdItems.Rows.Add(cmbProducts.SelectedValue.ToString(),itemType, cmbProducts.Text, classHelper.AvoidInjection(txtQty.Text),
                classHelper.AvoidInjection(txtRate.Text), Convert.ToDecimal(classHelper.AvoidInjection(txtQty.Text)) *
                Convert.ToDecimal(classHelper.AvoidInjection(txtRate.Text)), modelNo);
                TotalSum();
                cmbProducts.SelectedIndex = 0;
                txtQty.Text = "0";
                txtRate.Text = "0";
                // lblBalanceStock.Text = "AVAILABLE STOCK: 00";
            }
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            classHelper.CheckNumber(e);
        }

        private void cmbItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            //rdbnet.Checked = false;
            //rdbRetail.Checked = false;
            txtRate.Text = "0";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //if (cmbItem.SelectedIndex > 0 && rdbProduct.Checked == true)
            //{
            //     txtRate.Text = classHelper.GetProductRate(Convert.ToInt32(cmbItem.SelectedValue.ToString()), "net");
            //   }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //if (cmbItem.SelectedIndex > 0 && rdbProduct.Checked == true)
            //{
            //     txtRate.Text = classHelper.GetProductRate(Convert.ToInt32(cmbItem.SelectedValue.ToString()), "retail");
            // }
        }

        private void txtQty_Leave(object sender, EventArgs e)
        {
            //rdbRetail.Focus();
        }

        private void rdbRetail_Leave(object sender, EventArgs e)
        {
            //  rdbnet.Focus();
        }

        private void rdbnet_Leave(object sender, EventArgs e)
        {
            txtRate.Focus();
        }

        private void Delete()
        {

            classHelper.query = @" BEGIN TRY 
                             BEGIN TRANSACTION ";

            classHelper.query += @" DELETE FROM LEDGERS WHERE REF_ID = '" + id + @"' AND ENTRY_OF = 'SALES';
            DELETE FROM MATERIAL_ITEM_LEDGER WHERE REF_NO = '" + id + @"' AND ENTRY_FROM = 'SALES';
            DELETE FROM PRODUCT_ITEM_LEDGER WHERE REF_NO = '" + id + @"' AND ENTRY_FROM = 'SALES';
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
                LoadGrid();
            }
        }

        private void btn_VIEW_VOUCHER_Click_1(object sender, EventArgs e)
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

        private void cmbItem_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            /* if (rdbProduct.Checked == true)
              {
                  lblBalanceStock.Text = "AVAILABLE STOCK: "+ classHelper.GetStockBalance(cmbItem.SelectedValue.ToString());

                  string value = "";
                  if (rdbnet.Checked == true)
                  {
                      value = "net";
                  }
                  else if (rdbRetail.Checked == true)
                  {
                      value = "retail";
                  }

                  if (cmbItem.SelectedIndex > 0 && rdbProduct.Checked == true)
                  {
                      txtRate.Text = classHelper.GetProductRate(Convert.ToInt32(cmbItem.SelectedValue.ToString()), value);
                  }
              }
              else if (rdbRaw.Checked == true)
              {
                  lblBalanceStock.Text = "AVAILABLE STOCK: " + classHelper.GetMaterialBalance(cmbItem.SelectedValue.ToString());
              }
          */
        }

        private void rdbRaw_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lblBalanceStock_Click(object sender, EventArgs e)
        {

        }

        private void txtVehicleNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void grdSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void grdItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void LoadProductDetails(string productId)
        {

           

        }
      
       
        private void cmbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            
 }

        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
           
                classHelper.CheckNumber(e);
            }

        }
    
} 

