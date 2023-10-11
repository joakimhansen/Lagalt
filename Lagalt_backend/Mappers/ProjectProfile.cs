using AutoMapper;
using Lagalt_backend.Data.DTOs.CollaboratorApplications;
using Lagalt_backend.Data.DTOs.Projects;
using Lagalt_backend.Data.Models.Entities;

namespace Lagalt_backend.Mappers {
    public class ProjectProfile : Profile {
        public ProjectProfile() {

            CreateMap<Project, ProjectsUAuthGetDTO>();

            //CreateMap<Project, ProjectsAuthGetDTO>()
            //    .ForMember(projectDto => projectDto.Creator, options => options
            //        .MapFrom(project => project.Creator));

            //CreateMap<Project, ProjectsListDTO>()
            //    .ForMember(projectDto => projectDto.Creator, options => options
            //        .MapFrom(project => project.Creator));

            CreateMap<Project, ProjectsAuthGetDTO>()
                .ForMember(projectDto => projectDto.Applications, options => options
                    .MapFrom(project => project.CollaboratorApplications))
                .ForMember(projectDto => projectDto.NeededSkills, options => options
                    .MapFrom(project => project.Skills.Select(skill => skill.Name)));

            CreateMap<Project, ProjectsListDTO>()
                .ForMember(projectDto => projectDto.Applications, options => options
                    .MapFrom(project => project.CollaboratorApplications))
                .ForMember(projectDto => projectDto.NeededSkills, options => options
                    .MapFrom(project => project.Skills.Select(skill => skill.Name)));


            CreateMap<Project, ProjectsPostDTO>().ReverseMap();

            CreateMap<Project, ProjectsPutDTO>().ReverseMap();

            CreateMap<Project, ProjectUserDTO>().ReverseMap();
        }
    }
}
