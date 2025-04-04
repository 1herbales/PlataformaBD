using System;
using System.Collections.Generic;

namespace Plataforma.Core.Entidades;

public partial class CategoriaDocente
{
    public long Id { get; set; }
    public long DocentePlantaId { get; set; }

    public DateOnly? FechaVinculacion { get; set; }

    public DateOnly? FechaAsistente { get; set; }

    public DateOnly? FechaAsociado { get; set; }

    public DateOnly? FechaTitular { get; set; }

    public virtual DocentePlantum DocentePlanta { get; set; } = null!;
}
