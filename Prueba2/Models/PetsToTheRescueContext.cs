using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Prueba2.Models
{
    public partial class PetsToTheRescueContext : DbContext
    {
        public PetsToTheRescueContext()
        {
        }

        public PetsToTheRescueContext(DbContextOptions<PetsToTheRescueContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrador> Administrador { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Mascotas> Mascotas { get; set; }
        public virtual DbSet<MascotasEnAdopcion> MascotasEnAdopcion { get; set; }
        public virtual DbSet<MascotasFotos> MascotasFotos { get; set; }
        public virtual DbSet<MascotasPerdidas> MascotasPerdidas { get; set; }
        public virtual DbSet<SolicitarAdopcion> SolicitarAdopcion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-P6E5C3UL;Database=PetsToTheRescue;User=sa;Pwd=123456789");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Administrador>(entity =>
            {
                entity.HasKey(e => e.IdAdministrador)
                    .HasName("PK_Administradores");

                entity.Property(e => e.IdAdministrador)
                    .ValueGeneratedNever()
                    .HasColumnName("idAdministrador");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apellidos");

                entity.Property(e => e.Contrasenia)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("contrasenia");

                entity.Property(e => e.HoraMomento)
                    .HasColumnType("datetime")
                    .HasColumnName("horaMomento");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.NumDocumento)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("numDocumento");

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("usuario");
            });

            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__Clientes__885457EE26A29AC7");

                entity.Property(e => e.IdCliente)
                    .ValueGeneratedNever()
                    .HasColumnName("idCliente");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apellidos");

                entity.Property(e => e.Contrasenia)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("contrasenia");

                entity.Property(e => e.HoraMomento)
                    .HasColumnType("datetime")
                    .HasColumnName("horaMomento");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.NumDocumento)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("numDocumento");

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("usuario");
            });

            modelBuilder.Entity<Mascotas>(entity =>
            {
                entity.HasKey(e => e.IdMascota)
                    .HasName("PK__Mascotas__8E068112FEB00598");

                entity.Property(e => e.IdMascota)
                    .ValueGeneratedNever()
                    .HasColumnName("idMascota");

                entity.Property(e => e.ClienteId).HasColumnName("ClienteID");

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("color");

                entity.Property(e => e.Edad)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("edad");

                entity.Property(e => e.Foto)
                    .IsRequired()
                    .HasColumnType("image")
                    .HasColumnName("foto");

                entity.Property(e => e.NombreAnimal)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombreAnimal");

                entity.Property(e => e.Raza)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("raza");

                entity.Property(e => e.Sexo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("sexo");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Mascotas)
                    .HasForeignKey(d => d.ClienteId)
                    .HasConstraintName("FK_Mascotas_Clientes");
            });

            modelBuilder.Entity<MascotasEnAdopcion>(entity =>
            {
                entity.HasKey(e => e.IdMasAdopcion)
                    .HasName("PK__Mascotas__AD2CB9A7BB8A326D");

                entity.Property(e => e.IdMasAdopcion)
                    .ValueGeneratedNever()
                    .HasColumnName("idMasAdopcion");

                entity.Property(e => e.AdministradorId).HasColumnName("AdministradorID");

                entity.Property(e => e.ClienteId).HasColumnName("ClienteID");

                entity.Property(e => e.ColorOjos)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("colorOjos");

                entity.Property(e => e.ColorPelaje)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("colorPelaje");

                entity.Property(e => e.CondMedica)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("condMedica");

                entity.Property(e => e.DescAnimal)
                    .IsRequired()
                    .HasMaxLength(350)
                    .IsUnicode(false)
                    .HasColumnName("descAnimal");

                entity.Property(e => e.Edad)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("edad");

                entity.Property(e => e.EmaRespaldo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("emaRespaldo");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Foto)
                    .IsRequired()
                    .HasColumnType("image")
                    .HasColumnName("foto");

                entity.Property(e => e.NombreAnimal)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombreAnimal");

                entity.Property(e => e.RazDecision)
                    .IsRequired()
                    .HasMaxLength(350)
                    .IsUnicode(false)
                    .HasColumnName("razDecision");

                entity.Property(e => e.Raza)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("raza");

                entity.Property(e => e.Sexo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("sexo");

                entity.Property(e => e.TelRespaldo)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("telRespaldo");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tipo");

                entity.HasOne(d => d.Administrador)
                    .WithMany(p => p.MascotasEnAdopcion)
                    .HasForeignKey(d => d.AdministradorId)
                    .HasConstraintName("FK_MascotasEnAdopcion_Administrador");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.MascotasEnAdopcion)
                    .HasForeignKey(d => d.ClienteId)
                    .HasConstraintName("FK_MascotasEnAdopcion_Clientes");
            });

            modelBuilder.Entity<MascotasFotos>(entity =>
            {
                entity.HasKey(e => e.IdMasFoto)
                    .HasName("PK__Mascotas__88C84BE8123ED6D2");

                entity.Property(e => e.IdMasFoto)
                    .ValueGeneratedNever()
                    .HasColumnName("idMasFoto");

                entity.Property(e => e.FechaFoto)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaFoto");

                entity.Property(e => e.LargNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("largNombre");

                entity.Property(e => e.LargoFoto)
                    .IsRequired()
                    .HasColumnName("largoFoto");

                entity.Property(e => e.MascotasEnAdopcionId).HasColumnName("MascotasEnAdopcionID");

                entity.Property(e => e.MascotasId).HasColumnName("MascotasID");

                entity.Property(e => e.MascotasPerdidasId).HasColumnName("MascotasPerdidasID");

                entity.Property(e => e.MinNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("minNombre");

                entity.Property(e => e.Miniatura)
                    .IsRequired()
                    .HasColumnName("miniatura");

                entity.HasOne(d => d.MascotasEnAdopcion)
                    .WithMany(p => p.MascotasFotos)
                    .HasForeignKey(d => d.MascotasEnAdopcionId)
                    .HasConstraintName("FK_MascotasFotos_MascotasEnAdopcion");

                entity.HasOne(d => d.Mascotas)
                    .WithMany(p => p.MascotasFotos)
                    .HasForeignKey(d => d.MascotasId)
                    .HasConstraintName("FK_MascotasFotos_Mascotas");

                entity.HasOne(d => d.MascotasPerdidas)
                    .WithMany(p => p.MascotasFotos)
                    .HasForeignKey(d => d.MascotasPerdidasId)
                    .HasConstraintName("FK_MascotasFotos_MascotasPerdidas");
            });

            modelBuilder.Entity<MascotasPerdidas>(entity =>
            {
                entity.HasKey(e => e.IdMasPerdida)
                    .HasName("PK__Mascotas__C773AE4B7D02CAE8");

                entity.Property(e => e.IdMasPerdida)
                    .ValueGeneratedNever()
                    .HasColumnName("idMasPerdida");

                entity.Property(e => e.AdministradorId).HasColumnName("AdministradorID");

                entity.Property(e => e.ClienteId).HasColumnName("Cliente ID");

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("color");

                entity.Property(e => e.Comentario)
                    .IsRequired()
                    .HasMaxLength(350)
                    .IsUnicode(false)
                    .HasColumnName("comentario");

                entity.Property(e => e.Edad)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("edad");

                entity.Property(e => e.Foto)
                    .IsRequired()
                    .HasColumnType("image")
                    .HasColumnName("foto");

                entity.Property(e => e.NombreAnimal)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombreAnimal");

                entity.Property(e => e.NumContacto)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("numContacto");

                entity.Property(e => e.Raza)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("raza");

                entity.Property(e => e.Sexo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("sexo");

                entity.HasOne(d => d.Administrador)
                    .WithMany(p => p.MascotasPerdidas)
                    .HasForeignKey(d => d.AdministradorId)
                    .HasConstraintName("FK_MascotasPerdidas_Administradores");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.MascotasPerdidas)
                    .HasForeignKey(d => d.ClienteId)
                    .HasConstraintName("FK_MascotasPerdidas_Clientes");
            });

            modelBuilder.Entity<SolicitarAdopcion>(entity =>
            {
                entity.HasKey(e => e.IdMascotas)
                    .HasName("PK__Solicita__965CDA05134C871A");

                entity.Property(e => e.IdMascotas)
                    .ValueGeneratedNever()
                    .HasColumnName("idMascotas");

                entity.Property(e => e.Actividades)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("actividades");

                entity.Property(e => e.EstEconomica)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("estEconomica");

                entity.Property(e => e.Experiencia)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("experiencia");

                entity.Property(e => e.MainMascotaId).HasColumnName("MainMascotaID");

                entity.Property(e => e.MasCasa)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("masCasa");

                entity.Property(e => e.RazAdopcion)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("razAdopcion");

                entity.Property(e => e.TiempoFuera)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("tiempoFuera");

                entity.Property(e => e.Veterinaria)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("veterinaria");

                entity.Property(e => e.Viaje)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("viaje");

                entity.Property(e => e.Vivienda)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("vivienda");

                entity.HasOne(d => d.MainMascota)
                    .WithMany(p => p.SolicitarAdopcion)
                    .HasForeignKey(d => d.MainMascotaId)
                    .HasConstraintName("FK_SolicitarAdopcion_Mascotas");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
