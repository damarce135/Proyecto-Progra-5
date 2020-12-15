using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
    public partial class Carrera
    {
        public Carrera()
        {
            Calificacions = new HashSet<Calificacion>();
            Cursos = new HashSet<Curso>();
        }

        [Key]
        public int IdCarrera { get; set; }

        [Display(Name = "Nombre")]
        public string NombreCarrera { get; set; }

        public virtual ICollection<Calificacion> Calificacions { get; set; }
        public virtual ICollection<Curso> Cursos { get; set; }
    }
}
