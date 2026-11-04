using NexoStock.Class;
using NexoStock.Forms.Admin;
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

namespace NexoStock.Forms.Warehouse
{
    public partial class WarehouseProviderPanel : UserControl
    {
        public WarehouseProviderPanel()
        {
            InitializeComponent();
            LoadProviderCounters();
            LoadProviders();
            LoadStateFilter();
            txtUser.TextChanged += (s, e) => LoadProviders();

        }

        private void buttonNewProvider_Click(object sender, EventArgs e)
        {
            WarehouseForm dashboard = this.ParentForm as WarehouseForm;
            dashboard.LoadNewProviderControler();
        }




        private void LoadProviderCounters()
        {
            ProviderRepository providerRepository = new ProviderRepository();

            List<ProviderClass> providers = providerRepository.GetAllProviders();

            int totalProviders = providers.Count;
            int activeProviders = providers.Count(p => p.State);
            int inactiveProviders = providers.Count(p => !p.State);

            labelTotalProvider.Text = totalProviders.ToString();
            labelActiveProvider.Text = activeProviders.ToString();
            labelInactiveProvider.Text = inactiveProviders.ToString();
        }

        private void LoadProviders()
        {
            ProviderRepository providerRepository = new ProviderRepository();

            List<ProviderClass> providers = providerRepository.GetAllProviders();

            // Filtro por estado
            if (comboBoxState.SelectedIndex == 1)
                providers = providers.Where(p => p.State).ToList();
            else if (comboBoxState.SelectedIndex == 2)
                providers = providers.Where(p => !p.State).ToList();

            // Filtro por texto
            string search = txtUser.Text.Trim().ToLower();

            if (!string.IsNullOrEmpty(search))
            {
                providers = providers.Where(p =>
                    p.Name.ToLower().Contains(search) ||
                    p.Surname.ToLower().Contains(search) ||
                    p.Cuit.ToLower().Contains(search) ||
                    p.Email.ToLower().Contains(search)
                ).ToList();
            }

            var data = providers.Select(p => new
            {
                p.Id,
                p.Name,
                p.Surname,
                p.Cuit,
                p.Email,
                p.Tel,
                StateText = p.State ? "Activo" : "Inactivo"
            }).ToList();

            dataGridProviders.DataSource = null;
            dataGridProviders.AutoGenerateColumns = true;
            dataGridProviders.DataSource = data;

            // Ocultar columnas
            dataGridProviders.Columns["Id"].Visible = false;

            // Nombres personalizados
            Dictionary<string, string> columnHeaders = new Dictionary<string, string>
    {
        { "Name", "Nombre" },
        { "Surname", "Apellido" },
        { "Cuit", "CUIT" },
        { "Email", "Correo electrónico" },
        { "Tel", "Teléfono" },
        { "StateText", "Estado" }
    };

            foreach (var column in columnHeaders)
            {
                if (dataGridProviders.Columns.Contains(column.Key))
                {
                    dataGridProviders.Columns[column.Key].HeaderText = column.Value;
                }
            }
        }

        private void LoadStateFilter()
        {
            comboBoxState.Items.Clear();

            comboBoxState.Items.Add("Todos");
            comboBoxState.Items.Add("Activos");
            comboBoxState.Items.Add("Inactivos");

            comboBoxState.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxState.SelectedIndex = 0;

            comboBoxState.SelectedIndexChanged += (s, e) => LoadProviders();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridProviders.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Por favor, seleccione un proveedor para editar.",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            int providerId = Convert.ToInt32(
                dataGridProviders.SelectedRows[0].Cells["Id"].Value
            );

            ProviderRepository providerRepository = new ProviderRepository();

            ProviderClass provider = providerRepository.GetProviderById(providerId);

            if (provider == null)
            {
                MessageBox.Show(
                    "No se pudo encontrar el proveedor seleccionado.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            WarehouseForm dashboard = this.ParentForm as WarehouseForm;
            dashboard.LoadUpdateProviderControler(provider);

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridProviders.CurrentRow == null)
            {
                MessageBox.Show(
                    "Seleccione un proveedor.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            int providerId = Convert.ToInt32(
                dataGridProviders.CurrentRow.Cells["Id"].Value
            );

            string providerName = dataGridProviders.CurrentRow.Cells["Name"].Value.ToString();

            DialogResult result = MessageBox.Show(
                $"¿Está seguro de que desea desactivar al proveedor '{providerName}'?",
                "Confirmar desactivación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
                return;

            ProviderRepository providerRepository = new ProviderRepository();

            bool success = providerRepository.DeleteProvider(providerId);

            if (success)
            {
                MessageBox.Show(
                    "El proveedor fue desactivado correctamente.",
                    "Operación exitosa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                LoadProviderCounters();
                LoadProviders();
            }
            else
            {
                MessageBox.Show(
                    "No se pudo desactivar el proveedor.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }



        private void dataGridViewProviders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonStyles();
        }


        private void buttonStyles()
        {

            var providerState = dataGridProviders.SelectedRows[0].Cells[6].Value.ToString();

            if (providerState == "Activo")
            {
                buttonDelete.TextButton = "Eliminar";
                buttonDelete.ColorBackground_1 = Color.Crimson;
            }
            else
            {
                buttonDelete.TextButton = "Restaurar";
                buttonDelete.ColorBackground_1 = Color.LimeGreen;
            }
        }


    }
}
