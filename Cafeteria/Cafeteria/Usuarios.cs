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
            Login login = new Login();
            login.Show();
            Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Alta_Usuario alta = new Alta_Usuario();
            alta.ShowDialog();

            List<Usuario> usuario = new List<Usuario>();
            usuario = Funciones.Reporte_Usuarios();
            Usuarios reporte = new Usuarios(usuario);
            reporte.Show();
            Close();
        }

        Usuario user;

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells[0].Value);
                user = Funciones.Obtener_Usuario(id);

                Modificar_Usuario modificar = new Modificar_Usuario(user);
                modificar.ShowDialog();

                List<Usuario> usuario = new List<Usuario>();
                usuario = Funciones.Reporte_Usuarios();
                Usuarios reporte = new Usuarios(usuario);
                reporte.Show();
                Close();
            }
            else
                MessageBox.Show("Por favor selecciona la fila del producto.");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells[0].Value);

                if (id == 1)
                    MessageBox.Show("No se puede eliminar al administrador");
                else
                {
                    user = Funciones.Obtener_Usuario(id);

                    if (MessageBox.Show("¿Seguro que desea eliminar el usuario actual?", "Eliminar Usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (Funciones.Baja_Usuario(user.id_usuario) > 0)
                        {
                            MessageBox.Show("Usuario Eliminado Correctamente", "Usuario Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar el usuario", "Usuario No Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                        List<Usuario> usuario = new List<Usuario>();
                        usuario = Funciones.Reporte_Usuarios();
                        Usuarios reporte = new Usuarios(usuario);
                        reporte.Show();
                        Close();
                    }
                    else
                        MessageBox.Show("Se canceló la eliminación", "Eliminación Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
                MessageBox.Show("Por favor selecciona la fila del producto.");
        }
    }
}
