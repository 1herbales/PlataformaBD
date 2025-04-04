using AutoMapper;
using BD.Response;
using Microsoft.AspNetCore.Mvc;
using Plataforma.Core.DTOs;
using Plataforma.Core.Entidades;
using Plataforma.Core.Interfaces;

namespace BD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EgresoDocenteController(IDocentePlantumServicio docentePlantumServicio, IMapper mapper) : Controller
    {
        private readonly IDocentePlantumServicio _docentePlantumServicio = docentePlantumServicio;
        private readonly IMapper _mapper = mapper;


        [HttpGet]
        public IActionResult GetEgresos()
        {
            var Egresos =  _docentePlantumServicio.GetEgresos();
            var egresosDTOS = _mapper.Map<IEnumerable<EgresoDocenteDTO>>(Egresos);
            var response = new ApiResponse<IEnumerable<EgresoDocenteDTO>>(egresosDTOS);
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
