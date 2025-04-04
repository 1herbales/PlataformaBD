using System.Net;
using AutoMapper;
using BD.Response;
using Microsoft.AspNetCore.Mvc;
using Plataforma.Core.DTOs;
using Plataforma.Core.Entidades;
using Plataforma.Core.Interfaces;
using Plataforma.Core.QueryFilters;


namespace BD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaDocenteController(IDocentePlantumServicio docentePlantumServicio, IMapper mapper) : Controller
    {
        private readonly IDocentePlantumServicio _docentePlantumServicio = docentePlantumServicio;
        private readonly IMapper _mapper = mapper;


        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetCategorias([FromQuery] CategoriaDocenteQF categoriaDocenteqf)
        {
            var Categorias =  _docentePlantumServicio.GetCategorias(categoriaDocenteqf);
            var categoriasDTOS = _mapper.Map<IEnumerable<CategoriaDocenteDTO>>(Categorias);
            var response = new ApiResponse<IEnumerable<CategoriaDocenteDTO>>(categoriasDTOS);
            var metadata = new
            {
                Categorias.TotalCount,
                Categorias.PageSize,
                Categorias.PageNumber,
                Categorias.TotalPages,
                Categorias.HasNext,
                Categorias.HasPrevious

            };
            Response.Headers.Append("X-Pagination", Newtonsoft.Json.JsonConvert.SerializeObject(metadata));
            return Ok(response);
        }

        [HttpGet("{DocenteId}")]
        public async Task<IActionResult> GetCategoria(long DocenteId)
        {
            var Categoria = await _docentePlantumServicio.GetCategoria(DocenteId);
            var categoriaDTO = _mapper.Map<CategoriaDocenteDTO>(Categoria);
            var response = new ApiResponse<CategoriaDocenteDTO>(categoriaDTO);
            return Ok(response);

        }

        [HttpPost]
        public async Task<IActionResult> Post(CategoriaDocenteDTO categoriaDTO)
        {
            var categoria = _mapper.Map<CategoriaDocente>(categoriaDTO);
            await _docentePlantumServicio.InsertarCategoria(categoria);
            categoriaDTO = _mapper.Map<CategoriaDocenteDTO>(categoria);
            var response = new ApiResponse<CategoriaDocenteDTO>(categoriaDTO);
            return Ok(response);

        }

        [HttpPut]
        public async Task<IActionResult> Put(long DocenteId, CategoriaDocenteDTO categoriaDTO)
        {
            var categoria = _mapper.Map<CategoriaDocente>(categoriaDTO);
            categoria.Id = DocenteId;
            await _docentePlantumServicio.ActualizarCategoria(categoria);
            var response = new ApiResponse<CategoriaDocenteDTO>(categoriaDTO);
            return Ok(response);


        }

        [HttpDelete("{DocenteId}")]
        public async Task<IActionResult> Delete(long DocenteId)
        {
            var result = await _docentePlantumServicio.EliminarCategoria(DocenteId);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
