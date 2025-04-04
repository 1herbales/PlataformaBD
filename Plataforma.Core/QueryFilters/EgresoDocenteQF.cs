using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plataforma.Core.QueryFilters
{
    public class EgresoDocenteQF
    {
        public string? ResolucionNumero { get; set; }

        public DateOnly? FechaResolucion { get; set; }

        public DateOnly? EgresoAPartirDe { get; set; }
    }
}
