
using Domain.Models;

namespace Application.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> CreateCategory(Category category);
        Task<Category?> GetCategoryById(Guid categoryId);
        Task<List<Category>> GetAllCategories();
        Task<Category?> UpdateCategory(Guid categoryId, Category category);
        Task<Category?> DeleteCategory(Guid categoryId);
    }
}
