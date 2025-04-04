using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plataforma.Core.DTOs
{
    public class PregradoDTO
    {
        public long Id { get; set; }

        public long DocenteId { get; set; }

        public string Titulo { get; set; } = null!;

        public string Universidad { get; set; } = null!;

        public DateOnly FechaFinalizacion { get; set; }

        public string Pais { get; set; } = null!;

    }
}
