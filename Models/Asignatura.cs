using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASPNet_core.Models
{
    public class Asignatura:ObjetoEscuelaBase
    {
        [Required]
        public override string Nombre {get; set;}
        public string CursoId { get; set; }

        public Curso curso { get; set; }

        public List<Evaluacion> Evaluaciones {get;set;}
        
        
    }
}