using System;
using System.Collections.Generic;
using System.Text;

namespace DO.Objects
{
    public class Calificacion
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

        public virtual Carrera Carrera { get; set; }
        public virtual Curso Curso { get; set; }
        public virtual Etiquetum Etiqueta { get; set; }
        public virtual Profesor Profesor { get; set; }
    }
}
