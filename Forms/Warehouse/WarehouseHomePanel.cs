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

namespace NexoStock.Forms.Warehouse
{
    public partial class WarehouseHomePanel : UserControl
    {
        public WarehouseHomePanel()
        {
            InitializeComponent();
            initializeCountsPanels();
            LoadTopSellingProducts();
            LoadStockDistributionChart();
        }

        private void initializeCountsPanels()
        {
            List<ProductClass> products = new List<ProductClass>();
            ProductRepository productRepository = new ProductRepository();
            products = productRepository.GetAllProducts();
            int activeProducts = products.Count(p => p.State);
            int lowStockProducts = products.Count(p => p.State && p.Stock <= p.StockMin);
            int outOfStockProducts = products.Count(p => p.State && p.Stock == 0);

            labelProduct.Text = activeProducts.ToString();
            labelProductLowStock.Text = lowStockProducts.ToString();
            labelProductOutStock.Text = outOfStockProducts.ToString();
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

        private void WarehouseHomePanel_Load(object sender, EventArgs e)
        {

        }

        private void LoadStockDistributionChart()
        {
            ProductRepository repository = new ProductRepository();

            DataTable data = repository.GetStockDistribution();

            chartStockDistribution.Series.Clear();
            chartStockDistribution.ChartAreas.Clear();
            chartStockDistribution.Legends.Clear();
            chartStockDistribution.Titles.Clear();

            chartStockDistribution.Titles.Add("Distribución del inventario");

            ChartArea area = new ChartArea("MainArea");
            chartStockDistribution.ChartAreas.Add(area);

            Legend legend = new Legend("MainLegend");
            chartStockDistribution.Legends.Add(legend);

            Series series = new Series("Stock");
            series.ChartType = SeriesChartType.Doughnut;
            series.IsValueShownAsLabel = true;
            series.Label = "#VALX: #VALY (#PERCENT{P1})";
            series.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            if (data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];

                int normal = Convert.ToInt32(row["StockNormal"]);
                int bajo = Convert.ToInt32(row["StockBajo"]);
                int sinStock = Convert.ToInt32(row["SinStock"]);

                if (normal > 0)
                {
                    int index = series.Points.AddXY("Normal", normal);
                    series.Points[index].Color = Color.MediumSeaGreen;
                }

                if (bajo > 0)
                {
                    int index = series.Points.AddXY("Stock bajo", bajo);
                    series.Points[index].Color = Color.Goldenrod;
                }

                if (sinStock > 0)
                {
                    int index = series.Points.AddXY("Sin stock", sinStock);
                    series.Points[index].Color = Color.IndianRed;
                }
            }

            series.Legend = "MainLegend";

            chartStockDistribution.Series.Add(series);
        }
    }
}
