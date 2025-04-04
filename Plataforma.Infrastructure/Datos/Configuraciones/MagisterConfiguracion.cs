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
    internal class MagisterConfiguracion : IEntityTypeConfiguration<Magister>
    {
        public void Configure(EntityTypeBuilder<Magister> builder)
        {
            builder.HasKey(e => e.Id).HasName("magister_pkey");

            builder.ToTable("magister");

            builder.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            builder.Property(e => e.Convalidacion).HasColumnName("convalidacion");
            builder.Property(e => e.DocenteId).HasColumnName("docente_id");
            builder.Property(e => e.FechaConvalidacion).HasColumnName("fecha_convalidacion");
            builder.Property(e => e.FechaFinalizacion).HasColumnName("fecha_finalizacion");
            builder.Property(e => e.Pais).HasColumnName("pais");
            builder.Property(e => e.ResolucionConvalidacion).HasColumnName("resolucion_convalidacion");
            builder.Property(e => e.Titulo).HasColumnName("titulo");
            builder.Property(e => e.Universidad).HasColumnName("universidad");

            builder.HasOne(d => d.Docente).WithMany(p => p.Magisters)
                .HasForeignKey(d => d.DocenteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("magister_docente_id_fkey");
        }
    }
}
