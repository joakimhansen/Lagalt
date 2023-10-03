using Lagalt_backend.Data.Models.Entities;

namespace Lagalt_backend.Data.DTOs.Projects {
    public class ProjectsGetDTO {

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? ShortDescription { get; set; }
        public string? FullDescription { get; set; }
        public int? CategoryId { get; set; }
        public int? CreatorId { get; set; }

        //public virtual Category? Category { get; set; }
        //public virtual User? Creator { get; set; }

    }
}
