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
    public class DocenteServicio(IUnitOfWork unitOfWork) : IDocenteServicio
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<bool> ActualizarDocente(Docente docente)
        {
            _unitOfWork.DocenteRepositorio.ActualizarDocente(docente);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ActualizarDocenteCatedra(DocenteCatedra docenteCatedra)
        {
            _unitOfWork.DocenteRepositorio.ActualizarDocenteCatedra(docenteCatedra);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ActualizarDocenteDetalle(DocenteDetalle docenteDetalle)
        {
            _unitOfWork.DocenteRepositorio.ActualizarDocenteDetalle(docenteDetalle);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }



        public async Task<bool> EliminarDocente(long DocenteId)
        {
            await _unitOfWork.DocenteRepositorio.EliminarDocente(DocenteId);
            return true;
        }

        public async Task<bool> EliminarDocenteCatedra(long DocenteId)
        {
            await _unitOfWork.DocenteRepositorio.EliminarDocenteCatedra(DocenteId);
            return true;
        }

        public async Task<bool> EliminarDocenteDetalle(long DocenteId)
        {
            await _unitOfWork.DocenteRepositorio.EliminarDocenteDetalle(DocenteId);
            return true;
        }



        public async Task<Docente> GetDocente(long DocenteId)
        {
            return await _unitOfWork.DocenteRepositorio.GetDocente(DocenteId);
        }

        public async Task<DocenteCatedra> GetDocenteCatedra(long DocenteId)
        {
            return await _unitOfWork.DocenteRepositorio.GetDocenteCatedra(DocenteId);
        }

        public IEnumerable<DocenteCatedra> GetDocenteCatedras()
        {
            return _unitOfWork.DocenteRepositorio.GetDocenteCatedras();
        }

        public async Task<DocenteDetalle> GetDocenteDetalle(long DocenteId)
        {
            return await _unitOfWork.DocenteRepositorio.GetDocenteDetalle(DocenteId);
        }

        public IEnumerable<DocenteDetalle> GetDocenteDetalles()
        {
            return _unitOfWork.DocenteRepositorio.GetDocenteDetalles();
        }

        public IEnumerable<Docente> GetDocentes(DocenteQF docenteqf)
        {
            var query = _unitOfWork.DocenteRepositorio.GetDocentes();
            // Apply any filtering or sorting logic here if needed
            if (docenteqf != null)
            {
                if (!string.IsNullOrEmpty(docenteqf.Nombre))
                {
                    query = query.Where(d => d.Nombre.Contains(docenteqf.Nombre, StringComparison.OrdinalIgnoreCase));
                }

                if (!string.IsNullOrEmpty(docenteqf.Apellidos))
                {
                    query = query.Where(d => d.Apellidos.Contains(docenteqf.Apellidos, StringComparison.OrdinalIgnoreCase));
                }    

                if (!string.IsNullOrEmpty(docenteqf.NumeroIdentificacion))
                {
                    query = query.Where(d => d.NumeroIdentificacion.Contains(docenteqf.NumeroIdentificacion));
                }

                if (!string.IsNullOrEmpty(docenteqf.TipoIdentificacion))
                {
                    query = query.Where(d => d.TipoIdentificacion.Contains(docenteqf.TipoIdentificacion, StringComparison.OrdinalIgnoreCase));
                }

                if (!string.IsNullOrEmpty(docenteqf.EmailInstitucional))
                {
                    query = query.Where(d => d.EmailInstitucional.Contains(docenteqf.EmailInstitucional, StringComparison.OrdinalIgnoreCase));
                }
            }
            return query;
        }

        public async Task InsertarDocente(Docente docente)
        {
            await _unitOfWork.DocenteRepositorio.InsertarDocente(docente);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task InsertarDocenteCatedra(DocenteCatedra docenteCatedra)
        {
            await _unitOfWork.DocenteRepositorio.InsertarDocenteCatedra(docenteCatedra);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task InsertarDocenteDetalle(DocenteDetalle docenteDetalle)
        {
            await _unitOfWork.DocenteRepositorio.InsertarDocenteDetalle(docenteDetalle);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
