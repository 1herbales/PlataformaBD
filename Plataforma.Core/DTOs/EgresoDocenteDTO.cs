using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plataforma.Core.Entidades;

namespace Plataforma.Core.DTOs
{
   public class EgresoDocenteDTO
    {
        public long Id { get; set; }
        public long DocentePlantaId { get; set; }

        public string? ResolucionNumero { get; set; }

        public DateOnly? FechaResolucion { get; set; }

        public DateOnly? EgresoAPartirDe { get; set; }

        
    }
}
