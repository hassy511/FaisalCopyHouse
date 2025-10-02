namespace ERP_Maaz_Oil.Forms
{
    partial class frm_BankTr
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_BankTr));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtChq = new System.Windows.Forms.DateTimePicker();
            this.lblChqDt = new System.Windows.Forms.Label();
            this.cmbTrTo = new SergeUtils.EasyCompletionComboBox();
            this.lblTrTo = new System.Windows.Forms.Label();
            this.txtChq = new System.Windows.Forms.TextBox();
            this.lblCHQ = new System.Windows.Forms.Label();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.cmbTRFrom = new SergeUtils.EasyCompletionComboBox();
            this.lblTrNo = new System.Windows.Forms.Label();
            this.lblTr = new System.Windows.Forms.Label();
            this.dtp_DATE = new System.Windows.Forms.DateTimePicker();
            this.lblTV = new System.Windows.Forms.Label();
            this.lblHEADING = new System.Windows.Forms.Label();
            this.txtNar = new System.Windows.Forms.TextBox();
            this.lblNar = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lblTrFrom = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnCLEAR = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblAmt = new System.Windows.Forms.Label();
            this.btnSAVE = new System.Windows.Forms.Button();
            this.lblV = new System.Windows.Forms.Label();
            this.grdSEARCH = new System.Windows.Forms.DataGridView();
            this.txtSEARCH = new System.Windows.Forms.TextBox();
            this.lblSEARCH = new System.Windows.Forms.Label();
            this.pnlHEADER = new System.Windows.Forms.Panel();
            this.btn_VIEW_VOUCHER = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSEARCH)).BeginInit();
            this.pnlHEADER.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtChq
            // 
            this.dtChq.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.dtChq.Location = new System.Drawing.Point(114, 498);
            this.dtChq.Name = "dtChq";
            this.dtChq.Size = new System.Drawing.Size(231, 23);
            this.dtChq.TabIndex = 2;
            // 
            // lblChqDt
            // 
            this.lblChqDt.AutoSize = true;
            this.lblChqDt.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblChqDt.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblChqDt.Location = new System.Drawing.Point(5, 502);
            this.lblChqDt.Name = "lblChqDt";
            this.lblChqDt.Size = new System.Drawing.Size(87, 15);
            this.lblChqDt.TabIndex = 331;
            this.lblChqDt.Text = "CHEQUE DATE:";
            // 
            // cmbTrTo
            // 
            this.cmbTrTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTrTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTrTo.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbTrTo.FormattingEnabled = true;
            this.cmbTrTo.Location = new System.Drawing.Point(469, 528);
            this.cmbTrTo.Name = "cmbTrTo";
            this.cmbTrTo.Size = new System.Drawing.Size(231, 25);
            this.cmbTrTo.TabIndex = 5;
            this.cmbTrTo.DropDown += new System.EventHandler(this.cmbTrTo_DropDown);
            this.cmbTrTo.TextUpdate += new System.EventHandler(this.cmbTRFrom_TextUpdate);
            this.cmbTrTo.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmbTrTo_PreviewKeyDown);
            // 
            // lblTrTo
            // 
            this.lblTrTo.AutoSize = true;
            this.lblTrTo.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblTrTo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTrTo.Location = new System.Drawing.Point(352, 533);
            this.lblTrTo.Name = "lblTrTo";
            this.lblTrTo.Size = new System.Drawing.Size(86, 15);
            this.lblTrTo.TabIndex = 329;
            this.lblTrTo.Text = "TRANSFER TO:";
            // 
            // txtChq
            // 
            this.txtChq.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtChq.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtChq.Location = new System.Drawing.Point(469, 466);
            this.txtChq.MaxLength = 100;
            this.txtChq.Name = "txtChq";
            this.txtChq.Size = new System.Drawing.Size(231, 25);
            this.txtChq.TabIndex = 1;
            this.txtChq.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtAmount_MouseClick);
            this.txtChq.Enter += new System.EventHandler(this.txtAmount_Enter);
            this.txtChq.Leave += new System.EventHandler(this.txtChq_Leave);
            // 
            // lblCHQ
            // 
            this.lblCHQ.AutoSize = true;
            this.lblCHQ.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblCHQ.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCHQ.Location = new System.Drawing.Point(352, 471);
            this.lblCHQ.Name = "lblCHQ";
            this.lblCHQ.Size = new System.Drawing.Size(65, 15);
            this.lblCHQ.TabIndex = 327;
            this.lblCHQ.Text = "CHEQUE #:";
            // 
            // pictureBox15
            // 
            this.pictureBox15.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox15.Image = global::ERP_Maaz_Oil.Properties.Resources.plus;
            this.pictureBox15.Location = new System.Drawing.Point(1340, 3);
            this.pictureBox15.Name = "pictureBox15";
            this.pictureBox15.Size = new System.Drawing.Size(49, 20);
            this.pictureBox15.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox15.TabIndex = 25;
            this.pictureBox15.TabStop = false;
            // 
            // cmbTRFrom
            // 
            this.cmbTRFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTRFrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTRFrom.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbTRFrom.FormattingEnabled = true;
            this.cmbTRFrom.Location = new System.Drawing.Point(114, 528);
            this.cmbTRFrom.Name = "cmbTRFrom";
            this.cmbTRFrom.Size = new System.Drawing.Size(231, 25);
            this.cmbTRFrom.TabIndex = 4;
            this.cmbTRFrom.DropDown += new System.EventHandler(this.cmbTRFrom_DropDown);
            this.cmbTRFrom.TextUpdate += new System.EventHandler(this.cmbTRFrom_TextUpdate);
            this.cmbTRFrom.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmbTRFrom_PreviewKeyDown);
            // 
            // lblTrNo
            // 
            this.lblTrNo.AutoSize = true;
            this.lblTrNo.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblTrNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(24)))), ((int)(((byte)(38)))));
            this.lblTrNo.Location = new System.Drawing.Point(111, 447);
            this.lblTrNo.Name = "lblTrNo";
            this.lblTrNo.Size = new System.Drawing.Size(73, 15);
            this.lblTrNo.TabIndex = 323;
            this.lblTrNo.Text = "1221023332";
            // 
            // lblTr
            // 
            this.lblTr.AutoSize = true;
            this.lblTr.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblTr.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTr.Location = new System.Drawing.Point(5, 447);
            this.lblTr.Name = "lblTr";
            this.lblTr.Size = new System.Drawing.Size(102, 15);
            this.lblTr.TabIndex = 322;
            this.lblTr.Text = "TRANSACTION #:";
            // 
            // dtp_DATE
            // 
            this.dtp_DATE.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.dtp_DATE.Location = new System.Drawing.Point(114, 468);
            this.dtp_DATE.Name = "dtp_DATE";
            this.dtp_DATE.Size = new System.Drawing.Size(231, 23);
            this.dtp_DATE.TabIndex = 0;
            // 
            // lblTV
            // 
            this.lblTV.AutoSize = true;
            this.lblTV.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblTV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(215)))));
            this.lblTV.Location = new System.Drawing.Point(111, 427);
            this.lblTV.Name = "lblTV";
            this.lblTV.Size = new System.Drawing.Size(62, 15);
            this.lblTV.TabIndex = 320;
            this.lblTV.Text = "TV-1-2017";
            // 
            // lblHEADING
            // 
            this.lblHEADING.AutoSize = true;
            this.lblHEADING.BackColor = System.Drawing.Color.Transparent;
            this.lblHEADING.Font = new System.Drawing.Font("Berlin Sans FB", 15.75F);
            this.lblHEADING.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblHEADING.Location = new System.Drawing.Point(6, 32);
            this.lblHEADING.Name = "lblHEADING";
            this.lblHEADING.Size = new System.Drawing.Size(263, 23);
            this.lblHEADING.TabIndex = 23;
            this.lblHEADING.Text = "BANK TRANSFER VOUCHER";
            // 
            // txtNar
            // 
            this.txtNar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNar.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtNar.Location = new System.Drawing.Point(114, 559);
            this.txtNar.MaxLength = 100;
            this.txtNar.Multiline = true;
            this.txtNar.Name = "txtNar";
            this.txtNar.Size = new System.Drawing.Size(586, 56);
            this.txtNar.TabIndex = 6;
            this.txtNar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtAmount_MouseClick);
            this.txtNar.Enter += new System.EventHandler(this.txtAmount_Enter);
            this.txtNar.Leave += new System.EventHandler(this.txtChq_Leave);
            // 
            // lblNar
            // 
            this.lblNar.AutoSize = true;
            this.lblNar.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblNar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblNar.Location = new System.Drawing.Point(5, 564);
            this.lblNar.Name = "lblNar";
            this.lblNar.Size = new System.Drawing.Size(77, 15);
            this.lblNar.TabIndex = 318;
            this.lblNar.Text = "NARRATION:";
            // 
            // txtAmount
            // 
            this.txtAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAmount.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtAmount.Location = new System.Drawing.Point(469, 497);
            this.txtAmount.MaxLength = 10;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(231, 25);
            this.txtAmount.TabIndex = 3;
            this.txtAmount.Text = "0.0";
            this.txtAmount.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtAmount_MouseClick);
            this.txtAmount.Enter += new System.EventHandler(this.txtAmount_Enter);
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            this.txtAmount.Leave += new System.EventHandler(this.txtAmount_Leave);
            // 
            // lblTrFrom
            // 
            this.lblTrFrom.AutoSize = true;
            this.lblTrFrom.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblTrFrom.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTrFrom.Location = new System.Drawing.Point(5, 533);
            this.lblTrFrom.Name = "lblTrFrom";
            this.lblTrFrom.Size = new System.Drawing.Size(103, 15);
            this.lblTrFrom.TabIndex = 313;
            this.lblTrFrom.Text = "TRANSFER FROM:";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icons8-Save as Filled-100.png");
            this.imageList1.Images.SetKeyName(1, "icons8-Cancel Filled-100.png");
            this.imageList1.Images.SetKeyName(2, "icons8-search.png");
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
            this.btnCLEAR.Location = new System.Drawing.Point(583, 621);
            this.btnCLEAR.Name = "btnCLEAR";
            this.btnCLEAR.Size = new System.Drawing.Size(116, 25);
            this.btnCLEAR.TabIndex = 8;
            this.btnCLEAR.Text = "CLEAR";
            this.btnCLEAR.UseVisualStyleBackColor = false;
            this.btnCLEAR.Click += new System.EventHandler(this.btnCLEAR_Click);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblDate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDate.Location = new System.Drawing.Point(5, 471);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(39, 15);
            this.lblDate.TabIndex = 312;
            this.lblDate.Text = "DATE:";
            // 
            // lblAmt
            // 
            this.lblAmt.AutoSize = true;
            this.lblAmt.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblAmt.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblAmt.Location = new System.Drawing.Point(352, 502);
            this.lblAmt.Name = "lblAmt";
            this.lblAmt.Size = new System.Drawing.Size(62, 15);
            this.lblAmt.TabIndex = 316;
            this.lblAmt.Text = "AMOUNT:";
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
            this.btnSAVE.Location = new System.Drawing.Point(469, 621);
            this.btnSAVE.Name = "btnSAVE";
            this.btnSAVE.Size = new System.Drawing.Size(114, 25);
            this.btnSAVE.TabIndex = 7;
            this.btnSAVE.Text = "SAVE";
            this.btnSAVE.UseVisualStyleBackColor = false;
            this.btnSAVE.Click += new System.EventHandler(this.btnSAVE_Click_1);
            // 
            // lblV
            // 
            this.lblV.AutoSize = true;
            this.lblV.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblV.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblV.Location = new System.Drawing.Point(5, 427);
            this.lblV.Name = "lblV";
            this.lblV.Size = new System.Drawing.Size(74, 15);
            this.lblV.TabIndex = 311;
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
            this.grdSEARCH.Location = new System.Drawing.Point(-2, 133);
            this.grdSEARCH.Name = "grdSEARCH";
            this.grdSEARCH.ReadOnly = true;
            this.grdSEARCH.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSEARCH.Size = new System.Drawing.Size(710, 279);
            this.grdSEARCH.TabIndex = 310;
            this.grdSEARCH.TabStop = false;
            this.grdSEARCH.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdSEARCH_CellClick);
            this.grdSEARCH.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdSEARCH_CellContentClick);
            this.grdSEARCH.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.grdSEARCH_DataBindingComplete);
            // 
            // txtSEARCH
            // 
            this.txtSEARCH.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSEARCH.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSEARCH.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtSEARCH.Location = new System.Drawing.Point(71, 102);
            this.txtSEARCH.Name = "txtSEARCH";
            this.txtSEARCH.Size = new System.Drawing.Size(630, 25);
            this.txtSEARCH.TabIndex = 309;
            this.txtSEARCH.TextChanged += new System.EventHandler(this.txtSEARCH_TextChanged);
            // 
            // lblSEARCH
            // 
            this.lblSEARCH.AutoSize = true;
            this.lblSEARCH.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSEARCH.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSEARCH.Location = new System.Drawing.Point(8, 106);
            this.lblSEARCH.Name = "lblSEARCH";
            this.lblSEARCH.Size = new System.Drawing.Size(57, 17);
            this.lblSEARCH.TabIndex = 308;
            this.lblSEARCH.Text = "SEARCH";
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
            this.pnlHEADER.Size = new System.Drawing.Size(706, 88);
            this.pnlHEADER.TabIndex = 307;
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
            this.btn_VIEW_VOUCHER.Location = new System.Drawing.Point(114, 621);
            this.btn_VIEW_VOUCHER.Name = "btn_VIEW_VOUCHER";
            this.btn_VIEW_VOUCHER.Size = new System.Drawing.Size(231, 25);
            this.btn_VIEW_VOUCHER.TabIndex = 9;
            this.btn_VIEW_VOUCHER.Text = "VIEW VOUCHER";
            this.btn_VIEW_VOUCHER.UseVisualStyleBackColor = false;
            this.btn_VIEW_VOUCHER.Click += new System.EventHandler(this.btn_VIEW_VOUCHER_Click);
            // 
            // frm_BankTr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(706, 652);
            this.Controls.Add(this.btn_VIEW_VOUCHER);
            this.Controls.Add(this.dtChq);
            this.Controls.Add(this.lblChqDt);
            this.Controls.Add(this.cmbTrTo);
            this.Controls.Add(this.lblTrTo);
            this.Controls.Add(this.txtChq);
            this.Controls.Add(this.lblCHQ);
            this.Controls.Add(this.cmbTRFrom);
            this.Controls.Add(this.lblTrNo);
            this.Controls.Add(this.lblTr);
            this.Controls.Add(this.dtp_DATE);
            this.Controls.Add(this.lblTV);
            this.Controls.Add(this.txtNar);
            this.Controls.Add(this.lblNar);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.lblTrFrom);
            this.Controls.Add(this.btnCLEAR);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblAmt);
            this.Controls.Add(this.btnSAVE);
            this.Controls.Add(this.lblV);
            this.Controls.Add(this.grdSEARCH);
            this.Controls.Add(this.txtSEARCH);
            this.Controls.Add(this.lblSEARCH);
            this.Controls.Add(this.pnlHEADER);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_BankTr";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BANK TRANSFER VOUCHER";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_BankTr_FormClosed);
            this.Load += new System.EventHandler(this.frm_BankTr_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSEARCH)).EndInit();
            this.pnlHEADER.ResumeLayout(false);
            this.pnlHEADER.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtChq;
        private System.Windows.Forms.Label lblChqDt;
        private SergeUtils.EasyCompletionComboBox cmbTrTo;
        private System.Windows.Forms.Label lblTrTo;
        private System.Windows.Forms.TextBox txtChq;
        private System.Windows.Forms.Label lblCHQ;
        private System.Windows.Forms.PictureBox pictureBox15;
        private SergeUtils.EasyCompletionComboBox cmbTRFrom;
        private System.Windows.Forms.Label lblTrNo;
        private System.Windows.Forms.Label lblTr;
        private System.Windows.Forms.DateTimePicker dtp_DATE;
        private System.Windows.Forms.Label lblTV;
        private System.Windows.Forms.Label lblHEADING;
        private System.Windows.Forms.TextBox txtNar;
        private System.Windows.Forms.Label lblNar;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label lblTrFrom;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnCLEAR;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblAmt;
        private System.Windows.Forms.Button btnSAVE;
        private System.Windows.Forms.Label lblV;
        private System.Windows.Forms.DataGridView grdSEARCH;
        private System.Windows.Forms.TextBox txtSEARCH;
        private System.Windows.Forms.Label lblSEARCH;
        private System.Windows.Forms.Panel pnlHEADER;
        private System.Windows.Forms.Button btn_VIEW_VOUCHER;

    }
}