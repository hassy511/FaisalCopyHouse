namespace ERP_Maaz_Oil.Forms
{
    partial class frmSalesDirect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSalesDirect));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHEADER = new System.Windows.Forms.Panel();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.lblHEADING = new System.Windows.Forms.Label();
            this.grdSEARCH = new System.Windows.Forms.DataGridView();
            this.txtSEARCH = new System.Windows.Forms.TextBox();
            this.lblSEARCH = new System.Windows.Forms.Label();
            this.btnCLEAR = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnSAVE = new System.Windows.Forms.Button();
            this.cmbCustomer = new SergeUtils.EasyCompletionComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dtp_DATE = new System.Windows.Forms.DateTimePicker();
            this.lblPRO = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblV = new System.Windows.Forms.Label();
            this.txtDescript = new System.Windows.Forms.TextBox();
            this.lblAcc = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbItem = new SergeUtils.EasyCompletionComboBox();
            this.grdItems = new System.Windows.Forms.DataGridView();
            this.itemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UNIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaterialID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cmbSO = new SergeUtils.EasyCompletionComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotalWeight = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rdbProduct = new System.Windows.Forms.RadioButton();
            this.rdbRaw = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTQty = new System.Windows.Forms.TextBox();
            this.lblTotalQty = new System.Windows.Forms.Label();
            this.btnADD_CITY = new System.Windows.Forms.PictureBox();
            this.txtMuandRateD = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.txtCanolaWeight = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtOlienWeight = new System.Windows.Forms.TextBox();
            this.btnSalesProgram = new System.Windows.Forms.Button();
            this.imageList3 = new System.Windows.Forms.ImageList(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlHEADER.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSEARCH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnADD_CITY)).BeginInit();
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
            this.pnlHEADER.Size = new System.Drawing.Size(922, 88);
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
            this.lblHEADING.Location = new System.Drawing.Point(6, 25);
            this.lblHEADING.Name = "lblHEADING";
            this.lblHEADING.Size = new System.Drawing.Size(184, 29);
            this.lblHEADING.TabIndex = 23;
            this.lblHEADING.Text = "SALES DIRECT";
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
            this.grdSEARCH.Location = new System.Drawing.Point(5, 126);
            this.grdSEARCH.Name = "grdSEARCH";
            this.grdSEARCH.ReadOnly = true;
            this.grdSEARCH.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSEARCH.Size = new System.Drawing.Size(911, 150);
            this.grdSEARCH.TabIndex = 221;
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
            this.txtSEARCH.Location = new System.Drawing.Point(72, 95);
            this.txtSEARCH.Name = "txtSEARCH";
            this.txtSEARCH.Size = new System.Drawing.Size(844, 25);
            this.txtSEARCH.TabIndex = 0;
            this.txtSEARCH.TextChanged += new System.EventHandler(this.txtSEARCH_TextChanged);
            // 
            // lblSEARCH
            // 
            this.lblSEARCH.AutoSize = true;
            this.lblSEARCH.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSEARCH.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSEARCH.Location = new System.Drawing.Point(9, 99);
            this.lblSEARCH.Name = "lblSEARCH";
            this.lblSEARCH.Size = new System.Drawing.Size(57, 17);
            this.lblSEARCH.TabIndex = 219;
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
            this.btnCLEAR.Location = new System.Drawing.Point(261, 598);
            this.btnCLEAR.Name = "btnCLEAR";
            this.btnCLEAR.Size = new System.Drawing.Size(124, 25);
            this.btnCLEAR.TabIndex = 10;
            this.btnCLEAR.Text = "CLEAR";
            this.btnCLEAR.UseVisualStyleBackColor = false;
            this.btnCLEAR.Click += new System.EventHandler(this.btnCLEAR_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icons8-Save as Filled-100.png");
            this.imageList1.Images.SetKeyName(1, "icons8-Cancel Filled-100.png");
            // 
            // btnSAVE
            // 
            this.btnSAVE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(68)))), ((int)(((byte)(2)))));
            this.btnSAVE.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSAVE.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSAVE.ForeColor = System.Drawing.Color.White;
            this.btnSAVE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSAVE.ImageIndex = 0;
            this.btnSAVE.ImageList = this.imageList1;
            this.btnSAVE.Location = new System.Drawing.Point(118, 598);
            this.btnSAVE.Name = "btnSAVE";
            this.btnSAVE.Size = new System.Drawing.Size(124, 25);
            this.btnSAVE.TabIndex = 9;
            this.btnSAVE.Text = "SAVE";
            this.btnSAVE.UseVisualStyleBackColor = false;
            this.btnSAVE.Click += new System.EventHandler(this.btnSAVE_Click);
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
            this.cmbCustomer.Location = new System.Drawing.Point(118, 330);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(267, 25);
            this.cmbCustomer.TabIndex = 226;
            this.cmbCustomer.SelectedIndexChanged += new System.EventHandler(this.cmbCustomer_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(9, 335);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 15);
            this.label9.TabIndex = 227;
            this.label9.Text = "CUSTOMER";
            // 
            // dtp_DATE
            // 
            this.dtp_DATE.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.dtp_DATE.Location = new System.Drawing.Point(118, 301);
            this.dtp_DATE.Name = "dtp_DATE";
            this.dtp_DATE.Size = new System.Drawing.Size(267, 23);
            this.dtp_DATE.TabIndex = 295;
            // 
            // lblPRO
            // 
            this.lblPRO.AutoSize = true;
            this.lblPRO.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblPRO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(215)))));
            this.lblPRO.Location = new System.Drawing.Point(115, 283);
            this.lblPRO.Name = "lblPRO";
            this.lblPRO.Size = new System.Drawing.Size(70, 15);
            this.lblPRO.TabIndex = 298;
            this.lblPRO.Text = "PRO-1-2017";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblDate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDate.Location = new System.Drawing.Point(9, 305);
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
            this.lblV.Location = new System.Drawing.Point(9, 283);
            this.lblV.Name = "lblV";
            this.lblV.Size = new System.Drawing.Size(35, 15);
            this.lblV.TabIndex = 296;
            this.lblV.Text = "GP #:";
            // 
            // txtDescript
            // 
            this.txtDescript.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescript.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtDescript.Location = new System.Drawing.Point(118, 423);
            this.txtDescript.MaxLength = 100;
            this.txtDescript.Multiline = true;
            this.txtDescript.Name = "txtDescript";
            this.txtDescript.Size = new System.Drawing.Size(267, 26);
            this.txtDescript.TabIndex = 299;
            // 
            // lblAcc
            // 
            this.lblAcc.AutoSize = true;
            this.lblAcc.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblAcc.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblAcc.Location = new System.Drawing.Point(9, 429);
            this.lblAcc.Name = "lblAcc";
            this.lblAcc.Size = new System.Drawing.Size(83, 15);
            this.lblAcc.TabIndex = 300;
            this.lblAcc.Text = "DESCRIPTION";
            // 
            // txtTotal
            // 
            this.txtTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotal.Enabled = false;
            this.txtTotal.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtTotal.Location = new System.Drawing.Point(728, 567);
            this.txtTotal.MaxLength = 11;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(188, 25);
            this.txtTotal.TabIndex = 305;
            this.txtTotal.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(625, 573);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 15);
            this.label3.TabIndex = 306;
            this.label3.Text = "TOTAL AMOUNT";
            // 
            // txtQuantity
            // 
            this.txtQuantity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQuantity.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtQuantity.Location = new System.Drawing.Point(118, 536);
            this.txtQuantity.MaxLength = 11;
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(267, 25);
            this.txtQuantity.TabIndex = 309;
            this.txtQuantity.Text = "0";
            this.txtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNetWeight_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(9, 541);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 15);
            this.label5.TabIndex = 310;
            this.label5.Text = "QUANTITY";
            // 
            // txtRate
            // 
            this.txtRate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRate.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtRate.Location = new System.Drawing.Point(118, 567);
            this.txtRate.MaxLength = 11;
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(187, 25);
            this.txtRate.TabIndex = 318;
            this.txtRate.Text = "0";
            this.txtRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNetWeight_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Location = new System.Drawing.Point(9, 572);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 15);
            this.label10.TabIndex = 319;
            this.label10.Text = "RATE";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Location = new System.Drawing.Point(9, 510);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 15);
            this.label11.TabIndex = 322;
            this.label11.Text = "SELECT ITEM";
            // 
            // cmbItem
            // 
            this.cmbItem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbItem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbItem.Enabled = false;
            this.cmbItem.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbItem.FormattingEnabled = true;
            this.cmbItem.Items.AddRange(new object[] {
            "--SELECT SUPPLIER--",
            "AUTOMART"});
            this.cmbItem.Location = new System.Drawing.Point(118, 505);
            this.cmbItem.Name = "cmbItem";
            this.cmbItem.Size = new System.Drawing.Size(242, 25);
            this.cmbItem.TabIndex = 323;
            this.cmbItem.SelectedIndexChanged += new System.EventHandler(this.cmbItem_SelectedIndexChanged);
            // 
            // grdItems
            // 
            this.grdItems.AllowUserToAddRows = false;
            this.grdItems.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.grdItems.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.grdItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdItems.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grdItems.BackgroundColor = System.Drawing.Color.White;
            this.grdItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Semibold", 10.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.grdItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemId,
            this.itemName,
            this.qty,
            this.rate,
            this.weight,
            this.UNIT,
            this.total,
            this.itemType,
            this.MaterialID});
            this.grdItems.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdItems.DefaultCellStyle = dataGridViewCellStyle6;
            this.grdItems.Location = new System.Drawing.Point(388, 314);
            this.grdItems.Name = "grdItems";
            this.grdItems.ReadOnly = true;
            this.grdItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdItems.Size = new System.Drawing.Size(528, 216);
            this.grdItems.TabIndex = 324;
            this.grdItems.TabStop = false;
            this.grdItems.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdItems_CellClick);
            this.grdItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdItems_CellContentClick);
            // 
            // itemId
            // 
            this.itemId.HeaderText = "itemId";
            this.itemId.Name = "itemId";
            this.itemId.ReadOnly = true;
            this.itemId.Visible = false;
            this.itemId.Width = 74;
            // 
            // itemName
            // 
            this.itemName.HeaderText = "PRODUCT";
            this.itemName.Name = "itemName";
            this.itemName.ReadOnly = true;
            this.itemName.Width = 99;
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
            // weight
            // 
            this.weight.HeaderText = "WEIGHT";
            this.weight.Name = "weight";
            this.weight.ReadOnly = true;
            this.weight.Width = 87;
            // 
            // UNIT
            // 
            this.UNIT.HeaderText = "UNIT";
            this.UNIT.Name = "UNIT";
            this.UNIT.ReadOnly = true;
            this.UNIT.Width = 67;
            // 
            // total
            // 
            this.total.HeaderText = "TOTAL";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            this.total.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.total.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.total.Width = 55;
            // 
            // itemType
            // 
            this.itemType.HeaderText = "ITEM TYPE";
            this.itemType.Name = "itemType";
            this.itemType.ReadOnly = true;
            this.itemType.Visible = false;
            this.itemType.Width = 101;
            // 
            // MaterialID
            // 
            this.MaterialID.HeaderText = "MaterialID";
            this.MaterialID.Name = "MaterialID";
            this.MaterialID.ReadOnly = true;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(68)))), ((int)(((byte)(2)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.ImageIndex = 0;
            this.btnAdd.ImageList = this.imageList1;
            this.btnAdd.Location = new System.Drawing.Point(311, 567);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(74, 25);
            this.btnAdd.TabIndex = 325;
            this.btnAdd.Text = "ADD";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cmbSO
            // 
            this.cmbSO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSO.Enabled = false;
            this.cmbSO.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbSO.FormattingEnabled = true;
            this.cmbSO.Items.AddRange(new object[] {
            "--SELECT SUPPLIER--",
            "AUTOMART"});
            this.cmbSO.Location = new System.Drawing.Point(118, 361);
            this.cmbSO.Name = "cmbSO";
            this.cmbSO.Size = new System.Drawing.Size(267, 25);
            this.cmbSO.TabIndex = 326;
            this.cmbSO.SelectedIndexChanged += new System.EventHandler(this.cmbSO_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(9, 366);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 15);
            this.label1.TabIndex = 327;
            this.label1.Text = "SELECT S.O #";
            // 
            // txtTotalWeight
            // 
            this.txtTotalWeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotalWeight.Enabled = false;
            this.txtTotalWeight.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtTotalWeight.Location = new System.Drawing.Point(503, 598);
            this.txtTotalWeight.MaxLength = 11;
            this.txtTotalWeight.Name = "txtTotalWeight";
            this.txtTotalWeight.ReadOnly = true;
            this.txtTotalWeight.Size = new System.Drawing.Size(116, 25);
            this.txtTotalWeight.TabIndex = 330;
            this.txtTotalWeight.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(391, 604);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 15);
            this.label4.TabIndex = 331;
            this.label4.Text = "TOTAL WEIGHT";
            // 
            // rdbProduct
            // 
            this.rdbProduct.AutoSize = true;
            this.rdbProduct.Checked = true;
            this.rdbProduct.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.rdbProduct.Location = new System.Drawing.Point(183, 484);
            this.rdbProduct.Name = "rdbProduct";
            this.rdbProduct.Size = new System.Drawing.Size(79, 19);
            this.rdbProduct.TabIndex = 346;
            this.rdbProduct.TabStop = true;
            this.rdbProduct.Text = "PRODUCT";
            this.rdbProduct.UseVisualStyleBackColor = true;
            this.rdbProduct.CheckedChanged += new System.EventHandler(this.rdbProduct_CheckedChanged);
            // 
            // rdbRaw
            // 
            this.rdbRaw.AutoSize = true;
            this.rdbRaw.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.rdbRaw.Location = new System.Drawing.Point(118, 484);
            this.rdbRaw.Name = "rdbRaw";
            this.rdbRaw.Size = new System.Drawing.Size(52, 19);
            this.rdbRaw.TabIndex = 345;
            this.rdbRaw.Text = "RAW";
            this.rdbRaw.UseVisualStyleBackColor = true;
            this.rdbRaw.CheckedChanged += new System.EventHandler(this.rdbRaw_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(9, 486);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 15);
            this.label6.TabIndex = 344;
            this.label6.Text = "SALES TYPE";
            // 
            // txtTQty
            // 
            this.txtTQty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTQty.Enabled = false;
            this.txtTQty.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtTQty.Location = new System.Drawing.Point(728, 536);
            this.txtTQty.MaxLength = 11;
            this.txtTQty.Name = "txtTQty";
            this.txtTQty.ReadOnly = true;
            this.txtTQty.Size = new System.Drawing.Size(188, 25);
            this.txtTQty.TabIndex = 351;
            this.txtTQty.Text = "0";
            this.txtTQty.TextChanged += new System.EventHandler(this.txtTQty_TextChanged);
            // 
            // lblTotalQty
            // 
            this.lblTotalQty.AutoSize = true;
            this.lblTotalQty.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblTotalQty.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTotalQty.Location = new System.Drawing.Point(625, 541);
            this.lblTotalQty.Name = "lblTotalQty";
            this.lblTotalQty.Size = new System.Drawing.Size(67, 15);
            this.lblTotalQty.TabIndex = 352;
            this.lblTotalQty.Text = "TOTAL QTY";
            // 
            // btnADD_CITY
            // 
            this.btnADD_CITY.BackColor = System.Drawing.Color.Transparent;
            this.btnADD_CITY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnADD_CITY.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnADD_CITY.Image = global::ERP_Maaz_Oil.Properties.Resources.plus;
            this.btnADD_CITY.Location = new System.Drawing.Point(360, 505);
            this.btnADD_CITY.Name = "btnADD_CITY";
            this.btnADD_CITY.Size = new System.Drawing.Size(25, 25);
            this.btnADD_CITY.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnADD_CITY.TabIndex = 355;
            this.btnADD_CITY.TabStop = false;
            this.btnADD_CITY.Click += new System.EventHandler(this.btnADD_CITY_Click);
            // 
            // txtMuandRateD
            // 
            this.txtMuandRateD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMuandRateD.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtMuandRateD.Location = new System.Drawing.Point(118, 455);
            this.txtMuandRateD.MaxLength = 100;
            this.txtMuandRateD.Multiline = true;
            this.txtMuandRateD.Name = "txtMuandRateD";
            this.txtMuandRateD.Size = new System.Drawing.Size(267, 25);
            this.txtMuandRateD.TabIndex = 356;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(9, 460);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 15);
            this.label7.TabIndex = 357;
            this.label7.Text = "MUAND RATE";
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "icons8-Save as Filled-100.png");
            this.imageList2.Images.SetKeyName(1, "icons8-Cancel Filled-100.png");
            this.imageList2.Images.SetKeyName(2, "icons8-search.png");
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label12.Location = new System.Drawing.Point(391, 572);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(103, 15);
            this.label12.TabIndex = 331;
            this.label12.Text = "CANOLA WEIGHT";
            // 
            // txtCanolaWeight
            // 
            this.txtCanolaWeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCanolaWeight.Enabled = false;
            this.txtCanolaWeight.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtCanolaWeight.Location = new System.Drawing.Point(503, 567);
            this.txtCanolaWeight.MaxLength = 11;
            this.txtCanolaWeight.Name = "txtCanolaWeight";
            this.txtCanolaWeight.ReadOnly = true;
            this.txtCanolaWeight.Size = new System.Drawing.Size(116, 25);
            this.txtCanolaWeight.TabIndex = 330;
            this.txtCanolaWeight.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label13.Location = new System.Drawing.Point(391, 541);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(90, 15);
            this.label13.TabIndex = 352;
            this.label13.Text = "OLIEN WEIGHT";
            // 
            // txtOlienWeight
            // 
            this.txtOlienWeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOlienWeight.Enabled = false;
            this.txtOlienWeight.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtOlienWeight.Location = new System.Drawing.Point(503, 536);
            this.txtOlienWeight.MaxLength = 11;
            this.txtOlienWeight.Name = "txtOlienWeight";
            this.txtOlienWeight.ReadOnly = true;
            this.txtOlienWeight.Size = new System.Drawing.Size(116, 25);
            this.txtOlienWeight.TabIndex = 351;
            this.txtOlienWeight.Text = "0";
            this.txtOlienWeight.TextChanged += new System.EventHandler(this.txtTQty_TextChanged);
            // 
            // btnSalesProgram
            // 
            this.btnSalesProgram.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(24)))), ((int)(((byte)(38)))));
            this.btnSalesProgram.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSalesProgram.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSalesProgram.ForeColor = System.Drawing.Color.White;
            this.btnSalesProgram.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalesProgram.ImageIndex = 2;
            this.btnSalesProgram.ImageList = this.imageList3;
            this.btnSalesProgram.Location = new System.Drawing.Point(728, 283);
            this.btnSalesProgram.Name = "btnSalesProgram";
            this.btnSalesProgram.Size = new System.Drawing.Size(188, 25);
            this.btnSalesProgram.TabIndex = 367;
            this.btnSalesProgram.Text = "VIEW SALES INVOICE";
            this.btnSalesProgram.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalesProgram.UseVisualStyleBackColor = false;
            this.btnSalesProgram.Click += new System.EventHandler(this.btnSalesProgram_Click);
            // 
            // imageList3
            // 
            this.imageList3.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList3.ImageStream")));
            this.imageList3.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList3.Images.SetKeyName(0, "icons8-Save as Filled-100.png");
            this.imageList3.Images.SetKeyName(1, "icons8-Cancel Filled-100.png");
            this.imageList3.Images.SetKeyName(2, "icons8-search.png");
            // 
            // textBox1
            // 
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.textBox1.Location = new System.Drawing.Point(118, 392);
            this.textBox1.MaxLength = 100;
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(267, 25);
            this.textBox1.TabIndex = 368;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(9, 397);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 15);
            this.label8.TabIndex = 369;
            this.label8.Text = "VEHICLE #";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(24)))), ((int)(((byte)(38)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.ImageIndex = 2;
            this.button1.ImageList = this.imageList3;
            this.button1.Location = new System.Drawing.Point(534, 283);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(188, 25);
            this.button1.TabIndex = 370;
            this.button1.Text = "VIEW GATE PASS";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // frmSalesDirect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(922, 630);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnSalesProgram);
            this.Controls.Add(this.txtMuandRateD);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnADD_CITY);
            this.Controls.Add(this.txtOlienWeight);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtTQty);
            this.Controls.Add(this.lblTotalQty);
            this.Controls.Add(this.rdbProduct);
            this.Controls.Add(this.rdbRaw);
            this.Controls.Add(this.txtCanolaWeight);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtTotalWeight);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbSO);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.grdItems);
            this.Controls.Add(this.cmbItem);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtRate);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnCLEAR);
            this.Controls.Add(this.btnSAVE);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDescript);
            this.Controls.Add(this.lblAcc);
            this.Controls.Add(this.dtp_DATE);
            this.Controls.Add(this.lblPRO);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblV);
            this.Controls.Add(this.cmbCustomer);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.grdSEARCH);
            this.Controls.Add(this.txtSEARCH);
            this.Controls.Add(this.lblSEARCH);
            this.Controls.Add(this.pnlHEADER);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1314, 703);
            this.Name = "frmSalesDirect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SALES DIRECT";
            this.Load += new System.EventHandler(this.frm_AddGroupAccounts_Load);
            this.pnlHEADER.ResumeLayout(false);
            this.pnlHEADER.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSEARCH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnADD_CITY)).EndInit();
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
        private System.Windows.Forms.Button btnCLEAR;
        private System.Windows.Forms.Button btnSAVE;
        private System.Windows.Forms.ImageList imageList1;
        private SergeUtils.EasyCompletionComboBox cmbCustomer;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtp_DATE;
        private System.Windows.Forms.Label lblPRO;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblV;
        private System.Windows.Forms.TextBox txtDescript;
        private System.Windows.Forms.Label lblAcc;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private SergeUtils.EasyCompletionComboBox cmbItem;
        private System.Windows.Forms.DataGridView grdItems;
        private System.Windows.Forms.Button btnAdd;
        private SergeUtils.EasyCompletionComboBox cmbSO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTotalWeight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rdbProduct;
        private System.Windows.Forms.RadioButton rdbRaw;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTQty;
        private System.Windows.Forms.Label lblTotalQty;
        private System.Windows.Forms.PictureBox btnADD_CITY;
        private System.Windows.Forms.TextBox txtMuandRateD;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCanolaWeight;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtOlienWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn UNIT;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemType;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaterialID;
        private System.Windows.Forms.Button btnSalesProgram;
        private System.Windows.Forms.ImageList imageList3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
    }
}