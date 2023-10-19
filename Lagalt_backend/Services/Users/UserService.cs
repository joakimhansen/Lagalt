using Lagalt_backend.Data.Exceptions;
using Lagalt_backend.Data.Models;
using Lagalt_backend.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lagalt_backend.Services.Users {
    public class UserService : IUserService {
        private readonly LagaltDbContext _context;

        public UserService(LagaltDbContext context) {
            _context = context;
        }

        /// <summary>
        /// Get all the users from the db-context
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<User>> GetAllAsync() {
            List<User> users = await _context.Users
                                    .Include(user => user.Skills)
                                    .Include(user => user.ProjectsCreator)
                                    .ToListAsync();
            return users;
        }

        /// <summary>
        /// Get a spesific user by id
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        /// <exception cref="UserNotFoundException"></exception>
        public async Task<User> GetByIdAsync(string username) {

            if (!await _context.Users.AnyAsync(user => user.Username == username))
                throw new UserNotFoundException(username);

            User user = await _context.Users
                            .Where(user => user.Username == username)
                            .Include(user => user.Skills)
                            .Include(user => user.ProjectsCreator)
                            .ThenInclude(project => project.CollaboratorApplications)
                            .Include(user => user.ProjectsCollaborator)
                            .FirstAsync();

           /* if (user is null)
                throw new UserNotFoundException(username);*/

            return user;
        }

        /// <summary>
        /// Update an existing user
        /// </summary>
        /// <param name="updatedUser"></param>
        /// <returns></returns>
        /// <exception cref="UserNotFoundException"></exception>
        public async Task<User> UpdateAsync(User updatedUser) {
            if (!await _context.Users.AnyAsync(user => user.Username == updatedUser.Username))
                throw new UserNotFoundException(updatedUser.Username);

            _context.Entry(updatedUser).State = EntityState.Modified;
            _context.SaveChanges();

            return updatedUser;
        }
        public async Task<User> AddAsync(User newUser)
        {
            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();

            return newUser;
        }

        public Task DeleteByIdAsync(string username) {
            throw new NotImplementedException();
        }


        public Task<User> GetByIdAsync(int id) {
            throw new NotImplementedException();
        }

        /*
        public async Task<User> AddAsync(User newUser)
        {
            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();

            return newUser;
        }

        public async Task DeleteByIdAsync(int id)
        {
            //Throws EntityNotFoundException if it doesn't exist
            var UserToDelete = await GetByIdAsync(id);

            UserToDelete.Skills.Clear();
            UserToDelete.Projects.Clear();

            _context.Users.Remove(UserToDelete);
            await _context.SaveChangesAsync();
        }*/
    }
}
