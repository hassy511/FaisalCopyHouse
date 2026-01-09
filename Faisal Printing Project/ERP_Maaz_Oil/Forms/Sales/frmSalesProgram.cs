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
    public partial class frmSalesProgram : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        string id = "";
        int is_edit = 0;
        string soId = "0";
        float lastWeight = 0;
        float remainingWeight = 0;

        public frmSalesProgram()
        {
            InitializeComponent();
        }

        private void SalesProgramReport()
        {
            classHelper.nds.Tables["SalesProgramInvoice"].Clear();
            foreach (DataGridViewRow row in grdItems.Rows)
            {
                classHelper.dataR = classHelper.nds.Tables["SalesProgramInvoice"].NewRow();
                classHelper.dataR["InvoiceNo"] = lblPRO.Text;
                classHelper.dataR["date"] = dtp_DATE.Value.ToShortDateString();
                classHelper.dataR["customer"] = cmbCustomer.Text;
                classHelper.dataR["description"] = txtDescript.Text;

                classHelper.dataR["itemName"] = row.Cells["itemName"].Value.ToString();
                classHelper.dataR["qty"] = Convert.ToDouble(row.Cells["qty"].Value.ToString());
                classHelper.dataR["rate"] = Convert.ToDouble(row.Cells["rate"].Value.ToString());
                classHelper.dataR["amount"] = Convert.ToDouble(row.Cells["total"].Value.ToString());
                classHelper.dataR["muandRate"] = txtMuandRateD.Text;
                classHelper.dataR["totalWeight"] = Convert.ToDouble(txtTotalWeight.Text);
                classHelper.dataR["CanolaWeight"] = Convert.ToDouble(txtCanolaWeight.Text);
                classHelper.dataR["OlienWeight"] = Convert.ToDouble(txtOlienWeight.Text);

                classHelper.nds.Tables["SalesProgramInvoice"].Rows.Add(classHelper.dataR);
            }

            classHelper.rpt = new ERP_Maaz_Oil.Forms.Reporting.frmReports();
            classHelper.rpt.GenerateReport("SalesProgramInvoiceWO", classHelper.nds);
            classHelper.rpt.ShowDialog();

            classHelper.rpt = new ERP_Maaz_Oil.Forms.Reporting.frmReports();
            classHelper.rpt.GenerateReport("SalesProgramInvoice", classHelper.nds);
            classHelper.rpt.ShowDialog();
        }

        private void RowClear()
        {
            grdItems.Rows.Clear();
            txtOrderWeight.Text = "0";
            txtMuandRate.Text = "0";
            txtRemWeight.Text = "0";
            txtTQty.Text = "0";
            txtTotalWeight.Text = "0";
            txtTotal.Text = "0";

        }

        private void GeneratePRONumber()
        {
            classHelper.query = "SELECT COUNT(SPM_ID)+1 FROM SALES_PROGRAM_MASTER";
            lblPRO.Text = "PRO-" + classHelper.GetMaxValue(classHelper.query) + "-" + DateTime.Now.Year;
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
            classHelper.query = @"SELECT A.SPM_ID,A.DATE,A.INVOICE_NO AS[PROGRAM #],C.INVOICE_NO AS[SALES ORDER #],A.CUSTOMER_ID,B.COA_NAME AS [CUSTOMER],
            A.SOD_ID,A.TOTAL_WEIGHT AS [TOTAL WEIGHT],A.TOTAL AS [AMOUNT],A.DESCRIPTION,
            (C.TOTAL_KGS - (SELECT ISNULL(SUM(TOTAL_WEIGHT),0) FROM SALES_PROGRAM_MASTER WHERE SOD_ID = C.SOD_ID AND SO_TYPE = 'D')) AS [REMAINING_WEIGHT],
            A.[SO_TYPE]
            FROM SALES_PROGRAM_MASTER A, COA B, SALES_ORDER_DIRECT C
            WHERE A.CUSTOMER_ID = B.COA_ID AND A.SOD_ID = C.SOD_ID AND[SO_TYPE] = 'D'
            UNION ALL
            SELECT A.SPM_ID,A.DATE,A.INVOICE_NO AS[PROGRAM #],C.INVOICE_NO AS[SALES ORDER #],A.CUSTOMER_ID,B.COA_NAME AS [CUSTOMER],
            A.SOD_ID,A.TOTAL_WEIGHT AS [TOTAL WEIGHT],A.TOTAL AS [AMOUNT],A.DESCRIPTION,
            (C.TOTAL_WEIGHT - (SELECT ISNULL(SUM(TOTAL_WEIGHT),0) FROM SALES_PROGRAM_MASTER WHERE SOD_ID = C.SOPM_ID AND SO_TYPE = 'P')) AS [REMAINING_WEIGHT],
            A.[SO_TYPE]
            FROM SALES_PROGRAM_MASTER A, COA B, SALES_ORDER_PRODUCT_MASTER C
            WHERE A.CUSTOMER_ID = B.COA_ID AND A.SOD_ID = C.SOPM_ID AND[SO_TYPE] = 'P'
            UNION ALL
            SELECT A.SPM_ID,A.DATE,A.INVOICE_NO AS[PROGRAM #],C.INVOICE_NO AS[SALES ORDER #],A.CUSTOMER_ID,B.COA_NAME AS [CUSTOMER],
            A.SOD_ID,A.TOTAL_WEIGHT AS [TOTAL WEIGHT],A.TOTAL AS [AMOUNT],A.DESCRIPTION,
            (C.TOTAL_WEIGHT - (SELECT ISNULL(SUM(TOTAL_WEIGHT),0) FROM SALES_PROGRAM_MASTER WHERE SOD_ID = C.MPM_ID AND SO_TYPE = 'M')) AS [REMAINING_WEIGHT],
            A.[SO_TYPE]
            FROM SALES_PROGRAM_MASTER A, COA B, SO_MATERIAL_P_MASTER C
            WHERE A.CUSTOMER_ID = B.COA_ID AND A.SOD_ID = C.MPM_ID AND[SO_TYPE] = 'M'
            ORDER BY DATE DESC";
            classHelper.LoadGrid(grdSEARCH, classHelper.query);
        }
        //load COMBO BOXES
        private void LoadCustomers()
        {
            classHelper.LoadCustomers(cmbCustomer);
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

        //load item COMBO BOXES
        private void LoadProducts()
        {
            classHelper.LoadProducts(cmbItem);
        }

        private void LoadSoProduct(int soID)
        {
            classHelper.LoadSoProducts(cmbSOProduct, soID);
        }

        private void LoadSOProducts(DataGridView dgv, int soId)
        {
            classHelper.LoadSOProducts(dgv, soId);
        }

        private void LoadRaw()
        {
            classHelper.LoadMaterial(1, cmbItem);
        }

        //clear fields in form
        private void Clear()
        {
            GeneratePRONumber();
            dtp_DATE.Value = DateTime.Now;
            cmbCustomer.SelectedIndex = 0;
            if (cmbSO.Items.Count > 0)
            {
                cmbSO.SelectedIndex = 0;
            }
            cmbSO.Enabled = false;

            cmbSOProduct.Enabled = false;
            cmbSOProduct.Text = "";
            txtMuandRateD.Clear();
            txtDescript.Clear();
            rdbProduct.Checked = true;
            if (cmbItem.Items.Count > 0)
            {
                cmbItem.SelectedIndex = 0;
            }
            cmbItem.Enabled = false;
            txtQuantity.Enabled = false;
            txtRate.Enabled = false;
            txtRemWeight.Text = "0";
            txtTotalWeight.Text = "0";
            txtTotal.Text = "0";
            txtSEARCH.Clear();
            grdItems.Rows.Clear();
            id = "";
            is_edit = 0;
            lastWeight = 0;
            remainingWeight = 0;
            txtMuandRate.Text = "0";
            txtOrderWeight.Text = "0";
            txtTQty.Text = "0";
            soId = "0";
            txtCanolaWeight.Text = "0";
            txtOlienWeight.Text = "0";
            txtQuantity.Text = "0";
            txtRate.Text = "0";
        }

        private void AddClear()
        {
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
        private void GetSODWeight()
        {
            try
            {
                if (cmbSO.SelectedIndex != 0)
                {
                    string[] soDetails = classHelper.GetSODWeight(Convert.ToInt32(cmbSO.SelectedValue.ToString().TrimEnd('D')));
                    txtRemWeight.Text = soDetails[0];
                    txtOrderWeight.Text = soDetails[1];
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
                    txtRemWeight.Text = soDetails[0];
                    txtOrderWeight.Text = soDetails[1];
                    txtMuandRate.Text = Math.Round(Convert.ToDecimal(soDetails[2])).ToString();

                }
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
            //return 0;
        }

        private void GetSOMWeight()
        {
            try
            {
                if (cmbSO.SelectedIndex != 0)
                {
                    string[] soDetails = classHelper.GetSOMWeight(Convert.ToInt32(cmbSO.SelectedValue.ToString().TrimEnd('M')));
                    txtRemWeight.Text = soDetails[0];
                    txtOrderWeight.Text = soDetails[1];
                    //txtMuandRate.Text = Math.Round(Convert.ToDecimal(soDetails[2])).ToString();

                }
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
            //return 0;
        }

        private void ItemsTotalQty()
        {
            if (grdItems.Rows.Count > 0)
            {
                txtTQty.Text = grdItems.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToDecimal(t.Cells[2].Value)).ToString();
            }
        }
        private void ItemsTotalSum()
        {
            if (grdItems.Rows.Count > 0)
            {
                txtTotal.Text = grdItems.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToDecimal(t.Cells["total"].Value)).ToString();

                txtTotalWeight.Text = grdItems.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToDecimal(t.Cells["weight"].Value)).ToString();

                txtTQty.Text = grdItems.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToDecimal(t.Cells["qty"].Value)).ToString();
            }
        }
        private void RowSum()
        {
            if (grdItems.Rows.Count > 0)
            {
                txtTotal.Text = grdItems.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToDecimal(t.Cells["total"].Value)).ToString();

                txtTotalWeight.Text = grdItems.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToDecimal(t.Cells["weight"].Value)).ToString();

                txtTQty.Text = grdItems.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToDecimal(t.Cells["qty"].Value)).ToString();
            }
        }
        private void ItemsTotalWeight(char type, double value)
        {
            if (type.Equals('L'))
            {
                if (grdItems.Rows.Count > 0)
                {
                    txtTotalWeight.Text = grdItems.Rows.Cast<DataGridViewRow>()
                    .Sum(t => Convert.ToDecimal(t.Cells[3].Value)).ToString();
                    txtRemWeight.Text = (Convert.ToDouble(txtRemWeight.Text) - value).ToString();
                }
            }
            else
            {
                txtTotalWeight.Text = grdItems.Rows.Cast<DataGridViewRow>()
                    .Sum(t => Convert.ToDecimal(t.Cells[3].Value)).ToString();
                txtRemWeight.Text = (Convert.ToDouble(txtRemWeight.Text) + value).ToString();
            }
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
                    if (Convert.ToDouble(txtQuantity.Text) > Convert.ToDouble(txtRemWeight.Text))
                    {
                        MessageBox.Show("Weight is greater than Remaining Weight.", "Alert");
                        //return;
                    }
                    weight = Convert.ToDouble(txtQuantity.Text);
                    grdItems.Rows.Add(cmbItem.SelectedValue.ToString(), cmbItem.Text, txtQuantity.Text, txtRate.Text, weight, "KGS", (Convert.ToDecimal(txtQuantity.Text) * Convert.ToDecimal(txtRate.Text)), "R",
                        rdbRaw.Checked ? cmbItem.SelectedValue : GetMaterialID());
                }
                else if (rdbProduct.Checked == true)
                {
                    if ((GetProductWeight() * Convert.ToDouble(txtQuantity.Text)) > Convert.ToDouble(txtRemWeight.Text))
                    {
                        MessageBox.Show("Weight is greater than Remaining Weight.", "Alert");
                        //return;
                    }
                    weight = Convert.ToDouble((GetProductWeight() * Convert.ToDouble(txtQuantity.Text)));
                    grdItems.Rows.Add(cmbItem.SelectedValue.ToString(), cmbItem.Text, txtQuantity.Text, txtRate.Text, (GetProductWeight() * Convert.ToDouble(txtQuantity.Text)), "KGS", (Convert.ToDecimal(txtQuantity.Text) * Convert.ToDecimal(txtRate.Text)), "P",
                         rdbRaw.Checked ? cmbItem.SelectedValue : GetMaterialID());
                }
                ItemsTotalSum();
                ItemsTotalQty();
                ItemsTotalWeight('L', weight);
                ItemsTotalSum();
                AddClear();
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

        private void Save()
        {
            if (grdItems.Rows.Count > 0)
            {
                char itemType = 'P';
                string dId = id;
                string masterId = id;
                if (rdbRaw.Checked == true)
                {
                    itemType = 'R';
                }
                string updateQuery = "";
                string soId = cmbSO.SelectedValue.ToString();
                char soType = 'M';
                if (soId[soId.Length - 1] == 'D')
                {
                    soType = 'D';
                }
                else if (soId[soId.Length - 1] == 'P')
                {
                    soType = 'P';
                }

                if (!id.Equals(""))
                {
                    remainingWeight = (float.Parse(txtTotalWeight.Text) - lastWeight) - remainingWeight;
                    if (soType == 'D')
                    {
                        updateQuery = "UPDATE SALES_ORDER_DIRECT SET REMAINING_WEIGHT = '" + remainingWeight + "' WHERE SOD_ID = '" + cmbSO.SelectedValue.ToString().TrimEnd(soType) + "';";
                    }
                    else if (soType == 'P')
                    {
                        updateQuery = "UPDATE SALES_ORDER_PRODUCT_MASTER SET REMAINING_WEIGHT = " + (double.Parse(txtOrderWeight.Text) - double.Parse(txtTotalWeight.Text)) + " WHERE SOPM_ID = '" + cmbSO.SelectedValue.ToString().TrimEnd(soType) + "';";
                    }
                    else
                    {
                        updateQuery = "UPDATE SO_MATERIAL_P_MASTER SET REMAINING_WEIGHT = '" + remainingWeight + "' WHERE MPM_ID = '" + cmbSO.SelectedValue.ToString().TrimEnd(soType) + "';";
                    }

                }
                else
                {
                    if (soType == 'D')
                    {
                        updateQuery = "UPDATE SALES_ORDER_DIRECT SET REMAINING_WEIGHT = '" + txtRemWeight.Text + "' WHERE SOD_ID = '" + cmbSO.SelectedValue.ToString().TrimEnd(soType) + "';";
                    }
                    else if (soType == 'P')
                    {
                        updateQuery = "UPDATE SALES_ORDER_PRODUCT_MASTER SET REMAINING_WEIGHT = " + (double.Parse(txtOrderWeight.Text) - double.Parse(txtTotalWeight.Text)) + " WHERE SOPM_ID = '" + cmbSO.SelectedValue.ToString().TrimEnd(soType) + "';";
                    }
                    else
                    {
                        updateQuery = "UPDATE SO_MATERIAL_P_MASTER SET REMAINING_WEIGHT = '" + txtRemWeight.Text + "' WHERE MPM_ID = '" + cmbSO.SelectedValue.ToString().TrimEnd(soType) + "';";
                    }
                }


                if (id.Equals(""))
                {
                    id = "(SELECT MAX(SPM_ID) FROM SALES_PROGRAM_MASTER)";
                    masterId = id;
                }

                string detailQuery = "";

                foreach (DataGridViewRow rows in grdItems.Rows)
                {
                    detailQuery += @"INSERT INTO SALES_PROGRAM_DETAILS (SPM_ID,PRODUCT_ID,QTY,RATE,ITEM_TYPE,[WEIGHT]) VALUES 
                    (" + masterId + ",'" + rows.Cells[0].Value.ToString() + "'," + rows.Cells[2].Value.ToString() + @",
                     '" + rows.Cells["rate"].Value.ToString() + "','" + rows.Cells["itemType"].Value.ToString() + "','" + rows.Cells["weight"].Value.ToString() + @"');";
                }

                classHelper.query = "BEGIN TRAN ";
                classHelper.query += @"IF EXISTS (select SPM_ID from SALES_PROGRAM_MASTER WHERE SPM_ID ='" + dId + @"') 
                    BEGIN
                    UPDATE SALES_PROGRAM_MASTER SET [DATE] = '" + dtp_DATE.Value.ToString() + "',CUSTOMER_ID = '" + cmbCustomer.SelectedValue.ToString() + @"',
                    SOD_ID = '" + cmbSO.SelectedValue.ToString().TrimEnd(soType) + "', DESCRIPTION = '" + txtDescript.Text + @"',
                    TOTAL = '" + txtTotal.Text + "',TOTAL_WEIGHT = '" + txtTotalWeight.Text + @"',[SO_TYPE] = '" + soType + @"',
                    MODIFICATION_DATE = GETDATE(),MODIFIED_BY = '" + Classes.Helper.userId + @"' WHERE SPM_ID = '" + dId + @"';
                    END
                    ELSE
                    BEGIN
                    INSERT INTO SALES_PROGRAM_MASTER 
                    (DATE,CUSTOMER_ID,SOD_ID,INVOICE_NO,DESCRIPTION,TOTAL,TOTAL_WEIGHT,CREATED_BY,CREATION_DATE,REMAINING_WEIGHT,[SO_TYPE])
                    VALUES('" + dtp_DATE.Value.ToString() + "','" + cmbCustomer.SelectedValue.ToString() + "','" + cmbSO.SelectedValue.ToString().TrimEnd(soType) + @"',
                    '" + lblPRO.Text + "','" + txtDescript.Text + "','" + txtTotal.Text + "','" + txtTotalWeight.Text + "','" + Classes.Helper.userId + "',GETDATE(),0,'" + soType + @"')
                    END
                    DELETE FROM SALES_PROGRAM_DETAILS WHERE SPM_ID = '" + dId + @"'
                    " + detailQuery + @";";
                classHelper.query += updateQuery;
                classHelper.query += "COMMIT TRAN";
                if (classHelper.InsertUpdateDelete(classHelper.query) >= 1)
                {
                    classHelper.ShowMessageBox("Record Saved Sucessfully.", "Information");
                    DialogResult dialogResult = MessageBox.Show("Print Sales Program?", "Print Sales Program", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        SalesProgramReport();
                    }
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
                id = row.Cells["SPM_ID"].Value.ToString();
                is_edit = 1;
                dtp_DATE.Text = row.Cells["DATE"].Value.ToString();
                lblPRO.Text = row.Cells["PROGRAM #"].Value.ToString();
                soId = row.Cells["SOD_ID"].Value.ToString() + row.Cells["SO_TYPE"].Value.ToString();
                cmbCustomer.SelectedIndex = 0;
                cmbCustomer.SelectedValue = row.Cells["CUSTOMER_ID"].Value.ToString();

                //cmbSO.SelectedValue = row.Cells[5].Value.ToString();
                txtDescript.Text = row.Cells["DESCRIPTION"].Value.ToString();
                txtTotal.Text = row.Cells["AMOUNT"].Value.ToString();
                txtTotalWeight.Text = row.Cells["TOTAL WEIGHT"].Value.ToString();
                lastWeight = float.Parse(row.Cells["TOTAL WEIGHT"].Value.ToString());
                //remainingWeight = float.Parse(row.Cells[10].Value.ToString());
                txtRemWeight.Text = row.Cells["REMAINING_WEIGHT"].Value.ToString();//(Convert.ToDouble(row.Cells[8].Value.ToString())+Convert.ToDouble(row.Cells[9].Value.ToString())).ToString();
                grdItems.Rows.Clear();
                classHelper.GetSaleProgramDetails(Convert.ToInt16(id), grdItems, txtOlienWeight, txtCanolaWeight);

                ItemsTotalSum();


            }
        }

        private void frm_AddGroupAccounts_Load(object sender, EventArgs e)
        {
            GeneratePRONumber();
            LoadGrid();
            LoadCustomers();
        }

        private void txtSEARCH_TextChanged(object sender, EventArgs e)
        {
            classHelper.Sale_Program_Search(txtSEARCH, grdSEARCH);
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void grdSEARCH_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            grdSEARCH.Columns["SPM_ID"].Visible = false;
            grdSEARCH.Columns["CUSTOMER_ID"].Visible = false;
            grdSEARCH.Columns["SOD_ID"].Visible = false;
            grdSEARCH.Columns["REMAINING_WEIGHT"].Visible = false;
            grdSEARCH.Columns["SO_TYPE"].Visible = false;
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

        private void grdItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.grdItems.Rows[e.RowIndex];
                if (row.Cells["itemType"].Value.ToString().Equals("R"))
                {
                    rdbRaw.Checked = true;
                    cmbItem.SelectedValue = row.Cells[0].Value.ToString();
                }
                else
                {
                    rdbProduct.Checked = true;
                    cmbItem.SelectedValue = row.Cells[0].Value.ToString();
                }
                cmbItem.SelectedValue = row.Cells[0].Value.ToString();
                txtQuantity.Text = row.Cells[2].Value.ToString();
                txtRate.Text = row.Cells["rate"].Value.ToString();
                double weight = Convert.ToDouble(row.Cells["weight"].Value.ToString());
                grdItems.Rows.RemoveAt(e.RowIndex);
                ItemsTotalSum();
                ItemsTotalQty();
                ItemsTotalWeight('A', weight);
                ItemsTotalSum();
                WeightSum();
            }
        }

        private void WeightSum()
        {
            try
            {
                txtOlienWeight.Text = grdItems.Rows.Cast<DataGridViewRow>()
                    .Where(r => Convert.ToInt32(r.Cells["MaterialID"].Value) == 5003)
                    .Sum(t => Convert.ToDecimal(t.Cells["weight"].Value)).ToString();
                //grdItems.Rows.Cast<DataGridViewRow>()
                //    .Where(x => (x.Cells["MaterialID"].Value.ToString()).Equals("5003"))
                //    .Sum(x => Convert.ToDecimal(x.Cells["weight"].Value)).ToString();

                txtCanolaWeight.Text = grdItems.Rows.Cast<DataGridViewRow>()
                        .Where(r => Convert.ToInt32(r.Cells["MaterialID"].Value) == 5005)
                        .Sum(t => Convert.ToDecimal(t.Cells["weight"].Value)).ToString();
                //grdItems.Rows.Cast<DataGridViewRow>()
                //    .Where(x => (x.Cells["MaterialID"].Value.ToString()).Equals("5005"))
                //    .Sum(x => Convert.ToDecimal(x.Cells["weight"].Value)).ToString();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void cmbItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdbProduct.Checked == true)
            {
                //GetProductRate();
            }
        }

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

        private void rdbRaw_CheckedChanged(object sender, EventArgs e)
        {
            LoadRaw();
            cmbItem.Enabled = true;
        }

        private void rdbProduct_CheckedChanged(object sender, EventArgs e)
        {
            LoadProducts();
            cmbItem.Enabled = true;
        }

        private void cmbSO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSO.SelectedIndex > 0)
            {
                string soId = cmbSO.SelectedValue.ToString();
                if (soId[soId.Length - 1] == 'D')
                {
                    RowClear();
                    cmbSOProduct.Enabled = false;
                    cmbSOProduct.Text = "";
                    GetSODWeight();
                    txtMuandRateD.Text = classHelper.GetSOMuandRate(Convert.ToInt32(cmbSO.SelectedValue.ToString().TrimEnd('D')), 'D');
                }
                else if (soId[soId.Length - 1] == 'P')
                {
                    RowClear();
                    cmbSOProduct.Enabled = false;
                    cmbSOProduct.Text = "";
                    GetSOPWeight();
                    LoadSOProducts(grdItems, Convert.ToInt32(cmbSO.SelectedValue.ToString().TrimEnd('P')));
                    txtMuandRateD.Text = classHelper.GetSOMuandRate(Convert.ToInt32(cmbSO.SelectedValue.ToString().TrimEnd('P')), 'P');
                    RowSum();
                }
                else
                {
                    RowClear();
                    int somId = Convert.ToInt32(cmbSO.SelectedValue.ToString().TrimEnd('M'));
                    LoadSoProduct(somId);
                    txtMuandRateD.Text = classHelper.GetSOMuandRate(Convert.ToInt32(cmbSO.SelectedValue.ToString().TrimEnd('M')), 'M');
                    cmbSOProduct.Enabled = true;
                    if (cmbSOProduct.Items.Count > 0)
                    {
                        cmbSOProduct.SelectedIndex = 0;
                        txtMuandRate.Text = cmbSOProduct.SelectedValue.ToString();
                        GetSOMWeight();
                    }
                }

                //txtRemWeight.Text = GetSOWeight().ToString();

                rdbProduct.Checked = true;
                LoadProducts();
                cmbItem.Enabled = true;
                txtQuantity.Enabled = true;
                txtRate.Enabled = true;
            }
            else
            {
                if (cmbSO.Items.Count > 0)
                {
                    txtRemWeight.Text = "0";
                }
            }
        }

        private void txtTQty_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbSOProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSOProduct.Enabled == true && cmbSOProduct.Items.Count > 0) { txtMuandRate.Text = cmbSOProduct.SelectedValue.ToString(); }
        }

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

        private void btnViewSODetails_Click(object sender, EventArgs e)
        {
            if (!cmbSO.SelectedValue.ToString().Equals("0"))
            {
                Purchases.SOInwardReport clsSOInward = new Purchases.SOInwardReport();
                clsSOInward.SOInward_Report(Convert.ToInt32(cmbSO.SelectedValue.ToString().TrimEnd('D')));
            }
        }

        private void btnSalesProgram_Click(object sender, EventArgs e)
        {
            try
            {
                if (classHelper.record_search_grid(grdSEARCH, lblPRO.Text, 2) == 1)
                { SalesProgramReport(); }
                else
                {
                    MessageBox.Show("Sales Program not found in record or save the Sales Program first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }
    }
}

