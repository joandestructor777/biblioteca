using Application.DTOs.AuthorsDTOs;
using Application.Exceptions;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _service;

        public AuthorController(IAuthorService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody] CreateAuthorDTO author)
        {
            try
            {
                var createdAuthor = await _service.CreateAuthor(author);

                return Ok(createdAuthor);
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
        public async Task<IActionResult> GetAllAuthors()
        {
            try
            {
                var authors = await _service.GetAllAuthors();

                return Ok(authors);
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

        [HttpGet("{authorId}")]
        public async Task<IActionResult> GetAuthorById(Guid authorId)
        {
            try
            {
                var author = await _service.GetAuthorById(authorId);

                return Ok(author);
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

        [HttpPut("{authorId}")]
        public async Task<IActionResult> UpdateAuthor(Guid authorId, [FromBody] UpdateAuthorDTO author)
        {
            try
            {
                var updatedAuthor = await _service.UpdateAuthor(authorId, author);

                return Ok(updatedAuthor);
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

        [HttpDelete("{authorId}")]
        public async Task<IActionResult> DeleteAuthor(Guid authorId)
        {
            try
            {
                var deletedAuthor = await _service.DeleteAuthor(authorId);

                return Ok(deletedAuthor);
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