using System;
using System.Collections.Generic;
using System.Text;

namespace DO.Objects
{
    public class Curso
    {
        public Curso()
        {
            Calificacions = new HashSet<Calificacion>();
        }

        public int IdCurso { get; set; }
        public string NombreCurso { get; set; }
        public int? IdCarrera { get; set; }

        public virtual Carrera Carrera { get; set; }
        public virtual ICollection<Calificacion> Calificacions { get; set; }
    }
}
