using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP_Maaz_Oil.Forms
{
    public partial class frmBackUpRestoreDatabase : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        public frmBackUpRestoreDatabase()
        {
            InitializeComponent();
        }

        private void RestoreBrowse()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "SQL SERVER database backup files|*.bak";
            dlg.Title = "Database Restore";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = dlg.FileName;
                btnRestore.Enabled = true;
            }
        }

        private void RestoreDB()
        {
            string database = Classes.Helper.conn.Database.ToString();
            try
            {
                if (Classes.Helper.conn.State != ConnectionState.Open)
                {
                    Classes.Helper.conn.Open();
                }
                string sqlStat2 = string.Format("ALTER DATABASE [" + database + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                SqlCommand bu2 = new SqlCommand(sqlStat2, Classes.Helper.conn);
                bu2.ExecuteNonQuery();

                string sqlStat3 = "USE MASTER RESTORE DATABASE [" + database + "] FROM DISK = '" + txtFileName.Text + "' WITH REPLACE;";
                SqlCommand bu3 = new SqlCommand(sqlStat3, Classes.Helper.conn);
                bu3.ExecuteNonQuery();

                string sqlStat4 = string.Format("ALTER DATABASE [" + database + "] SET MULTI_USER");
                SqlCommand bu4 = new SqlCommand(sqlStat4, Classes.Helper.conn);
                bu4.ExecuteNonQuery();

                Classes.Helper.conn.Close();
                classHelper.ShowMessageBox("Database Restore Sucessfully.!", "Information");
                btnRestore.Enabled = false;
                txtFileName.Text = "";

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally {
                Classes.Helper.conn.Close();
            }
        }

        private void btnDetailReport_Click(object sender, EventArgs e)
        {
            RestoreBrowse();
        }

        private void btnSHOW_Click(object sender, EventArgs e)
        {
            RestoreDB();
        }
    }
}
