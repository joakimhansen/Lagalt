using Lagalt_backend.Data.DTOs.CollaboratorApplications;
using Lagalt_backend.Data.DTOs.Projects;
using Lagalt_backend.Data.Exceptions;
using Lagalt_backend.Data.Models;
using Lagalt_backend.Data.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lagalt_backend.Services.Applications {
    public class CollaboratorApplicationService : IApplicationService {

        private readonly LagaltDbContext _context;


        public CollaboratorApplicationService(LagaltDbContext context) {
            _context = context;
        }

        public async Task<CollaboratorApplication> AddAsync(CollaboratorApplication application) {
            await _context.CollaboratorApplications.AddAsync(application);
            await _context.SaveChangesAsync();
            return application;
        }

        public async Task DeleteByIdAsync(int id) {
            if (!await ApplicationExistsAsync(id)) {
                throw new EntityNotFoundException(nameof(CollaboratorApplication), id);
            }
            var application = await _context.CollaboratorApplications
                .Where(a => a.Id == id)
                .FirstAsync();

            //application.User = null;
            //application.Project = null;

            _context.CollaboratorApplications.Remove(application);
            _context.SaveChanges();
        }

        public async Task<ICollection<CollaboratorApplication>> GetAllAsync() {
            return await _context.CollaboratorApplications.ToListAsync();
        }

        public async Task<CollaboratorApplication> GetByIdAsync(int id) {
            if (!await ApplicationExistsAsync(id)) {
                throw new EntityNotFoundException(nameof(CollaboratorApplication), id);
            }
            return await _context.CollaboratorApplications.Where(ca => ca.Id == id)
                .FirstAsync();
        }

        public Task<CollaboratorApplication> UpdateAsync(CollaboratorApplication obj) {
            throw new NotImplementedException();
        }

        private Task<bool> ApplicationExistsAsync(int applicationId) {
            return _context.CollaboratorApplications.AnyAsync(a => a.Id == applicationId);
        }

        public async Task AcceptApplication(int id) {
            var application = GetByIdAsync(id).Result;

            var project = await _context.Projects
                .Where(p => p.Id == application.Project)
                .FirstAsync();

            var user = await _context.Users
                .Where(u => u.Username == application.User)
                .FirstAsync();

            project.Collaborators.Add(user);
            await DeleteByIdAsync(id);
            await _context.SaveChangesAsync();
        }

        public async Task<CollaboratorApplication> CreateApplication(CollaboratorApplication application) {
            await _context.CollaboratorApplications.AddAsync(application);
            await _context.SaveChangesAsync();
            return application;
        }

    }
}
