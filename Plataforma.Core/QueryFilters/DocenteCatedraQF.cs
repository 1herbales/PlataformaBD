using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plataforma.Core.QueryFilters
{
    public class DocenteCatedraQF
    {
        public int? HorasContratadas { get; set; }

        public DateOnly? FechaInicioContrato { get; set; }

        public string? ResolucionVinculacion { get; set; }

        public DateOnly? FechaResolucion { get; set; }

        public bool? DocenteActivo { get; set; }

        public string? NumeroTarjetaProfesional { get; set; }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
