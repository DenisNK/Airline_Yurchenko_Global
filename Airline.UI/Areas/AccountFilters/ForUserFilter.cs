using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using static Airline.DAL.Initializator.Constants;
namespace Airline_Yurchenko.Areas.AccountFilters
{
    public class ForUserFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.IsInRole(USER))
            {
                context.Result = new ForbidResult();
            }
        }
    }
    public class ForUserAttribute : Attribute, IFilterFactory
    {
        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider) =>
            new ForUserFilter();

        public bool IsReusable => false;
    }
}