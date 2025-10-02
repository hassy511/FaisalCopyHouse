namespace ERP_Maaz_Oil.Forms
{
    partial class frmAddArea
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddArea));
            this.grdSEARCH = new System.Windows.Forms.DataGridView();
            this.txtSEARCH = new System.Windows.Forms.TextBox();
            this.lblSEARCH = new System.Windows.Forms.Label();
            this.lblNAME = new System.Windows.Forms.Label();
            this.txtNAME = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lblID = new System.Windows.Forms.Label();
            this.cmbCITY = new SergeUtils.EasyCompletionComboBox();
            this.lblRINCIDENT = new System.Windows.Forms.Label();
            this.btn_R_ADD_INCIDENT = new System.Windows.Forms.PictureBox();
            this.btnCLEAR = new System.Windows.Forms.Button();
            this.btnSAVE = new System.Windows.Forms.Button();
            this.pnlHEADER = new System.Windows.Forms.Panel();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.lblHEADING = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdSEARCH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_R_ADD_INCIDENT)).BeginInit();
            this.pnlHEADER.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
            this.SuspendLayout();
            // 
            // grdSEARCH
            // 
            this.grdSEARCH.AllowUserToAddRows = false;
            this.grdSEARCH.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.grdSEARCH.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdSEARCH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdSEARCH.DefaultCellStyle = dataGridViewCellStyle3;
            this.grdSEARCH.Location = new System.Drawing.Point(-1, 97);
            this.grdSEARCH.Name = "grdSEARCH";
            this.grdSEARCH.ReadOnly = true;
            this.grdSEARCH.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSEARCH.Size = new System.Drawing.Size(382, 201);
            this.grdSEARCH.TabIndex = 26;
            this.grdSEARCH.TabStop = false;
            this.grdSEARCH.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdSEARCH_CellClick);
            this.grdSEARCH.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.grdSEARCH_ColumnAdded);
            this.grdSEARCH.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.grdSEARCH_DataBindingComplete);
            this.grdSEARCH.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.grdSEARCH_RowPostPaint);
            // 
            // txtSEARCH
            // 
            this.txtSEARCH.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSEARCH.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtSEARCH.Location = new System.Drawing.Point(66, 66);
            this.txtSEARCH.Name = "txtSEARCH";
            this.txtSEARCH.Size = new System.Drawing.Size(303, 25);
            this.txtSEARCH.TabIndex = 25;
            this.txtSEARCH.TextChanged += new System.EventHandler(this.txtSEARCH_TextChanged);
            // 
            // lblSEARCH
            // 
            this.lblSEARCH.AutoSize = true;
            this.lblSEARCH.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblSEARCH.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSEARCH.Location = new System.Drawing.Point(5, 70);
            this.lblSEARCH.Name = "lblSEARCH";
            this.lblSEARCH.Size = new System.Drawing.Size(51, 15);
            this.lblSEARCH.TabIndex = 24;
            this.lblSEARCH.Text = "SEARCH";
            // 
            // lblNAME
            // 
            this.lblNAME.AutoSize = true;
            this.lblNAME.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblNAME.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblNAME.Location = new System.Drawing.Point(4, 341);
            this.lblNAME.Name = "lblNAME";
            this.lblNAME.Size = new System.Drawing.Size(36, 15);
            this.lblNAME.TabIndex = 37;
            this.lblNAME.Text = "AREA";
            // 
            // txtNAME
            // 
            this.txtNAME.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNAME.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtNAME.Location = new System.Drawing.Point(82, 336);
            this.txtNAME.MaxLength = 100;
            this.txtNAME.Name = "txtNAME";
            this.txtNAME.Size = new System.Drawing.Size(280, 25);
            this.txtNAME.TabIndex = 2;
            this.txtNAME.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtNAME_MouseClick);
            this.txtNAME.Enter += new System.EventHandler(this.txtNAME_Enter);
            this.txtNAME.Leave += new System.EventHandler(this.txtNAME_Leave);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icons8-Save as Filled-100.png");
            this.imageList1.Images.SetKeyName(1, "icons8-Cancel Filled-100.png");
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblID.Location = new System.Drawing.Point(5, 283);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(0, 17);
            this.lblID.TabIndex = 136;
            this.lblID.Visible = false;
            // 
            // cmbCITY
            // 
            this.cmbCITY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCITY.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCITY.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbCITY.FormattingEnabled = true;
            this.cmbCITY.Location = new System.Drawing.Point(82, 304);
            this.cmbCITY.Name = "cmbCITY";
            this.cmbCITY.Size = new System.Drawing.Size(255, 25);
            this.cmbCITY.TabIndex = 1;
            this.cmbCITY.DropDown += new System.EventHandler(this.cmbRINCIDENT_DropDown);
            this.cmbCITY.TextUpdate += new System.EventHandler(this.cmbRINCIDENT_TextUpdate);
            this.cmbCITY.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmbRINCIDENT_PreviewKeyDown);
            // 
            // lblRINCIDENT
            // 
            this.lblRINCIDENT.AutoSize = true;
            this.lblRINCIDENT.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblRINCIDENT.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblRINCIDENT.Location = new System.Drawing.Point(4, 309);
            this.lblRINCIDENT.Name = "lblRINCIDENT";
            this.lblRINCIDENT.Size = new System.Drawing.Size(35, 15);
            this.lblRINCIDENT.TabIndex = 202;
            this.lblRINCIDENT.Text = "CITY:";
            // 
            // btn_R_ADD_INCIDENT
            // 
            this.btn_R_ADD_INCIDENT.BackColor = System.Drawing.Color.Transparent;
            this.btn_R_ADD_INCIDENT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btn_R_ADD_INCIDENT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_R_ADD_INCIDENT.Image = global::ERP_Maaz_Oil.Properties.Resources.plus;
            this.btn_R_ADD_INCIDENT.Location = new System.Drawing.Point(337, 304);
            this.btn_R_ADD_INCIDENT.Name = "btn_R_ADD_INCIDENT";
            this.btn_R_ADD_INCIDENT.Size = new System.Drawing.Size(25, 25);
            this.btn_R_ADD_INCIDENT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_R_ADD_INCIDENT.TabIndex = 203;
            this.btn_R_ADD_INCIDENT.TabStop = false;
            this.btn_R_ADD_INCIDENT.Click += new System.EventHandler(this.btn_R_ADD_INCIDENT_Click);
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
            this.btnCLEAR.Location = new System.Drawing.Point(223, 367);
            this.btnCLEAR.Name = "btnCLEAR";
            this.btnCLEAR.Size = new System.Drawing.Size(116, 25);
            this.btnCLEAR.TabIndex = 4;
            this.btnCLEAR.Text = "CLEAR";
            this.btnCLEAR.UseVisualStyleBackColor = false;
            this.btnCLEAR.Click += new System.EventHandler(this.btnCLEAR_Click);
            // 
            // btnSAVE
            // 
            this.btnSAVE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(68)))), ((int)(((byte)(2)))));
            this.btnSAVE.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSAVE.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSAVE.ForeColor = System.Drawing.Color.White;
            this.btnSAVE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSAVE.ImageIndex = 0;
            this.btnSAVE.ImageList = this.imageList1;
            this.btnSAVE.Location = new System.Drawing.Point(110, 367);
            this.btnSAVE.Name = "btnSAVE";
            this.btnSAVE.Size = new System.Drawing.Size(116, 25);
            this.btnSAVE.TabIndex = 3;
            this.btnSAVE.Text = "SAVE";
            this.btnSAVE.UseVisualStyleBackColor = false;
            this.btnSAVE.Click += new System.EventHandler(this.btnSAVE_Click);
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
            this.pnlHEADER.Size = new System.Drawing.Size(381, 57);
            this.pnlHEADER.TabIndex = 35;
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
            this.lblHEADING.Font = new System.Drawing.Font("Berlin Sans FB", 11.75F);
            this.lblHEADING.ForeColor = System.Drawing.Color.White;
            this.lblHEADING.Location = new System.Drawing.Point(11, 17);
            this.lblHEADING.Name = "lblHEADING";
            this.lblHEADING.Size = new System.Drawing.Size(86, 18);
            this.lblHEADING.TabIndex = 23;
            this.lblHEADING.Text = "ADD AREA";
            // 
            // frmAddArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(381, 425);
            this.Controls.Add(this.btn_R_ADD_INCIDENT);
            this.Controls.Add(this.cmbCITY);
            this.Controls.Add(this.lblRINCIDENT);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.btnCLEAR);
            this.Controls.Add(this.btnSAVE);
            this.Controls.Add(this.txtNAME);
            this.Controls.Add(this.grdSEARCH);
            this.Controls.Add(this.txtSEARCH);
            this.Controls.Add(this.lblSEARCH);
            this.Controls.Add(this.lblNAME);
            this.Controls.Add(this.pnlHEADER);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAddArea";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ADD AREA";
            this.Load += new System.EventHandler(this.frm_Add_Data_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdSEARCH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_R_ADD_INCIDENT)).EndInit();
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
        private System.Windows.Forms.Label lblSEARCH;
        private System.Windows.Forms.TextBox txtSEARCH;
        private System.Windows.Forms.DataGridView grdSEARCH;
        private System.Windows.Forms.Label lblNAME;
        private System.Windows.Forms.TextBox txtNAME;
        private System.Windows.Forms.Button btnCLEAR;
        private System.Windows.Forms.Button btnSAVE;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.PictureBox btn_R_ADD_INCIDENT;
        private SergeUtils.EasyCompletionComboBox cmbCITY;
        private System.Windows.Forms.Label lblRINCIDENT;
    }
}