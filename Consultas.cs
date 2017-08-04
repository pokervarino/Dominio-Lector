using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Dominio_Lector
{
    public class Consultas
    {
        MySqlCommand comando = new MySqlCommand();
        Conexion conexionMysql = new Conexion();


        public string ingresaAlumno(string User_alumno, string Nom_Alumno, string Ape_Alumno, Int32 Niv_Alumno, string Pass_Alumno ) 
        {
            try {
                conexionMysql.Desconectar();
                comando.Connection = conexionMysql.Conectar();
                comando.CommandText = @"Insert into Alumno (User_alumno, Nom_alumno, Ape_alumno, Niv_alumno, Pass_alumno) values(@User_alumno, @Nom_alumno, @Ape_alumno, @Niv_alumno, @Pass_alumno)";
                comando.Parameters.AddWithValue("@User_alumno", User_alumno);
                comando.Parameters.AddWithValue("@Nom_Alumno", Nom_Alumno);
                comando.Parameters.AddWithValue("@Ape_Alumno", Ape_Alumno);
                comando.Parameters.AddWithValue("@Niv_Alumno", Niv_Alumno);
                comando.Parameters.AddWithValue("@Pass_Alumno", Pass_Alumno);
                int filas = comando.ExecuteNonQuery();
                return "Exito";
            }
            catch (Exception ex) 
            {
                return null;
            }
        }

        public string ingresaLectura(string Nom_Lectura, string Des_Lectura, Int32 Niv_Lectura, Int32 Num_Lectura, string Url_Lectura, Int32 Est_Lectura) 
        {
            try {
                conexionMysql.Desconectar();
                comando.Connection = conexionMysql.Conectar();
                comando.CommandText = @"Insert into Lectura (Nom_Lectura, Des_Lectura, Niv_Lectura, Num_Lectura, Url_Lectura, Est_Lectura) values(@Nom_Lectura, @Des_Lectura, @Niv_Lectura, @Num_Lectura, @Url_Lectura, @Est_Lectura)";
                comando.Parameters.AddWithValue("@Nom_Lectura", Nom_Lectura);
                comando.Parameters.AddWithValue("@Des_Lectura", Des_Lectura);
                comando.Parameters.AddWithValue("@Niv_Lectura", Niv_Lectura);
                comando.Parameters.AddWithValue("@Num_Lectura", Num_Lectura);
                comando.Parameters.AddWithValue("@Url_Lectura", Url_Lectura);
                comando.Parameters.AddWithValue("@Est_Lectura", Est_Lectura);
                int filas = comando.ExecuteNonQuery();
                return "Exito";
            }
            catch (Exception ex) { return null; }
        }
        public MySqlDataReader recuperaLecturas()
        {
            try
            {
                conexionMysql.Desconectar();
                comando.Connection = conexionMysql.Conectar();
                comando.CommandText = @"SELECT * FROM lectura l ";
                MySqlDataReader reader = comando.ExecuteReader();
                return reader;
            }
            catch (Exception ex) { return null; }
        }

        public MySqlDataReader recuperaLecturasNo() 
        {
            try {
                conexionMysql.Desconectar();
                comando.Connection = conexionMysql.Conectar();
                comando.CommandText = @"SELECT * FROM lectura l where est_lectura = 0";
                MySqlDataReader reader = comando.ExecuteReader();
                return reader;
            }
            catch (Exception ex) { return null; }
        }
        public MySqlDataReader recuperaLecturasSi()
        {
            try
            {
                conexionMysql.Desconectar();
                comando.Connection = conexionMysql.Conectar();
                comando.CommandText = @"SELECT * FROM lectura l where est_lectura = 1";
                MySqlDataReader reader = comando.ExecuteReader();
                return reader;
            }
            catch (Exception ex) { return null; }
        }
        public string actualizaEstado1(Int32 estado) 
        {
            try {
                conexionMysql.Desconectar();
                comando.Connection = conexionMysql.Conectar();
                comando.CommandText = @"Update lectura set Est_Lectura = 1 where id_lectura = '"+estado+"'";
                int filas = comando.ExecuteNonQuery();
                return "Fila Modificada";

            }
            catch (Exception ex) { return null; }
        }
        public string actualizaEstado2(Int32 estado)
        {
            try
            {
                conexionMysql.Desconectar();
                comando.Connection = conexionMysql.Conectar();
                comando.CommandText = @"Update lectura set Est_Lectura = 0 where id_lectura = '" + estado + "'";
                int filas = comando.ExecuteNonQuery();
                return "Fila Modificada";

            }
            catch (Exception ex) { return null; }
        }

        public string creaPrueba(string Nom_Examen, string Des_Examen, Int32 Niv_Examen, Int32 Id_Lectura) 
        {
            try
            {
                conexionMysql.Desconectar();
                comando.Connection = conexionMysql.Conectar();
                comando.CommandText = @"Insert into Examenes (Nom_Examen, Des_Examen, Niv_Examen, Id_Lectura) values(@Nom_Examen, @Des_Examen, @Niv_Examen, @Id_Lectura)";
                comando.Parameters.AddWithValue("@Nom_Examen", Nom_Examen);
                comando.Parameters.AddWithValue("@Des_Examen", Des_Examen);
                comando.Parameters.AddWithValue("@Niv_Examen", Niv_Examen);
                comando.Parameters.AddWithValue("@Id_Lectura", Id_Lectura);
                int filas = comando.ExecuteNonQuery();
                return "Exito";
            }
            catch (Exception ex) { return null; }
        }
        public string agregaPreguntas(string Nom_Pregunta, Int32 Id_Examenes) {
            try {
                conexionMysql.Desconectar();
                comando.Connection = conexionMysql.Conectar();
                comando.CommandText = @"Insert into Preguntas (Nom_Pregunta, Id_Examenes) values(@Nom_Pregunta, @Id_Examenes)";
                comando.Parameters.AddWithValue("@Nom_Pregunta", Nom_Pregunta);
                comando.Parameters.AddWithValue("@Id_Examenes", Id_Examenes);
                int filas = comando.ExecuteNonQuery();
                return "Exito";
            }
            catch (Exception ex) { return null; }
        }
        public string agregaRespuesta(string Nom_Respuesta, Int32 Est_Respuesta, Int32 Id_Pregunta)
        {
            try{
                conexionMysql.Desconectar();
                comando.Connection = conexionMysql.Conectar();
                comando.CommandText = @"Insert into Respuestas (Nom_Respuesta, Est_Respuesta, Id_Pregunta) values(@Nom_Respuesta, @Est_Respuesta, @Id_Pregunta)";
                comando.Parameters.AddWithValue("@Nom_Respuesta", Nom_Respuesta);
                comando.Parameters.AddWithValue("@Est_Respuesta", Est_Respuesta);
                comando.Parameters.AddWithValue("@Id_Pregunta", Id_Pregunta);
                int filas = comando.ExecuteNonQuery();
                return "Exito";
            }
            catch(Exception ex){return null;}
        }
        public MySqlDataReader recuperaExamenes() 
        {
            try {
                conexionMysql.Desconectar();
                comando.Connection = conexionMysql.Conectar();
                comando.CommandText = @"Select * From Examenes";
                MySqlDataReader reader = comando.ExecuteReader();
                return reader;
            }
            catch (Exception ex) { return null; }
        }
        public MySqlDataReader recuperaPreguntas() 
        {
            try {
                conexionMysql.Desconectar();
                comando.Connection = conexionMysql.Conectar();
                comando.CommandText = @"Select * From Preguntas";
                MySqlDataReader reader = comando.ExecuteReader();
                return reader;
            }
            catch (Exception ex) { return null; }
        }
        public string actualizaEstadoRspta(string nombre) 
        {
            try {
                conexionMysql.Desconectar();
                comando.Connection = conexionMysql.Conectar();
                comando.CommandText = @"Update Respuestas set est_respuesta = 1 where nom_respuesta = '" + nombre +"'";
                int filas = comando.ExecuteNonQuery();
                return "Fila Modificada";
            }

            catch (Exception ex) { return null; }
        }
        public MySqlDataReader recuperaExamen(Int32 codigo) 
        {
            try {
                conexionMysql.Desconectar();
                comando.Connection = conexionMysql.Conectar();
                comando.CommandText = @"Select Id_Examen, Nom_Examen, Id_lectura from Examenes where id_lectura = '" + codigo + "'";
                MySqlDataReader reader = comando.ExecuteReader();
                return reader;

            }
            catch (Exception ex) { return null; }
        }
        public MySqlDataReader recupera1Lectura(Int32 codigo) 
        {
            try {
                conexionMysql.Desconectar();
                comando.Connection = conexionMysql.Conectar();
                comando.CommandText = @"Select Id_lectura, Nom_Lectura, Num_Lectura, Url_Lectura from lectura where id_lectura = '" + codigo + "'";
                MySqlDataReader reader = comando.ExecuteReader();
                return reader;
            }
            catch (Exception ex) { return null; }
        }
        public MySqlDataReader loginAdmin(string username, string password)
        {
            try
            {
                conexionMysql.Desconectar();
                comando.Connection = conexionMysql.Conectar();
                comando.CommandText = @"Select Id_Profesor, User_Profesor, Pass_Profesor from Profesor where User_profesor = '" + username + "' and Pass_Profesor = '" + password + "'";
                MySqlDataReader reader = comando.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public MySqlDataReader loginAlumno(string username, string password)
        {
            try
            {
                conexionMysql.Desconectar();
                comando.Connection = conexionMysql.Conectar();
                comando.CommandText = @"Select Id_Alumno, User_Alumno, Pass_Alumno from Alumno where User_Alumno = '" + username + "' and Pass_Alumno = '" + password + "'";
                MySqlDataReader reader = comando.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public MySqlDataReader recupera1Pregunta(Int32 codigo) 
        {
            try {
                conexionMysql.Desconectar();
                comando.Connection = conexionMysql.Conectar();
                comando.CommandText = @"select id_pregunta, nom_pregunta, id_examenes from preguntas where id_examenes = '" + codigo + "'";
                MySqlDataReader reader = comando.ExecuteReader();
                return reader;
            }
            catch (Exception ex) { return null; }
        }

        
    }
}
