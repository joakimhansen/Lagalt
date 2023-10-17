namespace Lagalt_backend.Data.DTOs.Projects {

    /// <summary>
    /// Used to define a project for the project-list in UserDTO
    /// </summary>
    public class ProjectUserDTO {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? ShortDescription { get; set; }
    }
}
