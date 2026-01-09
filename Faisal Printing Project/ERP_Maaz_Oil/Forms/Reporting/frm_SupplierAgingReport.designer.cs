namespace ERP_Maaz_Oil.Forms.Reporting
{
    partial class frm_SupplierAgingReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_SupplierAgingReport));
            this.pnlHEADER = new System.Windows.Forms.Panel();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.lblHEADING = new System.Windows.Forms.Label();
            this.grpCASHBOOK = new System.Windows.Forms.GroupBox();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.rdbSupplier = new System.Windows.Forms.RadioButton();
            this.rdbDueDate = new System.Windows.Forms.RadioButton();
            this.rdbOverAll = new System.Windows.Forms.RadioButton();
            this.cmbSupplier = new SergeUtils.EasyCompletionComboBox();
            this.btnSHOW = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pnlHEADER.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
            this.grpCASHBOOK.SuspendLayout();
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
            this.pnlHEADER.Size = new System.Drawing.Size(340, 88);
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
            this.lblHEADING.Font = new System.Drawing.Font("Berlin Sans FB", 14.75F);
            this.lblHEADING.ForeColor = System.Drawing.Color.White;
            this.lblHEADING.Location = new System.Drawing.Point(2, 18);
            this.lblHEADING.Name = "lblHEADING";
            this.lblHEADING.Size = new System.Drawing.Size(146, 46);
            this.lblHEADING.TabIndex = 23;
            this.lblHEADING.Text = "SUPPLIER \r\nAGING REPORT";
            // 
            // grpCASHBOOK
            // 
            this.grpCASHBOOK.Controls.Add(this.dtpDueDate);
            this.grpCASHBOOK.Controls.Add(this.rdbSupplier);
            this.grpCASHBOOK.Controls.Add(this.rdbDueDate);
            this.grpCASHBOOK.Controls.Add(this.rdbOverAll);
            this.grpCASHBOOK.Controls.Add(this.cmbSupplier);
            this.grpCASHBOOK.Controls.Add(this.btnSHOW);
            this.grpCASHBOOK.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpCASHBOOK.Location = new System.Drawing.Point(0, 90);
            this.grpCASHBOOK.Name = "grpCASHBOOK";
            this.grpCASHBOOK.Size = new System.Drawing.Size(340, 115);
            this.grpCASHBOOK.TabIndex = 1;
            this.grpCASHBOOK.TabStop = false;
            this.grpCASHBOOK.Text = "AGING REPORT";
            this.grpCASHBOOK.Enter += new System.EventHandler(this.grpSALES_Enter);
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.CustomFormat = "dd/MM/yyyy";
            this.dtpDueDate.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDueDate.Location = new System.Drawing.Point(137, 55);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(197, 23);
            this.dtpDueDate.TabIndex = 2;
            // 
            // rdbSupplier
            // 
            this.rdbSupplier.AutoSize = true;
            this.rdbSupplier.Location = new System.Drawing.Point(7, 26);
            this.rdbSupplier.Name = "rdbSupplier";
            this.rdbSupplier.Size = new System.Drawing.Size(86, 21);
            this.rdbSupplier.TabIndex = 129;
            this.rdbSupplier.Text = "SUPPLIER:";
            this.rdbSupplier.UseVisualStyleBackColor = true;
            this.rdbSupplier.CheckedChanged += new System.EventHandler(this.rdbCustomer_CheckedChanged);
            // 
            // rdbDueDate
            // 
            this.rdbDueDate.AutoSize = true;
            this.rdbDueDate.Location = new System.Drawing.Point(7, 55);
            this.rdbDueDate.Name = "rdbDueDate";
            this.rdbDueDate.Size = new System.Drawing.Size(126, 21);
            this.rdbDueDate.TabIndex = 1;
            this.rdbDueDate.Text = "DUE DATE UPTO:";
            this.rdbDueDate.UseVisualStyleBackColor = true;
            this.rdbDueDate.CheckedChanged += new System.EventHandler(this.rdbProvince_CheckedChanged);
            // 
            // rdbOverAll
            // 
            this.rdbOverAll.AutoSize = true;
            this.rdbOverAll.Checked = true;
            this.rdbOverAll.Location = new System.Drawing.Point(7, 86);
            this.rdbOverAll.Name = "rdbOverAll";
            this.rdbOverAll.Size = new System.Drawing.Size(80, 21);
            this.rdbOverAll.TabIndex = 3;
            this.rdbOverAll.TabStop = true;
            this.rdbOverAll.Text = "OVERALL";
            this.rdbOverAll.UseVisualStyleBackColor = true;
            this.rdbOverAll.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.Enabled = false;
            this.cmbSupplier.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbSupplier.FormattingEnabled = true;
            this.cmbSupplier.Location = new System.Drawing.Point(137, 24);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(197, 25);
            this.cmbSupplier.TabIndex = 0;
            this.cmbSupplier.DropDown += new System.EventHandler(this.cmbCustomer_DropDown);
            this.cmbSupplier.TextUpdate += new System.EventHandler(this.cmbSalePerson_TextUpdate);
            this.cmbSupplier.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmbCustomer_PreviewKeyDown);
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
            this.btnSHOW.Location = new System.Drawing.Point(137, 84);
            this.btnSHOW.Name = "btnSHOW";
            this.btnSHOW.Size = new System.Drawing.Size(197, 25);
            this.btnSHOW.TabIndex = 4;
            this.btnSHOW.Text = "SHOW";
            this.btnSHOW.UseVisualStyleBackColor = false;
            this.btnSHOW.Click += new System.EventHandler(this.btnINTER_SAVE_Click);
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
            // frm_SupplierAgingReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(340, 207);
            this.Controls.Add(this.grpCASHBOOK);
            this.Controls.Add(this.pnlHEADER);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(356, 246);
            this.Name = "frm_SupplierAgingReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SUPPLIER AGING REPORT";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_Account_Ledger_FormClosed);
            this.Load += new System.EventHandler(this.frm_Account_Ledger_Load);
            this.pnlHEADER.ResumeLayout(false);
            this.pnlHEADER.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
            this.grpCASHBOOK.ResumeLayout(false);
            this.grpCASHBOOK.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHEADER;
        private System.Windows.Forms.PictureBox pictureBox15;
        private System.Windows.Forms.PictureBox pictureBox14;
        private System.Windows.Forms.Label lblHEADING;
        private System.Windows.Forms.GroupBox grpCASHBOOK;
        private System.Windows.Forms.Button btnSHOW;
        private System.Windows.Forms.ImageList imageList1;
        private SergeUtils.EasyCompletionComboBox cmbSupplier;
        private System.Windows.Forms.RadioButton rdbSupplier;
        private System.Windows.Forms.RadioButton rdbDueDate;
        private System.Windows.Forms.RadioButton rdbOverAll;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
    }
}