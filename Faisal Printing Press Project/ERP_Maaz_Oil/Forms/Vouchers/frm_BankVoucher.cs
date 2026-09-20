using ERP_Maaz_Oil.Vouchers;
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
    public partial class frm_BankVoucher : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        int id = 0;
        bool isEdit = false;

        public frm_BankVoucher()
        {
            InitializeComponent();
        }

        private void Clear()
        {
            isEdit = true;
            id = 0;
            txtTotalBalanceAmount.Text = "0";
            txtDescription.Clear();
            txtSearch.Clear();
            cmbAccounts.SelectedIndex = 0;
            cmbBanks.SelectedIndex = 0;
            txtAmount.Text = "0";
            dtpDate.Focus();
            rdbBankReceipt.Checked = true;
            LoadForm();
            dtpDate.Value = DateTime.Now;
            isEdit = false;
        }

        private void Save()
        {
            if (cmbAccounts.SelectedIndex == 0)
            {
                MessageBox.Show("Account is not selected", "error");
                cmbAccounts.Focus();
            }
            else if (cmbBanks.SelectedIndex == 0)
            {
                MessageBox.Show("Bank is not selected", "error");
                cmbBanks.Focus();
            }
            else if (float.Parse(txtAmount.Text) <= 0)
            {
                MessageBox.Show("Amount field is left blank", "error");
                txtAmount.Focus();
            }
            else
            {
                char voucherType = 'R';
                if (rdbBankPayment.Checked == true)
                {
                    voucherType = 'P';
                }
                string masterId = id.ToString();
                if (id.Equals(""))
                {
                    masterId = "(SELECT MAX(ID) FROM BANK_VOUCHER)";
                }

                if (voucherType == 'R')
                {
                    classHelper.query = @"BEGIN TRY 
                      BEGIN TRANSACTION ";

                    classHelper.query += @" IF EXISTS (SELECT ID FROM BANK_VOUCHER WHERE ID = '" + id + @"') 
                                      BEGIN
                                      UPDATE BANK_VOUCHER SET DATE = '" + dtpDate.Value.ToString() + @"',
                                      VOUCHER_TYPE = '" + voucherType + @"',
                                      VOUCHER_NUMBER = '" + lblCode.Text + @"',
                                      ACCOUNT_ID = '" + cmbAccounts.SelectedValue.ToString() + @"',
                                      BANK_ID = '" + cmbBanks.SelectedValue.ToString() + @"',
                                      DESCRIPTION= '" + classHelper.AvoidInjection(txtDescription.Text) + @"',
                                      AMOUNT = '" + classHelper.AvoidInjection(txtAmount.Text) + @"',
                                      MODIFICATION_DATE = GETDATE(), MODIFIED_BY = '" + Classes.Helper.userId + @"'
                                      WHERE ID = '" + id + @"';


                                     DELETE FROM LEDGERS WHERE REF_ID = '" + id + @"' AND ENTRY_OF = 'BANK RECEIPT';
                                     INSERT INTO LEDGERS VALUES('" + dtpDate.Value.ToString() + "', '" + cmbBanks.SelectedValue.ToString() + @"',
                                      " + masterId + ", 'BANK RECEIPT','" + lblCode.Text + @"',
                                      '" + txtAmount.Text.ToString() + "','0','" + classHelper.AvoidInjection(txtDescription.Text) + "','" + Classes.Helper.userId + @"',
                                      GETDATE(),NULL,NULL,1,NULL);

                                      INSERT INTO LEDGERS VALUES('" + dtpDate.Value.ToString() + @"', '" + cmbAccounts.SelectedValue.ToString() + @"','" + masterId + "', 'BANK RECEIPT','" + lblCode.Text + @"',
                                      '0','" + txtAmount.Text.ToString() + "','" + classHelper.AvoidInjection(txtDescription.Text) + "','" + Classes.Helper.userId + @"',
                                      GETDATE(),NULL,NULL,1,NULL);
                                  END
                                  ELSE 
                                  BEGIN


                                     INSERT INTO BANK_VOUCHER VALUES('" + voucherType + @"','" + lblCode.Text + @"',
                                      '" + dtpDate.Value.ToString() + "','" + cmbBanks.SelectedValue.ToString() + "','" + cmbAccounts.SelectedValue.ToString() + @"',
                                      '" + classHelper.AvoidInjection(txtDescription.Text) + "','" + classHelper.AvoidInjection(txtAmount.Text) + @"',
                                      '" + Classes.Helper.userId + @"',GETDATE(),NULL,NULL);

                                      INSERT INTO LEDGERS VALUES('" + dtpDate.Value.ToString() + "', '" + cmbBanks.SelectedValue.ToString() + @"',
                                      " + masterId + ", 'BANK RECEIPT','" + lblCode.Text + @"',
                                      '" + txtAmount.Text.ToString() + "','0','" + classHelper.AvoidInjection(txtDescription.Text) + "','" + Classes.Helper.userId + @"',
                                      GETDATE(),NULL,NULL,1,NULL);

                                      INSERT INTO LEDGERS VALUES('" + dtpDate.Value.ToString() + @"', '" + cmbAccounts.SelectedValue.ToString() + @"','" + masterId + "', 'BANK RECEIPT','" + lblCode.Text + @"',
                                      '0','" + txtAmount.Text.ToString() + "','" + classHelper.AvoidInjection(txtDescription.Text) + "','" + Classes.Helper.userId + @"',
                                      GETDATE(),NULL,NULL,1,NULL);
                                   END";


                    classHelper.query += @" COMMIT TRANSACTION 
                          END TRY 
                      BEGIN CATCH 
                              IF @@TRANCOUNT > 0 
                              ROLLBACK TRANSACTION 
                      END CATCH";
                }
                else
                {
                    classHelper.query = @"BEGIN TRY 
                  BEGIN TRANSACTION ";

                    classHelper.query += @" IF EXISTS (SELECT ID FROM BANK_VOUCHER WHERE ID = '" + id + @"') 
                              BEGIN
                                  UPDATE BANK_VOUCHER SET DATE = '" + dtpDate.Value.ToString() + @"',
                                  VOUCHER_TYPE = '" + voucherType + @"',
                                  VOUCHER_NUMBER = '" + lblCode.Text + @"',
                                  ACCOUNT_ID = '" + cmbAccounts.SelectedValue.ToString() + @"',
                                  DESCRIPTION= '" + classHelper.AvoidInjection(txtDescription.Text) + @"',
                                  AMOUNT = '" + classHelper.AvoidInjection(txtAmount.Text) + @"',
                                  MODIFICATION_DATE = GETDATE(), MODIFIED_BY = '" + Classes.Helper.userId + @"'
                                  WHERE ID = '" + id + @"';

                                  DELETE FROM LEDGERS WHERE REF_ID = '" + id + @"' AND ENTRY_OF = 'BANK PAYMENT';
                                  INSERT INTO LEDGERS VALUES('" + dtpDate.Value.ToString() + "','" + cmbAccounts.SelectedValue.ToString() + @"','" + masterId + "', 'BANK PAYMENT','" + lblCode.Text + @"',
                                  '" + txtAmount.Text.ToString() + "','0','" + classHelper.AvoidInjection(txtDescription.Text) + "','" + Classes.Helper.userId + @"',
                                  GETDATE(),NULL,NULL,1,NULL); 

                                  INSERT INTO LEDGERS VALUES('" + dtpDate.Value.ToString() + @"', '" + cmbBanks.SelectedValue.ToString() + @"',
                                  '" + masterId + "', 'CASH PAYMENT','" + lblCode.Text + @"',
                                  '0','" + txtAmount.Text.ToString() + "','" + classHelper.AvoidInjection(txtDescription.Text) + "','" + Classes.Helper.userId + @"',
                                  GETDATE(),NULL,NULL,1,NULL);
                                    END
                                    ELSE 
                                    BEGIN
                                 
                               INSERT INTO BANK_VOUCHER VALUES('" + voucherType + @"','" + lblCode.Text + @"',
                                 '" + dtpDate.Value.ToString() + "','" + cmbBanks.SelectedValue.ToString() + "','" + cmbAccounts.SelectedValue.ToString() + @"',
                                 '" + classHelper.AvoidInjection(txtDescription.Text) + "','" + classHelper.AvoidInjection(txtAmount.Text) + @"',
                                  '" + Classes.Helper.userId + @"',GETDATE(),NULL,NULL);

                                INSERT INTO LEDGERS VALUES('" + dtpDate.Value.ToString() + "','" + cmbAccounts.SelectedValue.ToString() + @"','" + masterId + "', 'BANK PAYMENT','" + lblCode.Text + @"',
                                  '" + txtAmount.Text.ToString() + "','0','" + classHelper.AvoidInjection(txtDescription.Text) + "','" + Classes.Helper.userId + @"',
                                  GETDATE(),NULL,NULL,1,NULL);                



                                  INSERT INTO LEDGERS VALUES('" + dtpDate.Value.ToString() + @"', '" + cmbBanks.SelectedValue.ToString() + @"',
                                  '" + masterId + "', 'BANK PAYMENT','" + lblCode.Text + @"',
                                  '0','" + txtAmount.Text.ToString() + "','" + classHelper.AvoidInjection(txtDescription.Text) + "','" + Classes.Helper.userId + @"',
                                  GETDATE(),NULL,NULL,1,NULL);
                              END";


                    classHelper.query += @" COMMIT TRANSACTION 
                      END TRY 
                  BEGIN CATCH 
                          IF @@TRANCOUNT > 0 
                          ROLLBACK TRANSACTION 
                  END CATCH";

                }

                if (classHelper.InsertUpdateDelete(classHelper.query) > 0)
                {
                    MessageBox.Show("Record Saved Sucessfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Clear();
                }

            }
        }


        public void GenerateVoucher()
        {
            classHelper.query = "SELECT ISNULL(MAX(ID),0)+1 FROM BANK_VOUCHER";
            lblCode.Text = "BV-" + classHelper.generate_voucher_code(classHelper.query) + "-" + DateTime.Now.Year;
        }

        public void LoadPaymentTotalGrid()
        {
            classHelper.query = @"SELECT B.COA_NAME AS [PAYMENT ACCOUNT],SUM(A.AMOUNT) AS TOTAL
            FROM BANK_VOUCHER A
            INNER JOIN COA B ON A.ACCOUNT_ID = B.COA_ID          
            WHERE A.[DATE] BETWEEN '" + dtpDate.Value.Date + @"' AND '" + dtpDate.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
            AND A.VOUCHER_TYPE = 'P'
            GROUP BY B.COA_NAME";

            try
            {
                grdPaySummary.DataSource = null;
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    DataTable dt = new DataTable();
                    dt.Load(classHelper.dr);
                    grdPaySummary.DataSource = dt;
                }
                else
                {
                    // MessageBox.Show("No Record Found.", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public void LoadReceiptTotalGrid()
        {
            classHelper.query = @"SELECT B.COA_NAME AS [RECEIPT ACCOUNT],SUM(A.AMOUNT) AS TOTAL
            FROM BANK_VOUCHER A
            INNER JOIN COA B ON A.ACCOUNT_ID = B.COA_ID          
            WHERE A.[DATE] BETWEEN '" + dtpDate.Value.Date + @"' AND '" + dtpDate.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + @"'
            AND A.VOUCHER_TYPE = 'R'
            GROUP BY B.COA_NAME";

            try
            {
                grdRecSummary.DataSource = null;
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    DataTable dt = new DataTable();
                    dt.Load(classHelper.dr);
                    grdRecSummary.DataSource = dt;
                }
                else
                {
                    // MessageBox.Show("No Record Found.", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void LoadForm()
        {
            try
            {
                classHelper.LoadBankCashVoucherGrid(grdSearch, dtpDate.Value.Date);
                classHelper.LoadAllAccounts(cmbAccounts);
                classHelper.LoadAllBankss(cmbBanks);
                GenerateVoucher();

                LoadPaymentTotalGrid();
                LoadReceiptTotalGrid();


                if (grdRecSummary.DataSource != null)
                    grdRecSummary.Columns[0].Width = 190;

                if (grdPaySummary.DataSource != null)
                    grdPaySummary.Columns[0].Width = 190;

                rdbBankReceipt.Checked = true;

                TotalSum();
                TotalReceiptPaymentGrid();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void frm_CashPmt_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void txtSEARCH_TextChanged(object sender, EventArgs e)
        {
            try
            {
                (grdSearch.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
              [" + grdSearch.Columns["VOUCHER_NUMBER"].Name.ToString() + "] LIKE '%" + classHelper.AvoidInjection(txtSearch.Text) + "%' OR ["
              + grdSearch.Columns["ACCOUNT NAME"].Name.ToString() + "] LIKE '%" + classHelper.AvoidInjection(txtSearch.Text) + "%' OR["
               + grdSearch.Columns["DESCRIPTION"].Name.ToString() + "] LIKE '%" + classHelper.AvoidInjection(txtSearch.Text) + "%'");
                grdSearch.ClearSelection();
            }

            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void LoadGridData(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.grdSearch.Rows[e.RowIndex];
                id = Convert.ToInt32(row.Cells["ID"].Value.ToString());
                lblCode.Text = row.Cells["VOUCHER_NUMBER"].Value.ToString();
                dtpDate.Text = row.Cells["DATE"].Value.ToString();
                cmbAccounts.SelectedValue = row.Cells["ACCOUNT_ID"].Value.ToString();
                cmbBanks.SelectedValue = row.Cells["BANK_ID"].Value.ToString();
                txtDescription.Text = row.Cells["DESCRIPTION"].Value.ToString();
                txtAmount.Text = row.Cells["AMOUNT"].Value.ToString(); ;

                if (row.Cells["VOUCHER TYPE"].Value.ToString().Equals("RECEIPT"))
                {
                    rdbBankReceipt.Checked = true;
                }
                else
                {
                    rdbBankPayment.Checked = true;
                }

                TotalSum();
            }
        }

        private void TotalReceiptPaymentGrid()
        {
            try
            {
                txtTotalRecGrid.Text = grdRecSummary.Rows.Cast<DataGridViewRow>()
                    .Sum(t => Convert.ToDecimal(t.Cells["TOTAL"].Value)).ToString();

                txtTotalPayGrid.Text = grdPaySummary.Rows.Cast<DataGridViewRow>()
                    .Sum(t => Convert.ToDecimal(t.Cells["TOTAL"].Value)).ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void TotalSum()
        {
            try
            {
                txtTotalRcvd.Text = grdSearch.Rows.Cast<DataGridViewRow>()
                    .Where(x => x.Cells["VOUCHER TYPE"].Value.ToString().Equals("RECEIPT"))
                    .Sum(t => Convert.ToDecimal(t.Cells["AMOUNT"].Value)).ToString();

                txtTotalPaid.Text = grdSearch.Rows.Cast<DataGridViewRow>()
                    .Where(x => x.Cells["VOUCHER TYPE"].Value.ToString().Equals("PAYMENT"))
                    .Sum(t => Convert.ToDecimal(t.Cells["AMOUNT"].Value)).ToString();

                txtTotalBalanceAmount.Text = grdSearch.Rows.Cast<DataGridViewRow>()
                    .Sum(t => Convert.ToDecimal(t.Cells["AMOUNT"].Value)).ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void grdSEARCH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                isEdit = true;
                LoadGridData(e);
                isEdit = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        }

        private void btnCLEAR_Click(object sender, EventArgs e)
        {
            try
            {
                Clear();
                //  grdSearch.Rows.Clear();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        }



        private void btnSAVE_Click_1(object sender, EventArgs e)
        {
            Save();
        }


        private void grdSEARCH_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            grdSearch.Columns["ID"].Visible = false;
            grdSearch.Columns["ACCOUNT_ID"].Visible = false;
            grdSearch.Columns["BANK_ID"].Visible = false;
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            classHelper.AllowNumbers(e);
        }

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            classHelper.check_blank_zero(sender as TextBox);
            classHelper.textField_leave(sender as TextBox);
        }


        private void txtAmount_Enter(object sender, EventArgs e)
        {
            classHelper.select_all_text(sender as TextBox);
        }

        private void txtAmount_MouseClick(object sender, MouseEventArgs e)
        {
            classHelper.select_all_text(sender as TextBox);
        }

        private void txtPay_Leave(object sender, EventArgs e)
        {
            classHelper.textField_leave(sender as TextBox);
        }

        private void cmbPay_TextUpdate(object sender, EventArgs e)
        {
            classHelper.CmbTextUpdate(sender as ComboBox);
        }

        private void cmbPay_DropDown(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown += new PreviewKeyDownEventHandler(cmbPay_PreviewKeyDown);
        }

        private void cmbPay_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown -= cmbPay_PreviewKeyDown;
            if (cbo.DroppedDown) cbo.Focus();
        }

        private void frm_CashPmt_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void amountTxtChanged(object sender, EventArgs e)
        {
            TextBox txt = ((TextBox)sender);

            txtAmountWords.Text = classHelper.ConvertWholeNumber(txt.Text);
        }

        private void Delete()
        {
            char voucherType = 'R';
            if (rdbBankPayment.Checked == true)
            {
                voucherType = 'P';
            }

            if (voucherType == 'R')
            {
                classHelper.query = @" BEGIN TRY 
                             BEGIN TRANSACTION ";

                classHelper.query += @" DELETE FROM LEDGERS WHERE REF_ID = '" + id + @"' AND ENTRY_OF = 'BANK RECEIPT ';
                DELETE FROM BANK_VOUCHER WHERE ID = '" + id + @"';";

                classHelper.query += @" COMMIT TRANSACTION 
                        END TRY 
                    BEGIN CATCH 
                            IF @@TRANCOUNT > 0 
                            ROLLBACK TRANSACTION 
                    END CATCH";
            }
            else
            {
                classHelper.query = @" BEGIN TRY 
                             BEGIN TRANSACTION ";

                classHelper.query += @" DELETE FROM LEDGERS WHERE REF_ID = '" + id + @"' AND ENTRY_OF = 'BANK PAYMENT ';
                DELETE FROM BANK_VOUCHER WHERE ID = '" + id + @"';";

                classHelper.query += @" COMMIT TRANSACTION 
                        END TRY 
                    BEGIN CATCH 
                            IF @@TRANCOUNT > 0 
                            ROLLBACK TRANSACTION 
                    END CATCH";
            }

            if (classHelper.InsertUpdateDelete(classHelper.query) >= 1)
            {
                classHelper.ShowMessageBox("Record Deleted Sucessfully.", "Information");
                Clear();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (id > 0)
            {
                Delete();
                Clear();
            }
            else
            {
                MessageBox.Show("Please select voucher to delete.", "Error");
            }
        }

        private void dtp_DATE_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (isEdit) return;

                txtTotalPayGrid.Text = "0";
                txtTotalRecGrid.Text = "0";

                classHelper.LoadCashVoucherGrid(grdSearch, dtpDate.Value.Date);


                LoadPaymentTotalGrid();
                LoadReceiptTotalGrid();


                if (grdRecSummary.DataSource != null)
                    grdRecSummary.Columns[0].Width = 190;

                if (grdPaySummary.DataSource != null)
                    grdPaySummary.Columns[0].Width = 190;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void grdRecSummary_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }

        private void grdPaySummary_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }

        private void PrintVoucher()
        {
            try
            {
                if (id != 0)
                {
                    string voucherType = "RECEIPT";
                    if (rdbBankPayment.Checked == true)
                    {
                        voucherType = "PAYMENT";
                    }

                    classHelper.mds.Tables["ReceiptPaymentVoucher"].Clear();
                    classHelper.dataR = classHelper.mds.Tables["ReceiptPaymentVoucher"].NewRow();
                    //classHelper.dataR["id"] = lblCode.Text;
                   classHelper.dataR["debitCreditAc"] = lblCode.Text;
                    classHelper.dataR["date"] = dtpDate.Value.Date;
                    classHelper.dataR["chqDate"] = txtDescription.Text;
                    classHelper.dataR["paidRecTo"] = voucherType;
                    classHelper.dataR["bankName"] = cmbBanks.Text;
                    classHelper.dataR["amount"] = Convert.ToDouble(txtAmount.Text);
                    if (voucherType.Equals("RECEIPT"))
                    {
                        classHelper.dataR["voucherName"] = "BANK RECEIPT VOUCHER";
                    }
                    else
                    {
                        classHelper.dataR["voucherName"] = "BANK PAYMENT VOUCHER";
                    }

                    classHelper.mds.Tables["ReceiptPaymentVoucher"].Rows.Add(classHelper.dataR);

                    if (voucherType.Equals("RECEIPT"))
                    {
                        classHelper.rpt = new ERP_Maaz_Oil.Forms.Reporting.frmReports();
                        classHelper.rpt.GenerateReport("CashReceiptVoucher", classHelper.mds);
                        classHelper.rpt.ShowDialog();
                    }
                    else
                    {
                        classHelper.rpt = new ERP_Maaz_Oil.Forms.Reporting.frmReports();
                        classHelper.rpt.GenerateReport("CashPaymentVoucher", classHelper.mds);
                        classHelper.rpt.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Please select a record to print the voucher.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnReceiptVoucher_Click(object sender, EventArgs e)
        {
            PrintVoucher();

        }

        private void cmbAccounts_Leave(object sender, EventArgs e)
        {
            if (!classHelper.CheckAccountExists(cmbAccounts.Text))
            {
                string accountName = cmbAccounts.Text;
                DialogResult dialogResult = MessageBox.Show("Do you want to add " + cmbAccounts.Text + " Account?", "Add New Account", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    using (Forms.frmChartOfAccounts frm = new Forms.frmChartOfAccounts(10, 5, classHelper.AvoidInjection(cmbAccounts.Text), 0))
                    {
                        if (frm.ShowDialog() == System.Windows.Forms.DialogResult.Cancel || frm.ShowDialog() == System.Windows.Forms.DialogResult.Abort)
                        {
                            classHelper.LoadAllAccounts(cmbAccounts);
                            cmbAccounts.Text = accountName;
                        }
                    }
                }
                else
                {
                    cmbAccounts.SelectedIndex = 0;
                    cmbAccounts.Focus();
                }
            }
        }

        private void cmbBanks_Leave(object sender, EventArgs e)
        {
            if (!classHelper.CheckAccountExists(cmbBanks.Text))
            {
                string accountName = cmbBanks.Text;
                DialogResult dialogResult = MessageBox.Show("Do you want to add " + cmbBanks.Text + " Account?", "Add New Account", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    using (Forms.frmChartOfAccounts frm = new Forms.frmChartOfAccounts(5, 9, classHelper.AvoidInjection(cmbBanks.Text), 0))
                    {
                        if (frm.ShowDialog() == System.Windows.Forms.DialogResult.Cancel || frm.ShowDialog() == System.Windows.Forms.DialogResult.Abort)
                        {
                            classHelper.LoadAllBankss(cmbBanks);
                            cmbBanks.Text = accountName;
                        }
                    }
                }
                else
                {
                    cmbBanks.SelectedIndex = 0;
                    cmbBanks.Focus();
                }
            }
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {

        }
    }
}