using System;
using System.ComponentModel.DataAnnotations;

namespace ASPNet_core.Models
{
    public class Evaluacion : ObjetoEscuelaBase
    {


        [Required]
        public override string Nombre {get; set;}
        [Required]
        public Double Nota { get; set; }

        //public Evaluacion()=> UniqueId = Guid.NewGuid().ToString();
        public string AlumnoId { get; set; }
        public string AsignaturaId { get; set; }

        public Alumno Alumno { get; set; }

        public Asignatura Asignatura { get; set; }

        public override string ToString()
        {
            return $" {Math.Round(Nota,2)}, {Alumno.Nombre}, {Asignatura.Nombre}";

        }


    }
}