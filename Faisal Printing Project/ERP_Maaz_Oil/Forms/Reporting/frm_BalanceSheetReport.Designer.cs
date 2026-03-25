namespace ERP_Maaz_Oil.Forms.Reporting
{
    partial class frm_BalanceSheetReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_BalanceSheetReport));
            this.pnlHEADER = new System.Windows.Forms.Panel();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.lblHEADING = new System.Windows.Forms.Label();
            this.grpCASHBOOK = new System.Windows.Forms.GroupBox();
            this.lblTotalHard = new System.Windows.Forms.Label();
            this.lblTotalSoya = new System.Windows.Forms.Label();
            this.lblOpenHard = new System.Windows.Forms.Label();
            this.lblOpenSoya = new System.Windows.Forms.Label();
            this.grdData = new System.Windows.Forms.DataGridView();
            this.purchasesDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.canolaKg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.canolaRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.canolaAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.olienKg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.olienRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.olienAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.muandRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.materialId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soyaKg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soyaRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soyaAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hardKg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hardRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hardAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdOpening = new System.Windows.Forms.DataGridView();
            this.openPurchasesDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openInvoice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openCanolaKg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openCanolaRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openCanolaAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openOlienKg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openOlienRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openOlienAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openMuandRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openMaterialId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblOpenOlien = new System.Windows.Forms.Label();
            this.lblOpenCanola = new System.Windows.Forms.Label();
            this.lblTotalOlien = new System.Windows.Forms.Label();
            this.lblTotalCanola = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_TO = new System.Windows.Forms.DateTimePicker();
            this.btnSHOW = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pnlHEADER.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
            this.grpCASHBOOK.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOpening)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHEADER
            // 
            this.pnlHEADER.BackColor = System.Drawing.Color.Transparent;
            this.pnlHEADER.BackgroundImage = global::ERP_Maaz_Oil.Properties.Resources.header;
            this.pnlHEADER.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlHEADER.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHEADER.Controls.Add(this.pictureBox15);
            this.pnlHEADER.Controls.Add(this.pictureBox14);
            this.pnlHEADER.Controls.Add(this.lblHEADING);
            this.pnlHEADER.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHEADER.Location = new System.Drawing.Point(0, 0);
            this.pnlHEADER.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlHEADER.Name = "pnlHEADER";
            this.pnlHEADER.Size = new System.Drawing.Size(395, 108);
            this.pnlHEADER.TabIndex = 36;
            // 
            // pictureBox15
            // 
            this.pictureBox15.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox15.Location = new System.Drawing.Point(1787, 4);
            this.pictureBox15.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox15.Name = "pictureBox15";
            this.pictureBox15.Size = new System.Drawing.Size(65, 25);
            this.pictureBox15.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox15.TabIndex = 25;
            this.pictureBox15.TabStop = false;
            // 
            // pictureBox14
            // 
            this.pictureBox14.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox14.Location = new System.Drawing.Point(1713, 4);
            this.pictureBox14.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox14.Name = "pictureBox14";
            this.pictureBox14.Size = new System.Drawing.Size(65, 25);
            this.pictureBox14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox14.TabIndex = 24;
            this.pictureBox14.TabStop = false;
            // 
            // lblHEADING
            // 
            this.lblHEADING.AutoSize = true;
            this.lblHEADING.BackColor = System.Drawing.Color.Transparent;
            this.lblHEADING.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.75F);
            this.lblHEADING.ForeColor = System.Drawing.Color.White;
            this.lblHEADING.Location = new System.Drawing.Point(3, 32);
            this.lblHEADING.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHEADING.Name = "lblHEADING";
            this.lblHEADING.Size = new System.Drawing.Size(165, 44);
            this.lblHEADING.TabIndex = 23;
            this.lblHEADING.Text = "BALANCE SHEET \r\nREPORT";
            // 
            // grpCASHBOOK
            // 
            this.grpCASHBOOK.Controls.Add(this.lblTotalHard);
            this.grpCASHBOOK.Controls.Add(this.lblTotalSoya);
            this.grpCASHBOOK.Controls.Add(this.lblOpenHard);
            this.grpCASHBOOK.Controls.Add(this.lblOpenSoya);
            this.grpCASHBOOK.Controls.Add(this.grdData);
            this.grpCASHBOOK.Controls.Add(this.grdOpening);
            this.grpCASHBOOK.Controls.Add(this.lblOpenOlien);
            this.grpCASHBOOK.Controls.Add(this.lblOpenCanola);
            this.grpCASHBOOK.Controls.Add(this.lblTotalOlien);
            this.grpCASHBOOK.Controls.Add(this.lblTotalCanola);
            this.grpCASHBOOK.Controls.Add(this.label1);
            this.grpCASHBOOK.Controls.Add(this.dtp_TO);
            this.grpCASHBOOK.Controls.Add(this.btnSHOW);
            this.grpCASHBOOK.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpCASHBOOK.Location = new System.Drawing.Point(3, 111);
            this.grpCASHBOOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpCASHBOOK.Name = "grpCASHBOOK";
            this.grpCASHBOOK.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpCASHBOOK.Size = new System.Drawing.Size(392, 107);
            this.grpCASHBOOK.TabIndex = 37;
            this.grpCASHBOOK.TabStop = false;
            this.grpCASHBOOK.Text = "BALANCE SHEET REPORT";
            this.grpCASHBOOK.Enter += new System.EventHandler(this.grpSALES_Enter);
            // 
            // lblTotalHard
            // 
            this.lblTotalHard.AutoSize = true;
            this.lblTotalHard.Location = new System.Drawing.Point(495, 68);
            this.lblTotalHard.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalHard.Name = "lblTotalHard";
            this.lblTotalHard.Size = new System.Drawing.Size(19, 23);
            this.lblTotalHard.TabIndex = 356;
            this.lblTotalHard.Text = "0";
            this.lblTotalHard.Visible = false;
            // 
            // lblTotalSoya
            // 
            this.lblTotalSoya.AutoSize = true;
            this.lblTotalSoya.Location = new System.Drawing.Point(492, 36);
            this.lblTotalSoya.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalSoya.Name = "lblTotalSoya";
            this.lblTotalSoya.Size = new System.Drawing.Size(19, 23);
            this.lblTotalSoya.TabIndex = 355;
            this.lblTotalSoya.Text = "0";
            this.lblTotalSoya.Visible = false;
            // 
            // lblOpenHard
            // 
            this.lblOpenHard.AutoSize = true;
            this.lblOpenHard.Location = new System.Drawing.Point(467, 63);
            this.lblOpenHard.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOpenHard.Name = "lblOpenHard";
            this.lblOpenHard.Size = new System.Drawing.Size(19, 23);
            this.lblOpenHard.TabIndex = 354;
            this.lblOpenHard.Text = "0";
            this.lblOpenHard.Visible = false;
            // 
            // lblOpenSoya
            // 
            this.lblOpenSoya.AutoSize = true;
            this.lblOpenSoya.Location = new System.Drawing.Point(464, 31);
            this.lblOpenSoya.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOpenSoya.Name = "lblOpenSoya";
            this.lblOpenSoya.Size = new System.Drawing.Size(19, 23);
            this.lblOpenSoya.TabIndex = 353;
            this.lblOpenSoya.Text = "0";
            this.lblOpenSoya.Visible = false;
            // 
            // grdData
            // 
            this.grdData.AllowUserToAddRows = false;
            this.grdData.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue;
            this.grdData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grdData.BackgroundColor = System.Drawing.Color.White;
            this.grdData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.purchasesDate,
            this.invoice,
            this.canolaKg,
            this.canolaRate,
            this.canolaAmount,
            this.olienKg,
            this.olienRate,
            this.olienAmount,
            this.muandRate,
            this.materialId,
            this.soyaKg,
            this.soyaRate,
            this.soyaAmount,
            this.hardKg,
            this.hardRate,
            this.hardAmount});
            this.grdData.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdData.DefaultCellStyle = dataGridViewCellStyle3;
            this.grdData.Location = new System.Drawing.Point(39, 64);
            this.grdData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grdData.Name = "grdData";
            this.grdData.ReadOnly = true;
            this.grdData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdData.Size = new System.Drawing.Size(55, 22);
            this.grdData.TabIndex = 348;
            this.grdData.TabStop = false;
            this.grdData.Visible = false;
            // 
            // purchasesDate
            // 
            this.purchasesDate.HeaderText = "PURCHASED DATE";
            this.purchasesDate.Name = "purchasesDate";
            this.purchasesDate.ReadOnly = true;
            this.purchasesDate.Width = 182;
            // 
            // invoice
            // 
            this.invoice.HeaderText = "INVOICE";
            this.invoice.Name = "invoice";
            this.invoice.ReadOnly = true;
            this.invoice.Width = 106;
            // 
            // canolaKg
            // 
            this.canolaKg.HeaderText = "CANOLA KG";
            this.canolaKg.Name = "canolaKg";
            this.canolaKg.ReadOnly = true;
            this.canolaKg.Width = 132;
            // 
            // canolaRate
            // 
            this.canolaRate.HeaderText = "CANOLA RATE";
            this.canolaRate.Name = "canolaRate";
            this.canolaRate.ReadOnly = true;
            this.canolaRate.Width = 150;
            // 
            // canolaAmount
            // 
            this.canolaAmount.HeaderText = "CANOLA AMOUNT";
            this.canolaAmount.Name = "canolaAmount";
            this.canolaAmount.ReadOnly = true;
            this.canolaAmount.Width = 185;
            // 
            // olienKg
            // 
            this.olienKg.HeaderText = "OLIEN KG";
            this.olienKg.Name = "olienKg";
            this.olienKg.ReadOnly = true;
            this.olienKg.Width = 113;
            // 
            // olienRate
            // 
            this.olienRate.HeaderText = "OLIEN RATE";
            this.olienRate.Name = "olienRate";
            this.olienRate.ReadOnly = true;
            this.olienRate.Width = 131;
            // 
            // olienAmount
            // 
            this.olienAmount.HeaderText = "OLIEN AMOUNT";
            this.olienAmount.Name = "olienAmount";
            this.olienAmount.ReadOnly = true;
            this.olienAmount.Width = 166;
            // 
            // muandRate
            // 
            this.muandRate.HeaderText = "MUAND RATE";
            this.muandRate.Name = "muandRate";
            this.muandRate.ReadOnly = true;
            this.muandRate.Width = 147;
            // 
            // materialId
            // 
            this.materialId.HeaderText = "MATERIAL ID";
            this.materialId.Name = "materialId";
            this.materialId.ReadOnly = true;
            this.materialId.Width = 140;
            // 
            // soyaKg
            // 
            this.soyaKg.HeaderText = "SOYA KG";
            this.soyaKg.Name = "soyaKg";
            this.soyaKg.ReadOnly = true;
            this.soyaKg.Width = 107;
            // 
            // soyaRate
            // 
            this.soyaRate.HeaderText = "SOYA RATE";
            this.soyaRate.Name = "soyaRate";
            this.soyaRate.ReadOnly = true;
            this.soyaRate.Width = 125;
            // 
            // soyaAmount
            // 
            this.soyaAmount.HeaderText = "SOYA AMOUNT";
            this.soyaAmount.Name = "soyaAmount";
            this.soyaAmount.ReadOnly = true;
            this.soyaAmount.Width = 160;
            // 
            // hardKg
            // 
            this.hardKg.HeaderText = "HARD KG";
            this.hardKg.Name = "hardKg";
            this.hardKg.ReadOnly = true;
            this.hardKg.Width = 112;
            // 
            // hardRate
            // 
            this.hardRate.HeaderText = "HARD RATE";
            this.hardRate.Name = "hardRate";
            this.hardRate.ReadOnly = true;
            this.hardRate.Width = 130;
            // 
            // hardAmount
            // 
            this.hardAmount.HeaderText = "HARD AMOUNT";
            this.hardAmount.Name = "hardAmount";
            this.hardAmount.ReadOnly = true;
            this.hardAmount.Width = 165;
            // 
            // grdOpening
            // 
            this.grdOpening.AllowUserToAddRows = false;
            this.grdOpening.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightBlue;
            this.grdOpening.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.grdOpening.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdOpening.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grdOpening.BackgroundColor = System.Drawing.Color.White;
            this.grdOpening.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdOpening.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.grdOpening.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdOpening.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.openPurchasesDate,
            this.openInvoice,
            this.openCanolaKg,
            this.openCanolaRate,
            this.openCanolaAmount,
            this.openOlienKg,
            this.openOlienRate,
            this.openOlienAmount,
            this.openMuandRate,
            this.openMaterialId});
            this.grdOpening.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdOpening.DefaultCellStyle = dataGridViewCellStyle6;
            this.grdOpening.Location = new System.Drawing.Point(8, 68);
            this.grdOpening.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grdOpening.Name = "grdOpening";
            this.grdOpening.ReadOnly = true;
            this.grdOpening.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdOpening.Size = new System.Drawing.Size(31, 22);
            this.grdOpening.TabIndex = 344;
            this.grdOpening.TabStop = false;
            this.grdOpening.Visible = false;
            // 
            // openPurchasesDate
            // 
            this.openPurchasesDate.HeaderText = "PURCHASED DATE";
            this.openPurchasesDate.Name = "openPurchasesDate";
            this.openPurchasesDate.ReadOnly = true;
            this.openPurchasesDate.Width = 182;
            // 
            // openInvoice
            // 
            this.openInvoice.HeaderText = "INVOICE";
            this.openInvoice.Name = "openInvoice";
            this.openInvoice.ReadOnly = true;
            this.openInvoice.Width = 106;
            // 
            // openCanolaKg
            // 
            this.openCanolaKg.HeaderText = "CANOLA KG";
            this.openCanolaKg.Name = "openCanolaKg";
            this.openCanolaKg.ReadOnly = true;
            this.openCanolaKg.Width = 132;
            // 
            // openCanolaRate
            // 
            this.openCanolaRate.HeaderText = "CANOLA RATE";
            this.openCanolaRate.Name = "openCanolaRate";
            this.openCanolaRate.ReadOnly = true;
            this.openCanolaRate.Width = 150;
            // 
            // openCanolaAmount
            // 
            this.openCanolaAmount.HeaderText = "CANOLA AMOUNT";
            this.openCanolaAmount.Name = "openCanolaAmount";
            this.openCanolaAmount.ReadOnly = true;
            this.openCanolaAmount.Width = 185;
            // 
            // openOlienKg
            // 
            this.openOlienKg.HeaderText = "OLIEN KG";
            this.openOlienKg.Name = "openOlienKg";
            this.openOlienKg.ReadOnly = true;
            this.openOlienKg.Width = 113;
            // 
            // openOlienRate
            // 
            this.openOlienRate.HeaderText = "OLIEN RATE";
            this.openOlienRate.Name = "openOlienRate";
            this.openOlienRate.ReadOnly = true;
            this.openOlienRate.Width = 131;
            // 
            // openOlienAmount
            // 
            this.openOlienAmount.HeaderText = "OLIEN AMOUNT";
            this.openOlienAmount.Name = "openOlienAmount";
            this.openOlienAmount.ReadOnly = true;
            this.openOlienAmount.Width = 166;
            // 
            // openMuandRate
            // 
            this.openMuandRate.HeaderText = "MUAND RATE";
            this.openMuandRate.Name = "openMuandRate";
            this.openMuandRate.ReadOnly = true;
            this.openMuandRate.Width = 147;
            // 
            // openMaterialId
            // 
            this.openMaterialId.HeaderText = "MATERIAL ID";
            this.openMaterialId.Name = "openMaterialId";
            this.openMaterialId.ReadOnly = true;
            this.openMaterialId.Width = 140;
            // 
            // lblOpenOlien
            // 
            this.lblOpenOlien.AutoSize = true;
            this.lblOpenOlien.Location = new System.Drawing.Point(439, 69);
            this.lblOpenOlien.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOpenOlien.Name = "lblOpenOlien";
            this.lblOpenOlien.Size = new System.Drawing.Size(19, 23);
            this.lblOpenOlien.TabIndex = 343;
            this.lblOpenOlien.Text = "0";
            this.lblOpenOlien.Visible = false;
            // 
            // lblOpenCanola
            // 
            this.lblOpenCanola.AutoSize = true;
            this.lblOpenCanola.Location = new System.Drawing.Point(436, 37);
            this.lblOpenCanola.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOpenCanola.Name = "lblOpenCanola";
            this.lblOpenCanola.Size = new System.Drawing.Size(19, 23);
            this.lblOpenCanola.TabIndex = 342;
            this.lblOpenCanola.Text = "0";
            this.lblOpenCanola.Visible = false;
            // 
            // lblTotalOlien
            // 
            this.lblTotalOlien.AutoSize = true;
            this.lblTotalOlien.Location = new System.Drawing.Point(411, 64);
            this.lblTotalOlien.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalOlien.Name = "lblTotalOlien";
            this.lblTotalOlien.Size = new System.Drawing.Size(19, 23);
            this.lblTotalOlien.TabIndex = 341;
            this.lblTotalOlien.Text = "0";
            this.lblTotalOlien.Visible = false;
            // 
            // lblTotalCanola
            // 
            this.lblTotalCanola.AutoSize = true;
            this.lblTotalCanola.Location = new System.Drawing.Point(408, 32);
            this.lblTotalCanola.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalCanola.Name = "lblTotalCanola";
            this.lblTotalCanola.Size = new System.Drawing.Size(19, 23);
            this.lblTotalCanola.TabIndex = 340;
            this.lblTotalCanola.Text = "0";
            this.lblTotalCanola.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 23);
            this.label1.TabIndex = 121;
            this.label1.Text = "UPTO: ";
            // 
            // dtp_TO
            // 
            this.dtp_TO.CustomFormat = "dd/MM/yyyy";
            this.dtp_TO.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.dtp_TO.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_TO.Location = new System.Drawing.Point(101, 28);
            this.dtp_TO.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtp_TO.Name = "dtp_TO";
            this.dtp_TO.Size = new System.Drawing.Size(280, 27);
            this.dtp_TO.TabIndex = 120;
            // 
            // btnSHOW
            // 
            this.btnSHOW.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(68)))), ((int)(((byte)(2)))));
            this.btnSHOW.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSHOW.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSHOW.ForeColor = System.Drawing.Color.White;
            this.btnSHOW.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSHOW.ImageIndex = 5;
            this.btnSHOW.ImageList = this.imageList1;
            this.btnSHOW.Location = new System.Drawing.Point(101, 64);
            this.btnSHOW.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSHOW.Name = "btnSHOW";
            this.btnSHOW.Size = new System.Drawing.Size(281, 31);
            this.btnSHOW.TabIndex = 9;
            this.btnSHOW.Text = "SHOW";
            this.btnSHOW.UseVisualStyleBackColor = false;
            this.btnSHOW.Click += new System.EventHandler(this.btnINTER_SAVE_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icons8-Save as Filled-100.png");
            this.imageList1.Images.SetKeyName(1, "icons8-Cancel Filled-100.png");
            this.imageList1.Images.SetKeyName(2, "icons8-Future Filled-50 (1).png");
            this.imageList1.Images.SetKeyName(3, "icons8-Marker-48.png");
            this.imageList1.Images.SetKeyName(4, "icons8-Traffic Jam Filled-100.png");
            this.imageList1.Images.SetKeyName(5, "icons8-show-property-filled-50.png");
            // 
            // frm_BalanceSheetReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(395, 212);
            this.Controls.Add(this.grpCASHBOOK);
            this.Controls.Add(this.pnlHEADER);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximumSize = new System.Drawing.Size(413, 259);
            this.Name = "frm_BalanceSheetReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BALANCE SHEET REPORT";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_Account_Ledger_FormClosed);
            this.Load += new System.EventHandler(this.frm_Account_Ledger_Load);
            this.pnlHEADER.ResumeLayout(false);
            this.pnlHEADER.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
            this.grpCASHBOOK.ResumeLayout(false);
            this.grpCASHBOOK.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOpening)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHEADER;
        private System.Windows.Forms.PictureBox pictureBox15;
        private System.Windows.Forms.PictureBox pictureBox14;
        private System.Windows.Forms.Label lblHEADING;
        private System.Windows.Forms.GroupBox grpCASHBOOK;
        private System.Windows.Forms.Button btnSHOW;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DateTimePicker dtp_TO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalCanola;
        private System.Windows.Forms.Label lblTotalOlien;
        private System.Windows.Forms.DataGridView grdOpening;
        private System.Windows.Forms.Label lblOpenOlien;
        private System.Windows.Forms.Label lblOpenCanola;
        private System.Windows.Forms.DataGridViewTextBoxColumn openPurchasesDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn openInvoice;
        private System.Windows.Forms.DataGridViewTextBoxColumn openCanolaKg;
        private System.Windows.Forms.DataGridViewTextBoxColumn openCanolaRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn openCanolaAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn openOlienKg;
        private System.Windows.Forms.DataGridViewTextBoxColumn openOlienRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn openOlienAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn openMuandRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn openMaterialId;
        private System.Windows.Forms.DataGridView grdData;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchasesDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoice;
        private System.Windows.Forms.DataGridViewTextBoxColumn canolaKg;
        private System.Windows.Forms.DataGridViewTextBoxColumn canolaRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn canolaAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn olienKg;
        private System.Windows.Forms.DataGridViewTextBoxColumn olienRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn olienAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn muandRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn materialId;
        private System.Windows.Forms.DataGridViewTextBoxColumn soyaKg;
        private System.Windows.Forms.DataGridViewTextBoxColumn soyaRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn soyaAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn hardKg;
        private System.Windows.Forms.DataGridViewTextBoxColumn hardRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn hardAmount;
        private System.Windows.Forms.Label lblTotalHard;
        private System.Windows.Forms.Label lblTotalSoya;
        private System.Windows.Forms.Label lblOpenHard;
        private System.Windows.Forms.Label lblOpenSoya;
    }
}