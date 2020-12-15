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


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-0DD2K9Q\\SQLEXPRESS;Database=evaluaProfe;User Id=sa;Password=sa;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CalEtiqueta>(entity =>
            {
                entity.HasKey(e => e.IdCalEtiqueta)
                    .HasName("PK__calEtiqu__0A25B31E834B83DB");

                entity.ToTable("calEtiqueta");

                entity.Property(e => e.IdCalEtiqueta).HasColumnName("idCalEtiqueta");

                entity.Property(e => e.IdCalificacion).HasColumnName("idCalificacion");

                entity.Property(e => e.IdEtiqueta).HasColumnName("idEtiqueta");

                entity.HasOne(d => d.Calificacion)
                    .WithMany(p => p.CalEtiquetas)
                    .HasForeignKey(d => d.IdCalificacion)
                    .HasConstraintName("FK__calEtique__idCal__49C3F6B7");

                entity.HasOne(d => d.Etiqueta)
                    .WithMany(p => p.CalEtiquetas)
                    .HasForeignKey(d => d.IdEtiqueta)
                    .HasConstraintName("FK__calEtique__idEti__4AB81AF0");
            });

            modelBuilder.Entity<Calificacion>(entity =>
            {
                entity.HasKey(e => e.IdCalificacion)
                    .HasName("PK__califica__E056358FF16F7365");

                entity.ToTable("calificacion");

                entity.Property(e => e.IdCalificacion).HasColumnName("idCalificacion");

                entity.Property(e => e.Apoyo).HasColumnName("apoyo");

                entity.Property(e => e.Calificacion1).HasColumnName("calificacion1");

                entity.Property(e => e.Claridad).HasColumnName("claridad");

                entity.Property(e => e.Comentario)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("comentario");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Facilidad).HasColumnName("facilidad");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.IdProfesor).HasColumnName("idProfesor");

                entity.Property(e => e.Recomienda).HasColumnName("recomienda");

                entity.HasOne(d => d.Curso)
                    .WithMany(p => p.Calificaciones)
                    .HasForeignKey(d => d.IdCurso)
                    .HasConstraintName("FK__calificac__idCur__440B1D61");

                entity.HasOne(d => d.Profesor)
                    .WithMany(p => p.Calificaciones)
                    .HasForeignKey(d => d.IdProfesor)
                    .HasConstraintName("FK__calificac__idPro__44FF419A");
            });

            modelBuilder.Entity<Carrera>(entity =>
            {
                entity.HasKey(e => e.IdCarrera)
                    .HasName("PK__carrera__7B19E79120DB02DD");

                entity.ToTable("carrera");

                entity.Property(e => e.IdCarrera).HasColumnName("idCarrera");

                entity.Property(e => e.NombreCarrera)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nombreCarrera");
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.IdCurso)
                    .HasName("PK__curso__8551ED0520F21447");

                entity.ToTable("curso");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.NombreCurso)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nombreCurso");
            });

            modelBuilder.Entity<CursoCarrera>(entity =>
            {
                entity.HasKey(e => e.IdCursoCarrera)
                    .HasName("PK__cursoCar__405B0B548EC49C56");

                entity.ToTable("cursoCarrera");

                entity.Property(e => e.IdCursoCarrera).HasColumnName("idCursoCarrera");

                entity.Property(e => e.IdCarrera).HasColumnName("idCarrera");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.HasOne(d => d.Carrera)
                    .WithMany(p => p.CursoCarreras)
                    .HasForeignKey(d => d.IdCarrera)
                    .HasConstraintName("FK__cursoCarr__idCar__46E78A0C");

                entity.HasOne(d => d.Curso)
                    .WithMany(p => p.CursoCarreras)
                    .HasForeignKey(d => d.IdCurso)
                    .HasConstraintName("FK__cursoCarr__idCur__45F365D3");
            });

            modelBuilder.Entity<Etiqueta>(entity =>
            {
                entity.HasKey(e => e.IdEtiqueta)
                    .HasName("PK__etiqueta__3C1526A76C760765");

                entity.ToTable("etiqueta");

                entity.Property(e => e.IdEtiqueta).HasColumnName("idEtiqueta");

                entity.Property(e => e.NombreEtiqueta)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombreEtiqueta");
            });

            modelBuilder.Entity<ProfCurso>(entity =>
            {
                entity.HasKey(e => e.IdProfCurso)
                    .HasName("PK__profCurs__071E340A434CEAED");

                entity.ToTable("profCurso");

                entity.Property(e => e.IdProfCurso).HasColumnName("idProfCurso");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.IdProfesor).HasColumnName("idProfesor");

                entity.HasOne(d => d.Curso)
                    .WithMany(p => p.ProfCursos)
                    .HasForeignKey(d => d.IdCurso)
                    .HasConstraintName("FK__profCurso__idCur__48CFD27E");

                entity.HasOne(d => d.Profesor)
                    .WithMany(p => p.ProfCursos)
                    .HasForeignKey(d => d.IdProfesor)
                    .HasConstraintName("FK__profCurso__idPro__47DBAE45");
            });

            modelBuilder.Entity<Profesor>(entity =>
            {
                entity.HasKey(e => e.IdProfesor)
                    .HasName("PK__profesor__E4BBA604B3FC475B");

                entity.ToTable("profesor");

                entity.Property(e => e.IdProfesor).HasColumnName("idProfesor");

                entity.Property(e => e.Apellido1)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("apellido1");

                entity.Property(e => e.Apellido2)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("apellido2");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

        }
    }
}
