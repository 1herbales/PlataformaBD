using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plataforma.Core.Entidades;




namespace Plataforma.Core.Interfaces
{
   public interface IDocentePlantumServicio
    {
      

        IEnumerable<DocentePlantum> GetDocentesPlantum();
        IEnumerable<ProduccionAcademica> GetProducciones();
        IEnumerable<EgresoDocente> GetEgresos();
        IEnumerable<CategoriaDocente> GetCategorias();

        Task<DocentePlantum> GetDocentePlantum(long docenteId);
        Task<ProduccionAcademica> GetProduccion(long docenteId);
        Task<EgresoDocente> GetEgreso(long docenteId);
        Task<CategoriaDocente> GetCategoria(long docenteId);

        Task InsertarDocentePlantum(DocentePlantum docentePlantum);
        Task InsertarProduccion(ProduccionAcademica produccion);
        Task InsertarEgreso(EgresoDocente egreso);
        Task InsertarCategoria(CategoriaDocente categoria);

        Task<bool> ActualizarDocentePlantum(DocentePlantum docentePlantum);
        Task<bool> ActualizarProduccion(ProduccionAcademica produccion);
        Task<bool> ActualizarEgreso(EgresoDocente egreso);
        Task<bool> ActualizarCategoria(CategoriaDocente categoria);

        Task<bool> EliminarDocentePlantum(long docenteId);
        Task<bool> EliminarCategoria(long docenteId);
        Task<bool> EliminarEgreso(long docenteId);
        Task<bool> EliminarProduccion(long docenteId);


    }
}
