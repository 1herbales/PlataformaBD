using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plataforma.Core.Entidades;

namespace Plataforma.Core.Interfaces
{
    public interface IDocenteTitulosRepositorio
    {
        IEnumerable<Pregrado> GetPregrados();
        IEnumerable<Doctorado> GetDoctorados();
        IEnumerable<Especializacion> GetEspecializaciones();
        IEnumerable<Magister> GetMagisters();

        Task<Pregrado> GetPregrado(long DocenteId);
        Task<Especializacion> GetEspecializacion(long DocenteId);
        Task<Magister> GetMagister(long DocenteId);
        Task<Doctorado> GetDoctorado(long DocenteId);

        Task InsertarPregrado(Pregrado pregrado);
        Task InsertarMagister(Magister magister);
        Task InsertarEspecializacion(Especializacion especializacion);
        Task InsertarDoctorado(Doctorado doctorado);

        void ActualizarPregrado(Pregrado pregrado);
        void ActualizarDoctorado(Doctorado doctorado);
        void ActualizarEspecializacion(Especializacion especializacion);
        void ActualizarMagister(Magister magister);

        Task EliminarPregrado(long DocenteId);
        Task EliminarDoctorado(long DocenteId);
        Task EliminarEspecializacion(long DocenteId);
        Task EliminarMagister(long DocenteId);
       
       
    }
}
