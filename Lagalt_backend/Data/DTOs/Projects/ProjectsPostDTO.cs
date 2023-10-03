namespace Lagalt_backend.Data.DTOs.Projects {
    public class ProjectsPostDTO {
        public string Title { get; set; } = null!;
        public string? ShortDescription { get; set; }
        public string? FullDescription { get; set; }
        public int? CategoryId { get; set; }
        public int? CreatorId { get; set; }
    }
}
