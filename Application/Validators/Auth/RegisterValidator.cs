using Application.DTOs.Auth;
using FluentValidation;

namespace Application.Validators.Auth
{
    public class RegisterValidator : AbstractValidator<RegisterDTO>
    {
        public RegisterValidator()
        {
            RuleFor(user => user.Name).NotEmpty();
            RuleFor(user => user.Email).NotEmpty().EmailAddress();
            RuleFor(user => user.Password).NotEmpty().MinimumLength(4);
        }
    }
}