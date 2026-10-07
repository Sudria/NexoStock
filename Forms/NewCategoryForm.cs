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
    public partial class NewCategoryForm : Form
    {
        public NewCategoryForm()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (!Utils.Validator.isValidText(textBoxCategoryName.Text, "Nombre de Categoría"))
            {
                textBoxCategoryName.Focus();
                return;
            }

            CategoryClass category = new CategoryClass
            {
                Name = textBoxCategoryName.Text
            };

            Services.CategoryRepository categoryRepository = new Services.CategoryRepository();
            categoryRepository.CreateCategory(category);
            MessageBox.Show($"Categoría '{category.Name}' registrada con éxito.", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
