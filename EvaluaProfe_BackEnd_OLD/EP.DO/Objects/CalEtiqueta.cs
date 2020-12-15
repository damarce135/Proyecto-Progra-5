using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EP.DO.Objects
{
    public class CalEtiqueta
    {
        [Key]
        public int IdCalEtiqueta { get; set; }
        public int IdCalificacion { get; set; }
        public int IdEtiqueta { get; set; }

        [ForeignKey("IdCalificacion")]
        public virtual Calificacion Calificacion { get; set; }

        [ForeignKey("IdEtiqueta")]
        public virtual Etiqueta Etiqueta { get; set; }

        //public virtual Calificacion IdCalificacionNavigation { get; set; }
        //public virtual Etiqueta IdEtiquetaNavigation { get; set; }
    }
}
