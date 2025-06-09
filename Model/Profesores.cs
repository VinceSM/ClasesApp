using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestionClases.Model
{
    public class Profesores
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? TipoDeporte { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<Horarios>? Horarios { get; set; }
    }
}
