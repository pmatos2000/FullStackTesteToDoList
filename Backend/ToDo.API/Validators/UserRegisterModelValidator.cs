using FluentValidation;
using ToDo.API.Models;

namespace ToDo.API.Validators
{
    public class UserRegisterModelValidator : AbstractValidator<UserRegisterModel>
    {
        public UserRegisterModelValidator()
        {
            RuleFor(x => x.UserName)
                .SetValidator(new UserNameValidator());

            RuleFor(x => x.Password)
                .SetValidator(new PasswordValidator());
        }
    }
}
