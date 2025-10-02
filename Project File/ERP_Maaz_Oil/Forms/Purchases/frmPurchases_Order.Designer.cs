namespace ERP_Maaz_Oil.Forms
{
    partial class frmPurchases_Order
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPurchases_Order));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grdSearch = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSEARCH = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.cmbSupplier = new SergeUtils.EasyCompletionComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblInvoice = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblV = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblAcc = new System.Windows.Forms.Label();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbProducts = new SergeUtils.EasyCompletionComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.gridProducts = new System.Windows.Forms.DataGridView();
            this.productId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btn_VIEW_VOUCHER = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlHEADER = new System.Windows.Forms.Panel();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.lblHEADING = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridProducts)).BeginInit();
            this.pnlHEADER.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            this.SuspendLayout();
            // 
            // grdSearch
            // 
            this.grdSearch.AllowUserToAddRows = false;
            this.grdSearch.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.grdSearch.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdSearch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdSearch.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grdSearch.BackgroundColor = System.Drawing.Color.White;
            this.grdSearch.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdSearch.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdSearch.DefaultCellStyle = dataGridViewCellStyle3;
            this.grdSearch.Location = new System.Drawing.Point(5, 86);
            this.grdSearch.Name = "grdSearch";
            this.grdSearch.ReadOnly = true;
            this.grdSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSearch.Size = new System.Drawing.Size(910, 181);
            this.grdSearch.TabIndex = 2;
            this.grdSearch.TabStop = false;
            this.grdSearch.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdSearch_CellClick);
            this.grdSearch.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdSearch_CellContentClick);
            this.grdSearch.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.grdSEARCH_DataBindingComplete);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtSearch.Location = new System.Drawing.Point(72, 55);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(843, 25);
            this.txtSearch.TabIndex = 17;
            this.txtSearch.TabStop = false;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSEARCH_TextChanged);
            // 
            // lblSEARCH
            // 
            this.lblSEARCH.AutoSize = true;
            this.lblSEARCH.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSEARCH.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSEARCH.Location = new System.Drawing.Point(9, 59);
            this.lblSEARCH.Name = "lblSEARCH";
            this.lblSEARCH.Size = new System.Drawing.Size(57, 17);
            this.lblSEARCH.TabIndex = 219;
            this.lblSEARCH.Text = "SEARCH";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icons8-Save as Filled-100.png");
            this.imageList1.Images.SetKeyName(1, "icons8-Cancel Filled-100.png");
            this.imageList1.Images.SetKeyName(2, "icons8-search.png");
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSupplier.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSupplier.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbSupplier.FormattingEnabled = true;
            this.cmbSupplier.Items.AddRange(new object[] {
            "--SELECT SUPPLIER--",
            "AUTOMART"});
            this.cmbSupplier.Location = new System.Drawing.Point(99, 328);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(280, 25);
            this.cmbSupplier.TabIndex = 1;
            this.cmbSupplier.Leave += new System.EventHandler(this.cmbSupplier_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(12, 333);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 15);
            this.label9.TabIndex = 227;
            this.label9.Text = "SUPPLIER";
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.dtpDate.Location = new System.Drawing.Point(99, 299);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(280, 23);
            this.dtpDate.TabIndex = 0;
            // 
            // lblInvoice
            // 
            this.lblInvoice.AutoSize = true;
            this.lblInvoice.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblInvoice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(215)))));
            this.lblInvoice.Location = new System.Drawing.Point(99, 277);
            this.lblInvoice.Name = "lblInvoice";
            this.lblInvoice.Size = new System.Drawing.Size(63, 15);
            this.lblInvoice.TabIndex = 298;
            this.lblInvoice.Text = "PO-1-2017";
            this.lblInvoice.Click += new System.EventHandler(this.lblInvoice_Click);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblDate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDate.Location = new System.Drawing.Point(12, 303);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(36, 15);
            this.lblDate.TabIndex = 297;
            this.lblDate.Text = "DATE";
            // 
            // lblV
            // 
            this.lblV.AutoSize = true;
            this.lblV.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblV.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblV.Location = new System.Drawing.Point(12, 277);
            this.lblV.Name = "lblV";
            this.lblV.Size = new System.Drawing.Size(37, 15);
            this.lblV.TabIndex = 296;
            this.lblV.Text = "P.O #:";
            // 
            // txtDescription
            // 
            this.txtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtDescription.Location = new System.Drawing.Point(99, 359);
            this.txtDescription.MaxLength = 32000;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(280, 25);
            this.txtDescription.TabIndex = 2;
            // 
            // lblAcc
            // 
            this.lblAcc.AutoSize = true;
            this.lblAcc.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblAcc.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblAcc.Location = new System.Drawing.Point(12, 364);
            this.lblAcc.Name = "lblAcc";
            this.lblAcc.Size = new System.Drawing.Size(83, 15);
            this.lblAcc.TabIndex = 300;
            this.lblAcc.Text = "DESCRIPTION";
            // 
            // txtRate
            // 
            this.txtRate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRate.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtRate.Location = new System.Drawing.Point(99, 453);
            this.txtRate.MaxLength = 11;
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(208, 25);
            this.txtRate.TabIndex = 13;
            this.txtRate.Text = "0";
            this.txtRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCreditDays_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(12, 458);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 15);
            this.label3.TabIndex = 306;
            this.label3.Text = "RATE";
            // 
            // txtQty
            // 
            this.txtQty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQty.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtQty.Location = new System.Drawing.Point(99, 422);
            this.txtQty.MaxLength = 11;
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(280, 25);
            this.txtQty.TabIndex = 5;
            this.txtQty.Text = "0";
            this.txtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCreditDays_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(12, 427);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 15);
            this.label1.TabIndex = 343;
            this.label1.Text = "QTY";
            // 
            // cmbProducts
            // 
            this.cmbProducts.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbProducts.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbProducts.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbProducts.FormattingEnabled = true;
            this.cmbProducts.Items.AddRange(new object[] {
            "--SELECT SUPPLIER--",
            "AUTOMART"});
            this.cmbProducts.Location = new System.Drawing.Point(99, 391);
            this.cmbProducts.Name = "cmbProducts";
            this.cmbProducts.Size = new System.Drawing.Size(280, 25);
            this.cmbProducts.TabIndex = 3;
            this.cmbProducts.Leave += new System.EventHandler(this.cmbProducts_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Location = new System.Drawing.Point(12, 396);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 15);
            this.label11.TabIndex = 341;
            this.label11.Text = "PRODUCT";
            // 
            // gridProducts
            // 
            this.gridProducts.AllowUserToAddRows = false;
            this.gridProducts.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.gridProducts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.gridProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gridProducts.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridProducts.BackgroundColor = System.Drawing.Color.White;
            this.gridProducts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Semibold", 10.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gridProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productId,
            this.productname,
            this.qty,
            this.rate,
            this.total});
            this.gridProducts.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridProducts.DefaultCellStyle = dataGridViewCellStyle6;
            this.gridProducts.Location = new System.Drawing.Point(385, 273);
            this.gridProducts.Name = "gridProducts";
            this.gridProducts.ReadOnly = true;
            this.gridProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridProducts.Size = new System.Drawing.Size(530, 236);
            this.gridProducts.TabIndex = 16;
            this.gridProducts.TabStop = false;
            this.gridProducts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridProducts_CellClick);
            this.gridProducts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridProducts_CellClick);
            this.gridProducts.ColumnNameChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.gridProducts_ColumnNameChanged);
            // 
            // productId
            // 
            this.productId.HeaderText = "PRODUCT ID";
            this.productId.Name = "productId";
            this.productId.ReadOnly = true;
            this.productId.Visible = false;
            this.productId.Width = 117;
            // 
            // productname
            // 
            this.productname.HeaderText = "PRODUCT NAME";
            this.productname.Name = "productname";
            this.productname.ReadOnly = true;
            this.productname.Width = 143;
            // 
            // qty
            // 
            this.qty.HeaderText = "QUANTITY";
            this.qty.Name = "qty";
            this.qty.ReadOnly = true;
            this.qty.Width = 103;
            // 
            // rate
            // 
            this.rate.HeaderText = "RATE";
            this.rate.Name = "rate";
            this.rate.ReadOnly = true;
            this.rate.Width = 66;
            // 
            // total
            // 
            this.total.HeaderText = "TOTAL";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            this.total.Width = 74;
            // 
            // txtTotal
            // 
            this.txtTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotal.Enabled = false;
            this.txtTotal.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtTotal.Location = new System.Drawing.Point(737, 515);
            this.txtTotal.MaxLength = 11;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(178, 25);
            this.txtTotal.TabIndex = 345;
            this.txtTotal.TabStop = false;
            this.txtTotal.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(689, 520);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 15);
            this.label5.TabIndex = 346;
            this.label5.Text = "TOTAL";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(68)))), ((int)(((byte)(2)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.ImageIndex = 0;
            this.btnAdd.Location = new System.Drawing.Point(311, 453);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(68, 25);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "ADD";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btn_VIEW_VOUCHER
            // 
            this.btn_VIEW_VOUCHER.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(24)))), ((int)(((byte)(38)))));
            this.btn_VIEW_VOUCHER.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_VIEW_VOUCHER.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_VIEW_VOUCHER.ForeColor = System.Drawing.Color.White;
            this.btn_VIEW_VOUCHER.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_VIEW_VOUCHER.ImageIndex = 1;
            this.btn_VIEW_VOUCHER.ImageList = this.imageList1;
            this.btn_VIEW_VOUCHER.Location = new System.Drawing.Point(99, 514);
            this.btn_VIEW_VOUCHER.Name = "btn_VIEW_VOUCHER";
            this.btn_VIEW_VOUCHER.Size = new System.Drawing.Size(280, 25);
            this.btn_VIEW_VOUCHER.TabIndex = 347;
            this.btn_VIEW_VOUCHER.TabStop = false;
            this.btn_VIEW_VOUCHER.Text = "DELETE RECORD";
            this.btn_VIEW_VOUCHER.UseVisualStyleBackColor = false;
            this.btn_VIEW_VOUCHER.Click += new System.EventHandler(this.btn_VIEW_VOUCHER_Click);
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
            this.btnClear.Location = new System.Drawing.Point(255, 484);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(124, 25);
            this.btnClear.TabIndex = 10;
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
            this.btnSave.Location = new System.Drawing.Point(99, 484);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(124, 25);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSAVE_Click);
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
            this.pnlHEADER.Size = new System.Drawing.Size(922, 49);
            this.pnlHEADER.TabIndex = 18;
            this.pnlHEADER.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlHEADER_Paint);
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
            this.lblHEADING.Location = new System.Drawing.Point(6, 10);
            this.lblHEADING.Name = "lblHEADING";
            this.lblHEADING.Size = new System.Drawing.Size(236, 29);
            this.lblHEADING.TabIndex = 23;
            this.lblHEADING.Text = "PURCHASE ORDER";
            // 
            // frmPurchases_Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(922, 547);
            this.Controls.Add(this.btn_VIEW_VOUCHER);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.gridProducts);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbProducts);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtRate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblAcc);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblInvoice);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblV);
            this.Controls.Add(this.cmbSupplier);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.grdSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSEARCH);
            this.Controls.Add(this.pnlHEADER);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(938, 586);
            this.Name = "frmPurchases_Order";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PURCHASE ORDER";
            this.Load += new System.EventHandler(this.frm_AddGroupAccounts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridProducts)).EndInit();
            this.pnlHEADER.ResumeLayout(false);
            this.pnlHEADER.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHEADER;
        private System.Windows.Forms.PictureBox pictureBox15;
        private System.Windows.Forms.Label lblHEADING;
        private System.Windows.Forms.DataGridView grdSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSEARCH;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private SergeUtils.EasyCompletionComboBox cmbSupplier;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblInvoice;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblV;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblAcc;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label label1;
        private SergeUtils.EasyCompletionComboBox cmbProducts;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView gridProducts;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btn_VIEW_VOUCHER;
        private System.Windows.Forms.DataGridViewTextBoxColumn productId;
        private System.Windows.Forms.DataGridViewTextBoxColumn productname;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
    }
}