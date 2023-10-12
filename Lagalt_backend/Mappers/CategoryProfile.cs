using AutoMapper;
using Lagalt_backend.Data.DTOs.Categories;
using Lagalt_backend.Data.Models.Entities;

namespace Lagalt_backend.Mappers {
    public class CategoryProfile : Profile {

        public CategoryProfile() {
            CreateMap<Category, CategoriesGetDTO>();
        }

    }
}
