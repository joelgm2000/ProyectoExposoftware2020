using System;
using Datos;
using Entity;
using System.Collections.Generic;


namespace Logica
{
    public class DocenteService
    {
        private readonly ConnectionManager _conexion;
        private readonly DocenteRepository _repositorio;

        public DocenteService(string connectionString)
        {
            _conexion = new ConnectionManager(connectionString);
            _repositorio = new DocenteRepository(_conexion);
        }
        
        public GuardarDocenteResponse Guardar(Docente docente)
        {
            try
            {
                _conexion.Open();
                _repositorio.Guardar(docente);
                _conexion.Close();
                return new GuardarDocenteResponse(docente);
            }
            catch (Exception e)
            {
                return new GuardarDocenteResponse($"Error de la Aplicacion: {e.Message}");
            }
            finally { _conexion.Close(); }
        }
        public List<Docente> ConsultarTodos()
        {
            _conexion.Open();
            List<Docente> docentes = _repositorio.ConsultarTodos();
            _conexion.Close();
            return docentes;
        }
        public string Eliminar(string identificacion)
        {
            try
            {
                _conexion.Open();
                var docente = _repositorio.BuscarPorIdentificacion(identificacion);
                if (docente != null)
                {
                    _repositorio.Eliminar(docente);
                    _conexion.Close();
                    return ($"El registro {docente.PrimerNombre} se ha eliminado satisfactoriamente.");
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
        public Docente BuscarxIdentificacion(string identificacion)
        {
            _conexion.Open();
            Docente docente = _repositorio.BuscarPorIdentificacion(identificacion);
            _conexion.Close();
            return docente;
        }

    }
     public class GuardarDocenteResponse 
    {
        public GuardarDocenteResponse(Docente docente)
        {
            Error = false;
            Docente = docente;
        }
        public GuardarDocenteResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Docente Docente { get; set; }

    }
    
}
