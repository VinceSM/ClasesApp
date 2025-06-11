using ClaseApp.Model.Dao;
using gestionClases.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseApp.Controller
{
    public class ControladoraEstudiante
    {
        private readonly EstudianteDAO estudianteDAO;

        public ControladoraEstudiante()
        {
            estudianteDAO = new EstudianteDAO();
        }

        public List<Estudiantes> ListarActivos()
        {
            return estudianteDAO.ListarEstudiantesActivos();
        }

        public void Guardar(Estudiantes estudiante)
        {
            estudianteDAO.Agregar(estudiante);
        }

        public void Editar(Estudiantes estudiante)
        {
            estudianteDAO.Actualizar(estudiante);
        }

        public void SoftDelete(int idEstudiante)
        {
            estudianteDAO.Eliminar(idEstudiante);
        }

        public Estudiantes BuscarPorId(int id)
        {
            return estudianteDAO.ObtenerPorId(id);
        }
    }
}
