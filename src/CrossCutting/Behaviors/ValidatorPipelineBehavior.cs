using Domain.Shared;
using FluentValidation;
using MediatR;

namespace CrossCutting.Behaviors;

public class ValidatorPipelineBehavior<TRequest, TResponse>
    (IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : Response
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

        var result = BuildResponse<TResponse>(errorList);
        return result;
    }
    
    private static TResult BuildResponse<TResult>(List<string> errors)
        where TResult : Response
    {
        var validation = typeof(Response<>)
            .GetGenericTypeDefinition()
            .MakeGenericType(typeof(TResult).GenericTypeArguments[0])
            .GetMethod(nameof(Response.Failed))!
            .Invoke(null, [errors])!;

        return (TResult)validation;
    }
}