using ClaseApp.Model;
using ClaseApp.Resources;
using gestionClases.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClaseApp.Model.Dao
{
    public class EstudianteDAO
    {
        private readonly GestionClasesContext _context;

        public EstudianteDAO()
        {
            _context = new GestionClasesContext();
        }

        public void Agregar(Estudiantes estudiante)
        {
            estudiante.CreatedAt = DateTime.Now;
            _context.Estudiantes.Add(estudiante);
            _context.SaveChanges();
        }

        public Estudiantes ObtenerPorId(int id)
        {
            return _context.Estudiantes.FirstOrDefault(e => e.IdEstudiantes == id && e.DeletedAt == null);
        }

        public List<Estudiantes> ListarEstudiantesActivos()
        {
            return _context.Estudiantes
                .Where(e => e.DeletedAt == null)
                .OrderBy(e => e.NombreCompleto)
                .ToList();
        }

        public void Actualizar(Estudiantes estudianteActualizado)
        {
            var estudiante = _context.Estudiantes.FirstOrDefault(e => e.IdEstudiantes == estudianteActualizado.IdEstudiantes && e.DeletedAt == null);
            if (estudiante != null)
            {
                estudiante.NombreCompleto = estudianteActualizado.NombreCompleto;
                estudiante.Telefono = estudianteActualizado.Telefono;
                estudiante.Email = estudianteActualizado.Email;
                estudiante.UpdatedAt = DateTime.Now;
                _context.SaveChanges();
            }
        }

        public void Eliminar(int id)
        {
            var estudiante = _context.Estudiantes.FirstOrDefault(e => e.IdEstudiantes == id && e.DeletedAt == null);
            if (estudiante != null)
            {
                estudiante.DeletedAt = DateTime.Now;
                _context.SaveChanges();
            }
        }
    }
}
