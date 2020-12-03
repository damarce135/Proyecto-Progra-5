using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
    public partial class Carrera
    {
        public Carrera()
        {
            CursoCarrera = new HashSet<CursoCarrera>();
        }

        [Key]
        public int IdCarrera { get; set; }
        public string NombreCarrera { get; set; }

        public virtual ICollection<CursoCarrera> CursoCarrera { get; set; }
    }
}
