using ClaseApp.Model.Dao;
using gestionClases.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseApp.Controller
{
    public class ControladoraInscripcionClases
    {
        private readonly InscripcionClasesDAO inscripcionDAO;

        public ControladoraInscripcionClases()
        {
            inscripcionDAO = new InscripcionClasesDAO();
        }

        public void Guardar(InscripcionClases inscripcion)
        {
            inscripcionDAO.Agregar(inscripcion);
        }

        public List<InscripcionClases> ListarInscripcionesActivas()
        {
            return inscripcionDAO.ListarInscripcionesActivas();
        }

        public void Editar(InscripcionClases inscripcion)
        {
            inscripcionDAO.Actualizar(inscripcion);
        }

        public void SoftDelete(int idInscripcion)
        {
            inscripcionDAO.Eliminar(idInscripcion);
        }

        public InscripcionClases ObtenerPorId(int id)
        {
            return inscripcionDAO.ObtenerPorId(id);
        }

        public List<InscripcionClases> ObtenerPorEstudiante(int idEstudiante)
        {
            return inscripcionDAO.ObtenerPorEstudiante(idEstudiante);
        }

        public List<Estudiantes> ObtenerEstudiantesPorHorario(int idHorario)
        {
            return inscripcionDAO.ObtenerEstudiantesPorHorario(idHorario);
        }
    }
}
