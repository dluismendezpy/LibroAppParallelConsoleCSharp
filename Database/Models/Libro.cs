using System;
using System.Collections.Generic;

#nullable disable

namespace Database.Models
{
    public partial class Libro
    {
        public int LibroId { get; set; }
        public string NombreLibro { get; set; }
        public int AnoPublicacionLibro { get; set; }
        public string CategoriaLibro { get; set; }
        public string AutorLibro { get; set; }
        public string EditorialLibro { get; set; }
    }
}
