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
using NexoStock.Class;

namespace NexoStock.Forms.Seller
{
    public partial class SellerHomePanel : UserControl
    {
        ClientRepository clientRepository = new ClientRepository();
        ProductRepository productRepository = new ProductRepository();
        SaleRepository saleRepository = new SaleRepository();

        public SellerHomePanel(UserClass user)
        {
            InitializeComponent();
            labelCountClient.Text = clientRepository.GetTotalClients().ToString();
            labelCountProduct.Text = productRepository.GetTotalProducts().ToString();
            labelSaleCount.Text = saleRepository.GetTotalSalesByUserId(user.Id).ToString();
        }
    }
}
