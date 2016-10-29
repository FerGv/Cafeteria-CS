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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        public Usuario user { get; set; }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
                MessageBox.Show("Debes llenar el nombre");
            else
            {
                if (txtPass.Text == "")
                    MessageBox.Show("Debes llenar la contraseña");
                else
                {
                    user = Funciones.Consulta_Usuario(txtNombre.Text, txtPass.Text);

                    if ((user.usuario == txtNombre.Text) && (user.pass == txtPass.Text))
                    {
                        MessageBox.Show("Bienvenido");
                        Menu menu = new Menu();
                        menu.Show();
                        Close();
                    }
                    else
                        MessageBox.Show("Datos incorrectos");
                }
            }
        }
    }
}
