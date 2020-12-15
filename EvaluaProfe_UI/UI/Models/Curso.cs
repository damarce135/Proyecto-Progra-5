using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
    public partial class Curso
    {
        public Curso()
        {
            Calificacions = new HashSet<Calificacion>();
        }

        [Key]
        public int IdCurso { get; set; }

        [Display(Name = "Nombre")]
        public string NombreCurso { get; set; }

        [Display(Name = "Carrera")]
        public int? IdCarrera { get; set; }

        public virtual Carrera Carrera { get; set; }
        public virtual ICollection<Calificacion> Calificacions { get; set; }
    }
}
