using gestionClases.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseApp.Model
{
    public class ClaseHorario
    {
        public int InscripcionId { get; set; }
        public int HorarioId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public Inscripciones? Inscripcion { get; set; }
        public Horarios? Horario { get; set; }
    }
}
