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
using System.Xml.Linq;

namespace NexoStock.Forms.Seller
{
    public partial class SellerNewSellPanel : UserControl
    {
        private List<ClientClass> clients = new List<ClientClass>();
        private List<ProductClass> products = new List<ProductClass>();
        public SellerNewSellPanel()
        {
            InitializeComponent();
            LoadClients();
            LoadProducts();
            InitializeGridSell();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            SellerForm dashboard = this.ParentForm as SellerForm;
            dashboard.LoadSalesControler();
        }

        private void LoadClients()
        {
            ClientRepository clientRepository = new ClientRepository();
            clients = clientRepository.GetAllClients();

            comboBoxDni.DataSource = null;
            comboBoxDni.DisplayMember = "Dni";
            comboBoxDni.ValueMember = "Id";
            comboBoxDni.DataSource = clients;

            comboBoxDni.DropDownStyle = ComboBoxStyle.DropDown;
            comboBoxDni.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxDni.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void comboBoxDni_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDni.SelectedItem is ClientClass client)
            {
                txtName.Text = client.Name;
                txtSurname.Text = client.Surname;
                txtEmail.Text = client.Email;
                txtTel.Text = client.Tel;
            }
        }

        private void LoadProducts()
        {
            ProductRepository productRepository = new ProductRepository();

            products = productRepository.GetAllProducts()
                .Where(p => p.Stock > 1 && p.State == true)
                .ToList();

            comboBoxProduct.DataSource = null;
            comboBoxProduct.DisplayMember = "Name";
            comboBoxProduct.ValueMember = "Id";
            comboBoxProduct.DataSource = products;

            comboBoxProduct.DropDownStyle = ComboBoxStyle.DropDown;
            comboBoxProduct.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxProduct.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void comboBoxProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxProduct.SelectedItem is ProductClass product)
            {
                numericCount.MaxNum = product.Stock;
                numericCount.MinNum = 1;
                numericCount.ValueNumber = 1;
                txtStockDisp.Text = product.Stock.ToString();
            }
        }


        private void InitializeGridSell()
        {
            dataGridSell.AutoGenerateColumns = false;
            dataGridSell.Columns.Clear();

            dataGridSell.Columns.Add("ProductId", "ID");
            dataGridSell.Columns["ProductId"].Visible = false;

            dataGridSell.Columns.Add("Name", "Producto");
            dataGridSell.Columns.Add("Price", "Precio unitario");
            dataGridSell.Columns.Add("Quantity", "Cantidad");
            dataGridSell.Columns.Add("Subtotal", "Subtotal");
        }

        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            ProductClass product = comboBoxProduct.SelectedItem as ProductClass;

            if (product == null)
            {
                MessageBox.Show("Seleccioná un producto.");
                return;
            }

            int cantidad = (int)numericCount.ValueNumber;

            if (cantidad <= 0 || cantidad > product.Stock)
            {
                MessageBox.Show("La cantidad seleccionada no es válida.");
                return;
            }

            // Buscar si el producto ya existe en el grid
            DataGridViewRow filaExistente = null;

            foreach (DataGridViewRow row in dataGridSell.Rows)
            {
                if (row.IsNewRow)
                    continue;

                int idProducto = Convert.ToInt32(row.Cells["ProductId"].Value);

                if (idProducto == product.Id)
                {
                    filaExistente = row;
                    break;
                }
            }

            decimal precio = product.SalePrice;

            if (filaExistente != null)
            {
                // Sumar cantidad a la fila existente
                int cantidadActual = Convert.ToInt32(
                    filaExistente.Cells["Quantity"].Value
                );

                int nuevaCantidad = cantidadActual + cantidad;

                filaExistente.Cells["Quantity"].Value = nuevaCantidad;
                filaExistente.Cells["Subtotal"].Value = precio * nuevaCantidad;
            }
            else
            {
                // Agregar una fila nueva
                decimal subtotal = precio * cantidad;

                dataGridSell.Rows.Add(
                    product.Id,
                    product.Name,
                    precio,
                    cantidad,
                    subtotal
                );
            }

            // Descontar el stock disponible en memoria
            product.Stock -= cantidad;
            txtStockDisp.Text = product.Stock.ToString();

            // Actualizar el total de la venta
            CalcularTotal();

            // Actualizar el máximo de cantidad permitido
            if (product.Stock > 0)
            {
                numericCount.MinNum = 1;
                numericCount.MaxNum = product.Stock;
                numericCount.ValueNumber = 1;
                numericCount.Enabled = true;
            }
            else
            {
                comboBoxProduct.SelectedIndex = -1;
                numericCount.MinNum = 0;
                numericCount.MaxNum = 0;
                numericCount.ValueNumber = 0;
                numericCount.Enabled = false;
            }

            comboBoxProduct.Refresh();
        }

        private void CalcularTotal()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dataGridSell.Rows)
            {
                if (row.IsNewRow)
                    continue;

                total += Convert.ToDecimal(row.Cells["Subtotal"].Value);
            }

            txtTotal.Text = total.ToString("C2");
        }


    }
    
}
