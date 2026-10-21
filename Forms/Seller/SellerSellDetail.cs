using NexoStock.Class;
using NexoStock.Services;
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

namespace NexoStock.Forms.Seller
{
    public partial class SellerSellDetail : Form
    {

        private Sale _sale;

        public SellerSellDetail(Sale sale)
        {
            InitializeComponent();
            _sale = sale;
            LoadSaleDetails();

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadSaleDetails()
        {
            SaleDetailRepository repository =
                new SaleDetailRepository();

            DataTable details =
                repository.GetSaleDetailsTable(_sale.Id);

            dataGridDetails.DataSource = details;

            dataGridDetails.ReadOnly = true;
            dataGridDetails.AllowUserToAddRows = false;
            dataGridDetails.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            if (dataGridDetails.Columns["Precio unitario"] != null)
            {
                dataGridDetails.Columns["Precio unitario"]
                    .DefaultCellStyle.Format = "C2";
            }

            if (dataGridDetails.Columns["Subtotal"] != null)
            {
                dataGridDetails.Columns["Subtotal"]
                    .DefaultCellStyle.Format = "C2";
            }

            if (lblSaleId != null)
            {
                lblSaleId.Text = "Detalle de la venta N° " + _sale.Id;
            }

            if (_sale.SaleDate != null)
            {
                labelDate.Text = "Fecha: " + _sale.SaleDate.ToString("dd/MM/yyyy");
            }

          
                txtTotal.Text = "Total: " + _sale.Total.ToString("C2");
            

            ClientRepository repositoryClient = new ClientRepository();

            ClientClass client = repositoryClient.GetClientById(_sale.ClientId);

            if (client != null)
            {
                labelClient.Text = client.FullNameAndDni;
            }
            else
            {
                labelClient.Text = "Cliente no encontrado";
            }
        }

    }
}
