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

namespace NexoStock.Forms.Seller
{
    public partial class SellerSalesPanel : UserControl
    {
        UserClass user;
        private DataTable salesTable;
        public SellerSalesPanel(UserClass user)
        {
            InitializeComponent();
            this.user = user;
            LoadSales();
        }

        private void buttonNewSale_Click(object sender, EventArgs e)
        {
            SellerForm dashboard = this.ParentForm as SellerForm;
            dashboard.LoadNewSaleControler();
        }

        private void buttonDetails_Click(object sender, EventArgs e)
        {
            if (dataGridSales.CurrentRow == null)
            {
                MessageBox.Show("Seleccioná una venta.");
                return;
            }

            Sale sale = new Sale
            {
                Id = Convert.ToInt32(
           dataGridSales.CurrentRow.Cells["N° Venta"].Value),

                ClientId = Convert.ToInt32(
           dataGridSales.CurrentRow.Cells["ClientId"].Value),

                SaleDate = Convert.ToDateTime(
           dataGridSales.CurrentRow.Cells["Fecha"].Value),

                Total = Convert.ToDecimal(
           dataGridSales.CurrentRow.Cells["Total"].Value)
            };

            SellerSellDetail detailsForm = new SellerSellDetail(sale);
            detailsForm.ShowDialog();
        }

        private void LoadSales()
        {
            SaleRepository saleRepository = new SaleRepository();

            salesTable = saleRepository.GetSalesByUserId(user.Id);

            dataGridSales.DataSource = salesTable;

            dataGridSales.ReadOnly = true;
            dataGridSales.AllowUserToAddRows = false;
            dataGridSales.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dataGridSales.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dataGridSales.MultiSelect = false;

            dataGridSales.Columns["Fecha"].DefaultCellStyle.Format =
                "dd/MM/yyyy HH:mm";

            dataGridSales.Columns["Total"].DefaultCellStyle.Format = "C2";
        }

        private void txtSearchSale_TextChanged(object sender, EventArgs e)
        {
            FilterSales();
        }


        private void FilterSales()
        {
            if (salesTable == null)
                return;

            List<string> filtros = new List<string>();


            if (dateTimePickerFrom.Value.Date > dateTimePickerTo.Value.Date)
            {
                salesTable.DefaultView.RowFilter = "1 = 0";
                return;
            }

            // Filtro por número de venta o DNI
            string search = txtSearchSale.Text.Trim().Replace("'", "''");

            if (!string.IsNullOrWhiteSpace(search))
            {
                filtros.Add(
                    "Convert([N° Venta], 'System.String') LIKE '%" + search + "%' OR " +
                    "[DNI Cliente] LIKE '%" + search + "%'"
                );
            }

            // Filtro desde la fecha
            DateTime desde = dateTimePickerFrom.Value.Date;

            filtros.Add(
                "[Fecha] >= #" + desde.ToString("MM/dd/yyyy") + "#"
            );

            // Filtro hasta la fecha, incluyendo todo el día
            DateTime hasta = dateTimePickerTo.Value.Date.AddDays(1);

            filtros.Add(
                "[Fecha] < #" + hasta.ToString("MM/dd/yyyy") + "#"
            );

            salesTable.DefaultView.RowFilter = string.Join(" AND ", filtros);
        }

        private void dateTimePickerTo_ValueChanged(object sender, EventArgs e)
        {
            FilterSales();
        }

        private void dateTimePickerFrom_ValueChanged(object sender, EventArgs e)
        {
            FilterSales();
        }
    }
}
