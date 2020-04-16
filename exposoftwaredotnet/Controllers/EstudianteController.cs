  
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
    public class EstudianteController: ControllerBase
    {
     private readonly EstudianteService _estudianteService;
        public IConfiguration Configuration { get; }
        public EstudianteController(IConfiguration configuration)
        {
            Configuration = configuration;
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            _estudianteService = new EstudianteService(connectionString);
        }
        // GET: api/Estudiante
        [HttpGet]
        public IEnumerable<EstudianteViewModel> Gets()
        {
            var estudiantes = _estudianteService.ConsultarTodos().Select(e=> new EstudianteViewModel(e));
            return estudiantes;
        }

        // GET: api/Estudiante/5
        [HttpGet("{identificacion}")]
        public ActionResult<EstudianteViewModel> Get(string identificacion)
        {
            var estudiante = _estudianteService.BuscarxIdentificacion(identificacion);
            if (estudiante == null) return NotFound();
            var estudianteViewModel = new EstudianteViewModel(estudiante);
            return estudianteViewModel;
        }
        // POST: api/Estudiante
        [HttpPost]
        public ActionResult<EstudianteViewModel> Post(EstudianteInputModel estudianteInput)
        {
            Estudiante estudiante = MapearEstudiante(estudianteInput);
            var response = _estudianteService.Guardar(estudiante);
            if (response.Error) 
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Estudiante);
        }
        // DELETE: api/Estudiante/5
        [HttpDelete("{identificacion}")]
        public ActionResult<string> Delete(string identificacion)
        {
            string mensaje = _estudianteService.Eliminar(identificacion);
            return Ok(mensaje);
        }
        private Estudiante MapearEstudiante(EstudianteInputModel estudianteInput)
        {
            var estudiante = new Estudiante
            {
                Identificacion = estudianteInput.Identificacion,
                PrimerNombre = estudianteInput.PrimerNombre,
                SegundoNombre = estudianteInput.SegundoNombre,
                PrimerApellido = estudianteInput.PrimerApellido,
                SegundoApellido = estudianteInput.SegundoApellido,
                Celular = estudianteInput.Celular,
                Correo = estudianteInput.Correo,
            };
            return estudiante;
        }
        // PUT: api/Estudiante/5
        [HttpPut("{identificacion}")]
        public ActionResult<string> Put(string identificacion, Estudiante estudiante)
        {
            throw new NotImplementedException();
        }   
    }
}