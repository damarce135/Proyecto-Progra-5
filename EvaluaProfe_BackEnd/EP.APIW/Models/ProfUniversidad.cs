using System;
using System.Collections.Generic;

#nullable disable

namespace EP.APIW.Models
{
    public partial class ProfUniversidad
    {
        public int IdProfUniversidad { get; set; }
        public int? IdProfesor { get; set; }
        public int? IdUniversidad { get; set; }

        public virtual Profesor IdProfesorNavigation { get; set; }
        public virtual Universidad IdUniversidadNavigation { get; set; }
    }
}
