using System;
using System.Collections.Generic;

namespace Plataforma.Core.Entidades;

public partial class Especializacion
{

    public long Id { get; set; }
    public long DocenteId { get; set; }

    public string? Titulo { get; set; }

    public string? Universidad { get; set; }

    public DateOnly? FechaFinalizacion { get; set; }

    public virtual Docente Docente { get; set; } = null!;
}
