using Lagalt_backend.Data.DTOs.CollaboratorApplications;
using Lagalt_backend.Data.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Lagalt_backend.Services.Applications {
    public interface IApplicationService : ICrudService<CollaboratorApplication, int> {
        Task AcceptApplication(int id);
    }
}
