using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plataforma.Core.QueryFilters
{
    public class CategoriaDocenteQF
    {

        public DateOnly? FechaVinculacion { get; set; }

        public DateOnly? FechaAsistente { get; set; }

        public DateOnly? FechaAsociado { get; set; }

        public DateOnly? FechaTitular { get; set; }
    }
}
