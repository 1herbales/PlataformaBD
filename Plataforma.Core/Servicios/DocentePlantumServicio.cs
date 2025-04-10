﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Plataforma.Core.CustomEntities;
using Plataforma.Core.Entidades;
using Plataforma.Core.Interfaces;
using Plataforma.Core.QueryFilters;


namespace Plataforma.Core.Servicios
{
    public class DocentePlantumServicio : IDocentePlantumServicio
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;


        public DocentePlantumServicio(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
        }

        public PagedList<ProduccionAcademica> GetProducciones(ProduccionAcademicaQF produccionAcademicaqf)
        {
            var query = _unitOfWork.DocentePlantumRepositorio.GetProducciones();
            produccionAcademicaqf.PageNumber = produccionAcademicaqf.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : produccionAcademicaqf.PageNumber;
            produccionAcademicaqf.PageSize = produccionAcademicaqf.PageSize == 0 ? _paginationOptions.DefaultPageSize : produccionAcademicaqf.PageSize;


            if (!string.IsNullOrEmpty(produccionAcademicaqf.ActaNumero))
                {
                    query = query.Where(p => p.ActaNumero.Contains(produccionAcademicaqf.ActaNumero, StringComparison.OrdinalIgnoreCase));
                }
                if (produccionAcademicaqf.FechaActa != null)
                {
                    query = query.Where(p => p.FechaActa == produccionAcademicaqf.FechaActa.Value);
                }
                if (!string.IsNullOrEmpty(produccionAcademicaqf.TipoDePuntos))
                {
                    query = query.Where(p => p.TipoDePuntos.Contains(produccionAcademicaqf.TipoDePuntos, StringComparison.OrdinalIgnoreCase));
                }
                if (!string.IsNullOrEmpty(produccionAcademicaqf.TipoDeProducto))
                {
                    query = query.Where(p => p.TipoDeProducto.Contains(produccionAcademicaqf.TipoDeProducto, StringComparison.OrdinalIgnoreCase));
                }
                if (!string.IsNullOrEmpty(produccionAcademicaqf.RevistaPostgradoPremioEditorial))
                {
                    query = query.Where(p => p.RevistaPostgradoPremioEditorial.Contains(produccionAcademicaqf.RevistaPostgradoPremioEditorial, StringComparison.OrdinalIgnoreCase));
                }
                if (!string.IsNullOrEmpty(produccionAcademicaqf.IssnIsbn))
                {
                    query = query.Where(p => p.IssnIsbn.Contains(produccionAcademicaqf.IssnIsbn, StringComparison.OrdinalIgnoreCase));
                }
                if (!string.IsNullOrEmpty(produccionAcademicaqf.TituloDelProducto))
                {
                    query = query.Where(p => p.TituloDelProducto.Contains(produccionAcademicaqf.TituloDelProducto, StringComparison.OrdinalIgnoreCase));
                }
                if (produccionAcademicaqf.PuntosAsignados != null)
                {
                    query = query.Where(p => p.PuntosAsignados == produccionAcademicaqf.PuntosAsignados.Value);
                }
                if (produccionAcademicaqf.NumeroAutores != null)
                {
                    query = query.Where(p => p.NumeroAutores == produccionAcademicaqf.NumeroAutores.Value);
                }
                if (!string.IsNullOrEmpty(produccionAcademicaqf.EfectosFiscales))
                {
                    query = query.Where(p => p.EfectosFiscales.Contains(produccionAcademicaqf.EfectosFiscales, StringComparison.OrdinalIgnoreCase));
                }
                if (!string.IsNullOrEmpty(produccionAcademicaqf.ResolucionNumero))
                {
                    query = query.Where(p => p.ResolucionNumero.Contains(produccionAcademicaqf.ResolucionNumero, StringComparison.OrdinalIgnoreCase));
                }
                if (produccionAcademicaqf.FechaResolucion != null)
                {
                    query = query.Where(p => p.FechaResolucion == produccionAcademicaqf.FechaResolucion.Value);
                }
                if (!string.IsNullOrEmpty(produccionAcademicaqf.Observaciones))
                {
                    query = query.Where(p => p.Observaciones.Contains(produccionAcademicaqf.Observaciones, StringComparison.OrdinalIgnoreCase));
                }
            var pagedProduccion = PagedList<ProduccionAcademica>.Create(query, produccionAcademicaqf.PageNumber, produccionAcademicaqf.PageSize);
            return pagedProduccion;
        }
        public PagedList<EgresoDocente> GetEgresos(EgresoDocenteQF egresoDocenteqf)
        {
            var query = _unitOfWork.DocentePlantumRepositorio.GetEgresos();
            egresoDocenteqf.PageNumber = egresoDocenteqf.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : egresoDocenteqf.PageNumber;
            egresoDocenteqf.PageSize = egresoDocenteqf.PageSize == 0 ? _paginationOptions.DefaultPageSize : egresoDocenteqf.PageSize;

            if (!string.IsNullOrEmpty(egresoDocenteqf.ResolucionNumero))
                {
                    query = query.Where(e => e.ResolucionNumero.Contains(egresoDocenteqf.ResolucionNumero, StringComparison.OrdinalIgnoreCase));
                }
                if (egresoDocenteqf.FechaResolucion != null)
                {
                    query = query.Where(e => e.FechaResolucion == egresoDocenteqf.FechaResolucion.Value);
                }
                if (egresoDocenteqf.EgresoAPartirDe != null)
                {
                    query = query.Where(e => e.EgresoAPartirDe == egresoDocenteqf.EgresoAPartirDe.Value);
                }
                var pagedEgreso = PagedList<EgresoDocente>.Create(query, egresoDocenteqf.PageNumber, egresoDocenteqf.PageSize);
                return pagedEgreso;
            }
        public PagedList<CategoriaDocente> GetCategorias(CategoriaDocenteQF categoriaDocenteqf)
        {
            var query = _unitOfWork.DocentePlantumRepositorio.GetCategorias();
            categoriaDocenteqf.PageNumber = categoriaDocenteqf.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : categoriaDocenteqf.PageNumber;
            categoriaDocenteqf.PageSize = categoriaDocenteqf.PageSize == 0 ? _paginationOptions.DefaultPageSize : categoriaDocenteqf.PageSize;


            if (categoriaDocenteqf.FechaVinculacion != null)
                {
                    query = query.Where(d => d.FechaVinculacion == categoriaDocenteqf.FechaVinculacion.Value);
                }
                if (categoriaDocenteqf.FechaAsistente != null)
                {
                    query = query.Where(d => d.FechaAsistente == categoriaDocenteqf.FechaAsistente.Value);
                }
                if (categoriaDocenteqf.FechaAsociado != null)
                {
                    query = query.Where(d => d.FechaAsociado == categoriaDocenteqf.FechaAsociado.Value);
                }
                if (categoriaDocenteqf.FechaTitular != null)
                {
                    query = query.Where(d => d.FechaTitular == categoriaDocenteqf.FechaTitular.Value);
                }

            var pagedCategoria = PagedList<CategoriaDocente>.Create(query, categoriaDocenteqf.PageNumber, categoriaDocenteqf.PageSize);
            return pagedCategoria;

        }
        public PagedList<DocentePlantum> GetDocentesPlantum(DocentePlantumQF docentePlantumqf)
        {
            var query = _unitOfWork.DocentePlantumRepositorio.GetDocentesPlantum();
            docentePlantumqf.PageNumber = docentePlantumqf.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : docentePlantumqf.PageNumber;
            docentePlantumqf.PageSize = docentePlantumqf.PageSize == 0 ? _paginationOptions.DefaultPageSize : docentePlantumqf.PageSize;

            if (!string.IsNullOrEmpty(docentePlantumqf.Escalafon))
                {
                    query = query.Where(d => d.Escalafon.Contains(docentePlantumqf.Escalafon, StringComparison.OrdinalIgnoreCase));
                }
                if (!string.IsNullOrEmpty(docentePlantumqf.NumeroResolucionEscalafon))
                {
                    query = query.Where(d => d.NumeroResolucionEscalafon.Contains(docentePlantumqf.NumeroResolucionEscalafon, StringComparison.OrdinalIgnoreCase));
                }
                if (docentePlantumqf.FechaResolucionEscalafon != null)
                {
                    query = query.Where(d => d.FechaResolucionEscalafon == docentePlantumqf.FechaResolucionEscalafon.Value);
                }
                if (!string.IsNullOrEmpty(docentePlantumqf.Dedicacion))
                {
                    query = query.Where(d => d.Dedicacion.Contains(docentePlantumqf.Dedicacion, StringComparison.OrdinalIgnoreCase));
                }
                if (!string.IsNullOrEmpty(docentePlantumqf.NivelAcademico))
                {
                    query = query.Where(d => d.NivelAcademico.Contains(docentePlantumqf.NivelAcademico, StringComparison.OrdinalIgnoreCase));
                }
                if (!string.IsNullOrEmpty(docentePlantumqf.NumeroTarjetaProfesional))
                {
                    query = query.Where(d => d.NumeroTarjetaProfesional.Contains(docentePlantumqf.NumeroTarjetaProfesional, StringComparison.OrdinalIgnoreCase));
                }

                var pagedDocentePlantum = PagedList<DocentePlantum>.Create(query, docentePlantumqf.PageNumber, docentePlantumqf.PageSize);
                return pagedDocentePlantum;
            }

        public async Task<bool> ActualizarCategoria(CategoriaDocente categoria)
        {
            _unitOfWork.DocentePlantumRepositorio.ActualizarCategoria(categoria);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ActualizarDocentePlantum(DocentePlantum docentePlantum)
        {
            _unitOfWork.DocentePlantumRepositorio.ActualizarDocentePlantum(docentePlantum);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ActualizarEgreso(EgresoDocente egreso)
        {
            _unitOfWork.DocentePlantumRepositorio.ActualizarEgreso(egreso);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ActualizarProduccion(ProduccionAcademica produccion)
        {
            _unitOfWork.DocentePlantumRepositorio.ActualizarProduccion(produccion);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EliminarCategoria(long DocenteId)
        {
            await _unitOfWork.DocentePlantumRepositorio.EliminarCategoria(DocenteId);
            return true;
        }

        public async Task<bool> EliminarDocentePlantum(long DocenteId)
        {
            await _unitOfWork.DocentePlantumRepositorio.EliminarDocentePlantum(DocenteId);
            return true;
        }

        public async Task<bool> EliminarEgreso(long DocenteId)
        {
            await _unitOfWork.DocentePlantumRepositorio.EliminarEgreso(DocenteId);
            return true;
        }

        public async Task<bool> EliminarProduccion(long DocenteId)
        {
            await _unitOfWork.DocentePlantumRepositorio.EliminarProduccion(DocenteId);
            return true;
        }

        public async Task<CategoriaDocente> GetCategoria(long DocenteId)
        {
            return await _unitOfWork.DocentePlantumRepositorio.GetCategoria(DocenteId);
        }

        public async Task<DocentePlantum> GetDocentePlantum(long DocenteId)
        {
            return await _unitOfWork.DocentePlantumRepositorio.GetDocentePlantum(DocenteId);
        }

        public async Task<EgresoDocente> GetEgreso(long DocenteId)
        {
            return await _unitOfWork.DocentePlantumRepositorio.GetEgreso(DocenteId);
        }

        public async Task<ProduccionAcademica> GetProduccion(long DocenteId)
        {
            return await _unitOfWork.DocentePlantumRepositorio.GetProduccion(DocenteId);
        }

        public async Task InsertarCategoria(CategoriaDocente categoria)
        {
            await _unitOfWork.DocentePlantumRepositorio.InsertarCategoria(categoria);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task InsertarDocentePlantum(DocentePlantum docentePlantum)
        {
            await _unitOfWork.DocentePlantumRepositorio.InsertarDocentePlantum(docentePlantum);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task InsertarEgreso(EgresoDocente egreso)
        {
            await _unitOfWork.DocentePlantumRepositorio.InsertarEgreso(egreso);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task InsertarProduccion(ProduccionAcademica produccion)
        {
            await _unitOfWork.DocentePlantumRepositorio.InsertarProduccion(produccion);
            await _unitOfWork.SaveChangesAsync();
        }

        
       
    }
}
