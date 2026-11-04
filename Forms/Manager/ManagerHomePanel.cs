using LiveChartsCore;
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
using System.Windows.Forms.DataVisualization.Charting;

namespace NexoStock.Forms.Manager
{
    public partial class ManagerHomePanel : UserControl
    {
        public ManagerHomePanel()
        {
            InitializeComponent();
            initializeCountsPanels();
            LoadSalesLineChart();
            LoadCategoriesChart();
            LoadTopSellers();
            LoadTopSellingProducts();
        }

        private void initializeCountsPanels()
        {
            List<ProductClass> products = new List<ProductClass>();
            ProductRepository productRepository = new ProductRepository();
            products = productRepository.GetAllProducts();
            int activeProducts = products.Count(p => p.State);
            labelProducts.Text = activeProducts.ToString();

            List<ClientClass> clients = new List<ClientClass>();
            ClientRepository clientRepository = new ClientRepository();
            clients = clientRepository.GetAllClients();
            int activeClients = clients.Count(c => c.State);
            labelClients.Text = activeClients.ToString();

            List<SaleClass> sales = new List<SaleClass>();
            SaleRepository saleRepository = new SaleRepository();
            sales = saleRepository.GetAllSales();
            decimal totalSales = GetCurrentMonthSales();
            labelSales.Text = totalSales.ToString("C");
        }

        private decimal GetCurrentMonthSales()
        {
            SaleRepository saleRepository = new SaleRepository();

            List<SaleClass> sales = saleRepository.GetAllSales();

            DateTime now = DateTime.Now;

            decimal totalSales = sales
                .Where(s => s.SaleDate.Month == now.Month &&
                            s.SaleDate.Year == now.Year)
                .Sum(s => s.Total);

            return totalSales;
        }



        private void LoadSalesLineChart()
        {
            try
            {
                SaleRepository repository = new SaleRepository();

                List<SaleClass> sales = repository.GetAllSales();

                int currentYear = DateTime.Now.Year;

                string[] months =
                {
            "Enero", "Febrero", "Marzo",
            "Abril", "Mayo", "Junio",
            "Julio", "Agosto", "Septiembre",
            "Octubre", "Noviembre", "Diciembre"
        };

                // Limpiar gráfico
                chartSalesAnual.Series.Clear();
                chartSalesAnual.ChartAreas.Clear();
                chartSalesAnual.Legends.Clear();
                chartSalesAnual.Titles.Clear();

                chartSalesAnual.Titles.Add($"Ventas del año {currentYear}");

                // Configurar área
                ChartArea area = new ChartArea("MainArea");

                area.AxisY.LabelStyle.Format = "N0";
                area.AxisX.Title = "Mes";
                area.AxisY.Title = "Importe ($)";
                area.AxisX.Interval = 1;
                area.AxisX.LabelStyle.Angle = -45;

                chartSalesAnual.ChartAreas.Add(area);

                // Configurar serie
                Series series = new Series("Ventas")
                {
                    ChartType = SeriesChartType.Line,
                    BorderWidth = 3,
                    MarkerStyle = MarkerStyle.Circle,
                    MarkerSize = 7,
                    IsValueShownAsLabel = true,
                    IsXValueIndexed = true,
                    LabelFormat = "N0"
                };

                // Recorrer los 12 meses
                for (int month = 1; month <= 12; month++)
                {
                    decimal monthlyTotal = sales
                        .Where(s => s.State &&
                                    s.SaleDate.Year == currentYear &&
                                    s.SaleDate.Month == month)
                        .Sum(s => s.Total);

                    series.Points.AddXY(months[month - 1], monthlyTotal);
                }

                chartSalesAnual.Series.Add(series);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al cargar el gráfico de ventas:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void LoadCategoriesChart()
        {
            SaleRepository repository = new SaleRepository();

            DataTable data = repository.GetSalesByCategory();

            chartCategories.Series.Clear();
            chartCategories.ChartAreas.Clear();
            chartCategories.Legends.Clear();
            chartCategories.Titles.Clear();

            chartCategories.Titles.Add("Categorías más vendidas");

            chartCategories.ChartAreas.Add(new ChartArea("MainArea"));
            chartCategories.Legends.Add(new Legend("MainLegend"));

            if (data.Rows.Count == 0)
            {
                chartCategories.Titles.Add("Todavía no hay ventas registradas");
                return;
            }

            Series series = new Series("Categorías")
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true,
                ChartArea = "MainArea",
                Legend = "MainLegend",
                Label = "#PERCENT{P0}"
            };

            foreach (DataRow row in data.Rows)
            {
                string category = row["Categoria"].ToString();
                int quantity = Convert.ToInt32(row["CantidadVendida"]);

                int index = series.Points.AddXY(category, quantity);

                series.Points[index].LegendText = category;
            }

            chartCategories.Series.Add(series);
        }

        private void LoadTopSellers()
        {
            try
            {
                SaleRepository repository = new SaleRepository();

                DataTable data = repository.GetTopSellersOfCurrentMonth();

                dataGridTopSellers.DataSource = null;
                dataGridTopSellers.AutoGenerateColumns = true;
                dataGridTopSellers.DataSource = data;

                dataGridTopSellers.Columns["Nombre"].HeaderText = "Vendedor";
                dataGridTopSellers.Columns["TotalVendido"].HeaderText = "Total vendido";

                dataGridTopSellers.Columns["TotalVendido"].DefaultCellStyle.Format = "C2";
                dataGridTopSellers.Columns["TotalVendido"].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleRight;

                if (data.Rows.Count == 0)
                {
                    // No hay ventas durante el mes actual.
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al cargar los mejores vendedores:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void LoadTopSellingProducts()
        {
            try
            {
                SaleRepository repository = new SaleRepository();

                DataTable data = repository.GetTopSellingProductsOfCurrentMonth();

                dataGridTopProducts.DataSource = null;
                dataGridTopProducts.AutoGenerateColumns = true;
                dataGridTopProducts.DataSource = data;

                dataGridTopProducts.Columns["Producto"].HeaderText = "Producto";
                dataGridTopProducts.Columns["CantidadVendida"].HeaderText = "Unidades vendidas";

                dataGridTopProducts.Columns["CantidadVendida"].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al cargar los productos más vendidos:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


    }
}