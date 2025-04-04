using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Plataforma.Core.Entidades;
using Plataforma.Core.Interfaces;
using Plataforma.Infrastructure.Datos;



namespace Plataforma.Infrastructure.Repositorios
{
    public class DocentePlantumRepository(UniversidadContext context) : IDocentePlantumRepositorio
    {
        private readonly UniversidadContext _context = context;

        public void ActualizarCategoria(CategoriaDocente categoria)
        {
            _context.CategoriaDocentes.Update(categoria);

        }

        public void ActualizarDocentePlantum(DocentePlantum docentePlantum)
        {
            _context.DocentePlanta.Update(docentePlantum);

        }

        public void ActualizarEgreso(EgresoDocente egreso)
        {
            _context.EgresoDocentes.Update(egreso);


        }

        public void ActualizarProduccion(ProduccionAcademica produccion)
        {
            _context.ProduccionAcademicas.Update(produccion);

        }

        public async Task EliminarCategoria(long DocenteId)
        {
            var currentCategoria = await GetCategoria(DocenteId);
            _context.CategoriaDocentes.Remove(currentCategoria);
            
        }

        public async Task EliminarDocentePlantum(long DocenteId)
        {
            var currentDocentePlantum = await GetDocentePlantum(DocenteId);
            _context.DocentePlanta.Remove(currentDocentePlantum);
            
        }

        public async Task EliminarEgreso(long DocenteId)
        {
            var currentEgreso = await GetEgreso(DocenteId);
            _context.EgresoDocentes.Remove(currentEgreso);
            
        }

        public async Task EliminarProduccion(long DocenteId)
        {
            var currentProduccion = await GetProduccion(DocenteId);
            _context.ProduccionAcademicas.Remove(currentProduccion);
        }

        public async Task<CategoriaDocente> GetCategoria(long DocenteId)
        {
            return await _context.CategoriaDocentes.FindAsync(DocenteId);

        }

        public IEnumerable<CategoriaDocente> GetCategorias()
        {
            return _context.CategoriaDocentes.AsEnumerable();

        }

        public async Task<DocentePlantum> GetDocentePlantum(long DocenteId)
        {
            return await _context.DocentePlanta.FindAsync(DocenteId);

        }

        public IEnumerable<DocentePlantum> GetDocentesPlantum()
        {
            return _context.DocentePlanta.AsEnumerable();

        }

        public async Task<EgresoDocente> GetEgreso(long DocenteId)
        {
            return await _context.EgresoDocentes.FindAsync(DocenteId);

        }

        public IEnumerable<EgresoDocente> GetEgresos()
        {
            return _context.EgresoDocentes.AsEnumerable();

        }

        public async Task<ProduccionAcademica> GetProduccion(long DocenteId)
        {
            return await _context.ProduccionAcademicas.FindAsync(DocenteId);

        }

        public IEnumerable<ProduccionAcademica> GetProducciones()
        {
            return _context.ProduccionAcademicas.AsEnumerable();

        }

        public async Task InsertarCategoria(CategoriaDocente categoria)
        {
            await _context.CategoriaDocentes.AddAsync(categoria);

        }

        public async Task InsertarDocentePlantum(DocentePlantum docentePlantum)
        {
            await _context.DocentePlanta.AddAsync(docentePlantum);

        }

        public async Task InsertarEgreso(EgresoDocente egreso)
        {
            await _context.EgresoDocentes.AddAsync(egreso);

        }

        public async Task InsertarProduccion(ProduccionAcademica produccion)
        {
            await _context.ProduccionAcademicas.AddAsync(produccion);

        }
    }
}
