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
                Name = textBoxName.Text,
                Surname = textBoxSurname.Text,
                Dni = textBoxDni.Text,
                Email = textBoxEmail.Text,
                Tel = textBoxTel.Text,
                Username = textBoxUsername.Text,
                Password = textBoxPassword.Text,
                Rol = comboBoxRol.Text,
                State = activeCheckBox.Checked
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

            if (!Utils.Validator.isValidNum(newUser.Dni, "DNI", 8))
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

            if (!Utils.Validator.isValidText(newUser.Username, "Nombre de Usuario"))
            {
                textBoxUsername.Focus();
                return;
            }

            if (!Utils.Validator.isValidPassword(newUser.Password, textBoxRepeatPassword.Text))
            {
                textBoxPassword.Focus();
                return;
            }

            if (comboBoxRol.Text == "")
            {
                MessageBox.Show($"Debe seleccionar una opcion en el campo rol.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxRol.Focus();
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

        private void Initialize()
        {
            comboBoxRol.SelectedIndex = 0;
        }

        private void checkBoxShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPass.Checked)
            {
                textBoxPassword.PasswordChar = '\0';
                textBoxRepeatPassword.PasswordChar = '\0';
            }
            else
            {
                textBoxPassword.PasswordChar = '*';
                textBoxRepeatPassword.PasswordChar = '*';
            }
        }
    }
}
