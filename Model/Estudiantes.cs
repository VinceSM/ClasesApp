using ClaseApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestionClases.Model
{
    public class Estudiantes
    {
        public int IdEstudiantes { get; set; }
        public string? NombreCompleto { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public ICollection<EstudianteInscripcion>? EstudianteInscripciones { get; set; }
    }
}
