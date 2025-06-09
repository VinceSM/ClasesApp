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
        public DbSet<Inscripciones> Inscripciones { get; set; }
        public DbSet<ClaseHorario> ClaseHorarios { get; set; }
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
            // Configuración de Profesores
            modelBuilder.Entity<Profesores>(entity =>
            {
                entity.ToTable("Profesores");
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Id).HasColumnName("id");
                entity.Property(p => p.Nombre).HasColumnName("nombre").IsRequired().HasMaxLength(100);
                entity.Property(p => p.TipoDeporte).HasColumnName("tipoDeporte").IsRequired().HasMaxLength(50);
                entity.Property(p => p.CreatedAt).HasColumnName("createdAt").IsRequired();
                entity.Property(p => p.UpdatedAt).HasColumnName("updatedAt");
                entity.Property(p => p.DeletedAt).HasColumnName("deletedAt");
            });

            // Configuración de Estudiantes
            modelBuilder.Entity<Estudiantes>(entity =>
            {
                entity.ToTable("Estudiantes");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.NombreCompleto).HasColumnName("nombreCompleto").IsRequired().HasMaxLength(200);
                entity.Property(e => e.Telefono).HasColumnName("telefono").HasMaxLength(20);
                entity.Property(e => e.Email).HasColumnName("email").HasMaxLength(100);
                entity.Property(e => e.CreatedAt).HasColumnName("createdAt").IsRequired();
                entity.Property(e => e.UpdatedAt).HasColumnName("updatedAt");
                entity.Property(e => e.DeletedAt).HasColumnName("deletedAt");
            });

            // Configuración de Horarios
            modelBuilder.Entity<Horarios>(entity =>
            {
                entity.ToTable("Horarios");
                entity.HasKey(h => h.Id);
                entity.Property(h => h.Id).HasColumnName("id");
                entity.Property(h => h.Dia).HasColumnName("dia").IsRequired().HasMaxLength(10);
                entity.Property(h => h.Fecha).HasColumnName("fecha");
                entity.Property(h => h.HoraInicio).HasColumnName("horaInicio").IsRequired();
                entity.Property(h => h.HoraFin).HasColumnName("horaFin").IsRequired();
                entity.Property(h => h.Id_Profesor).HasColumnName("id_Profesor");
                entity.Property(h => h.DeletedAt).HasColumnName("deletedAt");

                entity.HasOne(h => h.Profesor)
                      .WithMany(p => p.Horarios)
                      .HasForeignKey(h => h.Id_Profesor)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuración de Inscripciones
            modelBuilder.Entity<Inscripciones>(entity =>
            {
                entity.ToTable("Inscripciones");
                entity.HasKey(i => i.Id);
                entity.Property(i => i.Id).HasColumnName("id");
                entity.Property(i => i.PrecioClase).HasColumnName("precioClase").HasColumnType("decimal(10,2)").IsRequired();
                entity.Property(i => i.Pagado).HasColumnName("pagado").HasDefaultValue(false);
                entity.Property(i => i.DeletedAt).HasColumnName("deletedAt");
            });

            // Configuración de la tabla puente ClaseHorario
            modelBuilder.Entity<ClaseHorario>(entity =>
            {
                entity.ToTable("Inscripciones_has_Horarios");
                entity.HasKey(ch => new { ch.InscripcionId, ch.HorarioId });

                entity.Property(ch => ch.InscripcionId).HasColumnName("idInscripcionesClases");
                entity.Property(ch => ch.HorarioId).HasColumnName("idHorario");
                entity.Property(ch => ch.DeletedAt).HasColumnName("deletedAt");

                entity.HasOne(ch => ch.Inscripcion)
                      .WithMany(i => i.Horarios)
                      .HasForeignKey(ch => ch.InscripcionId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(ch => ch.Horario)
                      .WithMany(h => h.Inscripciones)
                      .HasForeignKey(ch => ch.HorarioId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuración de la tabla puente EstudianteInscripcion
            modelBuilder.Entity<EstudianteInscripcion>(entity =>
            {
                entity.ToTable("Inscripciones_has_Estudiantes");
                entity.HasKey(ei => new { ei.EstudianteId, ei.InscripcionId });

                entity.Property(ei => ei.EstudianteId).HasColumnName("idEstudiantes");
                entity.Property(ei => ei.InscripcionId).HasColumnName("idInscripcionesClases");
                entity.Property(ei => ei.DeletedAt).HasColumnName("deletedAt");

                entity.HasOne(ei => ei.Estudiante)
                      .WithMany(e => e.Inscripciones)
                      .HasForeignKey(ei => ei.EstudianteId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(ei => ei.Inscripcion)
                      .WithMany(i => i.Estudiantes)
                      .HasForeignKey(ei => ei.InscripcionId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Aplicar filtros de soft delete
            modelBuilder.Entity<Profesores>().HasQueryFilter(p => p.DeletedAt == null);
            modelBuilder.Entity<Estudiantes>().HasQueryFilter(e => e.DeletedAt == null);
            modelBuilder.Entity<Horarios>().HasQueryFilter(h => h.DeletedAt == null);
            modelBuilder.Entity<Inscripciones>().HasQueryFilter(i => i.DeletedAt == null);
            modelBuilder.Entity<ClaseHorario>().HasQueryFilter(ch => ch.DeletedAt == null);
            modelBuilder.Entity<EstudianteInscripcion>().HasQueryFilter(ei => ei.DeletedAt == null);
        }
    }
}
