namespace ERP_Maaz_Oil.Forms
{
    partial class frmAASales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAASales));
            this.pnlHEADER = new System.Windows.Forms.Panel();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.lblHEADING = new System.Windows.Forms.Label();
            this.txtMaterialType = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.grdSEARCH = new System.Windows.Forms.DataGridView();
            this.txtSEARCH = new System.Windows.Forms.TextBox();
            this.lblSEARCH = new System.Windows.Forms.Label();
            this.btnCLEAR = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnSAVE = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtMaterial = new System.Windows.Forms.TextBox();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbSO = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtSaleWeight = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtSaleKg = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtSaleMuandRate = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtSalesTotal = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtSaleCreditDays = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.lblSaleInvoiceNo = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.btnViewSODetails = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.txtSalesBalanceWeight = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtSalesDescription = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnViewSalesInvoice = new System.Windows.Forms.Button();
            this.txtSODate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSOWeight = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.dtp_DATE = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
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
            this.pnlHEADER.Controls.Add(this.txtMaterialType);
            this.pnlHEADER.Controls.Add(this.label12);
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
            this.lblHEADING.Size = new System.Drawing.Size(125, 29);
            this.lblHEADING.TabIndex = 0;
            this.lblHEADING.Text = "AA SALES";
            // 
            // txtMaterialType
            // 
            this.txtMaterialType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMaterialType.Enabled = false;
            this.txtMaterialType.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtMaterialType.Location = new System.Drawing.Point(611, 47);
            this.txtMaterialType.MaxLength = 11;
            this.txtMaterialType.Name = "txtMaterialType";
            this.txtMaterialType.Size = new System.Drawing.Size(280, 25);
            this.txtMaterialType.TabIndex = 324;
            this.txtMaterialType.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label12.Location = new System.Drawing.Point(491, 52);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 15);
            this.label12.TabIndex = 323;
            this.label12.Text = "MATERIAL TYPE";
            this.label12.Visible = false;
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
            this.grdSEARCH.Size = new System.Drawing.Size(911, 133);
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
            this.btnCLEAR.Location = new System.Drawing.Point(786, 447);
            this.btnCLEAR.Name = "btnCLEAR";
            this.btnCLEAR.Size = new System.Drawing.Size(124, 25);
            this.btnCLEAR.TabIndex = 26;
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
            this.btnSAVE.Location = new System.Drawing.Point(630, 447);
            this.btnSAVE.Name = "btnSAVE";
            this.btnSAVE.Size = new System.Drawing.Size(124, 25);
            this.btnSAVE.TabIndex = 25;
            this.btnSAVE.Text = "SAVE";
            this.btnSAVE.UseVisualStyleBackColor = false;
            this.btnSAVE.Click += new System.EventHandler(this.btnSAVE_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Location = new System.Drawing.Point(563, 267);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 15);
            this.label11.TabIndex = 322;
            this.label11.Text = "MATERIAL";
            // 
            // txtMaterial
            // 
            this.txtMaterial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMaterial.Enabled = false;
            this.txtMaterial.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtMaterial.Location = new System.Drawing.Point(630, 262);
            this.txtMaterial.MaxLength = 11;
            this.txtMaterial.Name = "txtMaterial";
            this.txtMaterial.Size = new System.Drawing.Size(280, 25);
            this.txtMaterial.TabIndex = 13;
            this.txtMaterial.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtPODate_MouseClick);
            this.txtMaterial.Enter += new System.EventHandler(this.txtPODate_Enter);
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
            this.cmbCustomer.Location = new System.Drawing.Point(117, 322);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(280, 25);
            this.cmbCustomer.TabIndex = 14;
            this.cmbCustomer.SelectedIndexChanged += new System.EventHandler(this.cmbCustomer_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label13.Location = new System.Drawing.Point(44, 327);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 15);
            this.label13.TabIndex = 349;
            this.label13.Text = "CUSTOMER";
            // 
            // cmbSO
            // 
            this.cmbSO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSO.Enabled = false;
            this.cmbSO.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbSO.FormattingEnabled = true;
            this.cmbSO.Items.AddRange(new object[] {
            "--SELECT PURCHASES ORDER--",
            "P.O-1-2017"});
            this.cmbSO.Location = new System.Drawing.Point(117, 353);
            this.cmbSO.Name = "cmbSO";
            this.cmbSO.Size = new System.Drawing.Size(251, 25);
            this.cmbSO.TabIndex = 15;
            this.cmbSO.SelectedIndexChanged += new System.EventHandler(this.cmbSO_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label14.Location = new System.Drawing.Point(31, 358);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(82, 15);
            this.label14.TabIndex = 351;
            this.label14.Text = "SALES ORDER";
            // 
            // textBox2
            // 
            this.textBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.textBox2.Location = new System.Drawing.Point(315, 478);
            this.textBox2.MaxLength = 11;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(82, 25);
            this.textBox2.TabIndex = 354;
            this.textBox2.Text = "KGS";
            // 
            // txtSaleWeight
            // 
            this.txtSaleWeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSaleWeight.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtSaleWeight.Location = new System.Drawing.Point(117, 478);
            this.txtSaleWeight.MaxLength = 11;
            this.txtSaleWeight.Name = "txtSaleWeight";
            this.txtSaleWeight.Size = new System.Drawing.Size(200, 25);
            this.txtSaleWeight.TabIndex = 19;
            this.txtSaleWeight.Text = "0";
            this.txtSaleWeight.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtPODate_MouseClick);
            this.txtSaleWeight.TextChanged += new System.EventHandler(this.txtSaleWeight_TextChanged);
            this.txtSaleWeight.Enter += new System.EventHandler(this.txtPODate_Enter);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label15.Location = new System.Drawing.Point(30, 483);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(82, 15);
            this.label15.TabIndex = 353;
            this.label15.Text = "SALE WEIGHT";
            // 
            // txtSaleKg
            // 
            this.txtSaleKg.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSaleKg.Enabled = false;
            this.txtSaleKg.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtSaleKg.Location = new System.Drawing.Point(630, 291);
            this.txtSaleKg.MaxLength = 11;
            this.txtSaleKg.Name = "txtSaleKg";
            this.txtSaleKg.Size = new System.Drawing.Size(280, 25);
            this.txtSaleKg.TabIndex = 20;
            this.txtSaleKg.Text = "0";
            this.txtSaleKg.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtPODate_MouseClick);
            this.txtSaleKg.TextChanged += new System.EventHandler(this.txtSaleKg_TextChanged);
            this.txtSaleKg.Enter += new System.EventHandler(this.txtPODate_Enter);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label16.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label16.Location = new System.Drawing.Point(574, 296);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 15);
            this.label16.TabIndex = 358;
            this.label16.Text = "KG RATE";
            this.label16.Click += new System.EventHandler(this.label16_Click);
            // 
            // txtSaleMuandRate
            // 
            this.txtSaleMuandRate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSaleMuandRate.Enabled = false;
            this.txtSaleMuandRate.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtSaleMuandRate.Location = new System.Drawing.Point(630, 322);
            this.txtSaleMuandRate.MaxLength = 11;
            this.txtSaleMuandRate.Name = "txtSaleMuandRate";
            this.txtSaleMuandRate.Size = new System.Drawing.Size(280, 25);
            this.txtSaleMuandRate.TabIndex = 21;
            this.txtSaleMuandRate.Text = "0";
            this.txtSaleMuandRate.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtPODate_MouseClick);
            this.txtSaleMuandRate.TextChanged += new System.EventHandler(this.txtSaleMuandRate_TextChanged);
            this.txtSaleMuandRate.Enter += new System.EventHandler(this.txtPODate_Enter);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label17.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label17.Location = new System.Drawing.Point(544, 327);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(83, 15);
            this.label17.TabIndex = 356;
            this.label17.Text = "MAUND RATE";
            this.label17.Click += new System.EventHandler(this.label17_Click);
            // 
            // txtSalesTotal
            // 
            this.txtSalesTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSalesTotal.Enabled = false;
            this.txtSalesTotal.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtSalesTotal.Location = new System.Drawing.Point(630, 354);
            this.txtSalesTotal.MaxLength = 11;
            this.txtSalesTotal.Name = "txtSalesTotal";
            this.txtSalesTotal.Size = new System.Drawing.Size(280, 25);
            this.txtSalesTotal.TabIndex = 22;
            this.txtSalesTotal.Text = "0";
            this.txtSalesTotal.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtPODate_MouseClick);
            this.txtSalesTotal.TextChanged += new System.EventHandler(this.txtSalesTotal_TextChanged);
            this.txtSalesTotal.Enter += new System.EventHandler(this.txtPODate_Enter);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label18.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label18.Location = new System.Drawing.Point(537, 359);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(89, 15);
            this.label18.TabIndex = 362;
            this.label18.Text = "SALE AMOUNT";
            this.label18.Click += new System.EventHandler(this.label18_Click);
            // 
            // txtSaleCreditDays
            // 
            this.txtSaleCreditDays.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSaleCreditDays.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtSaleCreditDays.Location = new System.Drawing.Point(630, 385);
            this.txtSaleCreditDays.MaxLength = 11;
            this.txtSaleCreditDays.Name = "txtSaleCreditDays";
            this.txtSaleCreditDays.Size = new System.Drawing.Size(280, 25);
            this.txtSaleCreditDays.TabIndex = 23;
            this.txtSaleCreditDays.Text = "0";
            this.txtSaleCreditDays.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtPODate_MouseClick);
            this.txtSaleCreditDays.TextChanged += new System.EventHandler(this.txtSaleCreditDays_TextChanged);
            this.txtSaleCreditDays.Enter += new System.EventHandler(this.txtPODate_Enter);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label19.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label19.Location = new System.Drawing.Point(546, 390);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(80, 15);
            this.label19.TabIndex = 360;
            this.label19.Text = "CREDIT DAYS";
            this.label19.Click += new System.EventHandler(this.label19_Click);
            // 
            // lblSaleInvoiceNo
            // 
            this.lblSaleInvoiceNo.AutoSize = true;
            this.lblSaleInvoiceNo.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblSaleInvoiceNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(215)))));
            this.lblSaleInvoiceNo.Location = new System.Drawing.Point(115, 267);
            this.lblSaleInvoiceNo.Name = "lblSaleInvoiceNo";
            this.lblSaleInvoiceNo.Size = new System.Drawing.Size(62, 15);
            this.lblSaleInvoiceNo.TabIndex = 364;
            this.lblSaleInvoiceNo.Text = "SI-1-2017";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label21.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label21.Location = new System.Drawing.Point(75, 267);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(33, 15);
            this.label21.TabIndex = 363;
            this.label21.Text = "S.I #:";
            // 
            // btnViewSODetails
            // 
            this.btnViewSODetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(24)))), ((int)(((byte)(38)))));
            this.btnViewSODetails.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnViewSODetails.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnViewSODetails.ForeColor = System.Drawing.Color.White;
            this.btnViewSODetails.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewSODetails.ImageIndex = 2;
            this.btnViewSODetails.ImageList = this.imageList1;
            this.btnViewSODetails.Location = new System.Drawing.Point(367, 353);
            this.btnViewSODetails.Name = "btnViewSODetails";
            this.btnViewSODetails.Size = new System.Drawing.Size(30, 25);
            this.btnViewSODetails.TabIndex = 365;
            this.btnViewSODetails.UseVisualStyleBackColor = false;
            this.btnViewSODetails.Click += new System.EventHandler(this.btnViewSODetails_Click);
            // 
            // textBox3
            // 
            this.textBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox3.Enabled = false;
            this.textBox3.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.textBox3.Location = new System.Drawing.Point(315, 446);
            this.textBox3.MaxLength = 11;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(82, 25);
            this.textBox3.TabIndex = 368;
            this.textBox3.Text = "KGS";
            // 
            // txtSalesBalanceWeight
            // 
            this.txtSalesBalanceWeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSalesBalanceWeight.Enabled = false;
            this.txtSalesBalanceWeight.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtSalesBalanceWeight.Location = new System.Drawing.Point(117, 446);
            this.txtSalesBalanceWeight.MaxLength = 11;
            this.txtSalesBalanceWeight.Name = "txtSalesBalanceWeight";
            this.txtSalesBalanceWeight.Size = new System.Drawing.Size(200, 25);
            this.txtSalesBalanceWeight.TabIndex = 18;
            this.txtSalesBalanceWeight.Text = "0";
            this.txtSalesBalanceWeight.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtPODate_MouseClick);
            this.txtSalesBalanceWeight.Enter += new System.EventHandler(this.txtPODate_Enter);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label20.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label20.Location = new System.Drawing.Point(6, 451);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(106, 15);
            this.label20.TabIndex = 367;
            this.label20.Text = "BALANCE WEIGHT";
            // 
            // txtSalesDescription
            // 
            this.txtSalesDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSalesDescription.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtSalesDescription.Location = new System.Drawing.Point(630, 416);
            this.txtSalesDescription.MaxLength = 100;
            this.txtSalesDescription.Multiline = true;
            this.txtSalesDescription.Name = "txtSalesDescription";
            this.txtSalesDescription.Size = new System.Drawing.Size(280, 25);
            this.txtSalesDescription.TabIndex = 24;
            this.txtSalesDescription.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtPODate_MouseClick);
            this.txtSalesDescription.TextChanged += new System.EventHandler(this.txtSalesDescription_TextChanged);
            this.txtSalesDescription.Enter += new System.EventHandler(this.txtPODate_Enter);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(540, 421);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 15);
            this.label8.TabIndex = 370;
            this.label8.Text = "DESCRIPTION:";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // btnViewSalesInvoice
            // 
            this.btnViewSalesInvoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(24)))), ((int)(((byte)(38)))));
            this.btnViewSalesInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnViewSalesInvoice.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnViewSalesInvoice.ForeColor = System.Drawing.Color.White;
            this.btnViewSalesInvoice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewSalesInvoice.ImageIndex = 2;
            this.btnViewSalesInvoice.ImageList = this.imageList1;
            this.btnViewSalesInvoice.Location = new System.Drawing.Point(630, 478);
            this.btnViewSalesInvoice.Name = "btnViewSalesInvoice";
            this.btnViewSalesInvoice.Size = new System.Drawing.Size(280, 25);
            this.btnViewSalesInvoice.TabIndex = 371;
            this.btnViewSalesInvoice.Text = "VIEW SALES INVOICE";
            this.btnViewSalesInvoice.UseVisualStyleBackColor = false;
            this.btnViewSalesInvoice.Click += new System.EventHandler(this.btnViewSalesInvoice_Click);
            // 
            // txtSODate
            // 
            this.txtSODate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSODate.Enabled = false;
            this.txtSODate.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtSODate.Location = new System.Drawing.Point(117, 384);
            this.txtSODate.MaxLength = 11;
            this.txtSODate.Name = "txtSODate";
            this.txtSODate.Size = new System.Drawing.Size(280, 25);
            this.txtSODate.TabIndex = 16;
            this.txtSODate.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtPODate_MouseClick);
            this.txtSODate.Enter += new System.EventHandler(this.txtPODate_Enter);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(55, 389);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 15);
            this.label5.TabIndex = 372;
            this.label5.Text = "S.O DATE";
            // 
            // txtSOWeight
            // 
            this.txtSOWeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSOWeight.Enabled = false;
            this.txtSOWeight.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtSOWeight.Location = new System.Drawing.Point(117, 415);
            this.txtSOWeight.MaxLength = 11;
            this.txtSOWeight.Name = "txtSOWeight";
            this.txtSOWeight.Size = new System.Drawing.Size(280, 25);
            this.txtSOWeight.TabIndex = 17;
            this.txtSOWeight.Text = "0";
            this.txtSOWeight.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtPODate_MouseClick);
            this.txtSOWeight.Enter += new System.EventHandler(this.txtPODate_Enter);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label22.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label22.Location = new System.Drawing.Point(38, 420);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(74, 15);
            this.label22.TabIndex = 375;
            this.label22.Text = "S.O WEIGHT";
            // 
            // dtp_DATE
            // 
            this.dtp_DATE.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.dtp_DATE.Location = new System.Drawing.Point(117, 291);
            this.dtp_DATE.Name = "dtp_DATE";
            this.dtp_DATE.Size = new System.Drawing.Size(280, 23);
            this.dtp_DATE.TabIndex = 325;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblDate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDate.Location = new System.Drawing.Point(74, 295);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(40, 15);
            this.lblDate.TabIndex = 326;
            this.lblDate.Text = "DATE:";
            // 
            // frmAASales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(922, 510);
            this.Controls.Add(this.dtp_DATE);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.txtSOWeight);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.txtSODate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnViewSalesInvoice);
            this.Controls.Add(this.txtSalesDescription);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.txtSalesBalanceWeight);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.btnViewSODetails);
            this.Controls.Add(this.lblSaleInvoiceNo);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.txtSalesTotal);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.btnSAVE);
            this.Controls.Add(this.txtSaleCreditDays);
            this.Controls.Add(this.btnCLEAR);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.txtSaleKg);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtSaleMuandRate);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.txtSaleWeight);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.cmbSO);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cmbCustomer);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtMaterial);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.grdSEARCH);
            this.Controls.Add(this.txtSEARCH);
            this.Controls.Add(this.lblSEARCH);
            this.Controls.Add(this.pnlHEADER);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(938, 549);
            this.Name = "frmAASales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AA SALES";
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
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtMaterialType;
        private System.Windows.Forms.TextBox txtMaterial;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbSO;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtSaleWeight;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtSaleKg;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtSaleMuandRate;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtSalesTotal;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtSaleCreditDays;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblSaleInvoiceNo;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btnViewSODetails;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox txtSalesBalanceWeight;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtSalesDescription;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnViewSalesInvoice;
        private System.Windows.Forms.TextBox txtSODate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSOWeight;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.DateTimePicker dtp_DATE;
        private System.Windows.Forms.Label lblDate;
    }
}