using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Plataforma.Core.DTOs;
using Plataforma.Core.Entidades;


namespace Plataforma.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Docente, DocenteDTO>();
            CreateMap<DocenteDTO, Docente>();

            CreateMap<DocentePlantum, DocentePlantumDTO>();
            CreateMap<DocentePlantumDTO, DocentePlantum>();

            CreateMap<DocenteCatedra, DocenteCatedraDTO>();
            CreateMap<DocenteCatedraDTO, DocenteCatedra>();

            CreateMap<DocenteDetalle, DocenteDetalleDTO>();
            CreateMap<DocenteDetalleDTO, DocenteDetalle>();

            CreateMap<Pregrado, PregradoDTO>();
            CreateMap<PregradoDTO, Pregrado>();

            CreateMap<Especializacion, EspecializacionDTO>();
            CreateMap<EspecializacionDTO, Especializacion>();

            CreateMap<Magister, MagisterDTO>();
            CreateMap<MagisterDTO, Magister>();

            CreateMap<Doctorado, DoctoradoDTO>();
            CreateMap<DoctoradoDTO, Doctorado>();

            CreateMap<ProduccionAcademica, ProduccionAcademicaDTO>();
            CreateMap<ProduccionAcademicaDTO, ProduccionAcademica>();

            CreateMap<EgresoDocente, EgresoDocenteDTO>();
            CreateMap<EgresoDocenteDTO, EgresoDocente>();

            CreateMap<CategoriaDocente, CategoriaDocenteDTO>();
            CreateMap<CategoriaDocenteDTO, CategoriaDocente>();

            CreateMap<DocenteDatosPersonale, DocenteDatosPersonalesDTO>();
            CreateMap<DocenteDatosPersonalesDTO, DocenteDatosPersonale>();





        }
    }
}
