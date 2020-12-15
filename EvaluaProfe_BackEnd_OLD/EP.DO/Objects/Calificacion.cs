using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EP.DO.Objects
{
    public class Calificacion
    {

        [Key]
        public int IdCalificacion { get; set; }
        public int IdProfesor { get; set; }
        public int IdCurso { get; set; }
        public byte Facilidad { get; set; }
        public byte Apoyo { get; set; }
        public byte Claridad { get; set; }
        public byte Estado { get; set; }
        public string Comentario { get; set; }
        public bool Recomienda { get; set; }
        public byte Calificacion1 { get; set; }

        [ForeignKey("IdCurso")]
        public Curso Curso { get; set; }

        [ForeignKey("IdProfesor")]
        public Profesor Profesor { get; set; }

        public ICollection<CalEtiqueta> CalEtiquetas { get; set; }
    }
}
