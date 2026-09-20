using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ERP_Maaz_Oil.Forms
{
    public partial class frmGatePass_New : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        string id = ""; string gatePassId = "";string saleInvoiceId = "";
        int is_edit = 0;
        float lastWeight = 0;
        float remainingWeight = 0;
        float orderWeight = 0;

        public frmGatePass_New()
        {
            InitializeComponent();
        }
        private void GenerateGPNumber()
        {
            classHelper.query = "SELECT COUNT(S_ID)+1 FROM SALES";
            lblPRO.Text = "SI-" + classHelper.GetMaxValue(classHelper.query) + "-" + DateTime.Now.Year;
        }
        double unitWeight = 0;
        private void RowSum(DataGridViewCellEventArgs e)
        {
            try
            {
                
                if (grdItems.Rows.Count > 0)
                {
                    if (string.IsNullOrEmpty(grdItems.Rows[e.RowIndex].Cells["qty"].Value as string) || grdItems.Rows[e.RowIndex].Cells["qty"].Value.ToString().Equals("."))
                    {
                        grdItems.Rows[e.RowIndex].Cells["qty"].Value = "0";
                    }
                    if (string.IsNullOrEmpty(grdItems.Rows[e.RowIndex].Cells["rate"].Value as string) || grdItems.Rows[e.RowIndex].Cells["rate"].Value.ToString().Equals("."))
                    {
                        grdItems.Rows[e.RowIndex].Cells["rate"].Value = "0";
                    }
                    if (string.IsNullOrEmpty(grdItems.Rows[e.RowIndex].Cells["millingRate"].Value as string) || grdItems.Rows[e.RowIndex].Cells["millingRate"].Value.ToString().Equals("."))
                    {
                        grdItems.Rows[e.RowIndex].Cells["millingRate"].Value = "0";
                    }
                    if (string.IsNullOrEmpty(grdItems.Rows[e.RowIndex].Cells["packingRate"].Value as string) || grdItems.Rows[e.RowIndex].Cells["packingRate"].Value.ToString().Equals("."))
                    {
                        grdItems.Rows[e.RowIndex].Cells["packingRate"].Value = "0";
                    }
                }

                //if (grdItems.CurrentCell.ColumnIndex.Equals(2) && e.RowIndex != -1)
                //{
                //    if (double.Parse(grdItems.Rows[e.RowIndex].Cells[2].Value.ToString()) > double.Parse(grdItems.Rows[e.RowIndex].Cells[8].Value.ToString()))
                //    {
                //        MessageBox.Show("Input Quantity is greater than Available Quantity", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //        grdItems.Rows[e.RowIndex].Cells[2].Value = 0;

                //    }
                //}
                if (grdItems.CurrentCell.ColumnIndex.Equals(2) && e.RowIndex != -1)
                {
                    grdItems.Rows[e.RowIndex].Cells["total"].Value = (Convert.ToDouble(grdItems.Rows[e.RowIndex].Cells["qty"].Value.ToString()) * Convert.ToDouble(grdItems.Rows[e.RowIndex].Cells["rate"].Value.ToString()));
                }
                else
                {
                    grdItems.Rows[e.RowIndex].Cells["total"].Value = (Convert.ToDouble(grdItems.Rows[e.RowIndex].Cells["qty"].Value.ToString()) * Convert.ToDouble(grdItems.Rows[e.RowIndex].Cells["rate"].Value.ToString()));
                }

                grdItems.Rows[e.RowIndex].Cells["weight"].Value = (Convert.ToDouble(grdItems.Rows[e.RowIndex].Cells["qty"].Value.ToString()) * unitWeight);
                
                TotalSum();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TotalSum()
        {
            if (grdItems.Rows.Count > 0)
            {
                txtQty.Text = grdItems.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToDecimal(t.Cells["qty"].Value)).ToString();

                txtTotalWeight.Text = grdItems.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToDecimal(t.Cells["weight"].Value)).ToString();

                txtTotal.Text = grdItems.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToDecimal(t.Cells["total"].Value)).ToString();
            }
        }

        private void LoadGrid()
        {
            classHelper.query = @"SELECT B.GPM_ID,C.S_ID,A.SPM_ID,D.COA_ID,B.[DATE],A.INVOICE_NO AS [SALE PROGRAM #],B.INVOICE_NO AS [GATE PASS #],C.INVOICE_NO AS [SALE INVOICE #],
            D.COA_NAME AS [CUSTOMER],A.TOTAL_WEIGHT AS [WEIGHT], A.TOTAL AS [AMOUNT],
            B.DESCRIPTION,B.VEHICLE_NO,B.MUAND_RATE AS [MUAND RATE],
            B.SO_TYPE,B.SALES_ORDER_ID,B.GP_TYPE
            FROM SALES_PROGRAM_MASTER A
            INNER JOIN GATE_PASS B ON A.SPM_ID = B.SOP_ID
            INNER JOIN SALES C ON A.SPM_ID = C.SOP_ID
            INNER JOIN COA D ON A.CUSTOMER_ID = D.COA_ID
            WHERE B.GP_TYPE = 'N'
            UNION ALL
            SELECT B.GPM_ID,C.S_ID,B.SALES_ORDER_ID AS SPM_ID,D.COA_ID,B.[DATE],E.INVOICE_NO AS [SALE PROGRAM #],
            B.INVOICE_NO AS [GATE PASS #],C.INVOICE_NO AS [SALE INVOICE #],
            D.COA_NAME AS [CUSTOMER],B.TOTAL_WEIGHT AS [WEIGHT], B.AMOUNT AS [AMOUNT],
            B.DESCRIPTION,B.VEHICLE_NO,B.MUAND_RATE AS [MUAND RATE],
            B.SO_TYPE,B.SALES_ORDER_ID,B.GP_TYPE
            FROM GATE_PASS B
            INNER JOIN SALES C ON B.GPM_ID = C.GPM_ID
            INNER JOIN COA D ON C.CUSTOMER_ID = D.COA_ID
            LEFT JOIN SALES_ORDER_DIRECT E ON B.SALES_ORDER_ID = E.SOD_ID
            WHERE B.GP_TYPE = 'D' AND B.SO_TYPE = 'D'
            UNION ALL
            SELECT B.GPM_ID,C.S_ID,B.SALES_ORDER_ID AS SPM_ID,D.COA_ID,B.[DATE],E.INVOICE_NO AS [SALE PROGRAM #],
            B.INVOICE_NO AS [GATE PASS #],C.INVOICE_NO AS [SALE INVOICE #],
            D.COA_NAME AS [CUSTOMER],B.TOTAL_WEIGHT AS [WEIGHT], B.AMOUNT AS [AMOUNT],
            B.DESCRIPTION,B.VEHICLE_NO,B.MUAND_RATE AS [MUAND RATE],
            B.SO_TYPE,B.SALES_ORDER_ID,B.GP_TYPE
            FROM GATE_PASS B
            INNER JOIN SALES C ON B.GPM_ID = C.GPM_ID
            INNER JOIN COA D ON C.CUSTOMER_ID = D.COA_ID
            LEFT JOIN SALES_ORDER_PRODUCT_MASTER E ON B.SALES_ORDER_ID = E.SOPM_ID
            WHERE B.GP_TYPE = 'D' AND B.SO_TYPE = 'P'
            UNION ALL
            SELECT B.GPM_ID,C.S_ID,B.SALES_ORDER_ID AS SPM_ID,D.COA_ID,B.[DATE],'' AS [SALE PROGRAM #],
            B.INVOICE_NO AS [GATE PASS #],C.INVOICE_NO AS [SALE INVOICE #],
            D.COA_NAME AS [CUSTOMER],B.TOTAL_WEIGHT AS [WEIGHT], B.AMOUNT AS [AMOUNT],
            B.DESCRIPTION,B.VEHICLE_NO,B.MUAND_RATE AS [MUAND RATE],
            B.SO_TYPE,B.SALES_ORDER_ID,B.GP_TYPE
            FROM GATE_PASS B
            INNER JOIN SALES C ON B.GPM_ID = C.GPM_ID
            INNER JOIN COA D ON C.CUSTOMER_ID = D.COA_ID
            WHERE B.GP_TYPE = 'D' AND B.SO_TYPE = '0'
            ORDER BY GPM_ID desc,B.[DATE] DESC";
            classHelper.LoadGrid(grdSEARCH, classHelper.query);
        }


        //load COMBO BOXES
        private void LoadCustomers()
        {
            try
            {
                classHelper.query = @"SELECT '0' AS [id],'--SELECT CUSTOMER--' AS [name]
                UNION
                SELECT COA_ID AS [id],COA_NAME AS [name] FROM COA WHERE STAT = 0";
                classHelper.LoadEasyComboData(cmbCustomer, classHelper.query);
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
            //classHelper.LoadCustomers(cmbCustomer);
        }
        private void LoadVehicles()
        {
            try
            {
                classHelper.query = @"SELECT '' AS [id],'' AS [name]
                UNION
                SELECT VEHICLE_NO AS [id],VEHICLE_NO AS [name] FROM SALES
                GROUP BY VEHICLE_NO
                ORDER BY id";
                classHelper.LoadEasyComboData(txtVehicle, classHelper.query);
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
            //classHelper.LoadCustomers(cmbCustomer);
        }


        private void LoadPrograms(char type)
        {
            classHelper.LoadSO(cmbSO, Convert.ToInt16(cmbCustomer.SelectedValue.ToString()),type);
        }
        private void LoadCustomerDetails()
        {
            classHelper.query = @"SELECT B.NAME AS [SALES PERSON],C.AREA_NAME,a.CREDIT_DAYS
            FROM CUSTOMER_PROFILE A,SALES_PERSONS B,AREA C
            WHERE A.SALE_PER_ID = B.SALES_PER_ID AND A.AREA_ID = C.AREA_ID AND COA_ID = '" + cmbCustomer.SelectedValue.ToString() + "'";
            classHelper.LoadCustomerDetails(classHelper.query, txtSalePerson, txtArea, txtDueDate);
        }
        private void LoadDueDate()
        {
            classHelper.query = @"SELECT B.NAME AS [SALES PERSON],C.AREA_NAME 
            FROM CUSTOMER_PROFILE A,SALES_PERSONS B,AREA C
            WHERE A.SALE_PER_ID = B.SALES_PER_ID AND A.AREA_ID = C.AREA_ID AND COA_ID = '" + cmbCustomer.SelectedValue.ToString() + "'";
            classHelper.LoadDueDate(classHelper.query, txtDueDate);
        }

        //clear fields in form
        private void Clear()
        {
            GenerateGPNumber();
            dtp_DATE.Value = DateTime.Now;
            cmbCustomer.SelectedIndex = 0;
            if (cmbSO.Items.Count > 0)
            {
                cmbSO.SelectedIndex = 0;
            }
            cmbSO.Enabled = false;
            txtArea.Clear();
            txtDescript.Clear();
            txtSalePerson.Clear();
            txtVehicle.SelectedIndex = 0;
            txtDueDate.Clear();
            txtMuandRate.Text = "0";
            txtTotalWeight.Text = "0";
            txtQty.Text = "0";
            txtTotal.Text = "0";
            grdItems.Rows.Clear();
            id = "";
            is_edit = 0;
            lastWeight = 0;
            remainingWeight = 0;
            saleInvoiceId = "";
            gatePassId = "";
            LoadGrid();
            FieldsDisable();
            rdbNormal.Checked = true;
        }

        private bool checkZeroValue()
        {
            bool flag = false;
            foreach (DataGridViewRow row in grdItems.Rows)
            {
                if (Convert.ToString(row.Cells["rate"].Value) == string.Empty)
                    flag = true;
            }
            return flag;
        }
        private void GetSODWeight()
        {
            try
            {
                if (cmbSO.SelectedIndex != 0)
                {
                    string[] soDetails = classHelper.GetSODWeight(Convert.ToInt32(cmbSO.SelectedValue.ToString().TrimEnd('D')));
                    remainingWeight = float.Parse(soDetails[0]);
                    orderWeight = float.Parse(soDetails[1]);
                    txtMuandRate.Text = Math.Round(Convert.ToDecimal(soDetails[2])).ToString();

                }
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
            //return 0;
        }

        private void GetSOPWeight()
        {
            try
            {
                if (cmbSO.SelectedIndex != 0)
                {
                    string[] soDetails = classHelper.GetSOPWeight(Convert.ToInt32(cmbSO.SelectedValue.ToString().TrimEnd('P')));
                    remainingWeight = float.Parse(soDetails[0]);
                    orderWeight = float.Parse(soDetails[1]);
                    txtMuandRate.Text = Math.Round(Convert.ToDecimal(soDetails[2])).ToString();

                }
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
            //return 0;
        }
        private void GetSoWeight() {
            if (cmbSO.SelectedIndex > 0)
            {
                string soId = cmbSO.SelectedValue.ToString();
                if (soId[soId.Length - 1] == 'D')
                {
                    GetSODWeight();
                    txtMuandRate.Text = classHelper.GetSOMuandRate(Convert.ToInt32(cmbSO.SelectedValue.ToString().TrimEnd('D')), 'D');
                }
                else if (soId[soId.Length - 1] == 'P')
                {
                    GetSOPWeight();
                    txtMuandRate.Text = classHelper.GetSOMuandRate(Convert.ToInt32(cmbSO.SelectedValue.ToString().TrimEnd('P')), 'P');
                }
            }
            else
            {
                if (cmbSO.Items.Count > 0)
                {
                    remainingWeight = 0;
                }
            }
        }
        private void SaveNormal()
        {

            if (cmbCustomer.SelectedValue.ToString().Equals("0"))
            {
                MessageBox.Show("Select Customer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbCustomer.Focus();
                return;
            }
            else if (cmbSO.SelectedValue.ToString().Equals("0"))
            {
                MessageBox.Show("Select Program", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbSO.Focus();
                return;
            }
            else
            {
                if (grdItems.Rows.Count > 0)
                {
                    if (checkZeroValue())
                    { MessageBox.Show("Rate of an item is zero."); }
                    else
                    {
                        
                        string dId = saleInvoiceId;
                        //string masterId = saleInvoiceId;
                        //string soIType = "pro";
                        //string soType = "P";
                        //string updateQuery = "UPDATE SALES_PROGRAM_MASTER SET REMAINING_WEIGHT = (REMAINING_WEIGHT+" + txtTotalWeight.Text + ") WHERE SPM_ID = '" + cmbPro.SelectedValue.ToString() + "'";
                        //if (soIType.Substring(0, 2).Equals("so"))
                        //{
                        //    soIType = "so";
                        //    soType = "S";
                        //    updateQuery = "UPDATE SALES_ORDER_PRODUCT_MASTER SET REMAINING_WEIGHT = (REMAINING_WEIGHT+" + txtTotalWeight.Text + ") WHERE SOPM_ID = '" + cmbPro.SelectedValue.ToString() + "'";
                        //}

                        if (saleInvoiceId.Equals(""))
                        {
                            saleInvoiceId = "(SELECT MAX(S_ID) FROM SALES)";
                            //masterId = saleInvoiceId;
                        }

                        //string productDetailQuery = "";

                        //foreach (DataGridViewRow rows in grdItems.Rows)
                        //{
                        //    if (rows.Cells["itemType"].Value.ToString().Equals("P"))
                        //    {
                        //        productDetailQuery += @"INSERT INTO PRODUCT_ITEM_LEDGER
                        //        (DATE, PRODUCT_ID, REF_NO, ENTRY_FROM, STOCK_IN, STOCK_OUT, COST_AMT, SALE_AMT, L_ID, CREATED_BY, CREATION_DATE, COMPANY_ID)
                        //        VALUES('" + dtp_DATE.Value.ToString() + "', '" + rows.Cells["itemId"].Value.ToString() + "', " + masterId + ", 'SALES', 0, '" + rows.Cells["qty"].Value.ToString() + @"',
                        //        '0','" + rows.Cells["rate"].Value.ToString() + "', 1, '" + Classes.Helper.userId + @"', GETDATE(), 1); ";
                        //    }
                        //    else {

                        //    }
                        //}

                        string programDetailQuery = "";
                        foreach (DataGridViewRow rows in grdItems.Rows)
                        {
                            programDetailQuery += @"INSERT INTO SALES_PROGRAM_DETAILS (SPM_ID,PRODUCT_ID,QTY,RATE,ITEM_TYPE,[WEIGHT],MILLING_RATE,PACKING_RATE) VALUES 
                        (" + cmbSO.SelectedValue.ToString() + ",'" + rows.Cells["itemId"].Value.ToString() + "'," + rows.Cells["qty"].Value.ToString() + @",
                         '" + rows.Cells["rate"].Value.ToString() + "','" + rows.Cells["itemType"].Value.ToString() + "','" + rows.Cells["weight"].Value.ToString() + @"',
                        '" + rows.Cells["millingRate"].Value.ToString() + "','" + rows.Cells["packingRate"].Value.ToString() + @"');";
                        }

                        classHelper.query = @"BEGIN TRY 
                             BEGIN TRANSACTION ";
                    classHelper.query += @"IF EXISTS (select GPM_ID from GATE_PASS WHERE GPM_ID ='" + gatePassId + @"') 
                    BEGIN
                    UPDATE GATE_PASS SET [DATE] = '" + dtp_DATE.Value.ToString() + "',SOP_ID = '" + cmbSO.SelectedValue.ToString() + @"',
                    [DESCRIPTION] = '" + classHelper.AvoidInjection(txtDescript.Text) + @"',
                    VEHICLE_NO = '" + classHelper.AvoidInjection(txtVehicle.Text) + @"',
                    MUAND_RATE = '"+classHelper.AvoidInjection(txtMuandRate.Text)+@"',MODIFICATION_DATE = GETDATE(),
                    MODIFICATION_ID = '" + Classes.Helper.userId + @"',
                    SALES_ORDER_ID = (SELECT SOD_ID FROM SALES_PROGRAM_MASTER WHERE SPM_ID = '" + cmbSO.SelectedValue.ToString() + @"'),
                    SO_TYPE = (SELECT SO_TYPE FROM SALES_PROGRAM_MASTER WHERE SPM_ID = '" + cmbSO.SelectedValue.ToString() + @"')
                    WHERE GPM_ID = '" + gatePassId + @"';
                    END
                    ELSE
                    BEGIN
                    INSERT INTO GATE_PASS
                    (DATE,SOP_ID,INVOICE_NO,DESCRIPTION,VEHICLE_NO,CREATED_BY,CREATION_DATE,MUAND_RATE,SALES_ORDER_ID,SO_TYPE,GP_TYPE)
                    VALUES('" + dtp_DATE.Value.ToString() + "','" + cmbSO.SelectedValue.ToString() + @"',
                    (SELECT 'SI-'+CONVERT(VARCHAR(MAX),(COUNT(S_ID)+1))+'-'+CONVERT(VARCHAR(MAX),YEAR(getdate())) FROM SALES),'" + classHelper.AvoidInjection(txtDescript.Text) + "','" + classHelper.AvoidInjection(txtVehicle.Text) + "','" + Classes.Helper.userId + @"',GETDATE(),'"+classHelper.AvoidInjection(txtMuandRate.Text)+ @"',
                    (SELECT SOD_ID FROM SALES_PROGRAM_MASTER WHERE SPM_ID = '" + cmbSO.SelectedValue.ToString() + @"'),
                    (SELECT SO_TYPE FROM SALES_PROGRAM_MASTER WHERE SPM_ID = '" + cmbSO.SelectedValue.ToString() + @"'),'N')
                    END ";

                    classHelper.query += @"IF EXISTS (select S_ID from SALES WHERE S_ID ='" + dId + @"') 
                    BEGIN
                    UPDATE SALES SET [DATE] = '" + dtp_DATE.Value.ToString() + "',SOP_ID = '" + cmbSO.SelectedValue.ToString() + @"',
                    [DESCRIPTION] = '" + classHelper.AvoidInjection(txtDescript.Text) + @"',
                    VEHICLE_NO = '" + classHelper.AvoidInjection(txtVehicle.Text) + @"',
                    MUAND_RATE = '"+classHelper.AvoidInjection(txtMuandRate.Text)+"',MODIFICATION_DATE = GETDATE(),MODIFICATION_ID = '" + Classes.Helper.userId + @"' WHERE S_ID = '" + dId + @"';
                    END
                    ELSE
                    BEGIN
                    INSERT INTO SALES 
                    (DATE,SOP_ID,INVOICE_NO,DESCRIPTION,VEHICLE_NO,REMAINING_AMOUNT,CREATED_BY,CREATION_DATE,MUAND_RATE)
                    VALUES('" + dtp_DATE.Value.ToString() + "','" + cmbSO.SelectedValue.ToString() + @"',
                    (SELECT 'SI-'+CONVERT(VARCHAR(MAX),(COUNT(S_ID)+1))+'-'+CONVERT(VARCHAR(MAX),YEAR(getdate())) FROM SALES),'" + classHelper.AvoidInjection(txtDescript.Text) + "','" + classHelper.AvoidInjection(txtVehicle.Text) + "',0,'" + Classes.Helper.userId + @"',GETDATE(),'"+classHelper.AvoidInjection(txtMuandRate.Text)+@"')
                    END; ";

                        classHelper.query += @"DELETE FROM PRODUCT_ITEM_LEDGER WHERE REF_NO = '" + dId + @"' AND ENTRY_FROM = 'SALES';";
                        classHelper.query += @"DELETE FROM MATERIAL_ITEM_LEDGER WHERE REF_NO = '" + dId + @"' AND ENTRY_FROM = 'SALES';";
                        //" + detailQuery + @";

                        classHelper.query += @"DELETE FROM LEDGERS WHERE REF_ID = '" + dId + @"' AND ENTRY_OF = 'SALES'; 
                    INSERT INTO LEDGERS(DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
                    VALUES('" + dtp_DATE.Value.ToString() + "', '" + cmbCustomer.SelectedValue.ToString() + "', " + saleInvoiceId + ", 'SALES', '" + lblPRO.Text + @"',
                    '" + txtTotal.Text + "', 0, '" + classHelper.AvoidInjection(txtDescript.Text) + "', '" + Classes.Helper.userId + @"', GETDATE(), 1);
                    INSERT INTO LEDGERS(DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
                    VALUES('" + dtp_DATE.Value.ToString() + "', '" + Classes.Helper.salesId + "', " + saleInvoiceId + ", 'SALES', '" + lblPRO.Text + @"', 0,
                    '" + txtTotal.Text + "', '" + classHelper.AvoidInjection(txtDescript.Text) + "', '" + Classes.Helper.userId + @"', GETDATE(), 1);";

                        classHelper.query += @"DELETE FROM SALES_PROGRAM_DETAILS WHERE SPM_ID = '" + cmbSO.SelectedValue.ToString() + @"'; 
                    " + programDetailQuery + @";";

                        classHelper.query += @" COMMIT TRANSACTION 
                        END TRY 
                    BEGIN CATCH 
                            IF @@TRANCOUNT > 0 
                            ROLLBACK TRANSACTION 
                    END CATCH";
                        if (classHelper.InsertUpdateDelete(classHelper.query) >= 1)
                        {
                            classHelper.GatePassSP(Convert.ToInt32(cmbSO.SelectedValue.ToString()));
                            classHelper.ShowMessageBox("Record Saved Sucessfully.", "Information");
                            DialogResult dialogResult = MessageBox.Show("Print Gate Pass & Sales Invoice?", "Print Gate Pass & Invoice", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                GatePassReport();
                                SaleInvoiceReport();
                            }
                            Clear();
                            LoadGrid();
                        }
                    }
                }
            }
        }

        private void SaveDirect()
        {

            if (cmbCustomer.SelectedValue.ToString().Equals("0"))
            {
                MessageBox.Show("Select Customer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbCustomer.Focus();
                return;
            }
            else if (chkSO.Checked == true && cmbSO.SelectedValue.ToString().Equals("0"))
            {
                MessageBox.Show("Select Sales Order", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbSO.Focus();
                return;
            }

            else
            {
                string dId = saleInvoiceId;
                //string masterId = saleInvoiceId;
                //string soIType = "pro";
                //string soType = "P";
                //string updateQuery = "UPDATE SALES_PROGRAM_MASTER SET REMAINING_WEIGHT = (REMAINING_WEIGHT+" + txtTotalWeight.Text + ") WHERE SPM_ID = '" + cmbPro.SelectedValue.ToString() + "'";
                //if (soIType.Substring(0, 2).Equals("so"))
                //{
                //    soIType = "so";
                //    soType = "S";
                //    updateQuery = "UPDATE SALES_ORDER_PRODUCT_MASTER SET REMAINING_WEIGHT = (REMAINING_WEIGHT+" + txtTotalWeight.Text + ") WHERE SOPM_ID = '" + cmbPro.SelectedValue.ToString() + "'";
                //}

                if (saleInvoiceId.Equals(""))
                {
                    saleInvoiceId = "(SELECT MAX(S_ID) FROM SALES)";
                    //masterId = saleInvoiceId;
                }
                //else {
                //    saleInvoiceId = "''";
                //}

                if (dId.Equals(""))
                {
                    dId = "''";
                }

                //string productDetailQuery = "";

                //foreach (DataGridViewRow rows in grdItems.Rows)
                //{
                //    if (rows.Cells["itemType"].Value.ToString().Equals("P"))
                //    {
                //        productDetailQuery += @"INSERT INTO PRODUCT_ITEM_LEDGER
                //        (DATE, PRODUCT_ID, REF_NO, ENTRY_FROM, STOCK_IN, STOCK_OUT, COST_AMT, SALE_AMT, L_ID, CREATED_BY, CREATION_DATE, COMPANY_ID)
                //        VALUES('" + dtp_DATE.Value.ToString() + "', '" + rows.Cells["itemId"].Value.ToString() + "', " + masterId + ", 'SALES', 0, '" + rows.Cells["qty"].Value.ToString() + @"',
                //        '0','" + rows.Cells["rate"].Value.ToString() + "', 1, '" + Classes.Helper.userId + @"', GETDATE(), 1); ";
                //    }
                //    else {

                //    }
                //}

                classHelper.query = @" BEGIN TRY 
                             BEGIN TRANSACTION ";

                string soId = "0";
                char soType = '0';
                double totalWeight = double.Parse(txtTotalWeight.Text.Substring(0, txtTotalWeight.Text.Length - 4));
                if (chkSO.Checked == true) {
                    soId = cmbSO.SelectedValue.ToString();
                    
                    if (soId[soId.Length - 1] == 'D')
                    {
                        soType = 'D';
                        soId = soId.TrimEnd('D');
                    }
                    else if (soId[soId.Length - 1] == 'P')
                    {
                        soType = 'P';
                        soId = soId.TrimEnd('P');
                    }

                    

                    if (!id.Equals(""))
                    {
                        remainingWeight = (float.Parse(txtTotalWeight.Text) - lastWeight) - remainingWeight;
                        if (soType == 'D')
                        {
                            classHelper.query += @"UPDATE SALES_ORDER_DIRECT SET REMAINING_WEIGHT = '" + remainingWeight + @"' 
                                WHERE SOD_ID = '" + cmbSO.SelectedValue.ToString().TrimEnd(soType) + "';";
                        }
                        else if (soType == 'P')
                        {
                            classHelper.query += @"UPDATE SALES_ORDER_PRODUCT_MASTER SET REMAINING_WEIGHT = " + (orderWeight - totalWeight) + @" 
                            WHERE SOPM_ID = '" + cmbSO.SelectedValue.ToString().TrimEnd(soType) + "';";
                        }
                        else
                        {
                            classHelper.query += "UPDATE SO_MATERIAL_P_MASTER SET REMAINING_WEIGHT = '" + remainingWeight + @"' 
                            WHERE MPM_ID = '" + cmbSO.SelectedValue.ToString().TrimEnd(soType) + "';";
                        }

                    }
                    else
                    {
                        if (soType == 'D')
                        {
                            classHelper.query += "UPDATE SALES_ORDER_DIRECT SET REMAINING_WEIGHT = '" + remainingWeight + @"' 
                            WHERE SOD_ID = '" + cmbSO.SelectedValue.ToString().TrimEnd(soType) + "';";
                        }
                        else if (soType == 'P')
                        {
                            classHelper.query += "UPDATE SALES_ORDER_PRODUCT_MASTER SET REMAINING_WEIGHT = " + (orderWeight - totalWeight) + @" 
                            WHERE SOPM_ID = '" + cmbSO.SelectedValue.ToString().TrimEnd(soType) + "';";
                        }
                        else
                        {
                            classHelper.query += "UPDATE SO_MATERIAL_P_MASTER SET REMAINING_WEIGHT = '" + remainingWeight + @"' 
                            WHERE MPM_ID = '" + cmbSO.SelectedValue.ToString().TrimEnd(soType) + "';";
                        }
                    }
                }
                

                
                
                classHelper.query += @"IF EXISTS (select GPM_ID from GATE_PASS WHERE GPM_ID ='" + gatePassId + @"') 
                    BEGIN
                    UPDATE GATE_PASS SET [DATE] = '" + dtp_DATE.Value.ToString() + "',SALES_ORDER_ID = '" + soId + @"',
                    [DESCRIPTION] = '" + classHelper.AvoidInjection(txtDescript.Text) + @"',
                    VEHICLE_NO = '" + classHelper.AvoidInjection(txtVehicle.Text) + @"',
                    MUAND_RATE = '" + classHelper.AvoidInjection(txtMuandRate.Text) + @"',MODIFICATION_DATE = GETDATE(),
                    MODIFICATION_ID = '" + Classes.Helper.userId + @"',SO_TYPE = '" + soType + @"',
                    TOTAL_WEIGHT = '"+ totalWeight + @"',
                    AMOUNT = '" + classHelper.AvoidInjection(txtTotal.Text) + @"'
                    WHERE GPM_ID = '" + gatePassId + @"';
                    END
                    ELSE
                    BEGIN
                    INSERT INTO GATE_PASS
                    (DATE,INVOICE_NO,DESCRIPTION,VEHICLE_NO,CREATED_BY,CREATION_DATE,MUAND_RATE,SALES_ORDER_ID,SO_TYPE,GP_TYPE,TOTAL_WEIGHT,AMOUNT)
                    VALUES('" + dtp_DATE.Value.ToString() + @"',
                    (SELECT 'SI-'+CONVERT(VARCHAR(MAX),(COUNT(S_ID)+1))+'-'+CONVERT(VARCHAR(MAX),YEAR(getdate())) FROM SALES),
                    '" + classHelper.AvoidInjection(txtDescript.Text) + "','" + classHelper.AvoidInjection(txtVehicle.Text) + @"',
                    '" + Classes.Helper.userId + @"',GETDATE(),'" + classHelper.AvoidInjection(txtMuandRate.Text) + @"',
                    '" + soId + @"','" + soType + @"','D','" + totalWeight + @"',
                    '" + classHelper.AvoidInjection(txtTotal.Text) + @"');
                    END ";
                char isExisits = 'Y';
                classHelper.query += @"DELETE FROM GATE_PASS_DETAIL WHERE GP_ID ='" + gatePassId + @"';";
                if (gatePassId.Equals(""))
                {
                    gatePassId = "(SELECT ISNULL(MAX(GPM_ID),1) FROM GATE_PASS)";
                    isExisits = 'N';
                }

                foreach (DataGridViewRow rows in grdItems.Rows)
                {
                    classHelper.query += @"INSERT INTO GATE_PASS_DETAIL (GP_ID,PRODUCT_ID,QTY,RATE,ITEM_TYPE,[WEIGHT],MILLING_RATE,PACKING_RATE) VALUES 
                        (" + gatePassId + ",'" + rows.Cells["itemId"].Value.ToString() + "'," + rows.Cells["qty"].Value.ToString() + @",
                         '" + rows.Cells["rate"].Value.ToString() + "','" + rows.Cells["itemType"].Value.ToString() + "','" + rows.Cells["weight"].Value.ToString() + @"',
                        '" + rows.Cells["millingRate"].Value.ToString() + "','" + rows.Cells["packingRate"].Value.ToString() + @"');";
                }

                classHelper.query += @"IF EXISTS (select S_ID from SALES WHERE S_ID =" + dId + @") 
                    BEGIN
                    UPDATE SALES SET [DATE] = '" + dtp_DATE.Value.ToString() + @"',
                    [DESCRIPTION] = '" + classHelper.AvoidInjection(txtDescript.Text) + @"',
                    VEHICLE_NO = '" + classHelper.AvoidInjection(txtVehicle.Text) + @"',
                    MUAND_RATE = '" + classHelper.AvoidInjection(txtMuandRate.Text) + @"',MODIFICATION_DATE = GETDATE(),
                    MODIFICATION_ID = '" + Classes.Helper.userId + @"',GPM_ID = "+gatePassId+",CUSTOMER_ID = '"+cmbCustomer.SelectedValue.ToString()+@"'
                    WHERE S_ID = " + dId + @";
                    END
                    ELSE
                    BEGIN
                    INSERT INTO SALES 
                    (DATE,INVOICE_NO,DESCRIPTION,VEHICLE_NO,REMAINING_AMOUNT,CREATED_BY,CREATION_DATE,MUAND_RATE,GPM_ID,CUSTOMER_ID)
                    VALUES('" + dtp_DATE.Value.ToString() + @"',
                    (SELECT 'SI-'+CONVERT(VARCHAR(MAX),(COUNT(S_ID)+1))+'-'+CONVERT(VARCHAR(MAX),YEAR(getdate())) FROM SALES),
                    '" + classHelper.AvoidInjection(txtDescript.Text) + "','" + classHelper.AvoidInjection(txtVehicle.Text) + @"',0,
                    '" + Classes.Helper.userId + @"',GETDATE(),'" + classHelper.AvoidInjection(txtMuandRate.Text) + @"',
                    " + gatePassId + ",'" + cmbCustomer.SelectedValue.ToString() + @"');
                    END;";
                    
                classHelper.query += @"DELETE FROM PRODUCT_ITEM_LEDGER WHERE REF_NO = " + dId + @" AND ENTRY_FROM = 'SALES';";
                classHelper.query += @"DELETE FROM MATERIAL_ITEM_LEDGER WHERE REF_NO = " + dId + @" AND ENTRY_FROM = 'SALES';";
                //" + detailQuery + @";

                classHelper.query += @"DELETE FROM LEDGERS WHERE REF_ID = " + dId + @" AND ENTRY_OF = 'SALES'; 
                    INSERT INTO LEDGERS(DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
                    VALUES('" + dtp_DATE.Value.ToString() + "', '" + cmbCustomer.SelectedValue.ToString() + "', " + saleInvoiceId + ", 'SALES', '" + lblPRO.Text + @"',
                    '" + txtTotal.Text + "', 0, '" + classHelper.AvoidInjection(txtDescript.Text) + "', '" + Classes.Helper.userId + @"', GETDATE(), 1);
                    INSERT INTO LEDGERS(DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
                    VALUES('" + dtp_DATE.Value.ToString() + "', '" + Classes.Helper.salesId + "', " + saleInvoiceId + ", 'SALES', '" + lblPRO.Text + @"', 0,
                    '" + txtTotal.Text + "', '" + classHelper.AvoidInjection(txtDescript.Text) + "', '" + Classes.Helper.userId + @"', GETDATE(), 1);";

                

                classHelper.query += @" COMMIT TRANSACTION 
                        END TRY 
                    BEGIN CATCH 
                            IF @@TRANCOUNT > 0 
                            ROLLBACK TRANSACTION 
                    END CATCH";

                if (isExisits == 'N') {
                    gatePassId = "";
                }
                if (classHelper.InsertUpdateDelete(classHelper.query) >= 1)
                {
                    if (chkSO.Checked == true) {
                        classHelper.GatePassSP(Convert.ToInt32(soId));
                    }
                    classHelper.ShowMessageBox("Record Saved Sucessfully.", "Information");
                    DialogResult dialogResult = MessageBox.Show("Print Gate Pass & Sales Invoice?", "Print Gate Pass & Invoice", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        GatePassReport();
                        SaleInvoiceReport();
                    }
                    Clear();
                    LoadGrid();
                }
            }
        }
        //load item COMBO BOXES
        private void LoadProducts()
        {
            try
            {
                classHelper.query = @"SELECT '0' AS [id],'--SELECT PRODUCT--' AS [name]
                UNION ALL
                SELECT PM_ID AS [id],PRODUCT_NAME AS [name] 
                FROM PRODUCT_MASTER";
                classHelper.LoadEasyComboData(cmbItem, classHelper.query);
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
            //classHelper.LoadProducts(cmbItem);
        }
        private void frm_AddGroupAccounts_Load(object sender, EventArgs e)
        {
            GenerateGPNumber();
            LoadGrid();
            LoadCustomers();
            LoadProducts();
            LoadVehicles();
        }
        private void btnSAVE_Click(object sender, EventArgs e)
        {
            if (rdbNormal.Checked == true)
            {
                SaveNormal();
            }
            else if (rdbDirect.Checked == true)
            {
                {
                    SaveDirect();
                }
            }
        }
        private void btnCLEAR_Click(object sender, EventArgs e)
        {
            Clear();
        }
        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCustomer.SelectedIndex != 0)
            {
                chkSO.Checked = false;
                cmbSO.SelectedIndex = 0;
                //grdItems.Rows.Clear();
                //if (is_edit == 1)
                //{
                //    LoadPrograms('a');
                //}
                //else
                //{
                //    LoadPrograms('s');
                //}
                //LoadCustomerDetails();
                //cmbPro.Enabled = true;
            }
            else
            {
                if (cmbCustomer.Items.Count > 0)
                {
                    cmbCustomer.SelectedIndex = 0;
                }
            }
        }
        private void cmbSO_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbNormal.Checked == true)
                {
                    if (cmbSO.SelectedIndex > 0)
                    {
                        char type = 'P';
                        //if (cmbPro.Text.Substring(0, 2).Equals("SO"))
                        //{
                        //    type = 'S';
                        //}
                        txtMuandRate.Text = classHelper.GetProgramMuandRate(Convert.ToInt32(cmbSO.SelectedValue.ToString()));
                        grdItems.Rows.Clear();
                        classHelper.LoadSOProducts(type, Convert.ToInt32(cmbSO.SelectedValue.ToString()), grdItems, txtDueDate, dtp_DATE.Value.Date);
                        if (grdItems.Rows.Count > 0) { TotalSum(); }

                    }
                    //else
                    //{
                    //    if (cmbSO.Items.Count > 0)
                    //    {
                    //        cmbSO.SelectedIndex = 0;
                    //    }
                    //}
                }
                else if (rdbDirect.Checked == true)
                {
                    if (cmbSO.SelectedIndex != 0)
                    {
                        GetSoWeight();
                        FieldsEnable();
                        txtMuandRate.Enabled = false;
                    }
                    //else
                    //{
                    //    if (cmbSO.Items.Count > 0)
                    //    {
                    //        cmbSO.SelectedIndex = 0;
                    //    }
                    //}
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message.ToString());
            }
            
        }

        private void grdItems_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var txtEdit = (TextBox)e.Control;
            txtEdit.KeyPress += EditKeyPress;
        }

        private void EditKeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || e.KeyChar == '.' || char.IsSeparator(e.KeyChar) || e.KeyChar == (char)Keys.Space || e.KeyChar == ' ' || Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void grdItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                unitWeight =
                        double.Parse(grdItems.Rows[e.RowIndex].Cells["weight"].Value.ToString()) /
                        double.Parse(grdItems.Rows[e.RowIndex].Cells["qty"].Value.ToString());
                RowSum(e);
                unitWeight = 0;
            }
        }
        private void SaleInvoiceReport()
        {
            if (rdbNormal.Checked == true)
            {
                classHelper.query = @"IF EXISTS (
                    select
                    a.INVOICE_NO, a.DATE, d.COA_NAME as [customer], a.VEHICLE_NO, f.NAME, DATEADD(day, isnull(e.CREDIT_DAYS, 0), a.date) as [due],
                    g.PRODUCT_NAME, c.QTY, c.RATE, (c.QTY * c.RATE) as [total], a.DESCRIPTION, c.WEIGHT, a.MUAND_RATE
                    from SALES a
                    inner
                    join SALES_PROGRAM_MASTER b on a.SOP_ID = b.SPM_ID
                    inner
                    join SALES_PROGRAM_DETAILS c on b.SPM_ID = c.SPM_ID
                    inner
                    join PRODUCT_MASTER g on c.PRODUCT_ID = g.PM_ID
                    inner
                    join COA d on b.CUSTOMER_ID = d.COA_ID
                    left
                    join CUSTOMER_PROFILE e on d.COA_ID = e.COA_ID
                    left
                    join SALES_PERSONS f on e.SALE_PER_ID = f.SALES_PER_ID
                    where a.SOP_ID = '" + cmbSO.SelectedValue.ToString() + @"'
                    )
                    BEGIN
                    select
                    a.INVOICE_NO,a.DATE,d.COA_NAME as [customer],a.VEHICLE_NO,f.NAME,DATEADD(day, isnull(e.CREDIT_DAYS, 0), a.date) as [due],
                    g.PRODUCT_NAME,c.QTY,c.RATE,(c.QTY * c.RATE) as [total],a.DESCRIPTION,c.WEIGHT,a.MUAND_RATE
                    from SALES a
                    inner join SALES_PROGRAM_MASTER b on a.SOP_ID = b.SPM_ID
                    inner join SALES_PROGRAM_DETAILS c on b.SPM_ID = c.SPM_ID
                    inner join PRODUCT_MASTER g on c.PRODUCT_ID = g.PM_ID
                    inner join COA d on b.CUSTOMER_ID = d.COA_ID
                    left join CUSTOMER_PROFILE e on d.COA_ID = e.COA_ID
                    left join SALES_PERSONS f on e.SALE_PER_ID = f.SALES_PER_ID
                    where a.SOP_ID = '" + cmbSO.SelectedValue.ToString() + @"'
                    union all
                    select
                    a.INVOICE_NO,a.DATE,d.COA_NAME as [customer],a.VEHICLE_NO,f.NAME,DATEADD(day, isnull(e.CREDIT_DAYS, 0), a.date) as [due],
                    g.MATERIAL_NAME AS PRODUCT_NAME,c.QTY,c.RATE,(c.QTY * c.RATE) as [total],a.DESCRIPTION,c.WEIGHT,a.MUAND_RATE
                    from SALES a
                    inner join SALES_PROGRAM_MASTER b on a.SOP_ID = b.SPM_ID
                    inner join SALES_PROGRAM_DETAILS c on b.SPM_ID = c.SPM_ID
                    inner join MATERIALS g on c.PRODUCT_ID = g.MATERIAL_ID
                    inner join COA d on b.CUSTOMER_ID = d.COA_ID
                    left join CUSTOMER_PROFILE e on d.COA_ID = e.COA_ID
                    left join SALES_PERSONS f on e.SALE_PER_ID = f.SALES_PER_ID
                    where a.SOP_ID = '" + cmbSO.SelectedValue.ToString() + @"'
                    END";
            }
            else {
                if (gatePassId.Equals(""))
                {
                    classHelper.query = @"select
	                a.INVOICE_NO, a.DATE, d.COA_NAME as [customer], a.VEHICLE_NO, f.NAME, DATEADD(day, isnull(e.CREDIT_DAYS, 0), a.date) as [due],
	                g.PRODUCT_NAME, c.QTY, c.RATE, (c.QTY * c.RATE) as [total], a.DESCRIPTION, c.WEIGHT, a.MUAND_RATE
	                from SALES a
	                inner
	                join GATE_PASS b on a.GPM_ID = b.GPM_ID
	                inner
	                join GATE_PASS_DETAIL C on B.GPM_ID = C.GP_ID
	                inner
	                join PRODUCT_MASTER g on c.PRODUCT_ID = g.PM_ID
	                inner
	                join COA d on A.CUSTOMER_ID = d.COA_ID
	                left
	                join CUSTOMER_PROFILE e on d.COA_ID = e.COA_ID
	                left
	                join SALES_PERSONS f on e.SALE_PER_ID = f.SALES_PER_ID
	                where C.ITEM_TYPE = 'P' AND A.GPM_ID = (SELECT MAX(GPM_ID) FROM GATE_PASS)
	                UNION ALL
	                select
	                a.INVOICE_NO, a.DATE, d.COA_NAME as [customer], a.VEHICLE_NO, f.NAME, DATEADD(day, isnull(e.CREDIT_DAYS, 0), a.date) as [due],
	                g.MATERIAL_NAME as PRODUCT_NAME, c.QTY, c.RATE, (c.QTY * c.RATE) as [total], a.DESCRIPTION, c.WEIGHT, a.MUAND_RATE
	                from SALES a
	                inner
	                join GATE_PASS b on a.GPM_ID = b.GPM_ID
	                inner
	                join GATE_PASS_DETAIL C on B.GPM_ID = C.GP_ID
	                inner
	                join MATERIALS g on c.PRODUCT_ID = g.MATERIAL_ID 
	                inner
	                join COA d on A.CUSTOMER_ID = d.COA_ID
	                left
	                join CUSTOMER_PROFILE e on d.COA_ID = e.COA_ID
	                left
	                join SALES_PERSONS f on e.SALE_PER_ID = f.SALES_PER_ID
	                where C.ITEM_TYPE = 'R' AND A.GPM_ID = (SELECT MAX(GPM_ID) FROM GATE_PASS)";
                }
                else {
                    classHelper.query = @"select
	                a.INVOICE_NO, a.DATE, d.COA_NAME as [customer], a.VEHICLE_NO, f.NAME, DATEADD(day, isnull(e.CREDIT_DAYS, 0), a.date) as [due],
	                g.PRODUCT_NAME, c.QTY, c.RATE, (c.QTY * c.RATE) as [total], a.DESCRIPTION, c.WEIGHT, a.MUAND_RATE
	                from SALES a
	                inner
	                join GATE_PASS b on a.GPM_ID = b.GPM_ID
	                inner
	                join GATE_PASS_DETAIL C on B.GPM_ID = C.GP_ID
	                inner
	                join PRODUCT_MASTER g on c.PRODUCT_ID = g.PM_ID
	                inner
	                join COA d on A.CUSTOMER_ID = d.COA_ID
	                left
	                join CUSTOMER_PROFILE e on d.COA_ID = e.COA_ID
	                left
	                join SALES_PERSONS f on e.SALE_PER_ID = f.SALES_PER_ID
	                where C.ITEM_TYPE = 'P' AND A.GPM_ID = '"+gatePassId+ @"'
	                UNION ALL
	                select
	                a.INVOICE_NO, a.DATE, d.COA_NAME as [customer], a.VEHICLE_NO, f.NAME, DATEADD(day, isnull(e.CREDIT_DAYS, 0), a.date) as [due],
	                g.MATERIAL_NAME as PRODUCT_NAME, c.QTY, c.RATE, (c.QTY * c.RATE) as [total], a.DESCRIPTION, c.WEIGHT, a.MUAND_RATE
	                from SALES a
	                inner
	                join GATE_PASS b on a.GPM_ID = b.GPM_ID
	                inner
	                join GATE_PASS_DETAIL C on B.GPM_ID = C.GP_ID
	                inner
	                join MATERIALS g on c.PRODUCT_ID = g.MATERIAL_ID 
	                inner
	                join COA d on A.CUSTOMER_ID = d.COA_ID
	                left
	                join CUSTOMER_PROFILE e on d.COA_ID = e.COA_ID
	                left
	                join SALES_PERSONS f on e.SALE_PER_ID = f.SALES_PER_ID
	                where C.ITEM_TYPE = 'R' AND A.GPM_ID = '" + gatePassId + @"'";
                }
            }

            //ELSE
            //BEGIN
            //select
            //a.INVOICE_NO,a.DATE,d.COA_NAME as [customer],a.VEHICLE_NO,f.NAME,DATEADD(day, isnull(e.CREDIT_DAYS, 0), a.date) as [due],
            //g.MATERIAL_NAME AS PRODUCT_NAME,c.QTY,c.RATE,(c.QTY * c.RATE) as [total],a.DESCRIPTION,c.WEIGHT,a.MUAND_RATE
            //from SALES a
            //inner join SALES_PROGRAM_MASTER b on a.SOP_ID = b.SPM_ID
            //inner join SALES_PROGRAM_DETAILS c on b.SPM_ID = c.SPM_ID
            //inner join MATERIALS g on c.PRODUCT_ID = g.MATERIAL_ID
            //inner join COA d on b.CUSTOMER_ID = d.COA_ID
            //left join CUSTOMER_PROFILE e on d.COA_ID = e.COA_ID
            //left join SALES_PERSONS f on e.SALE_PER_ID = f.SALES_PER_ID
            //where a.SOP_ID = '" + cmbPro.SelectedValue.ToString() + @"'
            //END

            //classHelper.query = @"select a.INVOICE_NO,a.DATE,d.COA_NAME as [customer],a.VEHICLE_NO,f.NAME,DATEADD(day,isnull(e.CREDIT_DAYS,0),a.date) as [due],
            //g.PRODUCT_NAME,c.QTY,c.RATE,(c.QTY * c.RATE) as [total],a.DESCRIPTION,c.WEIGHT,a.MUAND_RATE
            //from SALES a
            //inner join SALES_PROGRAM_MASTER b on a.SOP_ID = b.SPM_ID
            //inner join SALES_PROGRAM_DETAILS c on b.SPM_ID = c.SPM_ID
            //inner join PRODUCT_MASTER g on c.PRODUCT_ID = g.PM_ID
            //inner join COA d on b.CUSTOMER_ID = d.COA_ID
            //left join CUSTOMER_PROFILE e on d.COA_ID = e.COA_ID
            //left join SALES_PERSONS f on e.SALE_PER_ID = f.SALES_PER_ID
            //where a.SOP_ID = '" + cmbPro.SelectedValue.ToString() + @"'";

            try
            {
                Classes.Helper.conn.Open();
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    classHelper.mds.Tables["SaleInvoice"].Clear();
                    while (classHelper.dr.Read())
                    {
                        
                        classHelper.dataR = classHelper.mds.Tables["SaleInvoice"].NewRow();
                        classHelper.dataR["InvoiceNo"] = classHelper.dr["INVOICE_NO"].ToString();
                        classHelper.dataR["date"] = Convert.ToDateTime(classHelper.dr["DATE"].ToString());
                        classHelper.dataR["customer"] = classHelper.dr["customer"].ToString();
                        classHelper.dataR["vehicleNo"] = classHelper.dr["VEHICLE_NO"].ToString();
                        classHelper.dataR["itemName"] = classHelper.dr["PRODUCT_NAME"].ToString();
                        classHelper.dataR["qty"] = Convert.ToDouble(classHelper.dr["QTY"].ToString());
                        classHelper.dataR["rate"] = Convert.ToDouble(classHelper.dr["RATE"].ToString());
                        classHelper.dataR["amount"] = Convert.ToDouble(classHelper.dr["total"].ToString());
                        classHelper.dataR["salePerson"] = classHelper.dr["NAME"].ToString();
                        classHelper.dataR["dueDate"] = Convert.ToDateTime(classHelper.dr["due"].ToString());
                        classHelper.dataR["description"] = classHelper.dr["DESCRIPTION"].ToString();
                        classHelper.dataR["muandRate"] = classHelper.dr["MUAND_RATE"].ToString();
                        classHelper.dataR["totalWeight"] = Convert.ToDouble(classHelper.dr["WEIGHT"].ToString());

                        classHelper.mds.Tables["SaleInvoice"].Rows.Add(classHelper.dataR);
                    }
                }

                classHelper.rpt = new ERP_Maaz_Oil.Forms.Reporting.frmReports();
                classHelper.rpt.GenerateReport("SaleInvoice", classHelper.mds);
                classHelper.rpt.ShowDialog();
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

        private void GatePassReport()
        {
            try {
                    classHelper.mds.Tables["GatePass"].Clear();
                    foreach (DataGridViewRow row in grdItems.Rows)
                    {
                        classHelper.dataR = classHelper.mds.Tables["GatePass"].NewRow();
                        classHelper.dataR["InvoiceNo"] = lblPRO.Text;
                        classHelper.dataR["date"] = dtp_DATE.Value.ToShortDateString();
                        classHelper.dataR["customer"] = cmbCustomer.Text;
                        classHelper.dataR["vehicleNo"] = txtVehicle.Text;

                        classHelper.dataR["itemName"] = row.Cells["itemName"].Value.ToString();
                        classHelper.dataR["qty"] = Convert.ToDouble(row.Cells["qty"].Value.ToString());
                        classHelper.dataR["rate"] = Convert.ToDouble(row.Cells["rate"].Value.ToString());
                        classHelper.dataR["amount"] = Convert.ToDouble(row.Cells["total"].Value.ToString());
                        classHelper.dataR["muandRate"] = txtMuandRate.Text;
                        classHelper.dataR["totalWeight"] = Convert.ToDouble(grdItems.Rows.Cast<DataGridViewRow>()
                                                            .Sum(t => Convert.ToDecimal(t.Cells["weight"].Value)).ToString());

                        //Convert.ToDouble(txtTotalWeight.Text.Substring(txtTotalWeight.Text.Length - 4));

                        classHelper.mds.Tables["GatePass"].Rows.Add(classHelper.dataR);
                    }

                    classHelper.rpt = new ERP_Maaz_Oil.Forms.Reporting.frmReports();
                    classHelper.rpt.GenerateReport("GatePass", classHelper.mds);
                    classHelper.rpt.ShowDialog();
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
        private void grdSEARCH_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            grdSEARCH.Columns["GPM_ID"].Visible = false;
            grdSEARCH.Columns["S_ID"].Visible = false;
            grdSEARCH.Columns["SPM_ID"].Visible = false;
            grdSEARCH.Columns["COA_ID"].Visible = false;
            grdSEARCH.Columns["SO_TYPE"].Visible = false;
            grdSEARCH.Columns["SALES_ORDER_ID"].Visible = false;
            grdSEARCH.Columns["GP_TYPE"].Visible = false;
        }

        private void txtSEARCH_TextChanged(object sender, EventArgs e)
        {
            classHelper.GatePass_Search(txtSEARCH, grdSEARCH);
        }

        //get data from grid on click
        private void load_data_fromGrid(DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.grdSEARCH.Rows[e.RowIndex];
            if (e.RowIndex >= 0)
            {
                if (row.Cells["GP_TYPE"].Value.ToString().Equals("N"))
                {
                    grdItems.Rows.Clear();
                    id = row.Cells["SPM_ID"].Value.ToString();
                    gatePassId = row.Cells["GPM_ID"].Value.ToString();
                    saleInvoiceId = row.Cells["S_ID"].Value.ToString();
                    is_edit = 1;
                    dtp_DATE.Text = row.Cells["DATE"].Value.ToString();
                    lblPRO.Text = row.Cells["GATE PASS #"].Value.ToString();
                    cmbCustomer.SelectedValue = row.Cells["COA_ID"].Value.ToString();
                    rdbNormal.Checked = true;
                    chkSO.Checked = true;
                    cmbSO.SelectedValue = row.Cells["SPM_ID"].Value.ToString();
                    txtDescript.Text = row.Cells["DESCRIPTION"].Value.ToString();
                    txtVehicle.Text = row.Cells["VEHICLE_NO"].Value.ToString();
                }
                else {
                    grdItems.Rows.Clear();
                    id = row.Cells["SPM_ID"].Value.ToString();
                    gatePassId = row.Cells["GPM_ID"].Value.ToString();
                    saleInvoiceId = row.Cells["S_ID"].Value.ToString();
                    LoadSO("0");
                    is_edit = 1;
                    dtp_DATE.Text = row.Cells["DATE"].Value.ToString();
                    lblPRO.Text = row.Cells["GATE PASS #"].Value.ToString();
                    cmbCustomer.SelectedValue = row.Cells["COA_ID"].Value.ToString();
                    rdbDirect.Checked = true;
                    if (!row.Cells["SALES_ORDER_ID"].Value.ToString().Equals("0")) {
                        chkSO.Checked = true;
                        cmbSO.SelectedValue = row.Cells["SALES_ORDER_ID"].Value.ToString();
                    }
                    txtDescript.Text = row.Cells["DESCRIPTION"].Value.ToString();
                    txtVehicle.Text = row.Cells["VEHICLE_NO"].Value.ToString();
                    FieldsEnable();
                    classHelper.LoadGPProducts(Convert.ToInt32(row.Cells["GPM_ID"].Value.ToString()), 
                            grdItems, txtDueDate, dtp_DATE.Value.Date);
                }
                ItemsTotalSum();
                WeightSum();
            }
        }

        private void grdSEARCH_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void grdSEARCH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            load_data_fromGrid(e);
        }

        private void btnSalesInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                if (classHelper.record_search_grid(grdSEARCH, lblPRO.Text, 6) == 1)
                { SaleInvoiceReport(); }
                else
                {
                    MessageBox.Show("Invoice not found in record or save the invoice first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void btnGatePass_Click(object sender, EventArgs e)
        {
            try
            {
                if (classHelper.record_search_grid(grdSEARCH, lblPRO.Text, 6) == 1)
                { GatePassReport();  }
                else
                {
                    MessageBox.Show("Invoice not found in record or save the invoice first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }
        private void LoadRaw()
        {
            classHelper.LoadMaterial(1, cmbItem);
        }

        private void rdbRaw_CheckedChanged(object sender, EventArgs e)
        {
            LoadRaw();
        }

        private void FieldsDisable() {
            rdbProduct.Enabled = false;
            rdbRaw.Enabled = false;
            cmbItem.Enabled = false;
            btnAddProduct.Enabled = false;
            txtQuantity.Enabled = false;
            txtRate.Enabled = false;
            btnAdd.Enabled = false;
            chkSO.Checked = false;
            txtMuandRate.Enabled = false;
            cmbSO.SelectedIndex = 0;
        }
        private void FieldsEnable()
        {
            rdbProduct.Enabled = true;
            rdbRaw.Enabled = true;
            cmbItem.Enabled = true;
            btnAddProduct.Enabled = true;
            txtQuantity.Enabled = true;
            txtRate.Enabled = true;
            btnAdd.Enabled = true;
            txtMuandRate.Enabled = true;
            //chkSO.Checked = false;
            //cmbSO.SelectedIndex = 0;
        }

        private void btnADD_CITY_Click(object sender, EventArgs e)
        {
            using (classHelper.frmProducts = new frmFinishedProducts())
            {
                if (classHelper.frmProducts.ShowDialog() == System.Windows.Forms.DialogResult.Cancel || classHelper.frmAddCity.ShowDialog() == System.Windows.Forms.DialogResult.Abort)
                {
                    classHelper.LoadProducts(cmbItem);
                }
            }
        }

        private void rdbNormal_CheckedChanged(object sender, EventArgs e)
        {
            FieldsDisable();
        }

        private void rdbDirect_CheckedChanged(object sender, EventArgs e)
        {
            FieldsEnable();
        }

        private void chkSO_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbNormal.Checked == true)
            {
                if (chkSO.Checked == true)
                {
                    if (cmbCustomer.SelectedIndex != 0)
                    {
                        grdItems.Rows.Clear();
                        if (is_edit == 1)
                        {
                            LoadPrograms('a');
                        }
                        else
                        {
                            LoadPrograms('s');
                        }
                        LoadCustomerDetails();
                        cmbSO.Enabled = true;
                    }
                    else
                    {
                        if (cmbCustomer.Items.Count > 0)
                        {
                            cmbCustomer.SelectedIndex = 0;
                        }
                    }
                }
                else {
                    cmbSO.Enabled = false;
                }
            }
            else if(rdbDirect.Checked == true) {
                if (chkSO.Checked == true)
                {
                    txtMuandRate.Enabled = false;
                    if (cmbCustomer.SelectedIndex != 0)
                    {
                        grdItems.Rows.Clear();
                        if (is_edit == 1)
                        {
                            //Need Code
                        }
                        else
                        {
                            LoadSO("0");
                        }
                        LoadCustomerDetails();
                        cmbSO.Enabled = true;
                    }
                    else
                    {
                        if (cmbCustomer.Items.Count > 0)
                        {
                            cmbCustomer.SelectedIndex = 0;
                        }
                    }
                }
                else
                {
                    cmbSO.Enabled = false;
                    txtMuandRate.Clear();
                    txtMuandRate.Enabled = true;
                }
            }
            
        }

        private void LoadSO(string soId)
        {
            if (soId.Equals("0"))
            {
                classHelper.LoadSOOrder(cmbSO, cmbCustomer.SelectedValue.ToString());
            }
            else
            {
                classHelper.LoadSOOrder(cmbSO, Convert.ToInt32(cmbCustomer.SelectedValue.ToString()), soId);
                cmbSO.SelectedValue = soId;
            }
        }

        private void WeightSum()
        {
            try {
                txtOlienWeight.Text = grdItems.Rows.Cast<DataGridViewRow>()
                    .Where(r => Convert.ToDecimal(r.Cells["materialId"].Value) == 5003)
                    .Sum(t => Convert.ToDecimal(t.Cells["weight"].Value)).ToString() + " KGS";
                //grdItems.Rows.Cast<DataGridViewRow>()
                //    .Where(x => (x.Cells["MaterialID"].Value.ToString()).Equals("5003"))
                //    .Sum(x => Convert.ToDecimal(x.Cells["weight"].Value)).ToString();

                txtCanolaWeight.Text = grdItems.Rows.Cast<DataGridViewRow>()
                        .Where(r => Convert.ToDecimal(r.Cells["materialId"].Value) == 5005)
                        .Sum(t => Convert.ToDecimal(t.Cells["weight"].Value)).ToString() + " KGS";
                //grdItems.Rows.Cast<DataGridViewRow>()
                //    .Where(x => (x.Cells["MaterialID"].Value.ToString()).Equals("5005"))
                //    .Sum(x => Convert.ToDecimal(x.Cells["weight"].Value)).ToString();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private double GetProductWeight()
        {
            try
            {
                if (cmbItem.SelectedIndex != 0)
                {
                    return Convert.ToDouble(classHelper.GetProductWeight(Convert.ToInt32(cmbItem.SelectedValue.ToString())));
                }
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
            return 0;
        }
        private void AddItemRow()
        {
            if (cmbItem.SelectedIndex == 0)
            {
                MessageBox.Show("Select Item", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbItem.Focus();
                return;
            }
            else if (txtQuantity.Text.Trim().Equals("") || txtQuantity.Text.Trim().Equals("0"))
            {
                MessageBox.Show("Enter Quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtQuantity.Focus();
                return;
            }
            else if (txtRate.Text.Trim().Equals(""))
            {
                MessageBox.Show("Enter Rate", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRate.Focus();
                return;
            }
            else
            {
                double weight = 0;
                if (rdbRaw.Checked == true)
                {
                    //if (Convert.ToDouble(txtQuantity.Text) > Convert.ToDouble(txtRemWeight.Text))
                    //{
                    //    MessageBox.Show("Weight is greater than Remaining Weight.", "Alert");
                    //    //return;
                    //}
                    weight = Convert.ToDouble(txtQuantity.Text);
                    grdItems.Rows.Add(
                        cmbItem.SelectedValue.ToString(), cmbItem.Text,txtQuantity.Text, txtRate.Text, weight, "KGS",
                        0, 0, (Convert.ToDecimal(txtQuantity.Text) * Convert.ToDecimal(txtRate.Text)), "R",
                        rdbRaw.Checked ? cmbItem.SelectedValue : GetMaterialID());
                }
                else if (rdbProduct.Checked == true)
                {
                    //if ((GetProductWeight() * Convert.ToDouble(txtQuantity.Text)) > Convert.ToDouble(txtRemWeight.Text))
                    //{
                    //    MessageBox.Show("Weight is greater than Remaining Weight.", "Alert");
                    //    //return;
                    //}
                    weight = Convert.ToDouble((GetProductWeight() * Convert.ToDouble(txtQuantity.Text)));
                    grdItems.Rows.Add(
                    cmbItem.SelectedValue.ToString(),cmbItem.Text,txtQuantity.Text, 
                    txtRate.Text, (GetProductWeight() * Convert.ToDouble(txtQuantity.Text)),
                    "KGS", 0, 0, (Convert.ToDecimal(txtQuantity.Text) * Convert.ToDecimal(txtRate.Text)),
                    "P",rdbRaw.Checked ? cmbItem.SelectedValue : GetMaterialID());
                }
                ItemsTotalSum();
                //ItemsTotalQty();
                //ItemsTotalWeight('L', weight);
                //ItemsTotalSum();
                AddClear();
            }
        }
        private void AddClear()
        {
            txtQuantity.Text = "0";
            txtRate.Text = "0";
            cmbItem.SelectedIndex = 0;
        }
        private void ItemsTotalWeight(char type, double value)
        {
            if (type.Equals('L'))
            {
                if (grdItems.Rows.Count > 0)
                {
                    txtTotalWeight.Text = grdItems.Rows.Cast<DataGridViewRow>()
                    .Sum(t => Convert.ToDecimal(t.Cells[3].Value)).ToString();
                    //txtRemWeight.Text = (Convert.ToDouble(txtRemWeight.Text) - value).ToString();
                }
            }
            else
            {
                txtTotalWeight.Text = grdItems.Rows.Cast<DataGridViewRow>()
                    .Sum(t => Convert.ToDecimal(t.Cells[3].Value)).ToString();
                //txtRemWeight.Text = (Convert.ToDouble(txtRemWeight.Text) + value).ToString();
            }
        }
        private void ItemsTotalQty()
        {
            if (grdItems.Rows.Count > 0)
            {
                //txtTQty.Text = grdItems.Rows.Cast<DataGridViewRow>()
                //.Sum(t => Convert.ToDecimal(t.Cells[2].Value)).ToString();
            }
        }
        private void ItemsTotalSum()
        {
            if (grdItems.Rows.Count > 0)
            {
                txtTotal.Text = grdItems.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToDecimal(t.Cells["total"].Value)).ToString();

                txtTotalWeight.Text = grdItems.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToDecimal(t.Cells["weight"].Value)).ToString()+" KGS";

                txtQty.Text = grdItems.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToDecimal(t.Cells["qty"].Value)).ToString();
            }
        }
        private int GetMaterialID()
        {
            try
            {
                classHelper.query = @"SELECT MATERIAL_ID FROM PRODUCT_DETAILS WHERE PM_ID = '" + cmbItem.SelectedValue.ToString() + "' ";
                if (Classes.Helper.conn.State == ConnectionState.Closed)
                    Classes.Helper.conn.Open();
                classHelper.cmd = new System.Data.SqlClient.SqlCommand(classHelper.query, Classes.Helper.conn);
                int result = int.Parse(classHelper.cmd.ExecuteScalar().ToString());
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return 0;
            }
            finally
            {
                Classes.Helper.conn.Close();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                AddItemRow();
                WeightSum();
            }
            catch (Exception ex)
            {
                classHelper.ShowMessageBox(ex.ToString(), "Exception");
            }
        }

        private void rdbProduct_CheckedChanged(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void grdItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DialogResult diag = new DialogResult();
                diag = MessageBox.Show("Do you want to edit this entry?", "Delete Entry", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (diag == DialogResult.Yes)
                {
                    DataGridViewRow row = this.grdItems.Rows[e.RowIndex];

                    if (rdbDirect.Checked == true) {
                        if (row.Cells["itemType"].Value.ToString().Equals("R"))
                        {
                            rdbRaw.Checked = true;
                            cmbItem.SelectedValue = row.Cells["itemid"].Value.ToString();
                        }
                        else
                        {
                            rdbProduct.Checked = true;
                            cmbItem.SelectedValue = row.Cells["itemid"].Value.ToString();
                        }
                        //cmbItem.SelectedValue = row.Cells[0].Value.ToString();
                        txtQuantity.Text = row.Cells["qty"].Value.ToString();
                        txtRate.Text = row.Cells["rate"].Value.ToString();
                        FieldsEnable();
                    }
                    
                    //double weight = Convert.ToDouble(row.Cells["weight"].Value.ToString());
                    ItemsTotalSum();
                    WeightSum();
                    grdItems.Rows.RemoveAt(e.RowIndex);
                }
            }
        }
    }
}

