namespace ERP_Maaz_Oil.Forms
{
    partial class frmStockIssuance
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStockIssuance));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHEADER = new System.Windows.Forms.Panel();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.lblHEADING = new System.Windows.Forms.Label();
            this.grdSearch = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSEARCH = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnSave = new System.Windows.Forms.Button();
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
            this.txtVehicleNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnInvoice = new System.Windows.Forms.Button();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.grdItems = new System.Windows.Forms.DataGridView();
            this.itemid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modelNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.rdbProduct = new System.Windows.Forms.RadioButton();
            this.rdbRaw = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbItem = new SergeUtils.EasyCompletionComboBox();
            this.btn_VIEW_VOUCHER = new System.Windows.Forms.Button();
            this.pnlHEADER.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems)).BeginInit();
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
            this.pnlHEADER.Size = new System.Drawing.Size(922, 49);
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
            this.lblHEADING.Location = new System.Drawing.Point(6, 12);
            this.lblHEADING.Name = "lblHEADING";
            this.lblHEADING.Size = new System.Drawing.Size(224, 29);
            this.lblHEADING.TabIndex = 23;
            this.lblHEADING.Text = "STOCK ISSUANCE";
            // 
            // grdSearch
            // 
            this.grdSearch.AllowUserToAddRows = false;
            this.grdSearch.AllowUserToDeleteRows = false;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.White;
            this.grdSearch.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.grdSearch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdSearch.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grdSearch.BackgroundColor = System.Drawing.Color.White;
            this.grdSearch.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Segoe UI Semibold", 10.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdSearch.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.grdSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdSearch.DefaultCellStyle = dataGridViewCellStyle15;
            this.grdSearch.Location = new System.Drawing.Point(5, 88);
            this.grdSearch.Name = "grdSearch";
            this.grdSearch.ReadOnly = true;
            this.grdSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSearch.Size = new System.Drawing.Size(911, 165);
            this.grdSearch.TabIndex = 221;
            this.grdSearch.TabStop = false;
            this.grdSearch.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdSEARCH_CellClick);
            this.grdSearch.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.grdSEARCH_DataBindingComplete);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtSearch.Location = new System.Drawing.Point(72, 57);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(844, 25);
            this.txtSearch.TabIndex = 14;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSEARCH_TextChanged);
            // 
            // lblSEARCH
            // 
            this.lblSEARCH.AutoSize = true;
            this.lblSEARCH.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSEARCH.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSEARCH.Location = new System.Drawing.Point(9, 61);
            this.lblSEARCH.Name = "lblSEARCH";
            this.lblSEARCH.Size = new System.Drawing.Size(57, 17);
            this.lblSEARCH.TabIndex = 219;
            this.lblSEARCH.Text = "SEARCH";
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
            this.btnClear.Location = new System.Drawing.Point(255, 556);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(108, 25);
            this.btnClear.TabIndex = 14;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnCLEAR_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icons8-Save as Filled-100.png");
            this.imageList1.Images.SetKeyName(1, "icons8-Cancel Filled-100.png");
            this.imageList1.Images.SetKeyName(2, "icons8-search.png");
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
            this.btnSave.Location = new System.Drawing.Point(126, 556);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(108, 25);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSAVE_Click);
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCustomer.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbCustomer.Items.AddRange(new object[] {
            "--SELECT SUPPLIER--",
            "AUTOMART"});
            this.cmbCustomer.Location = new System.Drawing.Point(126, 314);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(359, 25);
            this.cmbCustomer.TabIndex = 1;
            this.cmbCustomer.SelectedIndexChanged += new System.EventHandler(this.cmbSupplier_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(51, 319);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 15);
            this.label9.TabIndex = 227;
            this.label9.Text = "ACCOUNT:";
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.dtpDate.Location = new System.Drawing.Point(126, 285);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(359, 23);
            this.dtpDate.TabIndex = 0;
            // 
            // lblInvoice
            // 
            this.lblInvoice.AutoSize = true;
            this.lblInvoice.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblInvoice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(215)))));
            this.lblInvoice.Location = new System.Drawing.Point(126, 264);
            this.lblInvoice.Name = "lblInvoice";
            this.lblInvoice.Size = new System.Drawing.Size(103, 15);
            this.lblInvoice.TabIndex = 298;
            this.lblInvoice.Text = "ISSUANCE-1-2017";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblDate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDate.Location = new System.Drawing.Point(81, 289);
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
            this.lblV.Location = new System.Drawing.Point(44, 264);
            this.lblV.Name = "lblV";
            this.lblV.Size = new System.Drawing.Size(76, 15);
            this.lblV.TabIndex = 296;
            this.lblV.Text = "ISSUANCE #:";
            // 
            // txtDescription
            // 
            this.txtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtDescription.Location = new System.Drawing.Point(126, 407);
            this.txtDescription.MaxLength = 32000;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(359, 25);
            this.txtDescription.TabIndex = 5;
            // 
            // lblAcc
            // 
            this.lblAcc.AutoSize = true;
            this.lblAcc.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblAcc.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblAcc.Location = new System.Drawing.Point(34, 412);
            this.lblAcc.Name = "lblAcc";
            this.lblAcc.Size = new System.Drawing.Size(86, 15);
            this.lblAcc.TabIndex = 300;
            this.lblAcc.Text = "DESCRIPTION:";
            // 
            // txtCreditDays
            // 
            this.txtCreditDays.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCreditDays.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtCreditDays.Location = new System.Drawing.Point(126, 376);
            this.txtCreditDays.MaxLength = 11;
            this.txtCreditDays.Name = "txtCreditDays";
            this.txtCreditDays.Size = new System.Drawing.Size(359, 25);
            this.txtCreditDays.TabIndex = 3;
            this.txtCreditDays.Text = "0";
            this.txtCreditDays.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNetWeight_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(40, 381);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 15);
            this.label2.TabIndex = 304;
            this.label2.Text = "CREDIT DAYS";
            // 
            // txtRate
            // 
            this.txtRate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRate.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtRate.Location = new System.Drawing.Point(126, 525);
            this.txtRate.MaxLength = 11;
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(285, 25);
            this.txtRate.TabIndex = 11;
            this.txtRate.Text = "0";
            this.txtRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQty_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(86, 530);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 15);
            this.label3.TabIndex = 306;
            this.label3.Text = "RATE";
            // 
            // txtVehicleNumber
            // 
            this.txtVehicleNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtVehicleNumber.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtVehicleNumber.Location = new System.Drawing.Point(126, 345);
            this.txtVehicleNumber.MaxLength = 32000;
            this.txtVehicleNumber.Name = "txtVehicleNumber";
            this.txtVehicleNumber.Size = new System.Drawing.Size(359, 25);
            this.txtVehicleNumber.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(57, 350);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 15);
            this.label4.TabIndex = 308;
            this.label4.Text = "VEHICLE #";
            // 
            // btnInvoice
            // 
            this.btnInvoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(24)))), ((int)(((byte)(38)))));
            this.btnInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnInvoice.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnInvoice.ForeColor = System.Drawing.Color.White;
            this.btnInvoice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInvoice.ImageIndex = 2;
            this.btnInvoice.ImageList = this.imageList1;
            this.btnInvoice.Location = new System.Drawing.Point(696, 611);
            this.btnInvoice.Name = "btnInvoice";
            this.btnInvoice.Size = new System.Drawing.Size(220, 25);
            this.btnInvoice.TabIndex = 15;
            this.btnInvoice.Text = "VIEW INVOICE";
            this.btnInvoice.UseVisualStyleBackColor = false;
            this.btnInvoice.Click += new System.EventHandler(this.btn_VIEW_VOUCHER_Click);
            // 
            // txtQty
            // 
            this.txtQty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQty.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtQty.Location = new System.Drawing.Point(126, 494);
            this.txtQty.MaxLength = 11;
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(359, 25);
            this.txtQty.TabIndex = 9;
            this.txtQty.Text = "0";
            this.txtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQty_KeyPress);
            this.txtQty.Leave += new System.EventHandler(this.txtQty_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(91, 499);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 15);
            this.label1.TabIndex = 343;
            this.label1.Text = "QTY";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Location = new System.Drawing.Point(85, 468);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 15);
            this.label11.TabIndex = 341;
            this.label11.Text = "ITEM";
            // 
            // grdItems
            // 
            this.grdItems.AllowUserToAddRows = false;
            this.grdItems.AllowUserToDeleteRows = false;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.White;
            this.grdItems.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle16;
            this.grdItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdItems.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grdItems.BackgroundColor = System.Drawing.Color.White;
            this.grdItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Segoe UI Semibold", 10.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.grdItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemid,
            this.itemType,
            this.itemCode,
            this.itemName,
            this.itemQty,
            this.rate,
            this.total,
            this.modelNo});
            this.grdItems.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdItems.DefaultCellStyle = dataGridViewCellStyle18;
            this.grdItems.Location = new System.Drawing.Point(491, 259);
            this.grdItems.Name = "grdItems";
            this.grdItems.ReadOnly = true;
            this.grdItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdItems.Size = new System.Drawing.Size(425, 346);
            this.grdItems.TabIndex = 344;
            this.grdItems.TabStop = false;
            this.grdItems.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdItems_CellClick);
            // 
            // itemid
            // 
            this.itemid.HeaderText = "ID";
            this.itemid.Name = "itemid";
            this.itemid.ReadOnly = true;
            this.itemid.Visible = false;
            this.itemid.Width = 48;
            // 
            // itemType
            // 
            this.itemType.HeaderText = "ITEM TYPE";
            this.itemType.Name = "itemType";
            this.itemType.ReadOnly = true;
            this.itemType.Width = 101;
            // 
            // itemCode
            // 
            this.itemCode.HeaderText = "ITEM CODE";
            this.itemCode.Name = "itemCode";
            this.itemCode.ReadOnly = true;
            this.itemCode.Width = 107;
            // 
            // itemName
            // 
            this.itemName.HeaderText = "ITEM NAME";
            this.itemName.Name = "itemName";
            this.itemName.ReadOnly = true;
            this.itemName.Width = 110;
            // 
            // itemQty
            // 
            this.itemQty.HeaderText = "QUANTITY";
            this.itemQty.Name = "itemQty";
            this.itemQty.ReadOnly = true;
            this.itemQty.Width = 103;
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
            // modelNo
            // 
            this.modelNo.HeaderText = "MODEL NO";
            this.modelNo.Name = "modelNo";
            this.modelNo.ReadOnly = true;
            this.modelNo.Visible = false;
            this.modelNo.Width = 108;
            // 
            // txtTotal
            // 
            this.txtTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotal.Enabled = false;
            this.txtTotal.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtTotal.Location = new System.Drawing.Point(556, 611);
            this.txtTotal.MaxLength = 11;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(134, 25);
            this.txtTotal.TabIndex = 345;
            this.txtTotal.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(491, 616);
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
            this.btnAdd.Location = new System.Drawing.Point(417, 525);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(68, 25);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "ADD";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // rdbProduct
            // 
            this.rdbProduct.AutoSize = true;
            this.rdbProduct.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.rdbProduct.Location = new System.Drawing.Point(194, 438);
            this.rdbProduct.Name = "rdbProduct";
            this.rdbProduct.Size = new System.Drawing.Size(79, 19);
            this.rdbProduct.TabIndex = 6;
            this.rdbProduct.Text = "PRODUCT";
            this.rdbProduct.UseVisualStyleBackColor = true;
          //  this.rdbProduct.CheckedChanged += new System.EventHandler(this.rdbProduct_CheckedChanged);
            // 
            // rdbRaw
            // 
            this.rdbRaw.AutoSize = true;
            this.rdbRaw.Checked = true;
            this.rdbRaw.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.rdbRaw.Location = new System.Drawing.Point(129, 438);
            this.rdbRaw.Name = "rdbRaw";
            this.rdbRaw.Size = new System.Drawing.Size(52, 19);
            this.rdbRaw.TabIndex = 7;
            this.rdbRaw.TabStop = true;
            this.rdbRaw.Text = "RAW";
            this.rdbRaw.UseVisualStyleBackColor = true;
            //this.rdbRaw.CheckedChanged += new System.EventHandler(this.rdbRaw_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(51, 440);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 15);
            this.label6.TabIndex = 350;
            this.label6.Text = "ITEM TYPE";
            // 
            // cmbItem
            // 
            this.cmbItem.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbItem.Items.AddRange(new object[] {
            "--SELECT SUPPLIER--",
            "AUTOMART"});
            this.cmbItem.Location = new System.Drawing.Point(126, 463);
            this.cmbItem.Name = "cmbItem";
            this.cmbItem.Size = new System.Drawing.Size(359, 25);
            this.cmbItem.TabIndex = 8;
            this.cmbItem.SelectedIndexChanged += new System.EventHandler(this.cmbItem_SelectedIndexChanged_1);
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
            this.btn_VIEW_VOUCHER.Location = new System.Drawing.Point(377, 556);
            this.btn_VIEW_VOUCHER.Name = "btn_VIEW_VOUCHER";
            this.btn_VIEW_VOUCHER.Size = new System.Drawing.Size(108, 25);
            this.btn_VIEW_VOUCHER.TabIndex = 356;
            this.btn_VIEW_VOUCHER.Text = "DELETE";
            this.btn_VIEW_VOUCHER.UseVisualStyleBackColor = false;
            this.btn_VIEW_VOUCHER.Click += new System.EventHandler(this.btn_VIEW_VOUCHER_Click_1);
            // 
            // frmStockIssuance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(922, 645);
            this.Controls.Add(this.btn_VIEW_VOUCHER);
            this.Controls.Add(this.cmbItem);
            this.Controls.Add(this.rdbProduct);
            this.Controls.Add(this.rdbRaw);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.grdItems);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnInvoice);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtVehicleNumber);
            this.Controls.Add(this.label4);
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
            this.MaximumSize = new System.Drawing.Size(1314, 703);
            this.Name = "frmStockIssuance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "STOCK ISSUANCE";
            this.Load += new System.EventHandler(this.frm_AddGroupAccounts_Load);
            this.pnlHEADER.ResumeLayout(false);
            this.pnlHEADER.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems)).EndInit();
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
        private System.Windows.Forms.TextBox txtVehicleNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnInvoice;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView grdItems;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.RadioButton rdbProduct;
        private System.Windows.Forms.RadioButton rdbRaw;
        private System.Windows.Forms.Label label6;
        private SergeUtils.EasyCompletionComboBox cmbItem;
        private System.Windows.Forms.Button btn_VIEW_VOUCHER;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemid;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemType;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.DataGridViewTextBoxColumn modelNo;
    }
}