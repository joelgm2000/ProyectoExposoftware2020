using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Logica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using exposoftwaredotnet.Models;

namespace exposoftwaredotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectoController: ControllerBase
    {
        private readonly ProyectoService _proyectoService;
        public IConfiguration Configuration { get; }
        public ProyectoController(IConfiguration configuration)
        {
            Configuration = configuration;
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            _proyectoService = new ProyectoService(connectionString);
        }
        // GET: api/Proyecto
        [HttpGet]
        public IEnumerable<ProyectoViewModel> Gets()
        {
            var proyectos = _proyectoService.ConsultarTodos().Select(p=> new ProyectoViewModel(p));
            return proyectos;
        }

        // GET: api/Proyecto/5
        [HttpGet("{identificacion}")]
        public ActionResult<ProyectoViewModel> Get(string identificacion)
        {
            var proyecto = _proyectoService.BuscarxIdentificacion(identificacion);
            if (proyecto == null) return NotFound();
            var proyectoViewModel = new ProyectoViewModel(proyecto);
            return proyectoViewModel;
        }
        // POST: api/Proyecto
        [HttpPost]
        public ActionResult<ProyectoViewModel> Post(ProyectoInputModel proyectoInput)
        {
            Proyecto proyecto = MapearProyecto(proyectoInput);
            var response = _proyectoService.Guardar(proyecto);
            if (response.Error) 
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Proyecto);
        }
        // DELETE: api/Proyecto/5
        [HttpDelete("{identificacion}")]
        public ActionResult<string> Delete(string identificacion)
        {
            string mensaje = _proyectoService.Eliminar(identificacion);
            return Ok(mensaje);
        }
        private Proyecto MapearProyecto(ProyectoInputModel proyectoInput)
        {
            var proyecto = new Proyecto
            {
                Identificacion = proyectoInput.Identificacion,
                Estudiante1 = proyectoInput.Estudiante1,
                Estudiante2 = proyectoInput.Estudiante2,
                Asignatura = proyectoInput.Asignatura,
                Nombre = proyectoInput.Nombre,
                Semestre = proyectoInput.Semestre,
                Resumen = proyectoInput.Resumen,
                Metodologia = proyectoInput.Metodologia,
                Resultados = proyectoInput.Resultados,
            };
            return proyecto;
        }
        // PUT: api/Proyecto/5
        [HttpPut("{identificacion}")]
        public ActionResult<string> Put(string identificacion, Proyecto proyecto)
        {
            throw new NotImplementedException();
        }
        
    }
}