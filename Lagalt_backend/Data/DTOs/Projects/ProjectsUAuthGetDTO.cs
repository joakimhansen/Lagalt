using Lagalt_backend.Data.DTOs.User;
using Lagalt_backend.Data.Models.Entities;

namespace Lagalt_backend.Data.DTOs.Projects {

    /// <summary>
    /// Used to get a project by id when not authenticated/logged in
    /// </summary>
    public class ProjectsUAuthGetDTO {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? FullDescription { get; set; }
        public CollaboratorDTO Creator { get; set; }
        public int? Progress { get; set; }
    }
}
