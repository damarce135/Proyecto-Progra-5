using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UI.Models
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

        public virtual DbSet<Administrador> Administrador { get; set; }
        public virtual DbSet<CalEtiqueta> CalEtiqueta { get; set; }
        public virtual DbSet<Calificacion> Calificacion { get; set; }
        public virtual DbSet<Carrera> Carrera { get; set; }
        public virtual DbSet<Curso> Curso { get; set; }
        public virtual DbSet<CursoCarrera> CursoCarrera { get; set; }
        public virtual DbSet<Etiqueta> Etiqueta { get; set; }
        public virtual DbSet<ProfCurso> ProfCurso { get; set; }
        public virtual DbSet<ProfUniversidad> ProfUniversidad { get; set; }
        public virtual DbSet<Profesor> Profesor { get; set; }
        public virtual DbSet<Universidad> Universidad { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-0DD2K9Q\\SQLEXPRESS;Database=evaluaProfe;User Id=sa;Password=sa;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrador>(entity =>
            {
                entity.HasKey(e => e.IdAdministrador)
                    .HasName("PK__administ__EBE80EA17D213B28");

                entity.ToTable("administrador");

                entity.Property(e => e.IdAdministrador)
                    .HasColumnName("idAdministrador")
                    .ValueGeneratedNever();

                entity.Property(e => e.Apellido1)
                    .HasColumnName("apellido1")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Apellido2)
                    .HasColumnName("apellido2")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Contrasena)
                    .HasColumnName("contrasena")
                    .HasMaxLength(1);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Habilitado).HasColumnName("habilitado");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasColumnName("telefono")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CalEtiqueta>(entity =>
            {
                entity.HasKey(e => e.IdCalEtiqueta)
                    .HasName("PK__calEtiqu__0A25B31E47F40C52");

                entity.ToTable("calEtiqueta");

                entity.Property(e => e.IdCalEtiqueta)
                    .HasColumnName("idCalEtiqueta")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdCalificacion).HasColumnName("idCalificacion");

                entity.Property(e => e.IdEtiqueta).HasColumnName("idEtiqueta");

                entity.HasOne(d => d.IdCalificacionNavigation)
                    .WithMany(p => p.CalEtiqueta)
                    .HasForeignKey(d => d.IdCalificacion)
                    .HasConstraintName("FK__calEtique__idCal__52593CB8");

                entity.HasOne(d => d.IdEtiquetaNavigation)
                    .WithMany(p => p.CalEtiqueta)
                    .HasForeignKey(d => d.IdEtiqueta)
                    .HasConstraintName("FK__calEtique__idEti__534D60F1");
            });

            modelBuilder.Entity<Calificacion>(entity =>
            {
                entity.HasKey(e => e.IdCalificacion)
                    .HasName("PK__califica__E056358F6AC31138");

                entity.ToTable("calificacion");

                entity.Property(e => e.IdCalificacion)
                    .HasColumnName("idCalificacion")
                    .ValueGeneratedNever();

                entity.Property(e => e.Apoyo).HasColumnName("apoyo");

                entity.Property(e => e.Calificacion1).HasColumnName("calificacion");

                entity.Property(e => e.Claridad).HasColumnName("claridad");

                entity.Property(e => e.Comentario)
                    .HasColumnName("comentario")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Facilidad).HasColumnName("facilidad");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.IdProfesor).HasColumnName("idProfesor");

                entity.Property(e => e.Recomienda).HasColumnName("recomienda");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Calificacion)
                    .HasForeignKey(d => d.IdCurso)
                    .HasConstraintName("FK__calificac__idCur__4AB81AF0");

                entity.HasOne(d => d.IdProfesorNavigation)
                    .WithMany(p => p.Calificacion)
                    .HasForeignKey(d => d.IdProfesor)
                    .HasConstraintName("FK__calificac__idPro__4BAC3F29");
            });

            modelBuilder.Entity<Carrera>(entity =>
            {
                entity.HasKey(e => e.IdCarrera)
                    .HasName("PK__carrera__7B19E791AA8840C6");

                entity.ToTable("carrera");

                entity.Property(e => e.IdCarrera)
                    .HasColumnName("idCarrera")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdUniversidad).HasColumnName("idUniversidad");

                entity.Property(e => e.NombreCarrera)
                    .HasColumnName("nombreCarrera")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUniversidadNavigation)
                    .WithMany(p => p.Carrera)
                    .HasForeignKey(d => d.IdUniversidad)
                    .HasConstraintName("FK__carrera__idUnive__49C3F6B7");
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.IdCurso)
                    .HasName("PK__curso__8551ED050202B835");

                entity.ToTable("curso");

                entity.Property(e => e.IdCurso)
                    .HasColumnName("idCurso")
                    .ValueGeneratedNever();

                entity.Property(e => e.NombreCurso)
                    .HasColumnName("nombreCurso")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CursoCarrera>(entity =>
            {
                entity.HasKey(e => e.IdCursoCarrera)
                    .HasName("PK__cursoCar__405B0B5404809940");

                entity.ToTable("cursoCarrera");

                entity.Property(e => e.IdCursoCarrera)
                    .HasColumnName("idCursoCarrera")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdCarrera).HasColumnName("idCarrera");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.HasOne(d => d.IdCarreraNavigation)
                    .WithMany(p => p.CursoCarrera)
                    .HasForeignKey(d => d.IdCarrera)
                    .HasConstraintName("FK__cursoCarr__idCar__4D94879B");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.CursoCarrera)
                    .HasForeignKey(d => d.IdCurso)
                    .HasConstraintName("FK__cursoCarr__idCur__4CA06362");
            });

            modelBuilder.Entity<Etiqueta>(entity =>
            {
                entity.HasKey(e => e.IdEtiqueta)
                    .HasName("PK__etiqueta__3C1526A74FEE5A7B");

                entity.ToTable("etiqueta");

                entity.Property(e => e.IdEtiqueta)
                    .HasColumnName("idEtiqueta")
                    .ValueGeneratedNever();

                entity.Property(e => e.NombreEtiqueta)
                    .HasColumnName("nombreEtiqueta")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProfCurso>(entity =>
            {
                entity.HasKey(e => e.IdProfCurso)
                    .HasName("PK__profCurs__071E340A2421347E");

                entity.ToTable("profCurso");

                entity.Property(e => e.IdProfCurso)
                    .HasColumnName("idProfCurso")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.IdProfesor).HasColumnName("idProfesor");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.ProfCurso)
                    .HasForeignKey(d => d.IdCurso)
                    .HasConstraintName("FK__profCurso__idCur__5165187F");

                entity.HasOne(d => d.IdProfesorNavigation)
                    .WithMany(p => p.ProfCurso)
                    .HasForeignKey(d => d.IdProfesor)
                    .HasConstraintName("FK__profCurso__idPro__5070F446");
            });

            modelBuilder.Entity<ProfUniversidad>(entity =>
            {
                entity.HasKey(e => e.IdProfUniversidad)
                    .HasName("PK__profUniv__2ADE96A6A7B9BC2C");

                entity.ToTable("profUniversidad");

                entity.Property(e => e.IdProfUniversidad)
                    .HasColumnName("idProfUniversidad")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdProfesor).HasColumnName("idProfesor");

                entity.Property(e => e.IdUniversidad).HasColumnName("idUniversidad");

                entity.HasOne(d => d.IdProfesorNavigation)
                    .WithMany(p => p.ProfUniversidad)
                    .HasForeignKey(d => d.IdProfesor)
                    .HasConstraintName("FK__profUnive__idPro__4E88ABD4");

                entity.HasOne(d => d.IdUniversidadNavigation)
                    .WithMany(p => p.ProfUniversidad)
                    .HasForeignKey(d => d.IdUniversidad)
                    .HasConstraintName("FK__profUnive__idUni__4F7CD00D");
            });

            modelBuilder.Entity<Profesor>(entity =>
            {
                entity.HasKey(e => e.IdProfesor)
                    .HasName("PK__profesor__E4BBA604426522EA");

                entity.ToTable("profesor");

                entity.Property(e => e.IdProfesor)
                    .HasColumnName("idProfesor")
                    .ValueGeneratedNever();

                entity.Property(e => e.Apellido1)
                    .HasColumnName("apellido1")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Apellido2)
                    .HasColumnName("apellido2")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Universidad>(entity =>
            {
                entity.HasKey(e => e.IdUniversidad)
                    .HasName("PK__universi__AFB9D2241790CC02");

                entity.ToTable("universidad");

                entity.Property(e => e.IdUniversidad)
                    .HasColumnName("idUniversidad")
                    .ValueGeneratedNever();

                entity.Property(e => e.NombreUniversidad)
                    .HasColumnName("nombreUniversidad")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
