namespace Lagalt_backend.Data.DTOs.Projects {
    public class ProjectsListDTO 
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? ShortDescription { get; set; }
        public int? CategoryId { get; set; }
    }
}
