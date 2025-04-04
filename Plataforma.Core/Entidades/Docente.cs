using System;
using System.Collections.Generic;

namespace Plataforma.Core.Entidades;

public partial class Docente
{
    public long Id { get; set; }
    public string Apellidos { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string NumeroIdentificacion { get; set; } = null!;

    public string TipoIdentificacion { get; set; } = null!;

    public string EmailInstitucional { get; set; } = null!;

    public virtual DocenteCatedra? DocenteCatedra { get; set; }

    public virtual ICollection<DocenteDatosPersonale> DocenteDatosPersonales { get; set; } = new List<DocenteDatosPersonale>();

    public virtual ICollection<DocenteDetalle> DocenteDetalles { get; set; } = new List<DocenteDetalle>();

    public virtual DocentePlantum? DocentePlantum { get; set; }

    public virtual ICollection<Doctorado> Doctorados { get; set; } = new List<Doctorado>();

    public virtual ICollection<Especializacion> Especializacions { get; set; } = new List<Especializacion>();

    public virtual ICollection<Magister> Magisters { get; set; } = new List<Magister>();

    public virtual ICollection<Pregrado> Pregrados { get; set; } = new List<Pregrado>();
}
