using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafeteria
{
    public class Usuario
    {
        public int id_usuario { get; set; }
        public string usuario { get; set; }
        public string pass { get; set; }

        public Usuario() { }

        public Usuario(int id_usuario, string usuario, string pass)
        {
            this.id_usuario = id_usuario;
            this.usuario = usuario;
            this.pass = pass;
        }
    }
}
