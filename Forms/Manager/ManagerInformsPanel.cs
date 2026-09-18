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
    public partial class ManagerInformsPanel : UserControl
    {
        public ManagerInformsPanel()
        {
            InitializeComponent();
            comboBoxInforms.SelectedIndex = 0;
        }

        private void buttonDetails_Click(object sender, EventArgs e)
        {

        }
    }
}
