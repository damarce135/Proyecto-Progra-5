using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EP.DO.Objects
{
    public class Carrera
    {
        public Carrera()
        {
            CursoCarrera = new HashSet<CursoCarrera>();
        }

        [Key]
        public int IdCarrera { get; set; }
        public string NombreCarrera { get; set; }
        public int IdUniversidad { get; set; }

        public virtual Universidad IdUniversidadNavigation { get; set; }
        public virtual ICollection<CursoCarrera> CursoCarrera { get; set; }
    }
}
