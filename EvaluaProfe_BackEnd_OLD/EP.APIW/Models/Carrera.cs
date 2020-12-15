using System;
using System.Collections.Generic;

#nullable disable

namespace EP.APIW.Models
{
    public partial class Carrera
    {
        public Carrera()
        {
            CursoCarreras = new HashSet<CursoCarrera>();
        }

        public int IdCarrera { get; set; }
        public string NombreCarrera { get; set; }

        public virtual ICollection<CursoCarrera> CursoCarreras { get; set; }
    }
}
