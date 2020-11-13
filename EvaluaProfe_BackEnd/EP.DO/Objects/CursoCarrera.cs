using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EP.DO.Objects
{
    public class CursoCarrera
    {
        [Key]
        public int IdCursoCarrera { get; set; }
        public int IdCurso { get; set; }
        public int IdCarrera { get; set; }

        public virtual Carrera IdCarreraNavigation { get; set; }
        public virtual Curso IdCursoNavigation { get; set; }
    }
}
