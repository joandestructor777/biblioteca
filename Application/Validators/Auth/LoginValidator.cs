using Application.DTOs.Auth;
using FluentValidation;

namespace Application.Validators.Auth
{
    public class LoginValidator : AbstractValidator<LoginDTO>
    {
        public LoginValidator()
        {
            RuleFor(user => user.Email).NotEmpty().EmailAddress();
            RuleFor(user => user.Password).NotEmpty();
        }
    }
}
