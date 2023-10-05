using Lagalt_backend.Data.Models.Entities;

namespace Lagalt_backend.Data.DTOs.Categories {
    public class CategoriesGetDTO {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        //public int[] Projects { get; set; }

    }
}
