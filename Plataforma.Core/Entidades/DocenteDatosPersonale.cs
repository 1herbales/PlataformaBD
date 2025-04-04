using System;
using System.Collections.Generic;

namespace Plataforma.Core.Entidades;

public partial class DocenteDatosPersonale
{

    public long Id { get; set; }
    public DateOnly FechaNacimiento { get; set; }

    public string Sexo { get; set; } = null!;

    public int Edad { get; set; }

    public string LugarNacimientoMunicipio { get; set; } = null!;

    public string Departamento { get; set; } = null!;

    public string PaisProcedencia { get; set; } = null!;

    public string DireccionResidencia { get; set; } = null!;

    public string NumeroContacto { get; set; } = null!;

    public long DocenteId { get; set; }

    public virtual Docente Docente { get; set; } = null!;


}
