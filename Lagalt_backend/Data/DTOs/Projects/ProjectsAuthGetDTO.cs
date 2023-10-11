using Lagalt_backend.Data.DTOs.User;
using Lagalt_backend.Data.Models.Entities;

namespace Lagalt_backend.Data.DTOs.Projects {
    public class ProjectsAuthGetDTO {

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? FullDescription { get; set; }
        public CreatorDTO? Creator { get; set; }
        public ICollection<CollaboratorDTO> Collaborators { get; set; } = new List<CollaboratorDTO>();
        public int? Progress { get; set; }
        public string? GithubUrl { get; set; }
    }
}
