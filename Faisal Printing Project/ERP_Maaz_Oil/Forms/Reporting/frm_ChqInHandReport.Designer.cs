namespace ERP_Maaz_Oil.Forms.Reporting
{
    partial class frm_ChqInHandReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ChqInHandReport));
            this.pnlHEADER = new System.Windows.Forms.Panel();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.lblHEADING = new System.Windows.Forms.Label();
            this.grpCASHBOOK = new System.Windows.Forms.GroupBox();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.rdbDate = new System.Windows.Forms.RadioButton();
            this.rdbOverAll = new System.Windows.Forms.RadioButton();
            this.rdbCustomer = new System.Windows.Forms.RadioButton();
            this.rdbSalesPerson = new System.Windows.Forms.RadioButton();
            this.cmbSalePerson = new System.Windows.Forms.ComboBox();
            this.dtp_TO = new System.Windows.Forms.DateTimePicker();
            this.dtp_FROM = new System.Windows.Forms.DateTimePicker();
            this.lblFROM = new System.Windows.Forms.Label();
            this.btnSHOW = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
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
            this.pnlHEADER.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlHEADER.Name = "pnlHEADER";
            this.pnlHEADER.Size = new System.Drawing.Size(500, 108);
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
            // pictureBox14
            // 
            this.pictureBox14.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox14.Location = new System.Drawing.Point(1713, 4);
            this.pictureBox14.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox14.Name = "pictureBox14";
            this.pictureBox14.Size = new System.Drawing.Size(65, 25);
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
            this.lblHEADING.Location = new System.Drawing.Point(7, 30);
            this.lblHEADING.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHEADING.Name = "lblHEADING";
            this.lblHEADING.Size = new System.Drawing.Size(133, 44);
            this.lblHEADING.TabIndex = 23;
            this.lblHEADING.Text = "CHQ IN HAND \r\nREPORT";
            // 
            // grpCASHBOOK
            // 
            this.grpCASHBOOK.Controls.Add(this.cmbCustomer);
            this.grpCASHBOOK.Controls.Add(this.rdbDate);
            this.grpCASHBOOK.Controls.Add(this.rdbOverAll);
            this.grpCASHBOOK.Controls.Add(this.rdbCustomer);
            this.grpCASHBOOK.Controls.Add(this.rdbSalesPerson);
            this.grpCASHBOOK.Controls.Add(this.cmbSalePerson);
            this.grpCASHBOOK.Controls.Add(this.dtp_TO);
            this.grpCASHBOOK.Controls.Add(this.dtp_FROM);
            this.grpCASHBOOK.Controls.Add(this.lblFROM);
            this.grpCASHBOOK.Controls.Add(this.btnSHOW);
            this.grpCASHBOOK.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpCASHBOOK.Location = new System.Drawing.Point(0, 111);
            this.grpCASHBOOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpCASHBOOK.Name = "grpCASHBOOK";
            this.grpCASHBOOK.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpCASHBOOK.Size = new System.Drawing.Size(501, 183);
            this.grpCASHBOOK.TabIndex = 37;
            this.grpCASHBOOK.TabStop = false;
            this.grpCASHBOOK.Text = "CHQ IN HAND REPORT";
            this.grpCASHBOOK.Enter += new System.EventHandler(this.grpSALES_Enter);
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCustomer.Enabled = false;
            this.cmbCustomer.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(179, 68);
            this.cmbCustomer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(307, 29);
            this.cmbCustomer.TabIndex = 129;
            this.cmbCustomer.DropDown += new System.EventHandler(this.cmbCustomer_DropDown);
            this.cmbCustomer.TextUpdate += new System.EventHandler(this.cmbSalePerson_TextUpdate);
            this.cmbCustomer.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmbCustomer_PreviewKeyDown);
            // 
            // rdbDate
            // 
            this.rdbDate.AutoSize = true;
            this.rdbDate.Location = new System.Drawing.Point(16, 107);
            this.rdbDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdbDate.Name = "rdbDate";
            this.rdbDate.Size = new System.Drawing.Size(71, 27);
            this.rdbDate.TabIndex = 128;
            this.rdbDate.Text = "DATE";
            this.rdbDate.UseVisualStyleBackColor = true;
            this.rdbDate.CheckedChanged += new System.EventHandler(this.rdbDate_CheckedChanged);
            // 
            // rdbOverAll
            // 
            this.rdbOverAll.AutoSize = true;
            this.rdbOverAll.Checked = true;
            this.rdbOverAll.Location = new System.Drawing.Point(16, 144);
            this.rdbOverAll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdbOverAll.Name = "rdbOverAll";
            this.rdbOverAll.Size = new System.Drawing.Size(102, 27);
            this.rdbOverAll.TabIndex = 127;
            this.rdbOverAll.TabStop = true;
            this.rdbOverAll.Text = "OVERALL";
            this.rdbOverAll.UseVisualStyleBackColor = true;
            this.rdbOverAll.CheckedChanged += new System.EventHandler(this.rdbOverAll_CheckedChanged);
            // 
            // rdbCustomer
            // 
            this.rdbCustomer.AutoSize = true;
            this.rdbCustomer.Location = new System.Drawing.Point(16, 70);
            this.rdbCustomer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdbCustomer.Name = "rdbCustomer";
            this.rdbCustomer.Size = new System.Drawing.Size(120, 27);
            this.rdbCustomer.TabIndex = 126;
            this.rdbCustomer.Text = "CUSTOMER";
            this.rdbCustomer.UseVisualStyleBackColor = true;
            this.rdbCustomer.CheckedChanged += new System.EventHandler(this.rdbCustomer_CheckedChanged);
            // 
            // rdbSalesPerson
            // 
            this.rdbSalesPerson.AutoSize = true;
            this.rdbSalesPerson.Location = new System.Drawing.Point(16, 32);
            this.rdbSalesPerson.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdbSalesPerson.Name = "rdbSalesPerson";
            this.rdbSalesPerson.Size = new System.Drawing.Size(147, 27);
            this.rdbSalesPerson.TabIndex = 125;
            this.rdbSalesPerson.Text = "SALES PERSON";
            this.rdbSalesPerson.UseVisualStyleBackColor = true;
            this.rdbSalesPerson.CheckedChanged += new System.EventHandler(this.rdbSalesPerson_CheckedChanged);
            // 
            // cmbSalePerson
            // 
            this.cmbSalePerson.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSalePerson.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSalePerson.Enabled = false;
            this.cmbSalePerson.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbSalePerson.FormattingEnabled = true;
            this.cmbSalePerson.Location = new System.Drawing.Point(179, 30);
            this.cmbSalePerson.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbSalePerson.Name = "cmbSalePerson";
            this.cmbSalePerson.Size = new System.Drawing.Size(307, 29);
            this.cmbSalePerson.TabIndex = 124;
            this.cmbSalePerson.DropDown += new System.EventHandler(this.cmbSalePerson_DropDown);
            this.cmbSalePerson.TextUpdate += new System.EventHandler(this.cmbSalePerson_TextUpdate);
            this.cmbSalePerson.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmbSalePerson_PreviewKeyDown);
            // 
            // dtp_TO
            // 
            this.dtp_TO.CustomFormat = "dd/MM/yyyy";
            this.dtp_TO.Enabled = false;
            this.dtp_TO.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.dtp_TO.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_TO.Location = new System.Drawing.Point(343, 106);
            this.dtp_TO.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtp_TO.Name = "dtp_TO";
            this.dtp_TO.Size = new System.Drawing.Size(143, 27);
            this.dtp_TO.TabIndex = 120;
            // 
            // dtp_FROM
            // 
            this.dtp_FROM.CustomFormat = "dd/MM/yyyy";
            this.dtp_FROM.Enabled = false;
            this.dtp_FROM.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.dtp_FROM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_FROM.Location = new System.Drawing.Point(179, 106);
            this.dtp_FROM.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtp_FROM.Name = "dtp_FROM";
            this.dtp_FROM.Size = new System.Drawing.Size(143, 27);
            this.dtp_FROM.TabIndex = 119;
            // 
            // lblFROM
            // 
            this.lblFROM.AutoSize = true;
            this.lblFROM.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblFROM.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblFROM.Location = new System.Drawing.Point(325, 111);
            this.lblFROM.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFROM.Name = "lblFROM";
            this.lblFROM.Size = new System.Drawing.Size(15, 20);
            this.lblFROM.TabIndex = 118;
            this.lblFROM.Text = "-";
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
            this.btnSHOW.Location = new System.Drawing.Point(179, 142);
            this.btnSHOW.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSHOW.Name = "btnSHOW";
            this.btnSHOW.Size = new System.Drawing.Size(308, 31);
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
            // frm_ChqInHandReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(500, 286);
            this.Controls.Add(this.grpCASHBOOK);
            this.Controls.Add(this.pnlHEADER);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximumSize = new System.Drawing.Size(518, 333);
            this.Name = "frm_ChqInHandReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CHQ IN HAND REPORT";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_Account_Ledger_FormClosed);
            this.Load += new System.EventHandler(this.frm_Account_Ledger_Load);
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
        private System.Windows.Forms.DateTimePicker dtp_TO;
        private System.Windows.Forms.DateTimePicker dtp_FROM;
        private System.Windows.Forms.ComboBox cmbSalePerson;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.RadioButton rdbDate;
        private System.Windows.Forms.RadioButton rdbOverAll;
        private System.Windows.Forms.RadioButton rdbCustomer;
        private System.Windows.Forms.RadioButton rdbSalesPerson;
    }
}