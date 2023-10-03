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
            return await _context.Projects.ToListAsync();
        }

        public async Task<Project> GetByIdAsync(int id) {
            if (!await ProjectExistsAsync(id)) {
                throw new EntityNotFoundException(nameof(Project), id);
            }
            return await _context.Projects.Where(p => p.Id == id).FirstAsync();
        }

        public async Task<Project> AddAsync(Project obj) {
            await _context.Projects.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
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
                .FirstAsync();

            _context.Projects.Remove(project);
            _context.SaveChanges();
        }

        private Task<bool> ProjectExistsAsync(int projectId) {
            return _context.Projects.AnyAsync(p => p.Id == projectId);
        }

    }
}
