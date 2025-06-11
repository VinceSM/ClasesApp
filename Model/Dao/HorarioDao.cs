using ClaseApp.Model;
using ClaseApp.Resources;
using gestionClases.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClaseApp.Model.Dao
{
    public class HorarioDAO
    {
        private readonly GestionClasesContext _context;

        public HorarioDAO()
        {
            _context = new GestionClasesContext();
        }

        public void Agregar(Horarios horario)
        {
            horario.CreatedAt = DateTime.Now;
            _context.Horarios.Add(horario);
            _context.SaveChanges();
        }

        public Horarios ObtenerPorId(int id)
        {
            return _context.Horarios.FirstOrDefault(h => h.IdHorario == id && h.DeletedAt == null);
        }

        public List<Horarios> ListarHorariosActivos()
        {
            return _context.Horarios
                .Where(h => h.DeletedAt == null)
                .OrderBy(h => h.Fecha)
                .ToList();
        }

        public void Actualizar(Horarios horarioActualizado)
        {
            var horario = _context.Horarios.FirstOrDefault(h => h.IdHorario == horarioActualizado.IdHorario && h.DeletedAt == null);
            if (horario != null)
            {
                horario.Dia = horarioActualizado.Dia;
                horario.Fecha = horarioActualizado.Fecha;
                horario.HoraInicio = horarioActualizado.HoraInicio;
                horario.HoraFin = horarioActualizado.HoraFin;
                horario.UpdatedAt = DateTime.Now;
                _context.SaveChanges();
            }
        }

        public void Eliminar(int id)
        {
            var horario = _context.Horarios.FirstOrDefault(h => h.IdHorario == id && h.DeletedAt == null);
            if (horario != null)
            {
                horario.DeletedAt = DateTime.Now;
                _context.SaveChanges();
            }
        }
    }
}
