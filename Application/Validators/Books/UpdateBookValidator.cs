
using Application.DTOs.BooksDTOs;
using FluentValidation;

namespace Application.Validators.Books
{
    public class UpdateBookValidator : AbstractValidator<UpdateBookDTO>
    {
        public UpdateBookValidator() 
        {
            RuleFor(book => book.Title)
                .NotEmpty()
                .WithMessage("El titulo es obligatorio");

            RuleFor(book => book.ISBN)
                .NotEmpty()
                .MinimumLength(10)
                .WithMessage("El ISBN es obligatorio y debe contener mas de 10 caracteres");

            RuleFor(book => book.PublicationYear)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("El año es obligatorio y debe ser mayor a 0");

            RuleFor(book => book.CategoryId)
                .NotEmpty()
                .WithMessage("La categoria es obligatoria");

        }
    }
}
