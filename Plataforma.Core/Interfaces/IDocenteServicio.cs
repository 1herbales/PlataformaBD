using Plataforma.Core.CustomEntities;
using Plataforma.Core.Entidades;
using Plataforma.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Plataforma.Core.Interfaces
{
    public interface IDocenteServicio
    {
        PagedList<Docente> GetDocentes(DocenteQF docenteqf);
        Task InsertarDocente(Docente docente);
        Task<Docente> GetDocente(long DocenteId);
        Task<bool> ActualizarDocente(Docente docente);
        Task<bool> EliminarDocente(long DocenteId);

        PagedList<DocenteCatedra> GetDocenteCatedras(DocenteCatedraQF docenteCatedraqf);
        Task<DocenteCatedra> GetDocenteCatedra(long DocenteId);
        Task InsertarDocenteCatedra(DocenteCatedra docenteCatedra);
        Task<bool> ActualizarDocenteCatedra(DocenteCatedra docenteCatedra);
        Task<bool> EliminarDocenteCatedra(long DocenteId);

        PagedList<DocenteDetalle> GetDocenteDetalles(DocenteDetalleQF docenteDetalleqf);
        Task<DocenteDetalle> GetDocenteDetalle(long DocenteId);
        Task InsertarDocenteDetalle(DocenteDetalle docenteDetalle);
        Task<bool> ActualizarDocenteDetalle(DocenteDetalle docenteDetalle);
        Task<bool> EliminarDocenteDetalle(long DocenteId);

        PagedList<DocenteDatosPersonale> GetDatosPersonales(DocenteDatosPersonaleQF docenteDatosPersonaleqf);
        Task<DocenteDatosPersonale> GetDatoPersonal(long DocenteId);
        Task InsertarDatoPersonal(DocenteDatosPersonale datoPersonal);
        Task<bool> ActualizarDatoPersonal(DocenteDatosPersonale datoPersonal);
        Task<bool> EliminarDatoPersonal(long DocenteId);
    }
}