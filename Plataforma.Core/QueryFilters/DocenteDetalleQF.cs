using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plataforma.Core.QueryFilters
{
    public class DocenteDetalleQF : QueryFiltersBase
    {
        public string? Facultad { get; set; }

        public string? ProgramaAdscrito { get; set; }

        public string? Municipio { get; set; } 

        public string? Modalidad { get; set; }

       
    }
}
