using System;
using System.Collections.Generic;

#nullable disable

namespace EP.APIW.Models
{
    public partial class Universidad
    {
        public Universidad()
        {
            Carreras = new HashSet<Carrera>();
            ProfUniversidads = new HashSet<ProfUniversidad>();
        }

        public int IdUniversidad { get; set; }
        public string NombreUniversidad { get; set; }

        public virtual ICollection<Carrera> Carreras { get; set; }
        public virtual ICollection<ProfUniversidad> ProfUniversidads { get; set; }
    }
}
