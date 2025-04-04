using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plataforma.Core.Entidades;
using Plataforma.Core.QueryFilters;


namespace Plataforma.Core.Interfaces
{
    public interface IDocenteRepositorio
    {
        IEnumerable<Docente> GetDocentes();
        Task InsertarDocente(Docente docente);
        Task<Docente> GetDocente(long DocenteId);
        void ActualizarDocente(Docente docente);
        Task EliminarDocente(long DocenteId);

        IEnumerable<DocenteCatedra> GetDocenteCatedras();
        Task<DocenteCatedra> GetDocenteCatedra(long DocenteId);
        Task InsertarDocenteCatedra(DocenteCatedra docenteCatedra);
        void ActualizarDocenteCatedra(DocenteCatedra docenteCatedra);
        Task EliminarDocenteCatedra(long DocenteId);

        IEnumerable<DocenteDetalle> GetDocenteDetalles();
        Task<DocenteDetalle> GetDocenteDetalle(long DocenteId);
        Task InsertarDocenteDetalle(DocenteDetalle docenteDetalle);
        void ActualizarDocenteDetalle(DocenteDetalle docenteDetalle);
        Task EliminarDocenteDetalle(long DocenteId);

        IEnumerable<DocenteDatosPersonale> GetDatosPersonales();
        Task<DocenteDatosPersonale> GetDatoPersonal(long DocenteId);
        Task InsertarDatoPersonal(DocenteDatosPersonale datoPersonal);
        void ActualizarDatoPersonal(DocenteDatosPersonale datoPersonal);
        Task EliminarDatoPersonal(long DocenteId);
    }
}
