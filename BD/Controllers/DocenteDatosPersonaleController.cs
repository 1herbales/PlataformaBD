using AutoMapper;
using BD.Response;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Plataforma.Core.DTOs;
using Plataforma.Core.Entidades;
using Plataforma.Core.Interfaces;
using Plataforma.Core.QueryFilters;
using Plataforma.Core.Servicios;

namespace BD.Controllers
{
    [ApiController]
    public class DocenteDatosPersonaleController(IDocenteServicio docenteServicio, IMapper mapper5) : Controller
    {
        private readonly IDocenteServicio _docenteServicio = docenteServicio;
        private readonly IMapper _mapper5 = mapper5;

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public IActionResult GetDatosPersonales([FromQuery] DocenteDatosPersonaleQF docenteDatosPersonaleqf)
        {
            var DatosPersonales = _docenteServicio.GetDatosPersonales(docenteDatosPersonaleqf);
            var datosPersonalesDTOS = _mapper5.Map<IEnumerable<DocenteDatosPersonalesDTO>>(DatosPersonales);
            var response = new ApiResponse<IEnumerable<DocenteDatosPersonalesDTO>>(datosPersonalesDTOS);
            return Ok(response);
        }

        [HttpGet("{DocenteId}")]
        public async Task<IActionResult> GetDatoPersonal(long DocenteId)
        {
            var DatoPersonal = await _docenteServicio.GetDatoPersonal(DocenteId);
            var datopersonalDTO = _mapper5.Map<DocenteDatosPersonalesDTO>(DatoPersonal);
            var response = new ApiResponse<DocenteDatosPersonalesDTO>(datopersonalDTO);
            return Ok(response);

        }

        [HttpPost]
        public async Task<IActionResult> Post(DocenteDatosPersonalesDTO datoPersonalDTO)
        {
            var datoPersonal = _mapper5.Map<DocenteDatosPersonale>(datoPersonalDTO);
            await _docenteServicio.InsertarDatoPersonal(datoPersonal);
            datoPersonalDTO = _mapper5.Map<DocenteDatosPersonalesDTO>(datoPersonal);
            var response = new ApiResponse<DocenteDatosPersonalesDTO>(datoPersonalDTO);
            return Ok(response);

        }

        [HttpPut("{DocenteId}")]
        public async Task<IActionResult> Put(long DocenteId, DocenteDatosPersonalesDTO datoPersonalDTO)
        {
            var datoPersonal = _mapper5.Map<DocenteDatosPersonale>(datoPersonalDTO);
            datoPersonal.Id = DocenteId;
            await _docenteServicio.ActualizarDatoPersonal(datoPersonal);
            var response = new ApiResponse<DocenteDatosPersonalesDTO>(datoPersonalDTO);
            return Ok(response);


        }

        [HttpDelete("{DocenteId}")]
        public async Task<IActionResult> Delete(long DocenteId)
        {
            var result = await _docenteServicio.EliminarDatoPersonal(DocenteId);
            var response = new ApiResponse<bool>(result);
            return Ok(response);


        }
    }
}
