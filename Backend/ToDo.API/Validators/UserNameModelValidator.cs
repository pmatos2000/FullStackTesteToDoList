using FluentValidation;
using ToDo.API.Models;

namespace ToDo.API.Validators
{
    public class UserNameModelValidator : AbstractValidator<UserNameModel>
    {
        public UserNameModelValidator()
        {
            RuleFor(x => x.UserName)
                .SetValidator(new UserNameValidator());
        }
    }
}
