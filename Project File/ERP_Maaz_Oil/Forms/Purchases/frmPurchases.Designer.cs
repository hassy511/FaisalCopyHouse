namespace ERP_Maaz_Oil.Forms
{
    partial class frmPurchases
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPurchases));
            this.pnlHEADER = new System.Windows.Forms.Panel();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.lblHEADING = new System.Windows.Forms.Label();
            this.grdSEARCH = new System.Windows.Forms.DataGridView();
            this.txtSEARCH = new System.Windows.Forms.TextBox();
            this.lblSEARCH = new System.Windows.Forms.Label();
            this.btnCLEAR = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnSAVE = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPurchaseOrder = new SergeUtils.EasyCompletionComboBox();
            this.cmbSupplier = new SergeUtils.EasyCompletionComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dtp_DATE = new System.Windows.Forms.DateTimePicker();
            this.lblPI = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblV = new System.Windows.Forms.Label();
            this.txtDescript = new System.Windows.Forms.TextBox();
            this.lblAcc = new System.Windows.Forms.Label();
            this.txtCreditDays = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVehNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNetWeight = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtKorangiWeight = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMuandRate = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtKgRate = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtMaterialType = new System.Windows.Forms.TextBox();
            this.txtMaterial = new System.Windows.Forms.TextBox();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.txtMuandValue = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_VIEW_VOUCHER = new System.Windows.Forms.Button();
            this.txtOrderWeight = new System.Windows.Forms.TextBox();
            this.lblOrderedWeight = new System.Windows.Forms.Label();
            this.btnDetailReport = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtBalanceWeight = new System.Windows.Forms.TextBox();
            this.lblBalanceWeight = new System.Windows.Forms.Label();
            this.txtPODate = new System.Windows.Forms.TextBox();
            this.lblPODate = new System.Windows.Forms.Label();
            this.pnlHEADER.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSEARCH)).BeginInit();
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
            this.lblHEADING.Size = new System.Drawing.Size(160, 29);
            this.lblHEADING.TabIndex = 23;
            this.lblHEADING.Text = "PURCHASES";
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
            this.grdSEARCH.Size = new System.Drawing.Size(911, 165);
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
            this.btnCLEAR.Location = new System.Drawing.Point(744, 545);
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
            this.imageList1.Images.SetKeyName(2, "icons8-search.png");
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
            this.btnSAVE.Location = new System.Drawing.Point(588, 545);
            this.btnSAVE.Name = "btnSAVE";
            this.btnSAVE.Size = new System.Drawing.Size(124, 25);
            this.btnSAVE.TabIndex = 9;
            this.btnSAVE.Text = "SAVE";
            this.btnSAVE.UseVisualStyleBackColor = false;
            this.btnSAVE.Click += new System.EventHandler(this.btnSAVE_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(9, 395);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 15);
            this.label1.TabIndex = 212;
            this.label1.Text = "PURCHASES ORDER";
            // 
            // cmbPurchaseOrder
            // 
            this.cmbPurchaseOrder.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbPurchaseOrder.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPurchaseOrder.Enabled = false;
            this.cmbPurchaseOrder.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbPurchaseOrder.FormattingEnabled = true;
            this.cmbPurchaseOrder.Items.AddRange(new object[] {
            "--SELECT PURCHASES ORDER--",
            "P.O-1-2017"});
            this.cmbPurchaseOrder.Location = new System.Drawing.Point(129, 390);
            this.cmbPurchaseOrder.Name = "cmbPurchaseOrder";
            this.cmbPurchaseOrder.Size = new System.Drawing.Size(250, 25);
            this.cmbPurchaseOrder.TabIndex = 1;
            this.cmbPurchaseOrder.DropDown += new System.EventHandler(this.cmbCITY_DropDown);
            this.cmbPurchaseOrder.SelectedIndexChanged += new System.EventHandler(this.cmbPACCOUNT_SelectedIndexChanged);
            this.cmbPurchaseOrder.TextUpdate += new System.EventHandler(this.cmbVENDOR_TextUpdate);
            this.cmbPurchaseOrder.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmbCITY_PreviewKeyDown);
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
            this.cmbSupplier.Location = new System.Drawing.Point(129, 359);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(280, 25);
            this.cmbSupplier.TabIndex = 226;
            this.cmbSupplier.SelectedIndexChanged += new System.EventHandler(this.cmbSupplier_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(9, 364);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 15);
            this.label9.TabIndex = 227;
            this.label9.Text = "SUPPLIER";
            // 
            // dtp_DATE
            // 
            this.dtp_DATE.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.dtp_DATE.Location = new System.Drawing.Point(129, 330);
            this.dtp_DATE.Name = "dtp_DATE";
            this.dtp_DATE.Size = new System.Drawing.Size(280, 23);
            this.dtp_DATE.TabIndex = 295;
            // 
            // lblPI
            // 
            this.lblPI.AutoSize = true;
            this.lblPI.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblPI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(215)))));
            this.lblPI.Location = new System.Drawing.Point(129, 304);
            this.lblPI.Name = "lblPI";
            this.lblPI.Size = new System.Drawing.Size(58, 15);
            this.lblPI.TabIndex = 298;
            this.lblPI.Text = "PI-1-2017";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblDate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDate.Location = new System.Drawing.Point(9, 334);
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
            this.lblV.Location = new System.Drawing.Point(9, 304);
            this.lblV.Name = "lblV";
            this.lblV.Size = new System.Drawing.Size(32, 15);
            this.lblV.TabIndex = 296;
            this.lblV.Text = "P.I #:";
            // 
            // txtDescript
            // 
            this.txtDescript.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescript.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtDescript.Location = new System.Drawing.Point(588, 514);
            this.txtDescript.MaxLength = 100;
            this.txtDescript.Multiline = true;
            this.txtDescript.Name = "txtDescript";
            this.txtDescript.Size = new System.Drawing.Size(280, 25);
            this.txtDescript.TabIndex = 299;
            // 
            // lblAcc
            // 
            this.lblAcc.AutoSize = true;
            this.lblAcc.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblAcc.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblAcc.Location = new System.Drawing.Point(474, 519);
            this.lblAcc.Name = "lblAcc";
            this.lblAcc.Size = new System.Drawing.Size(86, 15);
            this.lblAcc.TabIndex = 300;
            this.lblAcc.Text = "DESCRIPTION:";
            // 
            // txtCreditDays
            // 
            this.txtCreditDays.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCreditDays.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtCreditDays.Location = new System.Drawing.Point(588, 483);
            this.txtCreditDays.MaxLength = 11;
            this.txtCreditDays.Name = "txtCreditDays";
            this.txtCreditDays.Size = new System.Drawing.Size(280, 25);
            this.txtCreditDays.TabIndex = 303;
            this.txtCreditDays.Text = "0";
            this.txtCreditDays.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNetWeight_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(474, 488);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 15);
            this.label2.TabIndex = 304;
            this.label2.Text = "CREDIT DAYS";
            // 
            // txtTotal
            // 
            this.txtTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotal.Enabled = false;
            this.txtTotal.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtTotal.Location = new System.Drawing.Point(588, 452);
            this.txtTotal.MaxLength = 11;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(280, 25);
            this.txtTotal.TabIndex = 305;
            this.txtTotal.Text = "0";
            this.txtTotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNetWeight_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(474, 457);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 15);
            this.label3.TabIndex = 306;
            this.label3.Text = "TOTAL";
            // 
            // txtVehNumber
            // 
            this.txtVehNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtVehNumber.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtVehNumber.Location = new System.Drawing.Point(129, 576);
            this.txtVehNumber.MaxLength = 11;
            this.txtVehNumber.Name = "txtVehNumber";
            this.txtVehNumber.Size = new System.Drawing.Size(280, 25);
            this.txtVehNumber.TabIndex = 307;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(9, 581);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 15);
            this.label4.TabIndex = 308;
            this.label4.Text = "VEHICLE #";
            // 
            // txtNetWeight
            // 
            this.txtNetWeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNetWeight.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtNetWeight.Location = new System.Drawing.Point(588, 299);
            this.txtNetWeight.MaxLength = 11;
            this.txtNetWeight.Name = "txtNetWeight";
            this.txtNetWeight.Size = new System.Drawing.Size(200, 25);
            this.txtNetWeight.TabIndex = 309;
            this.txtNetWeight.Text = "0";
            this.txtNetWeight.TextChanged += new System.EventHandler(this.txtNetWeight_TextChanged);
            this.txtNetWeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNetWeight_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(474, 304);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 15);
            this.label5.TabIndex = 310;
            this.label5.Text = "RECIVED WEIGHT";
            // 
            // txtKorangiWeight
            // 
            this.txtKorangiWeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtKorangiWeight.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtKorangiWeight.Location = new System.Drawing.Point(588, 329);
            this.txtKorangiWeight.MaxLength = 11;
            this.txtKorangiWeight.Name = "txtKorangiWeight";
            this.txtKorangiWeight.Size = new System.Drawing.Size(280, 25);
            this.txtKorangiWeight.TabIndex = 311;
            this.txtKorangiWeight.Text = "0";
            this.txtKorangiWeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNetWeight_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(474, 334);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 15);
            this.label6.TabIndex = 312;
            this.label6.Text = "TERMINAL WEIGHT";
            // 
            // txtMuandRate
            // 
            this.txtMuandRate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMuandRate.Enabled = false;
            this.txtMuandRate.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtMuandRate.Location = new System.Drawing.Point(588, 390);
            this.txtMuandRate.MaxLength = 11;
            this.txtMuandRate.Name = "txtMuandRate";
            this.txtMuandRate.Size = new System.Drawing.Size(280, 25);
            this.txtMuandRate.TabIndex = 313;
            this.txtMuandRate.Text = "0";
            this.txtMuandRate.TextChanged += new System.EventHandler(this.txtMuandRate_TextChanged);
            this.txtMuandRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNetWeight_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(474, 395);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 15);
            this.label7.TabIndex = 314;
            this.label7.Text = "MAUND RATE";
            // 
            // txtKgRate
            // 
            this.txtKgRate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtKgRate.Enabled = false;
            this.txtKgRate.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtKgRate.Location = new System.Drawing.Point(588, 359);
            this.txtKgRate.MaxLength = 11;
            this.txtKgRate.Name = "txtKgRate";
            this.txtKgRate.Size = new System.Drawing.Size(280, 25);
            this.txtKgRate.TabIndex = 318;
            this.txtKgRate.Text = "0";
            this.txtKgRate.TextChanged += new System.EventHandler(this.txtKgRate_TextChanged);
            this.txtKgRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNetWeight_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Location = new System.Drawing.Point(474, 364);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 15);
            this.label10.TabIndex = 319;
            this.label10.Text = "KG RATE";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Location = new System.Drawing.Point(9, 488);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 15);
            this.label11.TabIndex = 322;
            this.label11.Text = "MATERIAL";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label12.Location = new System.Drawing.Point(9, 457);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 15);
            this.label12.TabIndex = 323;
            this.label12.Text = "MATERIAL TYPE";
            // 
            // txtMaterialType
            // 
            this.txtMaterialType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMaterialType.Enabled = false;
            this.txtMaterialType.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtMaterialType.Location = new System.Drawing.Point(129, 452);
            this.txtMaterialType.MaxLength = 11;
            this.txtMaterialType.Name = "txtMaterialType";
            this.txtMaterialType.Size = new System.Drawing.Size(280, 25);
            this.txtMaterialType.TabIndex = 324;
            // 
            // txtMaterial
            // 
            this.txtMaterial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMaterial.Enabled = false;
            this.txtMaterial.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtMaterial.Location = new System.Drawing.Point(129, 483);
            this.txtMaterial.MaxLength = 11;
            this.txtMaterial.Name = "txtMaterial";
            this.txtMaterial.Size = new System.Drawing.Size(280, 25);
            this.txtMaterial.TabIndex = 325;
            // 
            // txtUnit
            // 
            this.txtUnit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUnit.Enabled = false;
            this.txtUnit.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtUnit.Location = new System.Drawing.Point(786, 299);
            this.txtUnit.MaxLength = 11;
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(82, 25);
            this.txtUnit.TabIndex = 329;
            this.txtUnit.Text = "KGS";
            // 
            // txtMuandValue
            // 
            this.txtMuandValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMuandValue.Enabled = false;
            this.txtMuandValue.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtMuandValue.Location = new System.Drawing.Point(588, 421);
            this.txtMuandValue.MaxLength = 11;
            this.txtMuandValue.Name = "txtMuandValue";
            this.txtMuandValue.Size = new System.Drawing.Size(280, 25);
            this.txtMuandValue.TabIndex = 330;
            this.txtMuandValue.Text = "0";
            this.txtMuandValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNetWeight_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(474, 426);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 15);
            this.label8.TabIndex = 331;
            this.label8.Text = "MAUND VALUE";
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
            this.btn_VIEW_VOUCHER.Location = new System.Drawing.Point(588, 576);
            this.btn_VIEW_VOUCHER.Name = "btn_VIEW_VOUCHER";
            this.btn_VIEW_VOUCHER.Size = new System.Drawing.Size(280, 25);
            this.btn_VIEW_VOUCHER.TabIndex = 339;
            this.btn_VIEW_VOUCHER.Text = "VIEW PURCHASES INVOICE";
            this.btn_VIEW_VOUCHER.UseVisualStyleBackColor = false;
            this.btn_VIEW_VOUCHER.Click += new System.EventHandler(this.btn_VIEW_VOUCHER_Click);
            // 
            // txtOrderWeight
            // 
            this.txtOrderWeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOrderWeight.Enabled = false;
            this.txtOrderWeight.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtOrderWeight.Location = new System.Drawing.Point(129, 514);
            this.txtOrderWeight.MaxLength = 11;
            this.txtOrderWeight.Name = "txtOrderWeight";
            this.txtOrderWeight.Size = new System.Drawing.Size(280, 25);
            this.txtOrderWeight.TabIndex = 340;
            this.txtOrderWeight.Text = "0";
            // 
            // lblOrderedWeight
            // 
            this.lblOrderedWeight.AutoSize = true;
            this.lblOrderedWeight.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblOrderedWeight.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblOrderedWeight.Location = new System.Drawing.Point(9, 519);
            this.lblOrderedWeight.Name = "lblOrderedWeight";
            this.lblOrderedWeight.Size = new System.Drawing.Size(94, 15);
            this.lblOrderedWeight.TabIndex = 341;
            this.lblOrderedWeight.Text = "ORDER WEIGHT";
            // 
            // btnDetailReport
            // 
            this.btnDetailReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(24)))), ((int)(((byte)(38)))));
            this.btnDetailReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDetailReport.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnDetailReport.ForeColor = System.Drawing.Color.White;
            this.btnDetailReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetailReport.ImageIndex = 2;
            this.btnDetailReport.ImageList = this.imageList1;
            this.btnDetailReport.Location = new System.Drawing.Point(379, 390);
            this.btnDetailReport.Name = "btnDetailReport";
            this.btnDetailReport.Size = new System.Drawing.Size(30, 25);
            this.btnDetailReport.TabIndex = 342;
            this.btnDetailReport.UseVisualStyleBackColor = false;
            this.btnDetailReport.Click += new System.EventHandler(this.btnDetailReport_Click);
            // 
            // textBox1
            // 
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.textBox1.Location = new System.Drawing.Point(327, 545);
            this.textBox1.MaxLength = 11;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(82, 25);
            this.textBox1.TabIndex = 345;
            this.textBox1.Text = "KGS";
            // 
            // txtBalanceWeight
            // 
            this.txtBalanceWeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBalanceWeight.Enabled = false;
            this.txtBalanceWeight.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtBalanceWeight.Location = new System.Drawing.Point(129, 545);
            this.txtBalanceWeight.MaxLength = 11;
            this.txtBalanceWeight.Name = "txtBalanceWeight";
            this.txtBalanceWeight.Size = new System.Drawing.Size(200, 25);
            this.txtBalanceWeight.TabIndex = 343;
            this.txtBalanceWeight.Text = "0";
            // 
            // lblBalanceWeight
            // 
            this.lblBalanceWeight.AutoSize = true;
            this.lblBalanceWeight.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblBalanceWeight.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblBalanceWeight.Location = new System.Drawing.Point(9, 550);
            this.lblBalanceWeight.Name = "lblBalanceWeight";
            this.lblBalanceWeight.Size = new System.Drawing.Size(107, 15);
            this.lblBalanceWeight.TabIndex = 344;
            this.lblBalanceWeight.Text = "BALANCE WEIGHT";
            // 
            // txtPODate
            // 
            this.txtPODate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPODate.Enabled = false;
            this.txtPODate.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtPODate.Location = new System.Drawing.Point(129, 421);
            this.txtPODate.MaxLength = 11;
            this.txtPODate.Name = "txtPODate";
            this.txtPODate.Size = new System.Drawing.Size(280, 25);
            this.txtPODate.TabIndex = 347;
            // 
            // lblPODate
            // 
            this.lblPODate.AutoSize = true;
            this.lblPODate.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblPODate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPODate.Location = new System.Drawing.Point(9, 426);
            this.lblPODate.Name = "lblPODate";
            this.lblPODate.Size = new System.Drawing.Size(56, 15);
            this.lblPODate.TabIndex = 346;
            this.lblPODate.Text = "P.O DATE";
            // 
            // frmPurchases
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(922, 607);
            this.Controls.Add(this.txtPODate);
            this.Controls.Add(this.lblPODate);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtBalanceWeight);
            this.Controls.Add(this.lblBalanceWeight);
            this.Controls.Add(this.btnDetailReport);
            this.Controls.Add(this.txtOrderWeight);
            this.Controls.Add(this.lblOrderedWeight);
            this.Controls.Add(this.btn_VIEW_VOUCHER);
            this.Controls.Add(this.txtMuandValue);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtUnit);
            this.Controls.Add(this.txtMaterial);
            this.Controls.Add(this.txtMaterialType);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtKgRate);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnCLEAR);
            this.Controls.Add(this.btnSAVE);
            this.Controls.Add(this.txtNetWeight);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtKorangiWeight);
            this.Controls.Add(this.txtMuandRate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbPurchaseOrder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtVehNumber);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCreditDays);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDescript);
            this.Controls.Add(this.lblAcc);
            this.Controls.Add(this.dtp_DATE);
            this.Controls.Add(this.lblPI);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblV);
            this.Controls.Add(this.cmbSupplier);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.grdSEARCH);
            this.Controls.Add(this.txtSEARCH);
            this.Controls.Add(this.lblSEARCH);
            this.Controls.Add(this.pnlHEADER);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1314, 703);
            this.Name = "frmPurchases";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PURCHASES ";
            this.Load += new System.EventHandler(this.frm_AddGroupAccounts_Load);
            this.pnlHEADER.ResumeLayout(false);
            this.pnlHEADER.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSEARCH)).EndInit();
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
        private System.Windows.Forms.Label label1;
        private SergeUtils.EasyCompletionComboBox cmbPurchaseOrder;
        private SergeUtils.EasyCompletionComboBox cmbSupplier;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtp_DATE;
        private System.Windows.Forms.Label lblPI;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblV;
        private System.Windows.Forms.TextBox txtDescript;
        private System.Windows.Forms.Label lblAcc;
        private System.Windows.Forms.TextBox txtCreditDays;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtVehNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNetWeight;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtKorangiWeight;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMuandRate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtKgRate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtMaterialType;
        private System.Windows.Forms.TextBox txtMaterial;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.TextBox txtMuandValue;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_VIEW_VOUCHER;
        private System.Windows.Forms.TextBox txtOrderWeight;
        private System.Windows.Forms.Label lblOrderedWeight;
        private System.Windows.Forms.Button btnDetailReport;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtBalanceWeight;
        private System.Windows.Forms.Label lblBalanceWeight;
        private System.Windows.Forms.TextBox txtPODate;
        private System.Windows.Forms.Label lblPODate;
    }
}