using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EP.API.Models
{
    public class Calificacion
    {
        //public Calificacion()
        //{
        //    CalEtiqueta = new HashSet<CalEtiqueta>();
        //    Etiqueta = new HashSet<Etiqueta>();
        //}

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

        //public virtual Curso IdCursoNavigation { get; set; }
        //public virtual Profesor IdProfesorNavigation { get; set; }
        //public virtual ICollection<CalEtiqueta> CalEtiqueta { get; set; }
        //public virtual ICollection<Etiqueta> Etiqueta { get; set; }
        //public virtual Curso Curso { get; set; }
        //public virtual Profesor Profesor { get; set; }
    }
}
