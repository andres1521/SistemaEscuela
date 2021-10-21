using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ASPNet_core.Models
{
    public class EscuelaContext : DbContext
    {
        public DbSet<EntEscuela> Escuelas { set; get; }
        public DbSet<Evaluacion> Evaluaciones { set; get; }
        public DbSet<Curso> Cursos { set; get; }
        public DbSet<Alumno> Alumnos { set; get; }
        public DbSet<Asignatura> Asignaturas { set; get; }
        public EscuelaContext(DbContextOptions<EscuelaContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var escuela = new EntEscuela();
            escuela.Nombre = ".NET";
            //escuela.UniqueId=Guid.NewGuid().ToString();
            escuela.AnioDeCreacion = 2020;
            escuela.Ciudad = "Cali";
            escuela.Pais = "Colombia";
            escuela.Direccion = "calle";
            escuela.TipoEscuela = TiposEscuela.Secundaria;

            

            //cargar cursos de la Escuela
            var cursos = CargarCursos(escuela);


            //x cada curso asignaturas
            var listAsignaturas=CargarAsignaturas(cursos);

            //xcada curso alumnos 
            var listaAlumnos=CargarAlumnos(cursos);
            //cargarEvaluaciones
            var listaEvaluaciones=CargarEvaluaciones(listaAlumnos,listAsignaturas);

            modelBuilder.Entity<EntEscuela>().HasData(escuela);
            modelBuilder.Entity<Curso>().HasData(cursos.ToArray());
            modelBuilder.Entity<Asignatura>().HasData(listAsignaturas.ToArray());
            modelBuilder.Entity<Alumno>().HasData(listaAlumnos.ToArray());
            modelBuilder.Entity<Evaluacion>().HasData(listaEvaluaciones.ToArray());

        }
        private List<Curso> CargarCursos(EntEscuela escuela)
        {
                        var curso = new List<Curso>(){
                        new Curso(){Nombre = "101", EscuelaId=escuela.UniqueId,Jornada = TiposJornada.Mañana },
                        new Curso(){Nombre = "201",EscuelaId=escuela.UniqueId, Jornada = TiposJornada.Mañana},
                        new Curso(){Nombre = "301",EscuelaId=escuela.UniqueId, Jornada = TiposJornada.Mañana},
                        new Curso(){Nombre = "401",EscuelaId=escuela.UniqueId, Jornada = TiposJornada.Tarde },
                        new Curso(){Nombre = "501",EscuelaId=escuela.UniqueId, Jornada = TiposJornada.Tarde}
                        };

                        return curso;
        }
        private List<Asignatura> CargarAsignaturas(List<Curso> cursos)
        {
            var listaAsignaturas =new List<Asignatura>();
          foreach (var curso in cursos)
          {
               var tmpListaAsignatura=new List<Asignatura>(){
                            new Asignatura{Nombre="Matemáticas",CursoId=curso.UniqueId} ,
                            new Asignatura{Nombre="Educación Física",CursoId=curso.UniqueId},
                            new Asignatura{Nombre="Castellano",CursoId=curso.UniqueId},
                            new Asignatura{Nombre="Ciencias Naturales",CursoId=curso.UniqueId}
              };

              listaAsignaturas.AddRange(tmpListaAsignatura);
              //curso.Asignaturas=tmpListaAsignatura;


              
                
          }
          return listaAsignaturas;
        }

        private List<Alumno> CargarAlumnos(List<Curso> cursos)
        {
            var listaAlumnos = new List<Alumno>();

            Random rnd = new Random();
            foreach (var curso in cursos)
            {
                int cantRandom = rnd.Next(5, 20);
                var tmplist = GenerarAlumnosAlAzar( cantRandom,curso);
                listaAlumnos.AddRange(tmplist);
            }
            return listaAlumnos;
        } 


        

     

        private IEnumerable<Alumno> GenerarAlumnosAlAzar( int cantidad, Curso curso)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from ap1 in apellido1
                               select new Alumno { Nombre = $"{n1} {n2} {ap1}" ,CursoId=curso.UniqueId};

            return listaAlumnos.OrderBy((al) => al.UniqueId).Take(cantidad).ToList();
        }


        private List<Evaluacion> CargarEvaluaciones(List<Alumno> alumnos,List<Asignatura> asignaturas)
        {

            string[] NombreEvaluaciones = { "Examen_1", "Examen_2", "Examen_3", "Examen_4", "Examen_5" };
            Random rnd = new Random();
            var listaEvaluaciones = new List<Evaluacion>();
            foreach (var asignatura in asignaturas)
            {
                foreach (var alumno in alumnos)
                {
                    foreach (var nomb_Evaluacion in NombreEvaluaciones)
                        {
                            var eval = new Evaluacion
                            {
                                Nombre = $"{asignatura.Nombre} Ev#{nomb_Evaluacion}",
                                AsignaturaId = asignatura.UniqueId,
                                AlumnoId = alumno.UniqueId,
                                Nota = rnd.NextDouble() * 5
                            };
                            listaEvaluaciones.Add(eval);
                        }
                }              
            }
            return listaEvaluaciones;
        }




    }
}