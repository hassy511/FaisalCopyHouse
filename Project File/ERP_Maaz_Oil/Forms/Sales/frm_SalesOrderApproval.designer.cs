namespace ERP_Maaz_Oil.Forms.Reporting
{
    partial class frm_SalesOrderApproval
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_SalesOrderApproval));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHEADER = new System.Windows.Forms.Panel();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.lblHEADING = new System.Windows.Forms.Label();
            this.grpCASHBOOK = new System.Windows.Forms.GroupBox();
            this.cmbCustomer = new SergeUtils.EasyCompletionComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnShowReport = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.rdbAll = new System.Windows.Forms.RadioButton();
            this.dtp_TO = new System.Windows.Forms.DateTimePicker();
            this.dtp_FROM = new System.Windows.Forms.DateTimePicker();
            this.lblFROM = new System.Windows.Forms.Label();
            this.btnSHOW = new System.Windows.Forms.Button();
            this.lblITO = new System.Windows.Forms.Label();
            this.grdSOList = new System.Windows.Forms.DataGridView();
            this.discard = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.soID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PO_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUSTOMER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MATERIAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SO_WEIGHT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DELIVERED_WEIGHT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BALANCE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RATE_KG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESCRIPTION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CREDIT_DAYS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDiscard = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSalesPerson = new SergeUtils.EasyCompletionComboBox();
            this.pnlHEADER.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
            this.grpCASHBOOK.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSOList)).BeginInit();
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
            this.pnlHEADER.Size = new System.Drawing.Size(994, 88);
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
            this.lblHEADING.Location = new System.Drawing.Point(2, 26);
            this.lblHEADING.Name = "lblHEADING";
            this.lblHEADING.Size = new System.Drawing.Size(103, 34);
            this.lblHEADING.TabIndex = 23;
            this.lblHEADING.Text = "SALES ORDER \r\nREPORT";
            // 
            // grpCASHBOOK
            // 
            this.grpCASHBOOK.Controls.Add(this.cmbSalesPerson);
            this.grpCASHBOOK.Controls.Add(this.label2);
            this.grpCASHBOOK.Controls.Add(this.cmbCustomer);
            this.grpCASHBOOK.Controls.Add(this.label1);
            this.grpCASHBOOK.Controls.Add(this.btnShowReport);
            this.grpCASHBOOK.Controls.Add(this.radioButton1);
            this.grpCASHBOOK.Controls.Add(this.rdbAll);
            this.grpCASHBOOK.Controls.Add(this.dtp_TO);
            this.grpCASHBOOK.Controls.Add(this.dtp_FROM);
            this.grpCASHBOOK.Controls.Add(this.lblFROM);
            this.grpCASHBOOK.Controls.Add(this.btnSHOW);
            this.grpCASHBOOK.Controls.Add(this.lblITO);
            this.grpCASHBOOK.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpCASHBOOK.Location = new System.Drawing.Point(0, 90);
            this.grpCASHBOOK.Name = "grpCASHBOOK";
            this.grpCASHBOOK.Size = new System.Drawing.Size(994, 86);
            this.grpCASHBOOK.TabIndex = 37;
            this.grpCASHBOOK.TabStop = false;
            this.grpCASHBOOK.Text = "SALES ORDER REPORT";
            this.grpCASHBOOK.Enter += new System.EventHandler(this.grpSALES_Enter);
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCustomer.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Items.AddRange(new object[] {
            "--SELECT SUPPLIER--",
            "AUTOMART"});
            this.cmbCustomer.Location = new System.Drawing.Point(127, 51);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(267, 25);
            this.cmbCustomer.TabIndex = 227;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(12, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 15);
            this.label1.TabIndex = 124;
            this.label1.Text = "CUSTOMER NAME:";
            // 
            // btnShowReport
            // 
            this.btnShowReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(68)))), ((int)(((byte)(2)))));
            this.btnShowReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnShowReport.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnShowReport.ForeColor = System.Drawing.Color.White;
            this.btnShowReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShowReport.ImageIndex = 5;
            this.btnShowReport.ImageList = this.imageList1;
            this.btnShowReport.Location = new System.Drawing.Point(853, 22);
            this.btnShowReport.Name = "btnShowReport";
            this.btnShowReport.Size = new System.Drawing.Size(129, 25);
            this.btnShowReport.TabIndex = 123;
            this.btnShowReport.Text = "SHOW REPORT";
            this.btnShowReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnShowReport.UseVisualStyleBackColor = false;
            this.btnShowReport.Click += new System.EventHandler(this.btnShowReport_Click);
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
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(162, 24);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(166, 21);
            this.radioButton1.TabIndex = 122;
            this.radioButton1.Text = "SHOW ACTIVE ORDERS";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // rdbAll
            // 
            this.rdbAll.AutoSize = true;
            this.rdbAll.Checked = true;
            this.rdbAll.Location = new System.Drawing.Point(12, 24);
            this.rdbAll.Name = "rdbAll";
            this.rdbAll.Size = new System.Drawing.Size(144, 21);
            this.rdbAll.TabIndex = 121;
            this.rdbAll.TabStop = true;
            this.rdbAll.Text = "SHOW ALL ORDERS";
            this.rdbAll.UseVisualStyleBackColor = true;
            // 
            // dtp_TO
            // 
            this.dtp_TO.CustomFormat = "dd/MM/yyyy";
            this.dtp_TO.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.dtp_TO.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_TO.Location = new System.Drawing.Point(576, 23);
            this.dtp_TO.Name = "dtp_TO";
            this.dtp_TO.Size = new System.Drawing.Size(136, 23);
            this.dtp_TO.TabIndex = 120;
            // 
            // dtp_FROM
            // 
            this.dtp_FROM.CustomFormat = "dd/MM/yyyy";
            this.dtp_FROM.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.dtp_FROM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_FROM.Location = new System.Drawing.Point(402, 23);
            this.dtp_FROM.Name = "dtp_FROM";
            this.dtp_FROM.Size = new System.Drawing.Size(136, 23);
            this.dtp_FROM.TabIndex = 119;
            // 
            // lblFROM
            // 
            this.lblFROM.AutoSize = true;
            this.lblFROM.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblFROM.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblFROM.Location = new System.Drawing.Point(353, 27);
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
            this.btnSHOW.Location = new System.Drawing.Point(718, 22);
            this.btnSHOW.Name = "btnSHOW";
            this.btnSHOW.Size = new System.Drawing.Size(129, 25);
            this.btnSHOW.TabIndex = 9;
            this.btnSHOW.Text = "SHOW";
            this.btnSHOW.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSHOW.UseVisualStyleBackColor = false;
            this.btnSHOW.Click += new System.EventHandler(this.btnINTER_SAVE_Click);
            // 
            // lblITO
            // 
            this.lblITO.AutoSize = true;
            this.lblITO.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblITO.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblITO.Location = new System.Drawing.Point(544, 27);
            this.lblITO.Name = "lblITO";
            this.lblITO.Size = new System.Drawing.Size(26, 15);
            this.lblITO.TabIndex = 46;
            this.lblITO.Text = "TO:";
            // 
            // grdSOList
            // 
            this.grdSOList.AllowUserToAddRows = false;
            this.grdSOList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.grdSOList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdSOList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdSOList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grdSOList.BackgroundColor = System.Drawing.Color.White;
            this.grdSOList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdSOList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdSOList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSOList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.discard,
            this.soID,
            this.DATE,
            this.PO_NO,
            this.CUSTOMER,
            this.MATERIAL,
            this.SO_WEIGHT,
            this.DELIVERED_WEIGHT,
            this.BALANCE,
            this.RATE_KG,
            this.DESCRIPTION,
            this.CREDIT_DAYS,
            this.TYPE});
            this.grdSOList.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdSOList.DefaultCellStyle = dataGridViewCellStyle3;
            this.grdSOList.Location = new System.Drawing.Point(0, 181);
            this.grdSOList.Name = "grdSOList";
            this.grdSOList.ReadOnly = true;
            this.grdSOList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSOList.Size = new System.Drawing.Size(994, 266);
            this.grdSOList.TabIndex = 222;
            this.grdSOList.TabStop = false;
            this.grdSOList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdPOList_CellClick);
            // 
            // discard
            // 
            this.discard.HeaderText = "DISCARD";
            this.discard.Name = "discard";
            this.discard.ReadOnly = true;
            this.discard.Width = 59;
            // 
            // soID
            // 
            this.soID.HeaderText = "SO ID";
            this.soID.Name = "soID";
            this.soID.ReadOnly = true;
            this.soID.Visible = false;
            this.soID.Width = 60;
            // 
            // DATE
            // 
            this.DATE.HeaderText = "DATE";
            this.DATE.Name = "DATE";
            this.DATE.ReadOnly = true;
            this.DATE.Width = 59;
            // 
            // PO_NO
            // 
            this.PO_NO.HeaderText = "INVOICE #";
            this.PO_NO.Name = "PO_NO";
            this.PO_NO.ReadOnly = true;
            this.PO_NO.Width = 84;
            // 
            // CUSTOMER
            // 
            this.CUSTOMER.HeaderText = "CUSTOMER";
            this.CUSTOMER.Name = "CUSTOMER";
            this.CUSTOMER.ReadOnly = true;
            this.CUSTOMER.Width = 90;
            // 
            // MATERIAL
            // 
            this.MATERIAL.HeaderText = "RAW MATERIAL";
            this.MATERIAL.Name = "MATERIAL";
            this.MATERIAL.ReadOnly = true;
            this.MATERIAL.Width = 111;
            // 
            // SO_WEIGHT
            // 
            this.SO_WEIGHT.HeaderText = "SO WEIGHT";
            this.SO_WEIGHT.Name = "SO_WEIGHT";
            this.SO_WEIGHT.ReadOnly = true;
            this.SO_WEIGHT.Width = 91;
            // 
            // DELIVERED_WEIGHT
            // 
            this.DELIVERED_WEIGHT.HeaderText = "DELIVERED WEIGHT";
            this.DELIVERED_WEIGHT.Name = "DELIVERED_WEIGHT";
            this.DELIVERED_WEIGHT.ReadOnly = true;
            this.DELIVERED_WEIGHT.Width = 133;
            // 
            // BALANCE
            // 
            this.BALANCE.HeaderText = "BALANCE WEIGHT";
            this.BALANCE.Name = "BALANCE";
            this.BALANCE.ReadOnly = true;
            this.BALANCE.Width = 124;
            // 
            // RATE_KG
            // 
            this.RATE_KG.HeaderText = "RATE (KG)";
            this.RATE_KG.Name = "RATE_KG";
            this.RATE_KG.ReadOnly = true;
            this.RATE_KG.Width = 84;
            // 
            // DESCRIPTION
            // 
            this.DESCRIPTION.HeaderText = "DESCRIPTION";
            this.DESCRIPTION.Name = "DESCRIPTION";
            this.DESCRIPTION.ReadOnly = true;
            // 
            // CREDIT_DAYS
            // 
            this.CREDIT_DAYS.HeaderText = "CREDIT DAYS";
            this.CREDIT_DAYS.Name = "CREDIT_DAYS";
            this.CREDIT_DAYS.ReadOnly = true;
            this.CREDIT_DAYS.Width = 99;
            // 
            // TYPE
            // 
            this.TYPE.HeaderText = "TYPE";
            this.TYPE.Name = "TYPE";
            this.TYPE.ReadOnly = true;
            this.TYPE.Visible = false;
            this.TYPE.Width = 56;
            // 
            // btnDiscard
            // 
            this.btnDiscard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(68)))), ((int)(((byte)(2)))));
            this.btnDiscard.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDiscard.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnDiscard.ForeColor = System.Drawing.Color.White;
            this.btnDiscard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDiscard.ImageIndex = 5;
            this.btnDiscard.ImageList = this.imageList1;
            this.btnDiscard.Location = new System.Drawing.Point(6, 453);
            this.btnDiscard.Name = "btnDiscard";
            this.btnDiscard.Size = new System.Drawing.Size(129, 25);
            this.btnDiscard.TabIndex = 124;
            this.btnDiscard.Text = "DISCARD S.O";
            this.btnDiscard.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDiscard.UseVisualStyleBackColor = false;
            this.btnDiscard.Click += new System.EventHandler(this.btnDiscard_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(427, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 15);
            this.label2.TabIndex = 124;
            this.label2.Text = "SALES PERSON:";
            // 
            // cmbSalesPerson
            // 
            this.cmbSalesPerson.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSalesPerson.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSalesPerson.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbSalesPerson.FormattingEnabled = true;
            this.cmbSalesPerson.Items.AddRange(new object[] {
            "--SELECT SUPPLIER--",
            "AUTOMART"});
            this.cmbSalesPerson.Location = new System.Drawing.Point(525, 51);
            this.cmbSalesPerson.Name = "cmbSalesPerson";
            this.cmbSalesPerson.Size = new System.Drawing.Size(187, 25);
            this.cmbSalesPerson.TabIndex = 227;
            // 
            // frm_SalesOrderApproval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(994, 483);
            this.Controls.Add(this.btnDiscard);
            this.Controls.Add(this.grdSOList);
            this.Controls.Add(this.grpCASHBOOK);
            this.Controls.Add(this.pnlHEADER);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1010, 522);
            this.Name = "frm_SalesOrderApproval";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SALES ORDER REPORT";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_Account_Ledger_FormClosed);
            this.Load += new System.EventHandler(this.frm_Account_Ledger_Load);
            this.pnlHEADER.ResumeLayout(false);
            this.pnlHEADER.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
            this.grpCASHBOOK.ResumeLayout(false);
            this.grpCASHBOOK.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSOList)).EndInit();
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
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton rdbAll;
        private System.Windows.Forms.DataGridView grdSOList;
        private System.Windows.Forms.Button btnShowReport;
        private System.Windows.Forms.Button btnDiscard;
        private System.Windows.Forms.Label label1;
        private SergeUtils.EasyCompletionComboBox cmbCustomer;
        private System.Windows.Forms.DataGridViewCheckBoxColumn discard;
        private System.Windows.Forms.DataGridViewTextBoxColumn soID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PO_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUSTOMER;
        private System.Windows.Forms.DataGridViewTextBoxColumn MATERIAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn SO_WEIGHT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DELIVERED_WEIGHT;
        private System.Windows.Forms.DataGridViewTextBoxColumn BALANCE;
        private System.Windows.Forms.DataGridViewTextBoxColumn RATE_KG;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESCRIPTION;
        private System.Windows.Forms.DataGridViewTextBoxColumn CREDIT_DAYS;
        private System.Windows.Forms.DataGridViewTextBoxColumn TYPE;
        private SergeUtils.EasyCompletionComboBox cmbSalesPerson;
        private System.Windows.Forms.Label label2;
    }
}