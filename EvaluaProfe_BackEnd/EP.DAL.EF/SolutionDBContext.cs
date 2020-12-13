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

        public DbSet<Profesor> Profesor { get; set; }

        public DbSet<ProfCurso> ProfCurso { get; set; }

        public DbSet<Etiqueta> Etiqueta { get; set; }

        public DbSet<CursoCarrera> CursoCarrera { get; set; }

        public DbSet<Curso> Curso { get; set; }

        public DbSet<Carrera> Carrera { get; set; }

        public DbSet<Calificacion> Calificacion { get; set; }

        public DbSet<CalEtiqueta> CalEtiqueta { get; set; } 

    }
}
