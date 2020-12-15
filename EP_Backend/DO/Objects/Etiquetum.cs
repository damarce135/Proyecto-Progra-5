using System;
using System.Collections.Generic;
using System.Text;

namespace DO.Objects
{
    public class Etiquetum
    {
        public Etiquetum()
        {
            Calificacions = new HashSet<Calificacion>();
        }

        public int IdEtiqueta { get; set; }
        public string NombreEtiqueta { get; set; }

        public virtual ICollection<Calificacion> Calificacions { get; set; }
    }
}
