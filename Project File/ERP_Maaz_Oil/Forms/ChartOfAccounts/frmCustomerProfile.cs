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
    public partial class frmCustomerProfile : Form
    {
        Classes.Helper cls_fhp = new Classes.Helper();
        string id = "";
        int is_edit = 0;

        public frmCustomerProfile()
        {
            InitializeComponent();
        }

        string query = @"SELECT
        A.CUST_PRO,C.COA_NAME,A.COA_ID,A.SALE_PER_ID,D.NAME as [SALES PERSON],
        A.CONTACT_PERSON,A.MOBILE,A.EMAIL,A.ADDRESS,A.CITY_ID,B.CITY_NAME as [CITY],A.AREA_ID,E.AREA_NAME,A.NTN_NUMBER,
        A.STRN_NUMBER,A.GST_NUMBER,convert(varchar(100), A.CREDIT_LIMIT) as CREDIT_LIMIT,A.STAT,A.CREDIT_DAYS as [CREDIT DAYS],
        A.CNIC,A.EXPIRY
        FROM CUSTOMER_PROFILE A, CITY B, COA C, SALES_PERSONS D,AREA E
        WHERE A.COA_ID=C.COA_ID and A.CITY_ID=B.CITY_ID and A.SALE_PER_ID=D.SALES_PER_ID AND A.AREA_ID = E.AREA_ID
        order by a.MODIFICATION_DATE desc";
        //load BANK PROFILE


        private void load_AREA()
        {
            try
            {
                cls_fhp.query = "select 0 as [id],'--SELECT AREA--' as [name] UNION select AREA_ID as [id],AREA_NAME as [name] from AREA ORDER BY NAME";
                cls_fhp.LoadComboData(cmbArea, cls_fhp.query);
            }
            catch (Exception ex) { cls_fhp.ShowMessageBox(ex.ToString(), "Exception"); }
        }
        private void load_Customer()
        {
            try
            {
                cls_fhp.query = "SELECT '0' AS [id], '--SELECT CUSTOMER--' AS [name] UNION SELECT COA_ID AS [id],COA_NAME AS [name] FROM COA WHERE CA_ID = 21";
                cls_fhp.LoadComboData(cmbCUS, cls_fhp.query);
            }
            catch (Exception ex) { cls_fhp.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        private void load_Saller()
        {
            try
            {
                cls_fhp.query = @"SELECT '0' AS [id], '--SELECT SALES PERSON--' AS [name] 
                    UNION SELECT SALES_PER_ID AS [id],NAME AS [name] FROM SALES_PERSONS WHERE STAT = 0";
                cls_fhp.LoadComboData(cmbSP, cls_fhp.query);
            }
            catch (Exception ex) { cls_fhp.ShowMessageBox(ex.ToString(), "Exception"); }
        }

        //load City
        
        private void load_city()
        {
            try
            {
                cls_fhp.query = "select 0 as [id],'--SELECT CITY--' as [name] UNION select CITY_ID as [id],CITY_NAME as [name] from CITY ORDER BY NAME";
                cls_fhp.LoadComboData(cmbCITY, cls_fhp.query);
            }

            catch (Exception ex) { cls_fhp.ShowMessageBox(ex.ToString(), "Exception"); }
        }


        //clear fields in form
        private void clear() {
            txtCNIC.Clear();
            dtp_Expiry.Value = DateTime.Now;
            cmbCITY.SelectedIndex = 0;
            cmbArea.SelectedIndex = 0;
            cmbCUS.SelectedIndex = 0;
            txtNTN.Clear();
            txtSEARCH.Clear();
            id = "";
            txtEMAIL.Clear();
            txtMOBILE.Clear();
            cmbSP.SelectedIndex = 0;
            txtADDRESS.Clear();
            txtCONTACT_PERSON.Clear();
            txtLIMIT.Clear();
            txtSTRN.Clear();
            txtGST.Clear();
            txtCreditDays.Clear();
            is_edit = 0;
        }


        //get data from grid on click
        private void load_data_fromGrid(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.grdSEARCH.Rows[e.RowIndex];
                is_edit = 1;
                cmbCUS.SelectedValue = row.Cells[2].Value.ToString();
                cmbSP.SelectedValue = row.Cells[3].Value.ToString();
                txtCONTACT_PERSON.Text = row.Cells[5].Value.ToString();
                txtMOBILE.Text = row.Cells[6].Value.ToString();
                txtEMAIL.Text = row.Cells[7].Value.ToString();
                txtADDRESS.Text = row.Cells[8].Value.ToString();
                cmbCITY.SelectedValue = row.Cells[9].Value.ToString();
                cmbArea.SelectedValue = row.Cells[11].Value.ToString();
                txtNTN.Text = row.Cells[13].Value.ToString();
                txtSTRN.Text = row.Cells[14].Value.ToString();
                txtGST.Text = row.Cells[15].Value.ToString();
                txtLIMIT.Text = row.Cells[16].Value.ToString();
                txtCreditDays.Text = row.Cells[18].Value.ToString();
                txtCNIC.Text = row.Cells["CNIC"].Value.ToString();
                object v = row.Cells["EXPIRY"].Value;
                if (v != DBNull.Value) {
                    dtp_Expiry.Value = Convert.ToDateTime(row.Cells["EXPIRY"].Value.ToString());
                }
                
                if (row.Cells[17].Value.ToString().Equals("0"))
                {
                    chkDeActive.Checked = false;
                }
                else
                {
                    chkDeActive.Checked = true;
                }
            }
        }

        private void frm_AddGroupAccounts_Load(object sender, EventArgs e)
        {
            cls_fhp.LoadGrid(grdSEARCH, query);
            load_Saller();
            load_city();
            load_AREA();
            load_Customer();
        }

        private void txtSEARCH_TextChanged(object sender, EventArgs e)
        {
            cls_fhp.CUSTOMER_Profile_grid_search(txtSEARCH, grdSEARCH);
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {
            if (cmbCUS.SelectedIndex == 0)
            {
                cls_fhp.ShowMessageBox("Customer is not selected, please select Customer.", "Warning");
                cmbCUS.Focus();
            }
            else if (txtNTN.Text.Trim().Equals(""))
            {
                cls_fhp.ShowMessageBox("NTN number field is blank.", "Warning");
                txtNTN.Focus();
            }

            else if (txtSTRN.Text.Trim().Equals(""))
            {
                cls_fhp.ShowMessageBox("STRN # field is blank.", "Warning");
                txtSTRN.Focus();
            }

            else if (txtGST.Text.Trim().Equals(""))
            {
                cls_fhp.ShowMessageBox("GST number field is blank.", "Warning");
                txtGST.Focus();
            }

            else if (txtMOBILE.Text.Trim().Equals(""))
            {
                cls_fhp.ShowMessageBox("Mobile field is blank.", "Warning");
                txtMOBILE.Focus();
            }
             else if (cmbSP.SelectedIndex == 0)
            {
                cls_fhp.ShowMessageBox("SUPPLIER TYPE is not selected, please select TYPE.", "Warning");
                cmbSP.Focus();
            }

            else if (txtEMAIL.Text.Trim().Equals(""))
            {
                cls_fhp.ShowMessageBox("Email field is blank.", "Warning");
                txtEMAIL.Focus();
            }
            else if (cmbCITY.SelectedIndex == 0)
            {
                cls_fhp.ShowMessageBox("City is not selected, please select city.", "Warning");
                cmbCITY.Focus();
            }
            else if (cmbArea.SelectedIndex == 0)
            {
                cls_fhp.ShowMessageBox("Area is not selected, please select Area.", "Warning");
                cmbArea.Focus();
            }

            else if (txtLIMIT.Text.Trim().Equals(""))
            {
                cls_fhp.ShowMessageBox("Credit limit field is blank.", "Warning");
                txtLIMIT.Focus();
            }
            else if (txtCONTACT_PERSON.Text.Trim().Equals(""))
            {
                cls_fhp.ShowMessageBox("Contact Person field is blank.", "Warning");
                txtCONTACT_PERSON.Focus();
            }
            else if (txtADDRESS.Text.Trim().Equals(""))
            {
                cls_fhp.ShowMessageBox("Address field is blank.", "Warning");
                txtADDRESS.Focus();
            }
            else if (txtCreditDays.Text.Trim().Equals(""))
            {
                cls_fhp.ShowMessageBox("Credit Days field is blank.", "Warning");
                txtCreditDays.Focus();
            }
            else
            {
                int status = 0;
                if (chkDeActive.Checked == true)
                {
                    status = 1;
                }
                cls_fhp.query = @"IF EXISTS (select COA_ID from CUSTOMER_PROFILE 
                                  WHERE COA_ID ='" + cmbCUS.SelectedValue.ToString()+
                    "') UPDATE CUSTOMER_PROFILE SET NTN_NUMBER = '" + txtNTN.Text+ 
                    "',STRN_NUMBER= '" + cls_fhp.AvoidInjection(txtSTRN.Text) + 
                    "' ,GST_NUMBER= '" + cls_fhp.AvoidInjection(txtGST.Text) + 
                    "',MOBILE = '" + cls_fhp.AvoidInjection(txtMOBILE.Text) + 
                    "',EMAIL = '" + cls_fhp.AvoidInjection(txtEMAIL.Text) +
                    "',ADDRESS = '" + cls_fhp.AvoidInjection(txtADDRESS.Text) +
                    "',CITY_ID = '" + cmbCITY.SelectedValue.ToString() +
                    "',AREA_ID = '" + cmbArea.SelectedValue.ToString() +
                    "',SALE_PER_ID = '" + cmbSP.SelectedValue.ToString() +
                    "',COA_ID = '" + cmbCUS.SelectedValue.ToString() +
                    "',CREDIT_LIMIT = '" + cls_fhp.AvoidInjection(txtLIMIT.Text) +
                    "',CONTACT_PERSON = '" + cls_fhp.AvoidInjection(txtCONTACT_PERSON.Text)+
                    "',STAT = '" + status +
                    "',CREDIT_DAYS = '" + cls_fhp.AvoidInjection(txtCreditDays.Text) +
                    "',MODIFICATION_DATE = '" + DateTime.Now + 
                    "', MODIFIED_BY = '" + Classes.Helper.userId +
                    "', CNIC = '" + cls_fhp.AvoidInjection(txtCNIC.Text) +
                    "', EXPIRY = '" + dtp_Expiry.Value.Date +
                    "' WHERE COA_ID = '" + cmbCUS.SelectedValue.ToString() +
                    "' ELSE INSERT INTO CUSTOMER_PROFILE VALUES('"
                    + cmbCUS.SelectedValue.ToString()+"','" + cmbSP.SelectedValue.ToString() + "','"
                    + cls_fhp.AvoidInjection(txtCONTACT_PERSON.Text) +
                    "','" + cls_fhp.AvoidInjection(txtMOBILE.Text) 
                    +"','"+ cls_fhp.AvoidInjection(txtEMAIL.Text) + 
                    "', '" + cls_fhp.AvoidInjection(txtADDRESS.Text) + 
                    "','" + cmbCITY.SelectedValue.ToString()  + 
                    "','" + cls_fhp.AvoidInjection(txtNTN.Text) + 
                    "', '" + cls_fhp.AvoidInjection(txtSTRN.Text) +
                    "','" + cls_fhp.AvoidInjection(txtGST.Text) + 
                    "','" + cls_fhp.AvoidInjection(txtLIMIT.Text) 
                    + "','" + cls_fhp.AvoidInjection(cmbArea.SelectedValue.ToString())
                    + "','" + status + "',GETDATE(),1,NULL,1,1,'" + cls_fhp.AvoidInjection(txtCreditDays.Text)+ @"'
                    ,'" + cls_fhp.AvoidInjection(txtCNIC.Text) + "','" + dtp_Expiry.Value.Date + "')";
                    
                if (cls_fhp.InsertUpdateDelete(cls_fhp.query) >= 1) {
                    cls_fhp.ShowMessageBox("Record Saved Sucessfully.", "Information");
                    clear();
                    cls_fhp.LoadGrid(grdSEARCH, query);
                }

            }
        }

        private void cmbPACCOUNT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCITY.SelectedIndex > 0)
            {
                cls_fhp.load_area(cmbArea, cmbCITY.SelectedValue.ToString());
                cmbArea.Enabled = true;
            }
            else
            {
                cmbArea.Enabled = false;
            }
        }

        private void grdSEARCH_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            grdSEARCH.Columns[0].Visible = false;
            grdSEARCH.Columns[2].Visible = false;
            grdSEARCH.Columns[3].Visible = false;
            grdSEARCH.Columns[9].Visible = false;
            grdSEARCH.Columns[11].Visible = false;
            grdSEARCH.Columns[17].Visible = false;

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
            cls_fhp.select_all_text(sender as TextBox);
        }

        private void txtPHONE_Enter(object sender, EventArgs e)
        {
            cls_fhp.select_all_text(sender as TextBox);
        }

        private void txtPHONE_Leave(object sender, EventArgs e)
        {
            
        }

        private void cmbVENDOR_TextUpdate(object sender, EventArgs e)
        {
            cls_fhp.CmbTextUpdate(sender as ComboBox);
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

        private void txtPHONE_KeyPress(object sender, KeyPressEventArgs e)
        {
            cls_fhp.AllowNumbers(e);
        }

        

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtLIMIT_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnADD_CITY_Click(object sender, EventArgs e)
        {
            using (cls_fhp.frmAddCity = new frmAddCity())
            {
                if (cls_fhp.frmAddCity.ShowDialog() == System.Windows.Forms.DialogResult.Cancel || cls_fhp.frmAddCity.ShowDialog() == System.Windows.Forms.DialogResult.Abort)
                {
                    cls_fhp.load_city(cmbCITY);
                }
            }
        }

        private void btnAddArea_Click(object sender, EventArgs e)
        {
            using (cls_fhp.frmAddArea = new frmAddArea())
            {
                if (cls_fhp.frmAddArea.ShowDialog() == System.Windows.Forms.DialogResult.Cancel || cls_fhp.frmAddArea.ShowDialog() == System.Windows.Forms.DialogResult.Abort)
                {
                    cls_fhp.load_area(cmbArea, cmbCITY.SelectedValue.ToString());
                }
            }
        }

        private void cmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbCUS_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbCUS.SelectedIndex == 0)
                {
                    clear();
                }
                else {
                    cls_fhp.GetCustomerData(grdSEARCH, cmbCUS.SelectedValue.ToString(), txtNTN, txtSTRN, txtGST, txtMOBILE, cmbSP, txtEMAIL, cmbCITY, cmbArea, txtCONTACT_PERSON, txtLIMIT, txtADDRESS, chkDeActive,txtCreditDays);
                }
            }
                
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void txtCNIC_TextChanged(object sender, EventArgs e)
        {
            if ((txtCNIC.Text.Length == 5 || txtCNIC.Text.Length == 13) && isBackSpace == false) {
                txtCNIC.AppendText("-");
            }
        }

        bool isBackSpace = false;

        private void txtCONTACT_PERSON_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txtCNIC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                isBackSpace = true;
            }
            else
            {
                isBackSpace = false;
            }
        }

        private void txtMOBILE_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCreditDays_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEMAIL_TextChanged(object sender, EventArgs e)
        {

        }

        private void grdSEARCH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
