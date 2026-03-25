namespace ERP_Maaz_Oil.Forms
{
    partial class frmAddLocation
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddLocation));
            this.grdSEARCH = new System.Windows.Forms.DataGridView();
            this.txtSEARCH = new System.Windows.Forms.TextBox();
            this.lblSEARCH = new System.Windows.Forms.Label();
            this.lblNAME = new System.Windows.Forms.Label();
            this.txtNAME = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lblID = new System.Windows.Forms.Label();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
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
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.grdSEARCH.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.grdSEARCH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdSEARCH.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grdSEARCH.BackgroundColor = System.Drawing.Color.White;
            this.grdSEARCH.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Semibold", 10.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdSEARCH.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.grdSEARCH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdSEARCH.DefaultCellStyle = dataGridViewCellStyle6;
            this.grdSEARCH.Location = new System.Drawing.Point(-1, 85);
            this.grdSEARCH.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grdSEARCH.Name = "grdSEARCH";
            this.grdSEARCH.ReadOnly = true;
            this.grdSEARCH.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSEARCH.Size = new System.Drawing.Size(509, 230);
            this.grdSEARCH.TabIndex = 5;
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
            this.txtSEARCH.Location = new System.Drawing.Point(88, 48);
            this.txtSEARCH.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSEARCH.Name = "txtSEARCH";
            this.txtSEARCH.Size = new System.Drawing.Size(403, 29);
            this.txtSEARCH.TabIndex = 0;
            this.txtSEARCH.TextChanged += new System.EventHandler(this.txtSEARCH_TextChanged);
            // 
            // lblSEARCH
            // 
            this.lblSEARCH.AutoSize = true;
            this.lblSEARCH.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblSEARCH.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSEARCH.Location = new System.Drawing.Point(7, 53);
            this.lblSEARCH.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSEARCH.Name = "lblSEARCH";
            this.lblSEARCH.Size = new System.Drawing.Size(64, 20);
            this.lblSEARCH.TabIndex = 24;
            this.lblSEARCH.Text = "SEARCH";
            // 
            // lblNAME
            // 
            this.lblNAME.AutoSize = true;
            this.lblNAME.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblNAME.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblNAME.Location = new System.Drawing.Point(5, 368);
            this.lblNAME.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNAME.Name = "lblNAME";
            this.lblNAME.Size = new System.Drawing.Size(84, 20);
            this.lblNAME.TabIndex = 37;
            this.lblNAME.Text = "LOCATION:";
            // 
            // txtNAME
            // 
            this.txtNAME.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNAME.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtNAME.Location = new System.Drawing.Point(109, 362);
            this.txtNAME.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNAME.MaxLength = 100;
            this.txtNAME.Name = "txtNAME";
            this.txtNAME.Size = new System.Drawing.Size(372, 29);
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
            this.lblID.Location = new System.Drawing.Point(7, 348);
            this.lblID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(0, 23);
            this.lblID.TabIndex = 136;
            this.lblID.Visible = false;
            // 
            // cmbLocation
            // 
            this.cmbLocation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbLocation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbLocation.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(109, 322);
            this.cmbLocation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(339, 29);
            this.cmbLocation.TabIndex = 1;
            this.cmbLocation.DropDown += new System.EventHandler(this.cmbRINCIDENT_DropDown);
            this.cmbLocation.TextUpdate += new System.EventHandler(this.cmbRINCIDENT_TextUpdate);
            this.cmbLocation.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmbRINCIDENT_PreviewKeyDown);
            // 
            // lblRINCIDENT
            // 
            this.lblRINCIDENT.AutoSize = true;
            this.lblRINCIDENT.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblRINCIDENT.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblRINCIDENT.Location = new System.Drawing.Point(5, 329);
            this.lblRINCIDENT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRINCIDENT.Name = "lblRINCIDENT";
            this.lblRINCIDENT.Size = new System.Drawing.Size(43, 20);
            this.lblRINCIDENT.TabIndex = 202;
            this.lblRINCIDENT.Text = "CITY:";
            // 
            // btn_R_ADD_INCIDENT
            // 
            this.btn_R_ADD_INCIDENT.BackColor = System.Drawing.Color.Transparent;
            this.btn_R_ADD_INCIDENT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btn_R_ADD_INCIDENT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_R_ADD_INCIDENT.Image = global::ERP_Maaz_Oil.Properties.Resources.plus;
            this.btn_R_ADD_INCIDENT.Location = new System.Drawing.Point(449, 322);
            this.btn_R_ADD_INCIDENT.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_R_ADD_INCIDENT.Name = "btn_R_ADD_INCIDENT";
            this.btn_R_ADD_INCIDENT.Size = new System.Drawing.Size(33, 30);
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
            this.btnCLEAR.Location = new System.Drawing.Point(297, 400);
            this.btnCLEAR.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCLEAR.Name = "btnCLEAR";
            this.btnCLEAR.Size = new System.Drawing.Size(155, 31);
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
            this.btnSAVE.Location = new System.Drawing.Point(147, 400);
            this.btnSAVE.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSAVE.Name = "btnSAVE";
            this.btnSAVE.Size = new System.Drawing.Size(155, 31);
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
            this.pnlHEADER.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlHEADER.Name = "pnlHEADER";
            this.pnlHEADER.Size = new System.Drawing.Size(508, 34);
            this.pnlHEADER.TabIndex = 35;
            // 
            // pictureBox15
            // 
            this.pictureBox15.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox15.Location = new System.Drawing.Point(1787, 4);
            this.pictureBox15.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox15.Name = "pictureBox15";
            this.pictureBox15.Size = new System.Drawing.Size(65, 25);
            this.pictureBox15.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox15.TabIndex = 25;
            this.pictureBox15.TabStop = false;
            // 
            // pictureBox14
            // 
            this.pictureBox14.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox14.Location = new System.Drawing.Point(1713, 4);
            this.pictureBox14.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox14.Name = "pictureBox14";
            this.pictureBox14.Size = new System.Drawing.Size(65, 25);
            this.pictureBox14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox14.TabIndex = 24;
            this.pictureBox14.TabStop = false;
            // 
            // lblHEADING
            // 
            this.lblHEADING.AutoSize = true;
            this.lblHEADING.BackColor = System.Drawing.Color.Transparent;
            this.lblHEADING.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.75F);
            this.lblHEADING.ForeColor = System.Drawing.Color.White;
            this.lblHEADING.Location = new System.Drawing.Point(4, 5);
            this.lblHEADING.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHEADING.Name = "lblHEADING";
            this.lblHEADING.Size = new System.Drawing.Size(163, 25);
            this.lblHEADING.TabIndex = 23;
            this.lblHEADING.Text = "ADD LOCATION";
            // 
            // frmAddLocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(508, 446);
            this.Controls.Add(this.btn_R_ADD_INCIDENT);
            this.Controls.Add(this.cmbLocation);
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
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmAddLocation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ADD LOCATION";
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
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.Label lblRINCIDENT;
    }
}