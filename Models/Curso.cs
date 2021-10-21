using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASPNet_core.Models
{
    public class Curso : ObjetoEscuelaBase
    {
        [Required]
        public override string Nombre {get; set;}
        public TiposJornada Jornada { get; set; }

        public List<Asignatura> Asignaturas { get; set; }

        public List<Alumno> Alumnos { get; set; }
        public string Direccion { get; set; }

        public string EscuelaId{get;set;}

        public EntEscuela Escuela { get; set; }

    }
}