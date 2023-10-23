using Lagalt_backend.Data.DTOs.CollaboratorApplications;
using Lagalt_backend.Data.DTOs.Projects;
using Lagalt_backend.Data.Exceptions;
using Lagalt_backend.Data.Models;
using Lagalt_backend.Data.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lagalt_backend.Services.Applications {

    /// <summary>
    /// Service to communicate with the database
    /// </summary>
    public class CollaboratorApplicationService : IApplicationService {

        private readonly LagaltDbContext _context;

        public CollaboratorApplicationService(LagaltDbContext context) {
            _context = context;
        }

        /// <summary>
        /// Add a new application to the db-context and save the changes
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        public async Task<CollaboratorApplication> AddAsync(CollaboratorApplication application) {
            await _context.CollaboratorApplications.AddAsync(application);
            await _context.SaveChangesAsync();
            return application;
        }

        /// <summary>
        /// Deletes an application by id from the db-context and save the changes
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="EntityNotFoundException"></exception>
        public async Task DeleteByIdAsync(int id) {
            if (!await ApplicationExistsAsync(id)) {
                throw new EntityNotFoundException(nameof(CollaboratorApplication), id);
            }
            var application = await _context.CollaboratorApplications
                .Where(a => a.Id == id)
                .FirstAsync();

            _context.CollaboratorApplications.Remove(application);
            _context.SaveChanges();
        }

        /// <summary>
        /// Get all the applications from the db-context
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<CollaboratorApplication>> GetAllAsync() {
            return await _context.CollaboratorApplications.ToListAsync();
        }

        /// <summary>
        /// Get an application by id from the db-context and save the changes
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="EntityNotFoundException"></exception>
        public async Task<CollaboratorApplication> GetByIdAsync(int id) {
            if (!await ApplicationExistsAsync(id)) {
                throw new EntityNotFoundException(nameof(CollaboratorApplication), id);
            }
            return await _context.CollaboratorApplications.Where(ca => ca.Id == id)
                .FirstAsync();
        }

        /// <summary>
        /// Check if a spesific application exist in the db-context
        /// </summary>
        /// <param name="applicationId"></param>
        /// <returns></returns>
        private Task<bool> ApplicationExistsAsync(int applicationId) {
            return _context.CollaboratorApplications.AnyAsync(a => a.Id == applicationId);
        }

        /// <summary>
        /// Accept a new application by adding the user to the project and delete the application
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task AcceptApplication(int id) {
            var application = GetByIdAsync(id).Result;

            var project = await _context.Projects
                .Where(p => p.Id == application.Project)
                .Include(p => p.Collaborators)
                .FirstAsync();

            var user = await _context.Users
                .Where(u => u.Username == application.User)
                .FirstAsync();

            if(project.Collaborators.Contains(user))
            {
                throw new CollaboratorExistsException(user.Username);
            }

            project.Collaborators.Add(user);
            await DeleteByIdAsync(id);
            await _context.SaveChangesAsync();
        }

        public Task<CollaboratorApplication> UpdateAsync(CollaboratorApplication obj) {
            throw new NotImplementedException();
        }

    }
}
