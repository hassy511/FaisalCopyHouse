namespace ERP_Maaz_Oil.Forms
{
    partial class frmChartOfAccounts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChartOfAccounts));
            this.cmbControlAccount = new SergeUtils.EasyCompletionComboBox();
            this.lblControlAccount = new System.Windows.Forms.Label();
            this.cmbGroupAccount = new SergeUtils.EasyCompletionComboBox();
            this.lblGroupAccount = new System.Windows.Forms.Label();
            this.lblAccountName = new System.Windows.Forms.Label();
            this.txtAccountName = new System.Windows.Forms.TextBox();
            this.chkDeActive = new System.Windows.Forms.CheckBox();
            this.txtOpeningBalance = new System.Windows.Forms.TextBox();
            this.lblOpeningBalance = new System.Windows.Forms.Label();
            this.cmbDebitCredit = new SergeUtils.EasyCompletionComboBox();
            this.grdSEARCH = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtSearching = new System.Windows.Forms.TextBox();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.lblHEADING = new System.Windows.Forms.Label();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.pnlHEADER = new System.Windows.Forms.Panel();
            this.lblMOBILE = new System.Windows.Forms.Label();
            this.txtMOBILE = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEMAIL = new System.Windows.Forms.TextBox();
            this.cmbArea = new SergeUtils.EasyCompletionComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbCITY = new SergeUtils.EasyCompletionComboBox();
            this.lblCITY = new System.Windows.Forms.Label();
            this.btnADD_CITY = new System.Windows.Forms.PictureBox();
            this.btnAddArea = new System.Windows.Forms.PictureBox();
            this.txtCreditDays = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtADDRESS = new System.Windows.Forms.TextBox();
            this.lblEMAIL = new System.Windows.Forms.Label();
            this.btnAddGroupAccount = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdSEARCH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            this.pnlHEADER.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnADD_CITY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddGroupAccount)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbControlAccount
            // 
            this.cmbControlAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbControlAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbControlAccount.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbControlAccount.FormattingEnabled = true;
            this.cmbControlAccount.Location = new System.Drawing.Point(125, 471);
            this.cmbControlAccount.Name = "cmbControlAccount";
            this.cmbControlAccount.Size = new System.Drawing.Size(231, 25);
            this.cmbControlAccount.TabIndex = 0;
            this.cmbControlAccount.DropDown += new System.EventHandler(this.cmbCONTROL_AC_DropDown);
            this.cmbControlAccount.SelectedIndexChanged += new System.EventHandler(this.cmbControlAccount_SelectedIndexChanged);
            this.cmbControlAccount.TextUpdate += new System.EventHandler(this.cmbCONTROL_AC_TextUpdate);
            this.cmbControlAccount.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmbCONTROL_AC_PreviewKeyDown);
            // 
            // lblControlAccount
            // 
            this.lblControlAccount.AutoSize = true;
            this.lblControlAccount.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblControlAccount.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblControlAccount.Location = new System.Drawing.Point(7, 476);
            this.lblControlAccount.Name = "lblControlAccount";
            this.lblControlAccount.Size = new System.Drawing.Size(112, 15);
            this.lblControlAccount.TabIndex = 209;
            this.lblControlAccount.Text = "ACCOUNT NATURE:";
            // 
            // cmbGroupAccount
            // 
            this.cmbGroupAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbGroupAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGroupAccount.Enabled = false;
            this.cmbGroupAccount.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbGroupAccount.FormattingEnabled = true;
            this.cmbGroupAccount.Location = new System.Drawing.Point(125, 502);
            this.cmbGroupAccount.Name = "cmbGroupAccount";
            this.cmbGroupAccount.Size = new System.Drawing.Size(205, 25);
            this.cmbGroupAccount.TabIndex = 1;
            this.cmbGroupAccount.DropDown += new System.EventHandler(this.cmbGROUP_AC_DropDown);
            this.cmbGroupAccount.SelectedIndexChanged += new System.EventHandler(this.cmbGroupAccount_SelectedIndexChanged);
            this.cmbGroupAccount.TextUpdate += new System.EventHandler(this.cmbCONTROL_AC_TextUpdate);
            this.cmbGroupAccount.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmbGROUP_AC_PreviewKeyDown);
            // 
            // lblGroupAccount
            // 
            this.lblGroupAccount.AutoSize = true;
            this.lblGroupAccount.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblGroupAccount.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblGroupAccount.Location = new System.Drawing.Point(33, 507);
            this.lblGroupAccount.Name = "lblGroupAccount";
            this.lblGroupAccount.Size = new System.Drawing.Size(86, 15);
            this.lblGroupAccount.TabIndex = 212;
            this.lblGroupAccount.Text = "TREE BRANCH:";
            // 
            // lblAccountName
            // 
            this.lblAccountName.AutoSize = true;
            this.lblAccountName.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblAccountName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblAccountName.Location = new System.Drawing.Point(17, 538);
            this.lblAccountName.Name = "lblAccountName";
            this.lblAccountName.Size = new System.Drawing.Size(102, 15);
            this.lblAccountName.TabIndex = 213;
            this.lblAccountName.Text = "ACCOUNT NAME:";
            // 
            // txtAccountName
            // 
            this.txtAccountName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAccountName.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtAccountName.Location = new System.Drawing.Point(125, 533);
            this.txtAccountName.MaxLength = 32000;
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.Size = new System.Drawing.Size(231, 25);
            this.txtAccountName.TabIndex = 2;
            this.txtAccountName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtACCOUNT_NAME_MouseClick);
            this.txtAccountName.TextChanged += new System.EventHandler(this.txtAccountName_TextChanged);
            this.txtAccountName.Enter += new System.EventHandler(this.txtACCOUNT_NAME_Enter);
            // 
            // chkDeActive
            // 
            this.chkDeActive.AutoSize = true;
            this.chkDeActive.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.chkDeActive.Location = new System.Drawing.Point(270, 595);
            this.chkDeActive.Name = "chkDeActive";
            this.chkDeActive.Size = new System.Drawing.Size(86, 19);
            this.chkDeActive.TabIndex = 5;
            this.chkDeActive.TabStop = false;
            this.chkDeActive.Text = "DE-ACTIVE";
            this.chkDeActive.UseVisualStyleBackColor = true;
            // 
            // txtOpeningBalance
            // 
            this.txtOpeningBalance.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOpeningBalance.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtOpeningBalance.Location = new System.Drawing.Point(125, 564);
            this.txtOpeningBalance.MaxLength = 15;
            this.txtOpeningBalance.Name = "txtOpeningBalance";
            this.txtOpeningBalance.Size = new System.Drawing.Size(122, 25);
            this.txtOpeningBalance.TabIndex = 3;
            this.txtOpeningBalance.Text = "0";
            this.txtOpeningBalance.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtACCOUNT_NAME_MouseClick);
            this.txtOpeningBalance.Enter += new System.EventHandler(this.txtACCOUNT_NAME_Enter);
            this.txtOpeningBalance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOPEN_BAL_KeyPress);
            this.txtOpeningBalance.Leave += new System.EventHandler(this.txtOPEN_BAL_Leave);
            // 
            // lblOpeningBalance
            // 
            this.lblOpeningBalance.AutoSize = true;
            this.lblOpeningBalance.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblOpeningBalance.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblOpeningBalance.Location = new System.Drawing.Point(3, 569);
            this.lblOpeningBalance.Name = "lblOpeningBalance";
            this.lblOpeningBalance.Size = new System.Drawing.Size(116, 15);
            this.lblOpeningBalance.TabIndex = 216;
            this.lblOpeningBalance.Text = "OPENING BALANCE:";
            // 
            // cmbDebitCredit
            // 
            this.cmbDebitCredit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbDebitCredit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDebitCredit.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbDebitCredit.FormattingEnabled = true;
            this.cmbDebitCredit.Items.AddRange(new object[] {
            "DEBIT",
            "CREDIT"});
            this.cmbDebitCredit.Location = new System.Drawing.Point(253, 564);
            this.cmbDebitCredit.Name = "cmbDebitCredit";
            this.cmbDebitCredit.Size = new System.Drawing.Size(103, 25);
            this.cmbDebitCredit.TabIndex = 4;
            this.cmbDebitCredit.TextUpdate += new System.EventHandler(this.cmbCONTROL_AC_TextUpdate);
            // 
            // grdSEARCH
            // 
            this.grdSEARCH.AllowUserToAddRows = false;
            this.grdSEARCH.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.grdSEARCH.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdSEARCH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdSEARCH.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grdSEARCH.BackgroundColor = System.Drawing.Color.White;
            this.grdSEARCH.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdSEARCH.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdSEARCH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSEARCH.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdSEARCH.DefaultCellStyle = dataGridViewCellStyle3;
            this.grdSEARCH.Location = new System.Drawing.Point(8, 87);
            this.grdSEARCH.Name = "grdSEARCH";
            this.grdSEARCH.ReadOnly = true;
            this.grdSEARCH.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSEARCH.Size = new System.Drawing.Size(1076, 378);
            this.grdSEARCH.TabIndex = 221;
            this.grdSEARCH.TabStop = false;
            this.grdSEARCH.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdSEARCH_CellClick);
            this.grdSEARCH.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdSEARCH_CellContentClick);
            this.grdSEARCH.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.grdSEARCH_DataBindingComplete);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtSearch.Location = new System.Drawing.Point(422, 95);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(662, 25);
            this.txtSearch.TabIndex = 220;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSEARCH_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSearch.Location = new System.Drawing.Point(12, 60);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(57, 17);
            this.lblSearch.TabIndex = 219;
            this.lblSearch.Text = "SEARCH";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icons8-Save as Filled-100.png");
            this.imageList1.Images.SetKeyName(1, "icons8-Cancel Filled-100.png");
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.DimGray;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.ImageIndex = 1;
            this.btnClear.ImageList = this.imageList1;
            this.btnClear.Location = new System.Drawing.Point(948, 564);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(112, 25);
            this.btnClear.TabIndex = 12;
            this.btnClear.TabStop = false;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnCLEAR_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(68)))), ((int)(((byte)(2)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.ImageIndex = 0;
            this.btnSave.ImageList = this.imageList1;
            this.btnSave.Location = new System.Drawing.Point(829, 564);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 25);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSAVE_Click);
            // 
            // txtSearching
            // 
            this.txtSearching.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearching.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSearching.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtSearching.Location = new System.Drawing.Point(75, 56);
            this.txtSearching.Name = "txtSearching";
            this.txtSearching.Size = new System.Drawing.Size(1009, 25);
            this.txtSearching.TabIndex = 284;
            this.txtSearching.TabStop = false;
            this.txtSearching.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // pictureBox14
            // 
            this.pictureBox14.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox14.Location = new System.Drawing.Point(1285, 3);
            this.pictureBox14.Name = "pictureBox14";
            this.pictureBox14.Size = new System.Drawing.Size(49, 20);
            this.pictureBox14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox14.TabIndex = 24;
            this.pictureBox14.TabStop = false;
            // 
            // lblHEADING
            // 
            this.lblHEADING.AutoSize = true;
            this.lblHEADING.BackColor = System.Drawing.Color.Transparent;
            this.lblHEADING.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHEADING.ForeColor = System.Drawing.Color.White;
            this.lblHEADING.Location = new System.Drawing.Point(12, 16);
            this.lblHEADING.Name = "lblHEADING";
            this.lblHEADING.Size = new System.Drawing.Size(224, 23);
            this.lblHEADING.TabIndex = 23;
            this.lblHEADING.Text = "CHART OF ACCOUNTS";
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
            // pnlHEADER
            // 
            this.pnlHEADER.BackColor = System.Drawing.Color.Transparent;
            this.pnlHEADER.BackgroundImage = global::ERP_Maaz_Oil.Properties.Resources.header;
            this.pnlHEADER.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlHEADER.Controls.Add(this.pictureBox15);
            this.pnlHEADER.Controls.Add(this.lblHEADING);
            this.pnlHEADER.Controls.Add(this.pictureBox14);
            this.pnlHEADER.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHEADER.Location = new System.Drawing.Point(0, 0);
            this.pnlHEADER.Name = "pnlHEADER";
            this.pnlHEADER.Size = new System.Drawing.Size(1090, 50);
            this.pnlHEADER.TabIndex = 222;
            // 
            // lblMOBILE
            // 
            this.lblMOBILE.AutoSize = true;
            this.lblMOBILE.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblMOBILE.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblMOBILE.Location = new System.Drawing.Point(397, 476);
            this.lblMOBILE.Name = "lblMOBILE";
            this.lblMOBILE.Size = new System.Drawing.Size(53, 15);
            this.lblMOBILE.TabIndex = 285;
            this.lblMOBILE.Text = "MOBILE:";
            // 
            // txtMOBILE
            // 
            this.txtMOBILE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMOBILE.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtMOBILE.Location = new System.Drawing.Point(456, 471);
            this.txtMOBILE.MaxLength = 11;
            this.txtMOBILE.Name = "txtMOBILE";
            this.txtMOBILE.Size = new System.Drawing.Size(241, 25);
            this.txtMOBILE.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(405, 507);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 15);
            this.label5.TabIndex = 287;
            this.label5.Text = "EMAIL:";
            // 
            // txtEMAIL
            // 
            this.txtEMAIL.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEMAIL.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtEMAIL.Location = new System.Drawing.Point(456, 502);
            this.txtEMAIL.MaxLength = 100;
            this.txtEMAIL.Name = "txtEMAIL";
            this.txtEMAIL.Size = new System.Drawing.Size(241, 25);
            this.txtEMAIL.TabIndex = 6;
            // 
            // cmbArea
            // 
            this.cmbArea.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbArea.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbArea.Enabled = false;
            this.cmbArea.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbArea.FormattingEnabled = true;
            this.cmbArea.Location = new System.Drawing.Point(456, 564);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(216, 25);
            this.cmbArea.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(414, 569);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 15);
            this.label6.TabIndex = 292;
            this.label6.Text = "AREA";
            // 
            // cmbCITY
            // 
            this.cmbCITY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCITY.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCITY.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbCITY.FormattingEnabled = true;
            this.cmbCITY.Location = new System.Drawing.Point(456, 533);
            this.cmbCITY.Name = "cmbCITY";
            this.cmbCITY.Size = new System.Drawing.Size(216, 25);
            this.cmbCITY.TabIndex = 7;
            this.cmbCITY.DropDown += new System.EventHandler(this.cmbCITY_DropDown);
            this.cmbCITY.SelectedIndexChanged += new System.EventHandler(this.cmbCITY_SelectedIndexChanged);
            this.cmbCITY.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmbCITY_PreviewKeyDown);
            // 
            // lblCITY
            // 
            this.lblCITY.AutoSize = true;
            this.lblCITY.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblCITY.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCITY.Location = new System.Drawing.Point(415, 538);
            this.lblCITY.Name = "lblCITY";
            this.lblCITY.Size = new System.Drawing.Size(35, 15);
            this.lblCITY.TabIndex = 290;
            this.lblCITY.Text = "CITY:";
            // 
            // btnADD_CITY
            // 
            this.btnADD_CITY.BackColor = System.Drawing.Color.Transparent;
            this.btnADD_CITY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnADD_CITY.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnADD_CITY.Image = global::ERP_Maaz_Oil.Properties.Resources.plus;
            this.btnADD_CITY.Location = new System.Drawing.Point(672, 533);
            this.btnADD_CITY.Name = "btnADD_CITY";
            this.btnADD_CITY.Size = new System.Drawing.Size(25, 25);
            this.btnADD_CITY.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnADD_CITY.TabIndex = 293;
            this.btnADD_CITY.TabStop = false;
            this.btnADD_CITY.Click += new System.EventHandler(this.btnADD_CITY_Click);
            // 
            // btnAddArea
            // 
            this.btnAddArea.BackColor = System.Drawing.Color.Transparent;
            this.btnAddArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnAddArea.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddArea.Image = global::ERP_Maaz_Oil.Properties.Resources.plus;
            this.btnAddArea.Location = new System.Drawing.Point(672, 564);
            this.btnAddArea.Name = "btnAddArea";
            this.btnAddArea.Size = new System.Drawing.Size(25, 25);
            this.btnAddArea.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnAddArea.TabIndex = 294;
            this.btnAddArea.TabStop = false;
            this.btnAddArea.Click += new System.EventHandler(this.btnAddArea_Click);
            // 
            // txtCreditDays
            // 
            this.txtCreditDays.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCreditDays.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtCreditDays.Location = new System.Drawing.Point(829, 533);
            this.txtCreditDays.MaxLength = 100;
            this.txtCreditDays.Name = "txtCreditDays";
            this.txtCreditDays.Size = new System.Drawing.Size(231, 25);
            this.txtCreditDays.TabIndex = 10;
            this.txtCreditDays.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Location = new System.Drawing.Point(740, 538);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 15);
            this.label10.TabIndex = 298;
            this.label10.Text = "CREDIT DAYS:";
            // 
            // txtADDRESS
            // 
            this.txtADDRESS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtADDRESS.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtADDRESS.Location = new System.Drawing.Point(829, 471);
            this.txtADDRESS.MaxLength = 32000;
            this.txtADDRESS.Multiline = true;
            this.txtADDRESS.Name = "txtADDRESS";
            this.txtADDRESS.Size = new System.Drawing.Size(231, 56);
            this.txtADDRESS.TabIndex = 9;
            this.txtADDRESS.TextChanged += new System.EventHandler(this.txtADDRESS_TextChanged);
            // 
            // lblEMAIL
            // 
            this.lblEMAIL.AutoSize = true;
            this.lblEMAIL.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblEMAIL.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblEMAIL.Location = new System.Drawing.Point(760, 476);
            this.lblEMAIL.Name = "lblEMAIL";
            this.lblEMAIL.Size = new System.Drawing.Size(63, 15);
            this.lblEMAIL.TabIndex = 295;
            this.lblEMAIL.Text = "ADDRESS:";
            // 
            // btnAddGroupAccount
            // 
            this.btnAddGroupAccount.BackColor = System.Drawing.Color.Transparent;
            this.btnAddGroupAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnAddGroupAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddGroupAccount.Image = global::ERP_Maaz_Oil.Properties.Resources.plus;
            this.btnAddGroupAccount.Location = new System.Drawing.Point(331, 502);
            this.btnAddGroupAccount.Name = "btnAddGroupAccount";
            this.btnAddGroupAccount.Size = new System.Drawing.Size(25, 25);
            this.btnAddGroupAccount.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnAddGroupAccount.TabIndex = 210;
            this.btnAddGroupAccount.TabStop = false;
            this.btnAddGroupAccount.Click += new System.EventHandler(this.btnADDGROUP_AC_Click);
            // 
            // frmChartOfAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1090, 620);
            this.Controls.Add(this.txtCreditDays);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtADDRESS);
            this.Controls.Add(this.lblEMAIL);
            this.Controls.Add(this.btnAddArea);
            this.Controls.Add(this.btnADD_CITY);
            this.Controls.Add(this.cmbArea);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbCITY);
            this.Controls.Add(this.lblCITY);
            this.Controls.Add(this.txtEMAIL);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtMOBILE);
            this.Controls.Add(this.lblMOBILE);
            this.Controls.Add(this.txtSearching);
            this.Controls.Add(this.pnlHEADER);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grdSEARCH);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.cmbDebitCredit);
            this.Controls.Add(this.txtOpeningBalance);
            this.Controls.Add(this.lblOpeningBalance);
            this.Controls.Add(this.chkDeActive);
            this.Controls.Add(this.txtAccountName);
            this.Controls.Add(this.lblAccountName);
            this.Controls.Add(this.cmbGroupAccount);
            this.Controls.Add(this.lblGroupAccount);
            this.Controls.Add(this.btnAddGroupAccount);
            this.Controls.Add(this.cmbControlAccount);
            this.Controls.Add(this.lblControlAccount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1284, 703);
            this.Name = "frmChartOfAccounts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CHART OF ACCOUNTS";
            this.Load += new System.EventHandler(this.frm_ChartOfAccounts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdSEARCH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
            this.pnlHEADER.ResumeLayout(false);
            this.pnlHEADER.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnADD_CITY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddGroupAccount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private SergeUtils.EasyCompletionComboBox cmbControlAccount;
        private System.Windows.Forms.Label lblControlAccount;
        private SergeUtils.EasyCompletionComboBox cmbGroupAccount;
        private System.Windows.Forms.Label lblGroupAccount;
        private System.Windows.Forms.Label lblAccountName;
        private System.Windows.Forms.TextBox txtAccountName;
        private System.Windows.Forms.CheckBox chkDeActive;
        private System.Windows.Forms.TextBox txtOpeningBalance;
        private System.Windows.Forms.Label lblOpeningBalance;
        private SergeUtils.EasyCompletionComboBox cmbDebitCredit;
        private System.Windows.Forms.DataGridView grdSEARCH;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox txtSearching;
        private System.Windows.Forms.PictureBox pictureBox14;
        private System.Windows.Forms.Label lblHEADING;
        private System.Windows.Forms.PictureBox pictureBox15;
        private System.Windows.Forms.Panel pnlHEADER;
        private System.Windows.Forms.Label lblMOBILE;
        private System.Windows.Forms.TextBox txtMOBILE;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEMAIL;
        private SergeUtils.EasyCompletionComboBox cmbArea;
        private System.Windows.Forms.Label label6;
        private SergeUtils.EasyCompletionComboBox cmbCITY;
        private System.Windows.Forms.Label lblCITY;
        private System.Windows.Forms.PictureBox btnADD_CITY;
        private System.Windows.Forms.PictureBox btnAddArea;
        private System.Windows.Forms.TextBox txtCreditDays;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtADDRESS;
        private System.Windows.Forms.Label lblEMAIL;
        private System.Windows.Forms.PictureBox btnAddGroupAccount;
    }
}