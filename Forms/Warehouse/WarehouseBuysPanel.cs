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

namespace NexoStock.Forms.Warehouse
{
    public partial class WarehouseBuysPanel : UserControl
    {
        private List<PurchaseClass> allPurchases;
        private BindingSource purchaseBindingSource = new BindingSource();
        UserClass user = new UserClass();
        public WarehouseBuysPanel(UserClass user)
        {
            InitializeComponent();
            LoadComboBoxs();
            dataPickerConfigure();
            LoadPurchases();
            FilterPurchases();
            this.user = user;
        }

        private void buttonNewBuy_Click(object sender, EventArgs e)
        {
            WarehouseForm dashboard = this.ParentForm as WarehouseForm;
            dashboard.LoadNewBuyControler(user);
        }


        private void LoadComboBoxs()
        {
            ProviderRepository providerRepository = new ProviderRepository();
            List<ProviderClass> providers = providerRepository.GetAllProviders();

            // Agregar TODOS al principio de la lista
            providers.Insert(0, new ProviderClass
            {
                Id = 0,
                Name = "TODOS"
            });

            comboBoxProvider.DisplayMember = "FullNameAndCuit";
            comboBoxProvider.ValueMember = "Id";
            comboBoxProvider.DataSource = providers;

            comboBoxProvider.SelectedIndex = 0;
        }


        private void LoadPurchases()
        {
            PurchaseRepository repository = new PurchaseRepository();

            allPurchases = repository.GetAllPurchases();

            purchaseBindingSource.DataSource = allPurchases;
            dataGridPurchases.DataSource = purchaseBindingSource;

            dataGridPurchases.Columns["Id"].Visible = false;
            dataGridPurchases.Columns["ProviderId"].Visible = false;
            dataGridPurchases.Columns["UserId"].Visible = false;
            dataGridPurchases.Columns["UserName"].Visible = false;

            dataGridPurchases.Columns["PurchaseDate"].HeaderText = "Fecha";
            dataGridPurchases.Columns["ProviderName"].HeaderText = "Proveedor";
            dataGridPurchases.Columns["TotalProducts"].HeaderText = "Cantidad de productos";
            dataGridPurchases.Columns["Total"].HeaderText = "Total";

            dataGridPurchases.Columns["PurchaseDate"].DisplayIndex = 0;
            dataGridPurchases.Columns["ProviderName"].DisplayIndex = 1;
            dataGridPurchases.Columns["TotalProducts"].DisplayIndex = 2;
            dataGridPurchases.Columns["Total"].DisplayIndex = 3;

            dataGridPurchases.Columns["PurchaseDate"].DefaultCellStyle.Format =
                "dd/MM/yyyy HH:mm";

            dataGridPurchases.Columns["Total"].DefaultCellStyle.Format = "N2";

            dataGridPurchases.ReadOnly = true;
            dataGridPurchases.AllowUserToAddRows = false;
            dataGridPurchases.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridPurchases.MultiSelect = false;
        }


        private void FilterPurchases()
        {
            if (allPurchases == null)
                return;

            DateTime from = datePickerFrom.Value.Date;
            DateTime to = datePickerTo.Value.Date;

            if (from > to)
            {
                purchaseBindingSource.DataSource = new List<PurchaseClass>();
                return;
            }

            var filteredPurchases = allPurchases
                .Where(p => p.PurchaseDate >= from &&
                            p.PurchaseDate < to.AddDays(1))
                .ToList();

            // Filtrar por proveedor únicamente si hay uno seleccionado.

            if (comboBoxProvider.SelectedItem is ProviderClass provider &&
                provider.Id != 0)
            {
                filteredPurchases = filteredPurchases
                    .Where(p => p.ProviderId == provider.Id)
                    .ToList();
            }

            purchaseBindingSource.DataSource = filteredPurchases;
        }


        private void datePickerFrom_ValueChanged(object sender, EventArgs e)
        {
            FilterPurchases();
        }

        private void datePickerTo_ValueChanged(object sender, EventArgs e)
        {
            FilterPurchases();
        }

        private void comboBoxProvider_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterPurchases();
        }

        private void dataPickerConfigure()
        {
            datePickerTo.MaxDate = DateTime.Now;
            datePickerTo.Value = DateTime.Now;
            datePickerFrom.MinDate = new DateTime(2020, 1, 1);
            datePickerFrom.MaxDate = DateTime.Now;
        }
    }
}
