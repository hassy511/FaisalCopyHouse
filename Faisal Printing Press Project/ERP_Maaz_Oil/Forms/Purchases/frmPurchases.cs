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
    public partial class frmPurchases : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        string id = "";
        int is_edit = 0;
        float lastWeight = 0;
        Purchases.POInwardReport clsPOInward = new Purchases.POInwardReport();
        public frmPurchases()
        {
            InitializeComponent();
        }

        private void LoadPODetails()
        {
            classHelper.query = @"SELECT (A.WEIGHT - A.REC_WEIGHT) AS [WEIGHT],B.MATERIAL_NAME,C.M_TYPE_NAME,D.UNIT_NAME,A.KG_RATE,A.MUAND_RATE,
            ((A.WEIGHT - A.REC_WEIGHT) * A.KG_RATE) AS [TOTAL],A.CREDIT_DAYS,A.MUAND_VALUE,A.WEIGHT AS [ORDERED WEIGHT],FORMAT(A.DATE,'dd/MM/yyyy') as [DATE]
            ,A.DESCRIPTION FROM PURCHASES_ORDER A,MATERIALS B, MATERIAL_TYPES C,UNITS D
            WHERE A.MATERIAL_ID = B.MATERIAL_ID AND B.M_TYPE_ID = C.M_TYPE_ID AND B.UNIT_ID = D.UNIT_ID
            AND A.PO_ID = '" + cmbPurchaseOrder.SelectedValue.ToString()+"'";
            classHelper.LoadPODetails(classHelper.query, txtMaterialType, txtMaterial, txtNetWeight,txtUnit,txtKgRate,txtDescript,
                txtTotal,txtCreditDays, txtMuandRate, txtOrderWeight,txtBalanceWeight,txtPODate,txtMuandValue);
        }

        private void GeneratePINumber()
        {
            classHelper.query = "SELECT COUNT(PI_ID)+1 FROM PURCHASES";
            lblPI.Text = "PI-" + classHelper.GetMaxValue(classHelper.query) + "-" + DateTime.Now.Year;
        }

        private void LoadGrid()
        {
            classHelper.query = @"SELECT A.PI_ID,A.DATE,A.SUPPLIER_ID,B.COA_NAME AS [SUPPLIER],A.PO_ID,C.PO_NUMBER AS [PO #],A.INVOICE_NO as [INVOICE #],
            A.VEHICLE_NO AS [VEHICLE #],D.M_TYPE_ID,E.M_TYPE_NAME AS [MATERIAL TYPE],C.MATERIAL_ID,D.MATERIAL_NAME AS [MATERIAL],A.NET_WEIGHT AS [RECEIVED WEIGHT],
            A.KORANGI_WEIGHT AS [TERMINAL WEIGHT],A.KG_RATE AS [KG RATE],A.MUAND_RATE AS [MUAND RATE],
            CASE WHEN A.KG_RATE = '0' THEN (A.MUAND_RATE / A.MUAND_VALUE) * A.NET_WEIGHT ELSE A.NET_WEIGHT * A.KG_RATE END AS [TOTAL], 
            A.DESCRIPTION,A.CREDIT_DAYS AS [CREDIT DAYS],F.UNIT_NAME,A.MUAND_VALUE
            FROM PURCHASES A,COA B,PURCHASES_ORDER C,MATERIALS D,MATERIAL_TYPES E,UNITS F
            WHERE A.SUPPLIER_ID = B.COA_ID AND A.PO_ID = C.PO_ID AND C.MATERIAL_ID = D.MATERIAL_ID AND D.M_TYPE_ID = E.M_TYPE_ID AND D.UNIT_ID = F.UNIT_ID
            ORDER BY A.DATE DESC";
            classHelper.LoadGrid(grdSEARCH, classHelper.query);
        }
        //load COMBO BOXES
        private void LoadSuppliers()
        {
            classHelper.LoadSuppliers(cmbSupplier);
        }
        private void LoadPO()
        {
            classHelper.LoadPurchaseOrder(cmbPurchaseOrder,Convert.ToInt16(cmbSupplier.SelectedValue.ToString()), is_edit);
        }
        
        //clear fields in form
        private void Clear() {
            GeneratePINumber();
            dtp_DATE.Value = DateTime.Now;
            cmbSupplier.SelectedIndex = 0;
            cmbPurchaseOrder.Enabled = false;
            cmbPurchaseOrder.SelectedIndex = 0;
            txtVehNumber.Clear();
            txtMaterialType.Clear();
            txtPODate.Clear();
            txtMaterial.Clear();
            txtDescript.Clear();
            txtNetWeight.Text = "0";
            txtKorangiWeight.Text = "0";
            txtKgRate.Text = "0";
            txtMuandRate.Text = "0";
            txtMuandValue.Text = "0";
            txtTotal.Text = "0";
            txtCreditDays.Text = "0";
            txtSEARCH.Clear();
            txtUnit.Clear();
            id = "";
            lastWeight = 0;
            is_edit = 0;
            txtOrderWeight.Clear();
        }

        private void Save() {
            if (cmbSupplier.SelectedIndex == 0)
            {
                classHelper.ShowMessageBox("Supplier is not selected, please select Supplier.", "Warning");
                cmbSupplier.Focus();
            }
            if (cmbPurchaseOrder.SelectedIndex == 0)
            {
                classHelper.ShowMessageBox("Purchase Order  is not selected, please select Purchase Order.", "Warning");
                cmbPurchaseOrder.Focus();
            }
            else if (txtVehNumber.Text.Trim().Equals(""))
            {
                classHelper.ShowMessageBox("Vehicle Number field is blank.", "Warning");
                txtVehNumber.Focus();
            }
            else if (txtNetWeight.Text.Trim().Equals("0") || txtNetWeight.Text.Trim().Equals(""))
            {
                classHelper.ShowMessageBox("Weight field is blank.", "Warning");
                txtNetWeight.Focus();
            }
            else
            {
                string dId = id;
                if (id.Equals(""))
                {
                    id = "(SELECT MAX(PI_ID) FROM PURCHASES)";
                }

                double purchasesMaterialRate = purchasesMaterialRate = Convert.ToDouble(txtKgRate.Text); 
                if (txtMaterial.Text.Equals("OLIEN") || txtMaterial.Text.Equals("RBD") || txtMaterial.Text.Equals("SOYA BEAN") || txtMaterial.Text.Equals("OLIEN/RBD"))
                {
                        purchasesMaterialRate = Convert.ToDouble(txtMuandRate.Text);
                }
                //(SELECT SUM(NET_WEIGHT) FROM PURCHASES WHERE PO_ID = '" + cmbPurchaseOrder.SelectedValue.ToString() + "') WHERE PO_ID = '" + cmbPurchaseOrder.SelectedValue.ToString() + @"'
                classHelper.query = "BEGIN TRAN ";
                classHelper.query += @"IF EXISTS (select PI_ID from PURCHASES WHERE PI_ID ='" + dId + @"') 
                    BEGIN
                    UPDATE PURCHASES SET DATE = '" + dtp_DATE.Value.ToString() + "',SUPPLIER_ID = '" + cmbSupplier.SelectedValue.ToString() + @"',
                    PO_ID = '" + cmbPurchaseOrder.SelectedValue.ToString() + "',VEHICLE_NO = '" + txtVehNumber.Text + "',DESCRIPTION = '" + txtDescript.Text + @"',
                    NET_WEIGHT = '" + txtNetWeight.Text + "',KORANGI_WEIGHT = '" + txtKorangiWeight.Text + "',KG_RATE = '" + txtKgRate.Text + @"',
                    MUAND_RATE = '" + txtMuandRate.Text + "',MUAND_VALUE = '" + txtMuandValue.Text + "',CREDIT_DAYS = '" + txtCreditDays.Text + @"',
                    MODIFICATION_DATE = GETDATE(),MODIFIED_BY = '" + Classes.Helper.userId + @"' WHERE PI_ID = '" + dId + @"';
                    END
                    ELSE
                    BEGIN
                    INSERT INTO PURCHASES (DATE,SUPPLIER_ID,PO_ID,VEHICLE_NO,DESCRIPTION,NET_WEIGHT,KORANGI_WEIGHT,KG_RATE,MUAND_RATE,MUAND_VALUE,CREDIT_DAYS,CREATION_DATE,CREATED_BY,INVOICE_NO) 
                    VALUES ('" + dtp_DATE.Value.ToString() + "','" + cmbSupplier.SelectedValue.ToString() + "','" + cmbPurchaseOrder.SelectedValue.ToString() + "','" + txtVehNumber.Text + "','" + txtDescript.Text + "','" + txtNetWeight.Text + @"',
                    '" + txtKorangiWeight.Text + "','" + txtKgRate.Text + "','" + txtMuandRate.Text + "','" + txtMuandValue.Text + "','" + txtCreditDays.Text + "',GETDATE(),'" + Classes.Helper.userId + "','" + lblPI.Text + @"')
                    END
                    UPDATE PURCHASES_ORDER SET REC_WEIGHT = REC_WEIGHT - '" + lastWeight + "' + '" + txtNetWeight.Text +"' WHERE PO_ID = '"+ cmbPurchaseOrder.SelectedValue.ToString() + @"';

                    DELETE FROM MATERIAL_ITEM_LEDGER WHERE REF_NO = '" + dId + @"' AND ENTRY_FROM = 'PURCHASES'
                    INSERT INTO MATERIAL_ITEM_LEDGER 
                    (DATE,MATERIAL_ID,REF_NO,ENTRY_FROM,STOCK_IN,STOCK_OUT,COST_AMT,SALE_AMT,L_ID,CREATED_BY,CREATION_DATE,COMPANY_ID) 
                    VALUES ('" + dtp_DATE.Value.ToString() + "',(SELECT MATERIAL_ID FROM PURCHASES_ORDER WHERE PO_ID = '" + cmbPurchaseOrder.SelectedValue.ToString() + "')," + id + ",'PURCHASES','" + txtNetWeight.Text + "',0,'" + Convert.ToDecimal(txtTotal.Text) / Convert.ToDecimal(txtNetWeight.Text) + @"',
                            0,1,'" + Classes.Helper.userId + @"',GETDATE(),1);
                    DELETE FROM LEDGERS WHERE REF_ID = '" + dId + @"' AND ENTRY_OF = 'PURCHASES'
                    INSERT INTO LEDGERS(DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
                    VALUES('" + dtp_DATE.Value.ToString() + "','" + cmbSupplier.SelectedValue.ToString() + "'," + id + ",'PURCHASES','" + lblPI.Text + @"',
                    0,'" + txtTotal.Text + "','P.I # " + lblPI.Text + " (" + txtKorangiWeight.Text + " x " + purchasesMaterialRate + "/" + txtMaterial.Text + "/" + txtCreditDays.Text + " DAYS PAYMENT/ VEHICLE # " + txtVehNumber.Text + ")','" + Classes.Helper.userId + @"',GETDATE(),1);
                    INSERT INTO LEDGERS(DATE, COA_ID, REF_ID, ENTRY_OF, FOLIO, DEBIT, CREDIT, DESCRIPTIONS, CREATED_BY, CREATION_DATE, COMPANY_ID)
                    VALUES('" + dtp_DATE.Value.ToString() + "','"+Classes.Helper.purchasesId+"'," + id + ",'PURCHASES','" + lblPI.Text + @"',
                    '" + txtTotal.Text + "',0,'P.I # " + lblPI.Text + " (" + txtKorangiWeight.Text + " x " + purchasesMaterialRate + "/" + txtMaterial.Text + "/" + txtCreditDays.Text + " DAYS PAYMENT/ VEHICLE # " + txtVehNumber.Text + ")','" + Classes.Helper.userId + @"',GETDATE(),1);";
                classHelper.query += "COMMIT TRAN";
                if (classHelper.InsertUpdateDelete(classHelper.query) >= 1)
                {
                    classHelper.ShowMessageBox("Record Saved Sucessfully.", "Information");
                    DialogResult dialogResult = MessageBox.Show("Print Invoice?", "Purchases Invoice", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        show_report();
                    }
                    Clear();
                    LoadGrid();
                }
            }
        }

        private void KgRateCalculation()
        {
            decimal netWeight = 0;
            if (!txtNetWeight.Text.Equals(""))
            {
                netWeight = Convert.ToDecimal(txtNetWeight.Text);
            }
            decimal kgRate = 0;
            if (!txtKgRate.Text.Equals(""))
            {
                kgRate = Convert.ToDecimal(txtKgRate.Text);
            }
            txtTotal.Text = Math.Round((netWeight * kgRate)).ToString();

            decimal muandValue = 0;
            if (!txtMuandValue.Text.Equals(""))
            {
                muandValue = Convert.ToDecimal(txtMuandValue.Text);
            }
            
            txtMuandRate.Text = Math.Round((kgRate * muandValue)).ToString();
            
        }

        private void show_report()
        {
            classHelper.mds.Tables["PI"].Clear();
            classHelper.dataR = classHelper.mds.Tables["PI"].NewRow();
            classHelper.dataR["PI_num"] = lblPI.Text;
            classHelper.dataR["date"] = dtp_DATE.Value.ToShortDateString();
            classHelper.dataR["supplier"] = cmbSupplier.Text;
            classHelper.dataR["description"] = txtDescript.Text;
            classHelper.dataR["material_type"] = txtMaterialType.Text;
            classHelper.dataR["material"] = txtMaterial.Text;
            classHelper.dataR["weight"] = Convert.ToDouble(txtNetWeight.Text);
            classHelper.dataR["kgRate"] = Convert.ToDouble(txtKgRate.Text);
            classHelper.dataR["munadRate"] = Convert.ToDouble(txtMuandRate.Text);
            classHelper.dataR["m_weight"] = Convert.ToDouble(txtNetWeight.Text) / Convert.ToDouble(txtMuandValue.Text);
            classHelper.dataR["total"] = txtTotal.Text;
            classHelper.dataR["creditDays"] = txtCreditDays.Text;
            classHelper.dataR["PO_no"] = cmbPurchaseOrder.Text;
            classHelper.dataR["vehicleNo"] = txtVehNumber.Text;
            classHelper.dataR["korangiWeight"] = txtKorangiWeight.Text;
            classHelper.dataR["dueDate"] = DateTime.Now.AddDays(Convert.ToInt32(txtCreditDays.Text));
            classHelper.dataR["muandValue"] = Convert.ToDouble(txtMuandValue.Text);
            classHelper.mds.Tables["PI"].Rows.Add(classHelper.dataR);
            classHelper.rpt = new ERP_Maaz_Oil.Forms.Reporting.frmReports();
            classHelper.rpt.GenerateReport("PI", classHelper.mds);
            classHelper.rpt.ShowDialog();
        }

        //get data from grid on click
        private void load_data_fromGrid(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.grdSEARCH.Rows[e.RowIndex];
                id = row.Cells["PI_ID"].Value.ToString();
                is_edit = 1;
                dtp_DATE.Text = row.Cells["DATE"].Value.ToString();
                cmbSupplier.SelectedValue = row.Cells["SUPPLIER_ID"].Value.ToString();
                txtVehNumber.Text = row.Cells["VEHICLE #"].Value.ToString();
                txtMaterialType.Text = row.Cells["M_TYPE_ID"].Value.ToString();
                txtMaterial.Text = row.Cells["MATERIAL"].Value.ToString();
                txtNetWeight.Text = row.Cells["RECEIVED WEIGHT"].Value.ToString();
                txtKorangiWeight.Text = row.Cells["TERMINAL WEIGHT"].Value.ToString();
                txtKgRate.Text = row.Cells["KG RATE"].Value.ToString();
                txtMuandRate.Text = row.Cells["MUAND RATE"].Value.ToString();
                txtTotal.Text = row.Cells["TOTAL"].Value.ToString();
                txtDescript.Text = row.Cells["DESCRIPTION"].Value.ToString();
                txtCreditDays.Text = row.Cells["CREDIT DAYS"].Value.ToString();
                txtUnit.Text = row.Cells["UNIT_NAME"].Value.ToString();
                txtMuandValue.Text = row.Cells["MUAND_VALUE"].Value.ToString();
                lblPI.Text = row.Cells["INVOICE #"].Value.ToString();
                lastWeight = float.Parse(row.Cells["RECEIVED WEIGHT"].Value.ToString());
                cmbPurchaseOrder.SelectedValue = row.Cells["PO_ID"].Value.ToString();

            }
        }

        private void frm_AddGroupAccounts_Load(object sender, EventArgs e)
        {
            GeneratePINumber();
            LoadGrid();
            LoadSuppliers();
        }

        private void txtSEARCH_TextChanged(object sender, EventArgs e)
        {
           classHelper.PurchaseRaw_search(txtSEARCH, grdSEARCH);
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void cmbPACCOUNT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPurchaseOrder.SelectedIndex != 0)
            {
                LoadPODetails();
            }
            else {
                txtMaterial.Clear();
                txtMaterialType.Clear();
                txtNetWeight.Clear();
                txtBalanceWeight.Clear();
                txtKgRate.Clear();
                txtMuandRate.Clear();
                txtTotal.Clear();
                txtUnit.Clear();
                txtMuandValue.Clear();
                txtOrderWeight.Clear();
            }
        }

        private void grdSEARCH_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            grdSEARCH.Columns["PI_ID"].Visible = false;
            grdSEARCH.Columns["SUPPLIER_ID"].Visible = false;
            grdSEARCH.Columns["PO_ID"].Visible = false;
           grdSEARCH.Columns["M_TYPE_ID"].Visible = false;
            grdSEARCH.Columns["MATERIAL_ID"].Visible = false;
            //grdSEARCH.Columns[19].Visible = false;
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

        

        private void cmbSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSupplier.SelectedIndex != 0)
            {
                LoadPO();
                cmbPurchaseOrder.Enabled = true;
            }
            else
            {
                if (cmbPurchaseOrder.Items.Count > 0) {
                    cmbPurchaseOrder.SelectedIndex = 0;
                }
            }
        }

        private void txtKgRate_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtMuandRate_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtNetWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtNetWeight_TextChanged(object sender, EventArgs e)
        {
            KgRateCalculation();
        }

        private void btn_VIEW_VOUCHER_Click(object sender, EventArgs e)
        {
            try
            {
                if (classHelper.record_search_grid(grdSEARCH, lblPI.Text, 20) == 1)
                { show_report(); }
                else
                {
                    MessageBox.Show("Invoice not found in record or save the invoice first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void btnDetailReport_Click(object sender, EventArgs e)
        {
            if (!cmbPurchaseOrder.SelectedValue.ToString().Equals("0")) {
                clsPOInward.POInward_Report(Convert.ToInt32(cmbPurchaseOrder.SelectedValue.ToString()));
            }
        }
    }
    }

