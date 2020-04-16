using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace exposoftwaredotnet.Models
{
    public class EstudianteInputModel
    {
        public string Identificacion { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Celular { get; set; } 
        public string Correo { get; set; }
        
    }
     public class EstudianteViewModel : EstudianteInputModel
        {
            public EstudianteViewModel()
            {

            }
            public EstudianteViewModel(Estudiante estudiante)
            {
                Identificacion = estudiante.Identificacion;
                PrimerNombre = estudiante.PrimerNombre;
                SegundoNombre = estudiante.SegundoNombre;
                PrimerApellido = estudiante.PrimerApellido;
                SegundoApellido = estudiante.SegundoApellido;
                Celular = estudiante.Celular;
                Correo = estudiante.Correo;
            }

        }
}