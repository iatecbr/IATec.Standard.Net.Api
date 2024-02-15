using Domain.Model.AreaAggregate;
using FluentValidation;

namespace Domain.Validator;

public class AreaValidator : AbstractValidator<Area>
{
    public AreaValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(150);
        
        RuleFor(x => x.Manager)
            .NotEmpty()
            .MaximumLength(255);
    }
}