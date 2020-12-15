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

        public ICollection<CursoCarrera> CursoCarreras { get; set; }
        public ICollection<Curso> Cursos { get; set; }

    }
}
