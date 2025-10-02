namespace ERP_Maaz_Oil.Forms.Reporting
{
    partial class frm_CustomerProfileReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_CustomerProfileReport));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmbCustName = new SergeUtils.EasyCompletionComboBox();
            this.lblAC_NAME = new System.Windows.Forms.Label();
            this.lblFROM = new System.Windows.Forms.Label();
            this.btnSHOW = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lblITO = new System.Windows.Forms.Label();
            this.FOLIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.debit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.a_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_nature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdSEARCH = new System.Windows.Forms.DataGridView();
            this.credit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpCASHBOOK = new System.Windows.Forms.GroupBox();
            this.cmbArea = new SergeUtils.EasyCompletionComboBox();
            this.cmbCity = new SergeUtils.EasyCompletionComboBox();
            this.cmbSalesPerson = new SergeUtils.EasyCompletionComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.lblHEADING = new System.Windows.Forms.Label();
            this.pnlHEADER = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.grdSEARCH)).BeginInit();
            this.grpCASHBOOK.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
            this.pnlHEADER.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbCustName
            // 
            this.cmbCustName.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbCustName.FormattingEnabled = true;
            this.cmbCustName.Location = new System.Drawing.Point(120, 24);
            this.cmbCustName.Name = "cmbCustName";
            this.cmbCustName.Size = new System.Drawing.Size(231, 25);
            this.cmbCustName.TabIndex = 0;
            // 
            // lblAC_NAME
            // 
            this.lblAC_NAME.AutoSize = true;
            this.lblAC_NAME.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblAC_NAME.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblAC_NAME.Location = new System.Drawing.Point(5, 29);
            this.lblAC_NAME.Name = "lblAC_NAME";
            this.lblAC_NAME.Size = new System.Drawing.Size(109, 15);
            this.lblAC_NAME.TabIndex = 121;
            this.lblAC_NAME.Text = "CUSTOMER NAME:";
            // 
            // lblFROM
            // 
            this.lblFROM.AutoSize = true;
            this.lblFROM.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblFROM.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblFROM.Location = new System.Drawing.Point(22, 60);
            this.lblFROM.Name = "lblFROM";
            this.lblFROM.Size = new System.Drawing.Size(92, 15);
            this.lblFROM.TabIndex = 118;
            this.lblFROM.Text = "SALES PERSON:";
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
            this.btnSHOW.Location = new System.Drawing.Point(114, 166);
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
            // lblITO
            // 
            this.lblITO.AutoSize = true;
            this.lblITO.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblITO.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblITO.Location = new System.Drawing.Point(75, 91);
            this.lblITO.Name = "lblITO";
            this.lblITO.Size = new System.Drawing.Size(35, 15);
            this.lblITO.TabIndex = 46;
            this.lblITO.Text = "CITY:";
            // 
            // FOLIO
            // 
            this.FOLIO.HeaderText = "FOLIO";
            this.FOLIO.Name = "FOLIO";
            this.FOLIO.ReadOnly = true;
            this.FOLIO.Width = 70;
            // 
            // dc
            // 
            this.dc.HeaderText = "Dr / Cr";
            this.dc.Name = "dc";
            this.dc.ReadOnly = true;
            this.dc.Width = 73;
            // 
            // bal
            // 
            this.bal.HeaderText = "BALANCE";
            this.bal.Name = "bal";
            this.bal.ReadOnly = true;
            this.bal.Width = 90;
            // 
            // debit
            // 
            this.debit.HeaderText = "DEBIT";
            this.debit.Name = "debit";
            this.debit.ReadOnly = true;
            this.debit.Width = 68;
            // 
            // a_name
            // 
            this.a_name.HeaderText = "DESCRIPTION";
            this.a_name.Name = "a_name";
            this.a_name.ReadOnly = true;
            this.a_name.Width = 115;
            // 
            // s_nature
            // 
            this.s_nature.HeaderText = "DATE";
            this.s_nature.Name = "s_nature";
            this.s_nature.ReadOnly = true;
            this.s_nature.Width = 64;
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
            // credit
            // 
            this.credit.HeaderText = "CREDIT";
            this.credit.Name = "credit";
            this.credit.ReadOnly = true;
            this.credit.Width = 76;
            // 
            // grpCASHBOOK
            // 
            this.grpCASHBOOK.Controls.Add(this.grdSEARCH);
            this.grpCASHBOOK.Controls.Add(this.cmbArea);
            this.grpCASHBOOK.Controls.Add(this.cmbCity);
            this.grpCASHBOOK.Controls.Add(this.cmbSalesPerson);
            this.grpCASHBOOK.Controls.Add(this.cmbCustName);
            this.grpCASHBOOK.Controls.Add(this.lblAC_NAME);
            this.grpCASHBOOK.Controls.Add(this.lblFROM);
            this.grpCASHBOOK.Controls.Add(this.btnSHOW);
            this.grpCASHBOOK.Controls.Add(this.label1);
            this.grpCASHBOOK.Controls.Add(this.lblITO);
            this.grpCASHBOOK.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpCASHBOOK.Location = new System.Drawing.Point(12, 94);
            this.grpCASHBOOK.Name = "grpCASHBOOK";
            this.grpCASHBOOK.Size = new System.Drawing.Size(377, 197);
            this.grpCASHBOOK.TabIndex = 39;
            this.grpCASHBOOK.TabStop = false;
            this.grpCASHBOOK.Text = "CUSTOMER PROFILE REPORT";
            // 
            // cmbArea
            // 
            this.cmbArea.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbArea.FormattingEnabled = true;
            this.cmbArea.Location = new System.Drawing.Point(120, 118);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(231, 25);
            this.cmbArea.TabIndex = 0;
            // 
            // cmbCity
            // 
            this.cmbCity.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbCity.FormattingEnabled = true;
            this.cmbCity.Location = new System.Drawing.Point(120, 87);
            this.cmbCity.Name = "cmbCity";
            this.cmbCity.Size = new System.Drawing.Size(231, 25);
            this.cmbCity.TabIndex = 0;
            // 
            // cmbSalesPerson
            // 
            this.cmbSalesPerson.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbSalesPerson.FormattingEnabled = true;
            this.cmbSalesPerson.Location = new System.Drawing.Point(120, 55);
            this.cmbSalesPerson.Name = "cmbSalesPerson";
            this.cmbSalesPerson.Size = new System.Drawing.Size(231, 25);
            this.cmbSalesPerson.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(75, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 46;
            this.label1.Text = "AREA:";
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
            this.lblHEADING.Location = new System.Drawing.Point(3, 55);
            this.lblHEADING.Name = "lblHEADING";
            this.lblHEADING.Size = new System.Drawing.Size(213, 18);
            this.lblHEADING.TabIndex = 23;
            this.lblHEADING.Text = "CUSTOMER PROFILE REPORT";
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
            this.pnlHEADER.Size = new System.Drawing.Size(407, 88);
            this.pnlHEADER.TabIndex = 38;
            // 
            // frm_CustomerProfileReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 303);
            this.Controls.Add(this.grpCASHBOOK);
            this.Controls.Add(this.pnlHEADER);
            this.Name = "frm_CustomerProfileReport";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CUSTOMER PROFILE REPORT";
            this.Load += new System.EventHandler(this.frm_CustomerProfileReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdSEARCH)).EndInit();
            this.grpCASHBOOK.ResumeLayout(false);
            this.grpCASHBOOK.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
            this.pnlHEADER.ResumeLayout(false);
            this.pnlHEADER.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SergeUtils.EasyCompletionComboBox cmbCustName;
        private System.Windows.Forms.Label lblAC_NAME;
        private System.Windows.Forms.Label lblFROM;
        private System.Windows.Forms.Button btnSHOW;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lblITO;
        private System.Windows.Forms.DataGridViewTextBoxColumn FOLIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn dc;
        private System.Windows.Forms.DataGridViewTextBoxColumn bal;
        private System.Windows.Forms.DataGridViewTextBoxColumn debit;
        private System.Windows.Forms.DataGridViewTextBoxColumn a_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_nature;
        private System.Windows.Forms.DataGridView grdSEARCH;
        private System.Windows.Forms.DataGridViewTextBoxColumn credit;
        private System.Windows.Forms.GroupBox grpCASHBOOK;
        private System.Windows.Forms.PictureBox pictureBox15;
        private System.Windows.Forms.PictureBox pictureBox14;
        private System.Windows.Forms.Label lblHEADING;
        private System.Windows.Forms.Panel pnlHEADER;
        private System.Windows.Forms.Label label1;
        private SergeUtils.EasyCompletionComboBox cmbArea;
        private SergeUtils.EasyCompletionComboBox cmbCity;
        private SergeUtils.EasyCompletionComboBox cmbSalesPerson;
    }
}