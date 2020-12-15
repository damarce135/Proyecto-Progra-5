using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Curso
    {
        public int IdCurso { get; set; }
        public string NombreCurso { get; set; }
        public int? IdCarrera { get; set; }

        public virtual Carrera Carrera { get; set; }
    }
}
