using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace exposoftwaredotnet.Models
{
    public class ProyectoInputModel
    {
        public string Identificacion { get; set; }
        public string Estudiante1 { get; set; }
        public string Estudiante2 { get; set; }
        public string Asignatura { get; set; } 
        public string Nombre { get; set; }
        public string Semestre { get; set; }
        public string Resumen { get; set; } 
        public string Metodologia { get; set; }
        public string Resultados { get; set; }         
        
    }
     public class ProyectoViewModel : ProyectoInputModel
        {
            public ProyectoViewModel()
            {

            }
            public ProyectoViewModel(Proyecto proyecto)
            {
                Identificacion = proyecto.Identificacion;
                Estudiante1 = proyecto.Estudiante1;
                Estudiante2 = proyecto.Estudiante2;
                Asignatura = proyecto.Asignatura;
                Nombre = proyecto.Nombre;
                Semestre = proyecto.Semestre;
                Resumen = proyecto.Resumen;
                Metodologia = proyecto.Metodologia;
                Resultados = proyecto.Resultados;
                Estado = proyecto.Estado;
            }
            public string Estado { get; set; }
        }
}