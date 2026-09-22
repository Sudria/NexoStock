using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NexoStock.Utils
{
    public partial class Tests : Form
    {
        private ConnectionDB connectionDB;
        public Tests()
        {
            InitializeComponent();
            connectionDB = new ConnectionDB();
        }

        private void cyberButton1_Click(object sender, EventArgs e)
        {
            if (connectionDB.GetConnection() != null)
            {
                MessageBox.Show("Conexión exitosa a la base de datos.");
            }
            else
            {
                MessageBox.Show("No se pudo conectar a la base de datos.");
            }
        }
    }
}
