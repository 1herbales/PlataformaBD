using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plataforma.Core.DTOs
{
    public class DoctoradoDTO
    {
        public long Id { get; set; }

        public long DocenteId { get; set; }

        public string? Titulo { get; set; }

        public string? Universidad { get; set; }

        public DateOnly? FechaFinalizacion { get; set; }

        public string? Pais { get; set; }

        public string? Convalidacion { get; set; }

        public string? ResolucionConvalidacion { get; set; }

        public DateOnly? FechaConvalidacion { get; set; }
    }
}
