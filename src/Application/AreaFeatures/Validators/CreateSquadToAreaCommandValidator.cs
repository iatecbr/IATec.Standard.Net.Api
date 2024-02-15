using Application.AreaFeatures.Commands;
using FluentValidation;

namespace Application.AreaFeatures.Validators;

public class CreateSquadToAreaCommandValidator : AbstractValidator<AddSquadToAreaCommand>
{
    public CreateSquadToAreaCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(150);
    }
}