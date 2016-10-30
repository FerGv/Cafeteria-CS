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

        public static List<Materia_Prima> Consulta_Producto(string Producto)
        {
            List<Materia_Prima> _lista = new List<Materia_Prima>();
            MySqlConnection conexion = Conexion.ObtenerConexion();

            MySqlCommand _comando = new MySqlCommand(String.Format("SELECT id_materia, producto, cantidad, precio, stock FROM materia_prima WHERE producto = '{0}'", Producto), conexion);
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                Materia_Prima mat_prim = new Materia_Prima();
                mat_prim.id_materia = _reader.GetInt32(0);
                mat_prim.producto = _reader.GetString(1);
                mat_prim.cantidad = _reader.GetFloat(2);
                mat_prim.precio = _reader.GetFloat(3);
                mat_prim.stock = _reader.GetFloat(4);

                _lista.Add(mat_prim);
            }

            conexion.Close();
            return _lista;
        }

        public static int Modificar_Producto(Materia_Prima mat_prim)
        {
            int retorno = 0;
            MySqlConnection conexion = Conexion.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(string.Format("Update materia_prima set producto='{0}', cantidad={1}, precio={2}, stock={3} where id_materia={4}",
                mat_prim.producto, mat_prim.cantidad, mat_prim.precio, mat_prim.stock, mat_prim.id_materia), conexion);

            retorno = comando.ExecuteNonQuery();
            conexion.Close();

            return retorno;


        }

        public static Materia_Prima Obtener_Producto(int id_materia)
        {
            Materia_Prima mat_prim = new Materia_Prima();
            MySqlConnection conexion = Conexion.ObtenerConexion();

            MySqlCommand _comando = new MySqlCommand(String.Format("SELECT id_materia, producto, cantidad, precio, stock FROM materia_prima WHERE id_materia = '{0}'", id_materia), conexion);
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                mat_prim.id_materia = _reader.GetInt32(0);
                mat_prim.producto = _reader.GetString(1);
                mat_prim.cantidad = _reader.GetFloat(2);
                mat_prim.precio = _reader.GetFloat(3);
                mat_prim.stock = _reader.GetFloat(4);
            }

            conexion.Close();
            return mat_prim;
        }

        public static int Baja_Producto(int id_materia)
        {
            int retorno = 0;
            MySqlConnection conexion = Conexion.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(string.Format("Delete From materia_prima where id_materia={0}", id_materia), conexion);

            retorno = comando.ExecuteNonQuery();
            conexion.Close();

            return retorno;

        }

        public static List<Materia_Prima> Reporte_Productos()
        {
            List<Materia_Prima> _lista = new List<Materia_Prima>();
            MySqlConnection conexion = Conexion.ObtenerConexion();

            MySqlCommand _comando = new MySqlCommand(String.Format("SELECT id_materia, producto, cantidad, precio, stock FROM materia_prima"), conexion);
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                Materia_Prima mat_prim = new Materia_Prima();
                mat_prim.id_materia = _reader.GetInt32(0);
                mat_prim.producto = _reader.GetString(1);
                mat_prim.cantidad = _reader.GetFloat(2);
                mat_prim.precio = _reader.GetFloat(3);
                mat_prim.stock = _reader.GetFloat(4);

                _lista.Add(mat_prim);
            }

            conexion.Close();
            return _lista;
        }
    }
}
