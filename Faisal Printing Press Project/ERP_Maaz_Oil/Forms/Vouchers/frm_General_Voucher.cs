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
    public partial class frm_General_Voucher : Form
    {
        Classes.Helper cls_fhp = new Classes.Helper();
        Classes.cls_General_Voucher cls_GV = new Classes.cls_General_Voucher();
        string gv_id = "";
        int is_edit = 0;
        public frm_General_Voucher()
        {
            InitializeComponent();
        }

        private void clear()
        {
            cls_GV.generate_transaction_no(lblTrNo);
            cls_GV.generate_voucher_no(lblTV);
            dtp_DATE.Value = DateTime.Now;
            txtDEBIT.Text = "0.0";
            txtCREDIT.Text = "0.0";
            txtNar.Clear();
            txtSEARCH.Clear();
            cmbACCOUNT.SelectedIndex = 0;
            dtp_DATE.Focus();
            gv_id = "";
            grdENTRY.Rows.Clear();
            is_edit = 0;
        }

        private void show_report()
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

        private void add_clear()
        {
            txtDEBIT.Text = "0.0";
            txtCREDIT.Text = "0.0";
            cmbACCOUNT.SelectedIndex = 0;
            cmbACCOUNT.Focus();
        }

        //get data from grid on click
        private void load_data_fromGrid(DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.grdSEARCH.Rows[e.RowIndex];
                    gv_id = row.Cells[0].Value.ToString();
                    is_edit = 1;
                    dtp_DATE.Value = DateTime.Parse(row.Cells[1].Value.ToString());
                    lblTV.Text = row.Cells[2].Value.ToString();
                    lblTrNo.Text = row.Cells[3].Value.ToString();
                    txtNar.Text = row.Cells[4].Value.ToString();
                    cls_GV.get_voucher_details(gv_id, grdENTRY);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        }

        private int debit_credit_sum()
        {
            if (grdENTRY.Rows.Count > 0)
            {
                float debit = 0;
                float credit = 0;
                for (int i = 0; i < grdENTRY.Rows.Count; ++i)
                {
                    debit += float.Parse(grdENTRY.Rows[i].Cells[2].Value.ToString());
                    credit += float.Parse(grdENTRY.Rows[i].Cells[3].Value.ToString());
                }
                if (debit - credit == 0)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            return 0;
        }

        string query = "";
        private void save()
        {
            if (grdENTRY.Rows.Count <= 0)
            {
                cls_fhp.ShowMessageBox("No entries found in table to save", "error");
                //essageBox.Show("No entries found in table to save, please add voucher entry.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txtNar.Text.Trim().Equals(""))
            {
                cls_fhp.ShowMessageBox("Narration field is left blank", "error");
                //essageBox.Show("Narration field is blank.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (debit_credit_sum() == 1)
            {
                cls_fhp.ShowMessageBox("Debit amount and Credit amount are not equal", "error");
                //essageBox.Show("Debit amount and Credit amount are not equal.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                query = "IF EXISTS (select GV_ID from GENERAL_VOUCHER_M WHERE GV_ID = '" + gv_id + "') UPDATE GENERAL_VOUCHER_M SET DAATE = '" + dtp_DATE.Value.ToString() + "',NARRATION = '" + cls_fhp.AvoidInjection(txtNar.Text) + "',  MODIFICATION_DATE = GETDATE(), MODIFIED_BY = '" + Classes.Helper.userId + "' WHERE GV_ID = '" + gv_id + "' ELSE INSERT INTO GENERAL_VOUCHER_M VALUES('" + lblTV.Text + "','" + lblTrNo.Text + "','" + dtp_DATE.Value.ToString() + "','" + cls_fhp.AvoidInjection(txtNar.Text) + "','" + Classes.Helper.userId + "',GETDATE(),NULL,'00')";
                int i = 0;
                int x = 0;
                if (cls_GV.save_Gv_details(query) >= 1)
                {
                    query = "DELETE FROM GENERAL_VOUCHER_D WHERE GV_ID = '" + gv_id + "'";
                    if (cls_GV.save_Gv_details(query) >= 0)
                    {
                        i = 0;

                        foreach (DataGridViewRow rows in grdENTRY.Rows)
                        {
                            query = "INSERT INTO GENERAL_VOUCHER_D VALUES((SELECT MAX(GV_ID) FROM GENERAL_VOUCHER_M),'" + rows.Cells[0].Value.ToString() + "','" + rows.Cells[2].Value.ToString() + "','" + rows.Cells[3].Value.ToString() + "')";
                            if (cls_GV.save_Gv_details(query) >= 1)
                            {
                                //i = cls_GV.insert_ledger_entry(dtp_DATE.Value.ToString(), Int32.Parse(rows.Cells[0].Value.ToString()), 
                                //gv_id, "GENERAL VOUCHER", float.Parse(rows.Cells[2].Value.ToString()), 
                                //float.Parse(rows.Cells[3].Value.ToString()), cls_fhp.AvoidInjection(txtNar.Text));

                                if (x == 0)
                                {
                                    query = @"IF EXISTS (SELECT REF_ID FROM LEDGERS WHERE REF_ID = '" + gv_id + @"')
                                BEGIN
                                DELETE FROM LEDGERS WHERE REF_ID = '" + gv_id + @"' AND ENTRY_OF = 'GENERAL VOUCHER'
                                INSERT INTO LEDGERS VALUES('" + dtp_DATE.Value.ToString() + "', '" + Int32.Parse(rows.Cells[0].Value.ToString()) + @"',
                                '" + gv_id + @"', 'GENERAL VOUCHER',
                                '" + float.Parse(rows.Cells[2].Value.ToString()) + "','" + float.Parse(rows.Cells[3].Value.ToString()) + "','" + cls_fhp.AvoidInjection(txtNar.Text) + "','" + Classes.Helper.userId + @"',
                                '" + DateTime.Now + @"',NULL,'00');
                                END
                                ELSE
                                BEGIN
                                DELETE FROM LEDGERS WHERE REF_ID = '" + gv_id + @"' AND ENTRY_OF = 'GENERAL VOUCHER'
                                INSERT INTO LEDGERS VALUES('" + dtp_DATE.Value.ToString() + "', '" + Int32.Parse(rows.Cells[0].Value.ToString()) + @"',
                                (SELECT MAX(GV_ID) FROM GENERAL_VOUCHER_M),'GENERAL VOUCHER',
                                '" + float.Parse(rows.Cells[2].Value.ToString()) + "','" + float.Parse(rows.Cells[3].Value.ToString()) + "','" + cls_fhp.AvoidInjection(txtNar.Text) + "','" + Classes.Helper.userId + @"',
                                '" + DateTime.Now + @"',NULL,'00');
                                END";
                                }
                                else
                                {
                                    query = @"IF EXISTS (SELECT REF_ID FROM LEDGERS WHERE REF_ID = '" + gv_id + @"')
                                BEGIN
                                INSERT INTO LEDGERS VALUES('" + dtp_DATE.Value.ToString() + "', '" + Int32.Parse(rows.Cells[0].Value.ToString()) + @"',
                                '" + gv_id + @"', 'GENERAL VOUCHER',
                                '" + float.Parse(rows.Cells[2].Value.ToString()) + "','" + float.Parse(rows.Cells[3].Value.ToString()) + "','" + cls_fhp.AvoidInjection(txtNar.Text) + "','" + Classes.Helper.userId + @"',
                                '" + DateTime.Now + @"',NULL,'00');
                                END
                                ELSE
                                BEGIN
                                INSERT INTO LEDGERS VALUES('" + dtp_DATE.Value.ToString() + "', '" + Int32.Parse(rows.Cells[0].Value.ToString()) + @"',
                                (SELECT MAX(GV_ID) FROM GENERAL_VOUCHER_M),'GENERAL VOUCHER',
                                '" + float.Parse(rows.Cells[2].Value.ToString()) + "','" + float.Parse(rows.Cells[3].Value.ToString()) + "','" + cls_fhp.AvoidInjection(txtNar.Text) + "','" + Classes.Helper.userId + @"',
                                '" + DateTime.Now + @"',NULL,'00');
                                END";
                                }

                                x = cls_fhp.InsertUpdateDelete(query);

                                if (!rows.Cells[4].Value.ToString().Equals("-") && !rows.Cells[5].Value.ToString().Equals("-"))
                                {
                                    if (rows.Cells[5].Value.ToString().Equals("PUR"))
                                    {
                                        save_pur_invoice_record(rows.Cells[0].Value.ToString(), rows.Cells[3].Value.ToString(), rows.Cells[4].Value.ToString());
                                    }
                                    else if (rows.Cells[5].Value.ToString().Equals("SALE"))
                                    {
                                        save_sale_invoice_record(rows.Cells[0].Value.ToString(), rows.Cells[2].Value.ToString(), rows.Cells[4].Value.ToString());
                                    }
                                }
                            }
                            i = x;
                            if (gv_id.Equals(""))
                            {
                                query = "INSERT INTO TRANSACTION_LOG VALUES('GENERAL VOUCHER','NEW GENERAL VOUCHER',(SELECT MAX(GV_ID) FROM GENERAL_VOUCHER_M),GETDATE()," + Classes.Helper.userId + ") ";
                                cls_fhp.InsertUpdateDelete(query);
                            }
                            else
                            {
                                query = "INSERT INTO TRANSACTION_LOG VALUES('GENERAL VOUCHER','NEW GENERAL VOUCHER','" + gv_id + "',GETDATE()," + Classes.Helper.userId + ") ";
                                cls_fhp.InsertUpdateDelete(query);
                            }
                        }
                    }
                    if (i > 0)
                    {
                        cls_fhp.ShowMessageBox("Record Saved Sucessfully!", "success");
                        //essageBox.Show("Record Saved Sucessfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        show_report();
                        clear();
                        cls_GV.load_trv_grid(grdSEARCH);
                    }
                }

            }
        }

        private int save_pur_invoice_record(string coa_id, string amount, string inv_no)
        {
            int i = 0;
            query = @"IF EXISTS (select VOUCHER_ID from INVOICES_DETAILS WHERE VOUCHER_OF = 'JV' AND VOUCHER_ID = '" + gv_id + @"') 
                    UPDATE INVOICES_DETAILS SET DAATE = '" + dtp_DATE.Value.ToString() + "',COA_ID = '" + coa_id + @"',
                    AMOUNT = '" + amount + "' WHERE VOUCHER_ID = '" + gv_id + @"' 
                    ELSE 
                    INSERT INTO INVOICES_DETAILS VALUES('" + dtp_DATE.Value.ToString() + "','PURCHASES','" + coa_id + "','" + inv_no + "',(SELECT MAX(GV_ID) FROM GENERAL_VOUCHER_M),'JV','" + amount + @"');
                    UPDATE PURCHASES SET REC_AMT = (SELECT SUM(AMOUNT) FROM INVOICES_DETAILS WHERE PAY_OF = 'PURCHASES' AND INVOICE_NO = '" + inv_no + "') WHERE P_ID = '" + inv_no + "'";
            i = cls_fhp.InsertUpdateDelete(query);
            return i;
        }
        private int save_sale_invoice_record(string coa_id, string amount, string inv_no)
        {
            int i = 0;
            query = @"IF EXISTS (select VOUCHER_ID from INVOICES_DETAILS WHERE VOUCHER_OF = 'JV' AND VOUCHER_ID = '" + gv_id + @"') 
                    UPDATE INVOICES_DETAILS SET DAATE = '" + dtp_DATE.Value.ToString() + "',COA_ID = '" + coa_id + @"',
                    AMOUNT = '" + amount + "' WHERE VOUCHER_ID = '" + gv_id + @"' 
                    ELSE 
                    INSERT INTO INVOICES_DETAILS VALUES('" + dtp_DATE.Value.ToString() + "','SALES','" + coa_id + "','" + inv_no + "',(SELECT MAX(GV_ID) FROM GENERAL_VOUCHER_M),'JV','" + amount + @"');
                    UPDATE SALES_M SET REC_AMT = (SELECT SUM(AMOUNT) FROM INVOICES_DETAILS WHERE PAY_OF = 'SALES' AND INVOICE_NO = '" + inv_no + "') WHERE SM_ID = '" + inv_no + "'";
            i = cls_fhp.InsertUpdateDelete(query);
            return i;
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {

        }

        private void frm_BankTr_Load(object sender, EventArgs e)
        {
            try
            {
                cls_GV.load_trv_grid(grdSEARCH);
                cls_GV.load_accounts(cmbACCOUNT);
                //cls_GV.load_accounts(cmbCREDIT);
                cls_GV.generate_transaction_no(lblTrNo);
                cls_GV.generate_voucher_no(lblTV);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        }

        private void txtSEARCH_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cls_GV.cvr_grid_search(txtSEARCH, grdSEARCH);
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
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            cls_fhp.AllowNumbers(e);
        }

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            cls_GV.check_blank_zero(sender as TextBox);
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

        private void lblAmt_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtDEBIT_TextChanged(object sender, EventArgs e)
        {
            if (!txtCREDIT.Text.Equals("0.0") && is_edit == 0)
            {
                txtCREDIT.Text = "0.0";
            }
        }

        private void txtCREDIT_TextChanged(object sender, EventArgs e)
        {
            if (!txtDEBIT.Text.Equals("0.0") && is_edit == 0)
            {
                txtDEBIT.Text = "0.0";
            }
        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbACCOUNT.SelectedIndex == 0)
                {
                    cls_fhp.ShowMessageBox("Account is not selected", "error");
                    //essageBox.Show("Account is not selected, please select account.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbACCOUNT.Focus();
                }
                else if (float.Parse(txtDEBIT.Text) <= 0 && float.Parse(txtCREDIT.Text) <= 0)
                {
                    cls_fhp.ShowMessageBox("Amount field is zero", "error");
                    //essageBox.Show("Amount field is zero.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDEBIT.Focus();
                }
                else if (rdbINV_REC.Checked == true && cmbSELECT_INV.SelectedIndex == 0)
                {
                    cls_fhp.ShowMessageBox("Invoice is not selected", "error");
                    //essageBox.Show("Invoice is not selected, please select invoice.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbSELECT_INV.Focus();
                }
                else if (rdbPAY.Checked == true && cmbSELECT_INV.SelectedIndex == 0)
                {
                    cls_fhp.ShowMessageBox("Invoice is not selected", "error");
                    //essageBox.Show("Invoice is not selected, please select invoice.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbSELECT_INV.Focus();
                }
                else
                {
                    if (rdbINV_REC.Checked == true && cmbSELECT_INV.Enabled == true)
                    {
                        string msg = cls_fhp.getSale_Invoice_Bal(cmbSELECT_INV.SelectedValue.ToString(), float.Parse(txtDEBIT.Text));
                        if (!msg.Equals("OK"))
                        {
                            MessageBox.Show(msg);
                            return;
                        }
                        grdENTRY.Rows.Add(cmbACCOUNT.SelectedValue.ToString(), cmbACCOUNT.Text, txtDEBIT.Text, txtCREDIT.Text, cmbSELECT_INV.SelectedValue.ToString(), "SALE");
                    }

                    else if (rdbPAY.Checked == true && cmbSELECT_INV.Enabled == true)
                    {
                        string msg = cls_fhp.getPur_Invoice_Bal(cmbSELECT_INV.SelectedValue.ToString(), float.Parse(txtCREDIT.Text));
                        if (!msg.Equals("OK"))
                        {
                            MessageBox.Show(msg);
                            return;
                        }
                        grdENTRY.Rows.Add(cmbACCOUNT.SelectedValue.ToString(), cmbACCOUNT.Text, txtDEBIT.Text, txtCREDIT.Text, cmbSELECT_INV.SelectedValue.ToString(), "PURCHASES");
                    }
                    else
                    {
                        grdENTRY.Rows.Add(cmbACCOUNT.SelectedValue.ToString(), cmbACCOUNT.Text, txtDEBIT.Text, txtCREDIT.Text, "-", "-");
                    }
                    add_clear();
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        }

        private void grdENTRY_Click(object sender, EventArgs e)
        {

        }

        private void grdENTRY_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.grdENTRY.Rows[e.RowIndex];
                    cmbACCOUNT.SelectedValue = row.Cells[0].Value.ToString();
                    cmbACCOUNT.Focus();

                    if (!row.Cells[4].Value.ToString().Equals("-") && !row.Cells[5].Value.ToString().Equals("-"))
                    {
                        if (row.Cells[5].Value.ToString().Equals("PURCHASES"))
                        {
                            rdbINV_REC.Checked = false;
                            rdbPAY.Checked = true;
                            rdbOTHERS.Checked = false;
                            cls_fhp.load_all_purchases_invoices(cmbSELECT_INV, row.Cells[0].Value.ToString());
                            cmbSELECT_INV.SelectedValue = row.Cells[4].Value.ToString();
                        }
                        else if (row.Cells[5].Value.ToString().Equals("SALE"))
                        {
                            rdbINV_REC.Checked = true;
                            rdbPAY.Checked = false;
                            rdbOTHERS.Checked = false;
                            cls_fhp.load_all_sale_invoices(cmbSELECT_INV, row.Cells[0].Value.ToString());
                            cmbSELECT_INV.SelectedValue = row.Cells[4].Value.ToString();
                        }
                        else
                        {
                            cmbSELECT_INV.SelectedIndex = 0;
                            cmbSELECT_INV.Enabled = false;
                            rdbINV_REC.Checked = false;
                            rdbPAY.Checked = false;
                            rdbOTHERS.Checked = true;
                        }
                    }

                    txtDEBIT.Text = row.Cells[2].Value.ToString();
                    txtCREDIT.Text = row.Cells[3].Value.ToString();
                    grdENTRY.Rows.RemoveAt(e.RowIndex);
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

        private void txtNar_Leave(object sender, EventArgs e)
        {
            cls_fhp.textField_leave(sender as TextBox);
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

        private void rdbINV_REC_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbINV_REC.Checked == true && rdbOTHERS.Checked == false && rdbPAY.Checked == false)
                {
                    cmbSELECT_INV.Enabled = true;
                    cls_fhp.load_sale_invoices(cmbSELECT_INV, cmbACCOUNT.SelectedValue.ToString());
                    txtDEBIT.Enabled = true;
                    txtCREDIT.Enabled = false;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbPAY.Checked == true && rdbOTHERS.Checked == false && rdbINV_REC.Checked == false)
                {
                    cmbSELECT_INV.Enabled = true;
                    cls_fhp.load_purchases_invoices(cmbSELECT_INV, cmbACCOUNT.SelectedValue.ToString());
                    txtDEBIT.Enabled = false;
                    txtCREDIT.Enabled = true;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        }

        private void rdbOTHERS_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbINV_REC.Checked == false && rdbOTHERS.Checked == true)
                {
                    cmbSELECT_INV.Enabled = false;
                    txtDEBIT.Enabled = true;
                    txtCREDIT.Enabled = true;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        }

        private void cmbACCOUNT_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbINV_REC.Checked == true && rdbOTHERS.Checked == false && rdbPAY.Checked == false)
                {
                    cmbSELECT_INV.Enabled = true;
                    if (is_edit == 0) { cls_fhp.load_sale_invoices(cmbSELECT_INV, cmbACCOUNT.SelectedValue.ToString()); }
                }
                else if (rdbPAY.Checked == true && rdbOTHERS.Checked == false && rdbINV_REC.Checked == false)
                {
                    cmbSELECT_INV.Enabled = true;
                    if (is_edit == 0) { cls_fhp.load_purchases_invoices(cmbSELECT_INV, cmbACCOUNT.SelectedValue.ToString()); }
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

        private void btn_VIEW_VOUCHER_Click(object sender, EventArgs e)
        {
            try
            {
                if (cls_fhp.CheckNameExists(grdSEARCH, lblTV.Text, 2) == 1)
                { show_report(); }
                else
                {
                    cls_fhp.ShowMessageBox("Record Not Found To Print", "error");
                    //essageBox.Show("Record Not Found To Print.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        }

        private void frm_General_Voucher_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
