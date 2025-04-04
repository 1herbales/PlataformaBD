using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plataforma.Core.DTOs
{
   public class DocenteDetalleDTO
    {
        public long Id { get; set; }
        public string Facultad { get; set; } = null!;

        public string ProgramaAdscrito { get; set; } = null!;

        public string Municipio { get; set; } = null!;

        public string Modalidad { get; set; } = null!;

        public long DocenteId { get; set; }

    }
}
