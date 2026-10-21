using MySqlX.XDevAPI;
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
using NexoStock.Class;

namespace NexoStock.Forms.Seller
{
    public partial class SellerClientPanel : UserControl
    {
        List<ClientClass> clients = new List<ClientClass>();

        public SellerClientPanel()
        {
            InitializeComponent();
            LoadDataGridClients();
        }



        private void buttonEdit_Click(object sender, EventArgs e)
        {
            SellerForm dashboard = this.ParentForm as SellerForm;
            dashboard.LoadUpdateClientControler((ClientClass)dataGridClients.CurrentRow.DataBoundItem);

        }

        private void buttonNewClient_Click(object sender, EventArgs e)
        {
            SellerForm dashboard = this.ParentForm as SellerForm;
            dashboard.LoadNewClientControler();
        }


        private void LoadDataGridClients()
        {
            ClientRepository clientRepository = new ClientRepository();

            clients = clientRepository.GetAllClients();

            dataGridClients.AutoGenerateColumns = false;
            dataGridClients.Columns.Clear();

            dataGridClients.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Dni",
                HeaderText = "DNI",
                DataPropertyName = "Dni"
            });

            dataGridClients.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Name",
                HeaderText = "Nombre",
                DataPropertyName = "Name"
            });

            dataGridClients.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Surname",
                HeaderText = "Apellido",
                DataPropertyName = "Surname"
            });

            dataGridClients.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Email",
                HeaderText = "Correo electrónico",
                DataPropertyName = "Email"
            });

            dataGridClients.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Tel",
                HeaderText = "Teléfono",
                DataPropertyName = "Tel"
            });

            dataGridClients.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "StateText",
                HeaderText = "Estado",
                DataPropertyName = "StateText"
            });

            dataGridClients.DataSource = clients;

            dataGridClients.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dataGridClients.AllowUserToAddRows = false;
            dataGridClients.ReadOnly = true;
            dataGridClients.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dataGridClients.MultiSelect = false;
        }


        private void txtSearchClient_TextChanged(object sender, EventArgs e)
        {
            string search = txtClient.Text.Trim().ToLower();

            var filteredClients = clients
                .Where(c =>
                    c.Name.ToLower().Contains(search) ||
                    c.Surname.ToLower().Contains(search) ||
                    c.Dni.ToLower().Contains(search) ||
                    c.Email.ToLower().Contains(search)
                )
                .ToList();

            dataGridClients.DataSource = null;
            dataGridClients.DataSource = filteredClients;
        }
    }
}
