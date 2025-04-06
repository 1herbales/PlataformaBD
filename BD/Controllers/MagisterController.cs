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
    public class MagisterController(IDocenteTitulosServicio docenteTitulosServicio, IMapper mapper, IUriService uriService) : Controller
    {
        private readonly IDocenteTitulosServicio _docenteTitulosServicio = docenteTitulosServicio;
        private readonly IMapper _mapper = mapper;
        private readonly IUriService _uriService = uriService;

        [HttpGet(Name = nameof(GetMagisters))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public IActionResult GetMagisters([FromQuery]MagisterQF magisterqf)
        {
            var Magisters = _docenteTitulosServicio.GetMagisters(magisterqf);
            var magistersDTOS = _mapper.Map<IEnumerable<MagisterDTO>>(Magisters);
            var metadata = new Metadata
            {
                TotalCount = Magisters.TotalCount,
                PageSize = Magisters.PageSize,
                PageNumber = Magisters.PageNumber,
                TotalPages = Magisters.TotalPages,
                HasNext = Magisters.HasNext,
                HasPrevious = Magisters.HasPrevious,
                NextPageUrl = _uriService.GetPaginationUri(magisterqf, Url.RouteUrl(nameof(GetMagisters))).ToString(),
                PreviousPageUrl = _uriService.GetPaginationUri(magisterqf, Url.RouteUrl(nameof(GetMagisters))).ToString(),

            };

            var response = new ApiResponse<IEnumerable<MagisterDTO>>(magistersDTOS)
            {
                Meta = metadata
            };
            Response.Headers.Append("X-Pagination", Newtonsoft.Json.JsonConvert.SerializeObject(metadata));
            return Ok(response);
        }

        [HttpGet("{DocenteId}")]
        public async Task<IActionResult> GetMagister(long DocenteId)
        {
            var Magister = await _docenteTitulosServicio.GetMagister(DocenteId);
            var magisterDTO = _mapper.Map<MagisterDTO>(Magister);
            var response = new ApiResponse<MagisterDTO>(magisterDTO);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(MagisterDTO magisterDTO)
        {
            var magister = _mapper.Map<Magister>(magisterDTO);
            await _docenteTitulosServicio.InsertarMagister(magister);
            magisterDTO = _mapper.Map<MagisterDTO>(magister);
            var response = new ApiResponse<MagisterDTO>(magisterDTO);
            return Ok(response);

        }

        [HttpPut("{DocenteId}")]
        public async Task<IActionResult> Put(long DocenteId, MagisterDTO magisterDTO)
        {
            var magister = _mapper.Map<Magister>(magisterDTO);
            magister.Id = DocenteId;
            await _docenteTitulosServicio.ActualizarMagister(magister);
            var response = new ApiResponse<MagisterDTO>(magisterDTO);
            return Ok(response);
        }

        [HttpDelete("{DocenteId}")]
        public async Task<IActionResult> Delete(long DocenteId)
        {
            var result = await _docenteTitulosServicio.EliminarMagister(DocenteId);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

    }
}
