using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EP.DO.Objects
{
    public class Carrera
    {

        [Key]
        public int IdCarrera { get; set; }
        public string NombreCarrera { get; set; }

        public virtual ICollection<CursoCarrera> CursoCarreras { get; set; }
        public virtual ICollection<Curso> Cursos { get; set; }
    }
}
