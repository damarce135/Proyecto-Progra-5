using System;
using System.Collections.Generic;

namespace UI.Models
{
    public partial class Etiqueta
    {
        public Etiqueta()
        {
            CalEtiqueta = new HashSet<CalEtiqueta>();
        }

        public int IdEtiqueta { get; set; }
        public string NombreEtiqueta { get; set; }

        public virtual ICollection<CalEtiqueta> CalEtiqueta { get; set; }
    }
}
