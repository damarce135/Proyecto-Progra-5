using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EP.DO.Objects
{
    public class Universidad
    { 
        [Key]
        public int idUniversidad { get; set; }

        [Required]
        public String nombreUniversidad { get; set; } 
    }
}
