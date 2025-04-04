using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Plataforma.Core.Entidades;

namespace Plataforma.Infrastructure.Datos.Configuraciones
{
    internal class CategoriaDocenteConfiguracion : IEntityTypeConfiguration<CategoriaDocente>
    {
        public void Configure(EntityTypeBuilder<CategoriaDocente> builder)
        {
            builder.HasKey(e => e.Id).HasName("categoria_docente_pkey");

            builder.ToTable("categoria_docente");

            builder.HasIndex(e => new { e.DocentePlantaId, e.FechaAsistente }, "unique_asistente").IsUnique();

            builder.HasIndex(e => new { e.DocentePlantaId, e.FechaAsociado }, "unique_asociado").IsUnique();

            builder.HasIndex(e => new { e.DocentePlantaId, e.FechaTitular }, "unique_titular").IsUnique();

            builder.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            builder.Property(e => e.DocentePlantaId).HasColumnName("docente_planta_id");
            builder.Property(e => e.FechaAsistente).HasColumnName("fecha_asistente");
            builder.Property(e => e.FechaAsociado).HasColumnName("fecha_asociado");
            builder.Property(e => e.FechaTitular).HasColumnName("fecha_titular");
            builder.Property(e => e.FechaVinculacion).HasColumnName("fecha_vinculacion");

            builder.HasOne(d => d.DocentePlanta).WithMany(p => p.CategoriaDocentes)
                .HasForeignKey(d => d.DocentePlantaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("categoria_docente_docente_planta_id_fkey");

        }

    }
}
