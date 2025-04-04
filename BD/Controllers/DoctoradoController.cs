using System.Net;
using AutoMapper;
using BD.Response;
using Microsoft.AspNetCore.Mvc;
using Plataforma.Core.DTOs;
using Plataforma.Core.Entidades;
using Plataforma.Core.Interfaces;
using Plataforma.Core.QueryFilters;
using Plataforma.Core.Servicios;

namespace BD.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctoradoController(IDocenteTitulosServicio docenteTitulosServicio, IMapper mapper) : Controller
    {
        private readonly IDocenteTitulosServicio _docenteTitulosServicio = docenteTitulosServicio;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetDoctorados([FromQuery] DoctoradoQF doctoradoqf)
        {
            var Doctorados = _docenteTitulosServicio.GetDoctorados(doctoradoqf);
            var doctoradosDTOS = _mapper.Map<IEnumerable<DoctoradoDTO>>(Doctorados);
            var response = new ApiResponse<IEnumerable<DoctoradoDTO>>(doctoradosDTOS);
            return Ok(response);
        }

        [HttpGet("{DocenteId}")]
        public async Task<IActionResult> GetDoctorado(long DocenteId)
        {
            var Doctorado = await _docenteTitulosServicio.GetDoctorado(DocenteId);
            var doctoradoDTO = _mapper.Map<DoctoradoDTO>(Doctorado);
            var response = new ApiResponse<DoctoradoDTO>(doctoradoDTO);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(DoctoradoDTO doctoradoDTO)
        {
            var doctorado = _mapper.Map<Doctorado>(doctoradoDTO);
            await _docenteTitulosServicio.InsertarDoctorado(doctorado);
            doctoradoDTO = _mapper.Map<DoctoradoDTO>(doctorado);
            var response = new ApiResponse<DoctoradoDTO>(doctoradoDTO);
            return Ok(response);

        }

        [HttpPut("{DocenteId}")]
        public async Task<IActionResult> Put(long DocenteId, DoctoradoDTO doctoradoDTO)
        {
            var doctorado = _mapper.Map<Doctorado>(doctoradoDTO);
            doctorado.Id = DocenteId;
            await _docenteTitulosServicio.ActualizarDoctorado(doctorado);
            var response = new ApiResponse<DoctoradoDTO>(doctoradoDTO);
            return Ok(response);
        }

        [HttpDelete("{DocenteId}")]
        public async Task<IActionResult> Delete(long DocenteId)
        {
            var result = await _docenteTitulosServicio.EliminarDoctorado(DocenteId);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

    }
}

