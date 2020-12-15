using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
    public partial class Etiqueta
    {
        public Etiqueta()
        {
            Calificacions = new HashSet<Calificacion>();
        }

        [Key]
        public int IdEtiqueta { get; set; }

        [Display(Name = "Tag")]
        public string NombreEtiqueta { get; set; }

        public virtual ICollection<Calificacion> Calificacions { get; set; }
    }
}
