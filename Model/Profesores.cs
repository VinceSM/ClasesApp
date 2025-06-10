using ClaseApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestionClases.Model
{
    public class Profesores
    {
        public int IdProfesores { get; set; }
        public string? Nombre { get; set; }
        public string? TipoDeporte { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public ICollection<ClaseProfesorHorario>? ClaseProfesorHorarios { get; set; }
    }
}
