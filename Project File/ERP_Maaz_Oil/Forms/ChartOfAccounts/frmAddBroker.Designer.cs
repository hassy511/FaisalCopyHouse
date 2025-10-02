namespace ERP_Maaz_Oil.Forms
{
    partial class frmAddBroker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddBroker));
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
            this.cmbBROKER = new SergeUtils.EasyCompletionComboBox();
            this.COMISSION_TYPE = new System.Windows.Forms.Label();
            this.cmbCOMISSION = new SergeUtils.EasyCompletionComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCOMISSION = new System.Windows.Forms.TextBox();
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
            this.pnlHEADER.Size = new System.Drawing.Size(745, 88);
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
            this.lblHEADING.Size = new System.Drawing.Size(150, 26);
            this.lblHEADING.TabIndex = 23;
            this.lblHEADING.Text = "ADD BROKER";
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
            this.grdSEARCH.Location = new System.Drawing.Point(2, 126);
            this.grdSEARCH.Name = "grdSEARCH";
            this.grdSEARCH.ReadOnly = true;
            this.grdSEARCH.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSEARCH.Size = new System.Drawing.Size(736, 212);
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
            this.txtSEARCH.Size = new System.Drawing.Size(666, 25);
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
            this.btnCLEAR.Location = new System.Drawing.Point(599, 437);
            this.btnCLEAR.Name = "btnCLEAR";
            this.btnCLEAR.Size = new System.Drawing.Size(139, 25);
            this.btnCLEAR.TabIndex = 9;
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
            this.btnSAVE.Location = new System.Drawing.Point(461, 437);
            this.btnSAVE.Name = "btnSAVE";
            this.btnSAVE.Size = new System.Drawing.Size(139, 25);
            this.btnSAVE.TabIndex = 8;
            this.btnSAVE.Text = "SAVE";
            this.btnSAVE.UseVisualStyleBackColor = false;
            this.btnSAVE.Click += new System.EventHandler(this.btnSAVE_Click);
            // 
            // lblCITY
            // 
            this.lblCITY.AutoSize = true;
            this.lblCITY.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblCITY.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCITY.Location = new System.Drawing.Point(351, 349);
            this.lblCITY.Name = "lblCITY";
            this.lblCITY.Size = new System.Drawing.Size(77, 15);
            this.lblCITY.TabIndex = 212;
            this.lblCITY.Text = "SELECT CITY:";
            // 
            // cmbCITY
            // 
            this.cmbCITY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCITY.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCITY.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbCITY.FormattingEnabled = true;
            this.cmbCITY.Location = new System.Drawing.Point(461, 344);
            this.cmbCITY.Name = "cmbCITY";
            this.cmbCITY.Size = new System.Drawing.Size(277, 25);
            this.cmbCITY.TabIndex = 4;
            this.cmbCITY.DropDown += new System.EventHandler(this.cmbCITY_DropDown);
            this.cmbCITY.TextUpdate += new System.EventHandler(this.cmbVENDOR_TextUpdate);
            this.cmbCITY.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmbCITY_PreviewKeyDown);
            // 
            // txtMOBILE
            // 
            this.txtMOBILE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMOBILE.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtMOBILE.Location = new System.Drawing.Point(68, 406);
            this.txtMOBILE.MaxLength = 11;
            this.txtMOBILE.Name = "txtMOBILE";
            this.txtMOBILE.Size = new System.Drawing.Size(277, 25);
            this.txtMOBILE.TabIndex = 3;
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
            this.lblMOBILE.Location = new System.Drawing.Point(9, 411);
            this.lblMOBILE.Name = "lblMOBILE";
            this.lblMOBILE.Size = new System.Drawing.Size(53, 15);
            this.lblMOBILE.TabIndex = 224;
            this.lblMOBILE.Text = "MOBILE:";
            // 
            // txtEMAIL
            // 
            this.txtEMAIL.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEMAIL.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtEMAIL.Location = new System.Drawing.Point(68, 375);
            this.txtEMAIL.MaxLength = 100;
            this.txtEMAIL.Name = "txtEMAIL";
            this.txtEMAIL.Size = new System.Drawing.Size(277, 25);
            this.txtEMAIL.TabIndex = 2;
            this.txtEMAIL.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtPHONE_MouseClick);
            this.txtEMAIL.Enter += new System.EventHandler(this.txtPHONE_Enter);
            this.txtEMAIL.Leave += new System.EventHandler(this.txtPHONE_Leave);
            // 
            // lblEMAIL
            // 
            this.lblEMAIL.AutoSize = true;
            this.lblEMAIL.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblEMAIL.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblEMAIL.Location = new System.Drawing.Point(9, 380);
            this.lblEMAIL.Name = "lblEMAIL";
            this.lblEMAIL.Size = new System.Drawing.Size(45, 15);
            this.lblEMAIL.TabIndex = 226;
            this.lblEMAIL.Text = "EMAIL:";
            // 
            // chkDeActive
            // 
            this.chkDeActive.AutoSize = true;
            this.chkDeActive.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.chkDeActive.Location = new System.Drawing.Point(68, 442);
            this.chkDeActive.Name = "chkDeActive";
            this.chkDeActive.Size = new System.Drawing.Size(86, 19);
            this.chkDeActive.TabIndex = 7;
            this.chkDeActive.Text = "DE-ACTIVE";
            this.chkDeActive.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(9, 349);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 212;
            this.label1.Text = "BROKER:";
            // 
            // cmbBROKER
            // 
            this.cmbBROKER.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbBROKER.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBROKER.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbBROKER.FormattingEnabled = true;
            this.cmbBROKER.Location = new System.Drawing.Point(68, 344);
            this.cmbBROKER.Name = "cmbBROKER";
            this.cmbBROKER.Size = new System.Drawing.Size(277, 25);
            this.cmbBROKER.TabIndex = 1;
            this.cmbBROKER.DropDown += new System.EventHandler(this.cmbCITY_DropDown);
            this.cmbBROKER.SelectedIndexChanged += new System.EventHandler(this.cmbPACCOUNT_SelectedIndexChanged);
            this.cmbBROKER.TextUpdate += new System.EventHandler(this.cmbVENDOR_TextUpdate);
            this.cmbBROKER.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmbCITY_PreviewKeyDown);
            // 
            // COMISSION_TYPE
            // 
            this.COMISSION_TYPE.AutoSize = true;
            this.COMISSION_TYPE.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.COMISSION_TYPE.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.COMISSION_TYPE.Location = new System.Drawing.Point(351, 411);
            this.COMISSION_TYPE.Name = "COMISSION_TYPE";
            this.COMISSION_TYPE.Size = new System.Drawing.Size(104, 15);
            this.COMISSION_TYPE.TabIndex = 212;
            this.COMISSION_TYPE.Text = "COMISSION TYPE";
            // 
            // cmbCOMISSION
            // 
            this.cmbCOMISSION.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCOMISSION.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCOMISSION.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbCOMISSION.FormattingEnabled = true;
            this.cmbCOMISSION.Items.AddRange(new object[] {
            "Rupess",
            "%"});
            this.cmbCOMISSION.Location = new System.Drawing.Point(461, 406);
            this.cmbCOMISSION.Name = "cmbCOMISSION";
            this.cmbCOMISSION.Size = new System.Drawing.Size(277, 25);
            this.cmbCOMISSION.TabIndex = 6;
            this.cmbCOMISSION.Text = "--------SELECT TYPE---------";
            this.cmbCOMISSION.DropDown += new System.EventHandler(this.cmbCITY_DropDown);
            this.cmbCOMISSION.TextUpdate += new System.EventHandler(this.cmbVENDOR_TextUpdate);
            this.cmbCOMISSION.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmbCITY_PreviewKeyDown);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.checkBox1.Location = new System.Drawing.Point(33, 520);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(86, 19);
            this.checkBox1.TabIndex = 235;
            this.checkBox1.Text = "DE-ACTIVE";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(351, 380);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 15);
            this.label2.TabIndex = 226;
            this.label2.Text = "COMISSION:";
            // 
            // txtCOMISSION
            // 
            this.txtCOMISSION.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCOMISSION.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtCOMISSION.Location = new System.Drawing.Point(461, 375);
            this.txtCOMISSION.MaxLength = 100;
            this.txtCOMISSION.Name = "txtCOMISSION";
            this.txtCOMISSION.Size = new System.Drawing.Size(277, 25);
            this.txtCOMISSION.TabIndex = 5;
            this.txtCOMISSION.Text = "0";
            this.txtCOMISSION.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtPHONE_MouseClick);
            this.txtCOMISSION.Enter += new System.EventHandler(this.txtPHONE_Enter);
            this.txtCOMISSION.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCOMISSION_KeyPress);
            this.txtCOMISSION.Leave += new System.EventHandler(this.txtPHONE_Leave);
            // 
            // frmAddBroker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(745, 471);
            this.Controls.Add(this.grdSEARCH);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.chkDeActive);
            this.Controls.Add(this.txtCOMISSION);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEMAIL);
            this.Controls.Add(this.lblEMAIL);
            this.Controls.Add(this.txtMOBILE);
            this.Controls.Add(this.lblMOBILE);
            this.Controls.Add(this.btnCLEAR);
            this.Controls.Add(this.btnSAVE);
            this.Controls.Add(this.txtSEARCH);
            this.Controls.Add(this.lblSEARCH);
            this.Controls.Add(this.cmbBROKER);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbCOMISSION);
            this.Controls.Add(this.COMISSION_TYPE);
            this.Controls.Add(this.cmbCITY);
            this.Controls.Add(this.lblCITY);
            this.Controls.Add(this.pnlHEADER);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1314, 703);
            this.Name = "frmAddBroker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ADD BROKER";
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
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lblCITY;
        private SergeUtils.EasyCompletionComboBox cmbCITY;
        private System.Windows.Forms.TextBox txtMOBILE;
        private System.Windows.Forms.Label lblMOBILE;
        private System.Windows.Forms.TextBox txtEMAIL;
        private System.Windows.Forms.Label lblEMAIL;
        private System.Windows.Forms.CheckBox chkDeActive;
        private System.Windows.Forms.Label label1;
        private SergeUtils.EasyCompletionComboBox cmbBROKER;
        private System.Windows.Forms.Label COMISSION_TYPE;
        private SergeUtils.EasyCompletionComboBox cmbCOMISSION;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCOMISSION;
    }
}