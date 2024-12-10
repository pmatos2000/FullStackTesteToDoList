using FluentValidation;
using ToDo.Shared.Constants;

namespace ToDo.API.Validators
{
    public class CategoryNameValidator : AbstractValidator<string>
    {
        public CategoryNameValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .NotNull()
                .Length(Limits.MIN_SIZE_CATEGORY, Limits.MAX_SIZE_CATEGORY);
        }
    }
}
