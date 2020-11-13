using EP.DO.Objects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EP.DAL.EF
{
    public class SolutionDBContext:DbContext 
    {
        public SolutionDBContext(DbContextOptions<SolutionDBContext> options) 
            :base(options) 
        {

        }

        public DbSet<Universidad> Universidad { get; set; }

        public DbSet<ProfUniversidad> ProfUniversidades { get; set; }

        public DbSet<Profesor> Profesors { get; set; }

        public DbSet<ProfCurso> ProfCursos { get; set; }

        public DbSet<Etiqueta> Etiquetas { get; set; }

        public DbSet<CursoCarrera> CursoCarreras { get; set; }

        public DbSet<Curso> Cursos { get; set; }

        public DbSet<Carrera> Carreras { get; set; }

        public DbSet<Calificacion> Calificacions { get; set; }

        public DbSet<CalEtiqueta> CalEtiquetas { get; set; } 

    }
}
