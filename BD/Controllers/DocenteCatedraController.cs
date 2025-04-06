
using AutoMapper;
using BD.Response;
using Microsoft.AspNetCore.Mvc;
using Plataforma.Core.CustomEntities;
using Plataforma.Core.DTOs;
using Plataforma.Core.Entidades;
using Plataforma.Core.Interfaces;
using Plataforma.Core.QueryFilters;
using Plataforma.Infrastructure.Interfaces;
using Plataforma.Infrastructure.Servicios;
using System;
using System.Collections.Generic;
using System.Net;




namespace BD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocenteCatedraController(IDocenteServicio docenteServicio, IMapper mapper1, IUriService uriService) : Controller
    {
        private readonly IDocenteServicio _docenteServicio = docenteServicio;
        private readonly IMapper _mapper1 = mapper1;
        private readonly IUriService _uriService = uriService;


        [HttpGet(Name = nameof(GetDocenteCatedras))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public IActionResult GetDocenteCatedras([FromQuery] DocenteCatedraQF docenteCatedraqf)
        {
            var DocenteCatedras = _docenteServicio.GetDocenteCatedras(docenteCatedraqf);
            var docenteCatedrasDTO = _mapper1.Map<IEnumerable<DocenteCatedraDTO>>(DocenteCatedras);
            var metadata = new Metadata
            {
                TotalCount = DocenteCatedras.TotalCount,
                PageSize = DocenteCatedras.PageSize,
                PageNumber = DocenteCatedras.PageNumber,
                TotalPages = DocenteCatedras.TotalPages,
                HasNext = DocenteCatedras.HasNext,
                HasPrevious = DocenteCatedras.HasPrevious,
                NextPageUrl = _uriService.GetPaginationUri(docenteCatedraqf, Url.RouteUrl(nameof(GetDocenteCatedras))).ToString(),
                PreviousPageUrl = _uriService.GetPaginationUri(docenteCatedraqf, Url.RouteUrl(nameof(GetDocenteCatedras))).ToString(),

            };

            var response = new ApiResponse<IEnumerable<DocenteCatedraDTO>>(docenteCatedrasDTO)
            {
                Meta = metadata
            };
            Response.Headers.Append("X-Pagination", Newtonsoft.Json.JsonConvert.SerializeObject(metadata));
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