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

namespace NexoStock.Forms.Seller
{
    public partial class SellerForm : Form
    {
        CyberButton activedButton = new CyberButton();

        public SellerForm()
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

        private void buttonProduct_Click(object sender, EventArgs e)
        {
            innactiveButton(activedButton);
            activedButton = buttonProduct;
            activeButton(activedButton);
            LoadProductControler();
        }

        private void buttonSells_Click(object sender, EventArgs e)
        {
            innactiveButton(activedButton);
            activedButton = buttonSells;
            activeButton(activedButton);
            LoadSalesControler();
        }

        private void buttonClients_Click(object sender, EventArgs e)
        {
            innactiveButton(activedButton);
            activedButton = buttonClients;
            activeButton(activedButton);
            LoadClientController();
        }


        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonCloseSession_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }



        //CONTROLADORES

        public void LoadHomeControler()
        {
            panelContent.Controls.Clear();
            panelContent.Controls.Add(new SellerHomePanel());
        }


        public void LoadProductControler()
        {
            panelContent.Controls.Clear();
            panelContent.Controls.Add(new SellerProductPanel());
        }

        public void LoadSalesControler()
        {
            panelContent.Controls.Clear();
            panelContent.Controls.Add(new SellerSalesPanel());
        }

        public void LoadClientController()
        {
            panelContent.Controls.Clear();
            panelContent.Controls.Add(new SellerClientPanel());
        }


        public void LoadNewClientControler()
        {
            panelContent.Controls.Clear();
            panelContent.Controls.Add(new SellerNewClientPanel());
        }

        public void LoadNewSaleControler()
        {
            panelContent.Controls.Clear();
            panelContent.Controls.Add(new SellerNewSellPanel());
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
