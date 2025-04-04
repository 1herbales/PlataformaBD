using System;
using System.Collections.Generic;

namespace Plataforma.Core.Entidades;

public partial class DocenteCatedra
{

    public long Id { get; set; }
    public long DocenteId { get; set; }

    public int? HorasContratadas { get; set; }

    public DateOnly? FechaInicioContrato { get; set; }

    public string? ResolucionVinculacion { get; set; }

    public DateOnly? FechaResolucion { get; set; }

    public bool? DocenteActivo { get; set; }

    public string? NumeroTarjetaProfesional { get; set; }

    public virtual Docente Docente { get; set; } = null!;
}
