namespace ERP_Maaz_Oil.Forms
{
    partial class frm_Sales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Sales));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grdSearch = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSEARCH = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.cmbCustomer = new SergeUtils.EasyCompletionComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblInvoice = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblV = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblAcc = new System.Windows.Forms.Label();
            this.txtCreditDays = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbProducts = new SergeUtils.EasyCompletionComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.gridProducts = new System.Windows.Forms.DataGridView();
            this.productId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gstValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.netTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtNetTotal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnViewInvoice = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlHEADER = new System.Windows.Forms.Panel();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.lblHEADING = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.rdbCash = new System.Windows.Forms.RadioButton();
            this.rdbCredit = new System.Windows.Forms.RadioButton();
            this.chkSO = new System.Windows.Forms.CheckBox();
            this.cmbSO = new SergeUtils.EasyCompletionComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBillNo = new System.Windows.Forms.TextBox();
            this.txtGST = new System.Windows.Forms.TextBox();
            this.GST = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.btnDeliveryChallan = new System.Windows.Forms.Button();
            this.txtCostRate = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkPosted = new System.Windows.Forms.CheckBox();
            this.cmbReference = new SergeUtils.EasyCompletionComboBox();
            this.label10 = new System.Windows.Forms.Label();
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
            this.grdSearch.Location = new System.Drawing.Point(5, 83);
            this.grdSearch.Name = "grdSearch";
            this.grdSearch.ReadOnly = true;
            this.grdSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSearch.Size = new System.Drawing.Size(910, 154);
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
            this.txtSearch.Location = new System.Drawing.Point(72, 52);
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
            this.lblSEARCH.Location = new System.Drawing.Point(9, 56);
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
            // cmbCustomer
            // 
            this.cmbCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCustomer.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Items.AddRange(new object[] {
            "--SELECT SUPPLIER--",
            "AUTOMART"});
            this.cmbCustomer.Location = new System.Drawing.Point(100, 297);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(280, 25);
            this.cmbCustomer.TabIndex = 1;
            this.cmbCustomer.SelectedIndexChanged += new System.EventHandler(this.cmbSupplier_SelectedIndexChanged);
            this.cmbCustomer.Leave += new System.EventHandler(this.cmbCustomer_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(10, 302);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 15);
            this.label9.TabIndex = 227;
            this.label9.Text = "CUSTOMER";
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.dtpDate.Location = new System.Drawing.Point(100, 268);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(280, 23);
            this.dtpDate.TabIndex = 0;
            // 
            // lblInvoice
            // 
            this.lblInvoice.AutoSize = true;
            this.lblInvoice.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblInvoice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(215)))));
            this.lblInvoice.Location = new System.Drawing.Point(100, 245);
            this.lblInvoice.Name = "lblInvoice";
            this.lblInvoice.Size = new System.Drawing.Size(58, 15);
            this.lblInvoice.TabIndex = 298;
            this.lblInvoice.Text = "SI-1-2017";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblDate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDate.Location = new System.Drawing.Point(10, 272);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(39, 15);
            this.lblDate.TabIndex = 297;
            this.lblDate.Text = "DATE:";
            // 
            // lblV
            // 
            this.lblV.AutoSize = true;
            this.lblV.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblV.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblV.Location = new System.Drawing.Point(10, 245);
            this.lblV.Name = "lblV";
            this.lblV.Size = new System.Drawing.Size(34, 15);
            this.lblV.TabIndex = 296;
            this.lblV.Text = "S.I #:";
            // 
            // txtDescription
            // 
            this.txtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtDescription.Location = new System.Drawing.Point(100, 446);
            this.txtDescription.MaxLength = 32000;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(280, 25);
            this.txtDescription.TabIndex = 5;
            // 
            // lblAcc
            // 
            this.lblAcc.AutoSize = true;
            this.lblAcc.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblAcc.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblAcc.Location = new System.Drawing.Point(10, 451);
            this.lblAcc.Name = "lblAcc";
            this.lblAcc.Size = new System.Drawing.Size(83, 15);
            this.lblAcc.TabIndex = 300;
            this.lblAcc.Text = "DESCRIPTION";
            // 
            // txtCreditDays
            // 
            this.txtCreditDays.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCreditDays.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtCreditDays.Location = new System.Drawing.Point(100, 415);
            this.txtCreditDays.MaxLength = 11;
            this.txtCreditDays.Name = "txtCreditDays";
            this.txtCreditDays.Size = new System.Drawing.Size(280, 25);
            this.txtCreditDays.TabIndex = 4;
            this.txtCreditDays.Text = "0";
            this.txtCreditDays.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCreditDays_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(10, 420);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 15);
            this.label2.TabIndex = 304;
            this.label2.Text = "CREDIT DAYS";
            // 
            // txtRate
            // 
            this.txtRate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRate.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtRate.Location = new System.Drawing.Point(100, 569);
            this.txtRate.MaxLength = 11;
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(211, 25);
            this.txtRate.TabIndex = 8;
            this.txtRate.Text = "0";
            this.txtRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCreditDays_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(10, 574);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 15);
            this.label3.TabIndex = 306;
            this.label3.Text = "RATE";
            // 
            // txtQty
            // 
            this.txtQty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQty.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtQty.Location = new System.Drawing.Point(100, 539);
            this.txtQty.MaxLength = 11;
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(280, 25);
            this.txtQty.TabIndex = 7;
            this.txtQty.Text = "0";
            this.txtQty.TextChanged += new System.EventHandler(this.txtQty_TextChanged);
            this.txtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCreditDays_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(10, 544);
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
            this.cmbProducts.Location = new System.Drawing.Point(100, 508);
            this.cmbProducts.Name = "cmbProducts";
            this.cmbProducts.Size = new System.Drawing.Size(280, 25);
            this.cmbProducts.TabIndex = 6;
            this.cmbProducts.SelectedIndexChanged += new System.EventHandler(this.cmbMaterials_SelectedIndexChanged);
            this.cmbProducts.Leave += new System.EventHandler(this.cmbProducts_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Location = new System.Drawing.Point(10, 513);
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
            this.productName,
            this.qty,
            this.rate,
            this.total,
            this.gstValue,
            this.netTotal,
            this.costRate});
            this.gridProducts.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridProducts.DefaultCellStyle = dataGridViewCellStyle6;
            this.gridProducts.Location = new System.Drawing.Point(386, 240);
            this.gridProducts.Name = "gridProducts";
            this.gridProducts.ReadOnly = true;
            this.gridProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridProducts.Size = new System.Drawing.Size(530, 380);
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
            // productName
            // 
            this.productName.HeaderText = "PRODUCT";
            this.productName.Name = "productName";
            this.productName.ReadOnly = true;
            this.productName.Width = 99;
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
            // gstValue
            // 
            this.gstValue.HeaderText = "GST";
            this.gstValue.Name = "gstValue";
            this.gstValue.ReadOnly = true;
            this.gstValue.Width = 60;
            // 
            // netTotal
            // 
            this.netTotal.HeaderText = "NET TOTAL";
            this.netTotal.Name = "netTotal";
            this.netTotal.ReadOnly = true;
            this.netTotal.Width = 104;
            // 
            // costRate
            // 
            this.costRate.HeaderText = "COST RATE";
            this.costRate.Name = "costRate";
            this.costRate.ReadOnly = true;
            this.costRate.Visible = false;
            this.costRate.Width = 106;
            // 
            // txtNetTotal
            // 
            this.txtNetTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNetTotal.Enabled = false;
            this.txtNetTotal.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtNetTotal.Location = new System.Drawing.Point(768, 627);
            this.txtNetTotal.MaxLength = 11;
            this.txtNetTotal.Name = "txtNetTotal";
            this.txtNetTotal.ReadOnly = true;
            this.txtNetTotal.Size = new System.Drawing.Size(148, 25);
            this.txtNetTotal.TabIndex = 345;
            this.txtNetTotal.TabStop = false;
            this.txtNetTotal.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(695, 632);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 346;
            this.label5.Text = "NET TOTAL";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(68)))), ((int)(((byte)(2)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.ImageIndex = 0;
            this.btnAdd.Location = new System.Drawing.Point(312, 569);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(68, 25);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "ADD";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnViewInvoice
            // 
            this.btnViewInvoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(24)))), ((int)(((byte)(38)))));
            this.btnViewInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnViewInvoice.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnViewInvoice.ForeColor = System.Drawing.Color.White;
            this.btnViewInvoice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewInvoice.ImageIndex = 2;
            this.btnViewInvoice.Location = new System.Drawing.Point(723, 657);
            this.btnViewInvoice.Name = "btnViewInvoice";
            this.btnViewInvoice.Size = new System.Drawing.Size(193, 25);
            this.btnViewInvoice.TabIndex = 14;
            this.btnViewInvoice.TabStop = false;
            this.btnViewInvoice.Text = "VIEW SALES INVOICE";
            this.btnViewInvoice.UseVisualStyleBackColor = false;
            this.btnViewInvoice.Click += new System.EventHandler(this.btnViewInvoice_Click);
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
            this.btnClear.Location = new System.Drawing.Point(255, 630);
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
            this.btnSave.Location = new System.Drawing.Point(99, 630);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(124, 25);
            this.btnSave.TabIndex = 10;
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
            this.pnlHEADER.Size = new System.Drawing.Size(920, 46);
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
            this.lblHEADING.Location = new System.Drawing.Point(6, 9);
            this.lblHEADING.Name = "lblHEADING";
            this.lblHEADING.Size = new System.Drawing.Size(89, 29);
            this.lblHEADING.TabIndex = 23;
            this.lblHEADING.Text = "SALES";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(24)))), ((int)(((byte)(38)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.ImageIndex = 1;
            this.btnDelete.ImageList = this.imageList1;
            this.btnDelete.Location = new System.Drawing.Point(99, 661);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(280, 25);
            this.btnDelete.TabIndex = 347;
            this.btnDelete.TabStop = false;
            this.btnDelete.Text = "DELETE RECORD";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btn_VIEW_VOUCHER_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(10, 391);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 15);
            this.label6.TabIndex = 351;
            this.label6.Text = "TERM";
            // 
            // rdbCash
            // 
            this.rdbCash.AutoSize = true;
            this.rdbCash.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.rdbCash.Location = new System.Drawing.Point(100, 389);
            this.rdbCash.Name = "rdbCash";
            this.rdbCash.Size = new System.Drawing.Size(56, 19);
            this.rdbCash.TabIndex = 2;
            this.rdbCash.Text = "CASH";
            this.rdbCash.UseVisualStyleBackColor = true;
            this.rdbCash.CheckedChanged += new System.EventHandler(this.rdbCredit_CheckedChanged);
            // 
            // rdbCredit
            // 
            this.rdbCredit.AutoSize = true;
            this.rdbCredit.Checked = true;
            this.rdbCredit.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.rdbCredit.Location = new System.Drawing.Point(177, 389);
            this.rdbCredit.Name = "rdbCredit";
            this.rdbCredit.Size = new System.Drawing.Size(65, 19);
            this.rdbCredit.TabIndex = 3;
            this.rdbCredit.TabStop = true;
            this.rdbCredit.Text = "CREDIT";
            this.rdbCredit.UseVisualStyleBackColor = true;
            this.rdbCredit.CheckedChanged += new System.EventHandler(this.rdbCredit_CheckedChanged);
            // 
            // chkSO
            // 
            this.chkSO.AutoSize = true;
            this.chkSO.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.chkSO.Location = new System.Drawing.Point(10, 362);
            this.chkSO.Name = "chkSO";
            this.chkSO.Size = new System.Drawing.Size(93, 19);
            this.chkSO.TabIndex = 354;
            this.chkSO.TabStop = false;
            this.chkSO.Text = "QUOTATION";
            this.chkSO.UseVisualStyleBackColor = true;
            this.chkSO.CheckedChanged += new System.EventHandler(this.chkPO_CheckedChanged);
            // 
            // cmbSO
            // 
            this.cmbSO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSO.Enabled = false;
            this.cmbSO.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbSO.FormattingEnabled = true;
            this.cmbSO.Location = new System.Drawing.Point(100, 358);
            this.cmbSO.Name = "cmbSO";
            this.cmbSO.Size = new System.Drawing.Size(280, 25);
            this.cmbSO.TabIndex = 355;
            this.cmbSO.TabStop = false;
            this.cmbSO.SelectedIndexChanged += new System.EventHandler(this.cmbPO_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(190, 245);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 15);
            this.label4.TabIndex = 356;
            this.label4.Text = "BILL #:";
            // 
            // txtBillNo
            // 
            this.txtBillNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBillNo.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtBillNo.Location = new System.Drawing.Point(238, 240);
            this.txtBillNo.MaxLength = 11;
            this.txtBillNo.Name = "txtBillNo";
            this.txtBillNo.Size = new System.Drawing.Size(141, 25);
            this.txtBillNo.TabIndex = 357;
            // 
            // txtGST
            // 
            this.txtGST.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGST.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtGST.Location = new System.Drawing.Point(100, 477);
            this.txtGST.MaxLength = 11;
            this.txtGST.Name = "txtGST";
            this.txtGST.Size = new System.Drawing.Size(280, 25);
            this.txtGST.TabIndex = 358;
            this.txtGST.Text = "0";
            this.txtGST.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCreditDays_KeyPress);
            // 
            // GST
            // 
            this.GST.AutoSize = true;
            this.GST.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.GST.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.GST.Location = new System.Drawing.Point(10, 482);
            this.GST.Name = "GST";
            this.GST.Size = new System.Drawing.Size(29, 15);
            this.GST.TabIndex = 359;
            this.GST.Text = "GST";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(390, 631);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 15);
            this.label7.TabIndex = 361;
            this.label7.Text = "TOTAL";
            // 
            // txtTotal
            // 
            this.txtTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotal.Enabled = false;
            this.txtTotal.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtTotal.Location = new System.Drawing.Point(438, 626);
            this.txtTotal.MaxLength = 11;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(148, 25);
            this.txtTotal.TabIndex = 360;
            this.txtTotal.TabStop = false;
            this.txtTotal.Text = "0";
            // 
            // btnDeliveryChallan
            // 
            this.btnDeliveryChallan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(24)))), ((int)(((byte)(38)))));
            this.btnDeliveryChallan.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDeliveryChallan.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnDeliveryChallan.ForeColor = System.Drawing.Color.White;
            this.btnDeliveryChallan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeliveryChallan.ImageIndex = 2;
            this.btnDeliveryChallan.Location = new System.Drawing.Point(393, 657);
            this.btnDeliveryChallan.Name = "btnDeliveryChallan";
            this.btnDeliveryChallan.Size = new System.Drawing.Size(193, 25);
            this.btnDeliveryChallan.TabIndex = 362;
            this.btnDeliveryChallan.TabStop = false;
            this.btnDeliveryChallan.Text = "VIEW DELIVERY CHALLAN";
            this.btnDeliveryChallan.UseVisualStyleBackColor = false;
            this.btnDeliveryChallan.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtCostRate
            // 
            this.txtCostRate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCostRate.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtCostRate.Location = new System.Drawing.Point(100, 599);
            this.txtCostRate.MaxLength = 11;
            this.txtCostRate.Name = "txtCostRate";
            this.txtCostRate.ReadOnly = true;
            this.txtCostRate.Size = new System.Drawing.Size(279, 25);
            this.txtCostRate.TabIndex = 363;
            this.txtCostRate.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(10, 604);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 15);
            this.label8.TabIndex = 364;
            this.label8.Text = "COST RATE";
            // 
            // chkPosted
            // 
            this.chkPosted.AutoSize = true;
            this.chkPosted.Checked = true;
            this.chkPosted.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPosted.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.chkPosted.Location = new System.Drawing.Point(10, 633);
            this.chkPosted.Name = "chkPosted";
            this.chkPosted.Size = new System.Drawing.Size(56, 19);
            this.chkPosted.TabIndex = 365;
            this.chkPosted.TabStop = false;
            this.chkPosted.Text = "POST";
            this.chkPosted.UseVisualStyleBackColor = true;
            // 
            // cmbReference
            // 
            this.cmbReference.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbReference.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbReference.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbReference.FormattingEnabled = true;
            this.cmbReference.Items.AddRange(new object[] {
            "--SELECT SUPPLIER--",
            "AUTOMART"});
            this.cmbReference.Location = new System.Drawing.Point(100, 328);
            this.cmbReference.Name = "cmbReference";
            this.cmbReference.Size = new System.Drawing.Size(280, 25);
            this.cmbReference.TabIndex = 366;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Location = new System.Drawing.Point(10, 333);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 15);
            this.label10.TabIndex = 367;
            this.label10.Text = "REFERENCE";
            // 
            // frm_Sales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(920, 695);
            this.Controls.Add(this.cmbReference);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.chkPosted);
            this.Controls.Add(this.txtCostRate);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnDeliveryChallan);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.txtGST);
            this.Controls.Add(this.GST);
            this.Controls.Add(this.txtBillNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbSO);
            this.Controls.Add(this.chkSO);
            this.Controls.Add(this.rdbCredit);
            this.Controls.Add(this.rdbCash);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNetTotal);
            this.Controls.Add(this.gridProducts);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbProducts);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnViewInvoice);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtRate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCreditDays);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblAcc);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblInvoice);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblV);
            this.Controls.Add(this.cmbCustomer);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.grdSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSEARCH);
            this.Controls.Add(this.pnlHEADER);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_Sales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SALES";
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
        private SergeUtils.EasyCompletionComboBox cmbCustomer;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblInvoice;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblV;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblAcc;
        private System.Windows.Forms.TextBox txtCreditDays;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnViewInvoice;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label label1;
        private SergeUtils.EasyCompletionComboBox cmbProducts;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView gridProducts;
        private System.Windows.Forms.TextBox txtNetTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rdbCash;
        private System.Windows.Forms.RadioButton rdbCredit;
        private System.Windows.Forms.CheckBox chkSO;
        private SergeUtils.EasyCompletionComboBox cmbSO;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBillNo;
        private System.Windows.Forms.TextBox txtGST;
        private System.Windows.Forms.Label GST;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Button btnDeliveryChallan;
        private System.Windows.Forms.TextBox txtCostRate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkPosted;
        private System.Windows.Forms.DataGridViewTextBoxColumn productId;
        private System.Windows.Forms.DataGridViewTextBoxColumn productName;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.DataGridViewTextBoxColumn gstValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn netTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn costRate;
        private SergeUtils.EasyCompletionComboBox cmbReference;
        private System.Windows.Forms.Label label10;
    }
}