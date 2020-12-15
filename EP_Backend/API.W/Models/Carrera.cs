using System;
using System.Collections.Generic;

#nullable disable

namespace API.W.Models
{
    public partial class Carrera
    {
        public Carrera()
        {
            Calificacions = new HashSet<Calificacion>();
            Cursos = new HashSet<Curso>();
        }

        public int IdCarrera { get; set; }
        public string NombreCarrera { get; set; }

        public virtual ICollection<Calificacion> Calificacions { get; set; }
        public virtual ICollection<Curso> Cursos { get; set; }
    }
}
