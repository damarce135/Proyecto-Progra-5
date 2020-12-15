using System;
using System.Collections.Generic;

#nullable disable

namespace API.W.Models
{
    public partial class Etiquetum
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
