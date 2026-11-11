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
        List<ProductClass> products = new List<ProductClass>();
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

            comboBoxState.Items.Clear();

            comboBoxState.Items.Add("TODOS");
            comboBoxState.Items.Add("ACTIVOS");
            comboBoxState.Items.Add("INACTIVOS");

            comboBoxState.SelectedIndex = 0;
        }





        private void LoadDataGridView()
        {
            try
            {
                products = productRepository.GetAllProducts();

                ApplyProductFilters();
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


        private void ApplyProductFilters()
        {
            var filteredProducts = products.AsEnumerable();

            // Filtro por stock bajo
            if (checkBoxLowStock.Checked)
            {
                filteredProducts = filteredProducts.Where(p => p.Stock < p.StockMin);
            }

            // Filtro por estado
            switch (comboBoxState.SelectedIndex)
            {
                case 1: // ACTIVOS
                    filteredProducts = filteredProducts.Where(p => p.State);
                    break;

                case 2: // INACTIVOS
                    filteredProducts = filteredProducts.Where(p => !p.State);
                    break;
            }

            // Filtro por categoría
            var categoriaSeleccionada = comboBoxCategory.SelectedItem as CategoryClass;

            if (categoriaSeleccionada != null && categoriaSeleccionada.Id != 0)
            {
                filteredProducts = filteredProducts.Where(
                    p => p.CategoryId == categoriaSeleccionada.Id
                );
            }

            // Filtro por proveedor
            var proveedorSeleccionado = comboBoxProvider.SelectedItem as ProviderClass;

            if (proveedorSeleccionado != null && proveedorSeleccionado.Id != 0)
            {
                filteredProducts = filteredProducts.Where(
                    p => p.ProviderId == proveedorSeleccionado.Id
                );
            }

            // Filtro por búsqueda
            string search = txtProduct.Text.Trim();

            if (!string.IsNullOrWhiteSpace(search))
            {
                filteredProducts = filteredProducts.Where(p =>
                    (p.Name ?? "").IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    (p.Cod ?? "").IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    (p.Description ?? "").IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0
                );
            }

            // Actualizar DataGridView
            dataGridViewProducts.DataSource = null;
            dataGridViewProducts.AutoGenerateColumns = true;
            dataGridViewProducts.DataSource = filteredProducts.ToList();

            // Ocultar columnas
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

            // Personalizar encabezados
            Dictionary<string, string> columnHeaders = new Dictionary<string, string>
    {
        { "Name", "Nombre" },
        { "Cod", "Código" },
        { "Description", "Descripción" },
        { "SalePrice", "Precio de venta" },
        { "Stock", "Stock" },
        { "StockMin", "Stock mínimo" },
        { "Brand", "Marca" },
        { "Category", "Categoría" },
        { "Provider", "Proveedor" },
        { "StateText", "Estado" }
    };

            foreach (var column in columnHeaders)
            {
                if (dataGridViewProducts.Columns.Contains(column.Key))
                {
                    dataGridViewProducts.Columns[column.Key].HeaderText = column.Value;
                }
            }
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
            int totalProducts = products.Count;
            int activeProducts = products.Count(p => p.State);
            int inactiveProducts = products.Count(p => !p.State);
            int lowStockProducts = products.Count(p => p.Stock <= p.StockMin);

            labelCountProducts.Text = totalProducts.ToString();
            labelActiveProducts.Text = activeProducts.ToString();
            labelInactiveProducts.Text = inactiveProducts.ToString();
            labelLowStockProducts.Text = lowStockProducts.ToString();
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyProductFilters();
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


        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Por favor, seleccione un producto para editar.",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            int productId = Convert.ToInt32(
                dataGridViewProducts.SelectedRows[0].Cells["Id"].Value
            );

            ProductClass selectedProduct = products
                .FirstOrDefault(p => p.Id == productId);

            if (selectedProduct == null)
                return;

            AdminForm dashboard = this.ParentForm as AdminForm;

            dashboard.LoadUpdateProductControler(selectedProduct);
        }

        private void txtProduct_TextChanged(object sender, EventArgs e)
        {
            ApplyProductFilters();
        }

        private void checkBoxLowStock_CheckedChanged(object sender, EventArgs e)
        {
            ApplyProductFilters();
        }

        private void comboBoxState_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyProductFilters();
        }
    }


}
