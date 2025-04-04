using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plataforma.Core.QueryFilters
{
    public class ProduccionAcademicaQF
    {
        public string? ActaNumero { get; set; }

        public DateOnly? FechaActa { get; set; }

        public string? TipoDePuntos { get; set; }

        public string? TipoDeProducto { get; set; }

        public string? RevistaPostgradoPremioEditorial { get; set; }

        public string? IssnIsbn { get; set; }

        public string? TituloDelProducto { get; set; }

        public decimal? PuntosAsignados { get; set; }

        public int? NumeroAutores { get; set; }

        public string? EfectosFiscales { get; set; }

        public string? ResolucionNumero { get; set; }

        public DateOnly? FechaResolucion { get; set; }

        public string? Observaciones { get; set; }
    }
}
