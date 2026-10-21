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
using System.Windows.Forms.DataVisualization.Charting;

namespace NexoStock.Forms.Seller
{
    public partial class SellerHomePanel : UserControl
    {
        ClientRepository clientRepository = new ClientRepository();
        ProductRepository productRepository = new ProductRepository();
        SaleRepository saleRepository = new SaleRepository();
        UserClass _user;

        public SellerHomePanel(UserClass user)
        {
            InitializeComponent();
            _user = user;
            labelCountClient.Text = clientRepository.GetTotalClients().ToString();
            labelCountProduct.Text = productRepository.GetTotalProducts().ToString();
            labelSaleCount.Text = saleRepository.GetTotalSalesByUserId(user.Id).ToString();
            LoadCategoriesChart();
            LoadSalesLineChart();
            LoadLastSales();
            LoadTopSellingProducts();
        }


        private void LoadLastSales()
        {
            SaleRepository repository = new SaleRepository();

            dataGridLastSales.DataSource =
                repository.GetLast5SalesByUserId(_user.Id);
        }

        private void LoadTopSellingProducts()
        {
            SaleDetailRepository repository = new SaleDetailRepository();

            dataGridTopProducts.DataSource =
                repository.GetTopSellingProductsByUser(_user.Id);

            dataGridTopProducts.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dataGridTopProducts.ReadOnly = true;
            dataGridTopProducts.AllowUserToAddRows = false;
            dataGridTopProducts.AllowUserToDeleteRows = false;
            dataGridTopProducts.RowHeadersVisible = false;
        }


        private void LoadCategoriesChart()
        {
            SaleRepository repository = new SaleRepository();

    

            DataTable data = repository.GetSalesByCategoryAndUser(_user.Id);

            chartCategories.Series.Clear();
            chartCategories.ChartAreas.Clear();
            chartCategories.Legends.Clear();
            chartCategories.Titles.Clear();

            chartCategories.Titles.Add("Categorías más vendidas");

            chartCategories.ChartAreas.Add(new ChartArea("MainArea"));
            chartCategories.Legends.Add(new Legend("MainLegend"));

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

            if (data.Rows.Count == 0)
            {
                chartCategories.Titles.Add("Todavía no hay ventas registradas");
            }
        }

        private void LoadSalesLineChart()
        {
            SaleRepository repository = new SaleRepository();

            DataTable data =
                repository.GetSalesByDayAndUser(_user.Id);

            chartSalesByDay.Series.Clear();
            chartSalesByDay.ChartAreas.Clear();
            chartSalesByDay.Legends.Clear();
            chartSalesByDay.Titles.Clear();

            chartSalesByDay.Titles.Add("Importe vendido por día");

            ChartArea area = new ChartArea("MainArea");
            area.AxisX.Title = "Fecha";
            area.AxisY.Title = "Importe ($)";
            area.AxisX.LabelStyle.Format = "dd/MM";
            area.AxisX.Interval = 1;
            area.AxisX.LabelStyle.Angle = -45;

            chartSalesByDay.ChartAreas.Add(area);

            Series series = new Series("Ventas")
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 3,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 7,
                IsValueShownAsLabel = true,
                XValueType = ChartValueType.Date
            };

            foreach (DataRow row in data.Rows)
            {
                DateTime fecha = Convert.ToDateTime(row["Fecha"]);
                decimal total = Convert.ToDecimal(row["TotalVendido"]);

                series.Points.AddXY(fecha, total);
            }

            chartSalesByDay.Series.Add(series);
        }
    }
}
