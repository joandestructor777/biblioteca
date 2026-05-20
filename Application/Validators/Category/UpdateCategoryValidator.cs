using Application.DTOs.CategoriesDTOs;
using FluentValidation;

namespace Application.Validators.Category
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryDTO>
    {
        public UpdateCategoryValidator() 
        {
            RuleFor(category => category.Name)
                .NotEmpty()
                .WithMessage("El nombre de la categoria es obligatorio");
        }
    }
}
