using System;
using System.Collections.Generic;

namespace ASPNet_core.Models
{
    public class EntEscuela:ObjetoEscuelaBase
    {/*
        string nombre;
        public string Nombre
        {
            get { return "Copia:" + nombre; }
            set { nombre = value.ToUpper(); }
        }*/
        public int AnioDeCreacion { get; set; }

        public string Pais { get; set; }

        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public TiposEscuela TipoEscuela { get; set; }
        //public Curso[] Cursos { get; set; }
        public List<Curso> Cursos { get; set; }

        public EntEscuela(string nombre, int anio) => (Nombre, AnioDeCreacion) = (nombre, anio);

        public EntEscuela(string nombre, int año, 
                       TiposEscuela tipo, 
                       string pais = "", string ciudad = "")
        {
            (Nombre, AnioDeCreacion) = (nombre, año);
            Pais = pais;
            Ciudad = ciudad;
        }

        public EntEscuela()
        {
           
        }



       


        public override string ToString()
        {
            return $"Nombre: \"{Nombre}\", Tipo: {TipoEscuela} {System.Environment.NewLine} Pais: {Pais}, Ciudad:{Ciudad}";
        }
    }
}