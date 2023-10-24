namespace Lagalt_backend.Data.DTOs.CollaboratorApplications
{
    public class ApplicationAcceptDTO
    {
        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public string? User { get; set; }
        public string? Project { get; set; }
    }
}
