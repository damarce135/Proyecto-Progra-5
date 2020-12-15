using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EP.DO.Objects
{
    public class CursoCarrera
    {
        [Key]
        public int IdCursoCarrera { get; set; }
        public int IdCurso { get; set; }
        public int IdCarrera { get; set; }

        [ForeignKey("IdCarrera")]
        public Carrera Carrera { get; set; }

        [ForeignKey("IdCurso")]
        public Curso Curso { get; set; }
    }
}
