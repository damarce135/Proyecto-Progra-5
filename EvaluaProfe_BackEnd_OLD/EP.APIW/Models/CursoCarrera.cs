using System;
using System.Collections.Generic;

#nullable disable

namespace EP.APIW.Models
{
    public partial class CursoCarrera
    {
        public int IdCursoCarrera { get; set; }
        public int? IdCurso { get; set; }
        public int? IdCarrera { get; set; }

        public virtual Carrera IdCarreraNavigation { get; set; }
        public virtual Curso IdCursoNavigation { get; set; }
    }
}
