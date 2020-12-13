using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EP.DO.Objects
{
    public class Curso
    {

        [Key]
        public int IdCurso { get; set; }
        public string NombreCurso { get; set; }

        public virtual ICollection<Calificacion> Calificaciones { get; set; }
        public virtual ICollection<CursoCarrera> CursoCarreras { get; set; }
        public virtual ICollection<ProfCurso> ProfCursos { get; set; }
    }
}
