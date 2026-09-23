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

namespace NexoStock.Forms.Warehouse
{
    public partial class WarehouseForm : Form
    {
        CyberButton activedButton = new CyberButton();

        public WarehouseForm()
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

        private void buttonProvider_Click(object sender, EventArgs e)
        {
            innactiveButton(activedButton);
            activedButton = buttonProvider;
            activeButton(activedButton);
            LoadProviderControler();
        }

        private void buttonBuys_Click(object sender, EventArgs e)
        {
            innactiveButton(activedButton);
            activedButton = buttonBuys;
            activeButton(activedButton);
            LoadBuysControler();
        }

        private void buttonCategoryAndBrand_Click(object sender, EventArgs e)
        {
            innactiveButton(activedButton);
            activedButton = buttonCategoryAndBrand;
            activeButton(activedButton);
            LoadCategoryAndBrandControler();
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
            panelContent.Controls.Add(new WarehouseHomePanel());
        }

        public void LoadProductControler()
        {
            panelContent.Controls.Clear();
            panelContent.Controls.Add(new WarehouseProductPanel());
        }
        public void LoadProviderControler()
        {
            panelContent.Controls.Clear();
            panelContent.Controls.Add(new WarehouseProviderPanel());
        }

        public void LoadBuysControler()
        {
            panelContent.Controls.Clear();
            panelContent.Controls.Add(new WarehouseBuysPanel());
        }

        public void LoadCategoryAndBrandControler()
        {
            panelContent.Controls.Clear();
            panelContent.Controls.Add(new WarehouseCategoryAndBrandPanel());
        }





        //BOTONES DENTRO DE LOS CONTROLES

        public void LoadNewProductControler()
        {
            panelContent.Controls.Clear();
            panelContent.Controls.Add(new WarehouseNewProductPanel());
        }

        public void LoadNewProviderControler()
        {
            panelContent.Controls.Clear();
            panelContent.Controls.Add(new WarehouseNewProviderPanel());
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
