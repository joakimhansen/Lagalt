using Lagalt_backend.Data.DTOs.User;
using Lagalt_backend.Data.Models.Entities;

namespace Lagalt_backend.Data.DTOs.Projects {
    public class ProjectsUAuthGetDTO {

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? FullDescription { get; set; }

        //public string? Github_Url { get; set; }
        //public CreatorDTO Creator { get; set; }
    }
}
