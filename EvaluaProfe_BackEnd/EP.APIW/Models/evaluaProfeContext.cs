using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EP.APIW.Models
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

        public virtual DbSet<Administrador> Administradors { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<CalEtiquetum> CalEtiqueta { get; set; }
        public virtual DbSet<Calificacion> Calificacions { get; set; }
        public virtual DbSet<Carrera> Carreras { get; set; }
        public virtual DbSet<Curso> Cursos { get; set; }
        public virtual DbSet<CursoCarrera> CursoCarreras { get; set; }
        public virtual DbSet<Etiquetum> Etiqueta { get; set; }
        public virtual DbSet<ProfCurso> ProfCursos { get; set; }
        public virtual DbSet<ProfUniversidad> ProfUniversidads { get; set; }
        public virtual DbSet<Profesor> Profesors { get; set; }
        public virtual DbSet<Universidad> Universidads { get; set; }

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
            modelBuilder.Entity<Administrador>(entity =>
            {
                entity.HasKey(e => e.IdAdministrador)
                    .HasName("PK__administ__EBE80EA17D213B28");

                entity.ToTable("administrador");

                entity.Property(e => e.IdAdministrador)
                    .ValueGeneratedNever()
                    .HasColumnName("idAdministrador");

                entity.Property(e => e.Apellido1)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("apellido1");

                entity.Property(e => e.Apellido2)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("apellido2");

                entity.Property(e => e.Contrasena)
                    .HasMaxLength(1)
                    .HasColumnName("contrasena");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Habilitado).HasColumnName("habilitado");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("telefono");
            });

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId, "IX_AspNetUserRoles_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<CalEtiquetum>(entity =>
            {
                entity.HasKey(e => e.IdCalEtiqueta)
                    .HasName("PK__calEtiqu__0A25B31E47F40C52");

                entity.ToTable("calEtiqueta");

                entity.Property(e => e.IdCalEtiqueta)
                    .ValueGeneratedNever()
                    .HasColumnName("idCalEtiqueta");

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
                    .ValueGeneratedNever()
                    .HasColumnName("idCalificacion");

                entity.Property(e => e.Apoyo).HasColumnName("apoyo");

                entity.Property(e => e.Calificacion1).HasColumnName("calificacion");

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

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Calificacions)
                    .HasForeignKey(d => d.IdCurso)
                    .HasConstraintName("FK__calificac__idCur__4AB81AF0");

                entity.HasOne(d => d.IdProfesorNavigation)
                    .WithMany(p => p.Calificacions)
                    .HasForeignKey(d => d.IdProfesor)
                    .HasConstraintName("FK__calificac__idPro__4BAC3F29");
            });

            modelBuilder.Entity<Carrera>(entity =>
            {
                entity.HasKey(e => e.IdCarrera)
                    .HasName("PK__carrera__7B19E791AA8840C6");

                entity.ToTable("carrera");

                entity.Property(e => e.IdCarrera)
                    .ValueGeneratedNever()
                    .HasColumnName("idCarrera");

                entity.Property(e => e.IdUniversidad).HasColumnName("idUniversidad");

                entity.Property(e => e.NombreCarrera)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nombreCarrera");

                entity.HasOne(d => d.IdUniversidadNavigation)
                    .WithMany(p => p.Carreras)
                    .HasForeignKey(d => d.IdUniversidad)
                    .HasConstraintName("FK__carrera__idUnive__49C3F6B7");
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.IdCurso)
                    .HasName("PK__curso__8551ED050202B835");

                entity.ToTable("curso");

                entity.Property(e => e.IdCurso)
                    .ValueGeneratedNever()
                    .HasColumnName("idCurso");

                entity.Property(e => e.NombreCurso)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nombreCurso");
            });

            modelBuilder.Entity<CursoCarrera>(entity =>
            {
                entity.HasKey(e => e.IdCursoCarrera)
                    .HasName("PK__cursoCar__405B0B5404809940");

                entity.ToTable("cursoCarrera");

                entity.Property(e => e.IdCursoCarrera)
                    .ValueGeneratedNever()
                    .HasColumnName("idCursoCarrera");

                entity.Property(e => e.IdCarrera).HasColumnName("idCarrera");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.HasOne(d => d.IdCarreraNavigation)
                    .WithMany(p => p.CursoCarreras)
                    .HasForeignKey(d => d.IdCarrera)
                    .HasConstraintName("FK__cursoCarr__idCar__4D94879B");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.CursoCarreras)
                    .HasForeignKey(d => d.IdCurso)
                    .HasConstraintName("FK__cursoCarr__idCur__4CA06362");
            });

            modelBuilder.Entity<Etiquetum>(entity =>
            {
                entity.HasKey(e => e.IdEtiqueta)
                    .HasName("PK__etiqueta__3C1526A74FEE5A7B");

                entity.ToTable("etiqueta");

                entity.Property(e => e.IdEtiqueta)
                    .ValueGeneratedNever()
                    .HasColumnName("idEtiqueta");

                entity.Property(e => e.NombreEtiqueta)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombreEtiqueta");
            });

            modelBuilder.Entity<ProfCurso>(entity =>
            {
                entity.HasKey(e => e.IdProfCurso)
                    .HasName("PK__profCurs__071E340A2421347E");

                entity.ToTable("profCurso");

                entity.Property(e => e.IdProfCurso)
                    .ValueGeneratedNever()
                    .HasColumnName("idProfCurso");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.IdProfesor).HasColumnName("idProfesor");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.ProfCursos)
                    .HasForeignKey(d => d.IdCurso)
                    .HasConstraintName("FK__profCurso__idCur__5165187F");

                entity.HasOne(d => d.IdProfesorNavigation)
                    .WithMany(p => p.ProfCursos)
                    .HasForeignKey(d => d.IdProfesor)
                    .HasConstraintName("FK__profCurso__idPro__5070F446");
            });

            modelBuilder.Entity<ProfUniversidad>(entity =>
            {
                entity.HasKey(e => e.IdProfUniversidad)
                    .HasName("PK__profUniv__2ADE96A6A7B9BC2C");

                entity.ToTable("profUniversidad");

                entity.Property(e => e.IdProfUniversidad)
                    .ValueGeneratedNever()
                    .HasColumnName("idProfUniversidad");

                entity.Property(e => e.IdProfesor).HasColumnName("idProfesor");

                entity.Property(e => e.IdUniversidad).HasColumnName("idUniversidad");

                entity.HasOne(d => d.IdProfesorNavigation)
                    .WithMany(p => p.ProfUniversidads)
                    .HasForeignKey(d => d.IdProfesor)
                    .HasConstraintName("FK__profUnive__idPro__4E88ABD4");

                entity.HasOne(d => d.IdUniversidadNavigation)
                    .WithMany(p => p.ProfUniversidads)
                    .HasForeignKey(d => d.IdUniversidad)
                    .HasConstraintName("FK__profUnive__idUni__4F7CD00D");
            });

            modelBuilder.Entity<Profesor>(entity =>
            {
                entity.HasKey(e => e.IdProfesor)
                    .HasName("PK__profesor__E4BBA604426522EA");

                entity.ToTable("profesor");

                entity.Property(e => e.IdProfesor)
                    .ValueGeneratedNever()
                    .HasColumnName("idProfesor");

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

            modelBuilder.Entity<Universidad>(entity =>
            {
                entity.HasKey(e => e.IdUniversidad)
                    .HasName("PK__universi__AFB9D2241790CC02");

                entity.ToTable("universidad");

                entity.Property(e => e.IdUniversidad)
                    .ValueGeneratedNever()
                    .HasColumnName("idUniversidad");

                entity.Property(e => e.NombreUniversidad)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nombreUniversidad");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
