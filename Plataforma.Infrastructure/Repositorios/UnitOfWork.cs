using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plataforma.Core.Entidades;
using Plataforma.Core.Interfaces;
using Plataforma.Infrastructure.Datos;
using Plataforma.Infrastructure.Repositorios;

namespace Plataforma.Infrastructure.Repositorios
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UniversidadContext _context;
        private readonly IDocenteRepositorio _docenteRepositorio;
        private readonly IDocentePlantumRepositorio _docentePlantumRepositorio;
        private readonly IDocenteTitulosRepositorio _docenteTitulosRepositorio;




        public UnitOfWork(UniversidadContext context) 
        {
            _context = context;
            
        }

        public IDocenteRepositorio DocenteRepositorio => _docenteRepositorio ?? new DocenteRepository(_context);

        public IDocentePlantumRepositorio DocentePlantumRepositorio => _docentePlantumRepositorio ?? new DocentePlantumRepository(_context);

        public IDocenteTitulosRepositorio DocenteTitulosRepositorio => _docenteTitulosRepositorio ?? new DocenteTitulosRepository(_context);

        public void Dispose()
        {
            _context?.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
