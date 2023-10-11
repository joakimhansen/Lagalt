using Lagalt_backend.Data.DTOs.Categories;
using Lagalt_backend.Data.DTOs.CollaboratorApplications;
using Lagalt_backend.Data.DTOs.Skills;
using Lagalt_backend.Data.DTOs.User;

namespace Lagalt_backend.Data.DTOs.Projects {
    public class ProjectsListDTO {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? ShortDescription { get; set; }
        public CategoriesGetDTO? Category { get; set; }
        public CreatorDTO? Creator { get; set; }
        public ICollection<CollaboratorDTO> Collaborators { get; set; } = new List<CollaboratorDTO>();
        public ICollection<ApplicationDTO> Applications { get; set; } = new List<ApplicationDTO>();
        public ICollection<NeededSkillDTO> NeededSkills { get; set; } = new List<NeededSkillDTO>();


        //public string? Github_Url { get; set; }
        //public CreatorDTO? Creator { get; set; }
    }
}
