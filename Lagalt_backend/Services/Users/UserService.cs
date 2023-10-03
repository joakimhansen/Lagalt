﻿using Lagalt_backend.Data.Exceptions;
using Lagalt_backend.Data.Models;
using Lagalt_backend.Data.Models.Entities;
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
            List<User> users = await _context.Users
                                    .Include(user => user.Skills)
                                    .Include(user => user.Projects)
                                    .ToListAsync();
            return users;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            User user = await _context.Users
                            .Where(user => user.Id == id)
                            .Include(user => user.Skills)
                            .Include(user => user.Projects)
                            .FirstAsync();

            if (user is null)
                throw new EntityNotFoundException(nameof(User), id);

            return user;
        }

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

            _context.Users.Remove(UserToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<User> UpdateAsync(User updatedUser)
        {
            if (!await _context.Users.AnyAsync(user => user.Id == updatedUser.Id))
                throw new EntityNotFoundException(nameof(User), updatedUser.Id);

            _context.Entry(updatedUser).State = EntityState.Modified;
            _context.SaveChanges();

            return updatedUser;
        }
    }
}