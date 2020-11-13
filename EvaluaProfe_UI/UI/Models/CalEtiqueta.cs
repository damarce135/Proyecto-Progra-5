using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
    public partial class CalEtiqueta
    {
        [Key]
        public int IdCalEtiqueta { get; set; }
        public int IdCalificacion { get; set; }
        public int IdEtiqueta { get; set; }

        public virtual Calificacion IdCalificacionNavigation { get; set; }
        public virtual Etiqueta IdEtiquetaNavigation { get; set; }
    }
}
