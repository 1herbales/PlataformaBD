﻿using System.Net;
using AutoMapper;
using BD.Response;
using Microsoft.AspNetCore.Mvc;
using Plataforma.Core.CustomEntities;
using Plataforma.Core.DTOs;
using Plataforma.Core.Entidades;
using Plataforma.Core.Interfaces;
using Plataforma.Core.QueryFilters;
using Plataforma.Core.Servicios;
using Plataforma.Infrastructure.Interfaces;

namespace BD.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class PregradoController(IDocenteTitulosServicio docenteTitulosServicio, IMapper mapper, IUriService uriService) : Controller
    {
        private readonly IDocenteTitulosServicio _docenteTitulosServicio = docenteTitulosServicio;
        private readonly IMapper _mapper = mapper;
        private readonly IUriService _uriService = uriService;

        [HttpGet(Name = nameof(GetPregrados))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetPregrados([FromQuery] PregradoQF pregradoqf)
        {
            var Pregrados = _docenteTitulosServicio.GetPregrados(pregradoqf);
            var pregradosDTOS = _mapper.Map<IEnumerable<PregradoDTO>>(Pregrados);
            var metadata = new Metadata
            {
                TotalCount = Pregrados.TotalCount,
                PageSize = Pregrados.PageSize,
                PageNumber = Pregrados.PageNumber,
                TotalPages = Pregrados.TotalPages,
                HasNext = Pregrados.HasNext,
                HasPrevious = Pregrados.HasPrevious,
                NextPageUrl = _uriService.GetPaginationUri(pregradoqf, Url.RouteUrl(nameof(GetPregrados))).ToString(),
                PreviousPageUrl = _uriService.GetPaginationUri(pregradoqf, Url.RouteUrl(nameof(GetPregrados))).ToString(),
                
            };

            var response = new ApiResponse<IEnumerable<PregradoDTO>>(pregradosDTOS)
            {
                Meta = metadata
            };
            Response.Headers.Append("X-Pagination", Newtonsoft.Json.JsonConvert.SerializeObject(metadata));
            return Ok(response);
        }
        


        [HttpGet("{DocenteId}")]
        public async Task<IActionResult> GetPregrado (long DocenteId)
        {
            var Pregrado = await _docenteTitulosServicio.GetPregrado(DocenteId);
            var pregradoDTO = _mapper.Map<PregradoDTO>(Pregrado);
            var response = new ApiResponse<PregradoDTO>(pregradoDTO);
            return Ok(response);
        }

     [HttpPost]
    public async Task<IActionResult> Post(PregradoDTO pregradoDTO)
    {
        var pregrado = _mapper.Map<Pregrado>(pregradoDTO);
        await _docenteTitulosServicio.InsertarPregrado(pregrado);
        pregradoDTO = _mapper.Map<PregradoDTO>(pregrado);
        var response = new ApiResponse<PregradoDTO>(pregradoDTO);
        return Ok(response);

    }

    [HttpPut("{DocenteId}")]
    public async Task<IActionResult> Put(long DocenteId, PregradoDTO pregradoDTO)
    {
        var pregrado = _mapper.Map<Pregrado>(pregradoDTO);
        pregrado.Id = DocenteId;
        await _docenteTitulosServicio.ActualizarPregrado(pregrado);
        var response = new ApiResponse<PregradoDTO>(pregradoDTO);
        return Ok(response);
    }

    [HttpDelete("{DocenteId}")]
    public async Task<IActionResult> Delete(long DocenteId)
    {
        var result = await _docenteTitulosServicio.EliminarPregrado(DocenteId);
        var response = new ApiResponse<bool>(result);
        return Ok(response);


    }

}
}
