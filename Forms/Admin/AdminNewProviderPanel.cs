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


namespace NexoStock.Forms.Admin
{
    public partial class AdminNewProviderPanel : UserControl
    {


        public AdminNewProviderPanel()
        {
            InitializeComponent();
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
            AdminForm dashboard = this.ParentForm as AdminForm;
            dashboard.LoadProviderControler();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            ProviderRepository providerRepository = new ProviderRepository();

            ProviderClass provider = new ProviderClass
            {
                Name = textBoxName.Text,
                Surname = textBoxSurname.Text,
                Tel = textBoxTel.Text,
                Email = textBoxEmail.Text,
                Cuit = textBoxCuit.Text,
                State = activeCheckBox.Checked
            };

            if (!Utils.Validator.isValidText(provider.Name, "Nombre"))
            {
                textBoxName.Focus();
                textBoxName.BorderColorA = Color.Red;
                return;
            }
            if (!Utils.Validator.isValidText(provider.Surname, "Apellido"))
            {
                textBoxSurname.Focus();
                textBoxSurname.BorderColorA = Color.Red;
                return;
            }
            if (!Utils.Validator.isValidNum(provider.Cuit, "CUIT", 11))
            {
                textBoxCuit.Focus();
                textBoxCuit.BorderColorA = Color.Red;
                return;
            }

            if (!Utils.Validator.isValidEmail(provider.Email))
            {
                textBoxEmail.Focus();
                textBoxEmail.BorderColorA = Color.Red;
                return;
            }


            if (!Utils.Validator.isValidNum(provider.Tel, "Teléfono", 13))
            {
                textBoxTel.Focus();
                textBoxTel.BorderColorA = Color.Red;
                return;
            }



            if (providerRepository.CreateProvider(provider))
            {
                MessageBox.Show("Proveedor creado exitosamente.");
                AdminForm dashboard = this.ParentForm as AdminForm;
                dashboard.LoadProviderControler();
            }
            else
            {
                MessageBox.Show("Error al crear el proveedor.");
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
    }
}
