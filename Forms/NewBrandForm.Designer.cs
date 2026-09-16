namespace NexoStock.Forms
{
    partial class NewBrandForm
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
            this.saveButton = new ReaLTaiizor.Controls.ParrotButton();
            this.exitButton = new ReaLTaiizor.Controls.ParrotButton();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxBrandName = new ReaLTaiizor.Controls.HopeTextBox();
            this.lostBorderPanel2 = new ReaLTaiizor.Controls.LostBorderPanel();
            this.lostBorderPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(168)))));
            this.saveButton.ButtonImage = null;
            this.saveButton.ButtonStyle = ReaLTaiizor.Controls.ParrotButton.Style.MaterialRounded;
            this.saveButton.ButtonText = "Guardar";
            this.saveButton.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(0)))), ((int)(((byte)(135)))));
            this.saveButton.ClickTextColor = System.Drawing.Color.White;
            this.saveButton.CornerRadius = 4;
            this.saveButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveButton.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.saveButton.HoverBackgroundColor = System.Drawing.Color.Fuchsia;
            this.saveButton.HoverTextColor = System.Drawing.Color.White;
            this.saveButton.ImagePosition = ReaLTaiizor.Controls.ParrotButton.ImgPosition.Left;
            this.saveButton.Location = new System.Drawing.Point(281, 272);
            this.saveButton.Margin = new System.Windows.Forms.Padding(2);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(119, 37);
            this.saveButton.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.saveButton.TabIndex = 67;
            this.saveButton.TextColor = System.Drawing.Color.White;
            this.saveButton.TextRenderingType = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.saveButton.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(80)))), ((int)(((byte)(255)))));
            this.exitButton.ButtonImage = null;
            this.exitButton.ButtonStyle = ReaLTaiizor.Controls.ParrotButton.Style.MaterialRounded;
            this.exitButton.ButtonText = "Cancelar";
            this.exitButton.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(100)))), ((int)(((byte)(181)))));
            this.exitButton.ClickTextColor = System.Drawing.Color.White;
            this.exitButton.CornerRadius = 4;
            this.exitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitButton.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.exitButton.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.exitButton.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(75)))), ((int)(((byte)(143)))));
            this.exitButton.HoverTextColor = System.Drawing.Color.White;
            this.exitButton.ImagePosition = ReaLTaiizor.Controls.ParrotButton.ImgPosition.Left;
            this.exitButton.Location = new System.Drawing.Point(19, 272);
            this.exitButton.Margin = new System.Windows.Forms.Padding(2);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(119, 37);
            this.exitButton.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.exitButton.TabIndex = 66;
            this.exitButton.TextColor = System.Drawing.Color.White;
            this.exitButton.TextRenderingType = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.exitButton.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.Fuchsia;
            this.label9.Location = new System.Drawing.Point(20, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(334, 32);
            this.label9.TabIndex = 68;
            this.label9.Text = "CREAR UNA NUEVA MARCA";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(20, 114);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(192, 25);
            this.label10.TabIndex = 70;
            this.label10.Text = "Nombre de la marca";
            // 
            // textBoxBrandName
            // 
            this.textBoxBrandName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(7)))), ((int)(((byte)(25)))));
            this.textBoxBrandName.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(55)))), ((int)(((byte)(66)))));
            this.textBoxBrandName.BorderColorA = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(25)))), ((int)(((byte)(190)))));
            this.textBoxBrandName.BorderColorB = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(80)))), ((int)(((byte)(255)))));
            this.textBoxBrandName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBoxBrandName.ForeColor = System.Drawing.Color.White;
            this.textBoxBrandName.Hint = "Ingresar el nombre de la marca";
            this.textBoxBrandName.Location = new System.Drawing.Point(19, 149);
            this.textBoxBrandName.MaxLength = 32767;
            this.textBoxBrandName.Multiline = false;
            this.textBoxBrandName.Name = "textBoxBrandName";
            this.textBoxBrandName.PasswordChar = '\0';
            this.textBoxBrandName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBoxBrandName.SelectedText = "";
            this.textBoxBrandName.SelectionLength = 0;
            this.textBoxBrandName.SelectionStart = 0;
            this.textBoxBrandName.Size = new System.Drawing.Size(381, 38);
            this.textBoxBrandName.TabIndex = 69;
            this.textBoxBrandName.TabStop = false;
            this.textBoxBrandName.UseSystemPasswordChar = false;
            // 
            // lostBorderPanel2
            // 
            this.lostBorderPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(11)))), ((int)(((byte)(31)))));
            this.lostBorderPanel2.BorderColor = System.Drawing.Color.Fuchsia;
            this.lostBorderPanel2.Controls.Add(this.textBoxBrandName);
            this.lostBorderPanel2.Controls.Add(this.label10);
            this.lostBorderPanel2.Controls.Add(this.saveButton);
            this.lostBorderPanel2.Controls.Add(this.exitButton);
            this.lostBorderPanel2.Controls.Add(this.label9);
            this.lostBorderPanel2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lostBorderPanel2.ForeColor = System.Drawing.Color.White;
            this.lostBorderPanel2.Location = new System.Drawing.Point(0, 0);
            this.lostBorderPanel2.Name = "lostBorderPanel2";
            this.lostBorderPanel2.Padding = new System.Windows.Forms.Padding(5);
            this.lostBorderPanel2.ShowText = true;
            this.lostBorderPanel2.Size = new System.Drawing.Size(413, 329);
            this.lostBorderPanel2.TabIndex = 71;
            // 
            // NewBrandForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(11)))), ((int)(((byte)(31)))));
            this.ClientSize = new System.Drawing.Size(413, 329);
            this.ControlBox = false;
            this.Controls.Add(this.lostBorderPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NewBrandForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewCategoryForm";
            this.lostBorderPanel2.ResumeLayout(false);
            this.lostBorderPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ReaLTaiizor.Controls.ParrotButton saveButton;
        private ReaLTaiizor.Controls.ParrotButton exitButton;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private ReaLTaiizor.Controls.HopeTextBox textBoxBrandName;
        private ReaLTaiizor.Controls.LostBorderPanel lostBorderPanel2;
    }
}