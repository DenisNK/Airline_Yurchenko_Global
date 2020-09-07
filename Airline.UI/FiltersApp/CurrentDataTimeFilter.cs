using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Airline_Yurchenko.FiltersApp
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
