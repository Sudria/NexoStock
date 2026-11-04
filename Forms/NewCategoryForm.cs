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
        CategoryClass category = new CategoryClass();
        public NewCategoryForm(CategoryClass category = null)
        {
            InitializeComponent();
            if (category != null)
            {
                this.category = category;
                textBoxCategoryName.Text = category.Name;
            }
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

            if (this.category == null)
            {
                CategoryClass newCategory = new CategoryClass
                {
                    Name = textBoxCategoryName.Text
                };

                Services.CategoryRepository categoryRepository = new Services.CategoryRepository();
                categoryRepository.CreateCategory(newCategory);
                MessageBox.Show($"Categoría '{newCategory.Name}' registrada con éxito.", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
            }
            else
            {
                this.category.Name = textBoxCategoryName.Text;
                Services.CategoryRepository categoryRepository = new Services.CategoryRepository();
                categoryRepository.UpdateCategory(this.category);
                MessageBox.Show($"Categoría '{this.category.Name}' actualizada con éxito.", "Actualización Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();


            }
        }
    }
}

