using System;
using System.Collections.Generic;

namespace Plataforma.Core.Entidades;

public partial class EgresoDocente
{

    public long Id { get; set; }
    public long DocentePlantaId { get; set; }

    public string? ResolucionNumero { get; set; }

    public DateOnly? FechaResolucion { get; set; }

    public DateOnly? EgresoAPartirDe { get; set; }

    public virtual DocentePlantum DocentePlanta { get; set; } = null!;
}
