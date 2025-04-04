using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Plataforma.Core.DTOs
{
    public class DocenteDTO
    {
        public long Id { get; set; }

        public string Apellidos { get; set; } = null!;

        public string Nombre { get; set; } = null!;

        public string NumeroIdentificacion { get; set; } = null!;

        public string TipoIdentificacion { get; set; } = null!;

        public string EmailInstitucional { get; set; } = null!;

    }
}
