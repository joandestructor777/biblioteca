
using Application.DTOs.CategoriesDTOs;

namespace Application.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<CategoryResponseDTO> CreateCategory(CreateCategoryDTO category);
        Task<CategoryResponseDTO?> GetCategoryById(Guid categoryId);
        Task<List<CategoryResponseDTO>> GetAllCategories();
        Task<UpdateCategoryResponseDTO?> UpdateCategory(Guid categoryId, UpdateCategoryDTO category);
        Task<CategoryResponseDTO?> DeleteCategory(Guid categoryId);
    }
}
