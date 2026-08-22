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
            c.Text = "";
            txtPassword.Text = "";
            c.Focus();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {

        }
    }
}
