using Application.DTOs.CopiesDTOs;
using FluentValidation;

namespace Application.Validators.Copy
{
    public class UpdateCopyValidator : AbstractValidator<UpdateCopyDTO>
    {
        public UpdateCopyValidator() 
        {
            RuleFor(copy => copy.Id)
                .NotEmpty()
                .WithMessage("El ID de la copia es obligatorio");

            RuleFor(copy => copy.BookId)
                .NotEmpty()
                .WithErrorCode("El ID del libro es obligatorio");

            RuleFor(copy => copy.IsAvailable)
                .NotEmpty()
                .WithMessage("El estado de disponibilidad es obligatorio");
        }
    }
}
