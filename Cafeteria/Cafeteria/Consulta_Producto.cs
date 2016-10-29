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
    public partial class Consulta_Producto : Form
    {
        public Consulta_Producto()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvProducto.DataSource = Funciones.Consulta_Producto(txtProducto.Text);

            if (dgvProducto.RowCount == 0)
                MessageBox.Show("Producto No encontrado");
        }



        Materia_Prima mat_prim_seleccionada;

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProducto.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dgvProducto.CurrentRow.Cells[0].Value);
                mat_prim_seleccionada = Funciones.Obtener_Producto(id);

                if (MessageBox.Show("¿Seguro que desea eliminar el producto actual", "Eliminar Producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (Funciones.Baja_Producto(mat_prim_seleccionada.id_materia) > 0)
                    {
                        MessageBox.Show("Producto Eliminado Correctamente!", "Producto Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el producto", "Prodcuto No Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                    MessageBox.Show("Se canceló la eliminación", "Eliminacion Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                Menu menu = new Menu();
                menu.Show();
                Close();
            }
            else
                MessageBox.Show("Por favor selecciona la fila del producto.");
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

        }
    }
}
