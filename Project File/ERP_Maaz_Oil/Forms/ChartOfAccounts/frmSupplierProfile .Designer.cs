namespace ERP_Maaz_Oil.Forms
{
    partial class frmSupplierProfile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSupplierProfile));
            this.pnlHEADER = new System.Windows.Forms.Panel();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.lblHEADING = new System.Windows.Forms.Label();
            this.grdSEARCH = new System.Windows.Forms.DataGridView();
            this.txtSEARCH = new System.Windows.Forms.TextBox();
            this.lblSEARCH = new System.Windows.Forms.Label();
            this.btnCLEAR = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnSAVE = new System.Windows.Forms.Button();
            this.lblCITY = new System.Windows.Forms.Label();
            this.cmbCITY = new SergeUtils.EasyCompletionComboBox();
            this.txtMOBILE = new System.Windows.Forms.TextBox();
            this.lblMOBILE = new System.Windows.Forms.Label();
            this.txtEMAIL = new System.Windows.Forms.TextBox();
            this.lblEMAIL = new System.Windows.Forms.Label();
            this.chkDeActive = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSUPPLIER = new SergeUtils.EasyCompletionComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNTN = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSTRN = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGST = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtLIMIT = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCONTACT_PERSON = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbTYPE = new SergeUtils.EasyCompletionComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbArea = new SergeUtils.EasyCompletionComboBox();
            this.btnAddArea = new System.Windows.Forms.PictureBox();
            this.btnADD_CITY = new System.Windows.Forms.PictureBox();
            this.txtADDRESS = new System.Windows.Forms.TextBox();
            this.pnlHEADER.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSEARCH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddArea)).BeginInit();
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
            this.pnlHEADER.Size = new System.Drawing.Size(1004, 88);
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
            this.lblHEADING.Font = new System.Drawing.Font("Berlin Sans FB", 16.75F);
            this.lblHEADING.ForeColor = System.Drawing.Color.White;
            this.lblHEADING.Location = new System.Drawing.Point(6, 25);
            this.lblHEADING.Name = "lblHEADING";
            this.lblHEADING.Size = new System.Drawing.Size(201, 26);
            this.lblHEADING.TabIndex = 23;
            this.lblHEADING.Text = "SUPPLIER PROFILE";
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
            this.grdSEARCH.Location = new System.Drawing.Point(4, 126);
            this.grdSEARCH.Name = "grdSEARCH";
            this.grdSEARCH.ReadOnly = true;
            this.grdSEARCH.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSEARCH.Size = new System.Drawing.Size(992, 191);
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
            this.txtSEARCH.Size = new System.Drawing.Size(924, 25);
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
            this.btnCLEAR.Location = new System.Drawing.Point(880, 477);
            this.btnCLEAR.Name = "btnCLEAR";
            this.btnCLEAR.Size = new System.Drawing.Size(116, 25);
            this.btnCLEAR.TabIndex = 14;
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
            this.btnSAVE.Location = new System.Drawing.Point(761, 477);
            this.btnSAVE.Name = "btnSAVE";
            this.btnSAVE.Size = new System.Drawing.Size(114, 25);
            this.btnSAVE.TabIndex = 13;
            this.btnSAVE.Text = "SAVE";
            this.btnSAVE.UseVisualStyleBackColor = false;
            this.btnSAVE.Click += new System.EventHandler(this.btnSAVE_Click);
            // 
            // lblCITY
            // 
            this.lblCITY.AutoSize = true;
            this.lblCITY.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblCITY.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCITY.Location = new System.Drawing.Point(315, 390);
            this.lblCITY.Name = "lblCITY";
            this.lblCITY.Size = new System.Drawing.Size(35, 15);
            this.lblCITY.TabIndex = 212;
            this.lblCITY.Text = "CITY:";
            // 
            // cmbCITY
            // 
            this.cmbCITY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCITY.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCITY.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbCITY.FormattingEnabled = true;
            this.cmbCITY.Location = new System.Drawing.Point(429, 385);
            this.cmbCITY.Name = "cmbCITY";
            this.cmbCITY.Size = new System.Drawing.Size(210, 25);
            this.cmbCITY.TabIndex = 8;
            this.cmbCITY.DropDown += new System.EventHandler(this.cmbCITY_DropDown);
            this.cmbCITY.SelectedIndexChanged += new System.EventHandler(this.cmbPACCOUNT_SelectedIndexChanged);
            this.cmbCITY.TextUpdate += new System.EventHandler(this.cmbVENDOR_TextUpdate);
            this.cmbCITY.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmbCITY_PreviewKeyDown);
            // 
            // txtMOBILE
            // 
            this.txtMOBILE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMOBILE.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtMOBILE.Location = new System.Drawing.Point(74, 447);
            this.txtMOBILE.MaxLength = 11;
            this.txtMOBILE.Name = "txtMOBILE";
            this.txtMOBILE.Size = new System.Drawing.Size(235, 25);
            this.txtMOBILE.TabIndex = 5;
            this.txtMOBILE.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtPHONE_MouseClick);
            this.txtMOBILE.Enter += new System.EventHandler(this.txtPHONE_Enter);
            this.txtMOBILE.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPHONE_KeyPress);
            this.txtMOBILE.Leave += new System.EventHandler(this.txtPHONE_Leave);
            // 
            // lblMOBILE
            // 
            this.lblMOBILE.AutoSize = true;
            this.lblMOBILE.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblMOBILE.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblMOBILE.Location = new System.Drawing.Point(9, 452);
            this.lblMOBILE.Name = "lblMOBILE";
            this.lblMOBILE.Size = new System.Drawing.Size(53, 15);
            this.lblMOBILE.TabIndex = 224;
            this.lblMOBILE.Text = "MOBILE:";
            // 
            // txtEMAIL
            // 
            this.txtEMAIL.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEMAIL.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtEMAIL.Location = new System.Drawing.Point(429, 354);
            this.txtEMAIL.MaxLength = 100;
            this.txtEMAIL.Name = "txtEMAIL";
            this.txtEMAIL.Size = new System.Drawing.Size(235, 25);
            this.txtEMAIL.TabIndex = 7;
            this.txtEMAIL.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtPHONE_MouseClick);
            this.txtEMAIL.Enter += new System.EventHandler(this.txtPHONE_Enter);
            this.txtEMAIL.Leave += new System.EventHandler(this.txtPHONE_Leave);
            // 
            // lblEMAIL
            // 
            this.lblEMAIL.AutoSize = true;
            this.lblEMAIL.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblEMAIL.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblEMAIL.Location = new System.Drawing.Point(670, 403);
            this.lblEMAIL.Name = "lblEMAIL";
            this.lblEMAIL.Size = new System.Drawing.Size(63, 15);
            this.lblEMAIL.TabIndex = 226;
            this.lblEMAIL.Text = "ADDRESS:";
            // 
            // chkDeActive
            // 
            this.chkDeActive.AutoSize = true;
            this.chkDeActive.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.chkDeActive.Location = new System.Drawing.Point(74, 480);
            this.chkDeActive.Name = "chkDeActive";
            this.chkDeActive.Size = new System.Drawing.Size(86, 19);
            this.chkDeActive.TabIndex = 12;
            this.chkDeActive.Text = "DE-ACTIVE";
            this.chkDeActive.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(9, 328);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 212;
            this.label1.Text = "SUPPLIER";
            // 
            // cmbSUPPLIER
            // 
            this.cmbSUPPLIER.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSUPPLIER.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSUPPLIER.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbSUPPLIER.FormattingEnabled = true;
            this.cmbSUPPLIER.Location = new System.Drawing.Point(74, 323);
            this.cmbSUPPLIER.Name = "cmbSUPPLIER";
            this.cmbSUPPLIER.Size = new System.Drawing.Size(235, 25);
            this.cmbSUPPLIER.TabIndex = 1;
            this.cmbSUPPLIER.DropDown += new System.EventHandler(this.cmbCITY_DropDown);
            this.cmbSUPPLIER.SelectedIndexChanged += new System.EventHandler(this.cmbSUPPLIER_SelectedIndexChanged);
            this.cmbSUPPLIER.TextUpdate += new System.EventHandler(this.cmbVENDOR_TextUpdate);
            this.cmbSUPPLIER.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmbCITY_PreviewKeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(9, 359);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 226;
            this.label2.Text = "NTN #:";
            // 
            // txtNTN
            // 
            this.txtNTN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNTN.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtNTN.Location = new System.Drawing.Point(74, 354);
            this.txtNTN.MaxLength = 32000;
            this.txtNTN.Name = "txtNTN";
            this.txtNTN.Size = new System.Drawing.Size(235, 25);
            this.txtNTN.TabIndex = 2;
            this.txtNTN.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtPHONE_MouseClick);
            this.txtNTN.Enter += new System.EventHandler(this.txtPHONE_Enter);
            this.txtNTN.Leave += new System.EventHandler(this.txtPHONE_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(9, 390);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 15);
            this.label3.TabIndex = 226;
            this.label3.Text = "STRN #";
            // 
            // txtSTRN
            // 
            this.txtSTRN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSTRN.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtSTRN.Location = new System.Drawing.Point(74, 385);
            this.txtSTRN.MaxLength = 32000;
            this.txtSTRN.Name = "txtSTRN";
            this.txtSTRN.Size = new System.Drawing.Size(235, 25);
            this.txtSTRN.TabIndex = 3;
            this.txtSTRN.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtPHONE_MouseClick);
            this.txtSTRN.Enter += new System.EventHandler(this.txtPHONE_Enter);
            this.txtSTRN.Leave += new System.EventHandler(this.txtPHONE_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(9, 421);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 15);
            this.label4.TabIndex = 226;
            this.label4.Text = "GST #:";
            // 
            // txtGST
            // 
            this.txtGST.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGST.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtGST.Location = new System.Drawing.Point(74, 416);
            this.txtGST.MaxLength = 32000;
            this.txtGST.Name = "txtGST";
            this.txtGST.Size = new System.Drawing.Size(235, 25);
            this.txtGST.TabIndex = 4;
            this.txtGST.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtPHONE_MouseClick);
            this.txtGST.Enter += new System.EventHandler(this.txtPHONE_Enter);
            this.txtGST.Leave += new System.EventHandler(this.txtPHONE_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(315, 359);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 15);
            this.label5.TabIndex = 226;
            this.label5.Text = "EMAIL:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(68)))), ((int)(((byte)(2)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.ImageIndex = 0;
            this.button1.Location = new System.Drawing.Point(572, 590);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 25);
            this.button1.TabIndex = 8;
            this.button1.Text = "SAVE";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnSAVE_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DimGray;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.ImageIndex = 1;
            this.button2.Location = new System.Drawing.Point(710, 590);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 25);
            this.button2.TabIndex = 9;
            this.button2.Text = "CLEAR";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.btnCLEAR_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(670, 328);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 15);
            this.label7.TabIndex = 226;
            this.label7.Text = "CREDIT LIMIT:";
            // 
            // txtLIMIT
            // 
            this.txtLIMIT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLIMIT.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtLIMIT.Location = new System.Drawing.Point(761, 323);
            this.txtLIMIT.MaxLength = 100;
            this.txtLIMIT.Name = "txtLIMIT";
            this.txtLIMIT.Size = new System.Drawing.Size(235, 25);
            this.txtLIMIT.TabIndex = 9;
            this.txtLIMIT.Text = "0";
            this.txtLIMIT.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtPHONE_MouseClick);
            this.txtLIMIT.Enter += new System.EventHandler(this.txtPHONE_Enter);
            this.txtLIMIT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPHONE_KeyPress);
            this.txtLIMIT.Leave += new System.EventHandler(this.txtPHONE_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(315, 452);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 15);
            this.label8.TabIndex = 226;
            this.label8.Text = "CONTACT PERSON";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // txtCONTACT_PERSON
            // 
            this.txtCONTACT_PERSON.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCONTACT_PERSON.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtCONTACT_PERSON.Location = new System.Drawing.Point(429, 447);
            this.txtCONTACT_PERSON.MaxLength = 32000;
            this.txtCONTACT_PERSON.Name = "txtCONTACT_PERSON";
            this.txtCONTACT_PERSON.Size = new System.Drawing.Size(235, 25);
            this.txtCONTACT_PERSON.TabIndex = 10;
            this.txtCONTACT_PERSON.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtPHONE_MouseClick);
            this.txtCONTACT_PERSON.Enter += new System.EventHandler(this.txtPHONE_Enter);
            this.txtCONTACT_PERSON.Leave += new System.EventHandler(this.txtPHONE_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(315, 328);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 15);
            this.label9.TabIndex = 212;
            this.label9.Text = "SUPPLIER TYPE";
            this.label9.Visible = false;
            // 
            // cmbTYPE
            // 
            this.cmbTYPE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTYPE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTYPE.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbTYPE.FormattingEnabled = true;
            this.cmbTYPE.Location = new System.Drawing.Point(429, 323);
            this.cmbTYPE.Name = "cmbTYPE";
            this.cmbTYPE.Size = new System.Drawing.Size(235, 25);
            this.cmbTYPE.TabIndex = 6;
            this.cmbTYPE.Visible = false;
            this.cmbTYPE.DropDown += new System.EventHandler(this.cmbCITY_DropDown);
            this.cmbTYPE.TextUpdate += new System.EventHandler(this.cmbVENDOR_TextUpdate);
            this.cmbTYPE.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmbCITY_PreviewKeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(315, 421);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 15);
            this.label6.TabIndex = 212;
            this.label6.Text = "AREA";
            // 
            // cmbArea
            // 
            this.cmbArea.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbArea.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbArea.Enabled = false;
            this.cmbArea.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbArea.FormattingEnabled = true;
            this.cmbArea.Location = new System.Drawing.Point(429, 416);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(210, 25);
            this.cmbArea.TabIndex = 6;
            this.cmbArea.DropDown += new System.EventHandler(this.cmbCITY_DropDown);
            this.cmbArea.TextUpdate += new System.EventHandler(this.cmbVENDOR_TextUpdate);
            this.cmbArea.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmbCITY_PreviewKeyDown);
            // 
            // btnAddArea
            // 
            this.btnAddArea.BackColor = System.Drawing.Color.Transparent;
            this.btnAddArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnAddArea.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddArea.Image = global::ERP_Maaz_Oil.Properties.Resources.plus;
            this.btnAddArea.Location = new System.Drawing.Point(639, 416);
            this.btnAddArea.Name = "btnAddArea";
            this.btnAddArea.Size = new System.Drawing.Size(25, 25);
            this.btnAddArea.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnAddArea.TabIndex = 241;
            this.btnAddArea.TabStop = false;
            this.btnAddArea.Click += new System.EventHandler(this.btnAddArea_Click);
            // 
            // btnADD_CITY
            // 
            this.btnADD_CITY.BackColor = System.Drawing.Color.Transparent;
            this.btnADD_CITY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnADD_CITY.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnADD_CITY.Image = global::ERP_Maaz_Oil.Properties.Resources.plus;
            this.btnADD_CITY.Location = new System.Drawing.Point(639, 385);
            this.btnADD_CITY.Name = "btnADD_CITY";
            this.btnADD_CITY.Size = new System.Drawing.Size(25, 25);
            this.btnADD_CITY.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnADD_CITY.TabIndex = 240;
            this.btnADD_CITY.TabStop = false;
            this.btnADD_CITY.Click += new System.EventHandler(this.btnADD_CITY_Click);
            // 
            // txtADDRESS
            // 
            this.txtADDRESS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtADDRESS.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtADDRESS.Location = new System.Drawing.Point(761, 354);
            this.txtADDRESS.MaxLength = 32000;
            this.txtADDRESS.Multiline = true;
            this.txtADDRESS.Name = "txtADDRESS";
            this.txtADDRESS.Size = new System.Drawing.Size(235, 117);
            this.txtADDRESS.TabIndex = 242;
            // 
            // frmSupplierProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1004, 515);
            this.Controls.Add(this.txtADDRESS);
            this.Controls.Add(this.btnAddArea);
            this.Controls.Add(this.btnADD_CITY);
            this.Controls.Add(this.txtMOBILE);
            this.Controls.Add(this.lblMOBILE);
            this.Controls.Add(this.cmbCITY);
            this.Controls.Add(this.lblCITY);
            this.Controls.Add(this.chkDeActive);
            this.Controls.Add(this.txtGST);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNTN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSTRN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCONTACT_PERSON);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtLIMIT);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtEMAIL);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lblEMAIL);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCLEAR);
            this.Controls.Add(this.btnSAVE);
            this.Controls.Add(this.grdSEARCH);
            this.Controls.Add(this.txtSEARCH);
            this.Controls.Add(this.lblSEARCH);
            this.Controls.Add(this.cmbArea);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbTYPE);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbSUPPLIER);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlHEADER);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1314, 703);
            this.Name = "frmSupplierProfile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SUPPILER PROFILE";
            this.Load += new System.EventHandler(this.frm_AddGroupAccounts_Load);
            this.pnlHEADER.ResumeLayout(false);
            this.pnlHEADER.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSEARCH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddArea)).EndInit();
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
        private System.Windows.Forms.Label lblCITY;
        private SergeUtils.EasyCompletionComboBox cmbCITY;
        private System.Windows.Forms.TextBox txtMOBILE;
        private System.Windows.Forms.Label lblMOBILE;
        private System.Windows.Forms.TextBox txtEMAIL;
        private System.Windows.Forms.Label lblEMAIL;
        private System.Windows.Forms.CheckBox chkDeActive;
        private System.Windows.Forms.Label label1;
        private SergeUtils.EasyCompletionComboBox cmbSUPPLIER;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNTN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSTRN;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtGST;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtLIMIT;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCONTACT_PERSON;
        private System.Windows.Forms.Label label9;
        private SergeUtils.EasyCompletionComboBox cmbTYPE;
        private System.Windows.Forms.Label label6;
        private SergeUtils.EasyCompletionComboBox cmbArea;
        private System.Windows.Forms.PictureBox btnAddArea;
        private System.Windows.Forms.PictureBox btnADD_CITY;
        private System.Windows.Forms.TextBox txtADDRESS;
    }
}