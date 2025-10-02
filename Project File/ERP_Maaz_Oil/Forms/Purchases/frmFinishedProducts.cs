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
        bool isParameter = false;

        string productName = "";

        public frmFinishedProducts()
        {
            InitializeComponent();
        }

        public frmFinishedProducts(string productName)
        {
            InitializeComponent();
            isParameter = true;
            this.productName = productName;
        }

        private void LoadParameterForm() {
            cmbBrand.Text = "N/A";
            txtProductCode.Text = this.productName;
            txtProductName.Text = this.productName;
        }

        /*  //load COMBO BOXES
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
          /*
         /* private void LoadBrand()
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
          */


        private void LoadGrid()
        {
            classHelper.query = @"SELECT A.BRAND_ID,B.P_CATEEGORY_NAME AS [BRAND],A.PM_ID,A.PRODUCT_CODE AS [PRODUCT CODE],A.PRODUCT_NAME AS [PRODUCT NAME],
            A.OPENING_QTY AS [OPENING_QUANTITY],A.OPENING_RATE AS RATE
            FROM PRODUCT_MASTER A
            INNER JOIN PRODUCT_CATEGORY B ON A.BRAND_ID = B.P_CATEGORY_ID
            ORDER BY A.PM_ID DESC";
            classHelper.LoadGrid(grdSearch, classHelper.query);
        }

        /*   private void LoadMaterialDetails(int productMasterId) {
               classHelper.query = @"SELECT A.MATERIAL_ID,B.MATERIAL_NAME AS [MATERIAL_NAME],A.WEIGHT AS [QTY] 
               FROM PRODUCT_DETAILS A
               INNER JOIN MATERIALS B ON A.MATERIAL_ID = B.MATERIAL_ID
               WHERE A.PM_ID = '"+ productMasterId + @"'
               ORDER BY A.PD_ID ";
              /// classHelper.LoadMaterialDetailGrid(gridMaterial, classHelper.query);
           }
           *
           *
           */

        //get data from grid on click
        private void load_data_fromGrid(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.grdSearch.Rows[e.RowIndex];
                id = row.Cells["PM_ID"].Value.ToString();
                is_edit = 1;
                cmbBrand.SelectedValue = row.Cells["BRAND_ID"].Value.ToString();
                txtProductCode.Text = row.Cells["PRODUCT CODE"].Value.ToString();
                txtProductName.Text = row.Cells["PRODUCT NAME"].Value.ToString();
                txtRate.Text = row.Cells["RATE"].Value.ToString();
                txtQty.Text = row.Cells["OPENING_QUANTITY"].Value.ToString();
                //txtRate.Text = row.Cells["OPENING RATE"].Value.ToString();
                // txtRetailRate.Text = row.Cells["LIST_RATE"].Value.ToString();

                //  txtMinQty.Text = row.Cells["QTY"].Value.ToString();
                //   txtMaxQty.Text = row.Cells["MAXIMUM QTY"].Value.ToString();
                // LoadMaterialDetails(Convert.ToInt32(id));
            }
        }

        //clear fields in form
        private void clear()
        {
            isParameter = false;
            id = "";
            is_edit = 0;
            cmbBrand.SelectedIndex = 0;
            txtProductCode.Clear();
            txtProductName.Clear();
            // cmbMatrial.SelectedIndex = 0;
            txtQty.Text = "0";
            txtRate.Text = "0";
            txtTotal.Text = "0";
            LoadGrid();
            txtSearch.Clear();
        }

        private void frm_AddGroupAccounts_Load(object sender, EventArgs e)
        {
            LoadGrid();
            //LoadCartagePacking();
            //LoadMaterial();
            //LoadBrand();
        }

        private void txtSEARCH_TextChanged(object sender, EventArgs e)
        {
            classHelper.Product_search(txtSearch, grdSearch);
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {
        }



        private void grdSEARCH_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            grdSearch.Columns["PM_ID"].Visible = false;
            grdSearch.Columns["BRAND_ID"].Visible = false;
        }

        private void btnCLEAR_Click(object sender, EventArgs e)
        {

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

        /* private void txtRawWeight_KeyPress(object sender, KeyPressEventArgs e)
         {
             try
             {
                 classHelper.AllowNumbers(e);
             }
             catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
         }*/


        //  private void btnAdd_Click(object sender, EventArgs e)
        //  {
        //   if (cmbMatrial.SelectedIndex == 0)
        //   {
        //      MessageBox.Show("Please select Material");
        //      cmbMatrial.Focus();
        //   }
        //  else if (txtMaterialQty.Text.Equals("0") || txtMaterialQty.Text.Equals(""))
        //  {
        //   MessageBox.Show("Please add Material Qty");
        //    txtMaterialQty.Focus();
        //}
        // else
        // {
        // gridMaterial.Rows.Add(cmbMatrial.SelectedValue.ToString(), cmbMatrial.Text, txtMaterialQty.Text);
        //   cmbMatrial.SelectedIndex = 0;
        //   txtMaterialQty.Text = "0";
        // }
        //  }

        //   private void gridMaterial_CellClick(object sender, DataGridViewCellEventArgs e)
        //   {
        //   if (e.RowIndex >= 0)
        //  {
        //      DataGridViewRow row = this.gridMaterial.Rows[e.RowIndex];
        //    cmbMatrial.SelectedValue = row.Cells["materialId"].Value.ToString();
        //    txtMaterialQty.Text = row.Cells["qty"].Value.ToString();
        //   gridMaterial.Rows.RemoveAt(e.RowIndex);
        //   }//
        // }//
        //

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

        private void frmFinishedProducts_Load(object sender, EventArgs e)
        {
            LoadGrid();
            LoadBrand();
            if (isParameter) {
                LoadParameterForm();
            }
            
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

        private void button1_Click(object sender, EventArgs e)
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
            else if (txtQty.Text.Equals(""))
            {
                classHelper.ShowMessageBox("Qty is Blank, please add value.", "Warning");
                txtQty.Focus();
                return;
            }
            else if (txtRate.Text.Equals(""))
            {
                classHelper.ShowMessageBox("Rate is Blank, please add value.", "Warning");
                txtRate.Focus();
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
                    UPDATE PRODUCT_MASTER SET
                    PRODUCT_CODE = '" + classHelper.AvoidInjection(txtProductCode.Text) + @"',
                    PRODUCT_NAME = '" + classHelper.AvoidInjection(txtProductName.Text) + @"',
                    MODIFIED_BY = '" + Classes.Helper.userId + @"',MODIFICATION_DATE = GETDATE(),
                    OPENING_QTY = '" + classHelper.AvoidInjection(txtQty.Text) + @"',
                    OPENING_RATE = '" + classHelper.AvoidInjection(txtRate.Text) + @"',
                    BRAND_ID = '" + cmbBrand.SelectedValue.ToString() + @"'
                    WHERE PM_ID = '" + id + @"';                 
                END
                ELSE
                BEGIN
                    INSERT INTO PRODUCT_MASTER
                    (BRAND_ID,PRODUCT_CODE, PRODUCT_NAME, CREATED_BY, CREATION_DATE, OPENING_RATE, OPENING_QTY)
                    VALUES
                    ('" + cmbBrand.SelectedValue.ToString() + @"','" + classHelper.AvoidInjection(txtProductCode.Text) + "','" + classHelper.AvoidInjection(txtProductName.Text) + @"',
                    '" + Classes.Helper.userId + "', GETDATE(), '" + classHelper.AvoidInjection(txtRate.Text) + @"',
                    '" + classHelper.AvoidInjection(txtQty.Text) + @"');
                END";

                classHelper.query += @" DELETE FROM PRODUCT_ITEM_LEDGER WHERE REF_NO = '00' AND PRODUCT_ID = " + masterId + @" AND ENTRY_FROM = 'ADD PRODUCT OPENING';
                INSERT INTO PRODUCT_ITEM_LEDGER 
                ([DATE],PRODUCT_ID,REF_NO,ENTRY_FROM,STOCK_IN,STOCK_OUT,COST_AMT,SALE_AMT,L_ID,CREATED_BY,CREATION_DATE,COMPANY_ID)
                VALUES('01-07-2020'," + masterId + ",'00','ADD PRODUCT OPENING','" + classHelper.AvoidInjection(txtQty.Text) + @"',
                '0','" + classHelper.AvoidInjection(txtRate.Text) + "','0','1','" + Classes.Helper.userId + "',GETDATE(),'1');";

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


        private void buttonclear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void grdSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtRate_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtProductCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void QUANTITY_TextChanged(object sender, EventArgs e)
        {
            CalculateTotal();

        }

        private void txtRate_TextChanged_1(object sender, EventArgs e)
        {
            CalculateTotal();
        }


        private void CalculateTotal()
        {
            // Ensure the quantity and rate are valid numbers
            if (decimal.TryParse(txtQty.Text, out decimal quantity) && decimal.TryParse(txtRate.Text, out decimal rate))
            {
                // Calculate total
                decimal total = quantity * rate;
                txtTotal.Text = total.ToString();
            }
            else
            {
                // If inputs are invalid, clear the total
                txtTotal.Text = "0";
            }
        }

        private void btnAddGroupAccount_Click(object sender, EventArgs e)
        {
            using (frmAddCategory frm = new frmAddCategory())
            {
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.Cancel || frm.ShowDialog() == System.Windows.Forms.DialogResult.Abort)
                {
                    LoadBrand();
                }
            }
        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {

        }
    }


    /*     private void btnDelete_Click(object sender, EventArgs e)
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
*/

}
