namespace ERP_Maaz_Oil.Forms.Reporting
{
    partial class frm_PaymentReports
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_PaymentReports));
            this.pnlHEADER = new System.Windows.Forms.Panel();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.lblHEADING = new System.Windows.Forms.Label();
            this.grpCASHBOOK = new System.Windows.Forms.GroupBox();
            this.cmbCustomer = new SergeUtils.EasyCompletionComboBox();
            this.cmbSupplier = new SergeUtils.EasyCompletionComboBox();
            this.rdbCustomer = new System.Windows.Forms.RadioButton();
            this.rdbSalesPerson = new System.Windows.Forms.RadioButton();
            this.rdbSupplier = new System.Windows.Forms.RadioButton();
            this.rdbOverallDetailReport = new System.Windows.Forms.RadioButton();
            this.cmbSalePerson = new SergeUtils.EasyCompletionComboBox();
            this.rdbPending = new System.Windows.Forms.RadioButton();
            this.rdbConformation = new System.Windows.Forms.RadioButton();
            this.dtp_TO = new System.Windows.Forms.DateTimePicker();
            this.dtp_FROM = new System.Windows.Forms.DateTimePicker();
            this.lblFROM = new System.Windows.Forms.Label();
            this.btnSHOW = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lblITO = new System.Windows.Forms.Label();
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
            this.pnlHEADER.Size = new System.Drawing.Size(820, 88);
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
            this.lblHEADING.Font = new System.Drawing.Font("Berlin Sans FB", 15.75F);
            this.lblHEADING.ForeColor = System.Drawing.Color.White;
            this.lblHEADING.Location = new System.Drawing.Point(11, 31);
            this.lblHEADING.Name = "lblHEADING";
            this.lblHEADING.Size = new System.Drawing.Size(190, 23);
            this.lblHEADING.TabIndex = 23;
            this.lblHEADING.Text = "PAYMENT REPORTS";
            // 
            // grpCASHBOOK
            // 
            this.grpCASHBOOK.Controls.Add(this.cmbCustomer);
            this.grpCASHBOOK.Controls.Add(this.cmbSupplier);
            this.grpCASHBOOK.Controls.Add(this.rdbCustomer);
            this.grpCASHBOOK.Controls.Add(this.rdbSalesPerson);
            this.grpCASHBOOK.Controls.Add(this.rdbSupplier);
            this.grpCASHBOOK.Controls.Add(this.rdbOverallDetailReport);
            this.grpCASHBOOK.Controls.Add(this.cmbSalePerson);
            this.grpCASHBOOK.Controls.Add(this.rdbPending);
            this.grpCASHBOOK.Controls.Add(this.rdbConformation);
            this.grpCASHBOOK.Controls.Add(this.dtp_TO);
            this.grpCASHBOOK.Controls.Add(this.dtp_FROM);
            this.grpCASHBOOK.Controls.Add(this.lblFROM);
            this.grpCASHBOOK.Controls.Add(this.btnSHOW);
            this.grpCASHBOOK.Controls.Add(this.lblITO);
            this.grpCASHBOOK.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpCASHBOOK.Location = new System.Drawing.Point(0, 90);
            this.grpCASHBOOK.Name = "grpCASHBOOK";
            this.grpCASHBOOK.Size = new System.Drawing.Size(814, 121);
            this.grpCASHBOOK.TabIndex = 0;
            this.grpCASHBOOK.TabStop = false;
            this.grpCASHBOOK.Text = "PAYMENT REPORT";
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCustomer.Enabled = false;
            this.cmbCustomer.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(329, 86);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(231, 25);
            this.cmbCustomer.TabIndex = 8;
            this.cmbCustomer.DropDown += new System.EventHandler(this.cmbCustomer_DropDown);
            this.cmbCustomer.TextUpdate += new System.EventHandler(this.cmbSalePerson_TextUpdate);
            this.cmbCustomer.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmbCustomer_PreviewKeyDown);
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSupplier.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSupplier.Enabled = false;
            this.cmbSupplier.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbSupplier.FormattingEnabled = true;
            this.cmbSupplier.Location = new System.Drawing.Point(329, 55);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(231, 25);
            this.cmbSupplier.TabIndex = 6;
            this.cmbSupplier.DropDown += new System.EventHandler(this.cmbSupplier_DropDown);
            this.cmbSupplier.TextUpdate += new System.EventHandler(this.cmbSalePerson_TextUpdate);
            this.cmbSupplier.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmbSupplier_PreviewKeyDown);
            // 
            // rdbCustomer
            // 
            this.rdbCustomer.AutoSize = true;
            this.rdbCustomer.Location = new System.Drawing.Point(176, 88);
            this.rdbCustomer.Name = "rdbCustomer";
            this.rdbCustomer.Size = new System.Drawing.Size(130, 21);
            this.rdbCustomer.TabIndex = 7;
            this.rdbCustomer.TabStop = true;
            this.rdbCustomer.Text = "Customer Report";
            this.rdbCustomer.UseVisualStyleBackColor = true;
            this.rdbCustomer.CheckedChanged += new System.EventHandler(this.rdbCustomer_CheckedChanged);
            // 
            // rdbSalesPerson
            // 
            this.rdbSalesPerson.AutoSize = true;
            this.rdbSalesPerson.Location = new System.Drawing.Point(176, 26);
            this.rdbSalesPerson.Name = "rdbSalesPerson";
            this.rdbSalesPerson.Size = new System.Drawing.Size(147, 21);
            this.rdbSalesPerson.TabIndex = 3;
            this.rdbSalesPerson.TabStop = true;
            this.rdbSalesPerson.Text = "Sales Person Report";
            this.rdbSalesPerson.UseVisualStyleBackColor = true;
            this.rdbSalesPerson.CheckedChanged += new System.EventHandler(this.rdbSalesPerson_CheckedChanged);
            // 
            // rdbSupplier
            // 
            this.rdbSupplier.AutoSize = true;
            this.rdbSupplier.Location = new System.Drawing.Point(176, 57);
            this.rdbSupplier.Name = "rdbSupplier";
            this.rdbSupplier.Size = new System.Drawing.Size(120, 21);
            this.rdbSupplier.TabIndex = 5;
            this.rdbSupplier.TabStop = true;
            this.rdbSupplier.Text = "Supplier Report";
            this.rdbSupplier.UseVisualStyleBackColor = true;
            this.rdbSupplier.CheckedChanged += new System.EventHandler(this.rdbSupplier_CheckedChanged);
            // 
            // rdbOverallDetailReport
            // 
            this.rdbOverallDetailReport.AutoSize = true;
            this.rdbOverallDetailReport.Location = new System.Drawing.Point(6, 88);
            this.rdbOverallDetailReport.Name = "rdbOverallDetailReport";
            this.rdbOverallDetailReport.Size = new System.Drawing.Size(151, 21);
            this.rdbOverallDetailReport.TabIndex = 2;
            this.rdbOverallDetailReport.TabStop = true;
            this.rdbOverallDetailReport.Text = "Overall Detail Report";
            this.rdbOverallDetailReport.UseVisualStyleBackColor = true;
            // 
            // cmbSalePerson
            // 
            this.cmbSalePerson.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSalePerson.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSalePerson.Enabled = false;
            this.cmbSalePerson.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbSalePerson.FormattingEnabled = true;
            this.cmbSalePerson.Location = new System.Drawing.Point(329, 24);
            this.cmbSalePerson.Name = "cmbSalePerson";
            this.cmbSalePerson.Size = new System.Drawing.Size(231, 25);
            this.cmbSalePerson.TabIndex = 4;
            this.cmbSalePerson.DropDown += new System.EventHandler(this.cmbSalePerson_DropDown);
            this.cmbSalePerson.TextUpdate += new System.EventHandler(this.cmbSalePerson_TextUpdate);
            this.cmbSalePerson.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmbSalePerson_PreviewKeyDown);
            // 
            // rdbPending
            // 
            this.rdbPending.AutoSize = true;
            this.rdbPending.Location = new System.Drawing.Point(6, 57);
            this.rdbPending.Name = "rdbPending";
            this.rdbPending.Size = new System.Drawing.Size(121, 21);
            this.rdbPending.TabIndex = 1;
            this.rdbPending.TabStop = true;
            this.rdbPending.Text = "Pending Report";
            this.rdbPending.UseVisualStyleBackColor = true;
            // 
            // rdbConformation
            // 
            this.rdbConformation.AutoSize = true;
            this.rdbConformation.Checked = true;
            this.rdbConformation.Location = new System.Drawing.Point(6, 26);
            this.rdbConformation.Name = "rdbConformation";
            this.rdbConformation.Size = new System.Drawing.Size(155, 21);
            this.rdbConformation.TabIndex = 0;
            this.rdbConformation.TabStop = true;
            this.rdbConformation.Text = "Conformation Report";
            this.rdbConformation.UseVisualStyleBackColor = true;
            // 
            // dtp_TO
            // 
            this.dtp_TO.CustomFormat = "dd/MM/yyyy";
            this.dtp_TO.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.dtp_TO.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_TO.Location = new System.Drawing.Point(615, 56);
            this.dtp_TO.Name = "dtp_TO";
            this.dtp_TO.Size = new System.Drawing.Size(193, 23);
            this.dtp_TO.TabIndex = 10;
            // 
            // dtp_FROM
            // 
            this.dtp_FROM.CustomFormat = "dd/MM/yyyy";
            this.dtp_FROM.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.dtp_FROM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_FROM.Location = new System.Drawing.Point(615, 25);
            this.dtp_FROM.Name = "dtp_FROM";
            this.dtp_FROM.Size = new System.Drawing.Size(193, 23);
            this.dtp_FROM.TabIndex = 9;
            // 
            // lblFROM
            // 
            this.lblFROM.AutoSize = true;
            this.lblFROM.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblFROM.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblFROM.Location = new System.Drawing.Point(566, 29);
            this.lblFROM.Name = "lblFROM";
            this.lblFROM.Size = new System.Drawing.Size(43, 15);
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
            this.btnSHOW.Location = new System.Drawing.Point(615, 86);
            this.btnSHOW.Name = "btnSHOW";
            this.btnSHOW.Size = new System.Drawing.Size(193, 25);
            this.btnSHOW.TabIndex = 11;
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
            this.lblITO.Location = new System.Drawing.Point(583, 60);
            this.lblITO.Name = "lblITO";
            this.lblITO.Size = new System.Drawing.Size(26, 15);
            this.lblITO.TabIndex = 46;
            this.lblITO.Text = "TO:";
            // 
            // frm_PaymentReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(820, 213);
            this.Controls.Add(this.grpCASHBOOK);
            this.Controls.Add(this.pnlHEADER);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(836, 252);
            this.Name = "frm_PaymentReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PAYMENT REPORTS";
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
        private System.Windows.Forms.Label lblITO;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lblFROM;
        private System.Windows.Forms.DateTimePicker dtp_TO;
        private System.Windows.Forms.DateTimePicker dtp_FROM;
        private System.Windows.Forms.RadioButton rdbConformation;
        private System.Windows.Forms.RadioButton rdbPending;
        private SergeUtils.EasyCompletionComboBox cmbSalePerson;
        private System.Windows.Forms.RadioButton rdbSupplier;
        private System.Windows.Forms.RadioButton rdbOverallDetailReport;
        private System.Windows.Forms.RadioButton rdbCustomer;
        private System.Windows.Forms.RadioButton rdbSalesPerson;
        private SergeUtils.EasyCompletionComboBox cmbCustomer;
        private SergeUtils.EasyCompletionComboBox cmbSupplier;
    }
}