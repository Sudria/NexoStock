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
    public partial class AdminMovementsPanel : UserControl
    {
        private DataTable movements;
        public AdminMovementsPanel()
        {
            InitializeComponent();
            comboBoxMovementType.Items.Clear();
            comboBoxMovementType.Items.Add("Todos");
            comboBoxMovementType.Items.Add("Compras");
            comboBoxMovementType.Items.Add("Ventas");

            comboBoxMovementType.SelectedIndex = 0;

            dateTimePickerFrom.Value = new DateTime(
            DateTime.Now.Year,
            DateTime.Now.Month,
      1
  );

            dateTimePickerTo.Value = DateTime.Today;
            LoadMovementsDataGridView();
        }


        private void LoadMovementsDataGridView()
        {
            try
            {
                ProductMovementRepository repository = new ProductMovementRepository();

                movements = repository.GetMovementsDataTable();

                ApplyMovementFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al cargar los movimientos:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void ApplyMovementFilter()
        {
            if (movements == null)
                return;

            DataTable filteredData = movements.Clone();

            string selected = comboBoxMovementType.Text;
            string search = textBoxName.Text.Trim();

            DateTime dateFrom = dateTimePickerFrom.Value.Date;
            DateTime dateTo = dateTimePickerTo.Value.Date.AddDays(1);

            IEnumerable<DataRow> rows = movements.AsEnumerable();

            // Filtro por tipo de movimiento
            if (selected == "Compras")
            {
                rows = rows.Where(r => r["Tipo"].ToString() == "COMPRA");
            }
            else if (selected == "Ventas")
            {
                rows = rows.Where(r => r["Tipo"].ToString() == "VENTA");
            }

            // Filtro por rango de fechas
            rows = rows.Where(r =>
                r["Fecha"] != DBNull.Value &&
                Convert.ToDateTime(r["Fecha"]) >= dateFrom &&
                Convert.ToDateTime(r["Fecha"]) < dateTo
            );

            // Filtro por texto
            if (!string.IsNullOrWhiteSpace(search))
            {
                rows = rows.Where(r =>
                    r["Producto"].ToString().IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    r["Usuario"].ToString().IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    r["Operacion"].ToString().Contains(search)
                );
            }

            foreach (DataRow row in rows)
            {
                filteredData.ImportRow(row);
            }

            dataGridMovements.DataSource = filteredData;

            // Personalización del DataGridView
            dataGridMovements.Columns["Id"].Visible = false;

            dataGridMovements.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

            dataGridMovements.Columns["Cantidad"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dataGridMovements.Columns["StockAnterior"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dataGridMovements.Columns["StockNuevo"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dataGridMovements.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void comboBoxMovementType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyMovementFilter();
        }

        private void dateTimePickerFrom_ValueChanged(object sender, EventArgs e)
        {
            ApplyMovementFilter();
        }

        private void dateTimePickerTo_ValueChanged(object sender, EventArgs e)
        {
            ApplyMovementFilter();
        }

        private void cc(object sender, EventArgs e)
        {
            ApplyMovementFilter();
        }
    }
}
