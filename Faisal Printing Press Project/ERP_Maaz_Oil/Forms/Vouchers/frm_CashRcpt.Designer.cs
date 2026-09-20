namespace ERP_Maaz_Oil.Forms
{
    partial class frm_CashRcpt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_CashRcpt));
            this.grdSEARCH = new System.Windows.Forms.DataGridView();
            this.txtSEARCH = new System.Windows.Forms.TextBox();
            this.lblSEARCH = new System.Windows.Forms.Label();
            this.txtNar = new System.Windows.Forms.TextBox();
            this.lblAcc = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lblAmt = new System.Windows.Forms.Label();
            this.lblRc = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblV = new System.Windows.Forms.Label();
            this.lblCRV = new System.Windows.Forms.Label();
            this.dtp_DATE = new System.Windows.Forms.DateTimePicker();
            this.lblTr = new System.Windows.Forms.Label();
            this.lblTrNo = new System.Windows.Forms.Label();
            this.cmbRc = new SergeUtils.EasyCompletionComboBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lblReceive = new System.Windows.Forms.Label();
            this.txtReceive = new System.Windows.Forms.TextBox();
            this.btnCLEAR = new System.Windows.Forms.Button();
            this.btnSAVE = new System.Windows.Forms.Button();
            this.pnlHEADER = new System.Windows.Forms.Panel();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.lblHEADING = new System.Windows.Forms.Label();
            this.btn_VIEW_VOUCHER = new System.Windows.Forms.Button();
            this.rdbOTHERS = new System.Windows.Forms.RadioButton();
            this.rdbINV_REC = new System.Windows.Forms.RadioButton();
            this.cmbSELECT_INV = new SergeUtils.EasyCompletionComboBox();
            this.lbl_SELECT_INV = new System.Windows.Forms.Label();
            this.cmbCASH_AC = new SergeUtils.EasyCompletionComboBox();
            this.lblCASH_AC = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdbPETTY_CASH = new System.Windows.Forms.RadioButton();
            this.rdbCASH = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdSEARCH)).BeginInit();
            this.pnlHEADER.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.grdSEARCH.Location = new System.Drawing.Point(-4, 125);
            this.grdSEARCH.Name = "grdSEARCH";
            this.grdSEARCH.ReadOnly = true;
            this.grdSEARCH.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSEARCH.Size = new System.Drawing.Size(710, 279);
            this.grdSEARCH.TabIndex = 224;
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
            this.txtSEARCH.Location = new System.Drawing.Point(69, 94);
            this.txtSEARCH.Name = "txtSEARCH";
            this.txtSEARCH.Size = new System.Drawing.Size(451, 25);
            this.txtSEARCH.TabIndex = 223;
            this.txtSEARCH.TextChanged += new System.EventHandler(this.txtSEARCH_TextChanged);
            // 
            // lblSEARCH
            // 
            this.lblSEARCH.AutoSize = true;
            this.lblSEARCH.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSEARCH.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSEARCH.Location = new System.Drawing.Point(6, 98);
            this.lblSEARCH.Name = "lblSEARCH";
            this.lblSEARCH.Size = new System.Drawing.Size(57, 17);
            this.lblSEARCH.TabIndex = 222;
            this.lblSEARCH.Text = "SEARCH";
            // 
            // txtNar
            // 
            this.txtNar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNar.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtNar.Location = new System.Drawing.Point(109, 499);
            this.txtNar.MaxLength = 100;
            this.txtNar.Multiline = true;
            this.txtNar.Name = "txtNar";
            this.txtNar.Size = new System.Drawing.Size(231, 87);
            this.txtNar.TabIndex = 2;
            this.txtNar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtAmount_MouseClick);
            this.txtNar.Enter += new System.EventHandler(this.txtAmount_Enter);
            this.txtNar.Leave += new System.EventHandler(this.txtNar_Leave);
            // 
            // lblAcc
            // 
            this.lblAcc.AutoSize = true;
            this.lblAcc.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblAcc.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblAcc.Location = new System.Drawing.Point(3, 504);
            this.lblAcc.Name = "lblAcc";
            this.lblAcc.Size = new System.Drawing.Size(104, 15);
            this.lblAcc.TabIndex = 242;
            this.lblAcc.Text = "ON ACCOUNT OF:";
            // 
            // txtAmount
            // 
            this.txtAmount.BackColor = System.Drawing.SystemColors.Window;
            this.txtAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAmount.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtAmount.Location = new System.Drawing.Point(468, 530);
            this.txtAmount.MaxLength = 10;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(231, 25);
            this.txtAmount.TabIndex = 4;
            this.txtAmount.Text = "0.0";
            this.txtAmount.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtAmount_MouseClick);
            this.txtAmount.Enter += new System.EventHandler(this.txtAmount_Enter);
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            this.txtAmount.Leave += new System.EventHandler(this.txtAmount_Leave);
            // 
            // lblAmt
            // 
            this.lblAmt.AutoSize = true;
            this.lblAmt.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblAmt.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblAmt.Location = new System.Drawing.Point(350, 535);
            this.lblAmt.Name = "lblAmt";
            this.lblAmt.Size = new System.Drawing.Size(62, 15);
            this.lblAmt.TabIndex = 240;
            this.lblAmt.Text = "AMOUNT:";
            // 
            // lblRc
            // 
            this.lblRc.AutoSize = true;
            this.lblRc.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblRc.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblRc.Location = new System.Drawing.Point(350, 419);
            this.lblRc.Name = "lblRc";
            this.lblRc.Size = new System.Drawing.Size(112, 15);
            this.lblRc.TabIndex = 236;
            this.lblRc.Text = "RECEIPT ACCOUNT:";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblDate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDate.Location = new System.Drawing.Point(3, 473);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(39, 15);
            this.lblDate.TabIndex = 235;
            this.lblDate.Text = "DATE:";
            // 
            // lblV
            // 
            this.lblV.AutoSize = true;
            this.lblV.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblV.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblV.Location = new System.Drawing.Point(3, 419);
            this.lblV.Name = "lblV";
            this.lblV.Size = new System.Drawing.Size(74, 15);
            this.lblV.TabIndex = 233;
            this.lblV.Text = "VOUCHER #:";
            // 
            // lblCRV
            // 
            this.lblCRV.AutoSize = true;
            this.lblCRV.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblCRV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(215)))));
            this.lblCRV.Location = new System.Drawing.Point(109, 419);
            this.lblCRV.Name = "lblCRV";
            this.lblCRV.Size = new System.Drawing.Size(69, 15);
            this.lblCRV.TabIndex = 248;
            this.lblCRV.Text = "CRV-1-2017";
            // 
            // dtp_DATE
            // 
            this.dtp_DATE.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.dtp_DATE.Location = new System.Drawing.Point(109, 469);
            this.dtp_DATE.Name = "dtp_DATE";
            this.dtp_DATE.Size = new System.Drawing.Size(231, 23);
            this.dtp_DATE.TabIndex = 0;
            // 
            // lblTr
            // 
            this.lblTr.AutoSize = true;
            this.lblTr.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblTr.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTr.Location = new System.Drawing.Point(3, 448);
            this.lblTr.Name = "lblTr";
            this.lblTr.Size = new System.Drawing.Size(102, 15);
            this.lblTr.TabIndex = 250;
            this.lblTr.Text = "TRANSACTION #:";
            // 
            // lblTrNo
            // 
            this.lblTrNo.AutoSize = true;
            this.lblTrNo.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblTrNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(24)))), ((int)(((byte)(38)))));
            this.lblTrNo.Location = new System.Drawing.Point(109, 448);
            this.lblTrNo.Name = "lblTrNo";
            this.lblTrNo.Size = new System.Drawing.Size(73, 15);
            this.lblTrNo.TabIndex = 251;
            this.lblTrNo.Text = "1221023332";
            // 
            // cmbRc
            // 
            this.cmbRc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbRc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRc.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbRc.FormattingEnabled = true;
            this.cmbRc.Location = new System.Drawing.Point(468, 414);
            this.cmbRc.Name = "cmbRc";
            this.cmbRc.Size = new System.Drawing.Size(231, 25);
            this.cmbRc.TabIndex = 3;
            this.cmbRc.DropDown += new System.EventHandler(this.cmbRc_DropDown);
            this.cmbRc.TextUpdate += new System.EventHandler(this.cmbRc_TextUpdate);
            this.cmbRc.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmbRc_PreviewKeyDown);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icons8-Save as Filled-100.png");
            this.imageList1.Images.SetKeyName(1, "icons8-Cancel Filled-100.png");
            this.imageList1.Images.SetKeyName(2, "icons8-search.png");
            // 
            // lblReceive
            // 
            this.lblReceive.AutoSize = true;
            this.lblReceive.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblReceive.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblReceive.Location = new System.Drawing.Point(350, 504);
            this.lblReceive.Name = "lblReceive";
            this.lblReceive.Size = new System.Drawing.Size(99, 15);
            this.lblReceive.TabIndex = 253;
            this.lblReceive.Text = "RECEIVED FROM:";
            // 
            // txtReceive
            // 
            this.txtReceive.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtReceive.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtReceive.Location = new System.Drawing.Point(468, 499);
            this.txtReceive.MaxLength = 50;
            this.txtReceive.Name = "txtReceive";
            this.txtReceive.Size = new System.Drawing.Size(231, 25);
            this.txtReceive.TabIndex = 1;
            this.txtReceive.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtAmount_MouseClick);
            this.txtReceive.Enter += new System.EventHandler(this.txtAmount_Enter);
            this.txtReceive.Leave += new System.EventHandler(this.txtNar_Leave);
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
            this.btnCLEAR.Location = new System.Drawing.Point(583, 592);
            this.btnCLEAR.Name = "btnCLEAR";
            this.btnCLEAR.Size = new System.Drawing.Size(116, 25);
            this.btnCLEAR.TabIndex = 7;
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
            this.btnSAVE.Location = new System.Drawing.Point(468, 592);
            this.btnSAVE.Name = "btnSAVE";
            this.btnSAVE.Size = new System.Drawing.Size(115, 25);
            this.btnSAVE.TabIndex = 6;
            this.btnSAVE.Text = "SAVE";
            this.btnSAVE.UseVisualStyleBackColor = false;
            this.btnSAVE.Click += new System.EventHandler(this.btnSAVE_Click);
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
            this.pnlHEADER.TabIndex = 37;
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
            // lblHEADING
            // 
            this.lblHEADING.AutoSize = true;
            this.lblHEADING.BackColor = System.Drawing.Color.Transparent;
            this.lblHEADING.Font = new System.Drawing.Font("Berlin Sans FB", 15.75F);
            this.lblHEADING.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblHEADING.Location = new System.Drawing.Point(6, 32);
            this.lblHEADING.Name = "lblHEADING";
            this.lblHEADING.Size = new System.Drawing.Size(237, 23);
            this.lblHEADING.TabIndex = 23;
            this.lblHEADING.Text = "CASH RECEIPT VOUCHER";
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
            this.btn_VIEW_VOUCHER.Location = new System.Drawing.Point(109, 592);
            this.btn_VIEW_VOUCHER.Name = "btn_VIEW_VOUCHER";
            this.btn_VIEW_VOUCHER.Size = new System.Drawing.Size(231, 25);
            this.btn_VIEW_VOUCHER.TabIndex = 7;
            this.btn_VIEW_VOUCHER.Text = "VIEW VOUCHER";
            this.btn_VIEW_VOUCHER.UseVisualStyleBackColor = false;
            this.btn_VIEW_VOUCHER.Click += new System.EventHandler(this.btn_VIEW_VOUCHER_Click);
            // 
            // rdbOTHERS
            // 
            this.rdbOTHERS.AutoSize = true;
            this.rdbOTHERS.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.rdbOTHERS.Location = new System.Drawing.Point(632, 445);
            this.rdbOTHERS.Name = "rdbOTHERS";
            this.rdbOTHERS.Size = new System.Drawing.Size(67, 21);
            this.rdbOTHERS.TabIndex = 255;
            this.rdbOTHERS.Text = "OTHER";
            this.rdbOTHERS.UseVisualStyleBackColor = true;
            this.rdbOTHERS.CheckedChanged += new System.EventHandler(this.rdbOTHERS_CheckedChanged);
            // 
            // rdbINV_REC
            // 
            this.rdbINV_REC.AutoSize = true;
            this.rdbINV_REC.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.rdbINV_REC.Location = new System.Drawing.Point(468, 445);
            this.rdbINV_REC.Name = "rdbINV_REC";
            this.rdbINV_REC.Size = new System.Drawing.Size(113, 21);
            this.rdbINV_REC.TabIndex = 254;
            this.rdbINV_REC.TabStop = true;
            this.rdbINV_REC.Text = "INVOICE / REC";
            this.rdbINV_REC.UseVisualStyleBackColor = true;
            this.rdbINV_REC.CheckedChanged += new System.EventHandler(this.rdbINV_REC_CheckedChanged);
            // 
            // cmbSELECT_INV
            // 
            this.cmbSELECT_INV.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSELECT_INV.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSELECT_INV.Enabled = false;
            this.cmbSELECT_INV.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbSELECT_INV.FormattingEnabled = true;
            this.cmbSELECT_INV.Location = new System.Drawing.Point(468, 468);
            this.cmbSELECT_INV.Name = "cmbSELECT_INV";
            this.cmbSELECT_INV.Size = new System.Drawing.Size(231, 25);
            this.cmbSELECT_INV.TabIndex = 256;
            this.cmbSELECT_INV.DropDown += new System.EventHandler(this.cmbSELECT_INV_DropDown);
            this.cmbSELECT_INV.TextUpdate += new System.EventHandler(this.cmbSELECT_INV_TextUpdate);
            this.cmbSELECT_INV.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmbSELECT_INV_PreviewKeyDown);
            // 
            // lbl_SELECT_INV
            // 
            this.lbl_SELECT_INV.AutoSize = true;
            this.lbl_SELECT_INV.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lbl_SELECT_INV.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_SELECT_INV.Location = new System.Drawing.Point(350, 473);
            this.lbl_SELECT_INV.Name = "lbl_SELECT_INV";
            this.lbl_SELECT_INV.Size = new System.Drawing.Size(99, 15);
            this.lbl_SELECT_INV.TabIndex = 257;
            this.lbl_SELECT_INV.Text = "SELECT INVOICE:";
            // 
            // cmbCASH_AC
            // 
            this.cmbCASH_AC.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCASH_AC.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCASH_AC.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbCASH_AC.FormattingEnabled = true;
            this.cmbCASH_AC.Location = new System.Drawing.Point(468, 561);
            this.cmbCASH_AC.Name = "cmbCASH_AC";
            this.cmbCASH_AC.Size = new System.Drawing.Size(231, 25);
            this.cmbCASH_AC.TabIndex = 5;
            this.cmbCASH_AC.DropDown += new System.EventHandler(this.cmbCASH_AC_DropDown);
            this.cmbCASH_AC.TextUpdate += new System.EventHandler(this.cmbCASH_AC_TextUpdate);
            this.cmbCASH_AC.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmbCASH_AC_PreviewKeyDown);
            // 
            // lblCASH_AC
            // 
            this.lblCASH_AC.AutoSize = true;
            this.lblCASH_AC.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblCASH_AC.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCASH_AC.Location = new System.Drawing.Point(350, 566);
            this.lblCASH_AC.Name = "lblCASH_AC";
            this.lblCASH_AC.Size = new System.Drawing.Size(99, 15);
            this.lblCASH_AC.TabIndex = 281;
            this.lblCASH_AC.Text = "CASH ACCOUNT:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdbPETTY_CASH);
            this.panel1.Controls.Add(this.rdbCASH);
            this.panel1.Location = new System.Drawing.Point(522, 94);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(177, 25);
            this.panel1.TabIndex = 282;
            // 
            // rdbPETTY_CASH
            // 
            this.rdbPETTY_CASH.AutoSize = true;
            this.rdbPETTY_CASH.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.rdbPETTY_CASH.Location = new System.Drawing.Point(70, 2);
            this.rdbPETTY_CASH.Name = "rdbPETTY_CASH";
            this.rdbPETTY_CASH.Size = new System.Drawing.Size(101, 21);
            this.rdbPETTY_CASH.TabIndex = 281;
            this.rdbPETTY_CASH.Text = "PETTY CASH";
            this.rdbPETTY_CASH.UseVisualStyleBackColor = true;
            this.rdbPETTY_CASH.CheckedChanged += new System.EventHandler(this.rdbPETTY_CASH_CheckedChanged);
            // 
            // rdbCASH
            // 
            this.rdbCASH.AutoSize = true;
            this.rdbCASH.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.rdbCASH.Location = new System.Drawing.Point(4, 2);
            this.rdbCASH.Name = "rdbCASH";
            this.rdbCASH.Size = new System.Drawing.Size(60, 21);
            this.rdbCASH.TabIndex = 280;
            this.rdbCASH.TabStop = true;
            this.rdbCASH.Text = "CASH";
            this.rdbCASH.UseVisualStyleBackColor = true;
            this.rdbCASH.CheckedChanged += new System.EventHandler(this.rdbCASH_CheckedChanged);
            // 
            // frm_CashRcpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(706, 653);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmbCASH_AC);
            this.Controls.Add(this.lblCASH_AC);
            this.Controls.Add(this.cmbSELECT_INV);
            this.Controls.Add(this.lbl_SELECT_INV);
            this.Controls.Add(this.rdbOTHERS);
            this.Controls.Add(this.rdbINV_REC);
            this.Controls.Add(this.btn_VIEW_VOUCHER);
            this.Controls.Add(this.txtReceive);
            this.Controls.Add(this.lblReceive);
            this.Controls.Add(this.cmbRc);
            this.Controls.Add(this.lblTrNo);
            this.Controls.Add(this.lblTr);
            this.Controls.Add(this.dtp_DATE);
            this.Controls.Add(this.lblCRV);
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
            this.Name = "frm_CashRcpt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CASH RECEIPT VOUCHER";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_CashRcpt_FormClosed);
            this.Load += new System.EventHandler(this.frm_CashRcpt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdSEARCH)).EndInit();
            this.pnlHEADER.ResumeLayout(false);
            this.pnlHEADER.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.TextBox txtNar;
        private System.Windows.Forms.Label lblAcc;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label lblAmt;
        private System.Windows.Forms.Button btnCLEAR;
        private System.Windows.Forms.Button btnSAVE;
        private System.Windows.Forms.Label lblRc;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblV;
        private System.Windows.Forms.Label lblCRV;
        private System.Windows.Forms.DateTimePicker dtp_DATE;
        private System.Windows.Forms.Label lblTr;
        private System.Windows.Forms.Label lblTrNo;
        private SergeUtils.EasyCompletionComboBox cmbRc;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lblReceive;
        private System.Windows.Forms.TextBox txtReceive;
        private System.Windows.Forms.Button btn_VIEW_VOUCHER;
        private System.Windows.Forms.RadioButton rdbOTHERS;
        private System.Windows.Forms.RadioButton rdbINV_REC;
        private SergeUtils.EasyCompletionComboBox cmbSELECT_INV;
        private System.Windows.Forms.Label lbl_SELECT_INV;
        private SergeUtils.EasyCompletionComboBox cmbCASH_AC;
        private System.Windows.Forms.Label lblCASH_AC;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdbPETTY_CASH;
        private System.Windows.Forms.RadioButton rdbCASH;
    }
}