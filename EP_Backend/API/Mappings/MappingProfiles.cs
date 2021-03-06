﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<DO.Objects.Calificacion, Models.Calificacion>().ReverseMap();
            CreateMap<DO.Objects.Carrera, Models.Carrera>().ReverseMap();
            CreateMap<DO.Objects.Curso, Models.Curso>().ReverseMap();
            CreateMap<DO.Objects.Etiquetum, Models.Etiquetum>().ReverseMap();
            CreateMap<DO.Objects.Profesor, Models.Profesor>().ReverseMap();
            CreateMap<DO.Objects.Solicitud, Models.Solicitud>().ReverseMap();
        }
    }
}
