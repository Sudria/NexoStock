using NexoStock.Class;
using NexoStock.Forms.Admin;
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

namespace NexoStock.Forms.Seller
{
    public partial class SellerNewClientPanel : UserControl
    {
        public SellerNewClientPanel()
        {
            InitializeComponent();
        }

        private void newUserButton_Click(object sender, EventArgs e)
        {

        }



        private void exitButton_Click(object sender, EventArgs e)
        {
            SellerForm dashboard = this.ParentForm as SellerForm;
            dashboard.LoadClientController();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            ClientClass newClient= new ClientClass
            {
                Name = textBoxName.Text,
                Surname = textBoxSurname.Text,
                Dni = textBoxDni.Text,
                Email = textBoxEmail.Text,
                Tel = textBoxTel.Text,
                State = activeCheckBox.Checked
            };

            if (!Utils.Validator.isValidText(newClient.Name, "Nombre"))
            {
                textBoxName.Focus();
                return;
            }

            if (!Utils.Validator.isValidText(newClient.Surname, "Apellido"))
            {
                textBoxSurname.Focus();
                return;
            }

            if (!Utils.Validator.isValidNum(newClient.Dni, "DNI", 8))
            {
                textBoxDni.Focus();
                return;
            }

            if (!Utils.Validator.isValidEmail(newClient.Email))
            {
                textBoxEmail.Focus();
                return;
            }

            if (!Utils.Validator.isValidNum(newClient.Tel.Replace(" ", ""), "Teléfono", 13))
            {
                textBoxTel.Focus();
                return;
            }

            ClientRepository clientRepository = new ClientRepository();

            if (clientRepository.CreateClient(newClient))
            {
                MessageBox.Show($"Cliente {newClient.Name} {newClient.Surname} creado correctamente.", "Cliente Creado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SellerForm dashboard = this.ParentForm as SellerForm;
                dashboard.LoadClientController();
            }



        }

        private void formatTel(object sender, KeyPressEventArgs e)
        {
            if (textBoxTel.Text.Length == 4)
            {
                textBoxTel.Text += " ";
                textBoxTel.SelectionStart = textBoxTel.Text.Length;
            }
        }

    }
}
