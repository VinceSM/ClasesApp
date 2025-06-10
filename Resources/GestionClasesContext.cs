using ClaseApp.Model;
using gestionClases.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseApp.Resources
{
    public class GestionClasesContext : DbContext
    {
        public DbSet<Profesores> Profesores { get; set; }
        public DbSet<Estudiantes> Estudiantes { get; set; }
        public DbSet<Horarios> Horarios { get; set; }
        public DbSet<InscripcionClases> InscripcionClases { get; set; }
        public DbSet<ClaseProfesorHorario> ClaseProfesorHorarios { get; set; }
        public DbSet<EstudianteInscripcion> EstudianteInscripciones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer(@"Server=GABRIELMUISE\SQLEXPRESS;Database=gestionclases;Trusted_Connection=True;TrustServerCertificate=True;");
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-10BAS3U\SQLEXPRESS;Database=gestionclases;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Profesores
            modelBuilder.Entity<Profesores>(entity =>
            {
                entity.ToTable("Profesores");
                entity.HasKey(p => p.IdProfesores);
                entity.Property(p => p.IdProfesores).HasColumnName("idProfesores");
                entity.Property(p => p.Nombre).HasColumnName("nombre").HasMaxLength(45).IsRequired();
                entity.Property(p => p.TipoDeporte).HasColumnName("tipoDeporte").HasMaxLength(45).IsRequired();
                entity.Property(p => p.CreatedAt).HasColumnName("createdAt");
                entity.Property(p => p.UpdatedAt).HasColumnName("updatedAt");
                entity.Property(p => p.DeletedAt).HasColumnName("deletedAt");
            });

            // Estudiantes
            modelBuilder.Entity<Estudiantes>(entity =>
            {
                entity.ToTable("Estudiantes");
                entity.HasKey(e => e.IdEstudiantes);
                entity.Property(e => e.IdEstudiantes).HasColumnName("idEstudiantes");
                entity.Property(e => e.NombreCompleto).HasColumnName("nombreCompleto").HasMaxLength(65).IsRequired();
                entity.Property(e => e.Telefono).HasColumnName("telefono").HasMaxLength(45);
                entity.Property(e => e.Email).HasColumnName("email").HasMaxLength(45);
                entity.Property(e => e.CreatedAt).HasColumnName("createdAt");
                entity.Property(e => e.UpdatedAt).HasColumnName("updatedAt");
                entity.Property(e => e.DeletedAt).HasColumnName("deletedAt");
            });

            // Horarios
            modelBuilder.Entity<Horarios>(entity =>
            {
                entity.ToTable("Horarios");
                entity.HasKey(h => h.IdHorario);
                entity.Property(h => h.IdHorario).HasColumnName("idHorario");
                entity.Property(h => h.Dia).HasColumnName("dia").HasMaxLength(45).IsRequired();
                entity.Property(h => h.Fecha).HasColumnName("fecha").IsRequired();
                entity.Property(h => h.HoraInicio).HasColumnName("horaInicio").IsRequired();
                entity.Property(h => h.HoraFin).HasColumnName("horaFin").IsRequired();
                entity.Property(h => h.CreatedAt).HasColumnName("createdAt");
                entity.Property(h => h.UpdatedAt).HasColumnName("updatedAt");
                entity.Property(h => h.DeletedAt).HasColumnName("deletedAt");
            });

            // InscripcionClases
            modelBuilder.Entity<InscripcionClases>(entity =>
            {
                entity.ToTable("InscripcionClases");
                entity.HasKey(i => i.IdClase);
                entity.Property(i => i.IdClase).HasColumnName("idClase");
                entity.Property(i => i.PrecioClase).HasColumnName("precioClase").HasColumnType("decimal(10,2)");
                entity.Property(i => i.Pagado).HasColumnName("pagado");
                entity.Property(i => i.CreatedAt).HasColumnName("createdAt");
                entity.Property(i => i.UpdatedAt).HasColumnName("updatedAt");
                entity.Property(i => i.DeletedAt).HasColumnName("deletedAt");
            });

            // ClaseProfesorHorario (relación triple)
            modelBuilder.Entity<ClaseProfesorHorario>(entity =>
            {
                entity.ToTable("ClaseProfesorHorario");
                entity.HasKey(c => new { c.IdClase, c.IdHorario, c.IdProfesor });

                entity.Property(c => c.IdClase).HasColumnName("idClase");
                entity.Property(c => c.IdHorario).HasColumnName("idHorario");
                entity.Property(c => c.IdProfesor).HasColumnName("idProfesor");

                entity.HasOne(c => c.Clase)
                      .WithMany(i => i.ClaseProfesorHorarios)
                      .HasForeignKey(c => c.IdClase)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(c => c.Horario)
                      .WithMany(h => h.ClaseProfesorHorarios)
                      .HasForeignKey(c => c.IdHorario)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(c => c.Profesor)
                      .WithMany(p => p.ClaseProfesorHorarios)
                      .HasForeignKey(c => c.IdProfesor)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // EstudianteInscripcion
            modelBuilder.Entity<EstudianteInscripcion>(entity =>
            {
                entity.ToTable("EstudianteInscripcion");
                entity.HasKey(e => new { e.IdClase, e.IdEstudiante });

                entity.Property(e => e.IdClase).HasColumnName("idClase");
                entity.Property(e => e.IdEstudiante).HasColumnName("idEstudiante");

                entity.HasOne(e => e.Clase)
                      .WithMany(i => i.EstudianteInscripciones)
                      .HasForeignKey(e => e.IdClase)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Estudiante)
                      .WithMany(s => s.EstudianteInscripciones)
                      .HasForeignKey(e => e.IdEstudiante)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Soft Delete Filters
            modelBuilder.Entity<Profesores>().HasQueryFilter(p => p.DeletedAt == null);
            modelBuilder.Entity<Estudiantes>().HasQueryFilter(e => e.DeletedAt == null);
            modelBuilder.Entity<Horarios>().HasQueryFilter(h => h.DeletedAt == null);
            modelBuilder.Entity<InscripcionClases>().HasQueryFilter(i => i.DeletedAt == null);
        }
    }
}
