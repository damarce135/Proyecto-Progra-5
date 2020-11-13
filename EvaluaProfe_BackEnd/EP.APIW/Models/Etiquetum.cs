using System;
using System.Collections.Generic;

#nullable disable

namespace EP.APIW.Models
{
    public partial class Etiquetum
    {
        public Etiquetum()
        {
            CalEtiqueta = new HashSet<CalEtiquetum>();
        }

        public int IdEtiqueta { get; set; }
        public string NombreEtiqueta { get; set; }

        public virtual ICollection<CalEtiquetum> CalEtiqueta { get; set; }
    }
}
