using System;
using System.Collections.Generic;
using System.Text;

namespace DO.Objects
{
    public class Profesor
    {
        public Profesor()
        {
            Calificacions = new HashSet<Calificacion>();
        }

        public int IdProfesor { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }

        public virtual ICollection<Calificacion> Calificacions { get; set; }
    }
}
