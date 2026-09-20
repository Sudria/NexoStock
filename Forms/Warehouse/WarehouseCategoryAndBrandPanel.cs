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
    public partial class WarehouseCategoryAndBrandPanel : UserControl
    {
        public WarehouseCategoryAndBrandPanel()
        {
            InitializeComponent();
        }


        private void buttonNewBrand_Click(object sender, EventArgs e)
        {
            NewBrandForm newBrandForm = new NewBrandForm();
            newBrandForm.ShowDialog();
        }

        private void buttonNewCattegory_Click(object sender, EventArgs e)
        {
            NewCategoryForm newCategoryForm = new NewCategoryForm();
            newCategoryForm.ShowDialog();
        }
    }
}
