using gestionClases.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseApp.Model
{
    public class ClaseProfesorHorario
    {
        public int IdClase { get; set; }
        public InscripcionClases? Clase { get; set; }

        public int IdHorario { get; set; }
        public Horarios? Horario { get; set; }

        public int IdProfesor { get; set; }
        public Profesores? Profesor { get; set; }
    }

}
