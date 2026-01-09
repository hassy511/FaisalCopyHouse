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
    public partial class frmBackUpDatabase : Form
    {
        Classes.Helper classHelper = new Classes.Helper();
        public frmBackUpDatabase()
        {
            InitializeComponent();
        }

        private void Browse()
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = dlg.SelectedPath;
                btnBackup.Enabled = true;
            }
        }

        private void BackupDB()
        {
            string database = Classes.Helper.conn.Database.ToString();
            try
            {
                if (txtFileName.Text.Equals(""))
                {
                    MessageBox.Show("Please Select File.!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string cmd = "BACKUP DATABASE [" + database + "] TO DISK= '" + txtFileName.Text + "\\" + "STOVE_BackUp" + "-" + DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss") + ".bak'";
                    using (SqlCommand command = new SqlCommand(cmd, Classes.Helper.conn))
                    {
                        if (Classes.Helper.conn.State != ConnectionState.Open)
                        {
                            Classes.Helper.conn.Open();
                        }
                        command.ExecuteNonQuery();
                        Classes.Helper.conn.Close();
                        MessageBox.Show("Database Backup Sucessfully.!");
                        btnBackup.Enabled = false;
                        txtFileName.Text = "";
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnDetailReport_Click(object sender, EventArgs e)
        {
            Browse();
        }

        private void btnSHOW_Click(object sender, EventArgs e)
        {
            BackupDB();
        }
    }
}
