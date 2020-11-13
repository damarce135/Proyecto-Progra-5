using System;
using System.Collections.Generic;

namespace UI.Models
{
    public partial class ProfCurso
    {
        public int IdProfCurso { get; set; }
        public int? IdProfesor { get; set; }
        public int? IdCurso { get; set; }

        public virtual Curso IdCursoNavigation { get; set; }
        public virtual Profesor IdProfesorNavigation { get; set; }
    }
}
