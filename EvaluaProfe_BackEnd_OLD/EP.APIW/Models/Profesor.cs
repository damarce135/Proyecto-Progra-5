using System;
using System.Collections.Generic;

#nullable disable

namespace EP.APIW.Models
{
    public partial class Profesor
    {
        public Profesor()
        {
            Calificacions = new HashSet<Calificacion>();
            ProfCursos = new HashSet<ProfCurso>();
        }

        public int IdProfesor { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }

        public virtual ICollection<Calificacion> Calificacions { get; set; }
        public virtual ICollection<ProfCurso> ProfCursos { get; set; }
    }
}
