using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ERP_Maaz_Oil.Forms.Reporting
{
    public partial class frm_SupplierAgingReport : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        public frm_SupplierAgingReport()
        {
            InitializeComponent();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.R))
            {
                ShowReport();
            }
            if (keyData == (Keys.Escape))
            {
                this.Dispose();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void OverAllSummary()
        {
            classHelper.query = @"IF OBJECT_ID('dbo.tblTEMPS2', 'U') IS NOT NULL 
            DROP TABLE dbo.tblTEMPS2;

            CREATE TABLE tblTEMPS2(
            SUPPLIER VARCHAR(100),
            [1-10] FLOAT,
            [11-20] FLOAT,
            [21 above] FLOAT
            )
            INSERT INTO tblTEMPS2
            SELECT COA_NAME,0,0,0 FROM tblTEMPS1 GROUP BY COA_NAME;

            DECLARE db_cursor2 CURSOR FOR 

	            SELECT COA_NAME,TOTAL_DAYS,AMOUNT FROM tblTEMPS1 ORDER BY [TOTAL_DAYS];

	            DECLARE @ACOA_NAME VARCHAR(50);
	            DECLARE @ADAYS INT;
	            DECLARE @ATOTAL FLOAT;
	
	            OPEN db_cursor2;
	            FETCH NEXT FROM db_cursor2 INTO @ACOA_NAME,@ADAYS,@ATOTAL;
		            WHILE @@FETCH_STATUS = 0  
		            BEGIN  
			            IF EXISTS (SELECT SUPPLIER FROM tblTEMPS2 WHERE SUPPLIER = @ACOA_NAME)
			            BEGIN
				            IF(@ADAYS < 11)
				            BEGIN
					            UPDATE tblTEMPS2 SET [1-10] = [1-10]+@ATOTAL WHERE SUPPLIER = @ACOA_NAME;
				            END
				            ELSE IF(@ADAYS > 10 AND @ADAYS < 21)
				            BEGIN
					            UPDATE tblTEMPS2 SET [11-20] = [11-20]+@ATOTAL WHERE SUPPLIER = @ACOA_NAME;
				            END
				            ELSE IF(@ADAYS > 20)
				            BEGIN
					            UPDATE tblTEMPS2 SET [21 above] = [21 above]+@ATOTAL WHERE SUPPLIER = @ACOA_NAME;
				            END
			            END
		            FETCH NEXT FROM db_cursor2 INTO @ACOA_NAME,@ADAYS,@ATOTAL;
		            END;
	            CLOSE db_cursor2;
	            DEALLOCATE db_cursor2;

	            SELECT ISNULL(SUPPLIER,'-') AS [SUPPLIER],
            ISNULL([1-10],'0') AS [1-10],
            ISNULL([11-20],'0') AS [11-20],
            ISNULL([21 above],'0') AS [21 above] FROM tblTEMPS2
            WHERE [1-10] + [11-20] + [21 above] > 0";

            try
            {
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    classHelper.nds.Tables["SupplierAgingSummary"].Clear();
                    while (classHelper.dr.Read())
                    {
                        classHelper.dataR = classHelper.nds.Tables["SupplierAgingSummary"].NewRow();
                        classHelper.dataR["Supplier"] = classHelper.dr["SUPPLIER"].ToString();
                        classHelper.dataR["1-10"] = classHelper.dr["1-10"].ToString();
                        classHelper.dataR["11-20"] = Convert.ToDecimal(classHelper.dr["11-20"].ToString());
                        classHelper.dataR["21"] = Convert.ToDecimal(classHelper.dr["21 above"].ToString());
                        classHelper.nds.Tables["SupplierAgingSummary"].Rows.Add(classHelper.dataR);
                    }
                }
                else
                {
                    MessageBox.Show("No Record Found.", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        
        private void LoadSupplier()
        {
            classHelper.query = @"SELECT '0' AS [id],'--SELECT SUPPLIER--' AS [name]
                UNION
                SELECT COA_ID AS [id],COA_NAME AS [name] FROM COA WHERE CA_ID IN ('20','21') AND STAT = 0";
            classHelper.LoadComboData(cmbSupplier, classHelper.query);
        }

        private void ShowReport()
        {
            string heading = "";
            classHelper.query = @"IF OBJECT_ID('dbo.tblTEMPS1', 'U') IS NOT NULL 
                                DROP TABLE dbo.tblTEMPS1;";
            if (rdbOverAll.Checked == true)
            {
                heading = "OVERALL SUPPLIER AGING REPORTS";
                classHelper.query += @"--SUPPLIER OVERALL AGING REPORT
                CREATE TABLE tblTEMPS1(
	                [DATE] DATETIME,
	                INVOICE_NO VARCHAR(50),
	                COA_NAME VARCHAR(100),
	                VEHICLE_NO VARCHAR(100),
	                MATERIAL VARCHAR(100),
	                [WEIGHT] FLOAT,
	                RATE FLOAT,
	                AMOUNT FLOAT,
	                [DAYS] INT,
	                COA_ID INT,
	                DUE_DATE DATETIME,
	                TOTAL_DAYS INT
                )

                DECLARE @BALANCE FLOAT;
                DECLARE @LAST_ACCOUNT INT;

                DECLARE db_cursor CURSOR FOR 
                    SELECT '"+Classes.Helper.openingDate+ @"' AS [DATE],'-' AS [INVOICE_NO],A.COA_NAME,
                    '' AS [VEHICLE_NO],'' AS [MATERIAL_NAME],'0' AS [NET_WEIGHT],'0' AS [RATE],
                    CASE WHEN A.DR_CR = 'D' THEN 
	                    -A.OPEN_BAL + (SELECT ISNULL(SUM(CREDIT),0) FROM LEDGERS WHERE COA_ID = A.COA_ID AND CREDIT <> 0 AND ENTRY_OF NOT IN ('PURCHASES','OTHER PURCHASES')) 
                    ELSE 
	                    A.OPEN_BAL + (SELECT ISNULL(SUM(CREDIT),0) FROM LEDGERS WHERE COA_ID = A.COA_ID AND CREDIT <> 0 AND ENTRY_OF NOT IN ('PURCHASES','OTHER PURCHASES'))  
                    END AS [AMOUNT],
                    '0' AS CREDIT_DAYS,A.COA_ID AS SUPPLIER_ID,
                    DATEADD(DAY,0,GETDATE()) AS [DUE DATE],
                    DATEDIFF(DAY,'" + Classes.Helper.openingDate + @"',GETDATE()) AS [TOTAL DAYS],'0' AS PI_ID
                    FROM COA A
                    WHERE DATEDIFF(DAY,'" + Classes.Helper.openingDate + @"',GETDATE()) > 0 AND A.CA_ID = 20
                    UNION ALL
	                SELECT A.DATE,A.INVOICE_NO,D.COA_NAME,A.VEHICLE_NO,E.MATERIAL_NAME,A.NET_WEIGHT,
	                CASE WHEN E.MATERIAL_NAME = 'CANOLA' THEN A.KG_RATE ELSE A.MUAND_RATE END AS [RATE],
	                CASE WHEN E.MATERIAL_NAME = 'CANOLA' THEN A.KG_RATE * A.NET_WEIGHT ELSE --(A.MUAND_RATE / 37.324) * A.NET_WEIGHT 
                    A.KG_RATE * A.NET_WEIGHT 
                    END 
                    AS [AMOUNT],
	                A.CREDIT_DAYS,A.SUPPLIER_ID,DATEADD(DAY,A.CREDIT_DAYS,A.DATE) AS [DUE DATE],
	                DATEDIFF(DAY,A.DATE,GETDATE()) AS [TOTAL DAYS],A.PI_ID
	                FROM PURCHASES A
	                INNER JOIN PURCHASES_ORDER B ON A.PO_ID = B.PO_ID
	                INNER JOIN COA D ON A.SUPPLIER_ID = D.COA_ID
	                INNER JOIN MATERIALS E ON E.MATERIAL_ID = B.MATERIAL_ID
	                WHERE DATEDIFF(DAY,A.DATE,GETDATE()) > 0 
	                ORDER BY [COA_NAME],PI_ID,[DATE]

	                DECLARE @DATE DATETIME;
	                DECLARE @INVOICE_NO VARCHAR(50);
	                DECLARE @COA_NAME VARCHAR(100);
	                DECLARE @VEHICLE VARCHAR(100);
	                DECLARE @MATERIAL VARCHAR(100);
	                DECLARE @WEIGHT FLOAT;
	                DECLARE @RATE FLOAT;
	                DECLARE @AMOUNT FLOAT;
	                DECLARE @DAYS INT;
	                DECLARE @COA_ID INT;
	                DECLARE @DUE_DATE DATETIME;
	                DECLARE @C_DAYS INT;
                    DECLARE @P_ID INT;
	
	                OPEN db_cursor;
	                FETCH NEXT FROM db_cursor INTO @DATE,@INVOICE_NO,@COA_NAME,@VEHICLE,@MATERIAL,@WEIGHT,@RATE,@AMOUNT,@DAYS,@COA_ID,@DUE_DATE,@C_DAYS,@P_ID;
		                WHILE @@FETCH_STATUS = 0  
		                    BEGIN  
			                    IF(@LAST_ACCOUNT = @COA_ID)
			                    BEGIN
				                    IF(@AMOUNT < @BALANCE)
				                    BEGIN
					                    SET @BALANCE = @BALANCE - @AMOUNT;
				                    END
				                    ELSE
				                    BEGIN
					                    INSERT INTO tblTEMPS1 VALUES (@DATE,@INVOICE_NO,@COA_NAME,@VEHICLE,@MATERIAL,@WEIGHT,@RATE,@AMOUNT-@balance,@DAYS,@COA_ID,@DUE_DATE,@C_DAYS);
					                    SET @BALANCE = 0;
				                    END
			                    END
			                    ELSE
			                    BEGIN	
				                    SET @LAST_ACCOUNT = @COA_ID;
				                    
				                SET @BALANCE = 
                                    (SELECT ISNULL(SUM(DEBIT),0) FROM LEDGERS WHERE COA_ID = @COA_ID AND FOLIO IS NOT NULL)+
                                    (SELECT ISNULL(SUM(AMOUNT),0) FROM PAYMENT_TRANSFER WHERE PAY_AC = @COA_ID AND STATUS = 0)+
                                    (SELECT ISNULL(SUM(AMOUNT),0) FROM CHQ WHERE PAY_AC = @COA_ID AND [STATUS] = 1); 					                    
IF(@AMOUNT < @BALANCE)
					                    BEGIN
						                    SET @BALANCE = @BALANCE - @AMOUNT;
					                    END
					                    ELSE
					                    BEGIN
						                    INSERT INTO tblTEMPS1 VALUES (@DATE,@INVOICE_NO,@COA_NAME,@VEHICLE,@MATERIAL,@WEIGHT,@RATE,@AMOUNT-@balance,@DAYS,@COA_ID,@DUE_DATE,@C_DAYS);
						                    SET @BALANCE = 0;
					                    END
			                    END
	                FETCH NEXT FROM db_cursor INTO @DATE,@INVOICE_NO,@COA_NAME,@VEHICLE,@MATERIAL,@WEIGHT,@RATE,@AMOUNT,@DAYS,@COA_ID,@DUE_DATE,@C_DAYS,@P_ID;
	                END;
                CLOSE db_cursor;
                DEALLOCATE db_cursor;

                SELECT * FROM tblTEMPS1 WHERE AMOUNT >= 1 ORDER BY [TOTAL_DAYS] DESC;";
            }

            else if (rdbDueDate.Checked == true)
            {
                heading = "DUE DATE WISE SUPPLIER AGING REPORTS";
                classHelper.query += @"
                --SUPPLIER DUE DATE AGING REPORT
                CREATE TABLE tblTEMPS1(
	                [DATE] DATETIME,
	                INVOICE_NO VARCHAR(50),
	                COA_NAME VARCHAR(100),
	                VEHICLE_NO VARCHAR(100),
	                MATERIAL VARCHAR(100),
	                [WEIGHT] FLOAT,
	                RATE FLOAT,
	                AMOUNT FLOAT,
	                [DAYS] INT,
	                COA_ID INT,
	                DUE_DATE DATETIME,
	                TOTAL_DAYS INT
                )

                DECLARE @BALANCE FLOAT;
                DECLARE @LAST_ACCOUNT INT;

                DECLARE db_cursor CURSOR FOR 
                    SELECT '" + Classes.Helper.openingDate + @"' AS [DATE],'-' AS [INVOICE_NO],A.COA_NAME,
                    '' AS [VEHICLE_NO],'' AS [MATERIAL_NAME],'0' AS [NET_WEIGHT],'0' AS [RATE],
                    CASE WHEN A.DR_CR = 'D' THEN 
                    -A.OPEN_BAL + (SELECT ISNULL(SUM(CREDIT),0) FROM LEDGERS WHERE COA_ID = A.COA_ID AND CREDIT <> 0 AND ENTRY_OF NOT IN ('PURCHASES','OTHER PURCHASES')) 
                    ELSE 
                    A.OPEN_BAL + (SELECT ISNULL(SUM(CREDIT),0) FROM LEDGERS WHERE COA_ID = A.COA_ID AND CREDIT <> 0 AND ENTRY_OF NOT IN ('PURCHASES','OTHER PURCHASES'))  
                    END AS [AMOUNT],
                    '0' AS CREDIT_DAYS,A.COA_ID AS SUPPLIER_ID,
                    DATEADD(DAY,0,GETDATE()) AS [DUE DATE],
                    DATEDIFF(DAY,'" + Classes.Helper.openingDate + @"',GETDATE()) AS [TOTAL DAYS],'0' AS PI_ID
                    FROM COA A
                    WHERE DATEDIFF(DAY,'" + Classes.Helper.openingDate + @"',GETDATE()) > 0 AND A.CA_ID = 20 AND DATEADD(DAY,0,GETDATE()) <= '" + Classes.Helper.ConvertDatetime(dtpDueDate.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'
                    UNION ALL
	                SELECT A.DATE,A.INVOICE_NO,D.COA_NAME,A.VEHICLE_NO,E.MATERIAL_NAME,A.NET_WEIGHT,
	                CASE WHEN E.MATERIAL_NAME = 'CANOLA' THEN A.KG_RATE ELSE A.MUAND_RATE END AS [RATE],
	                CASE WHEN E.MATERIAL_NAME = 'CANOLA' THEN A.KG_RATE * A.NET_WEIGHT ELSE --(A.MUAND_RATE / 37.324) * A.NET_WEIGHT 
                    A.KG_RATE * A.NET_WEIGHT 
                    END 
                    AS [AMOUNT],
	                A.CREDIT_DAYS,A.SUPPLIER_ID,DATEADD(DAY,A.CREDIT_DAYS,A.DATE) AS [DUE DATE],
	                DATEDIFF(DAY,A.DATE,GETDATE()) AS [TOTAL DAYS],A.PI_ID
	                FROM PURCHASES A
	                INNER JOIN PURCHASES_ORDER B ON A.PO_ID = B.PO_ID
	                INNER JOIN COA D ON A.SUPPLIER_ID = D.COA_ID
	                INNER JOIN MATERIALS E ON E.MATERIAL_ID = B.MATERIAL_ID
	                WHERE DATEDIFF(DAY,A.DATE,GETDATE()) > 0 AND DATEADD(DAY,A.CREDIT_DAYS,A.DATE) <= '" + Classes.Helper.ConvertDatetime(dtpDueDate.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59))+ @"'
	                ORDER BY [COA_NAME],PI_ID,[DATE]

	                DECLARE @DATE DATETIME;
	                DECLARE @INVOICE_NO VARCHAR(50);
	                DECLARE @COA_NAME VARCHAR(100);
	                DECLARE @VEHICLE VARCHAR(100);
	                DECLARE @MATERIAL VARCHAR(100);
	                DECLARE @WEIGHT FLOAT;
	                DECLARE @RATE FLOAT;
	                DECLARE @AMOUNT FLOAT;
	                DECLARE @DAYS INT;
	                DECLARE @COA_ID INT;
	                DECLARE @DUE_DATE DATETIME;
	                DECLARE @C_DAYS INT;
                    DECLARE @P_ID INT;
	
	                OPEN db_cursor;
	                FETCH NEXT FROM db_cursor INTO @DATE,@INVOICE_NO,@COA_NAME,@VEHICLE,@MATERIAL,@WEIGHT,@RATE,@AMOUNT,@DAYS,@COA_ID,@DUE_DATE,@C_DAYS,@P_ID;
		                WHILE @@FETCH_STATUS = 0  
		                    BEGIN  
			                    IF(@LAST_ACCOUNT = @COA_ID)
			                    BEGIN
				                    IF(@AMOUNT < @BALANCE)
				                    BEGIN
					                    SET @BALANCE = @BALANCE - @AMOUNT;
				                    END
				                    ELSE
				                    BEGIN
					                    INSERT INTO tblTEMPS1 VALUES (@DATE,@INVOICE_NO,@COA_NAME,@VEHICLE,@MATERIAL,@WEIGHT,@RATE,@AMOUNT-@balance,@DAYS,@COA_ID,@DUE_DATE,@C_DAYS);
					                    SET @BALANCE = 0;
				                    END
			                    END
			                    ELSE
			                    BEGIN	
				                    SET @LAST_ACCOUNT = @COA_ID;
				                    SET @BALANCE = 
                                    (SELECT ISNULL(SUM(DEBIT),0) FROM LEDGERS WHERE COA_ID = @COA_ID AND FOLIO IS NOT NULL AND [DATE] <= '" + Classes.Helper.ConvertDatetime(dtpDueDate.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"')+
                                    (SELECT ISNULL(SUM(AMOUNT),0) FROM PAYMENT_TRANSFER WHERE PAY_AC = @COA_ID AND STATUS = 0 AND [DATE] <= '" + Classes.Helper.ConvertDatetime(dtpDueDate.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"')+
                                    (SELECT ISNULL(SUM(AMOUNT),0) FROM CHQ WHERE PAY_AC = @COA_ID AND [STATUS] = 1 AND [CHQ_DATE] <= '" + Classes.Helper.ConvertDatetime(dtpDueDate.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) + @"'); 
					                    IF(@AMOUNT < @BALANCE)
					                    BEGIN
						                    SET @BALANCE = @BALANCE - @AMOUNT;
					                    END
					                    ELSE
					                    BEGIN
						                    INSERT INTO tblTEMPS1 VALUES (@DATE,@INVOICE_NO,@COA_NAME,@VEHICLE,@MATERIAL,@WEIGHT,@RATE,@AMOUNT-@balance,@DAYS,@COA_ID,@DUE_DATE,@C_DAYS);
						                    SET @BALANCE = 0;
					                    END
			                    END
	                FETCH NEXT FROM db_cursor INTO @DATE,@INVOICE_NO,@COA_NAME,@VEHICLE,@MATERIAL,@WEIGHT,@RATE,@AMOUNT,@DAYS,@COA_ID,@DUE_DATE,@C_DAYS,@P_ID;
	                END;
                CLOSE db_cursor;
                DEALLOCATE db_cursor;

                SELECT * FROM tblTEMPS1 WHERE AMOUNT >= 1 ORDER BY [TOTAL_DAYS] DESC;";
            }
            else if (rdbSupplier.Checked == true && cmbSupplier.SelectedIndex != 0)
            {
                heading = "SUPPLIER WISE AGING REPORTS";
                classHelper.query += @"--SUPPLIER WISE AGING REPORT
                CREATE TABLE tblTEMPS1(
	                [DATE] DATETIME,
	                INVOICE_NO VARCHAR(50),
	                COA_NAME VARCHAR(100),
	                VEHICLE_NO VARCHAR(100),
	                MATERIAL VARCHAR(100),
	                [WEIGHT] FLOAT,
	                RATE FLOAT,
	                AMOUNT FLOAT,
	                [DAYS] INT,
	                COA_ID INT,
	                DUE_DATE DATETIME,
	                TOTAL_DAYS INT
                )

                DECLARE @BALANCE FLOAT;
                DECLARE @LAST_ACCOUNT INT;

                DECLARE db_cursor CURSOR FOR 
                    SELECT '" + Classes.Helper.openingDate + @"' AS [DATE],'-' AS [INVOICE_NO],A.COA_NAME,
                    '' AS [VEHICLE_NO],'' AS [MATERIAL_NAME],'0' AS [NET_WEIGHT],'0' AS [RATE],
                    CASE WHEN A.DR_CR = 'D' THEN 
                    -A.OPEN_BAL + (SELECT ISNULL(SUM(CREDIT),0) FROM LEDGERS WHERE COA_ID = A.COA_ID AND CREDIT <> 0 AND ENTRY_OF NOT IN ('PURCHASES','OTHER PURCHASES')) 
                    ELSE 
                    A.OPEN_BAL + (SELECT ISNULL(SUM(CREDIT),0) FROM LEDGERS WHERE COA_ID = A.COA_ID AND CREDIT <> 0 AND ENTRY_OF NOT IN ('PURCHASES','OTHER PURCHASES'))  
                    END AS [AMOUNT],
                    '0' AS CREDIT_DAYS,A.COA_ID AS SUPPLIER_ID,
                    DATEADD(DAY,0,GETDATE()) AS [DUE DATE],
                    DATEDIFF(DAY,'" + Classes.Helper.openingDate + @"',GETDATE()) AS [TOTAL DAYS],'0' AS PI_ID
                    FROM COA A
                    WHERE DATEDIFF(DAY,'" + Classes.Helper.openingDate + @"',GETDATE()) > 0 AND A.CA_ID = 20 AND A.COA_ID = '" + cmbSupplier.SelectedValue.ToString() + @"'
                    UNION ALL
	                SELECT A.DATE,A.INVOICE_NO,D.COA_NAME,A.VEHICLE_NO,E.MATERIAL_NAME,A.NET_WEIGHT,
	                CASE WHEN E.MATERIAL_NAME = 'CANOLA' THEN A.KG_RATE ELSE A.MUAND_RATE END AS [RATE],
                    CASE WHEN E.MATERIAL_NAME = 'CANOLA' THEN A.KG_RATE * A.NET_WEIGHT ELSE --ROUND((A.MUAND_RATE / 37.324) ,0) * A.NET_WEIGHT 
                    A.KG_RATE * A.NET_WEIGHT 
                    END 
                    AS [AMOUNT],
	                A.CREDIT_DAYS,A.SUPPLIER_ID,DATEADD(DAY,A.CREDIT_DAYS,A.DATE) AS [DUE DATE],
	                DATEDIFF(DAY,A.DATE,GETDATE()) AS [TOTAL DAYS],A.PI_ID
	                FROM PURCHASES A
	                INNER JOIN PURCHASES_ORDER B ON A.PO_ID = B.PO_ID
	                INNER JOIN COA D ON A.SUPPLIER_ID = D.COA_ID
	                INNER JOIN MATERIALS E ON E.MATERIAL_ID = B.MATERIAL_ID
	                WHERE DATEDIFF(DAY,A.DATE,GETDATE()) > 0 AND A.SUPPLIER_ID = '" + cmbSupplier.SelectedValue.ToString()+ @"'
	                ORDER BY [COA_NAME],PI_ID,[DATE]

	                DECLARE @DATE DATETIME;
	                DECLARE @INVOICE_NO VARCHAR(50);
	                DECLARE @COA_NAME VARCHAR(100);
	                DECLARE @VEHICLE VARCHAR(100);
	                DECLARE @MATERIAL VARCHAR(100);
	                DECLARE @WEIGHT FLOAT;
	                DECLARE @RATE FLOAT;
	                DECLARE @AMOUNT FLOAT;
	                DECLARE @DAYS INT;
	                DECLARE @COA_ID INT;
	                DECLARE @DUE_DATE DATETIME;
	                DECLARE @C_DAYS INT;
                    DECLARE @P_ID INT;
	
	                OPEN db_cursor;
	                FETCH NEXT FROM db_cursor INTO @DATE,@INVOICE_NO,@COA_NAME,@VEHICLE,@MATERIAL,@WEIGHT,@RATE,@AMOUNT,@DAYS,@COA_ID,@DUE_DATE,@C_DAYS,@P_ID;
		                WHILE @@FETCH_STATUS = 0  
		                    BEGIN  
			                    IF(@LAST_ACCOUNT = @COA_ID)
			                    BEGIN
				                    IF(@AMOUNT < @BALANCE)
				                    BEGIN
					                    SET @BALANCE = @BALANCE - @AMOUNT;
				                    END
				                    ELSE
				                    BEGIN
					                    INSERT INTO tblTEMPS1 VALUES (@DATE,@INVOICE_NO,@COA_NAME,@VEHICLE,@MATERIAL,@WEIGHT,@RATE,@AMOUNT-@balance,@DAYS,@COA_ID,@DUE_DATE,@C_DAYS);
					                    SET @BALANCE = 0;
				                    END
			                    END
			                    ELSE
			                    BEGIN	
				                    SET @LAST_ACCOUNT = @COA_ID;
				                    SET @BALANCE = 
                                    (SELECT ISNULL(SUM(DEBIT),0) FROM LEDGERS WHERE COA_ID = @COA_ID AND FOLIO IS NOT NULL)+
                                    (SELECT ISNULL(SUM(AMOUNT),0) FROM PAYMENT_TRANSFER WHERE PAY_AC = @COA_ID AND STATUS = 0)+
                                    (SELECT ISNULL(SUM(AMOUNT),0) FROM CHQ WHERE PAY_AC = @COA_ID AND [STATUS] = 1); 
					                    IF(@AMOUNT < @BALANCE)
					                    BEGIN
						                    SET @BALANCE = @BALANCE - @AMOUNT;
					                    END
					                    ELSE
					                    BEGIN
						                    INSERT INTO tblTEMPS1 VALUES (@DATE,@INVOICE_NO,@COA_NAME,@VEHICLE,@MATERIAL,@WEIGHT,@RATE,@AMOUNT-@balance,@DAYS,@COA_ID,@DUE_DATE,@C_DAYS);
						                    SET @BALANCE = 0;
					                    END
			                    END
	                FETCH NEXT FROM db_cursor INTO @DATE,@INVOICE_NO,@COA_NAME,@VEHICLE,@MATERIAL,@WEIGHT,@RATE,@AMOUNT,@DAYS,@COA_ID,@DUE_DATE,@C_DAYS,@P_ID;
	                END;
                CLOSE db_cursor;
                DEALLOCATE db_cursor;

                SELECT * FROM tblTEMPS1 WHERE AMOUNT >= 1 ORDER BY [TOTAL_DAYS] DESC;";
            }

            char hasRows = 'N';
            try
            {
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    hasRows = 'Y';
                    classHelper.nds.Tables["SupplierAgingReport"].Clear();
                    while (classHelper.dr.Read())
                    {
                        classHelper.dataR = classHelper.nds.Tables["SupplierAgingReport"].NewRow();
                        classHelper.dataR["Date"] = Convert.ToDateTime(classHelper.dr["DATE"].ToString());
                        classHelper.dataR["Invoice"] = classHelper.dr["INVOICE_NO"].ToString();
                        classHelper.dataR["AccountName"] = classHelper.dr["COA_NAME"].ToString();
                        classHelper.dataR["VehicleNo"] = classHelper.dr["VEHICLE_NO"].ToString();
                        classHelper.dataR["Material"] = classHelper.dr["MATERIAL"].ToString();
                        classHelper.dataR["Weight"] = Convert.ToDecimal(classHelper.dr["WEIGHT"].ToString());
                        classHelper.dataR["Rate"] = Convert.ToDecimal(classHelper.dr["RATE"].ToString());
                        classHelper.dataR["Amount"] = Convert.ToDecimal(classHelper.dr["AMOUNT"].ToString());
                        classHelper.dataR["Days"] = classHelper.dr["DAYS"].ToString();
                        classHelper.dataR["TotalDays"] = classHelper.dr["TOTAL_DAYS"].ToString();
                        classHelper.dataR["CoaId"] = classHelper.dr["COA_ID"].ToString();
                        classHelper.dataR["DueDate"] = Convert.ToDateTime(classHelper.dr["DUE_DATE"].ToString());
                        classHelper.dataR["Heading"] = heading;
                        classHelper.nds.Tables["SupplierAgingReport"].Rows.Add(classHelper.dataR);
                    }
                }
                else
                {
                    MessageBox.Show("No Record Found.", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            if (hasRows == 'Y')
            {
                OverAllSummary();
                if (rdbOverAll.Checked == true)
                {
                    classHelper.rpt = new frmReports();
                    classHelper.rpt.GenerateReport("AgingReportSupplierO", classHelper.nds);
                    classHelper.rpt.ShowDialog();
                }
                else if (rdbDueDate.Checked == true)
                {
                    classHelper.rpt = new frmReports();
                    classHelper.rpt.GenerateReport("AgingReportSupplierD", classHelper.nds);
                    classHelper.rpt.ShowDialog();
                }
                else if (rdbSupplier.Checked == true)
                {
                    classHelper.rpt = new frmReports();
                    classHelper.rpt.GenerateReport("AgingReportSupplier", classHelper.nds);
                    classHelper.rpt.ShowDialog();
                }
            }
        }

        private void grpSALES_Enter(object sender, EventArgs e)
        {

        }

        private void btnINTER_SAVE_Click(object sender, EventArgs e)
        {
            ShowReport();
            //if (cmbSalePerson.SelectedIndex == 0)
            //{
            //    MessageBox.Show("Select an Sales Person.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //else
            //{

            //}

        }

        private void frm_Account_Ledger_Load(object sender, EventArgs e)
        {
            LoadSupplier();
        }

        private void frm_Account_Ledger_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void lblAC_NAME_Click(object sender, EventArgs e)
        {

        }

        private void cmbSalePerson_TextUpdate(object sender, EventArgs e)
        {
            classHelper.CmbTextUpdate(sender as ComboBox);
        }

        private void cmbSalePerson_DropDown(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown += new PreviewKeyDownEventHandler(cmbSalePerson_PreviewKeyDown);
        }

        private void cmbSalePerson_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown -= cmbSalePerson_PreviewKeyDown;
            if (cbo.DroppedDown) cbo.Focus();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //if (rdbOverAll.Checked == true)
            //{
            //    cmbSalePerson.Enabled = true;
            //}
            //else
            //{
            //    cmbSalePerson.Enabled = false;
            //}
        }

        private void rdbProvince_CheckedChanged(object sender, EventArgs e)
        {
            //if (rdbDueDate.Checked == true)
            //{
            //    cmbProvnice.Enabled = true;
            //}
            //else
            //{
            //    cmbProvnice.Enabled = false;
            //}
        }

        private void rdbCustomer_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbSupplier.Checked == true)
            {
                cmbSupplier.Enabled = true;
            }
            else
            {
                cmbSupplier.Enabled = false;
            }
        }

        private void cmbProvnice_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown -= cmbProvnice_PreviewKeyDown;
            if (cbo.DroppedDown) cbo.Focus();
        }

        private void cmbCustomer_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown -= cmbCustomer_PreviewKeyDown;
            if (cbo.DroppedDown) cbo.Focus();

        }

        private void cmbProvnice_DropDown(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown += new PreviewKeyDownEventHandler(cmbProvnice_PreviewKeyDown);
        }

        private void cmbCustomer_DropDown(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown += new PreviewKeyDownEventHandler(cmbCustomer_PreviewKeyDown);
        }

        private void cmbSalePerson_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
