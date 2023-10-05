using Lagalt_backend.Data.DTOs.Projects;
using Lagalt_backend.Data.Models.Entities;

namespace Lagalt_backend.Data.DTOs.User
{
    public class UserDTO
    {

        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string? Info { get; set; }

        public ICollection<ProjectUserDTO> Projects { get; set; } = new List<ProjectUserDTO>();
        public int[] Skills { get; set; } = new int[] { };
    }
}
