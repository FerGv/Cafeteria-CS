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
    public partial class Modificar_Producto : Form
    {
        public Materia_Prima mp { get; set; }

        public Modificar_Producto(Materia_Prima mat_prim)
        {
            InitializeComponent();
            this.mp = mat_prim;
            txtProducto.Text = mp.producto;
            txtCantidad.Text = mp.cantidad.ToString();
            cmbUnidades.Text = mp.unidad;
            txtPrecio.Text = mp.precio.ToString();
            txtStock.Text = mp.stock.ToString();
            
            //MessageBox.Show(valor);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Materia_Prima mat_prim = new Materia_Prima();

            mat_prim.producto = txtProducto.Text.Trim();
            mat_prim.cantidad = float.Parse(txtCantidad.Text);
            mat_prim.unidad = cmbUnidades.SelectedItem.ToString();
            mat_prim.precio = float.Parse(txtPrecio.Text);
            mat_prim.stock = float.Parse(txtStock.Text);
            mat_prim.id_materia = mp.id_materia;

            if (Funciones.Modificar_Producto(mat_prim) > 0)
            {
                MessageBox.Show("Los datos del producto se actualizaron", "Datos Actualizados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo actualizar", "Error al Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            Close();
        }
    }
}
