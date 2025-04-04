using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Plataforma.Core.Entidades;
using Plataforma.Core.Interfaces;
using Plataforma.Core.QueryFilters;
using Plataforma.Infrastructure.Datos;


namespace Plataforma.Infrastructure.Repositorios
{
   public class DocenteRepository(UniversidadContext context) : IDocenteRepositorio
    {
        private readonly UniversidadContext _context = context;

        public IEnumerable<Docente> GetDocentes()
        {
            return _context.Docentes.AsEnumerable();
        }

        public async Task<Docente> GetDocente(long DocenteId)
        {
            return await _context.Docentes.FindAsync(DocenteId);
        }


        public async Task InsertarDocente(Docente docente)
        {
            await _context.Docentes.AddAsync(docente);
            
        }

        public void ActualizarDocente(Docente docente)
        {
            _context.Docentes.Update(docente);

        }

        public async Task EliminarDocente(long DocenteId)
        {
            var currentDocente = await GetDocente(DocenteId);
            _context.Docentes.Remove(currentDocente);
            
        }


        //Docentes de Catedra
        public IEnumerable<DocenteCatedra> GetDocenteCatedras()
        {
            return _context.DocenteCatedras.AsEnumerable();
        }

        public async Task<DocenteCatedra> GetDocenteCatedra(long DocenteId)
        {
            return await _context.DocenteCatedras.FindAsync(DocenteId);
        }

        public async Task InsertarDocenteCatedra(DocenteCatedra docenteCatedra)
        {
           await _context.DocenteCatedras.AddAsync(docenteCatedra);
            
        }

        public void ActualizarDocenteCatedra(DocenteCatedra docenteCatedra)
        {
            _context.DocenteCatedras.Update(docenteCatedra);
            
        }

        public async Task EliminarDocenteCatedra(long DocenteId)
        {
            var currentDocenteCatedra = await GetDocenteCatedra(DocenteId);
            _context.DocenteCatedras.Remove(currentDocenteCatedra);
 
        }

        //Docente Detalles Academicos
        public  IEnumerable<DocenteDetalle> GetDocenteDetalles()
        {
            return _context.DocenteDetalles.AsEnumerable();
        }

        public async Task<DocenteDetalle> GetDocenteDetalle(long DocenteId)
        {
            return await _context.DocenteDetalles.FindAsync(DocenteId);
        }

        public async Task InsertarDocenteDetalle(DocenteDetalle docenteDetalle)
        {
            await _context.DocenteDetalles.AddAsync(docenteDetalle);
            
        }

        public void ActualizarDocenteDetalle(DocenteDetalle docenteDetalle)
        {
            _context.DocenteDetalles.Update(docenteDetalle);
           
        }

        public async Task EliminarDocenteDetalle(long DocenteId)
        {
            var currentDocenteDetalle = await GetDocenteDetalle(DocenteId);
            _context.DocenteDetalles.Remove(currentDocenteDetalle);
            
        }

        public IEnumerable<DocenteDatosPersonale> GetDatosPersonales()
        {
            return _context.DocenteDatosPersonales.AsEnumerable();
        }

        public async Task<DocenteDatosPersonale> GetDatoPersonal(long DocenteId)
        {
            return await _context.DocenteDatosPersonales.FindAsync(DocenteId);
        }

        public async Task InsertarDatoPersonal(DocenteDatosPersonale datoPersonal)
        {
            await _context.DocenteDatosPersonales.AddAsync(datoPersonal);

        }

        public void ActualizarDatoPersonal(DocenteDatosPersonale datoPersonal)
        {
            _context.DocenteDatosPersonales.Update(datoPersonal);
        }

        public async Task EliminarDatoPersonal(long DocenteId)
        {
            var currentDatoPersonal = await GetDatoPersonal(DocenteId);
            _context.DocenteDatosPersonales.Remove(currentDatoPersonal);
        }

    }
}
