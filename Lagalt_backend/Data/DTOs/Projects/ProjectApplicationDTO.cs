using Lagalt_backend.Data.DTOs.CollaboratorApplications;

namespace Lagalt_backend.Data.DTOs.Projects
{
    public class ProjectApplicationDTO
    {
        public ICollection<ApplicationDTO> Applications { get; set; } = new List<ApplicationDTO>();
    }
}
