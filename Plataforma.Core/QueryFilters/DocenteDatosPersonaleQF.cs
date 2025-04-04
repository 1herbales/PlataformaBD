using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plataforma.Core.QueryFilters
{
    public class DocenteDatosPersonaleQF
    {
        public DateOnly FechaNacimiento { get; set; }

        public string Sexo { get; set; } = null!;

        public int Edad { get; set; }

        public string LugarNacimientoMunicipio { get; set; } = null!;

        public string Departamento { get; set; } = null!;

        public string PaisProcedencia { get; set; } = null!;

        public string DireccionResidencia { get; set; } = null!;

        public string NumeroContacto { get; set; } = null!;

    }
}
