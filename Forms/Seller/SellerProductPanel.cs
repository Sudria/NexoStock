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

namespace NexoStock.Forms.Seller
{
    public partial class SellerProductPanel : UserControl
    {

        ProductRepository productRepository = new ProductRepository();
        List<ProductClass> products = new List<ProductClass>();
        public SellerProductPanel()
        {
            InitializeComponent();
            LoadDataGridView();
            initializeCountsPanels();
            LoadComboBoxs();

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
        private void txtProductName_KeyDown(object sender, KeyEventArgs e)
        {
            var filteredProducts = products.Where(p =>
            p.Name.ToLower().Contains(txtProduct.Text.ToLower()) ||
            p.Cod.ToLower().Contains(txtProduct.Text.ToLower()) ||
            p.Description.ToLower().Contains(txtProduct.Text.ToLower())
            ).ToList();

            dataGridViewProducts.DataSource = filteredProducts;
        }



        private void LoadDataGridView()
        {
            try
            {
                products = productRepository.GetAllProducts();

                dataGridViewProducts.DataSource = null;
                dataGridViewProducts.AutoGenerateColumns = true;
                dataGridViewProducts.DataSource = products;

                string[] hiddenColumns =
                {
            "Id",
            "BrandId",
            "CategoryId",
            "ProviderId",
            "State"
        };

                foreach (string column in hiddenColumns)
                {
                    if (dataGridViewProducts.Columns.Contains(column))
                        dataGridViewProducts.Columns[column].Visible = false;
                }

                if (dataGridViewProducts.Columns.Contains("StateText"))
                    dataGridViewProducts.Columns["StateText"].HeaderText = "Estado";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al cargar los productos:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        private void initializeCountsPanels()
        {
            int totalProducts = products.Count;
            int activeProducts = products.Count(p => p.State);
            int inactiveProducts = products.Count(p => !p.State);

            labelCountProducts.Text = totalProducts.ToString();
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



    }


}
