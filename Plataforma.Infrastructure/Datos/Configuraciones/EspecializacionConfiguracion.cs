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
    internal class EspecializacionConfiguracion :IEntityTypeConfiguration<Especializacion>
    {
        public void Configure(EntityTypeBuilder<Especializacion> builder)
        {
            builder.HasKey(e => e.Id).HasName("especializacion_pkey");

            builder.ToTable("especializacion");

            builder.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            builder.Property(e => e.DocenteId).HasColumnName("docente_id");
            builder.Property(e => e.FechaFinalizacion).HasColumnName("fecha_finalizacion");
            builder.Property(e => e.Titulo).HasColumnName("titulo");
            builder.Property(e => e.Universidad).HasColumnName("universidad");

            builder.HasOne(d => d.Docente).WithMany(p => p.Especializacions)
                .HasForeignKey(d => d.DocenteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("especializacion_docente_id_fkey");
        }
    }
}
