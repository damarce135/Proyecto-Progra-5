using System;
using System.Collections.Generic;

#nullable disable

namespace EP.APIW.Models
{
    public partial class CalEtiquetum
    {
        public int IdCalEtiqueta { get; set; }
        public int? IdCalificacion { get; set; }
        public int? IdEtiqueta { get; set; }

        public virtual Calificacion IdCalificacionNavigation { get; set; }
        public virtual Etiquetum IdEtiquetaNavigation { get; set; }
    }
}
