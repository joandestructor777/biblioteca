using Application.Interfaces.Repositories;
using Domain.Models;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Category> CreateCategory(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }
        public async Task<Category?> GetCategoryById(Guid categoryId)
        {
            var foundCategory = await _context.Categories.FirstOrDefaultAsync(category => category.Id == categoryId);
            if (foundCategory == null) return null;

            return foundCategory;
        }
        public async Task<List<Category>> GetAllCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            return categories;
        }
        public async Task<Category?> UpdateCategory(Guid categoryId, Category category)
        {
            var foundCategory = await _context.Categories.FindAsync(categoryId);
            if (foundCategory == null)
            {
                return null;
            }

            _context.Categories.Update(category);
            await _context.SaveChangesAsync();

            return foundCategory;
        }
        public async Task<Category?> DeleteCategory(Guid categoryId)
        {
            var foundCategory = await _context.Categories.FindAsync(categoryId);
            if(foundCategory == null)
            {
                return null;
            }

            _context.Categories.Remove(foundCategory);
            await _context.SaveChangesAsync();

            return foundCategory;
        }

    }
}
