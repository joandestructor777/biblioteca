using Application.DTOs.CategoriesDTOs;
using Application.Exceptions;
using Application.Interfaces.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;
        public CategoryController(ICategoryService service)
        {
            _service = service;
        }
            
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDTO categoryDto)
        {
            try
            {
                var createdCategory = await _service.CreateCategory(categoryDto);
                return Ok(createdCategory);
            }
            catch (BaseException ex)
            {
                return StatusCode(ex.StatusCode, new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetCategoryById(Guid categoryId)
        {
            try
            {
                var foundCategory = await _service.GetCategoryById(categoryId);
                return Ok(foundCategory);
            }
            catch (BaseException ex)
            {
                return StatusCode(ex.StatusCode, new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                var categories = await _service.GetAllCategories();
                return Ok(categories);
            }
            catch (BaseException ex)
            {
                return StatusCode(ex.StatusCode, new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPut("{categoryId}")]
        public async Task<IActionResult> UpdateCategory(Guid categoryId, [FromBody] UpdateCategoryDTO category)
        {
            try
            {
                var updatedCategory = await _service.UpdateCategory(categoryId, category);
                return Ok(updatedCategory);
            }
            catch (BaseException ex)
            {
                return StatusCode(ex.StatusCode, new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory([FromBody] Guid categoryId)
        {
            try
            {
                var deletedCategory = await _service.DeleteCategory(categoryId);
                return Ok(deletedCategory);
            }
            catch (BaseException ex)
            {
                return StatusCode(ex.StatusCode, new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
