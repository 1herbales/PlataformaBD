using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Plataforma.Core.Entidades;
using Plataforma.Infrastructure.Datos.Configuraciones;


namespace Plataforma.Infrastructure.Datos;

public partial class UniversidadContext : DbContext
{
    public UniversidadContext()
    {
    }

    public UniversidadContext(DbContextOptions<UniversidadContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CategoriaDocente> CategoriaDocentes { get; set; }

    public virtual DbSet<Docente> Docentes { get; set; }

    public virtual DbSet<DocenteCatedra> DocenteCatedras { get; set; }
    
    public virtual DbSet<DocenteDatosPersonale> DocenteDatosPersonales { get; set; }

    public virtual DbSet<DocenteDetalle> DocenteDetalles { get; set; }

    public virtual DbSet<DocentePlantum> DocentePlanta { get; set; }

    public virtual DbSet<Doctorado> Doctorados { get; set; }

    public virtual DbSet<EgresoDocente> EgresoDocentes { get; set; }

    public virtual DbSet<Especializacion> Especializacions { get; set; }

    public virtual DbSet<Magister> Magisters { get; set; }

    public virtual DbSet<Pregrado> Pregrados { get; set; }

    public virtual DbSet<ProduccionAcademica> ProduccionAcademicas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CategoriaDocenteConfiguracion());
        modelBuilder.ApplyConfiguration(new DocenteCatedraConfiguracion());
        modelBuilder.ApplyConfiguration(new DocenteConfiguracion());
        modelBuilder.ApplyConfiguration(new DocenteDatoPersonalConfiguracion());
        modelBuilder.ApplyConfiguration(new DocenteDetalleConfiguracion());
        modelBuilder.ApplyConfiguration(new DocentePlantumConfiguracion());
        modelBuilder.ApplyConfiguration(new DoctoradoConfiguracion());
        modelBuilder.ApplyConfiguration(new EgresoDocenteConfiguracion());
        modelBuilder.ApplyConfiguration(new EspecializacionConfiguracion());
        modelBuilder.ApplyConfiguration(new MagisterConfiguracion());
        modelBuilder.ApplyConfiguration(new PregradoConfiguracion());
        modelBuilder.ApplyConfiguration(new ProduccionAcademicaConfiguracion());
    }


}
