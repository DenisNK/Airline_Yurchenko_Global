using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Global_Logic_ASP.Core.FiltersApp
{
    public class CurrentDataTimeFilter : Attribute, IResourceFilter
    {
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            context.HttpContext.Response.Cookies.Append("LastVisit", DateTime.Now.ToString("dd/MM/yyyy hh-mm-ss"));
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
         
        }
    }
}
