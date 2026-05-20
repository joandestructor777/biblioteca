using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Models;
using Application.Exceptions;
using Application.DTOs.BooksDTOs;

namespace Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;
        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }
        public async Task<BookResponseDTO> CreateBook(CreateBookDTO dto)
        {
            var book = new Book
            {
                Title = dto.Title,
                ISBN = dto.ISBN,
                PublicationYear = dto.PublicationYear,
                CategoryId = dto.CategoryId,

                BookAuthors = dto.AuthorIds.Select(authorId =>
                    new BookAuthor
                    {
                        AuthorId = authorId
                    }).ToList()
            };

            var createdBook = await _repository.CreateBook(book);

            return new BookResponseDTO
            {
                Title = createdBook.Title,
                ISBN = createdBook.ISBN,
                PublicationYear = createdBook.PublicationYear,
                CategoryId = createdBook.CategoryId,
            };
        }
        public async Task<IEnumerable<BookResponseDTO>> GetAllBooks()
        {
            var books = await _repository.GetAllBooks();
            if (books == null || !books.Any())
            {
                throw new NotFoundException("No se encontraron libros");
            }
            var result = books.Select(b => new BookResponseDTO
            {
                Title = b.Title,
                ISBN = b.ISBN,
                PublicationYear = b.PublicationYear,
                CategoryId = b.CategoryId
            });
            return result;
        }

        public async Task<BookResponseDTO> GetBook(int id)
        {
            var foundBook = await _repository.GetBook(id);
            if (foundBook == null)
            {
                throw new NotFoundException("Libro no encontrado");
            }

            return new BookResponseDTO
            {
                Title = foundBook.Title,
                ISBN = foundBook.ISBN,
                PublicationYear = foundBook.PublicationYear,
                CategoryId = foundBook.CategoryId
            };

        }

        public async Task<BookResponseDTO> UpdateBook(int id, UpdateBookDTO book)
        {
            var foundBook = await _repository.GetBook(id);
            if(foundBook == null)
            {
                throw new NotFoundException($"El libro con el id: {id} no se encontró");
            }
            
            foundBook.Title = book.Title;
            foundBook.ISBN = book.ISBN;
            foundBook.PublicationYear = book.PublicationYear;
            foundBook.CategoryId = book.CategoryId;

            var updatedBook = await _repository.UpdateBook(id, foundBook);
            return new BookResponseDTO
            {
                Title = updatedBook.Title,
                ISBN = updatedBook.ISBN,
                PublicationYear = updatedBook.PublicationYear,
                CategoryId = updatedBook.CategoryId
            };
        }

        public async Task<DeleteBookResponseDTO> DeleteBook(int id)
        {
            var book = await _repository.GetBook(id);
            if(book == null)
            {
                throw new NotFoundException($"Libro con el id {id} no se encontró");
            }

            await _repository.DeleteBook(id);
            return new DeleteBookResponseDTO
            {
                Title = book.Title
            };
        }

        public async Task<BookResponseDTO> GetBookByTitle(string title)
        {
            var book = await _repository.GetBookByTitle(title);
            if (book == null)
            {
                throw new NotFoundException($"Libro con el título {title} no se encontró");
            }
            return new BookResponseDTO
            {
                Title = book.Title,
                ISBN = book.ISBN,
                PublicationYear = book.PublicationYear,
                CategoryId = book.CategoryId
            };
        }

        public async Task<BookResponseDTO> GetBookByISBN(string isbn)
        {
            var book = await _repository.GetBookByISBN(isbn);
            if(book == null)
            {
                throw new NotFoundException($"Libro con el ISBN {isbn} no se encontró");
            }

            return new BookResponseDTO
            {
                Title = book.Title,
                ISBN = book.ISBN,
                PublicationYear = book.PublicationYear,
                CategoryId = book.CategoryId
            };
        }

        public async Task<IEnumerable<BookResponseDTO>> GetBookByPublicationYear(int year)
        {
            var books = await _repository.GetBookByPublicationYear(year); 
            if( books == null)
            {
                throw new NotFoundException($"Libros con el año de publicación {year} no se encontraron");
            }
            return books.Select(books => new BookResponseDTO
            {
                Title = books.Title,
                ISBN = books.ISBN,
                PublicationYear = books.PublicationYear,
                CategoryId = books.CategoryId

            });
        }

        public async Task<IEnumerable<BookResponseDTO>> GetBookByCategory(Guid categoryId)
        {
            var books = await _repository.GetBookByCategory(categoryId);
            if (books == null)
            {
                throw new NotFoundException($"Libros con la categoría {categoryId} no se encontraron");
            }
            return books.Select(books => new BookResponseDTO 
            { 
                ISBN = books.ISBN, 
                Title = books.Title, 
                PublicationYear = books.PublicationYear, 
                CategoryId = books.CategoryId 
            });
        }
        public async Task<DeleteBookResponseDTO> DeleteBook(Guid id)
        {
            var book = await _repository.DeleteBook(id);

            if (book == null)
            {
                throw new NotFoundException($"Libro con el id {id} no se encontró");
            }

            return new DeleteBookResponseDTO
            {
                Title = book.Title
            };
        }
    }
}
