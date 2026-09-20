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
    public partial class frmAddBroker : Form
    {
        Classes.Helper cls_fhp = new Classes.Helper();
        string id = "";
        int is_edit = 0;

        public frmAddBroker()
        {
            InitializeComponent();
        }
        //============loading grid query--------------------->
            string query = @"SELECT A.BROKER_ID,A.NAME,A.MOBILE,A.EMAIL,A.COMMISSION_VALUE AS [COMMISSION VALUE],CASE 
            WHEN COMISSION_TYPE =1  
            THEN 'Rupess' 
            ELSE '%' END as COMISSION_TYPE  
            ,A.CITY_ID,B.CITY_NAME as [CITY],A.STAT FROM BROKER A,CITY B
            WHERE A.CITY_ID = B.CITY_ID";
        //load Broker

        private void load_broker()
        {
            try
            {
                cls_fhp.query = "SELECT '0' AS [id], '--SELECT BROKER--' AS [name] UNION SELECT COA_ID AS [id],COA_NAME AS [name] FROM COA WHERE CA_ID = 24";
                cls_fhp.LoadComboData(cmbBROKER, cls_fhp.query);
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
            cmbCITY.SelectedIndex = 0;
            cmbBROKER.SelectedIndex = 0;
            cmbCOMISSION.Text = "--------SELECT TYPE---------";
            txtCOMISSION.Clear();
            txtSEARCH.Clear();
            id = "";
            txtEMAIL.Clear();
            txtMOBILE.Clear();
            is_edit = 0;
        }


        //get data from grid on click
        private void load_data_fromGrid(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.grdSEARCH.Rows[e.RowIndex];
                id = row.Cells[0].Value.ToString();
                is_edit = 1;

                cmbBROKER.Text = row.Cells[1].Value.ToString();
                txtMOBILE.Text = row.Cells[2].Value.ToString();
                txtEMAIL.Text = row.Cells[3].Value.ToString();
                txtCOMISSION.Text = row.Cells[4].Value.ToString();
                cmbCITY.Text = row.Cells[7].Value.ToString();

                cmbCOMISSION.Text = row.Cells[5].Value.ToString();
                

                

                if (row.Cells[8].Value.ToString().Equals("0"))
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
           
            load_broker();
            load_city();
            
        }

        private void txtSEARCH_TextChanged(object sender, EventArgs e)
        {
            cls_fhp.Broker_grid_search(txtSEARCH, grdSEARCH);
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {
            string cm=(cmbCOMISSION.SelectedIndex+1).ToString();
            if (cmbBROKER.SelectedIndex == 0)
            {
                cls_fhp.ShowMessageBox("Broker is not selected, please select Broker.", "Warning");
                cmbBROKER.Focus();
            }
            else if (txtEMAIL.Text.Trim().Equals(""))
            {
                cls_fhp.ShowMessageBox("Email field is blank.", "Warning");
                txtEMAIL.Focus();
            }
            else if (txtMOBILE.Text.Trim().Equals(""))
            {
                cls_fhp.ShowMessageBox("Mobile field is blank.", "Warning");
                txtMOBILE.Focus();
            }

            else if (cmbCITY.SelectedIndex == 0)
            {
                cls_fhp.ShowMessageBox("City is not selected, please select city.", "Warning");
                cmbCITY.Focus();
            }
            else if (txtCOMISSION.Text.Trim().Equals(""))
            {
                cls_fhp.ShowMessageBox("Commision field is blank.", "Warning");
                txtCOMISSION.Focus();
            }

            else if (cmbCOMISSION.Text.Equals("--------SELECT TYPE---------"))
            {
                cls_fhp.ShowMessageBox("Commision Type is not selected, please select comission type.", "Warning");
                cmbCOMISSION.Focus();
            }

            else {
                int status = 0;
                if (chkDeActive.Checked == true)
                {
                    status = 1;
                }
                cls_fhp.query = @"IF EXISTS (select BROKER_ID from BROKER WHERE BROKER_ID ='"+cmbBROKER.SelectedValue.ToString()+@"') 
                    UPDATE BROKER SET NAME = '" + cmbBROKER.Text+ "',MOBILE = '" + cls_fhp.AvoidInjection(txtMOBILE.Text) + "',EMAIL = '" + cls_fhp.AvoidInjection(txtEMAIL.Text) 
                    + "',CITY_ID = '" + cmbCITY.SelectedValue.ToString() + "',COMMISSION_VALUE = '" 
                    + cls_fhp.AvoidInjection(txtCOMISSION.Text) + "',COMISSION_TYPE = '" + cm 
                    + "',STAT = '" + status + "',MODIFICATION_DATE = '" 
                    + DateTime.Now + "', MODIFIED_BY = '" + Classes.Helper.userId 
                    + "' WHERE BROKER_ID = '"+cmbBROKER.SelectedValue.ToString()+"' ELSE INSERT INTO BROKER VALUES('"+cmbBROKER.SelectedValue.ToString()+"','"
                    +cmbBROKER.Text+"', '"+ cls_fhp.AvoidInjection(txtMOBILE.Text) + "', '" 
                    + cls_fhp.AvoidInjection(txtEMAIL.Text) + "', '"
                    +cmbCITY.SelectedValue.ToString()+"','"
                    + cls_fhp.AvoidInjection(txtCOMISSION.Text) 
                    + "','"+cm+"','"+status+"',GETDATE(), 1,NULL,0,1)";
                    
                if (cls_fhp.InsertUpdateDelete(cls_fhp.query) >= 1) {
                    cls_fhp.ShowMessageBox("Record Saved Sucessfully.", "Information");
                    clear();
                    cls_fhp.LoadGrid(grdSEARCH, query);
                }

            }
        }

        private void cmbPACCOUNT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBROKER.SelectedIndex > 0) {
                cls_fhp.LoadBrokerDetails(grdSEARCH,cmbBROKER.SelectedValue.ToString(),txtEMAIL,txtMOBILE,cmbCITY,txtCOMISSION,cmbCOMISSION,chkDeActive);
            }
        }

        private void grdSEARCH_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            grdSEARCH.Columns[0].Visible = false;
            grdSEARCH.Columns[6].Visible = false;
            grdSEARCH.Columns[8].Visible = false;

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

        private void txtCOMISSION_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                cls_fhp.AllowNumbers(e);
            }
            catch (Exception ex) { cls_fhp.ShowMessageBox(ex.ToString(), "Exception"); }
        }
    }
}
