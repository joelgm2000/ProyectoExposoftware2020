using System;
using Entity;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Datos
{
    public class DocenteRepository
    {
         private readonly SqlConnection _connection;
        private readonly List<Docente> _docentes = new List<Docente>();
        
        public DocenteRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }
        
        public void Guardar(Docente docente)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"Insert Into LiderProyecto (Identificacion,PrimerNombre,SegundoNombre,PrimerApellido,"+
                                                    "SegundoApellido,Celular,Correo,TipoDocente)"+
                                        "values (@Identificacion,@PrimerNombre,@SegundoNombre,@PrimerApellido,@SegundoApellido,"+
                                        "@Celular,@Correo,@TipoDocente)";
                command.Parameters.AddWithValue("@Identificacion", docente.Identificacion);
                command.Parameters.AddWithValue("@PrimerNombre", docente.PrimerNombre);
                command.Parameters.AddWithValue("@SegundoNombre", docente.SegundoNombre);
                command.Parameters.AddWithValue("@PrimerApellido", docente.PrimerApellido);
                command.Parameters.AddWithValue("@SegundoApellido", docente.SegundoApellido);
                command.Parameters.AddWithValue("@Celular", docente.Celular);
                command.Parameters.AddWithValue("@Correo", docente.Correo);
                command.Parameters.AddWithValue("@TipoDocente", docente.TipoDocente);
                var filas = command.ExecuteNonQuery();
            }
        }
        public void Eliminar(Docente docente)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Delete from LiderProyecto where Identificacion=@Identificacion";
                command.Parameters.AddWithValue("@Identificacion", docente.Identificacion);
                command.ExecuteNonQuery();
            }
        }
        public List<Docente> ConsultarTodos()
        {
            SqlDataReader dataReader;
            List<Docente> docentes = new List<Docente>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select * from LiderProyecto ";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Docente docente = DataReaderMapToPerson(dataReader);
                        docentes.Add(docente);
                    }
                }
            }
            return docentes;
        }
        public Docente BuscarPorIdentificacion(string identificacion)
        {
            SqlDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from LiderProyecto where Identificacion=@Identificacion";
                command.Parameters.AddWithValue("@Identificacion", identificacion);
                dataReader = command.ExecuteReader();
                dataReader.Read();
                return DataReaderMapToPerson(dataReader);
            }
        }
        private Docente DataReaderMapToPerson(SqlDataReader dataReader)
        {
            if(!dataReader.HasRows) return null;
            Docente docente = new Docente();
            docente.Identificacion = (string)dataReader["Identificacion"];
            docente.PrimerNombre = (string)dataReader["PrimerNombre"];
            docente.SegundoNombre = (string)dataReader["SegundoNombre"];
            docente.PrimerApellido = (string)dataReader["PrimerApellido"];
            docente.SegundoApellido = (string)dataReader["SegundoApellido"];
            docente.Celular = (string)dataReader["Celular"];
            docente.Correo = (string)dataReader["Correo"];
            docente.TipoDocente = (string)dataReader["TipoDocente"];
            return docente;
        }
    }
}
