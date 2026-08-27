namespace NexoStock.Forms
{
    partial class Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.adminDashboard1 = new NexoStock.Forms.Admin.AdminDashboard();
            this.SuspendLayout();
            // 
            // adminDashboard1
            // 
            this.adminDashboard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(11)))), ((int)(((byte)(31)))));
            this.adminDashboard1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("adminDashboard1.BackgroundImage")));
            this.adminDashboard1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.adminDashboard1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.adminDashboard1.Location = new System.Drawing.Point(0, 0);
            this.adminDashboard1.Name = "adminDashboard1";
            this.adminDashboard1.Size = new System.Drawing.Size(326, 662);
            this.adminDashboard1.TabIndex = 0;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(11)))), ((int)(((byte)(31)))));
            this.ClientSize = new System.Drawing.Size(1444, 662);
            this.ControlBox = false;
            this.Controls.Add(this.adminDashboard1);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        #endregion

        private Admin.AdminDashboard adminDashboard1;
    }
}