namespace ERP_Maaz_Oil.Forms.Vouchers
{
    partial class frmBankBook
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBankBook));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button1 = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.cmbRefAc = new SergeUtils.EasyCompletionComboBox();
            this.grdPaySummary = new System.Windows.Forms.DataGridView();
            this.grdRecSummary = new System.Windows.Forms.DataGridView();
            this.grdEntries = new System.Windows.Forms.DataGridView();
            this.txtTotalPayGrid = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTotalRecGrid = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtEntries = new System.Windows.Forms.TextBox();
            this.lblEntries = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.cmbInstrumentNo = new SergeUtils.EasyCompletionComboBox();
            this.cmbPaymentAc = new SergeUtils.EasyCompletionComboBox();
            this.lblInstrumentNo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPaymentAc = new System.Windows.Forms.Label();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.cmbRecAc = new SergeUtils.EasyCompletionComboBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblVoucherNo = new System.Windows.Forms.Label();
            this.lblHEADING = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lblRecAc = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblVC = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlHEADER = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbChqNo = new SergeUtils.EasyCompletionComboBox();
            this.lblNarration = new System.Windows.Forms.Label();
            this.txtNarration = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.txtAmountWordsRec = new System.Windows.Forms.TextBox();
            this.btnReceiptVoucher = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdPaySummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRecSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEntries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            this.pnlHEADER.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DimGray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.ImageIndex = 1;
            this.button1.ImageList = this.imageList1;
            this.button1.Location = new System.Drawing.Point(475, 337);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 25);
            this.button1.TabIndex = 399;
            this.button1.Text = "DELETE";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icons8-Save as Filled-100.png");
            this.imageList1.Images.SetKeyName(1, "icons8-Cancel Filled-100.png");
            this.imageList1.Images.SetKeyName(2, "icons8-search.png");
            // 
            // cmbRefAc
            // 
            this.cmbRefAc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbRefAc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRefAc.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbRefAc.FormattingEnabled = true;
            this.cmbRefAc.Items.AddRange(new object[] {
            "--SELECT INVOICE--"});
            this.cmbRefAc.Location = new System.Drawing.Point(114, 147);
            this.cmbRefAc.Name = "cmbRefAc";
            this.cmbRefAc.Size = new System.Drawing.Size(250, 25);
            this.cmbRefAc.TabIndex = 398;
            // 
            // grdPaySummary
            // 
            this.grdPaySummary.AllowUserToAddRows = false;
            this.grdPaySummary.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdPaySummary.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdPaySummary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdPaySummary.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grdPaySummary.BackgroundColor = System.Drawing.Color.White;
            this.grdPaySummary.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdPaySummary.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdPaySummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPaySummary.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdPaySummary.DefaultCellStyle = dataGridViewCellStyle3;
            this.grdPaySummary.Location = new System.Drawing.Point(717, 369);
            this.grdPaySummary.Name = "grdPaySummary";
            this.grdPaySummary.ReadOnly = true;
            this.grdPaySummary.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdPaySummary.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.grdPaySummary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPaySummary.Size = new System.Drawing.Size(295, 194);
            this.grdPaySummary.TabIndex = 396;
            this.grdPaySummary.TabStop = false;
            this.grdPaySummary.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.grdPaySummary_DataBindingComplete);
            // 
            // grdRecSummary
            // 
            this.grdRecSummary.AllowUserToAddRows = false;
            this.grdRecSummary.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdRecSummary.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.grdRecSummary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdRecSummary.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grdRecSummary.BackgroundColor = System.Drawing.Color.White;
            this.grdRecSummary.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdRecSummary.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.grdRecSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdRecSummary.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdRecSummary.DefaultCellStyle = dataGridViewCellStyle7;
            this.grdRecSummary.Location = new System.Drawing.Point(717, 114);
            this.grdRecSummary.Name = "grdRecSummary";
            this.grdRecSummary.ReadOnly = true;
            this.grdRecSummary.RowHeadersVisible = false;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdRecSummary.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.grdRecSummary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdRecSummary.Size = new System.Drawing.Size(295, 188);
            this.grdRecSummary.TabIndex = 395;
            this.grdRecSummary.TabStop = false;
            this.grdRecSummary.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.grdRecSummary_DataBindingComplete);
            // 
            // grdEntries
            // 
            this.grdEntries.AllowUserToAddRows = false;
            this.grdEntries.AllowUserToDeleteRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            this.grdEntries.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.grdEntries.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdEntries.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grdEntries.BackgroundColor = System.Drawing.Color.White;
            this.grdEntries.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdEntries.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.grdEntries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdEntries.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdEntries.DefaultCellStyle = dataGridViewCellStyle11;
            this.grdEntries.Location = new System.Drawing.Point(68, 399);
            this.grdEntries.Name = "grdEntries";
            this.grdEntries.ReadOnly = true;
            this.grdEntries.RowHeadersVisible = false;
            this.grdEntries.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdEntries.Size = new System.Drawing.Size(637, 124);
            this.grdEntries.TabIndex = 394;
            this.grdEntries.TabStop = false;
            this.grdEntries.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdEntries_CellClick);
            this.grdEntries.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.grdEntries_DataBindingComplete);
            // 
            // txtTotalPayGrid
            // 
            this.txtTotalPayGrid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotalPayGrid.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtTotalPayGrid.Location = new System.Drawing.Point(903, 570);
            this.txtTotalPayGrid.Name = "txtTotalPayGrid";
            this.txtTotalPayGrid.ReadOnly = true;
            this.txtTotalPayGrid.Size = new System.Drawing.Size(110, 25);
            this.txtTotalPayGrid.TabIndex = 391;
            this.txtTotalPayGrid.Text = "0";
            this.txtTotalPayGrid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(842, 572);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 17);
            this.label6.TabIndex = 390;
            this.label6.Text = "TOTAL";
            // 
            // txtTotalRecGrid
            // 
            this.txtTotalRecGrid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotalRecGrid.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtTotalRecGrid.Location = new System.Drawing.Point(903, 309);
            this.txtTotalRecGrid.Name = "txtTotalRecGrid";
            this.txtTotalRecGrid.ReadOnly = true;
            this.txtTotalRecGrid.Size = new System.Drawing.Size(110, 25);
            this.txtTotalRecGrid.TabIndex = 393;
            this.txtTotalRecGrid.Text = "0";
            this.txtTotalRecGrid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(842, 309);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 17);
            this.label5.TabIndex = 389;
            this.label5.Text = "TOTAL";
            // 
            // txtTotal
            // 
            this.txtTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotal.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtTotal.Location = new System.Drawing.Point(68, 539);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(194, 25);
            this.txtTotal.TabIndex = 392;
            this.txtTotal.Text = "0";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTotal.Location = new System.Drawing.Point(20, 541);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(44, 17);
            this.lblTotal.TabIndex = 388;
            this.lblTotal.Text = "TOTAL";
            // 
            // txtEntries
            // 
            this.txtEntries.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEntries.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtEntries.Location = new System.Drawing.Point(635, 540);
            this.txtEntries.Name = "txtEntries";
            this.txtEntries.ReadOnly = true;
            this.txtEntries.Size = new System.Drawing.Size(71, 25);
            this.txtEntries.TabIndex = 387;
            this.txtEntries.Text = "0";
            // 
            // lblEntries
            // 
            this.lblEntries.AutoSize = true;
            this.lblEntries.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntries.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblEntries.Location = new System.Drawing.Point(573, 541);
            this.lblEntries.Name = "lblEntries";
            this.lblEntries.Size = new System.Drawing.Size(58, 17);
            this.lblEntries.TabIndex = 386;
            this.lblEntries.Text = "ENTRIES";
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtSearch.Location = new System.Drawing.Point(68, 369);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(696, 25);
            this.txtSearch.TabIndex = 385;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSearch.Location = new System.Drawing.Point(4, 369);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(60, 17);
            this.lblSearch.TabIndex = 384;
            this.lblSearch.Text = "SEARCH:";
            // 
            // cmbInstrumentNo
            // 
            this.cmbInstrumentNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbInstrumentNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbInstrumentNo.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbInstrumentNo.FormattingEnabled = true;
            this.cmbInstrumentNo.Items.AddRange(new object[] {
            "--SELECT INVOICE--"});
            this.cmbInstrumentNo.Location = new System.Drawing.Point(475, 208);
            this.cmbInstrumentNo.Name = "cmbInstrumentNo";
            this.cmbInstrumentNo.Size = new System.Drawing.Size(231, 25);
            this.cmbInstrumentNo.TabIndex = 382;
            // 
            // cmbPaymentAc
            // 
            this.cmbPaymentAc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbPaymentAc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPaymentAc.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbPaymentAc.FormattingEnabled = true;
            this.cmbPaymentAc.Items.AddRange(new object[] {
            "--SELECT INVOICE--"});
            this.cmbPaymentAc.Location = new System.Drawing.Point(114, 177);
            this.cmbPaymentAc.Name = "cmbPaymentAc";
            this.cmbPaymentAc.Size = new System.Drawing.Size(250, 25);
            this.cmbPaymentAc.TabIndex = 381;
            this.cmbPaymentAc.TextUpdate += new System.EventHandler(this.cmbTextUpdate);
            // 
            // lblInstrumentNo
            // 
            this.lblInstrumentNo.AutoSize = true;
            this.lblInstrumentNo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstrumentNo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblInstrumentNo.Location = new System.Drawing.Point(370, 210);
            this.lblInstrumentNo.Name = "lblInstrumentNo";
            this.lblInstrumentNo.Size = new System.Drawing.Size(101, 17);
            this.lblInstrumentNo.TabIndex = 380;
            this.lblInstrumentNo.Text = "INSTRUMENT #";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(752, 344);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(252, 21);
            this.label4.TabIndex = 376;
            this.label4.Text = "SUMMARY PAYMENT ACCOUNT";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(752, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(239, 21);
            this.label3.TabIndex = 374;
            this.label3.Text = "SUMMARY RECEIPT ACCOUNT";
            // 
            // lblPaymentAc
            // 
            this.lblPaymentAc.AutoSize = true;
            this.lblPaymentAc.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblPaymentAc.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPaymentAc.Location = new System.Drawing.Point(8, 184);
            this.lblPaymentAc.Name = "lblPaymentAc";
            this.lblPaymentAc.Size = new System.Drawing.Size(81, 15);
            this.lblPaymentAc.TabIndex = 369;
            this.lblPaymentAc.Text = "PAYMENT AC:";
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
            // cmbRecAc
            // 
            this.cmbRecAc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbRecAc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRecAc.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbRecAc.FormattingEnabled = true;
            this.cmbRecAc.Location = new System.Drawing.Point(114, 119);
            this.cmbRecAc.Name = "cmbRecAc";
            this.cmbRecAc.Size = new System.Drawing.Size(250, 25);
            this.cmbRecAc.TabIndex = 355;
            this.cmbRecAc.SelectedIndexChanged += new System.EventHandler(this.cmbRecAc_SelectedIndexChanged);
            this.cmbRecAc.TextUpdate += new System.EventHandler(this.cmbTextUpdate);
            // 
            // dtpDate
            // 
            this.dtpDate.Checked = false;
            this.dtpDate.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.dtpDate.Location = new System.Drawing.Point(475, 123);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(231, 23);
            this.dtpDate.TabIndex = 353;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // lblVoucherNo
            // 
            this.lblVoucherNo.AutoSize = true;
            this.lblVoucherNo.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblVoucherNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(215)))));
            this.lblVoucherNo.Location = new System.Drawing.Point(114, 92);
            this.lblVoucherNo.Name = "lblVoucherNo";
            this.lblVoucherNo.Size = new System.Drawing.Size(63, 15);
            this.lblVoucherNo.TabIndex = 367;
            this.lblVoucherNo.Text = "BV-1-2019";
            // 
            // lblHEADING
            // 
            this.lblHEADING.AutoSize = true;
            this.lblHEADING.BackColor = System.Drawing.Color.Transparent;
            this.lblHEADING.Font = new System.Drawing.Font("Berlin Sans FB", 15.75F);
            this.lblHEADING.ForeColor = System.Drawing.Color.White;
            this.lblHEADING.Location = new System.Drawing.Point(6, 16);
            this.lblHEADING.Name = "lblHEADING";
            this.lblHEADING.Size = new System.Drawing.Size(126, 23);
            this.lblHEADING.TabIndex = 23;
            this.lblHEADING.Text = "BANK BOOK";
            // 
            // txtAmount
            // 
            this.txtAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAmount.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtAmount.Location = new System.Drawing.Point(475, 152);
            this.txtAmount.MaxLength = 10;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(231, 25);
            this.txtAmount.TabIndex = 356;
            this.txtAmount.Text = "0";
            this.txtAmount.TextChanged += new System.EventHandler(this.txtAmount_TextChanged);
            // 
            // lblRecAc
            // 
            this.lblRecAc.AutoSize = true;
            this.lblRecAc.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblRecAc.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblRecAc.Location = new System.Drawing.Point(8, 122);
            this.lblRecAc.Name = "lblRecAc";
            this.lblRecAc.Size = new System.Drawing.Size(48, 15);
            this.lblRecAc.TabIndex = 364;
            this.lblRecAc.Text = "REC AC:";
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
            this.btnClear.Location = new System.Drawing.Point(589, 309);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(116, 25);
            this.btnClear.TabIndex = 358;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblDate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDate.Location = new System.Drawing.Point(370, 125);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(39, 15);
            this.lblDate.TabIndex = 363;
            this.lblDate.Text = "DATE:";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblAmount.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblAmount.Location = new System.Drawing.Point(370, 155);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(59, 15);
            this.lblAmount.TabIndex = 365;
            this.lblAmount.Text = "AMOUNT";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(215)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.ImageIndex = 0;
            this.btnSave.ImageList = this.imageList1;
            this.btnSave.Location = new System.Drawing.Point(475, 309);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(114, 25);
            this.btnSave.TabIndex = 357;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblVC
            // 
            this.lblVC.AutoSize = true;
            this.lblVC.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblVC.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblVC.Location = new System.Drawing.Point(8, 92);
            this.lblVC.Name = "lblVC";
            this.lblVC.Size = new System.Drawing.Size(74, 15);
            this.lblVC.TabIndex = 362;
            this.lblVC.Text = "VOUCHER #:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(8, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 360;
            this.label1.Text = "REF ACC:";
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
            this.pnlHEADER.Size = new System.Drawing.Size(1021, 55);
            this.pnlHEADER.TabIndex = 359;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(370, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 15);
            this.label2.TabIndex = 364;
            this.label2.Text = "CHQ NO";
            // 
            // cmbChqNo
            // 
            this.cmbChqNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbChqNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbChqNo.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbChqNo.FormattingEnabled = true;
            this.cmbChqNo.Location = new System.Drawing.Point(475, 180);
            this.cmbChqNo.Name = "cmbChqNo";
            this.cmbChqNo.Size = new System.Drawing.Size(231, 25);
            this.cmbChqNo.TabIndex = 355;
            this.cmbChqNo.SelectedIndexChanged += new System.EventHandler(this.cmbChqNo_SelectedIndexChanged);
            // 
            // lblNarration
            // 
            this.lblNarration.AutoSize = true;
            this.lblNarration.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblNarration.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblNarration.Location = new System.Drawing.Point(8, 244);
            this.lblNarration.Name = "lblNarration";
            this.lblNarration.Size = new System.Drawing.Size(77, 15);
            this.lblNarration.TabIndex = 366;
            this.lblNarration.Text = "NARRATION:";
            // 
            // txtNarration
            // 
            this.txtNarration.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNarration.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtNarration.Location = new System.Drawing.Point(114, 240);
            this.txtNarration.MaxLength = 100;
            this.txtNarration.Multiline = true;
            this.txtNarration.Name = "txtNarration";
            this.txtNarration.Size = new System.Drawing.Size(250, 53);
            this.txtNarration.TabIndex = 354;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label27.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label27.Location = new System.Drawing.Point(8, 211);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(114, 15);
            this.label27.TabIndex = 401;
            this.label27.Text = "AMOUNT(WORDS):";
            // 
            // txtAmountWordsRec
            // 
            this.txtAmountWordsRec.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtAmountWordsRec.Location = new System.Drawing.Point(114, 208);
            this.txtAmountWordsRec.MaxLength = 50;
            this.txtAmountWordsRec.Name = "txtAmountWordsRec";
            this.txtAmountWordsRec.ReadOnly = true;
            this.txtAmountWordsRec.Size = new System.Drawing.Size(250, 25);
            this.txtAmountWordsRec.TabIndex = 400;
            this.txtAmountWordsRec.Text = "0";
            // 
            // btnReceiptVoucher
            // 
            this.btnReceiptVoucher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(24)))), ((int)(((byte)(38)))));
            this.btnReceiptVoucher.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReceiptVoucher.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnReceiptVoucher.ForeColor = System.Drawing.Color.White;
            this.btnReceiptVoucher.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReceiptVoucher.ImageIndex = 2;
            this.btnReceiptVoucher.ImageList = this.imageList1;
            this.btnReceiptVoucher.Location = new System.Drawing.Point(589, 337);
            this.btnReceiptVoucher.Name = "btnReceiptVoucher";
            this.btnReceiptVoucher.Size = new System.Drawing.Size(117, 25);
            this.btnReceiptVoucher.TabIndex = 402;
            this.btnReceiptVoucher.Text = "VOUCHER";
            this.btnReceiptVoucher.UseVisualStyleBackColor = false;
            this.btnReceiptVoucher.Click += new System.EventHandler(this.btnReceiptVoucher_Click);
            // 
            // frmBankBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1021, 621);
            this.Controls.Add(this.btnReceiptVoucher);
            this.Controls.Add(this.txtAmountWordsRec);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmbRefAc);
            this.Controls.Add(this.grdPaySummary);
            this.Controls.Add(this.grdRecSummary);
            this.Controls.Add(this.grdEntries);
            this.Controls.Add(this.txtTotalPayGrid);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTotalRecGrid);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.txtEntries);
            this.Controls.Add(this.lblEntries);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.cmbInstrumentNo);
            this.Controls.Add(this.cmbPaymentAc);
            this.Controls.Add(this.lblInstrumentNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblPaymentAc);
            this.Controls.Add(this.cmbChqNo);
            this.Controls.Add(this.cmbRecAc);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblVoucherNo);
            this.Controls.Add(this.txtNarration);
            this.Controls.Add(this.lblNarration);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.lblRecAc);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblVC);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlHEADER);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1037, 660);
            this.MinimizeBox = false;
            this.Name = "frmBankBook";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BANK BOOK";
            this.Load += new System.EventHandler(this.frmBankBook_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdPaySummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRecSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEntries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
            this.pnlHEADER.ResumeLayout(false);
            this.pnlHEADER.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ImageList imageList1;
        private SergeUtils.EasyCompletionComboBox cmbRefAc;
        private System.Windows.Forms.DataGridView grdPaySummary;
        private System.Windows.Forms.DataGridView grdRecSummary;
        private System.Windows.Forms.DataGridView grdEntries;
        private System.Windows.Forms.TextBox txtTotalPayGrid;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTotalRecGrid;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtEntries;
        private System.Windows.Forms.Label lblEntries;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private SergeUtils.EasyCompletionComboBox cmbInstrumentNo;
        private SergeUtils.EasyCompletionComboBox cmbPaymentAc;
        private System.Windows.Forms.Label lblInstrumentNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPaymentAc;
        private System.Windows.Forms.PictureBox pictureBox15;
        private SergeUtils.EasyCompletionComboBox cmbRecAc;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblVoucherNo;
        private System.Windows.Forms.Label lblHEADING;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label lblRecAc;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblVC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlHEADER;
        private System.Windows.Forms.Label label2;
        private SergeUtils.EasyCompletionComboBox cmbChqNo;
        private System.Windows.Forms.Label lblNarration;
        private System.Windows.Forms.TextBox txtNarration;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtAmountWordsRec;
        private System.Windows.Forms.Button btnReceiptVoucher;
    }
}