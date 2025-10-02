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
    public partial class frmJobProductMatrialExpenses : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        int jobOrderId = 0;
        int id = 0;
        bool isEdit = false;
        public frmJobProductMatrialExpenses(int jobOrderId)
        {
            InitializeComponent();
            this.jobOrderId = jobOrderId;
        }
        private void Clear()
        {
            txtSearch.Clear();
            dtpDate.Value = DateTime.Now;
            cmbExpense.SelectedIndex = 0;
            txtDescription.Clear();
            txtAmount.Text = "0";
            id = 0;
            isEdit = false;
        }
        private void LoadGrid()
        {
            classHelper.query = @"SELECT A.JOB_ORDER_EXPENSES_ID,A.[DATE],A.EXPENSE_ID,B.COA_NAME AS [EXPENSE],
            A.[DESCRIPTION],A.AMOUNT
            FROM JOB_ORDER_EXPENSES A
            INNER JOIN COA B ON A.EXPENSE_ID = B.COA_ID
            WHERE A.JOB_ORDER_MASTER_ID = '"+jobOrderId+@"'
            ORDER BY A.JOB_ORDER_EXPENSES_ID DESC";
            classHelper.LoadGrid(grdSearch, classHelper.query);
        }

        private void LoadGridData(DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.grdSearch.Rows[e.RowIndex];
            if (e.RowIndex >= 0)
            {
                id = Convert.ToInt32(row.Cells["JOB_ORDER_EXPENSES_ID"].Value.ToString());
                dtpDate.Text = row.Cells["DATE"].Value.ToString();
                txtDescription.Text = row.Cells["DESCRIPTION"].Value.ToString();
                txtAmount.Text = row.Cells["AMOUNT"].Value.ToString();
                cmbExpense.SelectedValue = row.Cells["EXPENSE_ID"].Value.ToString();
            }
        }

        private void Save() {
            if (cmbExpense.SelectedIndex == 0)
            {
                classHelper.ShowMessageBox("Please add Expense.", "Warning");
                cmbExpense.Focus();
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

                classHelper.query += @"IF EXISTS (SELECT JOB_ORDER_EXPENSES_ID FROM JOB_ORDER_EXPENSES WHERE JOB_ORDER_EXPENSES_ID = '" + id + @"') 
                BEGIN
	                UPDATE JOB_ORDER_EXPENSES SET [DATE] = '" + dtpDate.Value.ToString() + @"',
                    [EXPENSE_ID] = '" + cmbExpense.SelectedValue.ToString() + @"',                    
                    [DESCRIPTION] = '" + classHelper.AvoidInjection(txtDescription.Text) + @"',
                    [AMOUNT] = '" + classHelper.AvoidInjection(txtAmount.Text) + @"',
	                MODIFICATION_DATE = GETDATE(),
	                MODIFIED_BY = '" + Classes.Helper.userId + @"'
                    WHERE JOB_ORDER_EXPENSES_ID = '" + id + @"';
                END
                ELSE
                BEGIN
                    INSERT INTO JOB_ORDER_EXPENSES
                    ([DATE],[DESCRIPTION],EXPENSE_ID,AMOUNT,CREATED_BY, CREATION_DATE,JOB_ORDER_MASTER_ID)
	                VALUES('" + dtpDate.Value.ToString() + "', '" + classHelper.AvoidInjection(txtDescription.Text) + @"',
                    '"+cmbExpense.SelectedValue.ToString()+ "','" + classHelper.AvoidInjection(txtAmount.Text) + @"',
                    '" + Classes.Helper.userId + @"', GETDATE(),'"+jobOrderId+@"');
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
        
        private void frmJobProductMatrialExpenses_Load(object sender, EventArgs e)
        {
            LoadGrid();
            LoadExpenses();
        }

        private void grdSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadGridData(e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            Clear();
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            classHelper.CheckNumber(e);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            classHelper.JobOrderExpense_Search(txtSearch, grdSearch);
        }
    }
}
