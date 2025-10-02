namespace TestCombo
{
    partial class Form1
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
            this.m_label = new System.Windows.Forms.Label();
            this.m_combo = new SergeUtils.EasyCompletionComboBox();
            this.m_methodCB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // m_label
            // 
            this.m_label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_label.Location = new System.Drawing.Point(12, 76);
            this.m_label.Name = "m_label";
            this.m_label.Size = new System.Drawing.Size(333, 13);
            this.m_label.TabIndex = 2;
            this.m_label.Text = "Selection:";
            this.m_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.m_label.Click += new System.EventHandler(this.m_label_Click);
            // 
            // m_combo
            // 
            this.m_combo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_combo.FormattingEnabled = true;
            this.m_combo.Location = new System.Drawing.Point(12, 42);
            this.m_combo.Name = "m_combo";
            this.m_combo.Size = new System.Drawing.Size(333, 21);
            this.m_combo.TabIndex = 0;
            this.m_combo.SelectedIndexChanged += new System.EventHandler(this.onSelectionChanged);
            // 
            // m_methodCB
            // 
            this.m_methodCB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_methodCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_methodCB.FormattingEnabled = true;
            this.m_methodCB.Location = new System.Drawing.Point(110, 12);
            this.m_methodCB.Name = "m_methodCB";
            this.m_methodCB.Size = new System.Drawing.Size(235, 21);
            this.m_methodCB.TabIndex = 3;
            this.m_methodCB.SelectedIndexChanged += new System.EventHandler(this.m_methodCB_SelectedIndexChanged);
            this.m_methodCB.SelectionChangeCommitted += new System.EventHandler(this.onMethodChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Matching method:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 109);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_methodCB);
            this.Controls.Add(this.m_combo);
            this.Controls.Add(this.m_label);
            this.Name = "Form1";
            this.Text = "EasyCompletionComboBox Test";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.onKeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label m_label;
        private SergeUtils.EasyCompletionComboBox m_combo;
        private System.Windows.Forms.ComboBox m_methodCB;
        private System.Windows.Forms.Label label1;
    }
}

