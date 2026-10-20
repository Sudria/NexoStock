using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class AdminProductPanel : UserControl
    {
        ProductRepository productRepository = new ProductRepository();
        List<ProductClass> products;
        public AdminProductPanel()
        {
            InitializeComponent();
            LoadDataGridView();
            initializeCountsPanels();
            LoadComboBoxs();

        }

        private void buttonNewProduct_Click(object sender, EventArgs e)
        {
            AdminForm dashboard = this.ParentForm as AdminForm;
            dashboard.LoadNewProductControler();
        }




        private void LoadComboBoxs()
        {
            List<CategoryClass> categories = new List<CategoryClass>();
            List<ProviderClass> providers = new List<ProviderClass>();
            CategoryRepository categoryRepository = new CategoryRepository();
            ProviderRepository providerRepository = new ProviderRepository();

            categories = categoryRepository.GetAllCategories();
            providers = providerRepository.GetAllProviders();

            categories.Insert(0, new CategoryClass { Id = 0, Name = "TODOS" });

            providers.Insert(0, new ProviderClass { Id = 0, Name = "TODOS" });

            comboBoxCategory.DataSource = categories;
            comboBoxCategory.DisplayMember = "Name";
            comboBoxCategory.ValueMember = "Id";

            comboBoxProvider.DataSource = providers;
            comboBoxProvider.DisplayMember = "FullName";
            comboBoxProvider.ValueMember = "Id";

        }

        private void LoadDataGridView()
        {
            ProductRepository productRepository = new ProductRepository();
            List<ProductClass> products = productRepository.GetAllProducts();
            dataGridViewProducts.DataSource = products;
            dataGridViewProducts.Columns["Id"].Visible = false;
            dataGridViewProducts.Columns["BrandId"].Visible = false;
            dataGridViewProducts.Columns["CategoryId"].Visible = false;
            dataGridViewProducts.Columns["ProviderId"].Visible = false;
            dataGridViewProducts.Columns["State"].Visible = false;
            dataGridViewProducts.Columns["StateText"].HeaderText = "Estado";

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Por favor, seleccione un producto para eliminar.",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            var productId = dataGridViewProducts.SelectedRows[0].Cells["Id"].Value.ToString();
            var productName = dataGridViewProducts.SelectedRows[0].Cells["Name"].Value.ToString();
            var productState = dataGridViewProducts.SelectedRows[0].Cells["StateText"].Value.ToString();

            if (productState == "Inactivo")
            {
                productRepository.RestoreProduct(Convert.ToInt32(productId));

                LoadDataGridView();

                MessageBox.Show(
                    $"Producto {productName} restaurado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            else
            {
                productRepository.DeleteProduct(Convert.ToInt32(productId));

                LoadDataGridView();

                MessageBox.Show(
                    $"Producto {productName} eliminado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }

            initializeCountsPanels();
        }

        private void buttonStyles()
        {

            var productState = dataGridViewProducts.SelectedRows[0].Cells["StateText"].Value.ToString();

            if (productState == "Activo")
            {
                buttonDelete.TextButton = "Eliminar";
                buttonDelete.ColorBackground_1 = Color.Crimson;
            }
            else
            {
                buttonDelete.TextButton = "Restaurar";
                buttonDelete.ColorBackground_1 = Color.LimeGreen;
            }
        }

        private void dataGridViewProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonStyles();
        }

        private void initializeCountsPanels()
        {
            if (products == null)
            {
                products = productRepository.GetAllProducts();
            }

            int totalProducts = products.Count;
            int activeProducts = products.Count(p => p.State);
            int inactiveProducts = products.Count(p => !p.State);


            labelCountProducts.Text = products.Count.ToString();
            labelActiveProducts.Text = activeProducts.ToString();
            labelInactiveProducts.Text = inactiveProducts.ToString();
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataFilter();
        }

        private void DataFilter()
        {
            var categoriaSeleccionada = comboBoxCategory.SelectedItem as CategoryClass;
            var proveedorSeleccionado = comboBoxProvider.SelectedItem as ProviderClass;

            if (categoriaSeleccionada == null || proveedorSeleccionado == null) return;

            int idCategorySelected = categoriaSeleccionada.Id;
            int idProviderSelected = proveedorSeleccionado.Id;

            var datosFiltrados = products.Where(p =>
                (idCategorySelected == 0 || p.CategoryId == idCategorySelected) &&
                (idProviderSelected == 0 || p.ProviderId == idProviderSelected)
            ).ToList();

            dataGridViewProducts.DataSource = datosFiltrados;
        }

        private void txtProductName_KeyDown(object sender, KeyEventArgs e)
        {
            var filteredProducts = products.Where(p =>
     p.Name.ToLower().Contains(txtProduct.Text.ToLower()) ||
     p.Cod.ToLower().Contains(txtProduct.Text.ToLower()) ||
     p.Description.ToLower().Contains(txtProduct.Text.ToLower())
 ).ToList();

            dataGridViewProducts.DataSource = filteredProducts;
        }
    }
}
