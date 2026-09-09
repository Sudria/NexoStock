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

namespace NexoStock.Forms.Admin
{
    public partial class AdminNewUserPanel : UserControl
    {
        public AdminNewUserPanel()
        {
            InitializeComponent();
            Initialize();
        }

        private void newUserButton_Click(object sender, EventArgs e)
        {

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
            dashboard.LoadUserControler();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            UserClass newUser = new UserClass
            {
                Name = nameTextBox.Text,
                Surname = surnameTextBox.Text,
                DNI = dniTextBox.Text,
                Email = emailTextBox.Text,
                Tel = telTextBox.Text,
                CreatedDate = DateTime.Now,
                Username = usernameTextBox.Text,
                Password = passwordTextBox.Text,
                Rol = RolComboBox.Text,
                Activo = activeCheckBox.Checked
            };

            if (!Utils.Validator.isValidText(newUser.Name, "Nombre"))
            {
                nameTextBox.Focus();
                return;
            }

            if (!Utils.Validator.isValidText(newUser.Surname, "Apellido"))
            {
                surnameTextBox.Focus();
                return;
            }

            if (!Utils.Validator.isValidNum(newUser.DNI, "DNI", 8))
            {
                dniTextBox.Focus();
                return;
            }

            if (!Utils.Validator.isValidEmail(newUser.Email))
            {
                emailTextBox.Focus();
                return;
            }

            if (!Utils.Validator.isValidNum(newUser.Tel.Replace(" ", ""), "Teléfono", 13))
            {
                telTextBox.Focus();
                return;
            }

            if (!Utils.Validator.isValidText(newUser.Username, "Nombre de Usuario"))
            {
                usernameTextBox.Focus();
                return;
            }

            if (!Utils.Validator.isValidPassword(newUser.Password, repeatPasswordTextBox.Text))
            {
                passwordTextBox.Focus();
                return;
            }

            if (RolComboBox.Text == "")
            {
                MessageBox.Show($"Debe seleccionar una opcion en el campo rol.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                RolComboBox.Focus();
                return;
            }
        }

        private void formatTel(object sender, KeyPressEventArgs e)
        {
            if (telTextBox.Text.Length == 4)
            {
                telTextBox.Text += " ";
                telTextBox.SelectionStart = telTextBox.Text.Length;
            }
        }

        private void Initialize()
        {
            RolComboBox.SelectedIndex = 0;
        }

        private void checkBoxShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPass.Checked)
            {
                passwordTextBox.PasswordChar = '\0';
                repeatPasswordTextBox.PasswordChar = '\0';
            }
            else
            {
                passwordTextBox.PasswordChar = '*';
                repeatPasswordTextBox.PasswordChar = '*';
            }
        }
    }
}
