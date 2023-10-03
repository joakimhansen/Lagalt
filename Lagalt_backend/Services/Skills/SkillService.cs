using Lagalt_backend.Data.Models;
using Lagalt_backend.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lagalt_backend.Services.Skills
{
    public class SkillService : ISkillService
    {
        private readonly LagaltDbContext _context;
        public SkillService(LagaltDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Skill>> GetAllAsync()
        {
            List<Skill> skills = await _context.Skills
                                       .Include(skill => skill.Users)
                                       .ToListAsync();
            return skills;
        }

        public Task<Skill> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Skill> AddAsync(Skill obj)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Skill> UpdateAsync(Skill obj)
        {
            throw new NotImplementedException();
        }
    }
}
