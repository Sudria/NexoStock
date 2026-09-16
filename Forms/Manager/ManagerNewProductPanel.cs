using Microsoft.VisualBasic.ApplicationServices;
using NexoStock.Class;
using NexoStock.Utils;
using NexoStock.Forms;
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

namespace NexoStock.Forms.Manager
{
    public partial class ManagerNewProductPanel : UserControl
    {
        public ManagerNewProductPanel()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            ManagerForm managerForm = this.ParentForm as ManagerForm;
            managerForm.LoadProductController();
        }



        private void saveButton_Click(object sender, EventArgs e)
        {
            ProductClass productClass = new ProductClass
            {
                Name = textBoxProductName.Text,
                Description = textBoxDescription.Text,
                CategoryId = int.Parse(comboBoxCategory.SelectedValue.ToString()),
                BrandId = int.Parse(comboBoxBrand.SelectedValue.ToString()),
                SalePrice = decimal.Parse(textBoxPrice.Text),
                Stock = int.Parse(textBoxStock.Text),
                StockMin = int.Parse(textBoxStockMin.Text),
                State = activeCheckBox.Checked,
                Imagenes = new List<string>()
            };

            if (!Utils.Validator.isValidText(productClass.Name, "Nombre del producto"))
            {
                textBoxProductName.Focus();
                return;
            }

            if (!Utils.Validator.isValidText(productClass.Description, "Descripción del producto"))
            {
                textBoxDescription.Focus();
                return;
            }

            if (!Utils.Validator.isValidNum(productClass.SalePrice.ToString(), "Precio de venta",10))
            {
                textBoxPrice.Focus();
                return;
            }

            if (!Utils.Validator.isValidNum(productClass.Stock.ToString(), "Stock", 10))
            {
                textBoxStock.Focus();
                return;
            }

            if (!Utils.Validator.isValidNum(productClass.StockMin.ToString(), "Stock Mínimo", 10))
            {
                textBoxStockMin.Focus();
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
    }
}
