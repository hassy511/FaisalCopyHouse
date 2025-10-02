namespace ERP_Maaz_Oil.Forms.Reporting
{
    partial class frm_RawReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_RawReport));
            this.pnlHEADER = new System.Windows.Forms.Panel();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.lblHEADING = new System.Windows.Forms.Label();
            this.grpCASHBOOK = new System.Windows.Forms.GroupBox();
            this.cmbItem = new SergeUtils.EasyCompletionComboBox();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblFROM = new System.Windows.Forms.Label();
            this.btnSHOW = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.pnlHEADER.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
            this.grpCASHBOOK.SuspendLayout();
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
            this.pnlHEADER.Size = new System.Drawing.Size(305, 88);
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
            // lblHEADING
            // 
            this.lblHEADING.AutoSize = true;
            this.lblHEADING.BackColor = System.Drawing.Color.Transparent;
            this.lblHEADING.Font = new System.Drawing.Font("Berlin Sans FB", 11.75F);
            this.lblHEADING.ForeColor = System.Drawing.Color.White;
            this.lblHEADING.Location = new System.Drawing.Point(4, 24);
            this.lblHEADING.Name = "lblHEADING";
            this.lblHEADING.Size = new System.Drawing.Size(123, 36);
            this.lblHEADING.TabIndex = 23;
            this.lblHEADING.Text = "RAW MATERIAL \r\nREPORT";
            // 
            // grpCASHBOOK
            // 
            this.grpCASHBOOK.Controls.Add(this.label1);
            this.grpCASHBOOK.Controls.Add(this.cmbItem);
            this.grpCASHBOOK.Controls.Add(this.dtpFrom);
            this.grpCASHBOOK.Controls.Add(this.lblFROM);
            this.grpCASHBOOK.Controls.Add(this.btnSHOW);
            this.grpCASHBOOK.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpCASHBOOK.Location = new System.Drawing.Point(0, 90);
            this.grpCASHBOOK.Name = "grpCASHBOOK";
            this.grpCASHBOOK.Size = new System.Drawing.Size(305, 119);
            this.grpCASHBOOK.TabIndex = 37;
            this.grpCASHBOOK.TabStop = false;
            this.grpCASHBOOK.Text = "RAW MATERIAL REPORT";
            // 
            // cmbItem
            // 
            this.cmbItem.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbItem.Items.AddRange(new object[] {
            "--SELECT SUPPLIER--",
            "AUTOMART"});
            this.cmbItem.Location = new System.Drawing.Point(78, 24);
            this.cmbItem.Name = "cmbItem";
            this.cmbItem.Size = new System.Drawing.Size(215, 25);
            this.cmbItem.TabIndex = 121;
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpFrom.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(78, 55);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(215, 23);
            this.dtpFrom.TabIndex = 1;
            // 
            // lblFROM
            // 
            this.lblFROM.AutoSize = true;
            this.lblFROM.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblFROM.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblFROM.Location = new System.Drawing.Point(31, 59);
            this.lblFROM.Name = "lblFROM";
            this.lblFROM.Size = new System.Drawing.Size(41, 15);
            this.lblFROM.TabIndex = 118;
            this.lblFROM.Text = "UPTO:";
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
            this.btnSHOW.Location = new System.Drawing.Point(78, 84);
            this.btnSHOW.Name = "btnSHOW";
            this.btnSHOW.Size = new System.Drawing.Size(215, 25);
            this.btnSHOW.TabIndex = 3;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 122;
            this.label1.Text = "MATERIAL:";
            // 
            // frm_RawReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(305, 212);
            this.Controls.Add(this.grpCASHBOOK);
            this.Controls.Add(this.pnlHEADER);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_RawReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RAW MATERIAL REPORT";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_Account_Ledger_FormClosed);
            this.Load += new System.EventHandler(this.frm_ControlAccountLedger_Load);
            this.pnlHEADER.ResumeLayout(false);
            this.pnlHEADER.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
            this.grpCASHBOOK.ResumeLayout(false);
            this.grpCASHBOOK.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHEADER;
        private System.Windows.Forms.PictureBox pictureBox15;
        private System.Windows.Forms.PictureBox pictureBox14;
        private System.Windows.Forms.Label lblHEADING;
        private System.Windows.Forms.GroupBox grpCASHBOOK;
        private System.Windows.Forms.Button btnSHOW;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lblFROM;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private SergeUtils.EasyCompletionComboBox cmbItem;
        private System.Windows.Forms.Label label1;
    }
}