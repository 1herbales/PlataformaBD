using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plataforma.Core.QueryFilters
{
    public class DocentePlantumQF
    {
        public string? Escalafon { get; set; }

        public string? NumeroResolucionEscalafon { get; set; }

        public DateOnly? FechaResolucionEscalafon { get; set; }

        public string? Dedicacion { get; set; }

        public string? NivelAcademico { get; set; }

        public string? NumeroTarjetaProfesional { get; set; }
    }
}
