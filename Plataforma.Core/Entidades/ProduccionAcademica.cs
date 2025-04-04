using System;
using System.Collections.Generic;

namespace Plataforma.Core.Entidades;

public partial class ProduccionAcademica
{
    public long Id { get; set; }

    public long DocentePlantaId { get; set; }

    public string? ActaNumero { get; set; }

    public DateOnly? FechaActa { get; set; }

    public string? TipoDePuntos { get; set; }

    public string? TipoDeProducto { get; set; }

    public string? RevistaPostgradoPremioEditorial { get; set; }

    public string? IssnIsbn { get; set; }

    public string? TituloDelProducto { get; set; }

    public decimal? PuntosAsignados { get; set; }

    public int? NumeroAutores { get; set; }

    public string? EfectosFiscales { get; set; }

    public string? ResolucionNumero { get; set; }

    public DateOnly? FechaResolucion { get; set; }

    public string? Observaciones { get; set; }

    public virtual DocentePlantum DocentePlanta { get; set; } = null!;
}
