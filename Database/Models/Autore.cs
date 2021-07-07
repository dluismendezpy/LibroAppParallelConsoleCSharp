using System;
using System.Collections.Generic;

#nullable disable

namespace Database.Models
{
    public partial class Autore
    {
        public int AutorId { get; set; }
        public string NombreAutor { get; set; }
        public string CorreoElectronicoAutor { get; set; }
    }
}
