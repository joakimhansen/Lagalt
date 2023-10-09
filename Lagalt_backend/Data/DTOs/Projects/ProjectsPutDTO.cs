namespace Lagalt_backend.Data.DTOs.Projects {
    public class ProjectsPutDTO {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? ShortDescription { get; set; }
        public string? FullDescription { get; set; }
        public int? CategoryId { get; set; }
        public string? CreatorName { get; set; }
        public string? GithubUrl { get; set; }
        public int? Progress { get; set; }

    }
}
