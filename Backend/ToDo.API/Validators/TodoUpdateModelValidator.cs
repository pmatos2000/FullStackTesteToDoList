using FluentValidation;
using ToDo.API.Models;

namespace ToDo.API.Validators
{
    public class TodoUpdateModelValidator : AbstractValidator<TodoUpdateModel>
    {
        public TodoUpdateModelValidator()
        {
            RuleFor(x => x)
                .SetValidator(new TodoCreateModelValidator());

            RuleFor(x => x.Id)
                .GreaterThan(0);
        }
    }
}
