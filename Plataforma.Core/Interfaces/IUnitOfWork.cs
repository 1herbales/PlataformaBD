using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plataforma.Core.Entidades;

namespace Plataforma.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IDocenteRepositorio DocenteRepositorio { get; }
        IDocentePlantumRepositorio DocentePlantumRepositorio { get; }
        IDocenteTitulosRepositorio DocenteTitulosRepositorio { get; }
        
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
