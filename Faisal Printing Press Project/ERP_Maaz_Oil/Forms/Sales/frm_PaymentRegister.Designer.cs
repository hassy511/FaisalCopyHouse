namespace ERP_Maaz_Oil.Forms
{
    partial class frm_PaymentRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_PaymentRegister));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHEADER = new System.Windows.Forms.Panel();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.lblHEADING = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnCashSave = new System.Windows.Forms.Button();
            this.txtReceivingTotal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbCashAccount = new SergeUtils.EasyCompletionComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.gridData = new System.Windows.Forms.DataGridView();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.grpCashPayment = new System.Windows.Forms.GroupBox();
            this.txtCashAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rdbPayment = new System.Windows.Forms.RadioButton();
            this.rdbReceive = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.grpAccountPayment = new System.Windows.Forms.GroupBox();
            this.txtAccountAmount = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbPayment = new SergeUtils.EasyCompletionComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbReceiving = new SergeUtils.EasyCompletionComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAccountSave = new System.Windows.Forms.Button();
            this.txtPaymentTotal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCashClosing = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCashOpening = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAccountDescription = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCashDescription = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receiveAccountId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receivingAccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paymentAccountId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paymentAccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlHEADER.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).BeginInit();
            this.grpCashPayment.SuspendLayout();
            this.grpAccountPayment.SuspendLayout();
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
            this.pnlHEADER.Size = new System.Drawing.Size(1136, 44);
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
            this.lblHEADING.Location = new System.Drawing.Point(2, 13);
            this.lblHEADING.Name = "lblHEADING";
            this.lblHEADING.Size = new System.Drawing.Size(141, 17);
            this.lblHEADING.TabIndex = 23;
            this.lblHEADING.Text = "PAYMENT REGISTER";
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
            // btnCashSave
            // 
            this.btnCashSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(68)))), ((int)(((byte)(2)))));
            this.btnCashSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCashSave.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnCashSave.ForeColor = System.Drawing.Color.White;
            this.btnCashSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCashSave.ImageIndex = 5;
            this.btnCashSave.Location = new System.Drawing.Point(448, 148);
            this.btnCashSave.Name = "btnCashSave";
            this.btnCashSave.Size = new System.Drawing.Size(93, 25);
            this.btnCashSave.TabIndex = 124;
            this.btnCashSave.Text = "SAVE";
            this.btnCashSave.UseVisualStyleBackColor = false;
            this.btnCashSave.Click += new System.EventHandler(this.btnDiscard_Click);
            // 
            // txtReceivingTotal
            // 
            this.txtReceivingTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtReceivingTotal.Enabled = false;
            this.txtReceivingTotal.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtReceivingTotal.Location = new System.Drawing.Point(123, 559);
            this.txtReceivingTotal.MaxLength = 11;
            this.txtReceivingTotal.Name = "txtReceivingTotal";
            this.txtReceivingTotal.ReadOnly = true;
            this.txtReceivingTotal.Size = new System.Drawing.Size(244, 25);
            this.txtReceivingTotal.TabIndex = 352;
            this.txtReceivingTotal.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(13, 564);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 15);
            this.label6.TabIndex = 353;
            this.label6.Text = "RECEIVING TOTAL";
            // 
            // cmbCashAccount
            // 
            this.cmbCashAccount.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbCashAccount.FormattingEnabled = true;
            this.cmbCashAccount.Items.AddRange(new object[] {
            "--SELECT SUPPLIER--",
            "AUTOMART"});
            this.cmbCashAccount.Location = new System.Drawing.Point(99, 22);
            this.cmbCashAccount.Name = "cmbCashAccount";
            this.cmbCashAccount.Size = new System.Drawing.Size(439, 25);
            this.cmbCashAccount.TabIndex = 359;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(10, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 15);
            this.label9.TabIndex = 360;
            this.label9.Text = "ACCOUNT";
            // 
            // gridData
            // 
            this.gridData.AllowUserToAddRows = false;
            this.gridData.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.gridData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridData.BackgroundColor = System.Drawing.Color.White;
            this.gridData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.receiveAccountId,
            this.receivingAccountName,
            this.paymentAccountId,
            this.paymentAccountName,
            this.amount,
            this.type,
            this.description});
            this.gridData.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridData.DefaultCellStyle = dataGridViewCellStyle3;
            this.gridData.Location = new System.Drawing.Point(6, 272);
            this.gridData.Name = "gridData";
            this.gridData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridData.Size = new System.Drawing.Size(1122, 281);
            this.gridData.TabIndex = 361;
            this.gridData.TabStop = false;
            this.gridData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridData_CellClick);
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.dtpDate.Location = new System.Drawing.Point(51, 50);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(280, 23);
            this.dtpDate.TabIndex = 362;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblDate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDate.Location = new System.Drawing.Point(8, 54);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(36, 15);
            this.lblDate.TabIndex = 363;
            this.lblDate.Text = "DATE";
            // 
            // grpCashPayment
            // 
            this.grpCashPayment.Controls.Add(this.txtCashDescription);
            this.grpCashPayment.Controls.Add(this.label12);
            this.grpCashPayment.Controls.Add(this.txtCashAmount);
            this.grpCashPayment.Controls.Add(this.label1);
            this.grpCashPayment.Controls.Add(this.rdbPayment);
            this.grpCashPayment.Controls.Add(this.rdbReceive);
            this.grpCashPayment.Controls.Add(this.label4);
            this.grpCashPayment.Controls.Add(this.cmbCashAccount);
            this.grpCashPayment.Controls.Add(this.label9);
            this.grpCashPayment.Controls.Add(this.btnCashSave);
            this.grpCashPayment.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.grpCashPayment.Location = new System.Drawing.Point(6, 83);
            this.grpCashPayment.Name = "grpCashPayment";
            this.grpCashPayment.Size = new System.Drawing.Size(554, 183);
            this.grpCashPayment.TabIndex = 364;
            this.grpCashPayment.TabStop = false;
            this.grpCashPayment.Text = "CASH PAYMENT";
            // 
            // txtCashAmount
            // 
            this.txtCashAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCashAmount.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtCashAmount.Location = new System.Drawing.Point(99, 53);
            this.txtCashAmount.MaxLength = 32000;
            this.txtCashAmount.Name = "txtCashAmount";
            this.txtCashAmount.Size = new System.Drawing.Size(439, 25);
            this.txtCashAmount.TabIndex = 372;
            this.txtCashAmount.Text = "0";
            this.txtCashAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCashAmount_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(10, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 373;
            this.label1.Text = "AMOUNT";
            // 
            // rdbPayment
            // 
            this.rdbPayment.AutoSize = true;
            this.rdbPayment.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.rdbPayment.Location = new System.Drawing.Point(186, 87);
            this.rdbPayment.Name = "rdbPayment";
            this.rdbPayment.Size = new System.Drawing.Size(78, 19);
            this.rdbPayment.TabIndex = 362;
            this.rdbPayment.Text = "PAYMENT";
            this.rdbPayment.UseVisualStyleBackColor = true;
            // 
            // rdbReceive
            // 
            this.rdbReceive.AutoSize = true;
            this.rdbReceive.Checked = true;
            this.rdbReceive.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.rdbReceive.Location = new System.Drawing.Point(104, 87);
            this.rdbReceive.Name = "rdbReceive";
            this.rdbReceive.Size = new System.Drawing.Size(69, 19);
            this.rdbReceive.TabIndex = 361;
            this.rdbReceive.TabStop = true;
            this.rdbReceive.Text = "RECEIVE";
            this.rdbReceive.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(10, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
            this.label4.TabIndex = 363;
            this.label4.Text = "PAYMENT";
            // 
            // grpAccountPayment
            // 
            this.grpAccountPayment.Controls.Add(this.txtAccountDescription);
            this.grpAccountPayment.Controls.Add(this.label11);
            this.grpAccountPayment.Controls.Add(this.txtAccountAmount);
            this.grpAccountPayment.Controls.Add(this.label10);
            this.grpAccountPayment.Controls.Add(this.cmbPayment);
            this.grpAccountPayment.Controls.Add(this.label3);
            this.grpAccountPayment.Controls.Add(this.cmbReceiving);
            this.grpAccountPayment.Controls.Add(this.label2);
            this.grpAccountPayment.Controls.Add(this.btnAccountSave);
            this.grpAccountPayment.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.grpAccountPayment.Location = new System.Drawing.Point(566, 83);
            this.grpAccountPayment.Name = "grpAccountPayment";
            this.grpAccountPayment.Size = new System.Drawing.Size(562, 183);
            this.grpAccountPayment.TabIndex = 365;
            this.grpAccountPayment.TabStop = false;
            this.grpAccountPayment.Text = "ACCOUNT PAYMENT";
            // 
            // txtAccountAmount
            // 
            this.txtAccountAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAccountAmount.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtAccountAmount.Location = new System.Drawing.Point(96, 84);
            this.txtAccountAmount.MaxLength = 32000;
            this.txtAccountAmount.Name = "txtAccountAmount";
            this.txtAccountAmount.Size = new System.Drawing.Size(460, 25);
            this.txtAccountAmount.TabIndex = 374;
            this.txtAccountAmount.Text = "0";
            this.txtAccountAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCashAmount_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Location = new System.Drawing.Point(7, 89);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 15);
            this.label10.TabIndex = 375;
            this.label10.Text = "AMOUNT";
            // 
            // cmbPayment
            // 
            this.cmbPayment.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbPayment.FormattingEnabled = true;
            this.cmbPayment.Items.AddRange(new object[] {
            "--SELECT SUPPLIER--",
            "AUTOMART"});
            this.cmbPayment.Location = new System.Drawing.Point(96, 53);
            this.cmbPayment.Name = "cmbPayment";
            this.cmbPayment.Size = new System.Drawing.Size(460, 25);
            this.cmbPayment.TabIndex = 364;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(7, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 15);
            this.label3.TabIndex = 365;
            this.label3.Text = "PAYMENT";
            // 
            // cmbReceiving
            // 
            this.cmbReceiving.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbReceiving.FormattingEnabled = true;
            this.cmbReceiving.Items.AddRange(new object[] {
            "--SELECT SUPPLIER--",
            "AUTOMART"});
            this.cmbReceiving.Location = new System.Drawing.Point(96, 22);
            this.cmbReceiving.Name = "cmbReceiving";
            this.cmbReceiving.Size = new System.Drawing.Size(460, 25);
            this.cmbReceiving.TabIndex = 362;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(7, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 15);
            this.label2.TabIndex = 363;
            this.label2.Text = "RECEIVING";
            // 
            // btnAccountSave
            // 
            this.btnAccountSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(68)))), ((int)(((byte)(2)))));
            this.btnAccountSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAccountSave.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnAccountSave.ForeColor = System.Drawing.Color.White;
            this.btnAccountSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccountSave.ImageIndex = 5;
            this.btnAccountSave.Location = new System.Drawing.Point(463, 148);
            this.btnAccountSave.Name = "btnAccountSave";
            this.btnAccountSave.Size = new System.Drawing.Size(93, 25);
            this.btnAccountSave.TabIndex = 361;
            this.btnAccountSave.Text = "SAVE";
            this.btnAccountSave.UseVisualStyleBackColor = false;
            this.btnAccountSave.Click += new System.EventHandler(this.btnAccountSave_Click);
            // 
            // txtPaymentTotal
            // 
            this.txtPaymentTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPaymentTotal.Enabled = false;
            this.txtPaymentTotal.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtPaymentTotal.Location = new System.Drawing.Point(487, 559);
            this.txtPaymentTotal.MaxLength = 11;
            this.txtPaymentTotal.Name = "txtPaymentTotal";
            this.txtPaymentTotal.ReadOnly = true;
            this.txtPaymentTotal.Size = new System.Drawing.Size(244, 25);
            this.txtPaymentTotal.TabIndex = 366;
            this.txtPaymentTotal.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(377, 564);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 15);
            this.label5.TabIndex = 367;
            this.label5.Text = "PAYMENT TOTAL";
            // 
            // txtCashClosing
            // 
            this.txtCashClosing.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCashClosing.Enabled = false;
            this.txtCashClosing.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtCashClosing.Location = new System.Drawing.Point(864, 559);
            this.txtCashClosing.MaxLength = 11;
            this.txtCashClosing.Name = "txtCashClosing";
            this.txtCashClosing.ReadOnly = true;
            this.txtCashClosing.Size = new System.Drawing.Size(244, 25);
            this.txtCashClosing.TabIndex = 368;
            this.txtCashClosing.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(767, 564);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 15);
            this.label7.TabIndex = 369;
            this.label7.Text = "CASH CLOSING";
            // 
            // txtCashOpening
            // 
            this.txtCashOpening.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCashOpening.Enabled = false;
            this.txtCashOpening.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtCashOpening.Location = new System.Drawing.Point(454, 51);
            this.txtCashOpening.MaxLength = 11;
            this.txtCashOpening.Name = "txtCashOpening";
            this.txtCashOpening.ReadOnly = true;
            this.txtCashOpening.Size = new System.Drawing.Size(265, 25);
            this.txtCashOpening.TabIndex = 370;
            this.txtCashOpening.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(357, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 15);
            this.label8.TabIndex = 371;
            this.label8.Text = "CASH OPENING";
            // 
            // txtAccountDescription
            // 
            this.txtAccountDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAccountDescription.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtAccountDescription.Location = new System.Drawing.Point(96, 115);
            this.txtAccountDescription.MaxLength = 32000;
            this.txtAccountDescription.Name = "txtAccountDescription";
            this.txtAccountDescription.Size = new System.Drawing.Size(460, 25);
            this.txtAccountDescription.TabIndex = 376;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Location = new System.Drawing.Point(7, 120);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 15);
            this.label11.TabIndex = 377;
            this.label11.Text = "DESCRIPTION";
            // 
            // txtCashDescription
            // 
            this.txtCashDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCashDescription.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtCashDescription.Location = new System.Drawing.Point(99, 115);
            this.txtCashDescription.MaxLength = 32000;
            this.txtCashDescription.Name = "txtCashDescription";
            this.txtCashDescription.Size = new System.Drawing.Size(439, 25);
            this.txtCashDescription.TabIndex = 378;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label12.Location = new System.Drawing.Point(10, 120);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(83, 15);
            this.label12.TabIndex = 379;
            this.label12.Text = "DESCRIPTION";
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // receiveAccountId
            // 
            this.receiveAccountId.HeaderText = "RECEIVING ACCOUNT ID";
            this.receiveAccountId.Name = "receiveAccountId";
            this.receiveAccountId.ReadOnly = true;
            this.receiveAccountId.Visible = false;
            // 
            // receivingAccountName
            // 
            this.receivingAccountName.HeaderText = "RECEIVING ACCOUNT";
            this.receivingAccountName.Name = "receivingAccountName";
            this.receivingAccountName.ReadOnly = true;
            // 
            // paymentAccountId
            // 
            this.paymentAccountId.HeaderText = "PAYMENT ACCOUNT ID";
            this.paymentAccountId.Name = "paymentAccountId";
            this.paymentAccountId.ReadOnly = true;
            this.paymentAccountId.Visible = false;
            // 
            // paymentAccountName
            // 
            this.paymentAccountName.HeaderText = "PAYMENT ACCOUNT";
            this.paymentAccountName.Name = "paymentAccountName";
            this.paymentAccountName.ReadOnly = true;
            // 
            // amount
            // 
            this.amount.HeaderText = "AMOUNT";
            this.amount.Name = "amount";
            this.amount.ReadOnly = true;
            // 
            // type
            // 
            this.type.HeaderText = "TYPE";
            this.type.Name = "type";
            this.type.ReadOnly = true;
            this.type.Visible = false;
            // 
            // description
            // 
            this.description.HeaderText = "DESCRIPTION";
            this.description.Name = "description";
            this.description.ReadOnly = true;
            // 
            // frm_PaymentRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1136, 588);
            this.Controls.Add(this.txtCashOpening);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCashClosing);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPaymentTotal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.grpAccountPayment);
            this.Controls.Add(this.grpCashPayment);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.gridData);
            this.Controls.Add(this.txtReceivingTotal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pnlHEADER);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1152, 627);
            this.Name = "frm_PaymentRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PAYMENT REGISTER";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_Account_Ledger_FormClosed);
            this.Load += new System.EventHandler(this.frm_Account_Ledger_Load);
            this.pnlHEADER.ResumeLayout(false);
            this.pnlHEADER.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).EndInit();
            this.grpCashPayment.ResumeLayout(false);
            this.grpCashPayment.PerformLayout();
            this.grpAccountPayment.ResumeLayout(false);
            this.grpAccountPayment.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHEADER;
        private System.Windows.Forms.PictureBox pictureBox15;
        private System.Windows.Forms.PictureBox pictureBox14;
        private System.Windows.Forms.Label lblHEADING;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnCashSave;
        private System.Windows.Forms.TextBox txtReceivingTotal;
        private System.Windows.Forms.Label label6;
        private SergeUtils.EasyCompletionComboBox cmbCashAccount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView gridData;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.GroupBox grpCashPayment;
        private System.Windows.Forms.GroupBox grpAccountPayment;
        private SergeUtils.EasyCompletionComboBox cmbReceiving;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAccountSave;
        private SergeUtils.EasyCompletionComboBox cmbPayment;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rdbPayment;
        private System.Windows.Forms.RadioButton rdbReceive;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPaymentTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCashClosing;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCashOpening;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCashAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAccountAmount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtAccountDescription;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCashDescription;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn receiveAccountId;
        private System.Windows.Forms.DataGridViewTextBoxColumn receivingAccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn paymentAccountId;
        private System.Windows.Forms.DataGridViewTextBoxColumn paymentAccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
    }
}