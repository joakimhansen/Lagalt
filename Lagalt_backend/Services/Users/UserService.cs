using Lagalt_backend.Models;
using Lagalt_backend.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lagalt_backend.Services.Users
{
    public class UserService : IUserService
    {
        private readonly LagaltDbContext _context;

        public UserService(LagaltDbContext context)
        {
            _context = context;
        }
        public async Task<ICollection<User>> GetAllAsync()
        {
            List<User> users = await _context.Users.ToListAsync();
            Console.WriteLine(users);

            return users;
        }

        public Task<User> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> AddAsync(User obj)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateAsync(User obj)
        {
            throw new NotImplementedException();
        }
    }
}
