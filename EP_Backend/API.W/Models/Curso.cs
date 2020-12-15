using System;
using System.Collections.Generic;

#nullable disable

namespace API.W.Models
{
    public partial class Curso
    {
        public Curso()
        {
            Calificacions = new HashSet<Calificacion>();
        }

        public int IdCurso { get; set; }
        public string NombreCurso { get; set; }
        public int? IdCarrera { get; set; }

        public virtual Carrera IdCarreraNavigation { get; set; }
        public virtual ICollection<Calificacion> Calificacions { get; set; }
    }
}
