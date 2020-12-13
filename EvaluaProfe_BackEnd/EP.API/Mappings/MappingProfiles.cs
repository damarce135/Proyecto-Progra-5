using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EP.API.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //CreateMap<DO.Objects.CalEtiqueta, Models.CalEtiqueta>().ReverseMap();
            CreateMap<DO.Objects.Calificacion, Models.Calificacion>().ReverseMap();
            CreateMap<DO.Objects.Carrera, Models.Carrera>().ReverseMap();
            CreateMap<DO.Objects.Curso, Models.Curso>().ReverseMap();
            //CreateMap<DO.Objects.CursoCarrera, Models.CursoCarrera>().ReverseMap();
            CreateMap<DO.Objects.Etiqueta, Models.Etiqueta>().ReverseMap();
            //CreateMap<DO.Objects.ProfCurso, Models.ProfCurso>().ReverseMap();
            CreateMap<DO.Objects.Profesor, Models.Profesor>().ReverseMap();
        }
    }
}
