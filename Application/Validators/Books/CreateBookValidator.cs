using Application.DTOs.BooksDTOs;
using FluentValidation;


namespace Application.Validators.Books
{
    public class CreateBookValidator : AbstractValidator<CreateBookDTO>
    {
        public CreateBookValidator()
        {
            RuleFor(book => book.Title)
                .NotEmpty()
                .WithMessage("El campo Titulo es obligatorio");

            RuleFor(book => book.ISBN)
                .NotEmpty()
                .MinimumLength(10)
                .WithMessage("El código ISBN es obligatorio");

            RuleFor(book => book.PublicationYear)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("El año de publicación es obligatorio y debe ser un número positivo");

            RuleFor(book => book.CategoryId)
                .NotEmpty()
                .WithMessage("La Categoria es obligatorio");
        }
    }
}
