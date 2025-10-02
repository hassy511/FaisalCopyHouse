using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP_Maaz_Oil.Forms.Job
{    
    public partial class frmJobOrderMaterialExpenses : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        int jobOrderId = 0;
        int id = 0;
        bool isEdit = false;
        public frmJobOrderMaterialExpenses(int jobOrderId)
        {
            InitializeComponent();
            this.jobOrderId = jobOrderId;
        }
        private void Clear()
        {
            txtSearch.Clear();
            dtpDate.Value = DateTime.Now;
            cmbExpense.SelectedIndex = 0;
            cmbPaymentAmount.SelectedIndex = 0;
            txtDescription.Clear();
            cmbMaterial.SelectedIndex = 0;
            txtQty.Text = "0";
            txtRecQty.Text = "0";
            txtAmount.Text = "0";
            id = 0;
            isEdit = false;
        }
        private void LoadGrid()
        {
            classHelper.query = @"SELECT a.JOB_ORDER_MATERIAL_EXPENSES_ID AS [ID],A.[DATE], 
            B.COA_NAME AS [EXPENSE],C.COA_NAME AS [PAYMENT ACCOUNT],
            D.MATERIAL_NAME,A.[DESCRIPTION],A.QTY,A.AMOUNT,A.REC_QTY,
            A.ACCOUNT_ID,A.EXPENSE_ID,A.MATERIAL_ID
            FROM JOB_ORDER_MATERIAL_EXPENSES A
            INNER JOIN COA B ON A.EXPENSE_ID = B.COA_ID
            INNER JOIN COA C ON A.ACCOUNT_ID = C.COA_ID
            INNER JOIN MATERIALS D ON A.MATERIAL_ID = D.MATERIAL_ID
            WHERE A.JOB_ORDER_MASTER_ID = '" + jobOrderId + @"'
            ORDER BY A.JOB_ORDER_MATERIAL_EXPENSES_ID DESC";
            classHelper.LoadGrid(grdSearch, classHelper.query);
        }
        private void LoadGridData(DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.grdSearch.Rows[e.RowIndex];
            if (e.RowIndex >= 0)
            {
                id = Convert.ToInt32(row.Cells["ID"].Value.ToString());
                dtpDate.Text = row.Cells["DATE"].Value.ToString();
                cmbExpense.SelectedValue = row.Cells["EXPENSE_ID"].Value.ToString();
                cmbPaymentAmount.SelectedValue = row.Cells["ACCOUNT_ID"].Value.ToString();
                txtDescription.Text = row.Cells["DESCRIPTION"].Value.ToString();
                cmbMaterial.SelectedValue = row.Cells["MATERIAL_ID"].Value.ToString();
                txtQty.Text = row.Cells["QTY"].Value.ToString();
                txtRecQty.Text = row.Cells["REC_QTY"].Value.ToString();
                txtAmount.Text = row.Cells["AMOUNT"].Value.ToString();
            }
        }

        private void Save()
        {
            if (cmbExpense.SelectedIndex == 0)
            {
                classHelper.ShowMessageBox("Please add Expense.", "Warning");
                cmbExpense.Focus();
            }
            else if (cmbPaymentAmount.SelectedIndex == 0)
            {
                classHelper.ShowMessageBox("Please add Payment Account.", "Warning");
                cmbPaymentAmount.Focus();
            }
            else if (cmbMaterial.SelectedIndex == 0)
            {
                classHelper.ShowMessageBox("Please add Material.", "Warning");
                cmbMaterial.Focus();
            }
            else if (txtQty.Text.Equals("") || txtQty.Text.Equals("0"))
            {
                classHelper.ShowMessageBox("Please add Qty.", "Warning");
                txtAmount.Focus();
            }
            else if (txtAmount.Text.Equals("") || txtAmount.Text.Equals("0"))
            {
                classHelper.ShowMessageBox("Please add Amount.", "Warning");
                txtAmount.Focus();
            }
            else
            {
                classHelper.query = @"BEGIN TRY 
                             BEGIN TRANSACTION ";

                classHelper.query += @"IF EXISTS (SELECT JOB_ORDER_MATERIAL_EXPENSES_ID FROM JOB_ORDER_MATERIAL_EXPENSES WHERE JOB_ORDER_MATERIAL_EXPENSES_ID = '" + id + @"') 
                BEGIN
	                UPDATE JOB_ORDER_MATERIAL_EXPENSES SET [DATE] = '" + dtpDate.Value.ToString() + @"',
                    [EXPENSE_ID] = '" + cmbExpense.SelectedValue.ToString() + @"', 
                    [ACCOUNT_ID] = '" + cmbPaymentAmount.SelectedValue.ToString() + @"',
                    [MATERIAL_ID] = '" + cmbMaterial.SelectedValue.ToString() + @"',                    
                    [DESCRIPTION] = '" + classHelper.AvoidInjection(txtDescription.Text) + @"',
                    [AMOUNT] = '" + classHelper.AvoidInjection(txtAmount.Text) + @"',
                    [QTY] = '" + classHelper.AvoidInjection(txtQty.Text) + @"',
                    [REC_QTY] = '" + classHelper.AvoidInjection(txtRecQty.Text) + @"',
	                MODIFICATION_DATE = GETDATE(),
	                MODIFIED_BY = '" + Classes.Helper.userId + @"'
                    WHERE JOB_ORDER_MATERIAL_EXPENSES_ID = '" + id + @"';
                END
                ELSE
                BEGIN
                    INSERT INTO JOB_ORDER_MATERIAL_EXPENSES
                    ([DATE],[DESCRIPTION],EXPENSE_ID,AMOUNT,CREATED_BY, CREATION_DATE,JOB_ORDER_MASTER_ID,ACCOUNT_ID,MATERIAL_ID,QTY,REC_QTY)
	                VALUES('" + dtpDate.Value.ToString() + "', '" + classHelper.AvoidInjection(txtDescription.Text) + @"',
                    '" + cmbExpense.SelectedValue.ToString() + "','" + classHelper.AvoidInjection(txtAmount.Text) + @"',
                    '" + Classes.Helper.userId + @"', GETDATE(),'" + jobOrderId + @"','" + cmbPaymentAmount.SelectedValue.ToString() + @"',
                    '" + cmbMaterial.SelectedValue.ToString() + @"','" + classHelper.AvoidInjection(txtQty.Text) + @"','" + classHelper.AvoidInjection(txtRecQty.Text) + @"');
                END";

                classHelper.query += @" COMMIT TRANSACTION 
                        END TRY 
                    BEGIN CATCH 
                            IF @@TRANCOUNT > 0 
                            ROLLBACK TRANSACTION 
                    END CATCH";

                if (classHelper.InsertUpdateDelete(classHelper.query) >= 1)
                {
                    classHelper.ShowMessageBox("Record Saved Sucessfully.", "Information");
                    Clear();
                    LoadGrid();
                }
            }
        }

        private void LoadExpenses()
        {
            classHelper.LoadAllAccounts(cmbExpense);
        }

        private void LoadPaymentAccounts()
        {
            classHelper.LoadAllAccounts(cmbPaymentAmount);
        }
        private void LoadMaterial()
        {
            try
            {
                classHelper.query = @"SELECT '0' AS [id], '--SELECT RAW ITEM--' AS [name] 
                UNION ALL 
                SELECT MATERIAL_ID AS [id],MATERIAL_NAME AS [name] FROM MATERIALS WHERE stat = 0";
                classHelper.LoadComboData(cmbMaterial, classHelper.query);
            }
            catch (Exception ex) { classHelper.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
         
        }

        private void frmJobOrderMaterialExpenses_Load(object sender, EventArgs e)
        {
            LoadGrid();
            LoadExpenses();
            LoadMaterial();
            LoadPaymentAccounts();
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void grdSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadGridData(e);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            classHelper.JobOrderMaterial_Search(txtSearch, grdSearch);
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            classHelper.CheckNumber(e);
        }
    }
}
