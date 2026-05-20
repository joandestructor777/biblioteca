using Application.DTOs.CategoriesDTOs;
using FluentValidation;

namespace Application.Validators.Category
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryDTO>
    {
        public CreateCategoryValidator() 
        {
            RuleFor(category => category.Name)
                .NotEmpty()
                .WithMessage("El nombre de la categoria es obligatorio");

        }
    }
}
