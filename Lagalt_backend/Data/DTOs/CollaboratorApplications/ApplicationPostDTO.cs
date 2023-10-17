namespace Lagalt_backend.Data.DTOs.CollaboratorApplications {

    /// <summary>
    /// Defines an application-dto
    /// Used to create a new collaboration-application 
    /// </summary>
    public class ApplicationPostDTO {
        public string Content { get; set; } = null!;
        public string? User { get; set; }
        public int? Project { get; set; }
    }
}
