using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UI.Models;

namespace UI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<UI.Models.Profesor> Profesor { get; set; }
        public DbSet<UI.Models.ProfCurso> ProfCurso { get; set; }
        public DbSet<UI.Models.Etiqueta> Etiqueta { get; set; }
        public DbSet<UI.Models.CursoCarrera> CursoCarrera { get; set; }
        public DbSet<UI.Models.Curso> Curso { get; set; }
        public DbSet<UI.Models.Carrera> Carrera { get; set; }
        public DbSet<UI.Models.Calificacion> Calificacion { get; set; }
        public DbSet<UI.Models.CalEtiqueta> CalEtiqueta { get; set; }
    }
}
