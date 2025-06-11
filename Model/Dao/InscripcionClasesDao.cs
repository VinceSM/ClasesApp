using ClaseApp.Model;
using ClaseApp.Resources;
using gestionClases.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClaseApp.Model.Dao
{
    public class InscripcionClasesDAO
    {
        private readonly GestionClasesContext _context;

        public InscripcionClasesDAO()
        {
            _context = new GestionClasesContext();
        }

        public void Agregar(InscripcionClases inscripcion)
        {
            inscripcion.CreatedAt = DateTime.Now;
            _context.InscripcionClases.Add(inscripcion);
            _context.SaveChanges();
        }

        public InscripcionClases ObtenerPorId(int id)
        {
            return _context.InscripcionClases.FirstOrDefault(i => i.IdClase == id && i.DeletedAt == null);
        }

        public List<InscripcionClases> ListarInscripcionesActivas()
        {
            return _context.InscripcionClases
                .Where(i => i.DeletedAt == null)
                .OrderByDescending(i => i.CreatedAt)
                .ToList();
        }

        public void Actualizar(InscripcionClases inscripcionActualizada)
        {
            var inscripcion = _context.InscripcionClases.FirstOrDefault(i => i.IdClase == inscripcionActualizada.IdClase && i.DeletedAt == null);
            if (inscripcion != null)
            {
                inscripcion.PrecioClase = inscripcionActualizada.PrecioClase;
                inscripcion.Pagado = inscripcionActualizada.Pagado;
                inscripcion.UpdatedAt = DateTime.Now;
                _context.SaveChanges();
            }
        }

        public void Eliminar(int id)
        {
            var inscripcion = _context.InscripcionClases.FirstOrDefault(i => i.IdClase == id && i.DeletedAt == null);
            if (inscripcion != null)
            {
                inscripcion.DeletedAt = DateTime.Now;
                _context.SaveChanges();
            }
        }

        public List<InscripcionClases> ObtenerPorEstudiante(int idEstudiante)
        {
            return _context.InscripcionClases
            .Where(ic =>
                !ic.DeletedAt.HasValue &&
                ic.EstudianteInscripciones.Any(ei => ei.IdEstudiante == idEstudiante)
            )
            .ToList();
        }

        public List<Estudiantes> ObtenerEstudiantesPorHorario(int idHorario)
        {
            var estudiantes = _context.InscripcionClases
        .Where(ic =>
            !ic.DeletedAt.HasValue &&
            ic.ClaseProfesorHorarios.Any(cph => cph.IdHorario == idHorario)
        )
        .SelectMany(ic => ic.EstudianteInscripciones)
        .Select(ei => ei.Estudiante)
        .Where(e => !e.DeletedAt.HasValue)
        .Distinct()
        .ToList();

            return estudiantes;
        }
    }
}
