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

namespace NexoStock.Forms.Manager
{
    public partial class ManagerForm : Form
    {
        CyberButton activedButton = new CyberButton();

        public ManagerForm()
        {
            InitializeComponent();
            activedButton = buttonHome;
            activeButton(activedButton);
            LoadHomeController();
        }


        //BOTONES

        private void buttonHome_Click(object sender, EventArgs e)
        {
            innactiveButton(activedButton);
            activedButton = buttonHome;
            activeButton(activedButton);
            LoadHomeController();
        }

        private void buttonSales_Click(object sender, EventArgs e)
        {
            innactiveButton(activedButton);
            activedButton = buttonSales;
            activeButton(activedButton);
            LoadSalesController();
        }


        private void buttonProduct_Click(object sender, EventArgs e)
        {
            innactiveButton(activedButton);
            activedButton = buttonProduct;
            activeButton(activedButton);
            LoadProductController();
        }
        private void buttonBuys_Click(object sender, EventArgs e)
        {
            innactiveButton(activedButton);
            activedButton = buttonBuys;
            activeButton(activedButton);
            LoadBuysController();
        }



        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonCloseSession_Click(object sender, EventArgs e)
        {

        }



        //CONTROLADORES

        public void LoadHomeController()
        {
            panelContent.Controls.Clear();
            panelContent.Controls.Add(new ManagerHomePanel());
        }


        public void LoadSalesController()
        {
            panelContent.Controls.Clear();
            panelContent.Controls.Add(new ManagerSalesPanel());
        }

        public void LoadNewProductController()
        {
            panelContent.Controls.Clear();
            panelContent.Controls.Add(new ManagerNewProductPanel());
        }



        public void LoadProductController()
        {
            panelContent.Controls.Clear();
            panelContent.Controls.Add(new ManagerProductPanel());
        }

        public void LoadBuysController()
        {
            panelContent.Controls.Clear();
            panelContent.Controls.Add(new ManagerBuysPanel());
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
