using FluentValidation;
using ToDo.Shared.Constants;

namespace ToDo.API.Validators
{
    public class PasswordValidator : AbstractValidator<string>
    {
        public PasswordValidator()
        {
            RuleFor(password => password)
                .NotEmpty()
                    .WithMessage(Messages.ERRO_PASSWORD_REQUERED)
                .MinimumLength(Limits.MIN_SIZE_PASSWORD)
                    .WithMessage(string.Format(Messages.ERRO_PASSWORD_SIZE_MIN, Limits.MIN_SIZE_PASSWORD))
                .MaximumLength(Limits.MAX_SIZE_PASSWORD)
                    .WithMessage(string.Format(Messages.ERRO_PASSWORD_SIZE_MAX, Limits.MAX_SIZE_PASSWORD))
                .Matches("[A-Z]")
                    .WithMessage(Messages.ERRO_PASSWORD_CHAR_UPPER)
                .Matches("[a-z]")
                    .WithMessage(Messages.ERRO_PASSWORD_CHAR_UPPER)
                .Matches("[0-9]")
                    .WithMessage(Messages.ERRO_PASSWORD_NUMBER)
                .Matches("[^a-zA-Z0-9]")
                    .WithMessage(Messages.ERRO_PASSWORD_CHAR_SPECIAL);
        }
    }

}
