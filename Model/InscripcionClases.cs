using ClaseApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestionClases.Model
{
    public class InscripcionClases
    {
        public int IdClase { get; set; }
        public decimal PrecioClase { get; set; }
        public bool Pagado { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public ICollection<EstudianteInscripcion>? EstudianteInscripciones { get; set; }
        public ICollection<ClaseProfesorHorario>? ClaseProfesorHorarios { get; set; }
    }
}
