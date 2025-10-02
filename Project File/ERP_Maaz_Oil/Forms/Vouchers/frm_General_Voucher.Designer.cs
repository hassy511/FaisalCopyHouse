namespace ERP_Maaz_Oil.Forms
{
    partial class frm_General_Voucher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_General_Voucher));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.cmbACCOUNT = new SergeUtils.EasyCompletionComboBox();
            this.lblTrNo = new System.Windows.Forms.Label();
            this.lblTr = new System.Windows.Forms.Label();
            this.dtp_DATE = new System.Windows.Forms.DateTimePicker();
            this.lblTV = new System.Windows.Forms.Label();
            this.lblHEADING = new System.Windows.Forms.Label();
            this.txtNar = new System.Windows.Forms.TextBox();
            this.lblNar = new System.Windows.Forms.Label();
            this.txtDEBIT = new System.Windows.Forms.TextBox();
            this.lblACCOUNT = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnCLEAR = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblDEBIT = new System.Windows.Forms.Label();
            this.btnSAVE = new System.Windows.Forms.Button();
            this.lblV = new System.Windows.Forms.Label();
            this.grdSEARCH = new System.Windows.Forms.DataGridView();
            this.txtSEARCH = new System.Windows.Forms.TextBox();
            this.lblSEARCH = new System.Windows.Forms.Label();
            this.pnlHEADER = new System.Windows.Forms.Panel();
            this.txtCREDIT = new System.Windows.Forms.TextBox();
            this.lblCREDIT = new System.Windows.Forms.Label();
            this.btnADD = new System.Windows.Forms.Button();
            this.grdENTRY = new System.Windows.Forms.DataGridView();
            this.acc_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acc_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.debit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.credit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inv_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inv_of = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbSELECT_INV = new SergeUtils.EasyCompletionComboBox();
            this.rdbOTHERS = new System.Windows.Forms.RadioButton();
            this.rdbINV_REC = new System.Windows.Forms.RadioButton();
            this.rdbPAY = new System.Windows.Forms.RadioButton();
            this.lbl_SELECT_INV = new System.Windows.Forms.Label();
            this.btn_VIEW_VOUCHER = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSEARCH)).BeginInit();
            this.pnlHEADER.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdENTRY)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox15
            // 
            this.pictureBox15.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox15.Image = global::ERP_Maaz_Oil.Properties.Resources.plus;
            this.pictureBox15.Location = new System.Drawing.Point(1340, 3);
            this.pictureBox15.Name = "pictureBox15";
            this.pictureBox15.Size = new System.Drawing.Size(49, 20);
            this.pictureBox15.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox15.TabIndex = 25;
            this.pictureBox15.TabStop = false;
            // 
            // cmbACCOUNT
            // 
            this.cmbACCOUNT.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbACCOUNT.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbACCOUNT.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbACCOUNT.FormattingEnabled = true;
            this.cmbACCOUNT.Location = new System.Drawing.Point(528, 241);
            this.cmbACCOUNT.Name = "cmbACCOUNT";
            this.cmbACCOUNT.Size = new System.Drawing.Size(231, 25);
            this.cmbACCOUNT.TabIndex = 2;
            this.cmbACCOUNT.DropDown += new System.EventHandler(this.cmbACCOUNT_DropDown);
            this.cmbACCOUNT.SelectedIndexChanged += new System.EventHandler(this.cmbACCOUNT_SelectedIndexChanged);
            this.cmbACCOUNT.TextUpdate += new System.EventHandler(this.cmbACCOUNT_TextUpdate);
            this.cmbACCOUNT.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmbACCOUNT_PreviewKeyDown);
            // 
            // lblTrNo
            // 
            this.lblTrNo.AutoSize = true;
            this.lblTrNo.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblTrNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(24)))), ((int)(((byte)(38)))));
            this.lblTrNo.Location = new System.Drawing.Point(528, 122);
            this.lblTrNo.Name = "lblTrNo";
            this.lblTrNo.Size = new System.Drawing.Size(73, 15);
            this.lblTrNo.TabIndex = 323;
            this.lblTrNo.Text = "1221023332";
            // 
            // lblTr
            // 
            this.lblTr.AutoSize = true;
            this.lblTr.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblTr.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTr.Location = new System.Drawing.Point(420, 122);
            this.lblTr.Name = "lblTr";
            this.lblTr.Size = new System.Drawing.Size(102, 15);
            this.lblTr.TabIndex = 322;
            this.lblTr.Text = "TRANSACTION #:";
            // 
            // dtp_DATE
            // 
            this.dtp_DATE.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.dtp_DATE.Location = new System.Drawing.Point(528, 150);
            this.dtp_DATE.Name = "dtp_DATE";
            this.dtp_DATE.Size = new System.Drawing.Size(231, 23);
            this.dtp_DATE.TabIndex = 0;
            // 
            // lblTV
            // 
            this.lblTV.AutoSize = true;
            this.lblTV.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblTV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(215)))));
            this.lblTV.Location = new System.Drawing.Point(528, 96);
            this.lblTV.Name = "lblTV";
            this.lblTV.Size = new System.Drawing.Size(63, 15);
            this.lblTV.TabIndex = 320;
            this.lblTV.Text = "GV-1-2017";
            // 
            // lblHEADING
            // 
            this.lblHEADING.AutoSize = true;
            this.lblHEADING.BackColor = System.Drawing.Color.Transparent;
            this.lblHEADING.Font = new System.Drawing.Font("Berlin Sans FB", 15.75F);
            this.lblHEADING.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblHEADING.Location = new System.Drawing.Point(6, 32);
            this.lblHEADING.Name = "lblHEADING";
            this.lblHEADING.Size = new System.Drawing.Size(193, 23);
            this.lblHEADING.TabIndex = 23;
            this.lblHEADING.Text = "JOURNAL VOUCHER";
            // 
            // txtNar
            // 
            this.txtNar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNar.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtNar.Location = new System.Drawing.Point(528, 179);
            this.txtNar.MaxLength = 100;
            this.txtNar.Multiline = true;
            this.txtNar.Name = "txtNar";
            this.txtNar.Size = new System.Drawing.Size(561, 56);
            this.txtNar.TabIndex = 1;
            this.txtNar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtDEBIT_MouseClick);
            this.txtNar.Enter += new System.EventHandler(this.txtDEBIT_Enter);
            this.txtNar.Leave += new System.EventHandler(this.txtNar_Leave);
            // 
            // lblNar
            // 
            this.lblNar.AutoSize = true;
            this.lblNar.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblNar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblNar.Location = new System.Drawing.Point(420, 200);
            this.lblNar.Name = "lblNar";
            this.lblNar.Size = new System.Drawing.Size(77, 15);
            this.lblNar.TabIndex = 318;
            this.lblNar.Text = "NARRATION:";
            // 
            // txtDEBIT
            // 
            this.txtDEBIT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDEBIT.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtDEBIT.Location = new System.Drawing.Point(849, 272);
            this.txtDEBIT.MaxLength = 10;
            this.txtDEBIT.Name = "txtDEBIT";
            this.txtDEBIT.Size = new System.Drawing.Size(240, 25);
            this.txtDEBIT.TabIndex = 3;
            this.txtDEBIT.Text = "0.0";
            this.txtDEBIT.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtDEBIT_MouseClick);
            this.txtDEBIT.TextChanged += new System.EventHandler(this.txtDEBIT_TextChanged);
            this.txtDEBIT.Enter += new System.EventHandler(this.txtDEBIT_Enter);
            this.txtDEBIT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            this.txtDEBIT.Leave += new System.EventHandler(this.txtAmount_Leave);
            // 
            // lblACCOUNT
            // 
            this.lblACCOUNT.AutoSize = true;
            this.lblACCOUNT.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblACCOUNT.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblACCOUNT.Location = new System.Drawing.Point(420, 246);
            this.lblACCOUNT.Name = "lblACCOUNT";
            this.lblACCOUNT.Size = new System.Drawing.Size(65, 15);
            this.lblACCOUNT.TabIndex = 313;
            this.lblACCOUNT.Text = "ACCOUNT:";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icons8-Save as Filled-100.png");
            this.imageList1.Images.SetKeyName(1, "icons8-Cancel Filled-100.png");
            this.imageList1.Images.SetKeyName(2, "icons8-search.png");
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
            this.btnCLEAR.Location = new System.Drawing.Point(973, 515);
            this.btnCLEAR.Name = "btnCLEAR";
            this.btnCLEAR.Size = new System.Drawing.Size(116, 25);
            this.btnCLEAR.TabIndex = 7;
            this.btnCLEAR.Text = "CLEAR";
            this.btnCLEAR.UseVisualStyleBackColor = false;
            this.btnCLEAR.Click += new System.EventHandler(this.btnCLEAR_Click);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblDate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDate.Location = new System.Drawing.Point(420, 154);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(39, 15);
            this.lblDate.TabIndex = 312;
            this.lblDate.Text = "DATE:";
            // 
            // lblDEBIT
            // 
            this.lblDEBIT.AutoSize = true;
            this.lblDEBIT.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblDEBIT.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDEBIT.Location = new System.Drawing.Point(768, 277);
            this.lblDEBIT.Name = "lblDEBIT";
            this.lblDEBIT.Size = new System.Drawing.Size(43, 15);
            this.lblDEBIT.TabIndex = 316;
            this.lblDEBIT.Text = "DEBIT:";
            this.lblDEBIT.Click += new System.EventHandler(this.lblAmt_Click);
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
            this.btnSAVE.Location = new System.Drawing.Point(859, 515);
            this.btnSAVE.Name = "btnSAVE";
            this.btnSAVE.Size = new System.Drawing.Size(114, 25);
            this.btnSAVE.TabIndex = 6;
            this.btnSAVE.Text = "SAVE";
            this.btnSAVE.UseVisualStyleBackColor = false;
            this.btnSAVE.Click += new System.EventHandler(this.btnSAVE_Click_1);
            // 
            // lblV
            // 
            this.lblV.AutoSize = true;
            this.lblV.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblV.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblV.Location = new System.Drawing.Point(420, 96);
            this.lblV.Name = "lblV";
            this.lblV.Size = new System.Drawing.Size(74, 15);
            this.lblV.TabIndex = 311;
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
            this.grdSEARCH.Location = new System.Drawing.Point(11, 122);
            this.grdSEARCH.Name = "grdSEARCH";
            this.grdSEARCH.ReadOnly = true;
            this.grdSEARCH.RowHeadersVisible = false;
            this.grdSEARCH.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSEARCH.Size = new System.Drawing.Size(403, 418);
            this.grdSEARCH.TabIndex = 310;
            this.grdSEARCH.TabStop = false;
            this.grdSEARCH.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdSEARCH_CellClick);
            this.grdSEARCH.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdSEARCH_CellContentClick);
            this.grdSEARCH.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.grdSEARCH_DataBindingComplete);
            // 
            // txtSEARCH
            // 
            this.txtSEARCH.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSEARCH.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSEARCH.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtSEARCH.Location = new System.Drawing.Point(71, 91);
            this.txtSEARCH.Name = "txtSEARCH";
            this.txtSEARCH.Size = new System.Drawing.Size(343, 25);
            this.txtSEARCH.TabIndex = 309;
            this.txtSEARCH.TextChanged += new System.EventHandler(this.txtSEARCH_TextChanged);
            // 
            // lblSEARCH
            // 
            this.lblSEARCH.AutoSize = true;
            this.lblSEARCH.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSEARCH.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSEARCH.Location = new System.Drawing.Point(8, 95);
            this.lblSEARCH.Name = "lblSEARCH";
            this.lblSEARCH.Size = new System.Drawing.Size(57, 17);
            this.lblSEARCH.TabIndex = 308;
            this.lblSEARCH.Text = "SEARCH";
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
            this.pnlHEADER.Size = new System.Drawing.Size(1101, 88);
            this.pnlHEADER.TabIndex = 307;
            // 
            // txtCREDIT
            // 
            this.txtCREDIT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCREDIT.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtCREDIT.Location = new System.Drawing.Point(849, 303);
            this.txtCREDIT.MaxLength = 10;
            this.txtCREDIT.Name = "txtCREDIT";
            this.txtCREDIT.Size = new System.Drawing.Size(240, 25);
            this.txtCREDIT.TabIndex = 4;
            this.txtCREDIT.Text = "0.0";
            this.txtCREDIT.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtDEBIT_MouseClick);
            this.txtCREDIT.TextChanged += new System.EventHandler(this.txtCREDIT_TextChanged);
            this.txtCREDIT.Enter += new System.EventHandler(this.txtDEBIT_Enter);
            this.txtCREDIT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            this.txtCREDIT.Leave += new System.EventHandler(this.txtAmount_Leave);
            // 
            // lblCREDIT
            // 
            this.lblCREDIT.AutoSize = true;
            this.lblCREDIT.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblCREDIT.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCREDIT.Location = new System.Drawing.Point(768, 308);
            this.lblCREDIT.Name = "lblCREDIT";
            this.lblCREDIT.Size = new System.Drawing.Size(50, 15);
            this.lblCREDIT.TabIndex = 325;
            this.lblCREDIT.Text = "CREDIT:";
            this.lblCREDIT.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnADD
            // 
            this.btnADD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(215)))));
            this.btnADD.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnADD.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnADD.ForeColor = System.Drawing.Color.White;
            this.btnADD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnADD.ImageIndex = 0;
            this.btnADD.ImageList = this.imageList1;
            this.btnADD.Location = new System.Drawing.Point(528, 303);
            this.btnADD.Name = "btnADD";
            this.btnADD.Size = new System.Drawing.Size(231, 25);
            this.btnADD.TabIndex = 5;
            this.btnADD.Text = "ADD";
            this.btnADD.UseVisualStyleBackColor = false;
            this.btnADD.Click += new System.EventHandler(this.btnADD_Click);
            // 
            // grdENTRY
            // 
            this.grdENTRY.AllowUserToAddRows = false;
            this.grdENTRY.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.grdENTRY.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.grdENTRY.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdENTRY.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grdENTRY.BackgroundColor = System.Drawing.Color.White;
            this.grdENTRY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Semibold", 10.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdENTRY.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.grdENTRY.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdENTRY.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.acc_id,
            this.acc_name,
            this.debit,
            this.credit,
            this.inv_no,
            this.inv_of});
            this.grdENTRY.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdENTRY.DefaultCellStyle = dataGridViewCellStyle6;
            this.grdENTRY.Location = new System.Drawing.Point(528, 334);
            this.grdENTRY.Name = "grdENTRY";
            this.grdENTRY.ReadOnly = true;
            this.grdENTRY.RowHeadersVisible = false;
            this.grdENTRY.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdENTRY.Size = new System.Drawing.Size(561, 175);
            this.grdENTRY.TabIndex = 327;
            this.grdENTRY.TabStop = false;
            this.grdENTRY.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdENTRY_CellClick);
            this.grdENTRY.Click += new System.EventHandler(this.grdENTRY_Click);
            // 
            // acc_id
            // 
            this.acc_id.HeaderText = "coa_id";
            this.acc_id.Name = "acc_id";
            this.acc_id.ReadOnly = true;
            this.acc_id.Visible = false;
            this.acc_id.Width = 55;
            // 
            // acc_name
            // 
            this.acc_name.HeaderText = "ACCOUNT";
            this.acc_name.Name = "acc_name";
            this.acc_name.ReadOnly = true;
            this.acc_name.Width = 101;
            // 
            // debit
            // 
            this.debit.HeaderText = "DEBIT";
            this.debit.Name = "debit";
            this.debit.ReadOnly = true;
            this.debit.Width = 71;
            // 
            // credit
            // 
            this.credit.HeaderText = "CREDIT";
            this.credit.Name = "credit";
            this.credit.ReadOnly = true;
            this.credit.Width = 81;
            // 
            // inv_no
            // 
            this.inv_no.HeaderText = "INVOICE #";
            this.inv_no.Name = "inv_no";
            this.inv_no.ReadOnly = true;
            this.inv_no.Visible = false;
            this.inv_no.Width = 101;
            // 
            // inv_of
            // 
            this.inv_of.HeaderText = "INVOICE OF";
            this.inv_of.Name = "inv_of";
            this.inv_of.ReadOnly = true;
            this.inv_of.Visible = false;
            this.inv_of.Width = 111;
            // 
            // cmbSELECT_INV
            // 
            this.cmbSELECT_INV.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSELECT_INV.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSELECT_INV.Enabled = false;
            this.cmbSELECT_INV.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbSELECT_INV.FormattingEnabled = true;
            this.cmbSELECT_INV.Items.AddRange(new object[] {
            "--SELECT INVOICE--"});
            this.cmbSELECT_INV.Location = new System.Drawing.Point(528, 272);
            this.cmbSELECT_INV.Name = "cmbSELECT_INV";
            this.cmbSELECT_INV.Size = new System.Drawing.Size(231, 25);
            this.cmbSELECT_INV.TabIndex = 330;
            this.cmbSELECT_INV.DropDown += new System.EventHandler(this.cmbSELECT_INV_DropDown);
            this.cmbSELECT_INV.TextUpdate += new System.EventHandler(this.cmbSELECT_INV_TextUpdate);
            this.cmbSELECT_INV.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmbSELECT_INV_PreviewKeyDown);
            // 
            // rdbOTHERS
            // 
            this.rdbOTHERS.AutoSize = true;
            this.rdbOTHERS.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.rdbOTHERS.Location = new System.Drawing.Point(1022, 243);
            this.rdbOTHERS.Name = "rdbOTHERS";
            this.rdbOTHERS.Size = new System.Drawing.Size(67, 21);
            this.rdbOTHERS.TabIndex = 329;
            this.rdbOTHERS.Text = "OTHER";
            this.rdbOTHERS.UseVisualStyleBackColor = true;
            this.rdbOTHERS.CheckedChanged += new System.EventHandler(this.rdbOTHERS_CheckedChanged);
            // 
            // rdbINV_REC
            // 
            this.rdbINV_REC.AutoSize = true;
            this.rdbINV_REC.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.rdbINV_REC.Location = new System.Drawing.Point(768, 243);
            this.rdbINV_REC.Name = "rdbINV_REC";
            this.rdbINV_REC.Size = new System.Drawing.Size(113, 21);
            this.rdbINV_REC.TabIndex = 328;
            this.rdbINV_REC.TabStop = true;
            this.rdbINV_REC.Text = "INVOICE / REC";
            this.rdbINV_REC.UseVisualStyleBackColor = true;
            this.rdbINV_REC.CheckedChanged += new System.EventHandler(this.rdbINV_REC_CheckedChanged);
            // 
            // rdbPAY
            // 
            this.rdbPAY.AutoSize = true;
            this.rdbPAY.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.rdbPAY.Location = new System.Drawing.Point(895, 243);
            this.rdbPAY.Name = "rdbPAY";
            this.rdbPAY.Size = new System.Drawing.Size(113, 21);
            this.rdbPAY.TabIndex = 331;
            this.rdbPAY.TabStop = true;
            this.rdbPAY.Text = "INVOICE / PAY";
            this.rdbPAY.UseVisualStyleBackColor = true;
            this.rdbPAY.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // lbl_SELECT_INV
            // 
            this.lbl_SELECT_INV.AutoSize = true;
            this.lbl_SELECT_INV.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lbl_SELECT_INV.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_SELECT_INV.Location = new System.Drawing.Point(420, 277);
            this.lbl_SELECT_INV.Name = "lbl_SELECT_INV";
            this.lbl_SELECT_INV.Size = new System.Drawing.Size(99, 15);
            this.lbl_SELECT_INV.TabIndex = 332;
            this.lbl_SELECT_INV.Text = "SELECT INVOICE:";
            // 
            // btn_VIEW_VOUCHER
            // 
            this.btn_VIEW_VOUCHER.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(24)))), ((int)(((byte)(38)))));
            this.btn_VIEW_VOUCHER.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_VIEW_VOUCHER.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_VIEW_VOUCHER.ForeColor = System.Drawing.Color.White;
            this.btn_VIEW_VOUCHER.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_VIEW_VOUCHER.ImageIndex = 2;
            this.btn_VIEW_VOUCHER.ImageList = this.imageList1;
            this.btn_VIEW_VOUCHER.Location = new System.Drawing.Point(528, 515);
            this.btn_VIEW_VOUCHER.Name = "btn_VIEW_VOUCHER";
            this.btn_VIEW_VOUCHER.Size = new System.Drawing.Size(231, 25);
            this.btn_VIEW_VOUCHER.TabIndex = 333;
            this.btn_VIEW_VOUCHER.Text = "VIEW VOUCHER";
            this.btn_VIEW_VOUCHER.UseVisualStyleBackColor = false;
            this.btn_VIEW_VOUCHER.Click += new System.EventHandler(this.btn_VIEW_VOUCHER_Click);
            // 
            // frm_General_Voucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1101, 546);
            this.Controls.Add(this.btn_VIEW_VOUCHER);
            this.Controls.Add(this.lbl_SELECT_INV);
            this.Controls.Add(this.rdbPAY);
            this.Controls.Add(this.cmbSELECT_INV);
            this.Controls.Add(this.rdbOTHERS);
            this.Controls.Add(this.rdbINV_REC);
            this.Controls.Add(this.grdENTRY);
            this.Controls.Add(this.btnADD);
            this.Controls.Add(this.txtCREDIT);
            this.Controls.Add(this.lblCREDIT);
            this.Controls.Add(this.cmbACCOUNT);
            this.Controls.Add(this.lblTrNo);
            this.Controls.Add(this.lblTr);
            this.Controls.Add(this.dtp_DATE);
            this.Controls.Add(this.lblTV);
            this.Controls.Add(this.txtNar);
            this.Controls.Add(this.lblNar);
            this.Controls.Add(this.txtDEBIT);
            this.Controls.Add(this.lblACCOUNT);
            this.Controls.Add(this.btnCLEAR);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblDEBIT);
            this.Controls.Add(this.btnSAVE);
            this.Controls.Add(this.lblV);
            this.Controls.Add(this.grdSEARCH);
            this.Controls.Add(this.txtSEARCH);
            this.Controls.Add(this.lblSEARCH);
            this.Controls.Add(this.pnlHEADER);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_General_Voucher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JOURNAL VOUCHER";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_General_Voucher_FormClosed);
            this.Load += new System.EventHandler(this.frm_BankTr_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSEARCH)).EndInit();
            this.pnlHEADER.ResumeLayout(false);
            this.pnlHEADER.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdENTRY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox15;
        private SergeUtils.EasyCompletionComboBox cmbACCOUNT;
        private System.Windows.Forms.Label lblTrNo;
        private System.Windows.Forms.Label lblTr;
        private System.Windows.Forms.DateTimePicker dtp_DATE;
        private System.Windows.Forms.Label lblTV;
        private System.Windows.Forms.Label lblHEADING;
        private System.Windows.Forms.TextBox txtNar;
        private System.Windows.Forms.Label lblNar;
        private System.Windows.Forms.TextBox txtDEBIT;
        private System.Windows.Forms.Label lblACCOUNT;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnCLEAR;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblDEBIT;
        private System.Windows.Forms.Button btnSAVE;
        private System.Windows.Forms.Label lblV;
        private System.Windows.Forms.DataGridView grdSEARCH;
        private System.Windows.Forms.TextBox txtSEARCH;
        private System.Windows.Forms.Label lblSEARCH;
        private System.Windows.Forms.Panel pnlHEADER;
        private System.Windows.Forms.TextBox txtCREDIT;
        private System.Windows.Forms.Label lblCREDIT;
        private System.Windows.Forms.Button btnADD;
        private System.Windows.Forms.DataGridView grdENTRY;
        private SergeUtils.EasyCompletionComboBox cmbSELECT_INV;
        private System.Windows.Forms.RadioButton rdbOTHERS;
        private System.Windows.Forms.RadioButton rdbINV_REC;
        private System.Windows.Forms.RadioButton rdbPAY;
        private System.Windows.Forms.Label lbl_SELECT_INV;
        private System.Windows.Forms.DataGridViewTextBoxColumn acc_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn acc_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn debit;
        private System.Windows.Forms.DataGridViewTextBoxColumn credit;
        private System.Windows.Forms.DataGridViewTextBoxColumn inv_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn inv_of;
        private System.Windows.Forms.Button btn_VIEW_VOUCHER;
    }
}