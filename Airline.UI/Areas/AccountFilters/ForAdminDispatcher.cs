using Microsoft.AspNetCore.Mvc.Filters;
using System;
using Microsoft.AspNetCore.Mvc;
using static Airline.DAL.Initializator.Constants;

namespace Airline_Yurchenko.Areas.AccountFilters
{
    public class ForAdminDispatcher : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.User.IsInRole(DISPATCHER) || context.HttpContext.User.IsInRole(ADMIN)) return;
            context.Result = new ForbidResult();
        }
    }
    public class ForAdminDispatcherAttribute : Attribute, IFilterFactory
    {
        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider) =>
            new ForAdminDispatcher();

        public bool IsReusable => false;
    }
}
