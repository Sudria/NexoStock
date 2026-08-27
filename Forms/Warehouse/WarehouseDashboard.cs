using FontAwesome.Sharp;
using ReaLTaiizor.Controls;
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
    public partial class WarehouseDashboard : UserControl
    {
        public WarehouseDashboard()
        {
            InitializeComponent();
        }



        private void changeStateButton(CyberButton e) {
            if (e.Lighting)
            {
               innactiveButton(e);
            }
            else
            {
                activeButton(e);
            }
           
        }

  


        private void activeButton(CyberButton e)
        {
            e.ColorPen_1 = Color.FromArgb(192, 0, 192);
            e.ColorPen_2 = Color.Violet;
            e.LinearGradient_Background = true;
            e.Lighting = true;
            e.ColorBackground_1 = Color.Fuchsia;
            e.ColorBackground_2 = Color.MediumSlateBlue;
        }

        private void innactiveButton(CyberButton e)
        {
            e.ColorPen_1 = Color.Transparent;
            e.ColorPen_2 = Color.Transparent;
            e.Lighting = false;
            e.LinearGradient_Background = false;
        }





        private void buttonClick(object sender, EventArgs e)
        {
            changeStateButton((CyberButton)sender);

        }


        private void HomeButton_Click(object sender, EventArgs e)
        {

        }
    }
}
