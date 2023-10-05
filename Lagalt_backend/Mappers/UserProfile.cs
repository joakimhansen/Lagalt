using AutoMapper;
using Lagalt_backend.Data.DTOs.User;
using Lagalt_backend.Data.Models.Entities;

namespace Lagalt_backend.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<User, UserDTO>()
                .ForMember(userDto => userDto.Projects, options => options
                    .MapFrom(user => user.Projects))
                .ForMember(userDto => userDto.Skills, options => options
                    .MapFrom(user => user.Skills.Select(skill => skill.Name)));

            CreateMap<UserPostDTO, User>();
            CreateMap<UserPutDTO, User>();
        }
    }
}
