
using NexoStock.Class;
using NexoStock.Forms.Admin;
using NexoStock.Forms.Manager;
using NexoStock.Forms.Seller;
using NexoStock.Forms.Warehouse;
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


namespace NexoStock
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void logginButton_Click(object sender, EventArgs e)
        {
            UserRepository userRepository = new UserRepository();
            UserClass user = userRepository.Login(txtUser.Text, txtPassword.Text);

            if (user == null)
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (user.State == false)
            {
                MessageBox.Show("Usuario inactivo, contacte con el administrador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (user.Rol == "Administrador")
            {
                this.Hide();
                AdminForm adminForm = new AdminForm();
                adminForm.Show();
            }
            else if (user.Rol == "Vendedor")
            {
                this.Hide();
                SellerForm sellerForm = new SellerForm(user);
                sellerForm.Show();
            }
            else if (user.Rol == "Repositor")
            {
                this.Hide();
                WarehouseForm warehouseForm = new WarehouseForm();
                warehouseForm.Show();
            }
            else if (user.Rol == "Encargado")
            {
                this.Hide();
                ManagerForm managerForm = new ManagerForm();
                managerForm.Show();
            }
        }


        private void checkBoxShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPass.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';

            }
        }
        private void clearButton_Click(object sender, EventArgs e)
        {
            txtUser.Text = "";
            txtPassword.Text = "";
            txtUser.Focus();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                logginButton.PerformClick();
            }
        }
    }
}
