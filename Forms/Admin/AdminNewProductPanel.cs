using Microsoft.VisualBasic.ApplicationServices;
using NexoStock.Class;
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
    public partial class AdminNewProductPanel : UserControl
    {
        public AdminNewProductPanel()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            AdminForm dashboard = this.ParentForm as AdminForm;
            dashboard.LoadProductControler();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            ProductClass productClass = new ProductClass
            {
                Name = textBoxProductName.Text,
                Cod = textBoxCod.Text,
                Description = textBoxDescription.Text,
                State = activeCheckBox.Checked,
                SalePrice = !string.IsNullOrEmpty(textBoxPrice.Text) ? decimal.Parse(textBoxPrice.Text) : 0,
                Stock = (int)numericStock.ValueNumber,
                StockMin = (int)numericStockMin.ValueNumber,
                CategoryId = 1, //int.Parse(comboBoxCategory.SelectedValue.ToString()),
                BrandId =  1,//int.Parse(comboBoxBrand.SelectedValue.ToString()),
                ProviderId = 1, //int.Parse(comboBoxProvider.SelectedValue.ToString()),
                Images = new List<string>()
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

            if (!Utils.Validator.isValidNum(productClass.SalePrice.ToString(), "Precio de venta",10))
            {
                textBoxPrice.Focus();
                textBoxPrice.BorderColorA = Color.Red;
                return;
            }

            if (!Utils.Validator.isValidNum(productClass.Stock.ToString(), "Stock", 10))
            {
                numericStock.Focus();
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
    }
}
