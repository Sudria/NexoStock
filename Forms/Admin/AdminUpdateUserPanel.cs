using NexoStock.Class;
using NexoStock.Services;
using NexoStock.Utils;
using Org.BouncyCastle.Bcpg;
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
    public partial class AdminUpdateUserPanel : UserControl
    {
        private int userId;
        public AdminUpdateUserPanel(UserClass user)
        {
            InitializeComponent();
            Initialize(user);
            userId = user.Id;
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


        private void Initialize(UserClass user)
        {
            comboBoxRol.SelectedIndex = 0;
            textBoxName.Text = user.Name;
            textBoxSurname.Text = user.Surname;
            textBoxDni.Text = user.Dni;
            textBoxEmail.Text = user.Email;
            textBoxTel.Text = String.Concat("54 9 ", user.Tel);
            textBoxUsername.Text = user.Username;
            textBoxPassword.Text = user.Password;
            textBoxRepeatPassword.Text = user.Password;
            comboBoxRol.Text = user.Rol;
            activeCheckBox.Checked = user.State;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            UserClass user = new UserClass
            {
                Id = userId,
                Name = textBoxName.Text,
                Surname = textBoxSurname.Text,
                Dni = textBoxDni.Text,
                Email = textBoxEmail.Text,
                Tel = textBoxTel.Text.Replace(" ", ""),
                Username = textBoxUsername.Text,
                Password = textBoxPassword.Text,
                Rol = comboBoxRol.Text,
                State = activeCheckBox.Checked
            };

            if (!Utils.Validator.isValidText(user.Name, "Nombre"))
            {
                textBoxName.Focus();
                return;
            }

            if (!Utils.Validator.isValidText(user.Surname, "Apellido"))
            {
                textBoxSurname.Focus();
                return;
            }

            if (!Utils.Validator.isValidNum(user.Dni, "DNI", 8))
            {
                textBoxDni.Focus();
                return;
            }

            if (!Utils.Validator.isValidEmail(user.Email))
            {
                textBoxEmail.Focus();
                return;
            }

            if (!Utils.Validator.isValidNum(user.Tel, "Teléfono", 13))
            {
                textBoxTel.Focus();
                return;
            }

            if (!Utils.Validator.isValidText(user.Username, "Nombre de Usuario"))
            {
                textBoxUsername.Focus();
                return;
            }

            if (!Utils.Validator.isValidPassword(user.Password, textBoxRepeatPassword.Text))
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

            UserRepository userRepository = new UserRepository();

            if (userRepository.UpdateUser(user))
            {
                MessageBox.Show($"Usuario {user.Name} {user.Surname} actualizado correctamente.", "Usuario Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AdminForm dashboard = this.ParentForm as AdminForm;
                dashboard.LoadUserControler();
            }
            else
            {
                MessageBox.Show($"Error al actualizar el usuario {user.Name} {user.Surname}.", "Error al Actualizar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void formatTel(object sender, KeyPressEventArgs e)
        {
            if (textBoxTel.Text.Length == 5)
            {
                textBoxTel.Text += " ";
                textBoxTel.SelectionStart = textBoxTel.Text.Length;
            }
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
