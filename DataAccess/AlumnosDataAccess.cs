using Entidades;
using MySql.Data.MySqlClient;
using System;

namespace DataAccess
{
    public class AlumnosDataAccess
    {
        public void Registrar(DatosPersona alumno)
        {
            try
            {
                var cadenaConexion = new Conexion().CadenaConexion();
                var conexion = new MySqlConnection(cadenaConexion);
                string query = "INSERT INTO escuela.Alumnos (Nombre,Edad) VALUES ('" + alumno.Nombre + "', " + alumno.Edad + ");";
                MySqlCommand MyCommand2 = new MySqlCommand(query, conexion);
                conexion.Open();
                int rowsInserted = MyCommand2.ExecuteNonQuery();

                conexion.Close();
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }

        public void Actualizar(DatosPersona alumno)
        {
            try
            {
                var cadenaConexion = new Conexion().CadenaConexion();
                var conexion = new MySqlConnection(cadenaConexion);

                string query = "UPDATE escuela.Alumnos SET Nombre= '" + alumno.Nombre + "', Edad= " + alumno.Edad + " WHERE idAlumnos = " + alumno.ID + ";";
                MySqlCommand MyCommand2 = new MySqlCommand(query, conexion);
                conexion.Open();
                int rowsInserted = MyCommand2.ExecuteNonQuery();

                conexion.Close();
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }

        public Alumnos GetAlumno(int alumnoId)
        {
            Alumnos result = new Alumnos();
            try
            {
                var cadenaConexion = new Conexion().CadenaConexion();
                var conexion = new MySqlConnection(cadenaConexion);

                string query = "SELECT Alumnos.idAlumnos, Alumnos.Nombre, Alumnos.Edad FROM escuela.Alumnos WHERE idAlumnos = " + alumnoId + ";";
                MySqlCommand MyCommand2 = new MySqlCommand(query, conexion);
                conexion.Open();
                MySqlDataReader dataReader = MyCommand2.ExecuteReader();

                while (dataReader.Read())
                {
                    result.ID = Convert.ToInt32(dataReader["idAlumnos"]);
                    result.Nombre = dataReader["Nombre"].ToString();
                    result.Edad = Convert.ToInt32(dataReader["Edad"]);
                    result.Tipo = TipoDePersona.Alumno;
                }

                //close Data Reader
                dataReader.Close();

                conexion.Close();
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }

            return result;
        }
    }
}