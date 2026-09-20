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
    public partial class frmGatePass : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        string id = ""; string gatePassId = "";string saleInvoiceId = "";
        int is_edit = 0;
        float lastWeight = 0;
        float remainingWeight = 0;

        public frmGatePass()
        {
            InitializeComponent();
        }
        private void GenerateGPNumber()
        {
            classHelper.query = "SELECT COUNT(S_ID)+1 FROM SALES";
            lblPRO.Text = "SI-" + classHelper.GetMaxValue(classHelper.query) + "-" + DateTime.Now.Year;
        }
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

                grdItems.Rows[e.RowIndex].Cells["weight"].Value = (Convert.ToDouble(grdItems.Rows[e.RowIndex].Cells["qty"].Value.ToString()) * Convert.ToDouble(grdItems.Rows[e.RowIndex].Cells["unitweight"].Value.ToString()));
                
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
            B.DESCRIPTION,B.VEHICLE_NO,B.MUAND_RATE AS [MUAND RATE]
            FROM SALES_PROGRAM_MASTER A
            INNER JOIN GATE_PASS B ON A.SPM_ID = B.SOP_ID
            INNER JOIN SALES C ON A.SPM_ID = C.SOP_ID
            INNER JOIN COA D ON A.CUSTOMER_ID = D.COA_ID
            ORDER BY B.[DATE] DESC";
            classHelper.LoadGrid(grdSEARCH, classHelper.query);
        }


        //load COMBO BOXES
        private void LoadCustomers()
        {
            classHelper.LoadCustomers(cmbCustomer);
        }


        private void LoadPrograms(char type)
        {
            classHelper.LoadSO(cmbPro, Convert.ToInt16(cmbCustomer.SelectedValue.ToString()),type);
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
            if (cmbPro.Items.Count > 0)
            {
                cmbPro.SelectedIndex = 0;
            }
            cmbPro.Enabled = false;
            txtArea.Clear();
            txtDescript.Clear();
            txtSalePerson.Clear();
            txtVehicle.Clear();
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
        private void Save()
        {

            if (cmbCustomer.SelectedValue.ToString().Equals("0"))
            {
                MessageBox.Show("Select Customer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbCustomer.Focus();
                return;
            }
            else if (cmbPro.SelectedValue.ToString().Equals("0"))
            {
                MessageBox.Show("Select Program", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbPro.Focus();
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
                        (" + cmbPro.SelectedValue.ToString() + ",'" + rows.Cells["itemId"].Value.ToString() + "'," + rows.Cells["qty"].Value.ToString() + @",
                         '" + rows.Cells["rate"].Value.ToString() + "','" + rows.Cells["itemType"].Value.ToString() + "','" + rows.Cells["weight"].Value.ToString() + @"',
                        '" + rows.Cells["millingRate"].Value.ToString() + "','" + rows.Cells["packingRate"].Value.ToString() + @"');";
                        }

                        classHelper.query = @"BEGIN TRY 
                             BEGIN TRANSACTION ";
                        classHelper.query += @"IF EXISTS (select GPM_ID from GATE_PASS WHERE GPM_ID ='" + gatePassId + @"') 
                    BEGIN
                    UPDATE GATE_PASS SET [DATE] = '" + dtp_DATE.Value.ToString() + "',SOP_ID = '" + cmbPro.SelectedValue.ToString() + @"',
                    [DESCRIPTION] = '" + classHelper.AvoidInjection(txtDescript.Text) + @"',
                    VEHICLE_NO = '" + classHelper.AvoidInjection(txtVehicle.Text) + @"',
                    MUAND_RATE = '"+classHelper.AvoidInjection(txtMuandRate.Text)+"',MODIFICATION_DATE = GETDATE(),MODIFICATION_ID = '" + Classes.Helper.userId + @"' WHERE GPM_ID = '" + gatePassId + @"';
                    END
                    ELSE
                    BEGIN
                    INSERT INTO GATE_PASS
                    (DATE,SOP_ID,INVOICE_NO,DESCRIPTION,VEHICLE_NO,CREATED_BY,CREATION_DATE,MUAND_RATE)
                    VALUES('" + dtp_DATE.Value.ToString() + "','" + cmbPro.SelectedValue.ToString() + @"',
                    (SELECT 'SI-'+CONVERT(VARCHAR(MAX),(COUNT(S_ID)+1))+'-'+CONVERT(VARCHAR(MAX),YEAR(getdate())) FROM SALES),'" + classHelper.AvoidInjection(txtDescript.Text) + "','" + classHelper.AvoidInjection(txtVehicle.Text) + "','" + Classes.Helper.userId + @"',GETDATE(),'"+classHelper.AvoidInjection(txtMuandRate.Text)+@"')
                    END ";

                    classHelper.query += @"IF EXISTS (select S_ID from SALES WHERE S_ID ='" + dId + @"') 
                    BEGIN
                    UPDATE SALES SET [DATE] = '" + dtp_DATE.Value.ToString() + "',SOP_ID = '" + cmbPro.SelectedValue.ToString() + @"',
                    [DESCRIPTION] = '" + classHelper.AvoidInjection(txtDescript.Text) + @"',
                    VEHICLE_NO = '" + classHelper.AvoidInjection(txtVehicle.Text) + @"',
                    MUAND_RATE = '"+classHelper.AvoidInjection(txtMuandRate.Text)+"',MODIFICATION_DATE = GETDATE(),MODIFICATION_ID = '" + Classes.Helper.userId + @"' WHERE S_ID = '" + dId + @"';
                    END
                    ELSE
                    BEGIN
                    INSERT INTO SALES 
                    (DATE,SOP_ID,INVOICE_NO,DESCRIPTION,VEHICLE_NO,REMAINING_AMOUNT,CREATED_BY,CREATION_DATE,MUAND_RATE)
                    VALUES('" + dtp_DATE.Value.ToString() + "','" + cmbPro.SelectedValue.ToString() + @"',
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

                        classHelper.query += @"DELETE FROM SALES_PROGRAM_DETAILS WHERE SPM_ID = '" + cmbPro.SelectedValue.ToString() + @"'; 
                    " + programDetailQuery + @";";

                        classHelper.query += @" COMMIT TRANSACTION 
                        END TRY 
                    BEGIN CATCH 
                            IF @@TRANCOUNT > 0 
                            ROLLBACK TRANSACTION 
                    END CATCH";
                        if (classHelper.InsertUpdateDelete(classHelper.query) >= 1)
                        {
                            classHelper.GatePassSP(Convert.ToInt32(cmbPro.SelectedValue.ToString()));
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
        private void frm_AddGroupAccounts_Load(object sender, EventArgs e)
        {
            GenerateGPNumber();
            LoadGrid();
            LoadCustomers();
        }
        private void btnSAVE_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void btnCLEAR_Click(object sender, EventArgs e)
        {
            Clear();
        }
        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCustomer.SelectedIndex != 0)
            {
                grdItems.Rows.Clear();
                if (is_edit == 1)
                {
                    LoadPrograms('a');
                }
                else {
                    LoadPrograms('s');
                }
                LoadCustomerDetails();
                cmbPro.Enabled = true;
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
            if (cmbPro.SelectedIndex != 0)
            {
                char type = 'P';
                //if (cmbPro.Text.Substring(0, 2).Equals("SO"))
                //{
                //    type = 'S';
                //}
                txtMuandRate.Text = classHelper.GetProgramMuandRate(Convert.ToInt32(cmbPro.SelectedValue.ToString()));
                grdItems.Rows.Clear();
                classHelper.LoadSOProducts(type, Convert.ToInt32(cmbPro.SelectedValue.ToString()), grdItems, txtDueDate, dtp_DATE.Value.Date);
                if (grdItems.Rows.Count > 0) { TotalSum(); }

            }
            else
            {
                if (cmbPro.Items.Count > 0)
                {
                    cmbPro.SelectedIndex = 0;
                }
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
                RowSum(e);
            }
        }
        private void SaleInvoiceReport()
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
    where a.SOP_ID = '" + cmbPro.SelectedValue.ToString() + @"'
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
        where a.SOP_ID = '" + cmbPro.SelectedValue.ToString() + @"'
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
        where a.SOP_ID = '" + cmbPro.SelectedValue.ToString() + @"'
    END";

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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Classes.Helper.conn.Close();
            }

            classHelper.rpt = new ERP_Maaz_Oil.Forms.Reporting.frmReports();
            classHelper.rpt.GenerateReport("SaleInvoice", classHelper.mds);
            classHelper.rpt.ShowDialog();

            
            
        }

        private void GatePassReport()
        {
            classHelper.mds.Tables["GatePass"].Clear();
            foreach (DataGridViewRow row in grdItems.Rows) {
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
                classHelper.dataR["totalWeight"] = Convert.ToDouble(txtTotalWeight.Text);

                classHelper.mds.Tables["GatePass"].Rows.Add(classHelper.dataR);
            }
            
            classHelper.rpt = new ERP_Maaz_Oil.Forms.Reporting.frmReports();
            classHelper.rpt.GenerateReport("GatePass", classHelper.mds);
            classHelper.rpt.ShowDialog();
        }
        private void grdSEARCH_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            grdSEARCH.Columns["GPM_ID"].Visible = false;
            grdSEARCH.Columns["S_ID"].Visible = false;
            grdSEARCH.Columns["SPM_ID"].Visible = false;
            grdSEARCH.Columns["COA_ID"].Visible = false;
        }

        private void txtSEARCH_TextChanged(object sender, EventArgs e)
        {
            classHelper.GatePass_Search(txtSEARCH, grdSEARCH);
        }

        //get data from grid on click
        private void load_data_fromGrid(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.grdSEARCH.Rows[e.RowIndex];
                id = row.Cells["SPM_ID"].Value.ToString();
                gatePassId = row.Cells["GPM_ID"].Value.ToString();
                saleInvoiceId = row.Cells["S_ID"].Value.ToString();
                is_edit = 1;
                dtp_DATE.Text = row.Cells["DATE"].Value.ToString();
                lblPRO.Text = row.Cells["GATE PASS #"].Value.ToString();
                cmbCustomer.SelectedValue = row.Cells["COA_ID"].Value.ToString();
                cmbPro.SelectedValue = row.Cells["SPM_ID"].Value.ToString();
                txtDescript.Text = row.Cells["DESCRIPTION"].Value.ToString();
                txtVehicle.Text = row.Cells["VEHICLE_NO"].Value.ToString();
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
    }
}

