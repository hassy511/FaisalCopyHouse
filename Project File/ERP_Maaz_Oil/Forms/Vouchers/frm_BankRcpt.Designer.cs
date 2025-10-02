namespace ERP_Maaz_Oil.Forms
{
    partial class frm_BankRcpt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_BankRcpt));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.txtReceive = new System.Windows.Forms.TextBox();
            this.lblReceive = new System.Windows.Forms.Label();
            this.cmbRc = new SergeUtils.EasyCompletionComboBox();
            this.lblTrNo = new System.Windows.Forms.Label();
            this.lblTr = new System.Windows.Forms.Label();
            this.dtp_DATE = new System.Windows.Forms.DateTimePicker();
            this.lblBRV = new System.Windows.Forms.Label();
            this.txtNar = new System.Windows.Forms.TextBox();
            this.lblAcc = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lblAmt = new System.Windows.Forms.Label();
            this.lblRc = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblV = new System.Windows.Forms.Label();
            this.grdSEARCH = new System.Windows.Forms.DataGridView();
            this.txtSEARCH = new System.Windows.Forms.TextBox();
            this.lblSEARCH = new System.Windows.Forms.Label();
            this.txtChq = new System.Windows.Forms.TextBox();
            this.lblCHQ = new System.Windows.Forms.Label();
            this.cmbBank = new SergeUtils.EasyCompletionComboBox();
            this.lblBank = new System.Windows.Forms.Label();
            this.dtChq = new System.Windows.Forms.DateTimePicker();
            this.lblChqDt = new System.Windows.Forms.Label();
            this.btnCLEAR = new System.Windows.Forms.Button();
            this.btnSAVE = new System.Windows.Forms.Button();
            this.pnlHEADER = new System.Windows.Forms.Panel();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.lblHEADING = new System.Windows.Forms.Label();
            this.btn_VIEW_VOUCHER = new System.Windows.Forms.Button();
            this.cmbSELECT_INV = new SergeUtils.EasyCompletionComboBox();
            this.lbl_SELECT_INV = new System.Windows.Forms.Label();
            this.rdbOTHERS = new System.Windows.Forms.RadioButton();
            this.rdbINV_REC = new System.Windows.Forms.RadioButton();
            this.cmbBankSearch = new SergeUtils.EasyCompletionComboBox();
            this.txtAmountWordsRec = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdSEARCH)).BeginInit();
            this.pnlHEADER.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icons8-Save as Filled-100.png");
            this.imageList1.Images.SetKeyName(1, "icons8-Cancel Filled-100.png");
            this.imageList1.Images.SetKeyName(2, "icons8-search.png");
            // 
            // txtReceive
            // 
            this.txtReceive.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtReceive.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtReceive.Location = new System.Drawing.Point(153, 577);
            this.txtReceive.Margin = new System.Windows.Forms.Padding(4);
            this.txtReceive.MaxLength = 50;
            this.txtReceive.Name = "txtReceive";
            this.txtReceive.Size = new System.Drawing.Size(307, 29);
            this.txtReceive.TabIndex = 4;
            this.txtReceive.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtAmount_MouseClick);
            this.txtReceive.Enter += new System.EventHandler(this.txtAmount_Enter);
            this.txtReceive.Leave += new System.EventHandler(this.txtReceive_Leave);
            // 
            // lblReceive
            // 
            this.lblReceive.AutoSize = true;
            this.lblReceive.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblReceive.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblReceive.Location = new System.Drawing.Point(11, 584);
            this.lblReceive.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReceive.Name = "lblReceive";
            this.lblReceive.Size = new System.Drawing.Size(126, 20);
            this.lblReceive.TabIndex = 273;
            this.lblReceive.Text = "RECEIVED FROM:";
            // 
            // cmbRc
            // 
            this.cmbRc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbRc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRc.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbRc.FormattingEnabled = true;
            this.cmbRc.Location = new System.Drawing.Point(153, 539);
            this.cmbRc.Margin = new System.Windows.Forms.Padding(4);
            this.cmbRc.Name = "cmbRc";
            this.cmbRc.Size = new System.Drawing.Size(307, 29);
            this.cmbRc.TabIndex = 5;
            this.cmbRc.DropDown += new System.EventHandler(this.cmbRc_DropDown);
            this.cmbRc.TextUpdate += new System.EventHandler(this.cmbRc_TextUpdate);
            this.cmbRc.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmbRc_PreviewKeyDown);
            // 
            // lblTrNo
            // 
            this.lblTrNo.AutoSize = true;
            this.lblTrNo.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblTrNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(24)))), ((int)(((byte)(38)))));
            this.lblTrNo.Location = new System.Drawing.Point(149, 440);
            this.lblTrNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTrNo.Name = "lblTrNo";
            this.lblTrNo.Size = new System.Drawing.Size(85, 20);
            this.lblTrNo.TabIndex = 271;
            this.lblTrNo.Text = "1221023332";
            // 
            // lblTr
            // 
            this.lblTr.AutoSize = true;
            this.lblTr.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblTr.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTr.Location = new System.Drawing.Point(11, 438);
            this.lblTr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTr.Name = "lblTr";
            this.lblTr.Size = new System.Drawing.Size(127, 20);
            this.lblTr.TabIndex = 270;
            this.lblTr.Text = "TRANSACTION #:";
            // 
            // dtp_DATE
            // 
            this.dtp_DATE.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.dtp_DATE.Location = new System.Drawing.Point(153, 466);
            this.dtp_DATE.Margin = new System.Windows.Forms.Padding(4);
            this.dtp_DATE.Name = "dtp_DATE";
            this.dtp_DATE.Size = new System.Drawing.Size(307, 27);
            this.dtp_DATE.TabIndex = 0;
            // 
            // lblBRV
            // 
            this.lblBRV.AutoSize = true;
            this.lblBRV.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblBRV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(215)))));
            this.lblBRV.Location = new System.Drawing.Point(149, 409);
            this.lblBRV.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBRV.Name = "lblBRV";
            this.lblBRV.Size = new System.Drawing.Size(85, 20);
            this.lblBRV.TabIndex = 268;
            this.lblBRV.Text = "BRV-1-2017";
            // 
            // txtNar
            // 
            this.txtNar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNar.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtNar.Location = new System.Drawing.Point(628, 543);
            this.txtNar.Margin = new System.Windows.Forms.Padding(4);
            this.txtNar.MaxLength = 100;
            this.txtNar.Multiline = true;
            this.txtNar.Name = "txtNar";
            this.txtNar.Size = new System.Drawing.Size(307, 68);
            this.txtNar.TabIndex = 1;
            this.txtNar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtAmount_MouseClick);
            this.txtNar.Enter += new System.EventHandler(this.txtAmount_Enter);
            this.txtNar.Leave += new System.EventHandler(this.txtReceive_Leave);
            // 
            // lblAcc
            // 
            this.lblAcc.AutoSize = true;
            this.lblAcc.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblAcc.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblAcc.Location = new System.Drawing.Point(479, 549);
            this.lblAcc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAcc.Name = "lblAcc";
            this.lblAcc.Size = new System.Drawing.Size(97, 20);
            this.lblAcc.TabIndex = 266;
            this.lblAcc.Text = "NARRATION:";
            // 
            // txtAmount
            // 
            this.txtAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAmount.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtAmount.Location = new System.Drawing.Point(628, 471);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(4);
            this.txtAmount.MaxLength = 10;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(307, 29);
            this.txtAmount.TabIndex = 6;
            this.txtAmount.Text = "0.0";
            this.txtAmount.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtAmount_MouseClick);
            this.txtAmount.TextChanged += new System.EventHandler(this.txtAmount_TextChanged);
            this.txtAmount.Enter += new System.EventHandler(this.txtAmount_Enter);
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            this.txtAmount.Leave += new System.EventHandler(this.txtAmount_Leave);
            // 
            // lblAmt
            // 
            this.lblAmt.AutoSize = true;
            this.lblAmt.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblAmt.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblAmt.Location = new System.Drawing.Point(479, 479);
            this.lblAmt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAmt.Name = "lblAmt";
            this.lblAmt.Size = new System.Drawing.Size(79, 20);
            this.lblAmt.TabIndex = 264;
            this.lblAmt.Text = "AMOUNT:";
            // 
            // lblRc
            // 
            this.lblRc.AutoSize = true;
            this.lblRc.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblRc.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblRc.Location = new System.Drawing.Point(11, 545);
            this.lblRc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRc.Name = "lblRc";
            this.lblRc.Size = new System.Drawing.Size(142, 20);
            this.lblRc.TabIndex = 261;
            this.lblRc.Text = "RECEIPT ACCOUNT:";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblDate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDate.Location = new System.Drawing.Point(11, 440);
            this.lblDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(49, 20);
            this.lblDate.TabIndex = 260;
            this.lblDate.Text = "DATE:";
            // 
            // lblV
            // 
            this.lblV.AutoSize = true;
            this.lblV.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblV.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblV.Location = new System.Drawing.Point(11, 409);
            this.lblV.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblV.Name = "lblV";
            this.lblV.Size = new System.Drawing.Size(95, 20);
            this.lblV.TabIndex = 259;
            this.lblV.Text = "VOUCHER #:";
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
            this.grdSEARCH.Location = new System.Drawing.Point(-3, 156);
            this.grdSEARCH.Margin = new System.Windows.Forms.Padding(4);
            this.grdSEARCH.Name = "grdSEARCH";
            this.grdSEARCH.ReadOnly = true;
            this.grdSEARCH.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSEARCH.Size = new System.Drawing.Size(947, 233);
            this.grdSEARCH.TabIndex = 258;
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
            this.txtSEARCH.Location = new System.Drawing.Point(95, 118);
            this.txtSEARCH.Margin = new System.Windows.Forms.Padding(4);
            this.txtSEARCH.Name = "txtSEARCH";
            this.txtSEARCH.Size = new System.Drawing.Size(791, 29);
            this.txtSEARCH.TabIndex = 257;
            this.txtSEARCH.TextChanged += new System.EventHandler(this.txtSEARCH_TextChanged);
            // 
            // lblSEARCH
            // 
            this.lblSEARCH.AutoSize = true;
            this.lblSEARCH.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSEARCH.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSEARCH.Location = new System.Drawing.Point(11, 123);
            this.lblSEARCH.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSEARCH.Name = "lblSEARCH";
            this.lblSEARCH.Size = new System.Drawing.Size(74, 23);
            this.lblSEARCH.TabIndex = 256;
            this.lblSEARCH.Text = "SEARCH";
            // 
            // txtChq
            // 
            this.txtChq.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtChq.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtChq.Location = new System.Drawing.Point(626, 400);
            this.txtChq.Margin = new System.Windows.Forms.Padding(4);
            this.txtChq.MaxLength = 100;
            this.txtChq.Name = "txtChq";
            this.txtChq.Size = new System.Drawing.Size(307, 29);
            this.txtChq.TabIndex = 2;
            this.txtChq.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtAmount_MouseClick);
            this.txtChq.Enter += new System.EventHandler(this.txtAmount_Enter);
            this.txtChq.Leave += new System.EventHandler(this.txtReceive_Leave);
            // 
            // lblCHQ
            // 
            this.lblCHQ.AutoSize = true;
            this.lblCHQ.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblCHQ.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCHQ.Location = new System.Drawing.Point(479, 404);
            this.lblCHQ.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCHQ.Name = "lblCHQ";
            this.lblCHQ.Size = new System.Drawing.Size(84, 20);
            this.lblCHQ.TabIndex = 275;
            this.lblCHQ.Text = "CHEQUE #:";
            // 
            // cmbBank
            // 
            this.cmbBank.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbBank.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBank.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbBank.FormattingEnabled = true;
            this.cmbBank.Location = new System.Drawing.Point(153, 501);
            this.cmbBank.Margin = new System.Windows.Forms.Padding(4);
            this.cmbBank.Name = "cmbBank";
            this.cmbBank.Size = new System.Drawing.Size(307, 29);
            this.cmbBank.TabIndex = 7;
            this.cmbBank.DropDown += new System.EventHandler(this.cmbBank_DropDown);
            this.cmbBank.TextUpdate += new System.EventHandler(this.cmbRc_TextUpdate);
            this.cmbBank.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmbBank_PreviewKeyDown);
            // 
            // lblBank
            // 
            this.lblBank.AutoSize = true;
            this.lblBank.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblBank.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblBank.Location = new System.Drawing.Point(11, 510);
            this.lblBank.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBank.Name = "lblBank";
            this.lblBank.Size = new System.Drawing.Size(127, 20);
            this.lblBank.TabIndex = 277;
            this.lblBank.Text = "BANK ACCOUNT:";
            // 
            // dtChq
            // 
            this.dtChq.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.dtChq.Location = new System.Drawing.Point(626, 437);
            this.dtChq.Margin = new System.Windows.Forms.Padding(4);
            this.dtChq.Name = "dtChq";
            this.dtChq.Size = new System.Drawing.Size(307, 27);
            this.dtChq.TabIndex = 3;
            // 
            // lblChqDt
            // 
            this.lblChqDt.AutoSize = true;
            this.lblChqDt.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblChqDt.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblChqDt.Location = new System.Drawing.Point(479, 442);
            this.lblChqDt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblChqDt.Name = "lblChqDt";
            this.lblChqDt.Size = new System.Drawing.Size(111, 20);
            this.lblChqDt.TabIndex = 279;
            this.lblChqDt.Text = "CHEQUE DATE:";
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
            this.btnCLEAR.Location = new System.Drawing.Point(778, 620);
            this.btnCLEAR.Margin = new System.Windows.Forms.Padding(4);
            this.btnCLEAR.Name = "btnCLEAR";
            this.btnCLEAR.Size = new System.Drawing.Size(157, 31);
            this.btnCLEAR.TabIndex = 10;
            this.btnCLEAR.Text = "CLEAR";
            this.btnCLEAR.UseVisualStyleBackColor = false;
            this.btnCLEAR.Click += new System.EventHandler(this.btnCLEAR_Click);
            // 
            // btnSAVE
            // 
            this.btnSAVE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(215)))));
            this.btnSAVE.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSAVE.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSAVE.ForeColor = System.Drawing.Color.White;
            this.btnSAVE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSAVE.ImageIndex = 0;
            this.btnSAVE.ImageList = this.imageList1;
            this.btnSAVE.Location = new System.Drawing.Point(628, 620);
            this.btnSAVE.Margin = new System.Windows.Forms.Padding(4);
            this.btnSAVE.Name = "btnSAVE";
            this.btnSAVE.Size = new System.Drawing.Size(150, 31);
            this.btnSAVE.TabIndex = 9;
            this.btnSAVE.Text = "SAVE";
            this.btnSAVE.UseVisualStyleBackColor = false;
            this.btnSAVE.Click += new System.EventHandler(this.btnSAVE_Click_1);
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
            this.pnlHEADER.Margin = new System.Windows.Forms.Padding(4);
            this.pnlHEADER.Name = "pnlHEADER";
            this.pnlHEADER.Size = new System.Drawing.Size(941, 108);
            this.pnlHEADER.TabIndex = 255;
            // 
            // pictureBox15
            // 
            this.pictureBox15.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox15.Image = global::ERP_Maaz_Oil.Properties.Resources.plus;
            this.pictureBox15.Location = new System.Drawing.Point(1787, 4);
            this.pictureBox15.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox15.Name = "pictureBox15";
            this.pictureBox15.Size = new System.Drawing.Size(65, 25);
            this.pictureBox15.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox15.TabIndex = 25;
            this.pictureBox15.TabStop = false;
            // 
            // lblHEADING
            // 
            this.lblHEADING.AutoSize = true;
            this.lblHEADING.BackColor = System.Drawing.Color.Transparent;
            this.lblHEADING.Font = new System.Drawing.Font("Berlin Sans FB", 15.75F);
            this.lblHEADING.ForeColor = System.Drawing.Color.White;
            this.lblHEADING.Location = new System.Drawing.Point(8, 39);
            this.lblHEADING.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHEADING.Name = "lblHEADING";
            this.lblHEADING.Size = new System.Drawing.Size(318, 30);
            this.lblHEADING.TabIndex = 23;
            this.lblHEADING.Text = "BANK RECEIPT VOUCHER";
            // 
            // btn_VIEW_VOUCHER
            // 
            this.btn_VIEW_VOUCHER.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(24)))), ((int)(((byte)(38)))));
            this.btn_VIEW_VOUCHER.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_VIEW_VOUCHER.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_VIEW_VOUCHER.ForeColor = System.Drawing.Color.White;
            this.btn_VIEW_VOUCHER.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_VIEW_VOUCHER.ImageIndex = 2;
            this.btn_VIEW_VOUCHER.ImageList = this.imageList1;
            this.btn_VIEW_VOUCHER.Location = new System.Drawing.Point(153, 620);
            this.btn_VIEW_VOUCHER.Margin = new System.Windows.Forms.Padding(4);
            this.btn_VIEW_VOUCHER.Name = "btn_VIEW_VOUCHER";
            this.btn_VIEW_VOUCHER.Size = new System.Drawing.Size(308, 31);
            this.btn_VIEW_VOUCHER.TabIndex = 8;
            this.btn_VIEW_VOUCHER.Text = "VIEW VOUCHER";
            this.btn_VIEW_VOUCHER.UseVisualStyleBackColor = false;
            this.btn_VIEW_VOUCHER.Click += new System.EventHandler(this.btn_VIEW_VOUCHER_Click);
            // 
            // cmbSELECT_INV
            // 
            this.cmbSELECT_INV.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSELECT_INV.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSELECT_INV.Enabled = false;
            this.cmbSELECT_INV.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbSELECT_INV.FormattingEnabled = true;
            this.cmbSELECT_INV.Location = new System.Drawing.Point(904, 649);
            this.cmbSELECT_INV.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSELECT_INV.Name = "cmbSELECT_INV";
            this.cmbSELECT_INV.Size = new System.Drawing.Size(307, 29);
            this.cmbSELECT_INV.TabIndex = 282;
            this.cmbSELECT_INV.Visible = false;
            this.cmbSELECT_INV.DropDown += new System.EventHandler(this.cmbSELECT_INV_DropDown);
            this.cmbSELECT_INV.TextUpdate += new System.EventHandler(this.cmbSELECT_INV_TextUpdate);
            this.cmbSELECT_INV.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmbSELECT_INV_PreviewKeyDown);
            // 
            // lbl_SELECT_INV
            // 
            this.lbl_SELECT_INV.AutoSize = true;
            this.lbl_SELECT_INV.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lbl_SELECT_INV.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_SELECT_INV.Location = new System.Drawing.Point(745, 655);
            this.lbl_SELECT_INV.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_SELECT_INV.Name = "lbl_SELECT_INV";
            this.lbl_SELECT_INV.Size = new System.Drawing.Size(123, 20);
            this.lbl_SELECT_INV.TabIndex = 283;
            this.lbl_SELECT_INV.Text = "SELECT INVOICE:";
            this.lbl_SELECT_INV.Visible = false;
            // 
            // rdbOTHERS
            // 
            this.rdbOTHERS.AutoSize = true;
            this.rdbOTHERS.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.rdbOTHERS.Location = new System.Drawing.Point(902, 645);
            this.rdbOTHERS.Margin = new System.Windows.Forms.Padding(4);
            this.rdbOTHERS.Name = "rdbOTHERS";
            this.rdbOTHERS.Size = new System.Drawing.Size(85, 27);
            this.rdbOTHERS.TabIndex = 281;
            this.rdbOTHERS.Text = "OTHER";
            this.rdbOTHERS.UseVisualStyleBackColor = true;
            this.rdbOTHERS.Visible = false;
            this.rdbOTHERS.CheckedChanged += new System.EventHandler(this.rdbOTHERS_CheckedChanged);
            // 
            // rdbINV_REC
            // 
            this.rdbINV_REC.AutoSize = true;
            this.rdbINV_REC.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.rdbINV_REC.Location = new System.Drawing.Point(902, 645);
            this.rdbINV_REC.Margin = new System.Windows.Forms.Padding(4);
            this.rdbINV_REC.Name = "rdbINV_REC";
            this.rdbINV_REC.Size = new System.Drawing.Size(146, 27);
            this.rdbINV_REC.TabIndex = 280;
            this.rdbINV_REC.TabStop = true;
            this.rdbINV_REC.Text = "INVOICE / REC";
            this.rdbINV_REC.UseVisualStyleBackColor = true;
            this.rdbINV_REC.Visible = false;
            this.rdbINV_REC.CheckedChanged += new System.EventHandler(this.rdbINV_REC_CheckedChanged);
            // 
            // cmbBankSearch
            // 
            this.cmbBankSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbBankSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBankSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbBankSearch.FormattingEnabled = true;
            this.cmbBankSearch.Location = new System.Drawing.Point(625, 118);
            this.cmbBankSearch.Margin = new System.Windows.Forms.Padding(4);
            this.cmbBankSearch.Name = "cmbBankSearch";
            this.cmbBankSearch.Size = new System.Drawing.Size(307, 29);
            this.cmbBankSearch.TabIndex = 284;
            this.cmbBankSearch.DropDown += new System.EventHandler(this.cmbBankSearch_DropDown);
            this.cmbBankSearch.SelectedIndexChanged += new System.EventHandler(this.cmbBankSearch_SelectedIndexChanged);
            this.cmbBankSearch.TextUpdate += new System.EventHandler(this.cmbRc_TextUpdate);
            this.cmbBankSearch.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmbBankSearch_PreviewKeyDown);
            // 
            // txtAmountWordsRec
            // 
            this.txtAmountWordsRec.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtAmountWordsRec.Location = new System.Drawing.Point(628, 507);
            this.txtAmountWordsRec.Margin = new System.Windows.Forms.Padding(4);
            this.txtAmountWordsRec.MaxLength = 50;
            this.txtAmountWordsRec.Name = "txtAmountWordsRec";
            this.txtAmountWordsRec.ReadOnly = true;
            this.txtAmountWordsRec.Size = new System.Drawing.Size(307, 29);
            this.txtAmountWordsRec.TabIndex = 285;
            this.txtAmountWordsRec.Text = "-";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label27.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label27.Location = new System.Drawing.Point(479, 512);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(142, 20);
            this.label27.TabIndex = 286;
            this.label27.Text = "AMOUNT(WORDS):";
            // 
            // frm_BankRcpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(941, 659);
            this.Controls.Add(this.txtAmountWordsRec);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.cmbBankSearch);
            this.Controls.Add(this.cmbSELECT_INV);
            this.Controls.Add(this.lbl_SELECT_INV);
            this.Controls.Add(this.rdbOTHERS);
            this.Controls.Add(this.rdbINV_REC);
            this.Controls.Add(this.btn_VIEW_VOUCHER);
            this.Controls.Add(this.dtChq);
            this.Controls.Add(this.lblChqDt);
            this.Controls.Add(this.cmbBank);
            this.Controls.Add(this.lblBank);
            this.Controls.Add(this.txtChq);
            this.Controls.Add(this.lblCHQ);
            this.Controls.Add(this.txtReceive);
            this.Controls.Add(this.lblReceive);
            this.Controls.Add(this.cmbRc);
            this.Controls.Add(this.lblTrNo);
            this.Controls.Add(this.lblTr);
            this.Controls.Add(this.dtp_DATE);
            this.Controls.Add(this.lblBRV);
            this.Controls.Add(this.txtNar);
            this.Controls.Add(this.lblAcc);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.lblAmt);
            this.Controls.Add(this.btnCLEAR);
            this.Controls.Add(this.btnSAVE);
            this.Controls.Add(this.lblRc);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblV);
            this.Controls.Add(this.grdSEARCH);
            this.Controls.Add(this.txtSEARCH);
            this.Controls.Add(this.lblSEARCH);
            this.Controls.Add(this.pnlHEADER);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_BankRcpt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BANK RECEIPT VOUCHER";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_BankRcpt_FormClosed);
            this.Load += new System.EventHandler(this.frm_BankRcpt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdSEARCH)).EndInit();
            this.pnlHEADER.ResumeLayout(false);
            this.pnlHEADER.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox15;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox txtReceive;
        private System.Windows.Forms.Label lblReceive;
        private SergeUtils.EasyCompletionComboBox cmbRc;
        private System.Windows.Forms.Label lblTrNo;
        private System.Windows.Forms.Label lblHEADING;
        private System.Windows.Forms.Label lblTr;
        private System.Windows.Forms.DateTimePicker dtp_DATE;
        private System.Windows.Forms.Label lblBRV;
        private System.Windows.Forms.TextBox txtNar;
        private System.Windows.Forms.Label lblAcc;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label lblAmt;
        private System.Windows.Forms.Button btnCLEAR;
        private System.Windows.Forms.Button btnSAVE;
        private System.Windows.Forms.Label lblRc;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblV;
        private System.Windows.Forms.DataGridView grdSEARCH;
        private System.Windows.Forms.TextBox txtSEARCH;
        private System.Windows.Forms.Label lblSEARCH;
        private System.Windows.Forms.Panel pnlHEADER;
        private System.Windows.Forms.TextBox txtChq;
        private System.Windows.Forms.Label lblCHQ;
        private SergeUtils.EasyCompletionComboBox cmbBank;
        private System.Windows.Forms.Label lblBank;
        private System.Windows.Forms.DateTimePicker dtChq;
        private System.Windows.Forms.Label lblChqDt;
        private System.Windows.Forms.Button btn_VIEW_VOUCHER;
        private SergeUtils.EasyCompletionComboBox cmbSELECT_INV;
        private System.Windows.Forms.Label lbl_SELECT_INV;
        private System.Windows.Forms.RadioButton rdbOTHERS;
        private System.Windows.Forms.RadioButton rdbINV_REC;
        private SergeUtils.EasyCompletionComboBox cmbBankSearch;
        private System.Windows.Forms.TextBox txtAmountWordsRec;
        private System.Windows.Forms.Label label27;
    }
}