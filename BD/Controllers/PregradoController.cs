using AutoMapper;
using BD.Response;
using Microsoft.AspNetCore.Mvc;
using Plataforma.Core.DTOs;
using Plataforma.Core.Entidades;
using Plataforma.Core.Interfaces;
using Plataforma.Core.Servicios;

namespace BD.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class PregradoController(IDocenteTitulosServicio docenteTitulosServicio, IMapper mapper) : Controller
    {
        private readonly IDocenteTitulosServicio _docenteTitulosServicio = docenteTitulosServicio;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public IActionResult GetPregrados()
        {
            var Pregrados = _docenteTitulosServicio.GetPregrados();
            var pregradosDTOS = _mapper.Map<IEnumerable<PregradoDTO>>(Pregrados);
            var response = new ApiResponse<IEnumerable<PregradoDTO>>(pregradosDTOS);
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
