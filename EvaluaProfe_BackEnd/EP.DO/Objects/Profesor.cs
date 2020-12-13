using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EP.DO.Objects
{
    public class Profesor
    {

        [Key]
        public int IdProfesor { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }

        public virtual ICollection<Calificacion> Calificaciones { get; set; }
        public virtual ICollection<ProfCurso> ProfCursos { get; set; }
        public virtual ICollection<Curso> Cursos { get; set; }
    }
}
