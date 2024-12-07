using FluentValidation;
using ToDo.API.Models;
using ToDo.Shared.Constants;

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
