using NexoStock.Class;
using NexoStock.Utils;
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

namespace NexoStock.Forms.Admin
{
    public partial class AdminNewProductPanel : UserControl
    {
        public AdminNewProductPanel()
        {
            InitializeComponent();
            Initialize();
        }

        private void newUserButton_Click(object sender, EventArgs e)
        {

        }

        private void activeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (activeCheckBox.Checked)
            {
                stateLabel.Text = "ACTIVO";
                stateLabel.ForeColor = Color.Fuchsia;
            }
            else
            {
                stateLabel.Text = "INACTIVO";
                stateLabel.ForeColor = Color.FromArgb(90, 80, 255);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            AdminForm dashboard = this.ParentForm as AdminForm;
            dashboard.LoadProductControler();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            
        }



        private void Initialize()
        {
           // comboBoxCategory.SelectedIndex = 0;
          //  comboBoxProvider.SelectedIndex = 0;
        }

        private void buttonAddCategory_Click(object sender, EventArgs e)
        {
            NewCategoryForm newCategoryForm = new NewCategoryForm();
            newCategoryForm.ShowDialog();
        }
    }
}
