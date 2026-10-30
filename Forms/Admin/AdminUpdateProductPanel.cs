
using NexoStock.Class;
using NexoStock.Services;
using NexoStock.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace NexoStock.Forms.Admin
{
    public partial class AdminUpdateProductPanel : UserControl
    {
        private ProductClass productClass;

        private readonly ProductRepository productRepository =
            new ProductRepository();

        private readonly ProductImageRepository imageRepository =
            new ProductImageRepository();

        public AdminUpdateProductPanel(ProductClass product)
        {
            InitializeComponent();

            productClass = product;

            LoadComboBoxs();
            LoadProductData();
            LoadProductImages();
        }



        private void LoadProductData()
        {
            textBoxProductName.Text = productClass.Name;
            textBoxCod.Text = productClass.Cod;
            textBoxDescription.Text = productClass.Description;

            activeCheckBox.Checked = productClass.State;

            numericStockMin.ValueNumber = productClass.StockMin;

            comboBoxCategory.SelectedValue = productClass.CategoryId;
            comboBoxBrand.SelectedValue = productClass.BrandId;
            comboBoxProvider.SelectedValue = productClass.ProviderId;

            textBoxPrice.Text = productClass.SalePrice.ToString(
                CultureInfo.CurrentCulture
            );
        }


        private void LoadProductImages()
        {
            List<ProductImageClass> images =
                imageRepository.GetImagesByProductId(productClass.Id);

            PictureBox[] pictureBoxes =
            {
                pictureBoxImage1,
                pictureBoxImage2,
                pictureBoxImage3
            };

            string folderPath = Path.Combine(
                Application.StartupPath,
                "ProductImages"
            );

            foreach (ProductImageClass image in images)
            {
                string filePath = Path.Combine(
                    Application.StartupPath,
                    image.ImagePath
                );

                if (!File.Exists(filePath))
                    continue;

                string fileName = Path.GetFileNameWithoutExtension(
                    image.ImagePath
                );

                string[] parts = fileName.Split('_');

                if (parts.Length < 2 ||
                    !int.TryParse(parts[parts.Length - 1], out int position))
                    continue;

                if (position < 1 || position > 3)
                    continue;

                using (Image loadedImage = Image.FromFile(filePath))
                {
                    pictureBoxes[position - 1].Image =
                        new Bitmap(loadedImage);
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (!Utils.Validator.isValidText(
                textBoxProductName.Text,
                "Nombre del producto"))
            {
                textBoxProductName.Focus();
                textBoxProductName.BorderColorA = Color.Red;
                return;
            }

            if (!Utils.Validator.isValidText(
                textBoxDescription.Text,
                "Descripción del producto"))
            {
                textBoxDescription.Focus();
                textBoxDescription.BorderColorA = Color.Red;
                return;
            }

            if (!Utils.Validator.isValidStock(
                numericStockMin.ValueNumber.ToString(),
                "Stock Mínimo"))
            {
                numericStockMin.Focus();
                return;
            }

            if (comboBoxCategory.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Debe seleccionar una categoría.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                comboBoxCategory.Focus();
                return;
            }

            if (comboBoxBrand.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Debe seleccionar una marca.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                comboBoxBrand.Focus();
                return;
            }

            if (comboBoxProvider.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Debe seleccionar un proveedor.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                comboBoxProvider.Focus();
                return;
            }

            if (!decimal.TryParse(
                textBoxPrice.Text,
                NumberStyles.Number,
                CultureInfo.CurrentCulture,
                out decimal price) || price < 0)
            {
                MessageBox.Show(
                    "Ingrese un precio válido.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                textBoxPrice.Focus();
                return;
            }

            ProductClass updatedProduct = new ProductClass
            {
                Id = productClass.Id,
                Name = textBoxProductName.Text.Trim(),
                Cod = textBoxCod.Text.Trim(),
                Description = textBoxDescription.Text.Trim(),

                State = activeCheckBox.Checked,

                StockMin = (int)numericStockMin.ValueNumber,

                CategoryId = Convert.ToInt32(
                    comboBoxCategory.SelectedValue
                ),

                BrandId = Convert.ToInt32(
                    comboBoxBrand.SelectedValue
                ),

                ProviderId = Convert.ToInt32(
                    comboBoxProvider.SelectedValue
                ),

                SalePrice = price
            };

            if (!productRepository.UpdateProduct(updatedProduct))
            {
                MessageBox.Show(
                    "No se pudo actualizar el producto.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }


            SaveProductImages();

            MessageBox.Show(
                "Producto actualizado exitosamente.",
                "Éxito",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            AdminForm dashboard = this.ParentForm as AdminForm;
            dashboard?.LoadProductControler();
        }

        private void SaveProductImages()
        {
            List<ProductImageClass> oldImages =
                imageRepository.GetImagesByProductId(productClass.Id);

            imageRepository.DeleteImagesByProductId(productClass.Id);

            PictureBox[] pictureBoxes =
            {
                pictureBoxImage1,
                pictureBoxImage2,
                pictureBoxImage3
            };

            string folderPath = Path.Combine(
                Application.StartupPath,
                "ProductImages"
            );

            Directory.CreateDirectory(folderPath);

            List<string> newImagePaths = new List<string>();

            for (int i = 0; i < pictureBoxes.Length; i++)
            {
                PictureBox pictureBox = pictureBoxes[i];

                if (pictureBox.Image == null)
                    continue;

                string fileName = $"{productClass.Id}_{i + 1}.jpg";

                string fullPath = Path.Combine(
                    folderPath,
                    fileName
                );

                string relativePath = Path.Combine(
                    "ProductImages",
                    fileName
                );

                pictureBox.Image.Save(fullPath, ImageFormat.Jpeg);

                ProductImageClass image = new ProductImageClass
                {
                    ProductId = productClass.Id,
                    ImagePath = relativePath
                };

                imageRepository.AddImage(image);

                newImagePaths.Add(relativePath);
            }

            // Eliminar archivos anteriores que ya no se utilizan.
            foreach (ProductImageClass oldImage in oldImages)
            {
                if (newImagePaths.Contains(oldImage.ImagePath))
                    continue;

                string oldFilePath = Path.Combine(
                    Application.StartupPath,
                    oldImage.ImagePath
                );

                if (File.Exists(oldFilePath))
                    File.Delete(oldFilePath);
            }
        }

        private void pictureBoxImage1_Click(object sender, EventArgs e)
        {
            LoadProductImage(pictureBoxImage1);
        }

        private void pictureBoxImage2_Click(object sender, EventArgs e)
        {
            LoadProductImage(pictureBoxImage2);
        }

        private void pictureBoxImage3_Click(object sender, EventArgs e)
        {
            LoadProductImage(pictureBoxImage3);
        }

        private void LoadProductImage(PictureBox pictureBox)
        {
            openFileDialog1.Filter =
                "Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            openFileDialog1.Title = "Seleccionar imagen del producto";

            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;

            using (Image image = Image.FromFile(openFileDialog1.FileName))
            {
                pictureBox.Image?.Dispose();

                pictureBox.Image = new Bitmap(image);
            }
        }

        private void LoadComboBoxs()
        {
            CategoryRepository categoryRepository =
                new CategoryRepository();

            BrandRepository brandRepository =
                new BrandRepository();

            ProviderRepository providerRepository =
                new ProviderRepository();

            comboBoxCategory.DataSource =
                categoryRepository.GetAllCategories();

            comboBoxCategory.DisplayMember = "Name";
            comboBoxCategory.ValueMember = "Id";

            comboBoxBrand.DataSource =
                brandRepository.GetAllBrands();

            comboBoxBrand.DisplayMember = "Name";
            comboBoxBrand.ValueMember = "Id";

            comboBoxProvider.DataSource =
                providerRepository.GetAllProviders();

            comboBoxProvider.DisplayMember = "FullNameAndCuit";
            comboBoxProvider.ValueMember = "Id";
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            AdminForm dashboard = this.ParentForm as AdminForm;
            dashboard?.LoadProductControler();
        }

        private void buttonAddCategory_Click(object sender, EventArgs e)
        {
            NewCategoryForm newCategoryForm = new NewCategoryForm();
            newCategoryForm.ShowDialog();

            LoadComboBoxs();
            comboBoxCategory.SelectedValue = productClass.CategoryId;
        }

        private void buttonAddBrand_Click(object sender, EventArgs e)
        {
            NewBrandForm newBrandForm = new NewBrandForm();
            newBrandForm.ShowDialog();

            LoadComboBoxs();
            comboBoxBrand.SelectedValue = productClass.BrandId;
        }


        private void activeCheckBox_CheckedChanged(
            object sender,
            EventArgs e)
        {
            if (activeCheckBox.Checked)
            {
                stateLabel.Text = "ACTIVO";
                stateLabel.ForeColor = Color.Fuchsia;
            }
            else
            {
                stateLabel.Text = "INACTIVO";
                stateLabel.ForeColor = Color.FromArgb(90, 80, 255);
            }
        }


        private void textBoxPrice_KeyPress(
            object sender,
            KeyPressEventArgs e)
        {
            char decimalSeparator = Convert.ToChar(
                CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
            );

            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar) &&
                e.KeyChar != decimalSeparator)
            {
                e.Handled = true;
            }

            if (e.KeyChar == decimalSeparator &&
                ((TextBox)sender).Text.Contains(decimalSeparator))
            {
                e.Handled = true;
            }
        }
    }
}
