using Application.DTOs.UsersDTOs;
using FluentValidation;

namespace Application.Validators.User
{
    public class CreateUserValidator : AbstractValidator<CreateUserDTO>
    {
        public CreateUserValidator() 
        {
            RuleFor(user => user.Name)
                .NotEmpty()
                .MinimumLength(3)
                .WithMessage("El nombre es obligatorio y debe contener al menos 3 caracteres");

            RuleFor(user => user.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("El email es obligatorio");

            RuleFor(user => user.PasswordHash)
                .NotEmpty()
                .WithMessage("La contraseña es obligatoria");

            RuleFor(user => user.Role)
                .NotEmpty()
                .WithMessage("El rol es obligatorio");

        }
    }
}
