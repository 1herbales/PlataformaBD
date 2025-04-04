using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plataforma.Core.Entidades;

namespace Plataforma.Core.DTOs
{
    public class DocentePlantumDTO
    {
        public long Id { get; set; }

        public long DocenteId { get; set; }

        public string? Escalafon { get; set; }

        public string? NumeroResolucionEscalafon { get; set; }

        public DateOnly? FechaResolucionEscalafon { get; set; }

        public string? Dedicacion { get; set; }

        public string? NivelAcademico { get; set; }

        public string? NumeroTarjetaProfesional { get; set; }

    }
}
