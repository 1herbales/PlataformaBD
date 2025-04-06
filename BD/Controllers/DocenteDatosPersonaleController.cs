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
    public class DocenteDatosPersonaleController(IDocenteServicio docenteServicio, IMapper mapper5, IUriService uriService) : Controller
    {
        private readonly IDocenteServicio _docenteServicio = docenteServicio;
        private readonly IMapper _mapper5 = mapper5;
        private readonly IUriService _uriService = uriService;


        [HttpGet(Name = nameof(GetDatosPersonales))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public IActionResult GetDatosPersonales([FromQuery] DocenteDatosPersonaleQF docenteDatosPersonaleqf)
        {
            var DatosPersonales = _docenteServicio.GetDatosPersonales(docenteDatosPersonaleqf);
            var datosPersonalesDTOS = _mapper5.Map<IEnumerable<DocenteDatosPersonalesDTO>>(DatosPersonales);
            var metadata = new Metadata
            {
                TotalCount = DatosPersonales.TotalCount,
                PageSize = DatosPersonales.PageSize,
                PageNumber = DatosPersonales.PageNumber,
                TotalPages = DatosPersonales.TotalPages,
                HasNext = DatosPersonales.HasNext,
                HasPrevious = DatosPersonales.HasPrevious,
                NextPageUrl = _uriService.GetPaginationUri(docenteDatosPersonaleqf, Url.RouteUrl(nameof(GetDatosPersonales))).ToString(),
                PreviousPageUrl = _uriService.GetPaginationUri(docenteDatosPersonaleqf, Url.RouteUrl(nameof(GetDatosPersonales))).ToString(),

            };

            var response = new ApiResponse<IEnumerable<DocenteDatosPersonalesDTO>>(datosPersonalesDTOS)
            {
                Meta = metadata
            };
            Response.Headers.Append("X-Pagination", Newtonsoft.Json.JsonConvert.SerializeObject(metadata));
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
