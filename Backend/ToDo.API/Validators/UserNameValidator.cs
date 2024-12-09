using FluentValidation;
using ToDo.Shared.Constants;

namespace ToDo.API.Validators
{
    public class UserNameValidator : AbstractValidator<string>
    {
        public UserNameValidator()
        {
            RuleFor(userName => userName)
                .NotEmpty()
                .NotNull()
                .Length(Limits.MIN_SIZE_NAMEUSER, Limits.MAX_SIZE_NAMEUSER);
        }
    }
}
