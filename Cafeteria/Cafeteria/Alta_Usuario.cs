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
    public partial class Alta_Usuario : Form
    {
        public Alta_Usuario()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
                MessageBox.Show("Introduce el nombre");
            else
            {
                if (txtPass.Text == "")
                    MessageBox.Show("Introduce la contraseña");
                else
                {
                    Usuario user = new Usuario();
                    user.usuario = txtUsuario.Text;
                    user.pass = txtPass.Text;

                    int resultado = Funciones.Agregar_Usuario(user);

                    if (resultado > 0)
                    {
                        MessageBox.Show("Usuario Guardado Con Exito");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Error al guardar Usuario");
                    }
                }
            }

            Close();
        }
    }
}
