using System;
using Entity;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Datos
{
    public class EstudianteRepository
    {
         private readonly SqlConnection _connection;
        private readonly List<Estudiante> _estudiantes = new List<Estudiante>();
        
        public EstudianteRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }

        public void Guardar(Estudiante estudiante)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"Insert Into Estudiante (Identificacion,PrimerNombre,SegundoNombre,PrimerApellido,"+
                                                    "SegundoApellido,Celular,Correo)"+
                                        "values (@Identificacion,@PrimerNombre,@SegundoNombre,@PrimerApellido,@SegundoApellido,"+
                                        "@Celular,@Correo)";
                command.Parameters.AddWithValue("@Identificacion", estudiante.Identificacion);
                command.Parameters.AddWithValue("@PrimerNombre", estudiante.PrimerNombre);
                command.Parameters.AddWithValue("@SegundoNombre", estudiante.SegundoNombre);
                command.Parameters.AddWithValue("@PrimerApellido", estudiante.PrimerApellido);
                command.Parameters.AddWithValue("@SegundoApellido", estudiante.SegundoApellido);
                command.Parameters.AddWithValue("@Celular", estudiante.Celular);
                command.Parameters.AddWithValue("@Correo", estudiante.Correo);
                var filas = command.ExecuteNonQuery();
            }
        }

        public void Eliminar(Estudiante estudiante)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Delete from Estudiante where Identificacion=@Identificacion";
                command.Parameters.AddWithValue("@Identificacion", estudiante.Identificacion);
                command.ExecuteNonQuery();
            }
        }

        public List<Estudiante> ConsultarTodos()
        {
            SqlDataReader dataReader;
            List<Estudiante> estudiantes = new List<Estudiante>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select * from Estudiante ";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Estudiante estudiante = DataReaderMapToPerson(dataReader);
                        estudiantes.Add(estudiante);
                    }
                }
            }
            return estudiantes;
        }

        public Estudiante BuscarPorIdentificacion(string identificacion)
        {
            SqlDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from Estudiante where Identificacion=@Identificacion";
                command.Parameters.AddWithValue("@Identificacion", identificacion);
                dataReader = command.ExecuteReader();
                dataReader.Read();
                return DataReaderMapToPerson(dataReader);
            }
        }

        private Estudiante DataReaderMapToPerson(SqlDataReader dataReader)
        {
            if(!dataReader.HasRows) return null;
            Estudiante estudiante = new Estudiante();
            estudiante.Identificacion = (string)dataReader["Identificacion"];
            estudiante.PrimerNombre = (string)dataReader["PrimerNombre"];
            estudiante.SegundoNombre = (string)dataReader["SegundoNombre"];
            estudiante.PrimerApellido = (string)dataReader["PrimerApellido"];
            estudiante.SegundoApellido = (string)dataReader["SegundoApellido"];
            estudiante.Celular = (string)dataReader["Celular"];
            estudiante.Correo = (string)dataReader["Correo"];
            return estudiante;
        }
        
    }
}