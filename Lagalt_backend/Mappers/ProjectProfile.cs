﻿using AutoMapper;
using Lagalt_backend.Data.DTOs.Projects;
using Lagalt_backend.Data.DTOs.User;
using Lagalt_backend.Data.Models.Entities;

namespace Lagalt_backend.Mappers {
    public class ProjectProfile : Profile {
        public ProjectProfile() {

            CreateMap<Project, ProjectsUAuthGetDTO>();

            CreateMap<Project, ProjectsAuthGetDTO>();

            CreateMap<Project, ProjectsListDTO>();

            CreateMap<Project, ProjectsPostDTO>().ReverseMap();

            CreateMap<Project, ProjectsPutDTO>().ReverseMap();

            CreateMap<Project, ProjectUserDTO>().ReverseMap();
        }
    }
}