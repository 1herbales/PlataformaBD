using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plataforma.Core.DTOs
{
    public class CategoriaDocenteDTO
    {
        public long Id { get; set; }
        public long DocentePlantaId { get; set; }

        public DateOnly? FechaVinculacion { get; set; }

        public DateOnly? FechaAsistente { get; set; }

        public DateOnly? FechaAsociado { get; set; }

        public DateOnly? FechaTitular { get; set; }
    }
}
