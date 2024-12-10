using FluentValidation;
using ToDo.API.Models;
using ToDo.Shared.Constants;

namespace ToDo.API.Validators
{
    public class TodoCreateModelValidator : AbstractValidator<TodoCreateModel>
    {
        public TodoCreateModelValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .NotEmpty()
                .NotNull()
                .Length(Limits.MIN_SIZE_TITLE_TODO, Limits.MAX_SIZE_TITLE_TODO);

            RuleFor(x => x.Description)
                .NotNull()
                .MaximumLength(Limits.MAX_SIZE_DESCRIPTION_TODO);

            RuleFor(x => x.CategoryId)
                .SetValidator(new OptionalIdValidator());
        }
    }
}
