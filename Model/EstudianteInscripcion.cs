﻿using gestionClases.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseApp.Model
{
    public class EstudianteInscripcion
    {
        public int IdClase { get; set; }
        public InscripcionClases? Clase { get; set; }

        public int IdEstudiante { get; set; }
        public Estudiantes? Estudiante { get; set; }
    }

}
