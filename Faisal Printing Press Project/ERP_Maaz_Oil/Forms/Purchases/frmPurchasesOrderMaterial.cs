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
    public partial class frmPurchasesOrderMaterial : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        string id = "";
        int is_edit = 0;
        Purchases.POInwardReport clsPOInward = new Purchases.POInwardReport();
        public frmPurchasesOrderMaterial()
        {
            InitializeComponent();
        }

        private void GeneratePONumber() {
            classHelper.query = "SELECT COUNT(PO_ID)+1 FROM PURCHASES_ORDER";
            lblPO.Text = "PO-" + classHelper.GetMaxValue(classHelper.query) + "-" + DateTime.Now.Year;
        }

        private void LoadGrid() {
            classHelper.query = @"SELECT A.PO_ID,A.PO_NUMBER AS [P.O #],A.DATE,A.SUPPLIER_ID,D.COA_NAME AS [SUPPLIER],
            B.M_TYPE_ID,C.M_TYPE_NAME AS [MATERIAL TYPE],A.MATERIAL_ID,B.MATERIAL_NAME AS [MATERIAL],
            A.WEIGHT,E.UNIT_NAME AS [UNIT],A.KG_RATE AS [KG RATE],A.MUAND_RATE AS [MUAND RATE],
            A.MUAND_VALUE AS[MUAND_VALUE],(A.KG_RATE * A.WEIGHT) AS [TOTAL], A.DESCRIPTION,A.CREDIT_DAYS,A.[STATUS]
            FROM PURCHASES_ORDER A,MATERIALS B,MATERIAL_TYPES C,COA D,UNITS E
            WHERE A.MATERIAL_ID = B.MATERIAL_ID AND B.M_TYPE_ID = C.M_TYPE_ID 
            AND A.SUPPLIER_ID = D.COA_ID AND B.UNIT_ID = E.UNIT_ID
            ORDER BY A.DATE DESC";
            classHelper.LoadGrid(grdSEARCH, classHelper.query);
        }
        //load COMBO BOXES
        private void LoadSuppliers()
        {
            classHelper.LoadSuppliers(cmbSupplier);
        }
        private void LoadMaterialType()
        {
            classHelper.LoadMaterialType(cmbMaterialType);
        }

        private void LoadMaterialUnit() {
            classHelper.LoadMaterialUnit(Convert.ToInt16(cmbMaterial.SelectedValue.ToString()), txtUnit);
        }

        //clear fields in form
        private void clear() {
            dtp_DATE.Value = DateTime.Now;
            cmbSupplier.SelectedIndex = 0;
            txtDescription.Clear();
            cmbMaterialType.SelectedIndex = 0;
            if (cmbMaterial.Items.Count > 0) { cmbMaterial.SelectedIndex = 0; }
            txtWeight.Text = "0";
            txtKgRate.Text = "0";
            txtMuandRate.Text = "0";
            rdb37.Checked = true;
            txtTotal.Text = "0";
            txtCreditDays.Text = "0";
            chkDiscard.Checked = false;
            GeneratePONumber();
            id = "";
            is_edit = 0;
        }

        private void Save() {
            if (cmbMaterialType.SelectedIndex == 0)
            {
                classHelper.ShowMessageBox("Material Type is not selected, please select Material Type.", "Warning");
                cmbMaterialType.Focus();
            }
            else if (cmbMaterial.SelectedIndex == 0)
            {
                classHelper.ShowMessageBox("Material is not selected, please select material.", "Warning");
                cmbMaterial.Focus();
            }
            else if (txtWeight.Text.Trim().Equals(""))
            {
                classHelper.ShowMessageBox("Weight Field is empty.", "Warning");
                txtWeight.Focus();
            }
            else if (cmbSupplier.SelectedIndex == 0)
            {
                classHelper.ShowMessageBox("Supplier is not selected, please select supplier.", "Warning");
                cmbSupplier.Focus();
            }
            else if (txtKgRate.Text.Trim().Equals("") || txtMuandRate.Text.Trim().Equals(""))
            {
                classHelper.ShowMessageBox("Rate Field is empty.", "Warning");
                txtKgRate.Focus();
            }
            else if (txtCreditDays.Text.Trim().Equals(""))
            {
                classHelper.ShowMessageBox("Credit Days Field is empty.", "Warning");
                txtCreditDays.Focus();
            }
            else
            {
                char orderStatus = 'N';
                if (chkDiscard.Checked == true) {
                    orderStatus = 'Y';
                }
                decimal muandValue = 40;
                if (rdb37.Checked == true)
                {
                    muandValue = 37.324M;
                }
                classHelper.query = "BEGIN TRAN ";
                classHelper.query += @"IF EXISTS (select PO_ID from PURCHASES_ORDER WHERE PO_ID ='" + id +
                    "') UPDATE PURCHASES_ORDER SET DATE = '" + Classes.Helper.ConvertDatetime(dtp_DATE.Value.Date) +
                    "',MATERIAL_ID = '" + cmbMaterial.SelectedValue.ToString() + "',[WEIGHT] = '" + classHelper.AvoidInjection(txtWeight.Text) +
                    "',SUPPLIER_ID = '" + cmbSupplier.SelectedValue.ToString() +
                    "',[DESCRIPTION] = '" + classHelper.AvoidInjection(txtDescription.Text) +
                    "',CREDIT_DAYS = '" + classHelper.AvoidInjection(txtCreditDays.Text) +
                    "',KG_RATE = '" + classHelper.AvoidInjection(txtKgRate.Text) +
                    "',MUAND_RATE = '" + classHelper.AvoidInjection(txtMuandRate.Text) +
                    "',MUAND_VALUE = '" + muandValue +
                    "',MODIFICATION_DATE = GETDATE(), MODIFIED_BY = '" + Classes.Helper.userId
                    + "',[STATUS] = '"+orderStatus+"' WHERE PO_ID = '" + id +
                    "' ELSE INSERT INTO PURCHASES_ORDER VALUES('" + lblPO.Text +
                    "','" + Classes.Helper.ConvertDatetime(dtp_DATE.Value.Date) + "','" + cmbMaterial.SelectedValue.ToString() + "','"
                    + classHelper.AvoidInjection(txtWeight.Text) + "','" + cmbSupplier.SelectedValue.ToString() + "','"
                    + classHelper.AvoidInjection(txtDescription.Text) + "','"
                    + classHelper.AvoidInjection(txtKgRate.Text) + "','"
                    + classHelper.AvoidInjection(txtMuandRate.Text) + "','"
                    + muandValue + "','" + classHelper.AvoidInjection(txtCreditDays.Text)
                    + "','0','" + Classes.Helper.userId + "',GETDATE(),NULL,NULL,'"+orderStatus+"');";
                classHelper.query += " COMMIT TRAN";

                if (classHelper.InsertUpdateDelete(classHelper.query) >= 1)
                {
                    classHelper.ShowMessageBox("Record Saved Sucessfully.", "Information");
                    LoadGrid();
                    //show_report();
                    clear();
                }
            }
        }

        //get data from grid on click
        private void load_data_fromGrid(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.grdSEARCH.Rows[e.RowIndex];
                id = row.Cells[0].Value.ToString();
                is_edit = 1;
                lblPO.Text = row.Cells[1].Value.ToString();
                dtp_DATE.Text = row.Cells[2].Value.ToString();
                cmbSupplier.SelectedValue = row.Cells[3].Value.ToString();
                cmbMaterialType.SelectedValue = row.Cells[5].Value.ToString();
                cmbMaterial.SelectedValue = row.Cells[7].Value.ToString();
                txtWeight.Text = row.Cells[9].Value.ToString();
                txtUnit.Text = row.Cells[10].Value.ToString();
                txtKgRate.Text = row.Cells[11].Value.ToString();
                txtMuandRate.Text = row.Cells[12].Value.ToString();
                if (row.Cells["STATUS"].Value.ToString().Equals("Y"))
                {
                    chkDiscard.Checked = true;
                }
                else {
                    chkDiscard.Checked = false;
                }
                if (row.Cells[13].Value.ToString().Equals("40"))
                {
                    rdb40.Checked = true;
                }
                else {
                    rdb37.Checked = true;
                }
                txtTotal.Text = row.Cells[14].Value.ToString();
                txtDescription.Text = row.Cells[15].Value.ToString();
                txtCreditDays.Text = row.Cells[16].Value.ToString();
            }
        }

        private void frm_AddGroupAccounts_Load(object sender, EventArgs e)
        {
            GeneratePONumber();
            LoadGrid();
            LoadMaterialType();
            LoadSuppliers();
        }

        private void txtSEARCH_TextChanged(object sender, EventArgs e)
        {
           classHelper.PurchasesOrderSearch(txtSEARCH, grdSEARCH);
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void cmbPACCOUNT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMaterialType.SelectedIndex != 0)
            {
                cmbMaterial.Enabled = true;
                classHelper.LoadMaterial(Convert.ToInt16(cmbMaterialType.SelectedValue.ToString()),cmbMaterial);
            }
            else
            {
                cmbMaterial.Enabled = false;
                if (cmbMaterial.Items.Count > 0)
                {
                    cmbMaterial.SelectedIndex = 0;
                }
            }
        }

        private void grdSEARCH_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            grdSEARCH.Columns[0].Visible = false;
            grdSEARCH.Columns[3].Visible = false;
            grdSEARCH.Columns[5].Visible = false;
            grdSEARCH.Columns[7].Visible = false;
        }

        private void btnCLEAR_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void grdSEARCH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           load_data_fromGrid(e); 
        }


        
        private void txtPHONE_MouseClick(object sender, MouseEventArgs e)
        {
            classHelper.select_all_text(sender as TextBox);
        }

        private void txtPHONE_Enter(object sender, EventArgs e)
        {
            classHelper.select_all_text(sender as TextBox);
        }

        private void txtPHONE_Leave(object sender, EventArgs e)
        {
            
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

        private void txtWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (classHelper.AllowNumbers(e) == 0) {
                    KgRateCalculation();
                }
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void cmbSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMaterial.SelectedIndex != 0) {
                LoadMaterialUnit();
            }
        }

        private void MuandRateCalculation()
        {
            decimal netWeight = 0;
            if (!txtWeight.Text.Equals(""))
            {
                netWeight = Convert.ToDecimal(txtWeight.Text);
            }
            decimal muandRate = 0;
            if (!txtMuandRate.Text.Equals(""))
            {
                muandRate = Convert.ToDecimal(txtMuandRate.Text);
            }
            decimal muandValue = 40;
            if (rdb37.Checked == true)
            {
                muandValue = 37.324M;
            }
            txtKgRate.Text = Math.Round((muandRate / muandValue),4).ToString();
            decimal kgRate = 0;
            if (!txtKgRate.Text.Equals(""))
            {
                kgRate = Convert.ToDecimal(txtKgRate.Text);
            }
            txtTotal.Text = Math.Round((netWeight * kgRate),4).ToString();
        }

        private void KgRateCalculation()
        {
            decimal netWeight = 0;
            if (!txtWeight.Text.Equals(""))
            {
                netWeight = Convert.ToDecimal(txtWeight.Text);
            }
            decimal kgRate = 0;
            if (!txtKgRate.Text.Equals(""))
            {
                kgRate = Convert.ToDecimal(txtKgRate.Text);
            }
            decimal muandValue = 40;
            if (rdb37.Checked == true)
            {
                muandValue = 37.324M;
            }
            txtMuandRate.Text = Math.Round((kgRate * muandValue),4).ToString();
            txtTotal.Text = Math.Round((netWeight * kgRate),4).ToString();
        }

        private void txtKgRate_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtMuandRate_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void rdb37_CheckedChanged(object sender, EventArgs e)
        {
            MuandRateCalculation();
        }

        private void rdb40_CheckedChanged(object sender, EventArgs e)
        {
            MuandRateCalculation();
        }

        private void txtWeight_TextChanged(object sender, EventArgs e)
        {

        }

        private void show_report()
        {
            double muandWeight = 37.324;
            if (rdb40.Checked == true) {
                muandWeight = 40;
            }
            classHelper.mds.Tables["PO_M"].Clear();
            classHelper.dataR = classHelper.mds.Tables["PO_M"].NewRow();
            classHelper.dataR["PO_num"] = lblPO.Text;
            classHelper.dataR["date"] = Classes.Helper.ConvertDatetime(dtp_DATE.Value.Date);
            classHelper.dataR["supplier"] = cmbSupplier.Text;
            classHelper.dataR["description"] = txtDescription.Text;
            classHelper.dataR["material_type"] = cmbMaterialType.Text;
            classHelper.dataR["material"] = cmbMaterial.Text;
            classHelper.dataR["weight"] = Convert.ToDouble(txtWeight.Text);
            classHelper.dataR["kgRate"] = Convert.ToDouble(txtKgRate.Text);
            classHelper.dataR["munadRate"] = Convert.ToDouble(txtMuandRate.Text);
            classHelper.dataR["m_weight"] = muandWeight;
            classHelper.dataR["total"] = txtTotal.Text;
            classHelper.dataR["creditDays"] = txtCreditDays.Text;
            classHelper.mds.Tables["PO_M"].Rows.Add(classHelper.dataR);
            classHelper.rpt = new ERP_Maaz_Oil.Forms.Reporting.frmReports();
            classHelper.rpt.GenerateReport("PO_M", classHelper.mds);
            classHelper.rpt.ShowDialog();
        }

        private void btn_VIEW_VOUCHER_Click(object sender, EventArgs e)
        {
            try
            {
                if (classHelper.record_search_grid(grdSEARCH, lblPO.Text, 1) == 1)
                { show_report(); }
                else
                {
                    MessageBox.Show("Invoice not found in record or save the invoice first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void txtKgRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (classHelper.AllowNumbers(e) == 0)
                {
                   
                }
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void txtMuandRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (classHelper.AllowNumbers(e) == 0)
                {
                    
                }
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void txtKgRate_KeyUp(object sender, KeyEventArgs e)
        {
            KgRateCalculation();
        }

        private void txtMuandRate_KeyUp(object sender, KeyEventArgs e)
        {
            MuandRateCalculation();
        }

        private void txtKgRate_Leave(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt.Text.Trim().Equals(""))
            {
                txt.Text = "0";
            }
        }

        private void txtMuandRate_Validated(object sender, EventArgs e)
        {

        }
        
        private void btnDetailReport_Click(object sender, EventArgs e)
        {
            if (!id.Equals("")) { clsPOInward.POInward_Report(Convert.ToInt32(id)); }
        }

        private void lblPO_Click(object sender, EventArgs e)
        {

        }
    }
    }

