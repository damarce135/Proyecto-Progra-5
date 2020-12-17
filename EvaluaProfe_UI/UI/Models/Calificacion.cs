using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
    public partial class Calificacion
    {
        [Key]
        public int IdCalificacion { get; set; }

        [Display(Name = "Profesor")]
        public int? IdProfesor { get; set; }

        [Display(Name = "Curso")]
        public int? IdCurso { get; set; }

        [Display(Name = "Carrera")]
        public int? IdCarrera { get; set; }

        [Display(Name = "Facilidad")]
        public byte Facilidad { get; set; }
        public byte Apoyo { get; set; }
        public byte Claridad { get; set; }
        public bool Estado { get; set; }
        public string Comentario { get; set; }

        [Display(Name = "Tag")]
        public int? IdEtiqueta { get; set; }

        [Display(Name = "Recomendado")]
        public bool Recomienda { get; set; }

        [Display(Name = "Promedio")]
        public byte? Puntaje { get; set; }

        public virtual Carrera Carrera { get; set; }
        public virtual Curso Curso { get; set; }

        [Display(Name = "Tag")]
        public virtual Etiqueta Etiqueta { get; set; }
        public virtual Profesor Profesor { get; set; }
    }
}
