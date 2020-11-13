using System;
using System.Collections.Generic;

#nullable disable

namespace EP.APIW.Models
{
    public partial class Calificacion
    {
        public Calificacion()
        {
            CalEtiqueta = new HashSet<CalEtiquetum>();
        }

        public int IdCalificacion { get; set; }
        public int? IdProfesor { get; set; }
        public int? IdCurso { get; set; }
        public byte? Facilidad { get; set; }
        public byte? Apoyo { get; set; }
        public byte? Claridad { get; set; }
        public byte? Estado { get; set; }
        public string Comentario { get; set; }
        public bool? Recomienda { get; set; }
        public byte? Calificacion1 { get; set; }

        public virtual Curso IdCursoNavigation { get; set; }
        public virtual Profesor IdProfesorNavigation { get; set; }
        public virtual ICollection<CalEtiquetum> CalEtiqueta { get; set; }
    }
}
