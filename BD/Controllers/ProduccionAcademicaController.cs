﻿using System.Net;
using AutoMapper;
using BD.Response;
using Microsoft.AspNetCore.Mvc;
using Plataforma.Core.DTOs;
using Plataforma.Core.Entidades;
using Plataforma.Core.Interfaces;
using Plataforma.Core.QueryFilters;

namespace BD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduccionAcademicaController(IDocentePlantumServicio docentePlantumServicio, IMapper mapper) : Controller
    {
        private readonly IDocentePlantumServicio _docentePlantumServicio = docentePlantumServicio;
        private readonly IMapper _mapper = mapper;


        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public IActionResult GetProducciones([FromQuery] ProduccionAcademicaQF produccionAcademicaqf)
        {
            var Producciones = _docentePlantumServicio.GetProducciones(produccionAcademicaqf);
            var produccionesDTOS = _mapper.Map<IEnumerable<ProduccionAcademicaDTO>>(Producciones);
            var response = new ApiResponse<IEnumerable<ProduccionAcademicaDTO>>(produccionesDTOS);
            var metadata = new
            {
                Producciones.TotalCount,
                Producciones.PageSize,
                Producciones.PageNumber,
                Producciones.TotalPages,
                Producciones.HasNext,
                Producciones.HasPrevious

            };
            Response.Headers.Append("X-Pagination", Newtonsoft.Json.JsonConvert.SerializeObject(metadata));
            return Ok(response);
        }
        

        [HttpGet("{DocenteId}")]
        public async Task<IActionResult> GetCategoria(long DocenteId)
        {
            var Produccion = await _docentePlantumServicio.GetProduccion(DocenteId);
            var produccionDTO = _mapper.Map<ProduccionAcademicaDTO>(Produccion);
            var response = new ApiResponse<ProduccionAcademicaDTO>(produccionDTO);
            return Ok(response);

        }

        [HttpPost]
        public async Task<IActionResult> Post(ProduccionAcademicaDTO produccionDTO)
        {
            var produccion = _mapper.Map<ProduccionAcademica>(produccionDTO);
            await _docentePlantumServicio.InsertarProduccion(produccion);
            produccionDTO = _mapper.Map<ProduccionAcademicaDTO>(produccion);
            var response = new ApiResponse<ProduccionAcademicaDTO>(produccionDTO);
            return Ok(response);

        }

        [HttpPut]
        public async Task<IActionResult> Put(long DocenteId, ProduccionAcademicaDTO produccionDTO)
        {
            var produccion = _mapper.Map<ProduccionAcademica>(produccionDTO);
            produccion.Id = DocenteId;
            await _docentePlantumServicio.ActualizarProduccion(produccion);
            var response = new ApiResponse<ProduccionAcademicaDTO>(produccionDTO);
            return Ok(response);


        }

        [HttpDelete("{DocenteId}")]
        public async Task<IActionResult> Delete(long DocenteId)
        {
            var result = await _docentePlantumServicio.EliminarProduccion(DocenteId);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
