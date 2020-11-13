using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EP.DO.Objects
{
    public class ProfCurso
    {
        [Key]
        public int IdProfCurso { get; set; }
        public int IdProfesor { get; set; }
        public int IdCurso { get; set; }

        public virtual Curso IdCursoNavigation { get; set; }
        public virtual Profesor IdProfesorNavigation { get; set; }
    }
}
