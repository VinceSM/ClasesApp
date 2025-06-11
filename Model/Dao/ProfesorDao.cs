using ClaseApp.Model;
using ClaseApp.Resources;
using gestionClases.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClaseApp.Model.Dao
{
    public class ProfesorDAO
    {
        private readonly GestionClasesContext _context;

        public ProfesorDAO()
        {
            _context = new GestionClasesContext();
        }

        public void Agregar(Profesores profesor)
        {
            profesor.CreatedAt = DateTime.Now;
            _context.Profesores.Add(profesor);
            _context.SaveChanges();
        }

        public Profesores ObtenerPorId(int id)
        {
            return _context.Profesores.FirstOrDefault(p => p.IdProfesores == id && p.DeletedAt == null);
        }

        public List<Profesores> ListarProfesoresActivos()
        {
            return _context.Profesores
                .Where(p => p.DeletedAt == null)
                .OrderBy(p => p.Nombre)
                .ToList();
        }

        public void Actualizar(Profesores profesorActualizado)
        {
            var profesor = _context.Profesores.FirstOrDefault(p => p.IdProfesores == profesorActualizado.IdProfesores && p.DeletedAt == null);
            if (profesor != null)
            {
                profesor.Nombre = profesorActualizado.Nombre;
                profesor.TipoDeporte = profesorActualizado.TipoDeporte;
                profesor.UpdatedAt = DateTime.Now;
                _context.SaveChanges();
            }
        }

        public void Eliminar(int id)
        {
            var profesor = _context.Profesores.FirstOrDefault(p => p.IdProfesores == id && p.DeletedAt == null);
            if (profesor != null)
            {
                profesor.DeletedAt = DateTime.Now;
                _context.SaveChanges();
            }
        }
    }
}
