using AutoMapper;
using Lagalt_backend.Data.DTOs.Skills;
using Lagalt_backend.Data.Models.Entities;

namespace Lagalt_backend.Mappers
{
    public class SkillProfile : Profile
    {
        public SkillProfile() 
        {

            CreateMap<NeededSkillDTO, Skill>().ReverseMap();

            //CreateMap<Skill, SkillDTO>()
            //.ForMember(skillDto => skillDto.UserIds, options => options
            //    .MapFrom(skill => skill.Users.Select(user => user.Id)));

            //CreateMap<SkillPostDTO, Skill>();
            //CreateMap<SkillPutDTO, Skill>();
        }
    }
}
