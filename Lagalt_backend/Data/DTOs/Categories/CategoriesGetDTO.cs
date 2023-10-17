using Lagalt_backend.Data.Models.Entities;

namespace Lagalt_backend.Data.DTOs.Categories {

    /// <summary>
    /// Define a category-dto with Id, Name.
    /// Used to get all categories
    /// </summary>
    public class CategoriesGetDTO {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
