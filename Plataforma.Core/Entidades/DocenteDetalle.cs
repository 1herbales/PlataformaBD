using System;
using System.Collections.Generic;

namespace Plataforma.Core.Entidades;

public partial class DocenteDetalle
{

    public long Id { get; set; }
    public string Facultad { get; set; } = null!;

    public string ProgramaAdscrito { get; set; } = null!;

    public string Municipio { get; set; } = null!;

    public string Modalidad { get; set; } = null!;

    public long DocenteId { get; set; }

    public virtual Docente Docente { get; set; } = null!;
}
