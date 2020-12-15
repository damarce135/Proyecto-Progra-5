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

        public ICollection<Calificacion> Calificaciones { get; set; }
        public ICollection<CursoCarrera> CursoCarreras { get; set; }
        public ICollection<ProfCurso> ProfCursos { get; set; }
    }
}
