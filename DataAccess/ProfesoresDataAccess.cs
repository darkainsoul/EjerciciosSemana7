using Entidades;
using MySql.Data.MySqlClient;
using System;

namespace DataAccess
{
    public class ProfesoresDataAccess
    {
        public void Registrar(DatosPersona profesor)
        {
            try
            {
                var cadenaConexion = new Conexion().CadenaConexion();
                var conexion = new MySqlConnection(cadenaConexion);
                string query = "INSERT INTO escuela.Profesores (Nombre,Edad) VALUES ('" + profesor.Nombre + "', " + profesor.Edad + ");";
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

        public void Actualizar(DatosPersona profesor)
        {
            try
            {
                var cadenaConexion = new Conexion().CadenaConexion();
                var conexion = new MySqlConnection(cadenaConexion);

                string query = "UPDATE escuela.Profesores SET Nombre= '" + profesor.Nombre + "', Edad= " + profesor.Edad + " WHERE idProfesores = " + profesor.ID + ";";
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

        public Alumnos GetAlumno(int profesorId)
        {
            Alumnos result = new Alumnos();
            try
            {
                var cadenaConexion = new Conexion().CadenaConexion();
                var conexion = new MySqlConnection(cadenaConexion);

                string query = "SELECT Profesores.idProfesores, Profesores.Nombre, Profesores.Edad FROM escuela.Profesores WHERE idProfesores = " + profesorId + ";";
                MySqlCommand MyCommand2 = new MySqlCommand(query, conexion);
                conexion.Open();
                MySqlDataReader dataReader = MyCommand2.ExecuteReader();

                while (dataReader.Read())
                {
                    result.ID = Convert.ToInt32(dataReader["idProfesores"]);
                    result.Nombre = dataReader["Nombre"].ToString();
                    result.Edad = Convert.ToInt32(dataReader["Edad"]);
                    result.Tipo = TipoDePersona.Profesor;
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