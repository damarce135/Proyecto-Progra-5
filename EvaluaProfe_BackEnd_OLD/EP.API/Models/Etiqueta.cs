﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EP.API.Models
{
    public class Etiqueta
    {
        //public Etiqueta()
        //{
        //    CalEtiqueta = new HashSet<CalEtiqueta>();
        //}

        [Key]
        public int IdEtiqueta { get; set; }
        public string NombreEtiqueta { get; set; }

        //public virtual ICollection<CalEtiqueta> CalEtiqueta { get; set; }
    }
}