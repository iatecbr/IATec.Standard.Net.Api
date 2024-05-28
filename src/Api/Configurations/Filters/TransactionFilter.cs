using Domain.Contracts.Transactions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Configurations.Filters;

public class TransactionFilter(ITransaction transaction) : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        transaction.BeginTransaction();
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Exception != null || !context.ModelState.IsValid || context.Result is BadRequestObjectResult)
            transaction.RollbackTransaction();
        else
            transaction.CommitTransaction();
    }
}