using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UI.Models
{
    public partial class Solicitud
    {

        [Key]
        public int IdSolicitud { get; set; }

        [Display(Name = "Asunto")]
        public string Asunto { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

    }
}
