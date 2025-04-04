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
    internal class ProduccionAcademicaConfiguracion : IEntityTypeConfiguration<ProduccionAcademica>
    {
        public void Configure(EntityTypeBuilder<ProduccionAcademica> builder)
        {
            builder.HasKey(e => e.Id).HasName("produccion_academica_pkey");

            builder.ToTable("produccion_academica");

            builder.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            builder.Property(e => e.ActaNumero).HasColumnName("acta_numero");
            builder.Property(e => e.DocentePlantaId).HasColumnName("docente_planta_id");
            builder.Property(e => e.EfectosFiscales).HasColumnName("efectos_fiscales");
            builder.Property(e => e.FechaActa).HasColumnName("fecha_acta");
            builder.Property(e => e.FechaResolucion).HasColumnName("fecha_resolucion");
            builder.Property(e => e.IssnIsbn).HasColumnName("issn_isbn");
            builder.Property(e => e.NumeroAutores).HasColumnName("numero_autores");
            builder.Property(e => e.Observaciones).HasColumnName("observaciones");
            builder.Property(e => e.PuntosAsignados).HasColumnName("puntos_asignados");
            builder.Property(e => e.ResolucionNumero).HasColumnName("resolucion_numero");
            builder.Property(e => e.RevistaPostgradoPremioEditorial).HasColumnName("revista_postgrado_premio_editorial");
            builder.Property(e => e.TipoDeProducto).HasColumnName("tipo_de_producto");
            builder.Property(e => e.TipoDePuntos).HasColumnName("tipo_de_puntos");
            builder.Property(e => e.TituloDelProducto).HasColumnName("titulo_del_producto");

            builder.HasOne(d => d.DocentePlanta).WithMany(p => p.ProduccionAcademicas)
                .HasForeignKey(d => d.DocentePlantaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("produccion_academica_docente_planta_id_fkey");
        }
    }
}
