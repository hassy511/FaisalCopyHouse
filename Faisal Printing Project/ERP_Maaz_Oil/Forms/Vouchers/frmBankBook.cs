using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace ERP_Maaz_Oil.Forms.Vouchers
{
    public partial class frmBankBook : Form
    {

        Classes.Helper cls_db = new Classes.Helper();
        Classes.Helper cls_fhp = new Classes.Helper();
        private string bb_id = "";

        public frmBankBook()
        {
            InitializeComponent();
        }

        private void LoadCombos()
        {
            cls_db.query = @"SELECT '0' as id, '--SELECT CHQ NO--' as name
            UNION ALL
            SELECT CHQ_ID as id, CHQ_NO as name from CHQ where [status] = 1";
            cls_db.LoadComboData(cmbChqNo, cls_db.query);

            cls_db.query = @"SELECT '0' as id, '--SELECT ACCOUNT--' as name
            UNION ALL
            SELECT COA_ID as id,COA_NAME as name from COA";

            cls_db.LoadComboData(cmbPaymentAc, cls_db.query);
            cls_db.LoadComboData(cmbRecAc, cls_db.query);

            cls_db.query = @"SELECT '0' as id, '--SELECT ACCOUNT--' as name
            UNION ALL
            SELECT DISTINCT REF_AC as id,REF_AC as name FROM BANK_BOOK";
            
            cls_db.LoadComboData(cmbRefAc, cls_db.query);


            cls_db.query = @"SELECT '0' as [id], '--SELECT INSTRUMENT--' as [name]
                    UNION ALL
            SELECT distinct INSTRUMENT as [id],INSTRUMENT as [name] FROM BANK_BOOK";
            cls_db.LoadComboData(cmbInstrumentNo, cls_db.query);

        }

        private void LoadForm() {
            LoadCombos();
            LoadGrid();
            getBVNum();
            TotalRowSum();

            load_rec_grid(grdRecSummary, dtpDate.Value);
            load_pay_grid(grdPaySummary, dtpDate.Value);
        }
        private void LoadGrid()
        {
            cls_db.query = @"
                SELECT A.DATE,B.COA_NAME as [RECEIVE ACC],C.COA_NAME as [PAYMENT ACC],A.REF_AC as [REF ACC],A.AMOUNT,ISNULL(D.CHQ_NO,'-') as CHQ_NO,A.INSTRUMENT,A.NARRATION,
                A.BB_ID,A.PAY_AC,A.REC_AC
                FROM BANK_BOOK A
                INNER JOIN COA B ON A.REC_AC = B.COA_ID
                INNER JOIN COA C ON A.PAY_AC = C.COA_ID
                LEFT JOIN CHQ D ON A.CHQ_ID = D.CHQ_ID
                WHERE A.DATE BETWEEN '"+dtpDate.Value.Date+"' and '"+dtpDate.Value.Date.AddDays(1).Date+"'";

            cls_db.LoadGrid(grdEntries, cls_db.query);
        }

        private void frmBankBook_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void SaveValidation()
        {
            if (cmbRecAc.SelectedIndex == 0)
            {
                MessageBox.Show("Please select Received account", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            //else if (cmbChqNo.SelectedIndex == 0)
            //{
            //    MessageBox.Show("Please select CHQ NO", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //}
            else if (cmbRefAc.Text.Equals("--SELECT ACCOUNT--") || cmbRefAc.Text.Equals(""))
            {
                MessageBox.Show("Please select Reference account", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (cmbPaymentAc.SelectedIndex == 0)
            {
                MessageBox.Show("Please select Payment account", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (txtAmount.Text.Equals("0") || txtAmount.Text.Equals(""))
            {
                MessageBox.Show("Please enter amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (cmbInstrumentNo.Text.Equals("--SELECT INSTRUMENT--") || cmbInstrumentNo.Text.Equals(""))
            {
                MessageBox.Show("Please select instrument", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                Save();
            }
        }

        private void Save()
        {
            string id;
            if (bb_id.Equals(""))
            {
                id = "(SELECT MAX(BB_ID) FROM BANK_BOOK)";
            }
            else
            {
                id = bb_id;
            }

            int chqId = 0;
            if (cmbChqNo.SelectedIndex > 0) {
                chqId = Convert.ToInt32(cmbChqNo.SelectedValue.ToString());
            }

            cls_db.query = @"BEGIN TRY 
                BEGIN TRANSACTION ";
            if (chqId == 0)
            {
                cls_db.query += @"IF EXISTS (SELECT BB_ID FROM BANK_BOOK WHERE BB_ID = '" + bb_id + @"')
                BEGIN
                    UPDATE BANK_BOOK SET DATE = '" + dtpDate.Value + "', REC_AC = '" + cmbRecAc.SelectedValue.ToString() +
                "',PAY_AC='" + cmbPaymentAc.SelectedValue.ToString() +
                "',AMOUNT='" + txtAmount.Text + "',NARRATION='" + txtNarration.Text +
                "',CHQ_ID='" + chqId + "',INSTRUMENT = '" + cmbInstrumentNo.Text + @"',REF_AC = '" + cmbRefAc.Text + @"'
                    WHERE BB_ID = '" + bb_id + @"';
                
                    DELETE FROM LEDGERS WHERE REF_ID = '" + bb_id + @"' AND ENTRY_OF = 'BANK BOOK'
                
                    INSERT INTO LEDGERS VALUES ('" + dtpDate.Value + "','" + cmbPaymentAc.SelectedValue.ToString() + "','" + bb_id + "','BANK BOOK','" + lblVoucherNo.Text + @"',
                    '" + txtAmount.Text + @"','0',
                    '"+cmbRecAc.Text+"/"+cmbPaymentAc.Text+"/"+cmbRefAc.Text+"/ CHQ# "+cmbChqNo.Text+"/"+cmbInstrumentNo.Text+"/"+txtNarration.Text+@"',
                    1,GETDATE(),null,null,1,'" + cmbRefAc.Text + @"');
                
                    INSERT INTO LEDGERS VALUES ('" + dtpDate.Value + "','" + cmbRecAc.SelectedValue.ToString() + "','" + bb_id + @"','BANK BOOK',
                    '" + lblVoucherNo.Text + "','0','" + txtAmount.Text + @"',
                    '"+cmbPaymentAc.Text+"/"+cmbRecAc.Text+"/"+cmbRefAc.Text+"/ CHQ# "+cmbChqNo.Text+"/"+cmbInstrumentNo.Text+"/"+txtNarration.Text + @"',1,GETDATE(),
                    null,null,1,'" + cmbRefAc.Text + @"');

                    END
                ELSE
                BEGIN
                    INSERT INTO BANK_BOOK(DATE,AMOUNT,REC_AC,PAY_AC,REF_AC,CHQ_ID,INSTRUMENT,NARRATION) 
                    VALUES ('" + dtpDate.Value.ToString() + "','" + txtAmount.Text + "','" + cmbRecAc.SelectedValue.ToString() + @"',
                    '" + cmbPaymentAc.SelectedValue.ToString() + "','" + cmbRefAc.Text + "','" + chqId + "','" + cmbInstrumentNo.Text + @"',
                    '" + txtNarration.Text + @"');
                
                    INSERT INTO LEDGERS VALUES ('" + dtpDate.Value + "','" + cmbPaymentAc.SelectedValue.ToString() + @"',
                    (SELECT MAX(BB_ID) FROM BANK_BOOK),'BANK BOOK',
                    '" + lblVoucherNo.Text + "','" + txtAmount.Text + @"','0',
                    '"+cmbRecAc.Text+"/"+cmbPaymentAc.Text+"/"+cmbRefAc.Text+"/ CHQ# "+cmbChqNo.Text+"/"+cmbInstrumentNo.Text+@" / "+txtNarration.Text + @"',
                    1,GETDATE(),null,null,1,'" + cmbRefAc.Text + @"');
                
                    INSERT INTO LEDGERS VALUES ('" + dtpDate.Value + "','" + cmbRecAc.SelectedValue.ToString() + @"',
                    (SELECT MAX(BB_ID) FROM BANK_BOOK),'BANK BOOK','" + lblVoucherNo.Text + "','0','" + txtAmount.Text + @"',
                    '" + cmbPaymentAc.Text + "/" + cmbRecAc.Text + "/" + cmbRefAc.Text + "/ CHQ# " + cmbChqNo.Text + "/" + cmbInstrumentNo.Text + " / " + txtNarration.Text + @"',
                    1,GETDATE(),null,null,1,'" + cmbRefAc.Text + @"');
                END";
            }
            else {
                //Cheque update
                cls_db.query += @" UPDATE CHQ SET PAY_AC = '" + cmbPaymentAc.SelectedValue.ToString() + "', PAY_DATE = '" + dtpDate.Value.ToString() + @"',STATUS=0 WHERE CHQ_ID='" + cmbChqNo.SelectedValue.ToString() + @"';";

                cls_db.query += @"IF EXISTS (SELECT BB_ID FROM BANK_BOOK WHERE BB_ID = '" + bb_id + @"')
                BEGIN
                    UPDATE BANK_BOOK SET DATE = '" + dtpDate.Value + "', REC_AC = '" + cmbRecAc.SelectedValue.ToString() +
                "',PAY_AC='" + cmbPaymentAc.SelectedValue.ToString() +
                "',AMOUNT='" + txtAmount.Text + "',NARRATION='" + txtNarration.Text +
                "',CHQ_ID='" + cmbChqNo.SelectedValue.ToString() + "',INSTRUMENT = '" + cmbInstrumentNo.Text + @"',REF_AC = '" + cmbRefAc.Text + @"'
                    WHERE BB_ID = '" + bb_id + @"';
                
                    DELETE FROM LEDGERS WHERE REF_ID = '" + bb_id + @"' AND ENTRY_OF = 'BANK BOOK'
                
                    INSERT INTO LEDGERS VALUES ('" + dtpDate.Value + "',(SELECT COA_ID FROM COA WHERE COA_NAME = 'CHQ IN HAND')," + id + ",'BANK BOOK','" + lblVoucherNo.Text + "','" + txtAmount.Text + @"','0',
                    '" + cmbRecAc.Text + "/" + cmbPaymentAc.Text + "/" + cmbRefAc.Text + "/ CHQ# " + cmbChqNo.Text + "/" + cmbInstrumentNo.Text + "/" + txtNarration.Text + @"'
                    ,1,GETDATE(),null,null,1,'" + cmbRefAc.Text + @"');
                
                    INSERT INTO LEDGERS VALUES ('" + dtpDate.Value + "',(SELECT REC_AC FROM CHQ WHERE CHQ_ID = '"+chqId+"')," + id + @",'BANK BOOK',
                    '" + lblVoucherNo.Text + "','0','" + txtAmount.Text + @"',
                    '" + cmbPaymentAc.Text + "/" + cmbRecAc.Text + "/" + cmbRefAc.Text + @"/ CHQ# " + cmbChqNo.Text + "/" + cmbInstrumentNo.Text + "/" + txtNarration.Text + @"',
                    1,GETDATE(),
                    null,null,1,'" + cmbRefAc.Text + @"');

                    INSERT INTO LEDGERS VALUES ('" + dtpDate.Value + "',(SELECT pay_AC FROM CHQ WHERE CHQ_ID = '" + chqId + "')," + id + ",'BANK BOOK','" + lblVoucherNo.Text + "','" + txtAmount.Text + @"','0',
                    '" + cmbRecAc.Text + "/" + cmbPaymentAc.Text + "/" + cmbRefAc.Text + "/ CHQ# " + cmbChqNo.Text + "/" + cmbInstrumentNo.Text + "/" + txtNarration.Text + @"'
                    ,1,GETDATE(),null,null,1,'" + cmbRefAc.Text + @"');
                
                    INSERT INTO LEDGERS VALUES ('" + dtpDate.Value + "',(SELECT COA_ID FROM COA WHERE COA_NAME = 'CHQ IN HAND')," + id + @",'BANK BOOK',
                    '" + lblVoucherNo.Text + "','0','" + txtAmount.Text + @"',
                    '" + cmbPaymentAc.Text + "/" + cmbRecAc.Text + "/" + cmbRefAc.Text + @" / CHQ# " + cmbChqNo.Text + "/" + cmbInstrumentNo.Text + "/" + txtNarration.Text + @"',
                    1,GETDATE(),
                    null,null,1,'" + cmbRefAc.Text + @"');

                    END
                ELSE
                BEGIN
                    INSERT INTO BANK_BOOK(DATE,AMOUNT,REC_AC,PAY_AC,REF_AC,CHQ_ID,INSTRUMENT,NARRATION) 
                    VALUES ('" + dtpDate.Value.ToString() + "','" + txtAmount.Text + "','" + cmbRecAc.SelectedValue.ToString() + @"',
                    '" + cmbPaymentAc.SelectedValue.ToString() + "','" + cmbRefAc.Text + "','" + cmbChqNo.SelectedValue.ToString() + "','" + cmbInstrumentNo.Text + @"',
                    '" + txtNarration.Text + @"');
                
                    INSERT INTO LEDGERS VALUES ('" + dtpDate.Value + "',(SELECT COA_ID FROM COA WHERE COA_NAME = 'CHQ IN HAND')," + id + ",'BANK BOOK','" + lblVoucherNo.Text + "','" + txtAmount.Text + @"','0',
                    '" + cmbRecAc.Text + "/" + cmbPaymentAc.Text + "/" + cmbRefAc.Text + "/ CHQ# " + cmbChqNo.Text + "/" + cmbInstrumentNo.Text + "/" + txtNarration.Text + @"'
                    ,1,GETDATE(),null,null,1,'" + cmbRefAc.Text + @"');
                
                    INSERT INTO LEDGERS VALUES ('" + dtpDate.Value + "',(SELECT REC_AC FROM CHQ WHERE CHQ_ID = '" + chqId + "')," + id + @",'BANK BOOK',
                    '" + lblVoucherNo.Text + "','0','" + txtAmount.Text + @"','" + cmbPaymentAc.Text + "/" + cmbRecAc.Text + "/" + cmbRefAc.Text + @"/ CHQ# " + cmbChqNo.Text + "/" + cmbInstrumentNo.Text + "/" + txtNarration.Text + @"',1,GETDATE(),
                    null,null,1,'" + cmbRefAc.Text + @"');

                    INSERT INTO LEDGERS VALUES ('" + dtpDate.Value + "',(SELECT pay_AC FROM CHQ WHERE CHQ_ID = '" + chqId + "')," + id + ",'BANK BOOK','" + lblVoucherNo.Text + "','" + txtAmount.Text + @"','0',
                    '" + cmbRecAc.Text + "/" + cmbPaymentAc.Text + "/" + cmbRefAc.Text + "/ CHQ# " + cmbChqNo.Text + "/" + cmbInstrumentNo.Text + "/" + txtNarration.Text + @"'
                    ,1,GETDATE(),null,null,1,'" + cmbRefAc.Text + @"');
                
                    INSERT INTO LEDGERS VALUES ('" + dtpDate.Value + "',(SELECT COA_ID FROM COA WHERE COA_NAME = 'CHQ IN HAND')," + id + @",'BANK BOOK',
                    '" + lblVoucherNo.Text + "','0','" + txtAmount.Text + @"','" + cmbPaymentAc.Text + "/" + cmbRecAc.Text + "/" + cmbRefAc.Text + @"/ CHQ# " + cmbChqNo.Text + "/" + cmbInstrumentNo.Text + "/" + txtNarration.Text + @"',1,GETDATE(),
                    null,null,1,'" + cmbRefAc.Text + @"');
                END";
            }


            

            //cls_db.query += @" INSERT INTO LEDGERS (DATE,DESCRIPTIONS,COA_ID,REF_ID,ENTRY_OF,DEBIT,CREDIT,CREATED_BY,CREATION_DATE,COMPANY_ID) 
            //                    VALUES ('" + Classes.Helper.ConvertDatetime(dtpDate.Value.Date) + @"',
            //                    'RECEIPT PAYMENT IN +(select bank_name from chq where chq_id = '"+cmbChqNo.SelectedValue.ToString()+@"')+CHQ #: " + cmbChqNo.SelectedValue.ToString() + @"',
            //                    " + "(SELECT COA_ID FROM COA WHERE COA_NAME = 'CHQ IN HAND')" + @",
            //                    " + id + ",'RECEIPT VOUCHER','" + txtAmount.Text + @"','0',1,GETDATE(),1); ";

            //cls_db.query += @" INSERT INTO LEDGERS (DATE,DESCRIPTIONS,COA_ID,REF_ID,ENTRY_OF,DEBIT,CREDIT,CREATED_BY,CREATION_DATE,COMPANY_ID) 
            //                    VALUES ('" + Classes.Helper.ConvertDatetime(dtpDate.Value.Date) + @"',
            //                    'RECEIPT PAYMENT IN +(select bank_name from chq where chq_id = '" + cmbChqNo.SelectedValue.ToString() + @"')+CHQ #: " + cmbChqNo.SelectedValue.ToString() + @"',
            //                    " + "(SELECT COA_ID FROM COA WHERE COA_NAME = 'CHQ IN HAND')" + @",
            //                    " + id + ",'RECEIPT VOUCHER','" + txtAmount.Text + @"','0',1,GETDATE(),1); ";

            //cls_db.query += @" INSERT INTO LEDGERS (DATE,DESCRIPTIONS,COA_ID,REF_ID,ENTRY_OF,DEBIT,CREDIT,CREATED_BY,CREATION_DATE,COMPANY_ID) 
            //                    VALUES ('" + Classes.Helper.ConvertDatetime(dtpDate.Value.Date) + "','RECEIPT PAYMENT IN " + item.Cells["BANK"].Value.ToString() + " CHQ #: " + item.Cells["CHQ_NO"].Value.ToString() + @"'," + "(select REC_AC from CHQ where CHQ_ID = '" + item.Cells["CHQ_ID"].Value.ToString() + "')" + @",
            //                    " + id + ",'RECEIPT VOUCHER','0','" + txtAmount.Text + @"',1,GETDATE(),1); ";

            cls_db.query += @"
                COMMIT TRANSACTION 
                    END TRY 
                BEGIN CATCH 
                        IF @@TRANCOUNT > 0 
                        ROLLBACK TRANSACTION 
                END CATCH";

            if (cls_db.InsertUpdateDelete(cls_db.query)> 0)
            {
                MessageBox.Show("Record saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cls_db.nds.Tables["BV"].Clear();
               
                cls_db.dataR = cls_db.nds.Tables["BV"].NewRow();
                cls_db.dataR["date"] = Convert.ToDateTime(dtpDate.Value.Date);
                cls_db.dataR["voucherNo"] = lblVoucherNo.Text;
                cls_db.dataR["accountName"] = cmbRecAc.Text;
                cls_db.dataR["description"] = string.IsNullOrEmpty(txtNarration.Text) ? "-" : txtNarration.Text;
                cls_db.dataR["debit"] = 0;
                cls_db.dataR["credit"] = Convert.ToDouble(txtAmount.Text);
                cls_db.dataR["chqNo"] = cmbChqNo.Text;
                cls_db.dataR["instrument"] = cmbInstrumentNo.Text;
                cls_db.nds.Tables["BV"].Rows.Add(cls_db.dataR);

                cls_db.dataR = cls_db.nds.Tables["BV"].NewRow();
                cls_db.dataR["date"] = Convert.ToDateTime(dtpDate.Value.Date);
                cls_db.dataR["voucherNo"] = lblVoucherNo.Text;
                cls_db.dataR["accountName"] = cmbPaymentAc.Text;
                cls_db.dataR["description"] = string.IsNullOrEmpty(txtNarration.Text) ? "-" : txtNarration.Text;
                cls_db.dataR["debit"] = Convert.ToDouble(txtAmount.Text);
                cls_db.dataR["credit"] = 0;
                cls_db.dataR["chqNo"] = cmbChqNo.Text;
                cls_db.dataR["instrument"] = cmbInstrumentNo.Text;
                cls_db.nds.Tables["BV"].Rows.Add(cls_db.dataR);


                cls_db.rpt = new Reporting.frmReports();
                cls_db.rpt.GenerateReport("BV", cls_db.nds);
                cls_db.rpt.ShowDialog();

                Clear();

                //load_rec_grid(grdRecSummary, dtpDate.Value);
                //load_pay_grid(grdPaySummary, dtpDate.Value);
            }
            //else
            //{
            //    MessageBox.Show("Error savinl g record", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveValidation();
        }

        private void Clear()
        {
            grdEntries.DataSource = null;
            cmbChqNo.Text = "--SELECT CHQ NO--";
            cmbInstrumentNo.SelectedIndex = 0;
            cmbPaymentAc.SelectedIndex = 0;
            cmbRefAc.SelectedIndex = 0;
            cmbRecAc.SelectedIndex = 0;

            txtAmount.Text = "0";
            txtAmountWordsRec.Text = "0";
            txtNarration.Clear();

            bb_id = "";

            grdRecSummary.DataSource = null;
            grdPaySummary.DataSource = null;

            txtTotal.Clear();
            txtTotalPayGrid.Clear();
            txtTotalRecGrid.Clear();
            txtEntries.Clear();

            //getBVNum();
            //LoadGrid();
            //TotalRowSum();
            LoadForm();
        }
        private void Delete() {
            cls_db.query = @"BEGIN TRY 
                BEGIN TRANSACTION ";

            cls_db.query += @"DELETE FROM BANK_BOOK WHERE BB_ID = '" + bb_id + @"'
                DELETE FROM LEDGERS WHERE REF_ID = '" + bb_id + @"' AND ENTRY_OF = 'BANK BOOK'";

            cls_db.query += @"
                COMMIT TRANSACTION 
                    END TRY 
                BEGIN CATCH 
                        IF @@TRANCOUNT > 0 
                        ROLLBACK TRANSACTION 
                END CATCH";

            if (cls_db.InsertUpdateDelete(cls_db.query) > 0)
            {
                MessageBox.Show("Record Deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
                //load_rec_grid(grdRecSummary, dtpDate.Value);
                //load_pay_grid(grdPaySummary, dtpDate.Value);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void grdEntries_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>=0)
            {
                int i = e.RowIndex;
                bb_id = grdEntries.Rows[i].Cells["BB_ID"].Value.ToString();
                lblVoucherNo.Text = "BV-" + bb_id + "-2020";
                string val = (grdEntries.Rows[i].Cells["CHQ_NO"].Value ?? 0).ToString();
                if (val.Equals(""))
                    cmbChqNo.SelectedValue = 0;
                else
                    cmbChqNo.Text = grdEntries.Rows[i].Cells["CHQ_NO"].Value.ToString();
                cmbRecAc.SelectedValue = grdEntries.Rows[i].Cells["REC_AC"].Value;
                cmbPaymentAc.SelectedValue = grdEntries.Rows[i].Cells["PAY_AC"].Value;
                cmbRefAc.SelectedValue = grdEntries.Rows[i].Cells["REF ACC"].Value; 
                txtAmount.Text = grdEntries.Rows[i].Cells["AMOUNT"].Value.ToString();
                cmbInstrumentNo.SelectedValue = grdEntries.Rows[i].Cells["INSTRUMENT"].Value;
                txtNarration.Text = grdEntries.Rows[i].Cells["NARRATION"].Value.ToString();
            }
        }

        private void grdEntries_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            
            grdEntries.Columns["REC_AC"].Visible = false;
            grdEntries.Columns["PAY_AC"].Visible = false;
            grdEntries.Columns["BB_ID"].Visible = false;

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

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            LoadGrid();

            txtTotal.Text = "0";
            txtEntries.Text = "0";

            grdRecSummary.DataSource = null;
            grdPaySummary.DataSource = null;

            load_rec_grid(grdRecSummary,dtpDate.Value);
            load_pay_grid(grdPaySummary, dtpDate.Value);
            TotalRowSum();
        }

        private void getBVNum()
        {
            cls_db.query = @"SELECT COUNT(BB_ID)+1 FROM BANK_BOOK";
            int x = cls_db.generate_voucher_code(cls_db.query);
            lblVoucherNo.Text = "BV-" + x + "-2020";
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int.Parse(txtAmount.Text);
                txtAmountWordsRec.Text = ERP_Maaz_Oil.Vouchers.DayBook.ConvertWholeNumber(txtAmount.Text);
            }
            catch
            {
                
            }
        }

        private void cmbChqNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cls_db.query = @"SELECT AMOUNT FROM CHQ WHERE CHQ_ID = '"+cmbChqNo.SelectedValue.ToString()+@"'";
            txtAmount.Text = cls_db.getNo(cls_db.query).ToString();

            try
            {
                cls_db.query = @"SELECT D.COA_ID FROM DAY_BOOK A
                INNER JOIN DAY_BOOK_CHQ B ON A.DAY_BOOK_ID = B.DAY_BOOK_ID
                INNER JOIN CHQ C ON B.CHQ_ID = C.CHQ_ID
                INNER JOIN COA D ON A.CREDIT_AC = D.COA_ID
                WHERE C.CHQ_ID = '" + cmbChqNo.SelectedValue.ToString() + "'";
                cls_db.cmd = new SqlCommand(cls_db.query, Classes.Helper.conn);
                if (Classes.Helper.conn.State == ConnectionState.Closed)
                    Classes.Helper.conn.Open();
                cls_db.dr = cls_db.cmd.ExecuteReader();
                if (cls_db.dr.HasRows)
                {
                    cls_db.dr.Read();
                    cmbRecAc.SelectedValue = cls_db.dr["COA_ID"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Classes.Helper.conn.Close();
            }
        }


        public void load_rec_grid(DataGridView dg, DateTime date)
        {
            cls_db.query = @"SELECT B.COA_NAME as [RECEIVE ACCOUNT],SUM(A.AMOUNT) as TOTAL
            FROM BANK_BOOK A
            INNER JOIN COA B ON A.REC_AC = B.COA_ID
            WHERE A.DATE BETWEEN '" + date.ToShortDateString() + @" 00:00:00 AM' AND '" + date.ToShortDateString() + @" 23:59:59 PM'
            GROUP BY B.COA_NAME";

            try
            {
                Classes.Helper.conn.Open();
                cls_db.cmd = new SqlCommand(cls_db.query, Classes.Helper.conn);
                cls_db.dr = cls_db.cmd.ExecuteReader();
                if (cls_db.dr.HasRows == true)
                {
                    DataTable dt = new DataTable();
                    dt.Load(cls_db.dr);
                    dg.DataSource = dt;
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

        public void load_pay_grid(DataGridView dg, DateTime date)
        {
            cls_db.query = @"SELECT B.Coa_NAME AS [PAYMENT ACCOUNT],SUM(A.AMOUNT) AS TOTAL
            FROM BANK_BOOK A
            INNER JOIN COA B ON A.PAY_AC = B.COA_ID          
            WHERE A.DATE BETWEEN '" + date.ToShortDateString() + @" 00:00:00 AM' AND '" + date.ToShortDateString() + @" 23:59:59 PM'
            GROUP BY B.COA_NAME";

            try
            {
                Classes.Helper.conn.Open();
                cls_db.cmd = new SqlCommand(cls_db.query, Classes.Helper.conn);
                cls_db.dr = cls_db.cmd.ExecuteReader();
                if (cls_db.dr.HasRows == true)
                {
                    DataTable dt = new DataTable();
                    dt.Load(cls_db.dr);
                    dg.DataSource = dt;
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

        private void cmbTextUpdate(object sender, EventArgs e)
        {
            cls_db.CmbTextUpdate(sender as ComboBox);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            (grdEntries.DataSource as DataTable).DefaultView.RowFilter = string.Format(@"
            [" + grdEntries.Columns["RECEIVE ACC"].Name.ToString() + "] LIKE '%" + cls_fhp.AvoidInjection(txtSearch.Text) + "%' OR ["
              + grdEntries.Columns["PAYMENT ACC"].Name.ToString() + "] LIKE '%" + cls_fhp.AvoidInjection(txtSearch.Text) + "%' OR ["
              + grdEntries.Columns["REF ACC"].Name.ToString() + "] LIKE '%" + cls_fhp.AvoidInjection(txtSearch.Text) + "%' OR ["
              + grdEntries.Columns["INSTRUMENT"].Name.ToString() + "] LIKE '%" + cls_fhp.AvoidInjection(txtSearch.Text) + "%'");
            grdEntries.ClearSelection();
        }

        private void btnReceiptVoucher_Click(object sender, EventArgs e)
        {
            if (grdEntries.Rows.Count > 0)
                GenerateVoucher();
            else
                cls_fhp.ShowMessageBox("No records to show", "Error");
        }

        private void GenerateVoucher()
        {
            cls_db.nds.Tables["BV"].Clear();
            foreach (DataGridViewRow rows in grdEntries.Rows)
            {
                cls_db.dataR = cls_db.nds.Tables["BV"].NewRow();
                cls_db.dataR["date"] = Convert.ToDateTime(dtpDate.Value.Date);
                cls_db.dataR["voucherNo"] = lblVoucherNo.Text;
                cls_db.dataR["accountName"] = rows.Cells["RECEIVE ACC"].Value.ToString();
                cls_db.dataR["description"] = string.IsNullOrEmpty(rows.Cells["NARRATION"].Value.ToString())?"-": rows.Cells["NARRATION"].Value.ToString();
                cls_db.dataR["debit"] = 0;
                cls_db.dataR["credit"] = Convert.ToDouble(rows.Cells["AMOUNT"].Value.ToString());
                cls_db.dataR["chqNo"] = rows.Cells["CHQ_NO"].Value.ToString();
                cls_db.dataR["instrument"] = rows.Cells["INSTRUMENT"].Value.ToString();
                cls_db.nds.Tables["BV"].Rows.Add(cls_db.dataR);

                cls_db.dataR = cls_db.nds.Tables["BV"].NewRow();
                cls_db.dataR["date"] = Convert.ToDateTime(dtpDate.Value.Date);
                cls_db.dataR["voucherNo"] = lblVoucherNo.Text;
                cls_db.dataR["accountName"] = rows.Cells["PAYMENT ACC"].Value.ToString();
                cls_db.dataR["description"] = string.IsNullOrEmpty(rows.Cells["NARRATION"].Value.ToString()) ? "-" : rows.Cells["NARRATION"].Value.ToString();
                cls_db.dataR["debit"] = Convert.ToDouble(rows.Cells["AMOUNT"].Value.ToString());
                cls_db.dataR["credit"] = 0;
                cls_db.dataR["chqNo"] = rows.Cells["CHQ_NO"].Value.ToString();
                cls_db.dataR["instrument"] = rows.Cells["INSTRUMENT"].Value.ToString();
                cls_db.nds.Tables["BV"].Rows.Add(cls_db.dataR);


            }
            cls_db.rpt = new Reporting.frmReports();
            cls_db.rpt.GenerateReport("BV", cls_db.nds);
            cls_db.rpt.ShowDialog();
        }

        private void cmbRecAc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }


}
