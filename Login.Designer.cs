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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.checkBoxShowPass = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.clearButton = new ReaLTaiizor.Controls.Button();
            this.exitButton = new ReaLTaiizor.Controls.Button();
            this.logginButton = new ReaLTaiizor.Controls.ParrotButton();
            this.c = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            this.txtPassword = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBoxShowPass
            // 
            this.checkBoxShowPass.AutoSize = true;
            this.checkBoxShowPass.ForeColor = System.Drawing.Color.White;
            this.checkBoxShowPass.Location = new System.Drawing.Point(608, 260);
            this.checkBoxShowPass.Name = "checkBoxShowPass";
            this.checkBoxShowPass.Size = new System.Drawing.Size(146, 20);
            this.checkBoxShowPass.TabIndex = 3;
            this.checkBoxShowPass.Text = "Mostrar Contraseña";
            this.checkBoxShowPass.UseVisualStyleBackColor = true;
            this.checkBoxShowPass.CheckedChanged += new System.EventHandler(this.checkBoxShowPass_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(-2, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(579, 404);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(704, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "NEXUS STOCK";
            // 
            // clearButton
            // 
            this.clearButton.BackColor = System.Drawing.Color.Transparent;
            this.clearButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.clearButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clearButton.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.clearButton.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.clearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearButton.Image = null;
            this.clearButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.clearButton.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(84)))), ((int)(((byte)(255)))));
            this.clearButton.Location = new System.Drawing.Point(608, 357);
            this.clearButton.Name = "clearButton";
            this.clearButton.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.clearButton.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.clearButton.Size = new System.Drawing.Size(92, 33);
            this.clearButton.TabIndex = 10;
            this.clearButton.Text = "Limpiar";
            this.clearButton.TextAlignment = System.Drawing.StringAlignment.Center;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.Transparent;
            this.exitButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.exitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitButton.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.exitButton.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.exitButton.Image = null;
            this.exitButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.exitButton.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(84)))), ((int)(((byte)(255)))));
            this.exitButton.Location = new System.Drawing.Point(813, 357);
            this.exitButton.Name = "exitButton";
            this.exitButton.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.exitButton.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.exitButton.Size = new System.Drawing.Size(106, 33);
            this.exitButton.TabIndex = 11;
            this.exitButton.Text = "Salir";
            this.exitButton.TextAlignment = System.Drawing.StringAlignment.Center;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
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
            this.logginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.logginButton.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.logginButton.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(107)))), ((int)(((byte)(203)))));
            this.logginButton.HoverTextColor = System.Drawing.Color.White;
            this.logginButton.ImagePosition = ReaLTaiizor.Controls.ParrotButton.ImgPosition.Left;
            this.logginButton.Location = new System.Drawing.Point(610, 286);
            this.logginButton.Name = "logginButton";
            this.logginButton.Size = new System.Drawing.Size(309, 50);
            this.logginButton.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.logginButton.TabIndex = 12;
            this.logginButton.TextColor = System.Drawing.Color.White;
            this.logginButton.TextRenderingType = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.logginButton.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            // 
            // c
            // 
            this.c.AnimateReadOnly = false;
            this.c.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.c.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.c.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.c.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.c.Depth = 0;
            this.c.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.c.HideSelection = true;
            this.c.Hint = "Usuario";
            this.c.LeadingIcon = null;
            this.c.Location = new System.Drawing.Point(608, 69);
            this.c.MaxLength = 32767;
            this.c.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            this.c.Name = "c";
            this.c.PasswordChar = '\0';
            this.c.PrefixSuffixText = null;
            this.c.ReadOnly = false;
            this.c.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.c.SelectedText = "";
            this.c.SelectionLength = 0;
            this.c.SelectionStart = 0;
            this.c.ShortcutsEnabled = true;
            this.c.Size = new System.Drawing.Size(311, 60);
            this.c.TabIndex = 15;
            this.c.TabStop = false;
            this.c.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.c.TrailingIcon = null;
            this.c.UseSystemPasswordChar = false;
            // 
            // txtPassword
            // 
            this.txtPassword.AnimateReadOnly = false;
            this.txtPassword.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtPassword.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPassword.Depth = 0;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtPassword.HideSelection = true;
            this.txtPassword.Hint = "Contraseña";
            this.txtPassword.LeadingIcon = null;
            this.txtPassword.Location = new System.Drawing.Point(608, 150);
            this.txtPassword.MaxLength = 32767;
            this.txtPassword.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '\0';
            this.txtPassword.PrefixSuffixText = null;
            this.txtPassword.ReadOnly = false;
            this.txtPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPassword.SelectedText = "";
            this.txtPassword.SelectionLength = 0;
            this.txtPassword.SelectionStart = 0;
            this.txtPassword.ShortcutsEnabled = true;
            this.txtPassword.Size = new System.Drawing.Size(297, 60);
            this.txtPassword.TabIndex = 16;
            this.txtPassword.TabStop = false;
            this.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPassword.TrailingIcon = null;
            this.txtPassword.UseSystemPasswordChar = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(11)))), ((int)(((byte)(31)))));
            this.ClientSize = new System.Drawing.Size(945, 402);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.c);
            this.Controls.Add(this.logginButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.checkBoxShowPass);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nexus STOCK";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox checkBoxShowPass;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private ReaLTaiizor.Controls.Button clearButton;
        private ReaLTaiizor.Controls.Button exitButton;
        private ReaLTaiizor.Controls.ParrotButton logginButton;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit c;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit txtPassword;
    }
}

