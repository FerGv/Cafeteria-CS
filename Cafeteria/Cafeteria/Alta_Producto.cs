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
    public partial class Alta_Producto : Form
    {
        public Alta_Producto()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtProducto.Text == "")
                MessageBox.Show("Introduce el nombre");
            else
            {
                if (txtCantidad.Text == "")
                    MessageBox.Show("Introduce la cantidad");
                else
                {
                    if(cmbUnidades.SelectedItem == null)
                        MessageBox.Show("Escoge una unidad");
                    else
                    {
                        if (txtPrecio.Text == "")
                            MessageBox.Show("Introduce el precio");
                        else
                        {
                            if (txtStock.Text == "")
                                MessageBox.Show("Introduce el stock mínimo");
                            else
                            {
                                Materia_Prima mat_prim = new Materia_Prima();
                                mat_prim.producto = txtProducto.Text;
                                mat_prim.cantidad = float.Parse(txtCantidad.Text);
                                mat_prim.precio = float.Parse(txtPrecio.Text);
                                mat_prim.stock = float.Parse(txtStock.Text);

                                int resultado = Funciones.Agregar_Producto(mat_prim);

                                if (resultado > 0)
                                {
                                    MessageBox.Show("Materia Prima Guardada Con Exito");
                                    Menu menu = new Menu();
                                    menu.Show();
                                    Close();
                                }
                                else
                                {
                                    MessageBox.Show("Error al guardar Materia Prima");
                                }
                            }
                        }
                    }
                }

            }
        }
    }
}
