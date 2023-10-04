using AutoMapper;
using Lagalt_backend.Data.DTOs.Categories;
using Lagalt_backend.Data.Models.Entities;

namespace Lagalt_backend.Mappers {
    public class CategoryProfile : Profile {

        public CategoryProfile() {

            CreateMap<Category, CategoriesGetDTO>()
                .ForMember(cdto => cdto.Projects, options => options
                .MapFrom(c => c.Projects.Select(p => p.Id).ToArray()));

            CreateMap<Category, CategoriesPostDTO>().ReverseMap();

            CreateMap<Category, CategoriesPutDTO>().ReverseMap();
        }

    }
}
