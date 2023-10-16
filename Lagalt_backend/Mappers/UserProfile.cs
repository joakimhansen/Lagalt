using AutoMapper;
using Lagalt_backend.Data.DTOs.CollaboratorApplications;
using Lagalt_backend.Data.DTOs.User;
using Lagalt_backend.Data.Models.Entities;

namespace Lagalt_backend.Mappers {
    public class UserProfile : Profile {
        public UserProfile() {
            CreateMap<User, UserDTO>()
                .ForMember(userDto => userDto.Projects, options => options
                    .MapFrom(user => user.ProjectsCreator.Concat(user.ProjectsCollaborator)))
                .ForMember(userDto => userDto.Skills, options => options
                    .MapFrom(user => user.Skills.Select(skill => skill.Name)))
                .ForMember(dto => dto.Applications, options => options
                    .MapFrom(user => JoinApplications(user)));    
                //.MapFrom(user => user.ProjectsCreator.Select(proj => proj.CollaboratorApplications)));
                

            CreateMap<UserPutDTO, User>();

            CreateMap<User, CollaboratorDTO>();
        }

        private ICollection<CollaboratorApplication> JoinApplications(User user)
        {
            List<CollaboratorApplication> result = new List<CollaboratorApplication>();

            foreach(var project in user.ProjectsCreator)
            {
                foreach(var app in project.CollaboratorApplications)
                {
                    result.Add(app);
                }
            }

            return result;
        }
    }
}
