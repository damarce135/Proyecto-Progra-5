using System;
using System.Collections.Generic;
using System.Text;

namespace DO.Objects
{
    public class Carrera
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
