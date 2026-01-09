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
    public partial class frmFinishedProducts : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        string id = "";
        int is_edit = 0;

        public frmFinishedProducts()
        {
            InitializeComponent();
        }

        //load COMBO BOXES
        private void LoadCartagePacking()
        {
            try
            {
                classHelper.query = @"SELECT '0' AS [id], '--SELECT CARTAGE PACKING--' AS [name] 
                UNION SELECT CP_ID AS[id], CP_NAME AS[name] FROM CARTAGE_PACKING";
                //classHelper.LoadComboData(cmbCartagePacking, classHelper.query);
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void LoadMaterial()
        {
            try
            {
                classHelper.query = @"SELECT '0' AS [id], '--SELECT RAW ITEM--' AS [name] 
                UNION ALL 
                SELECT MATERIAL_ID AS [id],MATERIAL_NAME AS [name] FROM MATERIALS WHERE stat = 0";
                classHelper.LoadComboData(cmbMatrial, classHelper.query);
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void LoadBrand()
        {
            try
            {
                classHelper.query = @"SELECT '0' AS [id], '--SELECT BRAND--' AS [name] 
                UNION
                SELECT P_CATEGORY_ID AS[id], P_CATEEGORY_NAME AS[name] FROM PRODUCT_CATEGORY
                WHERE STAT = 0";
                classHelper.LoadComboData(cmbBrand, classHelper.query);
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void LoadGrid()
        {
            classHelper.query = @"select A.PM_ID,B.P_CATEGORY_ID,B.P_CATEEGORY_NAME AS [BRAND],A.PRODUCT_CODE AS [PRODUCT CODE],A.PRODUCT_NAME AS [PRODUCT NAME],
            A.OPENING_QTY AS [QTY],A.OPENING_RATE AS [OPENING RATE],A.MIN_QTY AS [MINIMUM QTY],A.MAX_QTY AS [MAXIMUM QTY],a.LIST_RATE,a.NET_RATE
            from PRODUCT_MASTER A
            INNER JOIN PRODUCT_CATEGORY B ON A.BRAND_ID = B.P_CATEGORY_ID
            ORDER BY A.PM_ID DESC";
            classHelper.LoadGrid(grdSearch, classHelper.query);
        }

        private void LoadMaterialDetails(int productMasterId) {
            classHelper.query = @"SELECT A.MATERIAL_ID,B.MATERIAL_NAME AS [MATERIAL_NAME],A.WEIGHT AS [QTY] 
            FROM PRODUCT_DETAILS A
            INNER JOIN MATERIALS B ON A.MATERIAL_ID = B.MATERIAL_ID
            WHERE A.PM_ID = '"+ productMasterId + @"'
            ORDER BY A.PD_ID ";
            classHelper.LoadMaterialDetailGrid(gridMaterial, classHelper.query);
        }

        //get data from grid on click
        private void load_data_fromGrid(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.grdSearch.Rows[e.RowIndex];
                id = row.Cells["PM_ID"].Value.ToString();
                is_edit = 1;
                cmbBrand.SelectedValue = row.Cells["P_CATEGORY_ID"].Value.ToString();
                txtProductCode.Text = row.Cells["PRODUCT CODE"].Value.ToString();
                txtProductName.Text = row.Cells["PRODUCT NAME"].Value.ToString();
                txtOpeningQty.Text = row.Cells["QTY"].Value.ToString();
                txtOpeningRate.Text = row.Cells["OPENING RATE"].Value.ToString();
                txtRetailRate.Text = row.Cells["LIST_RATE"].Value.ToString();
                txtNetRate.Text = row.Cells["NET_RATE"].Value.ToString();
                txtMinQty.Text = row.Cells["MINIMUM QTY"].Value.ToString();
                txtMaxQty.Text = row.Cells["MAXIMUM QTY"].Value.ToString();
                LoadMaterialDetails(Convert.ToInt32(id));
            }
        }

        //clear fields in form
        private void clear()
        {
            id = "";
            is_edit = 0;
            cmbBrand.SelectedIndex = 0;
            txtProductCode.Clear();
            txtProductName.Clear();
            txtOpeningQty.Text = "0";
            txtOpeningRate.Text = "0";
            txtMinQty.Text = "0";
            txtMaxQty.Text = "0";
            cmbMatrial.SelectedIndex = 0;
            txtMaterialQty.Text = "0";
            gridMaterial.Rows.Clear();
            LoadGrid();
            txtSearch.Clear();
            txtRetailRate.Text = "0";
            txtNetRate.Text = "0";
        }

        //private void WeightCalculation() {
        //    decimal grossWeight = 0;
        //    decimal netWeight = 0;

        //    if (grdRawMaterial.Rows.Count > 0)
        //    {
        //        netWeight += grdRawMaterial.Rows.Cast<DataGridViewRow>()
        //        .Sum(t => Convert.ToDecimal(t.Cells[2].Value));
        //    }

        //    if (grdConsumable.Rows.Count > 0)
        //    {
        //        netWeight += grdConsumable.Rows.Cast<DataGridViewRow>()
        //        .Sum(t => Convert.ToDecimal(t.Cells[2].Value));
        //    }

        //    grossWeight = netWeight + Convert.ToDecimal(txtPackingWeight.Text);
        //    txtGrossWeight.Text = grossWeight.ToString();
        //    txtNetWeight.Text = netWeight.ToString();
        //}

        private void frm_AddGroupAccounts_Load(object sender, EventArgs e)
        {
            LoadGrid();
            LoadCartagePacking();
            LoadMaterial();
            LoadBrand();
        }

        private void txtSEARCH_TextChanged(object sender, EventArgs e)
        {
            classHelper.Product_search(txtSearch, grdSearch);
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {
            if (cmbBrand.SelectedIndex == 0)
            {
                classHelper.ShowMessageBox("Brand is not selected, please select Brand.", "Warning");
                cmbBrand.Focus();
                return;
            }
            if (txtProductCode.Text.Trim().Equals(""))
            {
                classHelper.ShowMessageBox("Product Code  field is blank.", "Warning");
                txtProductCode.Focus();
                return;
            }
            else if (txtProductName.Text.Trim().Equals(""))
            {
                classHelper.ShowMessageBox("Product Name  field is blank.", "Warning");
                txtProductName.Focus();
                return;
            }
            else if (txtOpeningQty.Text.Equals(""))
            {
                classHelper.ShowMessageBox("Opening Qty is Blank, please add value.", "Warning");
                txtOpeningQty.Focus();
                return;
            }
            else if (txtOpeningRate.Text.Equals(""))
            {
                classHelper.ShowMessageBox("Opening Rate is Blank, please add value.", "Warning");
                txtOpeningRate.Focus();
                return;
            }
            else if (txtRetailRate.Text.Equals(""))
            {
                classHelper.ShowMessageBox("Retail Rate is Blank, please add value.", "Warning");
                txtRetailRate.Focus();
                return;
            }
            else if (txtNetRate.Text.Equals(""))
            {
                classHelper.ShowMessageBox("Net Rate is Blank, please add value.", "Warning");
                txtNetRate.Focus();
                return;
            }
            else if (txtMinQty.Text.Equals(""))
            {
                classHelper.ShowMessageBox("Minimum Qty is Blank, please add value.", "Warning");
                txtMinQty.Focus();
                return;
            }
            else if (txtMaxQty.Text.Equals(""))
            {
                classHelper.ShowMessageBox("Maximum Qty is Blank, please add value.", "Warning");
                txtMaxQty.Focus();
                return;
            }
            else if (gridMaterial.Rows.Count <= 0)
            {
                classHelper.ShowMessageBox("Add Raw Material.", "Warning");
                cmbMatrial.Focus();
                return;
            }
            else
            {

                string masterId = id;
                if (id.Equals(""))
                {
                    masterId = "(SELECT MAX(PM_ID) FROM PRODUCT_MASTER)";
                }

                classHelper.query = @"BEGIN TRY 
                             BEGIN TRANSACTION ";
                classHelper.query += @"IF EXISTS(SELECT PM_ID FROM PRODUCT_MASTER WHERE PM_ID = '" + id + @"')
                BEGIN 
                    UPDATE PRODUCT_MASTER SET PRODUCT_CODE = '" + classHelper.AvoidInjection(txtProductCode.Text) + @"',
                    PRODUCT_NAME = '" + classHelper.AvoidInjection(txtProductName.Text) + @"',
                    BRAND_ID = '" + cmbBrand.SelectedValue.ToString() + @"',
                    MODIFIED_BY = '" + Classes.Helper.userId + @"',MODIFICATION_DATE = GETDATE(),
                    OPENING_QTY = '" + classHelper.AvoidInjection(txtOpeningQty.Text) + @"',
                    OPENING_RATE = '" + classHelper.AvoidInjection(txtOpeningRate.Text) + @"',
                    LIST_RATE = '" + classHelper.AvoidInjection(txtRetailRate.Text) + @"',
                    NET_RATE = '" + classHelper.AvoidInjection(txtNetRate.Text) + @"',
                    MIN_QTY = '" + classHelper.AvoidInjection(txtMinQty.Text) + @"',
                    MAX_QTY = '" + classHelper.AvoidInjection(txtMaxQty.Text) + @"'
                    WHERE PM_ID = '" + id + @"';                 
                END
                ELSE
                BEGIN
                    INSERT INTO PRODUCT_MASTER(PRODUCT_CODE,PRODUCT_NAME,CREATED_BY,CREATION_DATE,BRAND_ID,OPENING_QTY,OPENING_RATE,MIN_QTY,MAX_QTY,LIST_RATE,NET_RATE)
                    VALUES('" + classHelper.AvoidInjection(txtProductCode.Text) + "','" + classHelper.AvoidInjection(txtProductName.Text) + @"',
                    '" + Classes.Helper.userId + "',GETDATE(),'" + cmbBrand.SelectedValue.ToString() + @"','" + classHelper.AvoidInjection(txtOpeningQty.Text) + @"',
                    '" + classHelper.AvoidInjection(txtOpeningRate.Text) + @"','" + classHelper.AvoidInjection(txtMinQty.Text) + @"',
                    '" + classHelper.AvoidInjection(txtMaxQty.Text) + @"','" + classHelper.AvoidInjection(txtRetailRate.Text) + @"','" + classHelper.AvoidInjection(txtNetRate.Text) + @"'); 
                END 

                DELETE FROM PRODUCT_DETAILS WHERE PM_ID = '" + id + @"'";

                foreach (DataGridViewRow rows in gridMaterial.Rows)
                {
                    classHelper.query += @"INSERT INTO PRODUCT_DETAILS (PM_ID,MATERIAL_ID,WEIGHT) VALUES 
                    (" + masterId + ",'" + rows.Cells["materialId"].Value.ToString() + "','" + rows.Cells["qty"].Value.ToString() + @"');";
                }

                classHelper.query += @" DELETE FROM PRODUCT_ITEM_LEDGER WHERE REF_NO = '00' AND PRODUCT_ID = " + masterId + @" AND ENTRY_FROM = 'ADD PRODUCT OPENING';
                    INSERT INTO PRODUCT_ITEM_LEDGER 
                    ([DATE],PRODUCT_ID,REF_NO,ENTRY_FROM,STOCK_IN,STOCK_OUT,COST_AMT,SALE_AMT,L_ID,CREATED_BY,CREATION_DATE,COMPANY_ID)
                    VALUES('01-07-2020'," + masterId + ",'00','ADD PRODUCT OPENING','" + classHelper.AvoidInjection(txtOpeningQty.Text) + @"',
                    '0','" + classHelper.AvoidInjection(txtOpeningRate.Text) + "','0','1','" + Classes.Helper.userId + "',GETDATE(),'1');";

                classHelper.query += @" COMMIT TRANSACTION 
                        END TRY 
                    BEGIN CATCH 
                            IF @@TRANCOUNT > 0 
                            ROLLBACK TRANSACTION 
                    END CATCH";

                if (classHelper.InsertUpdateDelete(classHelper.query) >= 1)
                {
                    classHelper.ShowMessageBox("Record Saved Sucessfully.", "Information");
                    clear();
                    LoadGrid();
                }
            }
        }

        private void grdSEARCH_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            grdSearch.Columns["PM_ID"].Visible = false;
            grdSearch.Columns["P_CATEGORY_ID"].Visible = false;
            grdSearch.Columns["OPENING RATE"].Visible = false;
            grdSearch.Columns["MINIMUM QTY"].Visible = false;
            grdSearch.Columns["MAXIMUM QTY"].Visible = false;
        }

        private void btnCLEAR_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void grdSEARCH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            load_data_fromGrid(e);
        }

        private void cmbPacking_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //private void btnAddRaw_Click(object sender, EventArgs e)
        //{
        //    if (cmbRawMaterial.SelectedIndex == 0)
        //    {
        //        classHelper.ShowMessageBox("Select Raw Material.", "Warning");
        //        cmbRawMaterial.Focus();
        //        return;
        //    }
        //    else if (txtRawWeight.Text.Trim().Equals("") || txtRawWeight.Text.Trim().Equals("0"))
        //    {
        //        classHelper.ShowMessageBox("Enter Raw Material Weight.", "Warning");
        //        txtRawWeight.Focus();
        //        return;
        //    }
        //    else {
        //        grdRawMaterial.Rows.Add(cmbRawMaterial.SelectedValue.ToString(),cmbRawMaterial.Text,txtRawWeight.Text);
        //        WeightCalculation();
        //        cmbRawMaterial.SelectedIndex = 0;
        //        txtRawWeight.Text = "0";
        //    }
        //}

        //private void btnAddConumable_Click(object sender, EventArgs e)
        //{
        //    if (cmbConsumable.SelectedIndex == 0)
        //    {
        //        classHelper.ShowMessageBox("Select Consumable Material.", "Warning");
        //        cmbConsumable.Focus();
        //        return;
        //    }
        //    else if (txtConsumableWeight.Text.Trim().Equals("") || txtConsumableWeight.Text.Trim().Equals("0"))
        //    {
        //        classHelper.ShowMessageBox("Enter Consumable Material Weight.", "Warning");
        //        txtConsumableWeight.Focus();
        //        return;
        //    }
        //    else
        //    {
        //        grdConsumable.Rows.Add(cmbConsumable.SelectedValue.ToString(), cmbConsumable.Text, txtConsumableWeight.Text);
        //        WeightCalculation();
        //        cmbConsumable.SelectedIndex = 0;
        //        txtConsumableWeight.Text = "0";
        //    }
        //}

        //private void grdRawMaterial_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex >= 0)
        //    {
        //        DataGridViewRow row = this.grdRawMaterial.Rows[e.RowIndex];
        //        cmbRawMaterial.SelectedValue = row.Cells[0].Value.ToString();
        //        txtRawWeight.Text = row.Cells[2].Value.ToString();
        //        grdRawMaterial.Rows.RemoveAt(e.RowIndex);
        //    }
        //}

        //private void grdConsumable_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex >= 0)
        //    {
        //        DataGridViewRow row = this.grdConsumable.Rows[e.RowIndex];
        //        cmbConsumable.SelectedValue = row.Cells[0].Value.ToString();
        //        txtConsumableWeight.Text = row.Cells[2].Value.ToString();
        //        grdConsumable.Rows.RemoveAt(e.RowIndex);
        //    }
        //}

        private void txtRawWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                classHelper.AllowNumbers(e);
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbMatrial.SelectedIndex == 0)
            {
                MessageBox.Show("Please select Material");
                cmbMatrial.Focus();
            }
            else if (txtMaterialQty.Text.Equals("0") || txtMaterialQty.Text.Equals(""))
            {
                MessageBox.Show("Please add Material Qty");
                txtMaterialQty.Focus();
            }
            else
            {
                gridMaterial.Rows.Add(cmbMatrial.SelectedValue.ToString(), cmbMatrial.Text, txtMaterialQty.Text);
                cmbMatrial.SelectedIndex = 0;
                txtMaterialQty.Text = "0";
            }
        }

        private void gridMaterial_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.gridMaterial.Rows[e.RowIndex];
                cmbMatrial.SelectedValue = row.Cells["materialId"].Value.ToString();
                txtMaterialQty.Text = row.Cells["qty"].Value.ToString();
                gridMaterial.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void frmFinishedProducts_Load(object sender, EventArgs e)
        {
            LoadBrand();
            LoadMaterial();
            LoadGrid();
        }

       

        private int DeleteProduct(int productId)
        {
            int value = 0;
            classHelper.query = @"SELECT DBO.[DeleteProduct](" + productId + ")  as [value];";

            try
            {
                if (Classes.Helper.conn.State == System.Data.ConnectionState.Closed) { Classes.Helper.conn.Open(); }
                classHelper.cmd = new SqlCommand(classHelper.query, Classes.Helper.conn);
                classHelper.cmd.CommandTimeout = 0;
                classHelper.dr = classHelper.cmd.ExecuteReader();
                if (classHelper.dr.HasRows == true)
                {
                    if (classHelper.dr.Read())
                    {
                        if (classHelper.dr["value"].ToString().Equals("True"))
                        {
                            value = 1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                classHelper.ShowMessageBox(ex.Message, "Exception");
            }
            finally
            {
                Classes.Helper.conn.Close();
            }

            return value;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (id.Equals(""))
            {
                MessageBox.Show("Please Select Product!", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (DeleteProduct(Convert.ToInt32(id)) == 0)
                {
                    classHelper.query = @" delete from PRODUCT_MASTER where PM_ID = '" + id + @"';
                        delete from PRODUCT_DETAILS where PM_ID = '" + id + @"';";
                    if (classHelper.InsertUpdateDelete(classHelper.query) > 0)
                    {
                        MessageBox.Show("Product Deleted Sucessfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clear();
                    }
                }
                else
                {
                    MessageBox.Show("Product Cannot Delete, It is in use.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clear();
                }
            }
        }
    }
}

