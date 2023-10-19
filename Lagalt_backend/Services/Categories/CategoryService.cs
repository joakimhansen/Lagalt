using Lagalt_backend.Data.Exceptions;
using Lagalt_backend.Data.Models;
using Lagalt_backend.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lagalt_backend.Services.Categories {

    /// <summary>
    /// Service to communicate with the database
    /// </summary>
    public class CategoryService : ICategoryService {

        private readonly LagaltDbContext _context;

        public CategoryService(LagaltDbContext context) {
            _context = context;
        }

        /// <summary>
        /// Fetch all the categories from the db-context
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<Category>> GetAllAsync() {
            return await _context.Categories.Include(c => c.Projects).ToListAsync();
        }

        /// <summary>
        /// Get a category by id from the db-context and save the changes
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="EntityNotFoundException"></exception>
        public async Task<Category> GetByIdAsync(int id) {
            if (!await CategoryExistsAsync(id)) {
                throw new EntityNotFoundException(nameof(Category), id);
            }
            return await _context.Categories.Where(c => c.Id == id)
                .Include(c => c.Projects)
                .FirstAsync();
        }

        /// <summary>
        /// Add a new category to the db-context and save the changes
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task<Category> AddAsync(Category obj) {
            await _context.Categories.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        /// <summary>
        /// Change an existing category
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <exception cref="EntityNotFoundException"></exception>
        public async Task<Category> UpdateAsync(Category obj) {
            if (!await CategoryExistsAsync(obj.Id)) {
                throw new EntityNotFoundException(nameof(Category), obj.Id);
            }
            obj.Projects.Clear();
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
            return obj;
        }

        /// <summary>
        /// Delete an exsisting category by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="EntityNotFoundException"></exception>
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

        /// <summary>
        /// Check if a category exist in the db-context
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        private Task<bool> CategoryExistsAsync(int categoryId) {
            return _context.Categories.AnyAsync(c => c.Id == categoryId);
        }

    }
}
