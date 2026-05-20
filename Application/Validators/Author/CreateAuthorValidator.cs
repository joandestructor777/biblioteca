using Application.DTOs.AuthorsDTOs;
using FluentValidation;

namespace Application.Validators.Author
{
    public class CreateAuthorValidator : AbstractValidator<CreateAuthorDTO>
    {
        public CreateAuthorValidator()
        {
            RuleFor(author => author.Name)
                .NotEmpty()
                .WithMessage("El nombre del autor es obligatorio")
                .MaximumLength(150)
                .WithMessage("El nombre no puede superar 150 caracteres");
        }
    }
}