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
    public partial class Modificar_Usuario : Form
    {
        public Usuario usuario { get; set; }

        public Modificar_Usuario(Usuario user)
        {
            InitializeComponent();
            this.usuario = user;
            txtUsuario.Text = usuario.usuario;
            txtPass.Text = usuario.pass;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Usuario user = new Usuario();

            user.usuario = txtUsuario.Text.Trim();
            user.pass = txtPass.Text.Trim();
            user.id_usuario = usuario.id_usuario;

            if (Funciones.Modificar_Usuario(user) > 0)
            {
                MessageBox.Show("Los datos del usuario se actualizaron", "Datos Actualizados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo actualizar", "Error al Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            Close();
        }
    }
}
