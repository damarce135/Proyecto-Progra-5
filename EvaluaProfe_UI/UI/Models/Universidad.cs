using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
    public class Universidad
    {
        public Universidad()
        {
            Carrera = new HashSet<Carrera>();
            ProfUniversidad = new HashSet<ProfUniversidad>();
        }

        [Key]
        public int IdUniversidad { get; set; }
        public string NombreUniversidad { get; set; }

        public virtual ICollection<Carrera> Carrera { get; set; }
        public virtual ICollection<ProfUniversidad> ProfUniversidad { get; set; }
    }
}
