using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO.Packaging;
//using System.Data.SqlClient;

namespace CRUDEstatus.Clases
{
    internal class EstatusAlumno:ICRUDEstatus
    {

       private List<EstatusAlumnosEntity> _listEstatusAlu = new List<EstatusAlumnosEntity>();
       string conexion = ConfigurationManager.ConnectionStrings["ConexionLocal"].ConnectionString;

        //=========================================
        // CARGAR TODA LA LISTA DE ESTATUS ALUMNO
        //=========================================
        public List<EstatusAlumnosEntity> ObtenerTodos()
        {
            string selectodos = $"select * from EstatusAlumnos";
            _listEstatusAlu.Clear();
            using (SqlConnection connection = new SqlConnection(conexion))
            {
                SqlCommand commandRead = new SqlCommand(selectodos, connection);
                commandRead.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader reader = commandRead.ExecuteReader();
                while (reader.Read())
                {
                    _listEstatusAlu.Add
                        (
                            new EstatusAlumnosEntity()
                            {
                                id = Convert.ToInt32( reader["id"]),
                                nombre = reader["nombre"].ToString(),
                                clave = reader["clave"].ToString()

                            }
                        );
                }
                connection.Close();
                          
            }
           return _listEstatusAlu;
        }

                     //===========================
                     // CONSULTAR UN ESTATUS ALUMNO
                     //===========================
        public EstatusAlumnosEntity ConsultarUno(int idEstatus)
        {
            EstatusAlumnosEntity alumnosEntity = new EstatusAlumnosEntity();
            string selectUno = $"select * from EstatusAlumnos where id = {idEstatus}";
            using (SqlConnection connection = new SqlConnection(conexion))
            {
                SqlCommand commandRead = new SqlCommand(selectUno, connection);
                commandRead.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader dataReader = commandRead.ExecuteReader();
                while (dataReader.Read())
                {
                   alumnosEntity.id = Convert.ToInt32( dataReader["id"]);
                   alumnosEntity.nombre = dataReader["nombre"].ToString();
                    alumnosEntity.clave = dataReader["clave"].ToString();
                }
                connection.Close();
            }
            return alumnosEntity;
        }

        public void Agregar(string Nombre, string Clave)
        {
            string agregarEstatus = $"sp_agregarEstatusAlumnos";
            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand commandAgregar = new SqlCommand(agregarEstatus, con);
                commandAgregar.CommandType = CommandType.StoredProcedure;

                con.Open();
                commandAgregar.Parameters.AddWithValue("nombre", Nombre);
                commandAgregar.Parameters.AddWithValue("clave", Clave);

                commandAgregar.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Actualizar(int idEstatus, string nombreEstatus, String Clave)
        {
            string actualzarEstatus = $"update EstatusAlumnos set nombre = '{nombreEstatus}', clave='{Clave}' where id={idEstatus}";

            using (SqlConnection conection = new SqlConnection(conexion))
            {
                SqlCommand commandActualizar = new SqlCommand(actualzarEstatus, conection);
                commandActualizar.CommandType = CommandType.Text;
                conection.Open();
                commandActualizar.ExecuteNonQuery();
                conection.Close();
            }

        }

        public void Eliminar(int idEstatus)
        {
            string eliminarEstatus = $"delete EstatusAlumnos where id={idEstatus}";
            using (SqlConnection conection = new SqlConnection(conexion))
            {
                SqlCommand commandEliminar = new SqlCommand(eliminarEstatus, conection);
                commandEliminar.CommandType = CommandType.Text;
                conection.Open();
                commandEliminar.ExecuteNonQuery();
                conection.Close();
            }
        }
        
    }
}
