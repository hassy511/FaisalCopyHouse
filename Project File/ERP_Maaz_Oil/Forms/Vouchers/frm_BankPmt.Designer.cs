namespace ERP_Maaz_Oil.Forms
{
    partial class frm_BankPmt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_BankPmt));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtChq = new System.Windows.Forms.DateTimePicker();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lblChqDt = new System.Windows.Forms.Label();
            this.cmbBank = new SergeUtils.EasyCompletionComboBox();
            this.lblBank = new System.Windows.Forms.Label();
            this.txtChq = new System.Windows.Forms.TextBox();
            this.lblCHQ = new System.Windows.Forms.Label();
            this.txtPay = new System.Windows.Forms.TextBox();
            this.lblPay = new System.Windows.Forms.Label();
            this.cmbPay = new SergeUtils.EasyCompletionComboBox();
            this.lblTrNo = new System.Windows.Forms.Label();
            this.lblTr = new System.Windows.Forms.Label();
            this.dtp_DATE = new System.Windows.Forms.DateTimePicker();
            this.lblBPV = new System.Windows.Forms.Label();
            this.txtNar = new System.Windows.Forms.TextBox();
            this.lblAcc = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lblPaid = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblAmt = new System.Windows.Forms.Label();
            this.lblV = new System.Windows.Forms.Label();
            this.grdSEARCH = new System.Windows.Forms.DataGridView();
            this.txtSEARCH = new System.Windows.Forms.TextBox();
            this.lblSEARCH = new System.Windows.Forms.Label();
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtBankBalance = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdSEARCH)).BeginInit();
            this.pnlHEADER.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            this.SuspendLayout();
            // 
            // dtChq
            // 
            this.dtChq.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.dtChq.Location = new System.Drawing.Point(627, 457);
            this.dtChq.Margin = new System.Windows.Forms.Padding(4);
            this.dtChq.Name = "dtChq";
            this.dtChq.Size = new System.Drawing.Size(307, 27);
            this.dtChq.TabIndex = 4;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icons8-Save as Filled-100.png");
            this.imageList1.Images.SetKeyName(1, "icons8-Cancel Filled-100.png");
            this.imageList1.Images.SetKeyName(2, "icons8-search.png");
            // 
            // lblChqDt
            // 
            this.lblChqDt.AutoSize = true;
            this.lblChqDt.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblChqDt.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblChqDt.Location = new System.Drawing.Point(473, 461);
            this.lblChqDt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblChqDt.Name = "lblChqDt";
            this.lblChqDt.Size = new System.Drawing.Size(111, 20);
            this.lblChqDt.TabIndex = 305;
            this.lblChqDt.Text = "CHEQUE DATE:";
            // 
            // cmbBank
            // 
            this.cmbBank.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbBank.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBank.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbBank.FormattingEnabled = true;
            this.cmbBank.Location = new System.Drawing.Point(148, 526);
            this.cmbBank.Margin = new System.Windows.Forms.Padding(4);
            this.cmbBank.Name = "cmbBank";
            this.cmbBank.Size = new System.Drawing.Size(269, 29);
            this.cmbBank.TabIndex = 8;
            this.cmbBank.DropDown += new System.EventHandler(this.cmbBank_DropDown);
            this.cmbBank.SelectedIndexChanged += new System.EventHandler(this.cmbBank_SelectedIndexChanged);
            this.cmbBank.TextUpdate += new System.EventHandler(this.cmbPay_TextUpdate);
            this.cmbBank.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmbBank_PreviewKeyDown);
            // 
            // lblBank
            // 
            this.lblBank.AutoSize = true;
            this.lblBank.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblBank.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblBank.Location = new System.Drawing.Point(7, 532);
            this.lblBank.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBank.Name = "lblBank";
            this.lblBank.Size = new System.Drawing.Size(127, 20);
            this.lblBank.TabIndex = 303;
            this.lblBank.Text = "BANK ACCOUNT:";
            // 
            // txtChq
            // 
            this.txtChq.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtChq.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtChq.Location = new System.Drawing.Point(627, 420);
            this.txtChq.Margin = new System.Windows.Forms.Padding(4);
            this.txtChq.MaxLength = 50;
            this.txtChq.Name = "txtChq";
            this.txtChq.Size = new System.Drawing.Size(307, 29);
            this.txtChq.TabIndex = 3;
            this.txtChq.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtAmount_MouseClick);
            this.txtChq.Enter += new System.EventHandler(this.txtAmount_Enter);
            this.txtChq.Leave += new System.EventHandler(this.txtPay_Leave);
            // 
            // lblCHQ
            // 
            this.lblCHQ.AutoSize = true;
            this.lblCHQ.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblCHQ.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCHQ.Location = new System.Drawing.Point(473, 424);
            this.lblCHQ.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCHQ.Name = "lblCHQ";
            this.lblCHQ.Size = new System.Drawing.Size(84, 20);
            this.lblCHQ.TabIndex = 301;
            this.lblCHQ.Text = "CHEQUE #:";
            // 
            // txtPay
            // 
            this.txtPay.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPay.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtPay.Location = new System.Drawing.Point(148, 601);
            this.txtPay.Margin = new System.Windows.Forms.Padding(4);
            this.txtPay.MaxLength = 50;
            this.txtPay.Name = "txtPay";
            this.txtPay.Size = new System.Drawing.Size(269, 29);
            this.txtPay.TabIndex = 5;
            this.txtPay.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtAmount_MouseClick);
            this.txtPay.Enter += new System.EventHandler(this.txtAmount_Enter);
            this.txtPay.Leave += new System.EventHandler(this.txtPay_Leave);
            // 
            // lblPay
            // 
            this.lblPay.AutoSize = true;
            this.lblPay.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblPay.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPay.Location = new System.Drawing.Point(11, 603);
            this.lblPay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPay.Name = "lblPay";
            this.lblPay.Size = new System.Drawing.Size(68, 20);
            this.lblPay.TabIndex = 299;
            this.lblPay.Text = "PAID TO:";
            // 
            // cmbPay
            // 
            this.cmbPay.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbPay.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPay.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbPay.FormattingEnabled = true;
            this.cmbPay.Location = new System.Drawing.Point(148, 563);
            this.cmbPay.Margin = new System.Windows.Forms.Padding(4);
            this.cmbPay.Name = "cmbPay";
            this.cmbPay.Size = new System.Drawing.Size(269, 29);
            this.cmbPay.TabIndex = 6;
            this.cmbPay.DropDown += new System.EventHandler(this.cmbPay_DropDown);
            this.cmbPay.TextUpdate += new System.EventHandler(this.cmbPay_TextUpdate);
            this.cmbPay.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmbPay_PreviewKeyDown);
            // 
            // lblTrNo
            // 
            this.lblTrNo.AutoSize = true;
            this.lblTrNo.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblTrNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(24)))), ((int)(((byte)(38)))));
            this.lblTrNo.Location = new System.Drawing.Point(148, 461);
            this.lblTrNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTrNo.Name = "lblTrNo";
            this.lblTrNo.Size = new System.Drawing.Size(85, 20);
            this.lblTrNo.TabIndex = 297;
            this.lblTrNo.Text = "1221023332";
            // 
            // lblTr
            // 
            this.lblTr.AutoSize = true;
            this.lblTr.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblTr.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTr.Location = new System.Drawing.Point(7, 461);
            this.lblTr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTr.Name = "lblTr";
            this.lblTr.Size = new System.Drawing.Size(127, 20);
            this.lblTr.TabIndex = 296;
            this.lblTr.Text = "TRANSACTION #:";
            // 
            // dtp_DATE
            // 
            this.dtp_DATE.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.dtp_DATE.Location = new System.Drawing.Point(148, 492);
            this.dtp_DATE.Margin = new System.Windows.Forms.Padding(4);
            this.dtp_DATE.Name = "dtp_DATE";
            this.dtp_DATE.Size = new System.Drawing.Size(269, 27);
            this.dtp_DATE.TabIndex = 0;
            // 
            // lblBPV
            // 
            this.lblBPV.AutoSize = true;
            this.lblBPV.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblBPV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(215)))));
            this.lblBPV.Location = new System.Drawing.Point(148, 425);
            this.lblBPV.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBPV.Name = "lblBPV";
            this.lblBPV.Size = new System.Drawing.Size(85, 20);
            this.lblBPV.TabIndex = 294;
            this.lblBPV.Text = "BPV-1-2017";
            // 
            // txtNar
            // 
            this.txtNar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNar.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtNar.Location = new System.Drawing.Point(627, 570);
            this.txtNar.Margin = new System.Windows.Forms.Padding(4);
            this.txtNar.MaxLength = 100;
            this.txtNar.Multiline = true;
            this.txtNar.Name = "txtNar";
            this.txtNar.Size = new System.Drawing.Size(307, 94);
            this.txtNar.TabIndex = 2;
            this.txtNar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtAmount_MouseClick);
            this.txtNar.Enter += new System.EventHandler(this.txtAmount_Enter);
            this.txtNar.Leave += new System.EventHandler(this.txtPay_Leave);
            // 
            // lblAcc
            // 
            this.lblAcc.AutoSize = true;
            this.lblAcc.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblAcc.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblAcc.Location = new System.Drawing.Point(473, 574);
            this.lblAcc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAcc.Name = "lblAcc";
            this.lblAcc.Size = new System.Drawing.Size(97, 20);
            this.lblAcc.TabIndex = 292;
            this.lblAcc.Text = "NARRATION:";
            // 
            // txtAmount
            // 
            this.txtAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAmount.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtAmount.Location = new System.Drawing.Point(627, 496);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(4);
            this.txtAmount.MaxLength = 10;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(307, 29);
            this.txtAmount.TabIndex = 7;
            this.txtAmount.Text = "0.0";
            this.txtAmount.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtAmount_MouseClick);
            this.txtAmount.TextChanged += new System.EventHandler(this.txtAmount_TextChanged);
            this.txtAmount.Enter += new System.EventHandler(this.txtAmount_Enter);
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            this.txtAmount.Leave += new System.EventHandler(this.txtAmount_Leave);
            // 
            // lblPaid
            // 
            this.lblPaid.AutoSize = true;
            this.lblPaid.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblPaid.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPaid.Location = new System.Drawing.Point(11, 567);
            this.lblPaid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPaid.Name = "lblPaid";
            this.lblPaid.Size = new System.Drawing.Size(127, 20);
            this.lblPaid.TabIndex = 287;
            this.lblPaid.Text = "DEBIT ACCOUNT:";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblDate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDate.Location = new System.Drawing.Point(7, 496);
            this.lblDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(49, 20);
            this.lblDate.TabIndex = 286;
            this.lblDate.Text = "DATE:";
            // 
            // lblAmt
            // 
            this.lblAmt.AutoSize = true;
            this.lblAmt.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblAmt.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblAmt.Location = new System.Drawing.Point(472, 497);
            this.lblAmt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAmt.Name = "lblAmt";
            this.lblAmt.Size = new System.Drawing.Size(79, 20);
            this.lblAmt.TabIndex = 290;
            this.lblAmt.Text = "AMOUNT:";
            // 
            // lblV
            // 
            this.lblV.AutoSize = true;
            this.lblV.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblV.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblV.Location = new System.Drawing.Point(7, 425);
            this.lblV.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblV.Name = "lblV";
            this.lblV.Size = new System.Drawing.Size(95, 20);
            this.lblV.TabIndex = 285;
            this.lblV.Text = "VOUCHER #:";
            // 
            // grdSEARCH
            // 
            this.grdSEARCH.AllowUserToAddRows = false;
            this.grdSEARCH.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.grdSEARCH.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.grdSEARCH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdSEARCH.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grdSEARCH.BackgroundColor = System.Drawing.Color.White;
            this.grdSEARCH.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Semibold", 10.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdSEARCH.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.grdSEARCH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSEARCH.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdSEARCH.DefaultCellStyle = dataGridViewCellStyle6;
            this.grdSEARCH.Location = new System.Drawing.Point(-3, 161);
            this.grdSEARCH.Margin = new System.Windows.Forms.Padding(4);
            this.grdSEARCH.Name = "grdSEARCH";
            this.grdSEARCH.ReadOnly = true;
            this.grdSEARCH.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSEARCH.Size = new System.Drawing.Size(937, 251);
            this.grdSEARCH.TabIndex = 284;
            this.grdSEARCH.TabStop = false;
            this.grdSEARCH.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdSEARCH_CellClick);
            this.grdSEARCH.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.grdSEARCH_DataBindingComplete);
            // 
            // txtSEARCH
            // 
            this.txtSEARCH.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSEARCH.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtSEARCH.Location = new System.Drawing.Point(95, 123);
            this.txtSEARCH.Margin = new System.Windows.Forms.Padding(4);
            this.txtSEARCH.Name = "txtSEARCH";
            this.txtSEARCH.Size = new System.Drawing.Size(530, 29);
            this.txtSEARCH.TabIndex = 283;
            this.txtSEARCH.TextChanged += new System.EventHandler(this.txtSEARCH_TextChanged);
            // 
            // lblSEARCH
            // 
            this.lblSEARCH.AutoSize = true;
            this.lblSEARCH.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSEARCH.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSEARCH.Location = new System.Drawing.Point(11, 128);
            this.lblSEARCH.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSEARCH.Name = "lblSEARCH";
            this.lblSEARCH.Size = new System.Drawing.Size(74, 23);
            this.lblSEARCH.TabIndex = 282;
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
            this.btnCLEAR.Location = new System.Drawing.Point(779, 679);
            this.btnCLEAR.Margin = new System.Windows.Forms.Padding(4);
            this.btnCLEAR.Name = "btnCLEAR";
            this.btnCLEAR.Size = new System.Drawing.Size(156, 31);
            this.btnCLEAR.TabIndex = 11;
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
            this.btnSAVE.Location = new System.Drawing.Point(627, 679);
            this.btnSAVE.Margin = new System.Windows.Forms.Padding(4);
            this.btnSAVE.Name = "btnSAVE";
            this.btnSAVE.Size = new System.Drawing.Size(152, 31);
            this.btnSAVE.TabIndex = 10;
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
            this.pnlHEADER.Size = new System.Drawing.Size(948, 108);
            this.pnlHEADER.TabIndex = 281;
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
            this.lblHEADING.Size = new System.Drawing.Size(338, 30);
            this.lblHEADING.TabIndex = 23;
            this.lblHEADING.Text = "BANK PAYMENT VOUCHER";
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
            this.btn_VIEW_VOUCHER.Location = new System.Drawing.Point(148, 674);
            this.btn_VIEW_VOUCHER.Margin = new System.Windows.Forms.Padding(4);
            this.btn_VIEW_VOUCHER.Name = "btn_VIEW_VOUCHER";
            this.btn_VIEW_VOUCHER.Size = new System.Drawing.Size(269, 31);
            this.btn_VIEW_VOUCHER.TabIndex = 9;
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
            this.cmbSELECT_INV.Location = new System.Drawing.Point(891, 685);
            this.cmbSELECT_INV.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSELECT_INV.Name = "cmbSELECT_INV";
            this.cmbSELECT_INV.Size = new System.Drawing.Size(307, 29);
            this.cmbSELECT_INV.TabIndex = 308;
            this.cmbSELECT_INV.DropDown += new System.EventHandler(this.cmbSELECT_INV_DropDown);
            this.cmbSELECT_INV.TextUpdate += new System.EventHandler(this.cmbSELECT_INV_TextUpdate);
            this.cmbSELECT_INV.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmbSELECT_INV_PreviewKeyDown);
            // 
            // lbl_SELECT_INV
            // 
            this.lbl_SELECT_INV.AutoSize = true;
            this.lbl_SELECT_INV.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lbl_SELECT_INV.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_SELECT_INV.Location = new System.Drawing.Point(866, 685);
            this.lbl_SELECT_INV.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_SELECT_INV.Name = "lbl_SELECT_INV";
            this.lbl_SELECT_INV.Size = new System.Drawing.Size(123, 20);
            this.lbl_SELECT_INV.TabIndex = 309;
            this.lbl_SELECT_INV.Text = "SELECT INVOICE:";
            this.lbl_SELECT_INV.Visible = false;
            // 
            // rdbOTHERS
            // 
            this.rdbOTHERS.AutoSize = true;
            this.rdbOTHERS.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.rdbOTHERS.Location = new System.Drawing.Point(884, 685);
            this.rdbOTHERS.Margin = new System.Windows.Forms.Padding(4);
            this.rdbOTHERS.Name = "rdbOTHERS";
            this.rdbOTHERS.Size = new System.Drawing.Size(85, 27);
            this.rdbOTHERS.TabIndex = 307;
            this.rdbOTHERS.Text = "OTHER";
            this.rdbOTHERS.UseVisualStyleBackColor = true;
            this.rdbOTHERS.CheckedChanged += new System.EventHandler(this.rdbOTHERS_CheckedChanged);
            // 
            // rdbINV_REC
            // 
            this.rdbINV_REC.AutoSize = true;
            this.rdbINV_REC.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.rdbINV_REC.Location = new System.Drawing.Point(884, 681);
            this.rdbINV_REC.Margin = new System.Windows.Forms.Padding(4);
            this.rdbINV_REC.Name = "rdbINV_REC";
            this.rdbINV_REC.Size = new System.Drawing.Size(144, 27);
            this.rdbINV_REC.TabIndex = 306;
            this.rdbINV_REC.TabStop = true;
            this.rdbINV_REC.Text = "INVOICE / PAY";
            this.rdbINV_REC.UseVisualStyleBackColor = true;
            this.rdbINV_REC.CheckedChanged += new System.EventHandler(this.rdbINV_REC_CheckedChanged);
            // 
            // cmbBankSearch
            // 
            this.cmbBankSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbBankSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBankSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbBankSearch.FormattingEnabled = true;
            this.cmbBankSearch.Location = new System.Drawing.Point(627, 123);
            this.cmbBankSearch.Margin = new System.Windows.Forms.Padding(4);
            this.cmbBankSearch.Name = "cmbBankSearch";
            this.cmbBankSearch.Size = new System.Drawing.Size(307, 29);
            this.cmbBankSearch.TabIndex = 310;
            this.cmbBankSearch.SelectedIndexChanged += new System.EventHandler(this.cmbBankSearch_SelectedIndexChanged);
            // 
            // txtAmountWordsRec
            // 
            this.txtAmountWordsRec.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtAmountWordsRec.Location = new System.Drawing.Point(627, 533);
            this.txtAmountWordsRec.Margin = new System.Windows.Forms.Padding(4);
            this.txtAmountWordsRec.MaxLength = 50;
            this.txtAmountWordsRec.Name = "txtAmountWordsRec";
            this.txtAmountWordsRec.ReadOnly = true;
            this.txtAmountWordsRec.Size = new System.Drawing.Size(307, 29);
            this.txtAmountWordsRec.TabIndex = 311;
            this.txtAmountWordsRec.Text = "-";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label27.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label27.Location = new System.Drawing.Point(472, 535);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(142, 20);
            this.label27.TabIndex = 312;
            this.label27.Text = "AMOUNT(WORDS):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(7, 641);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 20);
            this.label1.TabIndex = 312;
            this.label1.Text = "BANK BALANCE:";
            // 
            // txtBankBalance
            // 
            this.txtBankBalance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtBankBalance.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtBankBalance.Location = new System.Drawing.Point(148, 635);
            this.txtBankBalance.Margin = new System.Windows.Forms.Padding(4);
            this.txtBankBalance.MaxLength = 50;
            this.txtBankBalance.Name = "txtBankBalance";
            this.txtBankBalance.ReadOnly = true;
            this.txtBankBalance.Size = new System.Drawing.Size(269, 29);
            this.txtBankBalance.TabIndex = 311;
            this.txtBankBalance.Text = "0";
            // 
            // frm_BankPmt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(948, 719);
            this.Controls.Add(this.btnCLEAR);
            this.Controls.Add(this.btnSAVE);
            this.Controls.Add(this.txtBankBalance);
            this.Controls.Add(this.label1);
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
            this.Controls.Add(this.txtPay);
            this.Controls.Add(this.lblPay);
            this.Controls.Add(this.cmbPay);
            this.Controls.Add(this.lblTrNo);
            this.Controls.Add(this.lblTr);
            this.Controls.Add(this.dtp_DATE);
            this.Controls.Add(this.lblBPV);
            this.Controls.Add(this.txtNar);
            this.Controls.Add(this.lblAcc);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.lblPaid);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblAmt);
            this.Controls.Add(this.lblV);
            this.Controls.Add(this.grdSEARCH);
            this.Controls.Add(this.txtSEARCH);
            this.Controls.Add(this.lblSEARCH);
            this.Controls.Add(this.pnlHEADER);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_BankPmt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BANK PAYMENT VOUCHER";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_BankPmt_FormClosed);
            this.Load += new System.EventHandler(this.frm_BankPmt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdSEARCH)).EndInit();
            this.pnlHEADER.ResumeLayout(false);
            this.pnlHEADER.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtChq;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lblChqDt;
        private SergeUtils.EasyCompletionComboBox cmbBank;
        private System.Windows.Forms.Label lblBank;
        private System.Windows.Forms.TextBox txtChq;
        private System.Windows.Forms.Label lblCHQ;
        private System.Windows.Forms.TextBox txtPay;
        private System.Windows.Forms.Label lblPay;
        private SergeUtils.EasyCompletionComboBox cmbPay;
        private System.Windows.Forms.Label lblTrNo;
        private System.Windows.Forms.Label lblTr;
        private System.Windows.Forms.DateTimePicker dtp_DATE;
        private System.Windows.Forms.Label lblBPV;
        private System.Windows.Forms.TextBox txtNar;
        private System.Windows.Forms.Label lblAcc;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Button btnCLEAR;
        private System.Windows.Forms.Label lblPaid;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.PictureBox pictureBox15;
        private System.Windows.Forms.Label lblAmt;
        private System.Windows.Forms.Button btnSAVE;
        private System.Windows.Forms.Label lblV;
        private System.Windows.Forms.DataGridView grdSEARCH;
        private System.Windows.Forms.Label lblHEADING;
        private System.Windows.Forms.TextBox txtSEARCH;
        private System.Windows.Forms.Label lblSEARCH;
        private System.Windows.Forms.Panel pnlHEADER;
        private System.Windows.Forms.Button btn_VIEW_VOUCHER;
        private SergeUtils.EasyCompletionComboBox cmbSELECT_INV;
        private System.Windows.Forms.Label lbl_SELECT_INV;
        private System.Windows.Forms.RadioButton rdbOTHERS;
        private System.Windows.Forms.RadioButton rdbINV_REC;
        private SergeUtils.EasyCompletionComboBox cmbBankSearch;
        private System.Windows.Forms.TextBox txtAmountWordsRec;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBankBalance;
    }
}