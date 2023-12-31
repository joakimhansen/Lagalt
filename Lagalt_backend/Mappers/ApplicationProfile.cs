﻿using AutoMapper;
using Lagalt_backend.Data.DTOs.Categories;
using Lagalt_backend.Data.DTOs.CollaboratorApplications;
using Lagalt_backend.Data.Models.Entities;

namespace Lagalt_backend.Mappers {
    public class ApplicationProfile : Profile {
        public ApplicationProfile() {
            CreateMap<CollaboratorApplication, ApplicationAcceptDTO>()
                .ForMember(dto => dto.Project, options => options
                    .MapFrom(application => application.ProjectNavigation.Title));
            CreateMap<CollaboratorApplication, ApplicationDTO>().ReverseMap();
            CreateMap<CollaboratorApplication, ApplicationPostDTO>().ReverseMap();
        }
    }
}
