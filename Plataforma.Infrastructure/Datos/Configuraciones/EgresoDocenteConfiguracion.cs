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
    internal class EgresoDocenteConfiguracion : IEntityTypeConfiguration<EgresoDocente>
    {
        public void Configure(EntityTypeBuilder<EgresoDocente> builder)
        {
            builder.HasKey(e => e.Id).HasName("egreso_docente_pkey");

            builder.ToTable("egreso_docente");

            builder.HasIndex(e => e.DocentePlantaId, "egreso_docente_docente_planta_id_key").IsUnique();

            builder.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            builder.Property(e => e.DocentePlantaId).HasColumnName("docente_planta_id");
            builder.Property(e => e.EgresoAPartirDe).HasColumnName("egreso_a_partir_de");
            builder.Property(e => e.FechaResolucion).HasColumnName("fecha_resolucion");
            builder.Property(e => e.ResolucionNumero).HasColumnName("resolucion_numero");

            builder.HasOne(d => d.DocentePlanta).WithOne(p => p.EgresoDocente)
                .HasForeignKey<EgresoDocente>(d => d.DocentePlantaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("egreso_docente_docente_planta_id_fkey");
        }
    }
}
