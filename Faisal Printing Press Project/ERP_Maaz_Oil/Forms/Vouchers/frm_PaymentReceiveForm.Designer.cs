namespace ERP_Maaz_Oil.Forms
{
    partial class frm_PaymentReceiveForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_PaymentReceiveForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmbReceivingAccount = new SergeUtils.EasyCompletionComboBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblCode = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblAcc = new System.Windows.Forms.Label();
            this.lblPaid = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblV = new System.Windows.Forms.Label();
            this.grdSearch = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSEARCH = new System.Windows.Forms.Label();
            this.btnSAVE = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlHEADER = new System.Windows.Forms.Panel();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.lblHEADING = new System.Windows.Forms.Label();
            this.rdbPayment = new System.Windows.Forms.RadioButton();
            this.rdbReceiving = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAmountWords = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTotalPaid = new System.Windows.Forms.TextBox();
            this.txtTotalReceiving = new System.Windows.Forms.TextBox();
            this.txtTotalBalanceAmount = new System.Windows.Forms.TextBox();
            this.btnCLEAR = new System.Windows.Forms.Button();
            this.btnVoucher = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.pnlPaymentType = new System.Windows.Forms.Panel();
            this.rdbCash = new System.Windows.Forms.RadioButton();
            this.rdbBank = new System.Windows.Forms.RadioButton();
            this.rdbExpense = new System.Windows.Forms.RadioButton();
            this.rdbOther = new System.Windows.Forms.RadioButton();
            this.cmbPaymentAccount = new SergeUtils.EasyCompletionComboBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlHEADER.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            this.pnlPaymentType.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbReceivingAccount
            // 
            this.cmbReceivingAccount.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbReceivingAccount.FormattingEnabled = true;
            this.cmbReceivingAccount.Location = new System.Drawing.Point(130, 194);
            this.cmbReceivingAccount.Name = "cmbReceivingAccount";
            this.cmbReceivingAccount.Size = new System.Drawing.Size(246, 25);
            this.cmbReceivingAccount.TabIndex = 3;
            this.cmbReceivingAccount.DropDown += new System.EventHandler(this.cmbPay_DropDown);
            this.cmbReceivingAccount.SelectedIndexChanged += new System.EventHandler(this.cmbAccounts_SelectedIndexChanged);
            this.cmbReceivingAccount.TextUpdate += new System.EventHandler(this.cmbPay_TextUpdate);
            this.cmbReceivingAccount.Leave += new System.EventHandler(this.cmbAccounts_Leave);
            this.cmbReceivingAccount.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmbPay_PreviewKeyDown);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icons8-Save as Filled-100.png");
            this.imageList1.Images.SetKeyName(1, "icons8-Cancel Filled-100.png");
            this.imageList1.Images.SetKeyName(2, "icons8-search.png");
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.dtpDate.Location = new System.Drawing.Point(130, 166);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(246, 23);
            this.dtpDate.TabIndex = 1;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtp_DATE_ValueChanged);
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(215)))));
            this.lblCode.Location = new System.Drawing.Point(127, 144);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(60, 15);
            this.lblCode.TabIndex = 0;
            this.lblCode.Text = "JV-1-2017";
            // 
            // txtDescription
            // 
            this.txtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtDescription.Location = new System.Drawing.Point(130, 256);
            this.txtDescription.MaxLength = 100;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(246, 115);
            this.txtDescription.TabIndex = 4;
            this.txtDescription.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtAmount_MouseClick);
            this.txtDescription.Enter += new System.EventHandler(this.txtAmount_Enter);
            this.txtDescription.Leave += new System.EventHandler(this.txtPay_Leave);
            // 
            // lblAcc
            // 
            this.lblAcc.AutoSize = true;
            this.lblAcc.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblAcc.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblAcc.Location = new System.Drawing.Point(10, 271);
            this.lblAcc.Name = "lblAcc";
            this.lblAcc.Size = new System.Drawing.Size(86, 15);
            this.lblAcc.TabIndex = 266;
            this.lblAcc.Text = "DESCRIPTION:";
            // 
            // lblPaid
            // 
            this.lblPaid.AutoSize = true;
            this.lblPaid.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblPaid.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPaid.Location = new System.Drawing.Point(10, 199);
            this.lblPaid.Name = "lblPaid";
            this.lblPaid.Size = new System.Drawing.Size(87, 15);
            this.lblPaid.TabIndex = 261;
            this.lblPaid.Text = "RECEIVING AC:";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblDate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDate.Location = new System.Drawing.Point(10, 170);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(39, 15);
            this.lblDate.TabIndex = 260;
            this.lblDate.Text = "DATE:";
            // 
            // lblV
            // 
            this.lblV.AutoSize = true;
            this.lblV.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblV.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblV.Location = new System.Drawing.Point(10, 144);
            this.lblV.Name = "lblV";
            this.lblV.Size = new System.Drawing.Size(74, 15);
            this.lblV.TabIndex = 259;
            this.lblV.Text = "VOUCHER #:";
            // 
            // grdSearch
            // 
            this.grdSearch.AllowUserToAddRows = false;
            this.grdSearch.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.grdSearch.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdSearch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdSearch.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grdSearch.BackgroundColor = System.Drawing.Color.White;
            this.grdSearch.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdSearch.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdSearch.DefaultCellStyle = dataGridViewCellStyle3;
            this.grdSearch.Location = new System.Drawing.Point(398, 93);
            this.grdSearch.Name = "grdSearch";
            this.grdSearch.ReadOnly = true;
            this.grdSearch.RowHeadersVisible = false;
            this.grdSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSearch.Size = new System.Drawing.Size(662, 371);
            this.grdSearch.TabIndex = 10;
            this.grdSearch.TabStop = false;
            this.grdSearch.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdSEARCH_CellClick);
            this.grdSearch.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdSearch_CellContentClick);
            this.grdSearch.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.grdSEARCH_DataBindingComplete);
            // 
            // txtSearch
            // 
            this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtSearch.Location = new System.Drawing.Point(458, 62);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(602, 25);
            this.txtSearch.TabIndex = 13;
            this.txtSearch.TabStop = false;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSEARCH_TextChanged);
            // 
            // lblSEARCH
            // 
            this.lblSEARCH.AutoSize = true;
            this.lblSEARCH.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSEARCH.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSEARCH.Location = new System.Drawing.Point(395, 67);
            this.lblSEARCH.Name = "lblSEARCH";
            this.lblSEARCH.Size = new System.Drawing.Size(57, 17);
            this.lblSEARCH.TabIndex = 256;
            this.lblSEARCH.Text = "SEARCH";
            // 
            // btnSAVE
            // 
            this.btnSAVE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(215)))));
            this.btnSAVE.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSAVE.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSAVE.ForeColor = System.Drawing.Color.White;
            this.btnSAVE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSAVE.ImageIndex = 0;
            this.btnSAVE.ImageList = this.imageList1;
            this.btnSAVE.Location = new System.Drawing.Point(128, 439);
            this.btnSAVE.Name = "btnSAVE";
            this.btnSAVE.Size = new System.Drawing.Size(122, 25);
            this.btnSAVE.TabIndex = 7;
            this.btnSAVE.Text = "SAVE";
            this.btnSAVE.UseVisualStyleBackColor = false;
            this.btnSAVE.Click += new System.EventHandler(this.btnSAVE_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::ERP_Maaz_Oil.Properties.Resources.plus;
            this.pictureBox1.Location = new System.Drawing.Point(1431, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(52, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 255;
            this.pictureBox1.TabStop = false;
            // 
            // pnlHEADER
            // 
            this.pnlHEADER.BackColor = System.Drawing.Color.Transparent;
            this.pnlHEADER.BackgroundImage = global::ERP_Maaz_Oil.Properties.Resources.header;
            this.pnlHEADER.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlHEADER.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHEADER.Controls.Add(this.pictureBox15);
            this.pnlHEADER.Controls.Add(this.lblHEADING);
            this.pnlHEADER.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHEADER.Location = new System.Drawing.Point(0, 0);
            this.pnlHEADER.Name = "pnlHEADER";
            this.pnlHEADER.Size = new System.Drawing.Size(1076, 56);
            this.pnlHEADER.TabIndex = 38;
            // 
            // pictureBox15
            // 
            this.pictureBox15.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox15.Image = global::ERP_Maaz_Oil.Properties.Resources.plus;
            this.pictureBox15.Location = new System.Drawing.Point(1430, 3);
            this.pictureBox15.Name = "pictureBox15";
            this.pictureBox15.Size = new System.Drawing.Size(52, 20);
            this.pictureBox15.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox15.TabIndex = 25;
            this.pictureBox15.TabStop = false;
            // 
            // lblHEADING
            // 
            this.lblHEADING.AutoSize = true;
            this.lblHEADING.BackColor = System.Drawing.Color.Transparent;
            this.lblHEADING.Font = new System.Drawing.Font("Berlin Sans FB", 15.75F);
            this.lblHEADING.ForeColor = System.Drawing.Color.White;
            this.lblHEADING.Location = new System.Drawing.Point(6, 18);
            this.lblHEADING.Name = "lblHEADING";
            this.lblHEADING.Size = new System.Drawing.Size(102, 23);
            this.lblHEADING.TabIndex = 23;
            this.lblHEADING.Text = "VOUCHER";
            // 
            // rdbPayment
            // 
            this.rdbPayment.AutoSize = true;
            this.rdbPayment.Font = new System.Drawing.Font("Segoe UI", 8.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.rdbPayment.Location = new System.Drawing.Point(115, 64);
            this.rdbPayment.Margin = new System.Windows.Forms.Padding(2);
            this.rdbPayment.Name = "rdbPayment";
            this.rdbPayment.Size = new System.Drawing.Size(78, 19);
            this.rdbPayment.TabIndex = 280;
            this.rdbPayment.Text = "PAYMENT";
            this.rdbPayment.UseVisualStyleBackColor = true;
            // 
            // rdbReceiving
            // 
            this.rdbReceiving.AutoSize = true;
            this.rdbReceiving.Checked = true;
            this.rdbReceiving.Font = new System.Drawing.Font("Segoe UI", 8.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.rdbReceiving.Location = new System.Drawing.Point(21, 64);
            this.rdbReceiving.Margin = new System.Windows.Forms.Padding(2);
            this.rdbReceiving.Name = "rdbReceiving";
            this.rdbReceiving.Size = new System.Drawing.Size(86, 19);
            this.rdbReceiving.TabIndex = 280;
            this.rdbReceiving.TabStop = true;
            this.rdbReceiving.Text = "RECEIVING";
            this.rdbReceiving.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(10, 381);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 264;
            this.label1.Text = "AMOUNT:";
            // 
            // txtAmount
            // 
            this.txtAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAmount.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtAmount.Location = new System.Drawing.Point(130, 377);
            this.txtAmount.MaxLength = 10;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(246, 25);
            this.txtAmount.TabIndex = 5;
            this.txtAmount.Text = "0.0";
            this.txtAmount.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtAmount_MouseClick);
            this.txtAmount.TextChanged += new System.EventHandler(this.amountTxtChanged);
            this.txtAmount.Enter += new System.EventHandler(this.txtAmount_Enter);
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            this.txtAmount.Leave += new System.EventHandler(this.txtAmount_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(10, 409);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 15);
            this.label3.TabIndex = 273;
            this.label3.Text = "AMOUNT (WORDS):";
            // 
            // txtAmountWords
            // 
            this.txtAmountWords.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAmountWords.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtAmountWords.Location = new System.Drawing.Point(130, 408);
            this.txtAmountWords.MaxLength = 50;
            this.txtAmountWords.Name = "txtAmountWords";
            this.txtAmountWords.ReadOnly = true;
            this.txtAmountWords.Size = new System.Drawing.Size(246, 25);
            this.txtAmountWords.TabIndex = 6;
            this.txtAmountWords.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtAmount_MouseClick);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.DimGray;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.ImageIndex = 1;
            this.btnDelete.ImageList = this.imageList1;
            this.btnDelete.Location = new System.Drawing.Point(127, 470);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(123, 25);
            this.btnDelete.TabIndex = 359;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Location = new System.Drawing.Point(398, 474);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 17);
            this.label10.TabIndex = 18;
            this.label10.Text = "RECEIVING TOTAL:";
            // 
            // txtTotalPaid
            // 
            this.txtTotalPaid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotalPaid.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtTotalPaid.Location = new System.Drawing.Point(770, 470);
            this.txtTotalPaid.Name = "txtTotalPaid";
            this.txtTotalPaid.ReadOnly = true;
            this.txtTotalPaid.Size = new System.Drawing.Size(117, 25);
            this.txtTotalPaid.TabIndex = 355;
            this.txtTotalPaid.TabStop = false;
            this.txtTotalPaid.Text = "0";
            this.txtTotalPaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalReceiving
            // 
            this.txtTotalReceiving.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotalReceiving.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtTotalReceiving.Location = new System.Drawing.Point(517, 470);
            this.txtTotalReceiving.Name = "txtTotalReceiving";
            this.txtTotalReceiving.ReadOnly = true;
            this.txtTotalReceiving.Size = new System.Drawing.Size(117, 25);
            this.txtTotalReceiving.TabIndex = 19;
            this.txtTotalReceiving.TabStop = false;
            this.txtTotalReceiving.Text = "0";
            this.txtTotalReceiving.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalBalanceAmount
            // 
            this.txtTotalBalanceAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotalBalanceAmount.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtTotalBalanceAmount.Location = new System.Drawing.Point(943, 470);
            this.txtTotalBalanceAmount.Name = "txtTotalBalanceAmount";
            this.txtTotalBalanceAmount.ReadOnly = true;
            this.txtTotalBalanceAmount.Size = new System.Drawing.Size(117, 25);
            this.txtTotalBalanceAmount.TabIndex = 35;
            this.txtTotalBalanceAmount.TabStop = false;
            this.txtTotalBalanceAmount.Text = "0";
            this.txtTotalBalanceAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnCLEAR
            // 
            this.btnCLEAR.BackColor = System.Drawing.Color.DimGray;
            this.btnCLEAR.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCLEAR.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnCLEAR.ForeColor = System.Drawing.Color.White;
            this.btnCLEAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCLEAR.ImageIndex = 1;
            this.btnCLEAR.ImageList = this.imageList1;
            this.btnCLEAR.Location = new System.Drawing.Point(250, 439);
            this.btnCLEAR.Name = "btnCLEAR";
            this.btnCLEAR.Size = new System.Drawing.Size(125, 25);
            this.btnCLEAR.TabIndex = 8;
            this.btnCLEAR.Text = "CLEAR";
            this.btnCLEAR.UseVisualStyleBackColor = false;
            this.btnCLEAR.Click += new System.EventHandler(this.btnCLEAR_Click);
            // 
            // btnVoucher
            // 
            this.btnVoucher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(24)))), ((int)(((byte)(38)))));
            this.btnVoucher.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVoucher.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnVoucher.ForeColor = System.Drawing.Color.White;
            this.btnVoucher.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVoucher.ImageIndex = 2;
            this.btnVoucher.ImageList = this.imageList1;
            this.btnVoucher.Location = new System.Drawing.Point(250, 470);
            this.btnVoucher.Name = "btnVoucher";
            this.btnVoucher.Size = new System.Drawing.Size(125, 25);
            this.btnVoucher.TabIndex = 9;
            this.btnVoucher.Text = "VOUCHER";
            this.btnVoucher.UseVisualStyleBackColor = false;
            this.btnVoucher.Click += new System.EventHandler(this.btnReceiptVoucher_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(654, 474);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 17);
            this.label2.TabIndex = 361;
            this.label2.Text = "PAYMENT TOTAL:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label12.Location = new System.Drawing.Point(902, 474);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 17);
            this.label12.TabIndex = 22;
            this.label12.Text = "NET:";
            // 
            // pnlPaymentType
            // 
            this.pnlPaymentType.Controls.Add(this.rdbOther);
            this.pnlPaymentType.Controls.Add(this.rdbExpense);
            this.pnlPaymentType.Controls.Add(this.rdbCash);
            this.pnlPaymentType.Controls.Add(this.rdbBank);
            this.pnlPaymentType.Location = new System.Drawing.Point(12, 94);
            this.pnlPaymentType.Name = "pnlPaymentType";
            this.pnlPaymentType.Size = new System.Drawing.Size(363, 36);
            this.pnlPaymentType.TabIndex = 362;
            // 
            // rdbCash
            // 
            this.rdbCash.AutoSize = true;
            this.rdbCash.Checked = true;
            this.rdbCash.Font = new System.Drawing.Font("Segoe UI", 8.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.rdbCash.Location = new System.Drawing.Point(9, 9);
            this.rdbCash.Margin = new System.Windows.Forms.Padding(2);
            this.rdbCash.Name = "rdbCash";
            this.rdbCash.Size = new System.Drawing.Size(56, 19);
            this.rdbCash.TabIndex = 363;
            this.rdbCash.TabStop = true;
            this.rdbCash.Text = "CASH";
            this.rdbCash.UseVisualStyleBackColor = true;
            // 
            // rdbBank
            // 
            this.rdbBank.AutoSize = true;
            this.rdbBank.Font = new System.Drawing.Font("Segoe UI", 8.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.rdbBank.Location = new System.Drawing.Point(103, 9);
            this.rdbBank.Margin = new System.Windows.Forms.Padding(2);
            this.rdbBank.Name = "rdbBank";
            this.rdbBank.Size = new System.Drawing.Size(58, 19);
            this.rdbBank.TabIndex = 364;
            this.rdbBank.Text = "BANK";
            this.rdbBank.UseVisualStyleBackColor = true;
            // 
            // rdbExpense
            // 
            this.rdbExpense.AutoSize = true;
            this.rdbExpense.Font = new System.Drawing.Font("Segoe UI", 8.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.rdbExpense.Location = new System.Drawing.Point(194, 9);
            this.rdbExpense.Margin = new System.Windows.Forms.Padding(2);
            this.rdbExpense.Name = "rdbExpense";
            this.rdbExpense.Size = new System.Drawing.Size(74, 19);
            this.rdbExpense.TabIndex = 365;
            this.rdbExpense.Text = "EXPENSE";
            this.rdbExpense.UseVisualStyleBackColor = true;
            // 
            // rdbOther
            // 
            this.rdbOther.AutoSize = true;
            this.rdbOther.Font = new System.Drawing.Font("Segoe UI", 8.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.rdbOther.Location = new System.Drawing.Point(288, 9);
            this.rdbOther.Margin = new System.Windows.Forms.Padding(2);
            this.rdbOther.Name = "rdbOther";
            this.rdbOther.Size = new System.Drawing.Size(64, 19);
            this.rdbOther.TabIndex = 366;
            this.rdbOther.Text = "OTHER";
            this.rdbOther.UseVisualStyleBackColor = true;
            // 
            // cmbPaymentAccount
            // 
            this.cmbPaymentAccount.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbPaymentAccount.FormattingEnabled = true;
            this.cmbPaymentAccount.Location = new System.Drawing.Point(130, 225);
            this.cmbPaymentAccount.Name = "cmbPaymentAccount";
            this.cmbPaymentAccount.Size = new System.Drawing.Size(246, 25);
            this.cmbPaymentAccount.TabIndex = 363;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(10, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 15);
            this.label4.TabIndex = 364;
            this.label4.Text = "PAYMENT AC:";
            // 
            // frm_PaymentReceiveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1076, 504);
            this.Controls.Add(this.cmbPaymentAccount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pnlPaymentType);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnVoucher);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.txtTotalReceiving);
            this.Controls.Add(this.txtTotalBalanceAmount);
            this.Controls.Add(this.txtTotalPaid);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.rdbReceiving);
            this.Controls.Add(this.rdbPayment);
            this.Controls.Add(this.txtAmountWords);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbReceivingAccount);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblAcc);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSAVE);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnCLEAR);
            this.Controls.Add(this.lblPaid);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblV);
            this.Controls.Add(this.grdSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSEARCH);
            this.Controls.Add(this.pnlHEADER);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1094, 596);
            this.Name = "frm_PaymentReceiveForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Receiving & Payments";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_CashPmt_FormClosed);
            this.Load += new System.EventHandler(this.frm_CashPmt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlHEADER.ResumeLayout(false);
            this.pnlHEADER.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
            this.pnlPaymentType.ResumeLayout(false);
            this.pnlPaymentType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHEADER;
        private System.Windows.Forms.PictureBox pictureBox15;
        private System.Windows.Forms.Label lblHEADING;
        private SergeUtils.EasyCompletionComboBox cmbReceivingAccount;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblAcc;
        private System.Windows.Forms.Button btnSAVE;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblPaid;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblV;
        private System.Windows.Forms.DataGridView grdSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSEARCH;
        private System.Windows.Forms.RadioButton rdbPayment;
        private System.Windows.Forms.RadioButton rdbReceiving;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAmountWords;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTotalPaid;
        private System.Windows.Forms.TextBox txtTotalReceiving;
        private System.Windows.Forms.TextBox txtTotalBalanceAmount;
        private System.Windows.Forms.Button btnCLEAR;
        private System.Windows.Forms.Button btnVoucher;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel pnlPaymentType;
        private System.Windows.Forms.RadioButton rdbOther;
        private System.Windows.Forms.RadioButton rdbExpense;
        private System.Windows.Forms.RadioButton rdbCash;
        private System.Windows.Forms.RadioButton rdbBank;
        private SergeUtils.EasyCompletionComboBox cmbPaymentAccount;
        private System.Windows.Forms.Label label4;
    }
}