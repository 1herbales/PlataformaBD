using System;
using System.Collections.Generic;

namespace Plataforma.Core.Entidades;

public partial class DocentePlantum
{

    public long Id { get; set; }
    public long DocenteId { get; set; }

    public string? Escalafon { get; set; }

    public string? NumeroResolucionEscalafon { get; set; }

    public DateOnly? FechaResolucionEscalafon { get; set; }

    public string? Dedicacion { get; set; }

    public string? NivelAcademico { get; set; }

    public string? NumeroTarjetaProfesional { get; set; }

    public virtual ICollection<CategoriaDocente> CategoriaDocentes { get; set; } = new List<CategoriaDocente>();

    public virtual Docente Docente { get; set; } = null!;

    public virtual EgresoDocente? EgresoDocente { get; set; }

    public virtual ICollection<ProduccionAcademica> ProduccionAcademicas { get; set; } = new List<ProduccionAcademica>();
}
