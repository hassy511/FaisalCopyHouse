namespace ERP_Maaz_Oil.Forms
{
    partial class frmAddServiceTypes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddServiceTypes));
            this.grdSearch = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSEARCH = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.txtServiceType = new System.Windows.Forms.TextBox();
            this.lblBrand = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlHEADER = new System.Windows.Forms.Panel();
            this.lblHEADING = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearch)).BeginInit();
            this.pnlHEADER.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdSearch
            // 
            this.grdSearch.AllowUserToAddRows = false;
            this.grdSearch.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.grdSearch.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.grdSearch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdSearch.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grdSearch.BackgroundColor = System.Drawing.Color.White;
            this.grdSearch.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Semibold", 10.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdSearch.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.grdSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdSearch.DefaultCellStyle = dataGridViewCellStyle6;
            this.grdSearch.Location = new System.Drawing.Point(0, 82);
            this.grdSearch.Name = "grdSearch";
            this.grdSearch.ReadOnly = true;
            this.grdSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSearch.Size = new System.Drawing.Size(398, 238);
            this.grdSearch.TabIndex = 221;
            this.grdSearch.TabStop = false;
            this.grdSearch.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdSEARCH_CellClick);
            this.grdSearch.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.grdSEARCH_DataBindingComplete);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtSearch.Location = new System.Drawing.Point(72, 51);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(314, 25);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSEARCH_TextChanged);
            // 
            // lblSEARCH
            // 
            this.lblSEARCH.AutoSize = true;
            this.lblSEARCH.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSEARCH.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSEARCH.Location = new System.Drawing.Point(9, 55);
            this.lblSEARCH.Name = "lblSEARCH";
            this.lblSEARCH.Size = new System.Drawing.Size(57, 17);
            this.lblSEARCH.TabIndex = 219;
            this.lblSEARCH.Text = "SEARCH";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icons8-Save as Filled-100.png");
            this.imageList1.Images.SetKeyName(1, "icons8-Cancel Filled-100.png");
            // 
            // txtServiceType
            // 
            this.txtServiceType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtServiceType.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtServiceType.Location = new System.Drawing.Point(99, 326);
            this.txtServiceType.MaxLength = 32000;
            this.txtServiceType.Name = "txtServiceType";
            this.txtServiceType.Size = new System.Drawing.Size(287, 25);
            this.txtServiceType.TabIndex = 222;
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblBrand.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblBrand.Location = new System.Drawing.Point(9, 331);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(82, 15);
            this.lblBrand.TabIndex = 212;
            this.lblBrand.Text = "SERVICE TYPE";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.DimGray;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.ImageIndex = 1;
            this.btnClear.ImageList = this.imageList1;
            this.btnClear.Location = new System.Drawing.Point(270, 357);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(116, 25);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnCLEAR_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(68)))), ((int)(((byte)(2)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.ImageIndex = 0;
            this.btnSave.ImageList = this.imageList1;
            this.btnSave.Location = new System.Drawing.Point(155, 357);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(114, 25);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSAVE_Click);
            // 
            // pnlHEADER
            // 
            this.pnlHEADER.BackColor = System.Drawing.Color.Transparent;
            this.pnlHEADER.BackgroundImage = global::ERP_Maaz_Oil.Properties.Resources.header;
            this.pnlHEADER.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlHEADER.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHEADER.Controls.Add(this.lblHEADING);
            this.pnlHEADER.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHEADER.Location = new System.Drawing.Point(0, 0);
            this.pnlHEADER.Name = "pnlHEADER";
            this.pnlHEADER.Size = new System.Drawing.Size(398, 45);
            this.pnlHEADER.TabIndex = 36;
            // 
            // lblHEADING
            // 
            this.lblHEADING.AutoSize = true;
            this.lblHEADING.BackColor = System.Drawing.Color.Transparent;
            this.lblHEADING.Font = new System.Drawing.Font("Berlin Sans FB", 16.75F);
            this.lblHEADING.ForeColor = System.Drawing.Color.White;
            this.lblHEADING.Location = new System.Drawing.Point(3, 11);
            this.lblHEADING.Name = "lblHEADING";
            this.lblHEADING.Size = new System.Drawing.Size(152, 26);
            this.lblHEADING.TabIndex = 23;
            this.lblHEADING.Text = "SERVICE TYPE";
            // 
            // frmAddServiceTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(398, 389);
            this.Controls.Add(this.txtServiceType);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grdSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSEARCH);
            this.Controls.Add(this.lblBrand);
            this.Controls.Add(this.pnlHEADER);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(414, 428);
            this.Name = "frmAddServiceTypes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ADD SERVICE TYPE";
            this.Load += new System.EventHandler(this.frm_AddGroupAccounts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdSearch)).EndInit();
            this.pnlHEADER.ResumeLayout(false);
            this.pnlHEADER.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHEADER;
        private System.Windows.Forms.Label lblHEADING;
        private System.Windows.Forms.DataGridView grdSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSEARCH;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox txtServiceType;
        private System.Windows.Forms.Label lblBrand;
    }
}