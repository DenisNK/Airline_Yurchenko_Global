using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using static Airline.DAL.Initializator.Constants;

namespace Airline_Yurchenko.Areas.AccountFilters
{
    public class ForAdminFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.IsInRole(ADMIN))
            {
                context.Result = new ForbidResult();
            }
        }
    }
    public class ForAdminAttribute : Attribute, IFilterFactory
    {
        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider) =>
            new ForAdminFilter();

        public bool IsReusable => false;
    }
}
