using Lagalt_backend.Data.Exceptions;
using Lagalt_backend.Data.Models;
using Lagalt_backend.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lagalt_backend.Services.Projects {
    public class ProjectService : IProjectService {

        private readonly LagaltDbContext _context;

        public ProjectService(LagaltDbContext context) {
            _context = context;
        }

        public async Task<ICollection<Project>> GetAllAsync() {
            return await _context.Projects
                .Include(p => p.Creator)
                .Include(p => p.Category)
                .Include(p => p.Collaborators)
                .Include(p => p.CollaboratorApplications)
                .Include(p => p.Skills)
                .ToListAsync();
        }

        public async Task<Project> GetByIdAsync(int id) {
            if (!await ProjectExistsAsync(id)) {
                throw new EntityNotFoundException(nameof(Project), id);
            }
            return await _context.Projects.Where(p => p.Id == id)
                .Include(p => p.Creator)
                .Include(p => p.Collaborators)
                .Include(p => p.CollaboratorApplications)
                .Include(p => p.Skills)
                .FirstAsync();
        }
        public async Task<Project> UpdateAsync(Project obj) {
            if (!await ProjectExistsAsync(obj.Id)) {
                throw new EntityNotFoundException(nameof(Project), obj.Id);
            }
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
            return obj;
        }

        public async Task DeleteByIdAsync(int id) {
            if (!await ProjectExistsAsync(id)) {
                throw new EntityNotFoundException(nameof(Project), id);
            }
            var project = await _context.Projects
                .Where(p => p.Id == id)
                .Include(P => P.Collaborators)
                .Include(p => p.Skills)
                .Include(p => p.CollaboratorApplications)
                .FirstAsync();

            foreach (var application in project.CollaboratorApplications)
            {
                _context.CollaboratorApplications.Remove(application);
            }
            project.Collaborators.Clear();
            project.Skills.Clear();
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
        }

        /*public async Task<Project> AddAsync(Project obj)
        {
            await _context.Projects.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

       

        */

        private Task<bool> ProjectExistsAsync(int projectId) {
            return _context.Projects.AnyAsync(p => p.Id == projectId);
        }
        public Task<Project> AddAsync(Project obj) {
            throw new NotImplementedException();
        }

    }
}
