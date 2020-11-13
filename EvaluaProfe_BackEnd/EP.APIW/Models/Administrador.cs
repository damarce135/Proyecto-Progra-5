using System;
using System.Collections.Generic;

#nullable disable

namespace EP.APIW.Models
{
    public partial class Administrador
    {
        public int IdAdministrador { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public byte[] Contrasena { get; set; }
        public bool? Habilitado { get; set; }
    }
}
