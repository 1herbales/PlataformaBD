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
    internal class PregradoConfiguracion : IEntityTypeConfiguration<Pregrado>
    {
        public void Configure(EntityTypeBuilder<Pregrado> builder)
        {
            builder.HasKey(e => e.Id).HasName("pregrado_pkey");

            builder.ToTable("pregrado");

            builder.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            builder.Property(e => e.DocenteId).HasColumnName("docente_id");
            builder.Property(e => e.FechaFinalizacion).HasColumnName("fecha_finalizacion");
            builder.Property(e => e.Pais).HasColumnName("pais");
            builder.Property(e => e.Titulo).HasColumnName("titulo");
            builder.Property(e => e.Universidad).HasColumnName("universidad");

            builder.HasOne(d => d.Docente).WithMany(p => p.Pregrados)
                .HasForeignKey(d => d.DocenteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pregrado_docente_id_fkey");
        }
    }
}
