using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NexoStock.Forms
{
    public partial class NewBrandForm : Form
    {
        public NewBrandForm()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Utils.Validator.isValidText(textBoxBrandName.Text, "Nombre de la Marca");
            textBoxBrandName.Focus();
        }
    }
}
