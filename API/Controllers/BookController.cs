using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Application.Services;
using Application.Interfaces.Services;
using System.ComponentModel.DataAnnotations;
using Application.Exceptions;
using Application.DTOs.BooksDTOs;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _service;
        public BookController(IBookService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] CreateBookDTO book)
        {
            var createdBook = await _service.CreateBook(book);
            try
            {
                return Ok(createdBook);

            }
            catch (BaseException ex)
            {
                return StatusCode(ex.StatusCode, new { message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            try
            {
                var books = await _service.GetAllBooks();
                return Ok(books);
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


        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            try
            {
                var book = await _service.GetBook(id);
                return Ok(book);
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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] UpdateBookDTO book)
        {
            try
            {
                var updatedBook = await _service.UpdateBook(id, book);
                return Ok(new { message = "Libro actualizado", updatedBook });
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            try
            {
                var deletedBook = await _service.DeleteBook(id);
                return Ok(new { message = "Libro eliminado", deletedBook });
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

        [HttpGet("searchByTitle")]
        public async Task<IActionResult> GetBookByTitle([FromQuery] string title)
        {
            try
            {
                var book = await _service.GetBookByTitle(title);
                return Ok(book);
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

        [HttpGet("searchByISBN")]
        public async Task<IActionResult> GetBookByISBN([FromQuery] string isbn)
        {
            try
            {
                var book = await _service.GetBookByISBN(isbn);
                return Ok(book);
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

        [HttpGet("searchByPublicationYear")]
        public async Task<IActionResult> GetBookByPublicationYear([FromQuery] int year)
        {
            try
            {
                var book = await _service.GetBookByPublicationYear(year);
                return Ok(book);
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

        [HttpGet("searchByCategory")]
        public async Task<IActionResult> GetBookByCategory([FromQuery] Guid categoryId)
        {
            try
            {
                var book = await _service.GetBookByCategory(categoryId);
                return Ok(book);
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
