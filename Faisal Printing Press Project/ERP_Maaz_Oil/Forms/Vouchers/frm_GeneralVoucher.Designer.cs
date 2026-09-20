namespace ERP_Maaz_Oil.Vouchers
{
    partial class frm_GeneralVoucher
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHEADER = new System.Windows.Forms.Panel();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.lblHEADING = new System.Windows.Forms.Label();
            this.lblCredit = new System.Windows.Forms.Label();
            this.dayControl = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cmbCreditAccount = new SergeUtils.EasyCompletionComboBox();
            this.btn_VIEW_VOUCHER = new System.Windows.Forms.Button();
            this.lblGV = new System.Windows.Forms.Label();
            this.lblV = new System.Windows.Forms.Label();
            this.btnDeleteGeneral = new System.Windows.Forms.Button();
            this.txtAmountWordsGen = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.grdENTRY = new System.Windows.Forms.DataGridView();
            this.DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.debitAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.creditAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESCRIPTION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.debitId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.creditId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnADD = new System.Windows.Forms.Button();
            this.txtSEARCH = new System.Windows.Forms.TextBox();
            this.lblSEARCH = new System.Windows.Forms.Label();
            this.EntryGrid = new System.Windows.Forms.DataGridView();
            this.btnGeneralClr = new System.Windows.Forms.Button();
            this.btnGeneralSave = new System.Windows.Forms.Button();
            this.txtNarration = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.cmbDebitAccount = new SergeUtils.EasyCompletionComboBox();
            this.lblDebit = new System.Windows.Forms.Label();
            this.txtCreditTotalGV = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.txtDebitTotalGV = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.txtGVAmount = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.pnlHEADER.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
            this.dayControl.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdENTRY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntryGrid)).BeginInit();
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
            this.pnlHEADER.Controls.Add(this.lblCredit);
            this.pnlHEADER.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHEADER.Location = new System.Drawing.Point(0, 0);
            this.pnlHEADER.Name = "pnlHEADER";
            this.pnlHEADER.Size = new System.Drawing.Size(1032, 68);
            this.pnlHEADER.TabIndex = 96;
            // 
            // pictureBox15
            // 
            this.pictureBox15.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox15.Location = new System.Drawing.Point(1430, 3);
            this.pictureBox15.Name = "pictureBox15";
            this.pictureBox15.Size = new System.Drawing.Size(52, 20);
            this.pictureBox15.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox15.TabIndex = 25;
            this.pictureBox15.TabStop = false;
            // 
            // pictureBox14
            // 
            this.pictureBox14.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox14.Location = new System.Drawing.Point(1370, 3);
            this.pictureBox14.Name = "pictureBox14";
            this.pictureBox14.Size = new System.Drawing.Size(52, 20);
            this.pictureBox14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox14.TabIndex = 24;
            this.pictureBox14.TabStop = false;
            // 
            // lblHEADING
            // 
            this.lblHEADING.AutoSize = true;
            this.lblHEADING.BackColor = System.Drawing.Color.Transparent;
            this.lblHEADING.Font = new System.Drawing.Font("Berlin Sans FB", 16.75F);
            this.lblHEADING.ForeColor = System.Drawing.Color.White;
            this.lblHEADING.Location = new System.Drawing.Point(10, 21);
            this.lblHEADING.Name = "lblHEADING";
            this.lblHEADING.Size = new System.Drawing.Size(216, 26);
            this.lblHEADING.TabIndex = 23;
            this.lblHEADING.Text = "JOURNAL VOUCHER";
            // 
            // lblCredit
            // 
            this.lblCredit.AutoSize = true;
            this.lblCredit.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblCredit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCredit.Location = new System.Drawing.Point(449, 29);
            this.lblCredit.Name = "lblCredit";
            this.lblCredit.Size = new System.Drawing.Size(108, 15);
            this.lblCredit.TabIndex = 132;
            this.lblCredit.Text = "CREDIT ACCOUNT:";
            this.lblCredit.Visible = false;
            // 
            // dayControl
            // 
            this.dayControl.Controls.Add(this.tabPage3);
            this.dayControl.Font = new System.Drawing.Font("Segoe UI Semibold", 10.25F, System.Drawing.FontStyle.Bold);
            this.dayControl.Location = new System.Drawing.Point(0, 74);
            this.dayControl.Margin = new System.Windows.Forms.Padding(2);
            this.dayControl.Name = "dayControl";
            this.dayControl.SelectedIndex = 0;
            this.dayControl.Size = new System.Drawing.Size(1028, 567);
            this.dayControl.TabIndex = 0;
            this.dayControl.SelectedIndexChanged += new System.EventHandler(this.dayControl_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.cmbCreditAccount);
            this.tabPage3.Controls.Add(this.btn_VIEW_VOUCHER);
            this.tabPage3.Controls.Add(this.lblGV);
            this.tabPage3.Controls.Add(this.lblV);
            this.tabPage3.Controls.Add(this.btnDeleteGeneral);
            this.tabPage3.Controls.Add(this.txtAmountWordsGen);
            this.tabPage3.Controls.Add(this.label29);
            this.tabPage3.Controls.Add(this.grdENTRY);
            this.tabPage3.Controls.Add(this.btnADD);
            this.tabPage3.Controls.Add(this.txtSEARCH);
            this.tabPage3.Controls.Add(this.lblSEARCH);
            this.tabPage3.Controls.Add(this.EntryGrid);
            this.tabPage3.Controls.Add(this.btnGeneralClr);
            this.tabPage3.Controls.Add(this.btnGeneralSave);
            this.tabPage3.Controls.Add(this.txtNarration);
            this.tabPage3.Controls.Add(this.lblDescription);
            this.tabPage3.Controls.Add(this.lblDate);
            this.tabPage3.Controls.Add(this.dtpDate);
            this.tabPage3.Controls.Add(this.cmbDebitAccount);
            this.tabPage3.Controls.Add(this.lblDebit);
            this.tabPage3.Controls.Add(this.txtCreditTotalGV);
            this.tabPage3.Controls.Add(this.label37);
            this.tabPage3.Controls.Add(this.txtDebitTotalGV);
            this.tabPage3.Controls.Add(this.label36);
            this.tabPage3.Controls.Add(this.label38);
            this.tabPage3.Controls.Add(this.txtGVAmount);
            this.tabPage3.Controls.Add(this.lblPrice);
            this.tabPage3.Location = new System.Drawing.Point(4, 28);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage3.Size = new System.Drawing.Size(1020, 535);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "JOURNAL VOUCHER";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // cmbCreditAccount
            // 
            this.cmbCreditAccount.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbCreditAccount.FormattingEnabled = true;
            this.cmbCreditAccount.Location = new System.Drawing.Point(122, 299);
            this.cmbCreditAccount.Margin = new System.Windows.Forms.Padding(2);
            this.cmbCreditAccount.Name = "cmbCreditAccount";
            this.cmbCreditAccount.Size = new System.Drawing.Size(230, 25);
            this.cmbCreditAccount.TabIndex = 2;
            this.cmbCreditAccount.Leave += new System.EventHandler(this.cmbCreditAccount_Leave);
            // 
            // btn_VIEW_VOUCHER
            // 
            this.btn_VIEW_VOUCHER.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(24)))), ((int)(((byte)(38)))));
            this.btn_VIEW_VOUCHER.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_VIEW_VOUCHER.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_VIEW_VOUCHER.ForeColor = System.Drawing.Color.White;
            this.btn_VIEW_VOUCHER.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_VIEW_VOUCHER.ImageIndex = 2;
            this.btn_VIEW_VOUCHER.Location = new System.Drawing.Point(867, 505);
            this.btn_VIEW_VOUCHER.Name = "btn_VIEW_VOUCHER";
            this.btn_VIEW_VOUCHER.Size = new System.Drawing.Size(146, 25);
            this.btn_VIEW_VOUCHER.TabIndex = 10;
            this.btn_VIEW_VOUCHER.TabStop = false;
            this.btn_VIEW_VOUCHER.Text = "VIEW VOUCHER";
            this.btn_VIEW_VOUCHER.UseVisualStyleBackColor = false;
            this.btn_VIEW_VOUCHER.Click += new System.EventHandler(this.btn_VIEW_VOUCHER_Click);
            // 
            // lblGV
            // 
            this.lblGV.AutoSize = true;
            this.lblGV.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblGV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(215)))));
            this.lblGV.Location = new System.Drawing.Point(123, 216);
            this.lblGV.Name = "lblGV";
            this.lblGV.Size = new System.Drawing.Size(60, 15);
            this.lblGV.TabIndex = 362;
            this.lblGV.Text = "JV-1-2017";
            // 
            // lblV
            // 
            this.lblV.AutoSize = true;
            this.lblV.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblV.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblV.Location = new System.Drawing.Point(9, 216);
            this.lblV.Name = "lblV";
            this.lblV.Size = new System.Drawing.Size(74, 15);
            this.lblV.TabIndex = 361;
            this.lblV.Text = "VOUCHER #:";
            // 
            // btnDeleteGeneral
            // 
            this.btnDeleteGeneral.BackColor = System.Drawing.Color.DarkRed;
            this.btnDeleteGeneral.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDeleteGeneral.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnDeleteGeneral.ForeColor = System.Drawing.Color.White;
            this.btnDeleteGeneral.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteGeneral.ImageIndex = 1;
            this.btnDeleteGeneral.Location = new System.Drawing.Point(711, 505);
            this.btnDeleteGeneral.Name = "btnDeleteGeneral";
            this.btnDeleteGeneral.Size = new System.Drawing.Size(150, 25);
            this.btnDeleteGeneral.TabIndex = 9;
            this.btnDeleteGeneral.TabStop = false;
            this.btnDeleteGeneral.Text = "DELETE";
            this.btnDeleteGeneral.UseVisualStyleBackColor = false;
            this.btnDeleteGeneral.Click += new System.EventHandler(this.btnDeleteGeneral_Click);
            // 
            // txtAmountWordsGen
            // 
            this.txtAmountWordsGen.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtAmountWordsGen.Location = new System.Drawing.Point(123, 362);
            this.txtAmountWordsGen.MaxLength = 50;
            this.txtAmountWordsGen.Name = "txtAmountWordsGen";
            this.txtAmountWordsGen.ReadOnly = true;
            this.txtAmountWordsGen.Size = new System.Drawing.Size(230, 25);
            this.txtAmountWordsGen.TabIndex = 4;
            this.txtAmountWordsGen.TabStop = false;
            this.txtAmountWordsGen.Text = "0";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label29.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label29.Location = new System.Drawing.Point(9, 369);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(114, 15);
            this.label29.TabIndex = 339;
            this.label29.Text = "AMOUNT(WORDS):";
            // 
            // grdENTRY
            // 
            this.grdENTRY.AllowUserToAddRows = false;
            this.grdENTRY.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.grdENTRY.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.grdENTRY.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdENTRY.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grdENTRY.BackgroundColor = System.Drawing.Color.White;
            this.grdENTRY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI Semibold", 10.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdENTRY.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.grdENTRY.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdENTRY.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DATE,
            this.debitAccount,
            this.creditAccount,
            this.DESCRIPTION,
            this.gvAmount,
            this.debitId,
            this.creditId});
            this.grdENTRY.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI Semibold", 10.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdENTRY.DefaultCellStyle = dataGridViewCellStyle7;
            this.grdENTRY.Location = new System.Drawing.Point(358, 213);
            this.grdENTRY.Name = "grdENTRY";
            this.grdENTRY.ReadOnly = true;
            this.grdENTRY.RowHeadersVisible = false;
            this.grdENTRY.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdENTRY.Size = new System.Drawing.Size(654, 258);
            this.grdENTRY.TabIndex = 337;
            this.grdENTRY.TabStop = false;
            this.grdENTRY.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdENTRY_CellClick);
            this.grdENTRY.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.grdENTRY_RowsAdded);
            this.grdENTRY.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.grdENTRY_RowsRemoved);
            // 
            // DATE
            // 
            this.DATE.HeaderText = "DATE";
            this.DATE.Name = "DATE";
            this.DATE.ReadOnly = true;
            // 
            // debitAccount
            // 
            this.debitAccount.HeaderText = "DEBIT ACCOUNT";
            this.debitAccount.Name = "debitAccount";
            this.debitAccount.ReadOnly = true;
            // 
            // creditAccount
            // 
            this.creditAccount.HeaderText = "CREDIT ACCOUNT";
            this.creditAccount.Name = "creditAccount";
            this.creditAccount.ReadOnly = true;
            // 
            // DESCRIPTION
            // 
            this.DESCRIPTION.HeaderText = "DESCRIPTION";
            this.DESCRIPTION.Name = "DESCRIPTION";
            this.DESCRIPTION.ReadOnly = true;
            this.DESCRIPTION.Visible = false;
            // 
            // gvAmount
            // 
            this.gvAmount.HeaderText = "AMOUNT";
            this.gvAmount.Name = "gvAmount";
            this.gvAmount.ReadOnly = true;
            // 
            // debitId
            // 
            this.debitId.HeaderText = "DEBIT_ID";
            this.debitId.Name = "debitId";
            this.debitId.ReadOnly = true;
            this.debitId.Visible = false;
            // 
            // creditId
            // 
            this.creditId.HeaderText = "CREDIT_ID";
            this.creditId.Name = "creditId";
            this.creditId.ReadOnly = true;
            this.creditId.Visible = false;
            // 
            // btnADD
            // 
            this.btnADD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(215)))));
            this.btnADD.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnADD.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnADD.ForeColor = System.Drawing.Color.White;
            this.btnADD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnADD.ImageIndex = 0;
            this.btnADD.Location = new System.Drawing.Point(123, 453);
            this.btnADD.Name = "btnADD";
            this.btnADD.Size = new System.Drawing.Size(230, 25);
            this.btnADD.TabIndex = 5;
            this.btnADD.Text = "ADD";
            this.btnADD.UseVisualStyleBackColor = false;
            this.btnADD.Click += new System.EventHandler(this.btnADD_Click);
            // 
            // txtSEARCH
            // 
            this.txtSEARCH.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSEARCH.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSEARCH.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtSEARCH.Location = new System.Drawing.Point(76, 7);
            this.txtSEARCH.Name = "txtSEARCH";
            this.txtSEARCH.Size = new System.Drawing.Size(937, 25);
            this.txtSEARCH.TabIndex = 287;
            this.txtSEARCH.TabStop = false;
            this.txtSEARCH.TextChanged += new System.EventHandler(this.txtSEARCH_TextChanged);
            // 
            // lblSEARCH
            // 
            this.lblSEARCH.AutoSize = true;
            this.lblSEARCH.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSEARCH.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSEARCH.Location = new System.Drawing.Point(9, 11);
            this.lblSEARCH.Name = "lblSEARCH";
            this.lblSEARCH.Size = new System.Drawing.Size(57, 17);
            this.lblSEARCH.TabIndex = 286;
            this.lblSEARCH.Text = "SEARCH";
            // 
            // EntryGrid
            // 
            this.EntryGrid.AllowUserToAddRows = false;
            this.EntryGrid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.LightBlue;
            this.EntryGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle8;
            this.EntryGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.EntryGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.EntryGrid.BackgroundColor = System.Drawing.Color.White;
            this.EntryGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.EntryGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EntryGrid.Location = new System.Drawing.Point(4, 38);
            this.EntryGrid.Margin = new System.Windows.Forms.Padding(2);
            this.EntryGrid.Name = "EntryGrid";
            this.EntryGrid.ReadOnly = true;
            this.EntryGrid.RowHeadersVisible = false;
            this.EntryGrid.RowTemplate.Height = 24;
            this.EntryGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.EntryGrid.Size = new System.Drawing.Size(1008, 169);
            this.EntryGrid.TabIndex = 148;
            this.EntryGrid.TabStop = false;
            this.EntryGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.EntryGrid_CellClick);
            this.EntryGrid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.EntryGrid_DataBindingComplete);
            // 
            // btnGeneralClr
            // 
            this.btnGeneralClr.BackColor = System.Drawing.Color.DimGray;
            this.btnGeneralClr.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGeneralClr.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnGeneralClr.ForeColor = System.Drawing.Color.White;
            this.btnGeneralClr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGeneralClr.ImageIndex = 1;
            this.btnGeneralClr.Location = new System.Drawing.Point(867, 477);
            this.btnGeneralClr.Name = "btnGeneralClr";
            this.btnGeneralClr.Size = new System.Drawing.Size(146, 25);
            this.btnGeneralClr.TabIndex = 8;
            this.btnGeneralClr.TabStop = false;
            this.btnGeneralClr.Text = "CLEAR";
            this.btnGeneralClr.UseVisualStyleBackColor = false;
            this.btnGeneralClr.Click += new System.EventHandler(this.btnClr_Click);
            // 
            // btnGeneralSave
            // 
            this.btnGeneralSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(215)))));
            this.btnGeneralSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGeneralSave.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnGeneralSave.ForeColor = System.Drawing.Color.White;
            this.btnGeneralSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGeneralSave.ImageIndex = 0;
            this.btnGeneralSave.Location = new System.Drawing.Point(711, 477);
            this.btnGeneralSave.Name = "btnGeneralSave";
            this.btnGeneralSave.Size = new System.Drawing.Size(150, 25);
            this.btnGeneralSave.TabIndex = 6;
            this.btnGeneralSave.Text = "SAVE";
            this.btnGeneralSave.UseVisualStyleBackColor = false;
            this.btnGeneralSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtNarration
            // 
            this.txtNarration.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtNarration.Location = new System.Drawing.Point(123, 393);
            this.txtNarration.MaxLength = 32000;
            this.txtNarration.Multiline = true;
            this.txtNarration.Name = "txtNarration";
            this.txtNarration.Size = new System.Drawing.Size(230, 54);
            this.txtNarration.TabIndex = 4;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblDescription.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDescription.Location = new System.Drawing.Point(9, 400);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(77, 15);
            this.lblDescription.TabIndex = 136;
            this.lblDescription.Text = "NARRATION:";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblDate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDate.Location = new System.Drawing.Point(9, 246);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(39, 15);
            this.lblDate.TabIndex = 131;
            this.lblDate.Text = "DATE:";
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtpDate.Location = new System.Drawing.Point(123, 241);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(230, 25);
            this.dtpDate.TabIndex = 0;
            // 
            // cmbDebitAccount
            // 
            this.cmbDebitAccount.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbDebitAccount.FormattingEnabled = true;
            this.cmbDebitAccount.Location = new System.Drawing.Point(123, 270);
            this.cmbDebitAccount.Margin = new System.Windows.Forms.Padding(2);
            this.cmbDebitAccount.Name = "cmbDebitAccount";
            this.cmbDebitAccount.Size = new System.Drawing.Size(230, 25);
            this.cmbDebitAccount.TabIndex = 1;
            this.cmbDebitAccount.DropDown += new System.EventHandler(this.cmbDebit_DropDown);
            this.cmbDebitAccount.TextUpdate += new System.EventHandler(this.cmbDebit_TextUpdate);
            this.cmbDebitAccount.Leave += new System.EventHandler(this.cmbDebitAccount_Leave);
            this.cmbDebitAccount.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmbDebit_PreviewKeyDown);
            // 
            // lblDebit
            // 
            this.lblDebit.AutoSize = true;
            this.lblDebit.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblDebit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDebit.Location = new System.Drawing.Point(9, 275);
            this.lblDebit.Name = "lblDebit";
            this.lblDebit.Size = new System.Drawing.Size(101, 15);
            this.lblDebit.TabIndex = 128;
            this.lblDebit.Text = "DEBIT ACCOUNT:";
            // 
            // txtCreditTotalGV
            // 
            this.txtCreditTotalGV.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtCreditTotalGV.Location = new System.Drawing.Point(449, 507);
            this.txtCreditTotalGV.MaxLength = 50;
            this.txtCreditTotalGV.Name = "txtCreditTotalGV";
            this.txtCreditTotalGV.ReadOnly = true;
            this.txtCreditTotalGV.Size = new System.Drawing.Size(239, 25);
            this.txtCreditTotalGV.TabIndex = 3;
            this.txtCreditTotalGV.TabStop = false;
            this.txtCreditTotalGV.Text = "0";
            this.txtCreditTotalGV.Click += new System.EventHandler(this.txtPrice_Click);
            this.txtCreditTotalGV.Enter += new System.EventHandler(this.txtPrice_Enter);
            this.txtCreditTotalGV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmnt_KeyPress);
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label37.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label37.Location = new System.Drawing.Point(359, 511);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(88, 15);
            this.label37.TabIndex = 127;
            this.label37.Text = "CREDIT TOTAL:";
            // 
            // txtDebitTotalGV
            // 
            this.txtDebitTotalGV.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtDebitTotalGV.Location = new System.Drawing.Point(449, 478);
            this.txtDebitTotalGV.MaxLength = 50;
            this.txtDebitTotalGV.Name = "txtDebitTotalGV";
            this.txtDebitTotalGV.ReadOnly = true;
            this.txtDebitTotalGV.Size = new System.Drawing.Size(239, 25);
            this.txtDebitTotalGV.TabIndex = 3;
            this.txtDebitTotalGV.TabStop = false;
            this.txtDebitTotalGV.Text = "0";
            this.txtDebitTotalGV.Click += new System.EventHandler(this.txtPrice_Click);
            this.txtDebitTotalGV.Enter += new System.EventHandler(this.txtPrice_Enter);
            this.txtDebitTotalGV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmnt_KeyPress);
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label36.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label36.Location = new System.Drawing.Point(359, 481);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(81, 15);
            this.label36.TabIndex = 127;
            this.label36.Text = "DEBIT TOTAL:";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label38.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label38.Location = new System.Drawing.Point(9, 303);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(108, 15);
            this.label38.TabIndex = 127;
            this.label38.Text = "CREDIT ACCOUNT:";
            // 
            // txtGVAmount
            // 
            this.txtGVAmount.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtGVAmount.Location = new System.Drawing.Point(123, 329);
            this.txtGVAmount.MaxLength = 50;
            this.txtGVAmount.Name = "txtGVAmount";
            this.txtGVAmount.Size = new System.Drawing.Size(230, 25);
            this.txtGVAmount.TabIndex = 3;
            this.txtGVAmount.Text = "0";
            this.txtGVAmount.Click += new System.EventHandler(this.txtPrice_Click);
            this.txtGVAmount.TextChanged += new System.EventHandler(this.txtPrice_TextChanged);
            this.txtGVAmount.Enter += new System.EventHandler(this.txtPrice_Enter);
            this.txtGVAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmnt_KeyPress);
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblPrice.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPrice.Location = new System.Drawing.Point(9, 334);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(62, 15);
            this.lblPrice.TabIndex = 127;
            this.lblPrice.Text = "AMOUNT:";
            // 
            // frm_GeneralVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1032, 644);
            this.Controls.Add(this.dayControl);
            this.Controls.Add(this.pnlHEADER);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frm_GeneralVoucher";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JOURNAL VOUCHER";
            this.Load += new System.EventHandler(this.DayBookForm_Load);
            this.pnlHEADER.ResumeLayout(false);
            this.pnlHEADER.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
            this.dayControl.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdENTRY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntryGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHEADER;
        private System.Windows.Forms.PictureBox pictureBox15;
        private System.Windows.Forms.PictureBox pictureBox14;
        private System.Windows.Forms.Label lblHEADING;
        private System.Windows.Forms.TabControl dayControl;
        private System.Windows.Forms.TabPage tabPage3;
        private SergeUtils.EasyCompletionComboBox cmbDebitAccount;
        private System.Windows.Forms.Label lblDebit;
        private System.Windows.Forms.TextBox txtGVAmount;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblCredit;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.TextBox txtNarration;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnGeneralClr;
        private System.Windows.Forms.Button btnGeneralSave;
        private System.Windows.Forms.DataGridView EntryGrid;
        private System.Windows.Forms.TextBox txtSEARCH;
        private System.Windows.Forms.Label lblSEARCH;
        private System.Windows.Forms.DataGridView grdENTRY;
        private System.Windows.Forms.Button btnADD;
        private System.Windows.Forms.TextBox txtAmountWordsGen;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Button btnDeleteGeneral;
        private System.Windows.Forms.Label lblGV;
        private System.Windows.Forms.Label lblV;
        private System.Windows.Forms.TextBox txtCreditTotalGV;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.TextBox txtDebitTotalGV;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Button btn_VIEW_VOUCHER;
        private SergeUtils.EasyCompletionComboBox cmbCreditAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn debitAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn creditAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESCRIPTION;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn debitId;
        private System.Windows.Forms.DataGridViewTextBoxColumn creditId;
    }
}