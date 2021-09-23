using BuiltCode.Domain.Services.ParceiroService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace BuiltCode.Application.Attributes
{
    [AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiKeyAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue("x-api-key", out var extractedApiKey))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "ApiKey não encontrada"
                };
                return;
            }

            var _parceiroService = context.HttpContext.RequestServices.GetRequiredService<IParceiroService>();

            var parceiro = await _parceiroService.ObterPorApiKey(Guid.Parse(extractedApiKey));

            if (parceiro == null)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "ApyKey inválida"
                };
                return;
            }

            await next();
        }
    }
}
