using System;
using System.Collections.Generic;

#nullable disable

namespace API.W.Models
{
    public partial class Calificacion
    {
        public int IdCalificacion { get; set; }
        public int? IdProfesor { get; set; }
        public int? IdCurso { get; set; }
        public int? IdCarrera { get; set; }
        public byte? Facilidad { get; set; }
        public byte? Apoyo { get; set; }
        public byte? Claridad { get; set; }
        public bool? Estado { get; set; }
        public string Comentario { get; set; }
        public int? IdEtiqueta { get; set; }
        public bool? Recomienda { get; set; }
        public byte? Puntaje { get; set; }

        public virtual Carrera IdCarreraNavigation { get; set; }
        public virtual Curso IdCursoNavigation { get; set; }
        public virtual Etiquetum IdEtiquetaNavigation { get; set; }
        public virtual Profesor IdProfesorNavigation { get; set; }
    }
}
