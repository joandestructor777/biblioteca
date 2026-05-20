using Application.DTOs.CopiesDTOs;
using FluentValidation;

namespace Application.Validators.Copy
{
    public class CreateCopyValidator : AbstractValidator<CreateCopyDTO>
    {
        public CreateCopyValidator() 
        {
            RuleFor(copy => copy.BookId)
                .NotEmpty()
                .WithMessage("El ID del libro es obligatorio");
        }

    }
}
