namespace ERP_Maaz_Oil.Forms
{
    partial class frm_Purchases
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Purchases));
            this.grdSearch = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSEARCH = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.cmbVendor = new SergeUtils.EasyCompletionComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblInvoice = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblV = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblAcc = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlHEADER = new System.Windows.Forms.Panel();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.lblHEADING = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearch)).BeginInit();
            this.pnlHEADER.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            this.SuspendLayout();
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
            this.grdSearch.Location = new System.Drawing.Point(5, 83);
            this.grdSearch.Name = "grdSearch";
            this.grdSearch.ReadOnly = true;
            this.grdSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSearch.Size = new System.Drawing.Size(1207, 310);
            this.grdSearch.TabIndex = 2;
            this.grdSearch.TabStop = false;
            this.grdSearch.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdSearch_CellClick);
            this.grdSearch.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdSearch_CellContentClick);
            this.grdSearch.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.grdSEARCH_DataBindingComplete);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtSearch.Location = new System.Drawing.Point(72, 52);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(1140, 25);
            this.txtSearch.TabIndex = 17;
            this.txtSearch.TabStop = false;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSEARCH_TextChanged);
            // 
            // lblSEARCH
            // 
            this.lblSEARCH.AutoSize = true;
            this.lblSEARCH.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSEARCH.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSEARCH.Location = new System.Drawing.Point(9, 56);
            this.lblSEARCH.Name = "lblSEARCH";
            this.lblSEARCH.Size = new System.Drawing.Size(57, 17);
            this.lblSEARCH.TabIndex = 219;
            this.lblSEARCH.Text = "SEARCH";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icons8-Save as Filled-100.png");
            this.imageList1.Images.SetKeyName(1, "icons8-Cancel Filled-100.png");
            this.imageList1.Images.SetKeyName(2, "icons8-search.png");
            // 
            // cmbVendor
            // 
            this.cmbVendor.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbVendor.FormattingEnabled = true;
            this.cmbVendor.Items.AddRange(new object[] {
            "--SELECT SUPPLIER--",
            "AUTOMART"});
            this.cmbVendor.Location = new System.Drawing.Point(576, 402);
            this.cmbVendor.Name = "cmbVendor";
            this.cmbVendor.Size = new System.Drawing.Size(280, 25);
            this.cmbVendor.TabIndex = 2;
            this.cmbVendor.SelectedIndexChanged += new System.EventHandler(this.cmbSupplier_SelectedIndexChanged);
            this.cmbVendor.Leave += new System.EventHandler(this.cmbCustomer_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(515, 407);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 15);
            this.label9.TabIndex = 227;
            this.label9.Text = "VENDOR";
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.dtpDate.Location = new System.Drawing.Point(188, 403);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(280, 23);
            this.dtpDate.TabIndex = 0;
            // 
            // lblInvoice
            // 
            this.lblInvoice.AutoSize = true;
            this.lblInvoice.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblInvoice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(215)))));
            this.lblInvoice.Location = new System.Drawing.Point(47, 407);
            this.lblInvoice.Name = "lblInvoice";
            this.lblInvoice.Size = new System.Drawing.Size(58, 15);
            this.lblInvoice.TabIndex = 298;
            this.lblInvoice.Text = "PI-1-2017";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblDate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDate.Location = new System.Drawing.Point(143, 407);
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
            this.lblV.Location = new System.Drawing.Point(9, 407);
            this.lblV.Name = "lblV";
            this.lblV.Size = new System.Drawing.Size(32, 15);
            this.lblV.TabIndex = 296;
            this.lblV.Text = "P.I #:";
            // 
            // txtDescription
            // 
            this.txtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtDescription.Location = new System.Drawing.Point(97, 435);
            this.txtDescription.MaxLength = 32000;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(1108, 183);
            this.txtDescription.TabIndex = 1;
            // 
            // lblAcc
            // 
            this.lblAcc.AutoSize = true;
            this.lblAcc.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblAcc.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblAcc.Location = new System.Drawing.Point(9, 440);
            this.lblAcc.Name = "lblAcc";
            this.lblAcc.Size = new System.Drawing.Size(82, 15);
            this.lblAcc.TabIndex = 300;
            this.lblAcc.Text = "PARTICULARS";
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
            this.btnClear.Location = new System.Drawing.Point(227, 624);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(124, 25);
            this.btnClear.TabIndex = 18;
            this.btnClear.TabStop = false;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnCLEAR_Click);
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
            this.btnSave.Location = new System.Drawing.Point(97, 624);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(124, 25);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSAVE_Click);
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
            this.pnlHEADER.Size = new System.Drawing.Size(1217, 46);
            this.pnlHEADER.TabIndex = 18;
            this.pnlHEADER.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlHEADER_Paint);
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
            this.lblHEADING.Location = new System.Drawing.Point(6, 9);
            this.lblHEADING.Name = "lblHEADING";
            this.lblHEADING.Size = new System.Drawing.Size(160, 29);
            this.lblHEADING.TabIndex = 23;
            this.lblHEADING.Text = "PURCHASES";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(24)))), ((int)(((byte)(38)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.ImageIndex = 1;
            this.btnDelete.ImageList = this.imageList1;
            this.btnDelete.Location = new System.Drawing.Point(357, 624);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(124, 25);
            this.btnDelete.TabIndex = 19;
            this.btnDelete.TabStop = false;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btn_VIEW_VOUCHER_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(882, 407);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 15);
            this.label7.TabIndex = 361;
            this.label7.Text = "TOTAL";
            // 
            // txtTotal
            // 
            this.txtTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotal.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtTotal.Location = new System.Drawing.Point(930, 402);
            this.txtTotal.MaxLength = 15;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(275, 25);
            this.txtTotal.TabIndex = 360;
            this.txtTotal.Text = "0";
            this.txtTotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTotal_KeyPress);
            // 
            // frm_Purchases
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1217, 656);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblAcc);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblInvoice);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblV);
            this.Controls.Add(this.cmbVendor);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.grdSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSEARCH);
            this.Controls.Add(this.pnlHEADER);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_Purchases";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PURCHASES";
            this.Load += new System.EventHandler(this.frm_AddGroupAccounts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdSearch)).EndInit();
            this.pnlHEADER.ResumeLayout(false);
            this.pnlHEADER.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
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
        private SergeUtils.EasyCompletionComboBox cmbVendor;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblInvoice;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblV;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblAcc;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTotal;
    }
}