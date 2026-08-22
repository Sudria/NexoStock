using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NexoStock.Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            hopeTextBox1.BackColor = Color.FromArgb(5, 7, 25);
            hopeTextBox1.BaseColor = Color.FromArgb(5, 7, 25);

            hopeTextBox1.BorderColorA = Color.FromArgb(255, 30, 190);
            hopeTextBox1.BorderColorB = Color.FromArgb(90, 100, 255);

            hopeTextBox1.ForeColor = Color.White;

            hopeTextBox1.Hint = "Usuario";

            hopeTextBox1.Font = new Font("Segoe UI", 11F);
        }

        private void hopeTextBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
