using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace exposoftwaredotnet.Models
{
    public class DocenteInputModel
    {
        public string Identificacion { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Celular { get; set; } 
        public string Correo { get; set; }
        public string TipoDocente { get; set; }  
    }
      public class DocenteViewModel : DocenteInputModel
        {
            public DocenteViewModel()
            {

            }
            public DocenteViewModel(Docente docente)
            {
                Identificacion = docente.Identificacion;
                PrimerNombre = docente.PrimerNombre;
                SegundoNombre = docente.SegundoNombre;
                PrimerApellido = docente.PrimerApellido;
                SegundoApellido = docente.SegundoApellido;
                Celular = docente.Celular;
                Correo = docente.Correo;
                TipoDocente = docente.TipoDocente;
            }

        }
}