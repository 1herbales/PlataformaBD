using AutoMapper;
using BD.Response;
using Microsoft.AspNetCore.Mvc;
using Plataforma.Core.DTOs;
using Plataforma.Core.Entidades;
using Plataforma.Core.Interfaces;
using Plataforma.Core.QueryFilters;
using Plataforma.Core.Servicios;
using System;
using System.Collections.Generic;
using System.Net;


namespace BD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocentePlantumController(IDocentePlantumServicio docentePlantumServicio, IMapper mapper) : Controller
    {
        private readonly IDocentePlantumServicio _docentePlantumServicio = docentePlantumServicio;
        private readonly IMapper _mapper = mapper;



        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]


        public IActionResult GetDocentesPlantum([FromQuery] DocentePlantumQF docentePlantumqf)
        {
            var DocentesPlantum = _docentePlantumServicio.GetDocentesPlantum(docentePlantumqf);
            var docentesPlantumDTOS = _mapper.Map<IEnumerable<DocentePlantumDTO>>(DocentesPlantum);
            var response = new ApiResponse<IEnumerable<DocentePlantumDTO>>(docentesPlantumDTOS);
            return Ok(response);
        }

        [HttpGet("{DocenteId}")]
        public async Task<IActionResult> GetDocentePlantum(long DocenteId)
        {
            var DocentePlantum = await _docentePlantumServicio.GetDocentePlantum(DocenteId);
            var docenteplantumDTO = _mapper.Map<ProduccionAcademicaDTO>(DocentePlantum);
            var response = new ApiResponse<ProduccionAcademicaDTO>(docenteplantumDTO);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(DocentePlantumDTO docentePlantumDTO)
        {
            var docentePlantum = _mapper.Map<DocentePlantum>(docentePlantumDTO);
            await _docentePlantumServicio.InsertarDocentePlantum(docentePlantum);
            docentePlantumDTO = _mapper.Map<DocentePlantumDTO>(docentePlantum);
            var response = new ApiResponse<DocentePlantumDTO>(docentePlantumDTO);
            return Ok(response);

        }

        [HttpPut("{DocenteId}")]
        public async Task<IActionResult> Put(long DocenteId, DocentePlantumDTO docentePlantumDTO)
        {
            var docentePlantum = _mapper.Map<DocentePlantum>(docentePlantumDTO);
            docentePlantum.Id = DocenteId;
            await _docentePlantumServicio.ActualizarDocentePlantum(docentePlantum);
            var response = new ApiResponse<DocentePlantumDTO>(docentePlantumDTO);
            return Ok(response);
        }

        [HttpDelete("{DocenteId}")]
        public async Task<IActionResult> Delete(long DocenteId)
        {
            var result = await _docentePlantumServicio.EliminarDocentePlantum(DocenteId);
            var response = new ApiResponse<bool>(result);
            return Ok(response);


        }
    }

    }
