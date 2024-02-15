using Domain.Model.AreaAggregate;
using FluentValidation;

namespace Domain.Validator;

public class SquadValidator : AbstractValidator<Squad>
{
    public SquadValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(150);
    }
}