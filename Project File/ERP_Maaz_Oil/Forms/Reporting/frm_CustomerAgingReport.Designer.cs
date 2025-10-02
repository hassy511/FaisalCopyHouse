namespace ERP_Maaz_Oil.Forms.Reporting
{
    partial class frm_CustomerAgingReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_CustomerAgingReport));
            this.pnlHEADER = new System.Windows.Forms.Panel();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.lblHEADING = new System.Windows.Forms.Label();
            this.grpCASHBOOK = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdbConsolidated = new System.Windows.Forms.RadioButton();
            this.rdbDetailed = new System.Windows.Forms.RadioButton();
            this.cmbDays = new SergeUtils.EasyCompletionComboBox();
            this.chkDays = new System.Windows.Forms.CheckBox();
            this.chkArea = new System.Windows.Forms.CheckBox();
            this.cmbArea = new SergeUtils.EasyCompletionComboBox();
            this.rdbCustomer = new System.Windows.Forms.RadioButton();
            this.rdbProvince = new System.Windows.Forms.RadioButton();
            this.cmbCustomer = new SergeUtils.EasyCompletionComboBox();
            this.cmbProvnice = new SergeUtils.EasyCompletionComboBox();
            this.btnSHOW = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.cmbSalePerson = new SergeUtils.EasyCompletionComboBox();
            this.rdbSalesPerson = new System.Windows.Forms.RadioButton();
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
            this.pnlHEADER.Size = new System.Drawing.Size(340, 88);
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
            this.lblHEADING.Font = new System.Drawing.Font("Berlin Sans FB", 14.75F);
            this.lblHEADING.ForeColor = System.Drawing.Color.White;
            this.lblHEADING.Location = new System.Drawing.Point(2, 18);
            this.lblHEADING.Name = "lblHEADING";
            this.lblHEADING.Size = new System.Drawing.Size(146, 46);
            this.lblHEADING.TabIndex = 23;
            this.lblHEADING.Text = "CUSTOMER \r\nAGING REPORT";
            // 
            // grpCASHBOOK
            // 
            this.grpCASHBOOK.Controls.Add(this.panel1);
            this.grpCASHBOOK.Controls.Add(this.cmbDays);
            this.grpCASHBOOK.Controls.Add(this.chkDays);
            this.grpCASHBOOK.Controls.Add(this.chkArea);
            this.grpCASHBOOK.Controls.Add(this.cmbArea);
            this.grpCASHBOOK.Controls.Add(this.rdbCustomer);
            this.grpCASHBOOK.Controls.Add(this.rdbProvince);
            this.grpCASHBOOK.Controls.Add(this.rdbSalesPerson);
            this.grpCASHBOOK.Controls.Add(this.cmbCustomer);
            this.grpCASHBOOK.Controls.Add(this.cmbProvnice);
            this.grpCASHBOOK.Controls.Add(this.cmbSalePerson);
            this.grpCASHBOOK.Controls.Add(this.btnSHOW);
            this.grpCASHBOOK.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpCASHBOOK.Location = new System.Drawing.Point(0, 90);
            this.grpCASHBOOK.Name = "grpCASHBOOK";
            this.grpCASHBOOK.Size = new System.Drawing.Size(340, 247);
            this.grpCASHBOOK.TabIndex = 37;
            this.grpCASHBOOK.TabStop = false;
            this.grpCASHBOOK.Text = "AGING REPORT";
            this.grpCASHBOOK.Enter += new System.EventHandler(this.grpSALES_Enter);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdbConsolidated);
            this.panel1.Controls.Add(this.rdbDetailed);
            this.panel1.Location = new System.Drawing.Point(125, 179);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(203, 29);
            this.panel1.TabIndex = 351;
            // 
            // rdbConsolidated
            // 
            this.rdbConsolidated.AutoSize = true;
            this.rdbConsolidated.Location = new System.Drawing.Point(82, 3);
            this.rdbConsolidated.Name = "rdbConsolidated";
            this.rdbConsolidated.Size = new System.Drawing.Size(121, 21);
            this.rdbConsolidated.TabIndex = 1;
            this.rdbConsolidated.Text = "CONSOLIDATED";
            this.rdbConsolidated.UseVisualStyleBackColor = true;
            // 
            // rdbDetailed
            // 
            this.rdbDetailed.AutoSize = true;
            this.rdbDetailed.Checked = true;
            this.rdbDetailed.Location = new System.Drawing.Point(0, 3);
            this.rdbDetailed.Name = "rdbDetailed";
            this.rdbDetailed.Size = new System.Drawing.Size(83, 21);
            this.rdbDetailed.TabIndex = 0;
            this.rdbDetailed.TabStop = true;
            this.rdbDetailed.Text = "DETAILED";
            this.rdbDetailed.UseVisualStyleBackColor = true;
            // 
            // cmbDays
            // 
            this.cmbDays.Enabled = false;
            this.cmbDays.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbDays.FormattingEnabled = true;
            this.cmbDays.Location = new System.Drawing.Point(125, 148);
            this.cmbDays.Name = "cmbDays";
            this.cmbDays.Size = new System.Drawing.Size(203, 25);
            this.cmbDays.TabIndex = 9;
            // 
            // chkDays
            // 
            this.chkDays.AutoSize = true;
            this.chkDays.Location = new System.Drawing.Point(7, 152);
            this.chkDays.Name = "chkDays";
            this.chkDays.Size = new System.Drawing.Size(59, 21);
            this.chkDays.TabIndex = 8;
            this.chkDays.Text = "DAYS";
            this.chkDays.UseVisualStyleBackColor = true;
            this.chkDays.CheckedChanged += new System.EventHandler(this.chkDays_CheckedChanged);
            // 
            // chkArea
            // 
            this.chkArea.AutoSize = true;
            this.chkArea.Location = new System.Drawing.Point(7, 121);
            this.chkArea.Name = "chkArea";
            this.chkArea.Size = new System.Drawing.Size(60, 21);
            this.chkArea.TabIndex = 6;
            this.chkArea.Text = "AREA";
            this.chkArea.UseVisualStyleBackColor = true;
            this.chkArea.CheckedChanged += new System.EventHandler(this.chkArea_CheckedChanged);
            // 
            // cmbArea
            // 
            this.cmbArea.Enabled = false;
            this.cmbArea.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbArea.FormattingEnabled = true;
            this.cmbArea.Location = new System.Drawing.Point(125, 117);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(203, 25);
            this.cmbArea.TabIndex = 7;
            // 
            // rdbCustomer
            // 
            this.rdbCustomer.AutoSize = true;
            this.rdbCustomer.Location = new System.Drawing.Point(7, 88);
            this.rdbCustomer.Name = "rdbCustomer";
            this.rdbCustomer.Size = new System.Drawing.Size(96, 21);
            this.rdbCustomer.TabIndex = 4;
            this.rdbCustomer.Text = "CUSTOMER:";
            this.rdbCustomer.UseVisualStyleBackColor = true;
            this.rdbCustomer.CheckedChanged += new System.EventHandler(this.rdbCustomer_CheckedChanged);
            // 
            // rdbProvince
            // 
            this.rdbProvince.AutoSize = true;
            this.rdbProvince.Location = new System.Drawing.Point(7, 57);
            this.rdbProvince.Name = "rdbProvince";
            this.rdbProvince.Size = new System.Drawing.Size(92, 21);
            this.rdbProvince.TabIndex = 2;
            this.rdbProvince.Text = "PROVINCE:";
            this.rdbProvince.UseVisualStyleBackColor = true;
            this.rdbProvince.CheckedChanged += new System.EventHandler(this.rdbProvince_CheckedChanged);
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.Enabled = false;
            this.cmbCustomer.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(125, 86);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(203, 25);
            this.cmbCustomer.TabIndex = 5;
            this.cmbCustomer.DropDown += new System.EventHandler(this.cmbCustomer_DropDown);
            this.cmbCustomer.TextUpdate += new System.EventHandler(this.cmbSalePerson_TextUpdate);
            this.cmbCustomer.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmbCustomer_PreviewKeyDown);
            // 
            // cmbProvnice
            // 
            this.cmbProvnice.Enabled = false;
            this.cmbProvnice.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbProvnice.FormattingEnabled = true;
            this.cmbProvnice.Location = new System.Drawing.Point(125, 55);
            this.cmbProvnice.Name = "cmbProvnice";
            this.cmbProvnice.Size = new System.Drawing.Size(203, 25);
            this.cmbProvnice.TabIndex = 3;
            this.cmbProvnice.DropDown += new System.EventHandler(this.cmbProvnice_DropDown);
            this.cmbProvnice.TextUpdate += new System.EventHandler(this.cmbSalePerson_TextUpdate);
            this.cmbProvnice.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmbProvnice_PreviewKeyDown);
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
            this.btnSHOW.Location = new System.Drawing.Point(125, 214);
            this.btnSHOW.Name = "btnSHOW";
            this.btnSHOW.Size = new System.Drawing.Size(203, 25);
            this.btnSHOW.TabIndex = 10;
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
            // cmbSalePerson
            // 
            this.cmbSalePerson.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbSalePerson.FormattingEnabled = true;
            this.cmbSalePerson.Location = new System.Drawing.Point(125, 24);
            this.cmbSalePerson.Name = "cmbSalePerson";
            this.cmbSalePerson.Size = new System.Drawing.Size(203, 25);
            this.cmbSalePerson.TabIndex = 1;
            this.cmbSalePerson.DropDown += new System.EventHandler(this.cmbSalePerson_DropDown);
            this.cmbSalePerson.SelectedIndexChanged += new System.EventHandler(this.cmbSalePerson_SelectedIndexChanged);
            this.cmbSalePerson.TextUpdate += new System.EventHandler(this.cmbSalePerson_TextUpdate);
            this.cmbSalePerson.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmbSalePerson_PreviewKeyDown);
            // 
            // rdbSalesPerson
            // 
            this.rdbSalesPerson.AutoSize = true;
            this.rdbSalesPerson.Checked = true;
            this.rdbSalesPerson.Location = new System.Drawing.Point(7, 26);
            this.rdbSalesPerson.Name = "rdbSalesPerson";
            this.rdbSalesPerson.Size = new System.Drawing.Size(112, 21);
            this.rdbSalesPerson.TabIndex = 0;
            this.rdbSalesPerson.TabStop = true;
            this.rdbSalesPerson.Text = "SALE PERSON:";
            this.rdbSalesPerson.UseVisualStyleBackColor = true;
            this.rdbSalesPerson.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // frm_CustomerAgingReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(340, 338);
            this.Controls.Add(this.grpCASHBOOK);
            this.Controls.Add(this.pnlHEADER);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(356, 377);
            this.Name = "frm_CustomerAgingReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CUSTOMER AGING REPORT";
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
        private System.Windows.Forms.ImageList imageList1;
        private SergeUtils.EasyCompletionComboBox cmbCustomer;
        private SergeUtils.EasyCompletionComboBox cmbProvnice;
        private System.Windows.Forms.RadioButton rdbCustomer;
        private System.Windows.Forms.RadioButton rdbProvince;
        private SergeUtils.EasyCompletionComboBox cmbArea;
        private System.Windows.Forms.CheckBox chkDays;
        private System.Windows.Forms.CheckBox chkArea;
        private SergeUtils.EasyCompletionComboBox cmbDays;
        private System.Windows.Forms.RadioButton rdbConsolidated;
        private System.Windows.Forms.RadioButton rdbDetailed;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdbSalesPerson;
        private SergeUtils.EasyCompletionComboBox cmbSalePerson;
    }
}