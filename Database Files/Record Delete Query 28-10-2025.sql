SELECT 
    t.name AS TableName,
	'select * from '+t.name
FROM 
    sys.tables AS t
WHERE 
    EXISTS (
        SELECT 1 
        FROM sys.partitions AS p 
        WHERE p.object_id = t.object_id 
          AND p.index_id IN (0,1) 
          AND p.rows > 0
    )
ORDER BY 
    t.name;


delete from BANK_VOUCHER
truncate table BANK_VOUCHER
delete from CASH_VOUCHER
truncate table CASH_VOUCHER
delete from COA where coa_id not in (23,1082,2106,5110,5111,5112,89168,89174,89178)
delete from DAY_BOOK
truncate table DAY_BOOK
delete from GENERAL_VOUCHER_D
truncate table GENERAL_VOUCHER_D
delete from GENERAL_VOUCHER_M
truncate table GENERAL_VOUCHER_M
delete from LEDGERS
truncate table LEDGERS
delete from PRODUCT_CATEGORY where p_category_id not in (1)
delete from PRODUCT_ITEM_LEDGER
truncate table PRODUCT_ITEM_LEDGER
delete from PRODUCT_MASTER
truncate table PRODUCT_MASTER
delete from PURCHASE_DETAIL
truncate table PURCHASE_DETAIL
delete from PURCHASE_MASTER
truncate table PURCHASE_MASTER
delete from PURCHASE_RETURN_DETAIL
truncate table PURCHASE_RETURN_DETAIL
delete from PURCHASE_RETURN_MASTER
truncate table PURCHASE_RETURN_MASTER
delete from PURCHASES_ORDER
truncate table PURCHASES_ORDER
delete from PURCHASES_ORDER_DETAILS
truncate table PURCHASES_ORDER_DETAILS
delete from SALE_DETAIL
truncate table SALE_DETAIL
delete from SALE_EXPENSE
truncate table SALE_EXPENSE
delete from SALE_MASTER
truncate table SALE_MASTER
delete from SALE_RETURN_DETAIL
truncate table SALE_RETURN_DETAIL
delete from SALE_RETURN_MASTER
truncate table SALE_RETURN_MASTER
delete from SALES_ORDER_PRODUCT_DETAILS
truncate table SALES_ORDER_PRODUCT_DETAILS
delete from SALES_ORDER_PRODUCT_MASTER
truncate table SALES_ORDER_PRODUCT_MASTER
delete from SERVICE_TYPES
truncate table SERVICE_TYPES
