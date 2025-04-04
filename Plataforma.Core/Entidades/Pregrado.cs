using System;
using System.Collections.Generic;

namespace Plataforma.Core.Entidades;

public partial class Pregrado
{
    public long Id { get; set; }

    public long DocenteId { get; set; }

    public string Titulo { get; set; } = null!;

    public string Universidad { get; set; } = null!;

    public DateOnly FechaFinalizacion { get; set; }

    public string Pais { get; set; } = null!;

    public virtual Docente Docente { get; set; } = null!;
}

