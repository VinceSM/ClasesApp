using gestionClases.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseApp.Model
{
    public class EstudianteInscripcion
    {
        public int EstudianteId { get; set; }
        public int InscripcionId { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public Estudiantes? Estudiante { get; set; }
        public Inscripciones? Inscripcion { get; set; }
    }
}
