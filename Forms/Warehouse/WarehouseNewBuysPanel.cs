using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using NexoStock.Class;
using NexoStock.Services;
using NexoStock.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NexoStock.Forms.Warehouse
{
    public partial class WarehouseNewBuysPanel : UserControl
    {
        private int? selectedProviderId = null;
        private UserClass user = new UserClass();
        public WarehouseNewBuysPanel(UserClass user)
        {
            InitializeComponent();
            LoadComboBoxs();
            ConfigurePurchaseGrid();
            this.user = user;
        }

        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            if (comboBoxProduct.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un producto.");
                return;
            }

            int providerId = Convert.ToInt32(comboBoxProvider.SelectedValue);

            if (selectedProviderId.HasValue &&
                selectedProviderId.Value != providerId)
            {
                MessageBox.Show(
                    "Todos los productos de una compra deben pertenecer al mismo proveedor."
                );
                return;
            }

            if (!decimal.TryParse(textBoxCost.Text, out decimal cost) || cost < 0)
            {
                MessageBox.Show("Ingrese un precio de compra válido.");
                return;
            }

            if (!decimal.TryParse(textBoxSellPrice.Text, out decimal salePrice) || salePrice < 0)
            {
                MessageBox.Show("Ingrese un precio de venta válido.");
                return;
            }

            ProductClass product = (ProductClass)comboBoxProduct.SelectedItem;
            int quantity = (int)numericQuantity.ValueNumber;

            if (quantity <= 0)
            {
                MessageBox.Show("Ingrese una cantidad válida.");
                return;
            }

            bool exists = false;

            foreach (DataGridViewRow row in dataGridPurchaseDetails.Rows)
            {
                int productId = Convert.ToInt32(row.Cells["ProductId"].Value);

                if (productId == product.Id)
                {
                    int currentQuantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                    int newQuantity = currentQuantity + quantity;

                    row.Cells["Quantity"].Value = newQuantity;
                    row.Cells["Subtotal"].Value = newQuantity * cost;

                    row.Cells["PurchasePrice"].Value = cost;
                    row.Cells["SalePrice"].Value = salePrice;

                    exists = true;
                    break;
                }
            }

            if (!exists)
            {
                dataGridPurchaseDetails.Rows.Add(
                    product.Id,
                    product.Name,
                    quantity,
                    cost,
                    salePrice,
                    quantity * cost
                );
            }

            selectedProviderId = providerId;
            comboBoxProvider.Enabled = false;

            CalculatePurchaseTotal();
        }

        private void textBoxCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' &&   e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void textBoxCost_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(
                textBoxCost.Text.Replace('.', ','),
                out decimal cost))
            {
                decimal percentage = numericNetwin.Value;

                decimal sellPrice = cost + (cost * percentage / 100);

                textBoxSellPrice.Text = sellPrice.ToString("F2");
            }
            else
            {
                textBoxSellPrice.Clear();
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            WarehouseForm dashboard = this.ParentForm as WarehouseForm;
            dashboard.LoadBuysControler(user);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxProvider.SelectedIndex == -1 ||
                comboBoxProvider.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un proveedor.");
                return;
            }

            if (dataGridPurchaseDetails.Rows.Count == 0)
            {
                MessageBox.Show("Agregue al menos un producto a la compra.");
                return;
            }

            int providerId = Convert.ToInt32(comboBoxProvider.SelectedValue);

            ConnectionDB connectionDB = new ConnectionDB();

            using (MySqlConnection connection = connectionDB.GetConnection())
            using (MySqlTransaction transaction = connection.BeginTransaction())
            {
                try
                {
                    decimal total = 0;

                    foreach (DataGridViewRow row in dataGridPurchaseDetails.Rows)
                    {
                        total += Convert.ToDecimal(row.Cells["Subtotal"].Value);
                    }

                    // 1. Registrar la cabecera de la compra
                    string queryPurchase = @"
                INSERT INTO purchases
                    (ProviderId, UserId, PurchaseDate, Total)
                VALUES
                    (@ProviderId, @UserId, NOW(), @Total);
            ";

                    int purchaseId;

                    using (MySqlCommand command = new MySqlCommand(
                        queryPurchase, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@ProviderId", providerId);
                        command.Parameters.AddWithValue("@UserId", user.Id);
                        command.Parameters.AddWithValue("@Total", total);

                        command.ExecuteNonQuery();
                        purchaseId = (int)command.LastInsertedId;
                    }

                    // 2. Registrar los detalles de la compra
                    string queryDetail = @"
                INSERT INTO purchase_details
                    (PurchaseId, ProductId, Quantity, PurchasePrice)
                VALUES
                    (@PurchaseId, @ProductId, @Quantity, @PurchasePrice);
            ";

                    // 3. Actualizar el precio de venta del producto
                    string queryUpdatePrice = @"
                UPDATE products
                SET SalePrice = @SalePrice
                WHERE Id = @ProductId;
            ";

                    foreach (DataGridViewRow row in dataGridPurchaseDetails.Rows)
                    {
                        int productId = Convert.ToInt32(row.Cells["ProductId"].Value);
                        int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                        decimal purchasePrice = Convert.ToDecimal(
                            row.Cells["PurchasePrice"].Value);
                        decimal salePrice = Convert.ToDecimal(
                            row.Cells["SalePrice"].Value);

                        using (MySqlCommand command = new MySqlCommand(
                            queryDetail, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@PurchaseId", purchaseId);
                            command.Parameters.AddWithValue("@ProductId", productId);
                            command.Parameters.AddWithValue("@Quantity", quantity);
                            command.Parameters.AddWithValue("@PurchasePrice", purchasePrice);

                            command.ExecuteNonQuery();
                        }

                        using (MySqlCommand command = new MySqlCommand(
                            queryUpdatePrice, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@SalePrice", salePrice);
                            command.Parameters.AddWithValue("@ProductId", productId);

                            command.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();

                    MessageBox.Show(
                        $"Compra registrada correctamente. N.º {purchaseId}",
                        "Compra registrada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    // Limpiar el formulario después de guardar
                    dataGridPurchaseDetails.Rows.Clear();
                    selectedProviderId = null;

                    comboBoxProvider.Enabled = true;
                    comboBoxProduct.DataSource = null;

                    textBoxTotal.Clear();
                }
                catch (Exception ex)
                {
                    try
                    {
                        transaction.Rollback();
                    }
                    catch
                    {
                        // La transacción podría ya estar finalizada.
                    }

                    MessageBox.Show(
                        "Error al registrar la compra: " + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }


        private void LoadComboBoxs()
        {
            //Proveedores activos
            List<ProviderClass> providers = new List<ProviderClass>();
            ProviderRepository providerRepository = new ProviderRepository();
            providers = providerRepository.GetAllActiveProviders();

            comboBoxProvider.DataSource = providers;
            comboBoxProvider.DisplayMember = "FullNameAndCuit";
            comboBoxProvider.ValueMember = "Id";

            comboBoxProvider.SelectedIndex = -1;


       
        }

        private void comboBoxProvider_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxProvider.SelectedIndex == -1 ||
                comboBoxProvider.SelectedValue == null)
            {
                comboBoxProduct.DataSource = null;
                return;
            }

            if (int.TryParse(
                comboBoxProvider.SelectedValue.ToString(),
                out int providerId))
            {
                LoadProductsByProvider(providerId);
            }
        }


        private void LoadProductsByProvider(int providerId)
        {
            ProductRepository productRepository = new ProductRepository();

            comboBoxProduct.DataSource = null;
            comboBoxProduct.DataSource =
                productRepository.GetProductsByProvider(providerId);

            comboBoxProduct.DisplayMember = "Name";
            comboBoxProduct.ValueMember = "Id";
            comboBoxProduct.SelectedIndex = -1;
        }

        private void numericNetwin_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(
      textBoxCost.Text.Replace('.', ','),
      out decimal cost))
            {
                decimal percentage = numericNetwin.Value;

                decimal sellPrice = cost + (cost * percentage / 100);

                textBoxSellPrice.Text = sellPrice.ToString("F2");
            }
            else
            {
                textBoxSellPrice.Clear();
            }
        }

    
           private void ConfigurePurchaseGrid()
           {
            dataGridPurchaseDetails.AutoGenerateColumns = false;
            dataGridPurchaseDetails.Columns.Clear();

            dataGridPurchaseDetails.Columns.Add("ProductId", "ID");
            dataGridPurchaseDetails.Columns.Add("ProductName", "Producto");
            dataGridPurchaseDetails.Columns.Add("Quantity", "Cantidad");
            dataGridPurchaseDetails.Columns.Add("PurchasePrice", "Precio de compra");
            dataGridPurchaseDetails.Columns.Add("SalePrice", "Precio de venta");
            dataGridPurchaseDetails.Columns.Add("Subtotal", "Subtotal");

            dataGridPurchaseDetails.Columns["ProductId"].Visible = false;

            dataGridPurchaseDetails.AllowUserToAddRows = false;
            dataGridPurchaseDetails.ReadOnly = true;
        
            }


        private void CalculatePurchaseTotal()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dataGridPurchaseDetails.Rows)
            {
                if (row.Cells["Subtotal"].Value != null)
                {
                    total += Convert.ToDecimal(row.Cells["Subtotal"].Value);
                }
            }

            textBoxTotal.Text = total.ToString("F2");
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (dataGridPurchaseDetails.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un producto para quitar.");
                return;
            }

            dataGridPurchaseDetails.Rows.Remove(
                dataGridPurchaseDetails.SelectedRows[0]
            );

            CalculatePurchaseTotal();

            if (dataGridPurchaseDetails.Rows.Count == 0)
            {
                selectedProviderId = null;
                comboBoxProvider.Enabled = true;
                comboBoxProduct.DataSource = null;
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            dataGridPurchaseDetails.Rows.Clear();

            selectedProviderId = null;
            comboBoxProvider.Enabled = true;
            comboBoxProduct.DataSource = null;

            textBoxTotal.Clear();
        }
    }
}
