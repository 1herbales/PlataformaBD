using System.Net;
using AutoMapper;
using BD.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Plataforma.Core.CustomEntities;
using Plataforma.Core.DTOs;
using Plataforma.Core.Entidades;
using Plataforma.Core.Interfaces;
using Plataforma.Core.QueryFilters;
using Plataforma.Infrastructure.Interfaces;

namespace BD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocenteDetalleController(IDocenteServicio docenteServicio, IMapper mapper3, IUriService uriService) : Controller
    {
        private readonly IDocenteServicio _docenteServicio = docenteServicio;
        private readonly IMapper _mapper3 = mapper3;
        private readonly IUriService _uriService = uriService;


        [HttpGet(Name = nameof(GetDocenteDetalles))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public IActionResult GetDocenteDetalles([FromQuery] DocenteDetalleQF docenteDetalleqf)
        {
            var DocentesDetalles = _docenteServicio.GetDocenteDetalles(docenteDetalleqf);
            var docentesDetallesDTOS = _mapper3.Map<IEnumerable<DocenteDetalleDTO>>(DocentesDetalles);
            var metadata = new Metadata
            {
                TotalCount = DocentesDetalles.TotalCount,
                PageSize = DocentesDetalles.PageSize,
                PageNumber = DocentesDetalles.PageNumber,
                TotalPages = DocentesDetalles.TotalPages,
                HasNext = DocentesDetalles.HasNext,
                HasPrevious = DocentesDetalles.HasPrevious,
                NextPageUrl = _uriService.GetPaginationUri(docenteDetalleqf, Url.RouteUrl(nameof(GetDocenteDetalles))).ToString(),
                PreviousPageUrl = _uriService.GetPaginationUri(docenteDetalleqf, Url.RouteUrl(nameof(GetDocenteDetalles))).ToString(),

            };

            var response = new ApiResponse<IEnumerable<DocenteDetalleDTO>>(docentesDetallesDTOS)
            {
                Meta = metadata
            };
            Response.Headers.Append("X-Pagination", Newtonsoft.Json.JsonConvert.SerializeObject(metadata));
            return Ok(response);

        }

        [HttpGet("{DocenteId}")]
        public async Task<IActionResult> GetDocenteDetalle(long DocenteId)
        {
            var DocenteDetalle = await _docenteServicio.GetDocenteDetalle(DocenteId);
            var docenteDetalleDTO = _mapper3.Map<DocenteDetalleDTO>(DocenteDetalle);
            var response = new ApiResponse<DocenteDetalleDTO>(docenteDetalleDTO);
            return Ok(response);

        }

        [HttpPost]
        public async Task<IActionResult> Post(DocenteDetalleDTO docenteDetalleDTO)
        {
            var docenteDetalle = _mapper3.Map<DocenteDetalle>(docenteDetalleDTO);
            await _docenteServicio.InsertarDocenteDetalle(docenteDetalle);
            docenteDetalleDTO = _mapper3.Map<DocenteDetalleDTO>(docenteDetalle);
            var response = new ApiResponse<DocenteDetalleDTO>(docenteDetalleDTO);
            return Ok(response);

        }

        [HttpPut("{DocenteId}")]
        public async Task<IActionResult> Put(long DocenteId, DocenteDetalleDTO docenteDetalleDTO)
        {
            var docenteDetalle = _mapper3.Map<DocenteDetalle>(docenteDetalleDTO);
            docenteDetalle.Id = DocenteId;
            await _docenteServicio.ActualizarDocenteDetalle(docenteDetalle);
            var response = new ApiResponse<DocenteDetalleDTO>(docenteDetalleDTO);
            return Ok(response);


        }

        [HttpDelete("{DocenteId}")]
        public async Task<IActionResult> Delete(long DocenteId)
        {
            var result = await _docenteServicio.EliminarDocenteDetalle(DocenteId);
            var response = new ApiResponse<bool>(result);
            return Ok(response);


        }
    }
}
