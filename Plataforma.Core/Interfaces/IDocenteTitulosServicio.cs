using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plataforma.Core.CustomEntities;
using Plataforma.Core.Entidades;
using Plataforma.Core.QueryFilters;



namespace Plataforma.Core.Interfaces
{
    public interface IDocenteTitulosServicio
    {
        PagedList<Pregrado> GetPregrados(PregradoQF pregradoqf);
        Task<Pregrado> GetPregrado(long DocenteId);
        Task InsertarPregrado(Pregrado pregrado);
        Task<bool> ActualizarPregrado(Pregrado pregrado);
        Task<bool> EliminarPregrado(long DocenteId);

        PagedList<Especializacion> GetEspecializaciones(EspecializacionQF especializacionqf);
        Task<Especializacion> GetEspecializacion(long DocenteId);
        Task InsertarEspecializacion(Especializacion especializacion);
        Task<bool> ActualizarEspecializacion(Especializacion especializacion);
        Task<bool> EliminarEspecializacion(long DocenteId);

        PagedList<Magister> GetMagisters(MagisterQF magisterqf);
        Task<Magister> GetMagister(long DocenteId);
        Task InsertarMagister(Magister magister);
        Task<bool> ActualizarMagister(Magister magister);
        Task<bool> EliminarMagister(long DocenteId);

        PagedList<Doctorado> GetDoctorados(DoctoradoQF doctoradoqf);
        Task<Doctorado> GetDoctorado(long DocenteId);
        Task InsertarDoctorado(Doctorado doctorado);
        Task<bool> ActualizarDoctorado(Doctorado doctorado);
        Task<bool> EliminarDoctorado(long DocenteId);
        
    }
}
