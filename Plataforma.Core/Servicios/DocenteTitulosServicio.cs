using System;
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
    public class DocenteTitulosServicio : IDocenteTitulosServicio
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;

        public DocenteTitulosServicio(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
        }

        
        public async Task<bool> ActualizarPregrado(Pregrado pregrado)
        {
            _unitOfWork.DocenteTitulosRepositorio.ActualizarPregrado(pregrado);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
        public async Task<bool> ActualizarEspecializacion(Especializacion especializacion)
        {
            _unitOfWork.DocenteTitulosRepositorio.ActualizarEspecializacion(especializacion);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ActualizarMagister(Magister magister)
        {
            _unitOfWork.DocenteTitulosRepositorio.ActualizarMagister(magister);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
        public async Task<bool> ActualizarDoctorado(Doctorado doctorado)
        {
            _unitOfWork.DocenteTitulosRepositorio.ActualizarDoctorado(doctorado);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }



   
        public async Task<bool> EliminarPregrado(long DocenteId)
        {
            await _unitOfWork.DocenteTitulosRepositorio.EliminarPregrado(DocenteId);
            return true;
        }

        public async Task<bool> EliminarEspecializacion(long DocenteId)
        {
            await _unitOfWork.DocenteTitulosRepositorio.EliminarEspecializacion(DocenteId);
            return true;
        }

        public async Task<bool> EliminarMagister(long DocenteId)
        {
            await _unitOfWork.DocenteTitulosRepositorio.EliminarMagister(DocenteId);
            return true;
        }

        public async Task<bool> EliminarDoctorado(long DocenteId)
        {
            await _unitOfWork.DocenteTitulosRepositorio.EliminarMagister(DocenteId);
            return true;
        }



        public async Task<Pregrado> GetPregrado(long DocenteId)
        {
            return await _unitOfWork.DocenteTitulosRepositorio.GetPregrado(DocenteId);
        }

        public PagedList<Pregrado> GetPregrados(PregradoQF pregradoqf)
        {
            var query = _unitOfWork.DocenteTitulosRepositorio.GetPregrados();
            // Apply any filtering or sorting logic here if needed
            pregradoqf.PageNumber = pregradoqf.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : pregradoqf.PageNumber;
            pregradoqf.PageSize = pregradoqf.PageSize == 0 ? _paginationOptions.DefaultPageSize : pregradoqf.PageSize;


            if (!string.IsNullOrEmpty(pregradoqf.Titulo))
                {
                    query = query.Where(d => d.Titulo.Contains(pregradoqf.Titulo, StringComparison.OrdinalIgnoreCase));
                }
                if (!string.IsNullOrEmpty(pregradoqf.Universidad))
                {
                    query = query.Where(d => d.Universidad.Contains(pregradoqf.Universidad, StringComparison.OrdinalIgnoreCase));
                }
                if (pregradoqf.FechaFinalizacion != null)
                {
                    query = query.Where(d => d.FechaFinalizacion == pregradoqf.FechaFinalizacion);
                }

            var pagedPregrados = PagedList<Pregrado>.Create(query, pregradoqf.PageNumber, pregradoqf.PageSize);
            return pagedPregrados;
        }

        public async Task<Especializacion> GetEspecializacion(long DocenteId)
        {
            return await _unitOfWork.DocenteTitulosRepositorio.GetEspecializacion(DocenteId);
        }

        public PagedList<Especializacion> GetEspecializaciones(EspecializacionQF especializacionqf)
        {
            var query = _unitOfWork.DocenteTitulosRepositorio.GetEspecializaciones();
            // Apply any filtering or sorting logic here if needed
            especializacionqf.PageNumber = especializacionqf.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : especializacionqf.PageNumber;
            especializacionqf.PageSize = especializacionqf.PageSize == 0 ? _paginationOptions.DefaultPageSize : especializacionqf.PageSize;
            if (!string.IsNullOrEmpty(especializacionqf.Titulo))
                {
                    query = query.Where(d => d.Titulo.Contains(especializacionqf.Titulo, StringComparison.OrdinalIgnoreCase));
                }
                if (!string.IsNullOrEmpty(especializacionqf.Universidad))
                {
                    query = query.Where(d => d.Universidad.Contains(especializacionqf.Universidad, StringComparison.OrdinalIgnoreCase));
                }
                if (especializacionqf.FechaFinalizacion != null)
                {
                    query = query.Where(d => d.FechaFinalizacion == especializacionqf.FechaFinalizacion);
                }
            var pagedEspecializaciones = PagedList<Especializacion>.Create(query, especializacionqf.PageNumber, especializacionqf.PageSize);
            return pagedEspecializaciones;
        }

        public async Task<Magister> GetMagister(long DocenteId)
        {
            return await _unitOfWork.DocenteTitulosRepositorio.GetMagister(DocenteId);
        }

        public PagedList<Magister> GetMagisters(MagisterQF magisterqf)
        {
            var query = _unitOfWork.DocenteTitulosRepositorio.GetMagisters();
            // Apply any filtering or sorting logic here if needed
            magisterqf.PageNumber = magisterqf.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : magisterqf.PageNumber;
            magisterqf.PageSize = magisterqf.PageSize == 0 ? _paginationOptions.DefaultPageSize : magisterqf.PageSize;
            if (!string.IsNullOrEmpty(magisterqf.Titulo))
                {
                    query = query.Where(d => d.Titulo.Contains(magisterqf.Titulo, StringComparison.OrdinalIgnoreCase));
                }
                if (!string.IsNullOrEmpty(magisterqf.Universidad))
                {
                    query = query.Where(d => d.Universidad.Contains(magisterqf.Universidad, StringComparison.OrdinalIgnoreCase));
                }
                if (!string.IsNullOrEmpty(magisterqf.Pais))
                {
                    query = query.Where(d => d.Pais.Contains(magisterqf.Pais, StringComparison.OrdinalIgnoreCase));
                }
                if (magisterqf.FechaFinalizacion != null)
                {
                    query = query.Where(d => d.FechaFinalizacion == magisterqf.FechaFinalizacion);
                }
                if (!string.IsNullOrEmpty(magisterqf.Convalidacion))
                {
                    query = query.Where(d => d.Convalidacion.Contains(magisterqf.Convalidacion, StringComparison.OrdinalIgnoreCase));
                }
                if (magisterqf.FechaConvalidacion != null)
                {
                    query = query.Where(d => d.FechaConvalidacion == magisterqf.FechaConvalidacion);
                }
                if (!string.IsNullOrEmpty(magisterqf.ResolucionConvalidacion))
                {
                    query = query.Where(d => d.ResolucionConvalidacion.Contains(magisterqf.ResolucionConvalidacion, StringComparison.OrdinalIgnoreCase));
                }

            var pagedMagister = PagedList<Magister>.Create(query, magisterqf.PageNumber, magisterqf.PageSize);
            return pagedMagister;
            
        }

        public async Task<Doctorado> GetDoctorado(long DocenteId)
        {
            return await _unitOfWork.DocenteTitulosRepositorio.GetDoctorado(DocenteId);

        }

        public PagedList<Doctorado> GetDoctorados(DoctoradoQF doctoradoqf)
        {
            var query = _unitOfWork.DocenteTitulosRepositorio.GetDoctorados();
            // Apply any filtering or sorting logic here if needed
            doctoradoqf.PageNumber = doctoradoqf.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : doctoradoqf.PageNumber;
            doctoradoqf.PageSize = doctoradoqf.PageSize == 0 ? _paginationOptions.DefaultPageSize : doctoradoqf.PageSize;

            if (!string.IsNullOrEmpty(doctoradoqf.Titulo))
                {
                    query = query.Where(d => d.Titulo.Contains(doctoradoqf.Titulo, StringComparison.OrdinalIgnoreCase));
                }

                if (!string.IsNullOrEmpty(doctoradoqf.Universidad))
                {
                    query = query.Where(d => d.Universidad.Contains(doctoradoqf.Universidad, StringComparison.OrdinalIgnoreCase));
                }

                if (doctoradoqf.FechaFinalizacion != null)
                {
                    query = query.Where(d => d.FechaFinalizacion == doctoradoqf.FechaFinalizacion);
                }

                if (!string.IsNullOrEmpty(doctoradoqf.Convalidacion))
                {
                    query = query.Where(d => d.Convalidacion.Contains(doctoradoqf.Convalidacion, StringComparison.OrdinalIgnoreCase));
                }

                if (doctoradoqf.FechaConvalidacion != null) 
                {
                    query = query.Where(d => d.FechaConvalidacion == doctoradoqf.FechaConvalidacion);
                }

                if (!string.IsNullOrEmpty(doctoradoqf.ResolucionConvalidacion))
                {
                    query = query.Where(d => d.ResolucionConvalidacion.Contains(doctoradoqf.ResolucionConvalidacion, StringComparison.OrdinalIgnoreCase));
                }
            var pagedDoctorado = PagedList<Doctorado>.Create(query, doctoradoqf.PageNumber, doctoradoqf.PageSize);
            return pagedDoctorado;

        }


        // INSERTAR

        public async Task InsertarDoctorado(Doctorado doctorado)
        {
            await _unitOfWork.DocenteTitulosRepositorio.InsertarDoctorado(doctorado);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task InsertarEspecializacion(Especializacion especializacion)
        {
            await _unitOfWork.DocenteTitulosRepositorio.InsertarEspecializacion(especializacion);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task InsertarMagister(Magister magister)
        {
            await _unitOfWork.DocenteTitulosRepositorio.InsertarMagister(magister);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task InsertarPregrado(Pregrado pregrado)
        {
             await _unitOfWork.DocenteTitulosRepositorio.InsertarPregrado(pregrado);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
