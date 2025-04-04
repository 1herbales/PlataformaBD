﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plataforma.Core.Entidades;
using Plataforma.Core.QueryFilters;




namespace Plataforma.Core.Interfaces
{
   public interface IDocentePlantumServicio
    {
      

        IEnumerable<DocentePlantum> GetDocentesPlantum(DocentePlantumQF docentePlantumqf);
        IEnumerable<ProduccionAcademica> GetProducciones(ProduccionAcademicaQF produccionAcademicaqf);
        IEnumerable<EgresoDocente> GetEgresos(EgresoDocenteQF egresoDocenteqf);
        IEnumerable<CategoriaDocente> GetCategorias(CategoriaDocenteQF categoriaDocenteqf);

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
