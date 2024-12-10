using FluentValidation;
using ToDo.API.Models;

namespace ToDo.API.Validators
{
    public class CreateCategoryModelValidator : AbstractValidator<CreateCategoryModel>
    {
        public CreateCategoryModelValidator()
        {
            RuleFor(x => x.CategoryName).SetValidator(new CategoryNameValidator());
        }
    }
}
