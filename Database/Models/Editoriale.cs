using System;
using System.Collections.Generic;

#nullable disable

namespace Database.Models
{
    public partial class Editoriale
    {
        public int EditorialId { get; set; }
        public string NombreEditorial { get; set; }
        public string TelefonoEditorial { get; set; }
        public string PaisEditorial { get; set; }
    }
}
