namespace Lagalt_backend.Data.DTOs.Projects {

    /// <summary>
    /// Used to change an existing project
    /// </summary>
    public class ProjectsPutDTO {
        public int Id { get; set; }
        public string? FullDescription { get; set; }
        public int Progress { get; set; }

    }
}
