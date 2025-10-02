namespace ERP_Maaz_Oil.Forms
{
    partial class frmSalesOrderDirect
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSalesOrderDirect));
            this.pnlHEADER = new System.Windows.Forms.Panel();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.lblHEADING = new System.Windows.Forms.Label();
            this.grdSEARCH = new System.Windows.Forms.DataGridView();
            this.txtSEARCH = new System.Windows.Forms.TextBox();
            this.lblSEARCH = new System.Windows.Forms.Label();
            this.btnCLEAR = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnSAVE = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.cmbCustomer = new SergeUtils.EasyCompletionComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dtp_DATE = new System.Windows.Forms.DateTimePicker();
            this.lblSOno = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblSO = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblAcc = new System.Windows.Forms.Label();
            this.txtCreditDays = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.txtMuandRate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtKgRate = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rdbCredit = new System.Windows.Forms.RadioButton();
            this.rdbCash = new System.Windows.Forms.RadioButton();
            this.cmbMaterial = new SergeUtils.EasyCompletionComboBox();
            this.lblMaterial = new System.Windows.Forms.Label();
            this.chkDiscard = new System.Windows.Forms.CheckBox();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.btnDetailReport = new System.Windows.Forms.Button();
            this.pnlHEADER.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSEARCH)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHEADER
            // 
            this.pnlHEADER.BackColor = System.Drawing.Color.Transparent;
            this.pnlHEADER.BackgroundImage = global::ERP_Maaz_Oil.Properties.Resources.header;
            this.pnlHEADER.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlHEADER.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHEADER.Controls.Add(this.pictureBox15);
            this.pnlHEADER.Controls.Add(this.lblHEADING);
            this.pnlHEADER.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHEADER.Location = new System.Drawing.Point(0, 0);
            this.pnlHEADER.Name = "pnlHEADER";
            this.pnlHEADER.Size = new System.Drawing.Size(922, 88);
            this.pnlHEADER.TabIndex = 36;
            // 
            // pictureBox15
            // 
            this.pictureBox15.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox15.Location = new System.Drawing.Point(1340, 3);
            this.pictureBox15.Name = "pictureBox15";
            this.pictureBox15.Size = new System.Drawing.Size(49, 20);
            this.pictureBox15.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox15.TabIndex = 25;
            this.pictureBox15.TabStop = false;
            // 
            // lblHEADING
            // 
            this.lblHEADING.AutoSize = true;
            this.lblHEADING.BackColor = System.Drawing.Color.Transparent;
            this.lblHEADING.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.75F);
            this.lblHEADING.ForeColor = System.Drawing.Color.White;
            this.lblHEADING.Location = new System.Drawing.Point(6, 25);
            this.lblHEADING.Name = "lblHEADING";
            this.lblHEADING.Size = new System.Drawing.Size(276, 29);
            this.lblHEADING.TabIndex = 23;
            this.lblHEADING.Text = "SALES ORDER DIRECT";
            // 
            // grdSEARCH
            // 
            this.grdSEARCH.AllowUserToAddRows = false;
            this.grdSEARCH.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            this.grdSEARCH.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.grdSEARCH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdSEARCH.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grdSEARCH.BackgroundColor = System.Drawing.Color.White;
            this.grdSEARCH.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI Semibold", 10.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdSEARCH.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.grdSEARCH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSEARCH.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdSEARCH.DefaultCellStyle = dataGridViewCellStyle9;
            this.grdSEARCH.Location = new System.Drawing.Point(5, 126);
            this.grdSEARCH.Name = "grdSEARCH";
            this.grdSEARCH.ReadOnly = true;
            this.grdSEARCH.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSEARCH.Size = new System.Drawing.Size(911, 195);
            this.grdSEARCH.TabIndex = 221;
            this.grdSEARCH.TabStop = false;
            this.grdSEARCH.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdSEARCH_CellClick);
            this.grdSEARCH.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.grdSEARCH_DataBindingComplete);
            // 
            // txtSEARCH
            // 
            this.txtSEARCH.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSEARCH.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSEARCH.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtSEARCH.Location = new System.Drawing.Point(72, 95);
            this.txtSEARCH.Name = "txtSEARCH";
            this.txtSEARCH.Size = new System.Drawing.Size(844, 25);
            this.txtSEARCH.TabIndex = 0;
            this.txtSEARCH.TextChanged += new System.EventHandler(this.txtSEARCH_TextChanged);
            // 
            // lblSEARCH
            // 
            this.lblSEARCH.AutoSize = true;
            this.lblSEARCH.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSEARCH.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSEARCH.Location = new System.Drawing.Point(9, 99);
            this.lblSEARCH.Name = "lblSEARCH";
            this.lblSEARCH.Size = new System.Drawing.Size(57, 17);
            this.lblSEARCH.TabIndex = 219;
            this.lblSEARCH.Text = "SEARCH";
            // 
            // btnCLEAR
            // 
            this.btnCLEAR.BackColor = System.Drawing.Color.DimGray;
            this.btnCLEAR.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCLEAR.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnCLEAR.ForeColor = System.Drawing.Color.White;
            this.btnCLEAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCLEAR.ImageIndex = 1;
            this.btnCLEAR.ImageList = this.imageList1;
            this.btnCLEAR.Location = new System.Drawing.Point(757, 478);
            this.btnCLEAR.Name = "btnCLEAR";
            this.btnCLEAR.Size = new System.Drawing.Size(124, 25);
            this.btnCLEAR.TabIndex = 10;
            this.btnCLEAR.Text = "CLEAR";
            this.btnCLEAR.UseVisualStyleBackColor = false;
            this.btnCLEAR.Click += new System.EventHandler(this.btnCLEAR_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icons8-Save as Filled-100.png");
            this.imageList1.Images.SetKeyName(1, "icons8-Cancel Filled-100.png");
            // 
            // btnSAVE
            // 
            this.btnSAVE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(68)))), ((int)(((byte)(2)))));
            this.btnSAVE.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSAVE.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSAVE.ForeColor = System.Drawing.Color.White;
            this.btnSAVE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSAVE.ImageIndex = 0;
            this.btnSAVE.ImageList = this.imageList1;
            this.btnSAVE.Location = new System.Drawing.Point(601, 478);
            this.btnSAVE.Name = "btnSAVE";
            this.btnSAVE.Size = new System.Drawing.Size(124, 25);
            this.btnSAVE.TabIndex = 9;
            this.btnSAVE.Text = "SAVE";
            this.btnSAVE.UseVisualStyleBackColor = false;
            this.btnSAVE.Click += new System.EventHandler(this.btnSAVE_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(503, 362);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 212;
            this.label4.Text = "WEIGHT";
            // 
            // txtWeight
            // 
            this.txtWeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtWeight.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtWeight.Location = new System.Drawing.Point(601, 357);
            this.txtWeight.MaxLength = 11;
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(198, 25);
            this.txtWeight.TabIndex = 6;
            this.txtWeight.Text = "0";
            this.txtWeight.TextChanged += new System.EventHandler(this.txtWeight_TextChanged);
            this.txtWeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWeight_KeyPress);
            this.txtWeight.Leave += new System.EventHandler(this.txtWeight_Leave);
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCustomer.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Items.AddRange(new object[] {
            "--SELECT SUPPLIER--",
            "AUTOMART"});
            this.cmbCustomer.Location = new System.Drawing.Point(108, 387);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(280, 25);
            this.cmbCustomer.TabIndex = 226;
            this.cmbCustomer.SelectedIndexChanged += new System.EventHandler(this.cmbCustomer_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(9, 392);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 15);
            this.label9.TabIndex = 227;
            this.label9.Text = "CUSTOMER";
            // 
            // dtp_DATE
            // 
            this.dtp_DATE.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.dtp_DATE.Location = new System.Drawing.Point(108, 358);
            this.dtp_DATE.Name = "dtp_DATE";
            this.dtp_DATE.Size = new System.Drawing.Size(280, 23);
            this.dtp_DATE.TabIndex = 295;
            // 
            // lblSOno
            // 
            this.lblSOno.AutoSize = true;
            this.lblSOno.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblSOno.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(215)))));
            this.lblSOno.Location = new System.Drawing.Point(108, 334);
            this.lblSOno.Name = "lblSOno";
            this.lblSOno.Size = new System.Drawing.Size(68, 15);
            this.lblSOno.TabIndex = 298;
            this.lblSOno.Text = "SO-1-2017";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblDate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDate.Location = new System.Drawing.Point(9, 362);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(40, 15);
            this.lblDate.TabIndex = 297;
            this.lblDate.Text = "DATE:";
            // 
            // lblSO
            // 
            this.lblSO.AutoSize = true;
            this.lblSO.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblSO.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSO.Location = new System.Drawing.Point(9, 334);
            this.lblSO.Name = "lblSO";
            this.lblSO.Size = new System.Drawing.Size(39, 15);
            this.lblSO.TabIndex = 296;
            this.lblSO.Text = "S.O #:";
            // 
            // txtDescription
            // 
            this.txtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtDescription.Location = new System.Drawing.Point(108, 449);
            this.txtDescription.MaxLength = 100;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(280, 23);
            this.txtDescription.TabIndex = 299;
            // 
            // lblAcc
            // 
            this.lblAcc.AutoSize = true;
            this.lblAcc.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblAcc.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblAcc.Location = new System.Drawing.Point(9, 453);
            this.lblAcc.Name = "lblAcc";
            this.lblAcc.Size = new System.Drawing.Size(84, 15);
            this.lblAcc.TabIndex = 300;
            this.lblAcc.Text = "DESCRIPTION:";
            // 
            // txtCreditDays
            // 
            this.txtCreditDays.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCreditDays.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtCreditDays.Location = new System.Drawing.Point(108, 478);
            this.txtCreditDays.MaxLength = 11;
            this.txtCreditDays.Name = "txtCreditDays";
            this.txtCreditDays.Size = new System.Drawing.Size(280, 25);
            this.txtCreditDays.TabIndex = 301;
            this.txtCreditDays.Text = "0";
            this.txtCreditDays.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWeight_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(9, 483);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 15);
            this.label2.TabIndex = 302;
            this.label2.Text = "CREDITDAYS";
            // 
            // txtUnit
            // 
            this.txtUnit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUnit.Enabled = false;
            this.txtUnit.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtUnit.Location = new System.Drawing.Point(799, 357);
            this.txtUnit.MaxLength = 11;
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(82, 25);
            this.txtUnit.TabIndex = 328;
            this.txtUnit.Text = "KGS";
            // 
            // txtMuandRate
            // 
            this.txtMuandRate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMuandRate.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtMuandRate.Location = new System.Drawing.Point(602, 418);
            this.txtMuandRate.MaxLength = 11;
            this.txtMuandRate.Name = "txtMuandRate";
            this.txtMuandRate.Size = new System.Drawing.Size(280, 25);
            this.txtMuandRate.TabIndex = 331;
            this.txtMuandRate.Text = "0";
            this.txtMuandRate.TextChanged += new System.EventHandler(this.txtMuandRate_TextChanged);
            this.txtMuandRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWeight_KeyPress);
            this.txtMuandRate.Leave += new System.EventHandler(this.txtWeight_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(503, 423);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 15);
            this.label5.TabIndex = 332;
            this.label5.Text = "MAUND RATE";
            // 
            // txtTotal
            // 
            this.txtTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotal.Enabled = false;
            this.txtTotal.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtTotal.Location = new System.Drawing.Point(601, 449);
            this.txtTotal.MaxLength = 11;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(280, 25);
            this.txtTotal.TabIndex = 329;
            this.txtTotal.Text = "0";
            this.txtTotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWeight_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(503, 454);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 15);
            this.label6.TabIndex = 330;
            this.label6.Text = "TOTAL";
            // 
            // txtKgRate
            // 
            this.txtKgRate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtKgRate.Enabled = false;
            this.txtKgRate.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtKgRate.Location = new System.Drawing.Point(602, 387);
            this.txtKgRate.MaxLength = 11;
            this.txtKgRate.Name = "txtKgRate";
            this.txtKgRate.Size = new System.Drawing.Size(280, 25);
            this.txtKgRate.TabIndex = 336;
            this.txtKgRate.Text = "0";
            this.txtKgRate.TextChanged += new System.EventHandler(this.txtKgRate_TextChanged);
            this.txtKgRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWeight_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Location = new System.Drawing.Point(503, 392);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 15);
            this.label10.TabIndex = 337;
            this.label10.Text = "KG RATE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(503, 334);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 338;
            this.label1.Text = "SALES TYPE";
            // 
            // rdbCredit
            // 
            this.rdbCredit.AutoSize = true;
            this.rdbCredit.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.rdbCredit.Location = new System.Drawing.Point(735, 332);
            this.rdbCredit.Name = "rdbCredit";
            this.rdbCredit.Size = new System.Drawing.Size(64, 19);
            this.rdbCredit.TabIndex = 340;
            this.rdbCredit.Text = "CREDIT";
            this.rdbCredit.UseVisualStyleBackColor = true;
            // 
            // rdbCash
            // 
            this.rdbCash.AutoSize = true;
            this.rdbCash.Checked = true;
            this.rdbCash.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.rdbCash.Location = new System.Drawing.Point(602, 332);
            this.rdbCash.Name = "rdbCash";
            this.rdbCash.Size = new System.Drawing.Size(56, 19);
            this.rdbCash.TabIndex = 339;
            this.rdbCash.TabStop = true;
            this.rdbCash.Text = "CASH";
            this.rdbCash.UseVisualStyleBackColor = true;
            // 
            // cmbMaterial
            // 
            this.cmbMaterial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMaterial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMaterial.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbMaterial.FormattingEnabled = true;
            this.cmbMaterial.Items.AddRange(new object[] {
            "--SELECT SUPPLIER--",
            "AUTOMART"});
            this.cmbMaterial.Location = new System.Drawing.Point(108, 418);
            this.cmbMaterial.Name = "cmbMaterial";
            this.cmbMaterial.Size = new System.Drawing.Size(280, 25);
            this.cmbMaterial.TabIndex = 341;
            this.cmbMaterial.SelectedIndexChanged += new System.EventHandler(this.cmbMaterial_SelectedIndexChanged);
            // 
            // lblMaterial
            // 
            this.lblMaterial.AutoSize = true;
            this.lblMaterial.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblMaterial.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblMaterial.Location = new System.Drawing.Point(9, 423);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(63, 15);
            this.lblMaterial.TabIndex = 342;
            this.lblMaterial.Text = "MATERIAL";
            // 
            // chkDiscard
            // 
            this.chkDiscard.AutoSize = true;
            this.chkDiscard.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.chkDiscard.Location = new System.Drawing.Point(506, 481);
            this.chkDiscard.Name = "chkDiscard";
            this.chkDiscard.Size = new System.Drawing.Size(76, 19);
            this.chkDiscard.TabIndex = 343;
            this.chkDiscard.Text = "DISCARD";
            this.chkDiscard.UseVisualStyleBackColor = true;
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "icons8-Save as Filled-100.png");
            this.imageList2.Images.SetKeyName(1, "icons8-Cancel Filled-100.png");
            this.imageList2.Images.SetKeyName(2, "icons8-search.png");
            // 
            // btnDetailReport
            // 
            this.btnDetailReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(24)))), ((int)(((byte)(38)))));
            this.btnDetailReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDetailReport.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnDetailReport.ForeColor = System.Drawing.Color.White;
            this.btnDetailReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetailReport.ImageIndex = 2;
            this.btnDetailReport.ImageList = this.imageList2;
            this.btnDetailReport.Location = new System.Drawing.Point(600, 509);
            this.btnDetailReport.Name = "btnDetailReport";
            this.btnDetailReport.Size = new System.Drawing.Size(281, 25);
            this.btnDetailReport.TabIndex = 344;
            this.btnDetailReport.Text = "VIEW S.O DETAIL REPORT";
            this.btnDetailReport.UseVisualStyleBackColor = false;
            this.btnDetailReport.Click += new System.EventHandler(this.btnDetailReport_Click);
            // 
            // frmSalesOrderDirect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(922, 554);
            this.Controls.Add(this.btnDetailReport);
            this.Controls.Add(this.chkDiscard);
            this.Controls.Add(this.cmbMaterial);
            this.Controls.Add(this.lblMaterial);
            this.Controls.Add(this.rdbCredit);
            this.Controls.Add(this.rdbCash);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtKgRate);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtMuandRate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtUnit);
            this.Controls.Add(this.txtCreditDays);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblAcc);
            this.Controls.Add(this.dtp_DATE);
            this.Controls.Add(this.lblSOno);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblSO);
            this.Controls.Add(this.cmbCustomer);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtWeight);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCLEAR);
            this.Controls.Add(this.btnSAVE);
            this.Controls.Add(this.grdSEARCH);
            this.Controls.Add(this.txtSEARCH);
            this.Controls.Add(this.lblSEARCH);
            this.Controls.Add(this.pnlHEADER);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1314, 703);
            this.Name = "frmSalesOrderDirect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SALES ORDER DIRECT";
            this.Load += new System.EventHandler(this.frm_AddGroupAccounts_Load);
            this.pnlHEADER.ResumeLayout(false);
            this.pnlHEADER.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSEARCH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHEADER;
        private System.Windows.Forms.PictureBox pictureBox15;
        private System.Windows.Forms.Label lblHEADING;
        private System.Windows.Forms.DataGridView grdSEARCH;
        private System.Windows.Forms.TextBox txtSEARCH;
        private System.Windows.Forms.Label lblSEARCH;
        private System.Windows.Forms.Button btnCLEAR;
        private System.Windows.Forms.Button btnSAVE;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtWeight;
        private SergeUtils.EasyCompletionComboBox cmbCustomer;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtp_DATE;
        private System.Windows.Forms.Label lblSOno;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblSO;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblAcc;
        private System.Windows.Forms.TextBox txtCreditDays;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.TextBox txtMuandRate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtKgRate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdbCredit;
        private System.Windows.Forms.RadioButton rdbCash;
        private SergeUtils.EasyCompletionComboBox cmbMaterial;
        private System.Windows.Forms.Label lblMaterial;
        private System.Windows.Forms.CheckBox chkDiscard;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Button btnDetailReport;
    }
}