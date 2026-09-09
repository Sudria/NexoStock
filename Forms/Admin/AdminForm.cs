using NexoStock.Forms.Admin;
using ReaLTaiizor.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace NexoStock.Forms.Admin
{
    public partial class AdminForm : Form
    {
        CyberButton activedButton = new CyberButton();

        public AdminForm()
        {
            InitializeComponent();
            activedButton = buttonHome;
            activeButton(activedButton);
            LoadHomeControler();
        }


        //BOTONES

        private void buttonHome_Click(object sender, EventArgs e)
        {
            innactiveButton(activedButton);
            activedButton = buttonHome;
            activeButton(activedButton);
            LoadHomeControler();
        }

        private void buttonUser_Click(object sender, EventArgs e)
        {
            innactiveButton(activedButton);
            activedButton = buttonUser;
            activeButton(activedButton);
            LoadUserControler();
        }



        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonCloseSession_Click(object sender, EventArgs e)
        {

        }



        //CONTROLADORES

        public void LoadHomeControler()
        {
            panelContent.Controls.Clear();
            panelContent.Controls.Add(new AdminHomePanel());
        }


        public void LoadNewUserControler()
        {
            panelContent.Controls.Clear();
            panelContent.Controls.Add(new AdminNewUserPanel());
        }

        public void LoadUserControler()
        {
            panelContent.Controls.Clear();
            panelContent.Controls.Add(new AdminUserPanel());
        }



        //COMPORTAMIENTO DE BOTONES

        private void activeButton(CyberButton e)
        {
            e.LinearGradient_Background = true;
            e.Lighting = true;
        }

        private void innactiveButton(CyberButton e)
        {
            e.Lighting = false;
            e.LinearGradient_Background = false;
        }



  







    }








}
