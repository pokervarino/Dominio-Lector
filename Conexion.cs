using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Dominio_Lector
{
    class Conexion
    {
        private MySqlConnection conexionDB = new MySqlConnection();
        public MySqlConnection Conectar()
        {
            MySqlConnection con = new MySqlConnection(RetornaCadenaConexion());
            conexionDB = con;
            try
            {
                conexionDB.Open();
                return conexionDB;
            }
            catch (Exception ex)
            {
                return (conexionDB);
            }
        }
        public void Desconectar()
        {
            conexionDB.Close();
            conexionDB.Dispose();
        }
        public String RetornaCadenaConexion()
        {
            return "Server=localhost;DataBase=Lector;Uid=root;Pwd=diego";
        }

    }
}
