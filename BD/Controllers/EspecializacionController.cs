using System.Net;
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
    public class EspecializacionController(IDocenteTitulosServicio docenteTitulosServicio, IMapper mapper4, IUriService uriService) : Controller
    {
        private readonly IDocenteTitulosServicio _docenteTitulosServicio = docenteTitulosServicio;
        private readonly IMapper _mapper4 = mapper4;
        private readonly IUriService _uriService = uriService;

        [HttpGet(Name = nameof(GetEspecializaciones))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public IActionResult GetEspecializaciones([FromQuery] EspecializacionQF especializacionqf)
        {
            var Especializaciones = _docenteTitulosServicio.GetEspecializaciones(especializacionqf);
            var especializacionesDTOS = _mapper4.Map<IEnumerable<EspecializacionDTO>>(Especializaciones);
            var metadata = new Metadata
            {
                TotalCount = Especializaciones.TotalCount,
                PageSize = Especializaciones.PageSize,
                PageNumber = Especializaciones.PageNumber,
                TotalPages = Especializaciones.TotalPages,
                HasNext = Especializaciones.HasNext,
                HasPrevious = Especializaciones.HasPrevious,
                NextPageUrl = _uriService.GetPaginationUri(especializacionqf, Url.RouteUrl(nameof(GetEspecializaciones))).ToString(),
                PreviousPageUrl = _uriService.GetPaginationUri(especializacionqf, Url.RouteUrl(nameof(GetEspecializaciones))).ToString(),

            };

            var response = new ApiResponse<IEnumerable<EspecializacionDTO>>(especializacionesDTOS)
            {
                Meta = metadata
            };
            Response.Headers.Append("X-Pagination", Newtonsoft.Json.JsonConvert.SerializeObject(metadata));
            return Ok(response);
        }

        [HttpGet("{DocenteId}")]
        public async Task<IActionResult> GetEspecializacion(long DocenteId)
        {
            var Especializacion = await _docenteTitulosServicio.GetEspecializacion(DocenteId);
            var especializacionDTO = _mapper4.Map<EspecializacionDTO>(Especializacion);
            var response = new ApiResponse<EspecializacionDTO>(especializacionDTO);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(EspecializacionDTO especializacionDTO)
        {
            var especializacion = _mapper4.Map<Especializacion>(especializacionDTO);
            await _docenteTitulosServicio.InsertarEspecializacion(especializacion);
            especializacionDTO = _mapper4.Map<EspecializacionDTO>(especializacion);
            var response = new ApiResponse<EspecializacionDTO>(especializacionDTO);
            return Ok(response);

        }

        [HttpPut("{DocenteId}")]
        public async Task<IActionResult> Put(long DocenteId, EspecializacionDTO especializacionDTO)
        {
            var especializacion = _mapper4.Map<Especializacion>(especializacionDTO);
            especializacion.Id = DocenteId;
            await _docenteTitulosServicio.ActualizarEspecializacion(especializacion);
            var response = new ApiResponse<EspecializacionDTO>(especializacionDTO);
            return Ok(response);
        }

        [HttpDelete("{DocenteId}")]
        public async Task<IActionResult> Delete(long DocenteId)
        {
            var result = await _docenteTitulosServicio.EliminarEspecializacion(DocenteId);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

    }
}

