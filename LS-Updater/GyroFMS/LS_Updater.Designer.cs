namespace LS_Updater
{
    partial class LS_Updater
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.progressBar = new CircularProgressBar.CircularProgressBar();
            this.iteckLogo = new System.Windows.Forms.PictureBox();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iteckLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.Controls.Add(this.lblStatus);
            this.pnlMain.Controls.Add(this.progressBar);
            this.pnlMain.Controls.Add(this.iteckLogo);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(293, 463);
            this.pnlMain.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.lblStatus.Location = new System.Drawing.Point(12, 381);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(269, 23);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "Checking for Updates...";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar
            // 
            this.progressBar.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.progressBar.AnimationSpeed = 500;
            this.progressBar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.progressBar.Font = new System.Drawing.Font("Segoe UI", 22.75F, System.Drawing.FontStyle.Bold);
            this.progressBar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.progressBar.InnerColor = System.Drawing.Color.Black;
            this.progressBar.InnerMargin = 0;
            this.progressBar.InnerWidth = -1;
            this.progressBar.Location = new System.Drawing.Point(66, 196);
            this.progressBar.MarqueeAnimationSpeed = 20000;
            this.progressBar.Name = "progressBar";
            this.progressBar.OuterColor = System.Drawing.Color.Black;
            this.progressBar.OuterMargin = 0;
            this.progressBar.OuterWidth = 2;
            this.progressBar.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(104)))), ((int)(((byte)(56)))));
            this.progressBar.ProgressWidth = 25;
            this.progressBar.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.progressBar.Size = new System.Drawing.Size(161, 161);
            this.progressBar.StartAngle = 270;
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.progressBar.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.progressBar.SubscriptText = "";
            this.progressBar.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.progressBar.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.progressBar.SuperscriptText = "";
            this.progressBar.TabIndex = 4;
            this.progressBar.Text = "0%";
            this.progressBar.TextMargin = new System.Windows.Forms.Padding(0);
            this.progressBar.Value = 68;
            // 
            // iteckLogo
            // 
            this.iteckLogo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.iteckLogo.Image = global::LS_Updater.Properties.Resources.ls_logodownload;
            this.iteckLogo.Location = new System.Drawing.Point(12, 11);
            this.iteckLogo.Name = "iteckLogo";
            this.iteckLogo.Size = new System.Drawing.Size(269, 133);
            this.iteckLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iteckLogo.TabIndex = 5;
            this.iteckLogo.TabStop = false;
            // 
            // LS_Updater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(293, 463);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(293, 463);
            this.Name = "LS_Updater";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GyroFMS";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.Load += new System.EventHandler(this.frmGyroFMS_Load);
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iteckLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CircularProgressBar.CircularProgressBar progressBar;
        private System.Windows.Forms.PictureBox iteckLogo;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblStatus;
    }
}

