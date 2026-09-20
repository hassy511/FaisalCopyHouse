namespace ERP_Maaz_Oil.Forms.Reporting
{
    partial class frm_MaterialPositionClosingReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_MaterialPositionClosingReport));
            this.pnlHEADER = new System.Windows.Forms.Panel();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.dtp_FROM = new System.Windows.Forms.DateTimePicker();
            this.lblHEADING = new System.Windows.Forms.Label();
            this.lblFROM = new System.Windows.Forms.Label();
            this.grpCASHBOOK = new System.Windows.Forms.GroupBox();
            this.grdData = new System.Windows.Forms.DataGridView();
            this.purchasesDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.canolaKg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.canolaRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.canolaAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.olienKg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.olienRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.olienAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.muandRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.materialId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soyaKg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soyaRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soyaAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hardKg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hardRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hardAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtp_TO = new System.Windows.Forms.DateTimePicker();
            this.btnSHOW = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lblITO = new System.Windows.Forms.Label();
            this.pnlHEADER.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
            this.grpCASHBOOK.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHEADER
            // 
            this.pnlHEADER.BackColor = System.Drawing.Color.Transparent;
            this.pnlHEADER.BackgroundImage = global::ERP_Maaz_Oil.Properties.Resources.header;
            this.pnlHEADER.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlHEADER.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHEADER.Controls.Add(this.pictureBox15);
            this.pnlHEADER.Controls.Add(this.pictureBox14);
            this.pnlHEADER.Controls.Add(this.dtp_FROM);
            this.pnlHEADER.Controls.Add(this.lblHEADING);
            this.pnlHEADER.Controls.Add(this.lblFROM);
            this.pnlHEADER.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHEADER.Location = new System.Drawing.Point(0, 0);
            this.pnlHEADER.Name = "pnlHEADER";
            this.pnlHEADER.Size = new System.Drawing.Size(301, 88);
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
            // dtp_FROM
            // 
            this.dtp_FROM.CustomFormat = "dd/MM/yyyy";
            this.dtp_FROM.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.dtp_FROM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_FROM.Location = new System.Drawing.Point(267, 4);
            this.dtp_FROM.Name = "dtp_FROM";
            this.dtp_FROM.Size = new System.Drawing.Size(10, 23);
            this.dtp_FROM.TabIndex = 119;
            this.dtp_FROM.Visible = false;
            // 
            // lblHEADING
            // 
            this.lblHEADING.AutoSize = true;
            this.lblHEADING.BackColor = System.Drawing.Color.Transparent;
            this.lblHEADING.Font = new System.Drawing.Font("Berlin Sans FB", 11.75F);
            this.lblHEADING.ForeColor = System.Drawing.Color.White;
            this.lblHEADING.Location = new System.Drawing.Point(2, 29);
            this.lblHEADING.Name = "lblHEADING";
            this.lblHEADING.Size = new System.Drawing.Size(153, 36);
            this.lblHEADING.TabIndex = 23;
            this.lblHEADING.Text = "MATERIAL POSITION \r\nCLOSING REPORT";
            // 
            // lblFROM
            // 
            this.lblFROM.AutoSize = true;
            this.lblFROM.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblFROM.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblFROM.Location = new System.Drawing.Point(218, 8);
            this.lblFROM.Name = "lblFROM";
            this.lblFROM.Size = new System.Drawing.Size(43, 15);
            this.lblFROM.TabIndex = 118;
            this.lblFROM.Text = "FROM:";
            this.lblFROM.Visible = false;
            // 
            // grpCASHBOOK
            // 
            this.grpCASHBOOK.Controls.Add(this.grdData);
            this.grpCASHBOOK.Controls.Add(this.dtp_TO);
            this.grpCASHBOOK.Controls.Add(this.btnSHOW);
            this.grpCASHBOOK.Controls.Add(this.lblITO);
            this.grpCASHBOOK.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpCASHBOOK.Location = new System.Drawing.Point(0, 90);
            this.grpCASHBOOK.Name = "grpCASHBOOK";
            this.grpCASHBOOK.Size = new System.Drawing.Size(299, 96);
            this.grpCASHBOOK.TabIndex = 37;
            this.grpCASHBOOK.TabStop = false;
            this.grpCASHBOOK.Text = "MATERIAL POSITION CLOSING REPORT";
            // 
            // grdData
            // 
            this.grdData.AllowUserToAddRows = false;
            this.grdData.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue;
            this.grdData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grdData.BackgroundColor = System.Drawing.Color.White;
            this.grdData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.purchasesDate,
            this.invoice,
            this.canolaKg,
            this.canolaRate,
            this.canolaAmount,
            this.olienKg,
            this.olienRate,
            this.olienAmount,
            this.muandRate,
            this.materialId,
            this.soyaKg,
            this.soyaRate,
            this.soyaAmount,
            this.hardKg,
            this.hardRate,
            this.hardAmount});
            this.grdData.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdData.DefaultCellStyle = dataGridViewCellStyle3;
            this.grdData.Location = new System.Drawing.Point(6, 63);
            this.grdData.Name = "grdData";
            this.grdData.ReadOnly = true;
            this.grdData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdData.Size = new System.Drawing.Size(41, 18);
            this.grdData.TabIndex = 338;
            this.grdData.TabStop = false;
            this.grdData.Visible = false;
            // 
            // purchasesDate
            // 
            this.purchasesDate.HeaderText = "PURCHASED DATE";
            this.purchasesDate.Name = "purchasesDate";
            this.purchasesDate.ReadOnly = true;
            this.purchasesDate.Width = 143;
            // 
            // invoice
            // 
            this.invoice.HeaderText = "INVOICE";
            this.invoice.Name = "invoice";
            this.invoice.ReadOnly = true;
            this.invoice.Width = 84;
            // 
            // canolaKg
            // 
            this.canolaKg.HeaderText = "CANOLA KG";
            this.canolaKg.Name = "canolaKg";
            this.canolaKg.ReadOnly = true;
            this.canolaKg.Width = 106;
            // 
            // canolaRate
            // 
            this.canolaRate.HeaderText = "CANOLA RATE";
            this.canolaRate.Name = "canolaRate";
            this.canolaRate.ReadOnly = true;
            this.canolaRate.Width = 119;
            // 
            // canolaAmount
            // 
            this.canolaAmount.HeaderText = "CANOLA AMOUNT";
            this.canolaAmount.Name = "canolaAmount";
            this.canolaAmount.ReadOnly = true;
            this.canolaAmount.Width = 146;
            // 
            // olienKg
            // 
            this.olienKg.HeaderText = "OLIEN KG";
            this.olienKg.Name = "olienKg";
            this.olienKg.ReadOnly = true;
            this.olienKg.Width = 91;
            // 
            // olienRate
            // 
            this.olienRate.HeaderText = "OLIEN RATE";
            this.olienRate.Name = "olienRate";
            this.olienRate.ReadOnly = true;
            this.olienRate.Width = 104;
            // 
            // olienAmount
            // 
            this.olienAmount.HeaderText = "OLIEN AMOUNT";
            this.olienAmount.Name = "olienAmount";
            this.olienAmount.ReadOnly = true;
            this.olienAmount.Width = 131;
            // 
            // muandRate
            // 
            this.muandRate.HeaderText = "MUAND RATE";
            this.muandRate.Name = "muandRate";
            this.muandRate.ReadOnly = true;
            this.muandRate.Width = 116;
            // 
            // materialId
            // 
            this.materialId.HeaderText = "MATERIAL ID";
            this.materialId.Name = "materialId";
            this.materialId.ReadOnly = true;
            this.materialId.Width = 111;
            // 
            // soyaKg
            // 
            this.soyaKg.HeaderText = "SOYA KG";
            this.soyaKg.Name = "soyaKg";
            this.soyaKg.ReadOnly = true;
            this.soyaKg.Width = 87;
            // 
            // soyaRate
            // 
            this.soyaRate.HeaderText = "SOYA RATE";
            this.soyaRate.Name = "soyaRate";
            this.soyaRate.ReadOnly = true;
            // 
            // soyaAmount
            // 
            this.soyaAmount.HeaderText = "SOYA AMOUNT";
            this.soyaAmount.Name = "soyaAmount";
            this.soyaAmount.ReadOnly = true;
            this.soyaAmount.Width = 127;
            // 
            // hardKg
            // 
            this.hardKg.HeaderText = "HARD KG";
            this.hardKg.Name = "hardKg";
            this.hardKg.ReadOnly = true;
            this.hardKg.Width = 90;
            // 
            // hardRate
            // 
            this.hardRate.HeaderText = "HARD RATE";
            this.hardRate.Name = "hardRate";
            this.hardRate.ReadOnly = true;
            this.hardRate.Width = 103;
            // 
            // hardAmount
            // 
            this.hardAmount.HeaderText = "HARD AMOUNT";
            this.hardAmount.Name = "hardAmount";
            this.hardAmount.ReadOnly = true;
            this.hardAmount.Width = 130;
            // 
            // dtp_TO
            // 
            this.dtp_TO.CustomFormat = "dd/MM/yyyy";
            this.dtp_TO.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.dtp_TO.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_TO.Location = new System.Drawing.Point(61, 34);
            this.dtp_TO.Name = "dtp_TO";
            this.dtp_TO.Size = new System.Drawing.Size(231, 23);
            this.dtp_TO.TabIndex = 0;
            // 
            // btnSHOW
            // 
            this.btnSHOW.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(68)))), ((int)(((byte)(2)))));
            this.btnSHOW.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSHOW.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSHOW.ForeColor = System.Drawing.Color.White;
            this.btnSHOW.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSHOW.ImageIndex = 5;
            this.btnSHOW.ImageList = this.imageList1;
            this.btnSHOW.Location = new System.Drawing.Point(61, 63);
            this.btnSHOW.Name = "btnSHOW";
            this.btnSHOW.Size = new System.Drawing.Size(231, 25);
            this.btnSHOW.TabIndex = 1;
            this.btnSHOW.Text = "SHOW";
            this.btnSHOW.UseVisualStyleBackColor = false;
            this.btnSHOW.Click += new System.EventHandler(this.btnINTER_SAVE_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icons8-Save as Filled-100.png");
            this.imageList1.Images.SetKeyName(1, "icons8-Cancel Filled-100.png");
            this.imageList1.Images.SetKeyName(2, "icons8-Future Filled-50 (1).png");
            this.imageList1.Images.SetKeyName(3, "icons8-Marker-48.png");
            this.imageList1.Images.SetKeyName(4, "icons8-Traffic Jam Filled-100.png");
            this.imageList1.Images.SetKeyName(5, "icons8-show-property-filled-50.png");
            // 
            // lblITO
            // 
            this.lblITO.AutoSize = true;
            this.lblITO.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblITO.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblITO.Location = new System.Drawing.Point(19, 38);
            this.lblITO.Name = "lblITO";
            this.lblITO.Size = new System.Drawing.Size(41, 15);
            this.lblITO.TabIndex = 46;
            this.lblITO.Text = "UPTO:";
            // 
            // frm_MaterialPositionClosingReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(301, 190);
            this.Controls.Add(this.grpCASHBOOK);
            this.Controls.Add(this.pnlHEADER);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(317, 229);
            this.Name = "frm_MaterialPositionClosingReport";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MATERIAL POSITION CLOSING REPORT";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_Account_Ledger_FormClosed);
            this.pnlHEADER.ResumeLayout(false);
            this.pnlHEADER.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
            this.grpCASHBOOK.ResumeLayout(false);
            this.grpCASHBOOK.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHEADER;
        private System.Windows.Forms.PictureBox pictureBox15;
        private System.Windows.Forms.PictureBox pictureBox14;
        private System.Windows.Forms.Label lblHEADING;
        private System.Windows.Forms.GroupBox grpCASHBOOK;
        private System.Windows.Forms.Button btnSHOW;
        private System.Windows.Forms.Label lblITO;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lblFROM;
        private System.Windows.Forms.DateTimePicker dtp_TO;
        private System.Windows.Forms.DateTimePicker dtp_FROM;
        private System.Windows.Forms.DataGridView grdData;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchasesDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoice;
        private System.Windows.Forms.DataGridViewTextBoxColumn canolaKg;
        private System.Windows.Forms.DataGridViewTextBoxColumn canolaRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn canolaAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn olienKg;
        private System.Windows.Forms.DataGridViewTextBoxColumn olienRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn olienAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn muandRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn materialId;
        private System.Windows.Forms.DataGridViewTextBoxColumn soyaKg;
        private System.Windows.Forms.DataGridViewTextBoxColumn soyaRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn soyaAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn hardKg;
        private System.Windows.Forms.DataGridViewTextBoxColumn hardRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn hardAmount;
    }
}