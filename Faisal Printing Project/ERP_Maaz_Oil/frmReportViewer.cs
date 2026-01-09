using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP_Maaz_Oil
{
    public partial class frmReportViewer : Form
    {
     
        private object rpt;

        public frmReportViewer(object report)
        {
            InitializeComponent();
            rpt = report;
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            crystalReportViewer1.ReportSource = rpt;  
        }
    }
}