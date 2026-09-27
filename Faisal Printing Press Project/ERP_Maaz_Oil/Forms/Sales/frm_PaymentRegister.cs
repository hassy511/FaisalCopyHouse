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
    public partial class frm_PaymentRegister : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        int recordId = 0;
        public frm_PaymentRegister()
        {
            InitializeComponent();
        }

        private void LoadAccounts()
        {
            try
            {
                classHelper.query = @" SELECT '0' AS [id],'--SELECT ACCOUNT--' AS [name]
                UNION ALL
                SELECT COA_ID AS [ID],COA_NAME AS [NAME] 
                FROM COA";
                classHelper.LoadComboData(cmbCashAccount, classHelper.query);
                classHelper.LoadComboData(cmbReceiving, classHelper.query);
                classHelper.LoadComboData(cmbPayment, classHelper.query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void GetCashOpeningBalance()
        {
            classHelper.query = @" SELECT 
            (CASE WHEN A.DR_CR = 'D' THEN A.OPEN_BAL ELSE -A.OPEN_BAL END) + 
            (SELECT ISNULL(SUM(DEBIT),0) - ISNULL(SUM(CREDIT),0) 
            FROM LEDGERS WHERE COA_ID = A.COA_ID AND [DATE] < '" + Classes.Helper.ConvertDatetime(dtpDate.Value.Date) + @"')
            FROM COA A
            WHERE A.COA_ID = " + Classes.Helper.cashId + @"";
            txtCashOpening.Text = classHelper.GetScalarAmount(classHelper.query).ToString();
        }

        private void GetData()
        {
            classHelper.query = @" SELECT A.ID,A.[DATE],A.RECEIVING_ACCOUNT_ID,B.COA_NAME AS [RECEIVING ACCOUNT],
            A.PAYMENT_ACCOUNT_ID,C.COA_NAME AS [PAYMENT ACCOUNT],A.AMOUNT,A.TRANSACTION_TYPE
            FROM PAYMENT_REGISTER A
            INNER JOIN COA B ON A.RECEIVING_ACCOUNT_ID = B.COA_ID
            INNER JOIN COA C ON A.PAYMENT_ACCOUNT_ID = C.COA_ID
            WHERE A.[DATE] = '"+ Classes.Helper.ConvertDatetime(dtpDate.Value.Date) + @"'
            ORDER BY A.ID";

            if (Classes.Helper.conn.State == System.Data.ConnectionState.Closed) { Classes.Helper.conn.Open(); }
            try
            {
                gridData.Rows.Clear();
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.cmd.CommandTimeout = 0;
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows)
                {
                    while (classHelper.dr.Read())
                    {
                        gridData.Rows.Add(classHelper.dr["ID"].ToString(), classHelper.dr["RECEIVING_ACCOUNT_ID"].ToString(), classHelper.dr["RECEIVING ACCOUNT"].ToString(), classHelper.dr["PAYMENT_ACCOUNT_ID"].ToString(), classHelper.dr["PAYMENT ACCOUNT"].ToString(), classHelper.dr["AMOUNT"].ToString(), classHelper.dr["TRANSACTION_TYPE"].ToString());
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Classes.Helper.conn.Close();
            }
        }

        private void SaveCashPayment() {
            if (cmbCashAccount.SelectedIndex == 0)
            {
                classHelper.ShowMessageBox("Account is not selected, please select Account.", "Warning");
                cmbCashAccount.Focus();
            }
            else {
                if (rdbReceive.Checked == true)
                {
                    string masterId = recordId.ToString();
                    if (recordId.ToString().Equals("0"))
                    {
                        masterId = "(SELECT MAX(ID) FROM PAYMENT_REGISTER)";
                    }

                    classHelper.query = @"BEGIN TRY 
                    BEGIN TRANSACTION ";

                    classHelper.query += @" IF EXISTS (SELECT ID FROM PAYMENT_REGISTER WHERE ID ='" + recordId + @"') 
                 BEGIN
                    UPDATE PAYMENT_REGISTER SET 
                        DATE = '" + Classes.Helper.ConvertDatetime(dtpDate.Value.Date) + @"',  
                        RECEIVING_ACCOUNT_ID = '" + Classes.Helper.cashId + @"',
                        PAYMENT_ACCOUNT_ID = '" + cmbCashAccount.SelectedValue.ToString() + @"',
                        AMOUNT = '" + classHelper.AvoidInjection(txtCashAmount.Text) + @"',
                        TRANSACTION_TYPE = 'C',      
                        MODIFICATION_DATE = GETDATE(),
                        MODIFIED_BY = '" + Classes.Helper.userId + @"'
                    WHERE ID = '" + recordId + @"';
                 END
                 ELSE
                 BEGIN
                     INSERT INTO PAYMENT_REGISTER (DATE,RECEIVING_ACCOUNT_ID,PAYMENT_ACCOUNT_ID,AMOUNT,TRANSACTION_TYPE,CREATION_DATE,CREATED_BY) 
                     VALUES (
                    '" + Classes.Helper.ConvertDatetime(dtpDate.Value.Date) + @"',
                    '" + Classes.Helper.cashId + @"',
                    '" + cmbCashAccount.SelectedValue.ToString() + @"',
                    '" + classHelper.AvoidInjection(txtCashAmount.Text) + @"',
                    'C', GETDATE(),'" + Classes.Helper.userId + @"');
                 END";

                    classHelper.query += @" DELETE FROM LEDGERS WHERE REF_ID = " + recordId + @" AND ENTRY_OF = 'PAYMENT REGISTER'";

                    classHelper.query += @" 
                            INSERT INTO LEDGERS(DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
                            VALUES('" + Classes.Helper.ConvertDatetime(dtpDate.Value.Date) + "','" + Classes.Helper.cashId +
                                    "'," + masterId + ",'PAYMENT REGISTER','VOUCHER-'+CONVERT(NVARCHAR,"+masterId+ ")+'-'+CONVERT(NVARCHAR,YEAR(GETDATE())), '" + txtCashAmount.Text + "',0,'PAYMENT VOUCHER','" + Classes.Helper.userId + @"',GETDATE(),1);

                            INSERT INTO LEDGERS(DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
                            VALUES('" + Classes.Helper.ConvertDatetime(dtpDate.Value.Date) + "','" + cmbCashAccount.SelectedValue.ToString() +
                                    "'," + masterId + ",'PAYMENT REGISTER','VOUCHER-'+CONVERT(NVARCHAR," + masterId + ")+'-'+CONVERT(NVARCHAR,YEAR(GETDATE())), 0,'" + txtCashAmount.Text + "','PAYMENT VOUCHER','" + Classes.Helper.userId + @"',GETDATE(),1);";

                    classHelper.query += @" COMMIT TRANSACTION 
                     END TRY 
                     BEGIN CATCH 
                             IF @@TRANCOUNT > 0 
                             ROLLBACK TRANSACTION 
                     END CATCH";

                    if (classHelper.InsertUpdateDelete(classHelper.query) >= 1)
                    {
                        classHelper.ShowMessageBox("Record Saved Successfully.", "Information");
                        cmbCashAccount.SelectedIndex = 0;
                        txtCashAmount.Text = "0";
                        GetData();
                        TotalSum();
                        recordId = 0;
                    }
                }
                else {
                    string masterId = recordId.ToString();
                    if (recordId.ToString().Equals("0"))
                    {
                        masterId = "(SELECT MAX(ID) FROM PAYMENT_REGISTER)";
                    }

                    classHelper.query = @"BEGIN TRY 
                    BEGIN TRANSACTION ";

                    classHelper.query += @" IF EXISTS (SELECT ID FROM PAYMENT_REGISTER WHERE ID ='" + recordId + @"') 
                 BEGIN
                    UPDATE PAYMENT_REGISTER SET 
                        DATE = '" + Classes.Helper.ConvertDatetime(dtpDate.Value.Date) + @"',  
                        RECEIVING_ACCOUNT_ID = '" + cmbCashAccount.SelectedValue.ToString() + @"',
                        PAYMENT_ACCOUNT_ID = '" + Classes.Helper.cashId + @"',
                        AMOUNT = '" + classHelper.AvoidInjection(txtCashAmount.Text) + @"',
                        TRANSACTION_TYPE = 'C',      
                        MODIFICATION_DATE = GETDATE(),
                        MODIFIED_BY = '" + Classes.Helper.userId + @"'
                    WHERE ID = '" + recordId + @"';
                 END
                 ELSE
                 BEGIN
                     INSERT INTO PAYMENT_REGISTER (DATE,RECEIVING_ACCOUNT_ID,PAYMENT_ACCOUNT_ID,AMOUNT,TRANSACTION_TYPE,CREATION_DATE,CREATED_BY) 
                     VALUES (
                    '" + Classes.Helper.ConvertDatetime(dtpDate.Value.Date) + @"',
                    '" + cmbCashAccount.SelectedValue.ToString() + @"',
                    '" + Classes.Helper.cashId + @"',
                    '" + classHelper.AvoidInjection(txtCashAmount.Text) + @"',
                    'C', GETDATE(),'" + Classes.Helper.userId + @"');
                 END";

                    classHelper.query += @" DELETE FROM LEDGERS WHERE REF_ID = " + recordId + @" AND ENTRY_OF = 'PAYMENT REGISTER'";

                    classHelper.query += @" 
                            INSERT INTO LEDGERS(DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
                            VALUES('" + Classes.Helper.ConvertDatetime(dtpDate.Value.Date) + "','" + cmbCashAccount.SelectedValue.ToString() +
                                    "'," + masterId + ",'PAYMENT REGISTER','VOUCHER-'+CONVERT(NVARCHAR," + masterId + ")+'-'+CONVERT(NVARCHAR,YEAR(GETDATE())), '" + txtCashAmount.Text + "',0,'PAYMENT VOUCHER','" + Classes.Helper.userId + @"',GETDATE(),1);

                            INSERT INTO LEDGERS(DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
                            VALUES('" + Classes.Helper.ConvertDatetime(dtpDate.Value.Date) + "','" + Classes.Helper.cashId +
                                    "'," + masterId + ",'PAYMENT REGISTER','VOUCHER-'+CONVERT(NVARCHAR," + masterId + ")+'-'+CONVERT(NVARCHAR,YEAR(GETDATE())), 0,'" + txtCashAmount.Text + "','PAYMENT VOUCHER','" + Classes.Helper.userId + @"',GETDATE(),1);";

                    classHelper.query += @" COMMIT TRANSACTION 
                     END TRY 
                     BEGIN CATCH 
                             IF @@TRANCOUNT > 0 
                             ROLLBACK TRANSACTION 
                     END CATCH";

                    if (classHelper.InsertUpdateDelete(classHelper.query) >= 1)
                    {
                        classHelper.ShowMessageBox("Record Saved Successfully.", "Information");
                        cmbCashAccount.SelectedIndex = 0;
                        txtCashAmount.Text = "0";
                        GetData();
                        TotalSum();
                        recordId = 0;
                    }
                }
            }
        }

        private void SaveAccountPayment()
        {
            if (cmbReceiving.SelectedIndex == 0)
            {
                classHelper.ShowMessageBox("Receiving Account is not selected, please select Receiving Account.", "Warning");
                cmbReceiving.Focus();
            }
            else if (cmbPayment.SelectedIndex == 0)
            {
                classHelper.ShowMessageBox("Payment Account is not selected, please select Payment Account.", "Warning");
                cmbPayment.Focus();
            }
            else
            {
                string masterId = recordId.ToString();
                if (recordId.ToString().Equals("0"))
                {
                    masterId = "(SELECT MAX(ID) FROM PAYMENT_REGISTER)";
                }

                classHelper.query = @"BEGIN TRY 
                    BEGIN TRANSACTION ";

                classHelper.query += @" IF EXISTS (SELECT ID FROM PAYMENT_REGISTER WHERE ID ='" + recordId + @"') 
                 BEGIN
                    UPDATE PAYMENT_REGISTER SET 
                        DATE = '" + Classes.Helper.ConvertDatetime(dtpDate.Value.Date) + @"',  
                        RECEIVING_ACCOUNT_ID = '" + cmbReceiving.SelectedValue.ToString() + @"',
                        PAYMENT_ACCOUNT_ID = '" + cmbPayment.SelectedValue.ToString() + @"',
                        AMOUNT = '" + classHelper.AvoidInjection(txtAccountAmount.Text) + @"',
                        TRANSACTION_TYPE = 'A',      
                        MODIFICATION_DATE = GETDATE(),
                        MODIFIED_BY = '" + Classes.Helper.userId + @"'
                    WHERE ID = '" + recordId + @"';
                 END
                 ELSE
                 BEGIN
                     INSERT INTO PAYMENT_REGISTER (DATE,RECEIVING_ACCOUNT_ID,PAYMENT_ACCOUNT_ID,AMOUNT,TRANSACTION_TYPE,CREATION_DATE,CREATED_BY) 
                     VALUES (
                    '" + Classes.Helper.ConvertDatetime(dtpDate.Value.Date) + @"',
                    '" + cmbReceiving.SelectedValue.ToString() + @"',
                    '" + cmbPayment.SelectedValue.ToString() + @"',
                    '" + classHelper.AvoidInjection(txtAccountAmount.Text) + @"',
                    'A', GETDATE(),'" + Classes.Helper.userId + @"');
                 END";

                classHelper.query += @" DELETE FROM LEDGERS WHERE REF_ID = " + recordId + @" AND ENTRY_OF = 'PAYMENT REGISTER'";

                classHelper.query += @" 
                            INSERT INTO LEDGERS(DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
                            VALUES('" + Classes.Helper.ConvertDatetime(dtpDate.Value.Date) + "','" + cmbReceiving.SelectedValue.ToString() +
                                "'," + masterId + ",'PAYMENT REGISTER','VOUCHER-'+CONVERT(NVARCHAR," + masterId + ")+'-'+CONVERT(NVARCHAR,YEAR(GETDATE())), '" + txtAccountAmount.Text + "',0,'PAYMENT VOUCHER','" + Classes.Helper.userId + @"',GETDATE(),1);

                            INSERT INTO LEDGERS(DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
                            VALUES('" + Classes.Helper.ConvertDatetime(dtpDate.Value.Date) + "','" + cmbPayment.SelectedValue.ToString() +
                                "'," + masterId + ",'PAYMENT REGISTER','VOUCHER-'+CONVERT(NVARCHAR," + masterId + ")+'-'+CONVERT(NVARCHAR,YEAR(GETDATE())), 0,'" + txtAccountAmount.Text + "','PAYMENT VOUCHER','" + Classes.Helper.userId + @"',GETDATE(),1);";

                classHelper.query += @" COMMIT TRANSACTION 
                     END TRY 
                     BEGIN CATCH 
                             IF @@TRANCOUNT > 0 
                             ROLLBACK TRANSACTION 
                     END CATCH";

                if (classHelper.InsertUpdateDelete(classHelper.query) >= 1)
                {
                    classHelper.ShowMessageBox("Record Saved Successfully.", "Information");
                    cmbReceiving.SelectedIndex = 0;
                    cmbPayment.SelectedIndex = 0;
                    txtAccountAmount.Text = "0";
                    GetData();
                    TotalSum();
                    recordId = 0;
                }
            }
        }

        private void TotalSum()
        {
            try
            {
                txtReceivingTotal.Text = gridData.Rows.Cast<DataGridViewRow>()
                    .Sum(t => Convert.ToDecimal(t.Cells["amount"].Value)).ToString();

                txtPaymentTotal.Text = gridData.Rows.Cast<DataGridViewRow>()
                    .Sum(t => Convert.ToDecimal(t.Cells["amount"].Value)).ToString();

                decimal cashDebit = gridData.Rows.Cast<DataGridViewRow>()
                    .Where(t => t.Cells["receiveAccountId"].Value?.ToString() == "1082")
                    .Sum(t => Convert.ToDecimal(t.Cells["amount"].Value));

                decimal cashCredit = gridData.Rows.Cast<DataGridViewRow>()
                    .Where(t => t.Cells["paymentAccountId"].Value?.ToString() == "1082")
                    .Sum(t => Convert.ToDecimal(t.Cells["amount"].Value));

                decimal cashOpening = Convert.ToDecimal(txtCashOpening.Text);

                txtCashClosing.Text = (cashOpening + cashDebit - cashCredit).ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void LoadGridData(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.gridData.Rows[e.RowIndex];
                recordId = Convert.ToInt32(row.Cells["id"].Value.ToString());
                if (row.Cells["type"].Value.ToString().Equals("C"))
                {
                    if (row.Cells["receiveAccountId"].Value.ToString().Equals("1082"))
                    {
                        cmbCashAccount.SelectedValue = row.Cells["paymentAccountId"].Value.ToString();
                        txtCashAmount.Text = row.Cells["amount"].Value.ToString();
                        rdbReceive.Checked = true;
                    }
                    else
                    {
                        cmbCashAccount.SelectedValue = row.Cells["receiveAccountId"].Value.ToString();
                        txtCashAmount.Text = row.Cells["amount"].Value.ToString();
                        rdbPayment.Checked = true;
                    }
                }
                else {
                    cmbReceiving.SelectedValue = row.Cells["receiveAccountId"].Value.ToString();
                    cmbPayment.SelectedValue = row.Cells["paymentAccountId"].Value.ToString();
                    txtAccountAmount.Text = row.Cells["amount"].Value.ToString();
                }
                gridData.Rows.RemoveAt(e.RowIndex);
                TotalSum();
            }
        }


        private void frm_Account_Ledger_Load(object sender, EventArgs e)
        {
            LoadAccounts();
            GetCashOpeningBalance();
            GetData();
            TotalSum();
        }

        private void frm_Account_Ledger_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void btnDiscard_Click(object sender, EventArgs e)
        {
            SaveCashPayment();      
        }


        private void txtCashAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                classHelper.AllowNumbers(e);
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void btnAccountSave_Click(object sender, EventArgs e)
        {
            SaveAccountPayment();
        }

        private void gridData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadGridData(e);
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            GetCashOpeningBalance();
            GetData();
            TotalSum();
        }
    }
}
