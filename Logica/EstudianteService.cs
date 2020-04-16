using System;
using Datos;
using Entity;
using System.Collections.Generic;

namespace Logica
{
    public class EstudianteService
    {
         private readonly ConnectionManager _conexion;
        private readonly EstudianteRepository _repositorio;

        public EstudianteService(string connectionString)
        {
            _conexion = new ConnectionManager(connectionString);
            _repositorio = new EstudianteRepository(_conexion);
        }
        
        public GuardarEstudianteResponse Guardar(Estudiante estudiante)
        {
            try
            {
                _conexion.Open();
                _repositorio.Guardar(estudiante);
                _conexion.Close();
                return new GuardarEstudianteResponse(estudiante);
            }
            catch (Exception e)
            {
                return new GuardarEstudianteResponse($"Error de la Aplicacion: {e.Message}");
            }
            finally { _conexion.Close(); }
        }

        public List<Estudiante> ConsultarTodos()
        {
            _conexion.Open();
            List<Estudiante> estudiantes = _repositorio.ConsultarTodos();
            _conexion.Close();
            return estudiantes;
        }

        public string Eliminar(string identificacion)
        {
            try
            {
                _conexion.Open();
                var estudiante = _repositorio.BuscarPorIdentificacion(identificacion);
                if (estudiante != null)
                {
                    _repositorio.Eliminar(estudiante);
                    _conexion.Close();
                    return ($"El registro {estudiante.PrimerNombre} se ha eliminado satisfactoriamente.");
                }
                else
                {
                    return ($"Lo sentimos, {identificacion} no se encuentra registrada.");
                }
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }
            finally { _conexion.Close(); }

        }
        public Estudiante BuscarxIdentificacion(string identificacion)
        {
            _conexion.Open();
            Estudiante estudiante = _repositorio.BuscarPorIdentificacion(identificacion);
            _conexion.Close();
            return estudiante;
        }
        
    }

     public class GuardarEstudianteResponse 
    {
        public GuardarEstudianteResponse(Estudiante estudiante)
        {
            Error = false;
            Estudiante = estudiante;
        }
        public GuardarEstudianteResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Estudiante Estudiante { get; set; }

    }
        
    
}