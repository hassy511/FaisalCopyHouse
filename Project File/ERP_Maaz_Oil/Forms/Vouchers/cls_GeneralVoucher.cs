
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ERP_Maaz_Oil.Vouchers
{
    public class cls_GeneralVoucher
    {
        Classes.Helper db = new Classes.Helper();

        //General Entry
        public cls_GeneralVoucher()
        {

        }

        public int getLastDayBookId()
        {
            return db.getNo("SELECT MAX(DAY_BOOK_ID) FROM DAY_BOOK") ;  
        }
        public void loadEntryGrid(DataGridView grd)
        {
            db.LoadGrid(grd, Classes.Queries.loadEntries());
        }
        public void loadDebit(ComboBox cmb)
        {
            db.LoadComboData(cmb, Classes.Queries.loadDebit());
        }
        public int getNum()
        {
            return db.getNo(Classes.Queries.getRefNum());
        }
        public void loadCredit(ComboBox cmb)
        {
            db.LoadComboData(cmb, Classes.Queries.loadCredit());
        }
        public int saveGeneral(string[] data)
        {
            if (db.InsertUpdateDelete(Classes.Queries.saveGeneral(data)) > 0)
            {
                return 1;
            }
            return 0;
        }

        public void insert_Rec_Person(string name)
        {
            string query = "INSERT INTO RECOVERY_PERSON VALUES('" + name + "')";
            db.InsertUpdateDelete(query);
        }
        //RECEIPTS
        public void loadReceiptGrid(DataGridView grd)
        {
            db.LoadGrid(grd, Classes.Queries.loadReceipts());
            grd.Columns["REC_PERSON_ID"].Visible = false;
        }

        public void getChq(string Id, DataGridView grd)
        {
            db.getReceiptChq(Id, grd);
        }

        public void getChqByNum(string Id,string chqNo, DataGridView grd)
        {
            db.getReceiptChq(Id,chqNo, grd);
        }

        public void loadReceipt(ComboBox cmb)
        {
            db.LoadComboData(cmb, Classes.Queries.loadBank());
        }
        public void loadRecieptCustomer(ComboBox cmb)
        {
            db.LoadComboData(cmb, Classes.Queries.loadCustomer());
        }



        public void loadRecoveryPerson(ComboBox cmb)
        {
            db.LoadComboData(cmb, Classes.Queries.loadRecPerson());
        }

        public int saveReceipts(string[] data, DataGridView grd, string debit)
        {
            if (db.InsertUpdateDelete(Classes.Queries.SaveReceipt(data)) > 0)
            {
                if (debit.Equals("CHQ"))
                {
                    db.InsertUpdateDelete(Classes.Queries.saveReceiptChq(grd, data[2]));
                }
                return 1;
            }
            return 0;
        }

        //PAYMENTS
        public void loadPayments(DataGridView grd)
        {
            db.LoadGrid(grd, Classes.Queries.loadPayment());
        }
        public void loadAllAccounts(ComboBox cmb)
        {
            db.LoadComboData(cmb, Classes.Queries.LoadAllAccounts());
        }
        public void loadChqsReceived(ComboBox cmbChqNoPay)
        {
            db.LoadComboData(cmbChqNoPay, Classes.Queries.LoadChqsReceived());
        }
        public void loadAllChqs(ComboBox cmbChqNoPay)
        {
            db.LoadComboData(cmbChqNoPay, Classes.Queries.LoadAllChqs());
        }
        public void loadPayGrid(DataGridView grd)
        {
          
            db.query = Classes.Queries.loadPayGrid();
            db.LoadGrid(grd, db.query);
            foreach (DataGridViewRow row in grd.Rows)
            {
                row.Cells["selectChq"].Value = false;
            }
            grd.Columns["selectChq"].Width = 60;
        }
        public void loadPayGrid(DataGridView grd, int dayBookId)
        {

            db.query = Classes.Queries.loadPayGrid(dayBookId);
            db.LoadPaymentChqGrid(grd, db.query);
            
        }
        public void getPayChq(string chqNo, DataGridView grd)
        {
            db.getPaymentChq(chqNo, grd);
        }
        public int savePayment(string[] data, List<string> grd)
        {
            if (db.InsertUpdateDelete(Classes.Queries.savePayment(data, grd)) > 0)
            {
                return 1;
            }
            return 0;
        }

        //CHEQUE DEPOSIT
        public void loadRecoveryDetails(DataGridView dg,string person,string from,string to)
        {
            string query = @"SELECT DISTINCT R.CREATION_DATE as [DATE],
                        C.COA_NAME as [CUSTOMER],R.CASH, CH.AMOUNT as [CHQ_AMOUNT],CH.BANK_NAME as [BANK],
                        CH.CHQ_DATE,CH.CHQ_NO
                        FROM RECOVERY_DETAILS R
                        INNER JOIN COA C ON R.CUST_ID = C.COA_ID 
                        INNER JOIN CHQ CH ON R.CHQ_NO = CH.CHQ_NO 
                        WHERE R.REC_PERSON_ID = '"+person+"' AND C.CA_ID ='21'" +
                        " AND R.CREATION_DATE BETWEEN '"+from+" 00:00:00' AND '"+to+" 23:59:59'";
            db.LoadGrid(dg, query);
        }

        public void loadBank(ComboBox cmb)
        {
            db.LoadComboData(cmb, Classes.Queries.loadBank());
        }
        public void loadChqDeposit(DataGridView grd)
        {
            db.query = Classes.Queries.loadChqDeposit();
            db.LoadGrid(grd, db.query);
        }
        public void loadChqDepositPaid(DataGridView grd)
        {
            db.query = Classes.Queries.loadChqDepositPaid();
            db.LoadGrid(grd, db.query);
        }
        public void loadChqDeposit(DataGridView grd, int customerId,char status)
        {
            db.query = Classes.Queries.loadChqDeposit(customerId,status);
            db.LoadGrid(grd, db.query);
        }

        private static String ones(String Number)
        {
            int _Number = Convert.ToInt32(Number);
            String name = "";
            switch (_Number)
            {

                case 1:
                    name = "One";
                    break;
                case 2:
                    name = "Two";
                    break;
                case 3:
                    name = "Three";
                    break;
                case 4:
                    name = "Four";
                    break;
                case 5:
                    name = "Five";
                    break;
                case 6:
                    name = "Six";
                    break;
                case 7:
                    name = "Seven";
                    break;
                case 8:
                    name = "Eight";
                    break;
                case 9:
                    name = "Nine";
                    break;
            }
            return name;
        }

        private static String tens(String Number)
        {
            int _Number = Convert.ToInt32(Number);
            String name = null;
            switch (_Number)
            {
                case 10:
                    name = "Ten";
                    break;
                case 11:
                    name = "Eleven";
                    break;
                case 12:
                    name = "Twelve";
                    break;
                case 13:
                    name = "Thirteen";
                    break;
                case 14:
                    name = "Fourteen";
                    break;
                case 15:
                    name = "Fifteen";
                    break;
                case 16:
                    name = "Sixteen";
                    break;
                case 17:
                    name = "Seventeen";
                    break;
                case 18:
                    name = "Eighteen";
                    break;
                case 19:
                    name = "Nineteen";
                    break;
                case 20:
                    name = "Twenty";
                    break;
                case 30:
                    name = "Thirty";
                    break;
                case 40:
                    name = "Fourty";
                    break;
                case 50:
                    name = "Fifty";
                    break;
                case 60:
                    name = "Sixty";
                    break;
                case 70:
                    name = "Seventy";
                    break;
                case 80:
                    name = "Eighty";
                    break;
                case 90:
                    name = "Ninety";
                    break;
                default:
                    if (_Number > 0)
                    {
                        name = tens(Number.Substring(0, 1) + "0") + " " + ones(Number.Substring(1));
                    }
                    break;
            }
            return name;
        }

        public static String ConvertWholeNumber(String Number)
        {
            string word = "";
            if (Number.Contains("."))
                Number = Number.Substring(0, Number.IndexOf('.'));
            try
            {
                bool beginsZero = false;//tests for 0XX   
                bool isDone = false;//test if already translated   
                double dblAmt = (Convert.ToDouble(Number));
                //if ((dblAmt > 0) && number.StartsWith("0"))   
                if (dblAmt > 0)
                {//test for zero or digit zero in a nuemric   
                    beginsZero = Number.StartsWith("0");

                    int numDigits = Number.Length;
                    int pos = 0;//store digit grouping   
                    String place = "";//digit grouping name:hundres,thousand,etc...   
                    switch (numDigits)
                    {
                        case 1://ones' range   

                            word = ones(Number);
                            isDone = true;
                            break;
                        case 2://tens' range   
                            word = tens(Number);
                            isDone = true;
                            break;
                        case 3://hundreds' range   
                            pos = (numDigits % 3) + 1;
                            place = " Hundred ";
                            break;
                        case 4://thousands' range   
                        case 5:
                        case 6:
                            pos = (numDigits % 4) + 1;
                            place = " Thousand ";
                            break;
                        case 7://millions' range   
                        case 8:
                        case 9:
                            pos = (numDigits % 7) + 1;
                            place = " Million ";
                            break;
                        case 10://Billions's range   
                        case 11:
                        case 12:

                            pos = (numDigits % 10) + 1;
                            place = " Billion ";
                            break;
                        //add extra case options for anything above Billion...   
                        default:
                            isDone = true;
                            break;
                    }
                    if (!isDone)
                    {//if transalation is not done, continue...(Recursion comes in now!!)   
                        if (Number.Substring(0, pos) != "0" && Number.Substring(pos) != "0")
                        {
                            try
                            {
                                word = ConvertWholeNumber(Number.Substring(0, pos)) + place + ConvertWholeNumber(Number.Substring(pos));
                            }
                            catch { }
                        }
                        else
                        {
                            word = ConvertWholeNumber(Number.Substring(0, pos)) + ConvertWholeNumber(Number.Substring(pos));
                        }


                    }
                    //ignore digit grouping names   
                    if (word.Trim().Equals(place.Trim())) word = "";
                }
            }
            catch { }
            return word.Trim();
        }
    }
}
