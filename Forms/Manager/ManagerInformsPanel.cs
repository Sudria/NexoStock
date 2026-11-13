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
using System.Windows.Forms.DataVisualization.Charting;

namespace NexoStock.Forms.Manager
{
    public partial class ManagerInformsPanel : UserControl
    {
        private bool filterByDate = true;
        public ManagerInformsPanel()
        {
            InitializeComponent();
            comboBoxInforms.SelectedIndex = 0;
        }

        private void comboBoxInforms_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxInforms.SelectedIndex)
            {
                case 0:
                    LoadTopSellingProducts();
                    break;


                case 1:
                    LoadTopSellingCategories();
                    break;

                case 2:
                    LoadBestSellers();
                    break;

                case 3:
                    LoadTopSellingBrands();
                    break;

                case 4:
                    LoadBestClients();
                    break;

                case 5:
                    LoadSalesByPeriod();
                    break;

            }
        }







        private void LoadTopSellingProducts()
        {
            if (filterByDate && dateTimePickerFrom.Value.Date > dateTimePickerTo.Value.Date)
            {
                MessageBox.Show("La fecha desde no puede ser posterior a la fecha hasta.");
                return;
            }

            SaleRepository repository = new SaleRepository();

            DataTable data = repository.GetTopSellingProducts(
                GetFromDate(),
                GetToDate()
            );

            dataGridInforms.DataSource = data;

            dataGridInforms.Columns["Id"].Visible = false;
            dataGridInforms.Columns["Producto"].HeaderText = "Producto";
            dataGridInforms.Columns["Codigo"].HeaderText = "Código";
            dataGridInforms.Columns["CantidadVendida"].HeaderText = "Unidades vendidas";
            dataGridInforms.Columns["TotalFacturado"].HeaderText = "Total facturado";

            dataGridInforms.Columns["TotalFacturado"].DefaultCellStyle.Format = "C2";

            LoadTopSellingProductsChart(data);
        }

        private void LoadTopSellingCategories()
        {
            if (filterByDate && dateTimePickerFrom.Value.Date > dateTimePickerTo.Value.Date)
            {
                MessageBox.Show("La fecha desde no puede ser posterior a la fecha hasta.");
                return;
            }

            SaleRepository repository = new SaleRepository();

            DataTable data = repository.GetTopSellingCategories(
                GetFromDate(),
                GetToDate()
            );

            dataGridInforms.DataSource = data;

            dataGridInforms.Columns["Id"].Visible = false;
            dataGridInforms.Columns["Categoria"].HeaderText = "Categoría";
            dataGridInforms.Columns["CantidadVendida"].HeaderText = "Unidades vendidas";
            dataGridInforms.Columns["TotalFacturado"].HeaderText = "Total facturado";

            dataGridInforms.Columns["TotalFacturado"].DefaultCellStyle.Format = "C2";

            LoadTopSellingCategoriesChart(data);
        }

        private void LoadTopSellingCategoriesChart(DataTable data)
        {
            chartInforms.Series.Clear();
            chartInforms.ChartAreas.Clear();
            chartInforms.Legends.Clear();
            chartInforms.Titles.Clear();

            chartInforms.Titles.Add("Ventas por categoría");

            chartInforms.ChartAreas.Add(new ChartArea("MainArea"));
            chartInforms.Legends.Add(new Legend("MainLegend"));

            Series series = new Series("Categorías");
            series.ChartType = SeriesChartType.Doughnut;
            series.IsValueShownAsLabel = true;
            series.Label = "#VALX: #VALY (#PERCENT{P1})";
            series["DoughnutHoleSize"] = "55";

            foreach (DataRow row in data.Rows)
            {
                string categoryName = row["Categoria"].ToString();
                int quantity = Convert.ToInt32(row["CantidadVendida"]);

                series.Points.AddXY(categoryName, quantity);
            }

            chartInforms.Series.Add(series);
        }

        private void LoadTopSellingProductsChart(DataTable data)
        {
            chartInforms.Series.Clear();
            chartInforms.ChartAreas.Clear();
            chartInforms.Legends.Clear();
            chartInforms.Titles.Clear();

            chartInforms.Titles.Add("Top 10 productos más vendidos");

            ChartArea area = new ChartArea("MainArea");
            area.AxisX.Title = "Unidades vendidas";
            area.AxisY.Title = "Productos";
            area.AxisY.Interval = 1;

            chartInforms.ChartAreas.Add(area);

            Series series = new Series("Unidades vendidas");
            series.ChartType = SeriesChartType.Bar;
            series.IsValueShownAsLabel = true;
            series.LabelFormat = "N0";

            foreach (DataRow row in data.Rows)
            {
                string productName = row["Producto"].ToString();
                int quantity = Convert.ToInt32(row["CantidadVendida"]);

                series.Points.AddXY(productName, quantity);
            }

            chartInforms.Series.Add(series);
        }

        private void LoadBestSellers()
        {
            if (filterByDate && dateTimePickerFrom.Value.Date > dateTimePickerTo.Value.Date)
            {
                MessageBox.Show("La fecha desde no puede ser posterior a la fecha hasta.");
                return;
            }

            SaleRepository repository = new SaleRepository();

            DataTable data = repository.GetBestSellers(
                GetFromDate(),
                GetToDate()
            );

            // Agregar columna de puesto
            data.Columns.Add("Puesto", typeof(int)).SetOrdinal(0);

            for (int i = 0; i < data.Rows.Count; i++)
            {
                data.Rows[i]["Puesto"] = i + 1;
            }

            dataGridInforms.DataSource = data;

            dataGridInforms.Columns["Id"].Visible = false;
            dataGridInforms.Columns["Puesto"].HeaderText = "Puesto";
            dataGridInforms.Columns["Vendedor"].HeaderText = "Vendedor";
            dataGridInforms.Columns["CantidadVentas"].HeaderText = "Cantidad de ventas";
            dataGridInforms.Columns["TotalFacturado"].HeaderText = "Total facturado";

            dataGridInforms.Columns["TotalFacturado"].DefaultCellStyle.Format = "C2";

            LoadBestSellersChart(data);
        }


        private void LoadBestSellersChart(DataTable data)
        {
            chartInforms.Series.Clear();
            chartInforms.ChartAreas.Clear();
            chartInforms.Legends.Clear();
            chartInforms.Titles.Clear();

            chartInforms.Titles.Add("Top 10 mejores vendedores");

            ChartArea area = new ChartArea("MainArea");
            area.AxisX.Title = "Total facturado";
            area.AxisY.Title = "Vendedores";
            area.AxisX.LabelStyle.Format = "C0";

            chartInforms.ChartAreas.Add(area);

            Series series = new Series("Facturación");
            series.ChartType = SeriesChartType.Bar;
            series.IsValueShownAsLabel = true;
            series.LabelFormat = "C0";

            foreach (DataRow row in data.Rows)
            {
                string seller = row["Vendedor"].ToString();
                decimal total = Convert.ToDecimal(row["TotalFacturado"]);

                series.Points.AddXY(seller, total);
            }

            chartInforms.Series.Add(series);
        }

        private void LoadTopSellingBrands()
        {
            if (filterByDate && dateTimePickerFrom.Value.Date > dateTimePickerTo.Value.Date)
            {
                MessageBox.Show("La fecha desde no puede ser posterior a la fecha hasta.");
                return;
            }

            SaleRepository repository = new SaleRepository();

            DataTable data = repository.GetTopSellingBrands(
                GetFromDate(),
                GetToDate()
            );

            data.Columns.Add("Puesto", typeof(int)).SetOrdinal(0);

            for (int i = 0; i < data.Rows.Count; i++)
            {
                data.Rows[i]["Puesto"] = i + 1;
            }

            dataGridInforms.DataSource = data;

            dataGridInforms.Columns["Id"].Visible = false;
            dataGridInforms.Columns["Puesto"].HeaderText = "Puesto";
            dataGridInforms.Columns["Marca"].HeaderText = "Marca";
            dataGridInforms.Columns["CantidadVendida"].HeaderText = "Unidades vendidas";
            dataGridInforms.Columns["TotalFacturado"].HeaderText = "Total facturado";

            dataGridInforms.Columns["TotalFacturado"].DefaultCellStyle.Format = "C2";

            LoadTopSellingBrandsChart(data);
        }

        private void LoadTopSellingBrandsChart(DataTable data)
        {
            chartInforms.Series.Clear();
            chartInforms.ChartAreas.Clear();
            chartInforms.Legends.Clear();
            chartInforms.Titles.Clear();

            chartInforms.Titles.Add("Top 10 marcas más vendidas");

            ChartArea area = new ChartArea("MainArea");
            area.AxisX.Title = "Unidades vendidas";
            area.AxisY.Title = "Marcas";
            area.AxisX.Interval = 1;

            chartInforms.ChartAreas.Add(area);

            Series series = new Series("Unidades vendidas");
            series.ChartType = SeriesChartType.Bar;
            series.IsValueShownAsLabel = true;
            series.LabelFormat = "N0";

            foreach (DataRow row in data.Rows)
            {
                string brand = row["Marca"].ToString();
                int quantity = Convert.ToInt32(row["CantidadVendida"]);

                series.Points.AddXY(brand, quantity);
            }

            chartInforms.Series.Add(series);
        }

        private void LoadBestClients()
        {
            if (filterByDate && dateTimePickerFrom.Value.Date > dateTimePickerTo.Value.Date)
            {
                MessageBox.Show("La fecha desde no puede ser posterior a la fecha hasta.");
                return;
            }

            SaleRepository repository = new SaleRepository();

            DataTable data = repository.GetBestClients(
                GetFromDate(),
                GetToDate()
            );

            data.Columns.Add("Puesto", typeof(int)).SetOrdinal(0);

            for (int i = 0; i < data.Rows.Count; i++)
            {
                data.Rows[i]["Puesto"] = i + 1;
            }

            dataGridInforms.DataSource = data;

            dataGridInforms.Columns["Id"].Visible = false;
            dataGridInforms.Columns["Puesto"].HeaderText = "Puesto";
            dataGridInforms.Columns["Cliente"].HeaderText = "Cliente";
            dataGridInforms.Columns["DNI"].HeaderText = "DNI";
            dataGridInforms.Columns["CantidadCompras"].HeaderText = "Cantidad de compras";
            dataGridInforms.Columns["TotalGastado"].HeaderText = "Total gastado";

            dataGridInforms.Columns["TotalGastado"].DefaultCellStyle.Format = "C2";

            LoadBestClientsChart(data);
        }

        private void LoadBestClientsChart(DataTable data)
        {
            chartInforms.Series.Clear();
            chartInforms.ChartAreas.Clear();
            chartInforms.Legends.Clear();
            chartInforms.Titles.Clear();

            chartInforms.Titles.Add("Top 10 mejores clientes");

            ChartArea area = new ChartArea("MainArea");
            area.AxisX.Title = "Total gastado";
            area.AxisY.Title = "Clientes";
            area.AxisX.LabelStyle.Format = "C0";

            chartInforms.ChartAreas.Add(area);

            Series series = new Series("Total gastado");
            series.ChartType = SeriesChartType.Bar;
            series.IsValueShownAsLabel = true;
            series.LabelFormat = "C0";

            foreach (DataRow row in data.Rows)
            {
                string client = row["Cliente"].ToString();
                decimal total = Convert.ToDecimal(row["TotalGastado"]);

                series.Points.AddXY(client, total);
            }

            chartInforms.Series.Add(series);
        }

        private void LoadSalesByPeriod()
        {
            if (filterByDate && dateTimePickerFrom.Value.Date > dateTimePickerTo.Value.Date)
            {
                MessageBox.Show("La fecha desde no puede ser posterior a la fecha hasta.");
                return;
            }

            SaleRepository repository = new SaleRepository();

            DataTable data = repository.GetSalesByPeriod(
                GetFromDate(),
                GetToDate()
            );

            dataGridInforms.DataSource = null;
            dataGridInforms.DataSource = data;

            dataGridInforms.Columns["Fecha"].HeaderText = "Fecha";
            dataGridInforms.Columns["CantidadVentas"].HeaderText = "Cantidad de ventas";
            dataGridInforms.Columns["UnidadesVendidas"].HeaderText = "Unidades vendidas";
            dataGridInforms.Columns["TotalFacturado"].HeaderText = "Total facturado";

            dataGridInforms.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridInforms.Columns["TotalFacturado"].DefaultCellStyle.Format = "C2";

            LoadSalesByPeriodChart(data);
        }

        private void LoadSalesByPeriodChart(DataTable data)
        {
            chartInforms.Series.Clear();
            chartInforms.ChartAreas.Clear();
            chartInforms.Legends.Clear();
            chartInforms.Titles.Clear();

            chartInforms.Titles.Add("Facturación diaria");

            chartInforms.ChartAreas.Add(new ChartArea("MainArea"));

            Series series = new Series("Facturación")
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 3,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 8,
                IsValueShownAsLabel = true,
                LabelFormat = "C0",
                XValueType = ChartValueType.String
            };

            foreach (DataRow row in data.Rows)
            {
                string fecha = Convert.ToDateTime(row["Fecha"]).ToString("dd/MM");

                decimal total = Convert.ToDecimal(row["TotalFacturado"]);

                series.Points.AddXY(fecha, total);
            }

            chartInforms.Series.Add(series);

            chartInforms.ChartAreas["MainArea"].AxisX.Title = "Fecha";
            chartInforms.ChartAreas["MainArea"].AxisY.Title = "Facturación";
            chartInforms.ChartAreas["MainArea"].AxisX.Interval = 1;
            chartInforms.ChartAreas["MainArea"].AxisY.LabelStyle.Format = "C0";
        }

        private void dateTimePickerFrom_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePickerTo_ValueChanged(object sender, EventArgs e)
        {

        }

        private DateTime GetFromDate()
        {
            return filterByDate
                ? dateTimePickerFrom.Value.Date
                : new DateTime(1000, 1, 1);
        }

        private DateTime GetToDate()
        {
            return filterByDate
                ? dateTimePickerTo.Value.Date.AddDays(1).AddTicks(-1)
                : new DateTime(9998, 12, 31);
        }

        private void buttonFilter_Click(object sender, EventArgs e)
        {
            filterByDate = true;

            if (dateTimePickerFrom.Value.Date > dateTimePickerTo.Value.Date)
            {
                MessageBox.Show("La fecha desde no puede ser posterior a la fecha hasta.");
                return;
            }

            LoadSelectedInform();
        }

        private void buttonAll_Click(object sender, EventArgs e)
        {
            filterByDate = false;

            LoadSelectedInform();
        }

        private void LoadSelectedInform()
        {
            switch (comboBoxInforms.SelectedIndex)
            {
                case 0:
                    LoadTopSellingProducts();
                    break;

                case 1:
                    LoadTopSellingCategories();
                    break;

                case 2:
                    LoadBestSellers();
                    break;

                case 3:
                    LoadTopSellingBrands();
                    break;

                case 4:
                    LoadBestClients();
                    break;

                case 5:
                    LoadSalesByPeriod();
                    break;
            }
        }
    }
}
