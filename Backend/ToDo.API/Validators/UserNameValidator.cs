using FluentValidation;
using ToDo.API.Models;
using ToDo.Shared.Constants;

namespace ToDo.API.Validators
{
    public class UserNameValidator : AbstractValidator<UserNameModel>
    {
        public UserNameValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .NotNull()
                .Length(Limits.MIN_SIZE_NAMEUSER, Limits.MAX_SIZE_NAMEUSER);
        }
    }
}
