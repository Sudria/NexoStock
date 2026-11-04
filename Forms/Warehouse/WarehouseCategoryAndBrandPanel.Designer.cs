namespace NexoStock.Forms.Warehouse
{
    partial class WarehouseCategoryAndBrandPanel
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridBrand = new ReaLTaiizor.Controls.PoisonDataGridView();
            this.dataGridCategory = new ReaLTaiizor.Controls.PoisonDataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonDeleteBrand = new ReaLTaiizor.Controls.CyberButton();
            this.buttonNewBrand = new ReaLTaiizor.Controls.CyberButton();
            this.buttonEditBrand = new ReaLTaiizor.Controls.CyberButton();
            this.buttonDeleteCategory = new ReaLTaiizor.Controls.CyberButton();
            this.buttonNewCattegory = new ReaLTaiizor.Controls.CyberButton();
            this.buttonEditCategory = new ReaLTaiizor.Controls.CyberButton();
            this.textBoxCategoryName = new ReaLTaiizor.Controls.HopeTextBox();
            this.textBoxBrandName = new ReaLTaiizor.Controls.HopeTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBrand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCategory)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(22, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 28);
            this.label1.TabIndex = 18;
            this.label1.Text = "CATEGORIA Y MARCAS";
            // 
            // dataGridBrand
            // 
            this.dataGridBrand.AllowUserToAddRows = false;
            this.dataGridBrand.AllowUserToDeleteRows = false;
            this.dataGridBrand.AllowUserToResizeRows = false;
            this.dataGridBrand.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridBrand.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(7)))), ((int)(((byte)(25)))));
            this.dataGridBrand.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridBrand.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dataGridBrand.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.MediumSlateBlue;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.Color.DarkSlateBlue;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridBrand.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.dataGridBrand.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.Fuchsia;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridBrand.DefaultCellStyle = dataGridViewCellStyle20;
            this.dataGridBrand.EnableHeadersVisualStyles = false;
            this.dataGridBrand.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dataGridBrand.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridBrand.Location = new System.Drawing.Point(27, 434);
            this.dataGridBrand.MultiSelect = false;
            this.dataGridBrand.Name = "dataGridBrand";
            this.dataGridBrand.ReadOnly = true;
            this.dataGridBrand.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.MediumSlateBlue;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.MediumSlateBlue;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridBrand.RowHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.dataGridBrand.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridBrand.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridBrand.Size = new System.Drawing.Size(1015, 225);
            this.dataGridBrand.TabIndex = 71;
            // 
            // dataGridCategory
            // 
            this.dataGridCategory.AllowUserToAddRows = false;
            this.dataGridCategory.AllowUserToDeleteRows = false;
            this.dataGridCategory.AllowUserToResizeRows = false;
            this.dataGridCategory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridCategory.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(7)))), ((int)(((byte)(25)))));
            this.dataGridCategory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridCategory.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dataGridCategory.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.MediumSlateBlue;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.Color.DarkSlateBlue;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridCategory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.dataGridCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.Color.Fuchsia;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridCategory.DefaultCellStyle = dataGridViewCellStyle23;
            this.dataGridCategory.EnableHeadersVisualStyles = false;
            this.dataGridCategory.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dataGridCategory.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridCategory.Location = new System.Drawing.Point(27, 127);
            this.dataGridCategory.MultiSelect = false;
            this.dataGridCategory.Name = "dataGridCategory";
            this.dataGridCategory.ReadOnly = true;
            this.dataGridCategory.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.MediumSlateBlue;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.MediumSlateBlue;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridCategory.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
            this.dataGridCategory.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridCategory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridCategory.Size = new System.Drawing.Size(1015, 225);
            this.dataGridCategory.TabIndex = 70;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(23, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 21);
            this.label2.TabIndex = 69;
            this.label2.Text = "Buscar Categoria";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(23, 365);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(111, 21);
            this.label10.TabIndex = 68;
            this.label10.Text = "Buscar Marca";
            // 
            // buttonDeleteBrand
            // 
            this.buttonDeleteBrand.Alpha = 30;
            this.buttonDeleteBrand.BackColor = System.Drawing.Color.Transparent;
            this.buttonDeleteBrand.Background = true;
            this.buttonDeleteBrand.Background_WidthPen = 2F;
            this.buttonDeleteBrand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonDeleteBrand.BackgroundPen = true;
            this.buttonDeleteBrand.ColorBackground = System.Drawing.Color.Empty;
            this.buttonDeleteBrand.ColorBackground_1 = System.Drawing.Color.Crimson;
            this.buttonDeleteBrand.ColorBackground_2 = System.Drawing.Color.MediumSlateBlue;
            this.buttonDeleteBrand.ColorBackground_Pen = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.buttonDeleteBrand.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(50)))), ((int)(((byte)(190)))));
            this.buttonDeleteBrand.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.buttonDeleteBrand.ColorPen_2 = System.Drawing.Color.Violet;
            this.buttonDeleteBrand.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDeleteBrand.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.buttonDeleteBrand.Effect_1 = true;
            this.buttonDeleteBrand.Effect_1_ColorBackground = System.Drawing.Color.Violet;
            this.buttonDeleteBrand.Effect_1_Transparency = 25;
            this.buttonDeleteBrand.Effect_2 = false;
            this.buttonDeleteBrand.Effect_2_ColorBackground = System.Drawing.Color.LimeGreen;
            this.buttonDeleteBrand.Effect_2_Transparency = 20;
            this.buttonDeleteBrand.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeleteBrand.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.buttonDeleteBrand.Lighting = true;
            this.buttonDeleteBrand.LinearGradient_Background = true;
            this.buttonDeleteBrand.LinearGradientPen = true;
            this.buttonDeleteBrand.Location = new System.Drawing.Point(800, 389);
            this.buttonDeleteBrand.Name = "buttonDeleteBrand";
            this.buttonDeleteBrand.PenWidth = 15;
            this.buttonDeleteBrand.Rounding = true;
            this.buttonDeleteBrand.RoundingInt = 25;
            this.buttonDeleteBrand.Size = new System.Drawing.Size(112, 38);
            this.buttonDeleteBrand.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.buttonDeleteBrand.TabIndex = 67;
            this.buttonDeleteBrand.Tag = "Cyber";
            this.buttonDeleteBrand.TextButton = "ELIMINAR";
            this.buttonDeleteBrand.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.buttonDeleteBrand.Timer_Effect_1 = 1;
            this.buttonDeleteBrand.Timer_RGB = 1;
            this.buttonDeleteBrand.Click += new System.EventHandler(this.buttonDeleteBrand_Click);
            // 
            // buttonNewBrand
            // 
            this.buttonNewBrand.Alpha = 30;
            this.buttonNewBrand.BackColor = System.Drawing.Color.Transparent;
            this.buttonNewBrand.Background = true;
            this.buttonNewBrand.Background_WidthPen = 2F;
            this.buttonNewBrand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonNewBrand.BackgroundPen = true;
            this.buttonNewBrand.ColorBackground = System.Drawing.Color.Empty;
            this.buttonNewBrand.ColorBackground_1 = System.Drawing.Color.Lime;
            this.buttonNewBrand.ColorBackground_2 = System.Drawing.Color.MediumSlateBlue;
            this.buttonNewBrand.ColorBackground_Pen = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.buttonNewBrand.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(50)))), ((int)(((byte)(190)))));
            this.buttonNewBrand.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.buttonNewBrand.ColorPen_2 = System.Drawing.Color.Violet;
            this.buttonNewBrand.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonNewBrand.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.buttonNewBrand.Effect_1 = true;
            this.buttonNewBrand.Effect_1_ColorBackground = System.Drawing.Color.Violet;
            this.buttonNewBrand.Effect_1_Transparency = 25;
            this.buttonNewBrand.Effect_2 = false;
            this.buttonNewBrand.Effect_2_ColorBackground = System.Drawing.Color.LimeGreen;
            this.buttonNewBrand.Effect_2_Transparency = 20;
            this.buttonNewBrand.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNewBrand.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.buttonNewBrand.Lighting = true;
            this.buttonNewBrand.LinearGradient_Background = true;
            this.buttonNewBrand.LinearGradientPen = true;
            this.buttonNewBrand.Location = new System.Drawing.Point(478, 389);
            this.buttonNewBrand.Name = "buttonNewBrand";
            this.buttonNewBrand.PenWidth = 15;
            this.buttonNewBrand.Rounding = true;
            this.buttonNewBrand.RoundingInt = 25;
            this.buttonNewBrand.Size = new System.Drawing.Size(198, 38);
            this.buttonNewBrand.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.buttonNewBrand.TabIndex = 66;
            this.buttonNewBrand.Tag = "Cyber";
            this.buttonNewBrand.TextButton = "+ NUEVA MARCA";
            this.buttonNewBrand.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.buttonNewBrand.Timer_Effect_1 = 1;
            this.buttonNewBrand.Timer_RGB = 1;
            this.buttonNewBrand.Click += new System.EventHandler(this.buttonNewBrand_Click);
            // 
            // buttonEditBrand
            // 
            this.buttonEditBrand.Alpha = 30;
            this.buttonEditBrand.BackColor = System.Drawing.Color.Transparent;
            this.buttonEditBrand.Background = true;
            this.buttonEditBrand.Background_WidthPen = 2F;
            this.buttonEditBrand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonEditBrand.BackgroundPen = true;
            this.buttonEditBrand.ColorBackground = System.Drawing.Color.Empty;
            this.buttonEditBrand.ColorBackground_1 = System.Drawing.Color.Orange;
            this.buttonEditBrand.ColorBackground_2 = System.Drawing.Color.MediumSlateBlue;
            this.buttonEditBrand.ColorBackground_Pen = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.buttonEditBrand.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(50)))), ((int)(((byte)(190)))));
            this.buttonEditBrand.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.buttonEditBrand.ColorPen_2 = System.Drawing.Color.Violet;
            this.buttonEditBrand.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEditBrand.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.buttonEditBrand.Effect_1 = true;
            this.buttonEditBrand.Effect_1_ColorBackground = System.Drawing.Color.Violet;
            this.buttonEditBrand.Effect_1_Transparency = 25;
            this.buttonEditBrand.Effect_2 = false;
            this.buttonEditBrand.Effect_2_ColorBackground = System.Drawing.Color.LimeGreen;
            this.buttonEditBrand.Effect_2_Transparency = 20;
            this.buttonEditBrand.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEditBrand.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.buttonEditBrand.Lighting = true;
            this.buttonEditBrand.LinearGradient_Background = true;
            this.buttonEditBrand.LinearGradientPen = true;
            this.buttonEditBrand.Location = new System.Drawing.Point(682, 389);
            this.buttonEditBrand.Name = "buttonEditBrand";
            this.buttonEditBrand.PenWidth = 15;
            this.buttonEditBrand.Rounding = true;
            this.buttonEditBrand.RoundingInt = 25;
            this.buttonEditBrand.Size = new System.Drawing.Size(112, 38);
            this.buttonEditBrand.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.buttonEditBrand.TabIndex = 65;
            this.buttonEditBrand.Tag = "Cyber";
            this.buttonEditBrand.TextButton = "EDITAR";
            this.buttonEditBrand.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.buttonEditBrand.Timer_Effect_1 = 1;
            this.buttonEditBrand.Timer_RGB = 1;
            this.buttonEditBrand.Click += new System.EventHandler(this.buttonEditBrand_Click);
            // 
            // buttonDeleteCategory
            // 
            this.buttonDeleteCategory.Alpha = 30;
            this.buttonDeleteCategory.BackColor = System.Drawing.Color.Transparent;
            this.buttonDeleteCategory.Background = true;
            this.buttonDeleteCategory.Background_WidthPen = 2F;
            this.buttonDeleteCategory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonDeleteCategory.BackgroundPen = true;
            this.buttonDeleteCategory.ColorBackground = System.Drawing.Color.Empty;
            this.buttonDeleteCategory.ColorBackground_1 = System.Drawing.Color.Crimson;
            this.buttonDeleteCategory.ColorBackground_2 = System.Drawing.Color.MediumSlateBlue;
            this.buttonDeleteCategory.ColorBackground_Pen = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.buttonDeleteCategory.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(50)))), ((int)(((byte)(190)))));
            this.buttonDeleteCategory.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.buttonDeleteCategory.ColorPen_2 = System.Drawing.Color.Violet;
            this.buttonDeleteCategory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDeleteCategory.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.buttonDeleteCategory.Effect_1 = true;
            this.buttonDeleteCategory.Effect_1_ColorBackground = System.Drawing.Color.Violet;
            this.buttonDeleteCategory.Effect_1_Transparency = 25;
            this.buttonDeleteCategory.Effect_2 = false;
            this.buttonDeleteCategory.Effect_2_ColorBackground = System.Drawing.Color.LimeGreen;
            this.buttonDeleteCategory.Effect_2_Transparency = 20;
            this.buttonDeleteCategory.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeleteCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.buttonDeleteCategory.Lighting = true;
            this.buttonDeleteCategory.LinearGradient_Background = true;
            this.buttonDeleteCategory.LinearGradientPen = true;
            this.buttonDeleteCategory.Location = new System.Drawing.Point(800, 83);
            this.buttonDeleteCategory.Name = "buttonDeleteCategory";
            this.buttonDeleteCategory.PenWidth = 15;
            this.buttonDeleteCategory.Rounding = true;
            this.buttonDeleteCategory.RoundingInt = 25;
            this.buttonDeleteCategory.Size = new System.Drawing.Size(112, 38);
            this.buttonDeleteCategory.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.buttonDeleteCategory.TabIndex = 64;
            this.buttonDeleteCategory.Tag = "Cyber";
            this.buttonDeleteCategory.TextButton = "ELIMINAR";
            this.buttonDeleteCategory.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.buttonDeleteCategory.Timer_Effect_1 = 1;
            this.buttonDeleteCategory.Timer_RGB = 1;
            this.buttonDeleteCategory.Click += new System.EventHandler(this.buttonDeleteCategory_Click);
            // 
            // buttonNewCattegory
            // 
            this.buttonNewCattegory.Alpha = 30;
            this.buttonNewCattegory.BackColor = System.Drawing.Color.Transparent;
            this.buttonNewCattegory.Background = true;
            this.buttonNewCattegory.Background_WidthPen = 2F;
            this.buttonNewCattegory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonNewCattegory.BackgroundPen = true;
            this.buttonNewCattegory.ColorBackground = System.Drawing.Color.Empty;
            this.buttonNewCattegory.ColorBackground_1 = System.Drawing.Color.LimeGreen;
            this.buttonNewCattegory.ColorBackground_2 = System.Drawing.Color.MediumSlateBlue;
            this.buttonNewCattegory.ColorBackground_Pen = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.buttonNewCattegory.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(50)))), ((int)(((byte)(190)))));
            this.buttonNewCattegory.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.buttonNewCattegory.ColorPen_2 = System.Drawing.Color.Violet;
            this.buttonNewCattegory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonNewCattegory.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.buttonNewCattegory.Effect_1 = true;
            this.buttonNewCattegory.Effect_1_ColorBackground = System.Drawing.Color.Violet;
            this.buttonNewCattegory.Effect_1_Transparency = 25;
            this.buttonNewCattegory.Effect_2 = false;
            this.buttonNewCattegory.Effect_2_ColorBackground = System.Drawing.Color.LimeGreen;
            this.buttonNewCattegory.Effect_2_Transparency = 20;
            this.buttonNewCattegory.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNewCattegory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.buttonNewCattegory.Lighting = true;
            this.buttonNewCattegory.LinearGradient_Background = true;
            this.buttonNewCattegory.LinearGradientPen = true;
            this.buttonNewCattegory.Location = new System.Drawing.Point(478, 83);
            this.buttonNewCattegory.Name = "buttonNewCattegory";
            this.buttonNewCattegory.PenWidth = 15;
            this.buttonNewCattegory.Rounding = true;
            this.buttonNewCattegory.RoundingInt = 25;
            this.buttonNewCattegory.Size = new System.Drawing.Size(198, 38);
            this.buttonNewCattegory.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.buttonNewCattegory.TabIndex = 63;
            this.buttonNewCattegory.Tag = "Cyber";
            this.buttonNewCattegory.TextButton = "+ NUEVA CATEGORIA";
            this.buttonNewCattegory.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.buttonNewCattegory.Timer_Effect_1 = 1;
            this.buttonNewCattegory.Timer_RGB = 1;
            this.buttonNewCattegory.Click += new System.EventHandler(this.buttonNewCattegory_Click);
            // 
            // buttonEditCategory
            // 
            this.buttonEditCategory.Alpha = 30;
            this.buttonEditCategory.BackColor = System.Drawing.Color.Transparent;
            this.buttonEditCategory.Background = true;
            this.buttonEditCategory.Background_WidthPen = 2F;
            this.buttonEditCategory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonEditCategory.BackgroundPen = true;
            this.buttonEditCategory.ColorBackground = System.Drawing.Color.Empty;
            this.buttonEditCategory.ColorBackground_1 = System.Drawing.Color.Orange;
            this.buttonEditCategory.ColorBackground_2 = System.Drawing.Color.MediumSlateBlue;
            this.buttonEditCategory.ColorBackground_Pen = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.buttonEditCategory.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(50)))), ((int)(((byte)(190)))));
            this.buttonEditCategory.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.buttonEditCategory.ColorPen_2 = System.Drawing.Color.Violet;
            this.buttonEditCategory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEditCategory.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.buttonEditCategory.Effect_1 = true;
            this.buttonEditCategory.Effect_1_ColorBackground = System.Drawing.Color.Violet;
            this.buttonEditCategory.Effect_1_Transparency = 25;
            this.buttonEditCategory.Effect_2 = false;
            this.buttonEditCategory.Effect_2_ColorBackground = System.Drawing.Color.LimeGreen;
            this.buttonEditCategory.Effect_2_Transparency = 20;
            this.buttonEditCategory.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEditCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.buttonEditCategory.Lighting = true;
            this.buttonEditCategory.LinearGradient_Background = true;
            this.buttonEditCategory.LinearGradientPen = true;
            this.buttonEditCategory.Location = new System.Drawing.Point(682, 83);
            this.buttonEditCategory.Name = "buttonEditCategory";
            this.buttonEditCategory.PenWidth = 15;
            this.buttonEditCategory.Rounding = true;
            this.buttonEditCategory.RoundingInt = 25;
            this.buttonEditCategory.Size = new System.Drawing.Size(112, 38);
            this.buttonEditCategory.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.buttonEditCategory.TabIndex = 62;
            this.buttonEditCategory.Tag = "Cyber";
            this.buttonEditCategory.TextButton = "EDITAR";
            this.buttonEditCategory.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.buttonEditCategory.Timer_Effect_1 = 1;
            this.buttonEditCategory.Timer_RGB = 1;
            this.buttonEditCategory.Click += new System.EventHandler(this.buttonEditCategory_Click);
            // 
            // textBoxCategoryName
            // 
            this.textBoxCategoryName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(7)))), ((int)(((byte)(25)))));
            this.textBoxCategoryName.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(55)))), ((int)(((byte)(66)))));
            this.textBoxCategoryName.BorderColorA = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(25)))), ((int)(((byte)(190)))));
            this.textBoxCategoryName.BorderColorB = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(80)))), ((int)(((byte)(255)))));
            this.textBoxCategoryName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBoxCategoryName.ForeColor = System.Drawing.Color.White;
            this.textBoxCategoryName.Hint = "Buscar categoria";
            this.textBoxCategoryName.Location = new System.Drawing.Point(27, 83);
            this.textBoxCategoryName.MaxLength = 32767;
            this.textBoxCategoryName.Multiline = false;
            this.textBoxCategoryName.Name = "textBoxCategoryName";
            this.textBoxCategoryName.PasswordChar = '\0';
            this.textBoxCategoryName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBoxCategoryName.SelectedText = "";
            this.textBoxCategoryName.SelectionLength = 0;
            this.textBoxCategoryName.SelectionStart = 0;
            this.textBoxCategoryName.Size = new System.Drawing.Size(420, 38);
            this.textBoxCategoryName.TabIndex = 61;
            this.textBoxCategoryName.TabStop = false;
            this.textBoxCategoryName.UseSystemPasswordChar = false;
            this.textBoxCategoryName.TextChanged += new System.EventHandler(this.textBoxCategoryName_TextChanged);
            // 
            // textBoxBrandName
            // 
            this.textBoxBrandName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(7)))), ((int)(((byte)(25)))));
            this.textBoxBrandName.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(55)))), ((int)(((byte)(66)))));
            this.textBoxBrandName.BorderColorA = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(25)))), ((int)(((byte)(190)))));
            this.textBoxBrandName.BorderColorB = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(80)))), ((int)(((byte)(255)))));
            this.textBoxBrandName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBoxBrandName.ForeColor = System.Drawing.Color.White;
            this.textBoxBrandName.Hint = "Buscar marca";
            this.textBoxBrandName.Location = new System.Drawing.Point(27, 389);
            this.textBoxBrandName.MaxLength = 32767;
            this.textBoxBrandName.Multiline = false;
            this.textBoxBrandName.Name = "textBoxBrandName";
            this.textBoxBrandName.PasswordChar = '\0';
            this.textBoxBrandName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBoxBrandName.SelectedText = "";
            this.textBoxBrandName.SelectionLength = 0;
            this.textBoxBrandName.SelectionStart = 0;
            this.textBoxBrandName.Size = new System.Drawing.Size(420, 38);
            this.textBoxBrandName.TabIndex = 60;
            this.textBoxBrandName.TabStop = false;
            this.textBoxBrandName.UseSystemPasswordChar = false;
            this.textBoxBrandName.TextChanged += new System.EventHandler(this.textBoxBrandName_TextChanged);
            // 
            // WarehouseCategoryAndBrandPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(11)))), ((int)(((byte)(31)))));
            this.Controls.Add(this.dataGridBrand);
            this.Controls.Add(this.dataGridCategory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.buttonDeleteBrand);
            this.Controls.Add(this.buttonNewBrand);
            this.Controls.Add(this.buttonEditBrand);
            this.Controls.Add(this.buttonDeleteCategory);
            this.Controls.Add(this.buttonNewCattegory);
            this.Controls.Add(this.buttonEditCategory);
            this.Controls.Add(this.textBoxCategoryName);
            this.Controls.Add(this.textBoxBrandName);
            this.Controls.Add(this.label1);
            this.Name = "WarehouseCategoryAndBrandPanel";
            this.Size = new System.Drawing.Size(1120, 662);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBrand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCategory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private ReaLTaiizor.Controls.PoisonDataGridView dataGridBrand;
        private ReaLTaiizor.Controls.PoisonDataGridView dataGridCategory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private ReaLTaiizor.Controls.CyberButton buttonDeleteBrand;
        private ReaLTaiizor.Controls.CyberButton buttonNewBrand;
        private ReaLTaiizor.Controls.CyberButton buttonEditBrand;
        private ReaLTaiizor.Controls.CyberButton buttonDeleteCategory;
        private ReaLTaiizor.Controls.CyberButton buttonNewCattegory;
        private ReaLTaiizor.Controls.CyberButton buttonEditCategory;
        private ReaLTaiizor.Controls.HopeTextBox textBoxCategoryName;
        private ReaLTaiizor.Controls.HopeTextBox textBoxBrandName;
    }
}
