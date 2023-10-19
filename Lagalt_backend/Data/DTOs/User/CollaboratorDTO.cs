namespace Lagalt_backend.Data.DTOs.User {

    /// <summary>
    /// Defines a collaborator
    /// - Used as type for creator in ProjectsListDTO, ProjectsAuthGetDTO and ProjectsUAuthGetDTO
    /// - Used as type for collaborator-list in ProjectsListDTO and ProjectsAuthGetDTO
    /// </summary>
    public class CollaboratorDTO {
        public string Username { get; set; } = null!;
        public string? ImageUrl { get; set; }
    }
}
