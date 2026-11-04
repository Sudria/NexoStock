using NexoStock.Class;
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

namespace NexoStock.Forms
{
    public partial class NewBrandForm : Form
    {
        BrandClass brand = new BrandClass();
        public NewBrandForm(BrandClass brand = null)
        {
            InitializeComponent();
            if (brand != null)
            {
                this.brand = brand;
                textBoxBrandName.Text = brand.Name;
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (!Utils.Validator.isValidText(textBoxBrandName.Text, "Nombre de la Marca"))
            {
                textBoxBrandName.Focus();
                return;
            }

            if (this.brand == null)
            {
                BrandClass newBrand = new BrandClass
                {
                    Name = textBoxBrandName.Text
                };

                Services.BrandRepository brandRepository = new Services.BrandRepository();
                brandRepository.CreateBrand(newBrand);
                MessageBox.Show($"Marca '{newBrand.Name}' registrada con éxito.", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();

            }
            else
            {
                this.brand.Name = textBoxBrandName.Text;
                Services.BrandRepository brandRepository = new Services.BrandRepository();
                brandRepository.UpdateBrand(this.brand);
                MessageBox.Show($"Marca '{this.brand.Name}' actualizada con éxito.", "Actualización Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
            }



        }
    }
}
