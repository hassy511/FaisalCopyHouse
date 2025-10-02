namespace ERP_Maaz_Oil.Forms
{
    partial class frmSalesInvoice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSalesInvoice));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHEADER = new System.Windows.Forms.Panel();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.lblHEADING = new System.Windows.Forms.Label();
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
            this.lblAmount = new System.Windows.Forms.Label();
            this.grdItems = new System.Windows.Forms.DataGridView();
            this.itemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UNIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbPro = new SergeUtils.EasyCompletionComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotalWeight = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDueDate = new System.Windows.Forms.TextBox();
            this.lblVehicle = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtVehicle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSalePerson = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtArea = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlHEADER.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
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
            this.pnlHEADER.Size = new System.Drawing.Size(738, 88);
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
            this.lblHEADING.Size = new System.Drawing.Size(192, 29);
            this.lblHEADING.TabIndex = 23;
            this.lblHEADING.Text = "SALES INVOICE";
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
            this.btnCLEAR.Location = new System.Drawing.Point(609, 518);
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
            this.btnSAVE.Location = new System.Drawing.Point(479, 518);
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
            this.cmbCustomer.Location = new System.Drawing.Point(104, 123);
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
            this.label9.Location = new System.Drawing.Point(10, 128);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 15);
            this.label9.TabIndex = 227;
            this.label9.Text = "CUSTOMER";
            // 
            // dtp_DATE
            // 
            this.dtp_DATE.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.dtp_DATE.Location = new System.Drawing.Point(466, 94);
            this.dtp_DATE.Name = "dtp_DATE";
            this.dtp_DATE.Size = new System.Drawing.Size(267, 23);
            this.dtp_DATE.TabIndex = 295;
            // 
            // lblPRO
            // 
            this.lblPRO.AutoSize = true;
            this.lblPRO.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblPRO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(215)))));
            this.lblPRO.Location = new System.Drawing.Point(104, 98);
            this.lblPRO.Name = "lblPRO";
            this.lblPRO.Size = new System.Drawing.Size(58, 15);
            this.lblPRO.TabIndex = 298;
            this.lblPRO.Text = "SI-1-2017";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblDate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDate.Location = new System.Drawing.Point(377, 98);
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
            this.lblV.Location = new System.Drawing.Point(10, 98);
            this.lblV.Name = "lblV";
            this.lblV.Size = new System.Drawing.Size(34, 15);
            this.lblV.TabIndex = 296;
            this.lblV.Text = "S.I #:";
            // 
            // txtDescript
            // 
            this.txtDescript.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescript.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtDescript.Location = new System.Drawing.Point(466, 154);
            this.txtDescript.MaxLength = 100;
            this.txtDescript.Multiline = true;
            this.txtDescript.Name = "txtDescript";
            this.txtDescript.Size = new System.Drawing.Size(267, 56);
            this.txtDescript.TabIndex = 299;
            // 
            // lblAcc
            // 
            this.lblAcc.AutoSize = true;
            this.lblAcc.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblAcc.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblAcc.Location = new System.Drawing.Point(377, 175);
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
            this.txtTotal.Location = new System.Drawing.Point(589, 474);
            this.txtTotal.MaxLength = 11;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(144, 25);
            this.txtTotal.TabIndex = 305;
            this.txtTotal.Text = "0";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblAmount.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblAmount.Location = new System.Drawing.Point(485, 479);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(97, 15);
            this.lblAmount.TabIndex = 306;
            this.lblAmount.Text = "TOTAL AMOUNT";
            // 
            // grdItems
            // 
            this.grdItems.AllowUserToAddRows = false;
            this.grdItems.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            this.grdItems.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.grdItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdItems.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grdItems.BackgroundColor = System.Drawing.Color.White;
            this.grdItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI Semibold", 10.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.grdItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemId,
            this.itemName,
            this.qty,
            this.weight,
            this.UNIT,
            this.rate,
            this.total,
            this.itemType});
            this.grdItems.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdItems.DefaultCellStyle = dataGridViewCellStyle9;
            this.grdItems.Location = new System.Drawing.Point(13, 247);
            this.grdItems.Name = "grdItems";
            this.grdItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdItems.Size = new System.Drawing.Size(720, 219);
            this.grdItems.TabIndex = 324;
            this.grdItems.TabStop = false;
            this.grdItems.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdItems_CellValueChanged);
            this.grdItems.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.grdItems_EditingControlShowing);
            // 
            // itemId
            // 
            this.itemId.HeaderText = "itemId";
            this.itemId.Name = "itemId";
            this.itemId.Visible = false;
            this.itemId.Width = 74;
            // 
            // itemName
            // 
            this.itemName.HeaderText = "PRODUCT";
            this.itemName.Name = "itemName";
            this.itemName.Width = 99;
            // 
            // qty
            // 
            this.qty.HeaderText = "QUANTITY";
            this.qty.Name = "qty";
            this.qty.Width = 103;
            // 
            // weight
            // 
            this.weight.HeaderText = "WEIGHT";
            this.weight.Name = "weight";
            this.weight.Width = 87;
            // 
            // UNIT
            // 
            this.UNIT.HeaderText = "UNIT";
            this.UNIT.Name = "UNIT";
            this.UNIT.Width = 67;
            // 
            // rate
            // 
            this.rate.HeaderText = "RATE";
            this.rate.Name = "rate";
            this.rate.Width = 66;
            // 
            // total
            // 
            this.total.HeaderText = "TOTAL";
            this.total.Name = "total";
            this.total.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.total.Width = 74;
            // 
            // itemType
            // 
            this.itemType.HeaderText = "ITEM TYPE";
            this.itemType.Name = "itemType";
            this.itemType.Visible = false;
            this.itemType.Width = 101;
            // 
            // cmbPro
            // 
            this.cmbPro.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbPro.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPro.Enabled = false;
            this.cmbPro.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbPro.FormattingEnabled = true;
            this.cmbPro.Items.AddRange(new object[] {
            "--SELECT SUPPLIER--",
            "AUTOMART"});
            this.cmbPro.Location = new System.Drawing.Point(466, 123);
            this.cmbPro.Name = "cmbPro";
            this.cmbPro.Size = new System.Drawing.Size(267, 25);
            this.cmbPro.TabIndex = 326;
            this.cmbPro.SelectedIndexChanged += new System.EventHandler(this.cmbSO_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(377, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 15);
            this.label1.TabIndex = 327;
            this.label1.Text = "SELECT G.P #";
            // 
            // txtTotalWeight
            // 
            this.txtTotalWeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotalWeight.Enabled = false;
            this.txtTotalWeight.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtTotalWeight.Location = new System.Drawing.Point(104, 474);
            this.txtTotalWeight.MaxLength = 11;
            this.txtTotalWeight.Name = "txtTotalWeight";
            this.txtTotalWeight.ReadOnly = true;
            this.txtTotalWeight.Size = new System.Drawing.Size(144, 25);
            this.txtTotalWeight.TabIndex = 330;
            this.txtTotalWeight.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(10, 479);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 15);
            this.label4.TabIndex = 331;
            this.label4.Text = "TOTALWEIGHT";
            // 
            // txtDueDate
            // 
            this.txtDueDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDueDate.Enabled = false;
            this.txtDueDate.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtDueDate.Location = new System.Drawing.Point(466, 216);
            this.txtDueDate.MaxLength = 100;
            this.txtDueDate.Name = "txtDueDate";
            this.txtDueDate.ReadOnly = true;
            this.txtDueDate.Size = new System.Drawing.Size(267, 25);
            this.txtDueDate.TabIndex = 332;
            // 
            // lblVehicle
            // 
            this.lblVehicle.AutoSize = true;
            this.lblVehicle.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblVehicle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblVehicle.Location = new System.Drawing.Point(377, 221);
            this.lblVehicle.Name = "lblVehicle";
            this.lblVehicle.Size = new System.Drawing.Size(62, 15);
            this.lblVehicle.TabIndex = 333;
            this.lblVehicle.Text = "DUE DATE";
            // 
            // txtQty
            // 
            this.txtQty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQty.Enabled = false;
            this.txtQty.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtQty.Location = new System.Drawing.Point(332, 474);
            this.txtQty.MaxLength = 11;
            this.txtQty.Name = "txtQty";
            this.txtQty.ReadOnly = true;
            this.txtQty.Size = new System.Drawing.Size(144, 25);
            this.txtQty.TabIndex = 334;
            this.txtQty.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(259, 479);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 335;
            this.label5.Text = "TOTAL QTY";
            // 
            // txtVehicle
            // 
            this.txtVehicle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtVehicle.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtVehicle.Location = new System.Drawing.Point(104, 216);
            this.txtVehicle.MaxLength = 100;
            this.txtVehicle.Name = "txtVehicle";
            this.txtVehicle.Size = new System.Drawing.Size(267, 25);
            this.txtVehicle.TabIndex = 336;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(10, 221);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 337;
            this.label2.Text = "VEHICLE #";
            // 
            // txtSalePerson
            // 
            this.txtSalePerson.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSalePerson.Enabled = false;
            this.txtSalePerson.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtSalePerson.Location = new System.Drawing.Point(104, 185);
            this.txtSalePerson.MaxLength = 100;
            this.txtSalePerson.Name = "txtSalePerson";
            this.txtSalePerson.ReadOnly = true;
            this.txtSalePerson.Size = new System.Drawing.Size(267, 25);
            this.txtSalePerson.TabIndex = 338;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(10, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 15);
            this.label3.TabIndex = 339;
            this.label3.Text = "SALES PERSON";
            // 
            // txtArea
            // 
            this.txtArea.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtArea.Enabled = false;
            this.txtArea.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtArea.Location = new System.Drawing.Point(104, 154);
            this.txtArea.MaxLength = 100;
            this.txtArea.Name = "txtArea";
            this.txtArea.ReadOnly = true;
            this.txtArea.Size = new System.Drawing.Size(267, 25);
            this.txtArea.TabIndex = 340;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(10, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 15);
            this.label6.TabIndex = 341;
            this.label6.Text = "AREA";
            // 
            // frmSalesInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(738, 546);
            this.Controls.Add(this.txtArea);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSalePerson);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtVehicle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDueDate);
            this.Controls.Add(this.lblVehicle);
            this.Controls.Add(this.txtTotalWeight);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbPro);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grdItems);
            this.Controls.Add(this.btnCLEAR);
            this.Controls.Add(this.btnSAVE);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.txtDescript);
            this.Controls.Add(this.lblAcc);
            this.Controls.Add(this.dtp_DATE);
            this.Controls.Add(this.lblPRO);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblV);
            this.Controls.Add(this.cmbCustomer);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.pnlHEADER);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1314, 703);
            this.Name = "frmSalesInvoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SALES INVOICE";
            this.Load += new System.EventHandler(this.frm_AddGroupAccounts_Load);
            this.pnlHEADER.ResumeLayout(false);
            this.pnlHEADER.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHEADER;
        private System.Windows.Forms.PictureBox pictureBox15;
        private System.Windows.Forms.Label lblHEADING;
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
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.DataGridView grdItems;
        private SergeUtils.EasyCompletionComboBox cmbPro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTotalWeight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblVehicle;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDueDate;
        private System.Windows.Forms.TextBox txtVehicle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSalePerson;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtArea;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn UNIT;
        private System.Windows.Forms.DataGridViewTextBoxColumn rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemType;
    }
}