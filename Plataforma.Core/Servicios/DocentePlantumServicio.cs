using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plataforma.Core.Entidades;
using Plataforma.Core.Interfaces;


namespace Plataforma.Core.Servicios
{
    public class DocentePlantumServicio : IDocentePlantumServicio
    {
        private readonly IUnitOfWork _unitOfWork;

        public DocentePlantumServicio(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<ProduccionAcademica> GetProducciones()
        {
            return _unitOfWork.DocentePlantumRepositorio.GetProducciones();
        }

        public IEnumerable<EgresoDocente> GetEgresos()
        {
            return _unitOfWork.DocentePlantumRepositorio.GetEgresos();
        }
        public IEnumerable<CategoriaDocente> GetCategorias()
        {
            return  _unitOfWork.DocentePlantumRepositorio.GetCategorias();
        }
        public IEnumerable<DocentePlantum> GetDocentesPlantum()
        {
            return  _unitOfWork.DocentePlantumRepositorio.GetDocentesPlantum();
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
