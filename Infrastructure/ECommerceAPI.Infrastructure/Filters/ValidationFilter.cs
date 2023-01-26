using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ECommerceAPI.Infrastructure.Filters;

public class ValidationFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        //Filter ile error mesajlarını alıp geriye döndürüyoruz.
        if (!context.ModelState.IsValid)
        {
            var errors = context.ModelState
                .Where(x => x.Value.Errors.Any())
                .ToDictionary(e => e.Key,
                    e => e.Value.Errors.Select(e => e.ErrorMessage))
                .ToArray();
            context.Result = new BadRequestObjectResult(errors);
            return;
        }

        await next();
    }
}