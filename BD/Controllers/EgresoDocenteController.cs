using System.Net;
using AutoMapper;
using BD.Response;
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
    public class EgresoDocenteController(IDocentePlantumServicio docentePlantumServicio, IMapper mapper, IUriService uriService) : Controller
    {
        private readonly IDocentePlantumServicio _docentePlantumServicio = docentePlantumServicio;
        private readonly IMapper _mapper = mapper;
        private readonly IUriService _uriService = uriService;


        [HttpGet(Name = nameof(GetEgresos))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetEgresos([FromQuery] EgresoDocenteQF egresoDocenteqf)
        {
            var Egresos =  _docentePlantumServicio.GetEgresos(egresoDocenteqf);
            var egresosDTOS = _mapper.Map<IEnumerable<EgresoDocenteDTO>>(Egresos);
            var metadata = new Metadata
            {
                TotalCount = Egresos.TotalCount,
                PageSize = Egresos.PageSize,
                PageNumber = Egresos.PageNumber,
                TotalPages = Egresos.TotalPages,
                HasNext =   Egresos.HasNext,
                HasPrevious = Egresos.HasPrevious,
                NextPageUrl = _uriService.GetPaginationUri(egresoDocenteqf, Url.RouteUrl(nameof(GetEgresos))).ToString(),
                PreviousPageUrl = _uriService.GetPaginationUri(egresoDocenteqf, Url.RouteUrl(nameof(GetEgresos))).ToString(),

            };

            var response = new ApiResponse<IEnumerable<EgresoDocenteDTO>>(egresosDTOS)
            {
                Meta = metadata
            };
            Response.Headers.Append("X-Pagination", Newtonsoft.Json.JsonConvert.SerializeObject(metadata));
            return Ok(response);
        }

        [HttpGet("{DocenteId}")]
        public async Task<IActionResult> GetCategoria(long DocenteId)
        {
            var Egreso = await _docentePlantumServicio.GetEgreso(DocenteId);
            var egresoDTO = _mapper.Map<EgresoDocenteDTO>(Egreso);
            var response = new ApiResponse<EgresoDocenteDTO>(egresoDTO);
            return Ok(response);

        }

        [HttpPost]
        public async Task<IActionResult> Post(EgresoDocenteDTO egresoDTO)
        {
            var egreso = _mapper.Map<EgresoDocente>(egresoDTO);
            await _docentePlantumServicio.InsertarEgreso(egreso);
            egresoDTO = _mapper.Map<EgresoDocenteDTO>(egreso);
            var response = new ApiResponse<EgresoDocenteDTO>(egresoDTO);
            return Ok(response);

        }

        [HttpPut]
        public async Task<IActionResult> Put(long DocenteId, EgresoDocenteDTO egresoDTO)
        {
            var egreso = _mapper.Map<EgresoDocente>(egresoDTO);
            egreso.Id = DocenteId;
            await _docentePlantumServicio.ActualizarEgreso(egreso);
            var response = new ApiResponse<EgresoDocenteDTO>(egresoDTO);
            return Ok(response);


        }

        [HttpDelete("{DocenteId}")]
        public async Task<IActionResult> Delete(long DocenteId)
        {
            var result = await _docentePlantumServicio.EliminarEgreso(DocenteId);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
