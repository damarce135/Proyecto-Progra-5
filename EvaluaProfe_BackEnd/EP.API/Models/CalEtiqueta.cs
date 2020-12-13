using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EP.API.Models
{
    public class CalEtiqueta
    {
        [Key]
        public int IdCalEtiqueta { get; set; }
        public int IdCalificacion { get; set; }
        public int IdEtiqueta { get; set; }

        //public virtual Calificacion IdCalificacionNavigation { get; set; }
        //public virtual Etiqueta IdEtiquetaNavigation { get; set; }
    }
}
