using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EP.DO.Objects
{
    public class ProfCurso
    {
        [Key]
        public int IdProfCurso { get; set; }
        public int IdProfesor { get; set; }
        public int IdCurso { get; set; }

        [ForeignKey("IdCurso")]
        public Curso Curso { get; set; }

        [ForeignKey("IdProfesor")]
        public Profesor Profesor { get; set; }
    }
}
