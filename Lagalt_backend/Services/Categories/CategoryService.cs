using Lagalt_backend.Data.Exceptions;
using Lagalt_backend.Data.Models;
using Lagalt_backend.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lagalt_backend.Services.Categories
{
    public class CategoryService : ICategoryService {

        private readonly LagaltDbContext _context;

        public CategoryService(LagaltDbContext context) {
            _context = context;
        }

        public async Task<ICollection<Category>> GetAllAsync() {
            return await _context.Categories.Include(c => c.Projects).ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id) {
            if (!await CategoryExistsAsync(id)) {
                throw new EntityNotFoundException(nameof(Category), id);
            }
            return await _context.Categories.Where(c => c.Id == id)
                .Include(c => c.Projects)
                .FirstAsync();
        }

        public async Task<Category> AddAsync(Category obj) {
            await _context.Categories.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task<Category> UpdateAsync(Category obj) {
            if (!await CategoryExistsAsync(obj.Id)) {
                throw new EntityNotFoundException(nameof(Category), obj.Id);
            }
            obj.Projects.Clear();
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
            return obj;
        }

        public async Task DeleteByIdAsync(int id) {
            if (!await CategoryExistsAsync(id)) {
                throw new EntityNotFoundException(nameof(Category), id);
            }
            var category = await _context.Categories
                .Where(c => c.Id == id)
                .Include(c => c.Projects)
                .FirstAsync();

            category.Projects.Clear();
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }

        private Task<bool> CategoryExistsAsync(int categoryId) {
            return _context.Categories.AnyAsync(c => c.Id == categoryId);
        }

    }
}
