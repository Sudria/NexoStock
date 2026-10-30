using Microsoft.VisualBasic.ApplicationServices;
using NexoStock.Class;
using NexoStock.Services;
using NexoStock.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NexoStock.Forms.Admin
{
    public partial class AdminUpdateProductPanel : UserControl
    {
        ProductClass productClass = new ProductClass();

        public AdminUpdateProductPanel(ProductClass product)
        {
            InitializeComponent();
            LoadComboBoxs();
            ProductClass productClass = product;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            AdminForm dashboard = this.ParentForm as AdminForm;
            dashboard.LoadProductControler();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            textBoxProductName.Text = productClass.Name;
            textBoxCod.Text = productClass.Cod;
            textBoxDescription.Text = productClass.Description;
            activeCheckBox.Checked = productClass.State;
            numericStockMin.ValueNumber = productClass.StockMin;
            comboBoxCategory.SelectedValue = productClass.CategoryId;
            comboBoxBrand.SelectedValue = productClass.BrandId;
            comboBoxProvider.SelectedValue = productClass.ProviderId;
            textBoxPrice.Text = productClass.SalePrice.ToString();

            ProductClass productClas = new ProductClass
            {
                Id = productClass.Id,
                Name = textBoxProductName.Text,
                Cod = textBoxCod.Text,
                Description = textBoxDescription.Text,
                State = activeCheckBox.Checked,
                StockMin = (int)numericStockMin.ValueNumber,
                CategoryId = 1, //int.Parse(comboBoxCategory.SelectedValue.ToString()),
                BrandId =  1,//int.Parse(comboBoxBrand.SelectedValue.ToString()),
                ProviderId = 1, //int.Parse(comboBoxProvider.SelectedValue.ToString()),
            };

            if (!Utils.Validator.isValidText(productClass.Name, "Nombre del producto"))
            {
                textBoxProductName.Focus();
                textBoxProductName.BorderColorA = Color.Red;
                return;
            }

            if (!Utils.Validator.isValidText(productClass.Description, "Descripción del producto"))
            {
                textBoxDescription.Focus();
                textBoxDescription.BorderColorA = Color.Red;
                return;
            }


            if (!Utils.Validator.isValidNum(productClass.StockMin.ToString(), "Stock Mínimo", 10))
            {
                numericStockMin.Focus();
                return;
            }

            if (comboBoxCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una categoría.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxCategory.Focus();
                return;
            }

            if (comboBoxBrand.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una marca.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxBrand.Focus();
                return;
            }

            if(comboBoxProvider.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un proveedor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxProvider.Focus();
                return;
            }

        }



  



        //BUTTON (+) ADD CATEGORY AND BRAND
        private void buttonAddCategory_Click(object sender, EventArgs e)
        {
            NewCategoryForm newCategoryForm = new NewCategoryForm();
            newCategoryForm.ShowDialog();
        }

        private void buttonAddBrand_Click(object sender, EventArgs e)
        {
            NewBrandForm newBrandForm = new NewBrandForm();
            newBrandForm.ShowDialog();
        }


        //CHECKBOX
        private void activeCheckBox_CheckedChanged(object sender, EventArgs e)
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

        private void pictureBoxImage1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBoxImage1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void pictureBoxImage2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBoxImage2.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void pictureBoxImage3_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBoxImage3.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void LoadComboBoxs()
        {
            List<CategoryClass> categories = new List<CategoryClass>();
            List<BrandClass> brands = new List<BrandClass>();
            List<ProviderClass> providers = new List<ProviderClass>();
            CategoryRepository CategoryClass = new CategoryRepository();
            BrandRepository brandRepository = new BrandRepository();
            ProviderRepository providerRepository = new ProviderRepository();

            categories = CategoryClass.GetAllCategories();
            brands = brandRepository.GetAllBrands();
            providers = providerRepository.GetAllProviders();
            comboBoxCategory.DataSource = categories;
            comboBoxCategory.DisplayMember = "Name";
            comboBoxCategory.ValueMember = "Id";
            comboBoxBrand.DataSource = brands;
            comboBoxBrand.DisplayMember = "Name";
            comboBoxBrand.ValueMember = "Id";
            comboBoxProvider.DataSource = providers;
            comboBoxProvider.DisplayMember = "FullNameAndCuit";
            comboBoxProvider.ValueMember = "Id";
        }

        private void textBoxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            char decimalSeparator = Convert.ToChar(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != decimalSeparator))
            {
                e.Handled = true; 
            }

            if ((e.KeyChar == decimalSeparator) && ((sender as TextBox).Text.IndexOf(decimalSeparator) > -1))
            {
                e.Handled = true;
            }
        }
    }
}
