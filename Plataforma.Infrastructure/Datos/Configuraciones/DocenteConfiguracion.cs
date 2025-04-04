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
    internal class DocenteConfiguracion : IEntityTypeConfiguration<Docente>
    {
        public void Configure(EntityTypeBuilder<Docente> builder)

        {
            builder.HasKey(e => e.Id).HasName("docente_pkey");

            builder.ToTable("docente");

            builder.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            builder.Property(e => e.Apellidos).HasColumnName("apellidos");
            builder.Property(e => e.EmailInstitucional).HasColumnName("email_institucional");
            builder.Property(e => e.Nombre).HasColumnName("nombre");
            builder.Property(e => e.NumeroIdentificacion).HasColumnName("numero_identificacion");
            builder.Property(e => e.TipoIdentificacion).HasColumnName("tipo_identificacion");
        }
    }

}
