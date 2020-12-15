using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace API.W.Models
{
    public partial class evaluaProfeContext : DbContext
    {
        public evaluaProfeContext()
        {
        }

        public evaluaProfeContext(DbContextOptions<evaluaProfeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Calificacion> Calificacions { get; set; }
        public virtual DbSet<Carrera> Carreras { get; set; }
        public virtual DbSet<Curso> Cursos { get; set; }
        public virtual DbSet<Etiquetum> Etiqueta { get; set; }
        public virtual DbSet<Profesor> Profesors { get; set; }

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
            modelBuilder.Entity<Calificacion>(entity =>
            {
                entity.HasKey(e => e.IdCalificacion)
                    .HasName("PK__califica__E056358F7FF73068");

                entity.ToTable("calificacion");

                entity.Property(e => e.IdCalificacion).HasColumnName("idCalificacion");

                entity.Property(e => e.Apoyo).HasColumnName("apoyo");

                entity.Property(e => e.Claridad).HasColumnName("claridad");

                entity.Property(e => e.Comentario)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("comentario");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Facilidad).HasColumnName("facilidad");

                entity.Property(e => e.IdCarrera).HasColumnName("idCarrera");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.IdEtiqueta).HasColumnName("idEtiqueta");

                entity.Property(e => e.IdProfesor).HasColumnName("idProfesor");

                entity.Property(e => e.Puntaje).HasColumnName("puntaje");

                entity.Property(e => e.Recomienda).HasColumnName("recomienda");

                entity.HasOne(d => d.IdCarreraNavigation)
                    .WithMany(p => p.Calificacions)
                    .HasForeignKey(d => d.IdCarrera)
                    .HasConstraintName("FK__calificac__idCar__403A8C7D");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Calificacions)
                    .HasForeignKey(d => d.IdCurso)
                    .HasConstraintName("FK__calificac__idCur__3E52440B");

                entity.HasOne(d => d.IdEtiquetaNavigation)
                    .WithMany(p => p.Calificacions)
                    .HasForeignKey(d => d.IdEtiqueta)
                    .HasConstraintName("FK__calificac__idEti__412EB0B6");

                entity.HasOne(d => d.IdProfesorNavigation)
                    .WithMany(p => p.Calificacions)
                    .HasForeignKey(d => d.IdProfesor)
                    .HasConstraintName("FK__calificac__idPro__3F466844");
            });

            modelBuilder.Entity<Carrera>(entity =>
            {
                entity.HasKey(e => e.IdCarrera)
                    .HasName("PK__carrera__7B19E7917801CE24");

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
                    .HasName("PK__curso__8551ED055FF1D06C");

                entity.ToTable("curso");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.IdCarrera).HasColumnName("idCarrera");

                entity.Property(e => e.NombreCurso)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nombreCurso");

                entity.HasOne(d => d.IdCarreraNavigation)
                    .WithMany(p => p.Cursos)
                    .HasForeignKey(d => d.IdCarrera)
                    .HasConstraintName("FK__curso__idCarrera__4222D4EF");
            });

            modelBuilder.Entity<Etiquetum>(entity =>
            {
                entity.HasKey(e => e.IdEtiqueta)
                    .HasName("PK__etiqueta__3C1526A76CEE0BAD");

                entity.ToTable("etiqueta");

                entity.Property(e => e.IdEtiqueta).HasColumnName("idEtiqueta");

                entity.Property(e => e.NombreEtiqueta)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombreEtiqueta");
            });

            modelBuilder.Entity<Profesor>(entity =>
            {
                entity.HasKey(e => e.IdProfesor)
                    .HasName("PK__profesor__E4BBA60472936245");

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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
