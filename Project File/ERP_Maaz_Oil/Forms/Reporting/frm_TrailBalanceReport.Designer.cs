namespace ERP_Maaz_Oil.Forms.Reporting
{
    partial class frm_TrailBalanceReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_TrailBalanceReport));
            this.pnlHEADER = new System.Windows.Forms.Panel();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.lblHEADING = new System.Windows.Forms.Label();
            this.grpCASHBOOK = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdbConsolidated = new System.Windows.Forms.RadioButton();
            this.rdbDetailed = new System.Windows.Forms.RadioButton();
            this.dtpUpto = new System.Windows.Forms.DateTimePicker();
            this.rdbRange = new System.Windows.Forms.RadioButton();
            this.rdbUpto = new System.Windows.Forms.RadioButton();
            this.dtp_TO = new System.Windows.Forms.DateTimePicker();
            this.dtp_FROM = new System.Windows.Forms.DateTimePicker();
            this.btnSHOW = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lblITO = new System.Windows.Forms.Label();
            this.chkZeroBalance = new System.Windows.Forms.CheckBox();
            this.pnlHEADER.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
            this.grpCASHBOOK.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.pnlHEADER.Size = new System.Drawing.Size(302, 60);
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
            this.lblHEADING.Font = new System.Drawing.Font("Berlin Sans FB", 10.75F);
            this.lblHEADING.ForeColor = System.Drawing.Color.White;
            this.lblHEADING.Location = new System.Drawing.Point(2, 12);
            this.lblHEADING.Name = "lblHEADING";
            this.lblHEADING.Size = new System.Drawing.Size(119, 34);
            this.lblHEADING.TabIndex = 23;
            this.lblHEADING.Text = "TRIAL BALANCE \r\nREPORT";
            // 
            // grpCASHBOOK
            // 
            this.grpCASHBOOK.Controls.Add(this.chkZeroBalance);
            this.grpCASHBOOK.Controls.Add(this.panel1);
            this.grpCASHBOOK.Controls.Add(this.dtpUpto);
            this.grpCASHBOOK.Controls.Add(this.rdbRange);
            this.grpCASHBOOK.Controls.Add(this.rdbUpto);
            this.grpCASHBOOK.Controls.Add(this.dtp_TO);
            this.grpCASHBOOK.Controls.Add(this.dtp_FROM);
            this.grpCASHBOOK.Controls.Add(this.btnSHOW);
            this.grpCASHBOOK.Controls.Add(this.lblITO);
            this.grpCASHBOOK.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpCASHBOOK.Location = new System.Drawing.Point(2, 66);
            this.grpCASHBOOK.Name = "grpCASHBOOK";
            this.grpCASHBOOK.Size = new System.Drawing.Size(297, 171);
            this.grpCASHBOOK.TabIndex = 37;
            this.grpCASHBOOK.TabStop = false;
            this.grpCASHBOOK.Text = "TRIAL BALANCE REPORT";
            this.grpCASHBOOK.Enter += new System.EventHandler(this.grpSALES_Enter);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdbConsolidated);
            this.panel1.Controls.Add(this.rdbDetailed);
            this.panel1.Location = new System.Drawing.Point(80, 78);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(211, 25);
            this.panel1.TabIndex = 128;
            // 
            // rdbConsolidated
            // 
            this.rdbConsolidated.AutoSize = true;
            this.rdbConsolidated.Location = new System.Drawing.Point(102, 3);
            this.rdbConsolidated.Name = "rdbConsolidated";
            this.rdbConsolidated.Size = new System.Drawing.Size(105, 21);
            this.rdbConsolidated.TabIndex = 127;
            this.rdbConsolidated.Text = "Consolidated";
            this.rdbConsolidated.UseVisualStyleBackColor = true;
            // 
            // rdbDetailed
            // 
            this.rdbDetailed.AutoSize = true;
            this.rdbDetailed.Checked = true;
            this.rdbDetailed.Location = new System.Drawing.Point(3, 1);
            this.rdbDetailed.Name = "rdbDetailed";
            this.rdbDetailed.Size = new System.Drawing.Size(75, 21);
            this.rdbDetailed.TabIndex = 126;
            this.rdbDetailed.TabStop = true;
            this.rdbDetailed.Text = "Detailed";
            this.rdbDetailed.UseVisualStyleBackColor = true;
            // 
            // dtpUpto
            // 
            this.dtpUpto.CustomFormat = "dd/MM/yyyy";
            this.dtpUpto.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.dtpUpto.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpUpto.Location = new System.Drawing.Point(80, 24);
            this.dtpUpto.Name = "dtpUpto";
            this.dtpUpto.Size = new System.Drawing.Size(211, 23);
            this.dtpUpto.TabIndex = 125;
            // 
            // rdbRange
            // 
            this.rdbRange.AutoSize = true;
            this.rdbRange.Location = new System.Drawing.Point(10, 54);
            this.rdbRange.Name = "rdbRange";
            this.rdbRange.Size = new System.Drawing.Size(64, 21);
            this.rdbRange.TabIndex = 124;
            this.rdbRange.TabStop = true;
            this.rdbRange.Text = "Range";
            this.rdbRange.UseVisualStyleBackColor = true;
            // 
            // rdbUpto
            // 
            this.rdbUpto.AutoSize = true;
            this.rdbUpto.Checked = true;
            this.rdbUpto.Location = new System.Drawing.Point(10, 25);
            this.rdbUpto.Name = "rdbUpto";
            this.rdbUpto.Size = new System.Drawing.Size(56, 21);
            this.rdbUpto.TabIndex = 123;
            this.rdbUpto.TabStop = true;
            this.rdbUpto.Text = "Upto";
            this.rdbUpto.UseVisualStyleBackColor = true;
            // 
            // dtp_TO
            // 
            this.dtp_TO.CustomFormat = "dd/MM/yyyy";
            this.dtp_TO.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.dtp_TO.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_TO.Location = new System.Drawing.Point(194, 53);
            this.dtp_TO.Name = "dtp_TO";
            this.dtp_TO.Size = new System.Drawing.Size(97, 23);
            this.dtp_TO.TabIndex = 120;
            // 
            // dtp_FROM
            // 
            this.dtp_FROM.CustomFormat = "dd/MM/yyyy";
            this.dtp_FROM.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.dtp_FROM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_FROM.Location = new System.Drawing.Point(80, 53);
            this.dtp_FROM.Name = "dtp_FROM";
            this.dtp_FROM.Size = new System.Drawing.Size(97, 23);
            this.dtp_FROM.TabIndex = 119;
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
            this.btnSHOW.Location = new System.Drawing.Point(80, 136);
            this.btnSHOW.Name = "btnSHOW";
            this.btnSHOW.Size = new System.Drawing.Size(211, 25);
            this.btnSHOW.TabIndex = 9;
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
            this.lblITO.Location = new System.Drawing.Point(176, 57);
            this.lblITO.Name = "lblITO";
            this.lblITO.Size = new System.Drawing.Size(18, 15);
            this.lblITO.TabIndex = 46;
            this.lblITO.Text = " - ";
            // 
            // chkZeroBalance
            // 
            this.chkZeroBalance.AutoSize = true;
            this.chkZeroBalance.Location = new System.Drawing.Point(80, 109);
            this.chkZeroBalance.Name = "chkZeroBalance";
            this.chkZeroBalance.Size = new System.Drawing.Size(144, 21);
            this.chkZeroBalance.TabIndex = 129;
            this.chkZeroBalance.Text = "Without 0 Balances";
            this.chkZeroBalance.UseVisualStyleBackColor = true;
            // 
            // frm_TrailBalanceReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(302, 234);
            this.Controls.Add(this.grpCASHBOOK);
            this.Controls.Add(this.pnlHEADER);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(318, 273);
            this.Name = "frm_TrailBalanceReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TRIAL BALANCE REPORT";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_Account_Ledger_FormClosed);
            this.Load += new System.EventHandler(this.frm_Account_Ledger_Load);
            this.pnlHEADER.ResumeLayout(false);
            this.pnlHEADER.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
            this.grpCASHBOOK.ResumeLayout(false);
            this.grpCASHBOOK.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.DateTimePicker dtp_TO;
        private System.Windows.Forms.DateTimePicker dtp_FROM;
        private System.Windows.Forms.RadioButton rdbRange;
        private System.Windows.Forms.RadioButton rdbUpto;
        private System.Windows.Forms.DateTimePicker dtpUpto;
        private System.Windows.Forms.RadioButton rdbConsolidated;
        private System.Windows.Forms.RadioButton rdbDetailed;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkZeroBalance;
    }
}