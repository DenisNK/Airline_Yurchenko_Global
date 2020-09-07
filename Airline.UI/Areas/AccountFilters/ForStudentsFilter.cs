using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using static Airline.DAL.Initializator.Constants;
namespace Airline_Yurchenko.Areas.AccountFilters
{
    public class ForStudentsFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.IsInRole(STUDENT))
            {
                context.Result = new ForbidResult();
            }
        }
    }
    public class ForStudentAttribute : Attribute, IFilterFactory
    {
        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider) =>
            new ForStudentsFilter();

        public bool IsReusable => false;
    }
}