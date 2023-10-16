namespace Lagalt_backend.Data.DTOs.CollaboratorApplications {
    public class ApplicationPostDTO {
        public string Content { get; set; } = null!;
        public string? User { get; set; }
        public int? Project { get; set; }
    }
}
