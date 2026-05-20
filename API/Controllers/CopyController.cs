using Application.DTOs.CopiesDTOs;
using Microsoft.AspNetCore.Mvc;
using Application.Exceptions;
using Application.Interfaces.Services;
namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CopyController : ControllerBase
    {
        private readonly ICopyService _service;
        public CopyController(ICopyService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCopy([FromBody] CreateCopyDTO copyDto)
        {
            try
            {
                var createdCopy = await _service.CreateCopy(copyDto);
                return Ok(createdCopy);
            }
            catch (BaseException ex)
            {
                return StatusCode(ex.StatusCode, new { message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Error de lado del servidor, intente de nuevo." });
            }
        }


        [HttpGet("book/{bookId}")]
        public async Task<IActionResult> GetCopiesByBook(Guid bookId)
        {
            try
            {
                var copies = await _service.GetCopiesByBook(bookId);
                return Ok(copies);
            }
            catch (BaseException ex)
            {
                return StatusCode(ex.StatusCode, new { message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Error de lado del servidor, intente de nuevo." });
            }
        }

        [HttpGet("available/{bookId}")]
        public async Task<IActionResult> GetAvailableCopies(Guid bookId)
        {
            try
            {
                var availableCopies = await _service.GetAvailableCopies(bookId);
                return Ok(availableCopies);
            }
            catch (BaseException ex)
            {
                return StatusCode(ex.StatusCode, new { message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Error de lado del servidor, intente de nuevo." });
            }
        }

        [HttpGet("availableBook/{bookId}")]
        public async Task<IActionResult> GetAvailableCopy(Guid bookId)
        {
            var copy = await _service.GetAvailableCopy(bookId);

            if (copy == null)
            {
                return NotFound(new { message = $"No se encontró copia con el id: {bookId}" });
            }

            return Ok(copy);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCopyById(Guid id)
        {
            try
            {
                var copy = await _service.GetCopyById(id);
                return Ok(copy);
            }
            catch (BaseException ex)
            {
                return StatusCode(ex.StatusCode, new { message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Error de lado del servidor, intente de nuevo." });
            }

        }

        [HttpPut("{copyId}")]
        public async Task<IActionResult> UpdateCopy(Guid copyId, UpdateCopyDTO copyDto)
        {
            try
            {
                var updatedCopy = await _service.UpdateCopy(copyId, copyDto);
                return Ok(updatedCopy);
            }
            catch (BaseException ex)
            {
                return StatusCode(ex.StatusCode, new { message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Error de lado del servidor, intente de nuevo." });
            }
        }

        [HttpDelete("{copyId}")]
        public async Task<IActionResult> DeleteCopy(Guid copyId)
        {
            try
            {
                var deletedCopy = await _service.DeleteCopy(copyId);
                return Ok(new { message = "Copia eliminada", deletedCopy });
            }
            catch (BaseException ex)
            {
                return StatusCode(ex.StatusCode, new { message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Error de lado del servidor, intente de nuevo." });
            }
        }
    }
}
