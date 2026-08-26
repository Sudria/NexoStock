namespace NexoStock
{
    partial class Login
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkBoxShowPass = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.logginButton = new ReaLTaiizor.Controls.ParrotButton();
            this.txtUser = new ReaLTaiizor.Controls.HopeTextBox();
            this.txtPassword = new ReaLTaiizor.Controls.HopeTextBox();
            this.clearButton = new ReaLTaiizor.Controls.ParrotButton();
            this.exitButton = new ReaLTaiizor.Controls.ParrotButton();
            this.parrotPictureBox1 = new ReaLTaiizor.Controls.ParrotPictureBox();
            this.SuspendLayout();
            // 
            // checkBoxShowPass
            // 
            this.checkBoxShowPass.AutoSize = true;
            this.checkBoxShowPass.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.checkBoxShowPass.ForeColor = System.Drawing.Color.White;
            this.checkBoxShowPass.Location = new System.Drawing.Point(456, 161);
            this.checkBoxShowPass.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxShowPass.Name = "checkBoxShowPass";
            this.checkBoxShowPass.Size = new System.Drawing.Size(183, 27);
            this.checkBoxShowPass.TabIndex = 3;
            this.checkBoxShowPass.Text = "Mostrar Contraseña";
            this.checkBoxShowPass.UseVisualStyleBackColor = true;
            this.checkBoxShowPass.CheckedChanged += new System.EventHandler(this.checkBoxShowPass_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(528, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "NEXUS STOCK";
            // 
            // logginButton
            // 
            this.logginButton.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(168)))));
            this.logginButton.ButtonImage = null;
            this.logginButton.ButtonStyle = ReaLTaiizor.Controls.ParrotButton.Style.MaterialRounded;
            this.logginButton.ButtonText = " Iniciar sesión";
            this.logginButton.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(0)))), ((int)(((byte)(135)))));
            this.logginButton.ClickTextColor = System.Drawing.Color.White;
            this.logginButton.CornerRadius = 10;
            this.logginButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logginButton.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logginButton.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.logginButton.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(107)))), ((int)(((byte)(203)))));
            this.logginButton.HoverTextColor = System.Drawing.Color.White;
            this.logginButton.ImagePosition = ReaLTaiizor.Controls.ParrotButton.ImgPosition.Left;
            this.logginButton.Location = new System.Drawing.Point(456, 196);
            this.logginButton.Margin = new System.Windows.Forms.Padding(2);
            this.logginButton.Name = "logginButton";
            this.logginButton.Size = new System.Drawing.Size(234, 35);
            this.logginButton.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.logginButton.TabIndex = 4;
            this.logginButton.TextColor = System.Drawing.Color.White;
            this.logginButton.TextRenderingType = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.logginButton.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.logginButton.Click += new System.EventHandler(this.logginButton_Click);
            // 
            // txtUser
            // 
            this.txtUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(7)))), ((int)(((byte)(25)))));
            this.txtUser.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(55)))), ((int)(((byte)(66)))));
            this.txtUser.BorderColorA = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(25)))), ((int)(((byte)(190)))));
            this.txtUser.BorderColorB = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(80)))), ((int)(((byte)(255)))));
            this.txtUser.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtUser.ForeColor = System.Drawing.Color.White;
            this.txtUser.Hint = "Usuario";
            this.txtUser.Location = new System.Drawing.Point(456, 59);
            this.txtUser.MaxLength = 32767;
            this.txtUser.Multiline = false;
            this.txtUser.Name = "txtUser";
            this.txtUser.PasswordChar = '\0';
            this.txtUser.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtUser.SelectedText = "";
            this.txtUser.SelectionLength = 0;
            this.txtUser.SelectionStart = 0;
            this.txtUser.Size = new System.Drawing.Size(234, 43);
            this.txtUser.TabIndex = 1;
            this.txtUser.TabStop = false;
            this.txtUser.UseSystemPasswordChar = false;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(7)))), ((int)(((byte)(25)))));
            this.txtPassword.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(55)))), ((int)(((byte)(66)))));
            this.txtPassword.BorderColorA = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(25)))), ((int)(((byte)(190)))));
            this.txtPassword.BorderColorB = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(80)))), ((int)(((byte)(255)))));
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPassword.ForeColor = System.Drawing.Color.White;
            this.txtPassword.Hint = "Contraseña";
            this.txtPassword.Location = new System.Drawing.Point(456, 115);
            this.txtPassword.MaxLength = 32767;
            this.txtPassword.Multiline = false;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPassword.SelectedText = "";
            this.txtPassword.SelectionLength = 0;
            this.txtPassword.SelectionStart = 0;
            this.txtPassword.Size = new System.Drawing.Size(234, 43);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.TabStop = false;
            this.txtPassword.UseSystemPasswordChar = false;
            // 
            // clearButton
            // 
            this.clearButton.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(53)))), ((int)(((byte)(107)))));
            this.clearButton.ButtonImage = null;
            this.clearButton.ButtonStyle = ReaLTaiizor.Controls.ParrotButton.Style.MaterialRounded;
            this.clearButton.ButtonText = "Limpiar";
            this.clearButton.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(100)))), ((int)(((byte)(181)))));
            this.clearButton.ClickTextColor = System.Drawing.Color.White;
            this.clearButton.CornerRadius = 4;
            this.clearButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clearButton.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.clearButton.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.clearButton.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(75)))), ((int)(((byte)(143)))));
            this.clearButton.HoverTextColor = System.Drawing.Color.White;
            this.clearButton.ImagePosition = ReaLTaiizor.Controls.ParrotButton.ImgPosition.Left;
            this.clearButton.Location = new System.Drawing.Point(456, 293);
            this.clearButton.Margin = new System.Windows.Forms.Padding(2);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(64, 31);
            this.clearButton.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.clearButton.TabIndex = 5;
            this.clearButton.TextColor = System.Drawing.Color.White;
            this.clearButton.TextRenderingType = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.clearButton.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(53)))), ((int)(((byte)(107)))));
            this.exitButton.ButtonImage = null;
            this.exitButton.ButtonStyle = ReaLTaiizor.Controls.ParrotButton.Style.MaterialRounded;
            this.exitButton.ButtonText = "Salir";
            this.exitButton.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(100)))), ((int)(((byte)(181)))));
            this.exitButton.ClickTextColor = System.Drawing.Color.White;
            this.exitButton.CornerRadius = 4;
            this.exitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitButton.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.exitButton.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.exitButton.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(75)))), ((int)(((byte)(143)))));
            this.exitButton.HoverTextColor = System.Drawing.Color.White;
            this.exitButton.ImagePosition = ReaLTaiizor.Controls.ParrotButton.ImgPosition.Left;
            this.exitButton.Location = new System.Drawing.Point(621, 293);
            this.exitButton.Margin = new System.Windows.Forms.Padding(2);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(69, 31);
            this.exitButton.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.exitButton.TabIndex = 6;
            this.exitButton.TextColor = System.Drawing.Color.White;
            this.exitButton.TextRenderingType = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.exitButton.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // parrotPictureBox1
            // 
            this.parrotPictureBox1.ColorLeft = System.Drawing.Color.Empty;
            this.parrotPictureBox1.ColorRight = System.Drawing.Color.Empty;
            this.parrotPictureBox1.CompositingQualityType = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            this.parrotPictureBox1.FilterAlpha = 0;
            this.parrotPictureBox1.FilterEnabled = true;
            this.parrotPictureBox1.Image = global::NexoStock.Properties.Resources.LoginLogo;
            this.parrotPictureBox1.InterpolationType = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            this.parrotPictureBox1.IsElipse = false;
            this.parrotPictureBox1.IsParallax = false;
            this.parrotPictureBox1.Location = new System.Drawing.Point(0, -4);
            this.parrotPictureBox1.Name = "parrotPictureBox1";
            this.parrotPictureBox1.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            this.parrotPictureBox1.Size = new System.Drawing.Size(436, 337);
            this.parrotPictureBox1.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.parrotPictureBox1.TabIndex = 9;
            this.parrotPictureBox1.Text = "parrotPictureBox1";
            this.parrotPictureBox1.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // Login
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(11)))), ((int)(((byte)(31)))));
            this.ClientSize = new System.Drawing.Size(714, 335);
            this.Controls.Add(this.parrotPictureBox1);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.logginButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBoxShowPass);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nexus STOCK";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox checkBoxShowPass;
        private System.Windows.Forms.Label label1;
        private ReaLTaiizor.Controls.ParrotButton logginButton;
        private ReaLTaiizor.Controls.HopeTextBox txtUser;
        private ReaLTaiizor.Controls.HopeTextBox txtPassword;
        private ReaLTaiizor.Controls.ParrotButton clearButton;
        private ReaLTaiizor.Controls.ParrotButton exitButton;
        private ReaLTaiizor.Controls.ParrotPictureBox parrotPictureBox1;
    }
}

