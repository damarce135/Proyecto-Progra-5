using System;
using System.Collections.Generic;

#nullable disable

namespace EP.APIW.Models
{
    public partial class Curso
    {
        public Curso()
        {
            Calificacions = new HashSet<Calificacion>();
            CursoCarreras = new HashSet<CursoCarrera>();
            ProfCursos = new HashSet<ProfCurso>();
        }

        public int IdCurso { get; set; }
        public string NombreCurso { get; set; }

        public virtual ICollection<Calificacion> Calificacions { get; set; }
        public virtual ICollection<CursoCarrera> CursoCarreras { get; set; }
        public virtual ICollection<ProfCurso> ProfCursos { get; set; }
    }
}
