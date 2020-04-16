using System;
using Entity;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Datos
{
    public class ProyectoRepository
    {
          private readonly SqlConnection _connection;
        private readonly List<Proyecto> _proyectos = new List<Proyecto>();
        public ProyectoRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }
        public void Guardar(Proyecto proyecto)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"Insert Into Proyecto (Identificacion,Estudiante1,Estudiante2,Asignatura,Nombre,Semestre,Resumen,"+
                                                    "Metodologia,Resultados)"+
                                        "values (@Identificacion,@Estudiante1,@Estudiante2,@Asignatura,@Nombre,@Semestre,@Resumen,"+
                                        "@Metodologia,@Resultados)";
                command.Parameters.AddWithValue("@Identificacion", proyecto.Identificacion);
                command.Parameters.AddWithValue("@Estudiante1", proyecto.Estudiante1);
                command.Parameters.AddWithValue("@Estudiante2", proyecto.Estudiante2);
                command.Parameters.AddWithValue("@Asignatura", proyecto.Asignatura);
                command.Parameters.AddWithValue("@Nombre", proyecto.Nombre);
                command.Parameters.AddWithValue("@Semestre", proyecto.Semestre);
                command.Parameters.AddWithValue("@Resumen", proyecto.Resumen);
                command.Parameters.AddWithValue("@Metodologia", proyecto.Metodologia);
                command.Parameters.AddWithValue("@Resultados", proyecto.Resultados);
                command.Parameters.AddWithValue("@Estado", "Pendiente");
                var filas = command.ExecuteNonQuery();
            }
        }

         public void Eliminar(Proyecto proyecto)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Delete from Proyecto where Identificacion=@Identificacion";
                command.Parameters.AddWithValue("@Identificacion", proyecto.Identificacion);
                command.ExecuteNonQuery();
            }
        }
        public List<Proyecto> ConsultarTodos()
        {
            SqlDataReader dataReader;
            List<Proyecto> proyectos = new List<Proyecto>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select * from Proyecto ";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Proyecto proyecto = DataReaderMapToPerson(dataReader);
                        proyectos.Add(proyecto);
                    }
                }
            }
            return proyectos;
        }
        public Proyecto BuscarPorIdentificacion(string identificacion)
        {
            SqlDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from Proyecto where Identificacion=@Identificacion";
                command.Parameters.AddWithValue("@Identificacion", identificacion);
                dataReader = command.ExecuteReader();
                dataReader.Read();
                return DataReaderMapToPerson(dataReader);
            }
        }
        private Proyecto DataReaderMapToPerson(SqlDataReader dataReader)
        {
            if(!dataReader.HasRows) return null;
            Proyecto proyecto = new Proyecto();
            proyecto.Identificacion = (string)dataReader["Identificacion"];
            proyecto.Estudiante1 = (string)dataReader["Estudiante1"];
            proyecto.Estudiante2 = (string)dataReader["Estudiante2"];
            proyecto.Asignatura = (string)dataReader["Asignatura"];
            proyecto.Nombre = (string)dataReader["Nombre"];
            proyecto.Semestre = (string)dataReader["Semestre"];
            proyecto.Resumen = (string)dataReader["Resumen"];
            proyecto.Metodologia = (string)dataReader["Metodologia"];
            proyecto.Resultados = (string)dataReader["Resultados"];
            proyecto.Estado = (string)dataReader["Estado"];
            return proyecto;
        }


    }
}