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
    public partial class Reporte_Productos : Form
    {
        public Reporte_Productos(List<Materia_Prima> mat_prim)
        {
            InitializeComponent();
            dgvProductos.DataSource = mat_prim;
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

        Materia_Prima mat_prim_seleccionada;

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value);
                mat_prim_seleccionada = Funciones.Obtener_Producto(id);

                if (MessageBox.Show("¿Seguro que desea eliminar el producto actual?", "Eliminar Producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (Funciones.Baja_Producto(mat_prim_seleccionada.id_materia) > 0)
                    {
                        MessageBox.Show("Producto Eliminado Correctamente", "Producto Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el producto", "Producto No Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    List<Materia_Prima> mp = new List<Materia_Prima>();
                    mp = Funciones.Reporte_Productos();
                    Reporte_Productos reporte = new Reporte_Productos(mp);
                    reporte.Show();
                    Close();
                }
                else
                    MessageBox.Show("Se canceló la eliminación", "Eliminación Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                
            }
            else
                MessageBox.Show("Por favor selecciona la fila del producto.");
        }


        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value);
                mat_prim_seleccionada = Funciones.Obtener_Producto(id);

                Modificar_Producto modificar = new Modificar_Producto(mat_prim_seleccionada);
                modificar.ShowDialog();

                List<Materia_Prima> mp = new List<Materia_Prima>();
                mp = Funciones.Reporte_Productos();
                Reporte_Productos reporte = new Reporte_Productos(mp);
                reporte.Show();
                Close();
            }
            else
                MessageBox.Show("Por favor selecciona la fila del producto.");
        }
    }
}
