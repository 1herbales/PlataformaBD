using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plataforma.Core.CustomEntities;
using Plataforma.Core.Entidades;
using Plataforma.Core.Interfaces;
using Plataforma.Core.QueryFilters;






namespace Plataforma.Core.Servicios
{
    public class DocenteServicio(IUnitOfWork unitOfWork) : IDocenteServicio
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<bool> ActualizarDatoPersonal(DocenteDatosPersonale datoPersonal)
        {
            _unitOfWork.DocenteRepositorio.ActualizarDatoPersonal(datoPersonal);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

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

        public async Task<bool> EliminarDatoPersonal(long DocenteId)
        {
            await _unitOfWork.DocenteRepositorio.EliminarDatoPersonal(DocenteId);
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

        public async Task<DocenteDatosPersonale> GetDatoPersonal(long DocenteId)
        {
            return await _unitOfWork.DocenteRepositorio.GetDatoPersonal(DocenteId);
        }

        public PagedList<DocenteDatosPersonale> GetDatosPersonales(DocenteDatosPersonaleQF docenteDatosPersonaleqf)
        {
            var query = _unitOfWork.DocenteRepositorio.GetDatosPersonales();
            
                if (!string.IsNullOrEmpty(docenteDatosPersonaleqf.Sexo))
                {
                    query = query.Where(d => d.Sexo.Contains(docenteDatosPersonaleqf.Sexo, StringComparison.OrdinalIgnoreCase));
                }
                if (docenteDatosPersonaleqf.Edad > 0)
                {
                    query = query.Where(d => d.Edad == docenteDatosPersonaleqf.Edad);
                }
                if (!string.IsNullOrEmpty(docenteDatosPersonaleqf.LugarNacimientoMunicipio))
                {
                    query = query.Where(d => d.LugarNacimientoMunicipio.Contains(docenteDatosPersonaleqf.LugarNacimientoMunicipio, StringComparison.OrdinalIgnoreCase));
                }
                if (!string.IsNullOrEmpty(docenteDatosPersonaleqf.Departamento))
                {
                    query = query.Where(d => d.Departamento.Contains(docenteDatosPersonaleqf.Departamento, StringComparison.OrdinalIgnoreCase));
                }
                if (!string.IsNullOrEmpty(docenteDatosPersonaleqf.PaisProcedencia))
                {
                    query = query.Where(d => d.PaisProcedencia.Contains(docenteDatosPersonaleqf.PaisProcedencia, StringComparison.OrdinalIgnoreCase));
                }
                if (!string.IsNullOrEmpty(docenteDatosPersonaleqf.DireccionResidencia))
                {
                    query = query.Where(d => d.DireccionResidencia.Contains(docenteDatosPersonaleqf.DireccionResidencia, StringComparison.OrdinalIgnoreCase));
                }
                if (!string.IsNullOrEmpty(docenteDatosPersonaleqf.NumeroContacto))
                {
                    query = query.Where(d => d.NumeroContacto.Contains(docenteDatosPersonaleqf.NumeroContacto, StringComparison.OrdinalIgnoreCase));
                }

            var pagedDocentesDatosPersonale = PagedList<DocenteDatosPersonale>.Create(query, docenteDatosPersonaleqf.PageNumber, docenteDatosPersonaleqf.PageSize);
            return pagedDocentesDatosPersonale;

        }

        public async Task<Docente> GetDocente(long DocenteId)
        {
            return await _unitOfWork.DocenteRepositorio.GetDocente(DocenteId);
        }

        public async Task<DocenteCatedra> GetDocenteCatedra(long DocenteId)
        {
            return await _unitOfWork.DocenteRepositorio.GetDocenteCatedra(DocenteId);
        }

        public PagedList<DocenteCatedra> GetDocenteCatedras(DocenteCatedraQF docenteCatedraqf)
        {
            var query = _unitOfWork.DocenteRepositorio.GetDocenteCatedras();
            
                if (docenteCatedraqf.HorasContratadas.HasValue)
                {
                    query = query.Where(d => d.HorasContratadas == docenteCatedraqf.HorasContratadas.Value);
                }

                if (docenteCatedraqf.FechaInicioContrato.HasValue)
                {
                    query = query.Where(d => d.FechaInicioContrato == docenteCatedraqf.FechaInicioContrato.Value);
                }

                if (!string.IsNullOrEmpty(docenteCatedraqf.ResolucionVinculacion))
                {
                    query = query.Where(d => d.ResolucionVinculacion.Contains(docenteCatedraqf.ResolucionVinculacion, StringComparison.OrdinalIgnoreCase));
                }

                if (docenteCatedraqf.FechaResolucion.HasValue)
                {
                    query = query.Where(d => d.FechaResolucion == docenteCatedraqf.FechaResolucion.Value);
                }

                if (docenteCatedraqf.DocenteActivo.HasValue)
                {
                    query = query.Where(d => d.DocenteActivo == docenteCatedraqf.DocenteActivo.Value);
                }

                if (!string.IsNullOrEmpty(docenteCatedraqf.NumeroTarjetaProfesional))
                {
                    query = query.Where(d => d.NumeroTarjetaProfesional.Contains(docenteCatedraqf.NumeroTarjetaProfesional, StringComparison.OrdinalIgnoreCase));
                }

            var pagedDocentesCatedra = PagedList<DocenteCatedra>.Create(query, docenteCatedraqf.PageNumber, docenteCatedraqf.PageSize);
            return pagedDocentesCatedra;
        }

        public async Task<DocenteDetalle> GetDocenteDetalle(long DocenteId)
        {
            return await _unitOfWork.DocenteRepositorio.GetDocenteDetalle(DocenteId);
        }

        public PagedList<DocenteDetalle> GetDocenteDetalles(DocenteDetalleQF docenteDetalleqf)
        {
            var query = _unitOfWork.DocenteRepositorio.GetDocenteDetalles();
            
                if (!string.IsNullOrEmpty(docenteDetalleqf.Modalidad))
                {
                    query = query.Where(d => d.Modalidad.Contains(docenteDetalleqf.Modalidad, StringComparison.OrdinalIgnoreCase));
                }

                if (!string.IsNullOrEmpty(docenteDetalleqf.Municipio))
                {
                    query = query.Where(d => d.Municipio.Contains(docenteDetalleqf.Municipio, StringComparison.OrdinalIgnoreCase));
                }

                if (!string.IsNullOrEmpty(docenteDetalleqf.Facultad))
                {
                    query = query.Where(d => d.Facultad.Contains(docenteDetalleqf.Facultad, StringComparison.OrdinalIgnoreCase));
                }

                if (!string.IsNullOrEmpty(docenteDetalleqf.ProgramaAdscrito))
                {
                    query = query.Where(d => d.ProgramaAdscrito.Contains(docenteDetalleqf.ProgramaAdscrito, StringComparison.OrdinalIgnoreCase));
                }
            var pagedDocentesDetalles = PagedList<DocenteDetalle>.Create(query, docenteDetalleqf.PageNumber, docenteDetalleqf.PageSize);
            return pagedDocentesDetalles;

        }

        public PagedList<Docente> GetDocentes(DocenteQF docenteqf)
        {
            var query = _unitOfWork.DocenteRepositorio.GetDocentes();
            // Apply any filtering or sorting logic here if needed
            
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
                var pagedDocentes = PagedList<Docente>.Create(query, docenteqf.PageNumber, docenteqf.PageSize);
                return pagedDocentes;
        }
            
        

        public async Task InsertarDatoPersonal(DocenteDatosPersonale datoPersonal)
        {
            await _unitOfWork.DocenteRepositorio.InsertarDatoPersonal(datoPersonal);
            await _unitOfWork.SaveChangesAsync();
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
