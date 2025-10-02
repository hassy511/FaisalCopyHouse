namespace ERP_Maaz_Oil
{
    partial class frmAddGroupAccounts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddGroupAccounts));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblHEADING = new System.Windows.Forms.Label();
            this.pnlHEADER = new System.Windows.Forms.Panel();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.btnCLEAR = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnSAVE = new System.Windows.Forms.Button();
            this.grdSEARCH = new System.Windows.Forms.DataGridView();
            this.txtSEARCH = new System.Windows.Forms.TextBox();
            this.lblSEARCH = new System.Windows.Forms.Label();
            this.txtGROUP = new System.Windows.Forms.TextBox();
            this.lblGROUP = new System.Windows.Forms.Label();
            this.cmbPACCOUNT = new SergeUtils.EasyCompletionComboBox();
            this.lblPACCOUNT = new System.Windows.Forms.Label();
            this.cmbACCOUNT_NATURE = new SergeUtils.EasyCompletionComboBox();
            this.lblACCOUNT_NATURE = new System.Windows.Forms.Label();
            this.pnlHEADER.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSEARCH)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHEADING
            // 
            this.lblHEADING.AutoSize = true;
            this.lblHEADING.BackColor = System.Drawing.Color.Transparent;
            this.lblHEADING.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHEADING.ForeColor = System.Drawing.Color.White;
            this.lblHEADING.Location = new System.Drawing.Point(12, 36);
            this.lblHEADING.Name = "lblHEADING";
            this.lblHEADING.Size = new System.Drawing.Size(255, 23);
            this.lblHEADING.TabIndex = 23;
            this.lblHEADING.Text = "ADD BRANCH ACCOUNTS";
            // 
            // pnlHEADER
            // 
            this.pnlHEADER.BackColor = System.Drawing.Color.Transparent;
            this.pnlHEADER.BackgroundImage = global::ERP_Maaz_Oil.Properties.Resources.header;
            this.pnlHEADER.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlHEADER.Controls.Add(this.pictureBox15);
            this.pnlHEADER.Controls.Add(this.lblHEADING);
            this.pnlHEADER.Controls.Add(this.pictureBox14);
            this.pnlHEADER.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHEADER.Location = new System.Drawing.Point(0, 0);
            this.pnlHEADER.Name = "pnlHEADER";
            this.pnlHEADER.Size = new System.Drawing.Size(725, 85);
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
            // pictureBox14
            // 
            this.pictureBox14.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox14.Location = new System.Drawing.Point(1285, 3);
            this.pictureBox14.Name = "pictureBox14";
            this.pictureBox14.Size = new System.Drawing.Size(49, 20);
            this.pictureBox14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox14.TabIndex = 24;
            this.pictureBox14.TabStop = false;
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
            this.btnCLEAR.Location = new System.Drawing.Point(600, 573);
            this.btnCLEAR.Name = "btnCLEAR";
            this.btnCLEAR.Size = new System.Drawing.Size(116, 25);
            this.btnCLEAR.TabIndex = 226;
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
            this.btnSAVE.Location = new System.Drawing.Point(486, 573);
            this.btnSAVE.Name = "btnSAVE";
            this.btnSAVE.Size = new System.Drawing.Size(114, 25);
            this.btnSAVE.TabIndex = 225;
            this.btnSAVE.Text = "SAVE";
            this.btnSAVE.UseVisualStyleBackColor = false;
            this.btnSAVE.Click += new System.EventHandler(this.btnSAVE_Click);
            // 
            // grdSEARCH
            // 
            this.grdSEARCH.AllowUserToAddRows = false;
            this.grdSEARCH.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.grdSEARCH.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.grdSEARCH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdSEARCH.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grdSEARCH.BackgroundColor = System.Drawing.Color.White;
            this.grdSEARCH.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Semibold", 10.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdSEARCH.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.grdSEARCH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSEARCH.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdSEARCH.DefaultCellStyle = dataGridViewCellStyle6;
            this.grdSEARCH.Location = new System.Drawing.Point(12, 127);
            this.grdSEARCH.Name = "grdSEARCH";
            this.grdSEARCH.ReadOnly = true;
            this.grdSEARCH.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSEARCH.Size = new System.Drawing.Size(704, 409);
            this.grdSEARCH.TabIndex = 232;
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
            this.txtSEARCH.Location = new System.Drawing.Point(72, 96);
            this.txtSEARCH.Name = "txtSEARCH";
            this.txtSEARCH.Size = new System.Drawing.Size(644, 25);
            this.txtSEARCH.TabIndex = 231;
            this.txtSEARCH.TextChanged += new System.EventHandler(this.txtSEARCH_TextChanged);
            // 
            // lblSEARCH
            // 
            this.lblSEARCH.AutoSize = true;
            this.lblSEARCH.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSEARCH.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSEARCH.Location = new System.Drawing.Point(9, 100);
            this.lblSEARCH.Name = "lblSEARCH";
            this.lblSEARCH.Size = new System.Drawing.Size(57, 17);
            this.lblSEARCH.TabIndex = 230;
            this.lblSEARCH.Text = "SEARCH";
            // 
            // txtGROUP
            // 
            this.txtGROUP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGROUP.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtGROUP.Location = new System.Drawing.Point(127, 573);
            this.txtGROUP.MaxLength = 100;
            this.txtGROUP.Name = "txtGROUP";
            this.txtGROUP.Size = new System.Drawing.Size(231, 25);
            this.txtGROUP.TabIndex = 224;
            this.txtGROUP.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtGROUP_MouseClick);
            this.txtGROUP.Enter += new System.EventHandler(this.txtGROUP_Enter);
            // 
            // lblGROUP
            // 
            this.lblGROUP.AutoSize = true;
            this.lblGROUP.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblGROUP.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblGROUP.Location = new System.Drawing.Point(9, 578);
            this.lblGROUP.Name = "lblGROUP";
            this.lblGROUP.Size = new System.Drawing.Size(94, 15);
            this.lblGROUP.TabIndex = 229;
            this.lblGROUP.Text = "BRANCH NAME:";
            // 
            // cmbPACCOUNT
            // 
            this.cmbPACCOUNT.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbPACCOUNT.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPACCOUNT.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbPACCOUNT.FormattingEnabled = true;
            this.cmbPACCOUNT.Location = new System.Drawing.Point(486, 542);
            this.cmbPACCOUNT.Name = "cmbPACCOUNT";
            this.cmbPACCOUNT.Size = new System.Drawing.Size(230, 25);
            this.cmbPACCOUNT.TabIndex = 223;
            this.cmbPACCOUNT.DropDown += new System.EventHandler(this.cmbPACCOUNT_DropDown);
            this.cmbPACCOUNT.SelectedIndexChanged += new System.EventHandler(this.cmbPACCOUNT_SelectedIndexChanged);
            this.cmbPACCOUNT.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmbPACCOUNT_PreviewKeyDown);
            // 
            // lblPACCOUNT
            // 
            this.lblPACCOUNT.AutoSize = true;
            this.lblPACCOUNT.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblPACCOUNT.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPACCOUNT.Location = new System.Drawing.Point(364, 547);
            this.lblPACCOUNT.Name = "lblPACCOUNT";
            this.lblPACCOUNT.Size = new System.Drawing.Size(111, 15);
            this.lblPACCOUNT.TabIndex = 228;
            this.lblPACCOUNT.Text = "PARENT ACCOUNT:";
            // 
            // cmbACCOUNT_NATURE
            // 
            this.cmbACCOUNT_NATURE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbACCOUNT_NATURE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbACCOUNT_NATURE.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbACCOUNT_NATURE.FormattingEnabled = true;
            this.cmbACCOUNT_NATURE.Location = new System.Drawing.Point(127, 542);
            this.cmbACCOUNT_NATURE.Name = "cmbACCOUNT_NATURE";
            this.cmbACCOUNT_NATURE.Size = new System.Drawing.Size(231, 25);
            this.cmbACCOUNT_NATURE.TabIndex = 222;
            this.cmbACCOUNT_NATURE.DropDown += new System.EventHandler(this.cmbACCOUNT_NATURE_DropDown);
            this.cmbACCOUNT_NATURE.TextUpdate += new System.EventHandler(this.cmbACCOUNT_NATURE_TextUpdate);
            this.cmbACCOUNT_NATURE.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmbACCOUNT_NATURE_PreviewKeyDown);
            // 
            // lblACCOUNT_NATURE
            // 
            this.lblACCOUNT_NATURE.AutoSize = true;
            this.lblACCOUNT_NATURE.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblACCOUNT_NATURE.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblACCOUNT_NATURE.Location = new System.Drawing.Point(9, 547);
            this.lblACCOUNT_NATURE.Name = "lblACCOUNT_NATURE";
            this.lblACCOUNT_NATURE.Size = new System.Drawing.Size(112, 15);
            this.lblACCOUNT_NATURE.TabIndex = 227;
            this.lblACCOUNT_NATURE.Text = "ACCOUNT NATURE:";
            // 
            // frmAddGroupAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(725, 604);
            this.Controls.Add(this.btnCLEAR);
            this.Controls.Add(this.btnSAVE);
            this.Controls.Add(this.grdSEARCH);
            this.Controls.Add(this.txtSEARCH);
            this.Controls.Add(this.lblSEARCH);
            this.Controls.Add(this.txtGROUP);
            this.Controls.Add(this.lblGROUP);
            this.Controls.Add(this.cmbPACCOUNT);
            this.Controls.Add(this.lblPACCOUNT);
            this.Controls.Add(this.cmbACCOUNT_NATURE);
            this.Controls.Add(this.lblACCOUNT_NATURE);
            this.Controls.Add(this.pnlHEADER);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddGroupAccounts";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ADD BRANCH ACCOUNTS";
            this.Load += new System.EventHandler(this.frmAddGroupAccounts_Load);
            this.pnlHEADER.ResumeLayout(false);
            this.pnlHEADER.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSEARCH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHEADING;
        private System.Windows.Forms.Panel pnlHEADER;
        private System.Windows.Forms.PictureBox pictureBox15;
        private System.Windows.Forms.PictureBox pictureBox14;
        private System.Windows.Forms.Button btnCLEAR;
        private System.Windows.Forms.Button btnSAVE;
        private System.Windows.Forms.DataGridView grdSEARCH;
        private System.Windows.Forms.TextBox txtSEARCH;
        private System.Windows.Forms.Label lblSEARCH;
        private System.Windows.Forms.TextBox txtGROUP;
        private System.Windows.Forms.Label lblGROUP;
        private SergeUtils.EasyCompletionComboBox cmbPACCOUNT;
        private System.Windows.Forms.Label lblPACCOUNT;
        private SergeUtils.EasyCompletionComboBox cmbACCOUNT_NATURE;
        private System.Windows.Forms.Label lblACCOUNT_NATURE;
        private System.Windows.Forms.ImageList imageList1;
    }
}

