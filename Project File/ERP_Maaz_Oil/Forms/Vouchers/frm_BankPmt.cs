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
    public partial class frm_BankPmt : Form
    {
        Classes.Helper cls_fhp = new Classes.Helper();
        Classes.cls_Bank_Payment cls_BPV = new Classes.cls_Bank_Payment();
        string bpv_id = "";
        int is_edit = 0;
        public frm_BankPmt()
        {
            InitializeComponent();
        }

        private void clear()
        {
            cls_BPV.generate_transaction_no(lblTrNo);
            cls_BPV.generate_voucher_no(lblBPV);
            dtp_DATE.Value = DateTime.Now;
            txtAmount.Clear();
            txtNar.Clear();
            txtPay.Clear();
            txtSEARCH.Clear();
            cmbPay.SelectedIndex = 0;
            dtp_DATE.Focus();
            bpv_id = "";
            dtChq.Value = DateTime.Now;
            cmbBank.SelectedIndex = 0;
            txtChq.Clear();
            rdbINV_REC.Checked = false;
            rdbOTHERS.Checked = false;
            if (cmbSELECT_INV.Enabled == true) { cmbSELECT_INV.SelectedIndex = 0; }
            cmbSELECT_INV.Enabled = false;
        }

        //get data from grid on click
        private void load_data_fromGrid(DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.grdSEARCH.Rows[e.RowIndex];
                    bpv_id = row.Cells[0].Value.ToString();
                    is_edit = 1;
                    lblBPV.Text = row.Cells["VOUCHER #"].Value.ToString();
                    lblTrNo.Text = row.Cells["TRANS_CODE"].Value.ToString();
                    dtp_DATE.Value = DateTime.Parse(row.Cells["DATE"].Value.ToString());
                    //dtp_DATE.Focus();
                    cmbBank.SelectedValue = row.Cells["BANK_ID"].Value.ToString();
                    cmbPay.SelectedValue = row.Cells["COA_ID"].Value.ToString();
                    txtChq.Text = row.Cells["CHEQUE #"].Value.ToString();
                    dtChq.Value = DateTime.Parse(row.Cells["CHEQUE DATE"].Value.ToString());
                    txtNar.Text = row.Cells["DESCRIPTION"].Value.ToString();
                    txtPay.Text = row.Cells["PAID TO"].Value.ToString();
                    txtAmount.Text = row.Cells["AMOUNT"].Value.ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        }

        string query = "";
        private void save()
        {

            if (cmbPay.SelectedIndex == 0)
            {
                cls_fhp.ShowMessageBox("Payment account is not selected", "error");
                //essageBox.Show("Payment account is not selected, please select payment account.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbPay.Focus();
            }
            else if (cmbBank.SelectedIndex == 0)
            {
                cls_fhp.ShowMessageBox("Bank account is not selected", "error");
                //essageBox.Show("Bank account is not selected, please select bank account.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbBank.Focus();
            }
           
            else if (txtNar.Text.Trim().Equals(""))
            {
                cls_fhp.ShowMessageBox("Narration field is left blank", "error");
                //essageBox.Show("Narration field is blank.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNar.Focus();
            }
            else if (txtPay.Text.Trim().Equals(""))
            {
                cls_fhp.ShowMessageBox("Paid field is left blank", "error");
                //essageBox.Show("Paid to field is blank.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPay.Focus();
            }
            else if (float.Parse(txtAmount.Text) < 0)
            {
                cls_fhp.ShowMessageBox("Amount field is left blank", "error");
                //essageBox.Show("Amount field is blank.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAmount.Focus();
            }
            else if (txtChq.Text.Trim().Equals(""))
            {
                cls_fhp.ShowMessageBox("Cheque # field is left blank", "error");
                //essageBox.Show("Cheque # field is blank.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtChq.Focus();
            }
            else
            {
               if (int.Parse(cls_fhp.check_balance_avilable(cmbBank.SelectedValue.ToString(), txtAmount.Text)) == 0)
                {
                    cls_fhp.ShowMessageBox("Insufficient balance in account", "error");
                    //essageBox.Show("Insufficient amount in account.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAmount.Focus();
                    txtAmount.SelectAll();
                    return;
                }

                query = "IF EXISTS (select BPV_ID from BANK_PAY_VOUCHER WHERE BPV_ID = '" + bpv_id + @"') 
                        UPDATE BANK_PAY_VOUCHER SET DAATE = '" + dtp_DATE.Value.ToString() + "',COA_ID = '" + cmbPay.SelectedValue.ToString() 
                        + "',ACCOUNT_OF = '" + cls_fhp.AvoidInjection(txtNar.Text) + "',AMOUNT = '" + cls_fhp.AvoidInjection(txtAmount.Text) + 
                        "',PAID_TO = '" + cls_fhp.AvoidInjection(txtPay.Text) + "',BANK_ID = '" + cmbBank.SelectedValue.ToString() + "',CHQ_NO = '" 
                        + txtChq.Text + "',CHQ_DAATE = '" + dtChq.Value.ToString() + "',  MODIFICATION_DATE = GETDATE(), MODIFIED_BY = '" + 
                        Classes.Helper.userId + "' WHERE BPV_ID = '" + bpv_id + @"' 

                        ELSE INSERT INTO BANK_PAY_VOUCHER VALUES('" + lblBPV.Text + 
                        "','" + lblTrNo.Text + "','" + dtp_DATE.Value.ToString() + "','" + cmbBank.SelectedValue.ToString() + "','" + cmbPay.SelectedValue.ToString() +
                        "','" + cls_fhp.AvoidInjection(txtNar.Text) + "','" + cls_fhp.AvoidInjection(txtChq.Text) + "','" + dtChq.Value.ToString() + "','" + cls_fhp.AvoidInjection(txtAmount.Text) + "','" + cls_fhp.AvoidInjection(txtPay.Text) + "','" + Classes.Helper.userId + "',GETDATE(),NULL,NULL,'00')";
                int i = 0;
                if (cls_BPV.save_bpv_details(query) >= 1)
                {
                    i = cls_BPV.insert_ledger_entry(dtp_DATE.Value.ToString(), Int32.Parse(cmbPay.SelectedValue.ToString()), Int32.Parse(cmbBank.SelectedValue.ToString()), bpv_id, "BANK PAYMENT", float.Parse(txtAmount.Text.ToString()), cls_fhp.AvoidInjection(txtNar.Text) + "/ CHQ NO: " + cls_fhp.AvoidInjection(txtChq.Text),lblBPV.Text);
                    if (i > 0)
                    {
                        if (rdbINV_REC.Checked == true && cmbSELECT_INV.Enabled == true) { save_invoice_record(); }
                        //if (bpv_id.Equals(""))
                        //{
                        //    query = "INSERT INTO TRANSACTION_LOG VALUES('BANK PAYMENT VOUCHER','ADD NEW BANK PAYMENT VOUCHER',(SELECT MAX(BPV_ID) FROM BANK_PAY_VOUCHER),GETDATE()," + Classes.Helper.userId + ") ";
                        //    cls_fhp.InsertUpdateDelete(query);
                        //}
                        //else
                        //{
                        //    query = "INSERT INTO TRANSACTION_LOG VALUES('BANK PAYMENT VOUCHER','UPDATE BANK PAYMENT VOUCHER'," + bpv_id + ",GETDATE()," + Classes.Helper.userId + ") ";
                        //    cls_fhp.InsertUpdateDelete(query);
                        //}
                        cls_fhp.ShowMessageBox("Record Saved Sucessfully!", "success");
                        //essageBox.Show("Record Saved Sucessfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        show_report();
                        clear();
                        cls_BPV.load_bvp_grid(grdSEARCH);
                    }
                }

            }
        }

        private int save_invoice_record()
        {
            int i = 0;
            query = @"IF EXISTS (select VOUCHER_ID from INVOICES_DETAILS WHERE VOUCHER_OF = 'BANK PAY' AND VOUCHER_ID = '" + bpv_id + @"') 
                    UPDATE INVOICES_DETAILS SET DAATE = '" + dtp_DATE.Value.ToString() + "',COA_ID = '" + cmbPay.SelectedValue.ToString() + @"',
                    AMOUNT = '" + cls_fhp.AvoidInjection(txtAmount.Text) + "' WHERE VOUCHER_ID = '" + bpv_id + @"' 
                    ELSE 
                    INSERT INTO INVOICES_DETAILS VALUES('" + dtp_DATE.Value.ToString() + "','PURCHASES','" + cmbPay.SelectedValue.ToString() + "','" + cmbSELECT_INV.SelectedValue.ToString() + "',(SELECT MAX(BPV_ID) FROM BANK_PAY_VOUCHER),'BANK PAY','" + cls_fhp.AvoidInjection(txtAmount.Text) + @"');
                    UPDATE PURCHASES SET REC_AMT = (SELECT SUM(AMOUNT) FROM INVOICES_DETAILS WHERE PAY_OF = 'PURCHASES' AND INVOICE_NO = '" + cmbSELECT_INV.SelectedValue.ToString() + "') WHERE P_ID = '" + cmbSELECT_INV.SelectedValue.ToString() + "'";
            i = cls_fhp.InsertUpdateDelete(query);
            return i;
        }

        private void show_report()
        {
            //cls_BPV.get_head_bank_code(cmbPay.SelectedValue.ToString(), cmbBank.SelectedValue.ToString());
            //cls_fhp.dataR = cls_fhp.mds.Tables["BankVoucher"].NewRow();
            //cls_fhp.dataR[0] = lblBPV.Text;
            //cls_fhp.dataR[1] = lblTrNo.Text;
            //cls_fhp.dataR[2] = dtp_DATE.Value.ToShortDateString();
            //cls_fhp.dataR[3] = txtPay.Text;
            //cls_fhp.dataR[4] = txtNar.Text;
            //cls_fhp.dataR[5] = cmbBank.Text;
            //cls_fhp.dataR[6] = cls_BPV.credit_code;
            //cls_fhp.dataR[7] = cmbPay.Text;
            //cls_fhp.dataR[8] = cls_BPV.debit_code;
            //cls_fhp.dataR[9] = Convert.ToDouble(txtAmount.Text);
            //cls_fhp.dataR[10] = "User";
            //cls_fhp.dataR[11] = txtChq.Text;
            //cls_fhp.dataR[12] = cmbBank.Text;
            //cls_fhp.dataR[13] = dtChq.Value.ToShortDateString();
            //cls_fhp.mds.Tables["BankVoucher"].Rows.Add(cls_fhp.dataR);
            //cls_fhp.rpt = new Report_Form.frmReports();
            //cls_fhp.rpt.GenerateReport("BankVoucherP", cls_fhp.mds);
            //cls_fhp.rpt.ShowDialog();
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {

        }

        private void frm_BankPmt_Load(object sender, EventArgs e)
        {
            try
            {
                cls_BPV.load_bvp_grid(grdSEARCH);
                cls_BPV.load_accounts(cmbPay);
                cls_BPV.load_bank_accounts(cmbBank);
                cls_BPV.load_bank_accounts(cmbBankSearch);
                cls_BPV.generate_transaction_no(lblTrNo);
                cls_BPV.generate_voucher_no(lblBPV);
                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        }

        private void txtSEARCH_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cls_BPV.cvr_grid_search(txtSEARCH, grdSEARCH);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        }

        private void grdSEARCH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                load_data_fromGrid(e);
                //cls_fhp.load_all_invoices(cmbSELECT_INV, cmbPay.SelectedValue.ToString());
               // cls_fhp.invoice_detail(bpv_id, cmbSELECT_INV, rdbINV_REC, rdbOTHERS);

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        }

        private void grdSEARCH_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            grdSEARCH.Columns[0].Visible = false;
            grdSEARCH.Columns[2].Visible = false;
            grdSEARCH.Columns[4].Visible = false;
            grdSEARCH.Columns[6].Visible = false;
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            cls_fhp.AllowNumbers(e);
        }

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            cls_BPV.check_blank_zero(sender as TextBox);
            cls_fhp.textField_leave(sender as TextBox);
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
            try
            {
                save();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        }

        private void btn_VIEW_VOUCHER_Click(object sender, EventArgs e)
        {
            try
            {
                if (cls_fhp.CheckNameExists(grdSEARCH, lblBPV.Text, 1) == 1)
                { show_report(); }
                else
                {
                    cls_fhp.ShowMessageBox("Record Not Found To Print", "error");
                    //essageBox.Show("Record Not Found To Print.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information); 
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

        private void cmbBank_DropDown(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown += new PreviewKeyDownEventHandler(cmbBank_PreviewKeyDown);
        }

        private void cmbBank_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown -= cmbBank_PreviewKeyDown;
            if (cbo.DroppedDown) cbo.Focus();
        }

        private void rdbINV_REC_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbINV_REC.Checked == true && rdbOTHERS.Checked == false)
                {
                    cmbSELECT_INV.Enabled = true;
                    if (is_edit == 0) { cls_fhp.load_invoices(cmbSELECT_INV, cmbPay.SelectedValue.ToString()); }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        }

        private void rdbOTHERS_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbINV_REC.Checked == false && rdbOTHERS.Checked == true)
            {
                cmbSELECT_INV.Enabled = false;
            }
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

        private void cmbBankSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbBankSearch.SelectedIndex == 0)
                {
                    cls_BPV.bvp_grid_search_bankAccount("", grdSEARCH);
                }
                else
                {
                    cls_BPV.bvp_grid_search_bankAccount(cmbBankSearch.Text, grdSEARCH);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        }

        private void frm_BankPmt_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            txtAmountWordsRec.Text = cls_fhp.ConvertWholeNumber(txtAmount.Text);
        }

        private void cmbBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBankBalance.Text = (cls_fhp.check_balance_avilable(cmbBank.SelectedValue.ToString(), txtAmount.Text));
        }
    }
}
