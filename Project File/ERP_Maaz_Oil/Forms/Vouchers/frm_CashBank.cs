using ERP_Maaz_Oil.Vouchers;
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
    public partial class frm_CashBank : Form
    {
        Classes.Helper cls_fhp = new Classes.Helper();
        Classes.cls_Cash_Book cls_CPV = new Classes.cls_Cash_Book();
        Classes.cls_Cash_Receipt cls_CRV = new Classes.cls_Cash_Receipt();
        Classes.cls_Payment_Transfer cls_pt = new Classes.cls_Payment_Transfer();
        Forms.Vouchers.Voucher voucher = new Forms.Vouchers.Voucher();
        DayBook dayBook = new DayBook();
        string cpv_id = "";
        string crv_id = "";
        int is_edit = 0;
        int rowIndex = -1;
        public frm_CashBank()
        {
            InitializeComponent();
        }

        private void clear()
        {
            //cls_CPV.generate_transaction_no(lblTrNo);
            //cls_CPV.generate_voucher_no(lblCode);
            dtp_DATE.Value = DateTime.Now;
            //  txtAmount.Text = "0";
            txtTotalBalanceAmount.Text = "0";
            txtDescription.Clear();
            //  txtRefAccPay.Clear();
            //    txtRefAccRec.Clear();

            txtSEARCH.Clear();
            cmbAccounts.SelectedIndex = 0;
            cmbBank.SelectedIndex = 0;
            txtAmountPay.Text = "0";
            //  txtPaidTo.Text = "";
            dtp_DATE.Focus();
            cpv_id = "";
            crv_id = "";
            is_edit = 0;
            rowIndex = -1;
            txtBalance.Text = cls_fhp.check_balance_avilable("" + Classes.Helper.cashId + @"", txtAmountPay.Text);
            // cmbRecAcc.SelectedIndex = 0;
            rdbCashPayment.Checked = true;
            LoadForm();
            //rdbINV_REC.Checked = false;
            //rdbOTHERS.Checked = false;
            //if (cmbSELECT_INV.Enabled == true) { cmbSELECT_INV.SelectedIndex = 0; }
            //cmbSELECT_INV.Enabled = false;
        }

        //get data from grid on click
        private void load_data_fromGrid(DataGridViewCellEventArgs e)
        {
            try
            {


                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.grdSEARCH.Rows[e.RowIndex];
                    if (row.Cells[1].Value.ToString().Contains("CRV"))
                        crv_id = row.Cells[0].Value.ToString();
                    else
                        cpv_id = row.Cells[0].Value.ToString();

                    is_edit = 1;
                    lblCode.Text = row.Cells[1].Value.ToString();
                    // string dateTime = DateTime.Parse(row.Cells[3].Value.ToString()).ToString("dddd, dd MMMM yyyy HH:mm:ss");

                    //dtp_DATE.Text = DateTime.Parse(row.Cells[3].Value.ToString()).ToString("dddd, dd MMMM yyyy HH:mm:ss");

                    // dtp_DATE.Focus();
                    //lblTrNo.Text = row.Cells[2].Value.ToString();
                    //cmbAccounts.SelectedValue = row.Cells[4].Value.ToString();
                    //txtNar.Text = row.Cells[6].Value.ToString();
                    //txtRefAccPay.Text = row.Cells[10].Value.ToString();
                    //txtAmountPay.Text = row.Cells[8].Value.ToString();
                    //txtPaidTo.Text = row.Cells[7].Value.ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        }
        string query = "";

        private void SaveCash()

        {
            // Determine transaction type based on the selected radio button
            string transactionType = rdbCashReceipt.Checked ? "0" : "1"; // 0 for Cash Receipt, 1 for Cash Payment


            if (cmbAccounts.SelectedIndex == 0)
            {
                cls_fhp.ShowMessageBox("Account is not selected", "error");
                //essageBox.Show("Payment account is not selected, please select payment account.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbAccounts.Focus();
            }

            if (cmbBank.SelectedIndex == 0)
            {
                cls_fhp.ShowMessageBox("BankAccount is not selected", "error");
                //essageBox.Show("Payment account is not selected, please select payment account.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbBank.Focus();
            }

            else if (txtDescription.Text.Trim().Equals(""))
            {
                cls_fhp.ShowMessageBox("Description field is left blank", "error");
                //essageBox.Show("Narration field is blank.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescription.Focus();
            }


            else if (float.Parse(txtAmountPay.Text) <= 0)
            {
                cls_fhp.ShowMessageBox("Amount field is left blank", "error");
                //essageBox.Show("Amount field is blank.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAmountPay.Focus();
            }



            else
            {

                if (int.Parse(cls_fhp.check_balance_avilable("" + Classes.Helper.cashId + @"", txtAmountPay.Text)) == 0)
                {
                    cls_fhp.ShowMessageBox("Insufficient Cash in account", "error");
                    //essageBox.Show("Insufficient Cash in account.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAmountPay.Focus();
                    txtAmountPay.SelectAll();
                    return;
                }
                //if (cpv_id.Equals("")) {
                //    cpv_id = "(SELECT MAX(CPV_ID) FROM CASH_PAY_VOUCHER)";
                //} 


                cls_fhp.query = @"BEGIN TRY 
                  BEGIN TRANSACTION ";
                cls_fhp.query += @"IF EXISTS (select CPV_ID from CASHBANKRECMASTER WHERE CPV_ID = '" + cpv_id + @"') 
                              BEGIN
                                  UPDATE CASHBANKRECMASTER SET DAATE = '" + dtp_DATE.Value.ToString() + @"',
                                  COA_ID = '" + cmbAccounts.SelectedValue.ToString() + "',DESCRIPTION= '" + cls_fhp.AvoidInjection(txtDescription.Text) + @"',
                                  BANK_ID='" + cmbBank.SelectedValue.ToString() + @"',
                                                                
                                  AMOUNT = '" + cls_fhp.AvoidInjection(txtAmountPay.Text) + @"',
                                  MODIFICATION_DATE = GETDATE(), MODIFIED_BY = '" + Classes.Helper.userId + @"', 
                                  TYPE = 

                                  WHERE CPV_ID = '" + cpv_id + @"';

                                  DELETE FROM LEDGERS WHERE REF_ID = '" + cpv_id + @"' AND ENTRY_OF = 'CASH_PAYMENT';
                                  INSERT INTO LEDGERS VALUES('" + dtp_DATE.Value.ToString() + "', '" + cmbAccounts.SelectedValue.ToString() + @"',
                                  '" + cpv_id + "', 'CASH_PAYMENT','" + lblCode.Text + @"',
                                  '" + txtAmountPay.Text.ToString() + "','0','" + cls_fhp.AvoidInjection(txtDescription.Text) + "','" + Classes.Helper.userId + @"',
                                  GETDATE(),NULL,NULL,1,NULL, '" + cmbBank.SelectedValue.ToString() + @"');                

                                  INSERT INTO LEDGERS VALUES('" + dtp_DATE.Value.ToString() + @"', '" + Classes.Helper.cashId + @"',
                                  '" + cpv_id + "', 'CASH_PAYMENT','" + lblCode.Text + @"',
                                  '0','" + txtAmountPay.Text.ToString() + "','" + cls_fhp.AvoidInjection(txtDescription.Text) + "','" + Classes.Helper.userId + @"',
                                  GETDATE(),NULL,NULL,1,NULL, '" + cmbBank.SelectedValue.ToString() + @"');
                                        END
                                         ELSE 
                              BEGIN
                                  INSERT INTO CASHBANKRECMASTER VALUES('" + lblCode.Text + "','" + lblTrNo.Text + @"',
                                  '" + dtp_DATE.Value.ToString() + "','" + cmbAccounts.SelectedValue.ToString() + @"',
                                  '" + cls_fhp.AvoidInjection(txtDescription.Text) + "','" + cls_fhp.AvoidInjection(txtAmountPay.Text) + @"',
                                  '" + Classes.Helper.userId + @"',GETDATE(),NULL,NULL,'00',1, '" + cmbBank.SelectedValue.ToString() + @"');

                                  INSERT INTO LEDGERS VALUES('" + dtp_DATE.Value.ToString() + "', '" + cmbAccounts.SelectedValue.ToString() + @"',
                                  (SELECT MAX(CPV_ID) FROM CASHBANKRECMASTER), 'CASH_PAYMENT','" + lblCode.Text + @"',
                                  '" + txtAmountPay.Text.ToString() + "','0','" + cls_fhp.AvoidInjection(txtDescription.Text) + "','" + Classes.Helper.userId + @"',
                                  GETDATE(),NULL,NULL,1,NULL, '" + cmbBank.SelectedValue.ToString() + @"');                

                                  INSERT INTO LEDGERS VALUES('" + dtp_DATE.Value.ToString() + @"', '" + Classes.Helper.cashId + @"',
                                  (SELECT MAX(CPV_ID) FROM CASHBANKRECMASTER), 'CASH_PAYMENT','" + lblCode.Text + @"',
                                  '0','" + txtAmountPay.Text.ToString() + "','" + cls_fhp.AvoidInjection(txtDescription.Text) + "','" + Classes.Helper.userId + @"',
                                  GETDATE(),NULL,NULL,1,NULL, '" + cmbBank.SelectedValue.ToString() + @"');
                              END";


                cls_fhp.query += @" COMMIT TRANSACTION 
                      END TRY 
                  BEGIN CATCH 
                          IF @@TRANCOUNT > 0 
                          ROLLBACK TRANSACTION 
                  END CATCH";

                if (cls_fhp.InsertUpdateDelete(cls_fhp.query) > 0)
                {
                    MessageBox.Show("Record Saved Sucessfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    show_report();
                    clear();

                }

            }
        }



        private void Savecredit()

        {


            if (cmbAccounts.SelectedIndex == 0)
            {
                cls_fhp.ShowMessageBox("Account is not selected", "error");
                //essageBox.Show("Payment account is not selected, please select payment account.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbAccounts.Focus();
            }

            if (cmbBank.SelectedIndex == 0)
            {
                cls_fhp.ShowMessageBox("BankAccount is not selected", "error");
                //essageBox.Show("Payment account is not selected, please select payment account.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbBank.Focus();
            }

            else if (txtDescription.Text.Trim().Equals(""))
            {
                cls_fhp.ShowMessageBox("Description field is left blank", "error");
                //essageBox.Show("Narration field is blank.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescription.Focus();
            }


            else if (float.Parse(txtAmountPay.Text) <= 0)
            {
                cls_fhp.ShowMessageBox("Amount field is left blank", "error");
                //essageBox.Show("Amount field is blank.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAmountPay.Focus();
            }



            else
            {

                if (int.Parse(cls_fhp.check_balance_avilable("" + Classes.Helper.cashId + @"", txtAmountPay.Text)) == 0)
                {
                    cls_fhp.ShowMessageBox("Insufficient Cash in account", "error");
                    //essageBox.Show("Insufficient Cash in account.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAmountPay.Focus();
                    txtAmountPay.SelectAll();
                    return;
                }
                //if (cpv_id.Equals("")) {
                //    cpv_id = "(SELECT MAX(CPV_ID) FROM CASH_PAY_VOUCHER)";
                //}       
                cls_fhp.query = @"BEGIN TRY 
                  BEGIN TRANSACTION ";

                cls_fhp.query += @"IF EXISTS (select CPV_ID from CASHBANKRECMASTER WHERE CPV_ID = '" + cpv_id + @"') 
                              BEGIN
                                  UPDATE CASHBANKRECMASTER SET DAATE = '" + dtp_DATE.Value.ToString() + @"',
                                  COA_ID = '" + cmbAccounts.SelectedValue.ToString() + "',DESCRIPTION= '" + cls_fhp.AvoidInjection(txtDescription.Text) + @"',
BANK_ID='" + cmbBank.SelectedValue.ToString() + @"',
                                                                
AMOUNT = '" + cls_fhp.AvoidInjection(txtAmountPay.Text) + @"',
                                  MODIFICATION_DATE = GETDATE(), MODIFIED_BY = '" + Classes.Helper.userId + @"', 
                                  TYPE = 1 

                                  WHERE CPV_ID = '" + cpv_id + @"';

                                  DELETE FROM LEDGERS WHERE REF_ID = '" + cpv_id + @"' AND ENTRY_OF = 'CASH_RECEIPT';
                                  INSERT INTO LEDGERS VALUES('" + dtp_DATE.Value.ToString() + "', '" + cmbAccounts.SelectedValue.ToString() + @"',
                                  '" + cpv_id + "', 'CASH_RECEIPT','" + lblCode.Text + @"',
                                  '" + txtAmountPay.Text.ToString() + "','0','" + cls_fhp.AvoidInjection(txtDescription.Text) + "','" + Classes.Helper.userId + @"',
                                  GETDATE(),NULL,NULL,1,NULL, '" + cmbBank.SelectedValue.ToString() + @"');                

                                  INSERT INTO LEDGERS VALUES('" + dtp_DATE.Value.ToString() + @"', '" + Classes.Helper.cashId + @"',
                                  '" + cpv_id + "', 'CASH_RECEIPT','" + lblCode.Text + @"',
                                  '0','" + txtAmountPay.Text.ToString() + "','" + cls_fhp.AvoidInjection(txtDescription.Text) + "','" + Classes.Helper.userId + @"',
                                  GETDATE(),NULL,NULL,1,NULL, '" + cmbBank.SelectedValue.ToString() + @"');
                              END
                              ELSE 
                              BEGIN
                                  INSERT INTO CASHBANKRECMASTER VALUES('" + lblCode.Text + "','" + lblTrNo.Text + @"',
                                  '" + dtp_DATE.Value.ToString() + "','" + cmbAccounts.SelectedValue.ToString() + @"',
                                  '" + cls_fhp.AvoidInjection(txtDescription.Text) + "','" + cls_fhp.AvoidInjection(txtAmountPay.Text) + @"',
                                  '" + Classes.Helper.userId + @"',GETDATE(),NULL,NULL,'00',1, '" + cmbBank.SelectedValue.ToString() + @"');

                                  INSERT INTO LEDGERS VALUES('" + dtp_DATE.Value.ToString() + "', '" + cmbAccounts.SelectedValue.ToString() + @"',
                                  (SELECT MAX(CPV_ID) FROM CASHBANKRECMASTER), 'CASH_RECEIPT','" + lblCode.Text + @"',
                                  '" + txtAmountPay.Text.ToString() + "','0','" + cls_fhp.AvoidInjection(txtDescription.Text) + "','" + Classes.Helper.userId + @"',
                                  GETDATE(),NULL,NULL,1,NULL, '" + cmbBank.SelectedValue.ToString() + @"');                

                                  INSERT INTO LEDGERS VALUES('" + dtp_DATE.Value.ToString() + @"', '" + Classes.Helper.cashId + @"',
                                  (SELECT MAX(CPV_ID) FROM CASHBANKRECMASTER), 'CASH_RECEIPT','" + lblCode.Text + @"',
                                  '0','" + txtAmountPay.Text.ToString() + "','" + cls_fhp.AvoidInjection(txtDescription.Text) + "','" + Classes.Helper.userId + @"',
                                  GETDATE(),NULL,NULL,1,NULL, '" + cmbBank.SelectedValue.ToString() + @"');
                              END";


                cls_fhp.query += @" COMMIT TRANSACTION 
                      END TRY 
                  BEGIN CATCH 
                          IF @@TRANCOUNT > 0 
                          ROLLBACK TRANSACTION 
                  END CATCH";

                if (cls_fhp.InsertUpdateDelete(cls_fhp.query) > 0)
                {
                    MessageBox.Show("Record Saved Sucessfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    show_report();
                    clear();
                }

            }
        }



        private void show_report()
        {
            //cls_fhp.mds.Tables["CashRcpt"].Clear();
            //cls_CPV.get_head_cash_code(cmbPay.SelectedValue.ToString());
            //cls_fhp.dataR = cls_fhp.mds.Tables["CashRcpt"].NewRow();
            //cls_fhp.dataR[0] = lblCPV.Text;
            //cls_fhp.dataR[1] = lblTrNo.Text;
            //cls_fhp.dataR[2] = dtp_DATE.Value.ToShortDateString();
            //cls_fhp.dataR[3] = txtPay.Text;
            //cls_fhp.dataR[4] = txtNar.Text;
            //cls_fhp.dataR[5] = cmbPay.Text;
            //cls_fhp.dataR[6] = cls_CPV.credit_code;
            //cls_fhp.dataR[7] = "PETTY CASH";
            //cls_fhp.dataR[8] = cls_CPV.debit_code;
            //cls_fhp.dataR[9] = Convert.ToDouble(txtAmount.Text);
            //cls_fhp.dataR[10] = "User";
            //cls_fhp.mds.Tables["CashRcpt"].Rows.Add(cls_fhp.dataR);
            //cls_fhp.rpt = new Report_Form.frmReports();
            //cls_fhp.rpt.GenerateReport("CashVoucherP", cls_fhp.mds);
            //cls_fhp.rpt.ShowDialog();
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {

        }

        private void LoadForm() {
            try
            {
                cls_CPV.load_CPMM_grid(grdSEARCH, dtp_DATE.Value.Date, double.Parse(txtBalance.Text));
                cls_CPV.load_accounts(cmbAccounts);
                cls_CPV.load_bankaccounts(cmbBank);

                cls_CPV.generate_transaction_no(lblTrNo);
                cls_CRV.generate_voucher_no(lblCode);
                txtBalance.Text = cls_fhp.check_balance_avilable("" + Classes.Helper.cashId + @"", txtAmountPay.Text);

                //    dayBook.loadRecoveryPerson(cmbRecAcc);

                grdPaySummary.DataSource = null;
                grdRecSummary.DataSource = null;
                cls_CPV.load_Bankcash_grid(grdPaySummary, dtp_DATE.Value);
                cls_CPV.load_Bankrec_grid(grdRecSummary, dtp_DATE.Value);
                if (grdRecSummary.DataSource != null)
                    grdRecSummary.Columns[0].Width = 190;


                if (grdPaySummary.DataSource != null)
                    grdPaySummary.Columns[0].Width = 190;

                rdbCashReceipt.Checked = true;
                cls_CPV.getOpeningBal(txtOpenBalance, dtp_DATE.Value);
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
                cls_CPV.cvr_grid_search(txtSEARCH, grdSEARCH);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        }

        private void grdSEARCH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                is_edit = 1;
                load_data_fromGrid(e);
                rowIndex = e.RowIndex;
                DataGridViewRow dr = grdSEARCH.Rows[rowIndex];
                string code = grdSEARCH.Rows[rowIndex].Cells[1].Value.ToString();
                lblCode.Text = dr.Cells["VOUCHER #"].Value.ToString();
                //isEdit = true;
                cmbAccounts.Text = dr.Cells["ACCOUNT"].Value.ToString();
                cmbBank.Text = dr.Cells["BANK"].Value.ToString();
                txtDescription.Text = dr.Cells["DESCRIPTION"].Value.ToString();
                txtAmountPay.Text = dr.Cells["AMOUNT"].Value.ToString();

                // Check TYPE column to select appropriate radio button
                if (dr.Cells["TYPE"].Value.ToString() == "0")
                {
                    rdbCashPayment.Checked = true;
                }
                else if (dr.Cells["TYPE"].Value.ToString() == "1")
                {
                    rdbCashReceipt.Checked = true;
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        }

        private void btnCLEAR_Click(object sender, EventArgs e)
        {
            try
            {
                clear();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        }

        private void btnSAVE_Click_1(object sender, EventArgs e)
        {
            
            if (rdbCashPayment.Checked)
            {
                SaveCash();
            }
            else if (rdbCashReceipt.Checked)
            {
                Savecredit();

            }
            else
            {
                MessageBox.Show("Please select either Cash Receipt or Cash Payment.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void grdSEARCH_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            grdSEARCH.Columns[0].Visible = false;
            //grdSEARCH.Columns[1].Visible = false;
            grdSEARCH.Columns[1].DisplayIndex = 2;

            grdSEARCH.Columns[4].Visible = false;
            grdSEARCH.Columns["DESCRIPTION"].Visible = false;
            //            grdSEARCH.Columns["B"].Visible = false;


            double totalPaid = 0, totalRcvd = 0, totalBalance;
            string val1 = "", val2 = "";
            bool yes1 = false, yes2 = false;
            double res = 0;
            for (int i = 0; i < grdSEARCH.Rows.Count; i++)
            {
                val1 = grdSEARCH.Rows[i].Cells["AMOUNT"].Value.ToString();
                //val2 = grdSEARCH.Rows[i].Cells["RECEIVED AMOUNT"].Value.ToString();


                //YES1 and 2 are for checking if the value is parseable
                yes1 = double.TryParse(val1, out res);
                yes2 = double.TryParse(val2, out res);

                //TOTALS BELOW GRID CALCULATION
                if (yes1)
                    totalPaid += double.Parse(val1);
                if (yes2)
                    totalRcvd += double.Parse(val2);

                //TOTAL BALANCE CALCULATION FOR EACH ROW
                //totalBalance = double.Parse(grdSEARCH.Rows[0].Cells["BALANCE AMOUNT"].Value.ToString());
                //if (i > 0)
                //{
                //    if (yes1)
                //        totalBalance = totalBalance - double.Parse(val1);
                //    else if (yes2)
                //        totalBalance = totalBalance - double.Parse(val2);

                //}
            }


            txtTotalPaid.Text = totalPaid.ToString();
            txtTotalRcvd.Text = totalRcvd.ToString();
            //if (grdSEARCH.Rows.Count > 0)
            //    txtTotalBalanceAmount.Text = grdSEARCH.Rows[grdSEARCH.Rows.Count - 1].Cells["BALANCE AMOUNT"].Value.ToString();
            //grdSEARCH.Columns["BALANCE AMOUNT"].DisplayIndex = 7;
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            cls_fhp.AllowNumbers(e);
        }

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            cls_CPV.check_blank_zero(sender as TextBox);
            cls_fhp.textField_leave(sender as TextBox);
        }

        private void btn_VIEW_VOUCHER_Click(object sender, EventArgs e)
        {
            try
            {
                if (cls_fhp.CheckNameExists(grdSEARCH, lblCode.Text, 1) == 1)
                { show_report(); }
                else
                {
                    cls_fhp.ShowMessageBox("Voucher not found in record or save it first", "error");
                    //essageBox.Show("Voucher not found in record or save it first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        }

        private void txtAmount_Enter(object sender, EventArgs e)
        {
            cls_fhp.select_all_text(sender as TextBox);
        }

        private void txtAmount_MouseClick(object sender, MouseEventArgs e)
        {
            cls_fhp.select_all_text(sender as TextBox);
        }

        private void txtPay_Leave(object sender, EventArgs e)
        {
            cls_fhp.textField_leave(sender as TextBox);
        }

        private void cmbPay_TextUpdate(object sender, EventArgs e)
        {
            cls_fhp.CmbTextUpdate(sender as ComboBox);
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

        //private void rdbINV_REC_CheckedChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (rdbINV_REC.Checked == true && rdbOTHERS.Checked == false)
        //        {
        //            cmbSELECT_INV.Enabled = true;
        //            if (is_edit == 0) { cls_CPV.load_invoices(cmbSELECT_INV, cmbPay.SelectedValue.ToString()); }
        //        }
        //    }
        //    catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        //}

        //private void rdbOTHERS_CheckedChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (rdbINV_REC.Checked == false && rdbOTHERS.Checked == true)
        //        {
        //            cmbSELECT_INV.Enabled = false;
        //        }
        //    }
        //    catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        //}

        private void cmbCASH_AC_DropDown(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown += new PreviewKeyDownEventHandler(cmbCASH_AC_PreviewKeyDown);
        }

        private void cmbCASH_AC_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown -= cmbCASH_AC_PreviewKeyDown;
            if (cbo.DroppedDown) cbo.Focus();
        }

        private void cmbCASH_AC_TextUpdate(object sender, EventArgs e)
        {
            cls_fhp.CmbTextUpdate(sender as ComboBox);
        }

        private void cmbSELECT_INV_DropDown(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown += new PreviewKeyDownEventHandler(cmbSELECT_INV_PreviewKeyDown);
        }

        private void cmbSELECT_INV_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown -= cmbSELECT_INV_PreviewKeyDown;
            if (cbo.DroppedDown) cbo.Focus();
        }

        private void cmbSELECT_INV_TextUpdate(object sender, EventArgs e)
        {
            cls_fhp.CmbTextUpdate(sender as ComboBox);
        }

        //private void rdbCASH_CheckedChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (rdbCASH.Checked == true && rdbPETTY_CASH.Checked == false)
        //        {
        //            cls_CPV.cvr_grid_search_cash_pettyCash("CASH", grdSEARCH);
        //        }
        //    }
        //    catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        //}

        //private void rdbPETTY_CASH_CheckedChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (rdbCASH.Checked == false && rdbPETTY_CASH.Checked == true)
        //        {
        //            cls_CPV.cvr_grid_search_cash_pettyCash("PETTY CASH", grdSEARCH);
        //        }
        //    }
        //    catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        //}

        private void frm_CashPmt_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void rdbCashPayment_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdb = ((RadioButton)sender);

            if (rdb.Text == "CASH PAYMENT")
            {
                if (is_edit == 0) {
                    cls_CPV.generate_voucher_no(lblCode);
                }
                txtAmountPay.Enabled = true;
                // txtRefAccPay.Enabled = true;
                //  txtPaidTo.Enabled = true;

                //txtAmount.Enabled = false;
                //txtRefAccRec.Enabled = false;
                // cmbRecAcc.Enabled = false;

            }
            else if (rdb.Text == "CASH RECEIPT")
            {
                if (is_edit == 0)
                {
                    cls_CRV.generate_voucher_no(lblCode);
                }
                txtAmountPay.Enabled = true;
                //  txtRefAccPay.Enabled = false;
                // txtPaidTo.Enabled = false;

                // txtAmount.Enabled = false;
                //  txtRefAccRec.Enabled = true;
                //  cmbRecAcc.Enabled = true;
            }
        }

        private void cmbPayAcc_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void amountTxtChanged(object sender, EventArgs e)
        {
            TextBox txt = ((TextBox)sender);

            txtAmountWords.Text = cls_fhp.ConvertWholeNumber(txt.Text);
        }

        /*    private void btnDelete_Click(object sender, EventArgs e)
            {
                string id = "";
                string code = "";
                string query = "";
                int x = 0;
                if (rowIndex>=0)
                {
                    id = grdSEARCH.Rows[rowIndex].Cells[0].Value.ToString();
                    code = grdSEARCH.Rows[rowIndex].Cells[1].Value.ToString();
                    if(code.Contains("CPV"))
                    {
                        query = "DELETE FROM CASHPAYRECMASTER WHERE CPV_ID = '" + id + "';" +
                            "DELETE FROM LEDGERS WHERE REF_ID = '"+id+"' AND ENTRY_OF = 'CASH PAYMENT'";
                        DialogResult dg = MessageBox.Show("Are you sure you want to delete this entry?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if(dg == DialogResult.Yes)
                            x = cls_fhp.InsertUpdateDelete(query);
                        if (x > 0)
                            MessageBox.Show("Entry deleted successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if(code.Contains("CRV"))
                    {
                        query = "DELETE FROM CASH_CASHPAYRECMASTER WHERE CRV_ID = '" + id + "';"+
                            "DELETE FROM LEDGERS WHERE REF_ID = '"+id+"' AND ENTRY_OF = 'CASH RECEIPT'";

                        DialogResult dg = MessageBox.Show("Are you sure you want to delete this entry?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dg == DialogResult.Yes)
                           x =  cls_fhp.InsertUpdateDelete(query);
                        if (x > 0)
                            MessageBox.Show("Entry deleted successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    cls_CPV.load_CPM_grid(grdSEARCH,dtp_DATE.Value.Date, double.Parse(txtBalance.Text));
                }
            }
            */
        private void RefreshGrid()
        {
            // Yeh tumhare data ko reload karne ka method hai
            // Tumhe yahan apne data ko retrieve karne ka logic likhna padega
            // Example:
            // grdSEARCH.DataSource = GetDataFromDatabase(); // yahan apne data retrieval logic ko call karo
        }

        private void btnDelete_Click(object sender, EventArgs e)
        
            {
                string id = "";
                string code = "";
                string query = "";
                int x = 0;
                if (rowIndex >= 0)
                {
                    id = grdSEARCH.Rows[rowIndex].Cells[0].Value.ToString();
                    code = grdSEARCH.Rows[rowIndex].Cells[1].Value.ToString();
                    if (code.Contains("CPV"))
                    {
                        query = "DELETE FROM CASHBANKRECMASTER WHERE CPV_ID = '" + id + "';" +
                            "DELETE FROM LEDGERS WHERE REF_ID = '" + id + "' AND ENTRY_OF = 'CASH_PAYMENT'";

                        DialogResult dg = MessageBox.Show("Are you sure you want to delete this entry?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dg == DialogResult.Yes)
                            x = cls_fhp.InsertUpdateDelete(query);
                        if (x > 0)
                            MessageBox.Show("Entry deleted successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (code.Contains("CRV"))
                    {
                        query = "DELETE FROM CASHBANKRECMASTER WHERE CPV_ID = '" + id + "';" +
                            "DELETE FROM LEDGERS WHERE REF_ID = '" + id + "' AND ENTRY_OF = 'CASH_RECEIPT'";

                        DialogResult dg = MessageBox.Show("Are you sure you want to delete this entry?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dg == DialogResult.Yes)
                            x = cls_fhp.InsertUpdateDelete(query);
                        if (x > 0)
                            MessageBox.Show("Entry deleted successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    cls_CPV.load_CPMM_grid(grdSEARCH, dtp_DATE.Value.Date, double.Parse(txtBalance.Text));
                }
            }



            private void cmbAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    

        private void dtp_DATE_ValueChanged(object sender, EventArgs e)
        {
            //if (!checkChangeDate.Checked)
            {
                

                    grdPaySummary.DataSource = null;
                    grdRecSummary.DataSource = null;
                    txtTotalPayGrid.Text = "0";
                    txtTotalRecGrid.Text = "0";
                    cls_CPV.getOpeningBal(txtOpenBalance, dtp_DATE.Value);
                    cls_CPV.load_Bankrec_grid(grdRecSummary, dtp_DATE.Value);
                    cls_CPV.load_Bankcash_grid(grdPaySummary, dtp_DATE.Value);
                    if (grdRecSummary.DataSource != null)
                        grdRecSummary.Columns[0].Width = 190;
                    if (grdPaySummary.DataSource != null)
                        grdPaySummary.Columns[0].Width = 190;
                    cls_CPV.load_CPM_grid(grdSEARCH, dtp_DATE.Value.Date, double.Parse(txtBalance.Text));
                }

            }

            private void grdRecSummary_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            double total = 0;
            for (int i = 0; i < grdRecSummary.Rows.Count; i++)
            {
                total += double.Parse(grdRecSummary.Rows[i].Cells["TOTAL"].Value.ToString());
            }
            txtTotalRecGrid.Text = total.ToString();
        }

        private void grdPaySummary_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            double total = 0;
            for (int i = 0; i < grdPaySummary.Rows.Count; i++)
            {
                total += double.Parse(grdPaySummary.Rows[i].Cells["TOTAL"].Value.ToString());
            }
            txtTotalPayGrid.Text = total.ToString();
        }

        private void CashRecVoucher() {
            try
            {
                if (!crv_id.Equals(""))
                {
                    voucher.BankCashReceiptVoucherReport(Convert.ToInt32(crv_id));
                }
                else
                {
                    MessageBox.Show("No Record Find", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CashPayVoucher()
        {
            try
            {
                if (!cpv_id.Equals(""))
                {
                    voucher.BankCashPaymentVoucherReport(Convert.ToInt32(cpv_id));
                }
                else
                {
                    MessageBox.Show("No Record Find", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnReceiptVoucher_Click(object sender, EventArgs e)
        {
            if (rdbCashPayment.Checked)
                CashPayVoucher(); 
            else if (rdbCashReceipt.Checked)
                CashRecVoucher();
        }

        private void TXTDESC_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbRecAcc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void grdSEARCH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void grdPaySummary_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = e.RowIndex;
            DataGridViewRow dr = grdPaySummary.Rows[rowIndex];
            txtSEARCH.Clear();
            txtSEARCH.Text = dr.Cells["PAYMENT ACCOUNT"].Value.ToString();

        }

        private void grdPaySummary_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //   rowIndex = e.RowIndex;
            // DataGridViewRow dr = grdPaySummary.Rows[rowIndex];
            // txtSEARCH.Clear();
            //            txtSEARCH.Text = dr.Cells["PAYMENT ACCOUNT"].Value.ToString();
            rowIndex = e.RowIndex;
            DataGridViewRow dr = grdPaySummary.Rows[rowIndex];
            txtSEARCH.Clear();
            txtSEARCH.Text = dr.Cells["PAYMENT ACCOUNT"].Value.ToString();

        }

        private void grdRecSummary_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            rowIndex = e.RowIndex;
            DataGridViewRow dr = grdRecSummary.Rows[rowIndex];
            txtSEARCH.Clear();
            txtSEARCH.Text = dr.Cells["SALES PERSON"].Value.ToString();

        }

        private void grdRecSummary_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}