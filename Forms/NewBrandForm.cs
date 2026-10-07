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
        public NewBrandForm()
        {
            InitializeComponent();
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

            BrandClass brand = new BrandClass
            {
                Name = textBoxBrandName.Text
            };

            Services.BrandRepository brandRepository = new Services.BrandRepository();
            brandRepository.CreateBrand(brand);
            MessageBox.Show($"Marca '{brand.Name}' registrada con éxito.", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
