using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Cafeteria
{
    public class Funciones
    {
        public static Usuario Consulta_Usuario(string usuario, string pass)
        {
            Usuario usuario_login = new Usuario();
            MySqlConnection conexion = Conexion.ObtenerConexion();

            MySqlCommand _comando = new MySqlCommand(String.Format("SELECT usuario,pass FROM usuarios where (usuario='{0}' and pass='{1}')", usuario, pass), conexion);
            MySqlDataReader _reader = _comando.ExecuteReader();

            while (_reader.Read())
            {
                usuario_login.usuario = _reader.GetString(0);
                usuario_login.pass = _reader.GetString(1);
            }

            conexion.Close();
            return usuario_login;
        }

        public static int Agregar_Producto(Materia_Prima mat_prim)
        {
            int retorno = 0;
            MySqlConnection conexion = Conexion.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(string.Format("INSERT INTO materia_prima (producto, cantidad, precio, stock) values ('{0}',{1},{2},{3})",
                mat_prim.producto, mat_prim.cantidad, mat_prim.precio, mat_prim.stock), conexion);

            retorno = comando.ExecuteNonQuery();
            conexion.Close();
            return retorno;
        }
    }
}
