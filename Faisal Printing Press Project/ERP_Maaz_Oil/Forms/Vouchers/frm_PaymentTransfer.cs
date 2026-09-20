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
    public partial class frm_PaymentTransfer : Form
    {
        Classes.Helper cls_fhp = new Classes.Helper();
        Classes.cls_Payment_Transfer cls_pt = new Classes.cls_Payment_Transfer();
        string pt_id = "";
        int is_edit = 0;

        bool rowClicked = false;
        public frm_PaymentTransfer()
        {
            InitializeComponent();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //if (keyData == (Keys.Control))
            //{
            //    SendKeys.Send("{TAB}");
            //}
            if (keyData == (Keys.Control | Keys.S))
            {
                RecordSave();
            }
            if (keyData == (Keys.Control | Keys.D))
            {
                RecordDelete();
            }
            if (keyData == (Keys.Control | Keys.C))
            {
                Clear();
            }
            if (keyData == (Keys.Escape))
            {
                this.Dispose();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        public void loadAllChqs()
        {
            cls_fhp.LoadComboData(cmbChqNo, Classes.Queries.LoadAllChqs());
        }
        private void LoadChqData() {
            try
            {
                if (cmbChqNo.SelectedIndex != 0)
                {
                    string[] chqDetails = cls_fhp.GetChqDetails(Convert.ToInt32(cmbChqNo.SelectedValue.ToString()));
                    cmbRecAc.SelectedValue = chqDetails[0];
                    txtAmount.Text = chqDetails[1];

                }
            }
            catch (Exception ex) { cls_fhp.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void Clear()
        {
            cls_pt.generate_voucher_no(lblVoucherNo);
            dtpDate.Value = DateTime.Now;
            dtpChqDate.Value = DateTime.Now;
            cmbRecAc.SelectedValue = "0";
            txtAmount.Text = "0";
            rdbOnline.Checked = true;
            dtpChqDate.Enabled = true;
            cmbBank.Text = "";
            cmbBrCode.SelectedIndex = 0;
            cmbPaymentAc.SelectedValue = "0";
            cmbChqNo.SelectedIndex = 0;
            cmbChqNo.Enabled = false;
            rdbOnline.Checked = true;
            cmbRefAc.Text = "";
            txtNarration.Clear();
            txtStatus.Clear();
            btnEdit.Enabled = false;
            EnableFields();
            //cmbInstrumentNo.Clear();
            cmbSubAccount.SelectedIndex = 0;
            txtSearch.Clear();
            dtpDate.Focus();
            txtTotal.Text = "0";
            txtEntries.Text = "0";
            pt_id = "";
            cls_pt.load_pt_grid(grdEntries,dtpDate.Value);
            is_edit = 0;
            TotalRowSum();
            cls_pt.load_branch_code(cmbBrCode);
            cls_pt.load_ref_accounts(cmbRefAc);
            cls_pt.load_bank(cmbBank);
            cmbRefAc.Text = "";
            cmbBank.Text = "";
            cmbInstrumentNo.SelectedIndex = 0;
            txtCNIC.Clear();
            grdPaySummary.DataSource = null;
            grdRecSummary.DataSource = null;
        }

        private void ShowReport()
        {
            //cls_fhp.mds.Tables["JV"].Clear();
            //foreach (DataGridViewRow rows in grdENTRY.Rows)
            //{
            //    cls_fhp.dataR = cls_fhp.mds.Tables["JV"].NewRow();
            //    cls_fhp.dataR[0] = lblTV.Text;
            //    cls_fhp.dataR[1] = lblTrNo.Text;
            //    cls_fhp.dataR[2] = dtp_DATE.Value.ToShortDateString();
            //    cls_fhp.dataR[3] = txtNar.Text;
            //    cls_fhp.dataR[4] = rows.Cells[1].Value.ToString();
            //    cls_fhp.dataR[5] = cls_GV.get_head_code(rows.Cells[0].Value.ToString());
            //    cls_fhp.dataR[6] = Convert.ToDouble(rows.Cells[2].Value.ToString());
            //    cls_fhp.dataR[7] = Convert.ToDouble(rows.Cells[3].Value.ToString());
            //    cls_fhp.dataR[8] = "User";
            //    cls_fhp.mds.Tables["JV"].Rows.Add(cls_fhp.dataR);
            //}
            //cls_fhp.rpt = new Report_Form.frmReports();
            //cls_fhp.rpt.GenerateReport("JV", cls_fhp.mds);
            //cls_fhp.rpt.ShowDialog();
        }


        

        //get data from grid on click
        private void LoadDataFromGrid(DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    rowClicked = true;
                    DataGridViewRow row = this.grdEntries.Rows[e.RowIndex];
                    is_edit = 1;
                    pt_id = row.Cells["PT_ID"].Value.ToString();
                    lblVoucherNo.Text = row.Cells["PV_NO"].Value.ToString();
                    dtpDate.Value = DateTime.Parse(row.Cells["DATE"].Value.ToString());
                    cmbRecAc.SelectedValue = row.Cells["REC_AC"].Value.ToString();
                    txtAmount.Text = row.Cells["AMOUNT"].Value.ToString();
                    if (row.Cells["CHQ_ONLINE"].Value.ToString().Equals("CHQ"))
                    {
                        rdbChq.Checked = true;
                        dtpChqDate.Enabled = true;
                        loadAllChqs();
                        dtpChqDate.Value = DateTime.Parse(row.Cells["CHQ_DATE"].Value.ToString());
                        cmbChqNo.SelectedValue = row.Cells["CHQ_ID"].Value.ToString();
                    }
                    else {
                        rdbOnline.Checked = true;
                        dtpChqDate.Enabled = true;
                    }
                    txtCNIC.Text = row.Cells["CNIC"].Value.ToString();
                    cmbBank.Text = row.Cells["BANK"].Value.ToString();
                    cmbBrCode.Text = row.Cells["BR_CODE"].Value.ToString();
                    cmbPaymentAc.SelectedValue = row.Cells["PAY_AC"].Value.ToString();
                    cmbRefAc.Text = row.Cells["REF AC"].Value.ToString();
                    txtNarration.Text = row.Cells["REMARKS"].Value.ToString();
                    cmbInstrumentNo.Text = row.Cells["INSTRUMENT_NO"].Value.ToString();
                    cmbSubAccount.Text = row.Cells["SUB ACCOUNT"].Value.ToString();
                    txtStatus.Text = row.Cells["STATUS"].Value.ToString();
                    rowClicked = false;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        }

        private void TotalRowSum()
        {
            if (grdEntries.Rows.Count > 0)
            {
                txtEntries.Text = grdEntries.Rows.Count.ToString();

                txtTotal.Text = grdEntries.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToDecimal(t.Cells["AMOUNT"].Value)).ToString();
            }
            
        }

        private void Delete()
        {
            char chqOnline = 'C';
            if (rdbOnline.Checked == true)
            {
                chqOnline = 'O';
            }
            cls_fhp.query = @"BEGIN TRY 
                             BEGIN TRANSACTION ";

            cls_fhp.query += "IF EXISTS (select PT_ID from PAYMENT_TRANSFER WHERE PT_ID = '" + pt_id + @"') 
                DELETE FROM PAYMENT_TRANSFER WHERE PT_ID = '" + pt_id + @"'";

            if (chqOnline == 'C')
            {
                cls_fhp.query += @"DELETE FROM CHQ WHERE CHQ_ID = (SELECT CHQ_ID FROM TRANSFER_CHQ WHERE PT_ID = '" + pt_id + @"')";
            }

            cls_fhp.query += @" COMMIT TRANSACTION 
                        END TRY 
                    BEGIN CATCH 
                            IF @@TRANCOUNT > 0 
                            ROLLBACK TRANSACTION 
                    END CATCH";

            if (cls_fhp.InsertUpdateDelete(cls_fhp.query) >= 1)
            {
                cls_fhp.ShowMessageBox("Record Deleted Sucessfully.", "Information");
                Clear();
            }
        }

        private void Save()
        {
            if (cmbRecAc.SelectedValue.ToString().Equals("0"))
            {
                cls_fhp.ShowMessageBox("Select Rec Account", "error");
            }
            else if (txtAmount.Text.Trim().Equals("0"))
            {
                cls_fhp.ShowMessageBox("Enter Amount", "error");
            }
            //else if (txtBankName.Text.Trim().Equals(""))
            //{
            //    cls_fhp.ShowMessageBox("Enter Bank", "error");
            //}
            else if (cmbBrCode.Text.Trim().Equals(""))
            {
                cls_fhp.ShowMessageBox("Enter BR Code", "error");
            }
            else if (cmbPaymentAc.SelectedValue.ToString().Equals("0"))
            {
                cls_fhp.ShowMessageBox("Select Payment Account", "error");
            }
            else if(txtCNIC.Text =="")
            {
                cls_fhp.ShowMessageBox("No CNIC Entered", "error");
            }
            else if (cmbChqNo.SelectedIndex == 0 && rdbChq.Checked == true)
            {
                cls_fhp.ShowMessageBox("Select Chq", "error");
                cmbChqNo.Focus();
            }
            else
            {
                char chqOnline = 'O';
                int chqId = 0;
                if (rdbChq.Checked == true) {
                    chqOnline = 'C';
                    chqId = Convert.ToInt32(cmbChqNo.SelectedValue.ToString());
                }

                
                
                cls_fhp.query = @"BEGIN TRY 
                             BEGIN TRANSACTION ";

                cls_fhp.query += "IF EXISTS (select PT_ID from PAYMENT_TRANSFER WHERE PT_ID = '" + pt_id + @"') 
                UPDATE PAYMENT_TRANSFER SET DATE = '" + dtpDate.Value.ToString() + "',REC_AC = '" + cmbRecAc.SelectedValue.ToString() + @"',
                PAY_AC = '" + cmbPaymentAc.SelectedValue.ToString() + "',REF_AC = '" + cmbRefAc.Text + @"',
                CHQ_ONLINE = '" + chqOnline + "',CHQ_DATE = '" + dtpChqDate.Value.ToString() + "',AMOUNT = '" + cls_fhp.AvoidInjection(txtAmount.Text) + @"',
                BANK = '" + cls_fhp.AvoidInjection(cmbBank.Text) + @"',BR_CODE = '" + cls_fhp.AvoidInjection(cmbBrCode.Text) + @"',
                INSTRUMENT_NO = '" + cls_fhp.AvoidInjection(cmbInstrumentNo.Text) + @"',REMARKS = '" + cls_fhp.AvoidInjection(txtNarration.Text) + @"',
                SUB_ACC ='" + cmbSubAccount.Text + @"', CNIC = '"+txtCNIC.Text+ @"',CHQ_ID = '" + chqId + @"'
                WHERE PT_ID = '" + pt_id + @"'
                ELSE
                INSERT INTO PAYMENT_TRANSFER (PV_NO,DATE,REC_AC,PAY_AC,REF_AC,CHQ_ONLINE,CHQ_DATE,AMOUNT,BANK,BR_CODE,INSTRUMENT_NO,STATUS,REMARKS,SUB_ACC,CNIC,CHQ_ID) VALUES (
                (select 'PV-'+convert(varchar(50),(ISNULL(MAX(PT_ID),0)+1))+'-'+convert(varchar(50),year(getdate())) from PAYMENT_TRANSFER),'" + dtpDate.Value.ToString() + "','" + cmbRecAc.SelectedValue.ToString() + "','" + cmbPaymentAc.SelectedValue.ToString() + @"',
                '" + cmbRefAc.Text + "','" + chqOnline + "','" + dtpChqDate.Value.ToString() + "','" + txtAmount.Text + @"',
                '" + cls_fhp.AvoidInjection(cmbBank.Text) + "','" + cls_fhp.AvoidInjection(cmbBrCode.Text) + "','" + cls_fhp.AvoidInjection(cmbInstrumentNo.Text) + @"',
                '0','" + cls_fhp.AvoidInjection(txtNarration.Text) + "','" + cmbSubAccount.Text +"','"+txtCNIC.Text+ @"','" + chqId + @"'); ";

                //if (chqOnline == 'C') {

                //    if (is_edit == 0)
                //    {
                //        cls_fhp.query += @"INSERT INTO CHQ (CHQ_DATE,CHQ_NO,AMOUNT,REC_AC,PAY_AC,BANK_NAME,STATUS,PAY_DATE) VALUES (
                //        '" + dtpChqDate.Value.ToString() + "','" + cls_fhp.AvoidInjection(cmbInstrumentNo.Text) + @"',
                //        '" + cls_fhp.AvoidInjection(txtAmount.Text) + "','" + cmbRecAc.SelectedValue.ToString() + "','" + cmbPaymentAc.SelectedValue.ToString() + @"',
                //        '" + cls_fhp.AvoidInjection(cmbBank.Text) + "','1','" + dtpDate.Value.ToString() + @"');";

                //        cls_fhp.query += @"INSERT INTO TRANSFER_CHQ (PT_ID,CHQ_ID) VALUES ((SELECT MAX(PT_ID) FROM PAYMENT_TRANSFER),(SELECT MAX(CHQ_ID) FROM CHQ))";
                //    }
                //    else {
                //        cls_fhp.query += @"UPDATE A
                //        SET A.CHQ_DATE = '" + dtpChqDate.Value.ToString() + "',A.CHQ_NO = '" + cls_fhp.AvoidInjection(cmbInstrumentNo.Text) + @"',
                //        A.AMOUNT = '" + cls_fhp.AvoidInjection(txtAmount.Text) + "',A.REC_AC = '" + cmbRecAc.SelectedValue.ToString() + @"',
                //        A.PAY_AC = '" + cmbPaymentAc.SelectedValue.ToString() + "',A.BANK_NAME = '" + cls_fhp.AvoidInjection(cmbBank.Text) + @"',
                //        A.PAY_DATE = '" + dtpDate.Value.ToString() + @"'
                //        FROM CHQ A 
                //        INNER JOIN TRANSFER_CHQ B ON A.CHQ_ID = B.CHQ_ID
                //        WHERE B.PT_ID = '" + pt_id + @"'";
                //    }
                //}

                //cls_fhp.query += @" COMMIT TRANSACTION 
                //        END TRY 
                //    BEGIN CATCH 
                //            IF @@TRANCOUNT > 0 
                //            ROLLBACK TRANSACTION 
                //    END CATCH";

                //if (cls_fhp.InsertUpdateDelete(cls_fhp.query) >= 1)
                //{
                    //cls_fhp.ShowMessageBox("Record Saved Sucessfully.", "Information");
                    //DialogResult dialogResult = MessageBox.Show("Print Voucher?", "Print cls_fhp", MessageBoxButtons.YesNo);
                    //if (dialogResult == DialogResult.Yes)
                    //{
                    //    ShowReport();
                    //}

                    if(cmbSubAccount.SelectedIndex>=0)
                    {
                        //cls_fhp.query = @"BEGIN TRY 
                        //     BEGIN TRANSACTION ";

                        cls_fhp.query += "IF EXISTS (select PT_ID from MAAZ_OIL_AA.dbo.PAYMENT_TRANSFER WHERE AOI_ID = '" + pt_id + @"') 
                        UPDATE MAAZ_OIL_AA.dbo.PAYMENT_TRANSFER SET DATE = '" + dtpDate.Value.ToString() + "',REC_AC = '" + cmbSubAccount.SelectedValue.ToString() + @"',
                        PAY_AC = '5111',REF_AC = '" + cmbRefAc.Text + @"',
                        CHQ_ONLINE = '" + chqOnline + "',CHQ_DATE = '" + dtpChqDate.Value.ToString() + "',AMOUNT = '" + cls_fhp.AvoidInjection(txtAmount.Text) + @"',
                        BANK = '" + cls_fhp.AvoidInjection(cmbBank.Text) + @"',BR_CODE = '" + cls_fhp.AvoidInjection(cmbBrCode.Text) + @"',
                        INSTRUMENT_NO = '" + cls_fhp.AvoidInjection(cmbInstrumentNo.Text) + @"',REMARKS = '" + cls_fhp.AvoidInjection(txtNarration.Text) + @"'              
                        WHERE AOI_ID = '" + pt_id + @"'
                        ELSE
                        INSERT INTO MAAZ_OIL_AA.dbo.PAYMENT_TRANSFER (PV_NO,DATE,REC_AC,PAY_AC,REF_AC,CHQ_ONLINE,CHQ_DATE,AMOUNT,BANK,BR_CODE,INSTRUMENT_NO,STATUS,REMARKS,AOI_ID) VALUES (
                        (select 'PV-'+convert(varchar(50),(ISNULL(MAX(PT_ID),0)+1))+'-'+convert(varchar(50),year(getdate())) from MAAZ_OIL_AA.dbo.PAYMENT_TRANSFER),'" + dtpDate.Value.ToString() + "','" + cmbSubAccount.SelectedValue.ToString() + @"','5111',
                        '" + cmbRefAc.Text + "','" + chqOnline + "','" + dtpChqDate.Value.ToString() + "','" + txtAmount.Text + @"',
                        '" + cls_fhp.AvoidInjection(cmbBank.Text) + "','" + cls_fhp.AvoidInjection(cmbBrCode.Text) + "','" + cls_fhp.AvoidInjection(cmbInstrumentNo.Text) + @"',
                        '0','" + cls_fhp.AvoidInjection(txtNarration.Text) + "',(SELECT MAX(PT_ID) FROM AOI_20_21.dbo.PAYMENT_TRANSFER))";

                                //if (chqOnline == 'C')
                                //{

                                //    if (is_edit == 0)
                                //    {
                                //        cls_fhp.query += @"INSERT INTO MAAZ_OIL_AA.dbo.CHQ (CHQ_DATE,CHQ_NO,AMOUNT,REC_AC,PAY_AC,BANK_NAME,STATUS,PAY_DATE) VALUES (
                                //'" + dtpChqDate.Value.ToString() + "','" + cls_fhp.AvoidInjection(cmbInstrumentNo.Text) + @"',
                                //'" + cls_fhp.AvoidInjection(txtAmount.Text) + "','" + cmbRecAc.SelectedValue.ToString() + "','" + cmbPaymentAc.SelectedValue.ToString() + @"',
                                //'" + cls_fhp.AvoidInjection(cmbBank.Text) + "','1','" + dtpDate.Value.ToString() + @"');";

                                //        cls_fhp.query += @"INSERT INTO MAAZ_OIL_AA.dbo.TRANSFER_CHQ (PT_ID,CHQ_ID) VALUES ((SELECT MAX(PT_ID) FROM MAAZ_OIL_AA.dbo.PAYMENT_TRANSFER),(SELECT MAX(CHQ_ID) FROM MAAZ_OIL_AA.dbo.CHQ))";
                                //    }
                                //    else
                                //    {
                                //        cls_fhp.query += @"UPDATE A
                                //        SET A.CHQ_DATE = '" + dtpChqDate.Value.ToString() + "',A.CHQ_NO = '" + cls_fhp.AvoidInjection(cmbInstrumentNo.Text) + @"',
                                //        A.AMOUNT = '" + cls_fhp.AvoidInjection(txtAmount.Text) + "',A.REC_AC = '" + cmbRecAc.SelectedValue.ToString() + @"',
                                //        A.PAY_AC = '" + cmbPaymentAc.SelectedValue.ToString() + "',A.BANK_NAME = '" + cls_fhp.AvoidInjection(cmbBank.Text) + @"',
                                //        A.PAY_DATE = '" + dtpDate.Value.ToString() + @"',STATUS = '0'
                                //        FROM MAAZ_OIL_AA.dbo.CHQ A 
                                //        INNER JOIN MAAZ_OIL_AA.dbo.TRANSFER_CHQ B ON A.CHQ_ID = B.CHQ_ID
                                //        WHERE B.PT_ID = '" + pt_id + @"'";
                                //    }
                                //}

                                
                        
                    }

                cls_fhp.query += @" COMMIT TRANSACTION 
                                END TRY 
                                BEGIN CATCH 
                                        IF @@TRANCOUNT > 0 
                                        ROLLBACK TRANSACTION 
                                END CATCH";
                if (cls_fhp.InsertUpdateDelete(cls_fhp.query) >= 1)
                {
                    cls_fhp.ShowMessageBox("Record Saved Sucessfully.", "Information");
                }
                else
                {
                    cls_fhp.ShowMessageBox("Error inserting data", "Error");

                }

                Clear();
                //}
            }
        }

        private void frm_BankTr_Load(object sender, EventArgs e)
        {
            try
            {
                cls_pt.generate_voucher_no(lblVoucherNo);
                cls_pt.load_pt_grid(grdEntries,dtpDate.Value);
                cls_pt.load_accounts(cmbRecAc);
                cls_pt.load_branch_code(cmbBrCode);
                grdPaySummary.DataSource = null;
                grdRecSummary.DataSource = null;     
                cls_pt.load_rec_grid(grdRecSummary, dtpDate.Value);
                cls_pt.load_pay_grid(grdPaySummary, dtpDate.Value);
                if (grdRecSummary.DataSource != null)
                    grdRecSummary.Columns[0].Width = 190;
                if (grdPaySummary.DataSource != null)
                    grdPaySummary.Columns[0].Width = 190;

                cls_pt.load_names(cmbSubAccount);
                cls_pt.load_instruments(cmbInstrumentNo);
                cls_pt.load_accounts(cmbPaymentAc);
                cls_pt.load_ref_accounts(cmbRefAc);
                cls_pt.load_bank(cmbBank);
                cmbBank.Text = "";
                cmbRefAc.Text = "";
                TotalRowSum();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        }

        private void grdSEARCH_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            grdEntries.Columns["PT_ID"].Visible = false;
            grdEntries.Columns["REC_AC"].Visible = false;
            grdEntries.Columns["PAY_AC"].Visible = false;
            grdEntries.Columns["REF_AC"].Visible = false;
            grdEntries.Columns["CHQ_ID"].Visible = false;
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            cls_fhp.AllowNumbers(e);
        }

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            cls_pt.check_blank_zero(sender as TextBox);
            cls_fhp.textField_leave(sender as TextBox);
        }

        private void btnCLEAR_Click(object sender, EventArgs e)
        {
            try
            {
                Clear();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        }

        private void RecordSave() {
            try
            {
                if (txtStatus.Text.Equals("APPROVED"))
                {
                    MessageBox.Show("Entry is Approved. It cannot be saved.", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Save();
                grdPaySummary.DataSource = null;
                grdRecSummary.DataSource = null;
                cls_pt.load_pt_grid(grdEntries, dtpDate.Value);
                cls_pt.load_rec_grid(grdRecSummary, dtpDate.Value);
                cls_pt.load_pay_grid(grdPaySummary, dtpDate.Value);
                if (grdRecSummary.DataSource != null)
                    grdRecSummary.Columns[0].Width = 190;
                if (grdPaySummary.DataSource != null)
                    grdPaySummary.Columns[0].Width = 190;
                dtpChqDate.Value = DateTime.Now;
                //cmbSubAccount.SelectedIndex = 0;
                //cmbInstrumentNo.Text = "";
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void btnSAVE_Click_1(object sender, EventArgs e)
        {
            RecordSave();
        }

        private void grdENTRY_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                LoadDataFromGrid(e);
                DisableFields();
                if (txtStatus.Text.Equals("APPROVED"))
                {
                    btnEdit.Enabled = false;
                }
                else {
                    btnEdit.Enabled = true;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        }

        private void txtDEBIT_Enter(object sender, EventArgs e)
        {
            cls_fhp.select_all_text(sender as TextBox);
        }

        private void txtDEBIT_MouseClick(object sender, MouseEventArgs e)
        {
            cls_fhp.select_all_text(sender as TextBox);
        }

        private void cmbACCOUNT_TextUpdate(object sender, EventArgs e)
        {
            cls_fhp.CmbTextUpdate(sender as ComboBox);
        }

        private void cmbACCOUNT_DropDown(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown += new PreviewKeyDownEventHandler(cmbACCOUNT_PreviewKeyDown);
        }

        private void cmbACCOUNT_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown -= cmbACCOUNT_PreviewKeyDown;
            if (cbo.DroppedDown) cbo.Focus();
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
            
        }

        private void btn_VIEW_VOUCHER_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (cls_fhp.CheckNameExists(grdSEARCH, lblVoucherNo.Text, 2) == 1)
            //    { show_report(); }
            //    else
            //    {
            //        cls_fhp.ShowMessageBox("Record Not Found To Print", "error");
            //        //essageBox.Show("Record Not Found To Print.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        }

        private void frm_General_Voucher_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            if (rowClicked == false) {
                grdPaySummary.DataSource = null;
                grdRecSummary.DataSource = null;
                txtTotalPayGrid.Text = "0";
                txtTotalRecGrid.Text = "0";
                cls_pt.load_pt_grid(grdEntries, dtpDate.Value);
                cls_pt.load_rec_grid(grdRecSummary, dtpDate.Value);
                cls_pt.load_pay_grid(grdPaySummary, dtpDate.Value);
                if(grdRecSummary.DataSource!=null)
                grdRecSummary.Columns[0].Width = 190;
                if(grdPaySummary.DataSource!=null)
                grdPaySummary.Columns[0].Width = 190;

                grdEntries.Columns["DATE"].Visible = false;
                txtTotal.Text = "0";
                //txtAmount.Text = "0";
                TotalRowSum();

            }
        }

        private void ChqLoad() {
            if (rdbChq.Checked == true)
            {
                cmbChqNo.Enabled = true;
                cls_fhp.LoadComboData(cmbChqNo, Classes.Queries.LoadPTChqs());
            }
            else
            {
                cmbChqNo.Enabled = false;
            }
        }

        private void rdbOthers_CheckedChanged_1(object sender, EventArgs e)
        {
            dtpChqDate.Enabled = true;
            ChqLoad();
        }

        private void rdbChq_CheckedChanged(object sender, EventArgs e)
        {
            dtpChqDate.Enabled = true;
            ChqLoad();
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                cls_pt.cvr_grid_search(txtSearch, grdEntries);
                double sum = 0;
                for(int i = 0; i <grdEntries.Rows.Count; i++)
                {
                    sum += double.Parse(grdEntries.Rows[i].Cells["AMOUNT"].Value.ToString());
                }
                txtTotal.Text = sum.ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void cmbPaymentAc_DropDown(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown += new PreviewKeyDownEventHandler(cmbPaymentAc_PreviewKeyDown);
        }

        private void cmbPaymentAc_TextUpdate(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown -= cmbPaymentAc_PreviewKeyDown;
            if (cbo.DroppedDown) cbo.Focus();
        }

        private void cmbPaymentAc_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            cls_fhp.CmbTextUpdate(sender as ComboBox);
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

        private void cmbBank_TextUpdate(object sender, EventArgs e)
        {
            
        }

        private void RecordDelete() {
            try
            {
                if (txtStatus.Text.Equals("APPROVED"))
                {
                    MessageBox.Show("Entry is Approved. It cannot be deleted.", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                Delete();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            RecordDelete();
        }

        private void txtCNIC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar=='\b')
            {
                if (txtCNIC.Text.Length == 6)
                    txtCNIC.Text.Remove(4, 1);

                else if (txtCNIC.Text.Length == 14)
                    txtCNIC.Text.Remove(13, 1);

            }
            else if (!char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
               
                e.Handled = true;
                
            }
            else if (txtCNIC.Text.Length == 5 || txtCNIC.Text.Length == 13)
            {
                txtCNIC.Text += "-";
                txtCNIC.SelectionStart = txtCNIC.Text.Length;
                txtCNIC.SelectionLength = 0;
            }
            txtCNIC.SelectionStart = txtCNIC.Text.Length;
            txtCNIC.SelectionLength = 0;
        }

        private void txtCNIC_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnSHOW_Click(object sender, EventArgs e)
        {

        }

        private void grdRecSummary_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            double total = 0;
            for(int i = 0; i < grdRecSummary.Rows.Count; i++)
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

        private void cmbChqNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadChqData();
        }

        private void cmbSubAccount_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cmbRecAc_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (rowClicked == false) {
            //        //txtSearch.Text = cmbRecAc.Text;
            //        cls_pt.PTVGridSearch(cmbRecAc.Text, grdEntries);
            //    }
            //}
            //catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }
           
        }

        private void EnableFields() {
            dtpDate.Enabled = true;
            cmbRecAc.Enabled = true;
            txtAmount.Enabled = true;
            cmbSubAccount.Enabled = true;
            txtCNIC.Enabled = true;
            cmbBank.Enabled = true;
            cmbBrCode.Enabled = true;
            cmbPaymentAc.Enabled = true;
            cmbRecAc.Enabled = true;
            cmbInstrumentNo.Enabled = true;
            cmbChqNo.Enabled = true;
            txtNarration.Enabled = true;
            txtStatus.Enabled = true;
            rdbChq.Enabled = true;
            rdbOnline.Enabled = true;
            btnSave.Enabled = true;
            cmbRefAc.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void DisableFields()
        {
            dtpDate.Enabled = false;
            cmbRecAc.Enabled = false;
            txtAmount.Enabled = false;
            cmbSubAccount.Enabled = false;
            txtCNIC.Enabled = false;
            cmbBank.Enabled = false;
            cmbBrCode.Enabled = false;
            cmbPaymentAc.Enabled = false;
            cmbRecAc.Enabled = false;
            cmbInstrumentNo.Enabled = false;
            cmbChqNo.Enabled = false;
            txtNarration.Enabled = false;
            txtStatus.Enabled = false;
            rdbChq.Enabled = false;
            cmbRefAc.Enabled = false;
            rdbOnline.Enabled = false;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EnableFields();
            btnEdit.Enabled = false;
        }
    }
}
