using NexoStock.Class;
using NexoStock.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NexoStock.Forms.Admin
{
    public partial class AdminCategoryAndBrandPanel : UserControl
    {
        private List<CategoryClass> categories;
        private List<BrandClass> brands;
        public AdminCategoryAndBrandPanel()
        {
            InitializeComponent();
            LoadDataGrids();
        }


        private void buttonNewBrand_Click(object sender, EventArgs e)
        {
            NewBrandForm newBrandForm = new NewBrandForm();
            newBrandForm.ShowDialog();
        }

        private void buttonNewCattegory_Click(object sender, EventArgs e)
        {
            NewCategoryForm newCategoryForm = new NewCategoryForm();
            newCategoryForm.ShowDialog();
        }



        private void LoadDataGrids()
        {
            try
            {
                BrandRepository brandRepository = new BrandRepository();
                CategoryRepository categoryRepository = new CategoryRepository();

                 brands = brandRepository.GetAllBrands();
                 categories = categoryRepository.GetAllCategories();

                // DataGridView de marcas
                var brandData = brands.Select(b => new
                {
                    b.Id,
                    b.Name,
                    StateText = b.State ? "Activo" : "Inactivo"
                }).ToList();

                dataGridBrand.DataSource = null;
                dataGridBrand.AutoGenerateColumns = true;
                dataGridBrand.DataSource = brandData;

                // DataGridView de categorías
                var categoryData = categories.Select(c => new
                {
                    c.Id,
                    c.Name,
                    StateText = c.State ? "Activo" : "Inactivo"
                }).ToList();

                dataGridCategory.DataSource = null;
                dataGridCategory.AutoGenerateColumns = true;
                dataGridCategory.DataSource = categoryData;

                // Ocultar IDs
                dataGridBrand.Columns["Id"].Visible = false;
                dataGridCategory.Columns["Id"].Visible = false;

                // Personalizar encabezados
                dataGridBrand.Columns["Name"].HeaderText = "Nombre";
                dataGridBrand.Columns["StateText"].HeaderText = "Estado";

                dataGridCategory.Columns["Name"].HeaderText = "Nombre";
                dataGridCategory.Columns["StateText"].HeaderText = "Estado";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al cargar marcas y categorías:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void buttonDeleteCategory_Click(object sender, EventArgs e)
        {
            if (dataGridCategory.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Por favor, seleccione una categoría para eliminar.",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            CategoryRepository categoryRepository = new CategoryRepository();


            var categoryId = dataGridCategory.SelectedRows[0].Cells["Id"].Value.ToString();
            var categoryName = dataGridCategory.SelectedRows[0].Cells["Name"].Value.ToString();
            var categoryState = dataGridCategory.SelectedRows[0].Cells["StateText"].Value.ToString();

            if (categoryState == "Inactivo")
            {
                categoryRepository.RestoreCategory(Convert.ToInt32(categoryId));

                LoadDataGrids();

                MessageBox.Show(
                    $"Categoría {categoryName} restaurada correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            else
            {
                categoryRepository.DeleteCategory(Convert.ToInt32(categoryId));

                LoadDataGrids();

                MessageBox.Show(
                    $"Categoría {categoryName} eliminada correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private void buttonDeleteBrand_Click(object sender, EventArgs e)
        {
            if (dataGridBrand.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Por favor, seleccione una marca para eliminar.",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            BrandRepository brandRepository = new BrandRepository();

            var brandId = dataGridBrand.SelectedRows[0].Cells["Id"].Value.ToString();
            var brandName = dataGridBrand.SelectedRows[0].Cells["Name"].Value.ToString();
            var brandState = dataGridBrand.SelectedRows[0].Cells["StateText"].Value.ToString();

            if (brandState == "Inactivo")
            {
                brandRepository.RestoreBrand(Convert.ToInt32(brandId));
                LoadDataGrids();
                MessageBox.Show(
                    $"Marca {brandName} restaurada correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            else
            {
                brandRepository.DeleteBrand(Convert.ToInt32(brandId));
                LoadDataGrids();
                MessageBox.Show(
                    $"Marca {brandName} eliminada correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private void buttonStylesCategory()
        {

            var productState = dataGridCategory.SelectedRows[0].Cells["StateText"].Value.ToString();

            if (productState == "Activo")
            {
                buttonDeleteCategory.TextButton = "Eliminar";
                buttonDeleteCategory.ColorBackground_1 = Color.Crimson;
            }
            else
            {
                buttonDeleteCategory.TextButton = "Restaurar";
                buttonDeleteCategory.ColorBackground_1 = Color.LimeGreen;
            }
        }

        private void buttonStylesBrand()
        {

            var productState = dataGridBrand.SelectedRows[0].Cells["StateText"].Value.ToString();

            if (productState == "Activo")
            {
                buttonDeleteBrand.TextButton = "Eliminar";
                buttonDeleteBrand.ColorBackground_1 = Color.Crimson;
            }
            else
            {
                buttonDeleteBrand.TextButton = "Restaurar";
                buttonDeleteBrand.ColorBackground_1 = Color.LimeGreen;
            }
        }

        private void dataGridCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonStylesCategory();
        }

        private void dataGridBrand_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonStylesBrand();
        }

        private void textBoxCategoryName_TextChanged(object sender, EventArgs e)
        {
            string search = textBoxCategoryName.Text.Trim().ToLower();

            var filteredCategories = categories
                .Where(c => c.Name.ToLower().Contains(search))
                .Select(c => new
                {
                    c.Id,
                    c.Name,
                    StateText = c.State ? "Activo" : "Inactivo"
                })
                .ToList();

            dataGridCategory.DataSource = null;
            dataGridCategory.DataSource = filteredCategories;

            dataGridCategory.Columns["Id"].Visible = false;
            dataGridCategory.Columns["Name"].HeaderText = "Nombre";
            dataGridCategory.Columns["StateText"].HeaderText = "Estado";
        }

        private void textBoxBrandName_TextChanged(object sender, EventArgs e)
        {
            string search = textBoxBrandName.Text.Trim().ToLower();

            var filteredBrands = brands
                .Where(b => b.Name.ToLower().Contains(search))
                .Select(b => new
                {
                    b.Id,
                    b.Name,
                    StateText = b.State ? "Activo" : "Inactivo"
                })
                .ToList();

            dataGridBrand.DataSource = null;
            dataGridBrand.DataSource = filteredBrands;

            dataGridBrand.Columns["Id"].Visible = false;
            dataGridBrand.Columns["Name"].HeaderText = "Nombre";
            dataGridBrand.Columns["StateText"].HeaderText = "Estado";
        }

        private void buttonEditBrand_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridBrand.SelectedRows[0];



            int id = Convert.ToInt32(row.Cells["Id"].Value);
            string name = row.Cells["Name"].Value.ToString();
            bool state = row.Cells["StateText"].Value.ToString() == "Activo";

            BrandClass brand = new BrandClass
            {
                Id = id,
                Name = name,
                State = state
            };

            NewBrandForm newBrandForm = new NewBrandForm(brand);
            newBrandForm.ShowDialog();
            LoadDataGrids();
        }

        private void buttonEditCategory_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridCategory.SelectedRows[0];



            int id = Convert.ToInt32(row.Cells["Id"].Value);
            string name = row.Cells["Name"].Value.ToString();
            bool state = row.Cells["StateText"].Value.ToString() == "Activo";

            CategoryClass category = new CategoryClass
            {
                Id = id,
                Name = name,
                State = state
            };

            NewCategoryForm newCategoryForm = new NewCategoryForm(category);
            newCategoryForm.ShowDialog();
            LoadDataGrids();
        }
    }
}
