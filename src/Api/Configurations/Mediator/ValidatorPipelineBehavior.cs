using Domain.Contracts.Notifier;
using FluentValidation;
using MediatR;

namespace Api.Configurations.Mediator;

public class ValidatorPipelineBehavior<TRequest, TResponse>
    (IEnumerable<IValidator<TRequest>> validators, INotifierMessage notifierMessage) : 
        IPipelineBehavior<TRequest, TResponse> 
    where TRequest : IRequest<TResponse>
{
    
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, 
        CancellationToken cancellationToken)
    {
        if (!validators.Any())
        {
            return await next();
        }

        var errorList = validators
            .Select(validator => validator.Validate(request))
            .SelectMany(validatorResult => validatorResult.Errors)
            .Where(validatorFailure => validatorFailure is not null)
            .Select(failure => failure.ErrorMessage)
            .Distinct()
            .ToList();


        if (errorList.Count <= 0) 
            return await next();
        
        notifierMessage.AddRange(errorList);
        return await next();
    }
}