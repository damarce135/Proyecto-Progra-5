using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
    public partial class ProfUniversidad
    {
        [Key]
        public int IdProfUniversidad { get; set; }
        public int IdProfesor { get; set; }
        public int IdUniversidad { get; set; }

        public virtual Profesor IdProfesorNavigation { get; set; }
        public virtual Universidad IdUniversidadNavigation { get; set; }
    }
}
