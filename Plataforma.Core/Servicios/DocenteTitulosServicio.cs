using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plataforma.Core.Entidades;
using Plataforma.Core.Interfaces;


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

        public IEnumerable<Pregrado> GetPregrados()
        {
            return _unitOfWork.DocenteTitulosRepositorio.GetPregrados();
        }

        public async Task<Especializacion> GetEspecializacion(long DocenteId)
        {
            return await _unitOfWork.DocenteTitulosRepositorio.GetEspecializacion(DocenteId);
        }

        public IEnumerable<Especializacion> GetEspecializaciones()
        {
            return  _unitOfWork.DocenteTitulosRepositorio.GetEspecializaciones();
        }

        public async Task<Magister> GetMagister(long DocenteId)
        {
            return await _unitOfWork.DocenteTitulosRepositorio.GetMagister(DocenteId);
        }

        public IEnumerable<Magister> GetMagisters()
        {
            return  _unitOfWork.DocenteTitulosRepositorio.GetMagisters();
        }

        public async Task<Doctorado> GetDoctorado(long DocenteId)
        {
            return await _unitOfWork.DocenteTitulosRepositorio.GetDoctorado(DocenteId);

        }

        public IEnumerable<Doctorado> GetDoctorados()
        {
            return _unitOfWork.DocenteTitulosRepositorio.GetDoctorados();
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
