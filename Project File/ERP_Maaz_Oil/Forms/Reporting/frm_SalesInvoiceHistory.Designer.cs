namespace ERP_Maaz_Oil.Forms.Reporting
{
    partial class frm_SalesInvoiceHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_SalesInvoiceHistory));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.lblHEADING = new System.Windows.Forms.Label();
            this.pnlHEADER = new System.Windows.Forms.Panel();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.cmbArea = new SergeUtils.EasyCompletionComboBox();
            this.cmbSalesPerson = new SergeUtils.EasyCompletionComboBox();
            this.btnSHOW = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.grpCASHBOOK = new System.Windows.Forms.GroupBox();
            this.chkDays = new System.Windows.Forms.CheckBox();
            this.chkArea = new System.Windows.Forms.CheckBox();
            this.rdbCustomer = new System.Windows.Forms.RadioButton();
            this.rdbProvince = new System.Windows.Forms.RadioButton();
            this.rdbAll = new System.Windows.Forms.RadioButton();
            this.rdbSales = new System.Windows.Forms.RadioButton();
            this.grdSEARCH = new System.Windows.Forms.DataGridView();
            this.s_nature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.a_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.debit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.credit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FOLIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbDays = new SergeUtils.EasyCompletionComboBox();
            this.cmbProvince = new SergeUtils.EasyCompletionComboBox();
            this.cmbCustName = new SergeUtils.EasyCompletionComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            this.pnlHEADER.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
            this.grpCASHBOOK.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSEARCH)).BeginInit();
            this.SuspendLayout();
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
            this.lblHEADING.Font = new System.Drawing.Font("Berlin Sans FB", 11.75F);
            this.lblHEADING.ForeColor = System.Drawing.Color.White;
            this.lblHEADING.Location = new System.Drawing.Point(3, 55);
            this.lblHEADING.Name = "lblHEADING";
            this.lblHEADING.Size = new System.Drawing.Size(175, 18);
            this.lblHEADING.TabIndex = 23;
            this.lblHEADING.Text = "SALES INVOICE HISTORY";
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
            this.pnlHEADER.Size = new System.Drawing.Size(468, 88);
            this.pnlHEADER.TabIndex = 40;
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
            // cmbArea
            // 
            this.cmbArea.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbArea.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbArea.Enabled = false;
            this.cmbArea.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbArea.FormattingEnabled = true;
            this.cmbArea.Location = new System.Drawing.Point(161, 156);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(231, 25);
            this.cmbArea.TabIndex = 0;
            // 
            // cmbSalesPerson
            // 
            this.cmbSalesPerson.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSalesPerson.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSalesPerson.Enabled = false;
            this.cmbSalesPerson.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbSalesPerson.FormattingEnabled = true;
            this.cmbSalesPerson.Location = new System.Drawing.Point(161, 63);
            this.cmbSalesPerson.Name = "cmbSalesPerson";
            this.cmbSalesPerson.Size = new System.Drawing.Size(231, 25);
            this.cmbSalesPerson.TabIndex = 0;
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
            this.btnSHOW.Location = new System.Drawing.Point(161, 228);
            this.btnSHOW.Name = "btnSHOW";
            this.btnSHOW.Size = new System.Drawing.Size(231, 25);
            this.btnSHOW.TabIndex = 3;
            this.btnSHOW.Text = "SHOW";
            this.btnSHOW.UseVisualStyleBackColor = false;
            this.btnSHOW.Click += new System.EventHandler(this.btnSHOW_Click);
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
            // grpCASHBOOK
            // 
            this.grpCASHBOOK.Controls.Add(this.chkDays);
            this.grpCASHBOOK.Controls.Add(this.chkArea);
            this.grpCASHBOOK.Controls.Add(this.rdbCustomer);
            this.grpCASHBOOK.Controls.Add(this.rdbProvince);
            this.grpCASHBOOK.Controls.Add(this.rdbAll);
            this.grpCASHBOOK.Controls.Add(this.rdbSales);
            this.grpCASHBOOK.Controls.Add(this.grdSEARCH);
            this.grpCASHBOOK.Controls.Add(this.cmbArea);
            this.grpCASHBOOK.Controls.Add(this.cmbDays);
            this.grpCASHBOOK.Controls.Add(this.cmbProvince);
            this.grpCASHBOOK.Controls.Add(this.cmbSalesPerson);
            this.grpCASHBOOK.Controls.Add(this.cmbCustName);
            this.grpCASHBOOK.Controls.Add(this.btnSHOW);
            this.grpCASHBOOK.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpCASHBOOK.Location = new System.Drawing.Point(12, 117);
            this.grpCASHBOOK.Name = "grpCASHBOOK";
            this.grpCASHBOOK.Size = new System.Drawing.Size(429, 268);
            this.grpCASHBOOK.TabIndex = 41;
            this.grpCASHBOOK.TabStop = false;
            this.grpCASHBOOK.Text = "SALES INVOICE HISTORY";
            // 
            // chkDays
            // 
            this.chkDays.AutoSize = true;
            this.chkDays.Location = new System.Drawing.Point(41, 191);
            this.chkDays.Name = "chkDays";
            this.chkDays.Size = new System.Drawing.Size(59, 21);
            this.chkDays.TabIndex = 340;
            this.chkDays.Text = "DAYS";
            this.chkDays.UseVisualStyleBackColor = true;
            this.chkDays.CheckedChanged += new System.EventHandler(this.checkBoxCheckedChanged);
            // 
            // chkArea
            // 
            this.chkArea.AutoSize = true;
            this.chkArea.Location = new System.Drawing.Point(41, 157);
            this.chkArea.Name = "chkArea";
            this.chkArea.Size = new System.Drawing.Size(60, 21);
            this.chkArea.TabIndex = 340;
            this.chkArea.Text = "AREA";
            this.chkArea.UseVisualStyleBackColor = true;
            this.chkArea.CheckedChanged += new System.EventHandler(this.checkBoxCheckedChanged);
            // 
            // rdbCustomer
            // 
            this.rdbCustomer.AutoSize = true;
            this.rdbCustomer.Location = new System.Drawing.Point(41, 127);
            this.rdbCustomer.Name = "rdbCustomer";
            this.rdbCustomer.Size = new System.Drawing.Size(96, 21);
            this.rdbCustomer.TabIndex = 339;
            this.rdbCustomer.TabStop = true;
            this.rdbCustomer.Text = "CUSTOMER:";
            this.rdbCustomer.UseVisualStyleBackColor = true;
            this.rdbCustomer.CheckedChanged += new System.EventHandler(this.rdbSales_CheckedChanged);
            // 
            // rdbProvince
            // 
            this.rdbProvince.AutoSize = true;
            this.rdbProvince.Location = new System.Drawing.Point(41, 96);
            this.rdbProvince.Name = "rdbProvince";
            this.rdbProvince.Size = new System.Drawing.Size(92, 21);
            this.rdbProvince.TabIndex = 339;
            this.rdbProvince.TabStop = true;
            this.rdbProvince.Text = "PROVINCE:";
            this.rdbProvince.UseVisualStyleBackColor = true;
            this.rdbProvince.CheckedChanged += new System.EventHandler(this.rdbSales_CheckedChanged);
            // 
            // rdbAll
            // 
            this.rdbAll.AutoSize = true;
            this.rdbAll.Checked = true;
            this.rdbAll.Location = new System.Drawing.Point(41, 38);
            this.rdbAll.Name = "rdbAll";
            this.rdbAll.Size = new System.Drawing.Size(47, 21);
            this.rdbAll.TabIndex = 339;
            this.rdbAll.TabStop = true;
            this.rdbAll.Text = "ALL";
            this.rdbAll.UseVisualStyleBackColor = true;
            this.rdbAll.CheckedChanged += new System.EventHandler(this.rdbSales_CheckedChanged);
            // 
            // rdbSales
            // 
            this.rdbSales.AutoSize = true;
            this.rdbSales.Location = new System.Drawing.Point(41, 65);
            this.rdbSales.Name = "rdbSales";
            this.rdbSales.Size = new System.Drawing.Size(116, 21);
            this.rdbSales.TabIndex = 339;
            this.rdbSales.Text = "SALES PERSON";
            this.rdbSales.UseVisualStyleBackColor = true;
            this.rdbSales.CheckedChanged += new System.EventHandler(this.rdbSales_CheckedChanged);
            // 
            // grdSEARCH
            // 
            this.grdSEARCH.AllowUserToAddRows = false;
            this.grdSEARCH.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue;
            this.grdSEARCH.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdSEARCH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdSEARCH.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grdSEARCH.BackgroundColor = System.Drawing.Color.White;
            this.grdSEARCH.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdSEARCH.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdSEARCH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSEARCH.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.s_nature,
            this.a_name,
            this.debit,
            this.credit,
            this.bal,
            this.dc,
            this.FOLIO});
            this.grdSEARCH.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdSEARCH.DefaultCellStyle = dataGridViewCellStyle3;
            this.grdSEARCH.Location = new System.Drawing.Point(9, 171);
            this.grdSEARCH.Name = "grdSEARCH";
            this.grdSEARCH.ReadOnly = true;
            this.grdSEARCH.RowHeadersVisible = false;
            this.grdSEARCH.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSEARCH.Size = new System.Drawing.Size(10, 10);
            this.grdSEARCH.TabIndex = 338;
            this.grdSEARCH.TabStop = false;
            this.grdSEARCH.Visible = false;
            // 
            // s_nature
            // 
            this.s_nature.HeaderText = "DATE";
            this.s_nature.Name = "s_nature";
            this.s_nature.ReadOnly = true;
            this.s_nature.Width = 64;
            // 
            // a_name
            // 
            this.a_name.HeaderText = "DESCRIPTION";
            this.a_name.Name = "a_name";
            this.a_name.ReadOnly = true;
            this.a_name.Width = 115;
            // 
            // debit
            // 
            this.debit.HeaderText = "DEBIT";
            this.debit.Name = "debit";
            this.debit.ReadOnly = true;
            this.debit.Width = 68;
            // 
            // credit
            // 
            this.credit.HeaderText = "CREDIT";
            this.credit.Name = "credit";
            this.credit.ReadOnly = true;
            this.credit.Width = 76;
            // 
            // bal
            // 
            this.bal.HeaderText = "BALANCE";
            this.bal.Name = "bal";
            this.bal.ReadOnly = true;
            this.bal.Width = 90;
            // 
            // dc
            // 
            this.dc.HeaderText = "Dr / Cr";
            this.dc.Name = "dc";
            this.dc.ReadOnly = true;
            this.dc.Width = 73;
            // 
            // FOLIO
            // 
            this.FOLIO.HeaderText = "FOLIO";
            this.FOLIO.Name = "FOLIO";
            this.FOLIO.ReadOnly = true;
            this.FOLIO.Width = 70;
            // 
            // cmbDays
            // 
            this.cmbDays.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbDays.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDays.Enabled = false;
            this.cmbDays.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbDays.FormattingEnabled = true;
            this.cmbDays.Items.AddRange(new object[] {
            "30",
            "40",
            "50",
            "60",
            "90"});
            this.cmbDays.Location = new System.Drawing.Point(161, 187);
            this.cmbDays.Name = "cmbDays";
            this.cmbDays.Size = new System.Drawing.Size(231, 25);
            this.cmbDays.TabIndex = 0;
            this.cmbDays.Text = "-- SELECT DAYS --";
            // 
            // cmbProvince
            // 
            this.cmbProvince.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbProvince.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbProvince.Enabled = false;
            this.cmbProvince.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbProvince.FormattingEnabled = true;
            this.cmbProvince.Location = new System.Drawing.Point(161, 94);
            this.cmbProvince.Name = "cmbProvince";
            this.cmbProvince.Size = new System.Drawing.Size(231, 25);
            this.cmbProvince.TabIndex = 0;
            // 
            // cmbCustName
            // 
            this.cmbCustName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCustName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCustName.Enabled = false;
            this.cmbCustName.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbCustName.FormattingEnabled = true;
            this.cmbCustName.Location = new System.Drawing.Point(161, 125);
            this.cmbCustName.Name = "cmbCustName";
            this.cmbCustName.Size = new System.Drawing.Size(231, 25);
            this.cmbCustName.TabIndex = 0;
            // 
            // frm_SalesInvoiceHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(468, 412);
            this.Controls.Add(this.pnlHEADER);
            this.Controls.Add(this.grpCASHBOOK);
            this.Name = "frm_SalesInvoiceHistory";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SALES INVOICE HISTORY";
            this.Load += new System.EventHandler(this.frm_SalesInvoiceHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
            this.pnlHEADER.ResumeLayout(false);
            this.pnlHEADER.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
            this.grpCASHBOOK.ResumeLayout(false);
            this.grpCASHBOOK.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSEARCH)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox15;
        private System.Windows.Forms.Label lblHEADING;
        private System.Windows.Forms.Panel pnlHEADER;
        private System.Windows.Forms.PictureBox pictureBox14;
        private SergeUtils.EasyCompletionComboBox cmbArea;
        private SergeUtils.EasyCompletionComboBox cmbSalesPerson;
        private System.Windows.Forms.Button btnSHOW;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox grpCASHBOOK;
        private System.Windows.Forms.DataGridView grdSEARCH;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_nature;
        private System.Windows.Forms.DataGridViewTextBoxColumn a_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn debit;
        private System.Windows.Forms.DataGridViewTextBoxColumn credit;
        private System.Windows.Forms.DataGridViewTextBoxColumn bal;
        private System.Windows.Forms.DataGridViewTextBoxColumn dc;
        private System.Windows.Forms.DataGridViewTextBoxColumn FOLIO;
        private SergeUtils.EasyCompletionComboBox cmbDays;
        private SergeUtils.EasyCompletionComboBox cmbCustName;
        private SergeUtils.EasyCompletionComboBox cmbProvince;
        private System.Windows.Forms.RadioButton rdbSales;
        private System.Windows.Forms.RadioButton rdbCustomer;
        private System.Windows.Forms.RadioButton rdbProvince;
        private System.Windows.Forms.CheckBox chkArea;
        private System.Windows.Forms.CheckBox chkDays;
        private System.Windows.Forms.RadioButton rdbAll;
    }
}