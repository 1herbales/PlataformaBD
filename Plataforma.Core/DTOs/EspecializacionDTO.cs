using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plataforma.Core.DTOs
{
    public class EspecializacionDTO
    {
        public long Id { get; set; }
        public long DocenteId { get; set; }

        public string? Titulo { get; set; }

        public string? Universidad { get; set; }

        public DateOnly? FechaFinalizacion { get; set; }
    }
}
