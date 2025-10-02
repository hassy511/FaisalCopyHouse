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
    public partial class frm_CashRcpt : Form
    {
        Classes.Helper cls_fhp = new Classes.Helper();
        Classes.cls_Cash_Receipt cls_CRP = new Classes.cls_Cash_Receipt();
        string crv_id = "";
        int is_edit = 0;
        public frm_CashRcpt()
        {
            InitializeComponent();
        }

        private void clear()
        {
            cls_CRP.generate_transaction_no(lblTrNo);
            cls_CRP.generate_voucher_no(lblCRV);
            dtp_DATE.Value = DateTime.Now;
            txtAmount.Clear();
            txtNar.Clear();
            txtReceive.Clear();
            txtSEARCH.Clear();
            cmbRc.SelectedIndex = 0;
            cmbCASH_AC.SelectedIndex = 0;
            dtp_DATE.Focus();
            crv_id = "";
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
                    crv_id = row.Cells[0].Value.ToString();
                    is_edit = 1;
                    lblCRV.Text = row.Cells[1].Value.ToString();
                    dtp_DATE.Value = DateTime.Parse(row.Cells[3].Value.ToString());
                    dtp_DATE.Focus();
                    lblTrNo.Text = row.Cells[2].Value.ToString();
                    cmbRc.SelectedValue = row.Cells[4].Value.ToString();
                    txtNar.Text = row.Cells[6].Value.ToString();
                    txtReceive.Text = row.Cells[7].Value.ToString();
                    txtAmount.Text = row.Cells[8].Value.ToString();
                    cmbCASH_AC.SelectedValue = row.Cells[9].Value.ToString();
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
            else if (rdbINV_REC.Checked == true && cmbSELECT_INV.SelectedIndex == 0)
            {
                cls_fhp.ShowMessageBox("Invoice account is not selected", "error");
                ///essageBox.Show("Invoice account is not selected, please select invoice.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbSELECT_INV.Focus();
            }
            else if (txtNar.Text.Trim().Equals(""))
            {
                cls_fhp.ShowMessageBox("Narration field is left blank", "error");
                //essageBox.Show("Narration field is blank.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNar.Focus();
            }
            else if (txtReceive.Text.Trim().Equals(""))
            {
                cls_fhp.ShowMessageBox("Received from field is left blank", "error");
                //essageBox.Show("Received from field is blank.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtReceive.Focus();
            }
            else if (float.Parse(txtAmount.Text) < 0)
            {
                cls_fhp.ShowMessageBox("Amount field is left blank", "error");
                //essageBox.Show("Amount field is blank.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAmount.Focus();
            }
            else if (cmbCASH_AC.SelectedIndex == 0)
            {
                cls_fhp.ShowMessageBox("Cash account is not selected", "error");
                //essageBox.Show("Cash account is not selected, please select cash account.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbCASH_AC.Focus();
            }
            else
            {
                if (rdbINV_REC.Checked == true && cmbSELECT_INV.Enabled == true)
                {
                    string msg = cls_fhp.getSale_Invoice_Bal(cmbSELECT_INV.SelectedValue.ToString(), float.Parse(txtAmount.Text));
                    if (!msg.Equals("OK"))
                    {
                        MessageBox.Show(msg);
                        return;
                    }
                }
                query = "IF EXISTS (select CRV_ID from CASH_REC_VOUCHER WHERE CRV_ID = '" + crv_id + "') UPDATE CASH_REC_VOUCHER SET DAATE = '" + dtp_DATE.Value.ToString() + "',COA_ID = '" + cmbRc.SelectedValue.ToString() + "',CASH_AC_ID = '" + cmbCASH_AC.SelectedValue.ToString() + "',DESCRIPTION = '" + cls_fhp.AvoidInjection(txtNar.Text) + "',AMOUNT = '" + cls_fhp.AvoidInjection(txtAmount.Text) + "',REC_FROM = '" + cls_fhp.AvoidInjection(txtReceive.Text) + "',MODIFICATION_DATE = GETDATE(), MODIFIED_BY = '" + Classes.Helper.userId + "' WHERE CRV_ID = '" + crv_id + "' ELSE INSERT INTO CASH_REC_VOUCHER VALUES('" + lblCRV.Text + "','" + lblTrNo.Text + "','" + dtp_DATE.Value.ToString() + "','" + cmbRc.SelectedValue.ToString() + "','" + cls_fhp.AvoidInjection(txtNar.Text) + "','" + cls_fhp.AvoidInjection(txtAmount.Text) + "','" + cls_fhp.AvoidInjection(txtReceive.Text) + "','" + Classes.Helper.userId + "',GETDATE(),NULL,'00','" + cmbCASH_AC.SelectedValue.ToString() + "')";
                int i = 0;
                if (cls_CRP.save_crv_details(query) >= 1)
                {
                    i = cls_CRP.insert_ledger_entry(dtp_DATE.Value.ToString(), Int32.Parse(cmbCASH_AC.SelectedValue.ToString()), Int32.Parse(cmbRc.SelectedValue.ToString()), crv_id, "CASH RECEIPT", float.Parse(txtAmount.Text.ToString()), cls_fhp.AvoidInjection(txtNar.Text),"","");
                    if (i > 0)
                    {
                        if (rdbINV_REC.Checked == true && cmbSELECT_INV.Enabled == true) { save_invoice_record(); }
                        if (crv_id.Equals(""))
                        {
                            query = "INSERT INTO TRANSACTION_LOG VALUES('CASH RECEIPT VOUCHER','ADD NEW CASH RECEIPT VOUCHER',(SELECT MAX(CRV_ID) FROM CASH_REC_VOUCHER),GETDATE()," + Classes.Helper.userId + ") ";
                            cls_fhp.InsertUpdateDelete(query);
                        }
                        else
                        {
                            query = "INSERT INTO TRANSACTION_LOG VALUES('CASH RECEIPT VOUCHER','UPDATE CASH RECEIPT VOUCHER'," + crv_id + ",GETDATE()," + Classes.Helper.userId + ") ";
                            cls_fhp.InsertUpdateDelete(query);
                        }
                        cls_fhp.ShowMessageBox("Record Saved Sucessfully!", "success");
                        //essageBox.Show("Record Saved Sucessfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        show_report();
                        clear();
                        cls_CRP.load_cvr_grid(grdSEARCH);
                    }
                }
            }
        }

        private int save_invoice_record()
        {
            int i = 0;
            query = @"IF EXISTS (select VOUCHER_ID from INVOICES_DETAILS WHERE VOUCHER_OF = 'CASH REC' AND VOUCHER_ID = '" + crv_id + @"') 
                    UPDATE INVOICES_DETAILS SET DAATE = '" + dtp_DATE.Value.ToString() + "',COA_ID = '" + cmbRc.SelectedValue.ToString() + @"',
                    AMOUNT = '" + cls_fhp.AvoidInjection(txtAmount.Text) + "' WHERE VOUCHER_ID = '" + crv_id + @"' 
                    ELSE 
                    INSERT INTO INVOICES_DETAILS VALUES('" + dtp_DATE.Value.ToString() + "','SALES','" + cmbRc.SelectedValue.ToString() + "','" + cmbSELECT_INV.SelectedValue.ToString() + "',(SELECT MAX(CRV_ID) FROM CASH_REC_VOUCHER),'CASH REC','" + cls_fhp.AvoidInjection(txtAmount.Text) + @"');
                    UPDATE SALES_M SET REC_AMT = (SELECT SUM(AMOUNT) FROM INVOICES_DETAILS WHERE PAY_OF = 'SALES' AND INVOICE_NO = '" + cmbSELECT_INV.SelectedValue.ToString() + "') WHERE SM_ID = '" + cmbSELECT_INV.SelectedValue.ToString() + "'";
            i = cls_fhp.InsertUpdateDelete(query);
            return i;
        }

        private void show_report()
        {
            //cls_fhp.get_head_cash_code(cmbRc.SelectedValue.ToString());
            //cls_fhp.dataR = cls_fhp.mds.Tables["CashRcpt"].NewRow();
            //cls_fhp.dataR[0] = lblCRV.Text;
            //cls_fhp.dataR[1] = lblTrNo.Text;
            //cls_fhp.dataR[2] = dtp_DATE.Value.ToShortDateString();
            //cls_fhp.dataR[3] = txtReceive.Text;
            //cls_fhp.dataR[4] = txtNar.Text;
            //cls_fhp.dataR[5] = "PETTY CASH";
            //cls_fhp.dataR[6] = cls_fhp.credit_code;
            //cls_fhp.dataR[7] = cmbRc.Text;
            //cls_fhp.dataR[8] = cls_fhp.debit_code;
            //cls_fhp.dataR[9] = Convert.ToDouble(txtAmount.Text);
            //cls_fhp.dataR[10] = "User";
            //cls_fhp.mds.Tables["CashRcpt"].Rows.Add(cls_fhp.dataR);
            //cls_fhp.rpt = new Report_Form.frmReports();
            //cls_fhp.rpt.GenerateReport("CashVoucherR", cls_fhp.mds);
            //cls_fhp.rpt.ShowDialog();
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {
            try
            {
                save();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        }

        private void frm_CashRcpt_Load(object sender, EventArgs e)
        {
            try
            {
                cls_CRP.load_cvr_grid(grdSEARCH);
                cls_CRP.load_accounts(cmbRc);
                cls_CRP.generate_transaction_no(lblTrNo);
                cls_CRP.generate_voucher_no(lblCRV);
                cls_CRP.load_cash_accounts(cmbCASH_AC);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        }

        private void txtSEARCH_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cls_CRP.cvr_grid_search(txtSEARCH, grdSEARCH);
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

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            cls_CRP.check_blank_zero(sender as TextBox);
            cls_fhp.textField_leave(sender as TextBox);
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            cls_fhp.AllowNumbers(e);
        }


        private void grdSEARCH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                load_data_fromGrid(e);
                cls_fhp.load_all_invoices(cmbSELECT_INV, cmbRc.SelectedValue.ToString());
                cls_fhp.invoice_detail(crv_id, cmbSELECT_INV, rdbINV_REC, rdbOTHERS);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        }

        private void grdSEARCH_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            grdSEARCH.Columns[0].Visible = false;
            grdSEARCH.Columns[2].Visible = false;
            grdSEARCH.Columns[4].Visible = false;
            grdSEARCH.Columns[9].Visible = false;
            //grdSEARCH.Columns[10].Visible = false;
        }

        private void btn_VIEW_VOUCHER_Click(object sender, EventArgs e)
        {
            try
            {
                if (cls_fhp.CheckNameExists(grdSEARCH, lblCRV.Text, 1) == 1)
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

        private void txtNar_Leave(object sender, EventArgs e)
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

        private void rdbCASH_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbCASH.Checked == true && rdbPETTY_CASH.Checked == false)
                {
                    cls_CRP.cvr_grid_search_cash_pettyCash("CASH", grdSEARCH);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        }

        private void rdbPETTY_CASH_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbCASH.Checked == false && rdbPETTY_CASH.Checked == true)
                {
                    cls_CRP.cvr_grid_search_cash_pettyCash("PETTY CASH", grdSEARCH);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        }

        private void frm_CashRcpt_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
