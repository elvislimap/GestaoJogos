using System.Linq;
using GestaoJogos.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GestaoJogos.Presentation.Site.Filters
{
    public class AuthorizeActionFilter : IActionFilter
    {
        private readonly ISecurityService _securityService;

        public AuthorizeActionFilter(ISecurityService securityService)
        {
            _securityService = securityService;
        }


        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!(context.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var isAllowAnonymous =
                controllerActionDescriptor.MethodInfo.GetCustomAttributes(typeof(AllowAnonymousAttribute), false)
                    .Any() || controllerActionDescriptor.ControllerTypeInfo
                    .GetCustomAttributes(typeof(AllowAnonymousAttribute), false).Any();

            if (isAllowAnonymous) return;

            var headers = context.HttpContext.Request.Headers;
            var headerAuthorization = headers.FirstOrDefault(h => h.Key == "Authorization");
            var authorization = headerAuthorization.Value.ToString();

            if (string.IsNullOrEmpty(authorization))
                authorization = $"Bearer {context.HttpContext.Request.Cookies["token"]}";

            if (!_securityService.ValidateToken(authorization))
                context.Result = new UnauthorizedResult();
        }
    }
}
