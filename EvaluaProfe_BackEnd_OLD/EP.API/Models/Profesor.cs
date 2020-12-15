using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EP.API.Models
{
    public class Profesor
    {
        //public Profesor()
        //{
        //    Calificacion = new HashSet<Calificacion>();
        //    ProfCurso = new HashSet<ProfCurso>();
        //    Curso = new HashSet<Curso>();

        //}

        [Key]
        public int IdProfesor { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }

        //public virtual ICollection<Calificacion> Calificacion { get; set; }
        //public virtual ICollection<ProfCurso> ProfCurso { get; set; }
        //public virtual ICollection<Curso> Curso { get; set; }
    }
}
