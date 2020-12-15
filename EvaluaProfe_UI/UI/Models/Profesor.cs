using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UI.Models
{
    public partial class Profesor
    {
        public Profesor()
        {
            Calificacions = new HashSet<Calificacion>();
        }

        [Key]
        public int IdProfesor { get; set; }
        public string Nombre { get; set; }

        [Display(Name = "Primer Apellido")]
        public string Apellido1 { get; set; }

        [Display(Name = "Segundo Apellido")]
        public string Apellido2 { get; set; }

        public virtual ICollection<Calificacion> Calificacions { get; set; }

        [NotMapped]
        public string Fullname => string.Format("{0} {1} {2}", Nombre, Apellido1, Apellido2);
    }
}
