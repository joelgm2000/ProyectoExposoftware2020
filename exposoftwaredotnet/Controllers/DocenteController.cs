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
    public class DocenteController: ControllerBase
    {
          private readonly DocenteService _docenteService;
        public IConfiguration Configuration { get; }
        public DocenteController(IConfiguration configuration)
        {
            Configuration = configuration;
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            _docenteService = new DocenteService(connectionString);
        }
        // GET: api/Docente
        [HttpGet]
        public IEnumerable<DocenteViewModel> Gets()
        {
            var docentes = _docenteService.ConsultarTodos().Select(d=> new DocenteViewModel(d));
            return docentes;
        }

        // GET: api/Docente/5
        [HttpGet("{identificacion}")]
        public ActionResult<DocenteViewModel> Get(string identificacion)
        {
            var docente = _docenteService.BuscarxIdentificacion(identificacion);
            if (docente == null) return NotFound();
            var docenteViewModel = new DocenteViewModel(docente);
            return docenteViewModel;
        }
        // POST: api/Docente
        [HttpPost]
        public ActionResult<DocenteViewModel> Post(DocenteInputModel docenteInput)
        {
            Docente docente = MapearDocente(docenteInput);
            var response = _docenteService.Guardar(docente);
            if (response.Error) 
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Docente);
        }
        // DELETE: api/Docente/5
        [HttpDelete("{identificacion}")]
        public ActionResult<string> Delete(string identificacion)
        {
            string mensaje = _docenteService.Eliminar(identificacion);
            return Ok(mensaje);
        }
        private Docente MapearDocente(DocenteInputModel docenteInput)
        {
            var docente = new Docente
            {
                 Identificacion = docenteInput.Identificacion,
                PrimerNombre = docenteInput.PrimerNombre,
                SegundoNombre = docenteInput.SegundoNombre,
                PrimerApellido = docenteInput.PrimerApellido,
                SegundoApellido = docenteInput.SegundoApellido,
                Celular = docenteInput.Celular,
                Correo = docenteInput.Correo,
                TipoDocente = docenteInput.TipoDocente
            };
            return docente;
        }
        // PUT: api/Docente/5
        [HttpPut("{identificacion}")]
        public ActionResult<string> Put(string identificacion, Docente docente)
        {
            throw new NotImplementedException();
        }
    }
}