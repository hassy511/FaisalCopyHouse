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
    public partial class frm_CustomerAgingReport : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        public frm_CustomerAgingReport()
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
            classHelper.query = @"IF OBJECT_ID('dbo.tblTEMP4', 'U') IS NOT NULL 
            DROP TABLE dbo.tblTEMP4;

            CREATE TABLE tblTEMP4(
            PROVINCE VARCHAR(100),
            SALES_PERSON VARCHAR(100),
            [1-19] FLOAT,
            [20-30] FLOAT,
            [31 above] FLOAT
            )
            INSERT INTO tblTEMP4
            SELECT REGION,SALES_PERSON,0,0,0 FROM tblTEMP1 WHERE 1=1";

            if (chkArea.Checked == true && cmbArea.SelectedIndex > 0)
            {
                classHelper.query += " AND AREA_ID = '" + cmbArea.SelectedValue.ToString() + "'";
            }

            if (chkDays.Checked == true && cmbDays.SelectedIndex > 0 && cmbDays.Text.Equals("[0-20]"))
            {
                classHelper.query += " AND [DAYS] BETWEEN '0' AND '20' ";
            }
            else if (chkDays.Checked == true && cmbDays.SelectedIndex > 0 && cmbDays.Text.Equals("[21-30]"))
            {
                classHelper.query += " AND [DAYS] BETWEEN '21' AND '30' ";
            }
            else if (chkDays.Checked == true && cmbDays.SelectedIndex > 0 && cmbDays.Text.Equals("[30 Above]"))
            {
                classHelper.query += " AND [DAYS] > '30' ";
            }

            classHelper.query += @"GROUP BY REGION,SALES_PERSON;

            DECLARE db_cursor2 CURSOR FOR 

	        SELECT REGION,SALES_PERSON,DAYS,AMOUNT FROM tblTEMP1 WHERE 1=1";

            if (chkArea.Checked == true && cmbArea.SelectedIndex > 0)
            {
                classHelper.query += " AND AREA_ID = '" + cmbArea.SelectedValue.ToString() + "'";
            }

            if (chkDays.Checked == true && cmbDays.SelectedIndex > 0 && cmbDays.Text.Equals("[0-20]"))
            {
                classHelper.query += " AND [DAYS] BETWEEN '0' AND '20' ";
            }
            else if (chkDays.Checked == true && cmbDays.SelectedIndex > 0 && cmbDays.Text.Equals("[21-30]"))
            {
                classHelper.query += " AND [DAYS] BETWEEN '21' AND '30' ";
            }
            else if (chkDays.Checked == true && cmbDays.SelectedIndex > 0 && cmbDays.Text.Equals("[30 Above]"))
            {
                classHelper.query += " AND [DAYS] > '30' ";
            }

            classHelper.query += @" ORDER BY [DAYS];

	            DECLARE @AREGION VARCHAR(50);
	            DECLARE @ASALES_PERSON VARCHAR(50);
	            DECLARE @ADAYS INT;
	            DECLARE @ATOTAL FLOAT;
	
	            OPEN db_cursor2;
	            FETCH NEXT FROM db_cursor2 INTO @AREGION,@ASALES_PERSON,@ADAYS,@ATOTAL;
		            WHILE @@FETCH_STATUS = 0  
		            BEGIN  
			            IF EXISTS (SELECT PROVINCE FROM tblTEMP4 WHERE PROVINCE = @AREGION AND SALES_PERSON = @ASALES_PERSON)
			            BEGIN
				            IF(@ADAYS < 19)
				            BEGIN
					            PRINT 'SP EX < 19';
					            UPDATE tblTEMP4 SET [1-19] = [1-19]+@ATOTAL WHERE PROVINCE = @AREGION AND SALES_PERSON = @ASALES_PERSON;
				            END
				            ELSE IF(@ADAYS >= 19 AND @ADAYS <= 30)
				            BEGIN
					            PRINT 'SP EX > 19 < 30';
					            UPDATE tblTEMP4 SET [20-30] = [20-30]+@ATOTAL WHERE PROVINCE = @AREGION AND SALES_PERSON = @ASALES_PERSON;
				            END
				            ELSE IF(@ADAYS > 30)
				            BEGIN
					            PRINT 'SP EX > 30';
					            UPDATE tblTEMP4 SET [31 above] = [31 above]+@ATOTAL WHERE PROVINCE = @AREGION AND SALES_PERSON = @ASALES_PERSON;
				            END
			            END
		            FETCH NEXT FROM db_cursor2 INTO @AREGION,@ASALES_PERSON,@ADAYS,@ATOTAL;
		            END;
	            CLOSE db_cursor2;
	            DEALLOCATE db_cursor2;

	            SELECT ISNULL(PROVINCE,'-') AS [PROVINCE],ISNULL(SALES_PERSON,'-') AS [SALES_PERSON],
				ISNULL([1-19],'0') AS [1-19],ISNULL([20-30],'0') AS [20-30],ISNULL([31 above],'0') AS [31 above] 
				FROM tblTEMP4
                WHERE ISNULL([1-19],'0') + ISNULL([20-30],'0') +ISNULL([31 above],'0') > 0";

            try
            {
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    classHelper.nds.Tables["AgingSummary"].Clear();
                    while (classHelper.dr.Read())
                    {
                        classHelper.dataR = classHelper.nds.Tables["AgingSummary"].NewRow();
                        classHelper.dataR["Province"] = classHelper.dr["PROVINCE"].ToString();
                        classHelper.dataR["SalesPerson"] = classHelper.dr["SALES_PERSON"].ToString();
                        classHelper.dataR["1-19"] = Convert.ToDecimal(classHelper.dr["1-19"].ToString());
                        classHelper.dataR["20-30"] = Convert.ToDecimal(classHelper.dr["20-30"].ToString());
                        classHelper.dataR["31"] = Convert.ToDecimal(classHelper.dr["31 above"].ToString());
                        classHelper.nds.Tables["AgingSummary"].Rows.Add(classHelper.dataR);
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
        private void OverAllSubSummary()
        {
            classHelper.query = @"IF OBJECT_ID('dbo.tblTEMP5', 'U') IS NOT NULL 
            DROP TABLE dbo.tblTEMP5;

            CREATE TABLE tblTEMP5(
            SALES_PERSON VARCHAR(100),
            BALOCHISTAN FLOAT,
            KPK FLOAT,
            PUNJAB FLOAT,
            SINDH FLOAT
            )
            INSERT INTO tblTEMP5
            SELECT SALES_PERSON,0,0,0,0 FROM tblTEMP1 WHERE 1=1 ";

            if (chkArea.Checked == true && cmbArea.SelectedIndex > 0)
            {
                classHelper.query += " AND AREA_ID = '" + cmbArea.SelectedValue.ToString() + "'";
            }

            if (chkDays.Checked == true && cmbDays.SelectedIndex > 0 && cmbDays.Text.Equals("[0-20]"))
            {
                classHelper.query += " AND [DAYS] BETWEEN '0' AND '20' ";
            }
            else if (chkDays.Checked == true && cmbDays.SelectedIndex > 0 && cmbDays.Text.Equals("[21-30]"))
            {
                classHelper.query += " AND [DAYS] BETWEEN '21' AND '30' ";
            }
            else if (chkDays.Checked == true && cmbDays.SelectedIndex > 0 && cmbDays.Text.Equals("[30 Above]"))
            {
                classHelper.query += " AND [DAYS] > '30' ";
            }

            classHelper.query += @"GROUP BY SALES_PERSON;

            DECLARE db_cursor2 CURSOR FOR 

	            SELECT SALES_PERSON,REGION,isnull(AMOUNT,0) as [AMOUNT] FROM tblTEMP1 WHERE 1=1";

            if (chkArea.Checked == true && cmbArea.SelectedIndex > 0)
            {
                classHelper.query += " AND AREA_ID = '" + cmbArea.SelectedValue.ToString() + "'";
            }

            if (chkDays.Checked == true && cmbDays.SelectedIndex > 0 && cmbDays.Text.Equals("[0-20]"))
            {
                classHelper.query += " AND [DAYS] BETWEEN '0' AND '20' ";
            }
            else if (chkDays.Checked == true && cmbDays.SelectedIndex > 0 && cmbDays.Text.Equals("[21-30]"))
            {
                classHelper.query += " AND [DAYS] BETWEEN '21' AND '30' ";
            }
            else if (chkDays.Checked == true && cmbDays.SelectedIndex > 0 && cmbDays.Text.Equals("[30 Above]"))
            {
                classHelper.query += " AND [DAYS] > '30' ";
            }

            classHelper.query += @"  ORDER BY [REGION];

	            DECLARE @ASALES_PERSON VARCHAR(50);
	            DECLARE @AREGION VARCHAR(50);
	            DECLARE @ATOTAL FLOAT;
	
	            OPEN db_cursor2;
	            FETCH NEXT FROM db_cursor2 INTO @ASALES_PERSON,@AREGION,@ATOTAL;
		            WHILE @@FETCH_STATUS = 0  
		            BEGIN  
			            IF EXISTS (SELECT SALES_PERSON FROM tblTEMP5 WHERE SALES_PERSON = @ASALES_PERSON)
			            BEGIN
				            IF(@AREGION = 'SINDH')
				            BEGIN
					            UPDATE tblTEMP5 SET [SINDH] = [SINDH]+@ATOTAL WHERE SALES_PERSON = @ASALES_PERSON;
				            END
				            ELSE IF(@AREGION = 'KPK')
				            BEGIN
					            UPDATE tblTEMP5 SET [KPK] = [KPK]+@ATOTAL WHERE SALES_PERSON = @ASALES_PERSON;
				            END
				            ELSE IF(@AREGION = 'BALOCHISTAN')
				            BEGIN
					            UPDATE tblTEMP5 SET [BALOCHISTAN] = [BALOCHISTAN]+@ATOTAL WHERE SALES_PERSON = @ASALES_PERSON;
				            END
				            ELSE IF(@AREGION = 'PUNJAB')
				            BEGIN
					            UPDATE tblTEMP5 SET [PUNJAB] = [PUNJAB]+@ATOTAL WHERE SALES_PERSON = @ASALES_PERSON;
				            END
			            END
		            FETCH NEXT FROM db_cursor2 INTO @ASALES_PERSON,@AREGION,@ATOTAL;
		            END;
	            CLOSE db_cursor2;
	            DEALLOCATE db_cursor2;
                
                SELECT ISNULL(SALES_PERSON,'-') AS [SALES_PERSON],ISNULL(BALOCHISTAN,'0') AS [BALOCHISTAN],
				ISNULL(KPK,'0') AS [KPK],ISNULL(PUNJAB,'0') AS [PUNJAB],ISNULL(SINDH,'0') AS [SINDH] 
				FROM tblTEMP5
                WHERE ISNULL([KPK],'0') + ISNULL([PUNJAB],'0') +ISNULL([SINDH],'0')+ISNULL([BALOCHISTAN],'0') > 0";

            try
            {
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    classHelper.nds.Tables["AgingOverAllSummary"].Clear();
                    while (classHelper.dr.Read())
                    {
                        classHelper.dataR = classHelper.nds.Tables["AgingOverAllSummary"].NewRow();
                        classHelper.dataR["SalesPerson"] = classHelper.dr["SALES_PERSON"].ToString();
                        classHelper.dataR["Balochistan"] = Convert.ToDecimal(classHelper.dr["BALOCHISTAN"].ToString());
                        classHelper.dataR["Kpk"] = Convert.ToDecimal(classHelper.dr["KPK"].ToString());
                        classHelper.dataR["Punjab"] = Convert.ToDecimal(classHelper.dr["PUNJAB"].ToString());
                        classHelper.dataR["Sindh"] = Convert.ToDecimal(classHelper.dr["SINDH"].ToString());
                        classHelper.nds.Tables["AgingOverAllSummary"].Rows.Add(classHelper.dataR);
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
        private void ProvinceSummary()
        {
            classHelper.query = @"IF OBJECT_ID('dbo.tblTEMP3', 'U') IS NOT NULL 
            DROP TABLE dbo.tblTEMP3;

            CREATE TABLE tblTEMP3(
            PROVINCE VARCHAR(100),
            [1-19] FLOAT,
            [20-30] FLOAT,
            [31 above] FLOAT
            )
            INSERT INTO tblTEMP3
            SELECT REGION,0,0,0 FROM tblTEMP1 WHERE 1=1 ";

            if (chkArea.Checked == true && cmbArea.SelectedIndex > 0)
            {
                classHelper.query += " AND AREA_ID = '" + cmbArea.SelectedValue.ToString() + "'";
            }

            if (chkDays.Checked == true && cmbDays.SelectedIndex > 0 && cmbDays.Text.Equals("[0-20]"))
            {
                classHelper.query += " AND [DAYS] BETWEEN '0' AND '20' ";
            }
            else if (chkDays.Checked == true && cmbDays.SelectedIndex > 0 && cmbDays.Text.Equals("[21-30]"))
            {
                classHelper.query += " AND [DAYS] BETWEEN '21' AND '30' ";
            }
            else if (chkDays.Checked == true && cmbDays.SelectedIndex > 0 && cmbDays.Text.Equals("[30 Above]"))
            {
                classHelper.query += " AND [DAYS] > '30' ";
            }

            classHelper.query += @"GROUP BY REGION;

            DECLARE db_cursor2 CURSOR FOR 

	            SELECT REGION,DAYS,AMOUNT FROM tblTEMP1  WHERE 1=1";

            if (chkArea.Checked == true && cmbArea.SelectedIndex > 0)
            {
                classHelper.query += " AND AREA_ID = '" + cmbArea.SelectedValue.ToString() + "'";
            }

            if (chkDays.Checked == true && cmbDays.SelectedIndex > 0 && cmbDays.Text.Equals("[0-20]"))
            {
                classHelper.query += " AND [DAYS] BETWEEN '0' AND '20' ";
            }
            else if (chkDays.Checked == true && cmbDays.SelectedIndex > 0 && cmbDays.Text.Equals("[21-30]"))
            {
                classHelper.query += " AND [DAYS] BETWEEN '21' AND '30' ";
            }
            else if (chkDays.Checked == true && cmbDays.SelectedIndex > 0 && cmbDays.Text.Equals("[30 Above]"))
            {
                classHelper.query += " AND [DAYS] > '30' ";
            }

            classHelper.query += @"  ORDER BY [DAYS];

	            DECLARE @AREGION VARCHAR(50);
	            DECLARE @ADAYS INT;
	            DECLARE @ATOTAL FLOAT;
	
	            OPEN db_cursor2;
	            FETCH NEXT FROM db_cursor2 INTO @AREGION,@ADAYS,@ATOTAL;
		            WHILE @@FETCH_STATUS = 0  
		            BEGIN  
			            IF EXISTS (SELECT PROVINCE FROM tblTEMP3 WHERE PROVINCE = @AREGION)
			            BEGIN
				            IF(@ADAYS < 19)
				            BEGIN
					            PRINT 'SP EX < 19';
					            UPDATE tblTEMP3 SET [1-19] = [1-19]+@ATOTAL WHERE PROVINCE = @AREGION;
				            END
				            ELSE IF(@ADAYS >= 19 AND @ADAYS <= 30)
				            BEGIN
					            PRINT 'SP EX > 19 < 30';
					            UPDATE tblTEMP3 SET [20-30] = [20-30]+@ATOTAL WHERE PROVINCE = @AREGION;
				            END
				            ELSE IF(@ADAYS > 30)
				            BEGIN
					            PRINT 'SP EX > 30';
					            UPDATE tblTEMP3 SET [31 above] = [31 above]+@ATOTAL WHERE PROVINCE = @AREGION;
				            END
			            END
		            FETCH NEXT FROM db_cursor2 INTO @AREGION,@ADAYS,@ATOTAL;
		            END;
	            CLOSE db_cursor2;
	            DEALLOCATE db_cursor2;
 SELECT 
ISNULL(PROVINCE,'-') AS [PROVINCE],
            ISNULL([1-19],0) AS [1-19],
            ISNULL([20-30],0) AS [20-30],
            ISNULL([31 above],0) AS [31 above]
	           FROM tblTEMP3
            WHERE ISNULL([1-19],'0') + ISNULL([20-30],'0') +ISNULL([31 above],'0') > 0";

            try
            {
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    classHelper.nds.Tables["AgingSummary"].Clear();
                    while (classHelper.dr.Read())
                    {
                        classHelper.dataR = classHelper.nds.Tables["AgingSummary"].NewRow();
                        classHelper.dataR["Province"] = classHelper.dr["PROVINCE"].ToString();
                        classHelper.dataR["1-19"] = Convert.ToDecimal(classHelper.dr["1-19"].ToString());
                        classHelper.dataR["20-30"] = Convert.ToDecimal(classHelper.dr["20-30"].ToString());
                        classHelper.dataR["31"] = Convert.ToDecimal(classHelper.dr["31 above"].ToString());
                        classHelper.nds.Tables["AgingSummary"].Rows.Add(classHelper.dataR);
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
        private void SalesPersonSummary() {
            classHelper.query = @"IF OBJECT_ID('dbo.tblTEMP2', 'U') IS NOT NULL 
            DROP TABLE dbo.tblTEMP2;

            CREATE TABLE tblTEMP2(
            SALES_PERSON VARCHAR(100),
            [1-19] FLOAT,
            [20-30] FLOAT,
            [31 above] FLOAT
            )
            INSERT INTO tblTEMP2
            SELECT SALES_PERSON,0,0,0 FROM tblTEMP1 WHERE 1=1 ";

            if (chkArea.Checked == true && cmbArea.SelectedIndex > 0)
            {
                classHelper.query += " AND AREA_ID = '" + cmbArea.SelectedValue.ToString() + "'";
            }

            if (chkDays.Checked == true && cmbDays.SelectedIndex > 0 && cmbDays.Text.Equals("[0-20]"))
            {
                classHelper.query += " AND [DAYS] BETWEEN '0' AND '20' ";
            }
            else if (chkDays.Checked == true && cmbDays.SelectedIndex > 0 && cmbDays.Text.Equals("[21-30]"))
            {
                classHelper.query += " AND [DAYS] BETWEEN '21' AND '30' ";
            }
            else if (chkDays.Checked == true && cmbDays.SelectedIndex > 0 && cmbDays.Text.Equals("[30 Above]"))
            {
                classHelper.query += " AND [DAYS] > '30' ";
            }

            classHelper.query += @"GROUP BY SALES_PERSON;

            DECLARE db_cursor2 CURSOR FOR 

            SELECT SALES_PERSON,DAYS,AMOUNT FROM tblTEMP1 WHERE 1=1";

            if (chkArea.Checked == true && cmbArea.SelectedIndex > 0)
            {
                classHelper.query += " AND AREA_ID = '" + cmbArea.SelectedValue.ToString() + "'";
            }

            if (chkDays.Checked == true && cmbDays.SelectedIndex > 0 && cmbDays.Text.Equals("[0-20]"))
            {
                classHelper.query += " AND [DAYS] BETWEEN '0' AND '20' ";
            }
            else if (chkDays.Checked == true && cmbDays.SelectedIndex > 0 && cmbDays.Text.Equals("[21-30]"))
            {
                classHelper.query += " AND [DAYS] BETWEEN '21' AND '30' ";
            }
            else if (chkDays.Checked == true && cmbDays.SelectedIndex > 0 && cmbDays.Text.Equals("[30 Above]"))
            {
                classHelper.query += " AND [DAYS] > '30' ";
            }

            classHelper.query += @" AND REGION = '" + cmbProvnice.Text+ @"' ORDER BY [DAYS];

            DECLARE @ASALES_PERSON VARCHAR(50);
            DECLARE @ADAYS INT;
            DECLARE @ATOTAL FLOAT;
	
            OPEN db_cursor2;
            FETCH NEXT FROM db_cursor2 INTO @ASALES_PERSON,@ADAYS,@ATOTAL;
	            WHILE @@FETCH_STATUS = 0  
	            BEGIN  
		            IF EXISTS (SELECT SALES_PERSON FROM tblTEMP2 WHERE SALES_PERSON = @ASALES_PERSON)
		            BEGIN
			            IF(@ADAYS <= 19)
			            BEGIN
				            PRINT 'SP EX < 19';
				            UPDATE tblTEMP2 SET [1-19] = [1-19]+@ATOTAL WHERE SALES_PERSON = @ASALES_PERSON;
			            END
			            ELSE IF(@ADAYS > 19 AND @ADAYS <= 30)
			            BEGIN
				            PRINT 'SP EX > 19 <= 30';
				            UPDATE tblTEMP2 SET [20-30] = [20-30]+@ATOTAL WHERE SALES_PERSON = @ASALES_PERSON;
			            END
			            ELSE IF(@ADAYS > 30)
			            BEGIN
				            PRINT 'SP EX > 30';
				            UPDATE tblTEMP2 SET [31 above] = [31 above]+@ATOTAL WHERE SALES_PERSON = @ASALES_PERSON;
			            END
		            END
	            FETCH NEXT FROM db_cursor2 INTO @ASALES_PERSON,@ADAYS,@ATOTAL;
	            END;
            CLOSE db_cursor2;
            DEALLOCATE db_cursor2;
 SELECT 
ISNULL(SALES_PERSON,'-') AS [SALES_PERSON],
            ISNULL([1-19],0) AS [1-19],
            ISNULL([20-30],0) AS [20-30],
            ISNULL([31 above],0) AS [31 above]
	           FROM tblTEMP2
WHERE ISNULL([1-19],'0') + ISNULL([20-30],'0') +ISNULL([31 above],'0') > 0";

            try
            {
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    classHelper.nds.Tables["AgingSummary"].Clear();
                    while (classHelper.dr.Read())
                    {
                        classHelper.dataR = classHelper.nds.Tables["AgingSummary"].NewRow();
                        classHelper.dataR["SalesPerson"] = classHelper.dr["SALES_PERSON"].ToString();
                        classHelper.dataR["1-19"] = Convert.ToDecimal(classHelper.dr["1-19"].ToString());
                        classHelper.dataR["20-30"] = Convert.ToDecimal(classHelper.dr["20-30"].ToString());
                        classHelper.dataR["31"] = Convert.ToDecimal(classHelper.dr["31 above"].ToString());
                        classHelper.nds.Tables["AgingSummary"].Rows.Add(classHelper.dataR);
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

        private void LoadSalesPerson()
        {
            classHelper.query = @"SELECT '0' AS [id],'--SELECT SALES PERSON--' as [name]
            UNION ALL
            SELECT SALES_PER_ID AS [id],NAME AS [name] FROM SALES_PERSONS WHERE SALES_PER_ID <> '1' ORDER BY [name]";
            classHelper.LoadComboData(cmbSalePerson, classHelper.query);
        }
        private void LoadArea()
        {
            classHelper.query = @"SELECT '0' AS [id],'--SELECT AREA--' AS [name]
            union all
            SELECT AREA_ID AS [id],AREA_NAME AS [name]
            FROM AREA 
            order by [name]";
            classHelper.LoadComboData(cmbArea, classHelper.query);
        }

        private void LoadDays()
        {
            cmbDays.Items.Add("--SELECT DAYS--");
            cmbDays.Items.Add("[0-20]");
            cmbDays.Items.Add("[21-30]");
            cmbDays.Items.Add("[30 Above]");
            cmbDays.SelectedIndex = 0;
        }

        private void LoadProvince()
        {
            classHelper.query = @"select 0 as [id],'--SELECT PROVINCE--' as [name] UNION select REGION_ID as [id],REGION_NAME as [name] from REGION ORDER BY NAME";
            classHelper.LoadComboData(cmbProvnice, classHelper.query);
        }

        private void LoadCustomer()
        {
            classHelper.query = @"SELECT '0' AS [id],'--SELECT CUSTOMER--' AS [name]
                UNION
                SELECT COA_ID AS [id],COA_NAME AS [name] FROM COA WHERE CA_ID = '21' AND STAT = 0";
            classHelper.LoadComboData(cmbCustomer, classHelper.query);
        }

        private void ShowReport()
        {
            string heading = "";
            classHelper.query = @"IF OBJECT_ID('dbo.tblTEMP1', 'U') IS NOT NULL 
                                DROP TABLE dbo.tblTEMP1;";
            if (rdbSalesPerson.Checked == true && !cmbSalePerson.SelectedValue.ToString().Equals("0"))
            {
                heading = "SALES PERSON WISE AGING REPORTS";
                classHelper.query += @"--AGING REPORT
                CREATE TABLE tblTEMP1(
                [DATE] DATETIME,
                INVOICE_NO VARCHAR(50),
                COA_NAME VARCHAR(100),
                AMOUNT decimal,
                DAYS INT,
                COA_ID INT,
                SALES_PERSON VARCHAR(100),
                REGION VARCHAR(100),
                DUE_DATE DATETIME,
				LEDGER float,
				CHQINHAND float,
				ONLINE float,
                AREA varchar(100),
                area_id int
                )
                DECLARE @BALANCE FLOAT;
                DECLARE @LAST_ACCOUNT INT;

                DECLARE db_cursor CURSOR FOR 
                    SELECT '" + Classes.Helper.openingDate + @"' AS [DATE],'-' AS [INVOICE_NO],A.COA_NAME,
                    CASE WHEN A.DR_CR = 'C' THEN 
						-A.OPEN_BAL + (SELECT ISNULL(SUM(DEBIT),0) FROM LEDGERS WHERE COA_ID = A.COA_ID AND DEBIT <> 0 AND ENTRY_OF <> 'SALES') 
					ELSE 
						A.OPEN_BAL + (SELECT ISNULL(SUM(DEBIT),0) FROM LEDGERS WHERE COA_ID = A.COA_ID AND DEBIT <> 0 AND ENTRY_OF <> 'SALES')  
					END AS [AMOUNT],
                    DATEDIFF(DAY,'" + Classes.Helper.openingDate + @"',GETDATE()) AS [DAYS],A.COA_ID,
                    ISNULL(C.NAME,'-') AS [NAME],ISNULL(E.REGION_NAME,'-') AS [REGION_NAME],ISNULL(B.CREDIT_DAYS,0) AS [CREDIT_DAYS],
                    F.AREA_NAME,F.AREA_ID
                    FROM COA A
                    LEFT JOIN CUSTOMER_PROFILE B ON B.COA_ID = A.COA_ID
                    LEFT JOIN SALES_PERSONS C ON B.SALE_PER_ID = C.SALES_PER_ID
                    LEFT JOIN CITY D ON B.CITY_ID = D.CITY_ID
                    LEFT JOIN REGION E ON D.REG_ID = E.REGION_ID
                    LEFT JOIN AREA F ON B.AREA_ID = F.AREA_ID
                    WHERE DATEDIFF(DAY,'" + Classes.Helper.openingDate + @"',GETDATE()) > 0 AND A.CA_ID = 21 and A.COA_ID not in (5051) AND C.SALES_PER_ID = '" + cmbSalePerson.SelectedValue.ToString() + @"'
                    UNION ALL
                    SELECT A.DATE,A.INVOICE_NO,D.COA_NAME,(SUM(C.QTY * C.RATE)) AS [AMOUNT],
                    DATEDIFF(DAY,A.DATE,GETDATE()) AS [DAYS],D.COA_ID,
                    ISNULL(G.NAME,'-') AS [NAME],ISNULL(I.REGION_NAME,'-') AS [REGION_NAME],ISNULL(F.CREDIT_DAYS,0) AS [CREDIT_DAYS],
                    J.AREA_NAME,J.AREA_ID
                    FROM SALES A
                    INNER JOIN SALES_PROGRAM_MASTER B ON A.SOP_ID = B.SPM_ID
                    INNER JOIN SALES_PROGRAM_DETAILS C ON B.SPM_ID = C.SPM_ID
                    INNER JOIN COA D ON B.CUSTOMER_ID = D.COA_ID
                    LEFT JOIN CUSTOMER_PROFILE F ON F.COA_ID = D.COA_ID
                    LEFT JOIN SALES_PERSONS G ON F.SALE_PER_ID = G.SALES_PER_ID
                    LEFT JOIN CITY H ON F.CITY_ID = H.CITY_ID
                    LEFT JOIN REGION I ON H.REG_ID = I.REGION_ID
                    LEFT JOIN AREA J ON F.AREA_ID = J.AREA_ID
                    WHERE DATEDIFF(DAY,A.DATE,GETDATE()) > 0  AND G.SALES_PER_ID = '" + cmbSalePerson.SelectedValue.ToString() + @"'
                    GROUP BY A.DATE,A.INVOICE_NO,F.CREDIT_DAYS,D.COA_NAME,D.COA_ID,G.NAME,i.REGION_NAME,J.AREA_NAME,J.AREA_ID
                    UNION ALL
                    SELECT A.DATE,A.INVOICE_NO,D.COA_NAME,(SUM(C.QTY * C.RATE)) AS [AMOUNT],
                    DATEDIFF(DAY,A.DATE,GETDATE()) AS [DAYS],D.COA_ID,
                    ISNULL(G.NAME,'-') AS [NAME],ISNULL(I.REGION_NAME,'-') AS [REGION_NAME],ISNULL(F.CREDIT_DAYS,0) AS [CREDIT_DAYS],
                    J.AREA_NAME,J.AREA_ID
                    FROM SALES A
                    INNER JOIN GATE_PASS B ON A.GPM_ID = B.GPM_ID
					INNER JOIN GATE_PASS_DETAIL C ON B.GPM_ID = C.GP_ID
					INNER JOIN COA D ON A.CUSTOMER_ID = D.COA_ID
                    LEFT JOIN CUSTOMER_PROFILE F ON F.COA_ID = D.COA_ID
                    LEFT JOIN SALES_PERSONS G ON F.SALE_PER_ID = G.SALES_PER_ID
                    LEFT JOIN CITY H ON F.CITY_ID = H.CITY_ID
                    LEFT JOIN REGION I ON H.REG_ID = I.REGION_ID
                    LEFT JOIN AREA J ON F.AREA_ID = J.AREA_ID
                    WHERE DATEDIFF(DAY,A.DATE,GETDATE()) > 0  AND G.SALES_PER_ID = '" + cmbSalePerson.SelectedValue.ToString() + @"'
                    GROUP BY A.DATE,A.INVOICE_NO,F.CREDIT_DAYS,D.COA_NAME,D.COA_ID,G.NAME,i.REGION_NAME,J.AREA_NAME,J.AREA_ID
                    ORDER BY [COA_NAME],[DATE]

	                DECLARE @DATE DATETIME;
	                DECLARE @INVOICE_NO VARCHAR(50);
	                DECLARE @COA_NAME VARCHAR(100);
	                DECLARE @AMOUNT FLOAT;
	                DECLARE @DAYS INT;
	                DECLARE @COA_ID INT;
	                DECLARE @SALES_PERSON VARCHAR(100);
	                DECLARE @REGION VARCHAR(100);
					DECLARE @Ledger float;
					DECLARE @chqinHand float;
					DECLARE @online float;
	DECLARE @C_DAYS INT;
    DECLARE @AREA_NAME VARCHAR(100);
    DECLARE @AREA_ID INT;
	
	                OPEN db_cursor;
	                FETCH NEXT FROM db_cursor INTO @DATE,@INVOICE_NO,@COA_NAME,@AMOUNT,@DAYS,@COA_ID,@SALES_PERSON,@REGION,@C_DAYS,@AREA_NAME,@AREA_ID;
		                WHILE @@FETCH_STATUS = 0  
		                BEGIN  
			                IF(@LAST_ACCOUNT = @COA_ID)
			                BEGIN
                                    SET @chqinHand =  (SELECT ISNULL(SUM(AMOUNT),0) FROM CHQ WHERE REC_AC = @COA_ID AND [STATUS] = 1); 
									SET @online = (SELECT ISNULL(SUM(AMOUNT),0) FROM PAYMENT_TRANSFER WHERE REC_AC = @COA_ID AND STATUS = 0);
									SET @Ledger =  (
										SELECT
											CASE WHEN DR_CR = 'C' THEN 
												-OPEN_BAL + (SELECT ISNULL(SUM(DEBIT),0) - ISNULL(SUM(CREDIT),0) FROM LEDGERS WHERE COA_ID = @COA_ID)
											ELSE 
												OPEN_BAL + (SELECT ISNULL(SUM(DEBIT),0) - ISNULL(SUM(CREDIT),0) FROM LEDGERS WHERE COA_ID = @COA_ID)
											END AS [BALANCE]
											FROM COA
											WHERE COA_ID = @COA_ID
									);
				                IF(@AMOUNT < @BALANCE)
				                BEGIN

					                SET @BALANCE = @BALANCE - @AMOUNT;
				                END
				                ELSE
				                BEGIN
					                INSERT INTO tblTEMP1 VALUES (@DATE,@INVOICE_NO,@COA_NAME,(@AMOUNT - @BALANCE),@DAYS,@COA_ID,@SALES_PERSON,@REGION,DATEADD(DAY,-@DAYS+@C_DAYS,GETDATE()),@Ledger,@chqinHand,@online,@AREA_NAME,@AREA_ID);
					                SET @BALANCE = 0;
				                END
			                END
			                ELSE
			                BEGIN	
				                SET @LAST_ACCOUNT = @COA_ID;
				                SET @BALANCE = 
                                    (SELECT ISNULL(SUM(CREDIT),0) FROM LEDGERS WHERE COA_ID = @COA_ID AND FOLIO IS NOT NULL)+
                                    (SELECT ISNULL(SUM(AMOUNT),0) FROM PAYMENT_TRANSFER WHERE REC_AC = @COA_ID AND STATUS = 0)+
                                    (SELECT ISNULL(SUM(AMOUNT),0) FROM CHQ WHERE REC_AC = @COA_ID AND [STATUS] = 1); 
	                                SET @chqinHand =  (SELECT ISNULL(SUM(AMOUNT),0) FROM CHQ WHERE REC_AC = @COA_ID AND [STATUS] = 1); 
									SET @online = (SELECT ISNULL(SUM(AMOUNT),0) FROM PAYMENT_TRANSFER WHERE REC_AC = @COA_ID AND STATUS = 0);
									SET @Ledger =  (
										SELECT
											CASE WHEN DR_CR = 'C' THEN 
												-OPEN_BAL + (SELECT ISNULL(SUM(DEBIT),0) - ISNULL(SUM(CREDIT),0) FROM LEDGERS WHERE COA_ID = @COA_ID)
											ELSE 
												OPEN_BAL + (SELECT ISNULL(SUM(DEBIT),0) - ISNULL(SUM(CREDIT),0) FROM LEDGERS WHERE COA_ID = @COA_ID)
											END AS [BALANCE]
											FROM COA
											WHERE COA_ID = @COA_ID
									);

					                IF(@AMOUNT < @BALANCE)
					                BEGIN
						                SET @BALANCE = @BALANCE - @AMOUNT;
					                END
					                ELSE
					                BEGIN
						                INSERT INTO tblTEMP1 VALUES (@DATE,@INVOICE_NO,@COA_NAME,(@AMOUNT - @BALANCE),@DAYS,@COA_ID,@SALES_PERSON,@REGION,DATEADD(DAY,-@DAYS+@C_DAYS,GETDATE()),@Ledger,@chqinHand,@online,@AREA_NAME,@AREA_ID);
						                SET @BALANCE = 0;
					                END
			                END
		                FETCH NEXT FROM db_cursor INTO @DATE,@INVOICE_NO,@COA_NAME,@AMOUNT,@DAYS,@COA_ID,@SALES_PERSON,@REGION,@C_DAYS,@AREA_NAME,@AREA_ID;
		                END;
	                CLOSE db_cursor;
	                DEALLOCATE db_cursor;";

                classHelper.query += "SELECT* FROM tblTEMP1 WHERE AMOUNT > 0";

                if (chkArea.Checked == true && cmbArea.SelectedIndex > 0)
                {
                    classHelper.query += " AND AREA_ID = '" + cmbArea.SelectedValue.ToString() + "'";
                }

                if (chkDays.Checked == true && cmbDays.SelectedIndex > 0 && cmbDays.Text.Equals("[0-20]"))
                {
                    classHelper.query += " AND [DAYS] BETWEEN '0' AND '20' ";
                }
                else if (chkDays.Checked == true && cmbDays.SelectedIndex > 0 && cmbDays.Text.Equals("[21-30]"))
                {
                    classHelper.query += " AND [DAYS] BETWEEN '21' AND '30' ";
                }
                else if (chkDays.Checked == true && cmbDays.SelectedIndex > 0 && cmbDays.Text.Equals("[30 Above]"))
                {
                    classHelper.query += " AND [DAYS] > '30' ";
                }

                classHelper.query += " ORDER BY DAYS DESC;";
            }

            else if (!cmbSalePerson.SelectedValue.ToString().Equals("0") && !cmbProvnice.SelectedValue.ToString().Equals("0"))
            {
                heading = "PROVINCE WISE AGING REPORTS";
                classHelper.query += @"--AGING REPORT
                CREATE TABLE tblTEMP1(
                [DATE] DATETIME,
                INVOICE_NO VARCHAR(50),
                COA_NAME VARCHAR(100),
                AMOUNT decimal,
                DAYS INT,
                COA_ID INT,
                SALES_PERSON VARCHAR(100),
                REGION VARCHAR(100),
                DUE_DATE DATETIME,
				LEDGER float,
				CHQINHAND float,
				ONLINE float,
                AREA varchar(100),
                area_id int
                )
                DECLARE @BALANCE FLOAT;
                DECLARE @LAST_ACCOUNT INT;

                DECLARE db_cursor CURSOR FOR 
	SELECT '" + Classes.Helper.openingDate + @"' AS [DATE],'-' AS [INVOICE_NO],A.COA_NAME,
                    CASE WHEN A.DR_CR = 'C' THEN 
						-A.OPEN_BAL + (SELECT ISNULL(SUM(DEBIT),0) FROM LEDGERS WHERE COA_ID = A.COA_ID AND DEBIT <> 0 AND ENTRY_OF <> 'SALES') 
					ELSE 
						A.OPEN_BAL + (SELECT ISNULL(SUM(DEBIT),0) FROM LEDGERS WHERE COA_ID = A.COA_ID AND DEBIT <> 0 AND ENTRY_OF <> 'SALES')  
					END AS [AMOUNT],
                    DATEDIFF(DAY,'" + Classes.Helper.openingDate + @"',GETDATE()) AS [DAYS],A.COA_ID,
                    ISNULL(C.NAME,'-') AS [NAME],ISNULL(E.REGION_NAME,'-') AS [REGION_NAME],ISNULL(B.CREDIT_DAYS,0) AS [CREDIT_DAYS]
                    ,F.AREA_NAME,F.AREA_ID
                    FROM COA A
                    LEFT JOIN CUSTOMER_PROFILE B ON B.COA_ID = A.COA_ID
                    LEFT JOIN SALES_PERSONS C ON B.SALE_PER_ID = C.SALES_PER_ID
                    LEFT JOIN CITY D ON B.CITY_ID = D.CITY_ID
                    LEFT JOIN REGION E ON D.REG_ID = E.REGION_ID
                    LEFT JOIN AREA F ON B.AREA_ID = F.AREA_ID
                    WHERE DATEDIFF(DAY,'" + Classes.Helper.openingDate + @"',GETDATE()) > 0 AND A.CA_ID = 21 and A.COA_ID not in (5051) AND E.REGION_ID = '" + cmbProvnice.SelectedValue.ToString() + @"' AND C.SALES_PER_ID = '" + cmbSalePerson.SelectedValue.ToString() + @"'
                    UNION ALL
                    SELECT A.DATE,A.INVOICE_NO,D.COA_NAME,(SUM(C.QTY * C.RATE)) AS [AMOUNT],
                    DATEDIFF(DAY,A.DATE,GETDATE()) AS [DAYS],D.COA_ID,
                    ISNULL(G.NAME,'-') AS [NAME],ISNULL(I.REGION_NAME,'-') AS [REGION_NAME],ISNULL(F.CREDIT_DAYS,0) AS [CREDIT_DAYS]
                    ,J.AREA_NAME,J.AREA_ID
                    FROM SALES A
                    INNER JOIN SALES_PROGRAM_MASTER B ON A.SOP_ID = B.SPM_ID
                    INNER JOIN SALES_PROGRAM_DETAILS C ON B.SPM_ID = C.SPM_ID
                    INNER JOIN COA D ON B.CUSTOMER_ID = D.COA_ID
                    LEFT JOIN CUSTOMER_PROFILE F ON F.COA_ID = D.COA_ID
                    LEFT JOIN SALES_PERSONS G ON F.SALE_PER_ID = G.SALES_PER_ID
                    LEFT JOIN CITY H ON F.CITY_ID = H.CITY_ID
                    LEFT JOIN REGION I ON H.REG_ID = I.REGION_ID
                    LEFT JOIN AREA J ON F.AREA_ID = J.AREA_ID
                    WHERE DATEDIFF(DAY,A.DATE,GETDATE()) > 0  AND I.REGION_ID = '" + cmbProvnice.SelectedValue.ToString() + @"' AND G.SALES_PER_ID = '" + cmbSalePerson.SelectedValue.ToString() + @"'
                    GROUP BY A.DATE,A.INVOICE_NO,F.CREDIT_DAYS,D.COA_NAME,D.COA_ID,G.NAME,i.REGION_NAME,J.AREA_NAME,J.AREA_ID
                    UNION ALL
                    SELECT A.DATE,A.INVOICE_NO,D.COA_NAME,(SUM(C.QTY * C.RATE)) AS [AMOUNT],
                    DATEDIFF(DAY,A.DATE,GETDATE()) AS [DAYS],D.COA_ID,
                    ISNULL(G.NAME,'-') AS [NAME],ISNULL(I.REGION_NAME,'-') AS [REGION_NAME],ISNULL(F.CREDIT_DAYS,0) AS [CREDIT_DAYS]
                    ,J.AREA_NAME,J.AREA_ID
                    FROM SALES A
                    INNER JOIN GATE_PASS B ON A.GPM_ID = B.GPM_ID
                    INNER JOIN GATE_PASS_DETAIL C ON B.GPM_ID = C.GP_ID
                    INNER JOIN COA D ON A.CUSTOMER_ID = D.COA_ID
                    LEFT JOIN CUSTOMER_PROFILE F ON F.COA_ID = D.COA_ID
                    LEFT JOIN SALES_PERSONS G ON F.SALE_PER_ID = G.SALES_PER_ID
                    LEFT JOIN CITY H ON F.CITY_ID = H.CITY_ID
                    LEFT JOIN REGION I ON H.REG_ID = I.REGION_ID
                    LEFT JOIN AREA J ON F.AREA_ID = J.AREA_ID
                    WHERE DATEDIFF(DAY,A.DATE,GETDATE()) > 0  AND I.REGION_ID = '" + cmbProvnice.SelectedValue.ToString() + @"' AND G.SALES_PER_ID = '" + cmbSalePerson.SelectedValue.ToString() + @"'
                    GROUP BY A.DATE,A.INVOICE_NO,F.CREDIT_DAYS,D.COA_NAME,D.COA_ID,G.NAME,i.REGION_NAME,J.AREA_NAME,J.AREA_ID
                    ORDER BY [COA_NAME],[DATE]

	                DECLARE @DATE DATETIME;
	                DECLARE @INVOICE_NO VARCHAR(50);
	                DECLARE @COA_NAME VARCHAR(100);
	                DECLARE @AMOUNT FLOAT;
	                DECLARE @DAYS INT;
	                DECLARE @COA_ID INT;
	                DECLARE @SALES_PERSON VARCHAR(100);
	                DECLARE @REGION VARCHAR(100);
					DECLARE @Ledger float;
					DECLARE @chqinHand float;
					DECLARE @online float;
	                DECLARE @C_DAYS INT;
                    DECLARE @AREA_NAME VARCHAR(100);
                    DECLARE @AREA_ID INT;
	
	                OPEN db_cursor;
	                FETCH NEXT FROM db_cursor INTO @DATE,@INVOICE_NO,@COA_NAME,@AMOUNT,@DAYS,@COA_ID,@SALES_PERSON,@REGION,@C_DAYS,@AREA_NAME,@AREA_ID;
		                WHILE @@FETCH_STATUS = 0  
		                BEGIN  
			                IF(@LAST_ACCOUNT = @COA_ID)
			                BEGIN
                            SET @chqinHand =  (SELECT ISNULL(SUM(AMOUNT),0) FROM CHQ WHERE REC_AC = @COA_ID AND [STATUS] = 1); 
                            SET @online = (SELECT ISNULL(SUM(AMOUNT),0) FROM PAYMENT_TRANSFER WHERE REC_AC = @COA_ID AND STATUS = 0);
                            SET @Ledger =  (SELECT CASE WHEN DR_CR = 'C' THEN -OPEN_BAL + 
                                    (SELECT ISNULL(SUM(DEBIT),0) - ISNULL(SUM(CREDIT),0) FROM LEDGERS WHERE COA_ID = @COA_ID)
                                    ELSE 
                                    OPEN_BAL + (SELECT ISNULL(SUM(DEBIT),0) - ISNULL(SUM(CREDIT),0) FROM LEDGERS WHERE COA_ID = @COA_ID)
                                    END AS [BALANCE]
                                    FROM COA
                                    WHERE COA_ID = @COA_ID
                                ); 

				                IF(@AMOUNT < @BALANCE)
				                BEGIN

					                SET @BALANCE = @BALANCE - @AMOUNT;
				                END
				                ELSE
				                BEGIN
					                INSERT INTO tblTEMP1 VALUES (@DATE,@INVOICE_NO,@COA_NAME,(@AMOUNT - @BALANCE),@DAYS,@COA_ID,@SALES_PERSON,@REGION,DATEADD(DAY,-@DAYS+@C_DAYS,GETDATE()),@Ledger,@chqinHand,@online,@AREA_NAME,@AREA_ID);
					                SET @BALANCE = 0;
				                END
			                END
			                ELSE
			                BEGIN	
				                SET @LAST_ACCOUNT = @COA_ID;
				                SET @BALANCE = 
                                    (SELECT ISNULL(SUM(CREDIT),0) FROM LEDGERS WHERE COA_ID = @COA_ID AND FOLIO IS NOT NULL)+
                                    (SELECT ISNULL(SUM(AMOUNT),0) FROM PAYMENT_TRANSFER WHERE REC_AC = @COA_ID AND STATUS = 0)+
                                    (SELECT ISNULL(SUM(AMOUNT),0) FROM CHQ WHERE REC_AC = @COA_ID AND [STATUS] = 1); 
                                                                 SET @chqinHand =  (SELECT ISNULL(SUM(AMOUNT),0) FROM CHQ WHERE REC_AC = @COA_ID AND [STATUS] = 1); 
                            SET @online = (SELECT ISNULL(SUM(AMOUNT),0) FROM PAYMENT_TRANSFER WHERE REC_AC = @COA_ID AND STATUS = 0);
                            SET @Ledger =  (SELECT CASE WHEN DR_CR = 'C' THEN -OPEN_BAL + 
                                    (SELECT ISNULL(SUM(DEBIT),0) - ISNULL(SUM(CREDIT),0) FROM LEDGERS WHERE COA_ID = @COA_ID)
                                    ELSE 
                                    OPEN_BAL + (SELECT ISNULL(SUM(DEBIT),0) - ISNULL(SUM(CREDIT),0) FROM LEDGERS WHERE COA_ID = @COA_ID)
                                    END AS [BALANCE]
                                    FROM COA
                                    WHERE COA_ID = @COA_ID
                                ); 

					                IF(@AMOUNT < @BALANCE)
					                BEGIN
	                             
						                SET @BALANCE = @BALANCE - @AMOUNT;
					                END
					                ELSE
					                BEGIN
						                INSERT INTO tblTEMP1 VALUES (@DATE,@INVOICE_NO,@COA_NAME,(@AMOUNT - @BALANCE),@DAYS,@COA_ID,@SALES_PERSON,@REGION,DATEADD(DAY,-@DAYS+@C_DAYS,GETDATE()),@Ledger,@chqinHand,@online,@AREA_NAME,@AREA_ID);
						                SET @BALANCE = 0;
					                END
			                END
		                FETCH NEXT FROM db_cursor INTO @DATE,@INVOICE_NO,@COA_NAME,@AMOUNT,@DAYS,@COA_ID,@SALES_PERSON,@REGION,@C_DAYS,@AREA_NAME,@AREA_ID;
		                END;
	                CLOSE db_cursor;
	                DEALLOCATE db_cursor;";

                classHelper.query += "SELECT* FROM tblTEMP1 WHERE AMOUNT > 0";

                if (chkArea.Checked == true && cmbArea.SelectedIndex > 0)
                {
                    classHelper.query += " AND AREA_ID = '" + cmbArea.SelectedValue.ToString() + "'";
                }

                if (chkDays.Checked == true && cmbDays.SelectedIndex > 0 && cmbDays.Text.Equals("[0-20]"))
                {
                    classHelper.query += " AND [DAYS] BETWEEN '0' AND '20' ";
                }
                else if (chkDays.Checked == true && cmbDays.SelectedIndex > 0 && cmbDays.Text.Equals("[21-30]"))
                {
                    classHelper.query += " AND [DAYS] BETWEEN '21' AND '30' ";
                }
                else if (chkDays.Checked == true && cmbDays.SelectedIndex > 0 && cmbDays.Text.Equals("[30 Above]"))
                {
                    classHelper.query += " AND [DAYS] > '30' ";
                }

                classHelper.query += " ORDER BY DAYS DESC;";
            }
            else if (rdbProvince.Checked == true && !cmbProvnice.SelectedValue.ToString().Equals("0"))
            {
                heading = "PROVINCE WISE AGING REPORTS";
                classHelper.query += @"--AGING REPORT
                CREATE TABLE tblTEMP1(
                [DATE] DATETIME,
                INVOICE_NO VARCHAR(50),
                COA_NAME VARCHAR(100),
                AMOUNT decimal,
                DAYS INT,
                COA_ID INT,
                SALES_PERSON VARCHAR(100),
                REGION VARCHAR(100),
                DUE_DATE DATETIME,
				LEDGER float,
				CHQINHAND float,
				ONLINE float,
AREA varchar(100),
area_id int
                )
                DECLARE @BALANCE FLOAT;
                DECLARE @LAST_ACCOUNT INT;

                DECLARE db_cursor CURSOR FOR 
                    SELECT '" + Classes.Helper.openingDate + @"' AS [DATE],'-' AS [INVOICE_NO],A.COA_NAME,
                    CASE WHEN A.DR_CR = 'C' THEN 
                    -A.OPEN_BAL + (SELECT ISNULL(SUM(DEBIT),0) FROM LEDGERS WHERE COA_ID = A.COA_ID AND DEBIT <> 0 AND ENTRY_OF <> 'SALES') 
                    ELSE 
                    A.OPEN_BAL + (SELECT ISNULL(SUM(DEBIT),0) FROM LEDGERS WHERE COA_ID = A.COA_ID AND DEBIT <> 0 AND ENTRY_OF <> 'SALES')  
                    END AS [AMOUNT],
                    DATEDIFF(DAY,'" + Classes.Helper.openingDate + @"',GETDATE()) AS [DAYS],A.COA_ID,
                    ISNULL(C.NAME,'-') AS [NAME],ISNULL(E.REGION_NAME,'-') AS [REGION_NAME],ISNULL(B.CREDIT_DAYS,0) AS [CREDIT_DAYS]
                    ,F.AREA_NAME,F.AREA_ID
                    FROM COA A
                    LEFT JOIN CUSTOMER_PROFILE B ON B.COA_ID = A.COA_ID
                    LEFT JOIN SALES_PERSONS C ON B.SALE_PER_ID = C.SALES_PER_ID
                    LEFT JOIN CITY D ON B.CITY_ID = D.CITY_ID
                    LEFT JOIN REGION E ON D.REG_ID = E.REGION_ID
                    LEFT JOIN AREA F ON B.AREA_ID = F.AREA_ID
                    WHERE DATEDIFF(DAY,'" + Classes.Helper.openingDate + @"',GETDATE()) > 0 AND A.CA_ID = 21 and A.COA_ID not in (5051) AND E.REGION_ID = '" + cmbProvnice.SelectedValue.ToString() + @"'
                    UNION ALL
                    SELECT A.DATE,A.INVOICE_NO,D.COA_NAME,(SUM(C.QTY * C.RATE)) AS [AMOUNT],
                    DATEDIFF(DAY,A.DATE,GETDATE()) AS [DAYS],D.COA_ID,
                    ISNULL(G.NAME,'-') AS [NAME],ISNULL(I.REGION_NAME,'-') AS [REGION_NAME],ISNULL(F.CREDIT_DAYS,0) AS [CREDIT_DAYS]
                    ,J.AREA_NAME,J.AREA_ID
                    FROM SALES A
                    INNER JOIN SALES_PROGRAM_MASTER B ON A.SOP_ID = B.SPM_ID
                    INNER JOIN SALES_PROGRAM_DETAILS C ON B.SPM_ID = C.SPM_ID
                    INNER JOIN COA D ON B.CUSTOMER_ID = D.COA_ID
                    LEFT JOIN CUSTOMER_PROFILE F ON F.COA_ID = D.COA_ID
                    LEFT JOIN SALES_PERSONS G ON F.SALE_PER_ID = G.SALES_PER_ID
                    LEFT JOIN CITY H ON F.CITY_ID = H.CITY_ID
                    LEFT JOIN REGION I ON H.REG_ID = I.REGION_ID
                    LEFT JOIN AREA J ON F.AREA_ID = J.AREA_ID
                    WHERE DATEDIFF(DAY,A.DATE,GETDATE()) > 0  AND I.REGION_ID = '" + cmbProvnice.SelectedValue.ToString() + @"'
                    GROUP BY A.DATE,A.INVOICE_NO,F.CREDIT_DAYS,D.COA_NAME,D.COA_ID,G.NAME,i.REGION_NAME,J.AREA_NAME,J.AREA_ID
                    UNION ALL
                    SELECT A.DATE,A.INVOICE_NO,D.COA_NAME,(SUM(C.QTY * C.RATE)) AS [AMOUNT],
                    DATEDIFF(DAY,A.DATE,GETDATE()) AS [DAYS],D.COA_ID,
                    ISNULL(G.NAME,'-') AS [NAME],ISNULL(I.REGION_NAME,'-') AS [REGION_NAME],ISNULL(F.CREDIT_DAYS,0) AS [CREDIT_DAYS]
                    ,J.AREA_NAME,J.AREA_ID
                    FROM SALES A
                    INNER JOIN GATE_PASS B ON A.GPM_ID = B.GPM_ID
                    INNER JOIN GATE_PASS_DETAIL C ON B.GPM_ID = C.GP_ID
                    INNER JOIN COA D ON A.CUSTOMER_ID = D.COA_ID
                    LEFT JOIN CUSTOMER_PROFILE F ON F.COA_ID = D.COA_ID
                    LEFT JOIN SALES_PERSONS G ON F.SALE_PER_ID = G.SALES_PER_ID
                    LEFT JOIN CITY H ON F.CITY_ID = H.CITY_ID
                    LEFT JOIN REGION I ON H.REG_ID = I.REGION_ID
                    LEFT JOIN AREA J ON F.AREA_ID = J.AREA_ID
                    WHERE DATEDIFF(DAY,A.DATE,GETDATE()) > 0  AND I.REGION_ID = '" + cmbProvnice.SelectedValue.ToString() + @"'
                    GROUP BY A.DATE,A.INVOICE_NO,F.CREDIT_DAYS,D.COA_NAME,D.COA_ID,G.NAME,i.REGION_NAME,J.AREA_NAME,J.AREA_ID
                    ORDER BY [COA_NAME],[DATE]

	                DECLARE @DATE DATETIME;
	                DECLARE @INVOICE_NO VARCHAR(50);
	                DECLARE @COA_NAME VARCHAR(100);
	                DECLARE @AMOUNT FLOAT;
	                DECLARE @DAYS INT;
	                DECLARE @COA_ID INT;
	                DECLARE @SALES_PERSON VARCHAR(100);
	                DECLARE @REGION VARCHAR(100);
					DECLARE @Ledger float;
					DECLARE @chqinHand float;
					DECLARE @online float;
	DECLARE @C_DAYS INT;
DECLARE @AREA_NAME VARCHAR(100);
DECLARE @AREA_ID INT;
	
	                OPEN db_cursor;
	                FETCH NEXT FROM db_cursor INTO @DATE,@INVOICE_NO,@COA_NAME,@AMOUNT,@DAYS,@COA_ID,@SALES_PERSON,@REGION,@C_DAYS,@AREA_NAME,@AREA_ID;
		                WHILE @@FETCH_STATUS = 0  
		                BEGIN  
			                IF(@LAST_ACCOUNT = @COA_ID)
			                BEGIN
	                            SET @chqinHand =  (SELECT ISNULL(SUM(AMOUNT),0) FROM CHQ WHERE REC_AC = @COA_ID AND [STATUS] = 1); 
                            SET @online = (SELECT ISNULL(SUM(AMOUNT),0) FROM PAYMENT_TRANSFER WHERE REC_AC = @COA_ID AND STATUS = 0);
                            SET @Ledger =  (SELECT CASE WHEN DR_CR = 'C' THEN -OPEN_BAL + 
                                    (SELECT ISNULL(SUM(DEBIT),0) - ISNULL(SUM(CREDIT),0) FROM LEDGERS WHERE COA_ID = @COA_ID)
                                    ELSE 
                                    OPEN_BAL + (SELECT ISNULL(SUM(DEBIT),0) - ISNULL(SUM(CREDIT),0) FROM LEDGERS WHERE COA_ID = @COA_ID)
                                    END AS [BALANCE]
                                    FROM COA
                                    WHERE COA_ID = @COA_ID
                                );  

				                IF(@AMOUNT < @BALANCE)
				                BEGIN
					                SET @BALANCE = @BALANCE - @AMOUNT;
				                END
				                ELSE
				                BEGIN
					                INSERT INTO tblTEMP1 VALUES (@DATE,@INVOICE_NO,@COA_NAME,(@AMOUNT - @BALANCE),@DAYS,@COA_ID,@SALES_PERSON,@REGION,DATEADD(DAY,-@DAYS+@C_DAYS,GETDATE()),@Ledger,@chqinHand,@online,@AREA_NAME,@AREA_ID);
					                SET @BALANCE = 0;
				                END
			                END
			                ELSE
			                BEGIN	
				                SET @LAST_ACCOUNT = @COA_ID;
				                SET @BALANCE = 
                                    (SELECT ISNULL(SUM(CREDIT),0) FROM LEDGERS WHERE COA_ID = @COA_ID AND FOLIO IS NOT NULL)+
                                    (SELECT ISNULL(SUM(AMOUNT),0) FROM PAYMENT_TRANSFER WHERE REC_AC = @COA_ID AND STATUS = 0)+
                                    (SELECT ISNULL(SUM(AMOUNT),0) FROM CHQ WHERE REC_AC = @COA_ID AND [STATUS] = 1); 
	                                SET @chqinHand =  (SELECT ISNULL(SUM(AMOUNT),0) FROM CHQ WHERE REC_AC = @COA_ID AND [STATUS] = 1); 
                            SET @online = (SELECT ISNULL(SUM(AMOUNT),0) FROM PAYMENT_TRANSFER WHERE REC_AC = @COA_ID AND STATUS = 0);
                            SET @Ledger =  (SELECT CASE WHEN DR_CR = 'C' THEN -OPEN_BAL + 
                                    (SELECT ISNULL(SUM(DEBIT),0) - ISNULL(SUM(CREDIT),0) FROM LEDGERS WHERE COA_ID = @COA_ID)
                                    ELSE 
                                    OPEN_BAL + (SELECT ISNULL(SUM(DEBIT),0) - ISNULL(SUM(CREDIT),0) FROM LEDGERS WHERE COA_ID = @COA_ID)
                                    END AS [BALANCE]
                                    FROM COA
                                    WHERE COA_ID = @COA_ID
                                ); 

					                IF(@AMOUNT < @BALANCE)
					                BEGIN
						                SET @BALANCE = @BALANCE - @AMOUNT;
					                END
					                ELSE
					                BEGIN
						                INSERT INTO tblTEMP1 VALUES (@DATE,@INVOICE_NO,@COA_NAME,(@AMOUNT - @BALANCE),@DAYS,@COA_ID,@SALES_PERSON,@REGION,DATEADD(DAY,-@DAYS+@C_DAYS,GETDATE()),@Ledger,@chqinHand,@online,@AREA_NAME,@AREA_ID);
						                SET @BALANCE = 0;
					                END
			                END
		                FETCH NEXT FROM db_cursor INTO @DATE,@INVOICE_NO,@COA_NAME,@AMOUNT,@DAYS,@COA_ID,@SALES_PERSON,@REGION,@C_DAYS,@AREA_NAME,@AREA_ID;
		                END;
	                CLOSE db_cursor;
	                DEALLOCATE db_cursor;";

                classHelper.query += "SELECT* FROM tblTEMP1 WHERE AMOUNT > 0";

                if (chkArea.Checked == true && cmbArea.SelectedIndex > 0)
                {
                    classHelper.query += " AND AREA_ID = '" + cmbArea.SelectedValue.ToString() + "'";
                }

                if (chkDays.Checked == true && cmbDays.SelectedIndex > 0 && cmbDays.Text.Equals("[0-20]"))
                {
                    classHelper.query += " AND [DAYS] BETWEEN '0' AND '20' ";
                }
                else if (chkDays.Checked == true && cmbDays.SelectedIndex > 0 && cmbDays.Text.Equals("[21-30]"))
                {
                    classHelper.query += " AND [DAYS] BETWEEN '21' AND '30' ";
                }
                else if (chkDays.Checked == true && cmbDays.SelectedIndex > 0 && cmbDays.Text.Equals("[30 Above]"))
                {
                    classHelper.query += " AND [DAYS] > '30' ";
                }

                classHelper.query += " ORDER BY DAYS DESC;";
            }
            else if (rdbCustomer.Checked == true && !cmbCustomer.SelectedValue.ToString().Equals("0"))
            {
                heading = "CUSTOMER WISE AGING REPORTS";
                classHelper.query += @"--AGING REPORT
                CREATE TABLE tblTEMP1(
                [DATE] DATETIME,
                INVOICE_NO VARCHAR(50),
                COA_NAME VARCHAR(100),
                AMOUNT decimal,
                DAYS INT,
                COA_ID INT,
                SALES_PERSON VARCHAR(100),
                REGION VARCHAR(100),
                DUE_DATE DATETIME,
				LEDGER float,
				CHQINHAND float,
				ONLINE float,
AREA varchar(100),
area_id int
                )
                DECLARE @BALANCE FLOAT;
                DECLARE @LAST_ACCOUNT INT;

                DECLARE db_cursor CURSOR FOR 
                    SELECT '" + Classes.Helper.openingDate + @"' AS [DATE],'-' AS [INVOICE_NO],A.COA_NAME,
                    CASE WHEN A.DR_CR = 'C' THEN 
                    -A.OPEN_BAL + (SELECT ISNULL(SUM(DEBIT),0) FROM LEDGERS WHERE COA_ID = A.COA_ID AND DEBIT <> 0 AND ENTRY_OF <> 'SALES') 
                    ELSE 
                    A.OPEN_BAL + (SELECT ISNULL(SUM(DEBIT),0) FROM LEDGERS WHERE COA_ID = A.COA_ID AND DEBIT <> 0 AND ENTRY_OF <> 'SALES')  
                    END AS [AMOUNT],
                    DATEDIFF(DAY,'" + Classes.Helper.openingDate + @"',GETDATE()) AS [DAYS],A.COA_ID,
                    ISNULL(C.NAME,'-') AS [NAME],ISNULL(E.REGION_NAME,'-') AS [REGION_NAME],ISNULL(B.CREDIT_DAYS,0) AS [CREDIT_DAYS]
                    ,F.AREA_NAME,F.AREA_ID
                    FROM COA A
                    LEFT JOIN CUSTOMER_PROFILE B ON B.COA_ID = A.COA_ID
                    LEFT JOIN SALES_PERSONS C ON B.SALE_PER_ID = C.SALES_PER_ID
                    LEFT JOIN CITY D ON B.CITY_ID = D.CITY_ID
                    LEFT JOIN REGION E ON D.REG_ID = E.REGION_ID
                    LEFT JOIN AREA F ON B.AREA_ID = F.AREA_ID
                    WHERE DATEDIFF(DAY,'" + Classes.Helper.openingDate + @"',GETDATE()) > 0 AND A.CA_ID = 21 and A.COA_ID not in (5051) AND A.COA_ID = '" + cmbCustomer.SelectedValue.ToString() + @"'
                    UNION ALL
                    SELECT A.DATE,A.INVOICE_NO,D.COA_NAME,(SUM(C.QTY * C.RATE)) AS [AMOUNT],
                    DATEDIFF(DAY,A.DATE,GETDATE()) AS [DAYS],D.COA_ID,
                    ISNULL(G.NAME,'-') AS [NAME],ISNULL(I.REGION_NAME,'-') AS [REGION_NAME],ISNULL(F.CREDIT_DAYS,0) AS [CREDIT_DAYS]
                    ,J.AREA_NAME,J.AREA_ID
                    FROM SALES A
                    INNER JOIN SALES_PROGRAM_MASTER B ON A.SOP_ID = B.SPM_ID
                    INNER JOIN SALES_PROGRAM_DETAILS C ON B.SPM_ID = C.SPM_ID
                    INNER JOIN COA D ON B.CUSTOMER_ID = D.COA_ID
                    LEFT JOIN CUSTOMER_PROFILE F ON F.COA_ID = D.COA_ID
                    LEFT JOIN SALES_PERSONS G ON F.SALE_PER_ID = G.SALES_PER_ID
                    LEFT JOIN CITY H ON F.CITY_ID = H.CITY_ID
                    LEFT JOIN REGION I ON H.REG_ID = I.REGION_ID
                    LEFT JOIN AREA J ON F.AREA_ID = J.AREA_ID
                    WHERE DATEDIFF(DAY,A.DATE,GETDATE()) > 0  AND D.COA_ID = '" + cmbCustomer.SelectedValue.ToString() + @"'
                    GROUP BY A.DATE,A.INVOICE_NO,F.CREDIT_DAYS,D.COA_NAME,D.COA_ID,G.NAME,i.REGION_NAME,J.AREA_NAME,J.AREA_ID
                    UNION ALL
                    SELECT A.DATE,A.INVOICE_NO,D.COA_NAME,(SUM(C.QTY * C.RATE)) AS [AMOUNT],
                    DATEDIFF(DAY,A.DATE,GETDATE()) AS [DAYS],D.COA_ID,
                    ISNULL(G.NAME,'-') AS [NAME],ISNULL(I.REGION_NAME,'-') AS [REGION_NAME],ISNULL(F.CREDIT_DAYS,0) AS [CREDIT_DAYS]
                    ,J.AREA_NAME,J.AREA_ID
                    FROM SALES A
                    INNER JOIN GATE_PASS B ON A.GPM_ID = B.GPM_ID
                    INNER JOIN GATE_PASS_DETAIL C ON B.GPM_ID = C.GP_ID
                    INNER JOIN COA D ON A.CUSTOMER_ID = D.COA_ID
                    LEFT JOIN CUSTOMER_PROFILE F ON F.COA_ID = D.COA_ID
                    LEFT JOIN SALES_PERSONS G ON F.SALE_PER_ID = G.SALES_PER_ID
                    LEFT JOIN CITY H ON F.CITY_ID = H.CITY_ID
                    LEFT JOIN REGION I ON H.REG_ID = I.REGION_ID
                    LEFT JOIN AREA J ON F.AREA_ID = J.AREA_ID
                    WHERE DATEDIFF(DAY,A.DATE,GETDATE()) > 0  AND D.COA_ID = '" + cmbCustomer.SelectedValue.ToString() + @"'
                    GROUP BY A.DATE,A.INVOICE_NO,F.CREDIT_DAYS,D.COA_NAME,D.COA_ID,G.NAME,i.REGION_NAME,J.AREA_NAME,J.AREA_ID
                    ORDER BY [COA_NAME],[DATE]

	                DECLARE @DATE DATETIME;
	                DECLARE @INVOICE_NO VARCHAR(50);
	                DECLARE @COA_NAME VARCHAR(100);
	                DECLARE @AMOUNT FLOAT;
	                DECLARE @DAYS INT;
	                DECLARE @COA_ID INT;
	                DECLARE @SALES_PERSON VARCHAR(100);
	                DECLARE @REGION VARCHAR(100);
					DECLARE @Ledger float;
					DECLARE @chqinHand float;
					DECLARE @online float;
	DECLARE @C_DAYS INT;
DECLARE @AREA_NAME VARCHAR(100);
DECLARE @AREA_ID INT;
	
	                OPEN db_cursor;
	                FETCH NEXT FROM db_cursor INTO @DATE,@INVOICE_NO,@COA_NAME,@AMOUNT,@DAYS,@COA_ID,@SALES_PERSON,@REGION,@C_DAYS,@AREA_NAME,@AREA_ID;
		                WHILE @@FETCH_STATUS = 0  
		                BEGIN  
			                IF(@LAST_ACCOUNT = @COA_ID)
			                BEGIN
	                            SET @chqinHand =  (SELECT ISNULL(SUM(AMOUNT),0) FROM CHQ WHERE REC_AC = @COA_ID AND [STATUS] = 1); 
                            SET @online = (SELECT ISNULL(SUM(AMOUNT),0) FROM PAYMENT_TRANSFER WHERE REC_AC = @COA_ID AND STATUS = 0);
                            SET @Ledger =  (SELECT CASE WHEN DR_CR = 'C' THEN -OPEN_BAL + 
                                    (SELECT ISNULL(SUM(DEBIT),0) - ISNULL(SUM(CREDIT),0) FROM LEDGERS WHERE COA_ID = @COA_ID)
                                    ELSE 
                                    OPEN_BAL + (SELECT ISNULL(SUM(DEBIT),0) - ISNULL(SUM(CREDIT),0) FROM LEDGERS WHERE COA_ID = @COA_ID)
                                    END AS [BALANCE]
                                    FROM COA
                                    WHERE COA_ID = @COA_ID
                                ); 

				                IF(@AMOUNT < @BALANCE)
				                BEGIN
	                                SET @BALANCE = @BALANCE - @AMOUNT;
				                END
				                ELSE
				                BEGIN
					                INSERT INTO tblTEMP1 VALUES (@DATE,@INVOICE_NO,@COA_NAME,(@AMOUNT - @BALANCE),@DAYS,@COA_ID,@SALES_PERSON,@REGION,DATEADD(DAY,-@DAYS+@C_DAYS,GETDATE()),@Ledger,@chqinHand,@online,@AREA_NAME,@AREA_ID);
					                SET @BALANCE = 0;
				                END
			                END
			                ELSE
			                BEGIN	
				                SET @LAST_ACCOUNT = @COA_ID;
				                SET @BALANCE = 
                                    (SELECT ISNULL(SUM(CREDIT),0) FROM LEDGERS WHERE COA_ID = @COA_ID AND FOLIO IS NOT NULL)+
                                    (SELECT ISNULL(SUM(AMOUNT),0) FROM PAYMENT_TRANSFER WHERE REC_AC = @COA_ID AND STATUS = 0)+
                                    (SELECT ISNULL(SUM(AMOUNT),0) FROM CHQ WHERE REC_AC = @COA_ID AND [STATUS] = 1); 
	                                SET @chqinHand =  (SELECT ISNULL(SUM(AMOUNT),0) FROM CHQ WHERE REC_AC = @COA_ID AND [STATUS] = 1); 
                            SET @online = (SELECT ISNULL(SUM(AMOUNT),0) FROM PAYMENT_TRANSFER WHERE REC_AC = @COA_ID AND STATUS = 0);
                            SET @Ledger =  (SELECT CASE WHEN DR_CR = 'C' THEN -OPEN_BAL + 
                                    (SELECT ISNULL(SUM(DEBIT),0) - ISNULL(SUM(CREDIT),0) FROM LEDGERS WHERE COA_ID = @COA_ID)
                                    ELSE 
                                    OPEN_BAL + (SELECT ISNULL(SUM(DEBIT),0) - ISNULL(SUM(CREDIT),0) FROM LEDGERS WHERE COA_ID = @COA_ID)
                                    END AS [BALANCE]
                                    FROM COA
                                    WHERE COA_ID = @COA_ID
                                ); 
					                IF(@AMOUNT < @BALANCE)
					                BEGIN
						                SET @BALANCE = @BALANCE - @AMOUNT;
					                END
					                ELSE
					                BEGIN
						                INSERT INTO tblTEMP1 VALUES (@DATE,@INVOICE_NO,@COA_NAME,(@AMOUNT - @BALANCE),@DAYS,@COA_ID,@SALES_PERSON,@REGION,DATEADD(DAY,-@DAYS+@C_DAYS,GETDATE()),@Ledger,@chqinHand,@online,@AREA_NAME,@AREA_ID);
						                SET @BALANCE = 0;
					                END
			                END
		                FETCH NEXT FROM db_cursor INTO @DATE,@INVOICE_NO,@COA_NAME,@AMOUNT,@DAYS,@COA_ID,@SALES_PERSON,@REGION,@C_DAYS,@AREA_NAME,@AREA_ID;
		                END;
	                CLOSE db_cursor;
	                DEALLOCATE db_cursor;";

                classHelper.query += "SELECT* FROM tblTEMP1 WHERE AMOUNT > 0";

                if (chkArea.Checked == true && cmbArea.SelectedIndex > 0)
                {
                    classHelper.query += " AND AREA_ID = '" + cmbArea.SelectedValue.ToString() + "'";
                }

                if (chkDays.Checked == true && cmbDays.SelectedIndex > 0 && cmbDays.Text.Equals("[0-20]"))
                {
                    classHelper.query += " AND [DAYS] BETWEEN '0' AND '20' ";
                }
                else if (chkDays.Checked == true && cmbDays.SelectedIndex > 0 && cmbDays.Text.Equals("[21-30]"))
                {
                    classHelper.query += " AND [DAYS] BETWEEN '21' AND '30' ";
                }
                else if (chkDays.Checked == true && cmbDays.SelectedIndex > 0 && cmbDays.Text.Equals("[30 Above]"))
                {
                    classHelper.query += " AND [DAYS] > '30' ";
                }

                classHelper.query += " ORDER BY DAYS DESC;";

            }
            else
            {
                heading = "OVERALL AGING REPORTS";
                classHelper.query += @"IF OBJECT_ID('dbo.tblTEMP1', 'U') IS NOT NULL 
DROP TABLE dbo.tblTEMP1;IF OBJECT_ID('dbo.tblTEMP1', 'U') IS NOT NULL 
DROP TABLE dbo.tblTEMP1;--AGING REPORT
CREATE TABLE tblTEMP1(
	[DATE] DATETIME,
	INVOICE_NO VARCHAR(50),
	COA_NAME VARCHAR(100),
	AMOUNT decimal,
	DAYS INT,
	COA_ID INT,
	SALES_PERSON VARCHAR(100),
	REGION VARCHAR(100),
	DUE_DATE DATETIME,
	LEDGER float,
	CHQINHAND float,
	ONLINE float,
	AREA VARCHAR(100),
    area_id int
)

			DECLARE @BALANCE FLOAT;
			DECLARE @LAST_ACCOUNT INT;


                DECLARE db_cursor CURSOR FOR 
					SELECT '" + Classes.Helper.openingDate + @"' AS [DATE],'-' AS [INVOICE_NO],A.COA_NAME,
                    CASE WHEN A.DR_CR = 'C' THEN 
						-A.OPEN_BAL + (SELECT ISNULL(SUM(DEBIT),0) FROM LEDGERS WHERE COA_ID = A.COA_ID AND DEBIT <> 0 AND ENTRY_OF <> 'SALES') 
					ELSE 
						A.OPEN_BAL + (SELECT ISNULL(SUM(DEBIT),0) FROM LEDGERS WHERE COA_ID = A.COA_ID AND DEBIT <> 0 AND ENTRY_OF <> 'SALES')  
					END AS [AMOUNT],
                    DATEDIFF(DAY,'" + Classes.Helper.openingDate + @"',GETDATE()) AS [DAYS],A.COA_ID,
                    ISNULL(C.NAME,'-') AS [NAME],ISNULL(E.REGION_NAME,'-') AS [REGION_NAME],ISNULL(B.CREDIT_DAYS,0) AS [CREDIT_DAYS],
					F.AREA_NAME,F.AREA_ID
                    FROM COA A
                    LEFT JOIN CUSTOMER_PROFILE B ON B.COA_ID = A.COA_ID
                    LEFT JOIN SALES_PERSONS C ON B.SALE_PER_ID = C.SALES_PER_ID
                    LEFT JOIN CITY D ON B.CITY_ID = D.CITY_ID
                    LEFT JOIN REGION E ON D.REG_ID = E.REGION_ID
					LEFT JOIN AREA F ON B.AREA_ID = F.AREA_ID
                    WHERE DATEDIFF(DAY,'" + Classes.Helper.openingDate + @"',GETDATE()) > 0  AND A.CA_ID = 21 and A.COA_ID not in (5051)
                    UNION ALL
	                SELECT A.DATE,A.INVOICE_NO,D.COA_NAME,(SUM(C.QTY * C.RATE)) AS [AMOUNT],
                    DATEDIFF(DAY,A.DATE,GETDATE()) AS [DAYS],D.COA_ID,
                    ISNULL(G.NAME,'-') AS [NAME],ISNULL(I.REGION_NAME,'-') AS [REGION_NAME],ISNULL(F.CREDIT_DAYS,0) AS [CREDIT_DAYS],
                    J.AREA_NAME,J.AREA_ID
                    FROM SALES A
                    INNER JOIN SALES_PROGRAM_MASTER B ON A.SOP_ID = B.SPM_ID
                    INNER JOIN SALES_PROGRAM_DETAILS C ON B.SPM_ID = C.SPM_ID
                    INNER JOIN COA D ON B.CUSTOMER_ID = D.COA_ID
                    LEFT JOIN CUSTOMER_PROFILE F ON F.COA_ID = D.COA_ID
                    LEFT JOIN SALES_PERSONS G ON F.SALE_PER_ID = G.SALES_PER_ID
                    LEFT JOIN CITY H ON F.CITY_ID = H.CITY_ID
                    LEFT JOIN REGION I ON H.REG_ID = I.REGION_ID
                    LEFT JOIN AREA J ON F.AREA_ID = J.AREA_ID
                    WHERE DATEDIFF(DAY,A.DATE,GETDATE()) > 0 
	                GROUP BY A.DATE,A.INVOICE_NO,F.CREDIT_DAYS,D.COA_NAME,D.COA_ID,G.NAME,i.REGION_NAME,J.AREA_NAME,J.AREA_ID
	                UNION ALL
	                SELECT A.DATE,A.INVOICE_NO,D.COA_NAME,(SUM(C.QTY * C.RATE)) AS [AMOUNT],
					DATEDIFF(DAY,A.DATE,GETDATE()) AS [DAYS],D.COA_ID,
					ISNULL(G.NAME,'-') AS [NAME],ISNULL(I.REGION_NAME,'-') AS [REGION_NAME],ISNULL(F.CREDIT_DAYS,0) AS [CREDIT_DAYS],
					J.AREA_NAME,J.AREA_ID
					FROM SALES A
					INNER JOIN GATE_PASS B ON A.GPM_ID = B.GPM_ID
					INNER JOIN GATE_PASS_DETAIL C ON B.GPM_ID = C.GP_ID
					INNER JOIN COA D ON A.CUSTOMER_ID = D.COA_ID
					LEFT JOIN CUSTOMER_PROFILE F ON F.COA_ID = D.COA_ID
					LEFT JOIN SALES_PERSONS G ON F.SALE_PER_ID = G.SALES_PER_ID
					LEFT JOIN CITY H ON F.CITY_ID = H.CITY_ID
					LEFT JOIN REGION I ON H.REG_ID = I.REGION_ID
					LEFT JOIN AREA J ON F.AREA_ID = J.AREA_ID
					WHERE DATEDIFF(DAY,A.DATE,GETDATE()) > 0 
					GROUP BY A.DATE,A.INVOICE_NO,F.CREDIT_DAYS,D.COA_NAME,D.COA_ID,G.NAME,i.REGION_NAME,J.AREA_NAME,J.AREA_ID
					ORDER BY [COA_NAME],[DATE]

	                DECLARE @DATE DATETIME;
	                DECLARE @INVOICE_NO VARCHAR(50);
	                DECLARE @COA_NAME VARCHAR(100);
	                DECLARE @AMOUNT FLOAT;
	                DECLARE @DAYS INT;
	                DECLARE @COA_ID INT;
	                DECLARE @SALES_PERSON VARCHAR(100);
	                DECLARE @REGION VARCHAR(100);
					DECLARE @Ledger float;
					DECLARE @chqinHand float;
					DECLARE @online float;
					DECLARE @C_DAYS INT;
					DECLARE @AREA VARCHAR(100);
                    DECLARE @AREA_ID INT;
	
	                OPEN db_cursor;
	                FETCH NEXT FROM db_cursor INTO @DATE,@INVOICE_NO,@COA_NAME,@AMOUNT,@DAYS,@COA_ID,@SALES_PERSON,@REGION,@C_DAYS,@AREA,@AREA_ID;
		                WHILE @@FETCH_STATUS = 0  
		                BEGIN  
			                IF(@LAST_ACCOUNT = @COA_ID)
			                BEGIN
									SET @chqinHand =  (SELECT ISNULL(SUM(AMOUNT),0) FROM CHQ WHERE REC_AC = @COA_ID AND [STATUS] = 1); 
									SET @online = (SELECT ISNULL(SUM(AMOUNT),0) FROM PAYMENT_TRANSFER WHERE REC_AC = @COA_ID AND STATUS = 0);
									SET @Ledger =  (
										SELECT
											CASE WHEN DR_CR = 'C' THEN 
												-OPEN_BAL + (SELECT ISNULL(SUM(DEBIT),0) - ISNULL(SUM(CREDIT),0) FROM LEDGERS WHERE COA_ID = @COA_ID)
											ELSE 
												OPEN_BAL + (SELECT ISNULL(SUM(DEBIT),0) - ISNULL(SUM(CREDIT),0) FROM LEDGERS WHERE COA_ID = @COA_ID)
											END AS [BALANCE]
											FROM COA
											WHERE COA_ID = @COA_ID
									);

				                IF(@AMOUNT < @BALANCE)
				                BEGIN
					                SET @BALANCE = @BALANCE - @AMOUNT;
				                END
				                ELSE
				                BEGIN
					                INSERT INTO tblTEMP1 VALUES (@DATE,@INVOICE_NO,@COA_NAME,(@AMOUNT - @BALANCE),@DAYS,@COA_ID,@SALES_PERSON,@REGION,DATEADD(DAY,-@DAYS+@C_DAYS,GETDATE()),@Ledger,@chqinHand,@online,@AREA,@AREA_ID);
					                SET @BALANCE = 0;
				                END
			                END
			                ELSE
			                BEGIN	
				                SET @LAST_ACCOUNT = @COA_ID;
				                SET @BALANCE = 
                                    (SELECT ISNULL(SUM(CREDIT),0) FROM LEDGERS WHERE COA_ID = @COA_ID AND FOLIO IS NOT NULL)+
                                    (SELECT ISNULL(SUM(AMOUNT),0) FROM PAYMENT_TRANSFER WHERE REC_AC = @COA_ID AND STATUS = 0)+
                                    (SELECT ISNULL(SUM(AMOUNT),0) FROM CHQ WHERE REC_AC = @COA_ID AND [STATUS] = 1); 

									SET @chqinHand =  (SELECT ISNULL(SUM(AMOUNT),0) FROM CHQ WHERE REC_AC = @COA_ID AND [STATUS] = 1); 
									SET @online = (SELECT ISNULL(SUM(AMOUNT),0) FROM PAYMENT_TRANSFER WHERE REC_AC = @COA_ID AND STATUS = 0);
									SET @Ledger =  (
										SELECT
											CASE WHEN DR_CR = 'C' THEN 
												-OPEN_BAL + (SELECT ISNULL(SUM(DEBIT),0) - ISNULL(SUM(CREDIT),0) FROM LEDGERS WHERE COA_ID = @COA_ID)
											ELSE 
												OPEN_BAL + (SELECT ISNULL(SUM(DEBIT),0) - ISNULL(SUM(CREDIT),0) FROM LEDGERS WHERE COA_ID = @COA_ID)
											END AS [BALANCE]
											FROM COA
											WHERE COA_ID = @COA_ID
									);
									 
					                IF(@AMOUNT < @BALANCE)
					                BEGIN
						                SET @BALANCE = @BALANCE - @AMOUNT;
					                END
					                ELSE
					                BEGIN
						                INSERT INTO tblTEMP1 VALUES (@DATE,@INVOICE_NO,@COA_NAME,(@AMOUNT - @BALANCE),@DAYS,@COA_ID,@SALES_PERSON,@REGION,DATEADD(DAY,-@DAYS+@C_DAYS,GETDATE()),@Ledger,@chqinHand,@online,@AREA,@AREA_ID);
						                SET @BALANCE = 0;
					                END
			                END
		                FETCH NEXT FROM db_cursor INTO @DATE,@INVOICE_NO,@COA_NAME,@AMOUNT,@DAYS,@COA_ID,@SALES_PERSON,@REGION,@C_DAYS,@AREA,@AREA_ID;
		                END;
	                CLOSE db_cursor;
	                DEALLOCATE db_cursor;";

                classHelper.query += "SELECT * FROM tblTEMP1 WHERE AMOUNT > 0";

                if (chkArea.Checked == true && cmbArea.SelectedIndex > 0)
                {
                    classHelper.query += " AND AREA_ID = '" + cmbArea.SelectedValue.ToString() + "'";
                }

                if (chkDays.Checked == true && cmbDays.SelectedIndex > 0 && cmbDays.Text.Equals("[0-20]")) {
                    classHelper.query += " AND [DAYS] BETWEEN '0' AND '20' ";
                }
                else if(chkDays.Checked == true && cmbDays.SelectedIndex > 0 && cmbDays.Text.Equals("[21-30]")) {
                    classHelper.query += " AND [DAYS] BETWEEN '21' AND '30' ";
                }
                else if (chkDays.Checked == true && cmbDays.SelectedIndex > 0 && cmbDays.Text.Equals("[30 Above]"))
                {
                    classHelper.query += " AND [DAYS] > '30' ";
                }

                classHelper.query += " ORDER BY DAYS DESC;";
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
                    classHelper.nds.Tables["AgingReport"].Clear();
                    while (classHelper.dr.Read())
                    {
                        classHelper.dataR = classHelper.nds.Tables["AgingReport"].NewRow();
                        classHelper.dataR["Date"] = Convert.ToDateTime(classHelper.dr["DATE"].ToString());
                        classHelper.dataR["Invoice"] = classHelper.dr["INVOICE_NO"].ToString();
                        classHelper.dataR["AccountName"] = classHelper.dr["COA_NAME"].ToString();
                        classHelper.dataR["Amount"] = Convert.ToDecimal(classHelper.dr["AMOUNT"].ToString());
                        classHelper.dataR["Days"] = classHelper.dr["DAYS"].ToString();
                        classHelper.dataR["CoaId"] = classHelper.dr["COA_ID"].ToString();
                        classHelper.dataR["SalesPerson"] = classHelper.dr["SALES_PERSON"].ToString();
                        classHelper.dataR["Region"] = classHelper.dr["REGION"].ToString();
                        classHelper.dataR["DueDate"] = Convert.ToDateTime(classHelper.dr["DUE_DATE"].ToString());
                      
                        classHelper.dataR["LedgerBalance"] = Convert.ToDouble(classHelper.dr["LEDGER"].ToString());
                        classHelper.dataR["ChqInHand"] = Convert.ToDouble(classHelper.dr["CHQINHAND"].ToString());
                        classHelper.dataR["OnlinePending"] = Convert.ToDouble(classHelper.dr["ONLINE"].ToString());

                        classHelper.dataR["Area"] = classHelper.dr["AREA"].ToString();
                        classHelper.dataR["Heading"] = heading;
                        classHelper.nds.Tables["AgingReport"].Rows.Add(classHelper.dataR);
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
                if (heading.Equals("OVERALL AGING REPORTS"))
                {
                    OverAllSummary();
                    OverAllSubSummary();
                    classHelper.rpt = new frmReports();
                    classHelper.rpt.GenerateReport("AgingReportC", classHelper.nds);
                    classHelper.rpt.ShowDialog();

                    classHelper.rpt = new frmReports();
                    classHelper.rpt.GenerateReport("AgingReportCS", classHelper.nds);
                    classHelper.rpt.ShowDialog();
                }
                else if (rdbSalesPerson.Checked == true)
                {
                    ProvinceSummary();
                    classHelper.rpt = new frmReports();
                    if (rdbConsolidated.Checked == true)
                    {
                        classHelper.rpt.GenerateReport("AgingReportS", classHelper.nds);
                        classHelper.rpt.ShowDialog();
                    }
                    else {
                        classHelper.rpt.GenerateReport("AgingReportC", classHelper.nds);
                        classHelper.rpt.ShowDialog();
                    }
                }
                else if (rdbProvince.Checked == true)
                {
                    SalesPersonSummary();
                    classHelper.rpt = new frmReports();
                    if (rdbConsolidated.Checked == true)
                    {
                        classHelper.rpt.GenerateReport("AgingReportP", classHelper.nds);
                        classHelper.rpt.ShowDialog();
                    }
                    else
                    {
                        classHelper.rpt.GenerateReport("AgingReportC", classHelper.nds);
                        classHelper.rpt.ShowDialog();
                    }
                }
                
                else
                {
                    ProvinceSummary();
                    classHelper.rpt = new frmReports();
                    if (rdbConsolidated.Checked == true)
                    {
                        classHelper.rpt.GenerateReport("AgingReport", classHelper.nds);
                        classHelper.rpt.ShowDialog();
                    }
                    else
                    {
                        classHelper.rpt.GenerateReport("AgingReportC", classHelper.nds);
                        classHelper.rpt.ShowDialog();
                    }
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
            LoadSalesPerson();
            LoadProvince();
            LoadCustomer();
            LoadArea();
            LoadDays();
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
            if (rdbSalesPerson.Checked == true)
            {
                cmbSalePerson.Enabled = true;
            }
            else
            {
                cmbSalePerson.Enabled = false;
            }
        }

        private void rdbProvince_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbProvince.Checked == true)
            {
                cmbProvnice.Enabled = true;
            }
            else
            {
                cmbProvnice.Enabled = false;
            }
        }

        private void rdbCustomer_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCustomer.Checked == true)
            {
                cmbCustomer.Enabled = true;
            }
            else
            {
                cmbCustomer.Enabled = false;
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

        private void chkArea_CheckedChanged(object sender, EventArgs e)
        {
            if (chkArea.Checked == true)
            {
                cmbArea.Enabled = true;
            }
            else {
                cmbArea.Enabled = false;
            }
        }

        private void chkDays_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDays.Checked == true)
            {
                cmbDays.Enabled = true;
            }
            else {
                cmbDays.Enabled = false;
            }
        }
    }
}
