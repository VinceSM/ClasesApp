using ClaseApp.Model.Dao;
using gestionClases.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseApp.Controller
{
    public class ControladoraHorario
    {
        private readonly HorarioDAO horarioDAO;

        public ControladoraHorario()
        {
            horarioDAO = new HorarioDAO();
        }

        public List<Horarios> ListarHorariosActivos()
        {
            return horarioDAO.ListarHorariosActivos();
        }

        public void Guardar(Horarios horario)
        {
            horarioDAO.Agregar(horario);
        }

        public void Editar(Horarios horario)
        {
            horarioDAO.Actualizar(horario);
        }

        public void SoftDelete(int idHorario)
        {
            horarioDAO.Eliminar(idHorario);
        }

        public Horarios ObtenerPorId(int id)
        {
            return horarioDAO.ObtenerPorId(id);
        }
    }
}
