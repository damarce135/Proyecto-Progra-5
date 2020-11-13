using System;
using System.Collections.Generic;

namespace UI.Models
{
    public partial class Curso
    {
        public Curso()
        {
            Calificacion = new HashSet<Calificacion>();
            CursoCarrera = new HashSet<CursoCarrera>();
            ProfCurso = new HashSet<ProfCurso>();
        }

        public int IdCurso { get; set; }
        public string NombreCurso { get; set; }

        public virtual ICollection<Calificacion> Calificacion { get; set; }
        public virtual ICollection<CursoCarrera> CursoCarrera { get; set; }
        public virtual ICollection<ProfCurso> ProfCurso { get; set; }
    }
}
