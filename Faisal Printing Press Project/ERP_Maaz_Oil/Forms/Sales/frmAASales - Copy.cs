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
    public partial class frmAASales : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        string asId = "";
        string soId = "";
        int is_edit = 0;
        decimal remainingWeight = 0;
        decimal lastWeight = 0;
        Purchases.SOInwardReport clsSOInward = new Purchases.SOInwardReport();
        public frmAASales()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
            if (keyData == (Keys.Control | Keys.S))
            {
                SaleSave();
            }
            if (keyData == (Keys.Control | Keys.C))
            {
                Clear();
            }
            if (keyData == (Keys.Escape))
            {
                this.Dispose();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void GenerateSINumber()
        {
            classHelper.query = "SELECT ISNULL(MAX(as_id)+1,1) FROM AA_SALES";
            lblSaleInvoiceNo.Text = "SI-" + classHelper.GetMaxValue(classHelper.query) + "-" + DateTime.Now.Year;
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

        //private void PurchaseKgRateCalculation()
        //{
        //    decimal netWeight = 0;
        //    if (!txtKorangiWeight.Text.Equals("") && !txtOrderWeight.Text.Equals(""))
        //    {
        //        netWeight = Convert.ToDecimal(txtKorangiWeight.Text);
        //        txtBalanceWeight.Text = (Convert.ToDecimal(txtOrderWeight.Text) - Convert.ToDecimal(txtKorangiWeight.Text)).ToString();
        //    }
        //    decimal kgRate = 0;
        //    if (!txtKgRate.Text.Equals(""))
        //    {
        //        kgRate = Convert.ToDecimal(txtKgRate.Text);
        //    }
        //    txtTotal.Text = Math.Round((netWeight * kgRate)).ToString();
        //}

        private void SalesKgRateCalculation()
        {
            decimal netWeight = 0;
            if (!txtSaleWeight.Text.Equals(""))
            {
                netWeight = Convert.ToDecimal(txtSaleWeight.Text);
                txtSalesBalanceWeight.Text = (remainingWeight - Convert.ToDecimal(txtSaleWeight.Text)).ToString();
            }
            decimal kgRate = 0;
            if (!txtSaleMuandRate.Text.Equals(""))
            {
                kgRate = Convert.ToDecimal(txtSaleMuandRate.Text) / Convert.ToDecimal(37.324);
            }
            txtSalesTotal.Text = Math.Round((netWeight * kgRate),2).ToString();
        }

        private void GetSODetails()
        {
            try
            {
                if (cmbSO.SelectedIndex != 0)
                {
                    classHelper.query = @"SELECT FORMAT(a.DATE,'dd/MM/yyyy') AS [SO DATE],a.REMAINING_WEIGHT AS [BALANCE WEIGHT],
                    a.RATE AS [KG RATE],a.CREDIT_DAYS AS [CREDIT DAYS],a.[DESCRIPTION],a.TOTAL_KGS AS [SO WEIGHT],
                    b.MATERIAL_NAME
                    FROM SALES_ORDER_DIRECT a 
                    inner join MATERIALS b on a.MATERIAL_ID = b.MATERIAL_ID
                    WHERE a.SOD_ID = '" + cmbSO.SelectedValue.ToString().TrimEnd('D') + "'";

                    if (Classes.Helper.conn1.State == System.Data.ConnectionState.Closed) { Classes.Helper.conn1.Open(); }
                    SqlCommand cmd = new SqlCommand(classHelper.query, Classes.Helper.conn1);
                    cmd.CommandTimeout = 0;
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        txtSODate.Text = dr["SO DATE"].ToString();
                        txtSalesBalanceWeight.Text = dr["BALANCE WEIGHT"].ToString();
                        txtSaleKg.Text = dr["KG RATE"].ToString();
                        txtSaleCreditDays.Text = dr["CREDIT DAYS"].ToString();
                        txtSalesDescription.Text = dr["DESCRIPTION"].ToString();
                        txtSOWeight.Text = dr["SO WEIGHT"].ToString();
                        txtMaterial.Text = dr["MATERIAL_NAME"].ToString();
                    }
                    //string[] soDetails = classHelper.GetSODWeight(Convert.ToInt32(cmbSO.SelectedValue.ToString().TrimEnd('D')));
                    //txtOrderWeight.Text = soDetails[1];
                    //txtMuandRate.Text = Math.Round(Convert.ToDecimal(soDetails[2])).ToString();
                    //txtDescript.Text = soDetails[3];
                }
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
            finally {
                Classes.Helper.conn1.Close();
            }
            //return 0;
        }
        //private void GeneratePINumber()
        //{
        //    classHelper.query = "SELECT isnull(MAX(PI_ID)+1,1) FROM PURCHASES";
        //    lblPI.Text = "PI-" + classHelper.GetMaxValue(classHelper.query) + "-" + DateTime.Now.Year;
        //}
        //private void LoadSuppliers()
        //{
        //    try
        //    {
        //        classHelper.query = @"SELECT '0' AS [id],'--SELECT SUPPLIER--' AS [name]
        //        UNION
        //        SELECT COA_ID AS [id],COA_NAME AS [name] FROM COA WHERE STAT = 0";
        //        classHelper.LoadComboData(cmbSupplier, classHelper.query);
        //    }
        //    catch (Exception ex) { MessageBox.Show(ex.ToString(), "Exception"); }
        //}
        private void LoadCustomers()
        {
            try
            {
                classHelper.query = @"SELECT '0' AS [id],'--SELECT CUSTOMER--' AS [name]
                UNION
                SELECT COA_ID AS [id],COA_NAME AS [name] FROM COA WHERE STAT = 0";
                classHelper.LoadComboData(cmbCustomer, classHelper.query);
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString(), "Exception"); }
        }
        //private void LoadPO()
        //{
        //    classHelper.LoadPurchaseOrder(cmbPurchaseOrder, Convert.ToInt16(cmbSupplier.SelectedValue.ToString()), is_edit);
        //}
        //private void LoadPODetails()
        //{
        //    classHelper.query = @"SELECT (A.WEIGHT - A.REC_WEIGHT) AS [WEIGHT],B.MATERIAL_NAME,C.M_TYPE_NAME,D.UNIT_NAME,A.KG_RATE,A.MUAND_RATE,
        //    ((A.WEIGHT - A.REC_WEIGHT) * A.KG_RATE) AS [TOTAL],A.CREDIT_DAYS,A.MUAND_VALUE,A.WEIGHT AS [ORDERED WEIGHT],FORMAT(A.DATE,'dd/MM/yyyy') as [DATE],A.[DESCRIPTION]
        //    FROM PURCHASES_ORDER A,MATERIALS B, MATERIAL_TYPES C,UNITS D
        //    WHERE A.MATERIAL_ID = B.MATERIAL_ID AND B.M_TYPE_ID = C.M_TYPE_ID AND B.UNIT_ID = D.UNIT_ID
        //    AND A.PO_ID = '" + cmbPurchaseOrder.SelectedValue.ToString()+"'";
        //    classHelper.LoadPODetails(classHelper.query, txtMaterialType, txtMaterial, txtKorangiWeight,txtUnit,txtKgRate, txtDescript, 
        //        txtTotal,txtCreditDays, txtMuandRate, txtOrderWeight,txtBalanceWeight,txtPODate,new TextBox());
        //}

        private void LoadGrid()
        {
            classHelper.query = @"SELECT a.[date] AS [DATE],
            A.INVOICE_NO AS [SALES INVOICE],A.customer_id,F.INVOICE_NO AS [SO #],A.so_id,F.DATE AS [SO DATE],h.MATERIAL_NAME,A.muand_rate AS [SALES MUAND RATE],A.sales_weight AS [SALES_WEIGHT],
            ROUND((F.TOTAL_KGS-(SELECT SUM(sales_weight) FROM AA_SALES WHERE so_id = a.so_id and as_id<=a.as_id group by so_id)),2) AS [SO BALANCE WEIGHT],A.kg_rate AS [SALE KG RATE],
            (A.sales_weight * A.kg_rate) AS [SALES AMOUNT],A.credit_days AS [SALES CREDIT DAY],
            A.description AS [SALES DESCRIPTION],A.as_id
            FROM AA_SALES A
            INNER JOIN SALES_ORDER_DIRECT F ON A.so_id = F.SOD_ID
            INNER JOIN COA G ON A.customer_id = G.COA_ID
            inner join MATERIALS h on f.MATERIAL_ID = h.MATERIAL_ID
            ORDER BY A.as_id DESC";
            classHelper.LoadGrid(grdSEARCH, classHelper.query);
        }
        //load COMBO BOXES
        
        
        //clear fields in form
        private void Clear() {
            GenerateSINumber();
            dtp_DATE.Value = DateTime.Now;
            txtMaterialType.Clear();
            txtMaterial.Clear();
            txtSOWeight.Text = "0";
            txtSEARCH.Clear();
            remainingWeight = 0;
            asId = "";
            lastWeight = 0;
            is_edit = 0;
            cmbCustomer.SelectedIndex = 0;
            cmbSO.SelectedIndex = 0;
            txtSODate.Clear();
            txtSaleWeight.Text = "0";
            txtSalesBalanceWeight.Text = "0";
            txtSaleKg.Text = "0";
            txtSaleMuandRate.Text = "0";
            txtSalesTotal.Text = "0";
            txtSaleCreditDays.Text = "0";
            txtSalesDescription.Clear();

        }

        private void SaleSave()
        {
            if (cmbCustomer.SelectedIndex == 0)
            {
                classHelper.ShowMessageBox("Customer is not selected, please select Customer.", "Warning");
                cmbCustomer.Focus();
            }
            else if (cmbSO.SelectedIndex == 0)
            {
                classHelper.ShowMessageBox("Sales Order  is not selected, please select Sales Order.", "Warning");
                cmbSO.Focus();
            }
            else if (txtSaleWeight.Text.Trim().Equals("0") || txtSaleWeight.Text.Trim().Equals(""))
            {
                classHelper.ShowMessageBox("Weight field is blank.", "Warning");
                txtSaleWeight.Focus();
            }
            else if(Convert.ToDecimal(txtSaleWeight.Text) > Convert.ToDecimal(remainingWeight))
            {
                classHelper.ShowMessageBox("Sales weight cannot be more than SO weight.", "Warning");
                txtSaleWeight.Focus();
            }
            else
            {
                //Purchases Save
                double muandValue = 37.324;
                string sdId = asId;

                classHelper.query = @"BEGIN TRY 
                BEGIN TRANSACTION ";

                if (asId.Equals(""))
                {
                    asId = "(SELECT MAX(as_ID) FROM AA_SALES)";
                }
                double saleTotal = 0;
                double salesMaterialRate = Convert.ToDouble(txtSaleMuandRate.Text);
                if (txtMaterial.Text.Equals("OLIEN") || txtMaterial.Text.Equals("RBD") || txtMaterial.Text.Equals("SOYA BEAN"))
                {
                    saleTotal = Convert.ToDouble(txtSaleWeight.Text) * (Convert.ToDouble(txtSaleMuandRate.Text) / 37.324);
                }
                else
                {
                    saleTotal = Convert.ToDouble(txtSaleWeight.Text) * Convert.ToDouble(txtSaleKg.Text);
                    muandValue = 40;
                    salesMaterialRate = Convert.ToDouble(txtSaleKg.Text);
                }

                string updateQuery = "";
               
                if (!asId.Equals(""))
                {
                    remainingWeight = remainingWeight - (Convert.ToDecimal(txtSaleWeight.Text));
                    updateQuery = "UPDATE SALES_ORDER_DIRECT SET REMAINING_WEIGHT = ('" + remainingWeight + "') WHERE SOD_ID = '" + cmbSO.SelectedValue.ToString().TrimEnd('D') + "';";
                }
                else
                {
                    updateQuery = "UPDATE SALES_ORDER_DIRECT SET REMAINING_WEIGHT = '" + txtSalesBalanceWeight.Text + "' WHERE SOD_ID = '" + cmbSO.SelectedValue.ToString().TrimEnd('D') + "';";
                }

                saleTotal = Math.Round(saleTotal, 2);
                classHelper.query += @" 
                IF EXISTS (SELECT as_ID FROM AA_SALES WHERE as_id = '" + sdId + @"')
                BEGIN
	                UPDATE AA_SALES SET [date] = '" + dtp_DATE.Value.Date + @"',
                    customer_id = '" + cmbCustomer.SelectedValue.ToString().TrimEnd('D') + "',so_id = '" + cmbSO.SelectedValue.ToString().TrimEnd('D') + @"',
	                sales_weight = '" + txtSaleWeight.Text + "',balance_weight = '" + txtSalesBalanceWeight.Text + @"',
                    kg_rate = '" + txtSaleKg.Text + "',muand_rate = '" + txtSaleMuandRate.Text + "',total = '" + saleTotal + @"',
                    credit_days = '" + txtSaleCreditDays.Text + "',[description] = '" + txtSalesDescription.Text + @"',
                    modification_date = GETDATE(),modification_id = '1',INVOICE_NO = '" + lblSaleInvoiceNo.Text + "' WHERE as_id = '" + sdId + @"';
                END
                ELSE
                BEGIN
	                INSERT INTO AA_SALES ([date],customer_id,so_id,sales_weight,
	                balance_weight,kg_rate,muand_rate,total,credit_days,[description],creation_date,created_by,INVOICE_NO)
	                VALUES ('" + dtp_DATE.Value.Date + "','" + cmbCustomer.SelectedValue.ToString() + @"',
                    '" + cmbSO.SelectedValue.ToString().TrimEnd('D') + @"','" + txtSaleWeight.Text + "','" + txtSalesBalanceWeight.Text + @"',
                    '" + txtSaleKg.Text + "','" + txtSaleMuandRate.Text + "','" + saleTotal + @"','" + txtSaleCreditDays.Text + @"',
                    '" + txtSalesDescription.Text + @"',GETDATE(),'1','" + lblSaleInvoiceNo.Text + @"');
                END
                
                DELETE FROM LEDGERS WHERE REF_ID = '" + sdId + @"' AND ENTRY_OF = 'AA SALES'; 
                INSERT INTO LEDGERS(DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
                VALUES('" + dtp_DATE.Value.Date + "', '" + cmbCustomer.SelectedValue.ToString() + "'," + asId + @",'AA SALES',
                '" + lblSaleInvoiceNo.Text + "','" + saleTotal + "', 0,'S.I # " + lblSaleInvoiceNo.Text + " (" + txtSaleWeight.Text + " x " + salesMaterialRate + "/" + txtMaterial.Text + "/" + txtSaleCreditDays.Text + @" DAYS PAYMENT)', 
                '" + Classes.Helper.userId + @"', GETDATE(), 1);

                INSERT INTO LEDGERS(DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
                VALUES('" + dtp_DATE.Value.Date + "', '" +Classes.Helper.aasalesId + "'," + asId + @",'AA SALES',
                '" + lblSaleInvoiceNo.Text + "',0,'" + saleTotal + "', 'S.I # " + lblSaleInvoiceNo.Text + " (" + txtSaleWeight.Text + " x " + salesMaterialRate + "/" + txtMaterial.Text + "/" + txtSaleCreditDays.Text + @" DAYS PAYMENT)', 
                '" + Classes.Helper.userId + @"', GETDATE(), 1);

                ";
                classHelper.query += @" "+updateQuery+@"
                COMMIT TRANSACTION 
                    END TRY 
                BEGIN CATCH 
                        IF @@TRANCOUNT > 0 
                        ROLLBACK TRANSACTION 
                END CATCH";

                if (classHelper.InsertUpdateDelete(classHelper.query) >= 1)
                {
                    classHelper.ShowMessageBox("Record Saved Sucessfully.", "Information");
                    //DialogResult purchasesDialogResult = MessageBox.Show("Print Invoice?", "Purchases Invoice", MessageBoxButtons.YesNo);
                    //if (purchasesDialogResult == DialogResult.Yes)
                    //{
                    //    show_report();
                    //}
                    DialogResult salesDialogResult = MessageBox.Show("Print Invoice?", "Sales Invoice", MessageBoxButtons.YesNo);
                    if (salesDialogResult == DialogResult.Yes)
                    {
                        SaleInvoiceReport();
                    }
                    Clear();
                    LoadGrid();
                }
            }
        }
        //private void SaleSave()
        //{
        //    if (cmbCustomer.SelectedIndex == 0)
        //    {
        //        classHelper.ShowMessageBox("Customer is not selected, please select Customer.", "Warning");
        //        cmbCustomer.Focus();
        //    }
        //    if (cmbSO.SelectedIndex == 0)
        //    {
        //        classHelper.ShowMessageBox("Sales Order  is not selected, please select Sales Order.", "Warning");
        //        cmbSO.Focus();
        //    }
        //    else if (txtSaleWeight.Text.Trim().Equals("0") || txtSaleWeight.Text.Trim().Equals(""))
        //    {
        //        classHelper.ShowMessageBox("Weight field is blank.", "Warning");
        //        txtSaleWeight.Focus();
        //    }
        //    else
        //    {
        //        double muandValue = 37.324;
        //        string dId = pstId;
        //        if (pstId.Equals(""))
        //        {
        //            pstId = "(SELECT MAX(PST_ID) FROM purchases_sales_transfer)";
        //        }
        //        double total = 0;
        //        if (txtMaterial.Text.Equals("OLIEN") || txtMaterial.Text.Equals("RBD"))
        //        {
        //            total = Convert.ToDouble(txtSaleWeight.Text) * (Convert.ToDouble(txtSaleMuandRate.Text) / 37.324);
        //        }
        //        else
        //        {
        //            total = Convert.ToDouble(txtSaleWeight.Text) * Convert.ToDouble(txtSaleMuandRate.Text);
        //            muandValue = 40;
        //        }

        //        classHelper.query = @"BEGIN TRY 
        //        BEGIN TRANSACTION 
        //        IF EXISTS (SELECT PST_ID FROM purchases_sales_transfer WHERE pst_id = '"+pstId+@"')
        //        BEGIN
	       //         UPDATE purchases_sales_transfer SET [date] = '"+dtp_DATE.Value.Date+"',purchases_id = '"+purchaseId+@"',
        //            customer_id = '"+cmbCustomer.SelectedValue.ToString()+"',so_id = '"+cmbSO.SelectedValue.ToString()+@"',
	       //         sales_weight = '"+txtSaleWeight.Text+"',balance_weight = '"+txtBalanceWeight.Text+@"',
        //            kg_rate = '"+txtSaleKg.Text+"',muand_rate = '"+ muandValue + "',total = '"+total+@"',
        //            credit_days = '"+txtCreditDays.Text+"',[description] = '"+txtSalesDescription.Text+@"',
        //            modification_date = GETDATE(),modification_id = '1' WHERE pst_id = '"+pstId+ @"';
        //        END
        //        ELSE
        //        BEGIN
	       //         INSERT INTO purchases_sales_transfer ([date],purchases_id,customer_id,so_id,sales_weight,
	       //         balance_weight,kg_rate,muand_rate,total,credit_days,[description],creation_date,created_by)
	       //         VALUES ('" + dtp_DATE.Value.Date + "','" + purchaseId + "','" + cmbCustomer.SelectedValue.ToString() + @"',
        //            '" + cmbSO.SelectedValue.ToString() + @"','" + txtSaleWeight.Text + "','" + txtBalanceWeight.Text + @"',
        //            '" + txtSaleKg.Text + "','" + muandValue + "','" + total + @"','" + txtCreditDays.Text + @"',
        //            '" + txtSalesDescription.Text + @"',GETDATE(),'1');
        //        END
        //        DELETE FROM MATERIAL_ITEM_LEDGER WHERE REF_NO = '"+ pstId + @"' AND ENTRY_FROM = 'SALES';
        //        DELETE FROM LEDGERS WHERE REF_ID = '" + pstId + @"' AND ENTRY_OF = 'SALES'; 
        //        INSERT INTO LEDGERS(DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
        //        VALUES('" + dtp_DATE.Value.Date + "', '"+ cmbCustomer.SelectedValue.ToString() + "','"+ pstId + @"','SALES',
        //        '"+lblSaleInvoiceNo.Text+"','"+txtSalesTotal.Text+"', 0,'"+lblSaleInvoiceNo.Text+"/" + classHelper.AvoidInjection(txtDescript.Text) + @"', 
        //        '" + Classes.Helper.userId + @"', GETDATE(), 1);
        //        INSERT INTO LEDGERS(DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
        //        VALUES('" + Classes.Helper.ConvertDatetime(dtp_DATE.Value.Date) + "', '" + Classes.Helper.salesId + "', " + pstId + ", 'SALES', '" + lblSaleInvoiceNo.Text + @"', 0,
        //        '" + txtTotal.Text + "','"+lblSaleInvoiceNo.Text+"/" + classHelper.AvoidInjection(txtDescript.Text) + "', '" + Classes.Helper.userId + @"', GETDATE(), 1);
        //        COMMIT TRANSACTION 
        //            END TRY 
        //        BEGIN CATCH 
        //                IF @@TRANCOUNT > 0 
        //                ROLLBACK TRANSACTION 
        //        END CATCH";

        //        if (classHelper.InsertUpdateDelete(classHelper.query) >= 1)
        //        {
        //            classHelper.ShowMessageBox("Record Saved Sucessfully.", "Information");
        //            DialogResult dialogResult = MessageBox.Show("Print Invoice?", "Sales Invoice", MessageBoxButtons.YesNo);
        //            if (dialogResult == DialogResult.Yes)
        //            {
        //                SaleInvoiceReport(); 
        //            }
        //            Clear();
        //            LoadGrid();
        //        }
        //    }
        //}

        //private void SaleInvoiceReport()
        //{
        //    try
        //    {
        //        classHelper.mds.Tables["SaleInvoice"].Clear();
        //        while (classHelper.dr.Read())
        //        {
        //            classHelper.dataR = classHelper.mds.Tables["SaleInvoice"].NewRow();
        //            classHelper.dataR["InvoiceNo"] = lblSaleInvoiceNo.Text;
        //            classHelper.dataR["date"] = dtp_DATE.Value.Date;
        //            classHelper.dataR["customer"] = cmbCustomer.Text;
        //            classHelper.dataR["vehicleNo"] = txtVehNumber.Text;
        //            classHelper.dataR["itemName"] = txtMaterial.Text;
        //            classHelper.dataR["qty"] = txtSaleWeight.Text;
        //            classHelper.dataR["rate"] = txtSaleMuandRate.Text;
        //            classHelper.dataR["amount"] = txtTotal.Text;
        //            classHelper.dataR["dueDate"] = dtp_DATE.Value.Date.AddDays(Convert.ToInt32(txtCreditDays.Text));
        //            classHelper.dataR["description"] = txtSalesDescription.Text;
        //            classHelper.dataR["muandRate"] = "37.324";
        //            classHelper.dataR["totalWeight"] = txtSaleWeight.Text;
        //            classHelper.mds.Tables["SaleInvoice"].Rows.Add(classHelper.dataR);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }

        //    classHelper.rpt = new ERP_Maaz_Oil.Forms.Reporting.frmReports();
        //    classHelper.rpt.GenerateReport("SaleInvoice", classHelper.mds);
        //    classHelper.rpt.ShowDialog();
        //}

        private void Save() {
            //if (cmbSupplier.SelectedIndex == 0)
            //{
            //    classHelper.ShowMessageBox("Supplier is not selected, please select Supplier.", "Warning");
            //    cmbSupplier.Focus();
            //}
            //if (cmbPurchaseOrder.SelectedIndex == 0)
            //{
            //    classHelper.ShowMessageBox("Purchase Order  is not selected, please select Purchase Order.", "Warning");
            //    cmbPurchaseOrder.Focus();
            //}
            //else if (txtVehNumber.Text.Trim().Equals(""))
            //{
            //    classHelper.ShowMessageBox("Vehicle Number field is blank.", "Warning");
            //    txtVehNumber.Focus();
            //}
            //else if (txtKorangiWeight.Text.Trim().Equals("0") || txtKorangiWeight.Text.Trim().Equals(""))
            //{
            //    classHelper.ShowMessageBox("Terminal Weight field is blank.", "Warning");
            //    txtKorangiWeight.Focus();
            //}
            //else
            //{
            //    decimal muandValue = 37.324M;
            //    if (!txtMaterial.Text.Equals("CANOLA"))
            //    {
            //        muandValue = 40;
            //    }

            //    string dId = id;
            //    if (id.Equals(""))
            //    {
            //        id = "(SELECT MAX(PI_ID) FROM PURCHASES)";
            //    }
            //    //     CASE WHEN C.MATERIAL_NAME = 'OLIEN/RBD' THEN(A.NET_WEIGHT * (A.MUAND_RATE / A.MUAND_VALUE)) ELSE
            //    //END
            //    //
            //    decimal total = 0;
            //    if (txtMaterial.Text.Equals("OLIEN") || txtMaterial.Text.Equals("RBD"))
            //    {
            //        total = Convert.ToDecimal(txtKorangiWeight.Text) * (Convert.ToDecimal(txtMuandRate.Text) / Convert.ToDecimal(muandValue));
            //    }
            //    else {
            //        total = Convert.ToDecimal(txtKgRate.Text) * Convert.ToDecimal(txtKorangiWeight.Text);
            //    }
            //    //(SELECT SUM(NET_WEIGHT) FROM PURCHASES WHERE PO_ID = '" + cmbPurchaseOrder.SelectedValue.ToString() + "') WHERE PO_ID = '" + cmbPurchaseOrder.SelectedValue.ToString() + @"'
            //    classHelper.query = "BEGIN TRAN ";
            //    classHelper.query += @"IF EXISTS (select PI_ID from PURCHASES WHERE PI_ID ='" + dId + @"') 
            //        BEGIN
            //        UPDATE PURCHASES SET DATE = '" + Classes.Helper.ConvertDatetime(dtp_DATE.Value.Date) + "',SUPPLIER_ID = '" + cmbSupplier.SelectedValue.ToString() + @"',
            //        PO_ID = '" + cmbPurchaseOrder.SelectedValue.ToString() + "',VEHICLE_NO = '" + txtVehNumber.Text + "',DESCRIPTION = '" + txtDescript.Text + @"',
            //        NET_WEIGHT = '" + txtKorangiWeight.Text + "',KORANGI_WEIGHT = '" + txtKorangiWeight.Text + "',KG_RATE = '" + txtKgRate.Text + @"',
            //        MUAND_RATE = '" + txtMuandRate.Text + "',MUAND_VALUE = '" + muandValue + "',CREDIT_DAYS = '" + txtCreditDays.Text + @"',
            //        MODIFICATION_DATE = GETDATE(),MODIFIED_BY = '" + Classes.Helper.userId + @"' WHERE PI_ID = '" + dId + @"';
            //        END
            //        ELSE
            //        BEGIN
            //        INSERT INTO PURCHASES (DATE,SUPPLIER_ID,PO_ID,VEHICLE_NO,DESCRIPTION,NET_WEIGHT,KORANGI_WEIGHT,KG_RATE,MUAND_RATE,MUAND_VALUE,CREDIT_DAYS,CREATION_DATE,CREATED_BY,INVOICE_NO) 
            //        VALUES ('" + Classes.Helper.ConvertDatetime(dtp_DATE.Value.Date) + "','" + cmbSupplier.SelectedValue.ToString() + "','" + cmbPurchaseOrder.SelectedValue.ToString() + "','" + txtVehNumber.Text + "','" + txtDescript.Text + "','" + txtKorangiWeight.Text + @"',
            //        '" + txtKorangiWeight.Text + "','" + txtKgRate.Text + "','" + txtMuandRate.Text + "','" + muandValue + "','" + txtCreditDays.Text + "',GETDATE(),'" + Classes.Helper.userId + "','" + lblPI.Text + @"')
            //        END
            //        UPDATE PURCHASES_ORDER SET REC_WEIGHT = REC_WEIGHT - '" + lastWeight + "' + '" + txtKorangiWeight.Text +"' WHERE PO_ID = '"+ cmbPurchaseOrder.SelectedValue.ToString() + @"';

            //        DELETE FROM MATERIAL_ITEM_LEDGER WHERE REF_NO = '" + dId + @"' AND ENTRY_FROM = 'PURCHASES'
            //        INSERT INTO MATERIAL_ITEM_LEDGER 
            //        (DATE,MATERIAL_ID,REF_NO,ENTRY_FROM,STOCK_IN,STOCK_OUT,COST_AMT,SALE_AMT,L_ID,CREATED_BY,CREATION_DATE,COMPANY_ID) 
            //        VALUES ('" + Classes.Helper.ConvertDatetime(dtp_DATE.Value.Date) + "',(SELECT MATERIAL_ID FROM PURCHASES_ORDER WHERE PO_ID = '" + cmbPurchaseOrder.SelectedValue.ToString() + "')," + id + ",'PURCHASES','" + txtKorangiWeight.Text + "',0,'" + Convert.ToDecimal(txtTotal.Text) / Convert.ToDecimal(txtKorangiWeight.Text) + @"',
            //                0,1,'" + Classes.Helper.userId + @"',GETDATE(),1);
            //        DELETE FROM LEDGERS WHERE REF_ID = '" + dId + @"' AND ENTRY_OF = 'PURCHASES'
            //        INSERT INTO LEDGERS(DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
            //        VALUES('" + Classes.Helper.ConvertDatetime(dtp_DATE.Value.Date) + "','" + cmbSupplier.SelectedValue.ToString() + "'," + id + ",'PURCHASES','" + lblPI.Text + @"',
            //        0,'" + Math.Round(total) + "','P.I # " + lblPI.Text + " ("+txtKorangiWeight.Text+" x "+txtMuandRate.Text+"/" + txtMaterial.Text +"/"+txtCreditDays.Text+" DAYS PAYMENT)','" + Classes.Helper.userId + @"',GETDATE(),1);
            //        INSERT INTO LEDGERS(DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
            //        VALUES('" + Classes.Helper.ConvertDatetime(dtp_DATE.Value.Date) + "','"+Classes.Helper.purchasesId+"'," + id + ",'PURCHASES','" + lblPI.Text + @"',
            //        '" + Math.Round(total) + "',0,'P.I # " + lblPI.Text + " (" + txtKorangiWeight.Text + " x " + txtMuandRate.Text + "/" + txtMaterial.Text + "/" + txtCreditDays.Text + " DAYS PAYMENT)','" + Classes.Helper.userId + @"',GETDATE(),1);";
            //    classHelper.query += "COMMIT TRAN";
            //    if (classHelper.InsertUpdateDelete(classHelper.query) >= 1)
            //    {
            //        classHelper.ShowMessageBox("Record Saved Sucessfully.", "Information");
            //        DialogResult dialogResult = MessageBox.Show("Print Invoice?", "Purchases Invoice", MessageBoxButtons.YesNo);
            //        if (dialogResult == DialogResult.Yes)
            //        {
            //            show_report();
            //        }
            //        Clear();
            //        LoadGrid();
            //    }
            //}
        }

        //private void KgRateCalculation()
        //{
        //    decimal netWeight = 0;
        //    if (!txtKorangiWeight.Text.Equals(""))
        //    {
        //        netWeight = Convert.ToDecimal(txtKorangiWeight.Text);
        //    }
        //    decimal kgRate = 0;
        //    if (!txtKgRate.Text.Equals(""))
        //    {
        //        kgRate = Convert.ToDecimal(txtKgRate.Text);
        //    }
        //    txtTotal.Text = Math.Round((netWeight * kgRate)).ToString();

        //    decimal muandValue = 37.324M;
        //    if (!txtMaterial.Text.Equals("CANOLA"))
        //    {
        //        muandValue = 40;
        //    }
        //    txtMuandRate.Text = Math.Round((kgRate * muandValue)).ToString();
            
        //}
        private void SaleInvoiceReport()
        {
            decimal muandValue = 37.324M;
            if (txtMaterial.Text.Equals("CANOLA"))
            {
                muandValue = 40;
            }

            classHelper.mds.Tables["PI"].Clear();
            classHelper.dataR = classHelper.mds.Tables["PI"].NewRow();
            classHelper.dataR["PI_num"] = lblSaleInvoiceNo.Text;
            classHelper.dataR["date"] = Classes.Helper.ConvertDatetime(dtp_DATE.Value.Date);
            classHelper.dataR["supplier"] = cmbCustomer.Text;
            classHelper.dataR["description"] = txtSalesDescription.Text;
            classHelper.dataR["material_type"] = txtMaterialType.Text;
            classHelper.dataR["material"] = txtMaterial.Text;
            classHelper.dataR["weight"] = Convert.ToDouble(txtSaleWeight.Text);
            classHelper.dataR["kgRate"] = Convert.ToDouble(txtSaleKg.Text);
            classHelper.dataR["munadRate"] = Convert.ToDouble(txtSaleMuandRate.Text);
            classHelper.dataR["m_weight"] = Convert.ToDouble(txtSaleWeight.Text) / Convert.ToDouble(muandValue);
            classHelper.dataR["total"] = txtSalesTotal.Text;
            classHelper.dataR["creditDays"] = txtSaleCreditDays.Text;
            classHelper.dataR["PO_no"] = cmbSO.Text;
            //classHelper.dataR["vehicleNo"] = txtVehNumber.Text;
            classHelper.dataR["korangiWeight"] = txtSalesBalanceWeight.Text;
            classHelper.dataR["dueDate"] = dtp_DATE.Value.Date.AddDays(Convert.ToInt32(txtSaleCreditDays.Text));
            classHelper.dataR["muandValue"] = Convert.ToDouble(muandValue);
            classHelper.mds.Tables["PI"].Rows.Add(classHelper.dataR);
            classHelper.rpt = new ERP_Maaz_Oil.Forms.Reporting.frmReports();
            classHelper.rpt.GenerateReport("PSI", classHelper.mds);
            classHelper.rpt.ShowDialog();
        }
        //private void show_report()
        //{
        //    decimal muandValue = 37.324M;
        //    if (txtMaterial.Text.Equals("CANOLA"))
        //    {
        //        muandValue = 40;
        //    }

        //    classHelper.mds.Tables["PI"].Clear();
        //    classHelper.dataR = classHelper.mds.Tables["PI"].NewRow();
        //    classHelper.dataR["PI_num"] = lblPI.Text;
        //    classHelper.dataR["date"] = Classes.Helper.ConvertDatetime(dtp_DATE.Value.Date);
        //    classHelper.dataR["supplier"] = cmbSupplier.Text;
        //    classHelper.dataR["description"] = txtDescript.Text;
        //    classHelper.dataR["material_type"] = txtMaterialType.Text;
        //    classHelper.dataR["material"] = txtMaterial.Text;
        //    classHelper.dataR["weight"] = Convert.ToDouble(txtKorangiWeight.Text);
        //    classHelper.dataR["kgRate"] = Convert.ToDouble(txtKgRate.Text);
        //    classHelper.dataR["munadRate"] = Convert.ToDouble(txtMuandRate.Text);
        //    classHelper.dataR["m_weight"] = Convert.ToDouble(txtKorangiWeight.Text) / Convert.ToDouble(muandValue);
        //    classHelper.dataR["total"] = txtTotal.Text;
        //    classHelper.dataR["creditDays"] = txtCreditDays.Text;
        //    classHelper.dataR["PO_no"] = cmbPurchaseOrder.Text;
        //    classHelper.dataR["vehicleNo"] = txtVehNumber.Text;
        //    classHelper.dataR["korangiWeight"] = txtKorangiWeight.Text;
        //    classHelper.dataR["dueDate"] = dtp_DATE.Value.Date.AddDays(Convert.ToInt32(txtCreditDays.Text));
        //    classHelper.dataR["muandValue"] = Convert.ToDouble(muandValue);
        //    classHelper.mds.Tables["PI"].Rows.Add(classHelper.dataR);
        //    classHelper.rpt = new ERP_Maaz_Oil.Forms.Reporting.frmReports();
        //    classHelper.rpt.GenerateReport("PI", classHelper.mds);
        //    classHelper.rpt.ShowDialog();
        //}

        //get data from grid on click
        private void load_data_fromGrid(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.grdSEARCH.Rows[e.RowIndex];
                //purchaseId = row.Cells["PURCHASES ID"].Value.ToString();
                asId = row.Cells["as_id"].Value.ToString();
                is_edit = 1;
                soId = row.Cells["so_id"].Value.ToString()+"D";
                //lblPI.Text = row.Cells["INVOICE_NO"].Value.ToString();
                dtp_DATE.Text = row.Cells["DATE"].Value.ToString();
                //cmbSupplier.SelectedValue = row.Cells["SUPPLIER_ID"].Value.ToString();
                //cmbPurchaseOrder.SelectedValue = row.Cells["PO_ID"].Value.ToString();
                //txtPODate.Text = row.Cells["VEHICLE_NO"].Value.ToString();
                //txtMaterialType.Text = row.Cells["MATERIAL TYPE"].Value.ToString();
                txtMaterial.Text = row.Cells["MATERIAL_NAME"].Value.ToString();
                //txtOrderWeight.Text = row.Cells["PO WEIGHT"].Value.ToString();
                //txtBalanceWeight.Text = row.Cells["BALANCE WEIGHT"].Value.ToString();
                //txtVehNumber.Text = row.Cells["VEHICLE_NO"].Value.ToString();
                //txtKorangiWeight.Text = row.Cells["TERMINAL WEIGHT"].Value.ToString();
                //txtKgRate.Text = row.Cells["KG_RATE"].Value.ToString();
                //txtMuandRate.Text = row.Cells["MUAND_RATE"].Value.ToString();
                //txtTotal.Text = row.Cells["PURCHASE AMOUNT"].Value.ToString();
                //txtCreditDays.Text = row.Cells["PURCHASE CREDIT DAYS"].Value.ToString();
                //txtDescript.Text = row.Cells["DESCRIPTION"].Value.ToString();

                lblSaleInvoiceNo.Text = row.Cells["SALES INVOICE"].Value.ToString();
                cmbCustomer.SelectedValue = row.Cells["customer_id"].Value.ToString();
                cmbSO.SelectedValue = row.Cells["so_id"].Value.ToString() + "D";
                txtSODate.Text = row.Cells["SO DATE"].Value.ToString();
                txtSaleKg.Text = row.Cells["SALE KG RATE"].Value.ToString();
                
                txtSaleWeight.Text = row.Cells["sales_weight"].Value.ToString();
                txtSaleMuandRate.Text = row.Cells["SALES MUAND RATE"].Value.ToString();
                txtSalesTotal.Text = Math.Round(Convert.ToDecimal(row.Cells["SALES AMOUNT"].Value.ToString()),2).ToString();
                txtSaleCreditDays.Text = row.Cells["SALES CREDIT DAY"].Value.ToString();
                txtSalesDescription.Text = row.Cells["SALES DESCRIPTION"].Value.ToString();
                lastWeight = Convert.ToDecimal(row.Cells["sales_weight"].Value.ToString());
                remainingWeight = Convert.ToDecimal(row.Cells["SO BALANCE WEIGHT"].Value.ToString())+Convert.ToDecimal(row.Cells["sales_weight"].Value.ToString());
                txtSalesBalanceWeight.Text = (float.Parse(row.Cells["sales_weight"].Value.ToString()) +
                    float.Parse(row.Cells["SO BALANCE WEIGHT"].Value.ToString())).ToString();
            }
        }

        private void frm_AddGroupAccounts_Load(object sender, EventArgs e)
        {
            //GeneratePINumber();
            LoadGrid();
            //LoadSuppliers();
            GenerateSINumber();
            //LoadGrid();
            LoadCustomers();
        }

        private void txtSEARCH_TextChanged(object sender, EventArgs e)
        {
           classHelper.PurchaseSale_search(txtSEARCH, grdSEARCH);
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {
            //Save();
            SaleSave();
        }

        private void cmbPACCOUNT_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbPurchaseOrder.SelectedIndex != 0)
            //{
            //    LoadPODetails();
            //}
            //else
            //{
            //    txtMaterial.Clear();
            //    txtMaterialType.Clear();
            //    txtBalanceWeight.Clear();
            //    txtKgRate.Clear();
            //    txtMuandRate.Clear();
            //    txtTotal.Clear();
            //    txtUnit.Clear();
            //    txtOrderWeight.Clear();
            //}
        }

        private void grdSEARCH_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //grdSEARCH.Columns["PURCHASES ID"].Visible = false;
            //grdSEARCH.Columns["SUPPLIER_ID"].Visible = false;
            grdSEARCH.Columns["AS_ID"].Visible = false;
            grdSEARCH.Columns["so_id"].Visible = false;
            grdSEARCH.Columns["customer_id"].Visible = false;
        }

        private void btnCLEAR_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void grdSEARCH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           load_data_fromGrid(e); 
        }


        
        

        private void cmbVENDOR_TextUpdate(object sender, EventArgs e)
        {
            classHelper.CmbTextUpdate(sender as ComboBox);
        }

        

        private void cmbCITY_DropDown(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown += new PreviewKeyDownEventHandler(cmbCITY_PreviewKeyDown);
        }

        private void cmbCITY_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown -= cmbCITY_PreviewKeyDown;
            if (cbo.DroppedDown) cbo.Focus();
        }

        

        //private void cmbSupplier_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cmbSupplier.SelectedIndex != 0)
        //    {
        //        LoadPO();
        //        cmbPurchaseOrder.Enabled = true;
        //    }
        //    else
        //    {
        //        if (cmbPurchaseOrder.Items.Count > 0) {
        //            cmbPurchaseOrder.SelectedIndex = 0;
        //        }
        //    }
        //}

        private void txtKgRate_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtMuandRate_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtNetWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        //private void txtNetWeight_TextChanged(object sender, EventArgs e)
        //{
        //    KgRateCalculation();
        //}

        //private void btn_VIEW_VOUCHER_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (classHelper.record_search_grid(grdSEARCH, lblPI.Text, 1) == 1)
        //        { show_report(); }
        //        else
        //        {
        //            MessageBox.Show("Invoice not found in record or save the invoice first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }

        //    }
        //    catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        //}

        //private void btnDetailReport_Click(object sender, EventArgs e)
        //{
        //    if (!cmbPurchaseOrder.SelectedValue.ToString().Equals("0")) {
        //        clsPOInward.POInward_Report(Convert.ToInt32(cmbPurchaseOrder.SelectedValue.ToString()));
        //    }
        //}

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCustomer.SelectedIndex != 0)
            {
                if (is_edit == 0)
                {
                    LoadSO("0");
                }
                else
                {
                    LoadSO(soId);
                }
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



        private void cmbSO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSO.SelectedIndex > 0)
            {
                string soId = cmbSO.SelectedValue.ToString();
                if (soId[soId.Length - 1] == 'D')
                {
                    GetSODetails();
                    txtSaleMuandRate.Text = classHelper.GetSOMuandRate(Convert.ToInt32(cmbSO.SelectedValue.ToString().TrimEnd('D')), 'D');
                    remainingWeight = Convert.ToDecimal(txtSalesBalanceWeight.Text);
                }
            }
        }

        //private void txtKorangiWeight_TextChanged(object sender, EventArgs e)
        //{
        //    PurchaseKgRateCalculation();
        //}

        private void txtSaleWeight_TextChanged(object sender, EventArgs e)
        {
            SalesKgRateCalculation();
        }

        private void txtSalesDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtSalesTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void txtSaleCreditDays_TextChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void txtSaleKg_TextChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void txtSaleMuandRate_TextChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void btnViewSalesInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                if (classHelper.record_search_grid(grdSEARCH, lblSaleInvoiceNo.Text, 17) == 1)
                { SaleInvoiceReport(); }
                else
                {
                    MessageBox.Show("Invoice not found in record or save the invoice first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void txtPODate_MouseClick(object sender, MouseEventArgs e)
        {
            classHelper.FocusField(sender as TextBox);
        }

        private void txtPODate_Enter(object sender, EventArgs e)
        {
            classHelper.FocusField(sender as TextBox);
        }

        private void btnViewSODetails_Click(object sender, EventArgs e)
        {
            if (!(cmbSO.SelectedValue??0).ToString().Equals("0"))
            {
                clsSOInward.SOInward_Report(Convert.ToInt32(cmbSO.SelectedValue.ToString().TrimEnd('D')));
            }
        }

        private void txtOrderWeight_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }

