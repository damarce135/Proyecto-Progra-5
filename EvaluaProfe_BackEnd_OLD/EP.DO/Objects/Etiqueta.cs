using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EP.DO.Objects
{
    public class Etiqueta
    {

        [Key]
        public int IdEtiqueta { get; set; }
        public string NombreEtiqueta { get; set; }

        public ICollection<CalEtiqueta> CalEtiquetas { get; set; }
    }
}
