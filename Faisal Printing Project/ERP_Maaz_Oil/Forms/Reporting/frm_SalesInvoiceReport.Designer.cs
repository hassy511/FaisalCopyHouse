namespace ERP_Maaz_Oil.Forms.Reporting
{
    partial class frm_SalesInvoiceReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_SalesInvoiceReport));
            this.pnlHEADER = new System.Windows.Forms.Panel();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.lblHEADING = new System.Windows.Forms.Label();
            this.grpSalesReport = new System.Windows.Forms.GroupBox();
            this.chkRaw = new System.Windows.Forms.CheckBox();
            this.chkProduct = new System.Windows.Forms.CheckBox();
            this.cmbRawMaterial = new SergeUtils.EasyCompletionComboBox();
            this.cmbProduct = new SergeUtils.EasyCompletionComboBox();
            this.dtp_TO = new System.Windows.Forms.DateTimePicker();
            this.dtp_FROM = new System.Windows.Forms.DateTimePicker();
            this.lblFROM = new System.Windows.Forms.Label();
            this.btnSHOW = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lblITO = new System.Windows.Forms.Label();
            this.pnlHEADER.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
            this.grpSalesReport.SuspendLayout();
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
            this.pnlHEADER.Controls.Add(this.lblHEADING);
            this.pnlHEADER.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHEADER.Location = new System.Drawing.Point(0, 0);
            this.pnlHEADER.Name = "pnlHEADER";
            this.pnlHEADER.Size = new System.Drawing.Size(512, 107);
            this.pnlHEADER.TabIndex = 36;
            // 
            // pictureBox15
            // 
            this.pictureBox15.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox15.Location = new System.Drawing.Point(1563, 3);
            this.pictureBox15.Name = "pictureBox15";
            this.pictureBox15.Size = new System.Drawing.Size(57, 24);
            this.pictureBox15.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox15.TabIndex = 25;
            this.pictureBox15.TabStop = false;
            // 
            // pictureBox14
            // 
            this.pictureBox14.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox14.Location = new System.Drawing.Point(1499, 3);
            this.pictureBox14.Name = "pictureBox14";
            this.pictureBox14.Size = new System.Drawing.Size(57, 24);
            this.pictureBox14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox14.TabIndex = 24;
            this.pictureBox14.TabStop = false;
            // 
            // lblHEADING
            // 
            this.lblHEADING.AutoSize = true;
            this.lblHEADING.BackColor = System.Drawing.Color.Transparent;
            this.lblHEADING.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.75F);
            this.lblHEADING.ForeColor = System.Drawing.Color.White;
            this.lblHEADING.Location = new System.Drawing.Point(2, 31);
            this.lblHEADING.Name = "lblHEADING";
            this.lblHEADING.Size = new System.Drawing.Size(150, 44);
            this.lblHEADING.TabIndex = 23;
            this.lblHEADING.Text = "SALES INVOICE \r\nREPORT";
            // 
            // grpSalesReport
            // 
            this.grpSalesReport.Controls.Add(this.chkRaw);
            this.grpSalesReport.Controls.Add(this.chkProduct);
            this.grpSalesReport.Controls.Add(this.cmbRawMaterial);
            this.grpSalesReport.Controls.Add(this.cmbProduct);
            this.grpSalesReport.Controls.Add(this.dtp_TO);
            this.grpSalesReport.Controls.Add(this.dtp_FROM);
            this.grpSalesReport.Controls.Add(this.lblFROM);
            this.grpSalesReport.Controls.Add(this.btnSHOW);
            this.grpSalesReport.Controls.Add(this.lblITO);
            this.grpSalesReport.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpSalesReport.Location = new System.Drawing.Point(0, 110);
            this.grpSalesReport.Name = "grpSalesReport";
            this.grpSalesReport.Size = new System.Drawing.Size(512, 215);
            this.grpSalesReport.TabIndex = 37;
            this.grpSalesReport.TabStop = false;
            this.grpSalesReport.Text = "SALES INVOICE REPORT";
            this.grpSalesReport.Enter += new System.EventHandler(this.grpSALES_Enter);
            // 
            // chkRaw
            // 
            this.chkRaw.AutoSize = true;
            this.chkRaw.Location = new System.Drawing.Point(8, 66);
            this.chkRaw.Name = "chkRaw";
            this.chkRaw.Size = new System.Drawing.Size(69, 27);
            this.chkRaw.TabIndex = 124;
            this.chkRaw.Text = "RAW";
            this.chkRaw.UseVisualStyleBackColor = true;
            // 
            // chkProduct
            // 
            this.chkProduct.AutoSize = true;
            this.chkProduct.Location = new System.Drawing.Point(8, 28);
            this.chkProduct.Name = "chkProduct";
            this.chkProduct.Size = new System.Drawing.Size(110, 27);
            this.chkProduct.TabIndex = 123;
            this.chkProduct.Text = "PRODUCT";
            this.chkProduct.UseVisualStyleBackColor = true;
            // 
            // cmbRawMaterial
            // 
            this.cmbRawMaterial.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbRawMaterial.Items.AddRange(new object[] {
            "--SELECT SUPPLIER--",
            "AUTOMART"});
            this.cmbRawMaterial.Location = new System.Drawing.Point(109, 63);
            this.cmbRawMaterial.Name = "cmbRawMaterial";
            this.cmbRawMaterial.Size = new System.Drawing.Size(394, 29);
            this.cmbRawMaterial.TabIndex = 122;
            // 
            // cmbProduct
            // 
            this.cmbProduct.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbProduct.Items.AddRange(new object[] {
            "--SELECT SUPPLIER--",
            "AUTOMART"});
            this.cmbProduct.Location = new System.Drawing.Point(109, 25);
            this.cmbProduct.Name = "cmbProduct";
            this.cmbProduct.Size = new System.Drawing.Size(394, 29);
            this.cmbProduct.TabIndex = 121;
            // 
            // dtp_TO
            // 
            this.dtp_TO.CustomFormat = "dd/MM/yyyy";
            this.dtp_TO.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.dtp_TO.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_TO.Location = new System.Drawing.Point(109, 137);
            this.dtp_TO.Name = "dtp_TO";
            this.dtp_TO.Size = new System.Drawing.Size(394, 27);
            this.dtp_TO.TabIndex = 1;
            // 
            // dtp_FROM
            // 
            this.dtp_FROM.CustomFormat = "dd/MM/yyyy";
            this.dtp_FROM.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.dtp_FROM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_FROM.Location = new System.Drawing.Point(109, 102);
            this.dtp_FROM.Name = "dtp_FROM";
            this.dtp_FROM.Size = new System.Drawing.Size(394, 27);
            this.dtp_FROM.TabIndex = 0;
            // 
            // lblFROM
            // 
            this.lblFROM.AutoSize = true;
            this.lblFROM.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblFROM.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblFROM.Location = new System.Drawing.Point(8, 107);
            this.lblFROM.Name = "lblFROM";
            this.lblFROM.Size = new System.Drawing.Size(55, 20);
            this.lblFROM.TabIndex = 118;
            this.lblFROM.Text = "FROM:";
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
            this.btnSHOW.Location = new System.Drawing.Point(109, 173);
            this.btnSHOW.Name = "btnSHOW";
            this.btnSHOW.Size = new System.Drawing.Size(395, 30);
            this.btnSHOW.TabIndex = 2;
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
            this.lblITO.Location = new System.Drawing.Point(8, 142);
            this.lblITO.Name = "lblITO";
            this.lblITO.Size = new System.Drawing.Size(31, 20);
            this.lblITO.TabIndex = 46;
            this.lblITO.Text = "TO:";
            // 
            // frm_SalesInvoiceReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(512, 316);
            this.Controls.Add(this.grpSalesReport);
            this.Controls.Add(this.pnlHEADER);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(530, 363);
            this.Name = "frm_SalesInvoiceReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SALES INVOICE REPORT";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_Account_Ledger_FormClosed);
            this.Load += new System.EventHandler(this.frm_Account_Ledger_Load);
            this.pnlHEADER.ResumeLayout(false);
            this.pnlHEADER.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
            this.grpSalesReport.ResumeLayout(false);
            this.grpSalesReport.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHEADER;
        private System.Windows.Forms.PictureBox pictureBox15;
        private System.Windows.Forms.PictureBox pictureBox14;
        private System.Windows.Forms.Label lblHEADING;
        private System.Windows.Forms.GroupBox grpSalesReport;
        private System.Windows.Forms.Button btnSHOW;
        private System.Windows.Forms.Label lblITO;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lblFROM;
        private System.Windows.Forms.DateTimePicker dtp_TO;
        private System.Windows.Forms.DateTimePicker dtp_FROM;
        private SergeUtils.EasyCompletionComboBox cmbRawMaterial;
        private SergeUtils.EasyCompletionComboBox cmbProduct;
        private System.Windows.Forms.CheckBox chkRaw;
        private System.Windows.Forms.CheckBox chkProduct;
    }
}