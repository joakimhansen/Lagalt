using AutoMapper;
using Lagalt_backend.Data.DTOs.Projects;
using Lagalt_backend.Data.DTOs.User;
using Lagalt_backend.Data.Models.Entities;

namespace Lagalt_backend.Mappers {
    public class ProjectProfile : Profile {
        public ProjectProfile() {

            CreateMap<Project, ProjectsGetDTO>().ReverseMap();

            CreateMap<Project, ProjectsPostDTO>().ReverseMap();

            CreateMap<Project, ProjectsPutDTO>().ReverseMap();

            CreateMap<Project, ProjectUserDTO>().ReverseMap();
        }
    }
}
