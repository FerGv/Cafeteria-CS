using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafeteria
{
    public class Materia_Prima
    {
        public int id_materia { get; set; }
        public string producto { get; set; }
        public float cantidad { get; set; }
        public float precio { get; set; }
        public float stock { get; set; }

        public Materia_Prima() { }

        public Materia_Prima(int id_materia, string producto, float cantidad, float precio, float stock)
        {
            this.id_materia = id_materia;
            this.producto = producto;
            this.cantidad = cantidad;
            this.precio = precio;
            this.stock = stock;
        }
    }
}
