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
            this.cmbSalePerson = new SergeUtils.EasyCompletionComboBox();
            this.dtp_TO = new System.Windows.Forms.DateTimePicker();
            this.dtp_FROM = new System.Windows.Forms.DateTimePicker();
            this.lblFROM = new System.Windows.Forms.Label();
            this.btnSHOW = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.rdbSalesPerson = new System.Windows.Forms.RadioButton();
            this.rdbCustomer = new System.Windows.Forms.RadioButton();
            this.rdbOverAll = new System.Windows.Forms.RadioButton();
            this.rdbDate = new System.Windows.Forms.RadioButton();
            this.cmbCustomer = new SergeUtils.EasyCompletionComboBox();
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
            this.pnlHEADER.Size = new System.Drawing.Size(377, 88);
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
            this.lblHEADING.Location = new System.Drawing.Point(5, 24);
            this.lblHEADING.Name = "lblHEADING";
            this.lblHEADING.Size = new System.Drawing.Size(107, 34);
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
            this.grpCASHBOOK.Location = new System.Drawing.Point(0, 90);
            this.grpCASHBOOK.Name = "grpCASHBOOK";
            this.grpCASHBOOK.Size = new System.Drawing.Size(376, 149);
            this.grpCASHBOOK.TabIndex = 37;
            this.grpCASHBOOK.TabStop = false;
            this.grpCASHBOOK.Text = "CHQ IN HAND REPORT";
            this.grpCASHBOOK.Enter += new System.EventHandler(this.grpSALES_Enter);
            // 
            // cmbSalePerson
            // 
            this.cmbSalePerson.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSalePerson.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSalePerson.Enabled = false;
            this.cmbSalePerson.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbSalePerson.FormattingEnabled = true;
            this.cmbSalePerson.Location = new System.Drawing.Point(134, 24);
            this.cmbSalePerson.Name = "cmbSalePerson";
            this.cmbSalePerson.Size = new System.Drawing.Size(231, 25);
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
            this.dtp_TO.Location = new System.Drawing.Point(257, 86);
            this.dtp_TO.Name = "dtp_TO";
            this.dtp_TO.Size = new System.Drawing.Size(108, 23);
            this.dtp_TO.TabIndex = 120;
            // 
            // dtp_FROM
            // 
            this.dtp_FROM.CustomFormat = "dd/MM/yyyy";
            this.dtp_FROM.Enabled = false;
            this.dtp_FROM.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.dtp_FROM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_FROM.Location = new System.Drawing.Point(134, 86);
            this.dtp_FROM.Name = "dtp_FROM";
            this.dtp_FROM.Size = new System.Drawing.Size(108, 23);
            this.dtp_FROM.TabIndex = 119;
            // 
            // lblFROM
            // 
            this.lblFROM.AutoSize = true;
            this.lblFROM.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblFROM.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblFROM.Location = new System.Drawing.Point(244, 90);
            this.lblFROM.Name = "lblFROM";
            this.lblFROM.Size = new System.Drawing.Size(12, 15);
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
            this.btnSHOW.Location = new System.Drawing.Point(134, 115);
            this.btnSHOW.Name = "btnSHOW";
            this.btnSHOW.Size = new System.Drawing.Size(231, 25);
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
            // rdbSalesPerson
            // 
            this.rdbSalesPerson.AutoSize = true;
            this.rdbSalesPerson.Location = new System.Drawing.Point(12, 26);
            this.rdbSalesPerson.Name = "rdbSalesPerson";
            this.rdbSalesPerson.Size = new System.Drawing.Size(116, 21);
            this.rdbSalesPerson.TabIndex = 125;
            this.rdbSalesPerson.Text = "SALES PERSON";
            this.rdbSalesPerson.UseVisualStyleBackColor = true;
            this.rdbSalesPerson.CheckedChanged += new System.EventHandler(this.rdbSalesPerson_CheckedChanged);
            // 
            // rdbCustomer
            // 
            this.rdbCustomer.AutoSize = true;
            this.rdbCustomer.Location = new System.Drawing.Point(12, 57);
            this.rdbCustomer.Name = "rdbCustomer";
            this.rdbCustomer.Size = new System.Drawing.Size(93, 21);
            this.rdbCustomer.TabIndex = 126;
            this.rdbCustomer.Text = "CUSTOMER";
            this.rdbCustomer.UseVisualStyleBackColor = true;
            this.rdbCustomer.CheckedChanged += new System.EventHandler(this.rdbCustomer_CheckedChanged);
            // 
            // rdbOverAll
            // 
            this.rdbOverAll.AutoSize = true;
            this.rdbOverAll.Checked = true;
            this.rdbOverAll.Location = new System.Drawing.Point(12, 117);
            this.rdbOverAll.Name = "rdbOverAll";
            this.rdbOverAll.Size = new System.Drawing.Size(80, 21);
            this.rdbOverAll.TabIndex = 127;
            this.rdbOverAll.TabStop = true;
            this.rdbOverAll.Text = "OVERALL";
            this.rdbOverAll.UseVisualStyleBackColor = true;
            this.rdbOverAll.CheckedChanged += new System.EventHandler(this.rdbOverAll_CheckedChanged);
            // 
            // rdbDate
            // 
            this.rdbDate.AutoSize = true;
            this.rdbDate.Location = new System.Drawing.Point(12, 87);
            this.rdbDate.Name = "rdbDate";
            this.rdbDate.Size = new System.Drawing.Size(57, 21);
            this.rdbDate.TabIndex = 128;
            this.rdbDate.Text = "DATE";
            this.rdbDate.UseVisualStyleBackColor = true;
            this.rdbDate.CheckedChanged += new System.EventHandler(this.rdbDate_CheckedChanged);
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCustomer.Enabled = false;
            this.cmbCustomer.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(134, 55);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(231, 25);
            this.cmbCustomer.TabIndex = 129;
            this.cmbCustomer.DropDown += new System.EventHandler(this.cmbCustomer_DropDown);
            this.cmbCustomer.TextUpdate += new System.EventHandler(this.cmbSalePerson_TextUpdate);
            this.cmbCustomer.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmbCustomer_PreviewKeyDown);
            // 
            // frm_ChqInHandReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(377, 240);
            this.Controls.Add(this.grpCASHBOOK);
            this.Controls.Add(this.pnlHEADER);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(393, 279);
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
        private SergeUtils.EasyCompletionComboBox cmbSalePerson;
        private SergeUtils.EasyCompletionComboBox cmbCustomer;
        private System.Windows.Forms.RadioButton rdbDate;
        private System.Windows.Forms.RadioButton rdbOverAll;
        private System.Windows.Forms.RadioButton rdbCustomer;
        private System.Windows.Forms.RadioButton rdbSalesPerson;
    }
}