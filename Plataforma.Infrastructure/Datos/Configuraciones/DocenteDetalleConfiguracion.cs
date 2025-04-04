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
    internal class DocenteDetalleConfiguracion : IEntityTypeConfiguration<DocenteDetalle>
    {
        public void Configure(EntityTypeBuilder<DocenteDetalle> builder)
        {
            builder.HasKey(e => e.Id).HasName("docente_detalle_pkey");

            builder.ToTable("docente_detalle");

            builder.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            builder.Property(e => e.DocenteId).HasColumnName("docente_id");
            builder.Property(e => e.Facultad).HasColumnName("facultad");
            builder.Property(e => e.Modalidad).HasColumnName("modalidad");
            builder.Property(e => e.Municipio).HasColumnName("municipio");
            builder.Property(e => e.ProgramaAdscrito).HasColumnName("programa_adscrito");

            builder.HasOne(d => d.Docente).WithMany(p => p.DocenteDetalles)
                .HasForeignKey(d => d.DocenteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("docente_detalle_docente_id_fkey");

        }
    }
}
