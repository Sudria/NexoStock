using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NexoStock.Forms.Warehouse
{
    public partial class WarehouseProductPanel : UserControl
    {
        public WarehouseProductPanel()
        {
            InitializeComponent();
        }

        private void buttonNewProduct_Click(object sender, EventArgs e)
        {
            WarehouseForm dashboard = this.ParentForm as WarehouseForm;
            dashboard.LoadNewProductControler();
        }
    }
}
