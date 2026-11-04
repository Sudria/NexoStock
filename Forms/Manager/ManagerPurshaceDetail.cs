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

namespace NexoStock.Forms.Manager
{
    public partial class ManagerPurshaceDetail : Form
    {

        private int idBuy;

        public ManagerPurshaceDetail(int idBuy)
        {
            InitializeComponent();
            this.idBuy = idBuy;
            LoadPurchaseDetails();

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadPurchaseDetails()
        {
            PurchaseRepository repository = new PurchaseRepository();

            // Cargar detalles
            DataTable details = repository.GetPurchaseDetailsTable(idBuy);

            dataGridPurchaseDetails.DataSource = details;

            dataGridPurchaseDetails.ReadOnly = true;
            dataGridPurchaseDetails.AllowUserToAddRows = false;
            dataGridPurchaseDetails.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dataGridPurchaseDetails.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dataGridPurchaseDetails.MultiSelect = false;

            dataGridPurchaseDetails.Columns["ID"].Visible = false;
            dataGridPurchaseDetails.Columns["N° Compra"].Visible = false;

            dataGridPurchaseDetails.Columns["Precio de Compra"]
                .DefaultCellStyle.Format = "C2";

            dataGridPurchaseDetails.Columns["Subtotal"]
                .DefaultCellStyle.Format = "C2";

            // Cargar total de la compra
            decimal total = repository.GetPurchaseTotal(idBuy);

            txtTotal.Text = total.ToString("C2");

            DataTable purchase = repository.GetPurchaseHeader(idBuy);

            if (purchase.Rows.Count > 0)
            {
                DateTime fecha = Convert.ToDateTime(purchase.Rows[0]["Fecha"]);

                labelDate.Text = fecha.ToString("dd/MM/yyyy HH:mm");
                labelClient.Text = purchase.Rows[0]["Proveedor"].ToString();
            }
        }

    }
}
