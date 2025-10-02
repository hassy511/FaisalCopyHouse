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
    public partial class frm_BankRcpt : Form
    {
        Classes.Helper cls_fhp = new Classes.Helper();
        Classes.cls_Bank_Receipt cls_BRV = new Classes.cls_Bank_Receipt();
        string brv_id = "";
        int is_edit = 0;
        public frm_BankRcpt()
        {
            InitializeComponent();
        }

        private void clear()
        {
            cls_BRV.generate_transaction_no(lblTrNo);
            cls_BRV.generate_voucher_no(lblBRV);
            dtp_DATE.Value = DateTime.Now;
            txtAmount.Clear();
            txtNar.Clear();
            txtReceive.Clear();
            txtSEARCH.Clear();
            cmbRc.SelectedIndex = 0;
            dtp_DATE.Focus();
            brv_id = "";
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
                    brv_id = row.Cells[0].Value.ToString();
                    is_edit = 1;
                    lblBRV.Text = row.Cells[1].Value.ToString();
                    lblTrNo.Text = row.Cells[2].Value.ToString();
                    dtp_DATE.Value = DateTime.Parse(row.Cells[3].Value.ToString());
                    dtp_DATE.Focus();
                    cmbBank.SelectedValue = row.Cells[4].Value.ToString();
                    cmbRc.SelectedValue = row.Cells[6].Value.ToString();
                    txtChq.Text = row.Cells[8].Value.ToString();
                    dtChq.Value = DateTime.Parse(row.Cells[9].Value.ToString());
                    txtNar.Text = row.Cells[10].Value.ToString();
                    txtReceive.Text = row.Cells[11].Value.ToString();
                    txtAmount.Text = row.Cells[12].Value.ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        }
        string query = "";
        private void save()
        {

            if (cmbRc.SelectedIndex == 0)
            {
                cls_fhp.ShowMessageBox("Receipt account is not selected", "error");
                //essageBox.Show("Receipt account is not selected, please select receipt account.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbRc.Focus();
            }
            else if (cmbBank.SelectedIndex == 0)
            {
                cls_fhp.ShowMessageBox("Bank account is not selected", "error");
                //essageBox.Show("Bank account is not selected, please select bank account.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbBank.Focus();
            }
            //else if (rdbINV_REC.Checked == true && cmbSELECT_INV.SelectedIndex == 0)
            //{
            //    cls_fhp.ShowMessageBox("Invoice is not selected", "error");
            //    //essageBox.Show("Invoice is not selected, please select invoice.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    cmbSELECT_INV.Focus();
            //}
            else if (txtNar.Text.Trim().Equals(""))
            {
                cls_fhp.ShowMessageBox("Narration field is left blank", "error");
                //essageBox.Show("Narration field is blank.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNar.Focus();
            }
            else if (txtReceive.Text.Trim().Equals(""))
            {
                cls_fhp.ShowMessageBox("Received field is left blank", "error");
                //essageBox.Show("Received from field is blank.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtReceive.Focus();
            }
            else if (float.Parse(txtAmount.Text) < 0)
            {
                cls_fhp.ShowMessageBox("Amount field is left blank", "error");
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
                //if (rdbINV_REC.Checked == true && cmbSELECT_INV.Enabled == true)
                //{
                //    string msg = cls_fhp.getSale_Invoice_Bal(cmbSELECT_INV.SelectedValue.ToString(), float.Parse(txtAmount.Text));
                //    if (!msg.Equals("OK"))
                //    {
                //        MessageBox.Show(msg);
                //        return;
                //    }
                //}

                query = "IF EXISTS (select BRV_ID from BANK_REC_VOUCHER WHERE BRV_ID = '" + brv_id + "') UPDATE BANK_REC_VOUCHER SET DAATE = '" + dtp_DATE.Value.ToString() + "',COA_ID = '" + cmbRc.SelectedValue.ToString() + "',ACCOUNT_OF = '" + cls_fhp.AvoidInjection(txtNar.Text) + "',AMOUNT = '" + cls_fhp.AvoidInjection(txtAmount.Text) + "',REC_FROM = '" + cls_fhp.AvoidInjection(txtReceive.Text) + "',BANK_ID = '" + cmbBank.SelectedValue.ToString() + "',CHQ_NO = '" + txtChq.Text + "',CHQ_DAATE = '" + dtChq.Value.ToString() + "',  MODIFICATION_DATE = GETDATE(), MODIFIED_BY = '" + Classes.Helper.userId + "' WHERE BRV_ID = '" + brv_id + "' ELSE INSERT INTO BANK_REC_VOUCHER VALUES('" + lblBRV.Text + "','" + lblTrNo.Text + "','" + dtp_DATE.Value.ToString() + "','" + cmbBank.SelectedValue.ToString() + "','" + cmbRc.SelectedValue.ToString() + "','" + cls_fhp.AvoidInjection(txtNar.Text) + "','" + cls_fhp.AvoidInjection(txtChq.Text) + "','" + dtChq.Value.ToString() + "','" + cls_fhp.AvoidInjection(txtAmount.Text) + "','" + cls_fhp.AvoidInjection(txtReceive.Text) + "','" + Classes.Helper.userId + "',GETDATE(),NULL,NULL,'00')";
                int i = 0;
                if (cls_BRV.save_crv_details(query) >= 1)
                {
                    i = cls_BRV.insert_ledger_entry(dtp_DATE.Value.ToString(), Int32.Parse(cmbBank.SelectedValue.ToString()), Int32.Parse(cmbRc.SelectedValue.ToString()), brv_id, "BANK RECEIPT", float.Parse(txtAmount.Text.ToString()), cls_fhp.AvoidInjection(txtNar.Text) + "/ CHQ NO: " + cls_fhp.AvoidInjection(txtChq.Text),lblBRV.Text);
                    if (i > 0)
                    {
                        if (rdbINV_REC.Checked == true && cmbSELECT_INV.Enabled == true) { save_invoice_record(); }
                        //if (brv_id.Equals(""))
                        //{
                        //    query = "INSERT INTO TRANSACTION_LOG VALUES('BANK RECEIPT VOUCHER','ADD NEW BANK RECEIPT VOUCHER',(SELECT MAX(BRV_ID) FROM BANK_REC_VOUCHER),GETDATE()," + Classes.Helper.userId + ") ";
                        //    cls_fhp.InsertUpdateDelete(query);
                        //}
                        //else
                        //{
                        //    query = "INSERT INTO TRANSACTION_LOG VALUES('BANK RECEIPT VOUCHER','UPDATE BANK RECEIPT VOUCHER'," + brv_id + ",GETDATE()," + Classes.Helper.userId + ") ";
                        //    cls_fhp.InsertUpdateDelete(query);
                        //}
                        cls_fhp.ShowMessageBox("Record Saved Sucessfully!", "success");
                        //essageBox.Show("Record Saved Sucessfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        show_report();
                        clear();
                        cls_BRV.load_bvr_grid(grdSEARCH);
                    }
                }

            }
        }
        private int save_invoice_record()
        {
            int i = 0;
            query = @"IF EXISTS (select VOUCHER_ID from INVOICES_DETAILS WHERE VOUCHER_OF = 'BANK REC' AND VOUCHER_ID = '" + brv_id + @"') 
                    UPDATE INVOICES_DETAILS SET DAATE = '" + dtp_DATE.Value.ToString() + "',COA_ID = '" + cmbRc.SelectedValue.ToString() + @"',
                    AMOUNT = '" + cls_fhp.AvoidInjection(txtAmount.Text) + "' WHERE VOUCHER_ID = '" + brv_id + @"' 
                    ELSE 
                    INSERT INTO INVOICES_DETAILS VALUES('" + dtp_DATE.Value.ToString() + "','SALES','" + cmbRc.SelectedValue.ToString() + "','" + cmbSELECT_INV.SelectedValue.ToString() + "',(SELECT MAX(BRV_ID) FROM BANK_REC_VOUCHER),'BANK REC','" + cls_fhp.AvoidInjection(txtAmount.Text) + @"');
                    UPDATE SALES_M SET REC_AMT = (SELECT SUM(AMOUNT) FROM INVOICES_DETAILS WHERE PAY_OF = 'SALES' AND INVOICE_NO = '" + cmbSELECT_INV.SelectedValue.ToString() + "') WHERE SM_ID = '" + cmbSELECT_INV.SelectedValue.ToString() + "'";
            i = cls_fhp.InsertUpdateDelete(query);
            return i;
        }
        private void show_report()
        {
            //cls_BRV.get_head_bank_code(cmbRc.SelectedValue.ToString(), cmbBank.SelectedValue.ToString());
            //cls_fhp.dataR = cls_fhp.mds.Tables["BankVoucher"].NewRow();
            //cls_fhp.dataR[0] = lblBRV.Text;
            //cls_fhp.dataR[1] = lblTrNo.Text;
            //cls_fhp.dataR[2] = dtp_DATE.Value.ToShortDateString();
            //cls_fhp.dataR[3] = txtReceive.Text;
            //cls_fhp.dataR[4] = txtNar.Text;
            //cls_fhp.dataR[5] = cmbBank.Text;
            //cls_fhp.dataR[6] = cls_BRV.debit_code;
            //cls_fhp.dataR[7] = cmbRc.Text;
            //cls_fhp.dataR[8] = cls_BRV.credit_code;
            //cls_fhp.dataR[9] = Convert.ToDouble(txtAmount.Text);
            //cls_fhp.dataR[10] = "User";
            //cls_fhp.dataR[11] = txtChq.Text;
            //cls_fhp.dataR[12] = cmbBank.Text;
            //cls_fhp.dataR[13] = dtChq.Value.ToShortDateString();
            //cls_fhp.mds.Tables["BankVoucher"].Rows.Add(cls_fhp.dataR);
            //cls_fhp.rpt = new Report_Form.frmReports();
            //cls_fhp.rpt.GenerateReport("BankVoucherR", cls_fhp.mds);
            //cls_fhp.rpt.ShowDialog();
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {

        }

        private void frm_BankRcpt_Load(object sender, EventArgs e)
        {
            try
            {
                cls_BRV.load_bvr_grid(grdSEARCH);
                cls_BRV.load_accounts(cmbRc);
                cls_BRV.load_bank_accounts(cmbBank);
                cls_BRV.load_bank_accounts(cmbBankSearch);
                cls_BRV.generate_transaction_no(lblTrNo);
                cls_BRV.generate_voucher_no(lblBRV);

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        }

        private void txtSEARCH_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cls_BRV.cvr_grid_search(txtSEARCH, grdSEARCH);
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

        private void grdSEARCH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                load_data_fromGrid(e);
                //cls_fhp.load_all_invoices(cmbSELECT_INV, cmbRc.SelectedValue.ToString());
                //cls_fhp.invoice_detail(brv_id, cmbSELECT_INV, rdbINV_REC, rdbOTHERS);
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

        private void btnSAVE_Click_1(object sender, EventArgs e)
        {
            try
            {
                save();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        }

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            cls_BRV.check_blank_zero(sender as TextBox);
            cls_fhp.textField_leave(sender as TextBox);
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            cls_fhp.AllowNumbers(e);
        }

        private void btn_VIEW_VOUCHER_Click(object sender, EventArgs e)
        {
            try
            {
                if (cls_fhp.CheckNameExists(grdSEARCH, lblBRV.Text, 1) == 1)
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

        private void txtReceive_Leave(object sender, EventArgs e)
        {
            cls_fhp.textField_leave(sender as TextBox);
        }

        private void cmbRc_TextUpdate(object sender, EventArgs e)
        {
            cls_fhp.CmbTextUpdate(sender as ComboBox);
        }

        private void cmbRc_DropDown(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown += new PreviewKeyDownEventHandler(cmbRc_PreviewKeyDown);
        }

        private void cmbRc_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown -= cmbRc_PreviewKeyDown;
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

        private void rdbOTHERS_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbINV_REC.Checked == false && rdbOTHERS.Checked == true)
            {
                cmbSELECT_INV.Enabled = false;
            }
        }

        private void rdbINV_REC_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbINV_REC.Checked == true && rdbOTHERS.Checked == false)
                {
                    cmbSELECT_INV.Enabled = true;
                    if (is_edit == 0) { cls_fhp.load_invoices(cmbSELECT_INV, cmbRc.SelectedValue.ToString()); }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }

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
                    cls_BRV.bvr_grid_search_bankAccount("", grdSEARCH);
                }
                else
                {
                    cls_BRV.bvr_grid_search_bankAccount(cmbBankSearch.Text, grdSEARCH);
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        }

        private void cmbBankSearch_DropDown(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown += new PreviewKeyDownEventHandler(cmbBankSearch_PreviewKeyDown);
        }

        private void cmbBankSearch_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown -= cmbBankSearch_PreviewKeyDown;
            if (cbo.DroppedDown) cbo.Focus();
        }

        private void frm_BankRcpt_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            txtAmountWordsRec.Text = cls_fhp.ConvertWholeNumber(txtAmount.Text);
        }
    }
}
