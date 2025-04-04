using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plataforma.Core.Entidades;

namespace Plataforma.Core.Interfaces
{
    public interface IDocentePlantumRepositorio
    {
        IEnumerable<EgresoDocente> GetEgresos();
        IEnumerable<DocentePlantum> GetDocentesPlantum();
        IEnumerable<ProduccionAcademica> GetProducciones();
        IEnumerable<CategoriaDocente> GetCategorias();

        Task<CategoriaDocente> GetCategoria(long DocenteId);
        Task<DocentePlantum> GetDocentePlantum(long DocenteId);
        Task<EgresoDocente> GetEgreso(long DocenteId);
        Task<ProduccionAcademica> GetProduccion(long DocenteId);


        Task InsertarDocentePlantum(DocentePlantum docentePlantum);
        Task InsertarEgreso(EgresoDocente egreso);
        Task InsertarProduccion(ProduccionAcademica produccion);
        Task InsertarCategoria(CategoriaDocente categoria);


        void ActualizarCategoria(CategoriaDocente categoria);
        void ActualizarDocentePlantum(DocentePlantum docentePlantum);
        void ActualizarEgreso(EgresoDocente egreso);
        void ActualizarProduccion(ProduccionAcademica produccion);


        Task EliminarCategoria(long DocenteId);
        Task EliminarDocentePlantum(long DocenteId);
        Task EliminarEgreso(long DocenteId);
        Task EliminarProduccion(long DocenteId);
    }
}
