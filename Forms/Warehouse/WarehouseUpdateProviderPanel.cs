using NexoStock.Class;
using NexoStock.Services;
using NexoStock.Utils;
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

namespace NexoStock.Forms.Warehouse
{
    public partial class WarehouseUpdateProviderPanel : UserControl
    {
        ProviderClass provider = new ProviderClass();
        public WarehouseUpdateProviderPanel(ProviderClass provider)
        {
            InitializeComponent();
            this.provider = provider;
            LoadProviderData();
        }



        private void activeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (activeCheckBox.Checked)
            {
                stateLabel.Text = "ACTIVO";
                stateLabel.ForeColor = Color.Fuchsia;
            }
            else
            {
                stateLabel.Text = "INACTIVO";
                stateLabel.ForeColor = Color.FromArgb(90, 80, 255);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            WarehouseForm dashboard = this.ParentForm as WarehouseForm;
            dashboard.LoadProviderControler();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            ProviderRepository providerRepository = new ProviderRepository();

            ProviderClass providerUpdate = new ProviderClass
            {
                Id = this.provider.Id,
                Name = textBoxName.Text,
                Surname = textBoxSurname.Text,
                Tel = textBoxTel.Text,
                Email = textBoxEmail.Text,
                Cuit = textBoxCuit.Text,
                State = activeCheckBox.Checked
            };

            if (!Utils.Validator.isValidText(providerUpdate.Name, "Nombre"))
            {
                textBoxName.Focus();
                textBoxName.BorderColorA = Color.Red;
                return;
            }
            if (!Utils.Validator.isValidText(providerUpdate.Surname, "Apellido"))
            {
                textBoxSurname.Focus();
                textBoxSurname.BorderColorA = Color.Red;
                return;
            }
            if (!Utils.Validator.isValidNum(providerUpdate.Cuit, "CUIT", 11))
            {
                textBoxCuit.Focus();
                textBoxCuit.BorderColorA = Color.Red;
                return;
            }

            if (!Utils.Validator.isValidEmail(providerUpdate.Email))
            {
                textBoxEmail.Focus();
                textBoxEmail.BorderColorA = Color.Red;
                return;
            }


            if (!Utils.Validator.isValidNum(providerUpdate.Tel, "Teléfono", 13))
            {
                textBoxTel.Focus();
                textBoxTel.BorderColorA = Color.Red;
                return;
            }

            if (providerRepository.UpdateProvider(providerUpdate))
            {
                MessageBox.Show("Proveedor actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                WarehouseForm dashboard = this.ParentForm as WarehouseForm;
                dashboard.LoadProviderControler();
            }
            else
            {
                MessageBox.Show("Error al actualizar el proveedor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void textBoxTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxCuit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void LoadProviderData()
        {
            textBoxName.Text = provider.Name;
            textBoxSurname.Text = provider.Surname;
            textBoxTel.Text = provider.Tel;
            textBoxEmail.Text = provider.Email;
            textBoxCuit.Text = provider.Cuit;
            activeCheckBox.Checked = provider.State;
        }
    }
}
