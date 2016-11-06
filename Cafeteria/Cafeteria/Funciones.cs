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
        public static int Agregar_Usuario(Usuario user)
        {
            int retorno = 0;
            MySqlConnection conexion = Conexion.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(string.Format("INSERT INTO usuarios (usuario, pass) values ('{0}','{1}')",
                user.usuario, user.pass), conexion);

            retorno = comando.ExecuteNonQuery();
            conexion.Close();
            return retorno;
        }

        public static int Baja_Usuario(int id_usuario)
        {
            int retorno = 0;
            MySqlConnection conexion = Conexion.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(string.Format("Delete From usuarios where id_usuario={0}", id_usuario), conexion);

            retorno = comando.ExecuteNonQuery();
            conexion.Close();

            return retorno;

        }

        public static Usuario Consulta_Usuario(string usuario, string pass)
        {
            Usuario usuario_login = new Usuario();
            MySqlConnection conexion = Conexion.ObtenerConexion();

            MySqlCommand _comando = new MySqlCommand(String.Format("SELECT id_usuario, usuario, pass FROM usuarios where (usuario='{0}' and pass='{1}')", usuario, pass), conexion);
            MySqlDataReader _reader = _comando.ExecuteReader();

            while (_reader.Read())
            {
                usuario_login.id_usuario = _reader.GetInt32(0);
                usuario_login.usuario = _reader.GetString(1);
                usuario_login.pass = _reader.GetString(2);
            }

            conexion.Close();
            return usuario_login;
        }

        public static int Modificar_Usuario(Usuario user)
        {
            int retorno = 0;
            MySqlConnection conexion = Conexion.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(string.Format("UPDATE usuarios SET usuario='{0}', pass='{1}' WHERE id_usuario={2}",
                user.usuario, user.pass, user.id_usuario), conexion);

            retorno = comando.ExecuteNonQuery();
            conexion.Close();

            return retorno;


        }

        public static List<Usuario> Reporte_Usuarios()
        {
            List<Usuario> _lista = new List<Usuario>();
            MySqlConnection conexion = Conexion.ObtenerConexion();

            MySqlCommand _comando = new MySqlCommand(String.Format("SELECT id_usuario, usuario, pass FROM usuarios"), conexion);
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                Usuario user = new Usuario();
                user.id_usuario = _reader.GetInt32(0);
                user.usuario = _reader.GetString(1);
                user.pass = _reader.GetString(2);

                _lista.Add(user);
            }

            conexion.Close();
            return _lista;
        }

        public static Usuario Obtener_Usuario(int id_usuario)
        {
            Usuario user = new Usuario();
            MySqlConnection conexion = Conexion.ObtenerConexion();

            MySqlCommand _comando = new MySqlCommand(String.Format("SELECT id_usuario, usuario, pass FROM usuarios WHERE id_usuario = {0}", id_usuario), conexion);
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                user.id_usuario = _reader.GetInt32(0);
                user.usuario = _reader.GetString(1);
                user.pass = _reader.GetString(2);
            }

            conexion.Close();
            return user;
        }



        public static int Agregar_Producto(Materia_Prima mat_prim)
        {
            int retorno = 0;
            MySqlConnection conexion = Conexion.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(string.Format("INSERT INTO materia_prima (producto, cantidad, unidad, precio, stock) values ('{0}',{1},'{2}',{3},{4})",
                mat_prim.producto, mat_prim.cantidad, mat_prim.unidad, mat_prim.precio, mat_prim.stock), conexion);

            retorno = comando.ExecuteNonQuery();
            conexion.Close();
            return retorno;
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

        public static List<Materia_Prima> Consulta_Producto(string Producto)
        {
            List<Materia_Prima> _lista = new List<Materia_Prima>();
            MySqlConnection conexion = Conexion.ObtenerConexion();

            MySqlCommand _comando = new MySqlCommand(String.Format("SELECT id_materia, producto, cantidad, unidad, precio, stock FROM materia_prima WHERE producto = '{0}'", Producto), conexion);
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                Materia_Prima mat_prim = new Materia_Prima();
                mat_prim.id_materia = _reader.GetInt32(0);
                mat_prim.producto = _reader.GetString(1);
                mat_prim.cantidad = _reader.GetFloat(2);
                mat_prim.unidad = _reader.GetString(3);
                mat_prim.precio = _reader.GetFloat(4);
                mat_prim.stock = _reader.GetFloat(5);

                _lista.Add(mat_prim);
            }

            conexion.Close();
            return _lista;
        }

        public static int Modificar_Producto(Materia_Prima mat_prim)
        {
            int retorno = 0;
            MySqlConnection conexion = Conexion.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(string.Format("UPDATE materia_prima SET producto='{0}', cantidad={1}, unidad='{2}', precio={3}, stock={4} WHERE id_materia={5}",
                mat_prim.producto, mat_prim.cantidad, mat_prim.unidad, mat_prim.precio, mat_prim.stock, mat_prim.id_materia), conexion);

            retorno = comando.ExecuteNonQuery();
            conexion.Close();

            return retorno;


        }
   
        public static List<Materia_Prima> Reporte_Productos()
        {
            List<Materia_Prima> _lista = new List<Materia_Prima>();
            MySqlConnection conexion = Conexion.ObtenerConexion();

            MySqlCommand _comando = new MySqlCommand(String.Format("SELECT id_materia, producto, cantidad, unidad, precio, stock FROM materia_prima"), conexion);
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                Materia_Prima mat_prim = new Materia_Prima();
                mat_prim.id_materia = _reader.GetInt32(0);
                mat_prim.producto = _reader.GetString(1);
                mat_prim.cantidad = _reader.GetFloat(2);
                mat_prim.unidad = _reader.GetString(3);
                mat_prim.precio = _reader.GetFloat(4);
                mat_prim.stock = _reader.GetFloat(5);

                _lista.Add(mat_prim);
            }

            conexion.Close();
            return _lista;
        }

        public static Materia_Prima Obtener_Producto(int id_materia)
        {
            Materia_Prima mat_prim = new Materia_Prima();
            MySqlConnection conexion = Conexion.ObtenerConexion();

            MySqlCommand _comando = new MySqlCommand(String.Format("SELECT id_materia, producto, cantidad, unidad, precio, stock FROM materia_prima WHERE id_materia = {0}", id_materia), conexion);
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                mat_prim.id_materia = _reader.GetInt32(0);
                mat_prim.producto = _reader.GetString(1);
                mat_prim.cantidad = _reader.GetFloat(2);
                mat_prim.unidad = _reader.GetString(3);
                mat_prim.precio = _reader.GetFloat(4);
                mat_prim.stock = _reader.GetFloat(5);
            }

            conexion.Close();
            return mat_prim;
        }
    }
}
