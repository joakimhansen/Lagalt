using Lagalt_backend.Data.DTOs.Categories;
using Lagalt_backend.Data.DTOs.User;

namespace Lagalt_backend.Data.DTOs.Projects {
    public class ProjectsListDTO {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? ShortDescription { get; set; }
        public CategoriesGetDTO? Category { get; set; }
        public CreatorDTO? Creator { get; set; }
        public ICollection<CollaboratorDTO> Collaborators { get; set; } = new List<CollaboratorDTO>();

        //public string? Github_Url { get; set; }
        //public CreatorDTO? Creator { get; set; }
    }
}
