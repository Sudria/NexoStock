using NexoStock.Forms.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NexoStock.Forms.Seller
{
    public partial class SellerClientPanel : UserControl
    {
        public SellerClientPanel()
        {
            InitializeComponent();
        }



        private void buttonEdit_Click(object sender, EventArgs e)
        {

        }

        private void buttonNewClient_Click(object sender, EventArgs e)
        {
            SellerForm dashboard = this.ParentForm as SellerForm;
            dashboard.LoadNewClientControler();
        }
    }
}
