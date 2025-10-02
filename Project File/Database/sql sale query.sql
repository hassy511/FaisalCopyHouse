SELECT* FROM SALE_DETAIL


INSERT INTO SALE_DETAIL (SALE_MASTER_ID,ITEM_ID,QTY,RATE,GST) 
                            VALUES (
                            " + masterId + ",'"
                          + rows.Cells["productId"].Value.ToString() + "','"
                        + rows.Cells["qty"].Value.ToString() + @"','"
                        + rows.Cells["rate"].Value.ToString() + @"','"
                      + rows.Cells["gstt"].Value.ToString() + @"');";
                    }




					SELECT A.ITEM_ID,   
                                                   B.PRODUCT_NAME AS [PRODUCT], 
                                                   A.QTY,
                                                   A.RATE, 
                                                   A.GST,
                                                   (A.QTY * A.RATE) AS [TOTAL], 
                                                   (A.QTY * A.RATE) * (1 + A.GST / 100) AS [TOTAL_WITH_GST]
                                                   FROM SALE_DETAIL A
                                                   INNER JOIN PRODUCT_MASTER B ON A.ITEM_ID = B.PM_ID
                                                   WHERE A.SALE_MASTER_ID = '" + rawId + @"'";


//SALE INVOICE RPT
				
  classHelper.query = @"SELECT A.SALE_MASTER_ID, A.DATE, A.INVOICE_NO, 
                      DATEADD(DAY, A.CREDIT_DAYS, A.DATE) AS [DUE DATE],
                      D.COA_NAME AS [ACCOUNT NAME], C.PRODUCT_NAME, 
                      B.QTY, B.RATE, B.QTY * B.RATE AS [TOTAL]
                      FROM SALE_MASTER A
                      INNER JOIN SALE_DETAIL B ON A.SALE_MASTER_ID = B.SALE_MASTER_ID
                      INNER JOIN PRODUCT_MASTER C ON B.ITEM_ID = C.PM_ID
                      INNER JOIN COA D ON A.CUSTOMER_ID = D.COA_ID
                      WHERE D.STAT = '0' 
                      AND [DATE] BETWEEN '" + dtp_FROM.Value.Date.ToString("yyyy-MM-dd") + @"' 
                      AND '" + Classes.Helper.ConvertDatetime(dtp_TO.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'";






					  //SALE QUERY


					  SELECT A.ITEM_ID,   
                                                   B.PRODUCT_NAME AS [PRODUCT], 
                                                   A.QTY,
                                                   A.RATE, 
                                                   A.GST,
                                                   (A.QTY * A.RATE) AS [TOTAL], 
                                                   (A.QTY * A.RATE) * (1 + A.GST / 100) AS [TOTAL_WITH_GST]
                                                   FROM SALE_DETAIL A
                                                   INNER JOIN PRODUCT_MASTER B ON A.ITEM_ID = B.PM_ID
                                                   WHERE A.SALE_MASTER_ID = '" + rawId + @"'";
