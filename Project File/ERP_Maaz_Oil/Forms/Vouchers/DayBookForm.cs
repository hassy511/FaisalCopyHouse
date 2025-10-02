using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace ERP_Maaz_Oil.Vouchers
{
    public partial class DayBookForm : Form
    {
        Forms.Vouchers.Voucher voucher = new Forms.Vouchers.Voucher();
        Classes.Helper db = new Classes.Helper();
        List<string> addedChqs = new List<string>();
        DayBook dayBook = new DayBook();
        //Others.Validation valid = new Others.Validation();
    
        string chqId = "";
        int rowEdit = -1;
        string refNum = "";
        string refID = "";
        string daybookID = "";
        string paybookID = "";
        string gv_id = "";
        int is_edit = 0;
        int isEdit = -1;
        string ID;
        //List<string> list = new List<string>();
        //List<string> listDeposit = new List<string>();
        //List<string> listReturn = new List<string>();

        public DayBookForm()
        {
            InitializeComponent();
        }

        private void dayControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (dayControl.SelectedTab.Text.Equals("Receipts"))
                {
                    loadReceipt();
                }
                else if (dayControl.SelectedTab.Text.Equals("Payments"))
                {
                    
                    loadPayment();
                }
                else if (dayControl.SelectedTab.Text.Equals("General Entry"))
                {
                    loadGE();
                }
                else if (dayControl.SelectedTab.Text.Equals("Cheque Deposit"))
                {
                    //loadCD();
                }
                else if (dayControl.SelectedTab.Text.Equals("Cheque Return"))
                {
                    loadCR();
                }
                else if(dayControl.SelectedTab.Text.Equals("Recovery Details"))
                {
                    loadRecovery();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void loadRecovery()
        {
            try
            {
                dayBook.loadRecoveryPerson(cmbRecoveryDetailsPerson);
                dayBook.loadRecoveryDetails(grdRecoveryDetails, cmbRecoveryDetailsPerson.SelectedValue.ToString(),dtpFrom.Value.ToString("yyyy-MM-dd"), dtpTo.Value.ToString("yyyy-MM-dd"));


            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void loadReceipt()
        {
            try {
                dayBook.loadReceiptGrid(ReceiptsGrid);
                dayBook.loadReceipt(cmbBankReceipt);
                dayBook.loadAllAccounts(cmbReceipt);
                //dayBook.loadBank(cmbBankReceipt);
                Classes.cls_Payment_Transfer cls_pt = new Classes.cls_Payment_Transfer();
                //cls_pt.load_bank(cmbBankReceipt);
                generateRVNum(lblVoucherNumRV);
                //dayBook.loadRecoveryPerson(cmbRecoveryPerson);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        public void generateRVNum(Label lbl)
        {
            string query = "SELECT ISNULL(COUNT(DAY_BOOK_ID)+1,1) FROM DAY_BOOK";
            if (lbl.Name.Equals("lblVoucherNumPV"))
                lbl.Text = "PVO-" + db.GenerateVoucherCode(query) + "-" + DateTime.Now.Year;
            else
                lbl.Text = "RV-" + db.GenerateVoucherCode(query) + "-" + DateTime.Now.Year;
            lbl.Refresh();            
        }

        public string generateCRNum()
        {
            string query = "select isnull(count(LEGDER_ID)+1,1) from LEDGERS where ENTRY_OF = 'CHQ RETUN' and CREDIT = 00";
            return "CRTN-" + db.GenerateVoucherCode(query) + "-" + DateTime.Now.Year;

        }


        private void loadPayment()
        {
            try
            {
                dayBook.loadPayments(PaymentGrid);
                //dayBook.loadBank(txtBankPayment);
                //dayBook.loadReceipt(cmbBankPayment);
                dayBook.loadAllAccounts(cmbSupplierPay);
                //dayBook.loadAllAccounts(cmbCustomerPay);
                //dayBook.loadChqsReceived(cmbChqNoPay);
                generateRVNum(lblVoucherNumPV);
                //dayBook.loadPayGrid(grdPayment);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }
        private void DayBookForm_Load(object sender, EventArgs e)
        {
            if (Classes.Helper.userId == 4)
            {
                tabPage1.Enabled = false;
                tabPage2.Enabled = false;
                tabPage4.Enabled = false;
                tabPage5.Enabled = false;
                recPersonTab.Enabled = false;
            }
            loadReceipt();
        }

        //Genral

        private void loadGE()
        {
            try
            {
                refNum = dayBook.getNum().ToString();
                dayBook.loadEntryGrid(EntryGrid);
                dayBook.loadDebit(cmbAccountGV);
                dayBook.loadCredit(cmbCredit);
                generate_voucher_no(lblGV);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }
        private void Generalclear()
        {
            try {
                dtpDate.ResetText();
                cmbAccountGV.SelectedValue = 0;
                cmbCredit.SelectedValue = 0;
                txtDebitGV.Text = "0";
                txtNarration.Clear();
                refNum = dayBook.getNum().ToString();
                refID = "";
                txtDebitTotalGV.Text = "0";
                txtCreditTotalGV.Text = "0";
                isEdit = -1;
                grdENTRY.Rows.Clear();
                generate_voucher_no(lblGV);
                gv_id = ""; 
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }
        private void btnClr_Click(object sender, EventArgs e)
        {
            Generalclear();
        }

        private void txtPrice_Enter(object sender, EventArgs e)
        {
            txtDebitGV.SelectAll();
        }

        private void txtPrice_Click(object sender, EventArgs e)
        {
            txtDebitGV.SelectAll();
        }

        public void generate_voucher_no(Label lbl)
        {
            string query = "SELECT ISNULL(COUNT(GV_ID)+1,1) FROM GENERAL_VOUCHER_M";
            lbl.Text = "JV-" + db.GenerateVoucherCode(query) + "-" + DateTime.Now.Year;
            lbl.Refresh();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try {
                if(!txtDebitTotalGV.Text.Equals(txtCreditTotalGV.Text))
                {
                    MessageBox.Show("Debit and Credit not equal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if(grdENTRY.RowCount==0)
                {
                    MessageBox.Show("No entries to save", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string query = @"BEGIN TRY 
                            declare @mid int = '" + gv_id + @"';
                             BEGIN TRANSACTION ";
                    //if (!gv_id.Equals("0") && !gv_id.Equals(""))
                    query += @"IF EXISTS (select GV_ID from GENERAL_VOUCHER_M WHERE GV_ID = '" + gv_id + @"') 
                    BEGIN
                    UPDATE GENERAL_VOUCHER_M SET DAATE = '" + Classes.Helper.ConvertDatetime(dtpDate.Value) + "',NARRATION = '" + db.AvoidInjection(txtNarration.Text) + "',  MODIFICATION_DATE = getdate(), MODIFIED_BY = '" + 1 + @"' 
                    WHERE GV_ID = '" + gv_id + @"';
                    END
                    ELSE
                    BEGIN
                    INSERT INTO GENERAL_VOUCHER_M (GV_CODE,DAATE,NARRATION,CREATED_BY,CREATION_DATE)
                    VALUES('" + lblGV.Text + "','" + Classes.Helper.ConvertDatetime(dtpDate.Value) + "', '" + db.AvoidInjection(txtNarration.Text) + "', '" + 1 + @"', getdate());
                    set @mid =(SELECT SCOPE_IDENTITY());
                    END; ";
                    //else

                    //int i = 0;
                    //int x = 0;
                    //if (cls_GV.save_Gv_details(query) >= 1)
                    //{
                    query += @"DELETE FROM GENERAL_VOUCHER_D WHERE GV_ID = @mid;";
                    query += @"DELETE FROM LEDGERS WHERE REF_ID = @mid AND ENTRY_OF = 'GENERAL VOUCHER';";
                    //if (cls_GV.save_Gv_details(query) >= 0)
                    //{
                    //i = 0;
                    //string id = "";
                    foreach (DataGridViewRow rows in grdENTRY.Rows)
                    {

                        query += "INSERT INTO GENERAL_VOUCHER_D VALUES(@mid,'" + rows.Cells["COA_ID"].Value.ToString() + "','" + rows.Cells[2].Value.ToString() + "','" + rows.Cells[3].Value.ToString() + "','"+ rows.Cells["DESCRIPTION"].Value.ToString() + "')";
                        query += @"INSERT INTO LEDGERS (DATE,COA_ID,REF_ID,ENTRY_OF,FOLIO,DEBIT,CREDIT,DESCRIPTIONS,CREATED_BY,CREATION_DATE)
                                VALUES('" + Classes.Helper.ConvertDatetime(dtpDate.Value) + "', '" + rows.Cells["COA_ID"].Value.ToString() + @"',
                                @mid, 'GENERAL VOUCHER','" + lblGV.Text + "','" + (rows.Cells[2].Value.ToString()) + "','" + (rows.Cells[3].Value.ToString()) + "','" + rows.Cells["DESCRIPTION"].Value.ToString() + "','" + 1 + @"',
                                GETDATE());";

                    }

                    query += @" COMMIT TRANSACTION 
                        END TRY 
                    BEGIN CATCH 
                            IF @@TRANCOUNT > 0 
                            ROLLBACK 
                        TRANSACTION 
                    END CATCH";
                        
                    if (db.InsertUpdateDelete(query) > 0)
                    {
                        MessageBox.Show("Record Save Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        show_report();
                        Generalclear();
                        loadGE();
                    }
                    //        string query = @"INSERT INTO LEDGERS VALUES('" + data[0] + "','" + data[4] + "','" + data[1] + "','','GENERAL ENTRY','" + data[3] + @"',0);
                    //INSERT INTO LEDGERS VALUES('" + data[0] + "','" + data[4] + "','" + data[2] + "','','GENERAL ENTRY',0,'" + data[3] + "');";

                    //string[] data = { dtpDate.Value.ToString(), cmbDebit.SelectedValue.ToString(), cmbCredit.SelectedValue.ToString(), txtPrice.Text, valid.AvoidInjection(txtDescriptions.Text) };
                    //if (dayBook.saveGeneral(data) == 1)
                    //{
                    //    MessageBox.Show("Information", "Record Save Successfully.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void rowClear() {
            txtAmnt.Text = "0";
            //cmbBankReceipt.Items.Clear();
            txtChqNo.Clear();
        }

        //Receipts
        private void btAddReceipt_Click(object sender, EventArgs e)
        {
            if (db.record_search_grid(ReceiptsGrid, txtChqNo.Text, 11) == 1) {
                MessageBox.Show("Chq No already update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtAmnt.Text.Equals("") || cmbBankReceipt.Text.Equals("") || txtChqNo.Text.Equals(""))
            {
                MessageBox.Show("Fill all Fields","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else if(cmbBankReceipt.Text.Contains("SELECT"))
            {
                MessageBox.Show("Enter correct bank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {
                grdReceipt.Rows.Add("",dtpCredit.Value, cmbReceipt.Text, txtAmnt.Text, db.AvoidInjection(cmbBankReceipt.Text), db.AvoidInjection(txtChqNo.Text),"");
                txtChqTotal.Text = grdReceipt.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToDecimal(t.Cells["AmntReceipt"].Value)).ToString();
                rowClear();
            }
        }

        private void cmbDebitReceipt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBank.SelectedValue.ToString().Equals("0"))
            {
                txtBankAmount.Enabled = false;
            }
            else {
                txtBankAmount.Enabled = true;
            }
            //if (cmbBank.Text.Equals("CHQ IN HAND"))
            //{
            //    grpCedit.Enabled = true;
            //    chq = "CHQ";
            //}
            //else
            //{
            //    grpCedit.Enabled = false;
            //    chq = "";
            //}
        }

        private void btnSAVEReceipt_Click(object sender, EventArgs e)
        {
            try
            {
                //if (cmbBank.SelectedValue.ToString().Equals("0"))
                //{
                //    MessageBox.Show("Select Receving Ac","Error",MessageBoxButtons.OK,MessageBoxIcon.Information);
                //    cmbBank.Focus();
                //}
                //else 
                if (cmbReceipt.SelectedValue.ToString().Equals("0"))
                {
                    MessageBox.Show("Select Customer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbReceipt.Focus();
                }
                else if (txtAmountReceipt.Text.Equals(""))
                {
                    MessageBox.Show("Enter Amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAmountReceipt.Focus();
                }
                else if (Convert.ToDecimal(txtAmountReceipt.Text) != (Convert.ToDecimal(txtCashAmount.Text) + Convert.ToDecimal(txtChqTotal.Text)))
                {
                    MessageBox.Show("Amount is not valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAmountReceipt.Focus();
                }
                //else if(cmbRecoveryPerson.SelectedIndex <=0)
                //{
                //    MessageBox.Show("Recovery Person not selected or added.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
              
                else
                {
                    string id="0";
                    if (daybookID.Equals(""))
                    {
                        id = "(SELECT MAX(DAY_BOOK_ID) FROM DAY_BOOK)";
                    }
                    else
                    {
                        id = daybookID;
                    }
                    string query = @"BEGIN TRY 
                             BEGIN TRANSACTION ";

                    

                    query += @"IF EXISTS 
                        (SELECT DAY_BOOK_ID FROM DAY_BOOK WHERE DAY_BOOK_ID='" + daybookID + @"' AND ENTRY_OF = 'RECEIPT VOUCHER') 
                    BEGIN 
                        UPDATE DAY_BOOK SET DATE='" + Classes.Helper.ConvertDatetime(dtpReceipt.Value.Date) + @"',
                        DEBIT_AC=(SELECT COA_ID FROM COA WHERE COA_NAME = 'CHQ IN HAND'),
                        CREDIT_AC='" + cmbReceipt.SelectedValue.ToString() + "',AMOUMT='" + txtAmountReceipt.Text + @"',
                        DESCRIPTION='" + txtDescriptRece.Text + "',CASH_AMOUNT='" + txtCashAmount.Text + @"',
                        BANK_AMOUNT='" + txtBankAmount.Text + @"',MODIFICATION_DATE=GETDATE(),MODIFIED_BY='1',
                        REC_PERSON_ID='1'  
                        WHERE DAY_BOOK_ID='" + daybookID + @"' AND ENTRY_OF='RECEIPT VOUCHER'; 
                    END 
                    ELSE 
                    BEGIN
                        INSERT INTO DAY_BOOK VALUES('" + Classes.Helper.ConvertDatetime(dtpReceipt.Value.Date) + @"',
                        'RECEIPT VOUCHER',(SELECT COA_ID FROM COA WHERE COA_NAME = 'CHQ IN HAND'),
                        '" + cmbReceipt.SelectedValue.ToString() + "','" + txtAmountReceipt.Text + @"',
                        '" + txtDescriptRece.Text + "',GETDATE(),'1',NULL,NULL,'" + txtCashAmount.Text + @"',
                        '" + txtBankAmount.Text + @"','1','-');
                    END";
                    
                    //if (Convert.ToDecimal(txtBankAmount.Text) > 0)
                    //{
                    //    query += @" INSERT INTO LEDGERS (DATE,DESCRIPTIONS,COA_ID,REF_ID,ENTRY_OF,DEBIT,CREDIT,CREATED_BY,CREATION_DATE,COMPANY_ID) 
                    //    VALUES ('" + Classes.Helper.ConvertDatetime(dtpReceipt.Value.Date) + "','RECEIPT PAYMENT IN " + cmbBank.Text + " BANK : (" + txtDescriptRece.Text + ")'," + "(SELECT COA_ID FROM COA WHERE COA_NAME = 'CHQ IN HAND')" + @",
                    //    " + id + ",'RECEIPT VOUCHER','" + txtBankAmount.Text + @"','0',1,GETDATE(),1); ";

                    //    query += @" INSERT INTO LEDGERS (DATE,DESCRIPTIONS,COA_ID,REF_ID,ENTRY_OF,DEBIT,CREDIT,CREATED_BY,CREATION_DATE,COMPANY_ID) 
                    //    VALUES ('" + Classes.Helper.ConvertDatetime(dtpReceipt.Value.Date) + "','RECEIPT PAYMENT IN " + cmbBank.Text + " BANK : (" + txtDescriptRece.Text + ")'," + "(SELECT COA_ID FROM COA WHERE COA_NAME = 'CHQ IN HAND')" + @",
                    //    " + id + ",'RECEIPT VOUCHER','0','" + txtBankAmount.Text + @"',1,GETDATE(),1); ";
                    //}
                    //chq status 1 for pending 0 for paid
                    if (Convert.ToDecimal(txtChqTotal.Text) > 0)
                    {
                        if (grdReceipt.Rows.Count > 0)
                        {
                            query += @" DELETE FROM CHQ WHERE CHQ_ID IN 
                                (SELECT CHQ_ID FROM DAY_BOOK_CHQ WHERE DAY_BOOK_ID=" + id + @") and [status] = 1;
                            DELETE FROM DAY_BOOK_CHQ WHERE DAY_BOOK_ID = " + id + " and CHQ_ID not in (select chq_id from CHQ where [STATUS] = 1)";
                            foreach (DataGridViewRow item in grdReceipt.Rows)
                            {
                                query += @" IF NOT EXISTS(SELECT CHQ_ID FROM CHQ WHERE CHQ_ID = '"+ item.Cells["chqID"].Value.ToString() + @"')
                                BEGIN                                
                                INSERT INTO CHQ VALUES('" + item.Cells["DATE1"].Value.ToString() + @"',
                                '" + item.Cells["CHQNO"].Value.ToString() + "','" + item.Cells["AmntReceipt"].Value.ToString() + @"',
                                '" + cmbReceipt.SelectedValue.ToString() + "',NULL,'" + item.Cells["Bank1"].Value.ToString() + @"',
                                1,null,'"+dtpReceipt.Value+@"'); 

                                INSERT INTO DAY_BOOK_CHQ VALUES((SELECT MAX(CHQ_ID) FROM CHQ)," + id + @",'R'); 
                                END";

                                //query += @" INSERT INTO LEDGERS (DATE,DESCRIPTIONS,COA_ID,REF_ID,ENTRY_OF,DEBIT,CREDIT,CREATED_BY,CREATION_DATE,COMPANY_ID) VALUES 
                                //('" + Classes.Helper.ConvertDatetime(dtpReceipt.Value.Date) + "','RECEIPT " + item.Cells["Bank1"].Value.ToString() + " CHQ #: " + item.Cells["CHQNO"].Value.ToString() + @"',(SELECT COA_ID FROM COA WHERE COA_NAME = 'CHQ IN HAND'),
                                //" + id + ",'RECEIPT VOUCHER','" + item.Cells["AmntReceipt"].Value.ToString() + @"','0',1,GETDATE(),1); ";

                                //query += @" INSERT INTO LEDGERS (DATE,DESCRIPTIONS,COA_ID,REF_ID,ENTRY_OF,DEBIT,CREDIT,CREATED_BY,CREATION_DATE,COMPANY_ID) VALUES ('" + Classes.Helper.ConvertDatetime(dtpReceipt.Value.Date) + "','RECEIPT " + item.Cells["Bank1"].Value.ToString() + " CHQ #: " + item.Cells["CHQNO"].Value.ToString() + @"','" + cmbReceipt.SelectedValue.ToString() + @"',
                                //" + id + ",'RECEIPT VOUCHER','0','" + item.Cells["AmntReceipt"].Value.ToString() + @"',1,GETDATE(),1); ";
                            }
                        }
                    }

                    foreach (DataGridViewRow row in grdReceipt.Rows)
                    {
                        query += @"
                                  DELETE FROM RECOVERY_DETAILS WHERE CHQ_NO = '" + row.Cells["CHQNO"].Value.ToString() + "'";

                        query += @"
                                INSERT INTO RECOVERY_DETAILS VALUES('1',(SELECT COA_ID FROM COA WHERE COA_NAME = '" + row.Cells["NAME"].Value.ToString() + @"'),
                                '" + row.Cells["CHQNO"].Value.ToString() + "','" + txtCashAmount.Text + "','"+ Classes.Helper.ConvertDatetime(dtpReceipt.Value.Date)+"'); ";
                    }

                    query += @" DELETE FROM LEDGERS WHERE REF_ID = " + id + " AND ENTRY_OF = 'RECEIPT VOUCHER CASH';";
                    if (Convert.ToDecimal(txtCashAmount.Text) > 0)
                    {
                        query += @" INSERT INTO LEDGERS (DATE,DESCRIPTIONS,COA_ID,REF_ID,ENTRY_OF,DEBIT,CREDIT,CREATED_BY,CREATION_DATE,COMPANY_ID,REF_AC_ID,FOLIO) 
                        VALUES ('" + Classes.Helper.ConvertDatetime(dtpReceipt.Value.Date) + "','" + txtDescriptRece.Text + @"','"+Classes.Helper.cashId+@"',
                        " + id + ",'RECEIPT VOUCHER CASH','" + txtCashAmount.Text + @"','0',1,GETDATE(),1,'"+ db.AvoidInjection(subAccTxt.Text)+ @"','"+lblVoucherNumRV.Text+@"'); ";

                        query += @" INSERT INTO LEDGERS (DATE,DESCRIPTIONS,COA_ID,REF_ID,ENTRY_OF,DEBIT,CREDIT,CREATED_BY,CREATION_DATE,COMPANY_ID,REF_AC_ID,FOLIO) 
                        VALUES ('" + Classes.Helper.ConvertDatetime(dtpReceipt.Value.Date) + "','" + txtDescriptRece.Text + "','" + cmbReceipt.SelectedValue.ToString() + @"',
                        " + id + ",'RECEIPT VOUCHER CASH','0','" + txtCashAmount.Text + @"',1,GETDATE(),1,'" + db.AvoidInjection(subAccTxt.Text) + @"','" + lblVoucherNumRV.Text + @"'); ";
                    }

                    query += @" COMMIT TRANSACTION 
                        END TRY 
                    BEGIN CATCH 
                            IF @@TRANCOUNT > 0 
                            ROLLBACK TRANSACTION;
                            THROW
                    END CATCH";

                    if (db.InsertUpdateDelete(query) > 0)
                    {
                        MessageBox.Show("Record Save Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        if(daybookID.Equals(""))
                            voucher.ReceiptVoucherReport(dayBook.getLastDayBookId());
                        else
                            voucher.ReceiptVoucherReport(int.Parse(daybookID));

                        ReceiptClear();
                        loadReceipt();
                    }
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void cmbCreditPay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtBankPayment.Text.Equals(""))
            {
                txtPayBankAmount.Enabled = false;
                
            }
            else
            {
                txtPayBankAmount.Enabled = true;
            }
        }

        private void grdPayment_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            grdPayment.Columns["CHQ_ID"].Visible = false;
        }

        private int DeletePVCChq(int chqId,int pvId,string bankName,string chqNo,decimal chqAmount) {
            db.query = @"BEGIN TRY 
                             BEGIN TRANSACTION 
            UPDATE CHQ SET PAY_AC = null, PAY_DATE = null,STATUS=1 WHERE CHQ_ID='" + chqId + @"';

            DELETE FROM DAY_BOOK_CHQ WHERE [TYPE] = 'P' and CHQ_ID = '"+ chqId + @"';

            INSERT INTO LEDGERS (DATE,DESCRIPTIONS,COA_ID,REF_ID,ENTRY_OF,DEBIT,CREDIT,CREATED_BY,CREATION_DATE,COMPANY_ID,FOLIO,REF_AC_ID) 
            VALUES ('" + Classes.Helper.ConvertDatetime(dtpPayment.Value.Date) + "','[CHQ DELETE] PAYMENT " + bankName + " CHQ #: " + chqNo + @"',
            '" + cmbSupplierPay.SelectedValue.ToString() + @"'," + pvId + @",'PAYMENT VOUCHER',
            '0','" + chqAmount + @"',1,GETDATE(),1,'" + lblVoucherNumPV.Text + @"',
            '" + db.AvoidInjection(txtPaidToPayments.Text) + @"');

            INSERT INTO LEDGERS (DATE,DESCRIPTIONS,COA_ID,REF_ID,ENTRY_OF,DEBIT,CREDIT,CREATED_BY,CREATION_DATE,COMPANY_ID,FOLIO,REF_AC_ID) 
            VALUES ('" + Classes.Helper.ConvertDatetime(dtpPayment.Value.Date) + "','[CHQ DELETE] RECEIPT PAYMENT IN " + bankName + " CHQ #: " + chqNo + @"',
            " + chqId + @"," + pvId + ",'RECEIPT VOUCHER','" + chqAmount + @"','0',1,GETDATE(),1,'" + lblVoucherNumPV.Text + @"',
            '" + db.AvoidInjection(txtPaidToPayments.Text) + @"');
  
            COMMIT TRANSACTION 
                            END TRY 
                        BEGIN CATCH 
                                THROW
                        END CATCH";

            if (db.InsertUpdateDelete(db.query) > 0)
            {
                return 1;
            }
            return 0;
        }

        private void btnSavePay_Click(object sender, EventArgs e)
        {
            try
            {
                //if (cmbCreditPay.SelectedValue.Equals("0"))
                //{
                //    MessageBox.Show("Error","Select Payment Account",MessageBoxButtons.OK,MessageBoxIcon.Information);
                //    cmbCreditPay.Focus();
                //}
                //else 
                //if (grdPayment.RowCount<=0)
                //{
                //    MessageBox.Show("No entries to save", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
                //else 
                if (cmbSupplierPay.SelectedValue.ToString().Equals("0"))

                {
                    MessageBox.Show("Select Payment Account", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbSupplierPay.Focus();
                }
                //else if (txtPaidToPayments.Text.Equals(""))
                //{
                //    MessageBox.Show("Enter Paid to", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    txtPaidToPayments.Focus();
                //}
                else if (txtAmountPay.Text.Equals(""))
                {
                    MessageBox.Show("Enter Amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAmountPay.Focus();
                }
                //else if (Convert.ToDecimal(txtAmountPay.Text) != Convert.ToDecimal(txtPayCashAmount.Text) + Convert.ToDecimal(txtTotalGrdPayment.Text))
                //{
                //    MessageBox.Show("Amount is not valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    txtAmountPay.Focus();
                //}
                else
                {
                    string id;
                    if (paybookID.Equals(""))
                    {
                        id = "(SELECT MAX(DAY_BOOK_ID) FROM DAY_BOOK)";
                    }
                    else
                    {
                        id = paybookID;
                    }

                    if (id.Equals("")) {
                        id = "0";
                    }
                    string query = @"BEGIN TRY 
                             BEGIN TRANSACTION ";
                    query += @"IF EXISTS (SELECT DAY_BOOK_ID FROM DAY_BOOK WHERE DAY_BOOK_ID='" + paybookID + @"'  AND ENTRY_OF = 'PAYMENT VOUCHER' )
                    BEGIN UPDATE DAY_BOOK SET DATE='" + dtpPayment.Value.ToString() + "',DEBIT_AC='" 
                    + cmbSupplierPay.SelectedValue.ToString() + "',ENTRY_OF='PAYMENT VOUCHER',CREDIT_AC=" +
                    "(SELECT COA_ID FROM COA WHERE COA_NAME = 'CHQ IN HAND')" + "," +
                    "AMOUMT='" + (Double.Parse(txtPayChqAmount.Text)+Double.Parse(txtPayCashAmount.Text)).ToString() +
                    "',DESCRIPTION='" + txtDescriptPay.Text + "',CASH_AMOUNT='" + txtPayCashAmount.Text +
                    "',BANK_AMOUNT='" + txtPayBankAmount.Text + @"',MODIFICATION_DATE=GETDATE(),MODIFIED_BY='1', 
                    PAID_TO = '"+txtPaidToPayments.Text+"'  WHERE DAY_BOOK_ID='" + paybookID + @"' ; 
                    END 
                    ELSE 
                    ";

                    query += @" INSERT INTO DAY_BOOK VALUES('" + dtpPayment.Value.ToString() + "','PAYMENT VOUCHER','" + cmbSupplierPay.SelectedValue.ToString() + @"',
                    " + "(SELECT COA_ID FROM COA WHERE COA_NAME = 'CHQ IN HAND')" + ",'" + (Double.Parse(txtPayChqAmount.Text) + Double.Parse(txtPayCashAmount.Text)).ToString() + "','" + txtDescriptPay.Text + "',GETDATE(),'1',NULL,NULL,'" + txtPayCashAmount.Text + @"','" + txtPayChqAmount.Text + @"',NULL,'" + txtPaidToPayments.Text + "');";

                    if (!id.Equals("")) {
                        query += @"DELETE FROM DAY_BOOK_CHQ WHERE DAY_BOOK_ID = " + id + @" AND [TYPE] = 'P' and CHQ_ID not in (select chq_id from CHQ where [STATUS] = 1);";
                        query += @"DELETE FROM PV_CHQS WHERE DAY_BOOK_ID = " + id + @";";

                    }
                    

                    //if (Convert.ToDecimal(txtPayBankAmount.Text) > 0)
                    //{
                    //    query += @" INSERT INTO LEDGERS (DATE,DESCRIPTIONS,COA_ID,REF_ID,ENTRY_OF,DEBIT,CREDIT,CREATED_BY,CREATION_DATE,COMPANY_ID)
                    //    VALUES ('" + dtpPayment.Value.ToString() + "','PAYMENT BANK " + cmbBank.Text + " : (" + txtDescriptPay.Text + ")','" + cmbSupplierPay.SelectedValue.ToString() + @"',
                    //    " + id + ",'PAYMENT VOUCHER','" + txtPayBankAmount.Text + @"','0',1,GETDATE(),1); ";

                    //    query += @" INSERT INTO LEDGERS (DATE,DESCRIPTIONS,COA_ID,REF_ID,ENTRY_OF,DEBIT,CREDIT,CREATED_BY,CREATION_DATE,COMPANY_ID)
                    //    VALUES ('" + dtpPayment.Value.ToString() + "','PAYMENT BANK " + cmbBank.Text + " : (" + txtDescriptPay.Text + ")','" + cmbPaymentBank.SelectedValue.ToString() + @"',
                    //    " + id + ",'PAYMENT VOUCHER','0','" + txtPayBankAmount.Text + @"',1,GETDATE(),1); ";
                    //}
                    //query += @" DELETE FROM LEDGERS WHERE REF_ID = " + id + " AND ENTRY_OF = 'PAYMENT CASH';";
                    //if (Convert.ToDecimal(txtPayCashAmount.Text) > 0)
                    //{
                    //    query += @" INSERT INTO LEDGERS (DATE,DESCRIPTIONS,COA_ID,REF_ID,ENTRY_OF,DEBIT,CREDIT,CREATED_BY,CREATION_DATE,COMPANY_ID)
                    //    VALUES ('" + dtpPayment.Value.ToString() + "','PAYMENT CASH : (" + txtDescriptPay.Text + @")','" + cmbSupplierPay.SelectedValue.ToString() + @"',
                    //    " + id + ",'PAYMENT VOUCHER','" + txtPayCashAmount.Text + @"','0',1,GETDATE(),1); ";

                    //    query += @" INSERT INTO LEDGERS (DATE,DESCRIPTIONS,COA_ID,REF_ID,ENTRY_OF,DEBIT,CREDIT,CREATED_BY,CREATION_DATE,COMPANY_ID)
                    //    VALUES ('" + dtpPayment.Value.ToString() + "','PAYMENT CASH : (" + txtDescriptPay.Text + @")','12',
                    //    " + id + ",'PAYMENT VOUCHER','0','" + txtPayCashAmount.Text + @"',1,GETDATE(),1); ";
                    //}
                    //if (Convert.ToDecimal(txtPayChqAmount.Text) > 0)
                    //{

                    //}
                    query += @" 
                    DELETE FROM LEDGERS WHERE REF_ID = " + id + " AND (ENTRY_OF = 'PAYMENT VOUCHER' OR ENTRY_OF = 'PAYMENT VOUCHER CASH' OR ENTRY_OF = 'RECEIPT VOUCHER');";
                    query += @" DELETE FROM PV_CHQS WHERE DAY_BOOK_ID = " + id + @"";
                    query += @" DELETE FROM DAY_BOOK_CHQ WHERE DAY_BOOK_ID = " + id + @"";

                    // query += @" DELETE FROM DAY_BOOK_CHQ WHERE DAY_BOOK_ID=" + id + "; ";
                    if (grdPayment.Rows.Count > 0) {
                        foreach (DataGridViewRow item in grdPayment.Rows)
                        {
                           

                            query += @" INSERT INTO CHQ (CHQ_DATE,CHQ_NO,AMOUNT,BANK_NAME,PAY_DATE) VALUES ('"+ item.Cells["CHQ_DATE"].Value.ToString() + "','"+ item.Cells["CHQ_NO"].Value.ToString() + @"',
                            '"+ item.Cells["AMOUNT"].Value.ToString() + "','"+ item.Cells["BANK"].Value.ToString() + "','"+dtpPayment.Value.Date+"')";

                            query += @" INSERT INTO DAY_BOOK_CHQ VALUES((SELECT MAX(CHQ_ID) FROM CHQ)," + id + @",'P'); ";

                            query += @"INSERT INTO PV_CHQS (DAY_BOOK_ID,CHQ_ID,PAY_AC) 
                            VALUES ("+id+",(SELECT MAX(CHQ_ID) FROM CHQ),'" + cmbSupplierPay.SelectedValue.ToString() + "')";
                            //IF NOT EXISTS(SELECT DBC_ID FROM DAY_BOOK_CHQ WHERE CHQ_ID = (SELECT CHQ_ID FROM CHQ WHERE CHQ_NO = '" + item.Cells["CHQ_NO"].Value.ToString() + "') AND DAY_BOOK_ID = " + id + @")
                            //BEGIN
                            //INSERT INTO DAY_BOOK_CHQ VALUES((SELECT CHQ_ID FROM CHQ WHERE CHQ_NO = '"+item.Cells["CHQ_NO"].Value.ToString()+"')," + id + "); " +
                            //" END" +
                            //"

                            query += @" INSERT INTO LEDGERS (DATE,DESCRIPTIONS,COA_ID,REF_ID,ENTRY_OF,DEBIT,CREDIT,CREATED_BY,CREATION_DATE,COMPANY_ID,FOLIO,REF_AC_ID) 
                            VALUES ('" + dtpPayment.Value.ToString() + "','" + item.Cells["BANK"].Value.ToString() + " / CHQ DATE: " + Classes.Helper.DateFormat(Convert.ToDateTime(item.Cells["CHQ_DATE"].Value.ToString())) + " / CHQ #: " + item.Cells["CHQ_NO"].Value.ToString() + @" " + txtPaidToPayments.Text + @"','" + cmbSupplierPay.SelectedValue.ToString() + @"',
                                " + id + ",'PAYMENT VOUCHER','" + item.Cells["AMOUNT"].Value.ToString() + @"','0',1,GETDATE(),1,'" + lblVoucherNumPV.Text + @"','" + db.AvoidInjection(txtPaidToPayments.Text) + @"'); ";

                            //query += @" INSERT INTO LEDGERS (DATE,DESCRIPTIONS,COA_ID,REF_ID,ENTRY_OF,DEBIT,CREDIT,CREATED_BY,CREATION_DATE,COMPANY_ID,FOLIO,REF_AC_ID) 
                            //VALUES ('" + dtpPayment.Value.ToString() + "','PAYMENT " + item.Cells["BANK"].Value.ToString() + " CHQ #: " + item.Cells["CHQ_NO"].Value.ToString() + @"'," + "(SELECT COA_ID FROM COA WHERE COA_NAME = 'CHQ IN HAND')" + @",
                            //    " + id + ",'PAYMENT VOUCHER','0','" + item.Cells["AMOUNT"].Value.ToString() + @"',1,GETDATE(),1,'" + lblVoucherNumPV.Text + @"','" + db.AvoidInjection(txtPaidToPayments.Text) + @"'); ";

                            //query += @" INSERT INTO LEDGERS (DATE,DESCRIPTIONS,COA_ID,REF_ID,ENTRY_OF,DEBIT,CREDIT,CREATED_BY,CREATION_DATE,COMPANY_ID,FOLIO,REF_AC_ID) 
                            //    VALUES ('" + Classes.Helper.ConvertDatetime(dtpPayment.Value.Date) + "','RECEIPT PAYMENT IN " + item.Cells["BANK"].Value.ToString() + " CHQ #: " + item.Cells["CHQ_NO"].Value.ToString() + @"'," + "(SELECT COA_ID FROM COA WHERE COA_NAME = 'CHQ IN HAND')" + @",
                            //    " + id + ",'RECEIPT VOUCHER','" + item.Cells["AMOUNT"].Value.ToString() + @"','0',1,GETDATE(),1,'" + lblVoucherNumPV.Text + @"','"+db.AvoidInjection(txtPaidToPayments.Text)+@"'); ";

                            query += @" INSERT INTO LEDGERS (DATE,DESCRIPTIONS,COA_ID,REF_ID,ENTRY_OF,DEBIT,CREDIT,CREATED_BY,CREATION_DATE,COMPANY_ID,FOLIO,REF_AC_ID) 
                                VALUES ('" + Classes.Helper.ConvertDatetime(dtpPayment.Value.Date) + "','" + item.Cells["BANK"].Value.ToString() + " / CHQ DATE: " + Classes.Helper.DateFormat(Convert.ToDateTime(item.Cells["CHQ_DATE"].Value.ToString())) + " / CHQ #: " + item.Cells["CHQ_NO"].Value.ToString() + @" " + txtPaidToPayments.Text + @"',null" + @",
                                " + id + ",'RECEIPT VOUCHER','0','" + item.Cells["AMOUNT"].Value.ToString() + @"',1,GETDATE(),1,'" + lblVoucherNumPV.Text + @"','" + db.AvoidInjection(txtPaidToPayments.Text) + @"'); ";

                        }
                    }
                    

                    //   //if (cmbCreditPay.Text.Contains("CHQ IN HAND"))
                    //    //{

                    //    //    else {
                    //    //        MessageBox.Show("Select Chq.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    //        return;
                    //    //    }
                    //    //}

                    

                    if (Convert.ToDecimal(txtPayCashAmount.Text) > 0)
                    {
                        query += @" INSERT INTO LEDGERS (DATE,DESCRIPTIONS,COA_ID,REF_ID,ENTRY_OF,CREDIT,DEBIT,CREATED_BY,CREATION_DATE,COMPANY_ID,FOLIO) 
                        VALUES ('" + dtpPayment.Value.ToString() + "','" + txtDescriptPay.Text + @"','"+Classes.Helper.cashId+@"',
                        " + id + ",'PAYMENT VOUCHER CASH','" + txtPayCashAmount.Text + @"','0',1,GETDATE(),1,'" + lblVoucherNumPV.Text + @"'); ";

                        query += @" INSERT INTO LEDGERS (DATE,DESCRIPTIONS,COA_ID,REF_ID,ENTRY_OF,CREDIT,DEBIT,CREATED_BY,CREATION_DATE,COMPANY_ID,FOLIO) 
                        VALUES ('" + dtpPayment.Value.ToString() + "','" + txtDescriptPay.Text + "','" + cmbSupplierPay.SelectedValue.ToString() + @"',
                        " + id + ",'PAYMENT VOUCHER CASH','0','" + txtPayCashAmount.Text + @"',1,GETDATE(),1,'" + lblVoucherNumPV.Text + @"'); ";
                    }

                    query += @" COMMIT TRANSACTION 
                            END TRY 
                        BEGIN CATCH 
                                THROW
                        END CATCH";

                    if (db.InsertUpdateDelete(query) > 0)
                    {
                        MessageBox.Show("Record Save Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       
                        if(id.Equals("")||id.Equals("(SELECT MAX(DAY_BOOK_ID) FROM DAY_BOOK)"))
                            voucher.PaymentVoucherReport(dayBook.getLastDayBookId(),Convert.ToInt32(cmbSupplierPay.SelectedValue.ToString()));
                        else
                            voucher.PaymentVoucherReport(int.Parse(id), Convert.ToInt32(cmbSupplierPay.SelectedValue.ToString()));

                        loadPayment();
                        PaymentClear();

                    }

                    //    //string[] data = { dtpPayment.Value.ToString("MM-dd-yyyy"),cmbCreditPay.SelectedValue.ToString(),cmbSupplierPay.SelectedValue.ToString(),txtAmountPay.Text,valid.AvoidInjection( txtDescriptPay.Text)};
                    //    //if (dayBook.savePayment(data,list)==1)
                    //    //{
                    //    //    MessageBox.Show("Information","Record Save Successfully.",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    //    //}
                    }
                }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }


        private void btnReceiptVoucher_Click(object sender, EventArgs e)
        {
            try
            {
                if (!daybookID.Equals(""))
                {
                    voucher.ReceiptVoucherReport(Convert.ToInt32(daybookID));
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

        private void btnPaymentVoucher_Click(object sender, EventArgs e)
        {
            try
            {
                if (!paybookID.Equals(""))
                {
                    voucher.PaymentVoucherReport(Convert.ToInt32(paybookID), Convert.ToInt32(cmbSupplierPay.SelectedValue.ToString()));
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

        private void btnClearReceipt_Click(object sender, EventArgs e)
        {

        }

        private void txtAmountReceipt_KeyPress(object sender, KeyPressEventArgs e)
        {
            db.CheckNumber(e);
        }

        private void txtAmountReceipt_Click(object sender, EventArgs e)
        {
            txtAmountReceipt.SelectAll();
        }

        private void txtAmnt_KeyPress(object sender, KeyPressEventArgs e)
        {
            db.CheckNumber(e);
            txtCreditGV.Text = "0";
        }

        private void txtAmnt_Click(object sender, EventArgs e)
        {
            txtAmnt.SelectAll();
        }

        private void grdPayment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grdPayment.Rows.Count > 0)
                {
                    if (e.RowIndex >= 0)
                    {
                        DialogResult diag = new DialogResult();
                        diag = MessageBox.Show("Do you want to unpaid this chq?", "Un paid chq", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (diag == DialogResult.Yes)
                        {
                            DataGridViewRow row = this.grdPayment.Rows[e.RowIndex];
                            if (DeletePVCChq(Convert.ToInt32(row.Cells["CHQ_ID"].Value.ToString()), Convert.ToInt32(paybookID),
                            row.Cells["BANK"].Value.ToString(), row.Cells["CHQ_NO"].Value.ToString(),
                            Convert.ToDecimal(row.Cells["AMOUNT"].Value.ToString())) > 0)
                            {
                                //dayBook.loadAllChqs(cmbChqNoPay);
                                txtChqAmountPay.Text = row.Cells["AMOUNT"].Value.ToString();
                                txtAmountPay.Text = (Double.Parse(txtChqAmountPay.Text) + Double.Parse(txtPayCashAmount.Text)).ToString();
                                //cmbChqNoPay.Text = row.Cells["CHQ_NO"].Value.ToString();
                                txtPayChqNo.Text = row.Cells["CHQ_NO"].Value.ToString();
                                addedChqs.Remove(txtPayChqNo.Text);
                                txtBankPayment.Text = row.Cells["BANK"].Value.ToString();
                                txtAmountWordsPay.Text = DayBook.ConvertWholeNumber(txtAmountPay.Text);
                                //cmbCustomerPay.SelectedValue = row.Cells["PAYMENT_ACC_ID"].Value.ToString();
                                chqId = "0";

                                rowEdit = 1;
                                grdPayment.Rows.RemoveAt(e.RowIndex);

                            }
                        }
                    }
                }

                //if (e.RowIndex != -1 && grdPayment.Enabled == true)
                //{
                //    list.Clear();
                //    foreach (DataGridViewRow item in grdPayment.Rows)
                //    {
                //        bool isSelected = Convert.ToBoolean(item.Cells["selectChq"].Value);
                //        if (isSelected)
                //        {
                //            list.Add(item.Cells["CHQ_ID"].Value.ToString());
                //        }
                //    }
                //}
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        //CHEQUE DEPOSIT

        private void loadCD()
        {
            try
            {
                dayBook.loadBank(cmbBankCD);
                dayBook.loadChqDeposit(grdDeposit);
                dayBook.loadChqDepositPaid(grdPaidChqsCD);
                foreach (DataGridViewRow row in grdDeposit.Rows)
                {
                    row.Cells["selectCHq1"].Value = false;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void ChqDepositClear() {
            dtpCD.Value = DateTime.Now;
            cmbBankCD.SelectedValue = "0";
            dayBook.loadChqDeposit(grdDeposit);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ChqDepositClear();
        }
        private void btnSaveCD_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbBankCD.SelectedValue.Equals("0"))
                {
                    MessageBox.Show("Error", "Select Bank A/C", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbBankCD.Focus();
                    return;
                }
                else if (grdDeposit.Rows.Count > 0)
                {
                    string query = @"BEGIN TRY 
                             BEGIN TRANSACTION ";
                    foreach (DataGridViewRow row in grdDeposit.Rows)
                    {
                        if (row.Cells["selectCHq1"].Value.ToString().Equals("True"))
                        {
                            query += @"UPDATE CHQ SET PAY_DATE='" + dtpCD.Value.ToString() + "', PAY_AC='" + cmbBankCD.SelectedValue.ToString() + "',STATUS=0 WHERE CHQ_ID='" + row.Cells["CHQ_ID"].Value.ToString() + "'";

                            query += @"INSERT INTO LEDGERS 
                            (DATE,DESCRIPTIONS,COA_ID,REF_ID,ENTRY_OF,DEBIT,CREDIT,CREATED_BY,CREATION_DATE,COMPANY_ID) values 
                            ('" + dtpReturn.Value.ToString() + "','CHQ DEPOSIT NO #: " + row.Cells["CHQ NO"].Value.ToString() + @"',
                            '" + cmbBankCD.SelectedValue.ToString() + "','" + row.Cells["CHQ_ID"].Value.ToString() + @"',
                            'CHQ DEPOSIT','" + row.Cells["AMOUNT"].Value.ToString() + "','0',1,GETDATE(),1);";

                            query += @"INSERT INTO LEDGERS (DATE,DESCRIPTIONS,COA_ID,REF_ID,ENTRY_OF,DEBIT,CREDIT,CREATED_BY,CREATION_DATE,COMPANY_ID) values 
                            ('" + dtpReturn.Value.ToString() + "','CHQ DEPOSIT NO #: " + row.Cells["CHQ NO"].Value.ToString() + @"',
                            '13','" + row.Cells["CHQ_ID"].Value.ToString() + @"',
                            'CHQ DEPOSIT','0','" + row.Cells["AMOUNT"].Value.ToString() + "',1,GETDATE(),1);";
                        }
                    }
                    query += @" COMMIT TRANSACTION 
                        END TRY 
                    BEGIN CATCH 
                            IF @@TRANCOUNT > 0 
                            ROLLBACK TRANSACTION 
                    END CATCH";

                    if (db.InsertUpdateDelete(query) > 0)
                    {
                        MessageBox.Show("Record Saved Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ChqDepositClear();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }
       
        private void grdDeposit_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grdDeposit.Rows.Count > 0)
                {
                    if (grdDeposit.CurrentCell.ColumnIndex.Equals(0) && grdDeposit.Rows[e.RowIndex].Cells["selectCHq1"].Value.ToString().Equals("True"))
                    {
                        grdDeposit.Rows[e.RowIndex].Cells["selectCHq1"].Value = false;
                    }
                    else if(grdDeposit.CurrentCell.ColumnIndex.Equals(0))
                    {
                        grdDeposit.Rows[e.RowIndex].Cells["selectCHq1"].Value = true;
                    }
                }
                //if (e.RowIndex != -1)
                //{
                //    listDeposit.Clear();
                //    foreach (DataGridViewRow item in grdDeposit.Rows)
                //    {
                //        bool isSelected = Convert.ToBoolean(item.Cells["selectCHq1"].Value);
                //        if (isSelected)
                //        {
                //            listDeposit.Add(item.Cells["CHQ_ID"].Value.ToString());
                //        }
                //    }
                //}
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void grdDeposit_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            grdDeposit.Columns["CHQ_ID"].Visible = false;
        }

        //CHEQUE RETURN
        private void loadCR()
        {
            try
            {
                dayBook.loadRecieptCustomer(cmbReturnCustomer);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void grdReturn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grdDeposit.Rows.Count > 0)
                {
                    if (grdReturn.Rows[e.RowIndex].Cells["RETURN"].Value.ToString().Equals("True"))
                    {
                        grdReturn.Rows[e.RowIndex].Cells["RETURN"].Value = false;
                    }
                    else
                    {
                        grdReturn.Rows[e.RowIndex].Cells["RETURN"].Value = true;
                    }
                }
                //if (e.RowIndex != -1)
                //{
                //    listReturn.Clear();
                //    foreach (DataGridViewRow item in grdReturn.Rows)
                //    {
                //        bool isSelected = Convert.ToBoolean(item.Cells["RETURN"].Value);
                //        if (isSelected)
                //        {
                //            listReturn.Add(item.Cells["CHQ_ID"].Value.ToString());
                //        }
                //    }
                //}
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void grdReturn_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            grdReturn.Columns["CHQ_ID"].Visible = false;
            grdReturn.Columns["PAY_AC"].Visible = false;
        }

        private void grdReceipt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.grdReceipt.Rows[e.RowIndex];
                dtpCredit.Value = Convert.ToDateTime(row.Cells["Date1"].Value.ToString());
                txtAmnt.Text = row.Cells["AmntReceipt"].Value.ToString();
                cmbBankReceipt.Text = row.Cells["Bank1"].Value.ToString();
                txtChqNo.Text = row.Cells["CHQNO"].Value.ToString();
                grdReceipt.Rows.RemoveAt(e.RowIndex);
                txtChqTotal.Text = grdReceipt.Rows.Cast<DataGridViewRow>()
                    .Sum(t => Convert.ToDecimal(t.Cells["AmntReceipt"].Value)).ToString();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void ReceiptClear() {
            dtpCredit.Value = DateTime.Now;
            txtChqNo.Clear();
            txtAmnt.Text = "0";
            //cmbBankReceipt.Items.Clear();
            txtChqNo.Clear();
            grdReceipt.Rows.Clear();
            txtChqTotal.Clear();
            cmbBankReceipt.Text = "--SELECT BANK--";
            txtAmountWordsRec.Clear();
            txtAmountReceipt.Clear();
            txtDescriptRece.Clear();
            txtCashAmount.Text = "0";
            txtBankAmount.Text = "0";
            txtBankAmount.Enabled = false;
            daybookID = "";
            //cmbRecoveryPerson.SelectedIndex = 0;
            subAccTxt.Clear();
            loadReceipt();
        }

        private void PaymentClear()
        {
            paybookID = "";
            dtpPayment.Value = DateTime.Now;
            txtBankPayment.Text = "";
            cmbSupplierPay.SelectedValue = "0";
            txtAmountPay.Text = "0";
            txtAmountWordsPay.Clear();
            txtPayBankAmount.Text = "0";
            txtPayCashAmount.Text = "0";
            txtDescriptPay.Clear();
            txtPayChqAmount.Text = "0";
            txtPaidToPayments.Text = "";
            //cmbCustomerPay.SelectedIndex = 0;
            //dayBook.loadPayGrid(grdPayment);
            //PayChqGrid.Rows.Clear();
            addedChqs.Clear();
            grdPayment.Rows.Clear();
            chqId = "";
            rowEdit = -1;
            loadPayment();
        }

        private void btnReceiptCLEAR_Click(object sender, EventArgs e)
        {
            ReceiptClear();
        }

        private void btnClearPay_Click(object sender, EventArgs e)
        {
            PaymentClear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                char status = 'P';
                if (rdbPaid.Checked == true) {
                    status = 'D';
                }
                dayBook.loadChqDeposit(grdReturn, Convert.ToInt32(cmbReturnCustomer.SelectedValue.ToString()),status);
                foreach (DataGridViewRow row in grdReturn.Rows)
                {
                    row.Cells["RETURN"].Value = false;
                }
                grdReturn.Columns[0].Width = 100;
            }
            catch (Exception ex) {
                MessageBox.Show("Error",ex.Message,MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cmbReturnCustomer.SelectedValue.Equals("0"))
            {
                MessageBox.Show("Error", "Select Customer A/C", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbReturnCustomer.Focus();
                return;
            }
            else if (grdReturn.Rows.Count > 0)
            {
                string query = @"BEGIN TRY 
                             BEGIN TRANSACTION ";
                if (rdbPending.Checked == true)
                {
                    foreach (DataGridViewRow row in grdReturn.Rows)
                    {
                        if (row.Cells["RETURN"].Value.ToString().Equals("True"))
                        {
                            query += @"UPDATE CHQ SET PAY_DATE=null, PAY_AC=null,STATUS=2 WHERE CHQ_ID='" + row.Cells["CHQ_ID"].Value.ToString() + "';";

                            query += @"INSERT INTO CHQ_RETURN_HISTORY ([DATE],CHQ_ID,REMARKS,REC_AC,PAY_AC) 
                            VALUES('" + dtpReturn.Value.ToString() + "','" + row.Cells["CHQ_ID"].Value.ToString() + @"',
                            '" + db.AvoidInjection(txtChqReturnReason.Text) + "',(SELECT REC_AC FROM CHQ WHERE CHQ_ID = '" + row.Cells["CHQ_ID"].Value.ToString() + @"'),
                            (SELECT PAY_AC FROM CHQ WHERE CHQ_ID = '" + row.Cells["CHQ_ID"].Value.ToString() + @"'))";

                            //query += @"INSERT INTO LEDGERS (DATE,DESCRIPTIONS,COA_ID,REF_ID,ENTRY_OF,DEBIT,CREDIT,CREATED_BY,CREATION_DATE,COMPANY_ID) 
                            //values 
                            //('" + dtpReturn.Value.ToString() + "','" + row.Cells["BANK"].Value.ToString() + " CHQ RETURN NO #: " + row.Cells["CHQ NO"].Value.ToString() + @"',
                            //'" + cmbReturnCustomer.SelectedValue.ToString() + "','" + row.Cells["CHQ_ID"].Value.ToString() + @"',
                            //'CHQ RETUN','" + row.Cells["AMOUNT"].Value.ToString() + "','0',1,GETDATE(),1);";

                            //query += @"INSERT INTO LEDGERS (DATE,DESCRIPTIONS,COA_ID,REF_ID,ENTRY_OF,DEBIT,CREDIT,CREATED_BY,CREATION_DATE,COMPANY_ID) values 
                            //('" + dtpReturn.Value.ToString() + "','" + row.Cells["BANK"].Value.ToString() + " CHQ RETURN NO #: " + row.Cells["CHQ NO"].Value.ToString() + @"',
                            //(SELECT COA_ID FROM COA WHERE COA_NAME = 'CHQ IN HAND'),'" + row.Cells["CHQ_ID"].Value.ToString() + @"',
                            //'CHQ RETUN','0','" + row.Cells["AMOUNT"].Value.ToString() + "',1,GETDATE(),1);";
                        }
                    }
                }
                else {
                    foreach (DataGridViewRow row in grdReturn.Rows)
                    {
                        if (row.Cells["RETURN"].Value.ToString().Equals("True"))
                        {
                            

                            query += @"INSERT INTO CHQ_RETURN_HISTORY ([DATE],CHQ_ID,REMARKS,REC_AC,PAY_AC) 
                            VALUES('" + dtpReturn.Value.ToString() + "','" + row.Cells["CHQ_ID"].Value.ToString() + @"',
                            '" + db.AvoidInjection(txtChqReturnReason.Text) + "',(SELECT REC_AC FROM CHQ WHERE CHQ_ID = '" + row.Cells["CHQ_ID"].Value.ToString() + @"'),
                            (SELECT PAY_AC FROM CHQ WHERE CHQ_ID = '" + row.Cells["CHQ_ID"].Value.ToString() + @"'));";

                            query += @"INSERT INTO LEDGERS (DATE,DESCRIPTIONS,COA_ID,REF_ID,ENTRY_OF,DEBIT,CREDIT,CREATED_BY,CREATION_DATE,COMPANY_ID,FOLIO) 
                            values 
                            ('" + dtpReturn.Value.ToString() + "','" + row.Cells["BANK"].Value.ToString() + " CHQ RETURN NO #: " + row.Cells["CHQ NO"].Value.ToString() + @"',
                            '" + cmbReturnCustomer.SelectedValue.ToString() + "','" + row.Cells["CHQ_ID"].Value.ToString() + @"',
                            'CHQ RETUN','" + row.Cells["AMOUNT"].Value.ToString() + "','0',1,GETDATE(),1,(select 'CHQ-RTN-'+CONVERT(VARCHAR(MAX),isnull(MAX(DAY_BOOK_ID),0)+1)+'-'+CONVERT(VARCHAR(MAX),YEAR(GETDATE())) from DAY_BOOK));";

                            //query += @"INSERT INTO LEDGERS (DATE,DESCRIPTIONS,COA_ID,REF_ID,ENTRY_OF,DEBIT,CREDIT,CREATED_BY,CREATION_DATE,COMPANY_ID) values 
                            //('" + dtpReturn.Value.ToString() + "','" + row.Cells["BANK"].Value.ToString() + " CHQ RETURN NO #: " + row.Cells["CHQ NO"].Value.ToString() + @"',
                            //(SELECT COA_ID FROM COA WHERE COA_NAME = 'CHQ IN HAND'),'" + row.Cells["CHQ_ID"].Value.ToString() + @"',
                            //'CHQ RETUN','0','" + row.Cells["AMOUNT"].Value.ToString() + "',1,GETDATE(),1);";

                            //query += @"INSERT INTO LEDGERS (DATE,DESCRIPTIONS,COA_ID,REF_ID,ENTRY_OF,DEBIT,CREDIT,CREATED_BY,CREATION_DATE,COMPANY_ID) values 
                            //('" + dtpReturn.Value.ToString() + "','" + row.Cells["BANK"].Value.ToString() + " CHQ RETURN NO #: " + row.Cells["CHQ NO"].Value.ToString() + @"',
                            //(SELECT COA_ID FROM COA WHERE COA_NAME = 'CHQ IN HAND'),'" + row.Cells["CHQ_ID"].Value.ToString() + @"',
                            //'CHQ RETUN','" + row.Cells["AMOUNT"].Value.ToString() + "','0',1,GETDATE(),1);";

                            query += @"INSERT INTO LEDGERS (DATE,DESCRIPTIONS,COA_ID,REF_ID,ENTRY_OF,DEBIT,CREDIT,CREATED_BY,CREATION_DATE,COMPANY_ID,FOLIO) 
                            values 
                            ('" + dtpReturn.Value.ToString() + "','" + row.Cells["BANK"].Value.ToString() + " CHQ RETURN NO #: " + row.Cells["CHQ NO"].Value.ToString() + @"',
                            (SELECT PAY_AC FROM CHQ WHERE CHQ_ID = '" + row.Cells["CHQ_ID"].Value.ToString() + @"'),'" + row.Cells["CHQ_ID"].Value.ToString() + @"',
                            'CHQ RETUN','0','" + row.Cells["AMOUNT"].Value.ToString() + "',1,GETDATE(),1,(select 'CHQ-RTN-'+CONVERT(VARCHAR(MAX),isnull(MAX(DAY_BOOK_ID),0)+1)+'-'+CONVERT(VARCHAR(MAX),YEAR(GETDATE())) from DAY_BOOK));";

                            query += @"UPDATE CHQ SET PAY_DATE=null, PAY_AC=null,STATUS=1 WHERE CHQ_ID='" + row.Cells["CHQ_ID"].Value.ToString() + "';";
                        }
                    }
                }
                
                query += @" COMMIT TRANSACTION 
                        END TRY 
                    BEGIN CATCH 
                            IF @@TRANCOUNT > 0 
                            ROLLBACK TRANSACTION 
                    END CATCH";
                //MessageBox.Show("Record Saved Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //generateChqReturnVoucher();
                //ClearChqReturn();

                if (db.InsertUpdateDelete(query) > 0)
                {
                    MessageBox.Show("Record Saved Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    generateChqReturnVoucher();
                    ClearChqReturn();
                }
            }
        }

        private void ClearChqReturn() {
            dtpReturn.Value = DateTime.Now;
            cmbReturnCustomer.SelectedValue = "0";
            rdbPaid.Checked = true;
            txtChqReturnReason.Clear();
            loadCR();
            //grdReturn.Rows.Clear();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ClearChqReturn();
        }

        private void txtPayCashAmount_TextChanged(object sender, EventArgs e)
        {
     
        }

        private void cmbPaymentBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtBankPayment.Text.ToString().Equals("0"))
            {
                txtPayBankAmount.Enabled = false;
            }
            else {
                txtPayBankAmount.Enabled = true;
            }
        }

        public void get_voucher_details(string gv_id, DataGridView dg)
        {
            dg.Rows.Clear();
            string query = @"SELECT C.DAATE,B.COA_NAME,A.DEBIT,A.CREDIT,A.NARRATION,A.COA_ID
            FROM GENERAL_VOUCHER_D A,COA B,GENERAL_VOUCHER_M C
            WHERE A.COA_ID = B.COA_ID AND A.GV_ID=C.GV_ID AND A.GV_ID = '" + gv_id + "'";
            //SELECT A.COA_ID,B.COA_NAME,A.DEBIT,A.CREDIT FROM GENERAL_VOUCHER_D A,COA B WHERE A.COA_ID = B.COA_ID AND A.GV_ID = '" + gv_id+"'
            if (Classes.Helper.conn.State == System.Data.ConnectionState.Closed) { Classes.Helper.conn.Open(); }
            try
            {
                db.cmd = new SqlCommand(query, Classes.Helper.conn);
                db.cmd.CommandTimeout = 0;
                db.dr = db.cmd.ExecuteReader();
                if (db.dr.HasRows)
                {
                    int i = 0;
                    while (db.dr.Read())
                    {
                        dg.Rows.Add(db.dr[0].ToString(), db.dr[1].ToString(), db.dr[2].ToString(), db.dr[3].ToString(), db.dr[4].ToString(),db.dr[5].ToString());
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

        private void EntryGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.EntryGrid.Rows[e.RowIndex];
                    gv_id = row.Cells["GV_ID"].Value.ToString();
                    is_edit = e.RowIndex;
                    dtpDate.Value = DateTime.Parse(row.Cells["DATE"].Value.ToString());
                    lblGV.Text = row.Cells["VOUCHER #"].Value.ToString();
                    
                    txtNarration.Text = row.Cells["NARRATION"].Value.ToString();
                   


                    get_voucher_details(gv_id, grdENTRY);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void EntryGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
          
            EntryGrid.Columns["GV_ID"].Visible = false;
            //EntryGrid.Columns["REF_ID"].Visible = false;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtBank_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtChqNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void ReceiptsGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try {
                if (e.RowIndex!=-1)
                {
                    DataGridViewRow row = this.ReceiptsGrid.Rows[e.RowIndex];
                    daybookID = row.Cells["DAY_BOOK_ID"].Value.ToString();
                    lblVoucherNumRV.Text = "RV-"+daybookID+"-"+DateTime.Now.Year;
                    dtpReceipt.Value =DateTime.Parse( row.Cells["DATE"].Value.ToString());
                    cmbReceipt.SelectedValue = row.Cells["CREDIT_AC"].Value.ToString();
                    //cmbBank.SelectedValue= row.Cells["DEBIT_AC"].Value.ToString();
                    txtAmountReceipt.Text= row.Cells["TOTAL_AMOUNT"].Value.ToString();
                    //txtBankAmount.Text= row.Cells["BANK AMOUNT"].Value.ToString();
                    txtCashAmount.Text= row.Cells["CASH AMOUNT"].Value.ToString();
                    txtDescriptRece.Text = row.Cells["DESCRIPTION"].Value.ToString();
                    cmbBank.Text = row.Cells["BANK"].Value.ToString();
                    grdReceipt.Rows.Clear();
                    txtChqTotal.Text = grdReceipt.Rows.Cast<DataGridViewRow>()
                    .Sum(t => Convert.ToDecimal(t.Cells["AmntReceipt"].Value)).ToString();
                    txtAmountWordsRec.Text = DayBook.ConvertWholeNumber(txtAmountReceipt.Text);
                    //cmbRecoveryPerson.SelectedValue = row.Cells["REC_PERSON_ID"].Value.ToString();
                    dayBook.getChq(row.Cells["DAY_BOOK_ID"].Value.ToString(), grdReceipt);
                    txtChqTotal.Text = grdReceipt.Rows.Cast<DataGridViewRow>()
                        .Sum(t => Convert.ToDecimal(t.Cells["AmntReceipt"].Value)).ToString();
                    rowClear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ReceiptsGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ReceiptsGrid.Columns["DAY_BOOK_ID"].Visible = false;
            ReceiptsGrid.Columns["DEBIT_AC"].Visible = false;
            ReceiptsGrid.Columns["CREDIT_AC"].Visible = false;
            ReceiptsGrid.Columns["TOTAL_AMOUNT"].HeaderText = "TOTAL AMOUNT";

        }

        private void btnAddChqPay_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBankPayment.Text.Equals(""))
                {
                    MessageBox.Show("Enter Bank name","ERROR");
                    txtBankPayment.Focus();
                }
                else if(txtPayChqAmount.Text.Equals(""))
                {
                    MessageBox.Show("Enter Amount", "ERROR");
                    txtChqAmountPay.Focus();
                }
                else if(txtPayChqNo.Text.Equals(""))
                {
                    MessageBox.Show("Enter CHQ No", "ERROR");
                    txtPayChqNo.Focus();
                }
                else if(addedChqs.Contains(txtPayChqNo.Text))
                {
                    MessageBox.Show("That CHQ is already added", "ERROR");
                }

                else
                {
                    if (rowEdit >= 0)
                    {
                        grdPayment.Rows.Add(dtpChqDatePV.Value.Date,txtPayChqAmount.Text, txtBankPayment.Text, db.AvoidInjection(txtPayChqNo.Text));
                        txtPayBankAmount.Text = PayChqGrid.Rows.Cast<DataGridViewRow>()
                        .Sum(t => Convert.ToDecimal(t.Cells["AMOUNT"].Value)).ToString();
                        //grdPayment.Rows.RemoveAt(rowEdit);
                        addedChqs.Add(txtPayChqNo.Text);
                        txtPayChqAmount.Text = "0";
                        txtPayChqNo.Clear();
                        txtBankPayment.Clear();
                        dtpChqDatePV.Value = DateTime.Now;
                        rowEdit = -1;
                    }
                    else
                    {
                        grdPayment.Rows.Add(dtpChqDatePV.Value.Date, txtPayChqAmount.Text, txtBankPayment.Text, db.AvoidInjection(txtPayChqNo.Text));
                        txtPayBankAmount.Text = PayChqGrid.Rows.Cast<DataGridViewRow>()
                        .Sum(t => Convert.ToDecimal(t.Cells["AMOUNT"].Value)).ToString();
                        addedChqs.Add(txtPayChqNo.Text);
                        txtPayChqAmount.Text = "0";
                        txtPayChqNo.Clear();
                        txtBankPayment.Clear();
                        dtpChqDatePV.Value = DateTime.Now;
                    }
                    dateOfChq = new DateTime();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PaymentGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    DataGridViewRow row = this.PaymentGrid.Rows[e.RowIndex];
                    paybookID = row.Cells["DAY_BOOK_ID"].Value.ToString();
                    lblVoucherNumPV.Text = "PVO-" + paybookID + "-" + DateTime.Now.Year;
                    //dtpPayment.Value = DateTime.Parse(row.Cells["DATE"].Value.ToString());
                    cmbSupplierPay.SelectedValue = row.Cells["PAYMENT_ID"].Value.ToString();
                    //txtAmountPay.Text = row.Cells["TOTAL"].Value.ToString();
                    //txtPayChqAmount.Text = row.Cells["CHQ AMOUNT"].Value.ToString();
                    txtPayCashAmount.Text = row.Cells["CASH_AMOUNT"].Value.ToString();
                    txtDescriptPay.Text = row.Cells["DESCRIPTION"].Value.ToString();
                  
                    //grdPayment.Rows.Clear();

                    //cmbChqNoPay.Text = row.Cells["CHQ_NO"].Value.ToString();
                    //chqId = row.Cells["CHQ_ID"].Value.ToString();

                    txtPaidToPayments.Text = row.Cells["PAID_TO"].Value.ToString();
                    //txtPayBankAmount.Text = grdPayment.Rows.Cast<DataGridViewRow>()
                    //.Sum(t => Convert.ToDecimal(t.Cells["amountPay"].Value)).ToString();
                    //txtAmountWordsPay.Text = DayBook.ConvertWholeNumber(txtAmountPay.Text);
                    //txtBankPayment.Text = row.Cells["CREDIT_AC"].Value.ToString();
                    //cmbSupplierPay.Text = row.Cells["PAYMENT_ID"].Value.ToString();
                    //cmbCustomerPay.SelectedValue = row.Cells["cust_id"].Value.ToString();

                    grdPayment.Rows.Clear();
                    dayBook.getPayChq(paybookID, grdPayment);
                    txtAmountPay.Text = (double.Parse(txtPayCashAmount.Text) + double.Parse(txtTotalGrdPayment.Text)).ToString();
                    
                    
                    //dayBook.loadPayGrid(grdPayment,int.Parse(paybookID));

                }
            }
            catch (Exception ex)
            {
                if(!ex.Message.Contains("Object reference"))
                    MessageBox.Show(ex.Message);
            }

        }

        private void PaymentGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            PaymentGrid.Columns["DAY_BOOK_ID"].HeaderText = "VOUCHER #";
            //PaymentGrid.Columns["PAY_AC"].Visible = false;
            //PaymentGrid.Columns["REC_AC"].Visible = false;
            //PaymentGrid.Columns["cust_id"].Visible = false;
            PaymentGrid.Columns["ENTRY_OF"].Visible = false;
            //PaymentGrid.Columns["CHQ_ID"].Visible = false;




        }

        private void PayChqGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.RowIndex!=-1)
                {
                    DataGridViewRow row = this.PayChqGrid.Rows[e.RowIndex];
                    dtpChqDatePV.Value = Convert.ToDateTime(row.Cells["CHQ_DATE"].Value.ToString()); 
                    txtChqAmountPay.Text = row.Cells["AMOUNT"].Value.ToString();
                    txtBankPayment.Text = row.Cells["BANK"].Value.ToString();
                    txtPayChqNo.Text = row.Cells["CHQ_NO"].Value.ToString();
                    PayChqGrid.Rows.RemoveAt(e.RowIndex);
                    txtPayBankAmount.Text = PayChqGrid.Rows.Cast<DataGridViewRow>()
                        .Sum(t => Convert.ToDecimal(t.Cells["AMOUNT"].Value)).ToString();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //gv grid search 
        public void gv_grid_search()
        {
            try
            {
                (EntryGrid.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
            CONVERT(" + EntryGrid.Columns["NARRATION"].Name.ToString() + ",System.String) LIKE '%" + txtSEARCH.Text + "%' OR ["
                  + EntryGrid.Columns["VOUCHER #"].Name.ToString() + "] LIKE '%" + txtSEARCH.Text + "%' OR CONVERT("
                  + EntryGrid.Columns["ACCOUNT"].Name.ToString() + ",System.String) LIKE '%" + txtSEARCH.Text + "%' OR CONVERT("
                  + EntryGrid.Columns["DEBIT"].Name.ToString() + ",System.String) LIKE '%" + txtSEARCH.Text + "%' OR CONVERT("
               //   + EntryGrid.Columns["DATE"].Name.ToString() + ",System.String) LIKE '%" + txtSEARCH.Text + "%' OR CONVERT("
                  + EntryGrid.Columns["CREDIT"].Name.ToString() + ",System.String) LIKE '%" + txtSEARCH.Text + "%'");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            EntryGrid.ClearSelection();
        }

        private void txtSEARCH_TextChanged(object sender, EventArgs e)
        {
            gv_grid_search();
        }

        private void cmbDebit_TextUpdate(object sender, EventArgs e)
        {
            db.CmbTextUpdate(sender as ComboBox);
        }

        private void cmbDebit_DropDown(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown += new PreviewKeyDownEventHandler(cmbDebit_PreviewKeyDown);
        }

        private void cmbCredit_DropDown(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown += new PreviewKeyDownEventHandler(cmbDebit_PreviewKeyDown);
        }

        private void cmbDebit_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown -= cmbDebit_PreviewKeyDown;
            if (cbo.DroppedDown) cbo.Focus();
        }

        private void cmbCredit_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown -= cmbDebit_PreviewKeyDown;
            if (cbo.DroppedDown) cbo.Focus();
        }
        //1
        private void cmbReceipt_DropDown(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown += new PreviewKeyDownEventHandler(cmbReceipt_PreviewKeyDown);
        }

        private void cmbBank_DropDown(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown += new PreviewKeyDownEventHandler(cmbBank_PreviewKeyDown);
        }

        private void cmbSupplierPay_DropDown(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown += new PreviewKeyDownEventHandler(cmbSupplierPay_PreviewKeyDown);
        }

        private void cmbPaymentBank_DropDown(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown += new PreviewKeyDownEventHandler(cmbPaymentBank_PreviewKeyDown);
        }

        private void cmbBankCD_DropDown(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown += new PreviewKeyDownEventHandler(cmbBankCD_PreviewKeyDown);
        }

        private void cmbReturnCustomer_DropDown(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown += new PreviewKeyDownEventHandler(cmbReturnCustomer_PreviewKeyDown);
        }
        //2
        private void cmbReceipt_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown -= cmbReceipt_PreviewKeyDown;
            if (cbo.DroppedDown) cbo.Focus();
        }

        private void cmbBank_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown -= cmbBank_PreviewKeyDown;
            if (cbo.DroppedDown) cbo.Focus();
        }

        private void cmbSupplierPay_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown -= cmbSupplierPay_PreviewKeyDown;
            if (cbo.DroppedDown) cbo.Focus();
        }

        private void cmbPaymentBank_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown -= cmbPaymentBank_PreviewKeyDown;
            if (cbo.DroppedDown) cbo.Focus();
        }

        private void cmbBankCD_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown -= cmbBankCD_PreviewKeyDown;
            if (cbo.DroppedDown) cbo.Focus();
        }

        private void cmbReturnCustomer_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown -= cmbReturnCustomer_PreviewKeyDown;
            if (cbo.DroppedDown) cbo.Focus();
        }

        //receipt grid search 
        public void receipt_grid_search()
        {
            (ReceiptsGrid.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
            [" + ReceiptsGrid.Columns["DESCRIPTION"].Name.ToString() + "] LIKE '%" + txtSearchReceipt.Text + "%' OR ["
               + ReceiptsGrid.Columns["CREDIT"].Name.ToString() + "] LIKE '%" + txtSearchReceipt.Text + "%' OR "
              + "CONVERT({0}, System.String) " + " LIKE '%" + txtSearchReceipt.Text + "%' OR ["
               + ReceiptsGrid.Columns["BANK"].Name.ToString() + "] LIKE '%" + txtSearchReceipt.Text + "%' OR ["
                + ReceiptsGrid.Columns["CHQ_NO"].Name.ToString() + "] LIKE '%" + txtSearchReceipt.Text + "%' OR ["
              + ReceiptsGrid.Columns["DEBIT"].Name.ToString() + "] LIKE '%" + txtSearchReceipt.Text + "%'", ReceiptsGrid.Columns["TOTAL_AMOUNT"].Name.ToString());
            ReceiptsGrid.ClearSelection();
        }

        //payment grid search 
        public void payment_grid_search()
        {
            (PaymentGrid.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
            [" + PaymentGrid.Columns["DESCRIPTION"].Name.ToString() + "] LIKE '%" + txtSEARCHPayments.Text + "%' OR ["
              + PaymentGrid.Columns["PAID_TO"].Name.ToString() + "] LIKE '%" + txtSEARCHPayments.Text + "%' OR "
              + "CONVERT({0}, System.String) " + " LIKE '%" + txtSEARCHPayments.Text + "%' OR ["
              + PaymentGrid.Columns["PAYMENT ACCOUNT"].Name.ToString() + "] LIKE '%" + txtSEARCHPayments.Text + "%' OR "
              + "CONVERT({2}, System.String) " + " LIKE '%" + txtSEARCHPayments.Text + "%' OR "

              + "CONVERT({1}, System.String) " + " LIKE '%" + txtSEARCHPayments.Text + "%'", PaymentGrid.Columns["TOTAL"].Name.ToString(), PaymentGrid.Columns["CHQ_TOTAL"].Name.ToString()
              , PaymentGrid.Columns["DAY_BOOK_ID"].Name.ToString());
            PaymentGrid.ClearSelection();
        }

        private void txtSearchReceipt_TextChanged(object sender, EventArgs e)
        {
            receipt_grid_search();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            payment_grid_search();
        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            Classes.Helper cls_fhp = new Classes.Helper();
            try
            {
                if (cmbAccountGV.SelectedIndex == 0)
                {
                    cls_fhp.ShowMessageBox("Account is not selected", "error");
                    //essageBox.Show("Account is not selected, please select account.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbAccountGV.Focus();
                }
                else if(txtDebitGV.Text.Equals(""))
                {
                    cls_fhp.ShowMessageBox("Amount is not entered", "error");
                    txtDebitGV.Focus();
                }


                else
                {
                    grdENTRY.Rows.Add(dtpDate.Value.ToString(), cmbAccountGV.Text, txtDebitGV.Text, txtCreditGV.Text, txtNarration.Text, cmbAccountGV.SelectedValue.ToString());
                    //if(isEdit>-1)
                    //{
                    //    grdENTRY.Rows.RemoveAt(isEdit);
                    //    grdENTRY.Rows.Insert(isEdit, dtpDate.Value.ToString(),cmbAccountGV.Text, txtDebitGV.Text, txtCreditGV.Text,txtNarration.Text,cmbAccountGV.SelectedValue.ToString());
                    //}
                    //else
                    //{
                    //    grdENTRY.Rows.Add(dtpDate.Value.ToString(), cmbAccountGV.Text, txtDebitGV.Text, txtCreditGV.Text, txtNarration.Text, cmbAccountGV.SelectedValue.ToString());
                    //}
                    cmbAccountGV.SelectedIndex = 0;
                    txtDebitGV.Text = "0";
                    txtCreditGV.Text = "0";
                    txtAmountWordsGen.Text = "-";
                    txtNarration.Clear();

                }
                isEdit = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void grdENTRY_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grdENTRY.Rows.Count > 0)
                {
                    if (e.RowIndex >= 0)
                    {
                        DialogResult diag = new DialogResult();
                        diag = MessageBox.Show("Do you want to delete this entry?", "Delete Entry", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (diag == DialogResult.Yes)
                        {
                            isEdit = e.RowIndex;
                            cmbAccountGV.Text = grdENTRY.Rows[e.RowIndex].Cells["ACC_NAME"].Value.ToString();
                            txtDebitGV.Text = grdENTRY.Rows[e.RowIndex].Cells["DEBIT"].Value.ToString();
                            txtCreditGV.Text = grdENTRY.Rows[e.RowIndex].Cells["CREDIT"].Value.ToString();
                            txtNarration.Text = grdENTRY.Rows[e.RowIndex].Cells["DESCRIPTION"].Value.ToString();
                            grdENTRY.Rows.RemoveAt(e.RowIndex);

                            //DataGridViewRow row = this.grdENTRY.Rows[e.RowIndex];
                            //if (DeletePVCChq(Convert.ToInt32(row.Cells["CHQ_ID"].Value.ToString()), Convert.ToInt32(paybookID),
                            //row.Cells["BANK"].Value.ToString(), row.Cells["CHQ_NO"].Value.ToString(),
                            //Convert.ToDecimal(row.Cells["AMOUNT"].Value.ToString())) > 0)
                            //{
                                
                            //}
                        }
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAddRecPerson_Click(object sender, EventArgs e)
        {
            //if(cmbRecoveryPerson.SelectedIndex<0)
            //{
            //    DialogResult diag = new DialogResult();
            //    diag = MessageBox.Show("Do you want to add new recovery person?", "Add New Person", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            //    if(diag == DialogResult.Yes)
            //    {
            //        string temp = cmbRecoveryPerson.Text;
            //        dayBook.insert_Rec_Person(cmbRecoveryPerson.Text);
            //        dayBook.loadRecoveryPerson(cmbRecoveryPerson);
            //        cmbRecoveryPerson.Text = temp;
            //    }
            //}
        }

        private void txtAmountReceipt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int.Parse(txtAmountReceipt.Text);
                txtAmountWordsRec.Text = DayBook.ConvertWholeNumber(txtAmountReceipt.Text);
            }
            catch
            {

            }
        }

        private void cmbRecoveryDetailsPerson_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            dayBook.loadRecoveryDetails(grdRecoveryDetails, cmbRecoveryDetailsPerson.SelectedValue.ToString(), dtpFrom.Value.ToString("yyyy-MM-dd"), dtpTo.Value.ToString("yyyy-MM-dd"));
        }

        private void grdRecoveryDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            txtCashTotalRec.Clear();
            txtChqTotalRec.Clear();
            double totalCash = 0, totalChq = 0;
            foreach (DataGridViewRow row in grdRecoveryDetails.Rows)
            {
                totalCash += double.Parse(row.Cells["CASH"].Value.ToString());
                totalChq += double.Parse(row.Cells["CHQ_AMOUNT"].Value.ToString());
            }
            txtCashTotalRec.Text = totalCash.ToString();
            txtChqTotalRec.Text = totalChq.ToString();
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            dayBook.loadRecoveryDetails(grdRecoveryDetails, cmbRecoveryDetailsPerson.SelectedValue.ToString(), dtpFrom.Value.ToString("yyyy-MM-dd"), dtpTo.Value.ToString("yyyy-MM-dd"));
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteGeneral_Click(object sender, EventArgs e)
        {
            if (gv_id.Equals(""))
            {
                MessageBox.Show("Please select an entry from the upper grid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (MessageBox.Show("Do you really want to delete this entry?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    db.query = @"DELETE FROM GENERAL_VOUCHER_M WHERE GV_ID = '" + gv_id + @"';
                                 DELETE FROM GENERAL_VOUCHER_D WHERE GV_ID = '"+gv_id+"'; " +
                                 "DELETE FROM LEDGERS WHERE REF_ID = '"+gv_id+"' AND ENTRY_OF = 'GENERAL VOUCHER'";
                    if (db.InsertUpdateDelete(db.query) > 0)
                    {
                        MessageBox.Show("Entry deleted successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Generalclear();
                        loadGE();

                    }
                }
            }
        }

        private void txtAmountPay_TextChanged(object sender, EventArgs e)
        {
            txtAmountWordsPay.Text = DayBook.ConvertWholeNumber(txtAmountPay.Text);
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (daybookID.Equals(""))
            {
                MessageBox.Show("Please select an entry from the upper grid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (MessageBox.Show("Do you really want to delete this entry?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    db.query = @"BEGIN TRY 
                             BEGIN TRANSACTION ";

                    db.query += @"IF EXISTS (SELECT A.CHQ_ID 
                    FROM CHQ A
                    INNER JOIN DAY_BOOK_CHQ B ON A.CHQ_ID = B.CHQ_ID
                    WHERE A.[STATUS] = 0 AND B.DAY_BOOK_ID = '" + daybookID + @"')
                    BEGIN
                        SELECT 'ERROR' AS [ERROR]
                    END
                    ELSE
                    BEGIN
                        DELETE FROM CHQ WHERE CHQ_ID IN (SELECT CHQ_ID FROM DAY_BOOK_CHQ WHERE DAY_BOOK_ID = '" + daybookID + @"');
                        DELETE FROM DAY_BOOK WHERE DAY_BOOK_ID = '" + daybookID + @"';
                        DELETE FROM DAY_BOOK_CHQ WHERE DAY_BOOK_ID = '" + daybookID + @"';
                        DELETE FROM LEDGERS WHERE REF_ID = " + daybookID + @" AND 
                        (ENTRY_OF = 'RECEIPT VOUCHER' OR ENTRY_OF = 'RECEIPT VOUCHER CASH');
                        SELECT 'OK' AS [ERROR]
                    END";

                    db.query += @" COMMIT TRANSACTION 
                        END TRY 
                    BEGIN CATCH 
                            IF @@TRANCOUNT > 0 
                            ROLLBACK TRANSACTION;
                            THROW
                    END CATCH";

                    char isDeleted = 'F';
                    if (Classes.Helper.conn.State == System.Data.ConnectionState.Closed) { Classes.Helper.conn.Open(); }
                    try
                    {
                        db.cmd = new SqlCommand(db.query, Classes.Helper.conn);
                        db.cmd.CommandTimeout = 0;
                        db.dr = db.cmd.ExecuteReader();
                        if (db.dr.HasRows)
                        {
                            while (db.dr.Read())
                            {
                                if (db.dr["ERROR"].ToString().Equals("OK")) {
                                    MessageBox.Show("Record Deleted Sucessfully", "Information");
                                    isDeleted = 'T';
                                    //loadReceipt();
                                }
                                else {
                                    MessageBox.Show("Entry Cannot be Deleted, Chq has been paid.", "Error");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Exception");
                    }
                    finally
                    {
                        Classes.Helper.conn.Close();
                    }
                    if (isDeleted == 'T') {
                        ReceiptClear();
                    }
                    
                    //if (db.InsertUpdateDelete(db.query)>0)
                    //{
                    //    MessageBox.Show("Entry deleted successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    loadReceipt();

                    //}
                    //else
                    //{
                    //    MessageBox.Show("Error deleting record", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                }
            }
        }

        private void btnDeletePayment_Click(object sender, EventArgs e)
        {
            if (paybookID.Equals(""))
            {
                MessageBox.Show("Please select an entry from the upper grid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (MessageBox.Show("Do you really want to delete this entry?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    db.query = @"BEGIN TRY 
                             BEGIN TRANSACTION ";

                    db.query += @"
                        UPDATE CHQ SET PAY_AC = NULL, PAY_DATE = NULL,STATUS=1  WHERE CHQ_ID IN (SELECT CHQ_ID FROM DAY_BOOK_CHQ WHERE DAY_BOOK_ID = '" + paybookID + @"');
                        DELETE FROM DAY_BOOK WHERE DAY_BOOK_ID = '" + paybookID + @"';
                        DELETE FROM LEDGERS WHERE REF_ID = " + paybookID + @" AND 
                        (ENTRY_OF = 'PAYMENT VOUCHER' OR ENTRY_OF = 'PAYMENT VOUCHER CASH' OR ENTRY_OF ='RECEIPT VOUCHER');";

                    db.query += @" COMMIT TRANSACTION 
                        END TRY 
                    BEGIN CATCH 
                            IF @@TRANCOUNT > 0 
                            ROLLBACK TRANSACTION;
                            THROW
                    END CATCH";

                    if (db.InsertUpdateDelete(db.query) > 0)
                    {
                        MessageBox.Show("Entry deleted successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        loadPayment();
                        PaymentClear();
                    }



                    //        if (chqId.Equals(""))
                    //{
                    //    MessageBox.Show("Please select an entry from the lower grid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                    //else
                    //{
                    //    if (MessageBox.Show("Do you really want to unpay this CHQ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    //    {
                    //        db.query = @"UPDATE CHQ SET STATUS = 1,PAY_AC=NULL WHERE CHQ_ID = '" + chqId + @"';
                    //                    DELETE FROM DAY_BOOK_CHQ WHERE DAY_BOOK_ID = '" + paybookID + "' AND CHQ_ID = '" + chqId + @"';
                    //                    DELETE FROM LEDGERS WHERE REF_ID = '" + paybookID + "' and ENTRY_OF = 'PAYMENT VOUCHER';" +
                    //                    "IF NOT EXISTS (SELECT CHQ_ID FROM DAY_BOOK_CHQ WHERE DAY_BOOK_ID = '" + paybookID + @"')
                    //                    BEGIN
                    //                    DELETE FROM DAY_BOOK WHERE DAY_BOOK_ID = '" + paybookID + @"';
                    //                    END";
                    //        if (db.InsertUpdateDelete(db.query) > 0)
                    //        {
                    //            MessageBox.Show("Entry deleted successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //            loadPayment();
                    //            PaymentClear();
                    //        }
                }
            }
        }

        private void rowAddedOrRemoved()
        {
            if (grdENTRY.Rows.Count > 0)
            {
                txtDebitTotalGV.Text = grdENTRY.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToDecimal(t.Cells["DEBIT"].Value)).ToString();

                txtCreditTotalGV.Text = grdENTRY.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToDecimal(t.Cells["CREDIT"].Value)).ToString();
            }

            //txtDebitTotalGV.Text = "0";
            //txtCreditTotalGV.Text = "0";

            //foreach (DataGridViewRow row in  grdENTRY.Rows)
            //{
            //    txtDebitTotalGV.Text = Math.Round(float.Parse(txtDebitTotalGV.Text) + float.Parse(row.Cells["DEBIT"].Value.ToString()),0).ToString();
            //    txtCreditTotalGV.Text = Math.Round(float.Parse(txtCreditTotalGV.Text) + float.Parse(row.Cells["CREDIT"].Value.ToString()),0).ToString();
            //}
        }

        private void grdENTRY_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            rowAddedOrRemoved();
        }

        private void grdENTRY_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            rowAddedOrRemoved();
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int.Parse(txtDebitGV.Text);
                txtAmountWordsGen.Text = DayBook.ConvertWholeNumber(txtDebitGV.Text);
                
            }
            catch
            {

            }
        }

        private void txtCreditGV_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int.Parse(txtCreditGV.Text);
                txtAmountWordsGen.Text = DayBook.ConvertWholeNumber(txtCreditGV.Text);
                
            }
            catch 
            {

            }
        }

        private void txtCreditGV_KeyPress(object sender, KeyPressEventArgs e)
        {
            db.CheckNumber(e);
            txtDebitGV.Text = "0";      
        }
        private void grdPaidChqsCD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>=0)
            {
                chqId = grdPaidChqsCD.Rows[e.RowIndex].Cells["CHQ_ID"].Value.ToString();
            }
        }

        private void grdPaidChqsCD_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            grdPaidChqsCD.Columns["CHQ_ID"].Visible = false;
        }

        private void deleteBtnCD_Click(object sender, EventArgs e)
        {
            if (chqId.Equals(""))
            {
                MessageBox.Show("Please select an entry from the grid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (MessageBox.Show("This cheque will be unpaid, continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    db.query = @"UPDATE CHQ SET STATUS = 1 WHERE CHQ_ID = '" + chqId + "'";
                    if (db.InsertUpdateDelete(db.query) > 0)
                    {
                        MessageBox.Show("Entry removed successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadCD();

                    }
                }
            }
        }
        DateTime dateOfChq;

        private void cmbChqNoPay_SelectedIndexChanged(object sender, EventArgs e)
        {
            return;
     //       string id="";
     //       //grdPayment.Rows.Clear();
     //       try
     //       {
     //           db.query = @"SELECT D.DAY_BOOK_ID as [id],E.COA_ID as [CUSTOMER],AMOUMT as[TOTAL_AMOUNT],ISNULL(DESCRIPTION,'-')  as [DESCRIPTION],CASH_AMOUNT AS[CASH AMOUNT],AMOUNT AS[CHQ_AMOUNT],
					//ISNULL(G.BANK_NAME,'-') as [BANK],G.CHQ_DATE
			  //      FROM DAY_BOOK D
     //               LEFT JOIN COA C ON C.COA_ID=D.DEBIT_AC
     //               LEFT JOIN COA E ON E.COA_ID=D.CREDIT_AC
			  //      LEFT JOIN DAY_BOOK_CHQ F ON D.DAY_BOOK_ID =f.DAY_BOOK_ID
			  //      LEFT JOIN CHQ G ON F.CHQ_ID = G.CHQ_ID
     //               WHERE G.CHQ_NO = '" + cmbChqNoPay.Text + "'";
     //           if (Classes.Helper.conn.State == ConnectionState.Closed)
     //               Classes.Helper.conn.Open();
     //           db.cmd = new SqlCommand(db.query, Classes.Helper.conn);
     //           db.dr = db.cmd.ExecuteReader();
     //           db.dr.Read();
     //           if(db.dr.HasRows)
     //           {
     //               txtBankPayment.Text = db.dr["BANK"].ToString();
     //               txtPayChqAmount.Text = db.dr["CHQ_AMOUNT"].ToString();
     //               cmbCustomerPay.SelectedValue = db.dr["CUSTOMER"].ToString();
     //               dateOfChq = DateTime.Parse(db.dr["CHQ_DATE"].ToString());
     //               //txtPayCashAmount.Text = db.dr["CASH AMOUNT"].ToString();
     //               //txtAmountPay.Text = db.dr["TOTAL_AMOUNT"].ToString();
     //               dtpChqDatePV.Value = dateOfChq;

     //               //txtDescriptPay.Text = db.dr["DESCRIPTION"].ToString();
     //               txtAmountPay.Text = (Double.Parse(txtPayChqAmount.Text) +Double.Parse(txtPayCashAmount.Text)).ToString();
     //               id = db.dr["id"].ToString();
     //               //paybookID = id;
     //               //paybookID = id;
     //               db.dr.Close();
                    //dayBook.getChqByNum(id, cmbChqNoPay.Text, grdPayment);

            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //finally
            //{
            //    Classes.Helper.conn.Close();
            //    db.dr.Close();
            //}
            
                   
        }

        private void grdPayment_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            txtTotalGrdPayment.Text = grdPayment.Rows.Cast<DataGridViewRow>()
                    .Sum(t => Convert.ToDecimal(t.Cells["AMOUNT"].Value)).ToString();
        }

        private void grdPayment_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            txtTotalGrdPayment.Text = grdPayment.Rows.Cast<DataGridViewRow>()
                   .Sum(t => Convert.ToDecimal(t.Cells["AMOUNT"].Value)).ToString();
        }

        private void btnVoucherWithCust_Click(object sender, EventArgs e)
        {
            try
            {
                if (!paybookID.Equals(""))
                {
                    voucher.PaymentVoucherReportWithCust(Convert.ToInt32(paybookID));
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

        private void txtChqTotal_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtAmountReceipt.Text = (Convert.ToDecimal(txtCashAmount.Text)+Convert.ToDecimal(txtChqTotal.Text)).ToString();
            }
            catch
            {

            }
        }

        private void generateChqReturnVoucher()
        {
            // **** UNDER DEVELOPMENT **** 
            db.nds.Tables["ChqReturnVoucher"].Clear();
            foreach (DataGridViewRow rows in grdReturn.Rows)
            {
                if (rows.Cells["RETURN"].Value.ToString().Equals("True"))
                {
                    if (rows.Cells["PAY_AC"].Value.ToString().Equals("-"))
                    {
                        db.dataR = db.nds.Tables["ChqReturnVoucher"].NewRow();
                        db.dataR["date"] = Convert.ToDateTime(dtpReturn.Value.Date);
                        db.dataR["voucherNo"] = generateCRNum();
                        db.dataR["accName"] = cmbReturnCustomer.Text.ToString();
                        db.dataR["narration"] = txtChqReturnReason.Text;
                        db.dataR["Bank"] = rows.Cells["BANK"].Value.ToString();
                        db.dataR["rupees"] = "";// db.ConvertWholeNumber(rows.Cells["AMOUNT"].Value.ToString());
                        db.dataR["debit"] = Convert.ToDecimal(rows.Cells["AMOUNT"].Value.ToString());
                        db.dataR["credit"] = 0;
                        db.dataR["chqNo"] = rows.Cells["CHQ NO"].Value.ToString();
                        db.dataR["chqDate"] = Convert.ToDateTime(rows.Cells["CHQ DATE"].Value.ToString());

                        db.nds.Tables["ChqReturnVoucher"].Rows.Add(db.dataR);
                    }
                    else
                    {
                        db.dataR = db.nds.Tables["ChqReturnVoucher"].NewRow();
                        db.dataR["date"] = Convert.ToDateTime(dtpReturn.Value.Date);
                        db.dataR["voucherNo"] = generateCRNum();
                        db.dataR["accName"] = cmbReturnCustomer.Text.ToString();
                        db.dataR["narration"] = txtChqReturnReason.Text;
                        db.dataR["Bank"] = rows.Cells["BANK"].Value.ToString();
                        db.dataR["rupees"] = "";//db.ConvertWholeNumber(rows.Cells["AMOUNT"].Value.ToString());
                        db.dataR["debit"] = Convert.ToDecimal(rows.Cells["AMOUNT"].Value.ToString());
                        db.dataR["credit"] = 0;
                        db.dataR["chqNo"] = rows.Cells["CHQ NO"].Value.ToString();
                        db.dataR["chqDate"] = Convert.ToDateTime(rows.Cells["CHQ DATE"].Value.ToString());

                        db.nds.Tables["ChqReturnVoucher"].Rows.Add(db.dataR);

                        db.dataR = db.nds.Tables["ChqReturnVoucher"].NewRow();
                        db.dataR["date"] = Convert.ToDateTime(dtpReturn.Value.Date);
                        db.dataR["voucherNo"] = generateCRNum();
                        db.dataR["accName"] = rows.Cells["PAY_AC"].Value.ToString();
                        db.dataR["narration"] = txtChqReturnReason.Text;
                        db.dataR["Bank"] = rows.Cells["BANK"].Value.ToString();
                        db.dataR["rupees"] = "";//db.ConvertWholeNumber(rows.Cells["AMOUNT"].Value.ToString());
                        db.dataR["debit"] = 0;
                        db.dataR["credit"] = Convert.ToDecimal(rows.Cells["AMOUNT"].Value.ToString());
                        db.dataR["chqNo"] = rows.Cells["CHQ NO"].Value.ToString();
                        db.dataR["chqDate"] = Convert.ToDateTime(rows.Cells["CHQ DATE"].Value.ToString());

                        db.nds.Tables["ChqReturnVoucher"].Rows.Add(db.dataR);
                    }
                }
            }
            db.rpt = new Forms.Reporting.frmReports();
            db.rpt.GenerateReport("ChqReturn", db.nds);
            db.rpt.ShowDialog();
        }

        private void show_report()
        {
            db.nds.Tables["JV"].Clear();
            foreach (DataGridViewRow rows in grdENTRY.Rows)
            {
                db.dataR = db.nds.Tables["JV"].NewRow();
                db.dataR["date"] = Convert.ToDateTime(dtpDate.Value.Date);
                db.dataR["voucherNo"] = lblGV.Text;
                db.dataR["accountName"] = rows.Cells["acc_name"].Value.ToString();
                db.dataR["description"] = rows.Cells["description"].Value.ToString();
                db.dataR["debit"] = Convert.ToDouble(rows.Cells["debit"].Value.ToString());
                db.dataR["credit"] = Convert.ToDouble(rows.Cells["credit"].Value.ToString());
                db.nds.Tables["JV"].Rows.Add(db.dataR);
            }
            db.rpt = new Forms.Reporting.frmReports();
            db.rpt.GenerateReport("JV", db.nds);
            db.rpt.ShowDialog();
        }

        private void btn_VIEW_VOUCHER_Click(object sender, EventArgs e)
        {
            try
            {
                //if (db.CheckNameExists(grdENTRY, lblHV.Text, 2) == 1)
                if(grdENTRY.Rows.Count>0)
                { show_report(); }
                else
                {
                    db.ShowMessageBox("Record Not Found To Print", "error");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void rdbPaid_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
