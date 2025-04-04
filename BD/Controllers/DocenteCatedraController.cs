
using AutoMapper;
using BD.Response;
using Microsoft.AspNetCore.Mvc;
using Plataforma.Core.DTOs;
using Plataforma.Core.Entidades;
using Plataforma.Core.Interfaces;
using System;
using System.Collections.Generic;




namespace BD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocenteCatedraController(IDocenteServicio docenteServicio, IMapper mapper1) : Controller
    {
        private readonly IDocenteServicio _docenteServicio = docenteServicio;
        private readonly IMapper _mapper1 = mapper1;

        [HttpGet]
        public IActionResult GetDocenteCatedras()
        {
            var DocenteCatedras = _docenteServicio.GetDocenteCatedras();
            var docenteCatedrasDTO = _mapper1.Map<IEnumerable<DocenteCatedraDTO>>(DocenteCatedras);
            var response = new ApiResponse<IEnumerable<DocenteCatedraDTO>>(docenteCatedrasDTO);
            return Ok(response);
        }

        [HttpGet("{DocenteId}")]
        public async Task<IActionResult> GetDocenteCatedra(long DocenteId)
        {
            var DocenteCatedra = await _docenteServicio.GetDocenteCatedra(DocenteId);
            var docenteCatedraDTO = _mapper1.Map<DocenteCatedraDTO>(DocenteCatedra);
            var response = new ApiResponse<DocenteCatedraDTO>(docenteCatedraDTO);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(DocenteCatedraDTO docenteCatedraDTO)
        {
            var docenteCatedra = _mapper1.Map<DocenteCatedra>(docenteCatedraDTO);
            await _docenteServicio.InsertarDocenteCatedra(docenteCatedra);
            docenteCatedraDTO = _mapper1.Map<DocenteCatedraDTO>(docenteCatedra);
            var response = new ApiResponse<DocenteCatedraDTO>(docenteCatedraDTO);
            return Ok(response);
        }

        [HttpPut("{DocenteId}")]
        public async Task<IActionResult> Put(long DocenteId, DocenteCatedraDTO docenteCatedraDTO)
        {
            var docenteCatedra = _mapper1.Map<DocenteCatedra>(docenteCatedraDTO);
            docenteCatedra.DocenteId = DocenteId;
            await _docenteServicio.ActualizarDocenteCatedra(docenteCatedra);
            var response = new ApiResponse<DocenteCatedraDTO>(docenteCatedraDTO);
            return Ok(response);
        }

        [HttpDelete("{DocenteId}")]
        public async Task<IActionResult> Delete(long DocenteId)
        {
            var result = await _docenteServicio.EliminarDocenteCatedra(DocenteId);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}