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
    internal class DocenteCatedraConfiguracion : IEntityTypeConfiguration<DocenteCatedra>
    {
        public void Configure(EntityTypeBuilder<DocenteCatedra> builder)
        {
            builder.HasKey(e => e.Id).HasName("docente_catedra_pkey");

            builder.ToTable("docente_catedra");

            builder.HasIndex(e => e.DocenteId, "docente_catedra_docente_id_key").IsUnique();

            builder.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            builder.Property(e => e.DocenteActivo).HasColumnName("docente_activo");
            builder.Property(e => e.DocenteId).HasColumnName("docente_id");
            builder.Property(e => e.FechaInicioContrato).HasColumnName("fecha_inicio_contrato");
            builder.Property(e => e.FechaResolucion).HasColumnName("fecha_resolucion");
            builder.Property(e => e.HorasContratadas).HasColumnName("horas_contratadas");
            builder.Property(e => e.NumeroTarjetaProfesional).HasColumnName("numero_tarjeta_profesional");
            builder.Property(e => e.ResolucionVinculacion).HasColumnName("resolucion_vinculacion");

            builder.HasOne(d => d.Docente).WithOne(p => p.DocenteCatedra)
                .HasForeignKey<DocenteCatedra>(d => d.DocenteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("docente_catedra_docente_id_fkey");
        }
    }
}
