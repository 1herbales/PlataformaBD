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
using System.Linq;
using Plataforma.Core.CustomEntities;
using Plataforma.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;



namespace BD.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DocenteController(IDocenteServicio docenteServicio, IMapper mapper, IUriService uriService) : Controller
    {
        private readonly IDocenteServicio _docenteServicio = docenteServicio;
        private readonly IMapper _mapper = mapper;
        private readonly IUriService _uriService = uriService;

        // GET: api/<DocenteController>
                                                                    
        [HttpGet(Name = nameof(GetDocentes))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        
        public IActionResult GetDocentes([FromQuery] DocenteQF docenteqf)
        {
            var Docentes = _docenteServicio.GetDocentes(docenteqf);
            var docentesDTOS = _mapper.Map<IEnumerable<DocenteDTO>>(Docentes);
            var metadata = new Metadata
            {
                TotalCount = Docentes.TotalCount,
                PageSize = Docentes.PageSize,
                PageNumber = Docentes.PageNumber,
                TotalPages = Docentes.TotalPages,
                HasNext = Docentes.HasNext,
                HasPrevious = Docentes.HasPrevious,
                NextPageUrl = _uriService.GetPaginationUri(docenteqf, Url.RouteUrl(nameof(GetDocentes))).ToString(),
                PreviousPageUrl = _uriService.GetPaginationUri(docenteqf, Url.RouteUrl(nameof(GetDocentes))).ToString(),

            };

            var response = new ApiResponse<IEnumerable<DocenteDTO>>(docentesDTOS)
            {
                Meta = metadata
            };
            Response.Headers.Append("X-Pagination", Newtonsoft.Json.JsonConvert.SerializeObject(metadata));
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

