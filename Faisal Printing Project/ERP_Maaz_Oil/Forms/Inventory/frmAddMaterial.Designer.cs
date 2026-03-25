namespace ERP_Maaz_Oil.Forms
{
    partial class frmAddMaterial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddMaterial));
            this.pnlHEADER = new System.Windows.Forms.Panel();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.lblHEADING = new System.Windows.Forms.Label();
            this.grdSearch = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSEARCH = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.chkDeActive = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaterialCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaterialName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOpeningQty = new System.Windows.Forms.TextBox();
            this.txtOpeningRate = new System.Windows.Forms.TextBox();
            this.cmbUnit = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtGrammage = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbMaterialType = new SergeUtils.EasyCompletionComboBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.pnlHEADER.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearch)).BeginInit();
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
            this.pnlHEADER.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlHEADER.Name = "pnlHEADER";
            this.pnlHEADER.Size = new System.Drawing.Size(1368, 108);
            this.pnlHEADER.TabIndex = 36;
            // 
            // pictureBox15
            // 
            this.pictureBox15.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox15.Location = new System.Drawing.Point(1787, 4);
            this.pictureBox15.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.lblHEADING.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.75F);
            this.lblHEADING.ForeColor = System.Drawing.Color.White;
            this.lblHEADING.Location = new System.Drawing.Point(8, 31);
            this.lblHEADING.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHEADING.Name = "lblHEADING";
            this.lblHEADING.Size = new System.Drawing.Size(357, 32);
            this.lblHEADING.TabIndex = 23;
            this.lblHEADING.Text = "ADD OPENING MATERIAL";
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
            this.grdSearch.Location = new System.Drawing.Point(7, 155);
            this.grdSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grdSearch.Name = "grdSearch";
            this.grdSearch.ReadOnly = true;
            this.grdSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSearch.Size = new System.Drawing.Size(1360, 384);
            this.grdSearch.TabIndex = 221;
            this.grdSearch.TabStop = false;
            this.grdSearch.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdSEARCH_CellClick);
            this.grdSearch.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdSearch_CellDoubleClick);
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
            this.txtSearch.Size = new System.Drawing.Size(1264, 29);
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
            this.btnClear.Location = new System.Drawing.Point(1120, 698);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(172, 31);
            this.btnClear.TabIndex = 10;
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
            this.btnSave.Location = new System.Drawing.Point(919, 698);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(193, 31);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSAVE_Click);
            // 
            // chkDeActive
            // 
            this.chkDeActive.AutoSize = true;
            this.chkDeActive.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.chkDeActive.Location = new System.Drawing.Point(484, 736);
            this.chkDeActive.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkDeActive.Name = "chkDeActive";
            this.chkDeActive.Size = new System.Drawing.Size(105, 24);
            this.chkDeActive.TabIndex = 8;
            this.chkDeActive.Text = "DE-ACTIVE";
            this.chkDeActive.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(84, 553);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 20);
            this.label1.TabIndex = 212;
            this.label1.Text = "MATERIAL TYPE";
            // 
            // txtMaterialCode
            // 
            this.txtMaterialCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMaterialCode.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtMaterialCode.Location = new System.Drawing.Point(225, 622);
            this.txtMaterialCode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMaterialCode.MaxLength = 32000;
            this.txtMaterialCode.Name = "txtMaterialCode";
            this.txtMaterialCode.Size = new System.Drawing.Size(372, 29);
            this.txtMaterialCode.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(84, 628);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 20);
            this.label2.TabIndex = 212;
            this.label2.Text = "MATERIAL CODE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(84, 666);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 20);
            this.label3.TabIndex = 212;
            this.label3.Text = "MATERIAL NAME";
            // 
            // txtMaterialName
            // 
            this.txtMaterialName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMaterialName.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtMaterialName.Location = new System.Drawing.Point(225, 660);
            this.txtMaterialName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMaterialName.MaxLength = 32000;
            this.txtMaterialName.Name = "txtMaterialName";
            this.txtMaterialName.Size = new System.Drawing.Size(372, 29);
            this.txtMaterialName.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(84, 704);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 20);
            this.label4.TabIndex = 212;
            this.label4.Text = "OPENING QTY";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(792, 553);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 20);
            this.label5.TabIndex = 212;
            this.label5.Text = "OPENING RATE";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // txtOpeningQty
            // 
            this.txtOpeningQty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOpeningQty.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtOpeningQty.Location = new System.Drawing.Point(225, 698);
            this.txtOpeningQty.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtOpeningQty.MaxLength = 11;
            this.txtOpeningQty.Name = "txtOpeningQty";
            this.txtOpeningQty.Size = new System.Drawing.Size(372, 29);
            this.txtOpeningQty.TabIndex = 6;
            this.txtOpeningQty.Text = "0";
            this.txtOpeningQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQTY_KeyPress);
            // 
            // txtOpeningRate
            // 
            this.txtOpeningRate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOpeningRate.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtOpeningRate.Location = new System.Drawing.Point(919, 546);
            this.txtOpeningRate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtOpeningRate.MaxLength = 11;
            this.txtOpeningRate.Name = "txtOpeningRate";
            this.txtOpeningRate.Size = new System.Drawing.Size(372, 29);
            this.txtOpeningRate.TabIndex = 7;
            this.txtOpeningRate.Text = "0";
            this.txtOpeningRate.TextChanged += new System.EventHandler(this.txtOpeningRate_TextChanged);
            this.txtOpeningRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQTY_KeyPress);
            // 
            // cmbUnit
            // 
            this.cmbUnit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbUnit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbUnit.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbUnit.FormattingEnabled = true;
            this.cmbUnit.Items.AddRange(new object[] {
            "--SELECT UNIT--",
            "KGS",
            "PCS"});
            this.cmbUnit.Location = new System.Drawing.Point(225, 583);
            this.cmbUnit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(372, 29);
            this.cmbUnit.TabIndex = 2;
            this.cmbUnit.DropDown += new System.EventHandler(this.cmbCITY_DropDown);
            this.cmbUnit.SelectedIndexChanged += new System.EventHandler(this.cmbPACCOUNT_SelectedIndexChanged);
            this.cmbUnit.TextUpdate += new System.EventHandler(this.cmbVENDOR_TextUpdate);
            this.cmbUnit.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmbCITY_PreviewKeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(84, 590);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 20);
            this.label7.TabIndex = 212;
            this.label7.Text = "UNIT ";
            // 
            // txtGrammage
            // 
            this.txtGrammage.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGrammage.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtGrammage.Location = new System.Drawing.Point(919, 660);
            this.txtGrammage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtGrammage.MaxLength = 11;
            this.txtGrammage.Name = "txtGrammage";
            this.txtGrammage.Size = new System.Drawing.Size(372, 29);
            this.txtGrammage.TabIndex = 222;
            this.txtGrammage.Text = "0";
            this.txtGrammage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQTY_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(792, 666);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 20);
            this.label8.TabIndex = 225;
            this.label8.Text = "GRAMMAGE";
            // 
            // cmbMaterialType
            // 
            this.cmbMaterialType.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbMaterialType.FormattingEnabled = true;
            this.cmbMaterialType.ItemHeight = 21;
            this.cmbMaterialType.Location = new System.Drawing.Point(225, 546);
            this.cmbMaterialType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbMaterialType.Name = "cmbMaterialType";
            this.cmbMaterialType.Size = new System.Drawing.Size(372, 29);
            this.cmbMaterialType.TabIndex = 226;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(24)))), ((int)(((byte)(38)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.ImageIndex = 2;
            this.btnDelete.Location = new System.Drawing.Point(919, 736);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(373, 31);
            this.btnDelete.TabIndex = 355;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Location = new System.Drawing.Point(792, 591);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 20);
            this.label10.TabIndex = 356;
            this.label10.Text = "HEIGHT";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // txtHeight
            // 
            this.txtHeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtHeight.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtHeight.Location = new System.Drawing.Point(919, 585);
            this.txtHeight.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtHeight.MaxLength = 11;
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(372, 29);
            this.txtHeight.TabIndex = 357;
            this.txtHeight.Text = "0";
            this.txtHeight.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.txtHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQTY_KeyPress);
            // 
            // txtWidth
            // 
            this.txtWidth.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtWidth.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtWidth.Location = new System.Drawing.Point(919, 622);
            this.txtWidth.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtWidth.MaxLength = 11;
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(372, 29);
            this.txtWidth.TabIndex = 358;
            this.txtWidth.Text = "0";
            this.txtWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQTY_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Location = new System.Drawing.Point(792, 628);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 20);
            this.label11.TabIndex = 359;
            this.label11.Text = "WIDTH";
            // 
            // frmAddMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1368, 777);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.cmbMaterialType);
            this.Controls.Add(this.txtGrammage);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtOpeningRate);
            this.Controls.Add(this.txtOpeningQty);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMaterialName);
            this.Controls.Add(this.txtMaterialCode);
            this.Controls.Add(this.chkDeActive);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grdSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSEARCH);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbUnit);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlHEADER);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximumSize = new System.Drawing.Size(1386, 952);
            this.Name = "frmAddMaterial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MATERIAL";
            this.Load += new System.EventHandler(this.frm_AddGroupAccounts_Load);
            this.pnlHEADER.ResumeLayout(false);
            this.pnlHEADER.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearch)).EndInit();
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
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.CheckBox chkDeActive;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaterialCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaterialName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtOpeningQty;
        private System.Windows.Forms.TextBox txtOpeningRate;
        private System.Windows.Forms.ComboBox cmbUnit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtGrammage;
        private System.Windows.Forms.Label label8;
        private SergeUtils.EasyCompletionComboBox cmbMaterialType;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Label label11;
    }
}