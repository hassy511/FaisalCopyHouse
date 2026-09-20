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
    public partial class frm_BankTr : Form
    {
        Classes.Helper cls_fhp = new Classes.Helper();
        Classes.cls_Bank_Transfer cls_BTV = new Classes.cls_Bank_Transfer();
        string btv_id = "";
        int is_edit = 0;
        public frm_BankTr()
        {
            InitializeComponent();
        }

        private void clear()
        {
            cls_BTV.generate_transaction_no(lblTrNo);
            cls_BTV.generate_voucher_no(lblTV);
            dtp_DATE.Value = DateTime.Now;
            txtAmount.Clear();
            txtNar.Clear();
            txtSEARCH.Clear();
            cmbTRFrom.SelectedIndex = 0;
            dtp_DATE.Focus();
            btv_id = "";
            dtChq.Value = DateTime.Now;
            cmbTrTo.SelectedIndex = 0;
            txtChq.Clear();
        }

        //get data from grid on click
        private void load_data_fromGrid(DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.grdSEARCH.Rows[e.RowIndex];
                    btv_id = row.Cells[0].Value.ToString();
                    is_edit = 1;
                    lblTV.Text = row.Cells[1].Value.ToString();
                    lblTrNo.Text = row.Cells[2].Value.ToString();
                    dtp_DATE.Value = DateTime.Parse(row.Cells[3].Value.ToString());
                    dtp_DATE.Focus();
                    cmbTRFrom.SelectedValue = row.Cells[4].Value.ToString();
                    cmbTrTo.SelectedValue = row.Cells[6].Value.ToString();
                    txtChq.Text = row.Cells[8].Value.ToString();
                    dtChq.Value = DateTime.Parse(row.Cells[9].Value.ToString());
                    txtNar.Text = row.Cells[10].Value.ToString();
                    txtAmount.Text = row.Cells[11].Value.ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        }

        private void save()
        {
            string query = "";
            if (int.Parse(cls_fhp.check_balance_avilable(cmbTRFrom.SelectedValue.ToString(), txtAmount.Text)) == 0)
            {
                cls_fhp.ShowMessageBox("Insufficient Balacne in Account", "error");
                //essageBox.Show("Insufficient Amount in Account.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAmount.Focus();
                txtAmount.SelectAll();
                return;
            }
            if (cmbTRFrom.SelectedIndex == 0)
            {
                cls_fhp.ShowMessageBox("Bank for transfer is not selected", "error");
                //essageBox.Show("Bank for transfer is not selected, please select bank for transfer.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbTRFrom.Focus();
            }
            else if (cmbTrTo.SelectedIndex == 0)
            {
                cls_fhp.ShowMessageBox("Bank for receive is not selected", "error");
                //essageBox.Show("Bank for receive is not selected, please select bank receive.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbTrTo.Focus();
            }
            else if (cmbTrTo.Text.Equals(cmbTRFrom.Text))
            {
                cls_fhp.ShowMessageBox("Transfer bank & receiver bank are same", "error");
                //essageBox.Show("Transfer bank & receiver bank are same, both should be different.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbTrTo.Focus();
            }
            else if (txtNar.Text.Trim().Equals(""))
            {
                cls_fhp.ShowMessageBox("Narration field is left blank", "error");
                //essageBox.Show("Narration field is blank.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNar.Focus();
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
                query = "IF EXISTS (select BTV_ID from BANK_TRANSFER_VOUCHER WHERE BTV_ID = '" + btv_id + "') UPDATE BANK_TRANSFER_VOUCHER SET DAATE = '" + dtp_DATE.Value.ToString() + "',FROM_BANK_ID = '" + cmbTRFrom.SelectedValue.ToString() + "',NARRATION = '" + cls_fhp.AvoidInjection(txtNar.Text) + "',AMOUNT = '" + cls_fhp.AvoidInjection(txtAmount.Text) + "',TO_BANK_ID = '" + cmbTrTo.SelectedValue.ToString() + "',CHQ_NO = '" + txtChq.Text + "',CHQ_DAATE = '" + dtChq.Value.ToString() + "',  MODIFICATION_DATE = GETDATE(), MODIFIED_BY = '" + Classes.Helper.userId + "' WHERE BTV_ID = '" + btv_id + "' ELSE INSERT INTO BANK_TRANSFER_VOUCHER VALUES('" + lblTV.Text + "','" + lblTrNo.Text + "','" + dtp_DATE.Value.ToString() + "','" + cmbTRFrom.SelectedValue.ToString() + "','" + cmbTrTo.SelectedValue.ToString() + "','" + cls_fhp.AvoidInjection(txtNar.Text) + "','" + cls_fhp.AvoidInjection(txtChq.Text) + "','" + dtChq.Value.ToString() + "','" + cls_fhp.AvoidInjection(txtAmount.Text) + "','" + Classes.Helper.userId + "',GETDATE(),NULL,'00')";
                int i = 0;
                if (cls_BTV.save_crv_details(query) >= 1)
                {
                    i = cls_BTV.insert_ledger_entry(dtp_DATE.Value.ToString(), Int32.Parse(cmbTrTo.SelectedValue.ToString()), Int32.Parse(cmbTRFrom.SelectedValue.ToString()), btv_id, "BANK TRANSFER", float.Parse(txtAmount.Text.ToString()), cls_fhp.AvoidInjection(txtNar.Text) + "/ CHQ NO: " + cls_fhp.AvoidInjection(txtChq.Text));
                    if (i > 0)
                    {
                        if (btv_id.Equals(""))
                        {
                            query = "INSERT INTO TRANSACTION_LOG VALUES('BANK TRANSFER VOUCHER','ADD NEW BANK TRANSFER VOUCHER',(SELECT MAX(BTV_ID) FROM BANK_TRANSFER_VOUCHER),GETDATE()," + Classes.Helper.userId + ") ";
                            cls_fhp.InsertUpdateDelete(query);
                        }
                        else
                        {
                            query = "INSERT INTO TRANSACTION_LOG VALUES('BANK TRANSFER VOUCHER','UPDATE BANK TRANSFER VOUCHER'," + btv_id + ",GETDATE()," + Classes.Helper.userId + ") ";
                            cls_fhp.InsertUpdateDelete(query);
                        }
                        cls_fhp.ShowMessageBox("Record Saved Sucessfully!", "success");
                        //essageBox.Show("Record Saved Sucessfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        show_report();
                        clear();
                        cls_BTV.load_trv_grid(grdSEARCH);
                    }
                }

            }
        }

        private void show_report()
        {
            //cls_BTV.get_head_bank_code(cmbTrTo.SelectedValue.ToString(), cmbTRFrom.SelectedValue.ToString());
            //cls_fhp.dataR = cls_fhp.mds.Tables["TV"].NewRow();
            //cls_fhp.dataR[0] = lblTV.Text;
            //cls_fhp.dataR[1] = lblTrNo.Text;
            //cls_fhp.dataR[2] = dtp_DATE.Value.ToShortDateString();
            //cls_fhp.dataR[3] = txtNar.Text;
            //cls_fhp.dataR[4] = cmbTRFrom.Text;
            //cls_fhp.dataR[5] = cls_BTV.debit_code;
            //cls_fhp.dataR[6] = cmbTrTo.Text;
            //cls_fhp.dataR[7] = cls_BTV.credit_code;
            //cls_fhp.dataR[8] = Convert.ToDouble(txtAmount.Text);
            //cls_fhp.dataR[9] = "User";
            //cls_fhp.dataR[10] = txtChq.Text;
            //cls_fhp.dataR[11] = dtChq.Value.ToShortDateString();
            //cls_fhp.mds.Tables["TV"].Rows.Add(cls_fhp.dataR);
            //cls_fhp.rpt = new Report_Form.frmReports();
            //cls_fhp.rpt.GenerateReport("TV", cls_fhp.mds);
            //cls_fhp.rpt.ShowDialog();
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {

        }

        private void frm_BankTr_Load(object sender, EventArgs e)
        {
            try
            {
                cls_BTV.load_trv_grid(grdSEARCH);
                cls_BTV.load_bank_accounts(cmbTRFrom);
                cls_BTV.load_bank_accounts(cmbTrTo);
                cls_BTV.generate_transaction_no(lblTrNo);
                cls_BTV.generate_voucher_no(lblTV);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        }

        private void txtSEARCH_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cls_BTV.cvr_grid_search(txtSEARCH, grdSEARCH);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        }

        private void grdSEARCH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void grdSEARCH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                load_data_fromGrid(e);
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
            cls_BTV.check_blank_zero(sender as TextBox);
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
                if (cls_fhp.CheckNameExists(grdSEARCH, lblTV.Text, 1) == 1)
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

        private void txtChq_Leave(object sender, EventArgs e)
        {
            cls_fhp.textField_leave(sender as TextBox);
        }

        private void cmbTRFrom_TextUpdate(object sender, EventArgs e)
        {
            cls_fhp.CmbTextUpdate(sender as ComboBox);
        }

        private void cmbTRFrom_DropDown(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown += new PreviewKeyDownEventHandler(cmbTRFrom_PreviewKeyDown);
        }

        private void cmbTRFrom_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown -= cmbTRFrom_PreviewKeyDown;
            if (cbo.DroppedDown) cbo.Focus();
        }

        private void cmbTrTo_DropDown(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown += new PreviewKeyDownEventHandler(cmbTrTo_PreviewKeyDown);
        }

        private void cmbTrTo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown -= cmbTrTo_PreviewKeyDown;
            if (cbo.DroppedDown) cbo.Focus();
        }

        private void frm_BankTr_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
