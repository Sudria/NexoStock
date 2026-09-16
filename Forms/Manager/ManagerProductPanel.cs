using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NexoStock.Forms.Manager
{
    public partial class ManagerProductPanel : UserControl
    {
        public ManagerProductPanel()
        {
            InitializeComponent();
        }

        private void buttonNewProduct_Click(object sender, EventArgs e)
        {
            ManagerForm managerForm = this.ParentForm as ManagerForm;
            managerForm.LoadNewProductController();
        }

 
    }
}
