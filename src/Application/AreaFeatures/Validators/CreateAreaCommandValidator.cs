using Application.AreaFeatures.Commands;
using FluentValidation;

namespace Application.AreaFeatures.Validators;

public class CreateAreaCommandValidator : AbstractValidator<CreateAreaCommand>
{
    public CreateAreaCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(150);
        
        RuleFor(x => x.Manager)
            .NotEmpty()
            .MaximumLength(255);
    }
}