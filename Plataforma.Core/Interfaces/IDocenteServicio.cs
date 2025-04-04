using Plataforma.Core.Entidades;
using Plataforma.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Plataforma.Core.Interfaces
{
    public interface IDocenteServicio
    {
        IEnumerable<Docente> GetDocentes(DocenteQF docenteqf);
        Task InsertarDocente(Docente docente);
        Task<Docente> GetDocente(long DocenteId);
        Task<bool> ActualizarDocente(Docente docente);
        Task<bool> EliminarDocente(long DocenteId);

        IEnumerable<DocenteCatedra> GetDocenteCatedras();
        Task<DocenteCatedra> GetDocenteCatedra(long DocenteId);
        Task InsertarDocenteCatedra(DocenteCatedra docenteCatedra);
        Task<bool> ActualizarDocenteCatedra(DocenteCatedra docenteCatedra);
        Task<bool> EliminarDocenteCatedra(long DocenteId);

        IEnumerable<DocenteDetalle> GetDocenteDetalles();
        Task<DocenteDetalle> GetDocenteDetalle(long DocenteId);
        Task InsertarDocenteDetalle(DocenteDetalle docenteDetalle);
        Task<bool> ActualizarDocenteDetalle(DocenteDetalle docenteDetalle);
        Task<bool> EliminarDocenteDetalle(long DocenteId);




    }
}