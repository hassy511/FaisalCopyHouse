using System;
using System.Windows.Forms;

namespace ERP_Maaz_Oil.Forms
{
    public partial class LogIn : Form
    {
        Classes.Helper db = new Classes.Helper();
        public LogIn()
        {
            InitializeComponent();
        }
        
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Enter))
            {
                if (DateTime.Now > Convert.ToDateTime("2025-01-31"))
                {
                    MessageBox.Show("Software has been expired, please contact support!");
                }
                else
                {
                    Classes.SignIn sign = new Classes.SignIn();
                    if (sign.login(txtUser, txtPassword) == "success")
                    {
                        Forms.frmDashboard main = new frmDashboard();
                        main.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("User Name or Password is Invalid.!");
                    }
                }
            }
            if (keyData == (Keys.Escape))
            {
                this.Dispose();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void LogIn_Load(object sender, EventArgs e)
        {

        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if (DateTime.Now > Convert.ToDateTime("2025-01-31"))
            {
                MessageBox.Show("Software has been expired, please contact support!");
            }
            else { 
                Classes.SignIn sign = new Classes.SignIn();
                if (sign.login(txtUser, txtPassword) == "success")
                {
                    Forms.frmDashboard main = new frmDashboard();
                    main.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("User Name or Password is Invalid.!");
                }
            }
        }
    }
}
