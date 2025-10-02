using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ERP_Maaz_Oil.Classes
{
    class Queries
    {
        //Add user form
        public static string LoadUsers()
        {
            return @"SELECT U.USER_ID,U.USER_NAME as[NAME],U.PASSWORD FROM USERS U";
        }
        public static string SaveUsers(string[] data)
        {
            string query = @" BEGIN TRAN IF EXISTS(SELECT USER_ID FROM USERS WHERE USER_ID='" + data[0] + @"')
            BEGIN
            UPDATE USERS SET USER_NAME ='" + data[1] + "',PASSWORD='" + data[2] + "' WHERE USER_ID='" + data[0] + @"'; 
            END
            ELSE
            INSERT INTO USERS VALUES('" + data[1] + "','" + data[2] + "'); COMMIT TRAN ";
            return query;
        }

        //Raw Purchases
        public static string getRawNo()
        {
            return @"SELECT COUNT(RPM_ID)+1 FROM RAW_PURCHASES_MASTER";
        }
        public static string LoadSupplier()
        {
            return @"SELECT '0' AS[id],'--SELECT SUPPLIER--' AS[name] UNION ALL SELECT COA_ID as [id],COA_NAME as [name] FROM COA WHERE CA_ID='20'";
        }
        public static string LoadAllAccounts()
        {
            return @"SELECT '0' AS[id],'--SELECT ACCOUNT--' AS[name] UNION ALL SELECT COA_ID as [id],COA_NAME as [name] FROM COA";
        }
        public static string LoadChqsReceived()
        {
            return @"SELECT '--SELECT CHQ--' as [name], '0' as [id]
                    UNION ALL
                    SELECT ISNULL(CHQ_NO,'-') as [name],ISNULL(CHQ_ID,'-') as [id]
			        FROM CHQ 
                    WHERE STATUS=1 AND CHQ_ID NOT IN (SELECT CHQ_ID FROM PAYMENT_TRANSFER where CHQ_ID is not null)";
        }
        public static string LoadPTChqs()
        {
            return @"SELECT '--SELECT CHQ--' as [name], '0' as [id]
                    UNION ALL
                    SELECT ISNULL(CHQ_NO,'-') as [name],ISNULL(CHQ_ID,'-') as [id]
			        FROM CHQ 
                    WHERE STATUS=1 AND CHQ_ID NOT IN (SELECT CHQ_ID FROM PAYMENT_TRANSFER where CHQ_ID is not null)";
        }
        public static string LoadAllChqs()
        {
            return @"SELECT '--SELECT CHQ--' as [name], '0' as [id]
                    UNION ALL
                    SELECT ISNULL(CHQ_NO,'-') as [name],ISNULL(CHQ_ID,'-') as [id]
			        FROM CHQ";
        }
        public static string LoadMaterial()
        {
            return @"SELECT '0' AS[id],'--SELECT MATERIAL--' AS[name] UNION ALL  SELECT MATERIAL_ID as [id],MATERIAL_NAME as [name] FROM MATERIAL";
        }
        public static string material()
        {
            return @"SELECT MATERIAL_ID,MATERIAL_NAME FROM MATERIAL WHERE MATERIAL_ID=1";
        }

       

        public static string LoadQuality()
        {
            return @"SELECT '0' AS[id],'-SELECT QUALITY--' AS[name] UNION ALL select MQ_ID as [id],QUALITY_NAME as [name] from MATERIAL_QUALITY";
        }
        //public static string LoadQuality()
        //{
        //    return @"SELECT '0' AS[ID],'-SELECT QUALITY--' AS[NAME] UNION ALL select MQ_ID,QUALITY_NAME from MATERIAL_QUALITY";
        //}
        public static string LoadDying()
        {
            return @"SELECT '0' AS[ID],'--SELECT DYING ACC--' AS[NAME] UNION ALL SELECT COA_ID as [id],ACCOUNT_NAME as [name] FROM CHART_OF_ACCOUNT WHERE AC_NATURE_ID='7'";
        }
        public static string LoadDyingGrid()
        {
            return @"SELECT R.PURCHASES_ID,D.COA_ID AS [SUPPLIER ID],R.DYING_ID,R.DYING_DATE as[DATE],D.LOT_NO as[LOT NO],R.DYING_AC,C.ACCOUNT_NAME as[DYING ACCOUNT],
            R.FINISHED_METER AS [FINISHED METER],R.DYING_PRICE,R.FINISHED_METER * R.DYING_PRICE AS [TOTAL],R.[DESCRIPTION],E.MQ_ID
            FROM DYING R
            INNER JOIN RAW_PURCHASES_MASTER D ON R.PURCHASES_ID = D.RPM_ID
            INNER JOIN CHART_OF_ACCOUNT C ON C.COA_ID = R.DYING_AC
            INNER JOIN RAW_PURCHASES_DETAILS E ON D.RPM_ID = E.RPM_ID";
        }
        public static string LoadRawGrid()
        {
            return @"SELECT R.RPM_ID,R.DATE as[DATE],R.INVOICE_NO as[INVOICE #],R.COA_ID,C.ACCOUNT_NAME as[SUPPLIER],
            SUM(B.METER) AS [TOTAL METER],SUM(B.METER * B.PRICE) AS [TOTAL],ISNULL(LOT_NO,'-') as[LOT NO],r.[status]
            FROM RAW_PURCHASES_MASTER R
            INNER JOIN RAW_PURCHASES_DETAILS B ON R.RPM_ID = B.RPM_ID
            INNER JOIN CHART_OF_ACCOUNT C ON C.COA_ID=R.COA_ID
            GROUP BY R.RPM_ID,R.DATE,R.INVOICE_NO,R.COA_ID,C.ACCOUNT_NAME,r.LOT_NO,r.[status]";
        }
        public static string saveRawPurchases(DataGridView dgv,string[] data)
        {
            string query = @"IF EXISTS (SELECT RPM_ID FROM RAW_PURCHASES_MASTER WHERE RPM_ID='" + data[3] + @"')
            BEGIN
            UPDATE RAW_PURCHASES_MASTER SET COA_ID='" + data[2] + "',DATE='" + data[1] + "',MODIFICATION_DATE=GETDATE(),MODIFIED_BY='1' WHERE RPM_ID='" + data[3] + @"';
            DELETE FROM RAW_PURCHASES_DETAILS WHERE RPM_ID='" + data[3] + @"';
            END 
            ELSE
            INSERT INTO RAW_PURCHASES_MASTER VALUES('" + data[2] + "','" + data[1] + "','" + data[0] + "',GETDATE(),''1'',NULL,NULL);";
            foreach (DataGridViewRow item in dgv.Rows)
            {
                query+= @"INSERT INTO RAW_PURCHASES_DETAILS VALUES('" + data[2] + "',(SELECT MAX(RPM_ID) FROM RAW_PURCHASES_MASTER),'"+item.Cells[4].Value.ToString()+ "','" + item.Cells[0].Value.ToString() + @"',
                '" + item.Cells[2].Value.ToString() + "','" + item.Cells[3].Value.ToString() + "','" + item.Cells[6].Value.ToString() + "','" + item.Cells[7].Value.ToString() + @"',
                '" + item.Cells[9].Value.ToString() + "','" + item.Cells[10].Value.ToString() + "','" + item.Cells[11].Value.ToString() + "',GETDATE(),'1',NULL,NULL)";
            }
            query += @"INSERT INTO LEDGERS VALUES ('" + data[1] + "','Add new Raw Purchases','" + data[2] + "',(SELECT MAX(PM_ID) FROM PURCHASES_MASTER),'RP','" + data[5] + @"','0'); 
            INSERT INTO LEDGERS VALUES ('" + data[1] + "', 'Add new Raw Purchases', '9', (SELECT MAX(PM_ID) FROM PURCHASES_MASTER),'RP','0','" + data[5] + "'); ";

            return query;
        }

        public static string getRawDetails()
        {
            string query = @"";
            return query;
        }
        //dying form

          
        //pURCHASES FORM

        public static string loadPurchaseGrid()
        {
            return @"SELECT P.PM_ID,P.DATE,P.INVOICE_NO as[INVOICE #],
            P.COA_ID,C.ACCOUNT_NAME AS[SUPPLIER],DESCRIPTION,
            SUM(B.METER) AS [TOTAL METER],SUM(B.METER * B.PRICE) AS [TOTAL],p.LOT_NO as[LOT NO]
            FROM PURCHASES_MASTER P
            INNER JOIN PURCHASES_DETAILS B ON P.PM_ID = B.RPM_ID
            INNER JOIN CHART_OF_ACCOUNT C ON C.COA_ID=P.COA_ID
            GROUP BY P.PM_ID,P.DATE,P.INVOICE_NO,P.COA_ID,C.ACCOUNT_NAME,DESCRIPTION,p.LOT_NO";
        }

        public static string getPurchaseNo()
        {
            return @"SELECT ISNULL(MAX(PM_ID),0)+1 FROM PURCHASES_MASTER";
        }

        public static string savePurchases(DataGridView dgv,string[] data)
        {
            string query = @"IF EXISTS (SELECT PM_ID FROM PURCHASES_MASTER WHERE PM_ID='"+data[0]+@"')
            BEGIN
            UPDATE PURCHASES_MASTER SET COA_ID='"+data[1]+ "',DATE='" + data[2] + "',	DESCRIPTION='" + data[4] + "',MODIFICATION_DATE=GETDATE(),MODIFIED_BY='1' WHERE PM_ID='" + data[0] + @"';
            DELETE FROM PURCHASES_DETAILS WHERE RPM_ID='" + data[0] + @"';
            END
            ELSE
            INSERT INTO PURCHASES_MASTER VALUES('" + data[1] + "','" + data[2] + "','" + data[3] + "','" + data[4] + "',GETDATE(),'1',NULL,NULL);";
            foreach (DataGridViewRow item in dgv.Rows)
            {
                query += @"INSERT INTO PURCHASES_DETAILS VALUES((SELECT MAX(PM_ID) FROM PURCHASES_MASTER),'"+item.Cells[4].Value.ToString()+ "','" + item.Cells[0].Value.ToString() + "','" + item.Cells[2].Value.ToString() + "','" + item.Cells[3].Value.ToString() + "',GETDATE(),'1',NULL,NULL);";
            }
            query += @"INSERT INTO LEDGERS VALUES ('"+data[2]+"','Add new Purchases','"+data[1]+ "',(SELECT MAX(PM_ID) FROM PURCHASES_MASTER),'PURCHASES','"+data[5]+@"','0'); 
            INSERT INTO LEDGERS VALUES ('"+data[2]+"', 'Add new Purchases', '9', (SELECT MAX(PM_ID) FROM PURCHASES_MASTER),'PURCHASES','0','" + data[5] + "'); ";


            return query;
        }

        //sales form

        public static string salesCount()
        {
            return @"SELECT COUNT(SM_ID)+1 FROM SALES_MASTER";
        }
        public static string loadSales()
        {
            return @"SELECT S.SM_ID,S.DATE,S.INVOICE_NO AS[INVOICE #],S.COA_ID,C.ACCOUNT_NAME AS[CUSTOMER],S.DESCRIPTION,
            SUM(B.METER) AS [TOTAL METER],SUM(B.METER * B.PRICE) AS [TOTAL],S.CHALLAN_NO as[CHALLAN NO]
            FROM SALES_MASTER S
            INNER JOIN SALES_DETAILS B ON S.SM_ID = B.SM_ID
            INNER JOIN CHART_OF_ACCOUNT C ON C.COA_ID=S.COA_ID
            GROUP BY S.SM_ID,S.DATE,S.INVOICE_NO,S.COA_ID,C.ACCOUNT_NAME,S.DESCRIPTION,S.CHALLAN_NO";
        }

        public static string loadRecoveryDetails(string person)
        {
            return @"SELECT R.CREATION_DATE as [DATE],
                        C.COA_NAME as [CUSTOMER],R.CASH, CH.AMOUNT as [CHQ_AMOUNT],CH.BANK_NAME as [BANK],
                        CH.CHQ_DATE
                        FROM RECOVERY_DETAILS R
                        INNER JOIN COA C ON R.CUST_ID = C.COA_ID
                        INNER JOIN CHQ CH ON R.CHQ_ID = CH.CHQ_ID
                        WHERE R.REC_PERSON_ID = '" + person + "' AND C.CA_ID = '21'";
        }

        public static string loadCustomer()
        {
            return @"SELECT '0' AS[ID],'--SELECT CUSTOMER--' AS[NAME] UNION ALL SELECT COA_ID AS [id],COA_NAME AS [name] FROM COA WHERE CA_ID IN ('21','20')";
        }

        public static string loadRecPerson()
        {
            return @"SELECT '0' AS [ID],'--SELECT REC PERSON--' AS [NAME]
                     UNION ALL
                     SELECT REC_PERSON_ID AS [ID],REC_PERSON_NAME as [NAME] FROM RECOVERY_PERSON";
        }

        public static string loadItems()
        {
            return @"SELECT I.IT_ID,I.MATERIAL_ID,'GREY' AS[ITEM NAME],I.MQ_ID,MQ.QUALITY_NAME AS[QUALITY],I.COST,
            I.QTY-(SELECT ISNULL(SUM(QTY),0) FROM ITEM_LEDGER_DETAIL WHERE IT_ID = I.IT_ID) AS[QTY] 
            FROM ITEM_LEDGER I
            --INNER JOIN MATERIAL M ON M.MATERIAL_ID=I.MATERIAL_ID
            INNER JOIN MATERIAL_QUALITY MQ ON MQ.MQ_ID=I.MQ_ID
            WHERE (I.QTY-(SELECT ISNULL(SUM(QTY),0) FROM ITEM_LEDGER_DETAIL WHERE IT_ID = I.IT_ID)) > 0";
        }

        public static string saveSale(DataGridView dgv,string[] data)
        {
            string query = @"IF EXISTS (SELECT SM_ID FROM SALES_MASTER WHERE SM_ID='" + data[0] + @"')
            BEGIN
            UPDATE SALES_MASTER SET COA_ID='" + data[3] + "', DATE='" + data[2] + "',DESCRIPTION='" + data[4] + "',MODIFICATION_DATE=GETDATE(),MODIFIED_BY='1' WHERE SM_ID='" + data[0] + @"';
            DELETE FROM SALES_DETAILS WHERE SM_ID='" + data[0] + @"';
            END
            ELSE
            INSERT INTO SALES_MASTER VALUES('" + data[3] + "','" + data[2] + "','" + data[1] + "','" + data[4] + "',GETDATE(),''1'',NULL,NULL);";
            foreach (DataGridViewRow item in dgv.Rows)
            {
                query += @"INSERT INTO SALES_DETAILS VALUES((SELECT ISNULL(MAX(SM_ID),1) FROM SALES_MASTER),'"+item.Cells["QID"].Value.ToString()+ "','" + item.Cells["IID"].Value.ToString() + @"',
                '" + item.Cells["Meter"].Value.ToString() + "','" + item.Cells["Price"].Value.ToString() + "',GETDATE(),'1',NULL,NULL)";
                query += @" INSERT INTO ITEM_LEDGER_DETAIL VALUES('"+data[2]+ "', '" + data[4] + "', '" + item.Cells["IT_ID"].Value.ToString() + "', '" + item.Cells["ItemID"].Value.ToString()+ "', '" + item.Cells["QID"].Value.ToString() + "', '" + item.Cells["Price"].Value.ToString() + "', '" + item.Cells["Quant"].Value.ToString() + "', 'sale');";
            }
            query += @"INSERT INTO LEDGERS VALUES('" + data[2] + "','" + data[3] + "','" + data[4] + "',(SELECT ISNULL(MAX(SM_ID),1) FROM SALES_MASTER),'SALE','" + data[5] + @"',0);
            INSERT INTO LEDGERS VALUES('" + data[2] + "',(select coa_id from CHART_OF_ACCOUNT where ACCOUNT_NAME='SALES'), '" + data[4] + "', (SELECT ISNULL(MAX(SM_ID),1) FROM SALES_MASTER),'SALE',0,'" + data[5] + "');";

            return query;
        }

        //Add user
        public static string loadUsersGrid()
        {
            return @"SELECT C.COA_ID,C.AC_NATURE_ID,A.AC_NATURE_NAME AS[NATURE],C.ACCOUNT_NAME AS[ACCOUNT],C.OPEN_BAL AS[BALANCE],CASE WHEN DEBIT_CREDIT='D' THEN 'DEBIT' ELSE 'CREDIT' END AS[TYPE] FROM CHART_OF_ACCOUNT C
            INNER JOIN ACCOUNT_NATURE A ON A.AC_NATURE_ID=C.AC_NATURE_ID";
            //where C.AC_NATURE_ID not in (4,5,6,8)
        }

        public static string loadNature()
        {
            return @"SELECT '0' AS[ID],'--SELECT USER TYPE--' AS[NAME] 
            UNION ALL 
            SELECT AC_NATURE_ID ,AC_NATURE_NAME FROM ACCOUNT_NATURE
            WHERE AC_NATURE_ID NOT IN ('4','5','6','8')";
        }

        public static string saveAddUser(string[] data)
        {
            string query= @"BEGIN TRAN
            IF EXISTS (select coa_ID from CHART_OF_ACCOUNT where COA_ID='"+data[4]+@"')
            BEGIN 
            UPDATE CHART_OF_ACCOUNT set AC_NATURE_ID='"+data[1]+"',ACCOUNT_NAME='"+data[0]+"',OPEN_BAL='"+data[2]+"',DEBIT_CREDIT='"+data[3]+"',MODIFICATION_DATE=GETDATE(),MODIFIED_BY='1' where COA_ID='"+data[4]+@"';
            END
            ELSE
            BEGIN
            INSERT INTO CHART_OF_ACCOUNT VALUES('" + data[1] + "','" + data[0] + "','" + data[2] + "','" + data[3] + @"',1,GETDATE(),'1',NULL,NULL);
            END
            COMMIT TRAN";
            return query;
        }

        // DAY BOOK
        //GENERAL ENTRY

        public static string loadEntries()
        {
            return @" SELECT A.GV_ID,A.GV_CODE AS [VOUCHER #],FORMAT(A.DAATE,'MM-dd-yyyy') AS [DATE],
            C.COA_NAME as [ACCOUNT],B.DEBIT as [DEBIT],B.CREDIT as [CREDIT],B.NARRATION AS [NARRATION],A.CREATED_BY
            FROM GENERAL_VOUCHER_M A
            INNER JOIN GENERAL_VOUCHER_D B ON A.GV_ID = B.GV_ID
            INNER JOIN COA C ON B.COA_ID = C.COA_ID
            GROUP BY A.GV_ID,A.DAATE,A.GV_CODE,C.COA_NAME,B.DEBIT,B.CREDIT,B.NARRATION,A.CREATED_BY
            ORDER BY A.DAATE DESC";
        }
        public static string getRefId()
        {
            return @"Select ISNULL(max(ref_id),0)+1 From ledgers";
        }
        public static string getRefNum()
        {
            return @"select ISNULL(max(LEGDER_ID),0)+1 from LEDGERS";
        }
        public static string getNum()
        {
            return @"SELECT ISNULL(COUNT(LEGDER_ID),0)+1 FROM LEDGERS";
        }
        public static string loadDebit()
        {
            return @"SELECT '0' AS[ID],'--SELECT DEBIT ACCOUNT--' AS[NAME] UNION ALL SELECT COA_ID,COA_NAME FROM COA ORDER BY [NAME]";
        }
        public static string loadCredit()
        {
            return @"SELECT '0' AS[ID],'--SELECT CREDIT ACCOUNT--' AS[NAME] UNION ALL SELECT COA_ID,COA_NAME FROM COA ORDER BY [NAME]";
        }
        public static string saveGeneral(string [] data)
        {
            string query = @"INSERT INTO LEDGERS VALUES('"+data[0]+ "','" + data[4] + "','" + data[1] + "','','GENERAL ENTRY','" + data[3] + @"',0);
            INSERT INTO LEDGERS VALUES('" + data[0] + "','" + data[4] + "','" + data[2] + "','','GENERAL ENTRY',0,'" + data[3] + "');";
            return query;
        }

        //RECEIPTS

        public static string loadReceipts()
        {
            return @"SELECT D.DAY_BOOK_ID,DATE,ISNULL(D.DEBIT_AC,'-') as [DEBIT_AC],C.COA_NAME AS[DEBIT],D.CREDIT_AC,E.COA_NAME AS[CREDIT],
                    AMOUMT as[TOTAL_AMOUNT],DESCRIPTION,CASH_AMOUNT AS[CASH AMOUNT],G.AMOUNT AS[CHQ AMOUNT],REC_PERSON_ID,
                    ISNULL(G.CHQ_NO,'-') as [CHQ_NO],ISNULL(G.BANK_NAME,'-') as [BANK],G.CHQ_DATE as [CHQ_DATE]
			        FROM DAY_BOOK D
                    LEFT JOIN COA C ON C.COA_ID=D.DEBIT_AC
                    LEFT JOIN COA E ON E.COA_ID=D.CREDIT_AC
			        LEFT JOIN DAY_BOOK_CHQ F ON D.DAY_BOOK_ID =f.DAY_BOOK_ID
			        LEFT JOIN CHQ G ON F.CHQ_ID = G.CHQ_ID
                    WHERE ENTRY_OF='RECEIPT VOUCHER'";
        }
        public static string getReceiptChq(string id)
        {
            string query = @"
			SELECT C.CHQ_ID,C.CHQ_DATE AS[DATE],E.COA_NAME,C.AMOUNT,C.BANK_NAME as[BANK],C.CHQ_NO FROM DAY_BOOK_CHQ D
            INNER JOIN DAY_BOOK B ON D.DAY_BOOK_ID=B.DAY_BOOK_ID
            INNER JOIN CHQ C ON C.CHQ_ID=D.CHQ_ID
			INNER JOIN COA E ON B.CREDIT_AC = E.COA_ID
            WHERE D.DAY_BOOK_ID='" + id+"'";
            return query;
        }

        public static string getReceiptChqByNum(string chqNo,string id)
        {
            string query = @"
			SELECT C.CHQ_ID,C.CHQ_DATE AS[DATE],E.COA_ID,E.COA_NAME,C.AMOUNT,C.BANK_NAME as[BANK],C.CHQ_NO as [CHQ_NO] FROM DAY_BOOK_CHQ D
            INNER JOIN DAY_BOOK B ON D.DAY_BOOK_ID=B.DAY_BOOK_ID
            INNER JOIN CHQ C ON C.CHQ_ID=D.CHQ_ID
			INNER JOIN COA E ON B.CREDIT_AC = E.COA_ID
            WHERE C.STATUS=1 AND C.CHQ_NO = '" + chqNo + "'";
            return query;
        }
        public static string loadDebitReceipt()
        {
            return @"SELECT '0' AS[ID],'--SELECT ACCOUNT--' AS[NAME] UNION ALL SELECT COA_ID,COA_NAME FROM COA WHERE CA_ID IN (5)";
        }
       
        public static string SaveReceipt(string [] data)
        {
            string query=@"INSERT INTO DAY_BOOK VALUES('"+data[0]+ "','RECEIPT VOUCHER','" + data[1] + "','" + data[2] + "','" + data[3] + "','" + data[4] + @"',GETDATE(),'1',NULL,NULL);
            INSERT INTO LEDGERS VALUES('" + data[0] + "', '" + data[4] + "', '" + data[1] + "',(SELECT ISNULL(MAX(DAY_BOOK_ID),0) from DAY_BOOK), 'RECEIPT VOUCHER', '" + data[3] + @"', '0');
            INSERT INTO LEDGERS VALUES('" + data[0] + "', '" + data[4] + "', '" + data[2] + "',(SELECT ISNULL(MAX(DAY_BOOK_ID),0) from DAY_BOOK), 'RECEIPT VOUCHER', '0', '" + data[3] + "'); ";
            return query;
        }
        public static string saveReceiptChq(DataGridView grd,string rec)
        {
            string query = "";
            foreach (DataGridViewRow item in grd.Rows)
            {
                query = @" INSERT INTO CHQ VALUES('"+item.Cells["DATE1"].Value.ToString()+ "','" + item.Cells["CHQNO"].Value.ToString() + "','" + item.Cells["AmntReceipt"].Value.ToString() + "','" + rec + "',NULL,'" + item.Cells["Bank1"].Value.ToString() + @"',1);
                INSERT INTO DAY_BOOK_CHQ VALUES((SELECT MAX(CHQ_ID) FROM CHQ),(SELECT MAX(DAY_BOOK_ID) FROM DAY_BOOK)); ";
            }
            return query;
        }

        //PAYMENT

        public static string loadPayment()
        {
            //         return @"SELECT C.CHQ_ID,D.DAY_BOOK_ID,C.CHQ_DATE AS[DATE],E.COA_ID as [cust_id],F.COA_NAME as [PAYMENT ACCOUNT],B.CASH_AMOUNT,C.AMOUNT as [CHQ AMOUNT],B.AMOUMT as [TOTAL]
            //,B.PAID_TO,C.CHQ_NO,B.DESCRIPTION ,B.ENTRY_OF,C.PAY_AC,C.REC_AC
            // FROM DAY_BOOK_CHQ D
            //         INNER JOIN DAY_BOOK B ON D.DAY_BOOK_ID=B.DAY_BOOK_ID
            //         INNER JOIN CHQ C ON C.CHQ_ID=D.CHQ_ID
            //INNER JOIN COA E ON C.REC_AC = E.COA_ID
            //         INNER JOIN COA F ON C.PAY_AC = F.COA_ID
            //         WHERE C.STATUS=0 AND D.DAY_BOOK_ID in 
            //         (SELECT A.DAY_BOOK_ID FROM DAY_BOOK A
            //         INNER JOIN DAY_BOOK_CHQ B ON A.DAY_BOOK_ID = B.DAY_BOOK_ID
            //         INNER JOIN CHQ C ON B.CHQ_ID = C.CHQ_ID ) AND B.ENTRY_OF = 'PAYMENT VOUCHER'";
            return @"SELECT DATE,B.DAY_BOOK_ID,
                    (
	                    SELECT DISTINCT(E.COA_NAME) 
	                    FROM DAY_BOOK A 
	                    INNER JOIN COA E ON A.DEBIT_AC= E.COA_ID
	                    WHERE A.DAY_BOOK_ID = b.DAY_BOOK_ID
                    ) as [PAYMENT ACCOUNT],
                    B.CASH_AMOUNT,
                    (
	                    SELECT SUM(C.AMOUNT) FROM DAY_BOOK A 
	                    INNER JOIN CHQ C ON A.DEBIT_AC = C.PAY_AC
	                    INNER JOIN DAY_BOOK_CHQ D ON C.CHQ_ID = D.CHQ_ID
	                    WHERE A.DAY_BOOK_ID = B.DAY_BOOK_ID
                    ) as [CHQ_TOTAL],B.AMOUMT as [TOTAL]
                    ,B.PAID_TO,B.DESCRIPTION ,B.ENTRY_OF,B.DEBIT_AC AS [PAYMENT_ID]
                    FROM DAY_BOOK B 
                    WHERE B.ENTRY_OF = 'PAYMENT VOUCHER'
                    ORDER BY DATE DESC";
        }
        public static string loadPayGrid()
        {
            return @"  SELECT A.CHQ_ID,A.CHQ_DATE AS[CHQ DATE],D.COA_NAME as [NAME],A.AMOUNT,A.BANK_NAME AS[BANK],A.CHQ_NO AS[CHQ NO]
                  FROM CHQ A 
                  INNER JOIN DAY_BOOK_CHQ B
                  ON A.CHQ_ID = B.CHQ_ID
                  INNER JOIN DAY_BOOK C
                  ON B.DAY_BOOK_ID = C.DAY_BOOK_ID
                  INNER JOIN COA D
                  ON C.CREDIT_AC = D.COA_ID
                  WHERE A.STATUS=0";
        }

        public static string loadPayGrid(int dayBookId)
        {
            return @"  SELECT A.CHQ_ID,C.DEBIT_AC,C.CREDIT_AC,A.CHQ_DATE AS[CHQ DATE],D.COA_NAME as [NAME],A.AMOUNT,A.BANK_NAME AS[BANK],A.CHQ_NO AS[CHQ NO]
                  FROM CHQ A 
                  INNER JOIN DAY_BOOK_CHQ B
                  ON A.CHQ_ID = B.CHQ_ID
                  INNER JOIN DAY_BOOK C
                  ON B.DAY_BOOK_ID = C.DAY_BOOK_ID
                  INNER JOIN COA D
                  ON C.CREDIT_AC = D.COA_ID
                  WHERE B.DAY_BOOK_ID = '"+dayBookId+"'";
        }

        public static string getPayChq(string id)
        {
            string query = @"SELECT C.CHQ_DATE AS[DATE],C.AMOUNT,
                C.BANK_NAME as[BANK],C.CHQ_NO
                FROM DAY_BOOK_CHQ D
                INNER JOIN DAY_BOOK B ON D.DAY_BOOK_ID=B.DAY_BOOK_ID
                INNER JOIN CHQ C ON C.CHQ_ID=D.CHQ_ID
                INNER JOIN PV_CHQS H ON C.CHQ_ID = H.CHQ_ID
                INNER JOIN COA G ON H.PAY_AC = G.COA_ID
                WHERE B.ENTRY_OF='PAYMENT VOUCHER' AND B.DAY_BOOK_ID='" + id + "'";
            return query;
        }

        public static string savePayment(string[] data,List<string> grd)
        {
            string query = @"INSERT INTO DAY_BOOK VALUES('" + data[0] + "','PAYMENT VOUCHER','','" + data[2] + "','" + data[1] + "','" + data[3] + @"',GETDATE(),'1',NULL,NULL); 
                INSERT INTO LEDGERS VALUES('" + data[0]+ "', '" + data[4] + "', '" + data[2] + "', (SELECT ISNULL(MAX(DAY_BOOK_ID),0) from DAY_BOOK), 'PAYMENT VOUCHER', '" + data[3] + @"', '0');
                INSERT INTO LEDGERS VALUES('"+data[0]+ "', '" + data[4] + "', '" + data[1] + "', (SELECT ISNULL(MAX(DAY_BOOK_ID),0) from DAY_BOOK), 'PAYMENT VOUCHER', '0', '" + data[3] + "'); ";
            foreach (var item in grd)
            {
                query += @"UPDATE CHQ SET PAY_DATE='" + data[0] + "', PAY_AC='" + data[2] + "',STATUS=0 WHERE CHQ_ID='"+grd+"'";
            }
            
            return query;
        }

        // CHEQUE DEPOSIT

        public static string loadBank()
        {
            return @"SELECT '0' as [id],'' as [name]
            UNION ALL
            SELECT '0' as [id],BANK_NAME as [name] FROM CHQ
            GROUP BY BANK_NAME
            ORDER BY [name]";
        }

        public static string loadChqDeposit()
        {
            return @"SELECT A.CHQ_ID,A.CHQ_DATE AS[CHQ DATE],B.COA_NAME AS [NAME],A.AMOUNT ,A.BANK_NAME AS[BANK],A.CHQ_NO AS[CHQ NO]
            FROM CHQ A 
            INNER JOIN COA B ON A.REC_AC = B.COA_ID
            WHERE A.STATUS=1";
        }

        public static string loadChqDepositPaid()
        {
            return @"SELECT A.CHQ_ID,A.CHQ_DATE AS[CHQ DATE],B.COA_NAME AS [NAME],A.AMOUNT ,A.BANK_NAME AS[BANK],A.CHQ_NO AS[CHQ NO]
            FROM CHQ A 
            INNER JOIN COA B ON A.REC_AC = B.COA_ID
            WHERE A.STATUS=0";
        }

        public static string loadChqDeposit(int customerId,char status)
        {
            if (status == 'P')
            {
                return @"SELECT CHQ_ID,CHQ_DATE AS[CHQ DATE],(SELECT COA_NAME FROM COA 
                WHERE COA_ID = '" + customerId + @"') as [NAME],AMOUNT,BANK_NAME AS[BANK],
                CHQ_NO AS[CHQ NO],isnull((SELECT COA_NAME FROM COA 
                WHERE COA_ID = isnull(PAY_AC,0)),'-') AS [PAY_AC] FROM CHQ WHERE STATUS=1 and rec_ac = '" + customerId + "'";
            }
            else {
                return @"SELECT CHQ_ID,CHQ_DATE AS[CHQ DATE],(SELECT COA_NAME FROM COA 
                WHERE COA_ID = '" + customerId + @"') as [NAME],AMOUNT,BANK_NAME AS[BANK],
                CHQ_NO AS[CHQ NO],isnull((SELECT COA_NAME FROM COA 
                WHERE COA_ID = isnull(PAY_AC,0)),'-') AS [PAY_AC] FROM CHQ WHERE STATUS=0 and rec_ac = '" + customerId + "'";
            }
        }


        // CHEQUE RETURN

        public static string loadChqReturn()
        {
            return @"SELECT E.DATE AS [CHQ REC DATE],B.ACCOUNT_NAME AS [CHQ REC FROM],
            CASE WHEN A.STATUS = '1' THEN 'AVAILABLE' ELSE 'NOT AVAILABLE' END AS [CHQ STATUS],
            A.CHQ_NO AS [CHQ #],A.AMOUNT AS [CHQ AMOUNT],A.BANK_NAME AS [BANK NAME],
            CASE WHEN A.PAY_AC IS NULL THEN '-' ELSE C.ACCOUNT_NAME END AS [CHQ PAID TO]
            FROM CHQ A
            INNER JOIN CHART_OF_ACCOUNT B ON A.REC_AC = B.COA_ID
            LEFT JOIN CHART_OF_ACCOUNT C ON A.PAY_AC = C.COA_ID
            INNER JOIN DAY_BOOK_CHQ D ON A.CHQ_ID = D.CHQ_ID
            INNER JOIN DAY_BOOK E ON D.DAY_BOOK_ID = E.DAY_BOOK_ID
            WHERE E.DATE BETWEEN '' AND ''";
        }

        
    }
}
