using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafeteria
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Alta_Producto alta = new Alta_Producto();
            alta.Show();
            Close();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Consulta_Producto consulta = new Consulta_Producto();
            consulta.Show();
            Close();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            Reporte_Productos reporte = new Reporte_Productos();
            reporte.Show();
            Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
