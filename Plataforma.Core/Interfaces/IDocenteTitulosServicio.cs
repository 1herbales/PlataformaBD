using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plataforma.Core.Entidades;


namespace Plataforma.Core.Interfaces
{
    public interface IDocenteTitulosServicio
    {
        IEnumerable<Pregrado> GetPregrados();
        Task<Pregrado> GetPregrado(long DocenteId);
        Task InsertarPregrado(Pregrado pregrado);
        Task<bool> ActualizarPregrado(Pregrado pregrado);
        Task<bool> EliminarPregrado(long DocenteId);

        IEnumerable<Especializacion> GetEspecializaciones();
        Task<Especializacion> GetEspecializacion(long DocenteId);
        Task InsertarEspecializacion(Especializacion especializacion);
        Task<bool> ActualizarEspecializacion(Especializacion especializacion);
        Task<bool> EliminarEspecializacion(long DocenteId);

        IEnumerable<Magister> GetMagisters();
        Task<Magister> GetMagister(long DocenteId);
        Task InsertarMagister(Magister magister);
        Task<bool> ActualizarMagister(Magister magister);
        Task<bool> EliminarMagister(long DocenteId);

        IEnumerable<Doctorado> GetDoctorados();
        Task<Doctorado> GetDoctorado(long DocenteId);
        Task InsertarDoctorado(Doctorado doctorado);
        Task<bool> ActualizarDoctorado(Doctorado doctorado);
        Task<bool> EliminarDoctorado(long DocenteId);
        
    }
}
