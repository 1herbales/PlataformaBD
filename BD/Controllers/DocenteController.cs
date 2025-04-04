using AutoMapper;
using BD.Response;
using Microsoft.AspNetCore.Mvc;
using Plataforma.Core.DTOs;
using Plataforma.Core.Entidades;
using Plataforma.Core.Interfaces;
using Plataforma.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Net;


namespace BD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocenteController(IDocenteServicio docenteServicio, IMapper mapper) : Controller
    {
        private readonly IDocenteServicio _docenteServicio = docenteServicio;
        private readonly IMapper _mapper = mapper;


        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        
        public IActionResult GetDocentes([FromQuery] DocenteQF docenteqf)
        {
            var Docentes = _docenteServicio.GetDocentes(docenteqf);
            var docentesDTOS = _mapper.Map<IEnumerable<DocenteDTO>>(Docentes);
            var response = new ApiResponse<IEnumerable<DocenteDTO>>(docentesDTOS);
            return Ok(response);
        }

        [HttpGet("{DocenteId}")]
        
        public async Task<IActionResult> GetDocente(long DocenteId)
        {
            var Docente = await _docenteServicio.GetDocente(DocenteId);
            var docenteDTO = _mapper.Map<DocenteDTO>(Docente);
            var response = new ApiResponse<DocenteDTO>(docenteDTO);
            return Ok(response);

        }

        [HttpPost]
        public async Task<IActionResult> Post(DocenteDTO docenteDTO)
        {
            var docente = _mapper.Map<Docente>(docenteDTO);
            await _docenteServicio.InsertarDocente(docente);
            docenteDTO = _mapper.Map<DocenteDTO>(docente);
            var response = new ApiResponse<DocenteDTO>(docenteDTO);
            return Ok(response);

        }

        [HttpPut]
        public async Task<IActionResult> Put(long DocenteId, DocenteDTO docenteDTO)
        {
            var docente = _mapper.Map<Docente>(docenteDTO);
            docente.Id = DocenteId;
            await _docenteServicio.ActualizarDocente(docente);
            var response = new ApiResponse<DocenteDTO>(docenteDTO);
            return Ok(response);


        }

        [HttpDelete("{DocenteId}")]
        public async Task<IActionResult> Delete(long DocenteId)
        {
            var result = await _docenteServicio.EliminarDocente(DocenteId);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
  }

