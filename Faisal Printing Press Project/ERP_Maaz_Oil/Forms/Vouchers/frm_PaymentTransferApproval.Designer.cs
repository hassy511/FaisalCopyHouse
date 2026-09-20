namespace ERP_Maaz_Oil.Forms.Vouchers
{
    partial class frm_PaymentTransferApproval
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_PaymentTransferApproval));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grpCASHBOOK = new System.Windows.Forms.GroupBox();
            this.cmbBank = new SergeUtils.EasyCompletionComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbSubAccount = new SergeUtils.EasyCompletionComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbRefAc = new SergeUtils.EasyCompletionComboBox();
            this.lblRefAc = new System.Windows.Forms.Label();
            this.cmbPayAccount = new SergeUtils.EasyCompletionComboBox();
            this.lblPayAccount = new System.Windows.Forms.Label();
            this.cmbSalesPerson = new SergeUtils.EasyCompletionComboBox();
            this.lblSalesPerson = new System.Windows.Forms.Label();
            this.btnShowReport = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.rdbPending = new System.Windows.Forms.RadioButton();
            this.rdbAll = new System.Windows.Forms.RadioButton();
            this.dtp_TO = new System.Windows.Forms.DateTimePicker();
            this.dtp_FROM = new System.Windows.Forms.DateTimePicker();
            this.lblFROM = new System.Windows.Forms.Label();
            this.btnSHOW = new System.Windows.Forms.Button();
            this.lblITO = new System.Windows.Forms.Label();
            this.grdEntries = new System.Windows.Forms.DataGridView();
            this.select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ptID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.voucherNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recaccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SUBACCOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bankName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.brCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.instrumentNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.conformationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.person = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.narration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salesPerson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.pnlHEADER = new System.Windows.Forms.Panel();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.lblHEADING = new System.Windows.Forms.Label();
            this.txtTotalPending = new System.Windows.Forms.TextBox();
            this.lblTotalPending = new System.Windows.Forms.Label();
            this.txtTotalApproved = new System.Windows.Forms.TextBox();
            this.lblTotalApproved = new System.Windows.Forms.Label();
            this.dtpConformationDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.rdbEntryDate = new System.Windows.Forms.RadioButton();
            this.rdbConformation = new System.Windows.Forms.RadioButton();
            this.cmbPerson = new SergeUtils.EasyCompletionComboBox();
            this.lblSSalePerson = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbRecAccount = new SergeUtils.EasyCompletionComboBox();
            this.grpCASHBOOK.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEntries)).BeginInit();
            this.pnlHEADER.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
            this.SuspendLayout();
            // 
            // grpCASHBOOK
            // 
            this.grpCASHBOOK.Controls.Add(this.cmbBank);
            this.grpCASHBOOK.Controls.Add(this.label3);
            this.grpCASHBOOK.Controls.Add(this.cmbSubAccount);
            this.grpCASHBOOK.Controls.Add(this.label2);
            this.grpCASHBOOK.Controls.Add(this.cmbRefAc);
            this.grpCASHBOOK.Controls.Add(this.lblRefAc);
            this.grpCASHBOOK.Controls.Add(this.cmbRecAccount);
            this.grpCASHBOOK.Controls.Add(this.label4);
            this.grpCASHBOOK.Controls.Add(this.cmbPayAccount);
            this.grpCASHBOOK.Controls.Add(this.lblPayAccount);
            this.grpCASHBOOK.Controls.Add(this.cmbSalesPerson);
            this.grpCASHBOOK.Controls.Add(this.lblSalesPerson);
            this.grpCASHBOOK.Controls.Add(this.btnShowReport);
            this.grpCASHBOOK.Controls.Add(this.rdbPending);
            this.grpCASHBOOK.Controls.Add(this.rdbAll);
            this.grpCASHBOOK.Controls.Add(this.dtp_TO);
            this.grpCASHBOOK.Controls.Add(this.dtp_FROM);
            this.grpCASHBOOK.Controls.Add(this.lblFROM);
            this.grpCASHBOOK.Controls.Add(this.btnSHOW);
            this.grpCASHBOOK.Controls.Add(this.lblITO);
            this.grpCASHBOOK.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpCASHBOOK.Location = new System.Drawing.Point(0, 70);
            this.grpCASHBOOK.Name = "grpCASHBOOK";
            this.grpCASHBOOK.Size = new System.Drawing.Size(994, 115);
            this.grpCASHBOOK.TabIndex = 37;
            this.grpCASHBOOK.TabStop = false;
            this.grpCASHBOOK.Text = "PAYMENT TRANSFER REPORT";
            this.grpCASHBOOK.Enter += new System.EventHandler(this.grpSALES_Enter);
            // 
            // cmbBank
            // 
            this.cmbBank.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbBank.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBank.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbBank.FormattingEnabled = true;
            this.cmbBank.Items.AddRange(new object[] {
            "--SELECT INVOICE--"});
            this.cmbBank.Location = new System.Drawing.Point(255, 84);
            this.cmbBank.Name = "cmbBank";
            this.cmbBank.Size = new System.Drawing.Size(136, 25);
            this.cmbBank.TabIndex = 353;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(203, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 352;
            this.label3.Text = "BANK:";
            // 
            // cmbSubAccount
            // 
            this.cmbSubAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSubAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSubAccount.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbSubAccount.FormattingEnabled = true;
            this.cmbSubAccount.Items.AddRange(new object[] {
            "--SELECT INVOICE--"});
            this.cmbSubAccount.Location = new System.Drawing.Point(495, 83);
            this.cmbSubAccount.Name = "cmbSubAccount";
            this.cmbSubAccount.Size = new System.Drawing.Size(188, 25);
            this.cmbSubAccount.TabIndex = 353;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(397, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 352;
            this.label2.Text = "SUB ACC:";
            // 
            // cmbRefAc
            // 
            this.cmbRefAc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbRefAc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRefAc.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbRefAc.FormattingEnabled = true;
            this.cmbRefAc.Location = new System.Drawing.Point(785, 48);
            this.cmbRefAc.Name = "cmbRefAc";
            this.cmbRefAc.Size = new System.Drawing.Size(203, 25);
            this.cmbRefAc.TabIndex = 129;
            // 
            // lblRefAc
            // 
            this.lblRefAc.AutoSize = true;
            this.lblRefAc.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblRefAc.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblRefAc.Location = new System.Drawing.Point(717, 53);
            this.lblRefAc.Name = "lblRefAc";
            this.lblRefAc.Size = new System.Drawing.Size(47, 15);
            this.lblRefAc.TabIndex = 128;
            this.lblRefAc.Text = "REF AC:";
            // 
            // cmbPayAccount
            // 
            this.cmbPayAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbPayAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPayAccount.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbPayAccount.FormattingEnabled = true;
            this.cmbPayAccount.Location = new System.Drawing.Point(785, 17);
            this.cmbPayAccount.Name = "cmbPayAccount";
            this.cmbPayAccount.Size = new System.Drawing.Size(203, 25);
            this.cmbPayAccount.TabIndex = 127;
            // 
            // lblPayAccount
            // 
            this.lblPayAccount.AutoSize = true;
            this.lblPayAccount.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblPayAccount.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPayAccount.Location = new System.Drawing.Point(689, 22);
            this.lblPayAccount.Name = "lblPayAccount";
            this.lblPayAccount.Size = new System.Drawing.Size(90, 15);
            this.lblPayAccount.TabIndex = 126;
            this.lblPayAccount.Text = "PAY ACCOUNT:";
            // 
            // cmbSalesPerson
            // 
            this.cmbSalesPerson.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSalesPerson.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSalesPerson.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbSalesPerson.FormattingEnabled = true;
            this.cmbSalesPerson.Location = new System.Drawing.Point(495, 22);
            this.cmbSalesPerson.Name = "cmbSalesPerson";
            this.cmbSalesPerson.Size = new System.Drawing.Size(188, 25);
            this.cmbSalesPerson.TabIndex = 125;
            // 
            // lblSalesPerson
            // 
            this.lblSalesPerson.AutoSize = true;
            this.lblSalesPerson.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblSalesPerson.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSalesPerson.Location = new System.Drawing.Point(397, 27);
            this.lblSalesPerson.Name = "lblSalesPerson";
            this.lblSalesPerson.Size = new System.Drawing.Size(92, 15);
            this.lblSalesPerson.TabIndex = 124;
            this.lblSalesPerson.Text = "SALES PERSON:";
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
            this.btnShowReport.Location = new System.Drawing.Point(864, 82);
            this.btnShowReport.Name = "btnShowReport";
            this.btnShowReport.Size = new System.Drawing.Size(130, 25);
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
            // rdbPending
            // 
            this.rdbPending.AutoSize = true;
            this.rdbPending.Location = new System.Drawing.Point(12, 55);
            this.rdbPending.Name = "rdbPending";
            this.rdbPending.Size = new System.Drawing.Size(181, 21);
            this.rdbPending.TabIndex = 122;
            this.rdbPending.Text = "SHOW PENDING ENTRIES";
            this.rdbPending.UseVisualStyleBackColor = true;
            // 
            // rdbAll
            // 
            this.rdbAll.AutoSize = true;
            this.rdbAll.Checked = true;
            this.rdbAll.Location = new System.Drawing.Point(12, 24);
            this.rdbAll.Name = "rdbAll";
            this.rdbAll.Size = new System.Drawing.Size(145, 21);
            this.rdbAll.TabIndex = 121;
            this.rdbAll.TabStop = true;
            this.rdbAll.Text = "SHOW ALL ENTRIES";
            this.rdbAll.UseVisualStyleBackColor = true;
            // 
            // dtp_TO
            // 
            this.dtp_TO.CustomFormat = "dd/MM/yyyy";
            this.dtp_TO.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.dtp_TO.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_TO.Location = new System.Drawing.Point(255, 54);
            this.dtp_TO.Name = "dtp_TO";
            this.dtp_TO.Size = new System.Drawing.Size(136, 23);
            this.dtp_TO.TabIndex = 120;
            // 
            // dtp_FROM
            // 
            this.dtp_FROM.CustomFormat = "dd/MM/yyyy";
            this.dtp_FROM.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.dtp_FROM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_FROM.Location = new System.Drawing.Point(255, 23);
            this.dtp_FROM.Name = "dtp_FROM";
            this.dtp_FROM.Size = new System.Drawing.Size(136, 23);
            this.dtp_FROM.TabIndex = 119;
            // 
            // lblFROM
            // 
            this.lblFROM.AutoSize = true;
            this.lblFROM.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblFROM.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblFROM.Location = new System.Drawing.Point(206, 27);
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
            this.btnSHOW.Location = new System.Drawing.Point(738, 82);
            this.btnSHOW.Name = "btnSHOW";
            this.btnSHOW.Size = new System.Drawing.Size(120, 25);
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
            this.lblITO.Location = new System.Drawing.Point(206, 58);
            this.lblITO.Name = "lblITO";
            this.lblITO.Size = new System.Drawing.Size(26, 15);
            this.lblITO.TabIndex = 46;
            this.lblITO.Text = "TO:";
            // 
            // grdEntries
            // 
            this.grdEntries.AllowUserToAddRows = false;
            this.grdEntries.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.grdEntries.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdEntries.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdEntries.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grdEntries.BackgroundColor = System.Drawing.Color.White;
            this.grdEntries.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdEntries.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdEntries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdEntries.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.select,
            this.ptID,
            this.DATE,
            this.voucherNo,
            this.recaccount,
            this.SUBACCOUNT,
            this.amount,
            this.bankName,
            this.brCode,
            this.instrumentNo,
            this.payAccount,
            this.refAccount,
            this.status,
            this.conformationDate,
            this.person,
            this.narration,
            this.salesPerson,
            this.recId,
            this.payId});
            this.grdEntries.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdEntries.DefaultCellStyle = dataGridViewCellStyle3;
            this.grdEntries.Location = new System.Drawing.Point(0, 233);
            this.grdEntries.Name = "grdEntries";
            this.grdEntries.RowHeadersVisible = false;
            this.grdEntries.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdEntries.Size = new System.Drawing.Size(996, 227);
            this.grdEntries.TabIndex = 222;
            this.grdEntries.TabStop = false;
            this.grdEntries.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdPOList_CellClick);
            this.grdEntries.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdEntries_CellValueChanged);
            this.grdEntries.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.grdEntries_ColumnWidthChanged);
            this.grdEntries.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.grdPOList_DataBindingComplete);
            this.grdEntries.Scroll += new System.Windows.Forms.ScrollEventHandler(this.grdEntries_Scroll);
            // 
            // select
            // 
            this.select.HeaderText = "SELECT";
            this.select.Name = "select";
            // 
            // ptID
            // 
            this.ptID.HeaderText = "PT ID";
            this.ptID.Name = "ptID";
            this.ptID.Visible = false;
            // 
            // DATE
            // 
            this.DATE.HeaderText = "DATE";
            this.DATE.Name = "DATE";
            // 
            // voucherNo
            // 
            this.voucherNo.HeaderText = "VOUCHER #";
            this.voucherNo.Name = "voucherNo";
            this.voucherNo.Visible = false;
            // 
            // recaccount
            // 
            this.recaccount.HeaderText = "REC ACCOUNT";
            this.recaccount.Name = "recaccount";
            // 
            // SUBACCOUNT
            // 
            this.SUBACCOUNT.HeaderText = "SUB ACCOUNT";
            this.SUBACCOUNT.Name = "SUBACCOUNT";
            // 
            // amount
            // 
            this.amount.HeaderText = "AMOUNT";
            this.amount.Name = "amount";
            // 
            // bankName
            // 
            this.bankName.HeaderText = "BANK";
            this.bankName.Name = "bankName";
            // 
            // brCode
            // 
            this.brCode.HeaderText = "BR CODE";
            this.brCode.Name = "brCode";
            // 
            // instrumentNo
            // 
            this.instrumentNo.HeaderText = "INSTRUMENT #";
            this.instrumentNo.Name = "instrumentNo";
            // 
            // payAccount
            // 
            this.payAccount.HeaderText = "PAY ACCOUNT";
            this.payAccount.Name = "payAccount";
            // 
            // refAccount
            // 
            this.refAccount.HeaderText = "REF ACCOUNT";
            this.refAccount.Name = "refAccount";
            // 
            // status
            // 
            this.status.HeaderText = "STATUS";
            this.status.Items.AddRange(new object[] {
            "PENDING",
            "APPROVED"});
            this.status.Name = "status";
            this.status.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // conformationDate
            // 
            this.conformationDate.HeaderText = "CONFORMATION DATE";
            this.conformationDate.Name = "conformationDate";
            this.conformationDate.ReadOnly = true;
            // 
            // person
            // 
            this.person.HeaderText = "PERSON";
            this.person.Name = "person";
            // 
            // narration
            // 
            this.narration.HeaderText = "NARRATION";
            this.narration.Name = "narration";
            // 
            // salesPerson
            // 
            this.salesPerson.HeaderText = "SALES PERSON";
            this.salesPerson.Name = "salesPerson";
            this.salesPerson.ReadOnly = true;
            this.salesPerson.Visible = false;
            // 
            // recId
            // 
            this.recId.HeaderText = "recId";
            this.recId.Name = "recId";
            this.recId.ReadOnly = true;
            this.recId.Visible = false;
            // 
            // payId
            // 
            this.payId.HeaderText = "payId";
            this.payId.Name = "payId";
            this.payId.ReadOnly = true;
            this.payId.Visible = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(68)))), ((int)(((byte)(2)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.ImageIndex = 5;
            this.btnUpdate.ImageList = this.imageList1;
            this.btnUpdate.Location = new System.Drawing.Point(6, 466);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(129, 25);
            this.btnUpdate.TabIndex = 124;
            this.btnUpdate.Text = "UPDATE";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnDiscard_Click);
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
            this.pnlHEADER.Size = new System.Drawing.Size(995, 66);
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
            this.lblHEADING.Size = new System.Drawing.Size(153, 34);
            this.lblHEADING.TabIndex = 23;
            this.lblHEADING.Text = "PAYMENT TRANSFER \r\nREPORT";
            // 
            // txtTotalPending
            // 
            this.txtTotalPending.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotalPending.Enabled = false;
            this.txtTotalPending.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtTotalPending.Location = new System.Drawing.Point(580, 466);
            this.txtTotalPending.MaxLength = 11;
            this.txtTotalPending.Name = "txtTotalPending";
            this.txtTotalPending.ReadOnly = true;
            this.txtTotalPending.Size = new System.Drawing.Size(144, 25);
            this.txtTotalPending.TabIndex = 332;
            this.txtTotalPending.Text = "0";
            // 
            // lblTotalPending
            // 
            this.lblTotalPending.AutoSize = true;
            this.lblTotalPending.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblTotalPending.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTotalPending.Location = new System.Drawing.Point(477, 471);
            this.lblTotalPending.Name = "lblTotalPending";
            this.lblTotalPending.Size = new System.Drawing.Size(98, 15);
            this.lblTotalPending.TabIndex = 333;
            this.lblTotalPending.Text = "TOTAL PENDING";
            // 
            // txtTotalApproved
            // 
            this.txtTotalApproved.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotalApproved.Enabled = false;
            this.txtTotalApproved.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtTotalApproved.Location = new System.Drawing.Point(844, 466);
            this.txtTotalApproved.MaxLength = 11;
            this.txtTotalApproved.Name = "txtTotalApproved";
            this.txtTotalApproved.ReadOnly = true;
            this.txtTotalApproved.Size = new System.Drawing.Size(144, 25);
            this.txtTotalApproved.TabIndex = 334;
            this.txtTotalApproved.Text = "0";
            // 
            // lblTotalApproved
            // 
            this.lblTotalApproved.AutoSize = true;
            this.lblTotalApproved.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblTotalApproved.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTotalApproved.Location = new System.Drawing.Point(732, 471);
            this.lblTotalApproved.Name = "lblTotalApproved";
            this.lblTotalApproved.Size = new System.Drawing.Size(108, 15);
            this.lblTotalApproved.TabIndex = 335;
            this.lblTotalApproved.Text = "TOTAL APPROVED";
            // 
            // dtpConformationDate
            // 
            this.dtpConformationDate.CustomFormat = "dd/MM/yyyy";
            this.dtpConformationDate.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.dtpConformationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpConformationDate.Location = new System.Drawing.Point(154, 204);
            this.dtpConformationDate.Name = "dtpConformationDate";
            this.dtpConformationDate.Size = new System.Drawing.Size(183, 23);
            this.dtpConformationDate.TabIndex = 131;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(12, 208);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 15);
            this.label1.TabIndex = 130;
            this.label1.Text = "CONFORMATION DATE:";
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(68)))), ((int)(((byte)(2)))));
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnApply.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnApply.ForeColor = System.Drawing.Color.White;
            this.btnApply.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnApply.ImageIndex = 5;
            this.btnApply.ImageList = this.imageList1;
            this.btnApply.Location = new System.Drawing.Point(622, 203);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(92, 25);
            this.btnApply.TabIndex = 130;
            this.btnApply.Text = "APPLY";
            this.btnApply.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // rdbEntryDate
            // 
            this.rdbEntryDate.AutoSize = true;
            this.rdbEntryDate.Checked = true;
            this.rdbEntryDate.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.rdbEntryDate.Location = new System.Drawing.Point(720, 205);
            this.rdbEntryDate.Name = "rdbEntryDate";
            this.rdbEntryDate.Size = new System.Drawing.Size(102, 21);
            this.rdbEntryDate.TabIndex = 130;
            this.rdbEntryDate.TabStop = true;
            this.rdbEntryDate.Text = "ENTRY DATE";
            this.rdbEntryDate.UseVisualStyleBackColor = true;
            // 
            // rdbConformation
            // 
            this.rdbConformation.AutoSize = true;
            this.rdbConformation.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.rdbConformation.Location = new System.Drawing.Point(826, 205);
            this.rdbConformation.Name = "rdbConformation";
            this.rdbConformation.Size = new System.Drawing.Size(167, 21);
            this.rdbConformation.TabIndex = 336;
            this.rdbConformation.Text = "CONFORMATION DATE";
            this.rdbConformation.UseVisualStyleBackColor = true;
            // 
            // cmbPerson
            // 
            this.cmbPerson.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbPerson.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPerson.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbPerson.FormattingEnabled = true;
            this.cmbPerson.Location = new System.Drawing.Point(440, 203);
            this.cmbPerson.Name = "cmbPerson";
            this.cmbPerson.Size = new System.Drawing.Size(176, 25);
            this.cmbPerson.TabIndex = 131;
            // 
            // lblSSalePerson
            // 
            this.lblSSalePerson.AutoSize = true;
            this.lblSSalePerson.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblSSalePerson.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSSalePerson.Location = new System.Drawing.Point(379, 208);
            this.lblSSalePerson.Name = "lblSSalePerson";
            this.lblSSalePerson.Size = new System.Drawing.Size(55, 15);
            this.lblSSalePerson.TabIndex = 130;
            this.lblSSalePerson.Text = "PERSON:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(399, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 15);
            this.label4.TabIndex = 126;
            this.label4.Text = "REC ACCOUNT:";
            // 
            // cmbRecAccount
            // 
            this.cmbRecAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbRecAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRecAccount.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbRecAccount.FormattingEnabled = true;
            this.cmbRecAccount.Location = new System.Drawing.Point(495, 53);
            this.cmbRecAccount.Name = "cmbRecAccount";
            this.cmbRecAccount.Size = new System.Drawing.Size(188, 25);
            this.cmbRecAccount.TabIndex = 127;
            // 
            // frm_PaymentTransferApproval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(995, 509);
            this.Controls.Add(this.cmbPerson);
            this.Controls.Add(this.lblSSalePerson);
            this.Controls.Add(this.rdbConformation);
            this.Controls.Add(this.rdbEntryDate);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.dtpConformationDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTotalApproved);
            this.Controls.Add(this.lblTotalApproved);
            this.Controls.Add(this.txtTotalPending);
            this.Controls.Add(this.lblTotalPending);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.grdEntries);
            this.Controls.Add(this.grpCASHBOOK);
            this.Controls.Add(this.pnlHEADER);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_PaymentTransferApproval";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PAYMENT TRANSFER REPORT";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_Account_Ledger_FormClosed);
            this.Load += new System.EventHandler(this.frm_Account_Ledger_Load);
            this.grpCASHBOOK.ResumeLayout(false);
            this.grpCASHBOOK.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEntries)).EndInit();
            this.pnlHEADER.ResumeLayout(false);
            this.pnlHEADER.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.RadioButton rdbPending;
        private System.Windows.Forms.RadioButton rdbAll;
        private System.Windows.Forms.DataGridView grdEntries;
        private System.Windows.Forms.Button btnShowReport;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label lblSalesPerson;
        private SergeUtils.EasyCompletionComboBox cmbSalesPerson;
        private SergeUtils.EasyCompletionComboBox cmbPayAccount;
        private System.Windows.Forms.Label lblPayAccount;
        private SergeUtils.EasyCompletionComboBox cmbRefAc;
        private System.Windows.Forms.Label lblRefAc;
        private System.Windows.Forms.TextBox txtTotalPending;
        private System.Windows.Forms.Label lblTotalPending;
        private System.Windows.Forms.TextBox txtTotalApproved;
        private System.Windows.Forms.Label lblTotalApproved;
        private System.Windows.Forms.DateTimePicker dtpConformationDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.RadioButton rdbEntryDate;
        private System.Windows.Forms.RadioButton rdbConformation;
        private SergeUtils.EasyCompletionComboBox cmbPerson;
        private System.Windows.Forms.Label lblSSalePerson;
        private SergeUtils.EasyCompletionComboBox cmbSubAccount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn select;
        private System.Windows.Forms.DataGridViewTextBoxColumn ptID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn voucherNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn recaccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn SUBACCOUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankName;
        private System.Windows.Forms.DataGridViewTextBoxColumn brCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn instrumentNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn payAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn refAccount;
        private System.Windows.Forms.DataGridViewComboBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn conformationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn person;
        private System.Windows.Forms.DataGridViewTextBoxColumn narration;
        private System.Windows.Forms.DataGridViewTextBoxColumn salesPerson;
        private System.Windows.Forms.DataGridViewTextBoxColumn recId;
        private System.Windows.Forms.DataGridViewTextBoxColumn payId;
        private SergeUtils.EasyCompletionComboBox cmbBank;
        private System.Windows.Forms.Label label3;
        private SergeUtils.EasyCompletionComboBox cmbRecAccount;
        private System.Windows.Forms.Label label4;
    }
}