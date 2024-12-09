using FluentValidation;
using ToDo.API.Models;

namespace ToDo.API.Validators
{
    public class LoginUserModelValidator : AbstractValidator<LoginUserModel>
    {
        public LoginUserModelValidator()
        {
            RuleFor(x => x.UserName)
                .SetValidator(new UserNameValidator());

            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull();
        }
    }
}
