using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ERP_Maaz_Oil.Forms
{
    public partial class frm_SalesInvoiceClear : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        public frm_SalesInvoiceClear()
        {
            InitializeComponent();
        }

        public void LoadBankAccounts()
        {
            try
            {
                classHelper.query = @" SELECT '0' AS [id],'--SELECT BANK--' AS [name]
                UNION ALL
                SELECT COA_ID AS [ID],COA_NAME AS [NAME] 
                FROM COA WHERE STAT = 0  AND CA_ID = 5";
                classHelper.LoadComboData(cmbBank, classHelper.query);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void UpdatePaymentGrid()
        {
            // Create a dictionary to group by CustomerId and CustomerName
            var groupedData = new Dictionary<string, (string customerName, string description, decimal totalAmount, string salesId)>();

            foreach (DataGridViewRow row in gridInvoiceData.Rows)
            {
                if (Convert.ToBoolean(row.Cells["check"].Value)) 
                {
                    string customerId = row.Cells["coaId"].Value.ToString();
                    string customerName = row.Cells["customerName"].Value.ToString();
                    string invoiceNumber = row.Cells["billNo"].Value.ToString();
                    decimal invoiceAmount = Convert.ToDecimal(row.Cells["totalAmount"].Value);
                    string salesId = row.Cells["salesId"].Value.ToString();

                    string key = customerId; // Using CustomerId as a unique key for grouping

                    if (groupedData.ContainsKey(key))
                    {
                        var existingEntry = groupedData[key];
                        groupedData[key] = (
                            customerName: existingEntry.customerName,
                            description: existingEntry.description + ", " + invoiceNumber,
                            totalAmount: existingEntry.totalAmount + invoiceAmount,
                            salesId: existingEntry.salesId + "," + salesId
                        );
                    }
                    else
                    {
                        groupedData[key] = (customerName, invoiceNumber, invoiceAmount, salesId);
                    }
                }
            }

            // Populate the second DataGridView
            gridPaymentData.Rows.Clear();

            foreach (var entry in groupedData)
            {
                gridPaymentData.Rows.Add(entry.Key, entry.Value.customerName, entry.Value.description, entry.Value.totalAmount, entry.Value.salesId);
            }
        }

        private void TotalSum()
        {
            try
            {
                txtTotal.Text = gridPaymentData.Rows.Cast<DataGridViewRow>()
                    .Sum(t => Convert.ToDecimal(t.Cells["amount"].Value)).ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void LoadData()
        {
            classHelper.query = @" SELECT A.CUSTOMER_ID,A.SALE_MASTER_ID,FORMAT(A.DATE,'dd/MM/yyyy') AS [DATE],A.INVOICE_NO,A.BILL_NO,A.REFERENCE,
            D.COA_NAME AS [CUSTOMER NAME],SUM(B.QTY * B.RATE) AS [TOTAL]
            FROM SALE_MASTER A
            INNER JOIN SALE_DETAIL B ON A.SALE_MASTER_ID = B.SALE_MASTER_ID
            INNER JOIN COA D ON A.CUSTOMER_ID = D.COA_ID
            WHERE D.COA_ID <> '1082' AND A.IS_PAID = 0
            GROUP BY A.CUSTOMER_ID,A.SALE_MASTER_ID,A.DATE,A.INVOICE_NO,A.BILL_NO,A.REFERENCE,D.COA_NAME
            ORDER BY D.COA_NAME,A.DATE";

            try
            {
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                gridInvoiceData.Rows.Clear();
                if (classHelper.dr.HasRows == true)
                {
                    while (classHelper.dr.Read())
                    {
                        gridInvoiceData.Rows.Add(false, classHelper.dr["CUSTOMER_ID"].ToString(), classHelper.dr["SALE_MASTER_ID"].ToString(),
                            classHelper.dr["DATE"].ToString(), classHelper.dr["INVOICE_NO"].ToString(),
                            classHelper.dr["BILL_NO"].ToString(), classHelper.dr["REFERENCE"].ToString(), classHelper.dr["CUSTOMER NAME"].ToString(),
                            Math.Round(Convert.ToDecimal(classHelper.dr["TOTAL"].ToString())));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Classes.Helper.conn.Close();
            }
        }

        private void PostData() {
            try
            {
                if (gridPaymentData.Rows.Count > 0)
                {
                    if (rdbCash.Checked == true) {
                        classHelper.query = @"BEGIN TRY 
                        declare @mid int = '0';
                        BEGIN TRANSACTION ";

                        classHelper.query += @"INSERT INTO GENERAL_VOUCHER_M (GV_CODE,DAATE,NARRATION,CREATED_BY,CREATION_DATE)
                        VALUES((SELECT 'JV-'+CONVERT(NVARCHAR(MAX),(SELECT ISNULL(COUNT(GV_ID)+1,1) FROM GENERAL_VOUCHER_M))+'-'+CONVERT(NVARCHAR(MAX),YEAR(GETDATE()))),'" + Classes.Helper.ConvertDatetime(dtpDate.Value) + "', '" + classHelper.AvoidInjection("SALES INVOICE PAYMENT") + "', '" + Classes.Helper.userId + @"', getdate());
                        set @mid =(SELECT SCOPE_IDENTITY());";

                        foreach (DataGridViewRow rows in gridPaymentData.Rows)
                        {
                            classHelper.query += @" UPDATE SALE_MASTER SET IS_PAID = 1 WHERE SALE_MASTER_ID IN (" + rows.Cells["saleId"].Value.ToString() + @")";

                            classHelper.query += "INSERT INTO GENERAL_VOUCHER_D VALUES(@mid,'" + Classes.Helper.cashId + @"',
                           '" + rows.Cells["amount"].Value.ToString() + @"','" + rows.Cells["amount"].Value.ToString() + @"',
                           'INVOICE PAYMENTS " + rows.Cells["billNumber"].Value.ToString() + "','" + rows.Cells["accountId"].Value.ToString() + "')";

                            classHelper.query += @"INSERT INTO LEDGERS (DATE,COA_ID,REF_ID,ENTRY_OF,FOLIO,DEBIT,CREDIT,DESCRIPTIONS,CREATED_BY,CREATION_DATE)
                                VALUES('" + Classes.Helper.ConvertDatetime(dtpDate.Value) + "', '" + Classes.Helper.cashId + @"',
                                @mid, 'GENERAL VOUCHER',(SELECT TOP 1 GV_CODE FROM GENERAL_VOUCHER_M ORDER BY GV_ID DESC),'" + (rows.Cells["amount"].Value.ToString()) + @"','0',
                                'INVOICE PAYMENTS " + rows.Cells["billNumber"].Value.ToString() + "','" + Classes.Helper.userId + @"',
                                GETDATE());";

                            classHelper.query += @"INSERT INTO LEDGERS (DATE,COA_ID,REF_ID,ENTRY_OF,FOLIO,DEBIT,CREDIT,DESCRIPTIONS,CREATED_BY,CREATION_DATE)
                                VALUES('" + Classes.Helper.ConvertDatetime(dtpDate.Value) + "', '" + rows.Cells["accountId"].Value.ToString() + @"',
                                @mid, 'GENERAL VOUCHER',(SELECT TOP 1 GV_CODE FROM GENERAL_VOUCHER_M ORDER BY GV_ID DESC),'0','" + (rows.Cells["amount"].Value.ToString()) + @"',
                                'INVOICE PAYMENTS " + rows.Cells["billNumber"].Value.ToString() + "','" + Classes.Helper.userId + @"',
                                GETDATE());";
                        }

                        classHelper.query += @" COMMIT TRANSACTION 
                            END TRY 
                        BEGIN CATCH 
                                IF @@TRANCOUNT > 0 
                                ROLLBACK 
                            TRANSACTION 
                        END CATCH";
                    }
                    else if (rdbBank.Checked == true)
                    {
                        if (cmbBank.SelectedIndex == 0) {
                            classHelper.ShowMessageBox("Bank is not selected, please select Bank.", "Warning");
                            return;
                        }

                        classHelper.query = @"BEGIN TRY 
                        declare @mid int = '0';
                        BEGIN TRANSACTION ";

                        classHelper.query += @"INSERT INTO GENERAL_VOUCHER_M (GV_CODE,DAATE,NARRATION,CREATED_BY,CREATION_DATE)
                        VALUES((SELECT 'JV-'+CONVERT(NVARCHAR(MAX),(SELECT ISNULL(COUNT(GV_ID)+1,1) FROM GENERAL_VOUCHER_M))+'-'+CONVERT(NVARCHAR(MAX),YEAR(GETDATE()))),'" + Classes.Helper.ConvertDatetime(dtpDate.Value) + "', '" + classHelper.AvoidInjection("SALES INVOICE PAYMENT") + "', '" + Classes.Helper.userId + @"', getdate());
                        set @mid =(SELECT SCOPE_IDENTITY());";

                        foreach (DataGridViewRow rows in gridPaymentData.Rows)
                        {
                            classHelper.query += @" UPDATE SALE_MASTER SET IS_PAID = 1 WHERE SALE_MASTER_ID IN (" + rows.Cells["saleId"].Value.ToString() + @")";

                            classHelper.query += "INSERT INTO GENERAL_VOUCHER_D VALUES(@mid,'" + cmbBank.SelectedValue.ToString() + @"',
                           '" + rows.Cells["amount"].Value.ToString() + @"','" + rows.Cells["amount"].Value.ToString() + @"',
                           'INVOICE PAYMENTS " + rows.Cells["billNumber"].Value.ToString() + "','" + rows.Cells["accountId"].Value.ToString() + "')";

                            classHelper.query += @"INSERT INTO LEDGERS (DATE,COA_ID,REF_ID,ENTRY_OF,FOLIO,DEBIT,CREDIT,DESCRIPTIONS,CREATED_BY,CREATION_DATE)
                                VALUES('" + Classes.Helper.ConvertDatetime(dtpDate.Value) + "', '" + cmbBank.SelectedValue.ToString() + @"',
                                @mid, 'GENERAL VOUCHER',(SELECT TOP 1 GV_CODE FROM GENERAL_VOUCHER_M ORDER BY GV_ID DESC),'" + (rows.Cells["amount"].Value.ToString()) + @"','0',
                                'INVOICE PAYMENTS " + rows.Cells["billNumber"].Value.ToString() + "','" + Classes.Helper.userId + @"',
                                GETDATE());";

                            classHelper.query += @"INSERT INTO LEDGERS (DATE,COA_ID,REF_ID,ENTRY_OF,FOLIO,DEBIT,CREDIT,DESCRIPTIONS,CREATED_BY,CREATION_DATE)
                                VALUES('" + Classes.Helper.ConvertDatetime(dtpDate.Value) + "', '" + rows.Cells["accountId"].Value.ToString() + @"',
                                @mid, 'GENERAL VOUCHER',(SELECT TOP 1 GV_CODE FROM GENERAL_VOUCHER_M ORDER BY GV_ID DESC),'0','" + (rows.Cells["amount"].Value.ToString()) + @"',
                                'INVOICE PAYMENTS " + rows.Cells["billNumber"].Value.ToString() + "','" + Classes.Helper.userId + @"',
                                GETDATE());";
                        }

                        classHelper.query += @" COMMIT TRANSACTION 
                            END TRY 
                        BEGIN CATCH 
                                IF @@TRANCOUNT > 0 
                                ROLLBACK 
                            TRANSACTION 
                        END CATCH";
                    }

                    if (classHelper.InsertUpdateDelete(classHelper.query) >= 1)
                    {
                        classHelper.ShowMessageBox("Record Updated Sucessfully.", "Information");
                        Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Clear() {
            LoadData();
            dtpDate.Value = DateTime.Now;
            txtSearch.Clear();
            txtTotal.Text = "0";
            cmbBank.SelectedIndex = 0;
            rdbBank.Checked = true;
            gridPaymentData.Rows.Clear();
        }
        
        private void grpSALES_Enter(object sender, EventArgs e)
        {
            
        }
        
        private void btnINTER_SAVE_Click(object sender, EventArgs e)
        {
            
        }

        private void frm_Account_Ledger_Load(object sender, EventArgs e)
        {
            LoadBankAccounts();
            LoadData();
        }

        private void frm_Account_Ledger_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            
        }

        private void grdPOList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridInvoiceData.Rows.Count > 0)
            {
                if (gridInvoiceData.Rows[e.RowIndex].Cells["check"].Value.ToString().Equals("True"))
                {
                    gridInvoiceData.Rows[e.RowIndex].Cells["check"].Value = false;
                }
                else
                {
                    gridInvoiceData.Rows[e.RowIndex].Cells["check"].Value = true;
                }
                UpdatePaymentGrid();
                TotalSum();
            }
        }

        private void btnDiscard_Click(object sender, EventArgs e)
        {
            PostData();          

        }

        private void grdPOList_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void grdPOList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            
        }

        private void grdPOList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void grdPOList_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
           
        }

        private void btnCompanyReport_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDiffReport_Click(object sender, EventArgs e)
        {
            
        }

        private void rdbCash_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbBank.Checked == true)
            {
                cmbBank.Enabled = true;
            }
            else {
                cmbBank.Enabled = false;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //(gridInvoiceData.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
            //[" + gridInvoiceData.Columns["invoiceNo"].Name.ToString() + "] LIKE '%" + classHelper.AvoidInjection(txtSearch.Text) + "%' OR ["
            //   + gridInvoiceData.Columns["billNo"].Name.ToString() + "] LIKE '%" + classHelper.AvoidInjection(txtSearch.Text) + "%' OR ["
            //   + gridInvoiceData.Columns["reference"].Name.ToString() + "] LIKE '%" + classHelper.AvoidInjection(txtSearch.Text) + "%' OR ["
            //  + gridInvoiceData.Columns["customerName"].Name.ToString() + "] LIKE '%" + classHelper.AvoidInjection(txtSearch.Text) + "%'");
            //gridInvoiceData.ClearSelection();
        }
    }
}
