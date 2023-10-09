using Lagalt_backend.Data.Exceptions;
using Lagalt_backend.Data.Models;
using Lagalt_backend.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lagalt_backend.Services.Skills
{
    public class SkillService : ISkillService
    {
        /*private readonly LagaltDbContext _context;
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

        public async Task<Skill> GetByIdAsync(int id)
        {
            if (!await _context.Skills.AnyAsync(skill => skill.Id == id))
                throw new EntityNotFoundException(nameof(Skill), id);

            return await _context.Skills
                            .Include(skill => skill.Users)
                            .Where(skill => skill.Id == id)
                            .FirstAsync();
        }

        public async Task<Skill> AddAsync(Skill skill)
        {
            await _context.Skills.AddAsync(skill);
            await _context.SaveChangesAsync();

            return skill;
        }

        public async Task<Skill> UpdateAsync(Skill updatedSkill)
        {
            if (!await _context.Skills.AnyAsync(skill => skill.Id == updatedSkill.Id))
                throw new EntityNotFoundException(nameof(Skill), updatedSkill.Id);

            _context.Entry(updatedSkill).State = EntityState.Modified;
            _context.SaveChanges();

            return updatedSkill;
        }

        public async Task DeleteByIdAsync(int id)
        {
            //Throws EntityNotFoundException if it dowsn't exist
            var SkillToDelete = await GetByIdAsync(id);

            SkillToDelete.Users.Clear();

            _context.Skills.Remove(SkillToDelete);
            await _context.SaveChangesAsync();
        }*/
        public Task<Skill> AddAsync(Skill obj)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Skill>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Skill> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Skill> UpdateAsync(Skill obj)
        {
            throw new NotImplementedException();
        }
    }
}
