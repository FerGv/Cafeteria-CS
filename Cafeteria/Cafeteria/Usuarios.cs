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
    public partial class Usuarios : Form
    {
        public Usuarios(List<Usuario> users)
        {
            InitializeComponent();
            dgvUsuarios.DataSource = users;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Owner.Show();
            Close();
        }
    }
}
