using System;
using System.Collections.Generic;

namespace UI.Models
{
    public partial class Universidad
    {
        public Universidad()
        {
            Carrera = new HashSet<Carrera>();
            ProfUniversidad = new HashSet<ProfUniversidad>();
        }

        public int IdUniversidad { get; set; }
        public string NombreUniversidad { get; set; }

        public virtual ICollection<Carrera> Carrera { get; set; }
        public virtual ICollection<ProfUniversidad> ProfUniversidad { get; set; }
    }
}
