using System;
using System.Collections.Generic;
using System.Text;
using Plataforma.Core.Entidades;
using System.Text.Json.Serialization;




namespace Plataforma.Core.DTOs
{
    public class DocenteCatedraDTO
    {
        public long Id { get; set; }

        public long DocenteId { get; set; }

        public int? HorasContratadas { get; set; }

        public DateOnly? FechaInicioContrato { get; set; }

        public string? ResolucionVinculacion { get; set; }

        public DateOnly? FechaResolucion { get; set; }

        public bool? DocenteActivo { get; set; }

        public string? NumeroTarjetaProfesional { get; set; }
    }
}
