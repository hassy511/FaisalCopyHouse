namespace ERP_Maaz_Oil.Forms
{
    partial class frm_CashBank
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_CashBank));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmbAccounts = new SergeUtils.EasyCompletionComboBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dtp_DATE = new System.Windows.Forms.DateTimePicker();
            this.lblCode = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblAcc = new System.Windows.Forms.Label();
            this.lblPaid = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblV = new System.Windows.Forms.Label();
            this.grdSEARCH = new System.Windows.Forms.DataGridView();
            this.txtSEARCH = new System.Windows.Forms.TextBox();
            this.lblSEARCH = new System.Windows.Forms.Label();
            this.btnSAVE = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlHEADER = new System.Windows.Forms.Panel();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.lblHEADING = new System.Windows.Forms.Label();
            this.rdbCashPayment = new System.Windows.Forms.RadioButton();
            this.rdbCashReceipt = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAmountPay = new System.Windows.Forms.TextBox();
            this.lblTrNo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAmountWords = new System.Windows.Forms.TextBox();
            this.grdPaySummary = new System.Windows.Forms.DataGridView();
            this.grdRecSummary = new System.Windows.Forms.DataGridView();
            this.txtTotalPayGrid = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTotalRecGrid = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTotalPaid = new System.Windows.Forms.TextBox();
            this.txtTotalRcvd = new System.Windows.Forms.TextBox();
            this.txtTotalBalanceAmount = new System.Windows.Forms.TextBox();
            this.btnCLEAR = new System.Windows.Forms.Button();
            this.btnReceiptVoucher = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtOpenBalance = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbBank = new SergeUtils.EasyCompletionComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdSEARCH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlHEADER.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPaySummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRecSummary)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbAccounts
            // 
            this.cmbAccounts.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbAccounts.FormattingEnabled = true;
            this.cmbAccounts.Location = new System.Drawing.Point(158, 233);
            this.cmbAccounts.Margin = new System.Windows.Forms.Padding(4);
            this.cmbAccounts.Name = "cmbAccounts";
            this.cmbAccounts.Size = new System.Drawing.Size(306, 29);
            this.cmbAccounts.TabIndex = 3;
            this.cmbAccounts.DropDown += new System.EventHandler(this.cmbPay_DropDown);
            this.cmbAccounts.SelectedIndexChanged += new System.EventHandler(this.cmbAccounts_SelectedIndexChanged);
            this.cmbAccounts.TextUpdate += new System.EventHandler(this.cmbPay_TextUpdate);
            this.cmbAccounts.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmbPay_PreviewKeyDown);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icons8-Save as Filled-100.png");
            this.imageList1.Images.SetKeyName(1, "icons8-Cancel Filled-100.png");
            this.imageList1.Images.SetKeyName(2, "icons8-search.png");
            // 
            // dtp_DATE
            // 
            this.dtp_DATE.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.dtp_DATE.Location = new System.Drawing.Point(158, 155);
            this.dtp_DATE.Margin = new System.Windows.Forms.Padding(4);
            this.dtp_DATE.Name = "dtp_DATE";
            this.dtp_DATE.Size = new System.Drawing.Size(306, 27);
            this.dtp_DATE.TabIndex = 0;
            this.dtp_DATE.ValueChanged += new System.EventHandler(this.dtp_DATE_ValueChanged);
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(215)))));
            this.lblCode.Location = new System.Drawing.Point(154, 131);
            this.lblCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(85, 20);
            this.lblCode.TabIndex = 268;
            this.lblCode.Text = "CPV-1-2017";
            // 
            // txtDescription
            // 
            this.txtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtDescription.Location = new System.Drawing.Point(158, 346);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescription.MaxLength = 100;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(790, 70);
            this.txtDescription.TabIndex = 2;
            this.txtDescription.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtAmount_MouseClick);
            this.txtDescription.Enter += new System.EventHandler(this.txtAmount_Enter);
            this.txtDescription.Leave += new System.EventHandler(this.txtPay_Leave);
            // 
            // lblAcc
            // 
            this.lblAcc.AutoSize = true;
            this.lblAcc.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblAcc.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblAcc.Location = new System.Drawing.Point(14, 352);
            this.lblAcc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAcc.Name = "lblAcc";
            this.lblAcc.Size = new System.Drawing.Size(106, 20);
            this.lblAcc.TabIndex = 266;
            this.lblAcc.Text = "DESCRIPTION:";
            // 
            // lblPaid
            // 
            this.lblPaid.AutoSize = true;
            this.lblPaid.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblPaid.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPaid.Location = new System.Drawing.Point(9, 239);
            this.lblPaid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPaid.Name = "lblPaid";
            this.lblPaid.Size = new System.Drawing.Size(131, 20);
            this.lblPaid.TabIndex = 261;
            this.lblPaid.Text = "ACCOUNT NAME:";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblDate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDate.Location = new System.Drawing.Point(12, 155);
            this.lblDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(49, 20);
            this.lblDate.TabIndex = 260;
            this.lblDate.Text = "DATE:";
            // 
            // lblV
            // 
            this.lblV.AutoSize = true;
            this.lblV.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblV.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblV.Location = new System.Drawing.Point(10, 131);
            this.lblV.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblV.Name = "lblV";
            this.lblV.Size = new System.Drawing.Size(95, 20);
            this.lblV.TabIndex = 259;
            this.lblV.Text = "VOUCHER #:";
            // 
            // grdSEARCH
            // 
            this.grdSEARCH.AllowUserToAddRows = false;
            this.grdSEARCH.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.grdSEARCH.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdSEARCH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdSEARCH.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grdSEARCH.BackgroundColor = System.Drawing.Color.White;
            this.grdSEARCH.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdSEARCH.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdSEARCH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSEARCH.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdSEARCH.DefaultCellStyle = dataGridViewCellStyle3;
            this.grdSEARCH.Location = new System.Drawing.Point(1, 489);
            this.grdSEARCH.Margin = new System.Windows.Forms.Padding(4);
            this.grdSEARCH.Name = "grdSEARCH";
            this.grdSEARCH.ReadOnly = true;
            this.grdSEARCH.RowHeadersVisible = false;
            this.grdSEARCH.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSEARCH.Size = new System.Drawing.Size(942, 138);
            this.grdSEARCH.TabIndex = 258;
            this.grdSEARCH.TabStop = false;
            this.grdSEARCH.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdSEARCH_CellClick);
            this.grdSEARCH.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdSEARCH_CellContentClick);
            this.grdSEARCH.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.grdSEARCH_DataBindingComplete);
            // 
            // txtSEARCH
            // 
            this.txtSEARCH.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSEARCH.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtSEARCH.Location = new System.Drawing.Point(159, 424);
            this.txtSEARCH.Margin = new System.Windows.Forms.Padding(4);
            this.txtSEARCH.Name = "txtSEARCH";
            this.txtSEARCH.Size = new System.Drawing.Size(789, 29);
            this.txtSEARCH.TabIndex = 257;
            this.txtSEARCH.TextChanged += new System.EventHandler(this.txtSEARCH_TextChanged);
            // 
            // lblSEARCH
            // 
            this.lblSEARCH.AutoSize = true;
            this.lblSEARCH.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSEARCH.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSEARCH.Location = new System.Drawing.Point(17, 427);
            this.lblSEARCH.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSEARCH.Name = "lblSEARCH";
            this.lblSEARCH.Size = new System.Drawing.Size(74, 23);
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
            this.btnSAVE.Location = new System.Drawing.Point(634, 222);
            this.btnSAVE.Margin = new System.Windows.Forms.Padding(4);
            this.btnSAVE.Name = "btnSAVE";
            this.btnSAVE.Size = new System.Drawing.Size(152, 31);
            this.btnSAVE.TabIndex = 6;
            this.btnSAVE.Text = "SAVE";
            this.btnSAVE.UseVisualStyleBackColor = false;
            this.btnSAVE.Click += new System.EventHandler(this.btnSAVE_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::ERP_Maaz_Oil.Properties.Resources.plus;
            this.pictureBox1.Location = new System.Drawing.Point(1789, 4);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(65, 25);
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
            this.pnlHEADER.Margin = new System.Windows.Forms.Padding(4);
            this.pnlHEADER.Name = "pnlHEADER";
            this.pnlHEADER.Size = new System.Drawing.Size(1348, 70);
            this.pnlHEADER.TabIndex = 38;
            // 
            // pictureBox15
            // 
            this.pictureBox15.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox15.Image = global::ERP_Maaz_Oil.Properties.Resources.plus;
            this.pictureBox15.Location = new System.Drawing.Point(1788, 4);
            this.pictureBox15.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox15.Name = "pictureBox15";
            this.pictureBox15.Size = new System.Drawing.Size(65, 25);
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
            this.lblHEADING.Location = new System.Drawing.Point(8, 22);
            this.lblHEADING.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHEADING.Name = "lblHEADING";
            this.lblHEADING.Size = new System.Drawing.Size(264, 30);
            this.lblHEADING.TabIndex = 23;
            this.lblHEADING.Text = "CASH BANK RECEIVE";
            // 
            // rdbCashPayment
            // 
            this.rdbCashPayment.AutoSize = true;
            this.rdbCashPayment.Checked = true;
            this.rdbCashPayment.Font = new System.Drawing.Font("Segoe UI", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbCashPayment.Location = new System.Drawing.Point(480, 81);
            this.rdbCashPayment.Margin = new System.Windows.Forms.Padding(2);
            this.rdbCashPayment.Name = "rdbCashPayment";
            this.rdbCashPayment.Size = new System.Drawing.Size(178, 29);
            this.rdbCashPayment.TabIndex = 280;
            this.rdbCashPayment.TabStop = true;
            this.rdbCashPayment.Text = "CASH PAYMENT";
            this.rdbCashPayment.UseVisualStyleBackColor = true;
            this.rdbCashPayment.CheckedChanged += new System.EventHandler(this.rdbCashPayment_CheckedChanged);
            // 
            // rdbCashReceipt
            // 
            this.rdbCashReceipt.AutoSize = true;
            this.rdbCashReceipt.Font = new System.Drawing.Font("Segoe UI", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbCashReceipt.Location = new System.Drawing.Point(6, 81);
            this.rdbCashReceipt.Margin = new System.Windows.Forms.Padding(2);
            this.rdbCashReceipt.Name = "rdbCashReceipt";
            this.rdbCashReceipt.Size = new System.Drawing.Size(162, 29);
            this.rdbCashReceipt.TabIndex = 280;
            this.rdbCashReceipt.Text = "CASH RECEIPT";
            this.rdbCashReceipt.UseVisualStyleBackColor = true;
            this.rdbCashReceipt.CheckedChanged += new System.EventHandler(this.rdbCashPayment_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(10, 276);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 20);
            this.label1.TabIndex = 264;
            this.label1.Text = "PAYMENT AMOUNT:";
            // 
            // txtAmountPay
            // 
            this.txtAmountPay.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAmountPay.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtAmountPay.Location = new System.Drawing.Point(158, 272);
            this.txtAmountPay.Margin = new System.Windows.Forms.Padding(4);
            this.txtAmountPay.MaxLength = 10;
            this.txtAmountPay.Name = "txtAmountPay";
            this.txtAmountPay.Size = new System.Drawing.Size(306, 29);
            this.txtAmountPay.TabIndex = 4;
            this.txtAmountPay.Text = "0.0";
            this.txtAmountPay.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtAmount_MouseClick);
            this.txtAmountPay.TextChanged += new System.EventHandler(this.amountTxtChanged);
            this.txtAmountPay.Enter += new System.EventHandler(this.txtAmount_Enter);
            this.txtAmountPay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            this.txtAmountPay.Leave += new System.EventHandler(this.txtAmount_Leave);
            // 
            // lblTrNo
            // 
            this.lblTrNo.AutoSize = true;
            this.lblTrNo.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblTrNo.ForeColor = System.Drawing.Color.Red;
            this.lblTrNo.Location = new System.Drawing.Point(832, 88);
            this.lblTrNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTrNo.Name = "lblTrNo";
            this.lblTrNo.Size = new System.Drawing.Size(85, 20);
            this.lblTrNo.TabIndex = 268;
            this.lblTrNo.Text = "CPV-1-2017";
            this.lblTrNo.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(804, 88);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 20);
            this.label4.TabIndex = 259;
            this.label4.Text = "TRANSACTION:";
            this.label4.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(12, 310);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 20);
            this.label3.TabIndex = 273;
            this.label3.Text = "AMOUNT(WORDS):";
            // 
            // txtAmountWords
            // 
            this.txtAmountWords.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAmountWords.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtAmountWords.Location = new System.Drawing.Point(158, 309);
            this.txtAmountWords.Margin = new System.Windows.Forms.Padding(4);
            this.txtAmountWords.MaxLength = 50;
            this.txtAmountWords.Name = "txtAmountWords";
            this.txtAmountWords.ReadOnly = true;
            this.txtAmountWords.Size = new System.Drawing.Size(306, 29);
            this.txtAmountWords.TabIndex = 1;
            this.txtAmountWords.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtAmount_MouseClick);
            this.txtAmountWords.Enter += new System.EventHandler(this.txtAmount_Enter);
            this.txtAmountWords.Leave += new System.EventHandler(this.txtPay_Leave);
            // 
            // grdPaySummary
            // 
            this.grdPaySummary.AllowUserToAddRows = false;
            this.grdPaySummary.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdPaySummary.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.grdPaySummary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdPaySummary.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grdPaySummary.BackgroundColor = System.Drawing.Color.White;
            this.grdPaySummary.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdPaySummary.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.grdPaySummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPaySummary.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdPaySummary.DefaultCellStyle = dataGridViewCellStyle6;
            this.grdPaySummary.Location = new System.Drawing.Point(951, 425);
            this.grdPaySummary.Margin = new System.Windows.Forms.Padding(4);
            this.grdPaySummary.Name = "grdPaySummary";
            this.grdPaySummary.ReadOnly = true;
            this.grdPaySummary.RowHeadersVisible = false;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdPaySummary.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.grdPaySummary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPaySummary.Size = new System.Drawing.Size(392, 168);
            this.grdPaySummary.TabIndex = 357;
            this.grdPaySummary.TabStop = false;
            this.grdPaySummary.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdPaySummary_CellClick);
            this.grdPaySummary.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdPaySummary_CellContentClick);
            this.grdPaySummary.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.grdPaySummary_DataBindingComplete);
            // 
            // grdRecSummary
            // 
            this.grdRecSummary.AllowUserToAddRows = false;
            this.grdRecSummary.AllowUserToDeleteRows = false;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdRecSummary.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle8;
            this.grdRecSummary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdRecSummary.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grdRecSummary.BackgroundColor = System.Drawing.Color.White;
            this.grdRecSummary.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdRecSummary.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.grdRecSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdRecSummary.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdRecSummary.DefaultCellStyle = dataGridViewCellStyle10;
            this.grdRecSummary.Location = new System.Drawing.Point(951, 112);
            this.grdRecSummary.Margin = new System.Windows.Forms.Padding(4);
            this.grdRecSummary.Name = "grdRecSummary";
            this.grdRecSummary.ReadOnly = true;
            this.grdRecSummary.RowHeadersVisible = false;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdRecSummary.RowsDefaultCellStyle = dataGridViewCellStyle11;
            this.grdRecSummary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdRecSummary.Size = new System.Drawing.Size(392, 232);
            this.grdRecSummary.TabIndex = 358;
            this.grdRecSummary.TabStop = false;
            this.grdRecSummary.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdRecSummary_CellClick);
            this.grdRecSummary.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdRecSummary_CellContentClick);
            this.grdRecSummary.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.grdRecSummary_DataBindingComplete);
            // 
            // txtTotalPayGrid
            // 
            this.txtTotalPayGrid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotalPayGrid.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtTotalPayGrid.Location = new System.Drawing.Point(1198, 601);
            this.txtTotalPayGrid.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotalPayGrid.Name = "txtTotalPayGrid";
            this.txtTotalPayGrid.ReadOnly = true;
            this.txtTotalPayGrid.Size = new System.Drawing.Size(145, 29);
            this.txtTotalPayGrid.TabIndex = 355;
            this.txtTotalPayGrid.Text = "0";
            this.txtTotalPayGrid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(1117, 604);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 23);
            this.label6.TabIndex = 353;
            this.label6.Text = "TOTAL";
            // 
            // txtTotalRecGrid
            // 
            this.txtTotalRecGrid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotalRecGrid.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtTotalRecGrid.Location = new System.Drawing.Point(1199, 352);
            this.txtTotalRecGrid.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotalRecGrid.Name = "txtTotalRecGrid";
            this.txtTotalRecGrid.ReadOnly = true;
            this.txtTotalRecGrid.Size = new System.Drawing.Size(145, 29);
            this.txtTotalRecGrid.TabIndex = 356;
            this.txtTotalRecGrid.Text = "0";
            this.txtTotalRecGrid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(1118, 352);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 23);
            this.label5.TabIndex = 354;
            this.label5.Text = "TOTAL";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(998, 395);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(313, 28);
            this.label7.TabIndex = 351;
            this.label7.Text = "SUMMARY PAYMENT ACCOUNT";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(998, 81);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(297, 28);
            this.label8.TabIndex = 352;
            this.label8.Text = "SUMMARY RECEIPT ACCOUNT";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(507, 185);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 20);
            this.label9.TabIndex = 273;
            this.label9.Text = "CASH BALANCE:";
            // 
            // txtBalance
            // 
            this.txtBalance.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBalance.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtBalance.Location = new System.Drawing.Point(635, 185);
            this.txtBalance.Margin = new System.Windows.Forms.Padding(4);
            this.txtBalance.MaxLength = 50;
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.ReadOnly = true;
            this.txtBalance.Size = new System.Drawing.Size(306, 29);
            this.txtBalance.TabIndex = 1;
            this.txtBalance.Text = "0";
            this.txtBalance.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtAmount_MouseClick);
            this.txtBalance.Enter += new System.EventHandler(this.txtAmount_Enter);
            this.txtBalance.Leave += new System.EventHandler(this.txtPay_Leave);
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
            this.btnDelete.Location = new System.Drawing.Point(633, 259);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(154, 31);
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
            this.label10.Location = new System.Drawing.Point(258, 636);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 23);
            this.label10.TabIndex = 353;
            this.label10.Text = "TOTAL:";
            // 
            // txtTotalPaid
            // 
            this.txtTotalPaid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotalPaid.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtTotalPaid.Location = new System.Drawing.Point(578, 635);
            this.txtTotalPaid.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotalPaid.Name = "txtTotalPaid";
            this.txtTotalPaid.ReadOnly = true;
            this.txtTotalPaid.Size = new System.Drawing.Size(145, 29);
            this.txtTotalPaid.TabIndex = 355;
            this.txtTotalPaid.Text = "0";
            this.txtTotalPaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalRcvd
            // 
            this.txtTotalRcvd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotalRcvd.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtTotalRcvd.Location = new System.Drawing.Point(385, 635);
            this.txtTotalRcvd.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotalRcvd.Name = "txtTotalRcvd";
            this.txtTotalRcvd.ReadOnly = true;
            this.txtTotalRcvd.Size = new System.Drawing.Size(145, 29);
            this.txtTotalRcvd.TabIndex = 355;
            this.txtTotalRcvd.Text = "0";
            this.txtTotalRcvd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalBalanceAmount
            // 
            this.txtTotalBalanceAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotalBalanceAmount.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtTotalBalanceAmount.Location = new System.Drawing.Point(793, 635);
            this.txtTotalBalanceAmount.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotalBalanceAmount.Name = "txtTotalBalanceAmount";
            this.txtTotalBalanceAmount.ReadOnly = true;
            this.txtTotalBalanceAmount.Size = new System.Drawing.Size(145, 29);
            this.txtTotalBalanceAmount.TabIndex = 355;
            this.txtTotalBalanceAmount.Text = "0";
            this.txtTotalBalanceAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalBalanceAmount.Visible = false;
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
            this.btnCLEAR.Location = new System.Drawing.Point(785, 222);
            this.btnCLEAR.Margin = new System.Windows.Forms.Padding(4);
            this.btnCLEAR.Name = "btnCLEAR";
            this.btnCLEAR.Size = new System.Drawing.Size(156, 31);
            this.btnCLEAR.TabIndex = 7;
            this.btnCLEAR.Text = "CLEAR";
            this.btnCLEAR.UseVisualStyleBackColor = false;
            this.btnCLEAR.Click += new System.EventHandler(this.btnCLEAR_Click);
            // 
            // btnReceiptVoucher
            // 
            this.btnReceiptVoucher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(24)))), ((int)(((byte)(38)))));
            this.btnReceiptVoucher.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReceiptVoucher.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnReceiptVoucher.ForeColor = System.Drawing.Color.White;
            this.btnReceiptVoucher.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReceiptVoucher.ImageIndex = 2;
            this.btnReceiptVoucher.ImageList = this.imageList1;
            this.btnReceiptVoucher.Location = new System.Drawing.Point(785, 259);
            this.btnReceiptVoucher.Margin = new System.Windows.Forms.Padding(4);
            this.btnReceiptVoucher.Name = "btnReceiptVoucher";
            this.btnReceiptVoucher.Size = new System.Drawing.Size(156, 31);
            this.btnReceiptVoucher.TabIndex = 360;
            this.btnReceiptVoucher.Text = "VOUCHER";
            this.btnReceiptVoucher.UseVisualStyleBackColor = false;
            this.btnReceiptVoucher.Click += new System.EventHandler(this.btnReceiptVoucher_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Location = new System.Drawing.Point(479, 155);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(148, 20);
            this.label11.TabIndex = 273;
            this.label11.Text = "OPENING BALANCE:";
            // 
            // txtOpenBalance
            // 
            this.txtOpenBalance.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOpenBalance.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtOpenBalance.Location = new System.Drawing.Point(633, 151);
            this.txtOpenBalance.Margin = new System.Windows.Forms.Padding(4);
            this.txtOpenBalance.MaxLength = 50;
            this.txtOpenBalance.Name = "txtOpenBalance";
            this.txtOpenBalance.ReadOnly = true;
            this.txtOpenBalance.Size = new System.Drawing.Size(306, 29);
            this.txtOpenBalance.TabIndex = 1;
            this.txtOpenBalance.Text = "0";
            this.txtOpenBalance.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtAmount_MouseClick);
            this.txtOpenBalance.Enter += new System.EventHandler(this.txtAmount_Enter);
            this.txtOpenBalance.Leave += new System.EventHandler(this.txtPay_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(9, 205);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 20);
            this.label2.TabIndex = 361;
            this.label2.Text = "BANK NAME:";
            // 
            // cmbBank
            // 
            this.cmbBank.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbBank.FormattingEnabled = true;
            this.cmbBank.Location = new System.Drawing.Point(159, 196);
            this.cmbBank.Margin = new System.Windows.Forms.Padding(4);
            this.cmbBank.Name = "cmbBank";
            this.cmbBank.Size = new System.Drawing.Size(306, 29);
            this.cmbBank.TabIndex = 362;
            // 
            // frm_CashBank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1348, 673);
            this.Controls.Add(this.cmbBank);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnReceiptVoucher);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.grdPaySummary);
            this.Controls.Add(this.grdRecSummary);
            this.Controls.Add(this.txtTotalRcvd);
            this.Controls.Add(this.txtTotalBalanceAmount);
            this.Controls.Add(this.txtTotalPaid);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtTotalPayGrid);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTotalRecGrid);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.rdbCashReceipt);
            this.Controls.Add(this.rdbCashPayment);
            this.Controls.Add(this.txtOpenBalance);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtBalance);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtAmountWords);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbAccounts);
            this.Controls.Add(this.dtp_DATE);
            this.Controls.Add(this.lblTrNo);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblAcc);
            this.Controls.Add(this.txtAmountPay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSAVE);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnCLEAR);
            this.Controls.Add(this.lblPaid);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblV);
            this.Controls.Add(this.grdSEARCH);
            this.Controls.Add(this.txtSEARCH);
            this.Controls.Add(this.lblSEARCH);
            this.Controls.Add(this.pnlHEADER);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(1366, 752);
            this.Name = "frm_CashBank";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CASH PAYMENT VOUCHER";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_CashPmt_FormClosed);
            this.Load += new System.EventHandler(this.frm_CashPmt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdSEARCH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlHEADER.ResumeLayout(false);
            this.pnlHEADER.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPaySummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRecSummary)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHEADER;
        private System.Windows.Forms.PictureBox pictureBox15;
        private System.Windows.Forms.Label lblHEADING;
        private SergeUtils.EasyCompletionComboBox cmbAccounts;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DateTimePicker dtp_DATE;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblAcc;
        private System.Windows.Forms.Button btnSAVE;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblPaid;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblV;
        private System.Windows.Forms.DataGridView grdSEARCH;
        private System.Windows.Forms.TextBox txtSEARCH;
        private System.Windows.Forms.Label lblSEARCH;
        private System.Windows.Forms.RadioButton rdbCashPayment;
        private System.Windows.Forms.RadioButton rdbCashReceipt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAmountPay;
        private System.Windows.Forms.Label lblTrNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAmountWords;
        private System.Windows.Forms.DataGridView grdPaySummary;
        private System.Windows.Forms.DataGridView grdRecSummary;
        private System.Windows.Forms.TextBox txtTotalPayGrid;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTotalRecGrid;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTotalPaid;
        private System.Windows.Forms.TextBox txtTotalRcvd;
        private System.Windows.Forms.TextBox txtTotalBalanceAmount;
        private System.Windows.Forms.Button btnCLEAR;
        private System.Windows.Forms.Button btnReceiptVoucher;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtOpenBalance;
        private System.Windows.Forms.Label label2;
        private SergeUtils.EasyCompletionComboBox cmbBank;
    }
}