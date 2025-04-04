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
    internal class DocenteDatoPersonalConfiguracion : IEntityTypeConfiguration<DocenteDatosPersonale>
    {
        public void Configure(EntityTypeBuilder<DocenteDatosPersonale> builder)
        {
            builder.HasKey(e => e.Id).HasName("docente_datos_personales_pkey");

            builder.ToTable("docente_datos_personales");

            builder.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            builder.Property(e => e.Departamento).HasColumnName("departamento");
            builder.Property(e => e.DireccionResidencia).HasColumnName("direccion_residencia");
            builder.Property(e => e.DocenteId).HasColumnName("docente_id");
            builder.Property(e => e.Edad).HasColumnName("edad");
            builder.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");
            builder.Property(e => e.LugarNacimientoMunicipio).HasColumnName("lugar_nacimiento_municipio");
            builder.Property(e => e.NumeroContacto).HasColumnName("numero_contacto");
            builder.Property(e => e.PaisProcedencia).HasColumnName("pais_procedencia");
            builder.Property(e => e.Sexo).HasColumnName("sexo");

            builder.HasOne(d => d.Docente).WithMany(p => p.DocenteDatosPersonales)
                .HasForeignKey(d => d.DocenteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("docente_datos_personales_docente_id_fkey");
        }
    }
}
