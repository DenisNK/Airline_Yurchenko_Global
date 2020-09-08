using Microsoft.AspNetCore.Mvc.Filters;
using System;
using Microsoft.AspNetCore.Mvc;
using static Airline.DAL.Initializator.Constants;

namespace Airline_Yurchenko.Areas.AccountFilters
{
    public class ForAdminStudent : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.User.IsInRole(STUDENT)|| context.HttpContext.User.IsInRole(ADMIN)) return;
            context.Result = new ForbidResult();
        }
    }
    public class ForAdminStudentAttribute : Attribute, IFilterFactory
    {
        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider) =>
            new ForAdminStudent();

        public bool IsReusable => false;
    }
}
