namespace ERP_Maaz_Oil.Forms
{
    partial class frmFinishedProducts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFinishedProducts));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHEADER = new System.Windows.Forms.Panel();
            this.lblHEADING = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOpeningRate = new System.Windows.Forms.TextBox();
            this.lblNetWeight = new System.Windows.Forms.Label();
            this.grdSearch = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSEARCH = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.lblProductName = new System.Windows.Forms.Label();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.lblProductCode = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.cmbBrand = new System.Windows.Forms.ComboBox();
            this.lblBrand = new System.Windows.Forms.Label();
            this.lblRawMaterial = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOpeningQty = new System.Windows.Forms.TextBox();
            this.cmbMatrial = new System.Windows.Forms.ComboBox();
            this.txtMaterialQty = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.gridMaterial = new System.Windows.Forms.DataGridView();
            this.materialId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.materialName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wastage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtNumberOfPackages = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPcsInBundle = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.cmbBindingType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtWastage = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pnlHEADER.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMaterial)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHEADER
            // 
            this.pnlHEADER.BackColor = System.Drawing.Color.Transparent;
            this.pnlHEADER.BackgroundImage = global::ERP_Maaz_Oil.Properties.Resources.header;
            this.pnlHEADER.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlHEADER.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHEADER.Controls.Add(this.lblHEADING);
            this.pnlHEADER.Controls.Add(this.label1);
            this.pnlHEADER.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHEADER.Location = new System.Drawing.Point(0, 0);
            this.pnlHEADER.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlHEADER.Name = "pnlHEADER";
            this.pnlHEADER.Size = new System.Drawing.Size(1387, 108);
            this.pnlHEADER.TabIndex = 36;
            // 
            // lblHEADING
            // 
            this.lblHEADING.AutoSize = true;
            this.lblHEADING.BackColor = System.Drawing.Color.Transparent;
            this.lblHEADING.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.75F);
            this.lblHEADING.ForeColor = System.Drawing.Color.White;
            this.lblHEADING.Location = new System.Drawing.Point(8, 31);
            this.lblHEADING.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHEADING.Name = "lblHEADING";
            this.lblHEADING.Size = new System.Drawing.Size(289, 32);
            this.lblHEADING.TabIndex = 23;
            this.lblHEADING.Text = "FINISHED PRODUCT";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(477, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 212;
            this.label1.Text = "MAX QTY";
            this.label1.Visible = false;
            // 
            // txtOpeningRate
            // 
            this.txtOpeningRate.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtOpeningRate.Location = new System.Drawing.Point(176, 823);
            this.txtOpeningRate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtOpeningRate.Name = "txtOpeningRate";
            this.txtOpeningRate.Size = new System.Drawing.Size(323, 29);
            this.txtOpeningRate.TabIndex = 4;
            this.txtOpeningRate.Text = "0";
            this.txtOpeningRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRawWeight_KeyPress);
            // 
            // lblNetWeight
            // 
            this.lblNetWeight.AutoSize = true;
            this.lblNetWeight.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblNetWeight.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblNetWeight.Location = new System.Drawing.Point(15, 830);
            this.lblNetWeight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNetWeight.Name = "lblNetWeight";
            this.lblNetWeight.Size = new System.Drawing.Size(113, 20);
            this.lblNetWeight.TabIndex = 212;
            this.lblNetWeight.Text = "OPENING RATE";
            // 
            // grdSearch
            // 
            this.grdSearch.AllowUserToAddRows = false;
            this.grdSearch.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.grdSearch.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdSearch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
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
            this.grdSearch.Location = new System.Drawing.Point(7, 155);
            this.grdSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grdSearch.Name = "grdSearch";
            this.grdSearch.ReadOnly = true;
            this.grdSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSearch.Size = new System.Drawing.Size(1372, 391);
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
            this.txtSearch.Location = new System.Drawing.Point(96, 117);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(1275, 29);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSEARCH_TextChanged);
            // 
            // lblSEARCH
            // 
            this.lblSEARCH.AutoSize = true;
            this.lblSEARCH.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSEARCH.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSEARCH.Location = new System.Drawing.Point(12, 122);
            this.lblSEARCH.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSEARCH.Name = "lblSEARCH";
            this.lblSEARCH.Size = new System.Drawing.Size(74, 23);
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
            this.btnClear.Location = new System.Drawing.Point(345, 976);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(155, 31);
            this.btnClear.TabIndex = 11;
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
            this.btnSave.Location = new System.Drawing.Point(176, 976);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(152, 31);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSAVE_Click);
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblProductName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblProductName.Location = new System.Drawing.Point(15, 639);
            this.lblProductName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(125, 20);
            this.lblProductName.TabIndex = 212;
            this.lblProductName.Text = "PRODUCT NAME";
            // 
            // txtProductCode
            // 
            this.txtProductCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProductCode.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtProductCode.Location = new System.Drawing.Point(176, 594);
            this.txtProductCode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtProductCode.MaxLength = 32000;
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(323, 29);
            this.txtProductCode.TabIndex = 1;
            // 
            // lblProductCode
            // 
            this.lblProductCode.AutoSize = true;
            this.lblProductCode.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblProductCode.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblProductCode.Location = new System.Drawing.Point(15, 601);
            this.lblProductCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProductCode.Name = "lblProductCode";
            this.lblProductCode.Size = new System.Drawing.Size(120, 20);
            this.lblProductCode.TabIndex = 212;
            this.lblProductCode.Text = "PRODUCT CODE";
            // 
            // txtProductName
            // 
            this.txtProductName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProductName.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtProductName.Location = new System.Drawing.Point(176, 633);
            this.txtProductName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtProductName.MaxLength = 32000;
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(323, 29);
            this.txtProductName.TabIndex = 2;
            // 
            // cmbBrand
            // 
            this.cmbBrand.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbBrand.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBrand.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbBrand.FormattingEnabled = true;
            this.cmbBrand.Location = new System.Drawing.Point(176, 556);
            this.cmbBrand.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbBrand.Name = "cmbBrand";
            this.cmbBrand.Size = new System.Drawing.Size(323, 29);
            this.cmbBrand.TabIndex = 0;
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblBrand.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblBrand.Location = new System.Drawing.Point(15, 562);
            this.lblBrand.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(112, 20);
            this.lblBrand.TabIndex = 250;
            this.lblBrand.Text = "SELECT BRAND";
            // 
            // lblRawMaterial
            // 
            this.lblRawMaterial.AutoSize = true;
            this.lblRawMaterial.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblRawMaterial.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblRawMaterial.Location = new System.Drawing.Point(15, 711);
            this.lblRawMaterial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRawMaterial.Name = "lblRawMaterial";
            this.lblRawMaterial.Size = new System.Drawing.Size(36, 20);
            this.lblRawMaterial.TabIndex = 229;
            this.lblRawMaterial.Text = "QTY";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(15, 868);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 20);
            this.label3.TabIndex = 212;
            this.label3.Text = "MATERIAL";
            // 
            // txtOpeningQty
            // 
            this.txtOpeningQty.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtOpeningQty.Location = new System.Drawing.Point(176, 709);
            this.txtOpeningQty.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtOpeningQty.Name = "txtOpeningQty";
            this.txtOpeningQty.Size = new System.Drawing.Size(323, 29);
            this.txtOpeningQty.TabIndex = 3;
            this.txtOpeningQty.Text = "0";
            this.txtOpeningQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRawWeight_KeyPress);
            // 
            // cmbMatrial
            // 
            this.cmbMatrial.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbMatrial.FormattingEnabled = true;
            this.cmbMatrial.Location = new System.Drawing.Point(176, 862);
            this.cmbMatrial.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbMatrial.Name = "cmbMatrial";
            this.cmbMatrial.Size = new System.Drawing.Size(323, 29);
            this.cmbMatrial.TabIndex = 7;
            // 
            // txtMaterialQty
            // 
            this.txtMaterialQty.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtMaterialQty.Location = new System.Drawing.Point(176, 900);
            this.txtMaterialQty.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMaterialQty.Name = "txtMaterialQty";
            this.txtMaterialQty.Size = new System.Drawing.Size(323, 29);
            this.txtMaterialQty.TabIndex = 8;
            this.txtMaterialQty.Text = "0";
            this.txtMaterialQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRawWeight_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(15, 906);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 20);
            this.label4.TabIndex = 212;
            this.label4.Text = "MATERIAL QTY";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(68)))), ((int)(((byte)(2)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(405, 938);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(95, 31);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "ADD";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // gridMaterial
            // 
            this.gridMaterial.AllowUserToAddRows = false;
            this.gridMaterial.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.gridMaterial.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.gridMaterial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gridMaterial.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridMaterial.BackgroundColor = System.Drawing.Color.White;
            this.gridMaterial.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Semibold", 10.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridMaterial.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gridMaterial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridMaterial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.materialId,
            this.materialName,
            this.qty,
            this.wastage});
            this.gridMaterial.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridMaterial.DefaultCellStyle = dataGridViewCellStyle6;
            this.gridMaterial.Location = new System.Drawing.Point(508, 556);
            this.gridMaterial.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridMaterial.Name = "gridMaterial";
            this.gridMaterial.ReadOnly = true;
            this.gridMaterial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridMaterial.Size = new System.Drawing.Size(871, 412);
            this.gridMaterial.TabIndex = 258;
            this.gridMaterial.TabStop = false;
            this.gridMaterial.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridMaterial_CellClick);
            // 
            // materialId
            // 
            this.materialId.HeaderText = "MATERIAL ID";
            this.materialId.Name = "materialId";
            this.materialId.ReadOnly = true;
            this.materialId.Width = 148;
            // 
            // materialName
            // 
            this.materialName.HeaderText = "MATERIAL NAME";
            this.materialName.Name = "materialName";
            this.materialName.ReadOnly = true;
            this.materialName.Width = 182;
            // 
            // qty
            // 
            this.qty.HeaderText = "QTY";
            this.qty.Name = "qty";
            this.qty.ReadOnly = true;
            this.qty.Width = 74;
            // 
            // wastage
            // 
            this.wastage.HeaderText = "WASTAGE %";
            this.wastage.Name = "wastage";
            this.wastage.ReadOnly = true;
            this.wastage.Width = 142;
            // 
            // txtNumberOfPackages
            // 
            this.txtNumberOfPackages.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtNumberOfPackages.Location = new System.Drawing.Point(176, 747);
            this.txtNumberOfPackages.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNumberOfPackages.Name = "txtNumberOfPackages";
            this.txtNumberOfPackages.Size = new System.Drawing.Size(323, 29);
            this.txtNumberOfPackages.TabIndex = 259;
            this.txtNumberOfPackages.Text = "0";
            this.txtNumberOfPackages.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRawWeight_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(15, 753);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 20);
            this.label5.TabIndex = 260;
            this.label5.Text = "NUMBER OF PAGES";
            // 
            // txtPcsInBundle
            // 
            this.txtPcsInBundle.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtPcsInBundle.Location = new System.Drawing.Point(176, 785);
            this.txtPcsInBundle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPcsInBundle.Name = "txtPcsInBundle";
            this.txtPcsInBundle.Size = new System.Drawing.Size(323, 29);
            this.txtPcsInBundle.TabIndex = 261;
            this.txtPcsInBundle.Text = "0";
            this.txtPcsInBundle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRawWeight_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(15, 791);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 20);
            this.label6.TabIndex = 262;
            this.label6.Text = "PCS IN BUNDLE";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(24)))), ((int)(((byte)(38)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.ImageIndex = 2;
            this.btnDelete.Location = new System.Drawing.Point(1239, 976);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(140, 31);
            this.btnDelete.TabIndex = 354;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cmbBindingType
            // 
            this.cmbBindingType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbBindingType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBindingType.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbBindingType.FormattingEnabled = true;
            this.cmbBindingType.Location = new System.Drawing.Point(176, 671);
            this.cmbBindingType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbBindingType.Name = "cmbBindingType";
            this.cmbBindingType.Size = new System.Drawing.Size(323, 29);
            this.cmbBindingType.TabIndex = 355;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(15, 677);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 20);
            this.label7.TabIndex = 356;
            this.label7.Text = "BINDING TYPE";
            // 
            // txtWastage
            // 
            this.txtWastage.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtWastage.Location = new System.Drawing.Point(176, 938);
            this.txtWastage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtWastage.Name = "txtWastage";
            this.txtWastage.Size = new System.Drawing.Size(220, 29);
            this.txtWastage.TabIndex = 357;
            this.txtWastage.Text = "0";
            this.txtWastage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRawWeight_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(15, 944);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 20);
            this.label8.TabIndex = 358;
            this.label8.Text = "WASTAGE %";
            // 
            // frmFinishedProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1387, 1014);
            this.Controls.Add(this.txtWastage);
            this.Controls.Add(this.txtOpeningRate);
            this.Controls.Add(this.lblNetWeight);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbBindingType);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.txtPcsInBundle);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtNumberOfPackages);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.gridMaterial);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cmbMatrial);
            this.Controls.Add(this.txtMaterialQty);
            this.Controls.Add(this.txtOpeningQty);
            this.Controls.Add(this.cmbBrand);
            this.Controls.Add(this.lblBrand);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.lblRawMaterial);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtProductCode);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grdSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSEARCH);
            this.Controls.Add(this.lblProductCode);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.pnlHEADER);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(1405, 1176);
            this.Name = "frmFinishedProducts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Finished Products";
            this.Load += new System.EventHandler(this.frmFinishedProducts_Load);
            this.pnlHEADER.ResumeLayout(false);
            this.pnlHEADER.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMaterial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHEADER;
        private System.Windows.Forms.Label lblHEADING;
        private System.Windows.Forms.DataGridView grdSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSEARCH;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.Label lblProductCode;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.ComboBox cmbBrand;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblNetWeight;
        private System.Windows.Forms.Label lblRawMaterial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOpeningQty;
        private System.Windows.Forms.TextBox txtOpeningRate;
        private System.Windows.Forms.ComboBox cmbMatrial;
        private System.Windows.Forms.TextBox txtMaterialQty;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView gridMaterial;
        private System.Windows.Forms.TextBox txtNumberOfPackages;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPcsInBundle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox cmbBindingType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtWastage;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn materialId;
        private System.Windows.Forms.DataGridViewTextBoxColumn materialName;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn wastage;
    }
}