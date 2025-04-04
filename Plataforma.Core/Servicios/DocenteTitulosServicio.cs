using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plataforma.Core.Entidades;
using Plataforma.Core.Interfaces;
using Plataforma.Core.QueryFilters;


namespace Plataforma.Core.Servicios
{
    public class DocenteTitulosServicio : IDocenteTitulosServicio
    {
        private readonly IUnitOfWork _unitOfWork;

        public DocenteTitulosServicio(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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

        public IEnumerable<Pregrado> GetPregrados(PregradoQF pregradoqf)
        {
            var query = _unitOfWork.DocenteTitulosRepositorio.GetPregrados();
            // Apply any filtering or sorting logic here if needed
            if (pregradoqf != null)
            {
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
            }
            return query.ToList();
        }

        public async Task<Especializacion> GetEspecializacion(long DocenteId)
        {
            return await _unitOfWork.DocenteTitulosRepositorio.GetEspecializacion(DocenteId);
        }

        public IEnumerable<Especializacion> GetEspecializaciones(EspecializacionQF especializacionqf)
        {
            var query = _unitOfWork.DocenteTitulosRepositorio.GetEspecializaciones();
            // Apply any filtering or sorting logic here if needed
            if (especializacionqf != null)
            {
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
            }
            return query.ToList();
        }

        public async Task<Magister> GetMagister(long DocenteId)
        {
            return await _unitOfWork.DocenteTitulosRepositorio.GetMagister(DocenteId);
        }

        public IEnumerable<Magister> GetMagisters(MagisterQF magisterqf)
        {
            var query = _unitOfWork.DocenteTitulosRepositorio.GetMagisters();
            // Apply any filtering or sorting logic here if needed
            if (magisterqf != null)
            {
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

            }
            return query.ToList();
        }

        public async Task<Doctorado> GetDoctorado(long DocenteId)
        {
            return await _unitOfWork.DocenteTitulosRepositorio.GetDoctorado(DocenteId);

        }

        public IEnumerable<Doctorado> GetDoctorados(DoctoradoQF doctoradoqf)
        {
            var query = _unitOfWork.DocenteTitulosRepositorio.GetDoctorados();
            // Apply any filtering or sorting logic here if needed
            if (doctoradoqf != null)
            {
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
            }
            return query.ToList();
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
