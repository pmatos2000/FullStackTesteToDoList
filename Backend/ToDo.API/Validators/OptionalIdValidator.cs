using FluentValidation;
using ToDo.Shared.Constants;

namespace ToDo.API.Validators
{
    public class OptionalIdValidator : AbstractValidator<long?>
    {
        public OptionalIdValidator()
        {
            RuleFor(x => x)
                .Must(id => !id.HasValue || id > 0)
                    .WithMessage(Messages.ERRO_OPTIONAL_ID);
        }
    }
}
