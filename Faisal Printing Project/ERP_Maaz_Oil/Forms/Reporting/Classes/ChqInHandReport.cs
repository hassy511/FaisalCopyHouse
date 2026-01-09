using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Maaz_Oil
{
    class ChqInHandReport
    {
        ERP_Maaz_Oil.Classes.Helper classHelper = new ERP_Maaz_Oil.Classes.Helper();
        public string OverAllQuery()
        {
            return @"--ALL LIST
            SELECT D.DATE AS [REC DATE],B.COA_NAME AS [REC FROM],A.AMOUNT,
            A.BANK_NAME AS [BANK],A.CHQ_DATE AS [CHQ DATE],A.CHQ_NO AS [CHQ NO]
            FROM CHQ A
            INNER JOIN COA B ON A.REC_AC = B.COA_ID
            INNER JOIN DAY_BOOK_CHQ C ON A.CHQ_ID = C.CHQ_ID
            INNER JOIN DAY_BOOK D ON C.DAY_BOOK_ID = D.DAY_BOOK_ID";
        }
        public string CustomerWiseQuery(int customerId)
        {
            return @"--CUSTOMER WISE
            SELECT D.DATE AS [REC DATE],B.COA_NAME AS [REC FROM],A.AMOUNT,
            A.BANK_NAME AS [BANK],A.CHQ_DATE AS [CHQ DATE],A.CHQ_NO AS [CHQ NO]
            FROM CHQ A
            INNER JOIN COA B ON A.REC_AC = B.COA_ID
            INNER JOIN DAY_BOOK_CHQ C ON A.CHQ_ID = C.CHQ_ID
            INNER JOIN DAY_BOOK D ON C.DAY_BOOK_ID = D.DAY_BOOK_ID
            WHERE A.REC_AC = '"+customerId+"'";
        }
        public string SalesPersonWiseQuery(int salesPersonId)
        {
            return @"--SALES PERSON WISE
            SELECT D.DATE AS [REC DATE],B.COA_NAME AS [REC FROM],A.AMOUNT,
            A.BANK_NAME AS [BANK],A.CHQ_DATE AS [CHQ DATE],A.CHQ_NO AS [CHQ NO]
            FROM CHQ A
            INNER JOIN COA B ON A.REC_AC = B.COA_ID
            INNER JOIN DAY_BOOK_CHQ C ON A.CHQ_ID = C.CHQ_ID
            INNER JOIN DAY_BOOK D ON C.DAY_BOOK_ID = D.DAY_BOOK_ID
            INNER JOIN CUSTOMER_PROFILE E ON B.COA_ID = E.COA_ID
            INNER JOIN SALES_PERSONS F ON E.SALE_PER_ID = F.SALES_PER_ID
            WHERE F.SALES_PER_ID = '"+salesPersonId+"'";
        }
        public string DateWiseQuery(DateTime from,DateTime to)
        {
            return @"--DATE WISE
            SELECT D.DATE AS [REC DATE],B.COA_NAME AS [REC FROM],A.AMOUNT,
            A.BANK_NAME AS [BANK],A.CHQ_DATE AS [CHQ DATE],A.CHQ_NO AS [CHQ NO]
            FROM CHQ A
            INNER JOIN COA B ON A.REC_AC = B.COA_ID
            INNER JOIN DAY_BOOK_CHQ C ON A.CHQ_ID = C.CHQ_ID
            INNER JOIN DAY_BOOK D ON C.DAY_BOOK_ID = D.DAY_BOOK_ID
            WHERE D.[DATE] BETWEEN '"+from+"' AND '"+to+"'";
        }
    }
}
