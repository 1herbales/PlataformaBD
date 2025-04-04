using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plataforma.Infrastructure.Datos;
using Plataforma.Core.Interfaces;
using Plataforma.Core.Entidades;
using Microsoft.EntityFrameworkCore;


namespace Plataforma.Infrastructure.Repositorios
{
    public class DocenteTitulosRepository(UniversidadContext context) : IDocenteTitulosRepositorio
    {
        private readonly UniversidadContext _context = context; 

        public IEnumerable<Pregrado> GetPregrados()
        {
            return _context.Pregrados.AsEnumerable();
        }
        public IEnumerable<Especializacion> GetEspecializaciones()
        {
            return _context.Especializacions.AsEnumerable();
        }
        public IEnumerable<Magister> GetMagisters()
        {
            return _context.Magisters.AsEnumerable();
        }
        public IEnumerable<Doctorado> GetDoctorados()
        {
            return _context.Doctorados.AsEnumerable();
        }




        public async Task<Pregrado> GetPregrado(long DocenteId)
        {
            return await _context.Pregrados.FindAsync(DocenteId);

        }

        public async Task<Especializacion> GetEspecializacion(long DocenteId)
        {
            return await _context.Especializacions.FindAsync(DocenteId);

        }

        public async Task<Magister> GetMagister(long DocenteId)
        {
            return await _context.Magisters.FindAsync(DocenteId);

        }

        public async Task<Doctorado> GetDoctorado(long DocenteId)
        {
            return await _context.Doctorados.FindAsync(DocenteId);

        }


        //INSERTAR

        public async Task InsertarPregrado(Pregrado pregrado)
        {
            await _context.Pregrados.AddAsync(pregrado);

        }
        public async Task InsertarMagister(Magister magister)
        {
            await _context.Magisters.AddAsync(magister);

        }

        public async Task InsertarEspecializacion(Especializacion especializacion)
        {
            await _context.Especializacions.AddAsync(especializacion);

        }

        public async Task InsertarDoctorado(Doctorado doctorado)
        {
            await _context.Doctorados.AddAsync(doctorado);

        }


        //ACTUALUZAR

        public void ActualizarPregrado(Pregrado pregrado)
        {
            _context.Pregrados.Update(pregrado);

        }

        public void ActualizarDoctorado(Doctorado doctorado)
        {
            _context.Doctorados.Update(doctorado);

        }

        public void ActualizarEspecializacion(Especializacion especializacion)
        {
            _context.Especializacions.Update(especializacion);

        }

        public void ActualizarMagister(Magister magister)
        {
            _context.Magisters.Update(magister);

        }

        public async Task EliminarPregrado(long DocenteId)
        {
            var currentPregrado = await GetPregrado(DocenteId);
            _context.Pregrados.Remove(currentPregrado);
           
        }
        public async Task EliminarDoctorado(long DocenteId)
        {
            var currentDoctorado = await GetDoctorado(DocenteId);
            _context.Doctorados.Remove(currentDoctorado);
            
        }

        public async Task EliminarEspecializacion(long DocenteId)
        {
            var currentEspecializacion = await GetEspecializacion(DocenteId);
            _context.Especializacions.Remove(currentEspecializacion);
          
        }

        public async Task EliminarMagister(long DocenteId)
        {
            var currentMagister = await GetMagister(DocenteId);
            _context.Magisters.Remove(currentMagister);
            
        }

       
    }
}
