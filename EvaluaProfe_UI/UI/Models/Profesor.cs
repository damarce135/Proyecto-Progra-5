﻿using System;
using System.Collections.Generic;

namespace UI.Models
{
    public partial class Profesor
    {
        public Profesor()
        {
            Calificacion = new HashSet<Calificacion>();
            ProfCurso = new HashSet<ProfCurso>();
            ProfUniversidad = new HashSet<ProfUniversidad>();
        }

        public int IdProfesor { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }

        public virtual ICollection<Calificacion> Calificacion { get; set; }
        public virtual ICollection<ProfCurso> ProfCurso { get; set; }
        public virtual ICollection<ProfUniversidad> ProfUniversidad { get; set; }
    }
}
