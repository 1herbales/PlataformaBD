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
    internal class DocentePlantumConfiguracion : IEntityTypeConfiguration<DocentePlantum>
    {
        public void Configure(EntityTypeBuilder<DocentePlantum> builder)
        {
            builder.HasKey(e => e.Id).HasName("docente_planta_pkey");

            builder.ToTable("docente_planta");

            builder.HasIndex(e => e.DocenteId, "docente_planta_docente_id_key").IsUnique();

            builder.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            builder.Property(e => e.Dedicacion).HasColumnName("dedicacion");
            builder.Property(e => e.DocenteId).HasColumnName("docente_id");
            builder.Property(e => e.Escalafon).HasColumnName("escalafon");
            builder.Property(e => e.FechaResolucionEscalafon).HasColumnName("fecha_resolucion_escalafon");
            builder.Property(e => e.NivelAcademico).HasColumnName("nivel_academico");
            builder.Property(e => e.NumeroResolucionEscalafon).HasColumnName("numero_resolucion_escalafon");
            builder.Property(e => e.NumeroTarjetaProfesional).HasColumnName("numero_tarjeta_profesional");

            builder.HasOne(d => d.Docente).WithOne(p => p.DocentePlantum)
                .HasForeignKey<DocentePlantum>(d => d.DocenteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("docente_planta_docente_id_fkey");
        }
    }
}
