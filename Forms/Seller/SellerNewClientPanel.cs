using NexoStock.Class;
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
            UserClass newUser = new UserClass
            {
                Name = textBoxName.Text,
                Surname = textBoxSurname.Text,
                DNI = textBoxDni.Text,
                Email = textBoxEmail.Text,
                Tel = textBoxTel.Text,
            };

            if (!Utils.Validator.isValidText(newUser.Name, "Nombre"))
            {
                textBoxName.Focus();
                return;
            }

            if (!Utils.Validator.isValidText(newUser.Surname, "Apellido"))
            {
                textBoxSurname.Focus();
                return;
            }

            if (!Utils.Validator.isValidNum(newUser.DNI, "DNI", 8))
            {
                textBoxDni.Focus();
                return;
            }

            if (!Utils.Validator.isValidEmail(newUser.Email))
            {
                textBoxEmail.Focus();
                return;
            }

            if (!Utils.Validator.isValidNum(newUser.Tel.Replace(" ", ""), "Teléfono", 13))
            {
                textBoxTel.Focus();
                return;
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
