using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plataforma.Core.QueryFilters
{
    public class PregradoQF
    {
        public string? Titulo { get; set; } 
        public string? Universidad { get; set; }
        public DateOnly FechaFinalizacion { get; set; }
        public string? Pais { get; set; } 
    }
}
