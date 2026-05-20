
using Application.DTOs.CategoriesDTOs;
using Application.Interfaces.Services;
using Application.Interfaces.Repositories;
using Domain.Models;
using Application.Exceptions;

namespace Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<CategoryResponseDTO> CreateCategory(CreateCategoryDTO category)
        {
            var newCategory = new Category
            {
                Name = category.Name
            };

            var createdCategory = await _repository.CreateCategory(newCategory);

            return new CategoryResponseDTO
            {
                Id = createdCategory.Id,
                Name = createdCategory.Name
            };
        }

        public async Task<CategoryResponseDTO?> GetCategoryById(Guid categoryId)
        {
            var foundCategory = await _repository.GetCategoryById(categoryId);
            if(foundCategory == null)
            {
                throw new NotFoundException($"La categoria con el id: {categoryId} no se encontró");
            }
            return new CategoryResponseDTO 
            {
                Id= foundCategory.Id,
                Name = foundCategory.Name
            };
        }
        public async Task<List<CategoryResponseDTO>> GetAllCategories()
        {
            var categories = await _repository.GetAllCategories();
            return categories.Select(category => new CategoryResponseDTO
            {
                Id = category.Id,
                Name = category.Name,
            }).ToList();
        }

        public async Task<UpdateCategoryResponseDTO?> UpdateCategory(Guid categoryId, UpdateCategoryDTO category)
        {
            var newCategory = new Category
            {
                Id = category.Id,
                Name = category.Name
            };
            var updatedCategory = await _repository.UpdateCategory(categoryId, newCategory);

            return new UpdateCategoryResponseDTO
            {
                Id = updatedCategory.Id,
                Name = updatedCategory.Name
            };
        }

        public async Task<CategoryResponseDTO?> DeleteCategory(Guid categoryId)
        {
            var deletedCategory = await _repository.DeleteCategory(categoryId);
            if(deletedCategory == null)
            {
                throw new NotFoundException($"El libro con el id: {categoryId} no se encontró");
            }

            return new CategoryResponseDTO
            {
                Id = deletedCategory.Id,
                Name = deletedCategory.Name,
            };
        }
    }
}
