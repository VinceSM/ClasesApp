using ClaseApp.Model.Dao;
using gestionClases.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseApp.Controller
{
    public class ControladoraProfesor
    {
        private readonly ProfesorDAO profesorDAO;

        public ControladoraProfesor()
        {
            profesorDAO = new ProfesorDAO();
        }

        public List<Profesores> ListarProfesoresActivos()
        {
            return profesorDAO.ListarProfesoresActivos();
        }

        public void Guardar(Profesores profesor)
        {
            profesorDAO.Agregar(profesor);
        }

        public void Editar(Profesores profesor)
        {
            profesorDAO.Actualizar(profesor);
        }

        public void SoftDelete(int idProfesor)
        {
            profesorDAO.Eliminar(idProfesor);
        }

        public Profesores ObtenerPorId(int id)
        {
            return profesorDAO.ObtenerPorId(id);
        }
    }
}
