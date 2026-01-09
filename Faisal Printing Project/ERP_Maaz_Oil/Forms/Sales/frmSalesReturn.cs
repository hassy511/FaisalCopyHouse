using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ERP_Maaz_Oil.Forms
{
    public partial class frmSalesReturn : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        string id = "";
        int is_edit= 0;
        //string soId = "0";
        //float lastWeight = 0;
        //float remainingWeight = 0;

        public frmSalesReturn()
        {
            InitializeComponent();
        }

        private void RowClear() {
            grdItems.Rows.Clear();
            cmbItem.SelectedIndex = 0;
            txtQuantity.Text = "0";
            txtRate.Text = "0";
            RowSum();
        }

        private void GenerateSRNumber()
        {
            classHelper.query = "SELECT isnull(MAX(SRM_ID)+1,1) FROM SALES_RETURN_MASTER";
            lblSR.Text = "SR-" + classHelper.GetMaxValue(classHelper.query) + "-" + DateTime.Now.Year;
        }

        private void GetProductRate()
        {
            try
            {
                if (cmbItem.SelectedIndex != 0)
                {
                    txtRate.Text = classHelper.GetProductRate(Convert.ToInt32(cmbItem.SelectedValue.ToString()), Convert.ToInt32(cmbCustomer.SelectedValue.ToString()));
                }
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void LoadGrid()
        {
            classHelper.query = @"SELECT A.SRM_ID AS [ID],A.INVOICE_NO AS [INVOICE #],A.[DATE],A.CUSTOMER_ID,
            B.COA_NAME AS [CUSTOMER NAME],SUM(C.ITEM_WEIGHT) AS [WEIGHT],SUM(C.QTY * C.ITEM_RATE) AS [AMOUNT],
            CAST(A.[DESCRIPTION] AS VARCHAR(MAX)) AS [DESCRIPTION],a.VEHICLE_NO,a.MUAND_RATE
            FROM SALES_RETURN_MASTER A
            INNER JOIN SALES_RETURN_DETAIL C ON A.SRM_ID = C.SRM_ID
            INNER JOIN COA B ON A.CUSTOMER_ID = B.COA_ID
            GROUP BY A.SRM_ID,A.INVOICE_NO,A.[DATE],A.CUSTOMER_ID,
            B.COA_NAME,CAST(A.[DESCRIPTION] AS VARCHAR(MAX)),a.VEHICLE_NO,a.MUAND_RATE
            ORDER BY A.SRM_ID DESC";
            classHelper.LoadGrid(grdSEARCH, classHelper.query);
        }
        //load COMBO BOXES
        private void LoadCustomers()
        {
            classHelper.LoadCustomers(cmbCustomer);
        }

        //load item COMBO BOXES
        private void LoadProducts()
        {
            classHelper.LoadProducts(cmbItem);
        }
        //private void LoadSO(string soId)
        //{
        //    if (soId.Equals("0"))
        //    {
        //        classHelper.LoadSOOrder(cmbSO, cmbCustomer.SelectedValue.ToString());
        //    }
        //    else {
        //        classHelper.LoadSOOrder(cmbSO, Convert.ToInt32(cmbCustomer.SelectedValue.ToString()), soId);
        //        cmbSO.SelectedValue = soId;
        //    }
        //}
        
        //private void LoadSoProduct(int soID)
        //{
        //    classHelper.LoadSoProducts(cmbSOProduct, soID);
        //}

        //private void LoadSOProducts(DataGridView dgv,int soId)
        //{
        //    classHelper.LoadSOProducts(dgv, soId);
        //}

        private void LoadRaw()
        {
            classHelper.LoadMaterial(1,cmbItem);
        }

        //clear fields in form
        private void Clear() {
            GenerateSRNumber();
            dtp_DATE.Value = DateTime.Now;
            cmbCustomer.SelectedIndex = 0;
            txtMuandRateD.Clear();
            txtVehicleNo.Clear();
            txtDescript.Clear();
            rdbProduct.Checked = true;
            cmbItem.SelectedIndex = 0;
            //txtQuantity.Enabled = false;
            //txtRate.Enabled = false;
            grdItems.Rows.Clear();
            txtCanolaWeight.Text = "0";
            txtRbdWeight.Text = "0";
            txtTotalWeight.Text = "0";
            txtTotalQty.Text = "0";
            txtAmount.Text = "0";
            txtSEARCH.Clear();
            id = "";
            is_edit = 0;
        }

        private void AddClear() {
            txtQuantity.Text = "0";
            txtRate.Text = "0";
            cmbItem.SelectedIndex = 0;
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
        //private void GetSODWeight()
        //{
        //    try
        //    {
        //        if (cmbSO.SelectedIndex != 0)
        //        {
        //            string[] soDetails = classHelper.GetSODWeight(Convert.ToInt32(cmbSO.SelectedValue.ToString().TrimEnd('D')));
        //            txtRemWeight.Text = soDetails[0];
        //            txtOrderWeight.Text = soDetails[1];
        //            txtMuandRate.Text = Math.Round(Convert.ToDecimal(soDetails[2])).ToString();

        //        }
        //    }
        //    catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
        //    //return 0;
        //}

        //private void GetSOPWeight()
        //{
        //    try
        //    {
        //        if (cmbSO.SelectedIndex != 0)
        //        {
        //            string[] soDetails = classHelper.GetSOPWeight(Convert.ToInt32(cmbSO.SelectedValue.ToString().TrimEnd('P')));
        //            txtRemWeight.Text = soDetails[0];
        //            txtOrderWeight.Text = soDetails[1];
        //            txtMuandRate.Text = Math.Round(Convert.ToDecimal(soDetails[2])).ToString();

        //        }
        //    }
        //    catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
        //    //return 0;
        //}

        //private void GetSOMWeight()
        //{
        //    try
        //    {
        //        if (cmbSO.SelectedIndex != 0)
        //        {
        //            string[] soDetails = classHelper.GetSOMWeight(Convert.ToInt32(cmbSO.SelectedValue.ToString().TrimEnd('M')));
        //            txtRemWeight.Text = soDetails[0];
        //            txtOrderWeight.Text = soDetails[1];
        //            //txtMuandRate.Text = Math.Round(Convert.ToDecimal(soDetails[2])).ToString();

        //        }
        //    }
        //    catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
        //    //return 0;
        //}

        //private void ItemsTotalQty()
        //{
        //    if (grdItems.Rows.Count > 0)
        //    {
        //        txtRbdWeight.Text = grdItems.Rows.Cast<DataGridViewRow>()
        //        .Sum(t => Convert.ToDecimal(t.Cells[2].Value)).ToString();
        //    }
        //}
        //private void ItemsTotalSum()
        //{
        //    if (grdItems.Rows.Count > 0)
        //    {
        //        txtCanolaWeight.Text = grdItems.Rows.Cast<DataGridViewRow>()
        //        .Sum(t => Convert.ToDecimal(t.Cells["total"].Value)).ToString();

        //        txtTotalWeight.Text = grdItems.Rows.Cast<DataGridViewRow>()
        //        .Sum(t => Convert.ToDecimal(t.Cells["weight"].Value)).ToString();

        //        txtRbdWeight.Text = grdItems.Rows.Cast<DataGridViewRow>()
        //        .Sum(t => Convert.ToDecimal(t.Cells["qty"].Value)).ToString();
        //    }
        //}
        private void RowSum()
        {
            if (grdItems.Rows.Count > 0)
            {
                txtTotalQty.Text = grdItems.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToDecimal(t.Cells["qty"].Value)).ToString();

                txtAmount.Text = grdItems.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToDecimal(t.Cells["total"].Value)).ToString();

                txtCanolaWeight.Text = grdItems.Rows.Cast<DataGridViewRow>()
                .Where(s => s.Cells["productType"].Value.ToString().Equals("C"))
                .Sum(t => Convert.ToDecimal(t.Cells["weight"].Value)).ToString();

                txtRbdWeight.Text = grdItems.Rows.Cast<DataGridViewRow>()
                .Where(s => s.Cells["productType"].Value.ToString().Equals("R"))
                .Sum(t => Convert.ToDecimal(t.Cells["weight"].Value)).ToString();

                txtTotalWeight.Text = grdItems.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToDecimal(t.Cells["weight"].Value)).ToString();
            }
            else {
                txtQuantity.Text = "0";
                txtAmount.Text = "0";
                txtCanolaWeight.Text = "0";
                txtRbdWeight.Text = "0";
                txtTotalWeight.Text = "0";
            }
        }
        //private void ItemsTotalWeight(char type,double value)
        //{
        //    if (type.Equals('L'))
        //    {
        //        if (grdItems.Rows.Count > 0)
        //        {
        //            txtTotalWeight.Text = grdItems.Rows.Cast<DataGridViewRow>()
        //            .Sum(t => Convert.ToDecimal(t.Cells[3].Value)).ToString();
        //            txtRemWeight.Text = (Convert.ToDouble(txtRemWeight.Text) - value).ToString();
        //        }
        //    }
        //    else {
        //        txtTotalWeight.Text = grdItems.Rows.Cast<DataGridViewRow>()
        //            .Sum(t => Convert.ToDecimal(t.Cells[3].Value)).ToString();
        //        txtRemWeight.Text = (Convert.ToDouble(txtRemWeight.Text) + value).ToString();
        //    }
        //}

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
                if (rdbRaw.Checked == true) {
                    //if (Convert.ToDouble(txtQuantity.Text) > Convert.ToDouble(txtRemWeight.Text)) {
                    //    MessageBox.Show("Weight is greater than Remaining Weight.","Alert");
                    //    //return;
                    //}
                    weight = Convert.ToDouble(txtQuantity.Text);
                    char productType = 'R';
                    int materialId = Convert.ToInt32(cmbItem.SelectedValue.ToString());
                    if (materialId.ToString().Equals("5005")) {
                        productType = 'C';
                    }
                    grdItems.Rows.Add(cmbItem.SelectedValue.ToString(), cmbItem.Text,  txtQuantity.Text, 1, "KGS", txtRate.Text, (Convert.ToDecimal(txtQuantity.Text) * Convert.ToDecimal(txtRate.Text)),"R",productType,materialId);
                }
                else if (rdbProduct.Checked == true) {
                    //if ((GetProductWeight() * Convert.ToDouble(txtQuantity.Text)) > Convert.ToDouble(txtRemWeight.Text))
                    //{
                    //    MessageBox.Show("Weight is greater than Remaining Weight.", "Alert");
                    //    //return;
                    //}
                    char productType = 'R';
                    int materialId = classHelper.GetProductMaterialId(Convert.ToInt32(cmbItem.SelectedValue.ToString()));
                    if (materialId.ToString().Equals("5005"))
                    {
                        productType = 'C';
                    }
                    weight = Convert.ToDouble((GetProductWeight() * Convert.ToDouble(txtQuantity.Text)));
                    grdItems.Rows.Add(cmbItem.SelectedValue.ToString(), cmbItem.Text, txtQuantity.Text, (GetProductWeight()*Convert.ToDouble(txtQuantity.Text)), "KGS", txtRate.Text, (Convert.ToDecimal(txtQuantity.Text) * Convert.ToDecimal(txtRate.Text)),"P",productType,materialId);
                }
                RowSum();
                //ItemsTotalSum();
                //ItemsTotalQty();
                //ItemsTotalWeight('L', weight);
                //ItemsTotalSum();
                AddClear();
            }
        }

        private void Save() {
            if (cmbCustomer.SelectedIndex == 0)
            {
                classHelper.ShowMessageBox("Select Customer.", "Information");
                return;
            }
            else if (txtVehicleNo.Text.Trim().Equals("")) {
                classHelper.ShowMessageBox("Enter Vehicle Number.", "Information");
                return;
            }
            else if (grdItems.Rows.Count > 0) {
                if (id.Equals(""))
                {
                    classHelper.query = @"BEGIN TRY
                    BEGIN TRAN ";

                    classHelper.query += @"INSERT INTO SALES_RETURN_MASTER (INVOICE_NO,[DATE],CUSTOMER_ID,VEHICLE_NO,[DESCRIPTION],
                    MUAND_RATE,TOTAL_CANOLA,TOTAL_RDB,CREATED_BY,CREATION_DATE) VALUES 
                    ('"+lblSR.Text+"','"+Classes.Helper.ConvertDatetime(dtp_DATE.Value.Date)+"','"+cmbCustomer.SelectedValue.ToString()+@"',
                    '"+classHelper.AvoidInjection(txtVehicleNo.Text)+"','"+ classHelper.AvoidInjection(txtDescript.Text) + @"',
                    '"+ classHelper.AvoidInjection(txtMuandRateD.Text) + "','"+ classHelper.AvoidInjection(txtCanolaWeight.Text) + @"',
                    '"+ classHelper.AvoidInjection(txtRbdWeight.Text) + "','"+Classes.Helper.userId+"',GETDATE());";

                    foreach (DataGridViewRow rows in grdItems.Rows)
                    {
                        classHelper.query += @"INSERT INTO SALES_RETURN_DETAIL (SRM_ID,ITEM_ID,QTY,ITEM_WEIGHT,ITEM_RATE,ITEM_TYPE,MATERIAL_ID) VALUES
                        ((SELECT ISNULL(MAX(SRM_ID),1) FROM SALES_RETURN_MASTER),'" + rows.Cells["itemId"].Value.ToString() + @"',
                        '" + rows.Cells["qty"].Value.ToString() + "','" + rows.Cells["weight"].Value.ToString() + @"',
                        '" + rows.Cells["rate"].Value.ToString() + "','" + rows.Cells["itemType"].Value.ToString() + @"',
                        '" + rows.Cells["materialId"].Value.ToString() + "');";

                        classHelper.query += @"INSERT INTO MATERIAL_ITEM_LEDGER ([DATE],MATERIAL_ID,REF_NO,ENTRY_FROM,STOCK_IN,STOCK_OUT,
                        CREATED_BY,CREATION_DATE,COMPANY_ID,L_ID,COST_AMT,SALE_AMT) VALUES 
                        ('" + Classes.Helper.ConvertDatetime(dtp_DATE.Value.Date) + "','" + rows.Cells["materialId"].Value.ToString() + @"',
                        (SELECT ISNULL(MAX(SRM_ID),1) FROM SALES_RETURN_MASTER),'SALES RETURN','0','" + rows.Cells["weight"].Value.ToString() + @"',
                        '" + Classes.Helper.userId + "',GETDATE(),'1','1','" + rows.Cells["rate"].Value.ToString() + @"','0');";

                        classHelper.query += @"INSERT INTO PRODUCT_ITEM_LEDGER ([DATE],PRODUCT_ID,REF_NO,ENTRY_FROM,STOCK_IN,STOCK_OUT,
                        COST_AMT,SALE_AMT,L_ID,CREATED_BY,CREATION_DATE,COMPANY_ID) VALUES 
                        ('" + Classes.Helper.ConvertDatetime(dtp_DATE.Value.Date) + "','" + rows.Cells["itemId"].Value.ToString() + @"',
                        (SELECT ISNULL(MAX(SRM_ID),1) FROM SALES_RETURN_MASTER),'SALES RETURN','0','" + rows.Cells["qty"].Value.ToString() + @"',
                        '" + rows.Cells["rate"].Value.ToString() + "','0','1','" + Classes.Helper.userId + "',GETDATE(),'1');";
                    }

                    classHelper.query += @"INSERT INTO LEDGERS ([DATE],COA_ID,REF_ID,ENTRY_OF,FOLIO,DEBIT,CREDIT,DESCRIPTIONS,
                    CREATED_BY,CREATION_DATE) VALUES 
                    ('" + Classes.Helper.ConvertDatetime(dtp_DATE.Value.Date) + "','"+cmbCustomer.SelectedValue.ToString()+ @"',
                    (SELECT ISNULL(MAX(SRM_ID),1) FROM SALES_RETURN_MASTER),'SALES RETURN','" + lblSR.Text + @"',
                    '0','" + classHelper.AvoidInjection(txtAmount.Text) + "','" + classHelper.AvoidInjection(txtDescript.Text) + @"',
                    '1',GETDATE());";

                    classHelper.query += @"INSERT INTO LEDGERS ([DATE],COA_ID,REF_ID,ENTRY_OF,FOLIO,DEBIT,CREDIT,DESCRIPTIONS,
                    CREATED_BY,CREATION_DATE) VALUES 
                    ('" + Classes.Helper.ConvertDatetime(dtp_DATE.Value.Date) + @"','"+Classes.Helper.salesReturnId+@"',
                    (SELECT ISNULL(MAX(SRM_ID),1) FROM SALES_RETURN_MASTER),'SALES RETURN','" + lblSR.Text + @"',
                    '" + classHelper.AvoidInjection(txtAmount.Text) + "','0','" + classHelper.AvoidInjection(txtDescript.Text) + @"',
                    '1',GETDATE());";

                    classHelper.query += @"
                        COMMIT TRAN
                    END TRY
                    BEGIN CATCH
                    IF(@@TRANCOUNT > 0)
                    ROLLBACK TRAN;
                    THROW;
                    END CATCH";
                }
                else {
                    classHelper.query = @"BEGIN TRY
                    BEGIN TRAN ";

                    classHelper.query += @"UPDATE SALES_RETURN_MASTER SET 
                    INVOICE_NO = '" + lblSR.Text + "',[DATE] = '" + Classes.Helper.ConvertDatetime(dtp_DATE.Value.Date) + @"',
                    CUSTOMER_ID = '" + cmbCustomer.SelectedValue.ToString() + @"',VEHICLE_NO = '" + classHelper.AvoidInjection(txtVehicleNo.Text) + @"',
                    [DESCRIPTION] = '" + classHelper.AvoidInjection(txtDescript.Text) + @"',MUAND_RATE = '" + classHelper.AvoidInjection(txtMuandRateD.Text) + @"',
                    TOTAL_CANOLA = '" + classHelper.AvoidInjection(txtCanolaWeight.Text) + @"',TOTAL_RDB = '" + classHelper.AvoidInjection(txtRbdWeight.Text) + @"',
                    MODIFIED_BY = '" + Classes.Helper.userId + @"',MODIFICATION_DATE = GETDATE() WHERE SRM_ID = '"+id+"';";

                    classHelper.query += @"DELETE FROM SALES_RETURN_DETAIL WHERE SRM_ID = '" + id + "';";
                    classHelper.query += @"DELETE FROM MATERIAL_ITEM_LEDGER WHERE REF_NO = '" + id + "' AND ENTRY_FROM = 'SALES RETURN';";
                    classHelper.query += @"DELETE FROM PRODUCT_ITEM_LEDGER WHERE REF_NO = '" + id + "' AND ENTRY_FROM = 'SALES RETURN';";
                    classHelper.query += @"DELETE FROM LEDGERS WHERE REF_ID = '" + id + "' AND ENTRY_OF = 'SALES RETURN';";

                    foreach (DataGridViewRow rows in grdItems.Rows)
                    {
                        classHelper.query += @"INSERT INTO SALES_RETURN_DETAIL (SRM_ID,ITEM_ID,QTY,ITEM_WEIGHT,ITEM_RATE,ITEM_TYPE,MATERIAL_ID) VALUES
                        ('"+id+"','" + rows.Cells["itemId"].Value.ToString() + @"',
                        '" + rows.Cells["qty"].Value.ToString() + "','" + rows.Cells["weight"].Value.ToString() + @"',
                        '" + rows.Cells["rate"].Value.ToString() + "','" + rows.Cells["itemType"].Value.ToString() + @"',
                        '" + rows.Cells["materialId"].Value.ToString() + "');";

                        classHelper.query += @"INSERT INTO MATERIAL_ITEM_LEDGER ([DATE],MATERIAL_ID,REF_NO,ENTRY_FROM,STOCK_IN,STOCK_OUT,
                        CREATED_BY,CREATION_DATE,COMPANY_ID,L_ID,COST_AMT,SALE_AMT) VALUES 
                        ('" + Classes.Helper.ConvertDatetime(dtp_DATE.Value.Date) + "','" + rows.Cells["materialId"].Value.ToString() + @"',
                        '" + id + "','SALES RETURN','0','" + rows.Cells["weight"].Value.ToString() + @"',
                        '" + Classes.Helper.userId + "',GETDATE(),'1','1','" + rows.Cells["rate"].Value.ToString() + @"','0');";

                        classHelper.query += @"INSERT INTO PRODUCT_ITEM_LEDGER ([DATE],PRODUCT_ID,REF_NO,ENTRY_FROM,STOCK_IN,STOCK_OUT,
                        COST_AMT,SALE_AMT,L_ID,CREATED_BY,CREATION_DATE,COMPANY_ID) VALUES 
                        ('" + Classes.Helper.ConvertDatetime(dtp_DATE.Value.Date) + "','" + rows.Cells["itemId"].Value.ToString() + @"',
                        '" + id + "','SALES RETURN','0','" + rows.Cells["qty"].Value.ToString() + @"',
                        '" + rows.Cells["rate"].Value.ToString() + "','0','1','" + Classes.Helper.userId + "',GETDATE(),'1');";
                    }

                    classHelper.query += @"INSERT INTO LEDGERS ([DATE],COA_ID,REF_ID,ENTRY_OF,FOLIO,DEBIT,CREDIT,DESCRIPTIONS,
                    CREATED_BY,CREATION_DATE) VALUES 
                    ('" + Classes.Helper.ConvertDatetime(dtp_DATE.Value.Date) + "','" + cmbCustomer.SelectedValue.ToString() + @"',
                    '" + id + "','SALES RETURN','" + lblSR.Text + @"',
                    '0','" + classHelper.AvoidInjection(txtAmount.Text) + "','" + classHelper.AvoidInjection(txtDescript.Text) + @"',
                    '1',GETDATE());";

                    classHelper.query += @"INSERT INTO LEDGERS ([DATE],COA_ID,REF_ID,ENTRY_OF,FOLIO,DEBIT,CREDIT,DESCRIPTIONS,
                    CREATED_BY,CREATION_DATE) VALUES 
                    ('" + Classes.Helper.ConvertDatetime(dtp_DATE.Value.Date) + @"','" + Classes.Helper.salesReturnId + @"',
                    '" + id + "','SALES RETURN','" + lblSR.Text + @"',
                    '" + classHelper.AvoidInjection(txtAmount.Text) + "','0','" + classHelper.AvoidInjection(txtDescript.Text) + @"',
                    '1',GETDATE());";

                    classHelper.query += @"
                        COMMIT TRAN
                    END TRY
                    BEGIN CATCH
                    IF(@@TRANCOUNT > 0)
                    ROLLBACK TRAN;
                    THROW;
                    END CATCH";
                }
                //char itemType = 'P';
                //string dId = id;
                //string masterId = id;
                //if (rdbRaw.Checked == true)
                //{
                //    itemType = 'R';
                //}
                //string updateQuery = "";
                //string soId = cmbSO.SelectedValue.ToString();
                //char soType = 'M';
                //if (soId[soId.Length - 1] == 'D')
                //{
                //    soType = 'D';
                //}
                //else if (soId[soId.Length - 1] == 'P') {
                //    soType = 'P';
                //}

                //if (!id.Equals(""))
                //{
                //    remainingWeight = (float.Parse(txtTotalWeight.Text) - lastWeight) - remainingWeight;
                //    if (soType == 'D')
                //    {
                //        updateQuery = "UPDATE SALES_ORDER_DIRECT SET REMAINING_WEIGHT = '" + remainingWeight + "' WHERE SOD_ID = '" + cmbSO.SelectedValue.ToString().TrimEnd(soType) + "';";
                //    }
                //    else if (soType == 'P')
                //    {
                //        updateQuery = "UPDATE SALES_ORDER_PRODUCT_MASTER SET REMAINING_WEIGHT = '" + remainingWeight + "' WHERE SOPM_ID = '" + cmbSO.SelectedValue.ToString().TrimEnd(soType) + "';";
                //    }
                //    else
                //    {
                //        updateQuery = "UPDATE SO_MATERIAL_P_MASTER SET REMAINING_WEIGHT = '" + remainingWeight + "' WHERE MPM_ID = '" + cmbSO.SelectedValue.ToString().TrimEnd(soType) + "';";
                //    }
                    
                //}
                //else {
                //    if (soType == 'D')
                //    {
                //        updateQuery = "UPDATE SALES_ORDER_DIRECT SET REMAINING_WEIGHT = '" + txtRemWeight.Text + "' WHERE SOD_ID = '" + cmbSO.SelectedValue.ToString().TrimEnd(soType) + "';";
                //    }
                //    else if (soType == 'P')
                //    {
                //        updateQuery = "UPDATE SALES_ORDER_PRODUCT_MASTER SET REMAINING_WEIGHT = '" + txtRemWeight.Text + "' WHERE SOPM_ID = '" + cmbSO.SelectedValue.ToString().TrimEnd(soType) + "';";
                //    }
                //    else
                //    {
                //        updateQuery = "UPDATE SO_MATERIAL_P_MASTER SET REMAINING_WEIGHT = '" + txtRemWeight.Text + "' WHERE MPM_ID = '" + cmbSO.SelectedValue.ToString().TrimEnd(soType) + "';";
                //    }
                //}

                
                //if (id.Equals(""))
                //{
                //    id = "(SELECT MAX(SPM_ID) FROM SALES_PROGRAM_MASTER)";
                //    masterId = id;
                //}

                //string detailQuery = "";

                //foreach (DataGridViewRow rows in grdItems.Rows)
                //{
                //    detailQuery += @"INSERT INTO SALES_PROGRAM_DETAILS (SPM_ID,PRODUCT_ID,QTY,RATE,ITEM_TYPE,[WEIGHT]) VALUES 
                //    ("+masterId+ ",'" + rows.Cells[0].Value.ToString() + "'," + rows.Cells[2].Value.ToString() + @",
                //     '" + rows.Cells[5].Value.ToString() + "','"+ rows.Cells[7].Value.ToString() + "','" + rows.Cells[3].Value.ToString() + @"');";
                //}

                //classHelper.query = "BEGIN TRAN ";
                //classHelper.query += @"IF EXISTS (select SPM_ID from SALES_PROGRAM_MASTER WHERE SPM_ID ='" + dId + @"') 
                //    BEGIN
                //    UPDATE SALES_PROGRAM_MASTER SET [DATE] = '" + dtp_DATE.Value.ToString() + "',CUSTOMER_ID = '" + cmbCustomer.SelectedValue.ToString() + @"',
                //    SOD_ID = '"+cmbSO.SelectedValue.ToString().TrimEnd(soType)+"', DESCRIPTION = '" + txtDescript.Text + @"',
                //    TOTAL = '" + txtCanolaWeight.Text + "',TOTAL_WEIGHT = '" + txtTotalWeight.Text + @"',[SO_TYPE] = '"+soType+@"',
                //    MODIFICATION_DATE = GETDATE(),MODIFIED_BY = '" + Classes.Helper.userId + @"' WHERE SPM_ID = '" + dId + @"';
                //    END
                //    ELSE
                //    BEGIN
                //    INSERT INTO SALES_PROGRAM_MASTER 
                //    (DATE,CUSTOMER_ID,SOD_ID,INVOICE_NO,DESCRIPTION,TOTAL,TOTAL_WEIGHT,CREATED_BY,CREATION_DATE,REMAINING_WEIGHT,[SO_TYPE])
                //    VALUES('" + dtp_DATE.Value.ToString() + "','" + cmbCustomer.SelectedValue.ToString() + "','"+cmbSO.SelectedValue.ToString().TrimEnd(soType) + @"',
                //    '"+lblSR.Text+"','"+txtDescript.Text+"','"+txtCanolaWeight.Text+"','"+txtTotalWeight.Text+ "','" + Classes.Helper.userId + "',GETDATE(),0,'"+soType+@"')
                //    END
                //    DELETE FROM SALES_PROGRAM_DETAILS WHERE SPM_ID = '" + dId + @"'
                //    " + detailQuery + @";";
                //classHelper.query += updateQuery;
                //classHelper.query += "COMMIT TRAN";
                if (classHelper.InsertUpdateDelete(classHelper.query) >= 1)
                {
                    classHelper.ShowMessageBox("Record Saved Sucessfully.", "Information");
                    Clear();
                    LoadGrid();
                }
            }
        }

        //get data from grid on click
        private void load_data_fromGrid(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.grdSEARCH.Rows[e.RowIndex];
                id = row.Cells["ID"].Value.ToString();
                is_edit = 1;
                dtp_DATE.Text = row.Cells["DATE"].Value.ToString();
                lblSR. Text = row.Cells["INVOICE #"].Value.ToString();
                //soId = row.Cells["SOD_ID"].Value.ToString()+row.Cells["SO_TYPE"].Value.ToString();
                //cmbCustomer.SelectedIndex = 0;
                cmbCustomer.SelectedValue = row.Cells["CUSTOMER_ID"].Value.ToString();
                
                ////cmbSO.SelectedValue = row.Cells[5].Value.ToString();
                txtDescript.Text = row.Cells["DESCRIPTION"].Value.ToString();
                txtVehicleNo.Text = row.Cells["VEHICLE_NO"].Value.ToString();
                txtMuandRateD.Text = row.Cells["MUAND_RATE"].Value.ToString();
                //txtCanolaWeight.Text = row.Cells["AMOUNT"].Value.ToString();
                //txtTotalWeight.Text = row.Cells["TOTAL WEIGHT"].Value.ToString();
                //lastWeight = float.Parse(row.Cells["TOTAL WEIGHT"].Value.ToString());
                ////remainingWeight = float.Parse(row.Cells[10].Value.ToString());
                //txtRemWeight.Text = row.Cells["REMAINING_WEIGHT"].Value.ToString();//(Convert.ToDouble(row.Cells[8].Value.ToString())+Convert.ToDouble(row.Cells[9].Value.ToString())).ToString();
                grdItems.Rows.Clear();
                classHelper.GetSaleReturnDetails(Convert.ToInt16(id),grdItems);
                RowSum();
            }
        }
        
        private void frm_AddGroupAccounts_Load(object sender, EventArgs e)
        {
            GenerateSRNumber();
            LoadGrid();
            LoadCustomers();
            LoadProducts();
        }

        private void txtSEARCH_TextChanged(object sender, EventArgs e)
        {
           classHelper.Sale_Return_Search(txtSEARCH, grdSEARCH);
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {
            Save();
        }
        
        private void grdSEARCH_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            grdSEARCH.Columns["ID"].Visible = false;
            grdSEARCH.Columns["CUSTOMER_ID"].Visible = false;
        }

        private void btnCLEAR_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void grdSEARCH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           load_data_fromGrid(e); 
        }
        
        private void txtNetWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                classHelper.AllowNumbers(e);
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddItemRow();
        }

        private void grdItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.grdItems.Rows[e.RowIndex];
                if (row.Cells["itemType"].Value.ToString().Equals("R"))
                {
                    rdbRaw.Checked = true;
                    cmbItem.SelectedValue = row.Cells["itemId"].Value.ToString();
                }
                else
                {
                    rdbProduct.Checked = true;
                    cmbItem.SelectedValue = row.Cells["itemId"].Value.ToString();
                }
                //cmbItem.SelectedValue = row.Cells[0].Value.ToString();
                txtQuantity.Text = row.Cells["qty"].Value.ToString();
                txtRate.Text = row.Cells["rate"].Value.ToString();
                double weight = Convert.ToDouble(row.Cells["weight"].Value.ToString());
                grdItems.Rows.RemoveAt(e.RowIndex);
                RowSum();
            }
        }

        private void cmbItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if(rdbProduct.Checked == true)
            //{
            //    GetProductRate();
            //}
        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbCustomer.SelectedIndex != 0)
            //{
            //    if (is_edit == 0)
            //    {
            //        LoadSO("0");
            //    }
            //    else {
            //        LoadSO(soId);
            //    }
            //    cmbSO.Enabled = true;
            //}
            //else
            //{
            //    if (cmbCustomer.Items.Count > 0)
            //    {
            //        cmbCustomer.SelectedIndex = 0;
            //    }
            //}
        }

        private void rdbRaw_CheckedChanged(object sender, EventArgs e)
        {
            LoadRaw();
        }

        private void rdbProduct_CheckedChanged(object sender, EventArgs e)
        {
            LoadProducts();
        }

        //private void cmbSO_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cmbSO.SelectedIndex > 0)
        //    {
        //        string soId = cmbSO.SelectedValue.ToString();
        //        if (soId[soId.Length - 1] == 'D') {
        //            RowClear();
        //            cmbSOProduct.Enabled = false;
        //            cmbSOProduct.Text = "";
        //            GetSODWeight();
        //            txtMuandRateD.Text = classHelper.GetSOMuandRate(Convert.ToInt32(cmbSO.SelectedValue.ToString().TrimEnd('D')),'D');
        //        }
        //        else if (soId[soId.Length - 1] == 'P') {
        //            RowClear();
        //            cmbSOProduct.Enabled = false;
        //            cmbSOProduct.Text = "";
        //            GetSOPWeight();
        //            LoadSOProducts(grdItems,Convert.ToInt32(cmbSO.SelectedValue.ToString().TrimEnd('P')));
        //            txtMuandRateD.Text = classHelper.GetSOMuandRate(Convert.ToInt32(cmbSO.SelectedValue.ToString().TrimEnd('P')), 'P');
        //            RowSum();
        //        }
        //        else {
        //            RowClear();
        //            int somId = Convert.ToInt32(cmbSO.SelectedValue.ToString().TrimEnd('M'));
        //            LoadSoProduct(somId);
        //            txtMuandRateD.Text = classHelper.GetSOMuandRate(Convert.ToInt32(cmbSO.SelectedValue.ToString().TrimEnd('M')), 'M');
        //            cmbSOProduct.Enabled = true;
        //            if (cmbSOProduct.Items.Count > 0) {
        //                cmbSOProduct.SelectedIndex = 0;
        //                txtMuandRate.Text = cmbSOProduct.SelectedValue.ToString();
        //                GetSOMWeight();
        //            }
        //        }

        //        //txtRemWeight.Text = GetSOWeight().ToString();
                
        //        rdbProduct.Checked = true;
        //        LoadProducts();
        //        cmbItem.Enabled = true;
        //        txtQuantity.Enabled = true;
        //        txtRate.Enabled = true;
        //    }
        //    else
        //    {
        //        if (cmbSO.Items.Count > 0)
        //        {
        //            txtRemWeight.Text = "0";
        //        }
        //    }
        //}

        private void txtTQty_TextChanged(object sender, EventArgs e)
        {

        }

        //private void cmbSOProduct_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cmbSOProduct.Enabled ==true && cmbSOProduct.Items.Count > 0) { txtMuandRate.Text = cmbSOProduct.SelectedValue.ToString(); }
        //}

        private void grdItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
    }
    }

