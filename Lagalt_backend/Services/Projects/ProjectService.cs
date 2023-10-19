using Lagalt_backend.Data.DTOs.Projects;
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

        /// <summary>
        /// Get all the projects from the db-context
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<Project>> GetAllAsync() {
            return await _context.Projects
                .Include(p => p.Creator)
                .Include(p => p.Category)
                .Include(p => p.Collaborators)
                .Include(p => p.CollaboratorApplications)
                .Include(p => p.Skills)
                .ToListAsync();
        }

        /// <summary>
        /// Get a spesific project by id from the db-context
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="EntityNotFoundException"></exception>
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

        /// <summary>
        /// Update an existing project
        /// </summary>
        /// <param name="UpdatedValues"></param>
        /// <returns></returns>
        /// <exception cref="EntityNotFoundException"></exception>
        public async Task<Project> UpdateAsync(Project UpdatedValues) {
            if (!await ProjectExistsAsync(UpdatedValues.Id)) {
                throw new EntityNotFoundException(nameof(Project), UpdatedValues.Id);
            }

            var project = await _context.Projects
                .Where(p => p.Id == UpdatedValues.Id)
                .FirstAsync();
            project.FullDescription = UpdatedValues.FullDescription;
            project.Progress = UpdatedValues.Progress;

            _context.Entry(project).State = EntityState.Modified;
            _context.SaveChanges();

            return project;
        }

        /// <summary>
        /// Delete an existing project by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="EntityNotFoundException"></exception>
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

            foreach (var application in project.CollaboratorApplications) {
                _context.CollaboratorApplications.Remove(application);
            }
            project.Collaborators.Clear();
            project.Skills.Clear();
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Check if a project exist in the db-context
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        private Task<bool> ProjectExistsAsync(int projectId) {
            return _context.Projects.AnyAsync(p => p.Id == projectId);
        }

        public Task<Project> AddAsync(Project obj)
        {
            throw new NotImplementedException();
        }
    }
}
